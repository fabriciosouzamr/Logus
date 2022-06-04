<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroNegociacao_AlteracaoJuros
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
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.txtTaxaJuros = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.lblTaxaJuros = New System.Windows.Forms.Label
        Me.chkConsideraDdiasQuarenciaCobrancaJuros = New System.Windows.Forms.CheckBox
        Me.txtQuantidadeDiasCarenciaCobrancaJuros = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.lblQuantidadeDiasCarenciaCobrancaJuros = New System.Windows.Forms.Label
        Me.chkCobraJuros = New System.Windows.Forms.CheckBox
        Me.Pesq_Fornecedor = New Logus.Pesq_CodigoNome
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtContratoPAF = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtNegociacao = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        CType(Me.txtTaxaJuros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantidadeDiasCarenciaCobrancaJuros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNegociacao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(7, 163)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 301
        Me.cmdGravar.TabStop = False
        Me.cmdGravar.Text = "G"
        '
        'txtTaxaJuros
        '
        Me.txtTaxaJuros.Location = New System.Drawing.Point(127, 65)
        Me.txtTaxaJuros.MaskInput = "{LOC}-n.nn"
        Me.txtTaxaJuros.Name = "txtTaxaJuros"
        Me.txtTaxaJuros.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtTaxaJuros.Size = New System.Drawing.Size(50, 21)
        Me.txtTaxaJuros.TabIndex = 298
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(514, 163)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 300
        Me.cmdFechar.Text = "F"
        '
        'lblTaxaJuros
        '
        Me.lblTaxaJuros.AutoSize = True
        Me.lblTaxaJuros.Location = New System.Drawing.Point(103, 50)
        Me.lblTaxaJuros.Name = "lblTaxaJuros"
        Me.lblTaxaJuros.Size = New System.Drawing.Size(74, 13)
        Me.lblTaxaJuros.TabIndex = 297
        Me.lblTaxaJuros.Text = "Taxa de Juros"
        '
        'chkConsideraDdiasQuarenciaCobrancaJuros
        '
        Me.chkConsideraDdiasQuarenciaCobrancaJuros.AutoSize = True
        Me.chkConsideraDdiasQuarenciaCobrancaJuros.Location = New System.Drawing.Point(7, 138)
        Me.chkConsideraDdiasQuarenciaCobrancaJuros.Name = "chkConsideraDdiasQuarenciaCobrancaJuros"
        Me.chkConsideraDdiasQuarenciaCobrancaJuros.Size = New System.Drawing.Size(278, 17)
        Me.chkConsideraDdiasQuarenciaCobrancaJuros.TabIndex = 296
        Me.chkConsideraDdiasQuarenciaCobrancaJuros.Text = "Considerar dias da Quarência na Cobrança de Juros?"
        Me.chkConsideraDdiasQuarenciaCobrancaJuros.UseVisualStyleBackColor = True
        '
        'txtQuantidadeDiasCarenciaCobrancaJuros
        '
        Me.txtQuantidadeDiasCarenciaCobrancaJuros.Location = New System.Drawing.Point(232, 109)
        Me.txtQuantidadeDiasCarenciaCobrancaJuros.MaskInput = "nnn"
        Me.txtQuantidadeDiasCarenciaCobrancaJuros.MaxValue = 100
        Me.txtQuantidadeDiasCarenciaCobrancaJuros.MinValue = 0
        Me.txtQuantidadeDiasCarenciaCobrancaJuros.Name = "txtQuantidadeDiasCarenciaCobrancaJuros"
        Me.txtQuantidadeDiasCarenciaCobrancaJuros.Size = New System.Drawing.Size(50, 21)
        Me.txtQuantidadeDiasCarenciaCobrancaJuros.TabIndex = 295
        '
        'lblQuantidadeDiasCarenciaCobrancaJuros
        '
        Me.lblQuantidadeDiasCarenciaCobrancaJuros.AutoSize = True
        Me.lblQuantidadeDiasCarenciaCobrancaJuros.Location = New System.Drawing.Point(7, 94)
        Me.lblQuantidadeDiasCarenciaCobrancaJuros.Name = "lblQuantidadeDiasCarenciaCobrancaJuros"
        Me.lblQuantidadeDiasCarenciaCobrancaJuros.Size = New System.Drawing.Size(275, 13)
        Me.lblQuantidadeDiasCarenciaCobrancaJuros.TabIndex = 294
        Me.lblQuantidadeDiasCarenciaCobrancaJuros.Text = "Quantidade de dias da Carência para Cobrança de Juros"
        '
        'chkCobraJuros
        '
        Me.chkCobraJuros.AutoSize = True
        Me.chkCobraJuros.Location = New System.Drawing.Point(7, 50)
        Me.chkCobraJuros.Name = "chkCobraJuros"
        Me.chkCobraJuros.Size = New System.Drawing.Size(88, 17)
        Me.chkCobraJuros.TabIndex = 293
        Me.chkCobraJuros.Text = "Cobra Juros?"
        Me.chkCobraJuros.UseVisualStyleBackColor = True
        '
        'Pesq_Fornecedor
        '
        Me.Pesq_Fornecedor.BancoDados_Campo_Codigo = Nothing
        Me.Pesq_Fornecedor.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_Fornecedor.BancoDados_Campo_Descricao = Nothing
        Me.Pesq_Fornecedor.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_Fornecedor.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Fornecedor.BancoDados_Tabela = Nothing
        Me.Pesq_Fornecedor.Codigo = CType(0, Long)
        Me.Pesq_Fornecedor.Enabled = False
        Me.Pesq_Fornecedor.Location = New System.Drawing.Point(183, 20)
        Me.Pesq_Fornecedor.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_Fornecedor.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_Fornecedor.Name = "Pesq_Fornecedor"
        Me.Pesq_Fornecedor.Size = New System.Drawing.Size(379, 28)
        Me.Pesq_Fornecedor.TabIndex = 292
        Me.Pesq_Fornecedor.TelaFiltro = False
        Me.Pesq_Fornecedor.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Inicializar
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(183, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 291
        Me.Label2.Text = "Fornecedor"
        '
        'txtContratoPAF
        '
        Me.txtContratoPAF.Location = New System.Drawing.Point(4, 22)
        Me.txtContratoPAF.Name = "txtContratoPAF"
        Me.txtContratoPAF.ReadOnly = True
        Me.txtContratoPAF.Size = New System.Drawing.Size(100, 20)
        Me.txtContratoPAF.TabIndex = 290
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 289
        Me.Label1.Text = "Nº de Contrato PAF"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(112, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 302
        Me.Label3.Text = "Negociação"
        '
        'txtNegociacao
        '
        Me.txtNegociacao.Location = New System.Drawing.Point(138, 22)
        Me.txtNegociacao.MaskInput = "nnn"
        Me.txtNegociacao.MaxValue = 100
        Me.txtNegociacao.MinValue = 0
        Me.txtNegociacao.Name = "txtNegociacao"
        Me.txtNegociacao.Size = New System.Drawing.Size(39, 21)
        Me.txtNegociacao.TabIndex = 303
        '
        'frmCadastroNegociacao_AlteracaoJuros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(567, 213)
        Me.Controls.Add(Me.txtNegociacao)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.txtTaxaJuros)
        Me.Controls.Add(Me.cmdFechar)
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
        Me.Name = "frmCadastroNegociacao_AlteracaoJuros"
        Me.Text = "Cadastro de Negociação - Alteração de Informações de Juros"
        CType(Me.txtTaxaJuros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantidadeDiasCarenciaCobrancaJuros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNegociacao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtTaxaJuros As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblTaxaJuros As System.Windows.Forms.Label
    Friend WithEvents chkConsideraDdiasQuarenciaCobrancaJuros As System.Windows.Forms.CheckBox
    Friend WithEvents txtQuantidadeDiasCarenciaCobrancaJuros As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents lblQuantidadeDiasCarenciaCobrancaJuros As System.Windows.Forms.Label
    Friend WithEvents chkCobraJuros As System.Windows.Forms.CheckBox
    Friend WithEvents Pesq_Fornecedor As Logus.Pesq_CodigoNome
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtContratoPAF As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNegociacao As Infragistics.Win.UltraWinEditors.UltraNumericEditor
End Class
