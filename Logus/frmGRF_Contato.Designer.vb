<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGRF_Contato
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim PaintElement1 As Infragistics.UltraChart.Resources.Appearance.PaintElement = New Infragistics.UltraChart.Resources.Appearance.PaintElement
        Dim StrokeEffect1 As Infragistics.UltraChart.Resources.Appearance.StrokeEffect = New Infragistics.UltraChart.Resources.Appearance.StrokeEffect
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboUsuario = New System.Windows.Forms.ComboBox
        Me.cboFilial = New System.Windows.Forms.ComboBox
        Me.cmdFechar_Grafico = New Infragistics.Win.Misc.UltraButton
        Me.optGrupamento = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.txtdt_escala_fim = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.cmdPesquisar = New Infragistics.Win.Misc.UltraButton
        Me.txtdt_escala_ini = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboTipoContato = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.grfGeral = New Infragistics.Win.UltraWinChart.UltraChart
        CType(Me.optGrupamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtdt_escala_fim, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtdt_escala_ini, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grfGeral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(220, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 191
        Me.Label1.Text = "Usuário"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(321, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 189
        Me.Label2.Text = "Filial"
        '
        'cboUsuario
        '
        Me.cboUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUsuario.Location = New System.Drawing.Point(223, 71)
        Me.cboUsuario.Name = "cboUsuario"
        Me.cboUsuario.Size = New System.Drawing.Size(241, 21)
        Me.cboUsuario.TabIndex = 190
        '
        'cboFilial
        '
        Me.cboFilial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilial.Location = New System.Drawing.Point(321, 21)
        Me.cboFilial.Name = "cboFilial"
        Me.cboFilial.Size = New System.Drawing.Size(143, 21)
        Me.cboFilial.TabIndex = 188
        '
        'cmdFechar_Grafico
        '
        Me.cmdFechar_Grafico.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar_Grafico.Location = New System.Drawing.Point(526, 5)
        Me.cmdFechar_Grafico.Name = "cmdFechar_Grafico"
        Me.cmdFechar_Grafico.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar_Grafico.TabIndex = 187
        Me.cmdFechar_Grafico.Text = "F"
        '
        'optGrupamento
        '
        ValueListItem1.DataValue = Global.Microsoft.VisualBasic.ChrW(70)
        ValueListItem1.DisplayText = "Filial"
        ValueListItem2.DataValue = Global.Microsoft.VisualBasic.ChrW(85)
        ValueListItem2.DisplayText = "Usuário"
        ValueListItem3.DataValue = Global.Microsoft.VisualBasic.ChrW(84)
        ValueListItem3.DisplayText = "Tipo Contato"
        Me.optGrupamento.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem3})
        Me.optGrupamento.Location = New System.Drawing.Point(3, 5)
        Me.optGrupamento.Name = "optGrupamento"
        Me.optGrupamento.Size = New System.Drawing.Size(154, 37)
        Me.optGrupamento.TabIndex = 192
        '
        'txtdt_escala_fim
        '
        Me.txtdt_escala_fim.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtdt_escala_fim.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.OfficeXP
        Me.txtdt_escala_fim.Location = New System.Drawing.Point(113, 71)
        Me.txtdt_escala_fim.Name = "txtdt_escala_fim"
        Me.txtdt_escala_fim.Size = New System.Drawing.Size(104, 21)
        Me.txtdt_escala_fim.TabIndex = 183
        Me.txtdt_escala_fim.Value = Nothing
        '
        'cmdPesquisar
        '
        Me.cmdPesquisar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdPesquisar.Location = New System.Drawing.Point(475, 5)
        Me.cmdPesquisar.Name = "cmdPesquisar"
        Me.cmdPesquisar.Size = New System.Drawing.Size(45, 45)
        Me.cmdPesquisar.TabIndex = 185
        Me.cmdPesquisar.Text = "P"
        '
        'txtdt_escala_ini
        '
        Me.txtdt_escala_ini.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtdt_escala_ini.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.OfficeXP
        Me.txtdt_escala_ini.Location = New System.Drawing.Point(3, 71)
        Me.txtdt_escala_ini.Name = "txtdt_escala_ini"
        Me.txtdt_escala_ini.Size = New System.Drawing.Size(104, 21)
        Me.txtdt_escala_ini.TabIndex = 182
        Me.txtdt_escala_ini.Value = Nothing
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(3, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 17)
        Me.Label6.TabIndex = 181
        Me.Label6.Text = "Data Inicial"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(113, 55)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 18)
        Me.Label8.TabIndex = 184
        Me.Label8.Text = "Data Final"
        '
        'cboTipoContato
        '
        Me.cboTipoContato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoContato.Location = New System.Drawing.Point(163, 21)
        Me.cboTipoContato.Name = "cboTipoContato"
        Me.cboTipoContato.Size = New System.Drawing.Size(152, 21)
        Me.cboTipoContato.TabIndex = 179
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(163, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 180
        Me.Label3.Text = "Tipo Contato"
        '
        '			'UltraChart' properties's serialization: Since 'ChartType' changes the way axes look,
        '			'ChartType' must be persisted ahead of any Axes change made in design time.
        '		
        Me.grfGeral.ChartType = Infragistics.UltraChart.[Shared].Styles.ChartType.BarChart3D
        '
        'grfGeral
        '
        Me.grfGeral.Axis.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(220, Byte), Integer))
        PaintElement1.ElementType = Infragistics.UltraChart.[Shared].Styles.PaintElementType.None
        PaintElement1.Fill = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.grfGeral.Axis.PE = PaintElement1
        Me.grfGeral.Axis.X.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.grfGeral.Axis.X.Labels.FontColor = System.Drawing.Color.DimGray
        Me.grfGeral.Axis.X.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.grfGeral.Axis.X.Labels.ItemFormatString = "<DATA_VALUE:00.##>"
        Me.grfGeral.Axis.X.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.grfGeral.Axis.X.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.VerticalLeftFacing
        Me.grfGeral.Axis.X.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.grfGeral.Axis.X.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray
        Me.grfGeral.Axis.X.Labels.SeriesLabels.FormatString = ""
        Me.grfGeral.Axis.X.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.grfGeral.Axis.X.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.grfGeral.Axis.X.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.VerticalLeftFacing
        Me.grfGeral.Axis.X.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.grfGeral.Axis.X.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.grfGeral.Axis.X.LineThickness = 1
        Me.grfGeral.Axis.X.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.grfGeral.Axis.X.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.grfGeral.Axis.X.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.grfGeral.Axis.X.MajorGridLines.Visible = True
        Me.grfGeral.Axis.X.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.grfGeral.Axis.X.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.grfGeral.Axis.X.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.grfGeral.Axis.X.MinorGridLines.Visible = False
        Me.grfGeral.Axis.X.TickmarkIntervalType = Infragistics.UltraChart.[Shared].Styles.AxisIntervalType.Hours
        Me.grfGeral.Axis.X.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.grfGeral.Axis.X.Visible = True
        Me.grfGeral.Axis.X2.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.grfGeral.Axis.X2.Labels.FontColor = System.Drawing.Color.Gray
        Me.grfGeral.Axis.X2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far
        Me.grfGeral.Axis.X2.Labels.ItemFormatString = "<ITEM_LABEL>"
        Me.grfGeral.Axis.X2.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.grfGeral.Axis.X2.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.VerticalLeftFacing
        Me.grfGeral.Axis.X2.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.grfGeral.Axis.X2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray
        Me.grfGeral.Axis.X2.Labels.SeriesLabels.FormatString = ""
        Me.grfGeral.Axis.X2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Far
        Me.grfGeral.Axis.X2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.grfGeral.Axis.X2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.VerticalLeftFacing
        Me.grfGeral.Axis.X2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.grfGeral.Axis.X2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.grfGeral.Axis.X2.LineThickness = 1
        Me.grfGeral.Axis.X2.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.grfGeral.Axis.X2.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.grfGeral.Axis.X2.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.grfGeral.Axis.X2.MajorGridLines.Visible = True
        Me.grfGeral.Axis.X2.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.grfGeral.Axis.X2.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.grfGeral.Axis.X2.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.grfGeral.Axis.X2.MinorGridLines.Visible = False
        Me.grfGeral.Axis.X2.TickmarkIntervalType = Infragistics.UltraChart.[Shared].Styles.AxisIntervalType.Hours
        Me.grfGeral.Axis.X2.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.grfGeral.Axis.X2.Visible = True
        Me.grfGeral.Axis.Y.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.grfGeral.Axis.Y.Labels.FontColor = System.Drawing.Color.DimGray
        Me.grfGeral.Axis.Y.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far
        Me.grfGeral.Axis.Y.Labels.ItemFormatString = "<ITEM_LABEL>"
        Me.grfGeral.Axis.Y.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.grfGeral.Axis.Y.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.grfGeral.Axis.Y.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.grfGeral.Axis.Y.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray
        Me.grfGeral.Axis.Y.Labels.SeriesLabels.FormatString = ""
        Me.grfGeral.Axis.Y.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Far
        Me.grfGeral.Axis.Y.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.grfGeral.Axis.Y.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.grfGeral.Axis.Y.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.grfGeral.Axis.Y.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.grfGeral.Axis.Y.LineThickness = 1
        Me.grfGeral.Axis.Y.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.grfGeral.Axis.Y.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.grfGeral.Axis.Y.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.grfGeral.Axis.Y.MajorGridLines.Visible = True
        Me.grfGeral.Axis.Y.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.grfGeral.Axis.Y.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.grfGeral.Axis.Y.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.grfGeral.Axis.Y.MinorGridLines.Visible = False
        Me.grfGeral.Axis.Y.TickmarkInterval = 40
        Me.grfGeral.Axis.Y.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.grfGeral.Axis.Y.Visible = True
        Me.grfGeral.Axis.Y2.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.grfGeral.Axis.Y2.Labels.FontColor = System.Drawing.Color.Gray
        Me.grfGeral.Axis.Y2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.grfGeral.Axis.Y2.Labels.ItemFormatString = "<DATA_VALUE:00.##>"
        Me.grfGeral.Axis.Y2.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.grfGeral.Axis.Y2.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.grfGeral.Axis.Y2.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.grfGeral.Axis.Y2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray
        Me.grfGeral.Axis.Y2.Labels.SeriesLabels.FormatString = ""
        Me.grfGeral.Axis.Y2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.grfGeral.Axis.Y2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.grfGeral.Axis.Y2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.grfGeral.Axis.Y2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.grfGeral.Axis.Y2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.grfGeral.Axis.Y2.LineThickness = 1
        Me.grfGeral.Axis.Y2.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.grfGeral.Axis.Y2.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.grfGeral.Axis.Y2.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.grfGeral.Axis.Y2.MajorGridLines.Visible = True
        Me.grfGeral.Axis.Y2.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.grfGeral.Axis.Y2.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.grfGeral.Axis.Y2.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.grfGeral.Axis.Y2.MinorGridLines.Visible = False
        Me.grfGeral.Axis.Y2.TickmarkInterval = 40
        Me.grfGeral.Axis.Y2.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.grfGeral.Axis.Y2.Visible = True
        Me.grfGeral.Axis.Z.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.grfGeral.Axis.Z.Labels.FontColor = System.Drawing.Color.DimGray
        Me.grfGeral.Axis.Z.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far
        Me.grfGeral.Axis.Z.Labels.ItemFormatString = "<ITEM_LABEL>"
        Me.grfGeral.Axis.Z.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.grfGeral.Axis.Z.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.grfGeral.Axis.Z.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.grfGeral.Axis.Z.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray
        Me.grfGeral.Axis.Z.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Far
        Me.grfGeral.Axis.Z.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.grfGeral.Axis.Z.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.grfGeral.Axis.Z.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.grfGeral.Axis.Z.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.grfGeral.Axis.Z.LineThickness = 1
        Me.grfGeral.Axis.Z.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.grfGeral.Axis.Z.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.grfGeral.Axis.Z.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.grfGeral.Axis.Z.MajorGridLines.Visible = True
        Me.grfGeral.Axis.Z.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.grfGeral.Axis.Z.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.grfGeral.Axis.Z.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.grfGeral.Axis.Z.MinorGridLines.Visible = False
        Me.grfGeral.Axis.Z.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.grfGeral.Axis.Z.Visible = True
        Me.grfGeral.Axis.Z2.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.grfGeral.Axis.Z2.Labels.FontColor = System.Drawing.Color.Gray
        Me.grfGeral.Axis.Z2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.grfGeral.Axis.Z2.Labels.ItemFormatString = ""
        Me.grfGeral.Axis.Z2.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.grfGeral.Axis.Z2.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.grfGeral.Axis.Z2.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.grfGeral.Axis.Z2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray
        Me.grfGeral.Axis.Z2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.grfGeral.Axis.Z2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.grfGeral.Axis.Z2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.grfGeral.Axis.Z2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.grfGeral.Axis.Z2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.grfGeral.Axis.Z2.LineThickness = 1
        Me.grfGeral.Axis.Z2.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.grfGeral.Axis.Z2.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.grfGeral.Axis.Z2.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.grfGeral.Axis.Z2.MajorGridLines.Visible = True
        Me.grfGeral.Axis.Z2.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.grfGeral.Axis.Z2.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.grfGeral.Axis.Z2.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.grfGeral.Axis.Z2.MinorGridLines.Visible = False
        Me.grfGeral.Axis.Z2.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.grfGeral.Axis.Z2.Visible = True
        Me.grfGeral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.grfGeral.ColorModel.AlphaLevel = CType(255, Byte)
        Me.grfGeral.ColorModel.ModelStyle = Infragistics.UltraChart.[Shared].Styles.ColorModels.CustomLinear
        StrokeEffect1.StrokeColor = System.Drawing.Color.White
        StrokeEffect1.StrokeOpacity = CType(255, Byte)
        StrokeEffect1.StrokeWidth = 0
        Me.grfGeral.Effects.Effects.Add(StrokeEffect1)
        Me.grfGeral.Location = New System.Drawing.Point(3, 98)
        Me.grfGeral.Name = "grfGeral"
        Me.grfGeral.Size = New System.Drawing.Size(700, 452)
        Me.grfGeral.TabIndex = 186
        Me.grfGeral.Tooltips.HighlightFillColor = System.Drawing.Color.DimGray
        Me.grfGeral.Tooltips.HighlightOutlineColor = System.Drawing.Color.DarkGray
        '
        'frmGRF_Contato
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 560)
        Me.Controls.Add(Me.grfGeral)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtdt_escala_fim)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboUsuario)
        Me.Controls.Add(Me.cboFilial)
        Me.Controls.Add(Me.txtdt_escala_ini)
        Me.Controls.Add(Me.cmdFechar_Grafico)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmdPesquisar)
        Me.Controls.Add(Me.optGrupamento)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboTipoContato)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmGRF_Contato"
        Me.Text = "Gráfico Contatos"
        CType(Me.optGrupamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtdt_escala_fim, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtdt_escala_ini, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grfGeral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboUsuario As System.Windows.Forms.ComboBox
    Friend WithEvents cboFilial As System.Windows.Forms.ComboBox
    Friend WithEvents cmdFechar_Grafico As Infragistics.Win.Misc.UltraButton
    Friend WithEvents optGrupamento As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents txtdt_escala_fim As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents cmdPesquisar As Infragistics.Win.Misc.UltraButton
    Private WithEvents grfGeral As Infragistics.Win.UltraWinChart.UltraChart
    Friend WithEvents txtdt_escala_ini As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboTipoContato As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
