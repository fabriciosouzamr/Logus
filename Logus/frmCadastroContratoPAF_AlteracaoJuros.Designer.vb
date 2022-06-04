<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroContratoPAF_AlteracaoJuros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadastroContratoPAF_AlteracaoJuros))
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtContratoPAF = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Pesq_Fornecedor = New Logus.Pesq_CodigoNome
        Me.chkCobraJuros = New System.Windows.Forms.CheckBox
        Me.lblQuantidadeDiasCarenciaCobrancaJuros = New System.Windows.Forms.Label
        Me.txtQuantidadeDiasCarenciaCobrancaJuros = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.chkConsideraDdiasQuarenciaCobrancaJuros = New System.Windows.Forms.CheckBox
        Me.lblTaxaJuros = New System.Windows.Forms.Label
        Me.txtTaxaJuros = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.fraCobrarJurosAte = New System.Windows.Forms.GroupBox
        Me.optCobrarJurosAte_NegociacaoRecebimento = New System.Windows.Forms.RadioButton
        Me.RadioButton4 = New System.Windows.Forms.RadioButton
        Me.optCobrarJurosAte_ContratoFixo = New System.Windows.Forms.RadioButton
        Me.optCobrarJurosAte_Negociacao = New System.Windows.Forms.RadioButton
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        CType(Me.txtQuantidadeDiasCarenciaCobrancaJuros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTaxaJuros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraCobrarJurosAte.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nº de Contrato PAF"
        '
        'txtContratoPAF
        '
        Me.txtContratoPAF.Location = New System.Drawing.Point(5, 20)
        Me.txtContratoPAF.Name = "txtContratoPAF"
        Me.txtContratoPAF.ReadOnly = True
        Me.txtContratoPAF.Size = New System.Drawing.Size(100, 20)
        Me.txtContratoPAF.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(113, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fornecedor"
        '
        'Pesq_Fornecedor
        '
        Me.Pesq_Fornecedor.Ativo = True
        Me.Pesq_Fornecedor.BancoDados_Campo_Codigo = Nothing
        Me.Pesq_Fornecedor.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Fornecedor.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_Fornecedor.BancoDados_Campo_Descricao = Nothing
        Me.Pesq_Fornecedor.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_Fornecedor.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Fornecedor.BancoDados_Tabela = Nothing
        Me.Pesq_Fornecedor.Codigo = 0
        Me.Pesq_Fornecedor.Descricao = ""
        Me.Pesq_Fornecedor.Enabled = False
        Me.Pesq_Fornecedor.ExibirCodigo = True
        Me.Pesq_Fornecedor.Location = New System.Drawing.Point(113, 18)
        Me.Pesq_Fornecedor.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_Fornecedor.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_Fornecedor.Name = "Pesq_Fornecedor"
        Me.Pesq_Fornecedor.Size = New System.Drawing.Size(450, 28)
        Me.Pesq_Fornecedor.TabIndex = 3
        Me.Pesq_Fornecedor.TelaFiltro = False
        Me.Pesq_Fornecedor.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Inicializar
        '
        'chkCobraJuros
        '
        Me.chkCobraJuros.AutoSize = True
        Me.chkCobraJuros.Location = New System.Drawing.Point(8, 48)
        Me.chkCobraJuros.Name = "chkCobraJuros"
        Me.chkCobraJuros.Size = New System.Drawing.Size(88, 17)
        Me.chkCobraJuros.TabIndex = 4
        Me.chkCobraJuros.Text = "Cobra Juros?"
        Me.chkCobraJuros.UseVisualStyleBackColor = True
        '
        'lblQuantidadeDiasCarenciaCobrancaJuros
        '
        Me.lblQuantidadeDiasCarenciaCobrancaJuros.AutoSize = True
        Me.lblQuantidadeDiasCarenciaCobrancaJuros.Location = New System.Drawing.Point(8, 92)
        Me.lblQuantidadeDiasCarenciaCobrancaJuros.Name = "lblQuantidadeDiasCarenciaCobrancaJuros"
        Me.lblQuantidadeDiasCarenciaCobrancaJuros.Size = New System.Drawing.Size(275, 13)
        Me.lblQuantidadeDiasCarenciaCobrancaJuros.TabIndex = 5
        Me.lblQuantidadeDiasCarenciaCobrancaJuros.Text = "Quantidade de dias da Carência para Cobrança de Juros"
        '
        'txtQuantidadeDiasCarenciaCobrancaJuros
        '
        Me.txtQuantidadeDiasCarenciaCobrancaJuros.Location = New System.Drawing.Point(244, 107)
        Me.txtQuantidadeDiasCarenciaCobrancaJuros.MaskInput = "nnn"
        Me.txtQuantidadeDiasCarenciaCobrancaJuros.MaxValue = 100
        Me.txtQuantidadeDiasCarenciaCobrancaJuros.MinValue = 0
        Me.txtQuantidadeDiasCarenciaCobrancaJuros.Name = "txtQuantidadeDiasCarenciaCobrancaJuros"
        Me.txtQuantidadeDiasCarenciaCobrancaJuros.Size = New System.Drawing.Size(39, 21)
        Me.txtQuantidadeDiasCarenciaCobrancaJuros.TabIndex = 6
        '
        'chkConsideraDdiasQuarenciaCobrancaJuros
        '
        Me.chkConsideraDdiasQuarenciaCobrancaJuros.AutoSize = True
        Me.chkConsideraDdiasQuarenciaCobrancaJuros.Location = New System.Drawing.Point(8, 136)
        Me.chkConsideraDdiasQuarenciaCobrancaJuros.Name = "chkConsideraDdiasQuarenciaCobrancaJuros"
        Me.chkConsideraDdiasQuarenciaCobrancaJuros.Size = New System.Drawing.Size(278, 17)
        Me.chkConsideraDdiasQuarenciaCobrancaJuros.TabIndex = 7
        Me.chkConsideraDdiasQuarenciaCobrancaJuros.Text = "Considerar dias da Quarência na Cobrança de Juros?"
        Me.chkConsideraDdiasQuarenciaCobrancaJuros.UseVisualStyleBackColor = True
        '
        'lblTaxaJuros
        '
        Me.lblTaxaJuros.AutoSize = True
        Me.lblTaxaJuros.Location = New System.Drawing.Point(104, 48)
        Me.lblTaxaJuros.Name = "lblTaxaJuros"
        Me.lblTaxaJuros.Size = New System.Drawing.Size(74, 13)
        Me.lblTaxaJuros.TabIndex = 8
        Me.lblTaxaJuros.Text = "Taxa de Juros"
        '
        'txtTaxaJuros
        '
        Me.txtTaxaJuros.Location = New System.Drawing.Point(128, 63)
        Me.txtTaxaJuros.MaskInput = "{LOC}-n.nn"
        Me.txtTaxaJuros.Name = "txtTaxaJuros"
        Me.txtTaxaJuros.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtTaxaJuros.Size = New System.Drawing.Size(50, 21)
        Me.txtTaxaJuros.TabIndex = 285
        '
        'fraCobrarJurosAte
        '
        Me.fraCobrarJurosAte.Controls.Add(Me.optCobrarJurosAte_NegociacaoRecebimento)
        Me.fraCobrarJurosAte.Controls.Add(Me.RadioButton4)
        Me.fraCobrarJurosAte.Controls.Add(Me.optCobrarJurosAte_ContratoFixo)
        Me.fraCobrarJurosAte.Controls.Add(Me.optCobrarJurosAte_Negociacao)
        Me.fraCobrarJurosAte.Location = New System.Drawing.Point(8, 161)
        Me.fraCobrarJurosAte.Name = "fraCobrarJurosAte"
        Me.fraCobrarJurosAte.Size = New System.Drawing.Size(359, 42)
        Me.fraCobrarJurosAte.TabIndex = 286
        Me.fraCobrarJurosAte.TabStop = False
        Me.fraCobrarJurosAte.Text = "Cobrar juros áte "
        '
        'optCobrarJurosAte_NegociacaoRecebimento
        '
        Me.optCobrarJurosAte_NegociacaoRecebimento.AutoSize = True
        Me.optCobrarJurosAte_NegociacaoRecebimento.Location = New System.Drawing.Point(202, 18)
        Me.optCobrarJurosAte_NegociacaoRecebimento.Name = "optCobrarJurosAte_NegociacaoRecebimento"
        Me.optCobrarJurosAte_NegociacaoRecebimento.Size = New System.Drawing.Size(151, 17)
        Me.optCobrarJurosAte_NegociacaoRecebimento.TabIndex = 2
        Me.optCobrarJurosAte_NegociacaoRecebimento.TabStop = True
        Me.optCobrarJurosAte_NegociacaoRecebimento.Text = "Negociação/Recebimento"
        Me.optCobrarJurosAte_NegociacaoRecebimento.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(526, 575)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(90, 17)
        Me.RadioButton4.TabIndex = 1
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "RadioButton2"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'optCobrarJurosAte_ContratoFixo
        '
        Me.optCobrarJurosAte_ContratoFixo.AutoSize = True
        Me.optCobrarJurosAte_ContratoFixo.Location = New System.Drawing.Point(107, 18)
        Me.optCobrarJurosAte_ContratoFixo.Name = "optCobrarJurosAte_ContratoFixo"
        Me.optCobrarJurosAte_ContratoFixo.Size = New System.Drawing.Size(87, 17)
        Me.optCobrarJurosAte_ContratoFixo.TabIndex = 1
        Me.optCobrarJurosAte_ContratoFixo.TabStop = True
        Me.optCobrarJurosAte_ContratoFixo.Text = "Contrato Fixo"
        Me.optCobrarJurosAte_ContratoFixo.UseVisualStyleBackColor = True
        '
        'optCobrarJurosAte_Negociacao
        '
        Me.optCobrarJurosAte_Negociacao.AutoSize = True
        Me.optCobrarJurosAte_Negociacao.Location = New System.Drawing.Point(16, 18)
        Me.optCobrarJurosAte_Negociacao.Name = "optCobrarJurosAte_Negociacao"
        Me.optCobrarJurosAte_Negociacao.Size = New System.Drawing.Size(83, 17)
        Me.optCobrarJurosAte_Negociacao.TabIndex = 0
        Me.optCobrarJurosAte_Negociacao.TabStop = True
        Me.optCobrarJurosAte_Negociacao.Text = "Negociação"
        Me.optCobrarJurosAte_Negociacao.UseVisualStyleBackColor = True
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(8, 211)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 288
        Me.cmdGravar.TabStop = False
        Me.cmdGravar.Text = "G"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(515, 211)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 287
        Me.cmdFechar.Text = "F"
        '
        'frmCadastroContratoPAF_AlteracaoJuros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(567, 265)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.fraCobrarJurosAte)
        Me.Controls.Add(Me.txtTaxaJuros)
        Me.Controls.Add(Me.lblTaxaJuros)
        Me.Controls.Add(Me.chkConsideraDdiasQuarenciaCobrancaJuros)
        Me.Controls.Add(Me.txtQuantidadeDiasCarenciaCobrancaJuros)
        Me.Controls.Add(Me.lblQuantidadeDiasCarenciaCobrancaJuros)
        Me.Controls.Add(Me.chkCobraJuros)
        Me.Controls.Add(Me.Pesq_Fornecedor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtContratoPAF)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCadastroContratoPAF_AlteracaoJuros"
        Me.Text = "Contrato PAF - Alteração de Informações de Juros"
        CType(Me.txtQuantidadeDiasCarenciaCobrancaJuros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTaxaJuros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraCobrarJurosAte.ResumeLayout(False)
        Me.fraCobrarJurosAte.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtContratoPAF As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Pesq_Fornecedor As Logus.Pesq_CodigoNome
    Friend WithEvents chkCobraJuros As System.Windows.Forms.CheckBox
    Friend WithEvents lblQuantidadeDiasCarenciaCobrancaJuros As System.Windows.Forms.Label
    Friend WithEvents txtQuantidadeDiasCarenciaCobrancaJuros As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents chkConsideraDdiasQuarenciaCobrancaJuros As System.Windows.Forms.CheckBox
    Friend WithEvents lblTaxaJuros As System.Windows.Forms.Label
    Friend WithEvents txtTaxaJuros As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents fraCobrarJurosAte As System.Windows.Forms.GroupBox
    Friend WithEvents optCobrarJurosAte_NegociacaoRecebimento As System.Windows.Forms.RadioButton
    Friend WithEvents optCobrarJurosAte_ContratoFixo As System.Windows.Forms.RadioButton
    Friend WithEvents optCobrarJurosAte_Negociacao As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
End Class
