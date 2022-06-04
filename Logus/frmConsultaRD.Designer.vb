<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaRD
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
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaRD))
        Me.grdGeral = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.cmdPesquisar = New Infragistics.Win.Misc.UltraButton
        Me.txtData = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboFilial = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkDiferenteZero = New System.Windows.Forms.CheckBox
        Me.cboTipoRD = New System.Windows.Forms.ComboBox
        Me.cmdExcell = New Infragistics.Win.Misc.UltraButton
        Me.grpTransito = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtValorICMSTransito = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtValorTransito = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtQuantidadeTransito = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.grpPreco = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtValorPrecoMedio = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdImprimir = New Infragistics.Win.Misc.UltraButton
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpTransito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpTransito.SuspendLayout()
        CType(Me.txtValorICMSTransito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorTransito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantidadeTransito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpPreco, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpPreco.SuspendLayout()
        CType(Me.txtValorPrecoMedio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdGeral
        '
        Appearance25.BackColor = System.Drawing.SystemColors.Window
        Appearance25.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdGeral.DisplayLayout.Appearance = Appearance25
        Me.grdGeral.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdGeral.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance26.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance26.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance26.BorderColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.GroupByBox.Appearance = Appearance26
        Appearance27.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdGeral.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance27
        Me.grdGeral.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance28.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance28.BackColor2 = System.Drawing.SystemColors.Control
        Appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance28.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdGeral.DisplayLayout.GroupByBox.PromptAppearance = Appearance28
        Me.grdGeral.DisplayLayout.MaxColScrollRegions = 1
        Me.grdGeral.DisplayLayout.MaxRowScrollRegions = 1
        Appearance29.BackColor = System.Drawing.SystemColors.Window
        Appearance29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdGeral.DisplayLayout.Override.ActiveCellAppearance = Appearance29
        Appearance30.BackColor = System.Drawing.SystemColors.Highlight
        Appearance30.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdGeral.DisplayLayout.Override.ActiveRowAppearance = Appearance30
        Me.grdGeral.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdGeral.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance31.BackColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.Override.CardAreaAppearance = Appearance31
        Appearance32.BorderColor = System.Drawing.Color.Silver
        Appearance32.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdGeral.DisplayLayout.Override.CellAppearance = Appearance32
        Me.grdGeral.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdGeral.DisplayLayout.Override.CellPadding = 0
        Appearance33.BackColor = System.Drawing.SystemColors.Control
        Appearance33.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance33.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance33.BorderColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.Override.GroupByRowAppearance = Appearance33
        Appearance34.TextHAlignAsString = "Left"
        Me.grdGeral.DisplayLayout.Override.HeaderAppearance = Appearance34
        Me.grdGeral.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdGeral.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance35.BackColor = System.Drawing.SystemColors.Window
        Appearance35.BorderColor = System.Drawing.Color.Silver
        Me.grdGeral.DisplayLayout.Override.RowAppearance = Appearance35
        Me.grdGeral.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance36.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdGeral.DisplayLayout.Override.TemplateAddRowAppearance = Appearance36
        Me.grdGeral.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdGeral.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdGeral.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdGeral.Location = New System.Drawing.Point(8, 61)
        Me.grdGeral.Name = "grdGeral"
        Me.grdGeral.Size = New System.Drawing.Size(725, 284)
        Me.grdGeral.TabIndex = 236
        Me.grdGeral.Text = "UltraGrid1"
        '
        'cmdPesquisar
        '
        Me.cmdPesquisar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdPesquisar.Location = New System.Drawing.Point(688, 8)
        Me.cmdPesquisar.Name = "cmdPesquisar"
        Me.cmdPesquisar.Size = New System.Drawing.Size(45, 45)
        Me.cmdPesquisar.TabIndex = 238
        Me.cmdPesquisar.Text = "P"
        '
        'txtData
        '
        Me.txtData.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtData.Location = New System.Drawing.Point(8, 23)
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(104, 23)
        Me.txtData.TabIndex = 237
        Me.txtData.Value = Nothing
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 240
        Me.Label6.Text = "Data"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(688, 408)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 239
        Me.cmdFechar.Text = "F"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(120, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 242
        Me.Label2.Text = "Filial"
        '
        'cboFilial
        '
        Me.cboFilial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilial.Location = New System.Drawing.Point(120, 24)
        Me.cboFilial.Name = "cboFilial"
        Me.cboFilial.Size = New System.Drawing.Size(200, 21)
        Me.cboFilial.TabIndex = 241
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(328, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 244
        Me.Label1.Text = "Tipo"
        '
        'chkDiferenteZero
        '
        Me.chkDiferenteZero.AutoSize = True
        Me.chkDiferenteZero.Checked = True
        Me.chkDiferenteZero.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDiferenteZero.Location = New System.Drawing.Point(455, 26)
        Me.chkDiferenteZero.Name = "chkDiferenteZero"
        Me.chkDiferenteZero.Size = New System.Drawing.Size(190, 17)
        Me.chkDiferenteZero.TabIndex = 245
        Me.chkDiferenteZero.Text = "Apenas Movimentações com Valor"
        Me.chkDiferenteZero.UseVisualStyleBackColor = True
        '
        'cboTipoRD
        '
        Me.cboTipoRD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoRD.Location = New System.Drawing.Point(328, 24)
        Me.cboTipoRD.Name = "cboTipoRD"
        Me.cboTipoRD.Size = New System.Drawing.Size(119, 21)
        Me.cboTipoRD.TabIndex = 246
        '
        'cmdExcell
        '
        Me.cmdExcell.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExcell.Location = New System.Drawing.Point(8, 408)
        Me.cmdExcell.Name = "cmdExcell"
        Me.cmdExcell.Size = New System.Drawing.Size(45, 45)
        Me.cmdExcell.TabIndex = 247
        Me.cmdExcell.Text = "Excell"
        '
        'grpTransito
        '
        Me.grpTransito.Controls.Add(Me.txtValorICMSTransito)
        Me.grpTransito.Controls.Add(Me.Label4)
        Me.grpTransito.Controls.Add(Me.txtValorTransito)
        Me.grpTransito.Controls.Add(Me.Label3)
        Me.grpTransito.Controls.Add(Me.Label5)
        Me.grpTransito.Controls.Add(Me.txtQuantidadeTransito)
        Me.grpTransito.Location = New System.Drawing.Point(227, 353)
        Me.grpTransito.Name = "grpTransito"
        Me.grpTransito.Size = New System.Drawing.Size(459, 47)
        Me.grpTransito.TabIndex = 248
        Me.grpTransito.Text = "Transferências em Transito"
        '
        'txtValorICMSTransito
        '
        Me.txtValorICMSTransito.Location = New System.Drawing.Point(345, 19)
        Me.txtValorICMSTransito.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtValorICMSTransito.Name = "txtValorICMSTransito"
        Me.txtValorICMSTransito.ReadOnly = True
        Me.txtValorICMSTransito.Size = New System.Drawing.Size(103, 21)
        Me.txtValorICMSTransito.TabIndex = 264
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(309, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 16)
        Me.Label4.TabIndex = 263
        Me.Label4.Text = "ICMS"
        '
        'txtValorTransito
        '
        Me.txtValorTransito.Location = New System.Drawing.Point(200, 18)
        Me.txtValorTransito.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtValorTransito.Name = "txtValorTransito"
        Me.txtValorTransito.ReadOnly = True
        Me.txtValorTransito.Size = New System.Drawing.Size(103, 21)
        Me.txtValorTransito.TabIndex = 262
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(162, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 16)
        Me.Label3.TabIndex = 261
        Me.Label3.Text = "Valor"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(11, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 16)
        Me.Label5.TabIndex = 260
        Me.Label5.Text = "Quantidade"
        '
        'txtQuantidadeTransito
        '
        Me.txtQuantidadeTransito.Location = New System.Drawing.Point(88, 19)
        Me.txtQuantidadeTransito.MaskInput = "{LOC}-nnnn,nnn"
        Me.txtQuantidadeTransito.Name = "txtQuantidadeTransito"
        Me.txtQuantidadeTransito.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtQuantidadeTransito.ReadOnly = True
        Me.txtQuantidadeTransito.Size = New System.Drawing.Size(68, 21)
        Me.txtQuantidadeTransito.TabIndex = 259
        '
        'grpPreco
        '
        Me.grpPreco.Controls.Add(Me.txtValorPrecoMedio)
        Me.grpPreco.Controls.Add(Me.Label7)
        Me.grpPreco.Location = New System.Drawing.Point(8, 353)
        Me.grpPreco.Name = "grpPreco"
        Me.grpPreco.Size = New System.Drawing.Size(211, 47)
        Me.grpPreco.TabIndex = 249
        Me.grpPreco.Text = "Preço Medio"
        '
        'txtValorPrecoMedio
        '
        Me.txtValorPrecoMedio.Location = New System.Drawing.Point(89, 17)
        Me.txtValorPrecoMedio.Name = "txtValorPrecoMedio"
        Me.txtValorPrecoMedio.ReadOnly = True
        Me.txtValorPrecoMedio.Size = New System.Drawing.Size(103, 21)
        Me.txtValorPrecoMedio.TabIndex = 263
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(6, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 16)
        Me.Label7.TabIndex = 262
        Me.Label7.Text = "Por Tonelada"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdImprimir.Location = New System.Drawing.Point(61, 408)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(45, 45)
        Me.cmdImprimir.TabIndex = 250
        Me.cmdImprimir.Text = "I"
        '
        'frmConsultaRD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(738, 460)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.grdGeral)
        Me.Controls.Add(Me.grpPreco)
        Me.Controls.Add(Me.grpTransito)
        Me.Controls.Add(Me.cmdExcell)
        Me.Controls.Add(Me.cboTipoRD)
        Me.Controls.Add(Me.chkDiferenteZero)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboFilial)
        Me.Controls.Add(Me.cmdPesquisar)
        Me.Controls.Add(Me.txtData)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmdFechar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsultaRD"
        Me.Text = "Consulta RD"
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpTransito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpTransito.ResumeLayout(False)
        Me.grpTransito.PerformLayout()
        CType(Me.txtValorICMSTransito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorTransito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantidadeTransito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpPreco, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPreco.ResumeLayout(False)
        Me.grpPreco.PerformLayout()
        CType(Me.txtValorPrecoMedio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdGeral As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cmdPesquisar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtData As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboFilial As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkDiferenteZero As System.Windows.Forms.CheckBox
    Friend WithEvents cboTipoRD As System.Windows.Forms.ComboBox
    Friend WithEvents cmdExcell As Infragistics.Win.Misc.UltraButton
    Friend WithEvents grpTransito As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtValorICMSTransito As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtValorTransito As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtQuantidadeTransito As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents grpPreco As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtValorPrecoMedio As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdImprimir As Infragistics.Win.Misc.UltraButton
End Class
