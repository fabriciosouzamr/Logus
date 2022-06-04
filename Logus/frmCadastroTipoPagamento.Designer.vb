<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroTipoPagamento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadastroTipoPagamento))
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.cboFormaPagamento = New System.Windows.Forms.ComboBox
        Me.chkFormaPagamento = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.chkJuros = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.chkICMS = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.chkAtivo = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.txtDescricao = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Pesq_OperacaoBancaria = New Logus.Pesq_CodigoNome
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(8, 188)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 314
        Me.cmdGravar.TabStop = False
        Me.cmdGravar.Text = "G"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.cboFormaPagamento)
        Me.UltraGroupBox1.Controls.Add(Me.chkFormaPagamento)
        Me.UltraGroupBox1.Controls.Add(Me.chkJuros)
        Me.UltraGroupBox1.Controls.Add(Me.chkICMS)
        Me.UltraGroupBox1.Controls.Add(Me.lblCodigo)
        Me.UltraGroupBox1.Controls.Add(Me.Label3)
        Me.UltraGroupBox1.Controls.Add(Me.chkAtivo)
        Me.UltraGroupBox1.Controls.Add(Me.txtDescricao)
        Me.UltraGroupBox1.Controls.Add(Me.Label2)
        Me.UltraGroupBox1.Controls.Add(Me.Label1)
        Me.UltraGroupBox1.Controls.Add(Me.Pesq_OperacaoBancaria)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(8, 12)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(305, 170)
        Me.UltraGroupBox1.TabIndex = 316
        '
        'cboFormaPagamento
        '
        Me.cboFormaPagamento.Location = New System.Drawing.Point(19, 126)
        Me.cboFormaPagamento.Name = "cboFormaPagamento"
        Me.cboFormaPagamento.Size = New System.Drawing.Size(131, 21)
        Me.cboFormaPagamento.TabIndex = 314
        '
        'chkFormaPagamento
        '
        Me.chkFormaPagamento.Location = New System.Drawing.Point(19, 107)
        Me.chkFormaPagamento.Name = "chkFormaPagamento"
        Me.chkFormaPagamento.Size = New System.Drawing.Size(148, 20)
        Me.chkFormaPagamento.TabIndex = 313
        Me.chkFormaPagamento.Text = "Forma Pagamento Fixo"
        '
        'chkJuros
        '
        Me.chkJuros.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkJuros.Location = New System.Drawing.Point(183, 144)
        Me.chkJuros.Name = "chkJuros"
        Me.chkJuros.Size = New System.Drawing.Size(92, 20)
        Me.chkJuros.TabIndex = 312
        Me.chkJuros.Text = "Calcula Juros"
        '
        'chkICMS
        '
        Me.chkICMS.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkICMS.Location = New System.Drawing.Point(217, 126)
        Me.chkICMS.Name = "chkICMS"
        Me.chkICMS.Size = New System.Drawing.Size(58, 20)
        Me.chkICMS.TabIndex = 311
        Me.chkICMS.Text = "ICMS"
        '
        'lblCodigo
        '
        Me.lblCodigo.BackColor = System.Drawing.Color.Black
        Me.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lblCodigo.Location = New System.Drawing.Point(6, 23)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(52, 23)
        Me.lblCodigo.TabIndex = 304
        Me.lblCodigo.Text = "NOVO"
        Me.lblCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(3, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 305
        Me.Label3.Text = "Número"
        '
        'chkAtivo
        '
        Me.chkAtivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAtivo.Location = New System.Drawing.Point(217, 107)
        Me.chkAtivo.Name = "chkAtivo"
        Me.chkAtivo.Size = New System.Drawing.Size(58, 20)
        Me.chkAtivo.TabIndex = 310
        Me.chkAtivo.Text = "Ativo"
        '
        'txtDescricao
        '
        Me.txtDescricao.Location = New System.Drawing.Point(64, 26)
        Me.txtDescricao.MaxLength = 40
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(231, 20)
        Me.txtDescricao.TabIndex = 306
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 13)
        Me.Label2.TabIndex = 309
        Me.Label2.Text = "Operação Bancaria"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(64, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 307
        Me.Label1.Text = "Descrição"
        '
        'Pesq_OperacaoBancaria
        '
        Me.Pesq_OperacaoBancaria.BancoDados_Campo_Codigo = Nothing
        Me.Pesq_OperacaoBancaria.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_OperacaoBancaria.BancoDados_Campo_Descricao = Nothing
        Me.Pesq_OperacaoBancaria.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_OperacaoBancaria.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_OperacaoBancaria.BancoDados_Tabela = Nothing
        Me.Pesq_OperacaoBancaria.Codigo = CType(0, Long)
        Me.Pesq_OperacaoBancaria.Location = New System.Drawing.Point(6, 73)
        Me.Pesq_OperacaoBancaria.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_OperacaoBancaria.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_OperacaoBancaria.Name = "Pesq_OperacaoBancaria"
        Me.Pesq_OperacaoBancaria.Size = New System.Drawing.Size(293, 28)
        Me.Pesq_OperacaoBancaria.TabIndex = 308
        Me.Pesq_OperacaoBancaria.TelaFiltro = False
        Me.Pesq_OperacaoBancaria.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Inicializar
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(268, 188)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 315
        Me.cmdFechar.Text = "F"
        '
        'frmCadastroTipoPagamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(318, 239)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.cmdFechar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCadastroTipoPagamento"
        Me.Text = "Cadastro Tipo Pagamento"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkAtivo As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents txtDescricao As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Pesq_OperacaoBancaria As Logus.Pesq_CodigoNome
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents chkJuros As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkICMS As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkFormaPagamento As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents cboFormaPagamento As System.Windows.Forms.ComboBox
End Class
