<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaGeral
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaGeral))
        Me.cmdUsuario = New Infragistics.Win.Misc.UltraButton
        Me.cmdExcell = New Infragistics.Win.Misc.UltraButton
        Me.cmdAlterar = New Infragistics.Win.Misc.UltraButton
        Me.cmdExcluir = New Infragistics.Win.Misc.UltraButton
        Me.cmdNovo = New Infragistics.Win.Misc.UltraButton
        Me.cmdEspecial_02 = New Infragistics.Win.Misc.UltraButton
        Me.cmdEspecial_01 = New Infragistics.Win.Misc.UltraButton
        Me.grdGeral = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.lblTituloPesquisa = New System.Windows.Forms.Label
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdAtualizar = New Infragistics.Win.Misc.UltraButton
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdUsuario
        '
        Me.cmdUsuario.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdUsuario.Location = New System.Drawing.Point(581, 316)
        Me.cmdUsuario.Name = "cmdUsuario"
        Me.cmdUsuario.Size = New System.Drawing.Size(45, 45)
        Me.cmdUsuario.TabIndex = 67
        Me.cmdUsuario.Text = "U"
        '
        'cmdExcell
        '
        Me.cmdExcell.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExcell.Location = New System.Drawing.Point(5, 316)
        Me.cmdExcell.Name = "cmdExcell"
        Me.cmdExcell.Size = New System.Drawing.Size(45, 45)
        Me.cmdExcell.TabIndex = 66
        Me.cmdExcell.Text = "Excell"
        '
        'cmdAlterar
        '
        Me.cmdAlterar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdAlterar.Location = New System.Drawing.Point(160, 316)
        Me.cmdAlterar.Name = "cmdAlterar"
        Me.cmdAlterar.Size = New System.Drawing.Size(45, 45)
        Me.cmdAlterar.TabIndex = 65
        Me.cmdAlterar.Text = "A"
        '
        'cmdExcluir
        '
        Me.cmdExcluir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExcluir.Location = New System.Drawing.Point(213, 316)
        Me.cmdExcluir.Name = "cmdExcluir"
        Me.cmdExcluir.Size = New System.Drawing.Size(45, 45)
        Me.cmdExcluir.TabIndex = 64
        Me.cmdExcluir.Text = "E"
        '
        'cmdNovo
        '
        Me.cmdNovo.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdNovo.Location = New System.Drawing.Point(107, 316)
        Me.cmdNovo.Name = "cmdNovo"
        Me.cmdNovo.Size = New System.Drawing.Size(45, 45)
        Me.cmdNovo.TabIndex = 63
        Me.cmdNovo.Text = "N"
        '
        'cmdEspecial_02
        '
        Me.cmdEspecial_02.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdEspecial_02.Location = New System.Drawing.Point(319, 316)
        Me.cmdEspecial_02.Name = "cmdEspecial_02"
        Me.cmdEspecial_02.Size = New System.Drawing.Size(45, 45)
        Me.cmdEspecial_02.TabIndex = 62
        Me.cmdEspecial_02.Text = "E2"
        '
        'cmdEspecial_01
        '
        Me.cmdEspecial_01.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdEspecial_01.Location = New System.Drawing.Point(266, 316)
        Me.cmdEspecial_01.Name = "cmdEspecial_01"
        Me.cmdEspecial_01.Size = New System.Drawing.Size(45, 45)
        Me.cmdEspecial_01.TabIndex = 61
        Me.cmdEspecial_01.Text = "E1"
        '
        'grdGeral
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdGeral.DisplayLayout.Appearance = Appearance1
        Me.grdGeral.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdGeral.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdGeral.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.grdGeral.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdGeral.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.grdGeral.DisplayLayout.MaxColScrollRegions = 1
        Me.grdGeral.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdGeral.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdGeral.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.grdGeral.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdGeral.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdGeral.DisplayLayout.Override.CellAppearance = Appearance8
        Me.grdGeral.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdGeral.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.grdGeral.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.grdGeral.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdGeral.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.grdGeral.DisplayLayout.Override.RowAppearance = Appearance11
        Me.grdGeral.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdGeral.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.grdGeral.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdGeral.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdGeral.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdGeral.Location = New System.Drawing.Point(5, 20)
        Me.grdGeral.Name = "grdGeral"
        Me.grdGeral.Size = New System.Drawing.Size(672, 288)
        Me.grdGeral.TabIndex = 60
        Me.grdGeral.Text = "UltraGrid1"
        '
        'lblTituloPesquisa
        '
        Me.lblTituloPesquisa.AutoSize = True
        Me.lblTituloPesquisa.Location = New System.Drawing.Point(5, 5)
        Me.lblTituloPesquisa.Name = "lblTituloPesquisa"
        Me.lblTituloPesquisa.Size = New System.Drawing.Size(34, 13)
        Me.lblTituloPesquisa.TabIndex = 59
        Me.lblTituloPesquisa.Text = "Texto"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(632, 316)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 68
        Me.cmdFechar.Text = "F"
        '
        'cmdAtualizar
        '
        Me.cmdAtualizar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdAtualizar.Location = New System.Drawing.Point(56, 316)
        Me.cmdAtualizar.Name = "cmdAtualizar"
        Me.cmdAtualizar.Size = New System.Drawing.Size(45, 45)
        Me.cmdAtualizar.TabIndex = 69
        Me.cmdAtualizar.Text = "AT"
        '
        'frmConsultaGeral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(683, 366)
        Me.Controls.Add(Me.cmdAtualizar)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdUsuario)
        Me.Controls.Add(Me.cmdExcell)
        Me.Controls.Add(Me.cmdAlterar)
        Me.Controls.Add(Me.cmdExcluir)
        Me.Controls.Add(Me.cmdNovo)
        Me.Controls.Add(Me.cmdEspecial_02)
        Me.Controls.Add(Me.cmdEspecial_01)
        Me.Controls.Add(Me.grdGeral)
        Me.Controls.Add(Me.lblTituloPesquisa)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmConsultaGeral"
        Me.Text = "frmCosultaGeral"
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdUsuario As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdExcell As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdAlterar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdExcluir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdNovo As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdEspecial_02 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdEspecial_01 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents grdGeral As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblTituloPesquisa As System.Windows.Forms.Label
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdAtualizar As Infragistics.Win.Misc.UltraButton
End Class
