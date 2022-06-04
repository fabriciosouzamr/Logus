<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroContratoPAF
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadastroContratoPAF))
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtDataEntrega = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtValorAdiantamento = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboTipoContrato = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtDataContrato = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.lblContrato = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtQuantidade = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboFilial = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.chkCobraJuros = New System.Windows.Forms.CheckBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtDataFixacao = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtDiasCarencia = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Label19 = New System.Windows.Forms.Label
        Me.chkJurosAposCarencia = New System.Windows.Forms.CheckBox
        Me.txtTaxaJuros = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.grpJuros = New Infragistics.Win.Misc.UltraGroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboContratoPAF = New System.Windows.Forms.ComboBox
        Me.grpDados = New Infragistics.Win.Misc.UltraGroupBox
        Me.Pesq_Fornecedor = New Logus.Pesq_CodigoNome
        Me.Pesq_Municipio = New Logus.Pesq_CodigoNome
        Me.cmdNovo = New Infragistics.Win.Misc.UltraButton
        Me.cmdImprimir = New Infragistics.Win.Misc.UltraButton
        CType(Me.txtDataEntrega, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorAdiantamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataContrato, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantidade, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataFixacao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDiasCarencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTaxaJuros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpJuros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpJuros.SuspendLayout()
        CType(Me.grpDados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDados.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(97, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 16)
        Me.Label1.TabIndex = 263
        Me.Label1.Text = "Data Entrega"
        '
        'txtDataEntrega
        '
        Me.txtDataEntrega.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtDataEntrega.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataEntrega.Location = New System.Drawing.Point(101, 87)
        Me.txtDataEntrega.Name = "txtDataEntrega"
        Me.txtDataEntrega.Size = New System.Drawing.Size(96, 23)
        Me.txtDataEntrega.TabIndex = 3
        Me.txtDataEntrega.Value = Nothing
        '
        'txtValorAdiantamento
        '
        Me.txtValorAdiantamento.Location = New System.Drawing.Point(369, 89)
        Me.txtValorAdiantamento.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtValorAdiantamento.Name = "txtValorAdiantamento"
        Me.txtValorAdiantamento.Size = New System.Drawing.Size(103, 21)
        Me.txtValorAdiantamento.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(224, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(153, 16)
        Me.Label9.TabIndex = 266
        Me.Label9.Text = "Fornecedor"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(203, 69)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 16)
        Me.Label8.TabIndex = 265
        Me.Label8.Text = "Tipo Contrato"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(371, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 13)
        Me.Label7.TabIndex = 264
        Me.Label7.Text = "Valor Adiantamento"
        '
        'cboTipoContrato
        '
        Me.cboTipoContrato.Location = New System.Drawing.Point(203, 87)
        Me.cboTipoContrato.Name = "cboTipoContrato"
        Me.cboTipoContrato.Size = New System.Drawing.Size(160, 21)
        Me.cboTipoContrato.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(98, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 269
        Me.Label5.Text = "Data"
        '
        'txtDataContrato
        '
        Me.txtDataContrato.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtDataContrato.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataContrato.Location = New System.Drawing.Point(101, 27)
        Me.txtDataContrato.Name = "txtDataContrato"
        Me.txtDataContrato.ReadOnly = True
        Me.txtDataContrato.Size = New System.Drawing.Size(90, 23)
        Me.txtDataContrato.TabIndex = 0
        Me.txtDataContrato.Value = Nothing
        '
        'lblContrato
        '
        Me.lblContrato.BackColor = System.Drawing.Color.Black
        Me.lblContrato.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContrato.ForeColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lblContrato.Location = New System.Drawing.Point(6, 27)
        Me.lblContrato.Name = "lblContrato"
        Me.lblContrato.Size = New System.Drawing.Size(89, 23)
        Me.lblContrato.TabIndex = 270
        Me.lblContrato.Text = "NOVO"
        Me.lblContrato.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(3, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 271
        Me.Label3.Text = "Número"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(3, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 16)
        Me.Label4.TabIndex = 273
        Me.Label4.Text = "Quantidade"
        '
        'txtQuantidade
        '
        Me.txtQuantidade.Location = New System.Drawing.Point(6, 88)
        Me.txtQuantidade.MaskInput = "{LOC}-nnnn,nnn"
        Me.txtQuantidade.Name = "txtQuantidade"
        Me.txtQuantidade.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtQuantidade.Size = New System.Drawing.Size(89, 21)
        Me.txtQuantidade.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(6, 126)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 16)
        Me.Label6.TabIndex = 275
        Me.Label6.Text = "Filial Entrega"
        '
        'cboFilial
        '
        Me.cboFilial.Location = New System.Drawing.Point(6, 144)
        Me.cboFilial.Name = "cboFilial"
        Me.cboFilial.Size = New System.Drawing.Size(162, 21)
        Me.cboFilial.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(201, 129)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(153, 16)
        Me.Label10.TabIndex = 277
        Me.Label10.Text = "Municipio"
        '
        'chkCobraJuros
        '
        Me.chkCobraJuros.AutoSize = True
        Me.chkCobraJuros.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCobraJuros.Location = New System.Drawing.Point(6, 37)
        Me.chkCobraJuros.Name = "chkCobraJuros"
        Me.chkCobraJuros.Size = New System.Drawing.Size(88, 17)
        Me.chkCobraJuros.TabIndex = 0
        Me.chkCobraJuros.Text = "Cobra Juros?"
        Me.chkCobraJuros.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(374, 193)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 13)
        Me.Label11.TabIndex = 280
        Me.Label11.Text = "Data Fixação"
        '
        'txtDataFixacao
        '
        Me.txtDataFixacao.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtDataFixacao.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataFixacao.Location = New System.Drawing.Point(374, 207)
        Me.txtDataFixacao.Name = "txtDataFixacao"
        Me.txtDataFixacao.Size = New System.Drawing.Size(96, 23)
        Me.txtDataFixacao.TabIndex = 9
        Me.txtDataFixacao.Value = Nothing
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
        Me.txtDiasCarencia.TabIndex = 1
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(97, 16)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(73, 13)
        Me.Label19.TabIndex = 282
        Me.Label19.Text = "Dias Carência"
        '
        'chkJurosAposCarencia
        '
        Me.chkJurosAposCarencia.AutoSize = True
        Me.chkJurosAposCarencia.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkJurosAposCarencia.Location = New System.Drawing.Point(179, 37)
        Me.chkJurosAposCarencia.Name = "chkJurosAposCarencia"
        Me.chkJurosAposCarencia.Size = New System.Drawing.Size(129, 17)
        Me.chkJurosAposCarencia.TabIndex = 2
        Me.chkJurosAposCarencia.Text = "Juros Após Carência?"
        Me.chkJurosAposCarencia.UseVisualStyleBackColor = True
        '
        'txtTaxaJuros
        '
        Me.txtTaxaJuros.Location = New System.Drawing.Point(314, 33)
        Me.txtTaxaJuros.MaskInput = "{LOC}-n.nn"
        Me.txtTaxaJuros.Name = "txtTaxaJuros"
        Me.txtTaxaJuros.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtTaxaJuros.Size = New System.Drawing.Size(32, 21)
        Me.txtTaxaJuros.TabIndex = 3
        '
        'grpJuros
        '
        Me.grpJuros.Controls.Add(Me.Label12)
        Me.grpJuros.Controls.Add(Me.chkCobraJuros)
        Me.grpJuros.Controls.Add(Me.txtTaxaJuros)
        Me.grpJuros.Controls.Add(Me.txtDiasCarencia)
        Me.grpJuros.Controls.Add(Me.chkJurosAposCarencia)
        Me.grpJuros.Controls.Add(Me.Label19)
        Me.grpJuros.Location = New System.Drawing.Point(6, 178)
        Me.grpJuros.Name = "grpJuros"
        Me.grpJuros.Size = New System.Drawing.Size(357, 61)
        Me.grpJuros.TabIndex = 8
        Me.grpJuros.Text = "Juros"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(311, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(31, 13)
        Me.Label12.TabIndex = 286
        Me.Label12.Text = "Taxa"
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(5, 305)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 1
        Me.cmdGravar.Text = "G"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(442, 305)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 4
        Me.cmdFechar.TabStop = False
        Me.cmdFechar.Text = "F"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(6, 246)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 289
        Me.Label2.Text = "Contrato Master"
        '
        'cboContratoPAF
        '
        Me.cboContratoPAF.Location = New System.Drawing.Point(6, 260)
        Me.cboContratoPAF.Name = "cboContratoPAF"
        Me.cboContratoPAF.Size = New System.Drawing.Size(160, 21)
        Me.cboContratoPAF.TabIndex = 10
        '
        'grpDados
        '
        Me.grpDados.Controls.Add(Me.Label6)
        Me.grpDados.Controls.Add(Me.Label2)
        Me.grpDados.Controls.Add(Me.Pesq_Fornecedor)
        Me.grpDados.Controls.Add(Me.cboContratoPAF)
        Me.grpDados.Controls.Add(Me.cboTipoContrato)
        Me.grpDados.Controls.Add(Me.Label7)
        Me.grpDados.Controls.Add(Me.Label8)
        Me.grpDados.Controls.Add(Me.grpJuros)
        Me.grpDados.Controls.Add(Me.Label9)
        Me.grpDados.Controls.Add(Me.Label11)
        Me.grpDados.Controls.Add(Me.txtValorAdiantamento)
        Me.grpDados.Controls.Add(Me.txtDataFixacao)
        Me.grpDados.Controls.Add(Me.txtDataEntrega)
        Me.grpDados.Controls.Add(Me.Label10)
        Me.grpDados.Controls.Add(Me.Label1)
        Me.grpDados.Controls.Add(Me.Pesq_Municipio)
        Me.grpDados.Controls.Add(Me.txtDataContrato)
        Me.grpDados.Controls.Add(Me.Label5)
        Me.grpDados.Controls.Add(Me.cboFilial)
        Me.grpDados.Controls.Add(Me.lblContrato)
        Me.grpDados.Controls.Add(Me.Label4)
        Me.grpDados.Controls.Add(Me.Label3)
        Me.grpDados.Controls.Add(Me.txtQuantidade)
        Me.grpDados.Location = New System.Drawing.Point(5, 5)
        Me.grpDados.Name = "grpDados"
        Me.grpDados.Size = New System.Drawing.Size(482, 292)
        Me.grpDados.TabIndex = 0
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
        Me.Pesq_Fornecedor.Location = New System.Drawing.Point(197, 27)
        Me.Pesq_Fornecedor.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_Fornecedor.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_Fornecedor.Name = "Pesq_Fornecedor"
        Me.Pesq_Fornecedor.Size = New System.Drawing.Size(277, 28)
        Me.Pesq_Fornecedor.TabIndex = 1
        Me.Pesq_Fornecedor.TelaFiltro = False
        Me.Pesq_Fornecedor.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'Pesq_Municipio
        '
        Me.Pesq_Municipio.BancoDados_Campo_Codigo = "CD_FORNECEDOR"
        Me.Pesq_Municipio.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Municipio.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_Municipio.BancoDados_Campo_Descricao = "NO_RAZAO_SOCIAL"
        Me.Pesq_Municipio.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_Municipio.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Municipio.BancoDados_Tabela = "FORNECEDOR F"
        Me.Pesq_Municipio.Codigo = 0
        Me.Pesq_Municipio.ExibirCodigo = True
        Me.Pesq_Municipio.Location = New System.Drawing.Point(174, 144)
        Me.Pesq_Municipio.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_Municipio.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_Municipio.Name = "Pesq_Municipio"
        Me.Pesq_Municipio.Size = New System.Drawing.Size(300, 28)
        Me.Pesq_Municipio.TabIndex = 7
        Me.Pesq_Municipio.TelaFiltro = False
        Me.Pesq_Municipio.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'cmdNovo
        '
        Me.cmdNovo.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdNovo.Location = New System.Drawing.Point(58, 305)
        Me.cmdNovo.Name = "cmdNovo"
        Me.cmdNovo.Size = New System.Drawing.Size(45, 45)
        Me.cmdNovo.TabIndex = 2
        Me.cmdNovo.Text = "N"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdImprimir.Location = New System.Drawing.Point(111, 305)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(45, 45)
        Me.cmdImprimir.TabIndex = 3
        Me.cmdImprimir.Text = "I"
        '
        'frmCadastroContratoPAF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(493, 358)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.cmdNovo)
        Me.Controls.Add(Me.grpDados)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdGravar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCadastroContratoPAF"
        Me.Text = "Contrato PAF"
        CType(Me.txtDataEntrega, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorAdiantamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataContrato, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantidade, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataFixacao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDiasCarencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTaxaJuros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpJuros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpJuros.ResumeLayout(False)
        Me.grpJuros.PerformLayout()
        CType(Me.grpDados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDados.ResumeLayout(False)
        Me.grpDados.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDataEntrega As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtValorAdiantamento As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboTipoContrato As System.Windows.Forms.ComboBox
    Friend WithEvents Pesq_Fornecedor As Logus.Pesq_CodigoNome
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDataContrato As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents lblContrato As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtQuantidade As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboFilial As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Pesq_Municipio As Logus.Pesq_CodigoNome
    Friend WithEvents chkCobraJuros As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtDataFixacao As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtDiasCarencia As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents chkJurosAposCarencia As System.Windows.Forms.CheckBox
    Friend WithEvents txtTaxaJuros As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents grpJuros As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboContratoPAF As System.Windows.Forms.ComboBox
    Friend WithEvents grpDados As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents cmdNovo As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdImprimir As Infragistics.Win.Misc.UltraButton
End Class
