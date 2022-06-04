<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroSolicitacaoCredito
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
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadastroSolicitacaoCredito))
        Me.UltraGroupBox5 = New Infragistics.Win.Misc.UltraGroupBox
        Me.grpValidade = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtDataValidade = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.grpGarantia = New Infragistics.Win.Misc.UltraGroupBox
        Me.cboGarantia = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.grpSolicitado = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtSolicitado = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.grpFornecedor = New Infragistics.Win.Misc.UltraGroupBox
        Me.grpRevisao = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtDataRevisao = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.optTipo = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.txtSaldo = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtValorAPagar = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtValorASolicitar = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Pesq_Fornecedor = New Logus.Pesq_CodigoNome
        Me.txtDescricao = New System.Windows.Forms.TextBox
        CType(Me.UltraGroupBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox5.SuspendLayout()
        CType(Me.grpValidade, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpValidade.SuspendLayout()
        CType(Me.txtDataValidade, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpGarantia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpGarantia.SuspendLayout()
        CType(Me.cboGarantia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpSolicitado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSolicitado.SuspendLayout()
        CType(Me.txtSolicitado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpFornecedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFornecedor.SuspendLayout()
        CType(Me.grpRevisao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpRevisao.SuspendLayout()
        CType(Me.txtDataRevisao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorAPagar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorASolicitar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox5
        '
        Me.UltraGroupBox5.Controls.Add(Me.txtDescricao)
        Me.UltraGroupBox5.Location = New System.Drawing.Point(8, 113)
        Me.UltraGroupBox5.Name = "UltraGroupBox5"
        Me.UltraGroupBox5.Size = New System.Drawing.Size(551, 232)
        Me.UltraGroupBox5.TabIndex = 271
        Me.UltraGroupBox5.Text = "Descrição"
        '
        'grpValidade
        '
        Me.grpValidade.Controls.Add(Me.txtDataValidade)
        Me.grpValidade.Location = New System.Drawing.Point(346, 57)
        Me.grpValidade.Name = "grpValidade"
        Me.grpValidade.Size = New System.Drawing.Size(104, 50)
        Me.grpValidade.TabIndex = 269
        Me.grpValidade.Text = "Validade"
        '
        'txtDataValidade
        '
        Me.txtDataValidade.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataValidade.Location = New System.Drawing.Point(8, 19)
        Me.txtDataValidade.Name = "txtDataValidade"
        Me.txtDataValidade.Size = New System.Drawing.Size(90, 23)
        Me.txtDataValidade.TabIndex = 219
        Me.txtDataValidade.Value = Nothing
        '
        'grpGarantia
        '
        Me.grpGarantia.Controls.Add(Me.cboGarantia)
        Me.grpGarantia.Location = New System.Drawing.Point(9, 59)
        Me.grpGarantia.Name = "grpGarantia"
        Me.grpGarantia.Size = New System.Drawing.Size(210, 48)
        Me.grpGarantia.TabIndex = 268
        Me.grpGarantia.Text = "Garantia"
        '
        'cboGarantia
        '
        Me.cboGarantia.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboGarantia.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.[Default]
        Me.cboGarantia.Location = New System.Drawing.Point(5, 17)
        Me.cboGarantia.Name = "cboGarantia"
        Me.cboGarantia.Size = New System.Drawing.Size(198, 22)
        Me.cboGarantia.TabIndex = 275
        Me.cboGarantia.Text = "UltraCombo1"
        '
        'grpSolicitado
        '
        Me.grpSolicitado.Controls.Add(Me.txtSolicitado)
        Me.grpSolicitado.Location = New System.Drawing.Point(222, 59)
        Me.grpSolicitado.Name = "grpSolicitado"
        Me.grpSolicitado.Size = New System.Drawing.Size(118, 48)
        Me.grpSolicitado.TabIndex = 267
        Me.grpSolicitado.Text = "Valor"
        '
        'txtSolicitado
        '
        Me.txtSolicitado.Location = New System.Drawing.Point(6, 19)
        Me.txtSolicitado.Name = "txtSolicitado"
        Me.txtSolicitado.Size = New System.Drawing.Size(106, 21)
        Me.txtSolicitado.TabIndex = 393
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(8, 351)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 266
        Me.cmdGravar.TabStop = False
        Me.cmdGravar.Text = "G"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(514, 351)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 265
        Me.cmdFechar.Text = "F"
        '
        'grpFornecedor
        '
        Me.grpFornecedor.Controls.Add(Me.Pesq_Fornecedor)
        Me.grpFornecedor.Location = New System.Drawing.Point(114, 3)
        Me.grpFornecedor.Name = "grpFornecedor"
        Me.grpFornecedor.Size = New System.Drawing.Size(445, 50)
        Me.grpFornecedor.TabIndex = 272
        Me.grpFornecedor.Text = "Fornecedor"
        '
        'grpRevisao
        '
        Me.grpRevisao.Controls.Add(Me.txtDataRevisao)
        Me.grpRevisao.Location = New System.Drawing.Point(456, 57)
        Me.grpRevisao.Name = "grpRevisao"
        Me.grpRevisao.Size = New System.Drawing.Size(104, 50)
        Me.grpRevisao.TabIndex = 273
        Me.grpRevisao.Text = "Revisão"
        '
        'txtDataRevisao
        '
        Me.txtDataRevisao.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataRevisao.Location = New System.Drawing.Point(7, 19)
        Me.txtDataRevisao.Name = "txtDataRevisao"
        Me.txtDataRevisao.Size = New System.Drawing.Size(90, 23)
        Me.txtDataRevisao.TabIndex = 219
        Me.txtDataRevisao.Value = Nothing
        '
        'optTipo
        '
        ValueListItem1.DataValue = "G"
        ValueListItem1.DisplayText = "Com Garantia"
        ValueListItem2.DataValue = "E"
        ValueListItem2.DisplayText = "Exceção"
        ValueListItem3.DataValue = "P"
        ValueListItem3.DisplayText = "Pré-Aprovação"
        Me.optTipo.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem3})
        Me.optTipo.Location = New System.Drawing.Point(8, 3)
        Me.optTipo.Name = "optTipo"
        Me.optTipo.Size = New System.Drawing.Size(100, 48)
        Me.optTipo.TabIndex = 274
        '
        'txtSaldo
        '
        Me.txtSaldo.Location = New System.Drawing.Point(59, 372)
        Me.txtSaldo.MaskInput = "{LOC}$ -n,nnn,nnn.nn"
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.ReadOnly = True
        Me.txtSaldo.Size = New System.Drawing.Size(103, 21)
        Me.txtSaldo.TabIndex = 276
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(59, 356)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 16)
        Me.Label7.TabIndex = 275
        Me.Label7.Text = "Saldo"
        '
        'txtValorAPagar
        '
        Me.txtValorAPagar.Location = New System.Drawing.Point(184, 372)
        Me.txtValorAPagar.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtValorAPagar.Name = "txtValorAPagar"
        Me.txtValorAPagar.Size = New System.Drawing.Size(103, 21)
        Me.txtValorAPagar.TabIndex = 278
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(184, 356)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 16)
        Me.Label1.TabIndex = 277
        Me.Label1.Text = "Valor a Pagar"
        '
        'txtValorASolicitar
        '
        Me.txtValorASolicitar.Location = New System.Drawing.Point(306, 372)
        Me.txtValorASolicitar.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtValorASolicitar.Name = "txtValorASolicitar"
        Me.txtValorASolicitar.ReadOnly = True
        Me.txtValorASolicitar.Size = New System.Drawing.Size(103, 21)
        Me.txtValorASolicitar.TabIndex = 280
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(306, 356)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 16)
        Me.Label2.TabIndex = 279
        Me.Label2.Text = "Valor a Solicitar"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(161, 372)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 24)
        Me.Label3.TabIndex = 281
        Me.Label3.Text = "-"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(285, 372)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 24)
        Me.Label4.TabIndex = 282
        Me.Label4.Text = "="
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
        Me.Pesq_Fornecedor.Location = New System.Drawing.Point(6, 19)
        Me.Pesq_Fornecedor.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_Fornecedor.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_Fornecedor.Name = "Pesq_Fornecedor"
        Me.Pesq_Fornecedor.Size = New System.Drawing.Size(427, 28)
        Me.Pesq_Fornecedor.TabIndex = 227
        Me.Pesq_Fornecedor.TelaFiltro = False
        Me.Pesq_Fornecedor.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'txtDescricao
        '
        Me.txtDescricao.Location = New System.Drawing.Point(6, 19)
        Me.txtDescricao.MaxLength = 4000
        Me.txtDescricao.Multiline = True
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(539, 207)
        Me.txtDescricao.TabIndex = 20
        '
        'frmCadastroSolicitacaoCredito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(567, 405)
        Me.Controls.Add(Me.txtValorASolicitar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtValorAPagar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSaldo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.optTipo)
        Me.Controls.Add(Me.grpRevisao)
        Me.Controls.Add(Me.grpFornecedor)
        Me.Controls.Add(Me.UltraGroupBox5)
        Me.Controls.Add(Me.grpValidade)
        Me.Controls.Add(Me.grpGarantia)
        Me.Controls.Add(Me.grpSolicitado)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCadastroSolicitacaoCredito"
        Me.Text = "Solicitação Crédito"
        CType(Me.UltraGroupBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox5.ResumeLayout(False)
        Me.UltraGroupBox5.PerformLayout()
        CType(Me.grpValidade, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpValidade.ResumeLayout(False)
        Me.grpValidade.PerformLayout()
        CType(Me.txtDataValidade, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpGarantia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpGarantia.ResumeLayout(False)
        Me.grpGarantia.PerformLayout()
        CType(Me.cboGarantia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpSolicitado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSolicitado.ResumeLayout(False)
        Me.grpSolicitado.PerformLayout()
        CType(Me.txtSolicitado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpFornecedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFornecedor.ResumeLayout(False)
        CType(Me.grpRevisao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpRevisao.ResumeLayout(False)
        Me.grpRevisao.PerformLayout()
        CType(Me.txtDataRevisao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSaldo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorAPagar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorASolicitar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UltraGroupBox5 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents grpValidade As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtDataValidade As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents grpGarantia As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents grpSolicitado As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents grpFornecedor As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Pesq_Fornecedor As Logus.Pesq_CodigoNome
    Friend WithEvents grpRevisao As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtDataRevisao As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents optTipo As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents cboGarantia As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents txtSaldo As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtValorAPagar As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtValorASolicitar As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSolicitado As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents txtDescricao As System.Windows.Forms.TextBox
End Class
