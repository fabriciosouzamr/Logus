<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroPreNegociacao
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
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.grpDados = New Infragistics.Win.Misc.UltraGroupBox
        Me.cboBolsa = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.grpJuros = New Infragistics.Win.Misc.UltraGroupBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.chkCobraJuros = New System.Windows.Forms.CheckBox
        Me.txtTaxaJuros = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtDiasCarencia = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.chkJurosAposCarencia = New System.Windows.Forms.CheckBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtFornecedor = New System.Windows.Forms.TextBox
        Me.cboTipoCacau = New System.Windows.Forms.ComboBox
        Me.txtValorTotal = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.txtValorFrete = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.cboFilialEntrega = New System.Windows.Forms.ComboBox
        Me.txtValorUnitarioPreNegociacao = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.cboLocalEntrega = New System.Windows.Forms.ComboBox
        Me.cboUnidade = New System.Windows.Forms.ComboBox
        Me.cboTipoNegociacao = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.cboTipoPessoa = New System.Windows.Forms.ComboBox
        Me.txtQuantidadePreNegociacao = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.lblPreNegociacao = New System.Windows.Forms.Label
        Me.txtDataNegociacao = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtDataPagamento = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtDataVencimento = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboUF = New System.Windows.Forms.ComboBox
        Me.lblR_UF = New System.Windows.Forms.Label
        CType(Me.grpDados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDados.SuspendLayout()
        CType(Me.cboBolsa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpJuros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpJuros.SuspendLayout()
        CType(Me.txtTaxaJuros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDiasCarencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorFrete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorUnitarioPreNegociacao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantidadePreNegociacao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataNegociacao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataPagamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataVencimento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(549, 337)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 14
        Me.cmdFechar.Text = "F"
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(12, 337)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 13
        Me.cmdGravar.TabStop = False
        Me.cmdGravar.Text = "G"
        '
        'grpDados
        '
        Me.grpDados.Controls.Add(Me.lblR_UF)
        Me.grpDados.Controls.Add(Me.cboUF)
        Me.grpDados.Controls.Add(Me.cboBolsa)
        Me.grpDados.Controls.Add(Me.grpJuros)
        Me.grpDados.Controls.Add(Me.txtFornecedor)
        Me.grpDados.Controls.Add(Me.cboTipoCacau)
        Me.grpDados.Controls.Add(Me.txtValorTotal)
        Me.grpDados.Controls.Add(Me.txtValorFrete)
        Me.grpDados.Controls.Add(Me.cboFilialEntrega)
        Me.grpDados.Controls.Add(Me.txtValorUnitarioPreNegociacao)
        Me.grpDados.Controls.Add(Me.cboLocalEntrega)
        Me.grpDados.Controls.Add(Me.cboUnidade)
        Me.grpDados.Controls.Add(Me.cboTipoNegociacao)
        Me.grpDados.Controls.Add(Me.Label15)
        Me.grpDados.Controls.Add(Me.cboTipoPessoa)
        Me.grpDados.Controls.Add(Me.txtQuantidadePreNegociacao)
        Me.grpDados.Controls.Add(Me.lblPreNegociacao)
        Me.grpDados.Controls.Add(Me.txtDataNegociacao)
        Me.grpDados.Controls.Add(Me.txtDataPagamento)
        Me.grpDados.Controls.Add(Me.txtDataVencimento)
        Me.grpDados.Controls.Add(Me.Label27)
        Me.grpDados.Controls.Add(Me.Label23)
        Me.grpDados.Controls.Add(Me.Label20)
        Me.grpDados.Controls.Add(Me.Label19)
        Me.grpDados.Controls.Add(Me.Label17)
        Me.grpDados.Controls.Add(Me.Label26)
        Me.grpDados.Controls.Add(Me.Label24)
        Me.grpDados.Controls.Add(Me.Label22)
        Me.grpDados.Controls.Add(Me.Label10)
        Me.grpDados.Controls.Add(Me.Label8)
        Me.grpDados.Controls.Add(Me.Label3)
        Me.grpDados.Controls.Add(Me.Label4)
        Me.grpDados.Controls.Add(Me.Label5)
        Me.grpDados.Controls.Add(Me.Label1)
        Me.grpDados.Controls.Add(Me.Label6)
        Me.grpDados.Location = New System.Drawing.Point(12, 12)
        Me.grpDados.Name = "grpDados"
        Me.grpDados.Size = New System.Drawing.Size(582, 317)
        Me.grpDados.TabIndex = 328
        '
        'cboBolsa
        '
        Me.cboBolsa.CheckedListSettings.CheckStateMember = ""
        Me.cboBolsa.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cboBolsa.Location = New System.Drawing.Point(205, 172)
        Me.cboBolsa.Name = "cboBolsa"
        Me.cboBolsa.PreferredDropDownSize = New System.Drawing.Size(0, 0)
        Me.cboBolsa.Size = New System.Drawing.Size(146, 22)
        Me.cboBolsa.TabIndex = 339
        '
        'grpJuros
        '
        Me.grpJuros.Controls.Add(Me.Label18)
        Me.grpJuros.Controls.Add(Me.chkCobraJuros)
        Me.grpJuros.Controls.Add(Me.txtTaxaJuros)
        Me.grpJuros.Controls.Add(Me.txtDiasCarencia)
        Me.grpJuros.Controls.Add(Me.chkJurosAposCarencia)
        Me.grpJuros.Controls.Add(Me.Label21)
        Me.grpJuros.Location = New System.Drawing.Point(9, 247)
        Me.grpJuros.Name = "grpJuros"
        Me.grpJuros.Size = New System.Drawing.Size(357, 61)
        Me.grpJuros.TabIndex = 338
        Me.grpJuros.Text = "Juros"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Location = New System.Drawing.Point(311, 16)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(31, 13)
        Me.Label18.TabIndex = 286
        Me.Label18.Text = "Taxa"
        '
        'chkCobraJuros
        '
        Me.chkCobraJuros.AutoSize = True
        Me.chkCobraJuros.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCobraJuros.Location = New System.Drawing.Point(6, 37)
        Me.chkCobraJuros.Name = "chkCobraJuros"
        Me.chkCobraJuros.Size = New System.Drawing.Size(88, 17)
        Me.chkCobraJuros.TabIndex = 14
        Me.chkCobraJuros.Text = "Cobra Juros?"
        Me.chkCobraJuros.UseVisualStyleBackColor = True
        '
        'txtTaxaJuros
        '
        Me.txtTaxaJuros.Location = New System.Drawing.Point(314, 33)
        Me.txtTaxaJuros.MaskInput = "{LOC}-n.nn"
        Me.txtTaxaJuros.Name = "txtTaxaJuros"
        Me.txtTaxaJuros.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtTaxaJuros.Size = New System.Drawing.Size(32, 21)
        Me.txtTaxaJuros.TabIndex = 17
        '
        'txtDiasCarencia
        '
        Me.txtDiasCarencia.Location = New System.Drawing.Point(100, 34)
        Me.txtDiasCarencia.MaskInput = "{LOC}-nn"
        Me.txtDiasCarencia.MaxValue = 999
        Me.txtDiasCarencia.MinValue = 0
        Me.txtDiasCarencia.Name = "txtDiasCarencia"
        Me.txtDiasCarencia.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtDiasCarencia.Size = New System.Drawing.Size(73, 21)
        Me.txtDiasCarencia.TabIndex = 15
        '
        'chkJurosAposCarencia
        '
        Me.chkJurosAposCarencia.AutoSize = True
        Me.chkJurosAposCarencia.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkJurosAposCarencia.Location = New System.Drawing.Point(179, 37)
        Me.chkJurosAposCarencia.Name = "chkJurosAposCarencia"
        Me.chkJurosAposCarencia.Size = New System.Drawing.Size(129, 17)
        Me.chkJurosAposCarencia.TabIndex = 16
        Me.chkJurosAposCarencia.Text = "Juros Após Carência?"
        Me.chkJurosAposCarencia.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Location = New System.Drawing.Point(97, 16)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(73, 13)
        Me.Label21.TabIndex = 282
        Me.Label21.Text = "Dias Carência"
        '
        'txtFornecedor
        '
        Me.txtFornecedor.Location = New System.Drawing.Point(8, 71)
        Me.txtFornecedor.MaxLength = 4000
        Me.txtFornecedor.Multiline = True
        Me.txtFornecedor.Name = "txtFornecedor"
        Me.txtFornecedor.Size = New System.Drawing.Size(563, 35)
        Me.txtFornecedor.TabIndex = 0
        '
        'cboTipoCacau
        '
        Me.cboTipoCacau.Location = New System.Drawing.Point(467, 171)
        Me.cboTipoCacau.Name = "cboTipoCacau"
        Me.cboTipoCacau.Size = New System.Drawing.Size(104, 21)
        Me.cboTipoCacau.TabIndex = 9
        '
        'txtValorTotal
        '
        Me.txtValorTotal.Location = New System.Drawing.Point(232, 218)
        Me.txtValorTotal.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtValorTotal.Name = "txtValorTotal"
        Me.txtValorTotal.ReadOnly = True
        Me.txtValorTotal.Size = New System.Drawing.Size(103, 21)
        Me.txtValorTotal.TabIndex = 307
        '
        'txtValorFrete
        '
        Me.txtValorFrete.Location = New System.Drawing.Point(123, 218)
        Me.txtValorFrete.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtValorFrete.Name = "txtValorFrete"
        Me.txtValorFrete.Size = New System.Drawing.Size(103, 21)
        Me.txtValorFrete.TabIndex = 11
        '
        'cboFilialEntrega
        '
        Me.cboFilialEntrega.Location = New System.Drawing.Point(415, 125)
        Me.cboFilialEntrega.Name = "cboFilialEntrega"
        Me.cboFilialEntrega.Size = New System.Drawing.Size(156, 21)
        Me.cboFilialEntrega.TabIndex = 5
        '
        'txtValorUnitarioPreNegociacao
        '
        Me.txtValorUnitarioPreNegociacao.Location = New System.Drawing.Point(9, 218)
        Me.txtValorUnitarioPreNegociacao.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtValorUnitarioPreNegociacao.Name = "txtValorUnitarioPreNegociacao"
        Me.txtValorUnitarioPreNegociacao.Size = New System.Drawing.Size(103, 21)
        Me.txtValorUnitarioPreNegociacao.TabIndex = 10
        '
        'cboLocalEntrega
        '
        Me.cboLocalEntrega.Location = New System.Drawing.Point(315, 125)
        Me.cboLocalEntrega.Name = "cboLocalEntrega"
        Me.cboLocalEntrega.Size = New System.Drawing.Size(94, 21)
        Me.cboLocalEntrega.TabIndex = 4
        '
        'cboUnidade
        '
        Me.cboUnidade.Location = New System.Drawing.Point(102, 126)
        Me.cboUnidade.Name = "cboUnidade"
        Me.cboUnidade.Size = New System.Drawing.Size(94, 21)
        Me.cboUnidade.TabIndex = 2
        '
        'cboTipoNegociacao
        '
        Me.cboTipoNegociacao.Location = New System.Drawing.Point(8, 173)
        Me.cboTipoNegociacao.Name = "cboTipoNegociacao"
        Me.cboTipoNegociacao.Size = New System.Drawing.Size(187, 21)
        Me.cboTipoNegociacao.TabIndex = 6
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(338, 203)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(101, 13)
        Me.Label15.TabIndex = 322
        Me.Label15.Text = "Tipo Pessoa - Bolsa"
        '
        'cboTipoPessoa
        '
        Me.cboTipoPessoa.Location = New System.Drawing.Point(341, 219)
        Me.cboTipoPessoa.Name = "cboTipoPessoa"
        Me.cboTipoPessoa.Size = New System.Drawing.Size(230, 21)
        Me.cboTipoPessoa.TabIndex = 12
        '
        'txtQuantidadePreNegociacao
        '
        Me.txtQuantidadePreNegociacao.Location = New System.Drawing.Point(8, 125)
        Me.txtQuantidadePreNegociacao.MaskInput = "{LOC}-nnnn,nnn"
        Me.txtQuantidadePreNegociacao.Name = "txtQuantidadePreNegociacao"
        Me.txtQuantidadePreNegociacao.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtQuantidadePreNegociacao.Size = New System.Drawing.Size(88, 21)
        Me.txtQuantidadePreNegociacao.TabIndex = 1
        '
        'lblPreNegociacao
        '
        Me.lblPreNegociacao.BackColor = System.Drawing.Color.Black
        Me.lblPreNegociacao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPreNegociacao.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPreNegociacao.ForeColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lblPreNegociacao.Location = New System.Drawing.Point(9, 28)
        Me.lblPreNegociacao.Name = "lblPreNegociacao"
        Me.lblPreNegociacao.Size = New System.Drawing.Size(82, 23)
        Me.lblPreNegociacao.TabIndex = 302
        Me.lblPreNegociacao.Text = "NOVO"
        Me.lblPreNegociacao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDataNegociacao
        '
        Me.txtDataNegociacao.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtDataNegociacao.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataNegociacao.Location = New System.Drawing.Point(481, 28)
        Me.txtDataNegociacao.Name = "txtDataNegociacao"
        Me.txtDataNegociacao.ReadOnly = True
        Me.txtDataNegociacao.Size = New System.Drawing.Size(90, 23)
        Me.txtDataNegociacao.TabIndex = 300
        Me.txtDataNegociacao.Value = Nothing
        '
        'txtDataPagamento
        '
        Me.txtDataPagamento.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtDataPagamento.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataPagamento.Location = New System.Drawing.Point(357, 171)
        Me.txtDataPagamento.Name = "txtDataPagamento"
        Me.txtDataPagamento.Size = New System.Drawing.Size(104, 23)
        Me.txtDataPagamento.TabIndex = 8
        Me.txtDataPagamento.Value = Nothing
        '
        'txtDataVencimento
        '
        Me.txtDataVencimento.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtDataVencimento.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataVencimento.Location = New System.Drawing.Point(207, 123)
        Me.txtDataVencimento.Name = "txtDataVencimento"
        Me.txtDataVencimento.Size = New System.Drawing.Size(102, 23)
        Me.txtDataVencimento.TabIndex = 3
        Me.txtDataVencimento.Value = Nothing
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(6, 55)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(61, 13)
        Me.Label27.TabIndex = 336
        Me.Label27.Text = "Fornecedor"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Location = New System.Drawing.Point(464, 157)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(62, 13)
        Me.Label23.TabIndex = 331
        Me.Label23.Text = "Tipo Cacau"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Location = New System.Drawing.Point(229, 202)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(58, 13)
        Me.Label20.TabIndex = 306
        Me.Label20.Text = "Valor Total"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(120, 202)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(77, 13)
        Me.Label19.TabIndex = 304
        Me.Label19.Text = "Frete por Saca"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(13, 202)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 13)
        Me.Label17.TabIndex = 300
        Me.Label17.Text = "Valor Unitário"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Location = New System.Drawing.Point(202, 157)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(33, 13)
        Me.Label26.TabIndex = 335
        Me.Label26.Text = "Bolsa"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Location = New System.Drawing.Point(412, 109)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(67, 13)
        Me.Label24.TabIndex = 331
        Me.Label24.Text = "Filial Entrega"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Location = New System.Drawing.Point(312, 109)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(73, 13)
        Me.Label22.TabIndex = 329
        Me.Label22.Text = "Local Entrega"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(99, 110)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 13)
        Me.Label10.TabIndex = 327
        Me.Label10.Text = "Unidade"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(6, 157)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 13)
        Me.Label8.TabIndex = 324
        Me.Label8.Text = "Tipo Negociacao"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(8, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 303
        Me.Label3.Text = "Número"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(5, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 305
        Me.Label4.Text = "Quantidade"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(478, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 301
        Me.Label5.Text = "Data"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(204, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 295
        Me.Label1.Text = "Data Vencimento"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(358, 155)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 312
        Me.Label6.Text = "Data Pagamento"
        '
        'cboUF
        '
        Me.cboUF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUF.Location = New System.Drawing.Point(372, 281)
        Me.cboUF.Name = "cboUF"
        Me.cboUF.Size = New System.Drawing.Size(199, 21)
        Me.cboUF.TabIndex = 340
        '
        'lblR_UF
        '
        Me.lblR_UF.AutoSize = True
        Me.lblR_UF.BackColor = System.Drawing.Color.Transparent
        Me.lblR_UF.Location = New System.Drawing.Point(372, 263)
        Me.lblR_UF.Name = "lblR_UF"
        Me.lblR_UF.Size = New System.Drawing.Size(40, 13)
        Me.lblR_UF.TabIndex = 341
        Me.lblR_UF.Text = "Estado"
        '
        'frmCadastroPreNegociacao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 396)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.grpDados)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmCadastroPreNegociacao"
        Me.Text = "Cadastro Pré-Negociação"
        CType(Me.grpDados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDados.ResumeLayout(False)
        Me.grpDados.PerformLayout()
        CType(Me.cboBolsa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpJuros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpJuros.ResumeLayout(False)
        Me.grpJuros.PerformLayout()
        CType(Me.txtTaxaJuros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDiasCarencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorFrete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorUnitarioPreNegociacao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantidadePreNegociacao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataNegociacao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataPagamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataVencimento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents grpDados As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtFornecedor As System.Windows.Forms.TextBox
    Friend WithEvents cboTipoCacau As System.Windows.Forms.ComboBox
    Friend WithEvents txtValorTotal As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents txtValorFrete As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents cboFilialEntrega As System.Windows.Forms.ComboBox
    Friend WithEvents txtValorUnitarioPreNegociacao As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents cboLocalEntrega As System.Windows.Forms.ComboBox
    Friend WithEvents cboUnidade As System.Windows.Forms.ComboBox
    Friend WithEvents cboTipoNegociacao As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboTipoPessoa As System.Windows.Forms.ComboBox
    Friend WithEvents txtQuantidadePreNegociacao As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents lblPreNegociacao As System.Windows.Forms.Label
    Friend WithEvents txtDataNegociacao As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtDataPagamento As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtDataVencimento As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents grpJuros As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents chkCobraJuros As System.Windows.Forms.CheckBox
    Friend WithEvents txtTaxaJuros As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents txtDiasCarencia As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents chkJurosAposCarencia As System.Windows.Forms.CheckBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cboBolsa As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cboUF As System.Windows.Forms.ComboBox
    Friend WithEvents lblR_UF As System.Windows.Forms.Label
End Class
