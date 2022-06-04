<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroModalidadeConciliacao
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadastroModalidadeConciliacao))
        Me.chkPagamento = New System.Windows.Forms.CheckBox
        Me.grpPagamento = New Infragistics.Win.Misc.UltraGroupBox
        Me.chkPagamentoDebito = New System.Windows.Forms.CheckBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtPagamentoDebito = New System.Windows.Forms.TextBox
        Me.chkPagamentoCredito = New System.Windows.Forms.CheckBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtPagamentoCredito = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.txtDescricao = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.optTipoFilial = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.grpMovimentacao = New Infragistics.Win.Misc.UltraGroupBox
        Me.chkMovimentacaoDebito = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtMovimentacaoDebito = New System.Windows.Forms.TextBox
        Me.chkMovimentacaoCredito = New System.Windows.Forms.CheckBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtMovimentacaoCredito = New System.Windows.Forms.TextBox
        Me.chkMovimentacao = New System.Windows.Forms.CheckBox
        Me.grdLancaRD = New Infragistics.Win.Misc.UltraGroupBox
        Me.cboFilial = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Pesq_TipoMovimentacao = New Logus.Pesq_CodigoNome
        Me.chkLancaRD = New System.Windows.Forms.CheckBox
        Me.chkValorBruto = New System.Windows.Forms.CheckBox
        Me.chkAtivo = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        CType(Me.grpPagamento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpPagamento.SuspendLayout()
        CType(Me.optTipoFilial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpMovimentacao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMovimentacao.SuspendLayout()
        CType(Me.grdLancaRD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grdLancaRD.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkPagamento
        '
        Me.chkPagamento.AutoSize = True
        Me.chkPagamento.Location = New System.Drawing.Point(12, 60)
        Me.chkPagamento.Name = "chkPagamento"
        Me.chkPagamento.Size = New System.Drawing.Size(77, 17)
        Me.chkPagamento.TabIndex = 6
        Me.chkPagamento.Text = "Contabiliza"
        Me.chkPagamento.UseVisualStyleBackColor = True
        '
        'grpPagamento
        '
        Me.grpPagamento.Controls.Add(Me.chkPagamentoDebito)
        Me.grpPagamento.Controls.Add(Me.Label7)
        Me.grpPagamento.Controls.Add(Me.txtPagamentoDebito)
        Me.grpPagamento.Controls.Add(Me.chkPagamentoCredito)
        Me.grpPagamento.Controls.Add(Me.Label8)
        Me.grpPagamento.Controls.Add(Me.txtPagamentoCredito)
        Me.grpPagamento.Location = New System.Drawing.Point(6, 83)
        Me.grpPagamento.Name = "grpPagamento"
        Me.grpPagamento.Size = New System.Drawing.Size(270, 102)
        Me.grpPagamento.TabIndex = 7
        Me.grpPagamento.Text = "Aplicação Pagamento"
        '
        'chkPagamentoDebito
        '
        Me.chkPagamentoDebito.Location = New System.Drawing.Point(6, 58)
        Me.chkPagamentoDebito.Name = "chkPagamentoDebito"
        Me.chkPagamentoDebito.Size = New System.Drawing.Size(55, 36)
        Me.chkPagamentoDebito.TabIndex = 13
        Me.chkPagamentoDebito.Text = "Muda Filial"
        Me.chkPagamentoDebito.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(61, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Débito"
        '
        'txtPagamentoDebito
        '
        Me.txtPagamentoDebito.Location = New System.Drawing.Point(64, 74)
        Me.txtPagamentoDebito.Name = "txtPagamentoDebito"
        Me.txtPagamentoDebito.Size = New System.Drawing.Size(191, 20)
        Me.txtPagamentoDebito.TabIndex = 15
        '
        'chkPagamentoCredito
        '
        Me.chkPagamentoCredito.Location = New System.Drawing.Point(6, 15)
        Me.chkPagamentoCredito.Name = "chkPagamentoCredito"
        Me.chkPagamentoCredito.Size = New System.Drawing.Size(55, 36)
        Me.chkPagamentoCredito.TabIndex = 1
        Me.chkPagamentoCredito.Text = "Muda Filial"
        Me.chkPagamentoCredito.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(61, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Crédito"
        '
        'txtPagamentoCredito
        '
        Me.txtPagamentoCredito.Location = New System.Drawing.Point(64, 31)
        Me.txtPagamentoCredito.Name = "txtPagamentoCredito"
        Me.txtPagamentoCredito.Size = New System.Drawing.Size(191, 20)
        Me.txtPagamentoCredito.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(6, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 314
        Me.Label2.Text = "Número"
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(6, 330)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 317
        Me.cmdGravar.TabStop = False
        Me.cmdGravar.Text = "G"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(67, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 316
        Me.Label4.Text = "Descrição"
        '
        'lblCodigo
        '
        Me.lblCodigo.BackColor = System.Drawing.Color.Black
        Me.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lblCodigo.Location = New System.Drawing.Point(9, 24)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(52, 23)
        Me.lblCodigo.TabIndex = 313
        Me.lblCodigo.Text = "NOVO"
        Me.lblCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(507, 330)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 318
        Me.cmdFechar.Text = "F"
        '
        'txtDescricao
        '
        Me.txtDescricao.Location = New System.Drawing.Point(67, 27)
        Me.txtDescricao.MaxLength = 40
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(485, 20)
        Me.txtDescricao.TabIndex = 315
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 13)
        Me.Label5.TabIndex = 320
        Me.Label5.Text = "Tipo de Movimentação"
        '
        'optTipoFilial
        '
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        Me.optTipoFilial.Appearance = Appearance1
        Me.optTipoFilial.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance2.TextHAlignAsString = "Center"
        Appearance2.TextVAlignAsString = "Middle"
        Me.optTipoFilial.ItemAppearance = Appearance2
        Me.optTipoFilial.ItemOrigin = New System.Drawing.Point(2, 2)
        ValueListItem1.DataValue = "C"
        ValueListItem1.DisplayText = "Conciliação"
        ValueListItem2.DataValue = "F"
        ValueListItem2.DisplayText = "Fixa"
        ValueListItem3.DataValue = "M"
        ValueListItem3.DisplayText = "Movimentação"
        Me.optTipoFilial.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem3})
        Me.optTipoFilial.Location = New System.Drawing.Point(10, 54)
        Me.optTipoFilial.Name = "optTipoFilial"
        Me.optTipoFilial.Size = New System.Drawing.Size(106, 49)
        Me.optTipoFilial.TabIndex = 321
        '
        'grpMovimentacao
        '
        Me.grpMovimentacao.Controls.Add(Me.chkMovimentacaoDebito)
        Me.grpMovimentacao.Controls.Add(Me.Label6)
        Me.grpMovimentacao.Controls.Add(Me.txtMovimentacaoDebito)
        Me.grpMovimentacao.Controls.Add(Me.chkMovimentacaoCredito)
        Me.grpMovimentacao.Controls.Add(Me.Label9)
        Me.grpMovimentacao.Controls.Add(Me.txtMovimentacaoCredito)
        Me.grpMovimentacao.Location = New System.Drawing.Point(282, 83)
        Me.grpMovimentacao.Name = "grpMovimentacao"
        Me.grpMovimentacao.Size = New System.Drawing.Size(270, 102)
        Me.grpMovimentacao.TabIndex = 322
        Me.grpMovimentacao.Text = "Aplicação Movimentação"
        '
        'chkMovimentacaoDebito
        '
        Me.chkMovimentacaoDebito.Location = New System.Drawing.Point(6, 58)
        Me.chkMovimentacaoDebito.Name = "chkMovimentacaoDebito"
        Me.chkMovimentacaoDebito.Size = New System.Drawing.Size(55, 36)
        Me.chkMovimentacaoDebito.TabIndex = 13
        Me.chkMovimentacaoDebito.Text = "Muda Filial"
        Me.chkMovimentacaoDebito.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(64, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Débito"
        '
        'txtMovimentacaoDebito
        '
        Me.txtMovimentacaoDebito.Location = New System.Drawing.Point(67, 74)
        Me.txtMovimentacaoDebito.Name = "txtMovimentacaoDebito"
        Me.txtMovimentacaoDebito.Size = New System.Drawing.Size(191, 20)
        Me.txtMovimentacaoDebito.TabIndex = 15
        '
        'chkMovimentacaoCredito
        '
        Me.chkMovimentacaoCredito.Location = New System.Drawing.Point(6, 15)
        Me.chkMovimentacaoCredito.Name = "chkMovimentacaoCredito"
        Me.chkMovimentacaoCredito.Size = New System.Drawing.Size(55, 36)
        Me.chkMovimentacaoCredito.TabIndex = 1
        Me.chkMovimentacaoCredito.Text = "Muda Filial"
        Me.chkMovimentacaoCredito.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(64, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Crédito"
        '
        'txtMovimentacaoCredito
        '
        Me.txtMovimentacaoCredito.Location = New System.Drawing.Point(67, 31)
        Me.txtMovimentacaoCredito.Name = "txtMovimentacaoCredito"
        Me.txtMovimentacaoCredito.Size = New System.Drawing.Size(191, 20)
        Me.txtMovimentacaoCredito.TabIndex = 12
        '
        'chkMovimentacao
        '
        Me.chkMovimentacao.AutoSize = True
        Me.chkMovimentacao.Location = New System.Drawing.Point(282, 60)
        Me.chkMovimentacao.Name = "chkMovimentacao"
        Me.chkMovimentacao.Size = New System.Drawing.Size(77, 17)
        Me.chkMovimentacao.TabIndex = 6
        Me.chkMovimentacao.Text = "Contabiliza"
        Me.chkMovimentacao.UseVisualStyleBackColor = True
        '
        'grdLancaRD
        '
        Me.grdLancaRD.Controls.Add(Me.cboFilial)
        Me.grdLancaRD.Controls.Add(Me.Label1)
        Me.grdLancaRD.Controls.Add(Me.Pesq_TipoMovimentacao)
        Me.grdLancaRD.Controls.Add(Me.Label5)
        Me.grdLancaRD.Controls.Add(Me.optTipoFilial)
        Me.grdLancaRD.Location = New System.Drawing.Point(6, 214)
        Me.grdLancaRD.Name = "grdLancaRD"
        Me.grdLancaRD.Size = New System.Drawing.Size(546, 110)
        Me.grdLancaRD.TabIndex = 323
        '
        'cboFilial
        '
        Me.cboFilial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilial.Location = New System.Drawing.Point(132, 82)
        Me.cboFilial.Name = "cboFilial"
        Me.cboFilial.Size = New System.Drawing.Size(189, 21)
        Me.cboFilial.TabIndex = 322
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(132, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 323
        Me.Label1.Text = "Filial Fixa"
        '
        'Pesq_TipoMovimentacao
        '
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_Codigo = Nothing
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_Descricao = Nothing
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_TipoMovimentacao.BancoDados_Tabela = Nothing
        Me.Pesq_TipoMovimentacao.Codigo = 0
        Me.Pesq_TipoMovimentacao.ExibirCodigo = True
        Me.Pesq_TipoMovimentacao.Location = New System.Drawing.Point(6, 20)
        Me.Pesq_TipoMovimentacao.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_TipoMovimentacao.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_TipoMovimentacao.Name = "Pesq_TipoMovimentacao"
        Me.Pesq_TipoMovimentacao.Size = New System.Drawing.Size(315, 28)
        Me.Pesq_TipoMovimentacao.TabIndex = 319
        Me.Pesq_TipoMovimentacao.TelaFiltro = False
        Me.Pesq_TipoMovimentacao.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Inicializar
        '
        'chkLancaRD
        '
        Me.chkLancaRD.AutoSize = True
        Me.chkLancaRD.Location = New System.Drawing.Point(12, 191)
        Me.chkLancaRD.Name = "chkLancaRD"
        Me.chkLancaRD.Size = New System.Drawing.Size(75, 17)
        Me.chkLancaRD.TabIndex = 324
        Me.chkLancaRD.Text = "Lança RD"
        Me.chkLancaRD.UseVisualStyleBackColor = True
        '
        'chkValorBruto
        '
        Me.chkValorBruto.AutoSize = True
        Me.chkValorBruto.Location = New System.Drawing.Point(365, 60)
        Me.chkValorBruto.Name = "chkValorBruto"
        Me.chkValorBruto.Size = New System.Drawing.Size(78, 17)
        Me.chkValorBruto.TabIndex = 325
        Me.chkValorBruto.Text = "Valor Bruto"
        Me.chkValorBruto.UseVisualStyleBackColor = True
        '
        'chkAtivo
        '
        Me.chkAtivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAtivo.Location = New System.Drawing.Point(488, 191)
        Me.chkAtivo.Name = "chkAtivo"
        Me.chkAtivo.Size = New System.Drawing.Size(58, 20)
        Me.chkAtivo.TabIndex = 324
        Me.chkAtivo.Text = "Ativo"
        '
        'frmCadastroModalidadeConciliacao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 383)
        Me.Controls.Add(Me.chkAtivo)
        Me.Controls.Add(Me.chkValorBruto)
        Me.Controls.Add(Me.chkLancaRD)
        Me.Controls.Add(Me.grdLancaRD)
        Me.Controls.Add(Me.grpMovimentacao)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.chkMovimentacao)
        Me.Controls.Add(Me.chkPagamento)
        Me.Controls.Add(Me.lblCodigo)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.txtDescricao)
        Me.Controls.Add(Me.grpPagamento)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCadastroModalidadeConciliacao"
        Me.Text = "Cadastro Modalidade Conciliação"
        CType(Me.grpPagamento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPagamento.ResumeLayout(False)
        Me.grpPagamento.PerformLayout()
        CType(Me.optTipoFilial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpMovimentacao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMovimentacao.ResumeLayout(False)
        Me.grpMovimentacao.PerformLayout()
        CType(Me.grdLancaRD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grdLancaRD.ResumeLayout(False)
        Me.grdLancaRD.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkPagamento As System.Windows.Forms.CheckBox
    Friend WithEvents grpPagamento As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents chkPagamentoDebito As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPagamentoDebito As System.Windows.Forms.TextBox
    Friend WithEvents chkPagamentoCredito As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPagamentoCredito As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtDescricao As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Pesq_TipoMovimentacao As Logus.Pesq_CodigoNome
    Friend WithEvents optTipoFilial As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents grpMovimentacao As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents chkMovimentacaoDebito As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtMovimentacaoDebito As System.Windows.Forms.TextBox
    Friend WithEvents chkMovimentacaoCredito As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtMovimentacaoCredito As System.Windows.Forms.TextBox
    Friend WithEvents chkMovimentacao As System.Windows.Forms.CheckBox
    Friend WithEvents grdLancaRD As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents chkLancaRD As System.Windows.Forms.CheckBox
    Friend WithEvents cboFilial As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkValorBruto As System.Windows.Forms.CheckBox
    Friend WithEvents chkAtivo As Infragistics.Win.UltraWinEditors.UltraCheckEditor
End Class
