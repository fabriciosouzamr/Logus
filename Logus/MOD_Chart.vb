Imports Infragistics.Win
Imports Infragistics.Excel
Imports Infragistics.Win.UltraWinChart
Imports System.Diagnostics
Imports System
Imports Infragistics.UltraChart.Resources

Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Infragistics.UltraChart.Core
Imports Infragistics.UltraChart.Core.Primitives
Imports Infragistics.UltraChart.Resources.Appearance
Imports Infragistics.UltraChart.Shared.Styles

Module MOD_Chart
    Const cnt_Menu_Item_Dados As String = "Dados"
    Const cnt_Menu_Item_TipoChart As String = "TipoChart"
    Const cnt_Menu_Item_ImprimirChart As String = "ImprimirChart"
    Const cnt_Menu_Item_Salvar_JPEG As String = "Salvar_JPEG"
    Const cnt_Menu_Item_EnviarEmail As String = "Enviar_Email"
    Const cnt_Menu_Item_AlterarLinhaColuna As String = "AlterarLinhaColuna"
    Const cnt_Menu_Item_AtivarCrossHair As String = "AtivarCrossHair"
    Const cnt_Menu_Item_ExibirLegenda As String = "ExibirLegenda"
    Const cnt_Menu_Item_Propriedade As String = "Propriedades"
    Const cnt_Menu_Item_TextoChart As String = "TextoChart"

    Event Menu_Clique(ByRef oChart As UltraChart)

    Public WithEvents oMenuChart As New System.Windows.Forms.ContextMenuStrip
    Dim oChart_Ctrl As UltraChart
    Dim iMenu_AtivarCrossHair As Integer

    Public Sub objChart_Formatar(ByVal oChart As UltraChart, _
                                 Optional ByVal TipoChart As ChartType = ChartType.CylinderColumnChart3D, _
                                 Optional ByVal bExibirLegenda As Boolean = False)
        oChart_Ctrl = oChart

        oChart.Hide()
        oChart.EnableCrossHair = True
        oChart.Legend.Visible = bExibirLegenda
        oChart.TitleLeft.HorizontalAlign = StringAlignment.Center
        oChart.TitleRight.HorizontalAlign = StringAlignment.Center
        oChart.TitleTop.HorizontalAlign = StringAlignment.Center
        oChart.TitleBottom.HorizontalAlign = StringAlignment.Center
        oChart.ChartType = TipoChart

        oMenuChart = New System.Windows.Forms.ContextMenuStrip
        Menu_Item_Add(cnt_Menu_Item_Dados, "Dados do Gráficos", oMenuChart)
        Menu_Item_Add(cnt_Menu_Item_TipoChart, "Tipo do Chart", oMenuChart)
        Menu_Adicionar_Separador(oMenuChart)
        Menu_Item_Add(cnt_Menu_Item_Salvar_JPEG, "Salvar no Computador", oMenuChart)
        Menu_Item_Add(cnt_Menu_Item_EnviarEmail, "Enviar por E-mail", oMenuChart)
        Menu_Adicionar_Separador(oMenuChart)
        Menu_Item_Add(cnt_Menu_Item_ImprimirChart, "Imprimir Chart", oMenuChart)
        Menu_Adicionar_Separador(oMenuChart)
        Menu_Item_Add(cnt_Menu_Item_AlterarLinhaColuna, "Alterar Linha e Colunas", oMenuChart)
        Menu_Item_Add(cnt_Menu_Item_AtivarCrossHair, "Ativar 'CrossHair'", oMenuChart)
        Menu_Item_Add(cnt_Menu_Item_ExibirLegenda, "Exibir Legenda", oMenuChart)
        Menu_Adicionar_Separador(oMenuChart)
        Menu_Item_Add(cnt_Menu_Item_TextoChart, "Texto do Chart", oMenuChart)
        'Menu_Item_Add(cnt_Menu_Item_Propriedade, "Propriedades")

        VerificarItemCheck()

        oChart.ContextMenuStrip = oMenuChart

        Dim labelHash As New Hashtable()
        labelHash.Add("DESCRICAO", New CustomTooltip())
        oChart.LabelHash = labelHash

        oChart.Tooltips.Format = Infragistics.UltraChart.Shared.Styles.TooltipStyle.Custom
        oChart.Tooltips.FormatString = "<DESCRICAO>"
    End Sub

    Private Sub VerificarItemCheck()
        Menu_Item_Checked(cnt_Menu_Item_AlterarLinhaColuna, oChart_Ctrl.Data.SwapRowsAndColumns)
        Menu_Item_Checked(cnt_Menu_Item_AtivarCrossHair, oChart_Ctrl.EnableCrossHair)
        Menu_Item_Checked(cnt_Menu_Item_ExibirLegenda, oChart_Ctrl.Legend.Visible)
    End Sub

    Public Function objChart_Carregar(ByVal oChart As UltraChart, _
                                      ByVal SqlText As String) As Boolean
        Dim oDS As New UltraWinDataSource.UltraDataSource
        Dim oData As New System.Data.DataTable

        oData = DBQuery(SqlText)

        If DBContemErro() Then
            oData = Nothing
            Return False
        End If

        oChart.DataSource = Nothing
        oChart.DataSource = oData

        If objDataTable_Vazio(oData) Then
            Msg_Mensagem("Essa consulta não retornou nenhum registro")

            oChart.Hide()
        Else
            oChart.Show()
        End If

        Return True
    End Function

    Private Sub oMenu_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles oMenuChart.ItemClicked
        Select Case e.ClickedItem.Name
            Case cnt_Menu_Item_Dados
                Dim oForm As New frmChart_Dados

                oForm.Form_Carregar(oChart_Ctrl)

                Form_Show(frmMDI, oForm, True)

                oForm.Dispose()
                oForm = Nothing
            Case cnt_Menu_Item_TipoChart
                Dim oForm As New frmChart_SelecionarChart

                oForm.Form_Carregar(oChart_Ctrl)

                Form_Show(frmMDI, oForm, True)

                oForm.Dispose()
                oForm = Nothing

                Menu_Item_Checked(cnt_Menu_Item_AtivarCrossHair, oChart_Ctrl.EnableCrossHair)
            Case cnt_Menu_Item_ImprimirChart
                Chart_Imprimir()
            Case cnt_Menu_Item_Salvar_JPEG
                Chart_Salvar("JPEG")
            Case cnt_Menu_Item_EnviarEmail
                Chart_Salvar("JPEG", , True)
            Case cnt_Menu_Item_AlterarLinhaColuna
                Dim oItem As ToolStripMenuItem

                oItem = e.ClickedItem
                oItem.Checked = (Not oItem.Checked)

                oChart_Ctrl.Data.SwapRowsAndColumns = oItem.Checked
            Case cnt_Menu_Item_AtivarCrossHair
                Dim oItem As ToolStripMenuItem

                oItem = e.ClickedItem
                oItem.Checked = (Not oItem.Checked)

                oChart_Ctrl.EnableCrossHair = oItem.Checked
            Case cnt_Menu_Item_ExibirLegenda
                Dim oItem As ToolStripMenuItem

                oItem = e.ClickedItem
                oItem.Checked = (Not oItem.Checked)

                oChart_Ctrl.Legend.Visible = oItem.Checked
            Case cnt_Menu_Item_Propriedade
                Dim oForm As New frmChart_Propriedade

                oForm.Form_Carregar(oChart_Ctrl)
                'oForm.StartPosition = FormStartPosition.Manual


                Form_Show(frmMDI, oForm, True)

                oForm.Dispose()
                oForm = Nothing
            Case cnt_Menu_Item_TextoChart
                Dim oForm As New frmChart_Texto

                oForm.Form_Carregar(oChart_Ctrl)

                Form_Show(frmMDI, oForm, True)

                oForm.Dispose()
                oForm = Nothing
        End Select

        oChart_Ctrl.Refresh()
    End Sub



    Private Sub Chart_Imprimir()
        Dim oPrintPreviewDialog As New Infragistics.Win.Printing.UltraPrintPreviewDialog

        With oPrintPreviewDialog
            .Document = oChart_Ctrl.PrintDocument
            .ShowDialog()
            .Dispose()
        End With

        oPrintPreviewDialog = Nothing
    End Sub

    Private Sub Chart_Salvar(ByVal Tipo As String, Optional ByVal bTransparente As Boolean = False, Optional ByVal bEnviarEmail As Boolean = False)
        Dim SaveFileDialog As New System.Windows.Forms.SaveFileDialog
        Dim ExportPath As String
        Dim sArquivo As String
        Dim ps As New ProcessStartInfo

        oMenuChart.Hide()


        If bEnviarEmail Then
            ExportPath = My.Computer.FileSystem.SpecialDirectories.Temp + "\Exported\"

            If System.IO.Directory.Exists(ExportPath) = False Then
                System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\Exported\")
            End If

            sArquivo = "Arquivo"

            frmUserDialogo_Texto.Carregar("Exportação de Gráfico", "Informe o nome do arquivo")

            If frmUserDialogo_Texto.Cancelado Then
                Exit Sub
            Else
                sArquivo = frmUserDialogo_Texto.Texto
            End If

            frmUserDialogo_Texto.Dispose()

            sArquivo = sArquivo & "." & Tipo

            sArquivo = ExportPath + sArquivo

            If Dir(sArquivo) <> "" Then
                Kill(sArquivo)
            End If
        Else
            SaveFileDialog.FileName = "Chart." + Tipo
            SaveFileDialog.Filter = Tipo + " (*." + Tipo.ToLower() + ")|*." + Tipo.ToLower()

            If SaveFileDialog.ShowDialog() = DialogResult.OK Then
                sArquivo = SaveFileDialog.FileName
            Else
                Exit Sub
            End If
        End If

        Dim myBm As System.Drawing.Bitmap = CType(oChart_Ctrl.Image.Clone, Bitmap)

        If bTransparente Then
            myBm.MakeTransparent(System.Drawing.Color.White)
        End If

        Select Case UCase(Tipo)
            Case "GIF"
                myBm.Save(sArquivo, System.Drawing.Imaging.ImageFormat.Gif)
            Case "JPEG"
                myBm.Save(sArquivo, System.Drawing.Imaging.ImageFormat.Jpeg)
            Case "BMP"
                myBm.Save(sArquivo, System.Drawing.Imaging.ImageFormat.Bmp)
            Case "PNG"
                myBm.Save(sArquivo, System.Drawing.Imaging.ImageFormat.Png)
        End Select

        If bEnviarEmail Then
            EMail_Enviar(cnt_EmailExportacaoRelatorio, _
                         sUsuario_EMail, _
                         "Exportação de Gráfico", "", _
                         False, _
                         cnt_EMail_Servidor_SMTP, _
                         Net.Mail.MailPriority.Normal, _
                         New String() {sArquivo})
            Msg_Mensagem("Gráfico enviada para o seu e-mail")
        Else
            If Msg_Perguntar("Deseja abrir o Gráfico exportado?") Then
                ps.UseShellExecute = True
                ps.FileName = sArquivo
                Process.Start(ps)
            End If
        End If
    End Sub

    Private Sub Menu_Item_Checked(ByVal NomeItem As String, ByVal bChecked As Boolean)
        Dim oMenuItem As ToolStripMenuItem
        Dim iCont As Integer

        For iCont = 0 To oMenuChart.Items.Count - 1
            If TypeName(oMenuChart.Items(iCont)) = "ToolStripMenuItem" Then
                oMenuItem = oMenuChart.Items(iCont)

                If oMenuItem.Name = NomeItem Then
                    oMenuItem.Checked = bChecked
                End If
            End If
        Next
    End Sub



    Public Sub Chart_AjustarDimensao(ByVal oChart As UltraChart, ByVal oTamanho As System.Drawing.Size)
        oChart.Height = oTamanho.Height - oChart.Top - 10
        oChart.Width = oTamanho.Width - oChart.Left - 10
    End Sub

    Public Class CustomTooltip
        Implements IRenderLabel

        Public Sub New()

        End Sub 'New

        Public Overloads Function ToString(ByVal Context As System.Collections.Hashtable) As String Implements IRenderLabel.ToString
            'Dim dataValue As Double = System.Convert.ToDouble(Context("DATA_VALUE"))
            'If dataValue > 75 Then
            '    Return dataValue.ToString() + "[Very High]"
            'ElseIf dataValue > 50 Then
            '    Return dataValue.ToString() + "[High]"
            'ElseIf dataValue > 25 Then
            '    Return dataValue.ToString() + "[Medium]"
            'ElseIf dataValue >= 0 Then
            '    Return dataValue.ToString() + "[Low]"
            'Else
            '    Return dataValue.ToString() + "[Negative]"
            'End If
            Return Context("ITEM_LABEL") + " - " + Context("DATA_VALUE").ToString + " - " + Context("SERIES_LABEL")
        End Function 'ToString 
    End Class 'MyCustomTooltip

    Public Class MyCustomAnnotation
        Implements IAnnotation

        '/ <summary>
        '/ Constructor
        '/ </summary>
        Public Sub New()
            ' instantiate objects with their default values
            Me.Location = New Location()
            Me.TextStyle = New LabelStyle()
            Me.LineStyle = New LineStyle()
            Me.LineThickness = 4
            Me.LineColor = Color.CornflowerBlue
            Me.Height = -1
            Me.Width = -1
            Me.PE = New PaintElement(Color.Orange)
            Me.PE.ElementType = PaintElementType.Texture
            Me.PE.Texture = TexturePresets.GrainA
            Me.Text = "Default Text"
        End Sub 'New

        '/ <summary>
        '/ This method renders different annotations.
        '/ </summary>
        '/ <param name="scene">Collection class for Primitives.</param>
        '/ <param name="renderPoint">Position of an annotation.</param>
        Public Overloads Sub RenderAnnotation(ByVal scene As SceneGraph, ByVal renderPoint As Point) Implements IAnnotation.RenderAnnotation
            Dim starSize As Size = Me.GetStarSize()

            renderPoint.X = 50
            renderPoint.Y = 10
            Dim height As Integer = starSize.Height
            Dim width As Integer = starSize.Width

            Dim xCoords As Point
            Dim yCoords As Point
            xCoords.X = 0 * width / 10 + renderPoint.X
            xCoords.Y = 1 * width / 10 + renderPoint.Y
            yCoords.X = 5 * width / 10 + renderPoint.X
            yCoords.Y = 1 * width / 10 + renderPoint.Y
            Dim arrow As New Line(xCoords, yCoords)

            ' Set visual attributes.
            arrow.PE = Me.PE

            arrow.lineStyle = Me.LineStyle
            arrow.PE.StrokeWidth = Me.LineThickness
            arrow.PE.Stroke = Me.LineColor
            arrow.PE.StrokeOpacity = Me.LineColor.A
            scene.Add(arrow)
        End Sub 'RenderAnnotation

        '/ <summary>
        '/ This method renders different annotations.
        '/ </summary>
        '/ <param name="scene">Collection class for Primitives.</param>
        '/ <param name="renderPoint">Position of an annotation.</param>
        Public Overloads Sub RenderAnnotation(ByVal scene As SceneGraph, ByVal parent As Primitive) Implements IAnnotation.RenderAnnotation
            ' Gets a point for rendering an annotation upon the specified parent primitive. 
            Dim renderPoint As Point = Annotation.GetRenderPointFromParent(parent)

            ' Render Annotation
            Me.RenderAnnotation(scene, renderPoint)

        End Sub 'RenderAnnotation

        '/ <summary>
        '/ Location of the annotation.
        '/ </summary>
        Private _location As Location

        '/ <summary>
        '/ Sets or Gets a location of the annotation.
        '/ </summary>

        Public Overloads Property Location() As Location Implements IAnnotation.Location
            Get
                Return Me._location
            End Get
            Set(ByVal Value As Location)
                Me._location = Value
            End Set
        End Property

