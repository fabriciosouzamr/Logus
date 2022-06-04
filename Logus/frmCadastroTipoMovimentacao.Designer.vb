<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroTipoMovimentacao
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadastroTipoMovimentacao))
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.txtSufixoLocal = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtCfopLocal_PJ = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtPrintMessageLocal = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtFormaTributacaoLocal = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtSituacaoTributacaoLocal = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtTributacaoIcmsLocal = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtCfopLocal = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.txtSufixoOutros = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtCfopOutros_PJ = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtPrintMessageOutros = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtFormaTributacaoOutros = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtSituacaoTributacaoOutros = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtTributacaoIcmsOutros = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtCfopOutros = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.txtDescricao = New System.Windows.Forms.TextBox
        Me.chkValidaQuilos = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.chkMovimentacaoFiscal = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.chkLivroFiscal = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.chkValidaValor = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.chkValidaQuatidade = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.chkLocalEntregaFixa = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.cboLocalEntrega = New System.Windows.Forms.ComboBox
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.chkLancaRD = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.optTipo = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.Label2 = New System.Windows.Forms.Label
        Me.chkImportacao = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.cboTipoRD = New System.Windows.Forms.ComboBox
        Me.grpContabiliza = New Infragistics.Win.Misc.UltraGroupBox
        Me.lblR_TipoSubLedgerCP = New System.Windows.Forms.Label
        Me.txtTipoSubLedgerCP = New System.Windows.Forms.TextBox
        Me.txtContaContabilCP = New System.Windows.Forms.TextBox
        Me.lblR_SubLedgerCP = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtSubLedgerCP = New System.Windows.Forms.TextBox
        Me.chkMudaFilial_CP = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtTipoSubLedger = New System.Windows.Forms.TextBox
        Me.txtContaContabil = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtSubLedger = New System.Windows.Forms.TextBox
        Me.chkMudaFilial_CC = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.chkContabilizacao = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.TabClass = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.txtCodigo = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.chkAtivo = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.lblR_AplicacaoCacau = New System.Windows.Forms.Label
        Me.chkAplicacaoSaidaAplicacao = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.cboAplicacaoCacau = New System.Windows.Forms.ComboBox
        Me.cboSaidaAplicacaoCacau = New System.Windows.Forms.ComboBox
        Me.lblR_SaidaAplicacaoCacau = New System.Windows.Forms.Label
        Me.chkSubLedgerCP = New System.Windows.Forms.CheckBox
        Me.UltraTabPageControl1.SuspendLayout()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.chkValidaQuilos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkMovimentacaoFiscal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkLivroFiscal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkValidaValor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkValidaQuatidade, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.chkLocalEntregaFixa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.chkLancaRD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkImportacao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpContabiliza, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpContabiliza.SuspendLayout()
        CType(Me.chkMudaFilial_CP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkMudaFilial_CC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkContabilizacao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabClass, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabClass.SuspendLayout()
        CType(Me.txtCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAtivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAplicacaoSaidaAplicacao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.txtSufixoLocal)
        Me.UltraTabPageControl1.Controls.Add(Me.Label16)
        Me.UltraTabPageControl1.Controls.Add(Me.txtCfopLocal_PJ)
        Me.UltraTabPageControl1.Controls.Add(Me.Label15)
        Me.UltraTabPageControl1.Controls.Add(Me.txtPrintMessageLocal)
        Me.UltraTabPageControl1.Controls.Add(Me.Label14)
        Me.UltraTabPageControl1.Controls.Add(Me.txtFormaTributacaoLocal)
        Me.UltraTabPageControl1.Controls.Add(Me.Label13)
        Me.UltraTabPageControl1.Controls.Add(Me.txtSituacaoTributacaoLocal)
        Me.UltraTabPageControl1.Controls.Add(Me.Label12)
        Me.UltraTabPageControl1.Controls.Add(Me.txtTributacaoIcmsLocal)
        Me.UltraTabPageControl1.Controls.Add(Me.Label11)
        Me.UltraTabPageControl1.Controls.Add(Me.txtCfopLocal)
        Me.UltraTabPageControl1.Controls.Add(Me.Label10)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 23)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(352, 89)
        '
        'txtSufixoLocal
        '
        Me.txtSufixoLocal.Location = New System.Drawing.Point(161, 19)
        Me.txtSufixoLocal.MaxLength = 2
        Me.txtSufixoLocal.Name = "txtSufixoLocal"
        Me.txtSufixoLocal.Size = New System.Drawing.Size(42, 20)
        Me.txtSufixoLocal.TabIndex = 341
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(161, 5)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(36, 13)
        Me.Label16.TabIndex = 342
        Me.Label16.Text = "Sufixo"
        '
        'txtCfopLocal_PJ
        '
        Me.txtCfopLocal_PJ.Location = New System.Drawing.Point(82, 19)
        Me.txtCfopLocal_PJ.MaxLength = 40
        Me.txtCfopLocal_PJ.Name = "txtCfopLocal_PJ"
        Me.txtCfopLocal_PJ.Size = New System.Drawing.Size(71, 20)
        Me.txtCfopLocal_PJ.TabIndex = 339
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(82, 5)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(69, 13)
        Me.Label15.TabIndex = 340
        Me.Label15.Text = "CFOP Repas"
        '
        'txtPrintMessageLocal
        '
        Me.txtPrintMessageLocal.Location = New System.Drawing.Point(236, 61)
        Me.txtPrintMessageLocal.MaxLength = 10
        Me.txtPrintMessageLocal.Name = "txtPrintMessageLocal"
        Me.txtPrintMessageLocal.Size = New System.Drawing.Size(103, 20)
        Me.txtPrintMessageLocal.TabIndex = 337
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(236, 47)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(85, 13)
        Me.Label14.TabIndex = 338
        Me.Label14.Text = "Finalidade Fiscal"
        '
        'txtFormaTributacaoLocal
        '
        Me.txtFormaTributacaoLocal.Location = New System.Drawing.Point(211, 19)
        Me.txtFormaTributacaoLocal.MaxLength = 1
        Me.txtFormaTributacaoLocal.Name = "txtFormaTributacaoLocal"
        Me.txtFormaTributacaoLocal.Size = New System.Drawing.Size(136, 20)
        Me.txtFormaTributacaoLocal.TabIndex = 335
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(211, 5)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(90, 13)
        Me.Label13.TabIndex = 336
        Me.Label13.Text = "Forma Tributação"
        '
        'txtSituacaoTributacaoLocal
        '
        Me.txtSituacaoTributacaoLocal.Location = New System.Drawing.Point(107, 61)
        Me.txtSituacaoTributacaoLocal.MaxLength = 2
        Me.txtSituacaoTributacaoLocal.Name = "txtSituacaoTributacaoLocal"
        Me.txtSituacaoTributacaoLocal.Size = New System.Drawing.Size(121, 20)
        Me.txtSituacaoTributacaoLocal.TabIndex = 333
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(107, 47)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(103, 13)
        Me.Label12.TabIndex = 334
        Me.Label12.Text = "Situação Tributação"
        '
        'txtTributacaoIcmsLocal
        '
        Me.txtTributacaoIcmsLocal.Location = New System.Drawing.Point(3, 61)
        Me.txtTributacaoIcmsLocal.MaxLength = 2
        Me.txtTributacaoIcmsLocal.Name = "txtTributacaoIcmsLocal"
        Me.txtTributacaoIcmsLocal.Size = New System.Drawing.Size(96, 20)
        Me.txtTributacaoIcmsLocal.TabIndex = 331
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(3, 47)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(87, 13)
        Me.Label11.TabIndex = 332
        Me.Label11.Text = "Tributação ICMS"
        '
        'txtCfopLocal
        '
        Me.txtCfopLocal.Location = New System.Drawing.Point(3, 19)
        Me.txtCfopLocal.MaxLength = 40
        Me.txtCfopLocal.Name = "txtCfopLocal"
        Me.txtCfopLocal.Size = New System.Drawing.Size(71, 20)
        Me.txtCfopLocal.TabIndex = 329
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(3, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 13)
        Me.Label10.TabIndex = 330
        Me.Label10.Text = "CFOP Prod"
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.txtSufixoOutros)
        Me.UltraTabPageControl2.Controls.Add(Me.Label17)
        Me.UltraTabPageControl2.Controls.Add(Me.txtCfopOutros_PJ)
        Me.UltraTabPageControl2.Controls.Add(Me.Label18)
        Me.UltraTabPageControl2.Controls.Add(Me.txtPrintMessageOutros)
        Me.UltraTabPageControl2.Controls.Add(Me.Label19)
        Me.UltraTabPageControl2.Controls.Add(Me.txtFormaTributacaoOutros)
        Me.UltraTabPageControl2.Controls.Add(Me.Label20)
        Me.UltraTabPageControl2.Controls.Add(Me.txtSituacaoTributacaoOutros)
        Me.UltraTabPageControl2.Controls.Add(Me.Label21)
        Me.UltraTabPageControl2.Controls.Add(Me.txtTributacaoIcmsOutros)
        Me.UltraTabPageControl2.Controls.Add(Me.Label22)
        Me.UltraTabPageControl2.Controls.Add(Me.txtCfopOutros)
        Me.UltraTabPageControl2.Controls.Add(Me.Label23)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(352, 89)
        '
        'txtSufixoOutros
        '
        Me.txtSufixoOutros.Location = New System.Drawing.Point(161, 19)
        Me.txtSufixoOutros.MaxLength = 2
        Me.txtSufixoOutros.Name = "txtSufixoOutros"
        Me.txtSufixoOutros.Size = New System.Drawing.Size(42, 20)
        Me.txtSufixoOutros.TabIndex = 355
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(161, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(36, 13)
        Me.Label17.TabIndex = 356
        Me.Label17.Text = "Sufixo"
        '
        'txtCfopOutros_PJ
        '
        Me.txtCfopOutros_PJ.Location = New System.Drawing.Point(82, 19)
        Me.txtCfopOutros_PJ.MaxLength = 40
        Me.txtCfopOutros_PJ.Name = "txtCfopOutros_PJ"
        Me.txtCfopOutros_PJ.Size = New System.Drawing.Size(71, 20)
        Me.txtCfopOutros_PJ.TabIndex = 353
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Location = New System.Drawing.Point(82, 5)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(69, 13)
        Me.Label18.TabIndex = 354
        Me.Label18.Text = "CFOP Repas"
        '
        'txtPrintMessageOutros
        '
        Me.txtPrintMessageOutros.Location = New System.Drawing.Point(236, 61)
        Me.txtPrintMessageOutros.MaxLength = 10
        Me.txtPrintMessageOutros.Name = "txtPrintMessageOutros"
        Me.txtPrintMessageOutros.Size = New System.Drawing.Size(103, 20)
        Me.txtPrintMessageOutros.TabIndex = 351
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(236, 47)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(85, 13)
        Me.Label19.TabIndex = 352
        Me.Label19.Text = "Finalidade Fiscal"
        '
        'txtFormaTributacaoOutros
        '
        Me.txtFormaTributacaoOutros.Location = New System.Drawing.Point(211, 19)
        Me.txtFormaTributacaoOutros.MaxLength = 1
        Me.txtFormaTributacaoOutros.Name = "txtFormaTributacaoOutros"
        Me.txtFormaTributacaoOutros.Size = New System.Drawing.Size(136, 20)
        Me.txtFormaTributacaoOutros.TabIndex = 349
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Location = New System.Drawing.Point(211, 5)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(90, 13)
        Me.Label20.TabIndex = 350
        Me.Label20.Text = "Forma Tributação"
        '
        'txtSituacaoTributacaoOutros
        '
        Me.txtSituacaoTributacaoOutros.Location = New System.Drawing.Point(107, 61)
        Me.txtSituacaoTributacaoOutros.MaxLength = 2
        Me.txtSituacaoTributacaoOutros.Name = "txtSituacaoTributacaoOutros"
        Me.txtSituacaoTributacaoOutros.Size = New System.Drawing.Size(121, 20)
        Me.txtSituacaoTributacaoOutros.TabIndex = 347
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Location = New System.Drawing.Point(107, 47)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(103, 13)
        Me.Label21.TabIndex = 348
        Me.Label21.Text = "Situação Tributação"
        '
        'txtTributacaoIcmsOutros
        '
        Me.txtTributacaoIcmsOutros.Location = New System.Drawing.Point(3, 61)
        Me.txtTributacaoIcmsOutros.MaxLength = 2
        Me.txtTributacaoIcmsOutros.Name = "txtTributacaoIcmsOutros"
        Me.txtTributacaoIcmsOutros.Size = New System.Drawing.Size(96, 20)
        Me.txtTributacaoIcmsOutros.TabIndex = 345
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Location = New System.Drawing.Point(3, 47)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(87, 13)
        Me.Label22.TabIndex = 346
        Me.Label22.Text = "Tributação ICMS"
        '
        'txtCfopOutros
        '
        Me.txtCfopOutros.Location = New System.Drawing.Point(3, 19)
        Me.txtCfopOutros.MaxLength = 40
        Me.txtCfopOutros.Name = "txtCfopOutros"
        Me.txtCfopOutros.Size = New System.Drawing.Size(71, 20)
        Me.txtCfopOutros.TabIndex = 343
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Location = New System.Drawing.Point(3, 5)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(60, 13)
        Me.Label23.TabIndex = 344
        Me.Label23.Text = "CFOP Prod"
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(8, 452)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 14
        Me.cmdGravar.TabStop = False
        Me.cmdGravar.Text = "G"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(8, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Número"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(68, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Descrição"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(479, 452)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 15
        Me.cmdFechar.Text = "F"
        '
        'txtDescricao
        '
        Me.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescricao.Location = New System.Drawing.Point(70, 22)
        Me.txtDescricao.MaxLength = 30
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(456, 20)
        Me.txtDescricao.TabIndex = 3
        '
        'chkValidaQuilos
        '
        Me.chkValidaQuilos.Location = New System.Drawing.Point(8, 254)
        Me.chkValidaQuilos.Name = "chkValidaQuilos"
        Me.chkValidaQuilos.Size = New System.Drawing.Size(94, 13)
        Me.chkValidaQuilos.TabIndex = 7
        Me.chkValidaQuilos.Text = "Valida Quilos?"
        '
        'chkMovimentacaoFiscal
        '
        Me.chkMovimentacaoFiscal.Location = New System.Drawing.Point(8, 317)
        Me.chkMovimentacaoFiscal.Name = "chkMovimentacaoFiscal"
        Me.chkMovimentacaoFiscal.Size = New System.Drawing.Size(128, 13)
        Me.chkMovimentacaoFiscal.TabIndex = 10
        Me.chkMovimentacaoFiscal.Text = "Movimentação Fiscal"
        '
        'chkLivroFiscal
        '
        Me.chkLivroFiscal.Location = New System.Drawing.Point(8, 233)
        Me.chkLivroFiscal.Name = "chkLivroFiscal"
        Me.chkLivroFiscal.Size = New System.Drawing.Size(151, 13)
        Me.chkLivroFiscal.TabIndex = 6
        Me.chkLivroFiscal.Text = "Envia para o Livro Fiscal?"
        '
        'chkValidaValor
        '
        Me.chkValidaValor.Location = New System.Drawing.Point(8, 296)
        Me.chkValidaValor.Name = "chkValidaValor"
        Me.chkValidaValor.Size = New System.Drawing.Size(82, 13)
        Me.chkValidaValor.TabIndex = 9
        Me.chkValidaValor.Text = "Valida Valor"
        '
        'chkValidaQuatidade
        '
        Me.chkValidaQuatidade.Location = New System.Drawing.Point(8, 275)
        Me.chkValidaQuatidade.Name = "chkValidaQuatidade"
        Me.chkValidaQuatidade.Size = New System.Drawing.Size(108, 13)
        Me.chkValidaQuatidade.TabIndex = 8
        Me.chkValidaQuatidade.Text = "Valida Qualidade"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.chkLocalEntregaFixa)
        Me.UltraGroupBox1.Controls.Add(Me.cboLocalEntrega)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(8, 402)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(214, 42)
        Me.UltraGroupBox1.TabIndex = 12
        Me.UltraGroupBox1.Text = "Local de Entrega"
        '
        'chkLocalEntregaFixa
        '
        Me.chkLocalEntregaFixa.Location = New System.Drawing.Point(10, 19)
        Me.chkLocalEntregaFixa.Name = "chkLocalEntregaFixa"
        Me.chkLocalEntregaFixa.Size = New System.Drawing.Size(46, 13)
        Me.chkLocalEntregaFixa.TabIndex = 320
        Me.chkLocalEntregaFixa.Text = "Fixo:"
        '
        'cboLocalEntrega
        '
        Me.cboLocalEntrega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLocalEntrega.Location = New System.Drawing.Point(64, 15)
        Me.cboLocalEntrega.Name = "cboLocalEntrega"
        Me.cboLocalEntrega.Size = New System.Drawing.Size(144, 21)
        Me.cboLocalEntrega.TabIndex = 315
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.chkLancaRD)
        Me.UltraGroupBox2.Controls.Add(Me.optTipo)
        Me.UltraGroupBox2.Controls.Add(Me.Label2)
        Me.UltraGroupBox2.Controls.Add(Me.chkImportacao)
        Me.UltraGroupBox2.Controls.Add(Me.cboTipoRD)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(8, 51)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(518, 42)
        Me.UltraGroupBox2.TabIndex = 4
        Me.UltraGroupBox2.Text = "RD"
        '
        'chkLancaRD
        '
        Me.chkLancaRD.Location = New System.Drawing.Point(10, 19)
        Me.chkLancaRD.Name = "chkLancaRD"
        Me.chkLancaRD.Size = New System.Drawing.Size(87, 13)
        Me.chkLancaRD.TabIndex = 0
        Me.chkLancaRD.Text = "Lança no RD"
        '
        'optTipo
        '
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        Me.optTipo.Appearance = Appearance1
        Me.optTipo.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.optTipo.CheckedIndex = 0
        Appearance2.TextHAlignAsString = "Center"
        Appearance2.TextVAlignAsString = "Middle"
        Me.optTipo.ItemAppearance = Appearance2
        Me.optTipo.ItemOrigin = New System.Drawing.Point(2, 2)
        ValueListItem1.DataValue = "E"
        ValueListItem1.DisplayText = "Entrada"
        ValueListItem2.DataValue = "S"
        ValueListItem2.DisplayText = "Saída"
        Me.optTipo.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2})
        Me.optTipo.Location = New System.Drawing.Point(385, 15)
        Me.optTipo.Name = "optTipo"
        Me.optTipo.Size = New System.Drawing.Size(119, 19)
        Me.optTipo.TabIndex = 3
        Me.optTipo.Text = "Entrada"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(234, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Tipo"
        '
        'chkImportacao
        '
        Me.chkImportacao.Location = New System.Drawing.Point(105, 19)
        Me.chkImportacao.Name = "chkImportacao"
        Me.chkImportacao.Size = New System.Drawing.Size(89, 13)
        Me.chkImportacao.TabIndex = 1
        Me.chkImportacao.Text = "Importação?"
        '
        'cboTipoRD
        '
        Me.cboTipoRD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoRD.Location = New System.Drawing.Point(268, 15)
        Me.cboTipoRD.Name = "cboTipoRD"
        Me.cboTipoRD.Size = New System.Drawing.Size(105, 21)
        Me.cboTipoRD.TabIndex = 2
        '
        'grpContabiliza
        '
        Me.grpContabiliza.Controls.Add(Me.chkSubLedgerCP)
        Me.grpContabiliza.Controls.Add(Me.lblR_TipoSubLedgerCP)
        Me.grpContabiliza.Controls.Add(Me.txtTipoSubLedgerCP)
        Me.grpContabiliza.Controls.Add(Me.txtContaContabilCP)
        Me.grpContabiliza.Controls.Add(Me.lblR_SubLedgerCP)
        Me.grpContabiliza.Controls.Add(Me.Label9)
        Me.grpContabiliza.Controls.Add(Me.txtSubLedgerCP)
        Me.grpContabiliza.Controls.Add(Me.chkMudaFilial_CP)
        Me.grpContabiliza.Controls.Add(Me.Label6)
        Me.grpContabiliza.Controls.Add(Me.txtTipoSubLedger)
        Me.grpContabiliza.Controls.Add(Me.txtContaContabil)
        Me.grpContabiliza.Controls.Add(Me.Label5)
        Me.grpContabiliza.Controls.Add(Me.Label4)
        Me.grpContabiliza.Controls.Add(Me.txtSubLedger)
        Me.grpContabiliza.Controls.Add(Me.chkMudaFilial_CC)
        Me.grpContabiliza.Location = New System.Drawing.Point(8, 122)
        Me.grpContabiliza.Name = "grpContabiliza"
        Me.grpContabiliza.Size = New System.Drawing.Size(518, 103)
        Me.grpContabiliza.TabIndex = 6
        Me.grpContabiliza.Text = "Contabilização"
        '
        'lblR_TipoSubLedgerCP
        '
        Me.lblR_TipoSubLedgerCP.AutoSize = True
        Me.lblR_TipoSubLedgerCP.BackColor = System.Drawing.Color.Transparent
        Me.lblR_TipoSubLedgerCP.Location = New System.Drawing.Point(370, 61)
        Me.lblR_TipoSubLedgerCP.Name = "lblR_TipoSubLedgerCP"
        Me.lblR_TipoSubLedgerCP.Size = New System.Drawing.Size(103, 13)
        Me.lblR_TipoSubLedgerCP.TabIndex = 340
        Me.lblR_TipoSubLedgerCP.Text = "Tipo Sub Ledger CP"
        '
        'txtTipoSubLedgerCP
        '
        Me.txtTipoSubLedgerCP.Location = New System.Drawing.Point(370, 75)
        Me.txtTipoSubLedgerCP.MaxLength = 40
        Me.txtTipoSubLedgerCP.Name = "txtTipoSubLedgerCP"
        Me.txtTipoSubLedgerCP.Size = New System.Drawing.Size(136, 20)
        Me.txtTipoSubLedgerCP.TabIndex = 5
        '
        'txtContaContabilCP
        '
        Me.txtContaContabilCP.Location = New System.Drawing.Point(10, 75)
        Me.txtContaContabilCP.MaxLength = 40
        Me.txtContaContabilCP.Name = "txtContaContabilCP"
        Me.txtContaContabilCP.Size = New System.Drawing.Size(136, 20)
        Me.txtContaContabilCP.TabIndex = 3
        '
        'lblR_SubLedgerCP
        '
        Me.lblR_SubLedgerCP.AutoSize = True
        Me.lblR_SubLedgerCP.BackColor = System.Drawing.Color.Transparent
        Me.lblR_SubLedgerCP.Location = New System.Drawing.Point(242, 61)
        Me.lblR_SubLedgerCP.Name = "lblR_SubLedgerCP"
        Me.lblR_SubLedgerCP.Size = New System.Drawing.Size(79, 13)
        Me.lblR_SubLedgerCP.TabIndex = 338
        Me.lblR_SubLedgerCP.Text = "Sub Ledger CP"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(10, 61)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 13)
        Me.Label9.TabIndex = 335
        Me.Label9.Text = "Contra Partida"
        '
        'txtSubLedgerCP
        '
        Me.txtSubLedgerCP.Location = New System.Drawing.Point(227, 75)
        Me.txtSubLedgerCP.MaxLength = 40
        Me.txtSubLedgerCP.Name = "txtSubLedgerCP"
        Me.txtSubLedgerCP.Size = New System.Drawing.Size(136, 20)
        Me.txtSubLedgerCP.TabIndex = 4
        '
        'chkMudaFilial_CP
        '
        Me.chkMudaFilial_CP.Location = New System.Drawing.Point(150, 79)
        Me.chkMudaFilial_CP.Name = "chkMudaFilial_CP"
        Me.chkMudaFilial_CP.Size = New System.Drawing.Size(76, 13)
        Me.chkMudaFilial_CP.TabIndex = 336
        Me.chkMudaFilial_CP.Text = "Muda Filial"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(370, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 13)
        Me.Label6.TabIndex = 333
        Me.Label6.Text = "Tipo Sub Ledger"
        '
        'txtTipoSubLedger
        '
        Me.txtTipoSubLedger.Location = New System.Drawing.Point(370, 33)
        Me.txtTipoSubLedger.MaxLength = 40
        Me.txtTipoSubLedger.Name = "txtTipoSubLedger"
        Me.txtTipoSubLedger.Size = New System.Drawing.Size(136, 20)
        Me.txtTipoSubLedger.TabIndex = 2
        '
        'txtContaContabil
        '
        Me.txtContaContabil.Location = New System.Drawing.Point(10, 33)
        Me.txtContaContabil.MaxLength = 40
        Me.txtContaContabil.Name = "txtContaContabil"
        Me.txtContaContabil.Size = New System.Drawing.Size(136, 20)
        Me.txtContaContabil.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(227, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 331
        Me.Label5.Text = "Sub Ledger"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(10, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 328
        Me.Label4.Text = "Conta Contabil"
        '
        'txtSubLedger
        '
        Me.txtSubLedger.Location = New System.Drawing.Point(227, 33)
        Me.txtSubLedger.MaxLength = 40
        Me.txtSubLedger.Name = "txtSubLedger"
        Me.txtSubLedger.Size = New System.Drawing.Size(136, 20)
        Me.txtSubLedger.TabIndex = 1
        '
        'chkMudaFilial_CC
        '
        Me.chkMudaFilial_CC.Location = New System.Drawing.Point(150, 37)
        Me.chkMudaFilial_CC.Name = "chkMudaFilial_CC"
        Me.chkMudaFilial_CC.Size = New System.Drawing.Size(76, 13)
        Me.chkMudaFilial_CC.TabIndex = 329
        Me.chkMudaFilial_CC.Text = "Muda Filial"
        '
        'chkContabilizacao
        '
        Me.chkContabilizacao.Location = New System.Drawing.Point(8, 101)
        Me.chkContabilizacao.Name = "chkContabilizacao"
        Me.chkContabilizacao.Size = New System.Drawing.Size(124, 13)
        Me.chkContabilizacao.TabIndex = 5
        Me.chkContabilizacao.Text = "Gera Contabilização"
        '
        'TabClass
        '
        Me.TabClass.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.TabClass.Controls.Add(Me.UltraTabPageControl1)
        Me.TabClass.Controls.Add(Me.UltraTabPageControl2)
        Me.TabClass.Location = New System.Drawing.Point(170, 233)
        Me.TabClass.Name = "TabClass"
        Me.TabClass.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.TabClass.Size = New System.Drawing.Size(356, 115)
        Me.TabClass.TabIndex = 11
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Mesmo Estado"
        UltraTab2.TabPage = Me.UltraTabPageControl2
        UltraTab2.Text = "Outros Estados"
        Me.TabClass.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(352, 89)
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(8, 22)
        Me.txtCodigo.MaskInput = "{LOC}-nnn"
        Me.txtCodigo.MaxValue = 999
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(54, 21)
        Me.txtCodigo.TabIndex = 2
        '
        'chkAtivo
        '
        Me.chkAtivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAtivo.Location = New System.Drawing.Point(478, 424)
        Me.chkAtivo.Name = "chkAtivo"
        Me.chkAtivo.Size = New System.Drawing.Size(46, 20)
        Me.chkAtivo.TabIndex = 13
        Me.chkAtivo.Text = "Ativo"
        '
        'lblR_AplicacaoCacau
        '
        Me.lblR_AplicacaoCacau.AutoSize = True
        Me.lblR_AplicacaoCacau.BackColor = System.Drawing.Color.Transparent
        Me.lblR_AplicacaoCacau.Location = New System.Drawing.Point(8, 359)
        Me.lblR_AplicacaoCacau.Name = "lblR_AplicacaoCacau"
        Me.lblR_AplicacaoCacau.Size = New System.Drawing.Size(103, 13)
        Me.lblR_AplicacaoCacau.TabIndex = 16
        Me.lblR_AplicacaoCacau.Text = "Aplicação de Cacau"
        '
        'chkAplicacaoSaidaAplicacao
        '
        Me.chkAplicacaoSaidaAplicacao.Location = New System.Drawing.Point(8, 338)
        Me.chkAplicacaoSaidaAplicacao.Name = "chkAplicacaoSaidaAplicacao"
        Me.chkAplicacaoSaidaAplicacao.Size = New System.Drawing.Size(155, 13)
        Me.chkAplicacaoSaidaAplicacao.TabIndex = 10
        Me.chkAplicacaoSaidaAplicacao.Text = "Aplicação/Saída Aplicação"
        '
        'cboAplicacaoCacau
        '
        Me.cboAplicacaoCacau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAplicacaoCacau.FormattingEnabled = True
        Me.cboAplicacaoCacau.Location = New System.Drawing.Point(8, 373)
        Me.cboAplicacaoCacau.Name = "cboAplicacaoCacau"
        Me.cboAplicacaoCacau.Size = New System.Drawing.Size(255, 21)
        Me.cboAplicacaoCacau.TabIndex = 17
        '
        'cboSaidaAplicacaoCacau
        '
        Me.cboSaidaAplicacaoCacau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSaidaAplicacaoCacau.FormattingEnabled = True
        Me.cboSaidaAplicacaoCacau.Location = New System.Drawing.Point(271, 373)
        Me.cboSaidaAplicacaoCacau.Name = "cboSaidaAplicacaoCacau"
        Me.cboSaidaAplicacaoCacau.Size = New System.Drawing.Size(255, 21)
        Me.cboSaidaAplicacaoCacau.TabIndex = 17
        '
        'lblR_SaidaAplicacaoCacau
        '
        Me.lblR_SaidaAplicacaoCacau.AutoSize = True
        Me.lblR_SaidaAplicacaoCacau.BackColor = System.Drawing.Color.Transparent
        Me.lblR_SaidaAplicacaoCacau.Location = New System.Drawing.Point(271, 359)
        Me.lblR_SaidaAplicacaoCacau.Name = "lblR_SaidaAplicacaoCacau"
        Me.lblR_SaidaAplicacaoCacau.Size = New System.Drawing.Size(150, 13)
        Me.lblR_SaidaAplicacaoCacau.TabIndex = 16
        Me.lblR_SaidaAplicacaoCacau.Text = "Saída de Aplicação de Cacau"
        '
        'chkSubLedgerCP
        '
        Me.chkSubLedgerCP.AutoSize = True
        Me.chkSubLedgerCP.Location = New System.Drawing.Point(227, 60)
        Me.chkSubLedgerCP.Name = "chkSubLedgerCP"
        Me.chkSubLedgerCP.Size = New System.Drawing.Size(15, 14)
        Me.chkSubLedgerCP.TabIndex = 341
        Me.chkSubLedgerCP.UseVisualStyleBackColor = True
        '
        'frmCadastroTipoMovimentacao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(535, 505)
        Me.Controls.Add(Me.cboSaidaAplicacaoCacau)
        Me.Controls.Add(Me.cboAplicacaoCacau)
        Me.Controls.Add(Me.lblR_SaidaAplicacaoCacau)
        Me.Controls.Add(Me.lblR_AplicacaoCacau)
        Me.Controls.Add(Me.chkAtivo)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.TabClass)
        Me.Controls.Add(Me.chkContabilizacao)
        Me.Controls.Add(Me.grpContabiliza)
        Me.Controls.Add(Me.UltraGroupBox2)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.chkValidaQuatidade)
        Me.Controls.Add(Me.chkValidaValor)
        Me.Controls.Add(Me.chkLivroFiscal)
        Me.Controls.Add(Me.chkAplicacaoSaidaAplicacao)
        Me.Controls.Add(Me.chkMovimentacaoFiscal)
        Me.Controls.Add(Me.chkValidaQuilos)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.txtDescricao)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCadastroTipoMovimentacao"
        Me.Text = "Cadastro Tipo Movimentação"
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.UltraTabPageControl2.PerformLayout()
        CType(Me.chkValidaQuilos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkMovimentacaoFiscal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkLivroFiscal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkValidaValor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkValidaQuatidade, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.chkLocalEntregaFixa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.chkLancaRD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkImportacao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpContabiliza, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpContabiliza.ResumeLayout(False)
        Me.grpContabiliza.PerformLayout()
        CType(Me.chkMudaFilial_CP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkMudaFilial_CC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkContabilizacao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabClass, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabClass.ResumeLayout(False)
        CType(Me.txtCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAtivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAplicacaoSaidaAplicacao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtDescricao As System.Windows.Forms.TextBox
    Friend WithEvents chkValidaQuilos As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkMovimentacaoFiscal As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkLivroFiscal As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkValidaValor As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkValidaQuatidade As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents chkLocalEntregaFixa As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents cboLocalEntrega As System.Windows.Forms.ComboBox
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkImportacao As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents cboTipoRD As System.Windows.Forms.ComboBox
    Friend WithEvents chkLancaRD As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents optTipo As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents grpContabiliza As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents lblR_TipoSubLedgerCP As System.Windows.Forms.Label
    Friend WithEvents txtTipoSubLedgerCP As System.Windows.Forms.TextBox
    Friend WithEvents txtContaContabilCP As System.Windows.Forms.TextBox
    Friend WithEvents lblR_SubLedgerCP As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtSubLedgerCP As System.Windows.Forms.TextBox
    Friend WithEvents chkMudaFilial_CP As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTipoSubLedger As System.Windows.Forms.TextBox
    Friend WithEvents txtContaContabil As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSubLedger As System.Windows.Forms.TextBox
    Friend WithEvents chkMudaFilial_CC As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkContabilizacao As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents TabClass As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents txtSufixoLocal As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtCfopLocal_PJ As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtPrintMessageLocal As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtFormaTributacaoLocal As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtSituacaoTributacaoLocal As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTributacaoIcmsLocal As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCfopLocal As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtSufixoOutros As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtCfopOutros_PJ As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtPrintMessageOutros As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtFormaTributacaoOutros As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtSituacaoTributacaoOutros As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtTributacaoIcmsOutros As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtCfopOutros As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents chkAtivo As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents lblR_AplicacaoCacau As System.Windows.Forms.Label
    Friend WithEvents chkAplicacaoSaidaAplicacao As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents cboAplicacaoCacau As System.Windows.Forms.ComboBox
    Friend WithEvents cboSaidaAplicacaoCacau As System.Windows.Forms.ComboBox
    Friend WithEvents lblR_SaidaAplicacaoCacau As System.Windows.Forms.Label
    Friend WithEvents chkSubLedgerCP As System.Windows.Forms.CheckBox
End Class
