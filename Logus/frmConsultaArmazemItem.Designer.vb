<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaArmazemItem
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.grdSacaria = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.grdEstoque = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdMovimentar = New Infragistics.Win.Misc.UltraButton
        Me.cmdExcell_Movimentacao = New Infragistics.Win.Misc.UltraButton
        Me.cmdExcell_Sacaria = New Infragistics.Win.Misc.UltraButton
        Me.cmdAjuste_Estoque = New Infragistics.Win.Misc.UltraButton
        Me.cmdAjuste_Sacaria = New Infragistics.Win.Misc.UltraButton
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.grdSacaria, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdEstoque, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdSacaria
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdSacaria.DisplayLayout.Appearance = Appearance1
        Me.grdSacaria.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdSacaria.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.grdSacaria.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdSacaria.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.grdSacaria.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdSacaria.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.grdSacaria.DisplayLayout.MaxColScrollRegions = 1
        Me.grdSacaria.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdSacaria.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdSacaria.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.grdSacaria.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdSacaria.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.grdSacaria.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdSacaria.DisplayLayout.Override.CellAppearance = Appearance8
        Me.grdSacaria.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdSacaria.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.grdSacaria.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.grdSacaria.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.grdSacaria.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdSacaria.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.grdSacaria.DisplayLayout.Override.RowAppearance = Appearance11
        Me.grdSacaria.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdSacaria.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.grdSacaria.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdSacaria.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdSacaria.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdSacaria.Location = New System.Drawing.Point(7, 21)
        Me.grdSacaria.Name = "grdSacaria"
        Me.grdSacaria.Size = New System.Drawing.Size(284, 108)
        Me.grdSacaria.TabIndex = 184
        Me.grdSacaria.Text = "UltraGrid1"
        '
        'grdEstoque
        '
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdEstoque.DisplayLayout.Appearance = Appearance13
        Me.grdEstoque.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdEstoque.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.grdEstoque.DisplayLayout.GroupByBox.Appearance = Appearance14
        Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdEstoque.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance15
        Me.grdEstoque.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance16.BackColor2 = System.Drawing.SystemColors.Control
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdEstoque.DisplayLayout.GroupByBox.PromptAppearance = Appearance16
        Me.grdEstoque.DisplayLayout.MaxColScrollRegions = 1
        Me.grdEstoque.DisplayLayout.MaxRowScrollRegions = 1
        Appearance17.BackColor = System.Drawing.SystemColors.Window
        Appearance17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdEstoque.DisplayLayout.Override.ActiveCellAppearance = Appearance17
        Appearance18.BackColor = System.Drawing.SystemColors.Highlight
        Appearance18.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdEstoque.DisplayLayout.Override.ActiveRowAppearance = Appearance18
        Me.grdEstoque.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdEstoque.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Me.grdEstoque.DisplayLayout.Override.CardAreaAppearance = Appearance19
        Appearance20.BorderColor = System.Drawing.Color.Silver
        Appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdEstoque.DisplayLayout.Override.CellAppearance = Appearance20
        Me.grdEstoque.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdEstoque.DisplayLayout.Override.CellPadding = 0
        Appearance21.BackColor = System.Drawing.SystemColors.Control
        Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance21.BorderColor = System.Drawing.SystemColors.Window
        Me.grdEstoque.DisplayLayout.Override.GroupByRowAppearance = Appearance21
        Appearance22.TextHAlignAsString = "Left"
        Me.grdEstoque.DisplayLayout.Override.HeaderAppearance = Appearance22
        Me.grdEstoque.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdEstoque.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Appearance23.BorderColor = System.Drawing.Color.Silver
        Me.grdEstoque.DisplayLayout.Override.RowAppearance = Appearance23
        Me.grdEstoque.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance24.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdEstoque.DisplayLayout.Override.TemplateAddRowAppearance = Appearance24
        Me.grdEstoque.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdEstoque.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdEstoque.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdEstoque.Location = New System.Drawing.Point(6, 19)
        Me.grdEstoque.Name = "grdEstoque"
        Me.grdEstoque.Size = New System.Drawing.Size(663, 264)
        Me.grdEstoque.TabIndex = 183
        Me.grdEstoque.Text = "UltraGrid1"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(625, 135)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 185
        Me.cmdFechar.Text = "F"
        '
        'cmdMovimentar
        '
        Appearance27.Image = Global.Logus.My.Resources.Resources.replace2
        Me.cmdMovimentar.Appearance = Appearance27
        Me.cmdMovimentar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdMovimentar.Location = New System.Drawing.Point(57, 289)
        Me.cmdMovimentar.Name = "cmdMovimentar"
        Me.cmdMovimentar.Size = New System.Drawing.Size(45, 45)
        Me.cmdMovimentar.TabIndex = 253
        Me.ToolTip1.SetToolTip(Me.cmdMovimentar, "Movimenta entre Armazem/Pilha")
        '
        'cmdExcell_Movimentacao
        '
        Me.cmdExcell_Movimentacao.AcceptsFocus = False
        Me.cmdExcell_Movimentacao.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExcell_Movimentacao.Location = New System.Drawing.Point(6, 289)
        Me.cmdExcell_Movimentacao.Name = "cmdExcell_Movimentacao"
        Me.cmdExcell_Movimentacao.Size = New System.Drawing.Size(45, 45)
        Me.cmdExcell_Movimentacao.TabIndex = 254
        Me.cmdExcell_Movimentacao.Text = "Excell"
        '
        'cmdExcell_Sacaria
        '
        Me.cmdExcell_Sacaria.AcceptsFocus = False
        Me.cmdExcell_Sacaria.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExcell_Sacaria.Location = New System.Drawing.Point(7, 135)
        Me.cmdExcell_Sacaria.Name = "cmdExcell_Sacaria"
        Me.cmdExcell_Sacaria.Size = New System.Drawing.Size(45, 45)
        Me.cmdExcell_Sacaria.TabIndex = 255
        Me.cmdExcell_Sacaria.Text = "Excell"
        '
        'cmdAjuste_Estoque
        '
        Me.cmdAjuste_Estoque.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdAjuste_Estoque.Location = New System.Drawing.Point(108, 289)
        Me.cmdAjuste_Estoque.Name = "cmdAjuste_Estoque"
        Me.cmdAjuste_Estoque.Size = New System.Drawing.Size(45, 45)
        Me.cmdAjuste_Estoque.TabIndex = 256
        Me.cmdAjuste_Estoque.Text = "AE"
        '
        'cmdAjuste_Sacaria
        '
        Me.cmdAjuste_Sacaria.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdAjuste_Sacaria.Location = New System.Drawing.Point(58, 135)
        Me.cmdAjuste_Sacaria.Name = "cmdAjuste_Sacaria"
        Me.cmdAjuste_Sacaria.Size = New System.Drawing.Size(45, 45)
        Me.cmdAjuste_Sacaria.TabIndex = 257
        Me.cmdAjuste_Sacaria.Text = "AS"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.cmdFechar)
        Me.UltraGroupBox1.Controls.Add(Me.cmdAjuste_Sacaria)
        Me.UltraGroupBox1.Controls.Add(Me.grdSacaria)
        Me.UltraGroupBox1.Controls.Add(Me.cmdExcell_Sacaria)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(3, 359)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(677, 189)
        Me.UltraGroupBox1.TabIndex = 258
        Me.UltraGroupBox1.Text = "Sacaria"
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.grdEstoque)
        Me.UltraGroupBox2.Controls.Add(Me.cmdMovimentar)
        Me.UltraGroupBox2.Controls.Add(Me.cmdAjuste_Estoque)
        Me.UltraGroupBox2.Controls.Add(Me.cmdExcell_Movimentacao)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(3, 12)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(679, 341)
        Me.UltraGroupBox2.TabIndex = 259
        Me.UltraGroupBox2.Text = "Estoque"
        '
        'frmConsultaArmazemItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(686, 554)
        Me.Controls.Add(Me.UltraGroupBox2)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmConsultaArmazemItem"
        Me.Text = "Consulta Itens em Estoque no Armazem"
        CType(Me.grdSacaria, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdEstoque, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdSacaria As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grdEstoque As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdMovimentar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdExcell_Movimentacao As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdExcell_Sacaria As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdAjuste_Estoque As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdAjuste_Sacaria As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