#Region "Public Properties"

        Private _height As Integer

        Public Property Height() As Integer
            Get
                Return Me._height
            End Get
            Set(ByVal Value As Integer)
                Me._height = Value
            End Set
        End Property
        Private _width As Integer

        Public Property Width() As Integer
            Get
                Return Me._width
            End Get
            Set(ByVal Value As Integer)
                Me._width = Value
            End Set
        End Property
        Private _text As String

        Public Property [Text]() As String
            Get
                Return Me._text
            End Get
            Set(ByVal Value As String)
                Me._text = Value
            End Set
        End Property
        Private _textStyle As LabelStyle

        Public Property TextStyle() As LabelStyle
            Get
                Return Me._textStyle
            End Get
            Set(ByVal Value As LabelStyle)
                Me._textStyle = Value
            End Set
        End Property

        Public Property FillColor() As Color
            Get
                Return Me.PE.Fill
            End Get
            Set(ByVal Value As Color)
                Me.PE.Fill = Value
            End Set
        End Property
        Private _pE As PaintElement

        Public Property PE() As PaintElement
            Get
                Return Me._pE
            End Get
            Set(ByVal Value As PaintElement)
                Me._pE = Value
            End Set
        End Property
        Private _lineStyle As LineStyle

        <TypeConverter(GetType(ExpandableObjectConverter))> _
        Public Property LineStyle() As LineStyle
            Get
                Return Me._lineStyle
            End Get
            Set(ByVal Value As LineStyle)
                Me._lineStyle = Value
            End Set
        End Property
        Private _lineThickness As Integer

        Public Property LineThickness() As Integer
            Get
                Return Me._lineThickness
            End Get
            Set(ByVal Value As Integer)
                Me._lineThickness = Value
            End Set
        End Property
        Private _lineColor As Color

        Public Property LineColor() As Color
            Get
                Return Me._lineColor
            End Get
            Set(ByVal Value As Color)
                Me._lineColor = Value
            End Set
        End Property
