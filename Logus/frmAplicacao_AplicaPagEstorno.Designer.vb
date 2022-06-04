<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAplicacao_AplicaPagEstorno
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
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAplicacao_AplicaPagEstorno))
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.cboNegocicao = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.cboContratoPAF = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.cboContratoFixo = New System.Windows.Forms.ComboBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtValorEstornar = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.txtSaldoPagamento = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.txtSaldoContrato = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtMotivo = New System.Windows.Forms.TextBox
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.cboNegocicao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboContratoPAF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtValorEstornar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSaldoPagamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSaldoContrato, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.cboNegocicao)
        Me.UltraGroupBox1.Controls.Add(Me.cboContratoPAF)
        Me.UltraGroupBox1.Controls.Add(Me.cboContratoFixo)
        Me.UltraGroupBox1.Controls.Add(Me.Label20)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(5, 5)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(635, 60)
        Me.UltraGroupBox1.TabIndex = 249
        '
        'cboNegocicao
        '
        Me.cboNegocicao.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance4.BackColor = System.Drawing.SystemColors.Window
        Appearance4.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.cboNegocicao.DisplayLayout.Appearance = Appearance4
        Me.cboNegocicao.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.cboNegocicao.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance1.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance1.BorderColor = System.Drawing.SystemColors.Window
        Me.cboNegocicao.DisplayLayout.GroupByBox.Appearance = Appearance1
        Appearance2.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cboNegocicao.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance2
        Me.cboNegocicao.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance3.BackColor2 = System.Drawing.SystemColors.Control
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cboNegocicao.DisplayLayout.GroupByBox.PromptAppearance = Appearance3
        Me.cboNegocicao.DisplayLayout.MaxColScrollRegions = 1
        Me.cboNegocicao.DisplayLayout.MaxRowScrollRegions = 1
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cboNegocicao.DisplayLayout.Override.ActiveCellAppearance = Appearance12
        Appearance7.BackColor = System.Drawing.SystemColors.Highlight
        Appearance7.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.cboNegocicao.DisplayLayout.Override.ActiveRowAppearance = Appearance7
        Me.cboNegocicao.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.cboNegocicao.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance6.BackColor = System.Drawing.SystemColors.Window
        Me.cboNegocicao.DisplayLayout.Override.CardAreaAppearance = Appearance6
        Appearance5.BorderColor = System.Drawing.Color.Silver
        Appearance5.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.cboNegocicao.DisplayLayout.Override.CellAppearance = Appearance5
        Me.cboNegocicao.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.cboNegocicao.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.cboNegocicao.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance11.TextHAlignAsString = "Left"
        Me.cboNegocicao.DisplayLayout.Override.HeaderAppearance = Appearance11
        Me.cboNegocicao.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.cboNegocicao.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance10.BackColor = System.Drawing.SystemColors.Window
        Appearance10.BorderColor = System.Drawing.Color.Silver
        Me.cboNegocicao.DisplayLayout.Override.RowAppearance = Appearance10
        Me.cboNegocicao.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance8.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cboNegocicao.DisplayLayout.Override.TemplateAddRowAppearance = Appearance8
        Me.cboNegocicao.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.cboNegocicao.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.cboNegocicao.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.cboNegocicao.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cboNegocicao.Location = New System.Drawing.Point(410, 25)
        Me.cboNegocicao.Name = "cboNegocicao"
        Me.cboNegocicao.Size = New System.Drawing.Size(160, 22)
        Me.cboNegocicao.TabIndex = 302
        '
        'cboContratoPAF
        '
        Me.cboContratoPAF.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.cboContratoPAF.DisplayLayout.Appearance = Appearance13
        Me.cboContratoPAF.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.cboContratoPAF.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.cboContratoPAF.DisplayLayout.GroupByBox.Appearance = Appearance14
        Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cboContratoPAF.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance15
        Me.cboContratoPAF.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance16.BackColor2 = System.Drawing.SystemColors.Control
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cboContratoPAF.DisplayLayout.GroupByBox.PromptAppearance = Appearance16
        Me.cboContratoPAF.DisplayLayout.MaxColScrollRegions = 1
        Me.cboContratoPAF.DisplayLayout.MaxRowScrollRegions = 1
        Appearance17.BackColor = System.Drawing.SystemColors.Window
        Appearance17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cboContratoPAF.DisplayLayout.Override.ActiveCellAppearance = Appearance17
        Appearance18.BackColor = System.Drawing.SystemColors.Highlight
        Appearance18.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.cboContratoPAF.DisplayLayout.Override.ActiveRowAppearance = Appearance18
        Me.cboContratoPAF.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.cboContratoPAF.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Me.cboContratoPAF.DisplayLayout.Override.CardAreaAppearance = Appearance19
        Appearance20.BorderColor = System.Drawing.Color.Silver
        Appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.cboContratoPAF.DisplayLayout.Override.CellAppearance = Appearance20
        Me.cboContratoPAF.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.cboContratoPAF.DisplayLayout.Override.CellPadding = 0
        Appearance21.BackColor = System.Drawing.SystemColors.Control
        Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance21.BorderColor = System.Drawing.SystemColors.Window
        Me.cboContratoPAF.DisplayLayout.Override.GroupByRowAppearance = Appearance21
        Appearance22.TextHAlignAsString = "Left"
        Me.cboContratoPAF.DisplayLayout.Override.HeaderAppearance = Appearance22
        Me.cboContratoPAF.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.cboContratoPAF.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Appearance23.BorderColor = System.Drawing.Color.Silver
        Me.cboContratoPAF.DisplayLayout.Override.RowAppearance = Appearance23
        Me.cboContratoPAF.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance24.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cboContratoPAF.DisplayLayout.Override.TemplateAddRowAppearance = Appearance24
        Me.cboContratoPAF.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.cboContratoPAF.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.cboContratoPAF.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.cboContratoPAF.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cboContratoPAF.Location = New System.Drawing.Point(6, 25)
        Me.cboContratoPAF.Name = "cboContratoPAF"
        Me.cboContratoPAF.Size = New System.Drawing.Size(400, 22)
        Me.cboContratoPAF.TabIndex = 301
        '
        'cboContratoFixo
        '
        Me.cboContratoFixo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboContratoFixo.Location = New System.Drawing.Point(575, 25)
        Me.cboContratoFixo.Name = "cboContratoFixo"
        Me.cboContratoFixo.Size = New System.Drawing.Size(49, 21)
        Me.cboContratoFixo.TabIndex = 242
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 10)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(47, 13)
        Me.Label20.TabIndex = 243
        Me.Label20.Text = "Contrato"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(595, 323)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 248
        Me.cmdFechar.Text = "F"
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(5, 323)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 235
        Me.cmdGravar.Text = "G"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtValorEstornar)
        Me.GroupBox1.Controls.Add(Me.txtSaldoPagamento)
        Me.GroupBox1.Controls.Add(Me.txtSaldoContrato)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 71)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(635, 60)
        Me.GroupBox1.TabIndex = 250
        Me.GroupBox1.TabStop = False
        '
        'txtValorEstornar
        '
        Me.txtValorEstornar.Location = New System.Drawing.Point(533, 32)
        Me.txtValorEstornar.Name = "txtValorEstornar"
        Me.txtValorEstornar.Size = New System.Drawing.Size(91, 21)
        Me.txtValorEstornar.TabIndex = 261
        '
        'txtSaldoPagamento
        '
        Me.txtSaldoPagamento.Location = New System.Drawing.Point(423, 32)
        Me.txtSaldoPagamento.Name = "txtSaldoPagamento"
        Me.txtSaldoPagamento.Size = New System.Drawing.Size(103, 21)
        Me.txtSaldoPagamento.TabIndex = 260
        '
        'txtSaldoContrato
        '
        Me.txtSaldoContrato.Location = New System.Drawing.Point(323, 32)
        Me.txtSaldoContrato.Name = "txtSaldoContrato"
        Me.txtSaldoContrato.Size = New System.Drawing.Size(91, 21)
        Me.txtSaldoContrato.TabIndex = 259
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(530, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 221
        Me.Label3.Text = "Valor a Estornar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(420, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 13)
        Me.Label2.TabIndex = 220
        Me.Label2.Text = "Saldo no Pagamento"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(320, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 217
        Me.Label1.Text = "Saldo do Contrato"
        '
        'txtMotivo
        '
        Me.txtMotivo.Location = New System.Drawing.Point(5, 139)
        Me.txtMotivo.MaxLength = 4000
        Me.txtMotivo.Multiline = True
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.Size = New System.Drawing.Size(635, 178)
        Me.txtMotivo.TabIndex = 251
        '
        'frmAplicacao_AplicaPagEstorno
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(644, 374)
        Me.Controls.Add(Me.txtMotivo)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmAplicacao_AplicaPagEstorno"
        Me.Text = "Estorno de Aplicação de Adiantamento"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.cboNegocicao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboContratoPAF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtValorEstornar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSaldoPagamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSaldoContrato, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cboContratoFixo As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMotivo As System.Windows.Forms.TextBox
    Friend WithEvents cboContratoPAF As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cboNegocicao As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents txtValorEstornar As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents txtSaldoPagamento As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents txtSaldoContrato As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
End Class
