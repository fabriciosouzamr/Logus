<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroPagamento
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
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadastroPagamento))
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboTipoPagamento = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboFormaPagamento = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboFavorecido = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboFilialPagadora = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtDescricao = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.grpContrato = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtValorAplicado = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.txtSaldoContrato = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.txtSaldoPagamento = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboNegociacao = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.cboContratoPaf = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.cmdAdiciona_Contrato = New Infragistics.Win.Misc.UltraButton
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.cboContratoFixo = New System.Windows.Forms.ComboBox
        Me.grdGeral = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.grpICMS = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtValorICMS = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.txtSaldoPagamentoICMS = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboContratoPafICMS = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.cmdAdiciona_ICMS = New Infragistics.Win.Misc.UltraButton
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtNF = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.chkFavorecidoAlternativo = New System.Windows.Forms.CheckBox
        Me.FavorecidoAlternativo = New Logus.Pesq_CodigoNome
        Me.cboContaCorrente = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.grpValor = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtValor = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.chkValorPagamento = New System.Windows.Forms.CheckBox
        Me.Pesq_Fornecedor = New Logus.Pesq_CodigoNome
        CType(Me.grpContrato, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpContrato.SuspendLayout()
        CType(Me.txtValorAplicado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSaldoContrato, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSaldoPagamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboNegociacao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboContratoPaf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpICMS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpICMS.SuspendLayout()
        CType(Me.txtValorICMS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSaldoPagamentoICMS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboContratoPafICMS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.cboContaCorrente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpValor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpValor.SuspendLayout()
        CType(Me.txtValor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(313, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 195
        Me.Label1.Text = "Tipo de Pagamento"
        '
        'cboTipoPagamento
        '
        Me.cboTipoPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoPagamento.Location = New System.Drawing.Point(313, 20)
        Me.cboTipoPagamento.Name = "cboTipoPagamento"
        Me.cboTipoPagamento.Size = New System.Drawing.Size(280, 21)
        Me.cboTipoPagamento.TabIndex = 194
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(453, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 13)
        Me.Label2.TabIndex = 197
        Me.Label2.Text = "Forma de Pagamento"
        '
        'cboFormaPagamento
        '
        Me.cboFormaPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFormaPagamento.Location = New System.Drawing.Point(453, 64)
        Me.cboFormaPagamento.Name = "cboFormaPagamento"
        Me.cboFormaPagamento.Size = New System.Drawing.Size(139, 21)
        Me.cboFormaPagamento.TabIndex = 196
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 199
        Me.Label3.Text = "Favorecido"
        '
        'cboFavorecido
        '
        Me.cboFavorecido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFavorecido.Location = New System.Drawing.Point(5, 107)
        Me.cboFavorecido.Name = "cboFavorecido"
        Me.cboFavorecido.Size = New System.Drawing.Size(358, 21)
        Me.cboFavorecido.TabIndex = 198
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(371, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 201
        Me.Label4.Text = "Filial Pagadora"
        '
        'cboFilialPagadora
        '
        Me.cboFilialPagadora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilialPagadora.Location = New System.Drawing.Point(371, 107)
        Me.cboFilialPagadora.Name = "cboFilialPagadora"
        Me.cboFilialPagadora.Size = New System.Drawing.Size(220, 21)
        Me.cboFilialPagadora.TabIndex = 200
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 212
        Me.Label8.Text = "Fornecedor"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 213
        Me.Label6.Text = "Descrição"
        '
        'txtDescricao
        '
        Me.txtDescricao.Location = New System.Drawing.Point(5, 64)
        Me.txtDescricao.MaxLength = 40
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(309, 20)
        Me.txtDescricao.TabIndex = 214
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(320, 137)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 13)
        Me.Label9.TabIndex = 219
        Me.Label9.Text = "Conta Corrente"
        '
        'grpContrato
        '
        Me.grpContrato.Controls.Add(Me.txtValorAplicado)
        Me.grpContrato.Controls.Add(Me.txtSaldoContrato)
        Me.grpContrato.Controls.Add(Me.txtSaldoPagamento)
        Me.grpContrato.Controls.Add(Me.Label5)
        Me.grpContrato.Controls.Add(Me.cboNegociacao)
        Me.grpContrato.Controls.Add(Me.cboContratoPaf)
        Me.grpContrato.Controls.Add(Me.cmdAdiciona_Contrato)
        Me.grpContrato.Controls.Add(Me.Label21)
        Me.grpContrato.Controls.Add(Me.Label20)
        Me.grpContrato.Controls.Add(Me.Label17)
        Me.grpContrato.Controls.Add(Me.cboContratoFixo)
        Me.grpContrato.Location = New System.Drawing.Point(5, 191)
        Me.grpContrato.Name = "grpContrato"
        Me.grpContrato.Size = New System.Drawing.Size(583, 63)
        Me.grpContrato.TabIndex = 222
        Me.grpContrato.Text = "Contrato"
        '
        'txtValorAplicado
        '
        Me.txtValorAplicado.Location = New System.Drawing.Point(347, 33)
        Me.txtValorAplicado.Name = "txtValorAplicado"
        Me.txtValorAplicado.Size = New System.Drawing.Size(93, 21)
        Me.txtValorAplicado.TabIndex = 391
        '
        'txtSaldoContrato
        '
        Me.txtSaldoContrato.Location = New System.Drawing.Point(248, 33)
        Me.txtSaldoContrato.Name = "txtSaldoContrato"
        Me.txtSaldoContrato.ReadOnly = True
        Me.txtSaldoContrato.Size = New System.Drawing.Size(93, 21)
        Me.txtSaldoContrato.TabIndex = 390
        '
        'txtSaldoPagamento
        '
        Me.txtSaldoPagamento.Location = New System.Drawing.Point(443, 33)
        Me.txtSaldoPagamento.Name = "txtSaldoPagamento"
        Me.txtSaldoPagamento.ReadOnly = True
        Me.txtSaldoPagamento.Size = New System.Drawing.Size(93, 21)
        Me.txtSaldoPagamento.TabIndex = 388
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(265, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 242
        Me.Label5.Text = "Saldo Contrato"
        '
        'cboNegociacao
        '
        Me.cboNegociacao.CheckedListSettings.CheckStateMember = ""
        Me.cboNegociacao.Location = New System.Drawing.Point(133, 33)
        Me.cboNegociacao.Name = "cboNegociacao"
        Me.cboNegociacao.PreferredDropDownSize = New System.Drawing.Size(0, 0)
        Me.cboNegociacao.Size = New System.Drawing.Size(54, 22)
        Me.cboNegociacao.TabIndex = 241
        Me.cboNegociacao.Text = "UltraCombo1"
        '
        'cboContratoPaf
        '
        Me.cboContratoPaf.CheckedListSettings.CheckStateMember = ""
        Me.cboContratoPaf.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cboContratoPaf.Location = New System.Drawing.Point(6, 33)
        Me.cboContratoPaf.Name = "cboContratoPaf"
        Me.cboContratoPaf.PreferredDropDownSize = New System.Drawing.Size(0, 0)
        Me.cboContratoPaf.Size = New System.Drawing.Size(124, 22)
        Me.cboContratoPaf.TabIndex = 240
        '
        'cmdAdiciona_Contrato
        '
        Appearance1.Image = Global.Logus.My.Resources.Resources.Expand_Vertical
        Appearance1.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.cmdAdiciona_Contrato.Appearance = Appearance1
        Me.cmdAdiciona_Contrato.Location = New System.Drawing.Point(543, 26)
        Me.cmdAdiciona_Contrato.Name = "cmdAdiciona_Contrato"
        Me.cmdAdiciona_Contrato.Size = New System.Drawing.Size(28, 28)
        Me.cmdAdiciona_Contrato.TabIndex = 239
        Me.cmdAdiciona_Contrato.TabStop = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(445, 17)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(91, 13)
        Me.Label21.TabIndex = 238
        Me.Label21.Text = "Saldo Pagamento"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 18)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(47, 13)
        Me.Label20.TabIndex = 235
        Me.Label20.Text = "Contrato"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(355, 17)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(31, 13)
        Me.Label17.TabIndex = 232
        Me.Label17.Text = "Valor"
        '
        'cboContratoFixo
        '
        Me.cboContratoFixo.Location = New System.Drawing.Point(193, 33)
        Me.cboContratoFixo.Name = "cboContratoFixo"
        Me.cboContratoFixo.Size = New System.Drawing.Size(49, 21)
        Me.cboContratoFixo.TabIndex = 224
        '
        'grdGeral
        '
        Appearance2.BackColor = System.Drawing.SystemColors.Window
        Appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdGeral.DisplayLayout.Appearance = Appearance2
        Me.grdGeral.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdGeral.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.BorderColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.GroupByBox.Appearance = Appearance3
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdGeral.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance4
        Me.grdGeral.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance5.BackColor2 = System.Drawing.SystemColors.Control
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdGeral.DisplayLayout.GroupByBox.PromptAppearance = Appearance5
        Me.grdGeral.DisplayLayout.MaxColScrollRegions = 1
        Me.grdGeral.DisplayLayout.MaxRowScrollRegions = 1
        Appearance6.BackColor = System.Drawing.SystemColors.Window
        Appearance6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdGeral.DisplayLayout.Override.ActiveCellAppearance = Appearance6
        Appearance7.BackColor = System.Drawing.SystemColors.Highlight
        Appearance7.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdGeral.DisplayLayout.Override.ActiveRowAppearance = Appearance7
        Me.grdGeral.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdGeral.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.Override.CardAreaAppearance = Appearance8
        Appearance9.BorderColor = System.Drawing.Color.Silver
        Appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdGeral.DisplayLayout.Override.CellAppearance = Appearance9
        Me.grdGeral.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdGeral.DisplayLayout.Override.CellPadding = 0
        Appearance10.BackColor = System.Drawing.SystemColors.Control
        Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance10.BorderColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.Override.GroupByRowAppearance = Appearance10
        Appearance11.TextHAlignAsString = "Left"
        Me.grdGeral.DisplayLayout.Override.HeaderAppearance = Appearance11
        Me.grdGeral.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdGeral.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.BorderColor = System.Drawing.Color.Silver
        Me.grdGeral.DisplayLayout.Override.RowAppearance = Appearance12
        Me.grdGeral.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance13.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdGeral.DisplayLayout.Override.TemplateAddRowAppearance = Appearance13
        Me.grdGeral.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdGeral.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdGeral.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdGeral.Location = New System.Drawing.Point(5, 260)
        Me.grdGeral.Name = "grdGeral"
        Me.grdGeral.Size = New System.Drawing.Size(586, 140)
        Me.grdGeral.TabIndex = 223
        Me.grdGeral.Text = "UltraGrid1"
        '
        'grpICMS
        '
        Me.grpICMS.Controls.Add(Me.txtValorICMS)
        Me.grpICMS.Controls.Add(Me.txtSaldoPagamentoICMS)
        Me.grpICMS.Controls.Add(Me.Label7)
        Me.grpICMS.Controls.Add(Me.cboContratoPafICMS)
        Me.grpICMS.Controls.Add(Me.cmdAdiciona_ICMS)
        Me.grpICMS.Controls.Add(Me.Label22)
        Me.grpICMS.Controls.Add(Me.Label16)
        Me.grpICMS.Controls.Add(Me.txtNF)
        Me.grpICMS.Controls.Add(Me.Label14)
        Me.grpICMS.Location = New System.Drawing.Point(5, 262)
        Me.grpICMS.Name = "grpICMS"
        Me.grpICMS.Size = New System.Drawing.Size(583, 63)
        Me.grpICMS.TabIndex = 224
        Me.grpICMS.Text = "Pagamento ICMS"
        Me.grpICMS.Visible = False
        '
        'txtValorICMS
        '
        Me.txtValorICMS.Location = New System.Drawing.Point(276, 33)
        Me.txtValorICMS.Name = "txtValorICMS"
        Me.txtValorICMS.Size = New System.Drawing.Size(93, 21)
        Me.txtValorICMS.TabIndex = 392
        '
        'txtSaldoPagamentoICMS
        '
        Me.txtSaldoPagamentoICMS.Location = New System.Drawing.Point(375, 32)
        Me.txtSaldoPagamentoICMS.Name = "txtSaldoPagamentoICMS"
        Me.txtSaldoPagamentoICMS.ReadOnly = True
        Me.txtSaldoPagamentoICMS.Size = New System.Drawing.Size(93, 21)
        Me.txtSaldoPagamentoICMS.TabIndex = 389
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(372, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 13)
        Me.Label7.TabIndex = 242
        Me.Label7.Text = "Saldo Pagamento"
        '
        'cboContratoPafICMS
        '
        Me.cboContratoPafICMS.CheckedListSettings.CheckStateMember = ""
        Me.cboContratoPafICMS.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cboContratoPafICMS.Location = New System.Drawing.Point(6, 33)
        Me.cboContratoPafICMS.Name = "cboContratoPafICMS"
        Me.cboContratoPafICMS.PreferredDropDownSize = New System.Drawing.Size(0, 0)
        Me.cboContratoPafICMS.Size = New System.Drawing.Size(139, 22)
        Me.cboContratoPafICMS.TabIndex = 241
        '
        'cmdAdiciona_ICMS
        '
        Appearance14.Image = Global.Logus.My.Resources.Resources.Expand_Vertical
        Appearance14.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance14.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.cmdAdiciona_ICMS.Appearance = Appearance14
        Me.cmdAdiciona_ICMS.Location = New System.Drawing.Point(543, 26)
        Me.cmdAdiciona_ICMS.Name = "cmdAdiciona_ICMS"
        Me.cmdAdiciona_ICMS.Size = New System.Drawing.Size(28, 28)
        Me.cmdAdiciona_ICMS.TabIndex = 238
        Me.cmdAdiciona_ICMS.TabStop = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(153, 16)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(61, 13)
        Me.Label22.TabIndex = 237
        Me.Label22.Text = "Número NF"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(273, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(31, 13)
        Me.Label16.TabIndex = 230
        Me.Label16.Text = "Valor"
        '
        'txtNF
        '
        Me.txtNF.Location = New System.Drawing.Point(153, 33)
        Me.txtNF.MaxLength = 8
        Me.txtNF.Name = "txtNF"
        Me.txtNF.Size = New System.Drawing.Size(112, 20)
        Me.txtNF.TabIndex = 228
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 18)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(47, 13)
        Me.Label14.TabIndex = 225
        Me.Label14.Text = "Contrato"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(545, 408)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 226
        Me.cmdFechar.Text = "F"
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(4, 408)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 225
        Me.cmdGravar.TabStop = False
        Me.cmdGravar.Text = "G"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.chkFavorecidoAlternativo)
        Me.UltraGroupBox1.Controls.Add(Me.FavorecidoAlternativo)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(4, 137)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(310, 46)
        Me.UltraGroupBox1.TabIndex = 227
        Me.UltraGroupBox1.Text = "Favorecido Alternativo"
        '
        'chkFavorecidoAlternativo
        '
        Me.chkFavorecidoAlternativo.AutoSize = True
        Me.chkFavorecidoAlternativo.Location = New System.Drawing.Point(149, 1)
        Me.chkFavorecidoAlternativo.Name = "chkFavorecidoAlternativo"
        Me.chkFavorecidoAlternativo.Size = New System.Drawing.Size(15, 14)
        Me.chkFavorecidoAlternativo.TabIndex = 218
        Me.chkFavorecidoAlternativo.UseVisualStyleBackColor = True
        '
        'FavorecidoAlternativo
        '
        Me.FavorecidoAlternativo.BancoDados_Campo_Codigo = "CD_FORNECEDOR"
        Me.FavorecidoAlternativo.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.FavorecidoAlternativo.BancoDados_Campo_Codigo2 = Nothing
        Me.FavorecidoAlternativo.BancoDados_Campo_Descricao = "NO_RAZAO_SOCIAL"
        Me.FavorecidoAlternativo.BancoDados_Campo_Pesquisa = Nothing
        Me.FavorecidoAlternativo.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.FavorecidoAlternativo.BancoDados_Tabela = "FORNECEDOR F"
        Me.FavorecidoAlternativo.Codigo = 0
        Me.FavorecidoAlternativo.ExibirCodigo = True
        Me.FavorecidoAlternativo.Location = New System.Drawing.Point(9, 16)
        Me.FavorecidoAlternativo.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.FavorecidoAlternativo.MinimumSize = New System.Drawing.Size(0, 28)
        Me.FavorecidoAlternativo.Name = "FavorecidoAlternativo"
        Me.FavorecidoAlternativo.Size = New System.Drawing.Size(295, 28)
        Me.FavorecidoAlternativo.TabIndex = 217
        Me.FavorecidoAlternativo.TelaFiltro = False
        Me.FavorecidoAlternativo.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'cboContaCorrente
        '
        Me.cboContaCorrente.CheckedListSettings.CheckStateMember = ""
        Me.cboContaCorrente.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cboContaCorrente.Location = New System.Drawing.Point(320, 152)
        Me.cboContaCorrente.Name = "cboContaCorrente"
        Me.cboContaCorrente.PreferredDropDownSize = New System.Drawing.Size(0, 0)
        Me.cboContaCorrente.Size = New System.Drawing.Size(270, 22)
        Me.cboContaCorrente.TabIndex = 241
        '
        'grpValor
        '
        Me.grpValor.Controls.Add(Me.txtValor)
        Me.grpValor.Controls.Add(Me.chkValorPagamento)
        Me.grpValor.Location = New System.Drawing.Point(323, 42)
        Me.grpValor.Name = "grpValor"
        Me.grpValor.Size = New System.Drawing.Size(122, 46)
        Me.grpValor.TabIndex = 242
        Me.grpValor.Text = "Valor"
        '
        'txtValor
        '
        Me.txtValor.Location = New System.Drawing.Point(23, 19)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(93, 21)
        Me.txtValor.TabIndex = 392
        '
        'chkValorPagamento
        '
        Me.chkValorPagamento.AutoSize = True
        Me.chkValorPagamento.Location = New System.Drawing.Point(8, 23)
        Me.chkValorPagamento.Name = "chkValorPagamento"
        Me.chkValorPagamento.Size = New System.Drawing.Size(15, 14)
        Me.chkValorPagamento.TabIndex = 219
        Me.chkValorPagamento.UseVisualStyleBackColor = True
        '
        'Pesq_Fornecedor
        '
        Me.Pesq_Fornecedor.BancoDados_Campo_Codigo = "CD_FORNECEDOR"
        Me.Pesq_Fornecedor.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Fornecedor.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_Fornecedor.BancoDados_Campo_Descricao = "NO_RAZAO_SOCIAL"
        Me.Pesq_Fornecedor.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_Fornecedor.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Fornecedor.BancoDados_Tabela = "FORNECEDOR F"
        Me.Pesq_Fornecedor.Codigo = 0
        Me.Pesq_Fornecedor.ExibirCodigo = True
        Me.Pesq_Fornecedor.Location = New System.Drawing.Point(5, 18)
        Me.Pesq_Fornecedor.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_Fornecedor.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_Fornecedor.Name = "Pesq_Fornecedor"
        Me.Pesq_Fornecedor.Size = New System.Drawing.Size(300, 28)
        Me.Pesq_Fornecedor.TabIndex = 202
        Me.Pesq_Fornecedor.TelaFiltro = False
        Me.Pesq_Fornecedor.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'frmCadastroPagamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 457)
        Me.Controls.Add(Me.grpValor)
        Me.Controls.Add(Me.cboContaCorrente)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.grpICMS)
        Me.Controls.Add(Me.grdGeral)
        Me.Controls.Add(Me.grpContrato)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtDescricao)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Pesq_Fornecedor)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboFilialPagadora)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboFavorecido)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboFormaPagamento)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboTipoPagamento)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCadastroPagamento"
        Me.Text = "Cadastro Pagamento"
        CType(Me.grpContrato, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpContrato.ResumeLayout(False)
        Me.grpContrato.PerformLayout()
        CType(Me.txtValorAplicado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSaldoContrato, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSaldoPagamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboNegociacao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboContratoPaf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpICMS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpICMS.ResumeLayout(False)
        Me.grpICMS.PerformLayout()
        CType(Me.txtValorICMS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSaldoPagamentoICMS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboContratoPafICMS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.cboContaCorrente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpValor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpValor.ResumeLayout(False)
        Me.grpValor.PerformLayout()
        CType(Me.txtValor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboTipoPagamento As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboFormaPagamento As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboFavorecido As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboFilialPagadora As System.Windows.Forms.ComboBox
    Friend WithEvents Pesq_Fornecedor As Logus.Pesq_CodigoNome
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDescricao As System.Windows.Forms.TextBox
    Friend WithEvents FavorecidoAlternativo As Logus.Pesq_CodigoNome
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents grpContrato As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents cboContratoFixo As System.Windows.Forms.ComboBox
    Friend WithEvents grdGeral As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grpICMS As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtNF As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cmdAdiciona_Contrato As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdAdiciona_ICMS As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents chkFavorecidoAlternativo As System.Windows.Forms.CheckBox
    Friend WithEvents cboContratoPaf As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cboContaCorrente As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cboNegociacao As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cboContratoPafICMS As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents grpValor As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents chkValorPagamento As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtValorAplicado As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents txtSaldoContrato As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents txtSaldoPagamento As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents txtSaldoPagamentoICMS As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents txtValor As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents txtValorICMS As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
End Class
