<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroOperacaoBancaria
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
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadastroOperacaoBancaria))
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtCentroCusto = New System.Windows.Forms.TextBox
        Me.txtContaContabil = New System.Windows.Forms.TextBox
        Me.optTipo = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtValorMaxCheque = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtDescricao = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkRD = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.Pesq_TipoMovimentacao = New Logus.Pesq_CodigoNome
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.grpDebito = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtSubAliquota2 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtValorSubAliquota2 = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtSubAliquota1 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtValorSubAliquota1 = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtAliquotaCheia = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtValorAliquotaCheia = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.chkEmiteCheque = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.chkAliquota = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.Label15 = New System.Windows.Forms.Label
        Me.cboFilial = New System.Windows.Forms.ComboBox
        Me.chkAtivo = New System.Windows.Forms.CheckBox
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.optTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorMaxCheque, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpDebito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDebito.SuspendLayout()
        CType(Me.txtValorSubAliquota2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorSubAliquota1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorAliquotaCheia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(2, 351)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 314
        Me.cmdGravar.TabStop = False
        Me.cmdGravar.Text = "G"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.txtCentroCusto)
        Me.UltraGroupBox1.Controls.Add(Me.txtContaContabil)
        Me.UltraGroupBox1.Controls.Add(Me.optTipo)
        Me.UltraGroupBox1.Controls.Add(Me.Label4)
        Me.UltraGroupBox1.Controls.Add(Me.Label5)
        Me.UltraGroupBox1.Controls.Add(Me.txtValorMaxCheque)
        Me.UltraGroupBox1.Controls.Add(Me.Label6)
        Me.UltraGroupBox1.Controls.Add(Me.lblCodigo)
        Me.UltraGroupBox1.Controls.Add(Me.Label3)
        Me.UltraGroupBox1.Controls.Add(Me.txtDescricao)
        Me.UltraGroupBox1.Controls.Add(Me.Label1)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(2, 3)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(445, 104)
        Me.UltraGroupBox1.TabIndex = 316
        '
        'txtCentroCusto
        '
        Me.txtCentroCusto.Location = New System.Drawing.Point(85, 74)
        Me.txtCentroCusto.MaxLength = 40
        Me.txtCentroCusto.Name = "txtCentroCusto"
        Me.txtCentroCusto.Size = New System.Drawing.Size(181, 20)
        Me.txtCentroCusto.TabIndex = 322
        '
        'txtContaContabil
        '
        Me.txtContaContabil.Location = New System.Drawing.Point(272, 74)
        Me.txtContaContabil.MaxLength = 40
        Me.txtContaContabil.Name = "txtContaContabil"
        Me.txtContaContabil.Size = New System.Drawing.Size(167, 20)
        Me.txtContaContabil.TabIndex = 320
        '
        'optTipo
        '
        Appearance13.TextHAlignAsString = "Center"
        Appearance13.TextVAlignAsString = "Middle"
        Me.optTipo.Appearance = Appearance13
        Me.optTipo.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance14.TextHAlignAsString = "Center"
        Appearance14.TextVAlignAsString = "Middle"
        Me.optTipo.ItemAppearance = Appearance14
        Me.optTipo.ItemOrigin = New System.Drawing.Point(4, 1)
        ValueListItem1.DataValue = "C"
        ValueListItem1.DisplayText = "Credito"
        ValueListItem2.DataValue = "D"
        ValueListItem2.DisplayText = "Debito"
        Me.optTipo.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2})
        Me.optTipo.ItemSpacingVertical = 2
        Me.optTipo.Location = New System.Drawing.Point(6, 57)
        Me.optTipo.Name = "optTipo"
        Me.optTipo.Size = New System.Drawing.Size(73, 37)
        Me.optTipo.TabIndex = 319
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(272, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 321
        Me.Label4.Text = "Conta Contabil"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(85, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 323
        Me.Label5.Text = "Centro de Custo"
        '
        'txtValorMaxCheque
        '
        Me.txtValorMaxCheque.Location = New System.Drawing.Point(322, 26)
        Me.txtValorMaxCheque.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtValorMaxCheque.Name = "txtValorMaxCheque"
        Me.txtValorMaxCheque.Size = New System.Drawing.Size(117, 21)
        Me.txtValorMaxCheque.TabIndex = 325
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(319, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 16)
        Me.Label6.TabIndex = 324
        Me.Label6.Text = "Valor Maximo Cheque"
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
        'txtDescricao
        '
        Me.txtDescricao.Location = New System.Drawing.Point(64, 26)
        Me.txtDescricao.MaxLength = 40
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(249, 20)
        Me.txtDescricao.TabIndex = 306
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
        'chkRD
        '
        Me.chkRD.Location = New System.Drawing.Point(21, 19)
        Me.chkRD.Name = "chkRD"
        Me.chkRD.Size = New System.Drawing.Size(91, 20)
        Me.chkRD.TabIndex = 310
        Me.chkRD.Text = "Lança no RD"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 13)
        Me.Label2.TabIndex = 309
        Me.Label2.Text = "Tipo de Movimentação RD"
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
        Me.Pesq_TipoMovimentacao.Location = New System.Drawing.Point(20, 57)
        Me.Pesq_TipoMovimentacao.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_TipoMovimentacao.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_TipoMovimentacao.Name = "Pesq_TipoMovimentacao"
        Me.Pesq_TipoMovimentacao.Size = New System.Drawing.Size(293, 28)
        Me.Pesq_TipoMovimentacao.TabIndex = 308
        Me.Pesq_TipoMovimentacao.TelaFiltro = False
        Me.Pesq_TipoMovimentacao.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Inicializar
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(402, 351)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 315
        Me.cmdFechar.Text = "F"
        '
        'grpDebito
        '
        Me.grpDebito.Controls.Add(Me.txtSubAliquota2)
        Me.grpDebito.Controls.Add(Me.Label9)
        Me.grpDebito.Controls.Add(Me.txtValorSubAliquota2)
        Me.grpDebito.Controls.Add(Me.txtSubAliquota1)
        Me.grpDebito.Controls.Add(Me.Label8)
        Me.grpDebito.Controls.Add(Me.txtValorSubAliquota1)
        Me.grpDebito.Controls.Add(Me.txtAliquotaCheia)
        Me.grpDebito.Controls.Add(Me.Label7)
        Me.grpDebito.Controls.Add(Me.txtValorAliquotaCheia)
        Me.grpDebito.Controls.Add(Me.chkEmiteCheque)
        Me.grpDebito.Controls.Add(Me.chkAliquota)
        Me.grpDebito.Controls.Add(Me.Label2)
        Me.grpDebito.Controls.Add(Me.chkRD)
        Me.grpDebito.Controls.Add(Me.Pesq_TipoMovimentacao)
        Me.grpDebito.Location = New System.Drawing.Point(2, 113)
        Me.grpDebito.Name = "grpDebito"
        Me.grpDebito.Size = New System.Drawing.Size(445, 188)
        Me.grpDebito.TabIndex = 317
        Me.grpDebito.Text = "Debito"
        '
        'txtSubAliquota2
        '
        Me.txtSubAliquota2.Location = New System.Drawing.Point(118, 157)
        Me.txtSubAliquota2.MaxLength = 40
        Me.txtSubAliquota2.Name = "txtSubAliquota2"
        Me.txtSubAliquota2.Size = New System.Drawing.Size(307, 20)
        Me.txtSubAliquota2.TabIndex = 327
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(22, 160)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(28, 13)
        Me.Label9.TabIndex = 326
        Me.Label9.Text = "Nº 2"
        '
        'txtValorSubAliquota2
        '
        Me.txtValorSubAliquota2.Location = New System.Drawing.Point(62, 157)
        Me.txtValorSubAliquota2.MaskInput = "{LOC}-nnn.nn"
        Me.txtValorSubAliquota2.Name = "txtValorSubAliquota2"
        Me.txtValorSubAliquota2.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtValorSubAliquota2.Size = New System.Drawing.Size(50, 21)
        Me.txtValorSubAliquota2.TabIndex = 325
        '
        'txtSubAliquota1
        '
        Me.txtSubAliquota1.Location = New System.Drawing.Point(118, 131)
        Me.txtSubAliquota1.MaxLength = 40
        Me.txtSubAliquota1.Name = "txtSubAliquota1"
        Me.txtSubAliquota1.Size = New System.Drawing.Size(307, 20)
        Me.txtSubAliquota1.TabIndex = 324
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(22, 134)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 13)
        Me.Label8.TabIndex = 323
        Me.Label8.Text = "Nº 1"
        '
        'txtValorSubAliquota1
        '
        Me.txtValorSubAliquota1.Location = New System.Drawing.Point(62, 131)
        Me.txtValorSubAliquota1.MaskInput = "{LOC}-nnn.nn"
        Me.txtValorSubAliquota1.Name = "txtValorSubAliquota1"
        Me.txtValorSubAliquota1.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtValorSubAliquota1.Size = New System.Drawing.Size(50, 21)
        Me.txtValorSubAliquota1.TabIndex = 322
        '
        'txtAliquotaCheia
        '
        Me.txtAliquotaCheia.Location = New System.Drawing.Point(118, 105)
        Me.txtAliquotaCheia.MaxLength = 40
        Me.txtAliquotaCheia.Name = "txtAliquotaCheia"
        Me.txtAliquotaCheia.Size = New System.Drawing.Size(307, 20)
        Me.txtAliquotaCheia.TabIndex = 321
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(22, 108)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 314
        Me.Label7.Text = "Cheio"
        '
        'txtValorAliquotaCheia
        '
        Me.txtValorAliquotaCheia.Location = New System.Drawing.Point(62, 105)
        Me.txtValorAliquotaCheia.MaskInput = "{LOC}-nnn.nn"
        Me.txtValorAliquotaCheia.Name = "txtValorAliquotaCheia"
        Me.txtValorAliquotaCheia.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtValorAliquotaCheia.Size = New System.Drawing.Size(50, 21)
        Me.txtValorAliquotaCheia.TabIndex = 313
        '
        'chkEmiteCheque
        '
        Me.chkEmiteCheque.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkEmiteCheque.Location = New System.Drawing.Point(319, 79)
        Me.chkEmiteCheque.Name = "chkEmiteCheque"
        Me.chkEmiteCheque.Size = New System.Drawing.Size(106, 20)
        Me.chkEmiteCheque.TabIndex = 312
        Me.chkEmiteCheque.Text = "Emite Cheque?"
        '
        'chkAliquota
        '
        Me.chkAliquota.Location = New System.Drawing.Point(21, 81)
        Me.chkAliquota.Name = "chkAliquota"
        Me.chkAliquota.Size = New System.Drawing.Size(69, 20)
        Me.chkAliquota.TabIndex = 311
        Me.chkAliquota.Text = "Alíquota"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(-1, 306)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(113, 13)
        Me.Label15.TabIndex = 324
        Me.Label15.Text = "Filial de Debito Default"
        '
        'cboFilial
        '
        Me.cboFilial.Location = New System.Drawing.Point(2, 322)
        Me.cboFilial.Name = "cboFilial"
        Me.cboFilial.Size = New System.Drawing.Size(194, 21)
        Me.cboFilial.TabIndex = 323
        '
        'chkAtivo
        '
        Me.chkAtivo.AutoSize = True
        Me.chkAtivo.Location = New System.Drawing.Point(204, 326)
        Me.chkAtivo.Name = "chkAtivo"
        Me.chkAtivo.Size = New System.Drawing.Size(50, 17)
        Me.chkAtivo.TabIndex = 325
        Me.chkAtivo.Text = "Ativo"
        Me.chkAtivo.UseVisualStyleBackColor = True
        '
        'frmCadastroOperacaoBancaria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(453, 399)
        Me.Controls.Add(Me.chkAtivo)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cboFilial)
        Me.Controls.Add(Me.grpDebito)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.cmdFechar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCadastroOperacaoBancaria"
        Me.Text = "Cadastro Operação Bancaria"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.optTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorMaxCheque, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpDebito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDebito.ResumeLayout(False)
        Me.grpDebito.PerformLayout()
        CType(Me.txtValorSubAliquota2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorSubAliquota1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorAliquotaCheia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkRD As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents txtDescricao As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Pesq_TipoMovimentacao As Logus.Pesq_CodigoNome
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents grpDebito As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents optTipo As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents txtContaContabil As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCentroCusto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtValorMaxCheque As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkEmiteCheque As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkAliquota As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents txtSubAliquota2 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtValorSubAliquota2 As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents txtSubAliquota1 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtValorSubAliquota1 As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents txtAliquotaCheia As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtValorAliquotaCheia As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboFilial As System.Windows.Forms.ComboBox
    Friend WithEvents chkAtivo As System.Windows.Forms.CheckBox
End Class
