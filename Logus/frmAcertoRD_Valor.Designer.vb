<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAcertoRD_Valor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAcertoRD_Valor))
        Me.Label2 = New System.Windows.Forms.Label
        Me.Pesq_TipoMovimentacao = New Logus.Pesq_CodigoNome
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.txtValor = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtQuantidade = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Label4 = New System.Windows.Forms.Label
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        CType(Me.txtValor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantidade, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 13)
        Me.Label2.TabIndex = 311
        Me.Label2.Text = "Tipo de Movimentação"
        '
        'Pesq_TipoMovimentacao
        '
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_Codigo = Nothing
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_Descricao = Nothing
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_TipoMovimentacao.BancoDados_Tabela = Nothing
        Me.Pesq_TipoMovimentacao.Codigo = CType(0, Long)
        Me.Pesq_TipoMovimentacao.Location = New System.Drawing.Point(17, 27)
        Me.Pesq_TipoMovimentacao.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_TipoMovimentacao.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_TipoMovimentacao.Name = "Pesq_TipoMovimentacao"
        Me.Pesq_TipoMovimentacao.Size = New System.Drawing.Size(293, 28)
        Me.Pesq_TipoMovimentacao.TabIndex = 310
        Me.Pesq_TipoMovimentacao.TelaFiltro = False
        Me.Pesq_TipoMovimentacao.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Inicializar
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(280, 119)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 313
        Me.cmdFechar.Text = "F"
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(3, 119)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 312
        Me.cmdGravar.TabStop = False
        Me.cmdGravar.Text = "G"
        '
        'txtValor
        '
        Me.txtValor.Location = New System.Drawing.Point(17, 76)
        Me.txtValor.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(131, 21)
        Me.txtValor.TabIndex = 317
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(177, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 16)
        Me.Label1.TabIndex = 315
        Me.Label1.Text = "Quantidade"
        '
        'txtQuantidade
        '
        Me.txtQuantidade.Location = New System.Drawing.Point(180, 76)
        Me.txtQuantidade.MaskInput = "{LOC}-nnnn,nnnn"
        Me.txtQuantidade.Name = "txtQuantidade"
        Me.txtQuantidade.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtQuantidade.Size = New System.Drawing.Size(130, 21)
        Me.txtQuantidade.TabIndex = 314
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(18, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 16)
        Me.Label4.TabIndex = 316
        Me.Label4.Text = "Valor"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.txtQuantidade)
        Me.UltraGroupBox1.Controls.Add(Me.txtValor)
        Me.UltraGroupBox1.Controls.Add(Me.Pesq_TipoMovimentacao)
        Me.UltraGroupBox1.Controls.Add(Me.Label1)
        Me.UltraGroupBox1.Controls.Add(Me.Label2)
        Me.UltraGroupBox1.Controls.Add(Me.Label4)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(322, 110)
        Me.UltraGroupBox1.TabIndex = 318
        '
        'frmAcertoRD_Valor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(329, 169)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdGravar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmAcertoRD_Valor"
        Me.Text = "Acerto RD Valor"
        CType(Me.txtValor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantidade, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Pesq_TipoMovimentacao As Logus.Pesq_CodigoNome
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtValor As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtQuantidade As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
End Class
