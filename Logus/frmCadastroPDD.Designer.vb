<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroPDD
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadastroPDD))
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboFilialReferencia = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtValor = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtQuantidade = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.optBens_Nao = New System.Windows.Forms.RadioButton
        Me.optBens_Sim = New System.Windows.Forms.RadioButton
        Me.optBens_NaoDefinido = New System.Windows.Forms.RadioButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboTipoGarantia = New System.Windows.Forms.ComboBox
        Me.txtStatus = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtObservacao = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.optTipo_PDD = New System.Windows.Forms.RadioButton
        Me.optTipo_GAAP = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboContratoFixo = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboNegociacao = New System.Windows.Forms.ComboBox
        Me.Pesq_ContratoPAF = New Logus.Pesq_CodigoNome
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cboRecuperacaoCredito = New System.Windows.Forms.ComboBox
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.txtDescricaoPDD = New System.Windows.Forms.TextBox
        Me.Pesq_Fornecedor = New Logus.Pesq_CodigoNome
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.txtDataVencimento = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        CType(Me.txtValor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantidade, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.txtDataVencimento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Filial de Referência"
        '
        'cboFilialReferencia
        '
        Me.cboFilialReferencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilialReferencia.FormattingEnabled = True
        Me.cboFilialReferencia.Location = New System.Drawing.Point(8, 22)
        Me.cboFilialReferencia.Name = "cboFilialReferencia"
        Me.cboFilialReferencia.Size = New System.Drawing.Size(200, 21)
        Me.cboFilialReferencia.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Quantidade"
        '
        'txtValor
        '
        Me.txtValor.Location = New System.Drawing.Point(104, 65)
        Me.txtValor.MaskInput = "{currency:-9.2}"
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(103, 21)
        Me.txtValor.TabIndex = 301
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(104, 51)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(31, 13)
        Me.Label17.TabIndex = 302
        Me.Label17.Text = "Valor"
        '
        'txtQuantidade
        '
        Me.txtQuantidade.Location = New System.Drawing.Point(8, 65)
        Me.txtQuantidade.MaskInput = "{LOC}-nnnn,nnn"
        Me.txtQuantidade.Name = "txtQuantidade"
        Me.txtQuantidade.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtQuantidade.Size = New System.Drawing.Size(88, 21)
        Me.txtQuantidade.TabIndex = 306
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(216, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 13)
        Me.Label9.TabIndex = 308
        Me.Label9.Text = "Fornecedor"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optBens_Nao)
        Me.GroupBox1.Controls.Add(Me.optBens_Sim)
        Me.GroupBox1.Controls.Add(Me.optBens_NaoDefinido)
        Me.GroupBox1.Location = New System.Drawing.Point(215, 51)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(215, 35)
        Me.GroupBox1.TabIndex = 310
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Possui Bens"
        '
        'optBens_Nao
        '
        Me.optBens_Nao.AutoSize = True
        Me.optBens_Nao.Location = New System.Drawing.Point(155, 14)
        Me.optBens_Nao.Name = "optBens_Nao"
        Me.optBens_Nao.Size = New System.Drawing.Size(45, 17)
        Me.optBens_Nao.TabIndex = 0
        Me.optBens_Nao.Text = "Não"
        Me.optBens_Nao.UseVisualStyleBackColor = True
        '
        'optBens_Sim
        '
        Me.optBens_Sim.AutoSize = True
        Me.optBens_Sim.Location = New System.Drawing.Point(105, 14)
        Me.optBens_Sim.Name = "optBens_Sim"
        Me.optBens_Sim.Size = New System.Drawing.Size(42, 17)
        Me.optBens_Sim.TabIndex = 0
        Me.optBens_Sim.Text = "Sim"
        Me.optBens_Sim.UseVisualStyleBackColor = True
        '
        'optBens_NaoDefinido
        '
        Me.optBens_NaoDefinido.AutoSize = True
        Me.optBens_NaoDefinido.Checked = True
        Me.optBens_NaoDefinido.Location = New System.Drawing.Point(12, 14)
        Me.optBens_NaoDefinido.Name = "optBens_NaoDefinido"
        Me.optBens_NaoDefinido.Size = New System.Drawing.Size(85, 17)
        Me.optBens_NaoDefinido.TabIndex = 0
        Me.optBens_NaoDefinido.TabStop = True
        Me.optBens_NaoDefinido.Text = "Não definido"
        Me.optBens_NaoDefinido.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(438, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Tipo de Garantia"
        '
        'cboTipoGarantia
        '
        Me.cboTipoGarantia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoGarantia.FormattingEnabled = True
        Me.cboTipoGarantia.Location = New System.Drawing.Point(438, 65)
        Me.cboTipoGarantia.Name = "cboTipoGarantia"
        Me.cboTipoGarantia.Size = New System.Drawing.Size(200, 21)
        Me.cboTipoGarantia.TabIndex = 1
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(8, 230)
        Me.txtStatus.Multiline = True
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(630, 93)
        Me.txtStatus.TabIndex = 311
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 216)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Status"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 331)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Observação"
        '
        'txtObservacao
        '
        Me.txtObservacao.Location = New System.Drawing.Point(8, 345)
        Me.txtObservacao.Multiline = True
        Me.txtObservacao.Name = "txtObservacao"
        Me.txtObservacao.Size = New System.Drawing.Size(630, 93)
        Me.txtObservacao.TabIndex = 311
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.optTipo_PDD)
        Me.GroupBox2.Controls.Add(Me.optTipo_GAAP)
        Me.GroupBox2.Location = New System.Drawing.Point(492, 164)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(132, 44)
        Me.GroupBox2.TabIndex = 310
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo"
        '
        'optTipo_PDD
        '
        Me.optTipo_PDD.AutoSize = True
        Me.optTipo_PDD.Location = New System.Drawing.Point(74, 19)
        Me.optTipo_PDD.Name = "optTipo_PDD"
        Me.optTipo_PDD.Size = New System.Drawing.Size(48, 17)
        Me.optTipo_PDD.TabIndex = 0
        Me.optTipo_PDD.TabStop = True
        Me.optTipo_PDD.Tag = "2"
        Me.optTipo_PDD.Text = "PDD"
        Me.optTipo_PDD.UseVisualStyleBackColor = True
        '
        'optTipo_GAAP
        '
        Me.optTipo_GAAP.AutoSize = True
        Me.optTipo_GAAP.Location = New System.Drawing.Point(12, 19)
        Me.optTipo_GAAP.Name = "optTipo_GAAP"
        Me.optTipo_GAAP.Size = New System.Drawing.Size(54, 17)
        Me.optTipo_GAAP.TabIndex = 0
        Me.optTipo_GAAP.TabStop = True
        Me.optTipo_GAAP.Tag = "1"
        Me.optTipo_GAAP.Text = "GAAP"
        Me.optTipo_GAAP.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.cboContratoFixo)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.cboNegociacao)
        Me.GroupBox3.Controls.Add(Me.Pesq_ContratoPAF)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 94)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(476, 62)
        Me.GroupBox3.TabIndex = 312
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Contrato"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(383, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 310
        Me.Label6.Text = "Contrato Fixo"
        '
        'cboContratoFixo
        '
        Me.cboContratoFixo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboContratoFixo.Location = New System.Drawing.Point(383, 30)
        Me.cboContratoFixo.Name = "cboContratoFixo"
        Me.cboContratoFixo.Size = New System.Drawing.Size(84, 21)
        Me.cboContratoFixo.TabIndex = 309
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(8, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 13)
        Me.Label7.TabIndex = 308
        Me.Label7.Text = "Contrato PAF"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(293, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 13)
        Me.Label8.TabIndex = 307
        Me.Label8.Text = "Negociação"
        '
        'cboNegociacao
        '
        Me.cboNegociacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNegociacao.Location = New System.Drawing.Point(293, 31)
        Me.cboNegociacao.Name = "cboNegociacao"
        Me.cboNegociacao.Size = New System.Drawing.Size(82, 21)
        Me.cboNegociacao.TabIndex = 306
        '
        'Pesq_ContratoPAF
        '
        Me.Pesq_ContratoPAF.Ativo = True
        Me.Pesq_ContratoPAF.BancoDados_Campo_Codigo = "CD_FORNECEDOR"
        Me.Pesq_ContratoPAF.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_ContratoPAF.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_ContratoPAF.BancoDados_Campo_Descricao = "NO_RAZAO_SOCIAL"
        Me.Pesq_ContratoPAF.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_ContratoPAF.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_ContratoPAF.BancoDados_Tabela = "FORNECEDOR F"
        Me.Pesq_ContratoPAF.Codigo = 0
        Me.Pesq_ContratoPAF.Descricao = ""
        Me.Pesq_ContratoPAF.ExibirCodigo = True
        Me.Pesq_ContratoPAF.Location = New System.Drawing.Point(8, 30)
        Me.Pesq_ContratoPAF.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_ContratoPAF.MinimumSize = New System.Drawing.Size(0, 23)
        Me.Pesq_ContratoPAF.Name = "Pesq_ContratoPAF"
        Me.Pesq_ContratoPAF.Size = New System.Drawing.Size(277, 23)
        Me.Pesq_ContratoPAF.TabIndex = 305
        Me.Pesq_ContratoPAF.TelaFiltro = False
        Me.Pesq_ContratoPAF.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.cboRecuperacaoCredito)
        Me.GroupBox4.Location = New System.Drawing.Point(492, 94)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(146, 62)
        Me.GroupBox4.TabIndex = 313
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Recuperação de Crédito"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(6, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 13)
        Me.Label10.TabIndex = 312
        Me.Label10.Text = "Descrição"
        '
        'cboRecuperacaoCredito
        '
        Me.cboRecuperacaoCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRecuperacaoCredito.Location = New System.Drawing.Point(6, 32)
        Me.cboRecuperacaoCredito.Name = "cboRecuperacaoCredito"
        Me.cboRecuperacaoCredito.Size = New System.Drawing.Size(134, 21)
        Me.cboRecuperacaoCredito.TabIndex = 311
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(593, 446)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 314
        Me.cmdFechar.Text = "F"
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(8, 446)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 315
        Me.cmdGravar.TabStop = False
        Me.cmdGravar.Text = "G"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtDescricaoPDD)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 164)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(354, 44)
        Me.GroupBox5.TabIndex = 316
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Descrição do PDD"
        '
        'txtDescricaoPDD
        '
        Me.txtDescricaoPDD.Location = New System.Drawing.Point(8, 16)
        Me.txtDescricaoPDD.Name = "txtDescricaoPDD"
        Me.txtDescricaoPDD.Size = New System.Drawing.Size(340, 20)
        Me.txtDescricaoPDD.TabIndex = 0
        '
        'Pesq_Fornecedor
        '
        Me.Pesq_Fornecedor.Ativo = True
        Me.Pesq_Fornecedor.BancoDados_Campo_Codigo = "CD_FORNECEDOR"
        Me.Pesq_Fornecedor.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Fornecedor.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_Fornecedor.BancoDados_Campo_Descricao = "NO_RAZAO_SOCIAL"
        Me.Pesq_Fornecedor.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_Fornecedor.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Fornecedor.BancoDados_Tabela = "FORNECEDOR F"
        Me.Pesq_Fornecedor.Codigo = 0
        Me.Pesq_Fornecedor.Descricao = ""
        Me.Pesq_Fornecedor.ExibirCodigo = True
        Me.Pesq_Fornecedor.Location = New System.Drawing.Point(216, 22)
        Me.Pesq_Fornecedor.MaximumSize = New System.Drawing.Size(1000, 23)
        Me.Pesq_Fornecedor.MinimumSize = New System.Drawing.Size(0, 23)
        Me.Pesq_Fornecedor.Name = "Pesq_Fornecedor"
        Me.Pesq_Fornecedor.Size = New System.Drawing.Size(422, 23)
        Me.Pesq_Fornecedor.TabIndex = 309
        Me.Pesq_Fornecedor.TelaFiltro = False
        Me.Pesq_Fornecedor.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txtDataVencimento)
        Me.GroupBox6.Location = New System.Drawing.Point(364, 164)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(122, 44)
        Me.GroupBox6.TabIndex = 317
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Vencimento"
        '
        'txtDataVencimento
        '
        Me.txtDataVencimento.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtDataVencimento.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataVencimento.Location = New System.Drawing.Point(12, 14)
        Me.txtDataVencimento.Name = "txtDataVencimento"
        Me.txtDataVencimento.Size = New System.Drawing.Size(104, 23)
        Me.txtDataVencimento.TabIndex = 225
        Me.txtDataVencimento.Value = Nothing
        '
        'frmCadastroPDD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(645, 498)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.txtObservacao)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Pesq_Fornecedor)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtQuantidade)
        Me.Controls.Add(Me.txtValor)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboTipoGarantia)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboFilialReferencia)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCadastroPDD"
        Me.Text = "Cadastro de PDD"
        CType(Me.txtValor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantidade, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.txtDataVencimento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboFilialReferencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtValor As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtQuantidade As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Pesq_Fornecedor As Logus.Pesq_CodigoNome
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optBens_Nao As System.Windows.Forms.RadioButton
    Friend WithEvents optBens_Sim As System.Windows.Forms.RadioButton
    Friend WithEvents optBens_NaoDefinido As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboTipoGarantia As System.Windows.Forms.ComboBox
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtObservacao As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents optTipo_GAAP As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboContratoFixo As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboNegociacao As System.Windows.Forms.ComboBox
    Friend WithEvents Pesq_ContratoPAF As Logus.Pesq_CodigoNome
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboRecuperacaoCredito As System.Windows.Forms.ComboBox
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDescricaoPDD As System.Windows.Forms.TextBox
    Friend WithEvents optTipo_PDD As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDataVencimento As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
End Class