#End Region

#Region "Helper Functions"


        '/ <summary>
        '/ Calculates the size of the star.
        '/ </summary>
        '/ <returns>Size of the star</returns>
        Private Function GetStarSize() As Size
            Dim inflation As Double = 2
            Dim starHeight, starWidth As Integer
            Dim textSize As SizeF
            If Not (Me.TextStyle Is Nothing) Then
                textSize = Infragistics.UltraChart.Core.Util.Platform.GetStringSizePixels(Me.Text, Me.TextStyle.Font)
                ' TextStyle should really not be null, but just in case it is, measure the string using Arial 12pt.
            Else
                textSize = Infragistics.UltraChart.Core.Util.Platform.GetStringSizePixels(Me.Text, New Font("Arial", 12))
            End If
            If Me.Height < 0 Then
                starHeight = Fix(textSize.Height * inflation)
            Else
                starHeight = Me.Height
            End If
            If Me.Width < 0 Then
                starWidth = Fix(textSize.Width * inflation)
            Else
                starWidth = Me.Width
            End If
            Return New Size(starWidth, starHeight)

        End Function 'GetStarSize

#End Region
    End Class 'MyCustomAnnotation

    Private Sub oMenu_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles oMenuChart.Opening
        VerificarItemCheck()
    End Sub
End Module