<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroReNegociacao_Solicitacao
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
        Me.lblNrContrato = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblData = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblSaldo = New System.Windows.Forms.Label
        Me.Pesq_Fornecedor = New Logus.Pesq_CodigoNome
        Me.Label9 = New System.Windows.Forms.Label
        Me.Pesq_Repassador = New Logus.Pesq_CodigoNome
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtQuantidadeNegociacao = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboUnidade = New System.Windows.Forms.ComboBox
        Me.txtDataPagamento = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtDataVencimento = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtDataPrazoFixacao = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboLocalEntrega = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboFilialEntrega = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cboTipoNegociacao = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblR_PrazoFixacao = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.cboBolsa = New System.Windows.Forms.ComboBox
        Me.lblR_Bolsa = New System.Windows.Forms.Label
        Me.txtValorUnitarioNegociacao = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label17 = New System.Windows.Forms.Label
        Me.cboTipoCacau = New System.Windows.Forms.ComboBox
        Me.txtAliquotaICMS = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtValorTotal = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.txtValorFrete = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label15 = New System.Windows.Forms.Label
        Me.cboTipoPessoa = New System.Windows.Forms.ComboBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.grpJuros = New Infragistics.Win.Misc.UltraGroupBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.chkCobraJuros = New System.Windows.Forms.CheckBox
        Me.txtTaxaJuros = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtDiasCarencia = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.chkJurosAposCarencia = New System.Windows.Forms.CheckBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtMotivoDataVencimentoAvancada = New System.Windows.Forms.TextBox
        Me.lblR_MotivoDataVencimentoAvancada = New System.Windows.Forms.Label
        Me.txtRazoesRenegociacao = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.txtSujidadePadrao = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtUmidadePadrao = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.cmdNovo = New Infragistics.Win.Misc.UltraButton
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        CType(Me.txtQuantidadeNegociacao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataPagamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataVencimento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataPrazoFixacao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorUnitarioNegociacao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAliquotaICMS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorFrete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpJuros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpJuros.SuspendLayout()
        CType(Me.txtTaxaJuros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDiasCarencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtSujidadePadrao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUmidadePadrao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblNrContrato
        '
        Me.lblNrContrato.BackColor = System.Drawing.Color.Black
        Me.lblNrContrato.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNrContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNrContrato.ForeColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lblNrContrato.Location = New System.Drawing.Point(8, 22)
        Me.lblNrContrato.Name = "lblNrContrato"
        Me.lblNrContrato.Size = New System.Drawing.Size(90, 23)
        Me.lblNrContrato.TabIndex = 304
        Me.lblNrContrato.Text = "NOVO"
        Me.lblNrContrato.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(8, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 305
        Me.Label3.Text = "Nº do Contrato"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(106, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 305
        Me.Label1.Text = "Data"
        '
        'lblData
        '
        Me.lblData.BackColor = System.Drawing.Color.White
        Me.lblData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblData.Location = New System.Drawing.Point(106, 22)
        Me.lblData.Name = "lblData"
        Me.lblData.Size = New System.Drawing.Size(80, 23)
        Me.lblData.TabIndex = 304
        Me.lblData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(194, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 305
        Me.Label4.Text = "Saldo"
        '
        'lblSaldo
        '
        Me.lblSaldo.BackColor = System.Drawing.Color.White
        Me.lblSaldo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblSaldo.Location = New System.Drawing.Point(194, 22)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(80, 23)
        Me.lblSaldo.TabIndex = 304
        Me.lblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Pesq_Fornecedor.Location = New System.Drawing.Point(8, 66)
        Me.Pesq_Fornecedor.MaximumSize = New System.Drawing.Size(1000, 23)
        Me.Pesq_Fornecedor.MinimumSize = New System.Drawing.Size(0, 23)
        Me.Pesq_Fornecedor.Name = "Pesq_Fornecedor"
        Me.Pesq_Fornecedor.Size = New System.Drawing.Size(330, 23)
        Me.Pesq_Fornecedor.TabIndex = 306
        Me.Pesq_Fornecedor.TelaFiltro = False
        Me.Pesq_Fornecedor.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(8, 53)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 13)
        Me.Label9.TabIndex = 307
        Me.Label9.Text = "Fornecedor"
        '
        'Pesq_Repassador
        '
        Me.Pesq_Repassador.BancoDados_Campo_Codigo = "CD_FORNECEDOR"
        Me.Pesq_Repassador.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Repassador.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_Repassador.BancoDados_Campo_Descricao = "NO_RAZAO_SOCIAL"
        Me.Pesq_Repassador.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_Repassador.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Repassador.BancoDados_Tabela = "FORNECEDOR F"
        Me.Pesq_Repassador.Codigo = 0
        Me.Pesq_Repassador.ExibirCodigo = True
        Me.Pesq_Repassador.Location = New System.Drawing.Point(346, 66)
        Me.Pesq_Repassador.MaximumSize = New System.Drawing.Size(1000, 23)
        Me.Pesq_Repassador.MinimumSize = New System.Drawing.Size(0, 23)
        Me.Pesq_Repassador.Name = "Pesq_Repassador"
        Me.Pesq_Repassador.Size = New System.Drawing.Size(340, 23)
        Me.Pesq_Repassador.TabIndex = 306
        Me.Pesq_Repassador.TelaFiltro = False
        Me.Pesq_Repassador.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(346, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 307
        Me.Label2.Text = "Repassador"
        '
        'txtQuantidadeNegociacao
        '
        Me.txtQuantidadeNegociacao.Location = New System.Drawing.Point(8, 111)
        Me.txtQuantidadeNegociacao.MaskInput = "{LOC}-nnnn,nnn"
        Me.txtQuantidadeNegociacao.Name = "txtQuantidadeNegociacao"
        Me.txtQuantidadeNegociacao.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtQuantidadeNegociacao.Size = New System.Drawing.Size(80, 21)
        Me.txtQuantidadeNegociacao.TabIndex = 308
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(8, 97)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 309
        Me.Label5.Text = "Quantidade"
        '
        'cboUnidade
        '
        Me.cboUnidade.FormattingEnabled = True
        Me.cboUnidade.Location = New System.Drawing.Point(96, 111)
        Me.cboUnidade.Name = "cboUnidade"
        Me.cboUnidade.Size = New System.Drawing.Size(60, 21)
        Me.cboUnidade.TabIndex = 310
        '
        'txtDataPagamento
        '
        Me.txtDataPagamento.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataPagamento.Location = New System.Drawing.Point(276, 111)
        Me.txtDataPagamento.Name = "txtDataPagamento"
        Me.txtDataPagamento.Size = New System.Drawing.Size(104, 23)
        Me.txtDataPagamento.TabIndex = 313
        Me.txtDataPagamento.Value = Nothing
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(276, 97)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 314
        Me.Label6.Text = "Data Pagamento"
        '
        'txtDataVencimento
        '
        Me.txtDataVencimento.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataVencimento.Location = New System.Drawing.Point(164, 111)
        Me.txtDataVencimento.Name = "txtDataVencimento"
        Me.txtDataVencimento.Size = New System.Drawing.Size(104, 23)
        Me.txtDataVencimento.TabIndex = 313
        Me.txtDataVencimento.Value = Nothing
        '
        'txtDataPrazoFixacao
        '
        Me.txtDataPrazoFixacao.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataPrazoFixacao.Location = New System.Drawing.Point(164, 154)
        Me.txtDataPrazoFixacao.Name = "txtDataPrazoFixacao"
        Me.txtDataPrazoFixacao.Size = New System.Drawing.Size(104, 23)
        Me.txtDataPrazoFixacao.TabIndex = 313
        Me.txtDataPrazoFixacao.Value = Nothing
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(96, 97)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 309
        Me.Label7.Text = "Unidade"
        '
        'cboLocalEntrega
        '
        Me.cboLocalEntrega.FormattingEnabled = True
        Me.cboLocalEntrega.Location = New System.Drawing.Point(388, 111)
        Me.cboLocalEntrega.Name = "cboLocalEntrega"
        Me.cboLocalEntrega.Size = New System.Drawing.Size(88, 21)
        Me.cboLocalEntrega.TabIndex = 310
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(388, 97)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 13)
        Me.Label8.TabIndex = 309
        Me.Label8.Text = "Local de Entrega"
        '
        'cboFilialEntrega
        '
        Me.cboFilialEntrega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilialEntrega.FormattingEnabled = True
        Me.cboFilialEntrega.Location = New System.Drawing.Point(482, 111)
        Me.cboFilialEntrega.Name = "cboFilialEntrega"
        Me.cboFilialEntrega.Size = New System.Drawing.Size(204, 21)
        Me.cboFilialEntrega.TabIndex = 310
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(482, 97)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 13)
        Me.Label10.TabIndex = 309
        Me.Label10.Text = "Filial de Entrega"
        '
        'cboTipoNegociacao
        '
        Me.cboTipoNegociacao.FormattingEnabled = True
        Me.cboTipoNegociacao.Location = New System.Drawing.Point(8, 154)
        Me.cboTipoNegociacao.Name = "cboTipoNegociacao"
        Me.cboTipoNegociacao.Size = New System.Drawing.Size(148, 21)
        Me.cboTipoNegociacao.TabIndex = 310
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(8, 140)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(104, 13)
        Me.Label11.TabIndex = 309
        Me.Label11.Text = "Tipo de Negociação"
        '
        'lblR_PrazoFixacao
        '
        Me.lblR_PrazoFixacao.AutoSize = True
        Me.lblR_PrazoFixacao.BackColor = System.Drawing.Color.Transparent
        Me.lblR_PrazoFixacao.Location = New System.Drawing.Point(164, 140)
        Me.lblR_PrazoFixacao.Name = "lblR_PrazoFixacao"
        Me.lblR_PrazoFixacao.Size = New System.Drawing.Size(74, 13)
        Me.lblR_PrazoFixacao.TabIndex = 314
        Me.lblR_PrazoFixacao.Text = "Prazo Fixação"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(164, 97)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(89, 13)
        Me.Label13.TabIndex = 314
        Me.Label13.Text = "Data Vencimento"
        '
        'cboBolsa
        '
        Me.cboBolsa.FormattingEnabled = True
        Me.cboBolsa.Location = New System.Drawing.Point(276, 154)
        Me.cboBolsa.Name = "cboBolsa"
        Me.cboBolsa.Size = New System.Drawing.Size(200, 21)
        Me.cboBolsa.TabIndex = 310
        '
        'lblR_Bolsa
        '
        Me.lblR_Bolsa.AutoSize = True
        Me.lblR_Bolsa.BackColor = System.Drawing.Color.Transparent
        Me.lblR_Bolsa.Location = New System.Drawing.Point(276, 140)
        Me.lblR_Bolsa.Name = "lblR_Bolsa"
        Me.lblR_Bolsa.Size = New System.Drawing.Size(33, 13)
        Me.lblR_Bolsa.TabIndex = 309
        Me.lblR_Bolsa.Text = "Bolsa"
        '
        'txtValorUnitarioNegociacao
        '
        Me.txtValorUnitarioNegociacao.Location = New System.Drawing.Point(8, 197)
        Me.txtValorUnitarioNegociacao.MaskInput = "{currency:-9.2}"
        Me.txtValorUnitarioNegociacao.Name = "txtValorUnitarioNegociacao"
        Me.txtValorUnitarioNegociacao.Size = New System.Drawing.Size(103, 21)
        Me.txtValorUnitarioNegociacao.TabIndex = 315
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(8, 183)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 13)
        Me.Label17.TabIndex = 316
        Me.Label17.Text = "Valor Unitário"
        '
        'cboTipoCacau
        '
        Me.cboTipoCacau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoCacau.Location = New System.Drawing.Point(439, 197)
        Me.cboTipoCacau.Name = "cboTipoCacau"
        Me.cboTipoCacau.Size = New System.Drawing.Size(138, 21)
        Me.cboTipoCacau.TabIndex = 334
        '
        'txtAliquotaICMS
        '
        Me.txtAliquotaICMS.Location = New System.Drawing.Point(119, 197)
        Me.txtAliquotaICMS.MaskInput = "{LOC}-n.nnnn"
        Me.txtAliquotaICMS.Name = "txtAliquotaICMS"
        Me.txtAliquotaICMS.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtAliquotaICMS.Size = New System.Drawing.Size(90, 21)
        Me.txtAliquotaICMS.TabIndex = 332
        '
        'txtValorTotal
        '
        Me.txtValorTotal.Location = New System.Drawing.Point(328, 197)
        Me.txtValorTotal.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtValorTotal.Name = "txtValorTotal"
        Me.txtValorTotal.ReadOnly = True
        Me.txtValorTotal.Size = New System.Drawing.Size(103, 21)
        Me.txtValorTotal.TabIndex = 338
        '
        'txtValorFrete
        '
        Me.txtValorFrete.Location = New System.Drawing.Point(217, 197)
        Me.txtValorFrete.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtValorFrete.Name = "txtValorFrete"
        Me.txtValorFrete.Size = New System.Drawing.Size(103, 21)
        Me.txtValorFrete.TabIndex = 333
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(585, 183)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(101, 13)
        Me.Label15.TabIndex = 340
        Me.Label15.Text = "Tipo Pessoa - Bolsa"
        '
        'cboTipoPessoa
        '
        Me.cboTipoPessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoPessoa.Location = New System.Drawing.Point(585, 197)
        Me.cboTipoPessoa.Name = "cboTipoPessoa"
        Me.cboTipoPessoa.Size = New System.Drawing.Size(100, 21)
        Me.cboTipoPessoa.TabIndex = 335
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Location = New System.Drawing.Point(439, 183)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(62, 13)
        Me.Label23.TabIndex = 341
        Me.Label23.Text = "Tipo Cacau"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(119, 183)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(82, 13)
        Me.Label16.TabIndex = 339
        Me.Label16.Text = "Aliquota ICMS%"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Location = New System.Drawing.Point(328, 183)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(58, 13)
        Me.Label20.TabIndex = 337
        Me.Label20.Text = "Valor Total"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(217, 183)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(77, 13)
        Me.Label19.TabIndex = 336
        Me.Label19.Text = "Frete por Saca"
        '
        'grpJuros
        '
        Me.grpJuros.Controls.Add(Me.Label18)
        Me.grpJuros.Controls.Add(Me.chkCobraJuros)
        Me.grpJuros.Controls.Add(Me.txtTaxaJuros)
        Me.grpJuros.Controls.Add(Me.txtDiasCarencia)
        Me.grpJuros.Controls.Add(Me.chkJurosAposCarencia)
        Me.grpJuros.Controls.Add(Me.Label21)
        Me.grpJuros.Location = New System.Drawing.Point(8, 226)
        Me.grpJuros.Name = "grpJuros"
        Me.grpJuros.Size = New System.Drawing.Size(357, 61)
        Me.grpJuros.TabIndex = 342
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
        Me.chkCobraJuros.Location = New System.Drawing.Point(6, 34)
        Me.chkCobraJuros.Name = "chkCobraJuros"
        Me.chkCobraJuros.Size = New System.Drawing.Size(88, 17)
        Me.chkCobraJuros.TabIndex = 14
        Me.chkCobraJuros.Text = "Cobra Juros?"
        Me.chkCobraJuros.UseVisualStyleBackColor = True
        '
        'txtTaxaJuros
        '
        Me.txtTaxaJuros.Location = New System.Drawing.Point(314, 30)
        Me.txtTaxaJuros.MaskInput = "{LOC}-n.nn"
        Me.txtTaxaJuros.Name = "txtTaxaJuros"
        Me.txtTaxaJuros.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtTaxaJuros.Size = New System.Drawing.Size(32, 21)
        Me.txtTaxaJuros.TabIndex = 17
        '
        'txtDiasCarencia
        '
        Me.txtDiasCarencia.Location = New System.Drawing.Point(100, 30)
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
        Me.chkJurosAposCarencia.Location = New System.Drawing.Point(179, 34)
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
        'txtMotivoDataVencimentoAvancada
        '
        Me.txtMotivoDataVencimentoAvancada.Location = New System.Drawing.Point(8, 309)
        Me.txtMotivoDataVencimentoAvancada.Multiline = True
        Me.txtMotivoDataVencimentoAvancada.Name = "txtMotivoDataVencimentoAvancada"
        Me.txtMotivoDataVencimentoAvancada.Size = New System.Drawing.Size(677, 56)
        Me.txtMotivoDataVencimentoAvancada.TabIndex = 343
        '
        'lblR_MotivoDataVencimentoAvancada
        '
        Me.lblR_MotivoDataVencimentoAvancada.AutoSize = True
        Me.lblR_MotivoDataVencimentoAvancada.BackColor = System.Drawing.Color.Transparent
        Me.lblR_MotivoDataVencimentoAvancada.Location = New System.Drawing.Point(8, 295)
        Me.lblR_MotivoDataVencimentoAvancada.Name = "lblR_MotivoDataVencimentoAvancada"
        Me.lblR_MotivoDataVencimentoAvancada.Size = New System.Drawing.Size(223, 13)
        Me.lblR_MotivoDataVencimentoAvancada.TabIndex = 340
        Me.lblR_MotivoDataVencimentoAvancada.Text = "Motivo para a data de vencimento avançada:"
        '
        'txtRazoesRenegociacao
        '
        Me.txtRazoesRenegociacao.Location = New System.Drawing.Point(8, 387)
        Me.txtRazoesRenegociacao.Multiline = True
        Me.txtRazoesRenegociacao.Name = "txtRazoesRenegociacao"
        Me.txtRazoesRenegociacao.Size = New System.Drawing.Size(677, 56)
        Me.txtRazoesRenegociacao.TabIndex = 343
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Location = New System.Drawing.Point(8, 373)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(134, 13)
        Me.Label24.TabIndex = 340
        Me.Label24.Text = "Razões de Renegociação:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.txtSujidadePadrao)
        Me.GroupBox1.Controls.Add(Me.txtUmidadePadrao)
        Me.GroupBox1.Location = New System.Drawing.Point(373, 226)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(118, 61)
        Me.GroupBox1.TabIndex = 346
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Qulidade Padrão"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Location = New System.Drawing.Point(61, 16)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(48, 13)
        Me.Label26.TabIndex = 348
        Me.Label26.Text = "Sujidade"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Location = New System.Drawing.Point(8, 16)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(49, 13)
        Me.Label25.TabIndex = 349
        Me.Label25.Text = "Umidade"
        '
        'txtSujidadePadrao
        '
        Me.txtSujidadePadrao.Location = New System.Drawing.Point(61, 30)
        Me.txtSujidadePadrao.MaskInput = "{LOC}-n.nn"
        Me.txtSujidadePadrao.Name = "txtSujidadePadrao"
        Me.txtSujidadePadrao.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtSujidadePadrao.Size = New System.Drawing.Size(45, 21)
        Me.txtSujidadePadrao.TabIndex = 346
        '
        'txtUmidadePadrao
        '
        Me.txtUmidadePadrao.Location = New System.Drawing.Point(8, 30)
        Me.txtUmidadePadrao.MaskInput = "{LOC}-n.nn"
        Me.txtUmidadePadrao.Name = "txtUmidadePadrao"
        Me.txtUmidadePadrao.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtUmidadePadrao.Size = New System.Drawing.Size(45, 21)
        Me.txtUmidadePadrao.TabIndex = 347
        '
        'cmdNovo
        '
        Me.cmdNovo.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdNovo.Location = New System.Drawing.Point(61, 451)
        Me.cmdNovo.Name = "cmdNovo"
        Me.cmdNovo.Size = New System.Drawing.Size(45, 45)
        Me.cmdNovo.TabIndex = 348
        Me.cmdNovo.Text = "N"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(640, 451)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 349
        Me.cmdFechar.Text = "F"
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(8, 451)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 347
        Me.cmdGravar.TabStop = False
        Me.cmdGravar.Text = "G"
        '
        'frmCadastroReNegociacao_Solicitacao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(697, 504)
        Me.Controls.Add(Me.cmdNovo)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtRazoesRenegociacao)
        Me.Controls.Add(Me.txtMotivoDataVencimentoAvancada)
        Me.Controls.Add(Me.grpJuros)
        Me.Controls.Add(Me.cboTipoCacau)
        Me.Controls.Add(Me.txtAliquotaICMS)
        Me.Controls.Add(Me.txtValorTotal)
        Me.Controls.Add(Me.txtValorFrete)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.lblR_MotivoDataVencimentoAvancada)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cboTipoPessoa)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtValorUnitarioNegociacao)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtDataPrazoFixacao)
        Me.Controls.Add(Me.txtDataVencimento)
        Me.Controls.Add(Me.txtDataPagamento)
        Me.Controls.Add(Me.lblR_PrazoFixacao)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cboBolsa)
        Me.Controls.Add(Me.cboTipoNegociacao)
        Me.Controls.Add(Me.cboFilialEntrega)
        Me.Controls.Add(Me.cboLocalEntrega)
        Me.Controls.Add(Me.cboUnidade)
        Me.Controls.Add(Me.txtQuantidadeNegociacao)
        Me.Controls.Add(Me.lblR_Bolsa)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Pesq_Repassador)
        Me.Controls.Add(Me.Pesq_Fornecedor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblSaldo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblData)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblNrContrato)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmCadastroReNegociacao_Solicitacao"
        Me.Text = "Solicitação de Renegociação"
        CType(Me.txtQuantidadeNegociacao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataPagamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataVencimento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataPrazoFixacao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorUnitarioNegociacao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAliquotaICMS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorFrete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpJuros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpJuros.ResumeLayout(False)
        Me.grpJuros.PerformLayout()
        CType(Me.txtTaxaJuros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDiasCarencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtSujidadePadrao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUmidadePadrao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNrContrato As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblData As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblSaldo As System.Windows.Forms.Label
    Friend WithEvents Pesq_Fornecedor As Logus.Pesq_CodigoNome
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Pesq_Repassador As Logus.Pesq_CodigoNome
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtQuantidadeNegociacao As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboUnidade As System.Windows.Forms.ComboBox
    Friend WithEvents txtDataPagamento As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDataVencimento As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtDataPrazoFixacao As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboLocalEntrega As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboFilialEntrega As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboTipoNegociacao As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblR_PrazoFixacao As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboBolsa As System.Windows.Forms.ComboBox
    Friend WithEvents lblR_Bolsa As System.Windows.Forms.Label
    Friend WithEvents txtValorUnitarioNegociacao As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboTipoCacau As System.Windows.Forms.ComboBox
    Friend WithEvents txtAliquotaICMS As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents txtValorTotal As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents txtValorFrete As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboTipoPessoa As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents grpJuros As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents chkCobraJuros As System.Windows.Forms.CheckBox
    Friend WithEvents txtTaxaJuros As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents txtDiasCarencia As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents chkJurosAposCarencia As System.Windows.Forms.CheckBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtMotivoDataVencimentoAvancada As System.Windows.Forms.TextBox
    Friend WithEvents lblR_MotivoDataVencimentoAvancada As System.Windows.Forms.Label
    Friend WithEvents txtRazoesRenegociacao As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtSujidadePadrao As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents txtUmidadePadrao As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents cmdNovo As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
End Class
