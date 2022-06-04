<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroContratoFixo
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
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadastroContratoFixo))
        Me.cmdNovo = New Infragistics.Win.Misc.UltraButton
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.cboNegociacao = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtDataVencimento = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtDataContratoFixo = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblContratoFixo = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtQuantidadeContratoFixo = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtSaldo = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtDataPagamento = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.lblTipoNegociacao = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtValorUnitarioNegocicao = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtQuantidadeNegociacao = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtDataNegociacao = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label12 = New System.Windows.Forms.Label
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtAliquotaICMS = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtValorTotal = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.txtValorINSS = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.txtValorICMS = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.txtValorUnitarioContratoFixo = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.chkDolar = New System.Windows.Forms.CheckBox
        Me.grpDados = New Infragistics.Win.Misc.UltraGroupBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.cboBolsa = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.cmdAtualizar = New Infragistics.Win.Misc.UltraButton
        Me.cboTipoPessoa = New System.Windows.Forms.ComboBox
        Me.txtBolsa = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.txtTaxaDolar = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Pesq_ContratoPAF = New Logus.Pesq_CodigoNome
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmdImprimir = New Infragistics.Win.Misc.UltraButton
        CType(Me.txtDataVencimento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataContratoFixo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantidadeContratoFixo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataPagamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.txtValorUnitarioNegocicao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantidadeNegociacao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataNegociacao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.txtAliquotaICMS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorINSS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorICMS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorUnitarioContratoFixo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpDados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDados.SuspendLayout()
        CType(Me.cboBolsa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBolsa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTaxaDolar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdNovo
        '
        Me.cmdNovo.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdNovo.Location = New System.Drawing.Point(62, 320)
        Me.cmdNovo.Name = "cmdNovo"
        Me.cmdNovo.Size = New System.Drawing.Size(45, 45)
        Me.cmdNovo.TabIndex = 10
        Me.cmdNovo.Text = "N"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(546, 320)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 11
        Me.cmdFechar.Text = "F"
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(9, 320)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 9
        Me.cmdGravar.TabStop = False
        Me.cmdGravar.Text = "G"
        '
        'cboNegociacao
        '
        Me.cboNegociacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNegociacao.Location = New System.Drawing.Point(296, 23)
        Me.cboNegociacao.Name = "cboNegociacao"
        Me.cboNegociacao.Size = New System.Drawing.Size(82, 21)
        Me.cboNegociacao.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(296, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 13)
        Me.Label8.TabIndex = 297
        Me.Label8.Text = "Negociação"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(11, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 298
        Me.Label9.Text = "Contrato PAF"
        '
        'txtDataVencimento
        '
        Me.txtDataVencimento.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataVencimento.Location = New System.Drawing.Point(383, 155)
        Me.txtDataVencimento.Name = "txtDataVencimento"
        Me.txtDataVencimento.Size = New System.Drawing.Size(86, 23)
        Me.txtDataVencimento.TabIndex = 6
        Me.txtDataVencimento.Value = Nothing
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(380, 139)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 295
        Me.Label1.Text = "Data Vencimento"
        '
        'txtDataContratoFixo
        '
        Me.txtDataContratoFixo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataContratoFixo.Location = New System.Drawing.Point(483, 23)
        Me.txtDataContratoFixo.Name = "txtDataContratoFixo"
        Me.txtDataContratoFixo.ReadOnly = True
        Me.txtDataContratoFixo.Size = New System.Drawing.Size(90, 23)
        Me.txtDataContratoFixo.TabIndex = 300
        Me.txtDataContratoFixo.Value = Nothing
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(483, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 301
        Me.Label5.Text = "Data"
        '
        'lblContratoFixo
        '
        Me.lblContratoFixo.BackColor = System.Drawing.Color.Black
        Me.lblContratoFixo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblContratoFixo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContratoFixo.ForeColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lblContratoFixo.Location = New System.Drawing.Point(11, 84)
        Me.lblContratoFixo.Name = "lblContratoFixo"
        Me.lblContratoFixo.Size = New System.Drawing.Size(52, 23)
        Me.lblContratoFixo.TabIndex = 302
        Me.lblContratoFixo.Text = "NOVO"
        Me.lblContratoFixo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(5, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 305
        Me.Label4.Text = "Quantidade"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(8, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 303
        Me.Label3.Text = "Número"
        '
        'txtQuantidadeContratoFixo
        '
        Me.txtQuantidadeContratoFixo.Location = New System.Drawing.Point(8, 156)
        Me.txtQuantidadeContratoFixo.MaskInput = "{LOC}-nnnn,nnn"
        Me.txtQuantidadeContratoFixo.Name = "txtQuantidadeContratoFixo"
        Me.txtQuantidadeContratoFixo.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtQuantidadeContratoFixo.Size = New System.Drawing.Size(90, 21)
        Me.txtQuantidadeContratoFixo.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(386, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 310
        Me.Label2.Text = "Saldo"
        '
        'txtSaldo
        '
        Me.txtSaldo.Location = New System.Drawing.Point(386, 23)
        Me.txtSaldo.MaskInput = "{double:8.0}"
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtSaldo.ReadOnly = True
        Me.txtSaldo.Size = New System.Drawing.Size(89, 21)
        Me.txtSaldo.TabIndex = 309
        '
        'txtDataPagamento
        '
        Me.txtDataPagamento.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataPagamento.Location = New System.Drawing.Point(477, 155)
        Me.txtDataPagamento.Name = "txtDataPagamento"
        Me.txtDataPagamento.Size = New System.Drawing.Size(87, 23)
        Me.txtDataPagamento.TabIndex = 7
        Me.txtDataPagamento.Value = Nothing
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(477, 139)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 312
        Me.Label6.Text = "Data Pagamento"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(103, 140)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 13)
        Me.Label10.TabIndex = 314
        Me.Label10.Text = "Bolsa"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(310, 139)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 13)
        Me.Label11.TabIndex = 316
        Me.Label11.Text = "Taxa Dolar"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.lblTipoNegociacao)
        Me.UltraGroupBox1.Controls.Add(Me.Label16)
        Me.UltraGroupBox1.Controls.Add(Me.Label14)
        Me.UltraGroupBox1.Controls.Add(Me.txtValorUnitarioNegocicao)
        Me.UltraGroupBox1.Controls.Add(Me.Label13)
        Me.UltraGroupBox1.Controls.Add(Me.txtQuantidadeNegociacao)
        Me.UltraGroupBox1.Controls.Add(Me.txtDataNegociacao)
        Me.UltraGroupBox1.Controls.Add(Me.Label12)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(69, 64)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(503, 73)
        Me.UltraGroupBox1.TabIndex = 317
        Me.UltraGroupBox1.Text = "Dados da Negociação"
        '
        'lblTipoNegociacao
        '
        Me.lblTipoNegociacao.BackColor = System.Drawing.Color.Black
        Me.lblTipoNegociacao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTipoNegociacao.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoNegociacao.ForeColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lblTipoNegociacao.Location = New System.Drawing.Point(314, 36)
        Me.lblTipoNegociacao.Name = "lblTipoNegociacao"
        Me.lblTipoNegociacao.Size = New System.Drawing.Size(181, 23)
        Me.lblTipoNegociacao.TabIndex = 310
        Me.lblTipoNegociacao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(314, 21)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(89, 13)
        Me.Label16.TabIndex = 311
        Me.Label16.Text = "Tipo Negociação"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(105, 21)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(70, 13)
        Me.Label14.TabIndex = 308
        Me.Label14.Text = "Valor Unitario"
        '
        'txtValorUnitarioNegocicao
        '
        Me.txtValorUnitarioNegocicao.Location = New System.Drawing.Point(105, 36)
        Me.txtValorUnitarioNegocicao.Name = "txtValorUnitarioNegocicao"
        Me.txtValorUnitarioNegocicao.ReadOnly = True
        Me.txtValorUnitarioNegocicao.Size = New System.Drawing.Size(103, 21)
        Me.txtValorUnitarioNegocicao.TabIndex = 309
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(5, 21)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 13)
        Me.Label13.TabIndex = 307
        Me.Label13.Text = "Quantidade"
        '
        'txtQuantidadeNegociacao
        '
        Me.txtQuantidadeNegociacao.Location = New System.Drawing.Point(8, 36)
        Me.txtQuantidadeNegociacao.MaskInput = "{double:8.2}"
        Me.txtQuantidadeNegociacao.Name = "txtQuantidadeNegociacao"
        Me.txtQuantidadeNegociacao.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtQuantidadeNegociacao.ReadOnly = True
        Me.txtQuantidadeNegociacao.Size = New System.Drawing.Size(89, 21)
        Me.txtQuantidadeNegociacao.TabIndex = 306
        '
        'txtDataNegociacao
        '
        Me.txtDataNegociacao.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataNegociacao.Location = New System.Drawing.Point(216, 36)
        Me.txtDataNegociacao.Name = "txtDataNegociacao"
        Me.txtDataNegociacao.ReadOnly = True
        Me.txtDataNegociacao.Size = New System.Drawing.Size(90, 23)
        Me.txtDataNegociacao.TabIndex = 302
        Me.txtDataNegociacao.Value = Nothing
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(216, 21)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 13)
        Me.Label12.TabIndex = 303
        Me.Label12.Text = "Data"
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.txtAliquotaICMS)
        Me.UltraGroupBox2.Controls.Add(Me.txtValorTotal)
        Me.UltraGroupBox2.Controls.Add(Me.txtValorINSS)
        Me.UltraGroupBox2.Controls.Add(Me.txtValorICMS)
        Me.UltraGroupBox2.Controls.Add(Me.txtValorUnitarioContratoFixo)
        Me.UltraGroupBox2.Controls.Add(Me.Label7)
        Me.UltraGroupBox2.Controls.Add(Me.Label20)
        Me.UltraGroupBox2.Controls.Add(Me.Label19)
        Me.UltraGroupBox2.Controls.Add(Me.Label18)
        Me.UltraGroupBox2.Controls.Add(Me.Label17)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(8, 186)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(562, 63)
        Me.UltraGroupBox2.TabIndex = 318
        Me.UltraGroupBox2.Text = "Valores do Contrato"
        '
        'txtAliquotaICMS
        '
        Me.txtAliquotaICMS.Location = New System.Drawing.Point(115, 35)
        Me.txtAliquotaICMS.MaskInput = "{LOC}-n.nnnn"
        Me.txtAliquotaICMS.Name = "txtAliquotaICMS"
        Me.txtAliquotaICMS.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtAliquotaICMS.ReadOnly = True
        Me.txtAliquotaICMS.Size = New System.Drawing.Size(109, 21)
        Me.txtAliquotaICMS.TabIndex = 317
        '
        'txtValorTotal
        '
        Me.txtValorTotal.Location = New System.Drawing.Point(230, 35)
        Me.txtValorTotal.Name = "txtValorTotal"
        Me.txtValorTotal.ReadOnly = True
        Me.txtValorTotal.Size = New System.Drawing.Size(103, 21)
        Me.txtValorTotal.TabIndex = 307
        '
        'txtValorINSS
        '
        Me.txtValorINSS.Location = New System.Drawing.Point(448, 35)
        Me.txtValorINSS.Name = "txtValorINSS"
        Me.txtValorINSS.ReadOnly = True
        Me.txtValorINSS.Size = New System.Drawing.Size(103, 21)
        Me.txtValorINSS.TabIndex = 305
        '
        'txtValorICMS
        '
        Me.txtValorICMS.Location = New System.Drawing.Point(339, 35)
        Me.txtValorICMS.Name = "txtValorICMS"
        Me.txtValorICMS.ReadOnly = True
        Me.txtValorICMS.Size = New System.Drawing.Size(103, 21)
        Me.txtValorICMS.TabIndex = 303
        '
        'txtValorUnitarioContratoFixo
        '
        Me.txtValorUnitarioContratoFixo.Location = New System.Drawing.Point(6, 35)
        Me.txtValorUnitarioContratoFixo.Name = "txtValorUnitarioContratoFixo"
        Me.txtValorUnitarioContratoFixo.ReadOnly = True
        Me.txtValorUnitarioContratoFixo.Size = New System.Drawing.Size(103, 21)
        Me.txtValorUnitarioContratoFixo.TabIndex = 301
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(112, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 13)
        Me.Label7.TabIndex = 318
        Me.Label7.Text = "Aliquota ICMS%"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Location = New System.Drawing.Point(227, 19)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(58, 13)
        Me.Label20.TabIndex = 306
        Me.Label20.Text = "Valor Total"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(445, 19)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(59, 13)
        Me.Label19.TabIndex = 304
        Me.Label19.Text = "Valor INSS"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Location = New System.Drawing.Point(336, 19)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(60, 13)
        Me.Label18.TabIndex = 302
        Me.Label18.Text = "Valor ICMS"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(8, 19)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 13)
        Me.Label17.TabIndex = 300
        Me.Label17.Text = "Valor Unitário"
        '
        'chkDolar
        '
        Me.chkDolar.AutoSize = True
        Me.chkDolar.Location = New System.Drawing.Point(292, 160)
        Me.chkDolar.Name = "chkDolar"
        Me.chkDolar.Size = New System.Drawing.Size(15, 14)
        Me.chkDolar.TabIndex = 3
        Me.chkDolar.UseVisualStyleBackColor = True
        '
        'grpDados
        '
        Me.grpDados.Controls.Add(Me.Label21)
        Me.grpDados.Controls.Add(Me.cboBolsa)
        Me.grpDados.Controls.Add(Me.cmdAtualizar)
        Me.grpDados.Controls.Add(Me.cboTipoPessoa)
        Me.grpDados.Controls.Add(Me.lblContratoFixo)
        Me.grpDados.Controls.Add(Me.txtBolsa)
        Me.grpDados.Controls.Add(Me.txtTaxaDolar)
        Me.grpDados.Controls.Add(Me.txtQuantidadeContratoFixo)
        Me.grpDados.Controls.Add(Me.txtDataPagamento)
        Me.grpDados.Controls.Add(Me.txtDataVencimento)
        Me.grpDados.Controls.Add(Me.UltraGroupBox2)
        Me.grpDados.Controls.Add(Me.chkDolar)
        Me.grpDados.Controls.Add(Me.UltraGroupBox1)
        Me.grpDados.Controls.Add(Me.txtDataContratoFixo)
        Me.grpDados.Controls.Add(Me.txtSaldo)
        Me.grpDados.Controls.Add(Me.cboNegociacao)
        Me.grpDados.Controls.Add(Me.Pesq_ContratoPAF)
        Me.grpDados.Controls.Add(Me.Label5)
        Me.grpDados.Controls.Add(Me.Label9)
        Me.grpDados.Controls.Add(Me.Label2)
        Me.grpDados.Controls.Add(Me.Label8)
        Me.grpDados.Controls.Add(Me.Label4)
        Me.grpDados.Controls.Add(Me.Label11)
        Me.grpDados.Controls.Add(Me.Label10)
        Me.grpDados.Controls.Add(Me.Label1)
        Me.grpDados.Controls.Add(Me.Label6)
        Me.grpDados.Controls.Add(Me.Label3)
        Me.grpDados.Controls.Add(Me.Label15)
        Me.grpDados.Location = New System.Drawing.Point(9, 12)
        Me.grpDados.Name = "grpDados"
        Me.grpDados.Size = New System.Drawing.Size(582, 302)
        Me.grpDados.TabIndex = 320
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Location = New System.Drawing.Point(171, 140)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(60, 13)
        Me.Label21.TabIndex = 388
        Me.Label21.Text = "Valor Bolsa"
        '
        'cboBolsa
        '
        Me.cboBolsa.CheckedListSettings.CheckStateMember = ""
        Me.cboBolsa.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cboBolsa.Location = New System.Drawing.Point(104, 156)
        Me.cboBolsa.Name = "cboBolsa"
        Me.cboBolsa.PreferredDropDownSize = New System.Drawing.Size(0, 0)
        Me.cboBolsa.Size = New System.Drawing.Size(62, 22)
        Me.cboBolsa.TabIndex = 322
        '
        'cmdAtualizar
        '
        Appearance30.Image = 19
        Me.cmdAtualizar.Appearance = Appearance30
        Me.cmdAtualizar.ImageSize = New System.Drawing.Size(20, 20)
        Me.cmdAtualizar.Location = New System.Drawing.Point(258, 152)
        Me.cmdAtualizar.Name = "cmdAtualizar"
        Me.cmdAtualizar.Size = New System.Drawing.Size(28, 28)
        Me.cmdAtualizar.TabIndex = 387
        Me.cmdAtualizar.TabStop = False
        '
        'cboTipoPessoa
        '
        Me.cboTipoPessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoPessoa.Location = New System.Drawing.Point(14, 275)
        Me.cboTipoPessoa.Name = "cboTipoPessoa"
        Me.cboTipoPessoa.Size = New System.Drawing.Size(194, 21)
        Me.cboTipoPessoa.TabIndex = 8
        '
        'txtBolsa
        '
        Me.txtBolsa.Location = New System.Drawing.Point(169, 157)
        Me.txtBolsa.MaskInput = "{currency:7.2}"
        Me.txtBolsa.Name = "txtBolsa"
        Me.txtBolsa.Size = New System.Drawing.Size(84, 21)
        Me.txtBolsa.TabIndex = 385
        '
        'txtTaxaDolar
        '
        Me.txtTaxaDolar.Location = New System.Drawing.Point(309, 156)
        Me.txtTaxaDolar.MaskInput = "{LOC}$ nnn.nnnn"
        Me.txtTaxaDolar.Name = "txtTaxaDolar"
        Me.txtTaxaDolar.Size = New System.Drawing.Size(69, 21)
        Me.txtTaxaDolar.TabIndex = 386
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
        Me.Pesq_ContratoPAF.Location = New System.Drawing.Point(11, 21)
        Me.Pesq_ContratoPAF.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_ContratoPAF.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_ContratoPAF.Name = "Pesq_ContratoPAF"
        Me.Pesq_ContratoPAF.Size = New System.Drawing.Size(277, 28)
        Me.Pesq_ContratoPAF.TabIndex = 0
        Me.Pesq_ContratoPAF.TelaFiltro = False
        Me.Pesq_ContratoPAF.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(11, 259)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(101, 13)
        Me.Label15.TabIndex = 322
        Me.Label15.Text = "Tipo Pessoa - Bolsa"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdImprimir.Location = New System.Drawing.Point(115, 320)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(45, 45)
        Me.cmdImprimir.TabIndex = 321
        Me.cmdImprimir.Text = "I"
        '
        'frmCadastroContratoFixo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 369)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.grpDados)
        Me.Controls.Add(Me.cmdNovo)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdGravar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCadastroContratoFixo"
        Me.Text = "Contrato Fixo"
        CType(Me.txtDataVencimento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataContratoFixo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantidadeContratoFixo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSaldo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataPagamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.txtValorUnitarioNegocicao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantidadeNegociacao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataNegociacao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.txtAliquotaICMS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorINSS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorICMS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorUnitarioContratoFixo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpDados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDados.ResumeLayout(False)
        Me.grpDados.PerformLayout()
        CType(Me.cboBolsa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBolsa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTaxaDolar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdNovo As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Pesq_ContratoPAF As Logus.Pesq_CodigoNome
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cboNegociacao As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDataVencimento As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDataContratoFixo As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblContratoFixo As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtQuantidadeContratoFixo As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSaldo As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents txtDataPagamento As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtValorUnitarioNegocicao As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtQuantidadeNegociacao As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents txtDataNegociacao As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblTipoNegociacao As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtValorTotal As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtValorINSS As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtValorICMS As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtValorUnitarioContratoFixo As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtAliquotaICMS As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents chkDolar As System.Windows.Forms.CheckBox
    Friend WithEvents grpDados As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboTipoPessoa As System.Windows.Forms.ComboBox
    Friend WithEvents cmdImprimir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtBolsa As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents txtTaxaDolar As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents cmdAtualizar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cboBolsa As Infragistics.Win.UltraWinGrid.UltraCombo
End Class
