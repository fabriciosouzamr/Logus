<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroNegociacao
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
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadastroNegociacao))
        Me.grpDados = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtSaldo = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtValorAdiantamento = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.txtMotivoDataVencimento = New System.Windows.Forms.TextBox
        Me.cboTipoCacau = New System.Windows.Forms.ComboBox
        Me.txtAliquotaICMS = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtDataParaFixacao = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtValorTotal = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.txtValorFrete = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.cboFilialEntrega = New System.Windows.Forms.ComboBox
        Me.txtValorUnitarioNegociacao = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.cboLocalEntrega = New System.Windows.Forms.ComboBox
        Me.cboUnidade = New System.Windows.Forms.ComboBox
        Me.cboTipoNegociacao = New System.Windows.Forms.ComboBox
        Me.grpJuros = New Infragistics.Win.Misc.UltraGroupBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.chkCobraJuros = New System.Windows.Forms.CheckBox
        Me.txtTaxaJuros = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtDiasCarencia = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.chkJurosAposCarencia = New System.Windows.Forms.CheckBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.cboTipoPessoa = New System.Windows.Forms.ComboBox
        Me.txtQuantidadeNegociacao = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.cmdPostoFabrica = New Infragistics.Win.Misc.UltraButton
        Me.cmdPostoFazenda = New Infragistics.Win.Misc.UltraButton
        Me.txtQuantidadeFabrica = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtQuantidadeFilial = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtValorAdiantamentoAberto = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.txtValorMedioFrete = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.txtQuantidadeFazenda = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.lblNegociacao = New System.Windows.Forms.Label
        Me.txtDataNegociacao = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtDataPagamento = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtDataVencimento = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lbl_ValorTotal = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdNovo = New Infragistics.Win.Misc.UltraButton
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.cmdImprimir = New Infragistics.Win.Misc.UltraButton
        Me.cboBolsa = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Pesq_ContratoPAF = New Logus.Pesq_CodigoNome
        Me.txtPremioCRM = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.lbl_CRM = New System.Windows.Forms.Label
        CType(Me.grpDados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDados.SuspendLayout()
        CType(Me.txtSaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorAdiantamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAliquotaICMS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataParaFixacao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorFrete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorUnitarioNegociacao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpJuros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpJuros.SuspendLayout()
        CType(Me.txtTaxaJuros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDiasCarencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantidadeNegociacao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.txtQuantidadeFabrica, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantidadeFilial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorAdiantamentoAberto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorMedioFrete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantidadeFazenda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataNegociacao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataPagamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataVencimento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboBolsa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPremioCRM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpDados
        '
        Me.grpDados.Controls.Add(Me.txtPremioCRM)
        Me.grpDados.Controls.Add(Me.lbl_CRM)
        Me.grpDados.Controls.Add(Me.cboBolsa)
        Me.grpDados.Controls.Add(Me.txtSaldo)
        Me.grpDados.Controls.Add(Me.txtValorAdiantamento)
        Me.grpDados.Controls.Add(Me.txtMotivoDataVencimento)
        Me.grpDados.Controls.Add(Me.cboTipoCacau)
        Me.grpDados.Controls.Add(Me.txtAliquotaICMS)
        Me.grpDados.Controls.Add(Me.txtDataParaFixacao)
        Me.grpDados.Controls.Add(Me.txtValorTotal)
        Me.grpDados.Controls.Add(Me.txtValorFrete)
        Me.grpDados.Controls.Add(Me.cboFilialEntrega)
        Me.grpDados.Controls.Add(Me.txtValorUnitarioNegociacao)
        Me.grpDados.Controls.Add(Me.cboLocalEntrega)
        Me.grpDados.Controls.Add(Me.cboUnidade)
        Me.grpDados.Controls.Add(Me.cboTipoNegociacao)
        Me.grpDados.Controls.Add(Me.grpJuros)
        Me.grpDados.Controls.Add(Me.Label15)
        Me.grpDados.Controls.Add(Me.cboTipoPessoa)
        Me.grpDados.Controls.Add(Me.txtQuantidadeNegociacao)
        Me.grpDados.Controls.Add(Me.UltraGroupBox1)
        Me.grpDados.Controls.Add(Me.lblNegociacao)
        Me.grpDados.Controls.Add(Me.txtDataNegociacao)
        Me.grpDados.Controls.Add(Me.txtDataPagamento)
        Me.grpDados.Controls.Add(Me.txtDataVencimento)
        Me.grpDados.Controls.Add(Me.Pesq_ContratoPAF)
        Me.grpDados.Controls.Add(Me.Label28)
        Me.grpDados.Controls.Add(Me.Label27)
        Me.grpDados.Controls.Add(Me.Label23)
        Me.grpDados.Controls.Add(Me.Label7)
        Me.grpDados.Controls.Add(Me.lbl_ValorTotal)
        Me.grpDados.Controls.Add(Me.Label19)
        Me.grpDados.Controls.Add(Me.Label17)
        Me.grpDados.Controls.Add(Me.Label26)
        Me.grpDados.Controls.Add(Me.Label25)
        Me.grpDados.Controls.Add(Me.Label24)
        Me.grpDados.Controls.Add(Me.Label22)
        Me.grpDados.Controls.Add(Me.Label10)
        Me.grpDados.Controls.Add(Me.Label8)
        Me.grpDados.Controls.Add(Me.Label3)
        Me.grpDados.Controls.Add(Me.Label4)
        Me.grpDados.Controls.Add(Me.Label5)
        Me.grpDados.Controls.Add(Me.Label1)
        Me.grpDados.Controls.Add(Me.Label6)
        Me.grpDados.Controls.Add(Me.Label9)
        Me.grpDados.Controls.Add(Me.Label2)
        Me.grpDados.Location = New System.Drawing.Point(5, 3)
        Me.grpDados.Name = "grpDados"
        Me.grpDados.Size = New System.Drawing.Size(582, 366)
        Me.grpDados.TabIndex = 324
        '
        'txtSaldo
        '
        Me.txtSaldo.Location = New System.Drawing.Point(382, 23)
        Me.txtSaldo.MaskInput = "{LOC}nn,nnn,nnn"
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.ReadOnly = True
        Me.txtSaldo.Size = New System.Drawing.Size(89, 21)
        Me.txtSaldo.TabIndex = 340
        '
        'txtValorAdiantamento
        '
        Me.txtValorAdiantamento.Location = New System.Drawing.Point(468, 335)
        Me.txtValorAdiantamento.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtValorAdiantamento.Name = "txtValorAdiantamento"
        Me.txtValorAdiantamento.Size = New System.Drawing.Size(103, 21)
        Me.txtValorAdiantamento.TabIndex = 20
        '
        'txtMotivoDataVencimento
        '
        Me.txtMotivoDataVencimento.Location = New System.Drawing.Point(17, 335)
        Me.txtMotivoDataVencimento.MaxLength = 4000
        Me.txtMotivoDataVencimento.Multiline = True
        Me.txtMotivoDataVencimento.Name = "txtMotivoDataVencimento"
        Me.txtMotivoDataVencimento.Size = New System.Drawing.Size(441, 21)
        Me.txtMotivoDataVencimento.TabIndex = 19
        '
        'cboTipoCacau
        '
        Me.cboTipoCacau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoCacau.Location = New System.Drawing.Point(435, 226)
        Me.cboTipoCacau.Name = "cboTipoCacau"
        Me.cboTipoCacau.Size = New System.Drawing.Size(138, 21)
        Me.cboTipoCacau.TabIndex = 13
        '
        'txtAliquotaICMS
        '
        Me.txtAliquotaICMS.Location = New System.Drawing.Point(121, 226)
        Me.txtAliquotaICMS.MaskInput = "{LOC}-nn.nnnn"
        Me.txtAliquotaICMS.Name = "txtAliquotaICMS"
        Me.txtAliquotaICMS.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtAliquotaICMS.Size = New System.Drawing.Size(90, 21)
        Me.txtAliquotaICMS.TabIndex = 11
        '
        'txtDataParaFixacao
        '
        Me.txtDataParaFixacao.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataParaFixacao.Location = New System.Drawing.Point(206, 177)
        Me.txtDataParaFixacao.Name = "txtDataParaFixacao"
        Me.txtDataParaFixacao.Size = New System.Drawing.Size(104, 23)
        Me.txtDataParaFixacao.TabIndex = 7
        Me.txtDataParaFixacao.Value = Nothing
        '
        'txtValorTotal
        '
        Me.txtValorTotal.Location = New System.Drawing.Point(326, 226)
        Me.txtValorTotal.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtValorTotal.Name = "txtValorTotal"
        Me.txtValorTotal.ReadOnly = True
        Me.txtValorTotal.Size = New System.Drawing.Size(103, 21)
        Me.txtValorTotal.TabIndex = 307
        '
        'txtValorFrete
        '
        Me.txtValorFrete.Location = New System.Drawing.Point(217, 226)
        Me.txtValorFrete.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtValorFrete.Name = "txtValorFrete"
        Me.txtValorFrete.Size = New System.Drawing.Size(103, 21)
        Me.txtValorFrete.TabIndex = 12
        '
        'cboFilialEntrega
        '
        Me.cboFilialEntrega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilialEntrega.Location = New System.Drawing.Point(416, 133)
        Me.cboFilialEntrega.Name = "cboFilialEntrega"
        Me.cboFilialEntrega.Size = New System.Drawing.Size(156, 21)
        Me.cboFilialEntrega.TabIndex = 5
        '
        'txtValorUnitarioNegociacao
        '
        Me.txtValorUnitarioNegociacao.Location = New System.Drawing.Point(12, 226)
        Me.txtValorUnitarioNegociacao.MaskInput = "{currency:-9.2}"
        Me.txtValorUnitarioNegociacao.Name = "txtValorUnitarioNegociacao"
        Me.txtValorUnitarioNegociacao.Size = New System.Drawing.Size(103, 21)
        Me.txtValorUnitarioNegociacao.TabIndex = 10
        '
        'cboLocalEntrega
        '
        Me.cboLocalEntrega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLocalEntrega.Location = New System.Drawing.Point(316, 133)
        Me.cboLocalEntrega.Name = "cboLocalEntrega"
        Me.cboLocalEntrega.Size = New System.Drawing.Size(94, 21)
        Me.cboLocalEntrega.TabIndex = 4
        '
        'cboUnidade
        '
        Me.cboUnidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnidade.Location = New System.Drawing.Point(103, 134)
        Me.cboUnidade.Name = "cboUnidade"
        Me.cboUnidade.Size = New System.Drawing.Size(94, 21)
        Me.cboUnidade.TabIndex = 2
        '
        'cboTipoNegociacao
        '
        Me.cboTipoNegociacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoNegociacao.Location = New System.Drawing.Point(10, 177)
        Me.cboTipoNegociacao.Name = "cboTipoNegociacao"
        Me.cboTipoNegociacao.Size = New System.Drawing.Size(187, 21)
        Me.cboTipoNegociacao.TabIndex = 6
        '
        'grpJuros
        '
        Me.grpJuros.Controls.Add(Me.Label18)
        Me.grpJuros.Controls.Add(Me.chkCobraJuros)
        Me.grpJuros.Controls.Add(Me.txtTaxaJuros)
        Me.grpJuros.Controls.Add(Me.txtDiasCarencia)
        Me.grpJuros.Controls.Add(Me.chkJurosAposCarencia)
        Me.grpJuros.Controls.Add(Me.Label21)
        Me.grpJuros.Location = New System.Drawing.Point(12, 253)
        Me.grpJuros.Name = "grpJuros"
        Me.grpJuros.Size = New System.Drawing.Size(357, 61)
        Me.grpJuros.TabIndex = 325
        Me.grpJuros.Text = "Juros"
        Me.grpJuros.Visible = False
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
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(375, 270)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(101, 13)
        Me.Label15.TabIndex = 322
        Me.Label15.Text = "Tipo Pessoa - Bolsa"
        '
        'cboTipoPessoa
        '
        Me.cboTipoPessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoPessoa.Location = New System.Drawing.Point(378, 286)
        Me.cboTipoPessoa.Name = "cboTipoPessoa"
        Me.cboTipoPessoa.Size = New System.Drawing.Size(194, 21)
        Me.cboTipoPessoa.TabIndex = 18
        '
        'txtQuantidadeNegociacao
        '
        Me.txtQuantidadeNegociacao.Location = New System.Drawing.Point(9, 133)
        Me.txtQuantidadeNegociacao.MaskInput = "{LOC}-nnnn,nnn"
        Me.txtQuantidadeNegociacao.Name = "txtQuantidadeNegociacao"
        Me.txtQuantidadeNegociacao.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtQuantidadeNegociacao.Size = New System.Drawing.Size(88, 21)
        Me.txtQuantidadeNegociacao.TabIndex = 1
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.cmdPostoFabrica)
        Me.UltraGroupBox1.Controls.Add(Me.cmdPostoFazenda)
        Me.UltraGroupBox1.Controls.Add(Me.txtQuantidadeFabrica)
        Me.UltraGroupBox1.Controls.Add(Me.txtQuantidadeFilial)
        Me.UltraGroupBox1.Controls.Add(Me.txtValorAdiantamentoAberto)
        Me.UltraGroupBox1.Controls.Add(Me.txtValorMedioFrete)
        Me.UltraGroupBox1.Controls.Add(Me.txtQuantidadeFazenda)
        Me.UltraGroupBox1.Controls.Add(Me.Label16)
        Me.UltraGroupBox1.Controls.Add(Me.Label12)
        Me.UltraGroupBox1.Controls.Add(Me.Label11)
        Me.UltraGroupBox1.Controls.Add(Me.Label14)
        Me.UltraGroupBox1.Controls.Add(Me.Label13)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(8, 51)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(564, 63)
        Me.UltraGroupBox1.TabIndex = 317
        Me.UltraGroupBox1.Text = "Dados do Contrato PAF"
        '
        'cmdPostoFabrica
        '
        Appearance28.Image = Global.Logus.My.Resources.Resources.Pasta
        Appearance28.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance28.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.cmdPostoFabrica.Appearance = Appearance28
        Me.cmdPostoFabrica.ImageSize = New System.Drawing.Size(20, 20)
        Me.cmdPostoFabrica.Location = New System.Drawing.Point(198, 29)
        Me.cmdPostoFabrica.Name = "cmdPostoFabrica"
        Me.cmdPostoFabrica.Size = New System.Drawing.Size(28, 28)
        Me.cmdPostoFabrica.TabIndex = 317
        Me.cmdPostoFabrica.TabStop = False
        '
        'cmdPostoFazenda
        '
        Appearance1.Image = Global.Logus.My.Resources.Resources.Pasta
        Appearance1.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.cmdPostoFazenda.Appearance = Appearance1
        Me.cmdPostoFazenda.ImageSize = New System.Drawing.Size(20, 20)
        Me.cmdPostoFazenda.Location = New System.Drawing.Point(88, 29)
        Me.cmdPostoFazenda.Name = "cmdPostoFazenda"
        Me.cmdPostoFazenda.Size = New System.Drawing.Size(28, 28)
        Me.cmdPostoFazenda.TabIndex = 316
        Me.cmdPostoFazenda.TabStop = False
        '
        'txtQuantidadeFabrica
        '
        Me.txtQuantidadeFabrica.Location = New System.Drawing.Point(230, 35)
        Me.txtQuantidadeFabrica.MaskInput = "nnnnnnnnn"
        Me.txtQuantidadeFabrica.Name = "txtQuantidadeFabrica"
        Me.txtQuantidadeFabrica.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtQuantidadeFabrica.ReadOnly = True
        Me.txtQuantidadeFabrica.Size = New System.Drawing.Size(111, 21)
        Me.txtQuantidadeFabrica.TabIndex = 314
        '
        'txtQuantidadeFilial
        '
        Me.txtQuantidadeFilial.Location = New System.Drawing.Point(122, 35)
        Me.txtQuantidadeFilial.MaskInput = "{LOC}nn,nnn,nnn"
        Me.txtQuantidadeFilial.Name = "txtQuantidadeFilial"
        Me.txtQuantidadeFilial.ReadOnly = True
        Me.txtQuantidadeFilial.Size = New System.Drawing.Size(72, 21)
        Me.txtQuantidadeFilial.TabIndex = 312
        '
        'txtValorAdiantamentoAberto
        '
        Me.txtValorAdiantamentoAberto.Location = New System.Drawing.Point(455, 35)
        Me.txtValorAdiantamentoAberto.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtValorAdiantamentoAberto.Name = "txtValorAdiantamentoAberto"
        Me.txtValorAdiantamentoAberto.ReadOnly = True
        Me.txtValorAdiantamentoAberto.Size = New System.Drawing.Size(103, 21)
        Me.txtValorAdiantamentoAberto.TabIndex = 311
        '
        'txtValorMedioFrete
        '
        Me.txtValorMedioFrete.Location = New System.Drawing.Point(346, 35)
        Me.txtValorMedioFrete.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtValorMedioFrete.Name = "txtValorMedioFrete"
        Me.txtValorMedioFrete.ReadOnly = True
        Me.txtValorMedioFrete.Size = New System.Drawing.Size(103, 21)
        Me.txtValorMedioFrete.TabIndex = 309
        '
        'txtQuantidadeFazenda
        '
        Me.txtQuantidadeFazenda.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaToolbarButton
        Me.txtQuantidadeFazenda.Location = New System.Drawing.Point(8, 35)
        Me.txtQuantidadeFazenda.MaskInput = "{LOC}nn,nnn,nnn"
        Me.txtQuantidadeFazenda.Name = "txtQuantidadeFazenda"
        Me.txtQuantidadeFazenda.ReadOnly = True
        Me.txtQuantidadeFazenda.Size = New System.Drawing.Size(75, 21)
        Me.txtQuantidadeFazenda.TabIndex = 306
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(227, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(90, 13)
        Me.Label16.TabIndex = 315
        Me.Label16.Text = "Qt Aberto Fabrica"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(119, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 13)
        Me.Label12.TabIndex = 313
        Me.Label12.Text = "Qt Aberto Filial"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(457, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(90, 13)
        Me.Label11.TabIndex = 310
        Me.Label11.Text = "Valor Adto Aberto"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(348, 19)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(90, 13)
        Me.Label14.TabIndex = 308
        Me.Label14.Text = "Valor Medio Frete"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(5, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(96, 13)
        Me.Label13.TabIndex = 307
        Me.Label13.Text = "Qt Aberto Fazenda"
        '
        'lblNegociacao
        '
        Me.lblNegociacao.BackColor = System.Drawing.Color.Black
        Me.lblNegociacao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNegociacao.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNegociacao.ForeColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lblNegociacao.Location = New System.Drawing.Point(294, 23)
        Me.lblNegociacao.Name = "lblNegociacao"
        Me.lblNegociacao.Size = New System.Drawing.Size(82, 23)
        Me.lblNegociacao.TabIndex = 302
        Me.lblNegociacao.Text = "NOVO"
        Me.lblNegociacao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDataNegociacao
        '
        Me.txtDataNegociacao.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataNegociacao.Location = New System.Drawing.Point(481, 22)
        Me.txtDataNegociacao.Name = "txtDataNegociacao"
        Me.txtDataNegociacao.ReadOnly = True
        Me.txtDataNegociacao.Size = New System.Drawing.Size(90, 23)
        Me.txtDataNegociacao.TabIndex = 300
        Me.txtDataNegociacao.Value = Nothing
        '
        'txtDataPagamento
        '
        Me.txtDataPagamento.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataPagamento.Location = New System.Drawing.Point(468, 177)
        Me.txtDataPagamento.Name = "txtDataPagamento"
        Me.txtDataPagamento.Size = New System.Drawing.Size(104, 23)
        Me.txtDataPagamento.TabIndex = 9
        Me.txtDataPagamento.Value = Nothing
        '
        'txtDataVencimento
        '
        Me.txtDataVencimento.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataVencimento.Location = New System.Drawing.Point(208, 131)
        Me.txtDataVencimento.Name = "txtDataVencimento"
        Me.txtDataVencimento.Size = New System.Drawing.Size(102, 23)
        Me.txtDataVencimento.TabIndex = 3
        Me.txtDataVencimento.Value = Nothing
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Location = New System.Drawing.Point(470, 319)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(99, 13)
        Me.Label28.TabIndex = 325
        Me.Label28.Text = "Valor Adiantamento"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(14, 319)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(55, 13)
        Me.Label27.TabIndex = 336
        Me.Label27.Text = "Descrição"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Location = New System.Drawing.Point(432, 210)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(62, 13)
        Me.Label23.TabIndex = 331
        Me.Label23.Text = "Tipo Cacau"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(118, 210)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 13)
        Me.Label7.TabIndex = 318
        Me.Label7.Text = "Aliquota ICMS%"
        '
        'lbl_ValorTotal
        '
        Me.lbl_ValorTotal.AutoSize = True
        Me.lbl_ValorTotal.BackColor = System.Drawing.Color.Transparent
        Me.lbl_ValorTotal.Location = New System.Drawing.Point(323, 210)
        Me.lbl_ValorTotal.Name = "lbl_ValorTotal"
        Me.lbl_ValorTotal.Size = New System.Drawing.Size(58, 13)
        Me.lbl_ValorTotal.TabIndex = 306
        Me.lbl_ValorTotal.Text = "Valor Total"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(214, 210)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(77, 13)
        Me.Label19.TabIndex = 304
        Me.Label19.Text = "Frete por Saca"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(14, 210)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 13)
        Me.Label17.TabIndex = 300
        Me.Label17.Text = "Valor Unitário"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Location = New System.Drawing.Point(313, 163)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(33, 13)
        Me.Label26.TabIndex = 335
        Me.Label26.Text = "Bolsa"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Location = New System.Drawing.Point(206, 163)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(95, 13)
        Me.Label25.TabIndex = 333
        Me.Label25.Text = "Data Para Fixação"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Location = New System.Drawing.Point(413, 117)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(67, 13)
        Me.Label24.TabIndex = 331
        Me.Label24.Text = "Filial Entrega"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Location = New System.Drawing.Point(313, 117)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(73, 13)
        Me.Label22.TabIndex = 329
        Me.Label22.Text = "Local Entrega"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(100, 118)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 13)
        Me.Label10.TabIndex = 327
        Me.Label10.Text = "Unidade"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(7, 163)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 13)
        Me.Label8.TabIndex = 324
        Me.Label8.Text = "Tipo Negociacao"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(291, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 303
        Me.Label3.Text = "Número"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(6, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 305
        Me.Label4.Text = "Quantidade"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(478, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 301
        Me.Label5.Text = "Data"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(205, 115)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 295
        Me.Label1.Text = "Data Vencimento"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(469, 163)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 312
        Me.Label6.Text = "Data Pagamento"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(11, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 298
        Me.Label9.Text = "Contrato PAF"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(382, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 310
        Me.Label2.Text = "Saldo"
        '
        'cmdNovo
        '
        Me.cmdNovo.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdNovo.Location = New System.Drawing.Point(56, 375)
        Me.cmdNovo.Name = "cmdNovo"
        Me.cmdNovo.Size = New System.Drawing.Size(45, 45)
        Me.cmdNovo.TabIndex = 22
        Me.cmdNovo.Text = "N"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(542, 375)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 23
        Me.cmdFechar.Text = "F"
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(5, 375)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 21
        Me.cmdGravar.TabStop = False
        Me.cmdGravar.Text = "G"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdImprimir.Location = New System.Drawing.Point(109, 375)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(45, 45)
        Me.cmdImprimir.TabIndex = 325
        Me.cmdImprimir.Text = "I"
        '
        'cboBolsa
        '
        Me.cboBolsa.CheckedListSettings.CheckStateMember = ""
        Me.cboBolsa.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cboBolsa.Location = New System.Drawing.Point(316, 177)
        Me.cboBolsa.Name = "cboBolsa"
        Me.cboBolsa.PreferredDropDownSize = New System.Drawing.Size(0, 0)
        Me.cboBolsa.Size = New System.Drawing.Size(146, 22)
        Me.cboBolsa.TabIndex = 341
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
        Me.Pesq_ContratoPAF.Location = New System.Drawing.Point(11, 24)
        Me.Pesq_ContratoPAF.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_ContratoPAF.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_ContratoPAF.Name = "Pesq_ContratoPAF"
        Me.Pesq_ContratoPAF.Size = New System.Drawing.Size(277, 28)
        Me.Pesq_ContratoPAF.TabIndex = 0
        Me.Pesq_ContratoPAF.TelaFiltro = False
        Me.Pesq_ContratoPAF.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'txtPremioCRM
        '
        Me.txtPremioCRM.Location = New System.Drawing.Point(382, 226)
        Me.txtPremioCRM.MaskInput = "{currency:-9.2}"
        Me.txtPremioCRM.Name = "txtPremioCRM"
        Me.txtPremioCRM.Size = New System.Drawing.Size(103, 21)
        Me.txtPremioCRM.TabIndex = 342
        Me.txtPremioCRM.Visible = False
        '
        'lbl_CRM
        '
        Me.lbl_CRM.AutoSize = True
        Me.lbl_CRM.BackColor = System.Drawing.Color.Transparent
        Me.lbl_CRM.Location = New System.Drawing.Point(384, 210)
        Me.lbl_CRM.Name = "lbl_CRM"
        Me.lbl_CRM.Size = New System.Drawing.Size(66, 13)
        Me.lbl_CRM.TabIndex = 343
        Me.lbl_CRM.Text = "Premio CRM"
        Me.lbl_CRM.Visible = False
        '
        'frmCadastroNegociacao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(593, 424)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.cmdNovo)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.grpDados)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCadastroNegociacao"
        Me.Text = "Cadastro Negociação"
        CType(Me.grpDados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDados.ResumeLayout(False)
        Me.grpDados.PerformLayout()
        CType(Me.txtSaldo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorAdiantamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAliquotaICMS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataParaFixacao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorFrete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorUnitarioNegociacao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpJuros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpJuros.ResumeLayout(False)
        Me.grpJuros.PerformLayout()
        CType(Me.txtTaxaJuros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDiasCarencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantidadeNegociacao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.txtQuantidadeFabrica, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantidadeFilial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorAdiantamentoAberto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorMedioFrete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantidadeFazenda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataNegociacao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataPagamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataVencimento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboBolsa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPremioCRM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpDados As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtAliquotaICMS As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents lbl_ValorTotal As System.Windows.Forms.Label
    Friend WithEvents txtValorTotal As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtValorFrete As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtValorUnitarioNegociacao As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents cboTipoPessoa As System.Windows.Forms.ComboBox
    Friend WithEvents txtQuantidadeNegociacao As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtValorMedioFrete As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtQuantidadeFazenda As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblNegociacao As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDataNegociacao As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDataPagamento As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtDataVencimento As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Pesq_ContratoPAF As Logus.Pesq_CodigoNome
    Friend WithEvents cmdNovo As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboTipoNegociacao As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboUnidade As System.Windows.Forms.ComboBox
    Friend WithEvents grpJuros As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents chkCobraJuros As System.Windows.Forms.CheckBox
    Friend WithEvents txtTaxaJuros As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents txtDiasCarencia As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents chkJurosAposCarencia As System.Windows.Forms.CheckBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cboLocalEntrega As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cboTipoCacau As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtQuantidadeFabrica As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtQuantidadeFilial As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtValorAdiantamentoAberto As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cboFilialEntrega As System.Windows.Forms.ComboBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtDataParaFixacao As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtMotivoDataVencimento As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtValorAdiantamento As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents cmdImprimir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtSaldo As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents cmdPostoFazenda As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdPostoFabrica As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cboBolsa As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents txtPremioCRM As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents lbl_CRM As System.Windows.Forms.Label
End Class
