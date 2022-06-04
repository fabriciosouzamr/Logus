<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParametroGeral
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
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim UltraTab6 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim UltraTab4 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim UltraTab5 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmParametroGeral))
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.txtEmailContato = New System.Windows.Forms.TextBox
        Me.txtEmailInovacao = New System.Windows.Forms.TextBox
        Me.txtEmailSeguraca = New System.Windows.Forms.TextBox
        Me.txtEmailVencimentoForaPadrao = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.txtNivelAprovacaoPagamento = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Label65 = New System.Windows.Forms.Label
        Me.UltraGroupBox7 = New Infragistics.Win.Misc.UltraGroupBox
        Me.chkHabilitaPagamentoJDE = New System.Windows.Forms.CheckBox
        Me.txtTipoDocumentoJDE = New System.Windows.Forms.TextBox
        Me.txtMoeda = New System.Windows.Forms.TextBox
        Me.txtEmailInterfaceJDE = New System.Windows.Forms.TextBox
        Me.txtDiretorio = New System.Windows.Forms.TextBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.UltraGroupBox6 = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtTipoDocumento = New System.Windows.Forms.TextBox
        Me.txtTipoPedido = New System.Windows.Forms.TextBox
        Me.txtCodigoCompra = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.cboModalidadeConciliacaoDevolucao = New System.Windows.Forms.ComboBox
        Me.UltraGroupBox5 = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtAplicacaoContratoFixoMaximo = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtAplicacaoNegociacaoMaxima = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.txtValorMinimoNFComplementar = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtContaContabilINSS = New System.Windows.Forms.TextBox
        Me.txtDataSafra = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtDataSistema = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtSafra = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtEmpresa = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtCia = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.cboFilialMae = New System.Windows.Forms.ComboBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Pesq_TP_MOV_EST_PROV_NF = New Logus.Pesq_CodigoNome
        Me.Label63 = New System.Windows.Forms.Label
        Me.Pesq_TP_MOV_PROV_NF = New Logus.Pesq_CodigoNome
        Me.Label64 = New System.Windows.Forms.Label
        Me.Pesq_TP_MOV_EST_REV_DIF = New Logus.Pesq_CodigoNome
        Me.Label61 = New System.Windows.Forms.Label
        Me.Pesq_TP_MOV_REV_DIF = New Logus.Pesq_CodigoNome
        Me.Label62 = New System.Windows.Forms.Label
        Me.Pesq_TP_MOV_EST_REV_AFIXAR = New Logus.Pesq_CodigoNome
        Me.Label59 = New System.Windows.Forms.Label
        Me.Pesq_TP_MOV_REV_AFIXAR = New Logus.Pesq_CodigoNome
        Me.Label60 = New System.Windows.Forms.Label
        Me.Pesq_ICMSImpotacao = New Logus.Pesq_CodigoNome
        Me.Label42 = New System.Windows.Forms.Label
        Me.Pesq_SaidaAordem = New Logus.Pesq_CodigoNome
        Me.Pesq_ICMS = New Logus.Pesq_CodigoNome
        Me.Pesq_EntradaFixoRD = New Logus.Pesq_CodigoNome
        Me.Label41 = New System.Windows.Forms.Label
        Me.Pesq_SaidaAordemImportado = New Logus.Pesq_CodigoNome
        Me.Pesq_EntradaFixoImportado = New Logus.Pesq_CodigoNome
        Me.Pesq_Funrural = New Logus.Pesq_CodigoNome
        Me.Pesq_Desagio = New Logus.Pesq_CodigoNome
        Me.Label56 = New System.Windows.Forms.Label
        Me.Pesq_RecebimentoCacau = New Logus.Pesq_CodigoNome
        Me.Label43 = New System.Windows.Forms.Label
        Me.Pesq_DesagioSujidade = New Logus.Pesq_CodigoNome
        Me.Label44 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.Pesq_recebimentoCacauImportado = New Logus.Pesq_CodigoNome
        Me.Label47 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label48 = New System.Windows.Forms.Label
        Me.Pesq_ICMSTransferencia = New Logus.Pesq_CodigoNome
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.UltraTabPageControl6 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.cboMoedaCredito = New System.Windows.Forms.ComboBox
        Me.UltraGroupBox14 = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtDiasMaximoFixacao = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Label46 = New System.Windows.Forms.Label
        Me.UltraGroupBox13 = New Infragistics.Win.Misc.UltraGroupBox
        Me.cboTipoCtrPAFNegociaMaster = New System.Windows.Forms.ComboBox
        Me.cboTipoAprovacaoInterna = New System.Windows.Forms.ComboBox
        Me.cboTipoNegociacaoPadrao = New System.Windows.Forms.ComboBox
        Me.cboTipoFreteTransferencia = New System.Windows.Forms.ComboBox
        Me.cboTipoFreteRecebimentoCacau = New System.Windows.Forms.ComboBox
        Me.Label49 = New System.Windows.Forms.Label
        Me.Label50 = New System.Windows.Forms.Label
        Me.Label51 = New System.Windows.Forms.Label
        Me.Label52 = New System.Windows.Forms.Label
        Me.Label53 = New System.Windows.Forms.Label
        Me.UltraGroupBox12 = New Infragistics.Win.Misc.UltraGroupBox
        Me.cboModalidadeConciliacaoICMS = New System.Windows.Forms.ComboBox
        Me.Label57 = New System.Windows.Forms.Label
        Me.UltraGroupBox11 = New Infragistics.Win.Misc.UltraGroupBox
        Me.chkSacariaFornecedor = New System.Windows.Forms.CheckBox
        Me.chkHabilitaBranche = New System.Windows.Forms.CheckBox
        Me.chkEnviaEmailCredito = New System.Windows.Forms.CheckBox
        Me.chkCacauAordemMaster = New System.Windows.Forms.CheckBox
        Me.UltraGroupBox10 = New Infragistics.Win.Misc.UltraGroupBox
        Me.cboTipoPagamentoICMS = New System.Windows.Forms.ComboBox
        Me.cboTipoPagamentoGP = New System.Windows.Forms.ComboBox
        Me.Label54 = New System.Windows.Forms.Label
        Me.Label55 = New System.Windows.Forms.Label
        Me.Label58 = New System.Windows.Forms.Label
        Me.UltraTabPageControl4 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.txtDataVigencia = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.chkDesagioContrato = New System.Windows.Forms.CheckBox
        Me.chkDesagioNF = New System.Windows.Forms.CheckBox
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.cboTipoPagamentoSujidade = New System.Windows.Forms.ComboBox
        Me.cboTipoPagamentoUmidade = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.cboModalidadeConciliacaoEstorno = New System.Windows.Forms.ComboBox
        Me.cboModalidadeConciliacaoAcordo = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtEmailQualidade = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.UltraTabPageControl5 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.txtMaximoCarenciaJuros = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtJurosAoMes = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.optCobraJuros = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.txtEmailEstornoJuros = New System.Windows.Forms.TextBox
        Me.chkJurosAutomatico = New System.Windows.Forms.CheckBox
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox
        Me.cboTipoPagamentoDescontoJuros = New System.Windows.Forms.ComboBox
        Me.cboTipoPagamentoJuros = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.UltraGroupBox4 = New Infragistics.Win.Misc.UltraGroupBox
        Me.cboModalidadeConciliacaoEstornoJuros = New System.Windows.Forms.ComboBox
        Me.cboModalidadeConciliacaoAcordoJuros = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtEmailAlteracaoJuros = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.UltraTabPageControl1.SuspendLayout()
        Me.UltraTabPageControl3.SuspendLayout()
        CType(Me.txtNivelAprovacaoPagamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox7.SuspendLayout()
        CType(Me.UltraGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox6.SuspendLayout()
        CType(Me.UltraGroupBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox5.SuspendLayout()
        CType(Me.txtAplicacaoContratoFixoMaximo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAplicacaoNegociacaoMaxima, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorMinimoNFComplementar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataSafra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataSistema, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSafra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmpresa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        Me.UltraTabPageControl6.SuspendLayout()
        CType(Me.UltraGroupBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox14.SuspendLayout()
        CType(Me.txtDiasMaximoFixacao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox13.SuspendLayout()
        CType(Me.UltraGroupBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox12.SuspendLayout()
        CType(Me.UltraGroupBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox11.SuspendLayout()
        CType(Me.UltraGroupBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox10.SuspendLayout()
        Me.UltraTabPageControl4.SuspendLayout()
        CType(Me.txtDataVigencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.UltraTabPageControl5.SuspendLayout()
        CType(Me.txtMaximoCarenciaJuros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJurosAoMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optCobraJuros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox4.SuspendLayout()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.txtEmailContato)
        Me.UltraTabPageControl1.Controls.Add(Me.txtEmailInovacao)
        Me.UltraTabPageControl1.Controls.Add(Me.txtEmailSeguraca)
        Me.UltraTabPageControl1.Controls.Add(Me.txtEmailVencimentoForaPadrao)
        Me.UltraTabPageControl1.Controls.Add(Me.Label3)
        Me.UltraTabPageControl1.Controls.Add(Me.Label2)
        Me.UltraTabPageControl1.Controls.Add(Me.Label1)
        Me.UltraTabPageControl1.Controls.Add(Me.Label27)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 23)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(544, 421)
        '
        'txtEmailContato
        '
        Me.txtEmailContato.Location = New System.Drawing.Point(8, 22)
        Me.txtEmailContato.MaxLength = 4000
        Me.txtEmailContato.Multiline = True
        Me.txtEmailContato.Name = "txtEmailContato"
        Me.txtEmailContato.Size = New System.Drawing.Size(525, 57)
        Me.txtEmailContato.TabIndex = 343
        '
        'txtEmailInovacao
        '
        Me.txtEmailInovacao.Location = New System.Drawing.Point(8, 101)
        Me.txtEmailInovacao.MaxLength = 4000
        Me.txtEmailInovacao.Multiline = True
        Me.txtEmailInovacao.Name = "txtEmailInovacao"
        Me.txtEmailInovacao.Size = New System.Drawing.Size(525, 52)
        Me.txtEmailInovacao.TabIndex = 341
        '
        'txtEmailSeguraca
        '
        Me.txtEmailSeguraca.Location = New System.Drawing.Point(8, 175)
        Me.txtEmailSeguraca.MaxLength = 4000
        Me.txtEmailSeguraca.Multiline = True
        Me.txtEmailSeguraca.Name = "txtEmailSeguraca"
        Me.txtEmailSeguraca.Size = New System.Drawing.Size(525, 56)
        Me.txtEmailSeguraca.TabIndex = 339
        '
        'txtEmailVencimentoForaPadrao
        '
        Me.txtEmailVencimentoForaPadrao.Location = New System.Drawing.Point(8, 253)
        Me.txtEmailVencimentoForaPadrao.MaxLength = 4000
        Me.txtEmailVencimentoForaPadrao.Multiline = True
        Me.txtEmailVencimentoForaPadrao.Name = "txtEmailVencimentoForaPadrao"
        Me.txtEmailVencimentoForaPadrao.Size = New System.Drawing.Size(527, 165)
        Me.txtEmailVencimentoForaPadrao.TabIndex = 337
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(8, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 344
        Me.Label3.Text = "Contato"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(8, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 342
        Me.Label2.Text = "Inovação"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(8, 161)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 340
        Me.Label1.Text = "Segurança"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Location = New System.Drawing.Point(10, 239)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(311, 13)
        Me.Label27.TabIndex = 338
        Me.Label27.Text = "Informação sobre data de vencimento fora do padrão na compra"
        '
        'UltraTabPageControl3
        '
        Me.UltraTabPageControl3.Controls.Add(Me.txtNivelAprovacaoPagamento)
        Me.UltraTabPageControl3.Controls.Add(Me.Label65)
        Me.UltraTabPageControl3.Controls.Add(Me.UltraGroupBox7)
        Me.UltraTabPageControl3.Controls.Add(Me.UltraGroupBox6)
        Me.UltraTabPageControl3.Controls.Add(Me.cboModalidadeConciliacaoDevolucao)
        Me.UltraTabPageControl3.Controls.Add(Me.UltraGroupBox5)
        Me.UltraTabPageControl3.Controls.Add(Me.txtValorMinimoNFComplementar)
        Me.UltraTabPageControl3.Controls.Add(Me.txtContaContabilINSS)
        Me.UltraTabPageControl3.Controls.Add(Me.txtDataSafra)
        Me.UltraTabPageControl3.Controls.Add(Me.txtDataSistema)
        Me.UltraTabPageControl3.Controls.Add(Me.txtSafra)
        Me.UltraTabPageControl3.Controls.Add(Me.txtEmpresa)
        Me.UltraTabPageControl3.Controls.Add(Me.txtCia)
        Me.UltraTabPageControl3.Controls.Add(Me.cboFilialMae)
        Me.UltraTabPageControl3.Controls.Add(Me.Label31)
        Me.UltraTabPageControl3.Controls.Add(Me.Label26)
        Me.UltraTabPageControl3.Controls.Add(Me.Label25)
        Me.UltraTabPageControl3.Controls.Add(Me.Label24)
        Me.UltraTabPageControl3.Controls.Add(Me.Label23)
        Me.UltraTabPageControl3.Controls.Add(Me.Label22)
        Me.UltraTabPageControl3.Controls.Add(Me.Label21)
        Me.UltraTabPageControl3.Controls.Add(Me.Label20)
        Me.UltraTabPageControl3.Controls.Add(Me.Label11)
        Me.UltraTabPageControl3.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
        Me.UltraTabPageControl3.Size = New System.Drawing.Size(544, 421)
        '
        'txtNivelAprovacaoPagamento
        '
        Me.txtNivelAprovacaoPagamento.Location = New System.Drawing.Point(18, 348)
        Me.txtNivelAprovacaoPagamento.MaskInput = "{LOC}-nn"
        Me.txtNivelAprovacaoPagamento.Name = "txtNivelAprovacaoPagamento"
        Me.txtNivelAprovacaoPagamento.Size = New System.Drawing.Size(33, 21)
        Me.txtNivelAprovacaoPagamento.TabIndex = 392
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.BackColor = System.Drawing.Color.Transparent
        Me.Label65.Location = New System.Drawing.Point(18, 334)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(180, 13)
        Me.Label65.TabIndex = 393
        Me.Label65.Text = "Níveis de Aprovação de Pagamento"
        '
        'UltraGroupBox7
        '
        Me.UltraGroupBox7.Controls.Add(Me.chkHabilitaPagamentoJDE)
        Me.UltraGroupBox7.Controls.Add(Me.txtTipoDocumentoJDE)
        Me.UltraGroupBox7.Controls.Add(Me.txtMoeda)
        Me.UltraGroupBox7.Controls.Add(Me.txtEmailInterfaceJDE)
        Me.UltraGroupBox7.Controls.Add(Me.txtDiretorio)
        Me.UltraGroupBox7.Controls.Add(Me.Label35)
        Me.UltraGroupBox7.Controls.Add(Me.Label36)
        Me.UltraGroupBox7.Controls.Add(Me.Label34)
        Me.UltraGroupBox7.Controls.Add(Me.Label10)
        Me.UltraGroupBox7.Location = New System.Drawing.Point(18, 189)
        Me.UltraGroupBox7.Name = "UltraGroupBox7"
        Me.UltraGroupBox7.Size = New System.Drawing.Size(502, 137)
        Me.UltraGroupBox7.TabIndex = 391
        Me.UltraGroupBox7.Text = "Interface Pagamentos - JDE"
        '
        'chkHabilitaPagamentoJDE
        '
        Me.chkHabilitaPagamentoJDE.Location = New System.Drawing.Point(165, 19)
        Me.chkHabilitaPagamentoJDE.Name = "chkHabilitaPagamentoJDE"
        Me.chkHabilitaPagamentoJDE.Size = New System.Drawing.Size(109, 36)
        Me.chkHabilitaPagamentoJDE.TabIndex = 393
        Me.chkHabilitaPagamentoJDE.Text = "Habilita Pagamento JDE"
        Me.chkHabilitaPagamentoJDE.UseVisualStyleBackColor = True
        '
        'txtTipoDocumentoJDE
        '
        Me.txtTipoDocumentoJDE.Location = New System.Drawing.Point(70, 32)
        Me.txtTipoDocumentoJDE.Name = "txtTipoDocumentoJDE"
        Me.txtTipoDocumentoJDE.Size = New System.Drawing.Size(89, 20)
        Me.txtTipoDocumentoJDE.TabIndex = 391
        '
        'txtMoeda
        '
        Me.txtMoeda.Location = New System.Drawing.Point(6, 32)
        Me.txtMoeda.Name = "txtMoeda"
        Me.txtMoeda.Size = New System.Drawing.Size(58, 20)
        Me.txtMoeda.TabIndex = 389
        '
        'txtEmailInterfaceJDE
        '
        Me.txtEmailInterfaceJDE.Location = New System.Drawing.Point(6, 87)
        Me.txtEmailInterfaceJDE.MaxLength = 4000
        Me.txtEmailInterfaceJDE.Multiline = True
        Me.txtEmailInterfaceJDE.Name = "txtEmailInterfaceJDE"
        Me.txtEmailInterfaceJDE.Size = New System.Drawing.Size(490, 44)
        Me.txtEmailInterfaceJDE.TabIndex = 364
        '
        'txtDiretorio
        '
        Me.txtDiretorio.Location = New System.Drawing.Point(280, 32)
        Me.txtDiretorio.Name = "txtDiretorio"
        Me.txtDiretorio.Size = New System.Drawing.Size(216, 20)
        Me.txtDiretorio.TabIndex = 174
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.Location = New System.Drawing.Point(67, 16)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(86, 13)
        Me.Label35.TabIndex = 392
        Me.Label35.Text = "Tipo Documento"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.Location = New System.Drawing.Point(6, 16)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(40, 13)
        Me.Label36.TabIndex = 390
        Me.Label36.Text = "Moeda"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Location = New System.Drawing.Point(6, 71)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(103, 13)
        Me.Label34.TabIndex = 365
        Me.Label34.Text = "E-mail Interface JDE"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(282, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 175
        Me.Label10.Text = "Diretorio"
        '
        'UltraGroupBox6
        '
        Me.UltraGroupBox6.Controls.Add(Me.txtTipoDocumento)
        Me.UltraGroupBox6.Controls.Add(Me.txtTipoPedido)
        Me.UltraGroupBox6.Controls.Add(Me.txtCodigoCompra)
        Me.UltraGroupBox6.Controls.Add(Me.Label33)
        Me.UltraGroupBox6.Controls.Add(Me.Label30)
        Me.UltraGroupBox6.Controls.Add(Me.Label32)
        Me.UltraGroupBox6.Location = New System.Drawing.Point(18, 117)
        Me.UltraGroupBox6.Name = "UltraGroupBox6"
        Me.UltraGroupBox6.Size = New System.Drawing.Size(309, 66)
        Me.UltraGroupBox6.TabIndex = 390
        Me.UltraGroupBox6.Text = "Interface Livro Fiscal"
        '
        'txtTipoDocumento
        '
        Me.txtTipoDocumento.Location = New System.Drawing.Point(214, 40)
        Me.txtTipoDocumento.Name = "txtTipoDocumento"
        Me.txtTipoDocumento.Size = New System.Drawing.Size(89, 20)
        Me.txtTipoDocumento.TabIndex = 387
        '
        'txtTipoPedido
        '
        Me.txtTipoPedido.Location = New System.Drawing.Point(119, 40)
        Me.txtTipoPedido.Name = "txtTipoPedido"
        Me.txtTipoPedido.Size = New System.Drawing.Size(89, 20)
        Me.txtTipoPedido.TabIndex = 385
        '
        'txtCodigoCompra
        '
        Me.txtCodigoCompra.Location = New System.Drawing.Point(6, 40)
        Me.txtCodigoCompra.Name = "txtCodigoCompra"
        Me.txtCodigoCompra.Size = New System.Drawing.Size(107, 20)
        Me.txtCodigoCompra.TabIndex = 383
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Location = New System.Drawing.Point(211, 24)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(86, 13)
        Me.Label33.TabIndex = 388
        Me.Label33.Text = "Tipo Documento"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Location = New System.Drawing.Point(115, 23)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(64, 13)
        Me.Label30.TabIndex = 386
        Me.Label30.Text = "Tipo Pedido"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Location = New System.Drawing.Point(6, 24)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(94, 13)
        Me.Label32.TabIndex = 384
        Me.Label32.Text = "Código de Compra"
        '
        'cboModalidadeConciliacaoDevolucao
        '
        Me.cboModalidadeConciliacaoDevolucao.Location = New System.Drawing.Point(349, 86)
        Me.cboModalidadeConciliacaoDevolucao.Name = "cboModalidadeConciliacaoDevolucao"
        Me.cboModalidadeConciliacaoDevolucao.Size = New System.Drawing.Size(171, 21)
        Me.cboModalidadeConciliacaoDevolucao.TabIndex = 388
        '
        'UltraGroupBox5
        '
        Me.UltraGroupBox5.Controls.Add(Me.txtAplicacaoContratoFixoMaximo)
        Me.UltraGroupBox5.Controls.Add(Me.txtAplicacaoNegociacaoMaxima)
        Me.UltraGroupBox5.Controls.Add(Me.Label29)
        Me.UltraGroupBox5.Controls.Add(Me.Label28)
        Me.UltraGroupBox5.Location = New System.Drawing.Point(330, 117)
        Me.UltraGroupBox5.Name = "UltraGroupBox5"
        Me.UltraGroupBox5.Size = New System.Drawing.Size(188, 66)
        Me.UltraGroupBox5.TabIndex = 385
        Me.UltraGroupBox5.Text = "% de Aplicação de Pagamento"
        '
        'txtAplicacaoContratoFixoMaximo
        '
        Me.txtAplicacaoContratoFixoMaximo.Location = New System.Drawing.Point(98, 39)
        Me.txtAplicacaoContratoFixoMaximo.MaskInput = "{LOC}-n.nn"
        Me.txtAplicacaoContratoFixoMaximo.Name = "txtAplicacaoContratoFixoMaximo"
        Me.txtAplicacaoContratoFixoMaximo.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtAplicacaoContratoFixoMaximo.Size = New System.Drawing.Size(84, 21)
        Me.txtAplicacaoContratoFixoMaximo.TabIndex = 387
        '
        'txtAplicacaoNegociacaoMaxima
        '
        Me.txtAplicacaoNegociacaoMaxima.Location = New System.Drawing.Point(9, 39)
        Me.txtAplicacaoNegociacaoMaxima.MaskInput = "{LOC}-n.nn"
        Me.txtAplicacaoNegociacaoMaxima.Name = "txtAplicacaoNegociacaoMaxima"
        Me.txtAplicacaoNegociacaoMaxima.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtAplicacaoNegociacaoMaxima.Size = New System.Drawing.Size(83, 21)
        Me.txtAplicacaoNegociacaoMaxima.TabIndex = 385
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Location = New System.Drawing.Point(95, 23)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(69, 13)
        Me.Label29.TabIndex = 388
        Me.Label29.Text = "Contrato Fixo"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Location = New System.Drawing.Point(6, 23)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(65, 13)
        Me.Label28.TabIndex = 386
        Me.Label28.Text = "Negociação"
        '
        'txtValorMinimoNFComplementar
        '
        Me.txtValorMinimoNFComplementar.Location = New System.Drawing.Point(192, 87)
        Me.txtValorMinimoNFComplementar.MaskInput = "{LOC}-n.nn"
        Me.txtValorMinimoNFComplementar.Name = "txtValorMinimoNFComplementar"
        Me.txtValorMinimoNFComplementar.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtValorMinimoNFComplementar.Size = New System.Drawing.Size(151, 21)
        Me.txtValorMinimoNFComplementar.TabIndex = 383
        '
        'txtContaContabilINSS
        '
        Me.txtContaContabilINSS.Location = New System.Drawing.Point(19, 87)
        Me.txtContaContabilINSS.Name = "txtContaContabilINSS"
        Me.txtContaContabilINSS.Size = New System.Drawing.Size(167, 20)
        Me.txtContaContabilINSS.TabIndex = 381
        '
        'txtDataSafra
        '
        Me.txtDataSafra.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataSafra.Location = New System.Drawing.Point(327, 37)
        Me.txtDataSafra.Name = "txtDataSafra"
        Me.txtDataSafra.ReadOnly = True
        Me.txtDataSafra.Size = New System.Drawing.Size(95, 23)
        Me.txtDataSafra.TabIndex = 379
        Me.txtDataSafra.Value = Nothing
        '
        'txtDataSistema
        '
        Me.txtDataSistema.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataSistema.Location = New System.Drawing.Point(428, 36)
        Me.txtDataSistema.Name = "txtDataSistema"
        Me.txtDataSistema.ReadOnly = True
        Me.txtDataSistema.Size = New System.Drawing.Size(92, 23)
        Me.txtDataSistema.TabIndex = 377
        Me.txtDataSistema.Value = Nothing
        '
        'txtSafra
        '
        Me.txtSafra.Location = New System.Drawing.Point(288, 38)
        Me.txtSafra.MaskInput = "{LOC}-nn"
        Me.txtSafra.Name = "txtSafra"
        Me.txtSafra.ReadOnly = True
        Me.txtSafra.Size = New System.Drawing.Size(33, 21)
        Me.txtSafra.TabIndex = 375
        '
        'txtEmpresa
        '
        Me.txtEmpresa.Location = New System.Drawing.Point(60, 37)
        Me.txtEmpresa.MaskInput = "{LOC}-nnnnnn"
        Me.txtEmpresa.Name = "txtEmpresa"
        Me.txtEmpresa.Size = New System.Drawing.Size(56, 21)
        Me.txtEmpresa.TabIndex = 373
        '
        'txtCia
        '
        Me.txtCia.Location = New System.Drawing.Point(21, 37)
        Me.txtCia.MaskInput = "{LOC}-nn"
        Me.txtCia.Name = "txtCia"
        Me.txtCia.Size = New System.Drawing.Size(33, 21)
        Me.txtCia.TabIndex = 371
        '
        'cboFilialMae
        '
        Me.cboFilialMae.Location = New System.Drawing.Point(122, 38)
        Me.cboFilialMae.Name = "cboFilialMae"
        Me.cboFilialMae.Size = New System.Drawing.Size(157, 21)
        Me.cboFilialMae.TabIndex = 355
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Location = New System.Drawing.Point(349, 70)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(117, 13)
        Me.Label31.TabIndex = 389
        Me.Label31.Text = "Modalidade Devolução"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Location = New System.Drawing.Point(189, 71)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(138, 13)
        Me.Label26.TabIndex = 384
        Me.Label26.Text = "Valor Min NF Complementar"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Location = New System.Drawing.Point(21, 71)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(104, 13)
        Me.Label25.TabIndex = 382
        Me.Label25.Text = "Conta Contabil INSS"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Location = New System.Drawing.Point(327, 22)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(58, 13)
        Me.Label24.TabIndex = 380
        Me.Label24.Text = "Data Safra"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Location = New System.Drawing.Point(425, 21)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(70, 13)
        Me.Label23.TabIndex = 378
        Me.Label23.Text = "Data Sistema"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Location = New System.Drawing.Point(285, 22)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(32, 13)
        Me.Label22.TabIndex = 376
        Me.Label22.Text = "Safra"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Location = New System.Drawing.Point(57, 21)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(48, 13)
        Me.Label21.TabIndex = 374
        Me.Label21.Text = "Empresa"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Location = New System.Drawing.Point(18, 21)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(22, 13)
        Me.Label20.TabIndex = 372
        Me.Label20.Text = "Cia"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(122, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 13)
        Me.Label11.TabIndex = 356
        Me.Label11.Text = "Filial Mãe"
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.Pesq_TP_MOV_EST_PROV_NF)
        Me.UltraTabPageControl2.Controls.Add(Me.Label63)
        Me.UltraTabPageControl2.Controls.Add(Me.Pesq_TP_MOV_PROV_NF)
        Me.UltraTabPageControl2.Controls.Add(Me.Label64)
        Me.UltraTabPageControl2.Controls.Add(Me.Pesq_TP_MOV_EST_REV_DIF)
        Me.UltraTabPageControl2.Controls.Add(Me.Label61)
        Me.UltraTabPageControl2.Controls.Add(Me.Pesq_TP_MOV_REV_DIF)
        Me.UltraTabPageControl2.Controls.Add(Me.Label62)
        Me.UltraTabPageControl2.Controls.Add(Me.Pesq_TP_MOV_EST_REV_AFIXAR)
        Me.UltraTabPageControl2.Controls.Add(Me.Label59)
        Me.UltraTabPageControl2.Controls.Add(Me.Pesq_TP_MOV_REV_AFIXAR)
        Me.UltraTabPageControl2.Controls.Add(Me.Label60)
        Me.UltraTabPageControl2.Controls.Add(Me.Pesq_ICMSImpotacao)
        Me.UltraTabPageControl2.Controls.Add(Me.Label42)
        Me.UltraTabPageControl2.Controls.Add(Me.Pesq_SaidaAordem)
        Me.UltraTabPageControl2.Controls.Add(Me.Pesq_ICMS)
        Me.UltraTabPageControl2.Controls.Add(Me.Pesq_EntradaFixoRD)
        Me.UltraTabPageControl2.Controls.Add(Me.Label41)
        Me.UltraTabPageControl2.Controls.Add(Me.Pesq_SaidaAordemImportado)
        Me.UltraTabPageControl2.Controls.Add(Me.Pesq_EntradaFixoImportado)
        Me.UltraTabPageControl2.Controls.Add(Me.Pesq_Funrural)
        Me.UltraTabPageControl2.Controls.Add(Me.Pesq_Desagio)
        Me.UltraTabPageControl2.Controls.Add(Me.Label56)
        Me.UltraTabPageControl2.Controls.Add(Me.Pesq_RecebimentoCacau)
        Me.UltraTabPageControl2.Controls.Add(Me.Label43)
        Me.UltraTabPageControl2.Controls.Add(Me.Pesq_DesagioSujidade)
        Me.UltraTabPageControl2.Controls.Add(Me.Label44)
        Me.UltraTabPageControl2.Controls.Add(Me.Label38)
        Me.UltraTabPageControl2.Controls.Add(Me.Label45)
        Me.UltraTabPageControl2.Controls.Add(Me.Pesq_recebimentoCacauImportado)
        Me.UltraTabPageControl2.Controls.Add(Me.Label47)
        Me.UltraTabPageControl2.Controls.Add(Me.Label37)
        Me.UltraTabPageControl2.Controls.Add(Me.Label48)
        Me.UltraTabPageControl2.Controls.Add(Me.Pesq_ICMSTransferencia)
        Me.UltraTabPageControl2.Controls.Add(Me.Label39)
        Me.UltraTabPageControl2.Controls.Add(Me.Label40)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(544, 421)
        '
        'Pesq_TP_MOV_EST_PROV_NF
        '
        Me.Pesq_TP_MOV_EST_PROV_NF.Ativo = True
        Me.Pesq_TP_MOV_EST_PROV_NF.BancoDados_Campo_Codigo = Nothing
        Me.Pesq_TP_MOV_EST_PROV_NF.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_TP_MOV_EST_PROV_NF.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_TP_MOV_EST_PROV_NF.BancoDados_Campo_Descricao = Nothing
        Me.Pesq_TP_MOV_EST_PROV_NF.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_TP_MOV_EST_PROV_NF.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_TP_MOV_EST_PROV_NF.BancoDados_Tabela = Nothing
        Me.Pesq_TP_MOV_EST_PROV_NF.Codigo = 0
        Me.Pesq_TP_MOV_EST_PROV_NF.Descricao = ""
        Me.Pesq_TP_MOV_EST_PROV_NF.ExibirCodigo = True
        Me.Pesq_TP_MOV_EST_PROV_NF.Location = New System.Drawing.Point(274, 393)
        Me.Pesq_TP_MOV_EST_PROV_NF.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_TP_MOV_EST_PROV_NF.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_TP_MOV_EST_PROV_NF.Name = "Pesq_TP_MOV_EST_PROV_NF"
        Me.Pesq_TP_MOV_EST_PROV_NF.Size = New System.Drawing.Size(247, 28)
        Me.Pesq_TP_MOV_EST_PROV_NF.TabIndex = 259
        Me.Pesq_TP_MOV_EST_PROV_NF.TelaFiltro = False
        Me.Pesq_TP_MOV_EST_PROV_NF.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Inicializar
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Location = New System.Drawing.Point(274, 377)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(155, 13)
        Me.Label63.TabIndex = 260
        Me.Label63.Text = "Estorno Prov NF Complementar"
        '
        'Pesq_TP_MOV_PROV_NF
        '
        Me.Pesq_TP_MOV_PROV_NF.Ativo = True
        Me.Pesq_TP_MOV_PROV_NF.BancoDados_Campo_Codigo = Nothing
        Me.Pesq_TP_MOV_PROV_NF.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_TP_MOV_PROV_NF.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_TP_MOV_PROV_NF.BancoDados_Campo_Descricao = Nothing
        Me.Pesq_TP_MOV_PROV_NF.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_TP_MOV_PROV_NF.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_TP_MOV_PROV_NF.BancoDados_Tabela = Nothing
        Me.Pesq_TP_MOV_PROV_NF.Codigo = 0
        Me.Pesq_TP_MOV_PROV_NF.Descricao = ""
        Me.Pesq_TP_MOV_PROV_NF.ExibirCodigo = True
        Me.Pesq_TP_MOV_PROV_NF.Location = New System.Drawing.Point(12, 393)
        Me.Pesq_TP_MOV_PROV_NF.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_TP_MOV_PROV_NF.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_TP_MOV_PROV_NF.Name = "Pesq_TP_MOV_PROV_NF"
        Me.Pesq_TP_MOV_PROV_NF.Size = New System.Drawing.Size(247, 28)
        Me.Pesq_TP_MOV_PROV_NF.TabIndex = 257
        Me.Pesq_TP_MOV_PROV_NF.TelaFiltro = False
        Me.Pesq_TP_MOV_PROV_NF.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Inicializar
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Location = New System.Drawing.Point(12, 377)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(116, 13)
        Me.Label64.TabIndex = 258
        Me.Label64.Text = "Prov NF Complementar"
        '
        'Pesq_TP_MOV_EST_REV_DIF
        '
        Me.Pesq_TP_MOV_EST_REV_DIF.Ativo = True
        Me.Pesq_TP_MOV_EST_REV_DIF.BancoDados_Campo_Codigo = Nothing
        Me.Pesq_TP_MOV_EST_REV_DIF.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_TP_MOV_EST_REV_DIF.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_TP_MOV_EST_REV_DIF.BancoDados_Campo_Descricao = Nothing
        Me.Pesq_TP_MOV_EST_REV_DIF.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_TP_MOV_EST_REV_DIF.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_TP_MOV_EST_REV_DIF.BancoDados_Tabela = Nothing
        Me.Pesq_TP_MOV_EST_REV_DIF.Codigo = 0
        Me.Pesq_TP_MOV_EST_REV_DIF.Descricao = ""
        Me.Pesq_TP_MOV_EST_REV_DIF.ExibirCodigo = True
        Me.Pesq_TP_MOV_EST_REV_DIF.Location = New System.Drawing.Point(274, 352)
        Me.Pesq_TP_MOV_EST_REV_DIF.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_TP_MOV_EST_REV_DIF.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_TP_MOV_EST_REV_DIF.Name = "Pesq_TP_MOV_EST_REV_DIF"
        Me.Pesq_TP_MOV_EST_REV_DIF.Size = New System.Drawing.Size(247, 28)
        Me.Pesq_TP_MOV_EST_REV_DIF.TabIndex = 255
        Me.Pesq_TP_MOV_EST_REV_DIF.TelaFiltro = False
        Me.Pesq_TP_MOV_EST_REV_DIF.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Inicializar
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Location = New System.Drawing.Point(274, 336)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(189, 13)
        Me.Label61.TabIndex = 256
        Me.Label61.Text = "Estorno Revalorização Diferencial Fixo"
        '
        'Pesq_TP_MOV_REV_DIF
        '
        Me.Pesq_TP_MOV_REV_DIF.Ativo = True
        Me.Pesq_TP_MOV_REV_DIF.BancoDados_Campo_Codigo = Nothing
        Me.Pesq_TP_MOV_REV_DIF.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_TP_MOV_REV_DIF.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_TP_MOV_REV_DIF.BancoDados_Campo_Descricao = Nothing
        Me.Pesq_TP_MOV_REV_DIF.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_TP_MOV_REV_DIF.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_TP_MOV_REV_DIF.BancoDados_Tabela = Nothing
        Me.Pesq_TP_MOV_REV_DIF.Codigo = 0
        Me.Pesq_TP_MOV_REV_DIF.Descricao = ""
        Me.Pesq_TP_MOV_REV_DIF.ExibirCodigo = True
        Me.Pesq_TP_MOV_REV_DIF.Location = New System.Drawing.Point(12, 352)
        Me.Pesq_TP_MOV_REV_DIF.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_TP_MOV_REV_DIF.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_TP_MOV_REV_DIF.Name = "Pesq_TP_MOV_REV_DIF"
        Me.Pesq_TP_MOV_REV_DIF.Size = New System.Drawing.Size(247, 28)
        Me.Pesq_TP_MOV_REV_DIF.TabIndex = 253
        Me.Pesq_TP_MOV_REV_DIF.TelaFiltro = False
        Me.Pesq_TP_MOV_REV_DIF.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Inicializar
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Location = New System.Drawing.Point(12, 336)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(150, 13)
        Me.Label62.TabIndex = 254
        Me.Label62.Text = "Revalorização Diferencial Fixo"
        '
        'Pesq_TP_MOV_EST_REV_AFIXAR
        '
        Me.Pesq_TP_MOV_EST_REV_AFIXAR.Ativo = True
        Me.Pesq_TP_MOV_EST_REV_AFIXAR.BancoDados_Campo_Codigo = Nothing
        Me.Pesq_TP_MOV_EST_REV_AFIXAR.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_TP_MOV_EST_REV_AFIXAR.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_TP_MOV_EST_REV_AFIXAR.BancoDados_Campo_Descricao = Nothing
        Me.Pesq_TP_MOV_EST_REV_AFIXAR.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_TP_MOV_EST_REV_AFIXAR.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_TP_MOV_EST_REV_AFIXAR.BancoDados_Tabela = Nothing
        Me.Pesq_TP_MOV_EST_REV_AFIXAR.Codigo = 0
        Me.Pesq_TP_MOV_EST_REV_AFIXAR.Descricao = ""
        Me.Pesq_TP_MOV_EST_REV_AFIXAR.ExibirCodigo = True
        Me.Pesq_TP_MOV_EST_REV_AFIXAR.Location = New System.Drawing.Point(274, 305)
        Me.Pesq_TP_MOV_EST_REV_AFIXAR.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_TP_MOV_EST_REV_AFIXAR.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_TP_MOV_EST_REV_AFIXAR.Name = "Pesq_TP_MOV_EST_REV_AFIXAR"
        Me.Pesq_TP_MOV_EST_REV_AFIXAR.Size = New System.Drawing.Size(247, 28)
        Me.Pesq_TP_MOV_EST_REV_AFIXAR.TabIndex = 251
        Me.Pesq_TP_MOV_EST_REV_AFIXAR.TelaFiltro = False
        Me.Pesq_TP_MOV_EST_REV_AFIXAR.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Inicializar
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(274, 289)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(179, 13)
        Me.Label59.TabIndex = 252
        Me.Label59.Text = "Estorno Revalorização Preço a Fixar"
        '
        'Pesq_TP_MOV_REV_AFIXAR
        '
        Me.Pesq_TP_MOV_REV_AFIXAR.Ativo = True
        Me.Pesq_TP_MOV_REV_AFIXAR.BancoDados_Campo_Codigo = Nothing
        Me.Pesq_TP_MOV_REV_AFIXAR.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_TP_MOV_REV_AFIXAR.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_TP_MOV_REV_AFIXAR.BancoDados_Campo_Descricao = Nothing
        Me.Pesq_TP_MOV_REV_AFIXAR.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_TP_MOV_REV_AFIXAR.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_TP_MOV_REV_AFIXAR.BancoDados_Tabela = Nothing
        Me.Pesq_TP_MOV_REV_AFIXAR.Codigo = 0
        Me.Pesq_TP_MOV_REV_AFIXAR.Descricao = ""
        Me.Pesq_TP_MOV_REV_AFIXAR.ExibirCodigo = True
        Me.Pesq_TP_MOV_REV_AFIXAR.Location = New System.Drawing.Point(12, 305)
        Me.Pesq_TP_MOV_REV_AFIXAR.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_TP_MOV_REV_AFIXAR.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_TP_MOV_REV_AFIXAR.Name = "Pesq_TP_MOV_REV_AFIXAR"
        Me.Pesq_TP_MOV_REV_AFIXAR.Size = New System.Drawing.Size(247, 28)
        Me.Pesq_TP_MOV_REV_AFIXAR.TabIndex = 249
        Me.Pesq_TP_MOV_REV_AFIXAR.TelaFiltro = False
        Me.Pesq_TP_MOV_REV_AFIXAR.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Inicializar
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(12, 289)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(140, 13)
        Me.Label60.TabIndex = 250
        Me.Label60.Text = "Revalorização Preço a Fixar"
        '
        'Pesq_ICMSImpotacao
        '
        Me.Pesq_ICMSImpotacao.Ativo = True
        Me.Pesq_ICMSImpotacao.BancoDados_Campo_Codigo = Nothing
        Me.Pesq_ICMSImpotacao.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_ICMSImpotacao.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_ICMSImpotacao.BancoDados_Campo_Descricao = Nothing
        Me.Pesq_ICMSImpotacao.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_ICMSImpotacao.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_ICMSImpotacao.BancoDados_Tabela = Nothing
        Me.Pesq_ICMSImpotacao.Codigo = 0
        Me.Pesq_ICMSImpotacao.Descricao = ""
        Me.Pesq_ICMSImpotacao.ExibirCodigo = True
        Me.Pesq_ICMSImpotacao.Location = New System.Drawing.Point(274, 257)
        Me.Pesq_ICMSImpotacao.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_ICMSImpotacao.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_ICMSImpotacao.Name = "Pesq_ICMSImpotacao"
        Me.Pesq_ICMSImpotacao.Size = New System.Drawing.Size(247, 28)
        Me.Pesq_ICMSImpotacao.TabIndex = 247
        Me.Pesq_ICMSImpotacao.TelaFiltro = False
        Me.Pesq_ICMSImpotacao.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Inicializar
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(12, 61)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(33, 13)
        Me.Label42.TabIndex = 246
        Me.Label42.Text = "ICMS"
        '
        'Pesq_SaidaAordem
        '
        Me.Pesq_SaidaAordem.Ativo = True
        Me.Pesq_SaidaAordem.BancoDados_Campo_Codigo = Nothing
        Me.Pesq_SaidaAordem.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_SaidaAordem.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_SaidaAordem.BancoDados_Campo_Descricao = Nothing
        Me.Pesq_SaidaAordem.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_SaidaAordem.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_SaidaAordem.BancoDados_Tabela = Nothing
        Me.Pesq_SaidaAordem.Codigo = 0
        Me.Pesq_SaidaAordem.Descricao = ""
        Me.Pesq_SaidaAordem.ExibirCodigo = True
        Me.Pesq_SaidaAordem.Location = New System.Drawing.Point(274, 77)
        Me.Pesq_SaidaAordem.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_SaidaAordem.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_SaidaAordem.Name = "Pesq_SaidaAordem"
        Me.Pesq_SaidaAordem.Size = New System.Drawing.Size(247, 28)
        Me.Pesq_SaidaAordem.TabIndex = 245
        Me.Pesq_SaidaAordem.TelaFiltro = False
        Me.Pesq_SaidaAordem.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Inicializar
        '
        'Pesq_ICMS
        '
        Me.Pesq_ICMS.Ativo = True
        Me.Pesq_ICMS.BancoDados_Campo_Codigo = Nothing
        Me.Pesq_ICMS.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_ICMS.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_ICMS.BancoDados_Campo_Descricao = Nothing
        Me.Pesq_ICMS.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_ICMS.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_ICMS.BancoDados_Tabela = Nothing
        Me.Pesq_ICMS.Codigo = 0
        Me.Pesq_ICMS.Descricao = ""
        Me.Pesq_ICMS.ExibirCodigo = True
        Me.Pesq_ICMS.Location = New System.Drawing.Point(12, 77)
        Me.Pesq_ICMS.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_ICMS.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_ICMS.Name = "Pesq_ICMS"
        Me.Pesq_ICMS.Size = New System.Drawing.Size(247, 28)
        Me.Pesq_ICMS.TabIndex = 245
        Me.Pesq_ICMS.TelaFiltro = False
        Me.Pesq_ICMS.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Inicializar
        '
        'Pesq_EntradaFixoRD
        '
        Me.Pesq_EntradaFixoRD.Ativo = True
        Me.Pesq_EntradaFixoRD.BancoDados_Campo_Codigo = Nothing
        Me.Pesq_EntradaFixoRD.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_EntradaFixoRD.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_EntradaFixoRD.BancoDados_Campo_Descricao = Nothing
        Me.Pesq_EntradaFixoRD.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_EntradaFixoRD.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_EntradaFixoRD.BancoDados_Tabela = Nothing
        Me.Pesq_EntradaFixoRD.Codigo = 0
        Me.Pesq_EntradaFixoRD.Descricao = ""
        Me.Pesq_EntradaFixoRD.ExibirCodigo = True
        Me.Pesq_EntradaFixoRD.Location = New System.Drawing.Point(274, 119)
        Me.Pesq_EntradaFixoRD.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_EntradaFixoRD.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_EntradaFixoRD.Name = "Pesq_EntradaFixoRD"
        Me.Pesq_EntradaFixoRD.Size = New System.Drawing.Size(247, 28)
        Me.Pesq_EntradaFixoRD.TabIndex = 243
        Me.Pesq_EntradaFixoRD.TelaFiltro = False
        Me.Pesq_EntradaFixoRD.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Inicializar
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(12, 106)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(45, 13)
        Me.Label41.TabIndex = 244
        Me.Label41.Text = "Funrural"
        '
        'Pesq_SaidaAordemImportado
        '
        Me.Pesq_SaidaAordemImportado.Ativo = True
        Me.Pesq_SaidaAordemImportado.BancoDados_Campo_Codigo = Nothing
        Me.Pesq_SaidaAordemImportado.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_SaidaAordemImportado.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_SaidaAordemImportado.BancoDados_Campo_Descricao = Nothing
        Me.Pesq_SaidaAordemImportado.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_SaidaAordemImportado.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_SaidaAordemImportado.BancoDados_Tabela = Nothing
        Me.Pesq_SaidaAordemImportado.Codigo = 0
        Me.Pesq_SaidaAordemImportado.Descricao = ""
        Me.Pesq_SaidaAordemImportado.ExibirCodigo = True
        Me.Pesq_SaidaAordemImportado.Location = New System.Drawing.Point(274, 166)
        Me.Pesq_SaidaAordemImportado.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_SaidaAordemImportado.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_SaidaAordemImportado.Name = "Pesq_SaidaAordemImportado"
        Me.Pesq_SaidaAordemImportado.Size = New System.Drawing.Size(247, 28)
        Me.Pesq_SaidaAordemImportado.TabIndex = 241
        Me.Pesq_SaidaAordemImportado.TelaFiltro = False
        Me.Pesq_SaidaAordemImportado.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Inicializar
        '
        'Pesq_EntradaFixoImportado
        '
        Me.Pesq_EntradaFixoImportado.Ativo = True
        Me.Pesq_EntradaFixoImportado.BancoDados_Campo_Codigo = Nothing
        Me.Pesq_EntradaFixoImportado.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_EntradaFixoImportado.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_EntradaFixoImportado.BancoDados_Campo_Descricao = Nothing
        Me.Pesq_EntradaFixoImportado.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_EntradaFixoImportado.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_EntradaFixoImportado.BancoDados_Tabela = Nothing
        Me.Pesq_EntradaFixoImportado.Codigo = 0
        Me.Pesq_EntradaFixoImportado.Descricao = ""
        Me.Pesq_EntradaFixoImportado.ExibirCodigo = True
        Me.Pesq_EntradaFixoImportado.Location = New System.Drawing.Point(274, 210)
        Me.Pesq_EntradaFixoImportado.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_EntradaFixoImportado.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_EntradaFixoImportado.Name = "Pesq_EntradaFixoImportado"
        Me.Pesq_EntradaFixoImportado.Size = New System.Drawing.Size(247, 28)
        Me.Pesq_EntradaFixoImportado.TabIndex = 237
        Me.Pesq_EntradaFixoImportado.TelaFiltro = False
        Me.Pesq_EntradaFixoImportado.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Inicializar
        '
        'Pesq_Funrural
        '
        Me.Pesq_Funrural.Ativo = True
        Me.Pesq_Funrural.BancoDados_Campo_Codigo = Nothing
        Me.Pesq_Funrural.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Funrural.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_Funrural.BancoDados_Campo_Descricao = Nothing
        Me.Pesq_Funrural.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_Funrural.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Funrural.BancoDados_Tabela = Nothing
        Me.Pesq_Funrural.Codigo = 0
        Me.Pesq_Funrural.Descricao = ""
        Me.Pesq_Funrural.ExibirCodigo = True
        Me.Pesq_Funrural.Location = New System.Drawing.Point(12, 119)
        Me.Pesq_Funrural.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_Funrural.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_Funrural.Name = "Pesq_Funrural"
        Me.Pesq_Funrural.Size = New System.Drawing.Size(247, 28)
        Me.Pesq_Funrural.TabIndex = 243
        Me.Pesq_Funrural.TelaFiltro = False
        Me.Pesq_Funrural.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Inicializar
        '
        'Pesq_Desagio
        '
        Me.Pesq_Desagio.Ativo = True
        Me.Pesq_Desagio.BancoDados_Campo_Codigo = Nothing
        Me.Pesq_Desagio.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Desagio.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_Desagio.BancoDados_Campo_Descricao = Nothing
        Me.Pesq_Desagio.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_Desagio.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Desagio.BancoDados_Tabela = Nothing
        Me.Pesq_Desagio.Codigo = 0
        Me.Pesq_Desagio.Descricao = ""
        Me.Pesq_Desagio.ExibirCodigo = True
        Me.Pesq_Desagio.Location = New System.Drawing.Point(274, 29)
        Me.Pesq_Desagio.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_Desagio.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_Desagio.Name = "Pesq_Desagio"
        Me.Pesq_Desagio.Size = New System.Drawing.Size(247, 28)
        Me.Pesq_Desagio.TabIndex = 235
        Me.Pesq_Desagio.TelaFiltro = False
        Me.Pesq_Desagio.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Inicializar
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(274, 241)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(95, 13)
        Me.Label56.TabIndex = 248
        Me.Label56.Text = "ICMS - Importação"
        '
        'Pesq_RecebimentoCacau
        '
        Me.Pesq_RecebimentoCacau.Ativo = True
        Me.Pesq_RecebimentoCacau.BancoDados_Campo_Codigo = Nothing
        Me.Pesq_RecebimentoCacau.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_RecebimentoCacau.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_RecebimentoCacau.BancoDados_Campo_Descricao = Nothing
        Me.Pesq_RecebimentoCacau.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_RecebimentoCacau.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_RecebimentoCacau.BancoDados_Tabela = Nothing
        Me.Pesq_RecebimentoCacau.Codigo = 0
        Me.Pesq_RecebimentoCacau.Descricao = ""
        Me.Pesq_RecebimentoCacau.ExibirCodigo = True
        Me.Pesq_RecebimentoCacau.Location = New System.Drawing.Point(12, 166)
        Me.Pesq_RecebimentoCacau.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_RecebimentoCacau.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_RecebimentoCacau.Name = "Pesq_RecebimentoCacau"
        Me.Pesq_RecebimentoCacau.Size = New System.Drawing.Size(247, 28)
        Me.Pesq_RecebimentoCacau.TabIndex = 241
        Me.Pesq_RecebimentoCacau.TelaFiltro = False
        Me.Pesq_RecebimentoCacau.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Inicializar
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(274, 61)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(135, 13)
        Me.Label43.TabIndex = 246
        Me.Label43.Text = "Aplicação - Saída a Ordem"
        '
        'Pesq_DesagioSujidade
        '
        Me.Pesq_DesagioSujidade.Ativo = True
        Me.Pesq_DesagioSujidade.BancoDados_Campo_Codigo = Nothing
        Me.Pesq_DesagioSujidade.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_DesagioSujidade.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_DesagioSujidade.BancoDados_Campo_Descricao = Nothing
        Me.Pesq_DesagioSujidade.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_DesagioSujidade.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_DesagioSujidade.BancoDados_Tabela = Nothing
        Me.Pesq_DesagioSujidade.Codigo = 0
        Me.Pesq_DesagioSujidade.Descricao = ""
        Me.Pesq_DesagioSujidade.ExibirCodigo = True
        Me.Pesq_DesagioSujidade.Location = New System.Drawing.Point(12, 257)
        Me.Pesq_DesagioSujidade.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_DesagioSujidade.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_DesagioSujidade.Name = "Pesq_DesagioSujidade"
        Me.Pesq_DesagioSujidade.Size = New System.Drawing.Size(247, 28)
        Me.Pesq_DesagioSujidade.TabIndex = 239
        Me.Pesq_DesagioSujidade.TelaFiltro = False
        Me.Pesq_DesagioSujidade.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Inicializar
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(274, 106)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(178, 13)
        Me.Label44.TabIndex = 244
        Me.Label44.Text = "Aplicação - Entrada Fixo no RD Fixo"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(12, 13)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(101, 13)
        Me.Label38.TabIndex = 236
        Me.Label38.Text = "ICMS Transferência"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(274, 150)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(189, 13)
        Me.Label45.TabIndex = 242
        Me.Label45.Text = "Aplicação - Saida a Ordem - Importado"
        '
        'Pesq_recebimentoCacauImportado
        '
        Me.Pesq_recebimentoCacauImportado.Ativo = True
        Me.Pesq_recebimentoCacauImportado.BancoDados_Campo_Codigo = Nothing
        Me.Pesq_recebimentoCacauImportado.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_recebimentoCacauImportado.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_recebimentoCacauImportado.BancoDados_Campo_Descricao = Nothing
        Me.Pesq_recebimentoCacauImportado.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_recebimentoCacauImportado.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_recebimentoCacauImportado.BancoDados_Tabela = Nothing
        Me.Pesq_recebimentoCacauImportado.Codigo = 0
        Me.Pesq_recebimentoCacauImportado.Descricao = ""
        Me.Pesq_recebimentoCacauImportado.ExibirCodigo = True
        Me.Pesq_recebimentoCacauImportado.Location = New System.Drawing.Point(12, 210)
        Me.Pesq_recebimentoCacauImportado.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_recebimentoCacauImportado.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_recebimentoCacauImportado.Name = "Pesq_recebimentoCacauImportado"
        Me.Pesq_recebimentoCacauImportado.Size = New System.Drawing.Size(247, 28)
        Me.Pesq_recebimentoCacauImportado.TabIndex = 237
        Me.Pesq_recebimentoCacauImportado.TelaFiltro = False
        Me.Pesq_recebimentoCacauImportado.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Inicializar
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(274, 197)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(178, 13)
        Me.Label47.TabIndex = 238
        Me.Label47.Text = "Aplicação - Entrada Fixo - Importado"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(12, 197)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(154, 13)
        Me.Label37.TabIndex = 238
        Me.Label37.Text = "Recebimento Cacau Importado"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(274, 13)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(46, 13)
        Me.Label48.TabIndex = 236
        Me.Label48.Text = "Desagio"
        '
        'Pesq_ICMSTransferencia
        '
        Me.Pesq_ICMSTransferencia.Ativo = True
        Me.Pesq_ICMSTransferencia.BancoDados_Campo_Codigo = Nothing
        Me.Pesq_ICMSTransferencia.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_ICMSTransferencia.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_ICMSTransferencia.BancoDados_Campo_Descricao = Nothing
        Me.Pesq_ICMSTransferencia.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_ICMSTransferencia.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_ICMSTransferencia.BancoDados_Tabela = Nothing
        Me.Pesq_ICMSTransferencia.Codigo = 0
        Me.Pesq_ICMSTransferencia.Descricao = ""
        Me.Pesq_ICMSTransferencia.ExibirCodigo = True
        Me.Pesq_ICMSTransferencia.Location = New System.Drawing.Point(12, 29)
        Me.Pesq_ICMSTransferencia.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_ICMSTransferencia.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_ICMSTransferencia.Name = "Pesq_ICMSTransferencia"
        Me.Pesq_ICMSTransferencia.Size = New System.Drawing.Size(247, 28)
        Me.Pesq_ICMSTransferencia.TabIndex = 235
        Me.Pesq_ICMSTransferencia.TelaFiltro = False
        Me.Pesq_ICMSTransferencia.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Inicializar
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(12, 241)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(90, 13)
        Me.Label39.TabIndex = 240
        Me.Label39.Text = "Desagio Sujidade"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(12, 150)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(104, 13)
        Me.Label40.TabIndex = 242
        Me.Label40.Text = "Recebimento Cacau"
        '
        'UltraTabPageControl6
        '
        Me.UltraTabPageControl6.Controls.Add(Me.cboMoedaCredito)
        Me.UltraTabPageControl6.Controls.Add(Me.UltraGroupBox14)
        Me.UltraTabPageControl6.Controls.Add(Me.UltraGroupBox13)
        Me.UltraTabPageControl6.Controls.Add(Me.UltraGroupBox12)
        Me.UltraTabPageControl6.Controls.Add(Me.UltraGroupBox11)
        Me.UltraTabPageControl6.Controls.Add(Me.UltraGroupBox10)
        Me.UltraTabPageControl6.Controls.Add(Me.Label58)
        Me.UltraTabPageControl6.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl6.Name = "UltraTabPageControl6"
        Me.UltraTabPageControl6.Size = New System.Drawing.Size(544, 421)
        '
        'cboMoedaCredito
        '
        Me.cboMoedaCredito.Location = New System.Drawing.Point(431, 265)
        Me.cboMoedaCredito.Name = "cboMoedaCredito"
        Me.cboMoedaCredito.Size = New System.Drawing.Size(101, 21)
        Me.cboMoedaCredito.TabIndex = 421
        '
        'UltraGroupBox14
        '
        Me.UltraGroupBox14.Controls.Add(Me.txtDiasMaximoFixacao)
        Me.UltraGroupBox14.Controls.Add(Me.Label46)
        Me.UltraGroupBox14.Location = New System.Drawing.Point(291, 189)
        Me.UltraGroupBox14.Name = "UltraGroupBox14"
        Me.UltraGroupBox14.Size = New System.Drawing.Size(241, 45)
        Me.UltraGroupBox14.TabIndex = 420
        '
        'txtDiasMaximoFixacao
        '
        Me.txtDiasMaximoFixacao.Location = New System.Drawing.Point(182, 11)
        Me.txtDiasMaximoFixacao.MaskInput = "{LOC}-nn"
        Me.txtDiasMaximoFixacao.Name = "txtDiasMaximoFixacao"
        Me.txtDiasMaximoFixacao.Size = New System.Drawing.Size(41, 21)
        Me.txtDiasMaximoFixacao.TabIndex = 414
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.BackColor = System.Drawing.Color.Transparent
        Me.Label46.Location = New System.Drawing.Point(6, 15)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(173, 13)
        Me.Label46.TabIndex = 415
        Me.Label46.Text = "Dias Maximo Fixação Contrato PAF"
        '
        'UltraGroupBox13
        '
        Me.UltraGroupBox13.Controls.Add(Me.cboTipoCtrPAFNegociaMaster)
        Me.UltraGroupBox13.Controls.Add(Me.cboTipoAprovacaoInterna)
        Me.UltraGroupBox13.Controls.Add(Me.cboTipoNegociacaoPadrao)
        Me.UltraGroupBox13.Controls.Add(Me.cboTipoFreteTransferencia)
        Me.UltraGroupBox13.Controls.Add(Me.cboTipoFreteRecebimentoCacau)
        Me.UltraGroupBox13.Controls.Add(Me.Label49)
        Me.UltraGroupBox13.Controls.Add(Me.Label50)
        Me.UltraGroupBox13.Controls.Add(Me.Label51)
        Me.UltraGroupBox13.Controls.Add(Me.Label52)
        Me.UltraGroupBox13.Controls.Add(Me.Label53)
        Me.UltraGroupBox13.Location = New System.Drawing.Point(20, 9)
        Me.UltraGroupBox13.Name = "UltraGroupBox13"
        Me.UltraGroupBox13.Size = New System.Drawing.Size(238, 237)
        Me.UltraGroupBox13.TabIndex = 419
        '
        'cboTipoCtrPAFNegociaMaster
        '
        Me.cboTipoCtrPAFNegociaMaster.Location = New System.Drawing.Point(6, 204)
        Me.cboTipoCtrPAFNegociaMaster.Name = "cboTipoCtrPAFNegociaMaster"
        Me.cboTipoCtrPAFNegociaMaster.Size = New System.Drawing.Size(218, 21)
        Me.cboTipoCtrPAFNegociaMaster.TabIndex = 392
        '
        'cboTipoAprovacaoInterna
        '
        Me.cboTipoAprovacaoInterna.Location = New System.Drawing.Point(6, 157)
        Me.cboTipoAprovacaoInterna.Name = "cboTipoAprovacaoInterna"
        Me.cboTipoAprovacaoInterna.Size = New System.Drawing.Size(218, 21)
        Me.cboTipoAprovacaoInterna.TabIndex = 394
        '
        'cboTipoNegociacaoPadrao
        '
        Me.cboTipoNegociacaoPadrao.Location = New System.Drawing.Point(6, 112)
        Me.cboTipoNegociacaoPadrao.Name = "cboTipoNegociacaoPadrao"
        Me.cboTipoNegociacaoPadrao.Size = New System.Drawing.Size(218, 21)
        Me.cboTipoNegociacaoPadrao.TabIndex = 396
        '
        'cboTipoFreteTransferencia
        '
        Me.cboTipoFreteTransferencia.Location = New System.Drawing.Point(6, 66)
        Me.cboTipoFreteTransferencia.Name = "cboTipoFreteTransferencia"
        Me.cboTipoFreteTransferencia.Size = New System.Drawing.Size(218, 21)
        Me.cboTipoFreteTransferencia.TabIndex = 398
        '
        'cboTipoFreteRecebimentoCacau
        '
        Me.cboTipoFreteRecebimentoCacau.Location = New System.Drawing.Point(6, 22)
        Me.cboTipoFreteRecebimentoCacau.Name = "cboTipoFreteRecebimentoCacau"
        Me.cboTipoFreteRecebimentoCacau.Size = New System.Drawing.Size(218, 21)
        Me.cboTipoFreteRecebimentoCacau.TabIndex = 400
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.BackColor = System.Drawing.Color.Transparent
        Me.Label49.Location = New System.Drawing.Point(6, 188)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(190, 13)
        Me.Label49.TabIndex = 393
        Me.Label49.Text = "Tipo Contrato PAF Negociação Master"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.BackColor = System.Drawing.Color.Transparent
        Me.Label50.Location = New System.Drawing.Point(6, 141)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(119, 13)
        Me.Label50.TabIndex = 395
        Me.Label50.Text = "Tipo Aprovação Interna"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.BackColor = System.Drawing.Color.Transparent
        Me.Label51.Location = New System.Drawing.Point(6, 96)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(126, 13)
        Me.Label51.TabIndex = 397
        Me.Label51.Text = "Tipo Negociação Padrão"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.BackColor = System.Drawing.Color.Transparent
        Me.Label52.Location = New System.Drawing.Point(6, 50)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(129, 13)
        Me.Label52.TabIndex = 399
        Me.Label52.Text = "Tipo Frete - Transferência"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.BackColor = System.Drawing.Color.Transparent
        Me.Label53.Location = New System.Drawing.Point(6, 6)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(161, 13)
        Me.Label53.TabIndex = 401
        Me.Label53.Text = "Tipo Frete - Recebimento Cacau"
        '
        'UltraGroupBox12
        '
        Me.UltraGroupBox12.Controls.Add(Me.cboModalidadeConciliacaoICMS)
        Me.UltraGroupBox12.Controls.Add(Me.Label57)
        Me.UltraGroupBox12.Location = New System.Drawing.Point(291, 130)
        Me.UltraGroupBox12.Name = "UltraGroupBox12"
        Me.UltraGroupBox12.Size = New System.Drawing.Size(241, 52)
        Me.UltraGroupBox12.TabIndex = 418
        '
        'cboModalidadeConciliacaoICMS
        '
        Me.cboModalidadeConciliacaoICMS.Location = New System.Drawing.Point(9, 23)
        Me.cboModalidadeConciliacaoICMS.Name = "cboModalidadeConciliacaoICMS"
        Me.cboModalidadeConciliacaoICMS.Size = New System.Drawing.Size(218, 21)
        Me.cboModalidadeConciliacaoICMS.TabIndex = 406
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.BackColor = System.Drawing.Color.Transparent
        Me.Label57.Location = New System.Drawing.Point(9, 7)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(149, 13)
        Me.Label57.TabIndex = 407
        Me.Label57.Text = "Modalidade Conciliacao ICMS"
        '
        'UltraGroupBox11
        '
        Me.UltraGroupBox11.Controls.Add(Me.chkSacariaFornecedor)
        Me.UltraGroupBox11.Controls.Add(Me.chkHabilitaBranche)
        Me.UltraGroupBox11.Controls.Add(Me.chkEnviaEmailCredito)
        Me.UltraGroupBox11.Controls.Add(Me.chkCacauAordemMaster)
        Me.UltraGroupBox11.Location = New System.Drawing.Point(20, 256)
        Me.UltraGroupBox11.Name = "UltraGroupBox11"
        Me.UltraGroupBox11.Size = New System.Drawing.Size(402, 63)
        Me.UltraGroupBox11.TabIndex = 416
        '
        'chkSacariaFornecedor
        '
        Me.chkSacariaFornecedor.AutoSize = True
        Me.chkSacariaFornecedor.Location = New System.Drawing.Point(6, 33)
        Me.chkSacariaFornecedor.Name = "chkSacariaFornecedor"
        Me.chkSacariaFornecedor.Size = New System.Drawing.Size(119, 17)
        Me.chkSacariaFornecedor.TabIndex = 412
        Me.chkSacariaFornecedor.Text = "Sacaria Fornecedor"
        Me.chkSacariaFornecedor.UseVisualStyleBackColor = True
        '
        'chkHabilitaBranche
        '
        Me.chkHabilitaBranche.AutoSize = True
        Me.chkHabilitaBranche.Location = New System.Drawing.Point(6, 10)
        Me.chkHabilitaBranche.Name = "chkHabilitaBranche"
        Me.chkHabilitaBranche.Size = New System.Drawing.Size(104, 17)
        Me.chkHabilitaBranche.TabIndex = 409
        Me.chkHabilitaBranche.Text = "Habilita Branche"
        Me.chkHabilitaBranche.UseVisualStyleBackColor = True
        '
        'chkEnviaEmailCredito
        '
        Me.chkEnviaEmailCredito.AutoSize = True
        Me.chkEnviaEmailCredito.Location = New System.Drawing.Point(143, 33)
        Me.chkEnviaEmailCredito.Name = "chkEnviaEmailCredito"
        Me.chkEnviaEmailCredito.Size = New System.Drawing.Size(135, 17)
        Me.chkEnviaEmailCredito.TabIndex = 410
        Me.chkEnviaEmailCredito.Text = "Envia E-mail do Crédito"
        Me.chkEnviaEmailCredito.UseVisualStyleBackColor = True
        '
        'chkCacauAordemMaster
        '
        Me.chkCacauAordemMaster.AutoSize = True
        Me.chkCacauAordemMaster.Location = New System.Drawing.Point(143, 10)
        Me.chkCacauAordemMaster.Name = "chkCacauAordemMaster"
        Me.chkCacauAordemMaster.Size = New System.Drawing.Size(132, 17)
        Me.chkCacauAordemMaster.TabIndex = 411
        Me.chkCacauAordemMaster.Text = "Cacau NPE no Master"
        Me.chkCacauAordemMaster.UseVisualStyleBackColor = True
        '
        'UltraGroupBox10
        '
        Me.UltraGroupBox10.Controls.Add(Me.cboTipoPagamentoICMS)
        Me.UltraGroupBox10.Controls.Add(Me.cboTipoPagamentoGP)
        Me.UltraGroupBox10.Controls.Add(Me.Label54)
        Me.UltraGroupBox10.Controls.Add(Me.Label55)
        Me.UltraGroupBox10.Location = New System.Drawing.Point(291, 15)
        Me.UltraGroupBox10.Name = "UltraGroupBox10"
        Me.UltraGroupBox10.Size = New System.Drawing.Size(241, 109)
        Me.UltraGroupBox10.TabIndex = 408
        Me.UltraGroupBox10.Text = "Tipo Pagamento"
        '
        'cboTipoPagamentoICMS
        '
        Me.cboTipoPagamentoICMS.Location = New System.Drawing.Point(11, 31)
        Me.cboTipoPagamentoICMS.Name = "cboTipoPagamentoICMS"
        Me.cboTipoPagamentoICMS.Size = New System.Drawing.Size(218, 21)
        Me.cboTipoPagamentoICMS.TabIndex = 402
        '
        'cboTipoPagamentoGP
        '
        Me.cboTipoPagamentoGP.Location = New System.Drawing.Point(11, 77)
        Me.cboTipoPagamentoGP.Name = "cboTipoPagamentoGP"
        Me.cboTipoPagamentoGP.Size = New System.Drawing.Size(218, 21)
        Me.cboTipoPagamentoGP.TabIndex = 404
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.BackColor = System.Drawing.Color.Transparent
        Me.Label54.Location = New System.Drawing.Point(11, 15)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(120, 13)
        Me.Label54.TabIndex = 403
        Me.Label54.Text = "Tipo Pagamento - ICMS"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.BackColor = System.Drawing.Color.Transparent
        Me.Label55.Location = New System.Drawing.Point(11, 61)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(109, 13)
        Me.Label55.TabIndex = 405
        Me.Label55.Text = "Tipo Pagamento - GP"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.BackColor = System.Drawing.Color.Transparent
        Me.Label58.Location = New System.Drawing.Point(428, 249)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(76, 13)
        Me.Label58.TabIndex = 417
        Me.Label58.Text = "Moeda Crédito"
        '
        'UltraTabPageControl4
        '
        Me.UltraTabPageControl4.Controls.Add(Me.txtDataVigencia)
        Me.UltraTabPageControl4.Controls.Add(Me.chkDesagioContrato)
        Me.UltraTabPageControl4.Controls.Add(Me.chkDesagioNF)
        Me.UltraTabPageControl4.Controls.Add(Me.UltraGroupBox2)
        Me.UltraTabPageControl4.Controls.Add(Me.UltraGroupBox1)
        Me.UltraTabPageControl4.Controls.Add(Me.txtEmailQualidade)
        Me.UltraTabPageControl4.Controls.Add(Me.Label9)
        Me.UltraTabPageControl4.Controls.Add(Me.Label5)
        Me.UltraTabPageControl4.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl4.Name = "UltraTabPageControl4"
        Me.UltraTabPageControl4.Size = New System.Drawing.Size(544, 421)
        '
        'txtDataVigencia
        '
        Me.txtDataVigencia.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataVigencia.Location = New System.Drawing.Point(218, 144)
        Me.txtDataVigencia.Name = "txtDataVigencia"
        Me.txtDataVigencia.Size = New System.Drawing.Size(104, 23)
        Me.txtDataVigencia.TabIndex = 359
        Me.txtDataVigencia.Value = Nothing
        '
        'chkDesagioContrato
        '
        Me.chkDesagioContrato.AutoSize = True
        Me.chkDesagioContrato.Location = New System.Drawing.Point(104, 144)
        Me.chkDesagioContrato.Name = "chkDesagioContrato"
        Me.chkDesagioContrato.Size = New System.Drawing.Size(108, 17)
        Me.chkDesagioContrato.TabIndex = 358
        Me.chkDesagioContrato.Text = "Desagio Contrato"
        Me.chkDesagioContrato.UseVisualStyleBackColor = True
        '
        'chkDesagioNF
        '
        Me.chkDesagioNF.AutoSize = True
        Me.chkDesagioNF.Location = New System.Drawing.Point(16, 144)
        Me.chkDesagioNF.Name = "chkDesagioNF"
        Me.chkDesagioNF.Size = New System.Drawing.Size(82, 17)
        Me.chkDesagioNF.TabIndex = 357
        Me.chkDesagioNF.Text = "Desagio NF"
        Me.chkDesagioNF.UseVisualStyleBackColor = True
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.cboTipoPagamentoSujidade)
        Me.UltraGroupBox2.Controls.Add(Me.cboTipoPagamentoUmidade)
        Me.UltraGroupBox2.Controls.Add(Me.Label6)
        Me.UltraGroupBox2.Controls.Add(Me.Label4)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(16, 15)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(238, 110)
        Me.UltraGroupBox2.TabIndex = 356
        Me.UltraGroupBox2.Text = "Tipo Pagamento"
        '
        'cboTipoPagamentoSujidade
        '
        Me.cboTipoPagamentoSujidade.Location = New System.Drawing.Point(6, 83)
        Me.cboTipoPagamentoSujidade.Name = "cboTipoPagamentoSujidade"
        Me.cboTipoPagamentoSujidade.Size = New System.Drawing.Size(218, 21)
        Me.cboTipoPagamentoSujidade.TabIndex = 357
        '
        'cboTipoPagamentoUmidade
        '
        Me.cboTipoPagamentoUmidade.Location = New System.Drawing.Point(6, 38)
        Me.cboTipoPagamentoUmidade.Name = "cboTipoPagamentoUmidade"
        Me.cboTipoPagamentoUmidade.Size = New System.Drawing.Size(218, 21)
        Me.cboTipoPagamentoUmidade.TabIndex = 353
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(6, 67)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 358
        Me.Label6.Text = "Sujidade"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(6, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 354
        Me.Label4.Text = "Umidade"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.cboModalidadeConciliacaoEstorno)
        Me.UltraGroupBox1.Controls.Add(Me.cboModalidadeConciliacaoAcordo)
        Me.UltraGroupBox1.Controls.Add(Me.Label7)
        Me.UltraGroupBox1.Controls.Add(Me.Label8)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(293, 15)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(238, 110)
        Me.UltraGroupBox1.TabIndex = 355
        Me.UltraGroupBox1.Text = "Modalidade Conciliacao"
        '
        'cboModalidadeConciliacaoEstorno
        '
        Me.cboModalidadeConciliacaoEstorno.Location = New System.Drawing.Point(14, 83)
        Me.cboModalidadeConciliacaoEstorno.Name = "cboModalidadeConciliacaoEstorno"
        Me.cboModalidadeConciliacaoEstorno.Size = New System.Drawing.Size(218, 21)
        Me.cboModalidadeConciliacaoEstorno.TabIndex = 361
        '
        'cboModalidadeConciliacaoAcordo
        '
        Me.cboModalidadeConciliacaoAcordo.Location = New System.Drawing.Point(14, 38)
        Me.cboModalidadeConciliacaoAcordo.Name = "cboModalidadeConciliacaoAcordo"
        Me.cboModalidadeConciliacaoAcordo.Size = New System.Drawing.Size(218, 21)
        Me.cboModalidadeConciliacaoAcordo.TabIndex = 359
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(14, 67)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 362
        Me.Label7.Text = "Estorno"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(14, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 360
        Me.Label8.Text = "Acordo"
        '
        'txtEmailQualidade
        '
        Me.txtEmailQualidade.Location = New System.Drawing.Point(16, 195)
        Me.txtEmailQualidade.MaxLength = 4000
        Me.txtEmailQualidade.Multiline = True
        Me.txtEmailQualidade.Name = "txtEmailQualidade"
        Me.txtEmailQualidade.Size = New System.Drawing.Size(515, 44)
        Me.txtEmailQualidade.TabIndex = 351
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(218, 129)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 13)
        Me.Label9.TabIndex = 360
        Me.Label9.Text = "Data Vigencia"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(13, 179)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(328, 13)
        Me.Label5.TabIndex = 352
        Me.Label5.Text = "E-mail para informação de cacau com qualidade inferior ao permitido"
        '
        'UltraTabPageControl5
        '
        Me.UltraTabPageControl5.Controls.Add(Me.txtMaximoCarenciaJuros)
        Me.UltraTabPageControl5.Controls.Add(Me.txtJurosAoMes)
        Me.UltraTabPageControl5.Controls.Add(Me.optCobraJuros)
        Me.UltraTabPageControl5.Controls.Add(Me.txtEmailEstornoJuros)
        Me.UltraTabPageControl5.Controls.Add(Me.chkJurosAutomatico)
        Me.UltraTabPageControl5.Controls.Add(Me.UltraGroupBox3)
        Me.UltraTabPageControl5.Controls.Add(Me.UltraGroupBox4)
        Me.UltraTabPageControl5.Controls.Add(Me.txtEmailAlteracaoJuros)
        Me.UltraTabPageControl5.Controls.Add(Me.Label19)
        Me.UltraTabPageControl5.Controls.Add(Me.Label18)
        Me.UltraTabPageControl5.Controls.Add(Me.Label17)
        Me.UltraTabPageControl5.Controls.Add(Me.Label16)
        Me.UltraTabPageControl5.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl5.Name = "UltraTabPageControl5"
        Me.UltraTabPageControl5.Size = New System.Drawing.Size(544, 421)
        '
        'txtMaximoCarenciaJuros
        '
        Me.txtMaximoCarenciaJuros.Location = New System.Drawing.Point(108, 158)
        Me.txtMaximoCarenciaJuros.MaskInput = "{LOC}-nnn"
        Me.txtMaximoCarenciaJuros.Name = "txtMaximoCarenciaJuros"
        Me.txtMaximoCarenciaJuros.Size = New System.Drawing.Size(85, 21)
        Me.txtMaximoCarenciaJuros.TabIndex = 369
        '
        'txtJurosAoMes
        '
        Me.txtJurosAoMes.Location = New System.Drawing.Point(199, 158)
        Me.txtJurosAoMes.MaskInput = "{LOC}-n.nn"
        Me.txtJurosAoMes.Name = "txtJurosAoMes"
        Me.txtJurosAoMes.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtJurosAoMes.Size = New System.Drawing.Size(67, 21)
        Me.txtJurosAoMes.TabIndex = 367
        '
        'optCobraJuros
        '
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        Me.optCobraJuros.Appearance = Appearance1
        Me.optCobraJuros.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance2.TextHAlignAsString = "Center"
        Appearance2.TextVAlignAsString = "Middle"
        Me.optCobraJuros.ItemAppearance = Appearance2
        Me.optCobraJuros.ItemOrigin = New System.Drawing.Point(2, 2)
        ValueListItem1.DataValue = "NE"
        ValueListItem1.DisplayText = "Negociacao"
        ValueListItem2.DataValue = "CF"
        ValueListItem2.DisplayText = "Contrato Fixo"
        ValueListItem3.DataValue = "NR"
        ValueListItem3.DisplayText = "Negociacao/Recebimento"
        Me.optCobraJuros.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem3})
        Me.optCobraJuros.Location = New System.Drawing.Point(278, 147)
        Me.optCobraJuros.Name = "optCobraJuros"
        Me.optCobraJuros.Size = New System.Drawing.Size(252, 32)
        Me.optCobraJuros.TabIndex = 366
        '
        'txtEmailEstornoJuros
        '
        Me.txtEmailEstornoJuros.Location = New System.Drawing.Point(15, 274)
        Me.txtEmailEstornoJuros.MaxLength = 4000
        Me.txtEmailEstornoJuros.Multiline = True
        Me.txtEmailEstornoJuros.Name = "txtEmailEstornoJuros"
        Me.txtEmailEstornoJuros.Size = New System.Drawing.Size(515, 44)
        Me.txtEmailEstornoJuros.TabIndex = 364
        '
        'chkJurosAutomatico
        '
        Me.chkJurosAutomatico.Location = New System.Drawing.Point(15, 147)
        Me.chkJurosAutomatico.Name = "chkJurosAutomatico"
        Me.chkJurosAutomatico.Size = New System.Drawing.Size(87, 32)
        Me.chkJurosAutomatico.TabIndex = 362
        Me.chkJurosAutomatico.Text = "Juros Automativo"
        Me.chkJurosAutomatico.UseVisualStyleBackColor = True
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Controls.Add(Me.cboTipoPagamentoDescontoJuros)
        Me.UltraGroupBox3.Controls.Add(Me.cboTipoPagamentoJuros)
        Me.UltraGroupBox3.Controls.Add(Me.Label12)
        Me.UltraGroupBox3.Controls.Add(Me.Label13)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(15, 18)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(238, 110)
        Me.UltraGroupBox3.TabIndex = 361
        Me.UltraGroupBox3.Text = "Tipo Pagamento"
        '
        'cboTipoPagamentoDescontoJuros
        '
        Me.cboTipoPagamentoDescontoJuros.Location = New System.Drawing.Point(6, 83)
        Me.cboTipoPagamentoDescontoJuros.Name = "cboTipoPagamentoDescontoJuros"
        Me.cboTipoPagamentoDescontoJuros.Size = New System.Drawing.Size(218, 21)
        Me.cboTipoPagamentoDescontoJuros.TabIndex = 357
        '
        'cboTipoPagamentoJuros
        '
        Me.cboTipoPagamentoJuros.Location = New System.Drawing.Point(6, 38)
        Me.cboTipoPagamentoJuros.Name = "cboTipoPagamentoJuros"
        Me.cboTipoPagamentoJuros.Size = New System.Drawing.Size(218, 21)
        Me.cboTipoPagamentoJuros.TabIndex = 353
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(6, 67)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(81, 13)
        Me.Label12.TabIndex = 358
        Me.Label12.Text = "Desconto Juros"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(6, 22)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(32, 13)
        Me.Label13.TabIndex = 354
        Me.Label13.Text = "Juros"
        '
        'UltraGroupBox4
        '
        Me.UltraGroupBox4.Controls.Add(Me.cboModalidadeConciliacaoEstornoJuros)
        Me.UltraGroupBox4.Controls.Add(Me.cboModalidadeConciliacaoAcordoJuros)
        Me.UltraGroupBox4.Controls.Add(Me.Label14)
        Me.UltraGroupBox4.Controls.Add(Me.Label15)
        Me.UltraGroupBox4.Location = New System.Drawing.Point(292, 18)
        Me.UltraGroupBox4.Name = "UltraGroupBox4"
        Me.UltraGroupBox4.Size = New System.Drawing.Size(238, 110)
        Me.UltraGroupBox4.TabIndex = 360
        Me.UltraGroupBox4.Text = "Modalidade Conciliacao"
        '
        'cboModalidadeConciliacaoEstornoJuros
        '
        Me.cboModalidadeConciliacaoEstornoJuros.Location = New System.Drawing.Point(14, 83)
        Me.cboModalidadeConciliacaoEstornoJuros.Name = "cboModalidadeConciliacaoEstornoJuros"
        Me.cboModalidadeConciliacaoEstornoJuros.Size = New System.Drawing.Size(218, 21)
        Me.cboModalidadeConciliacaoEstornoJuros.TabIndex = 361
        '
        'cboModalidadeConciliacaoAcordoJuros
        '
        Me.cboModalidadeConciliacaoAcordoJuros.Location = New System.Drawing.Point(14, 38)
        Me.cboModalidadeConciliacaoAcordoJuros.Name = "cboModalidadeConciliacaoAcordoJuros"
        Me.cboModalidadeConciliacaoAcordoJuros.Size = New System.Drawing.Size(218, 21)
        Me.cboModalidadeConciliacaoAcordoJuros.TabIndex = 359
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(14, 67)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(77, 13)
        Me.Label14.TabIndex = 362
        Me.Label14.Text = "Estorno - Juros"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(14, 22)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(75, 13)
        Me.Label15.TabIndex = 360
        Me.Label15.Text = "Acordo - Juros"
        '
        'txtEmailAlteracaoJuros
        '
        Me.txtEmailAlteracaoJuros.Location = New System.Drawing.Point(15, 207)
        Me.txtEmailAlteracaoJuros.MaxLength = 4000
        Me.txtEmailAlteracaoJuros.Multiline = True
        Me.txtEmailAlteracaoJuros.Name = "txtEmailAlteracaoJuros"
        Me.txtEmailAlteracaoJuros.Size = New System.Drawing.Size(515, 44)
        Me.txtEmailAlteracaoJuros.TabIndex = 359
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(105, 142)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(88, 13)
        Me.Label19.TabIndex = 370
        Me.Label19.Text = "Maximo Carência"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Location = New System.Drawing.Point(196, 142)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(70, 13)
        Me.Label18.TabIndex = 368
        Me.Label18.Text = "Juros ao Mês"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(12, 258)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(301, 13)
        Me.Label17.TabIndex = 365
        Me.Label17.Text = "E-mail para informação sobre estorno de juros do contrato PAF"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(12, 191)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(310, 13)
        Me.Label16.TabIndex = 363
        Me.Label16.Text = "E-mail para informação sobre alteração no juros do contrato PAF"
        '
        'UltraTabControl1
        '
        Me.UltraTabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl2)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl3)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl4)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl5)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl6)
        Me.UltraTabControl1.Location = New System.Drawing.Point(8, 8)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl1.Size = New System.Drawing.Size(548, 447)
        Me.UltraTabControl1.TabIndex = 0
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "E-mail"
        UltraTab3.TabPage = Me.UltraTabPageControl3
        UltraTab3.Text = "Empresa"
        UltraTab2.TabPage = Me.UltraTabPageControl2
        UltraTab2.Text = "Padrões Tipo Movimentação"
        UltraTab6.TabPage = Me.UltraTabPageControl6
        UltraTab6.Text = "Outros Padrões"
        UltraTab4.TabPage = Me.UltraTabPageControl4
        UltraTab4.Text = "Qualidade"
        UltraTab5.TabPage = Me.UltraTabPageControl5
        UltraTab5.Text = "Juros"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab3, UltraTab2, UltraTab6, UltraTab4, UltraTab5})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(544, 421)
        '
        'cmdFechar
        '
        Me.cmdFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(511, 463)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 252
        Me.cmdFechar.Text = "F"
        '
        'cmdGravar
        '
        Me.cmdGravar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(8, 463)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 253
        Me.cmdGravar.TabStop = False
        Me.cmdGravar.Text = "G"
        '
        'frmParametroGeral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(564, 514)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.UltraTabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmParametroGeral"
        Me.Text = "Parâmetros Gerais"
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        Me.UltraTabPageControl3.ResumeLayout(False)
        Me.UltraTabPageControl3.PerformLayout()
        CType(Me.txtNivelAprovacaoPagamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox7.ResumeLayout(False)
        Me.UltraGroupBox7.PerformLayout()
        CType(Me.UltraGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox6.ResumeLayout(False)
        Me.UltraGroupBox6.PerformLayout()
        CType(Me.UltraGroupBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox5.ResumeLayout(False)
        Me.UltraGroupBox5.PerformLayout()
        CType(Me.txtAplicacaoContratoFixoMaximo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAplicacaoNegociacaoMaxima, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorMinimoNFComplementar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataSafra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataSistema, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSafra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmpresa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.UltraTabPageControl2.PerformLayout()
        Me.UltraTabPageControl6.ResumeLayout(False)
        Me.UltraTabPageControl6.PerformLayout()
        CType(Me.UltraGroupBox14, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox14.ResumeLayout(False)
        Me.UltraGroupBox14.PerformLayout()
        CType(Me.txtDiasMaximoFixacao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox13, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox13.ResumeLayout(False)
        Me.UltraGroupBox13.PerformLayout()
        CType(Me.UltraGroupBox12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox12.ResumeLayout(False)
        Me.UltraGroupBox12.PerformLayout()
        CType(Me.UltraGroupBox11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox11.ResumeLayout(False)
        Me.UltraGroupBox11.PerformLayout()
        CType(Me.UltraGroupBox10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox10.ResumeLayout(False)
        Me.UltraGroupBox10.PerformLayout()
        Me.UltraTabPageControl4.ResumeLayout(False)
        Me.UltraTabPageControl4.PerformLayout()
        CType(Me.txtDataVigencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        Me.UltraTabPageControl5.ResumeLayout(False)
        Me.UltraTabPageControl5.PerformLayout()
        CType(Me.txtMaximoCarenciaJuros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJurosAoMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optCobraJuros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox4.ResumeLayout(False)
        Me.UltraGroupBox4.PerformLayout()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl3 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl4 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl5 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents txtEmailContato As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtEmailInovacao As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEmailSeguraca As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEmailVencimentoForaPadrao As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtEmailQualidade As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkDesagioContrato As System.Windows.Forms.CheckBox
    Friend WithEvents chkDesagioNF As System.Windows.Forms.CheckBox
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboTipoPagamentoSujidade As System.Windows.Forms.ComboBox
    Friend WithEvents cboTipoPagamentoUmidade As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboModalidadeConciliacaoEstorno As System.Windows.Forms.ComboBox
    Friend WithEvents cboModalidadeConciliacaoAcordo As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDataVigencia As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboFilialMae As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtDiretorio As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents chkJurosAutomatico As System.Windows.Forms.CheckBox
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboTipoPagamentoDescontoJuros As System.Windows.Forms.ComboBox
    Friend WithEvents cboTipoPagamentoJuros As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents UltraGroupBox4 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboModalidadeConciliacaoEstornoJuros As System.Windows.Forms.ComboBox
    Friend WithEvents cboModalidadeConciliacaoAcordoJuros As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtEmailAlteracaoJuros As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtEmailEstornoJuros As System.Windows.Forms.TextBox
    Friend WithEvents optCobraJuros As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtMaximoCarenciaJuros As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtJurosAoMes As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents txtDataSafra As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtDataSistema As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtSafra As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtEmpresa As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtCia As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents cboModalidadeConciliacaoDevolucao As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents UltraGroupBox5 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtAplicacaoContratoFixoMaximo As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtAplicacaoNegociacaoMaxima As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtValorMinimoNFComplementar As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtContaContabilINSS As System.Windows.Forms.TextBox
    Friend WithEvents UltraGroupBox7 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox6 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtTipoDocumento As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtTipoPedido As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoCompra As System.Windows.Forms.TextBox
    Friend WithEvents chkHabilitaPagamentoJDE As System.Windows.Forms.CheckBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtTipoDocumentoJDE As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txtMoeda As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtEmailInterfaceJDE As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Pesq_ICMSTransferencia As Logus.Pesq_CodigoNome
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Pesq_ICMS As Logus.Pesq_CodigoNome
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Pesq_Funrural As Logus.Pesq_CodigoNome
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Pesq_RecebimentoCacau As Logus.Pesq_CodigoNome
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Pesq_DesagioSujidade As Logus.Pesq_CodigoNome
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Pesq_recebimentoCacauImportado As Logus.Pesq_CodigoNome
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Pesq_SaidaAordem As Logus.Pesq_CodigoNome
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Pesq_EntradaFixoRD As Logus.Pesq_CodigoNome
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Pesq_SaidaAordemImportado As Logus.Pesq_CodigoNome
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Pesq_EntradaFixoImportado As Logus.Pesq_CodigoNome
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Pesq_Desagio As Logus.Pesq_CodigoNome
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraTabPageControl6 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents cboTipoFreteRecebimentoCacau As System.Windows.Forms.ComboBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents cboTipoFreteTransferencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents cboTipoNegociacaoPadrao As System.Windows.Forms.ComboBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents cboTipoAprovacaoInterna As System.Windows.Forms.ComboBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents cboTipoCtrPAFNegociaMaster As System.Windows.Forms.ComboBox
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Pesq_ICMSImpotacao As Logus.Pesq_CodigoNome
    Friend WithEvents UltraGroupBox10 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents cboModalidadeConciliacaoICMS As System.Windows.Forms.ComboBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents cboTipoPagamentoGP As System.Windows.Forms.ComboBox
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents cboTipoPagamentoICMS As System.Windows.Forms.ComboBox
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents chkSacariaFornecedor As System.Windows.Forms.CheckBox
    Friend WithEvents chkCacauAordemMaster As System.Windows.Forms.CheckBox
    Friend WithEvents chkEnviaEmailCredito As System.Windows.Forms.CheckBox
    Friend WithEvents chkHabilitaBranche As System.Windows.Forms.CheckBox
    Friend WithEvents UltraGroupBox12 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents UltraGroupBox11 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents txtDiasMaximoFixacao As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents UltraGroupBox14 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox13 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents cboMoedaCredito As System.Windows.Forms.ComboBox
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Pesq_TP_MOV_EST_PROV_NF As Logus.Pesq_CodigoNome
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents Pesq_TP_MOV_PROV_NF As Logus.Pesq_CodigoNome
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents Pesq_TP_MOV_EST_REV_DIF As Logus.Pesq_CodigoNome
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents Pesq_TP_MOV_REV_DIF As Logus.Pesq_CodigoNome
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents Pesq_TP_MOV_EST_REV_AFIXAR As Logus.Pesq_CodigoNome
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Pesq_TP_MOV_REV_AFIXAR As Logus.Pesq_CodigoNome
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents txtNivelAprovacaoPagamento As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label65 As System.Windows.Forms.Label
End Class
