<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroTipoFretistaTributacao
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadastroTipoFretistaTributacao))
        Me.txtDescricao = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtBaseCalculo = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboTributoDeducao = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtValorMinimo = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtValorMaximo = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtDeducaoDependente = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtSequencia = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboProvisao = New System.Windows.Forms.ComboBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.grdGeral = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.chkISS = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.Label9 = New System.Windows.Forms.Label
        Me.lstTipoFretista = New System.Windows.Forms.CheckedListBox
        CType(Me.txtBaseCalculo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorMinimo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorMaximo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDeducaoDependente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSequencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtDescricao
        '
        Me.txtDescricao.Location = New System.Drawing.Point(9, 32)
        Me.txtDescricao.MaxLength = 40
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(231, 20)
        Me.txtDescricao.TabIndex = 308
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(9, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 309
        Me.Label1.Text = "Descrição"
        '
        'txtBaseCalculo
        '
        Me.txtBaseCalculo.Location = New System.Drawing.Point(246, 32)
        Me.txtBaseCalculo.MaskInput = "{LOC}-nnn.nn"
        Me.txtBaseCalculo.MaxValue = 100
        Me.txtBaseCalculo.Name = "txtBaseCalculo"
        Me.txtBaseCalculo.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtBaseCalculo.Size = New System.Drawing.Size(68, 21)
        Me.txtBaseCalculo.TabIndex = 312
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(9, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 311
        Me.Label2.Text = "Tributo Dedução"
        '
        'cboTributoDeducao
        '
        Me.cboTributoDeducao.Location = New System.Drawing.Point(9, 81)
        Me.cboTributoDeducao.Name = "cboTributoDeducao"
        Me.cboTributoDeducao.Size = New System.Drawing.Size(231, 21)
        Me.cboTributoDeducao.TabIndex = 310
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(246, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 16)
        Me.Label3.TabIndex = 313
        Me.Label3.Text = "Base Cálculo "
        '
        'txtValorMinimo
        '
        Me.txtValorMinimo.Location = New System.Drawing.Point(447, 32)
        Me.txtValorMinimo.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtValorMinimo.Name = "txtValorMinimo"
        Me.txtValorMinimo.Size = New System.Drawing.Size(109, 21)
        Me.txtValorMinimo.TabIndex = 315
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(444, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 16)
        Me.Label4.TabIndex = 314
        Me.Label4.Text = "Valor Minimo"
        '
        'txtValorMaximo
        '
        Me.txtValorMaximo.Location = New System.Drawing.Point(562, 32)
        Me.txtValorMaximo.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtValorMaximo.Name = "txtValorMaximo"
        Me.txtValorMaximo.Size = New System.Drawing.Size(109, 21)
        Me.txtValorMaximo.TabIndex = 317
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(559, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 16)
        Me.Label5.TabIndex = 316
        Me.Label5.Text = "Valor Maximo"
        '
        'txtDeducaoDependente
        '
        Me.txtDeducaoDependente.Location = New System.Drawing.Point(320, 32)
        Me.txtDeducaoDependente.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtDeducaoDependente.Name = "txtDeducaoDependente"
        Me.txtDeducaoDependente.Size = New System.Drawing.Size(119, 21)
        Me.txtDeducaoDependente.TabIndex = 319
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(320, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(121, 17)
        Me.Label6.TabIndex = 318
        Me.Label6.Text = "Dedução Dependente"
        '
        'txtSequencia
        '
        Me.txtSequencia.Location = New System.Drawing.Point(478, 81)
        Me.txtSequencia.MaskInput = "{LOC}-nnnnnnnnnn"
        Me.txtSequencia.Name = "txtSequencia"
        Me.txtSequencia.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtSequencia.Size = New System.Drawing.Size(96, 21)
        Me.txtSequencia.TabIndex = 320
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(478, 65)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 16)
        Me.Label7.TabIndex = 321
        Me.Label7.Text = "Sequência"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(246, 66)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 13)
        Me.Label8.TabIndex = 323
        Me.Label8.Text = "Provisao"
        '
        'cboProvisao
        '
        Me.cboProvisao.Location = New System.Drawing.Point(246, 82)
        Me.cboProvisao.Name = "cboProvisao"
        Me.cboProvisao.Size = New System.Drawing.Size(226, 21)
        Me.cboProvisao.TabIndex = 322
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(6, 113)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(80, 13)
        Me.Label27.TabIndex = 338
        Me.Label27.Text = "Tipo de Fretista"
        '
        'grdGeral
        '
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdGeral.DisplayLayout.Appearance = Appearance13
        Me.grdGeral.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdGeral.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.GroupByBox.Appearance = Appearance14
        Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdGeral.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance15
        Me.grdGeral.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance16.BackColor2 = System.Drawing.SystemColors.Control
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdGeral.DisplayLayout.GroupByBox.PromptAppearance = Appearance16
        Me.grdGeral.DisplayLayout.MaxColScrollRegions = 1
        Me.grdGeral.DisplayLayout.MaxRowScrollRegions = 1
        Appearance17.BackColor = System.Drawing.SystemColors.Window
        Appearance17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdGeral.DisplayLayout.Override.ActiveCellAppearance = Appearance17
        Appearance18.BackColor = System.Drawing.SystemColors.Highlight
        Appearance18.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdGeral.DisplayLayout.Override.ActiveRowAppearance = Appearance18
        Me.grdGeral.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdGeral.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.Override.CardAreaAppearance = Appearance19
        Appearance20.BorderColor = System.Drawing.Color.Silver
        Appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdGeral.DisplayLayout.Override.CellAppearance = Appearance20
        Me.grdGeral.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdGeral.DisplayLayout.Override.CellPadding = 0
        Appearance21.BackColor = System.Drawing.SystemColors.Control
        Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance21.BorderColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.Override.GroupByRowAppearance = Appearance21
        Appearance22.TextHAlignAsString = "Left"
        Me.grdGeral.DisplayLayout.Override.HeaderAppearance = Appearance22
        Me.grdGeral.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdGeral.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Appearance23.BorderColor = System.Drawing.Color.Silver
        Me.grdGeral.DisplayLayout.Override.RowAppearance = Appearance23
        Me.grdGeral.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance24.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdGeral.DisplayLayout.Override.TemplateAddRowAppearance = Appearance24
        Me.grdGeral.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdGeral.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdGeral.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdGeral.Location = New System.Drawing.Point(161, 129)
        Me.grdGeral.Name = "grdGeral"
        Me.grdGeral.Size = New System.Drawing.Size(510, 155)
        Me.grdGeral.TabIndex = 339
        Me.grdGeral.Text = "UltraGrid1"
        '
        'chkISS
        '
        Me.chkISS.Location = New System.Drawing.Point(591, 82)
        Me.chkISS.Name = "chkISS"
        Me.chkISS.Size = New System.Drawing.Size(50, 20)
        Me.chkISS.TabIndex = 340
        Me.chkISS.Text = "ISS"
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(9, 290)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 341
        Me.cmdGravar.TabStop = False
        Me.cmdGravar.Text = "G"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(626, 290)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 342
        Me.cmdFechar.Text = "F"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(160, 113)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(94, 13)
        Me.Label9.TabIndex = 344
        Me.Label9.Text = "Tabela Tributação"
        '
        'lstTipoFretista
        '
        Me.lstTipoFretista.CheckOnClick = True
        Me.lstTipoFretista.Location = New System.Drawing.Point(9, 129)
        Me.lstTipoFretista.Name = "lstTipoFretista"
        Me.lstTipoFretista.Size = New System.Drawing.Size(146, 154)
        Me.lstTipoFretista.TabIndex = 345
        Me.lstTipoFretista.ThreeDCheckBoxes = True
        '
        'frmCadastroTipoFretistaTributacao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(676, 340)
        Me.Controls.Add(Me.lstTipoFretista)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.chkISS)
        Me.Controls.Add(Me.grdGeral)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboProvisao)
        Me.Controls.Add(Me.txtSequencia)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtDeducaoDependente)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtValorMaximo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtValorMinimo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtBaseCalculo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboTributoDeducao)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDescricao)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCadastroTipoFretistaTributacao"
        Me.Text = "Cadastro Tipo Fretista Tributação"
        CType(Me.txtBaseCalculo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorMinimo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorMaximo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDeducaoDependente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSequencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDescricao As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBaseCalculo As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboTributoDeducao As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtValorMinimo As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtValorMaximo As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDeducaoDependente As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSequencia As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboProvisao As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents grdGeral As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents chkISS As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lstTipoFretista As System.Windows.Forms.CheckedListBox
End Class
