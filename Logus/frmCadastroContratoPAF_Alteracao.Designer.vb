<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroContratoPAF_Alteracao
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.txtDataAssinaturaContrato = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDataFixacao = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Pesq_FornecedorBeneficiario = New Logus.Pesq_CodigoNome
        Me.Pesq_Repassador = New Logus.Pesq_CodigoNome
        Me.txtDataEntrega = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtQuantidade = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.lblR_Quantidade = New System.Windows.Forms.Label
        Me.lblR_TipoSubLedgerCP = New System.Windows.Forms.Label
        Me.txtTipoSubLedgerCP = New System.Windows.Forms.TextBox
        Me.lblR_SubLedgerCP = New System.Windows.Forms.Label
        Me.txtSubLedgerCP = New System.Windows.Forms.TextBox
        CType(Me.txtDataAssinaturaContrato, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataFixacao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataEntrega, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantidade, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Repassador"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Fornecedor Beneficiário"
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(8, 183)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 3
        Me.cmdGravar.Text = "G"
        '
        'cmdFechar
        '
        Me.cmdFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(383, 183)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 4
        Me.cmdFechar.Text = "F"
        '
        'txtDataAssinaturaContrato
        '
        Me.txtDataAssinaturaContrato.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtDataAssinaturaContrato.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataAssinaturaContrato.Location = New System.Drawing.Point(8, 110)
        Me.txtDataAssinaturaContrato.Name = "txtDataAssinaturaContrato"
        Me.txtDataAssinaturaContrato.Size = New System.Drawing.Size(104, 23)
        Me.txtDataAssinaturaContrato.TabIndex = 226
        Me.txtDataAssinaturaContrato.Value = Nothing
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Data de Assinatura"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(120, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 227
        Me.Label4.Text = "Data de Fixação"
        '
        'txtDataFixacao
        '
        Me.txtDataFixacao.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtDataFixacao.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataFixacao.Location = New System.Drawing.Point(120, 110)
        Me.txtDataFixacao.Name = "txtDataFixacao"
        Me.txtDataFixacao.Size = New System.Drawing.Size(104, 23)
        Me.txtDataFixacao.TabIndex = 226
        Me.txtDataFixacao.Value = Nothing
        '
        'Pesq_FornecedorBeneficiario
        '
        Me.Pesq_FornecedorBeneficiario.Ativo = True
        Me.Pesq_FornecedorBeneficiario.BancoDados_Campo_Codigo = Nothing
        Me.Pesq_FornecedorBeneficiario.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_FornecedorBeneficiario.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_FornecedorBeneficiario.BancoDados_Campo_Descricao = Nothing
        Me.Pesq_FornecedorBeneficiario.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_FornecedorBeneficiario.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_FornecedorBeneficiario.BancoDados_Tabela = Nothing
        Me.Pesq_FornecedorBeneficiario.Codigo = 0
        Me.Pesq_FornecedorBeneficiario.Descricao = ""
        Me.Pesq_FornecedorBeneficiario.ExibirCodigo = True
        Me.Pesq_FornecedorBeneficiario.Location = New System.Drawing.Point(8, 65)
        Me.Pesq_FornecedorBeneficiario.MaximumSize = New System.Drawing.Size(1000, 23)
        Me.Pesq_FornecedorBeneficiario.MinimumSize = New System.Drawing.Size(0, 23)
        Me.Pesq_FornecedorBeneficiario.Name = "Pesq_FornecedorBeneficiario"
        Me.Pesq_FornecedorBeneficiario.Size = New System.Drawing.Size(420, 23)
        Me.Pesq_FornecedorBeneficiario.TabIndex = 2
        Me.Pesq_FornecedorBeneficiario.TelaFiltro = False
        Me.Pesq_FornecedorBeneficiario.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Inicializar
        '
        'Pesq_Repassador
        '
        Me.Pesq_Repassador.Ativo = True
        Me.Pesq_Repassador.BancoDados_Campo_Codigo = Nothing
        Me.Pesq_Repassador.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Repassador.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_Repassador.BancoDados_Campo_Descricao = Nothing
        Me.Pesq_Repassador.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_Repassador.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Repassador.BancoDados_Tabela = Nothing
        Me.Pesq_Repassador.Codigo = 0
        Me.Pesq_Repassador.Descricao = ""
        Me.Pesq_Repassador.ExibirCodigo = True
        Me.Pesq_Repassador.Location = New System.Drawing.Point(8, 21)
        Me.Pesq_Repassador.MaximumSize = New System.Drawing.Size(1000, 23)
        Me.Pesq_Repassador.MinimumSize = New System.Drawing.Size(0, 23)
        Me.Pesq_Repassador.Name = "Pesq_Repassador"
        Me.Pesq_Repassador.Size = New System.Drawing.Size(420, 23)
        Me.Pesq_Repassador.TabIndex = 1
        Me.Pesq_Repassador.TelaFiltro = False
        Me.Pesq_Repassador.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Inicializar
        '
        'txtDataEntrega
        '
        Me.txtDataEntrega.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtDataEntrega.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataEntrega.Location = New System.Drawing.Point(232, 110)
        Me.txtDataEntrega.Name = "txtDataEntrega"
        Me.txtDataEntrega.Size = New System.Drawing.Size(104, 23)
        Me.txtDataEntrega.TabIndex = 226
        Me.txtDataEntrega.Value = Nothing
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(232, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 227
        Me.Label5.Text = "Data de Entrega"
        '
        'txtQuantidade
        '
        Me.txtQuantidade.Location = New System.Drawing.Point(344, 110)
        Me.txtQuantidade.MaskInput = "{LOC}-nnnn,nnn"
        Me.txtQuantidade.Name = "txtQuantidade"
        Me.txtQuantidade.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtQuantidade.Size = New System.Drawing.Size(80, 21)
        Me.txtQuantidade.TabIndex = 306
        '
        'lblR_Quantidade
        '
        Me.lblR_Quantidade.AutoSize = True
        Me.lblR_Quantidade.BackColor = System.Drawing.Color.Transparent
        Me.lblR_Quantidade.Location = New System.Drawing.Point(344, 96)
        Me.lblR_Quantidade.Name = "lblR_Quantidade"
        Me.lblR_Quantidade.Size = New System.Drawing.Size(62, 13)
        Me.lblR_Quantidade.TabIndex = 307
        Me.lblR_Quantidade.Text = "Quantidade"
        '
        'lblR_TipoSubLedgerCP
        '
        Me.lblR_TipoSubLedgerCP.AutoSize = True
        Me.lblR_TipoSubLedgerCP.BackColor = System.Drawing.Color.Transparent
        Me.lblR_TipoSubLedgerCP.Location = New System.Drawing.Point(152, 141)
        Me.lblR_TipoSubLedgerCP.Name = "lblR_TipoSubLedgerCP"
        Me.lblR_TipoSubLedgerCP.Size = New System.Drawing.Size(103, 13)
        Me.lblR_TipoSubLedgerCP.TabIndex = 344
        Me.lblR_TipoSubLedgerCP.Text = "Tipo Sub Ledger CP"
        '
        'txtTipoSubLedgerCP
        '
        Me.txtTipoSubLedgerCP.Location = New System.Drawing.Point(152, 155)
        Me.txtTipoSubLedgerCP.MaxLength = 40
        Me.txtTipoSubLedgerCP.Name = "txtTipoSubLedgerCP"
        Me.txtTipoSubLedgerCP.Size = New System.Drawing.Size(136, 20)
        Me.txtTipoSubLedgerCP.TabIndex = 342
        '
        'lblR_SubLedgerCP
        '
        Me.lblR_SubLedgerCP.AutoSize = True
        Me.lblR_SubLedgerCP.BackColor = System.Drawing.Color.Transparent
        Me.lblR_SubLedgerCP.Location = New System.Drawing.Point(8, 141)
        Me.lblR_SubLedgerCP.Name = "lblR_SubLedgerCP"
        Me.lblR_SubLedgerCP.Size = New System.Drawing.Size(79, 13)
        Me.lblR_SubLedgerCP.TabIndex = 343
        Me.lblR_SubLedgerCP.Text = "Sub Ledger CP"
        '
        'txtSubLedgerCP
        '
        Me.txtSubLedgerCP.Location = New System.Drawing.Point(8, 155)
        Me.txtSubLedgerCP.MaxLength = 40
        Me.txtSubLedgerCP.Name = "txtSubLedgerCP"
        Me.txtSubLedgerCP.Size = New System.Drawing.Size(136, 20)
        Me.txtSubLedgerCP.TabIndex = 341
        '
        'frmCadastroContratoPAF_Alteracao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(436, 237)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblR_TipoSubLedgerCP)
        Me.Controls.Add(Me.txtTipoSubLedgerCP)
        Me.Controls.Add(Me.lblR_SubLedgerCP)
        Me.Controls.Add(Me.txtSubLedgerCP)
        Me.Controls.Add(Me.txtQuantidade)
        Me.Controls.Add(Me.lblR_Quantidade)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDataEntrega)
        Me.Controls.Add(Me.txtDataFixacao)
        Me.Controls.Add(Me.txtDataAssinaturaContrato)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.Pesq_FornecedorBeneficiario)
        Me.Controls.Add(Me.Pesq_Repassador)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmCadastroContratoPAF_Alteracao"
        Me.Text = " Contrato PAF - Alteração"
        CType(Me.txtDataAssinaturaContrato, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataFixacao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataEntrega, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantidade, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Pesq_Repassador As Logus.Pesq_CodigoNome
    Friend WithEvents Pesq_FornecedorBeneficiario As Logus.Pesq_CodigoNome
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtDataAssinaturaContrato As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDataFixacao As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtDataEntrega As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtQuantidade As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents lblR_Quantidade As System.Windows.Forms.Label
    Friend WithEvents lblR_TipoSubLedgerCP As System.Windows.Forms.Label
    Friend WithEvents txtTipoSubLedgerCP As System.Windows.Forms.TextBox
    Friend WithEvents lblR_SubLedgerCP As System.Windows.Forms.Label
    Friend WithEvents txtSubLedgerCP As System.Windows.Forms.TextBox
End Class
