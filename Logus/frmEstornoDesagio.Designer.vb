<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEstornoDesagio
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
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEstornoDesagio))
        Me.cboContratoFixo = New System.Windows.Forms.ComboBox
        Me.cboNegocicao = New System.Windows.Forms.ComboBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtValorDesagio = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.txtMotivo = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.grdMovimentacao = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.txtValorDescontado = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.optTipo = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.txtPC_Contrato = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Label31 = New System.Windows.Forms.Label
        Me.Pesq_ContratoPAF = New Logus.Pesq_CodigoNome
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.txtValorAjuste = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.txtValorDesagio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdMovimentacao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorDescontado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPC_Contrato, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorAjuste, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboContratoFixo
        '
        Me.cboContratoFixo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboContratoFixo.Location = New System.Drawing.Point(520, 21)
        Me.cboContratoFixo.Name = "cboContratoFixo"
        Me.cboContratoFixo.Size = New System.Drawing.Size(49, 21)
        Me.cboContratoFixo.TabIndex = 301
        '
        'cboNegocicao
        '
        Me.cboNegocicao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNegocicao.Location = New System.Drawing.Point(463, 21)
        Me.cboNegocicao.Name = "cboNegocicao"
        Me.cboNegocicao.Size = New System.Drawing.Size(49, 21)
        Me.cboNegocicao.TabIndex = 303
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(8, 8)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(47, 13)
        Me.Label20.TabIndex = 302
        Me.Label20.Text = "Contrato"
        '
        'txtValorDesagio
        '
        Me.txtValorDesagio.Enabled = False
        Me.txtValorDesagio.Location = New System.Drawing.Point(575, 65)
        Me.txtValorDesagio.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtValorDesagio.Name = "txtValorDesagio"
        Me.txtValorDesagio.ReadOnly = True
        Me.txtValorDesagio.Size = New System.Drawing.Size(110, 21)
        Me.txtValorDesagio.TabIndex = 338
        '
        'txtMotivo
        '
        Me.txtMotivo.Location = New System.Drawing.Point(8, 65)
        Me.txtMotivo.MaxLength = 4000
        Me.txtMotivo.Multiline = True
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.Size = New System.Drawing.Size(441, 63)
        Me.txtMotivo.TabIndex = 337
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Location = New System.Drawing.Point(575, 51)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(73, 13)
        Me.Label28.TabIndex = 339
        Me.Label28.Text = "Valor Desagio"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(8, 51)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(39, 13)
        Me.Label27.TabIndex = 340
        Me.Label27.Text = "Motivo"
        '
        'grdMovimentacao
        '
        Appearance45.BackColor = System.Drawing.SystemColors.Window
        Appearance45.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdMovimentacao.DisplayLayout.Appearance = Appearance45
        Me.grdMovimentacao.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdMovimentacao.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance46.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance46.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance46.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance46.BorderColor = System.Drawing.SystemColors.Window
        Me.grdMovimentacao.DisplayLayout.GroupByBox.Appearance = Appearance46
        Appearance47.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdMovimentacao.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance47
        Me.grdMovimentacao.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance48.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance48.BackColor2 = System.Drawing.SystemColors.Control
        Appearance48.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance48.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdMovimentacao.DisplayLayout.GroupByBox.PromptAppearance = Appearance48
        Me.grdMovimentacao.DisplayLayout.MaxColScrollRegions = 1
        Me.grdMovimentacao.DisplayLayout.MaxRowScrollRegions = 1
        Appearance49.BackColor = System.Drawing.SystemColors.Window
        Appearance49.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdMovimentacao.DisplayLayout.Override.ActiveCellAppearance = Appearance49
        Appearance50.BackColor = System.Drawing.SystemColors.Highlight
        Appearance50.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdMovimentacao.DisplayLayout.Override.ActiveRowAppearance = Appearance50
        Me.grdMovimentacao.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdMovimentacao.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance51.BackColor = System.Drawing.SystemColors.Window
        Me.grdMovimentacao.DisplayLayout.Override.CardAreaAppearance = Appearance51
        Appearance52.BorderColor = System.Drawing.Color.Silver
        Appearance52.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdMovimentacao.DisplayLayout.Override.CellAppearance = Appearance52
        Me.grdMovimentacao.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdMovimentacao.DisplayLayout.Override.CellPadding = 0
        Appearance53.BackColor = System.Drawing.SystemColors.Control
        Appearance53.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance53.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance53.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance53.BorderColor = System.Drawing.SystemColors.Window
        Me.grdMovimentacao.DisplayLayout.Override.GroupByRowAppearance = Appearance53
        Appearance54.TextHAlignAsString = "Left"
        Me.grdMovimentacao.DisplayLayout.Override.HeaderAppearance = Appearance54
        Me.grdMovimentacao.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdMovimentacao.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance55.BackColor = System.Drawing.SystemColors.Window
        Appearance55.BorderColor = System.Drawing.Color.Silver
        Me.grdMovimentacao.DisplayLayout.Override.RowAppearance = Appearance55
        Me.grdMovimentacao.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance56.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdMovimentacao.DisplayLayout.Override.TemplateAddRowAppearance = Appearance56
        Me.grdMovimentacao.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdMovimentacao.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdMovimentacao.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdMovimentacao.Location = New System.Drawing.Point(8, 136)
        Me.grdMovimentacao.Name = "grdMovimentacao"
        Me.grdMovimentacao.Size = New System.Drawing.Size(677, 238)
        Me.grdMovimentacao.TabIndex = 341
        Me.grdMovimentacao.Text = "UltraGrid1"
        '
        'txtValorDescontado
        '
        Me.txtValorDescontado.Enabled = False
        Me.txtValorDescontado.Location = New System.Drawing.Point(457, 107)
        Me.txtValorDescontado.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtValorDescontado.Name = "txtValorDescontado"
        Me.txtValorDescontado.ReadOnly = True
        Me.txtValorDescontado.Size = New System.Drawing.Size(110, 21)
        Me.txtValorDescontado.TabIndex = 342
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(457, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 13)
        Me.Label1.TabIndex = 343
        Me.Label1.Text = "Valor de Descontado"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(640, 382)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 344
        Me.cmdFechar.Text = "F"
        '
        'optTipo
        '
        Appearance43.TextHAlignAsString = "Center"
        Appearance43.TextVAlignAsString = "Middle"
        Me.optTipo.Appearance = Appearance43
        Me.optTipo.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance44.TextHAlignAsString = "Center"
        Appearance44.TextVAlignAsString = "Middle"
        Me.optTipo.ItemAppearance = Appearance44
        Me.optTipo.ItemOrigin = New System.Drawing.Point(5, 3)
        ValueListItem4.DataValue = "U"
        ValueListItem4.DisplayText = "Umidade"
        ValueListItem5.DataValue = "S"
        ValueListItem5.DisplayText = "Sujidade"
        Me.optTipo.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem4, ValueListItem5})
        Me.optTipo.ItemSpacingHorizontal = 2
        Me.optTipo.ItemSpacingVertical = 1
        Me.optTipo.Location = New System.Drawing.Point(574, 6)
        Me.optTipo.Name = "optTipo"
        Me.optTipo.Size = New System.Drawing.Size(111, 36)
        Me.optTipo.TabIndex = 345
        '
        'txtPC_Contrato
        '
        Me.txtPC_Contrato.Enabled = False
        Me.txtPC_Contrato.Location = New System.Drawing.Point(457, 65)
        Me.txtPC_Contrato.MaskInput = "nnn.nn %"
        Me.txtPC_Contrato.MaxValue = 100
        Me.txtPC_Contrato.MinValue = 0
        Me.txtPC_Contrato.Name = "txtPC_Contrato"
        Me.txtPC_Contrato.Nullable = True
        Me.txtPC_Contrato.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtPC_Contrato.ReadOnly = True
        Me.txtPC_Contrato.Size = New System.Drawing.Size(110, 21)
        Me.txtPC_Contrato.TabIndex = 498
        Me.txtPC_Contrato.Value = Nothing
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Location = New System.Drawing.Point(457, 51)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(74, 13)
        Me.Label31.TabIndex = 499
        Me.Label31.Text = "Taxa Contrato"
        '
        'Pesq_ContratoPAF
        '
        Me.Pesq_ContratoPAF.BancoDados_Campo_Codigo = "CD_FORNECEDOR"
        Me.Pesq_ContratoPAF.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_ContratoPAF.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_ContratoPAF.BancoDados_Campo_Descricao = "NO_RAZAO_SOCIAL"
        Me.Pesq_ContratoPAF.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_ContratoPAF.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_ContratoPAF.BancoDados_Tabela = "FORNECEDOR F"
        Me.Pesq_ContratoPAF.Codigo = 0
        Me.Pesq_ContratoPAF.ExibirCodigo = True
        Me.Pesq_ContratoPAF.Location = New System.Drawing.Point(8, 21)
        Me.Pesq_ContratoPAF.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_ContratoPAF.MinimumSize = New System.Drawing.Size(0, 14)
        Me.Pesq_ContratoPAF.Name = "Pesq_ContratoPAF"
        Me.Pesq_ContratoPAF.Size = New System.Drawing.Size(447, 22)
        Me.Pesq_ContratoPAF.TabIndex = 304
        Me.Pesq_ContratoPAF.TelaFiltro = False
        Me.Pesq_ContratoPAF.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(8, 382)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 344
        Me.cmdGravar.Text = "G"
        '
        'txtValorAjuste
        '
        Me.txtValorAjuste.Location = New System.Drawing.Point(573, 107)
        Me.txtValorAjuste.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtValorAjuste.Name = "txtValorAjuste"
        Me.txtValorAjuste.Size = New System.Drawing.Size(110, 21)
        Me.txtValorAjuste.TabIndex = 342
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(573, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 343
        Me.Label2.Text = "Valor Ajuste"
        '
        'frmEstornoDesagio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 434)
        Me.Controls.Add(Me.txtPC_Contrato)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.optTipo)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.txtValorAjuste)
        Me.Controls.Add(Me.txtValorDescontado)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grdMovimentacao)
        Me.Controls.Add(Me.txtValorDesagio)
        Me.Controls.Add(Me.txtMotivo)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Pesq_ContratoPAF)
        Me.Controls.Add(Me.cboContratoFixo)
        Me.Controls.Add(Me.cboNegocicao)
        Me.Controls.Add(Me.Label20)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmEstornoDesagio"
        Me.Text = "Estorno Desagio"
        CType(Me.txtValorDesagio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdMovimentacao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorDescontado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPC_Contrato, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorAjuste, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Pesq_ContratoPAF As Logus.Pesq_CodigoNome
    Friend WithEvents cboContratoFixo As System.Windows.Forms.ComboBox
    Friend WithEvents cboNegocicao As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtValorDesagio As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents txtMotivo As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents grdMovimentacao As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtValorDescontado As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents optTipo As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents txtPC_Contrato As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtValorAjuste As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
