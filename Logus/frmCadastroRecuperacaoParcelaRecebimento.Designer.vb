<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroRecuperacaoParcelaRecebimento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadastroRecuperacaoParcelaRecebimento))
        Me.txtValorParcela = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.txtDataPagamento = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtQuantidadeParcela = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtDescricaoOutros = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.optForma = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.lblDataPagamento = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboNegociacao = New System.Windows.Forms.ComboBox
        Me.cboContratoFixo = New System.Windows.Forms.ComboBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.cboContratoPAF = New System.Windows.Forms.ComboBox
        CType(Me.txtValorParcela, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataPagamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantidadeParcela, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optForma, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtValorParcela
        '
        Me.txtValorParcela.Location = New System.Drawing.Point(352, 28)
        Me.txtValorParcela.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtValorParcela.Name = "txtValorParcela"
        Me.txtValorParcela.Size = New System.Drawing.Size(80, 21)
        Me.txtValorParcela.TabIndex = 268
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(489, 127)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 267
        Me.cmdFechar.Text = "F"
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(4, 127)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 266
        Me.cmdGravar.TabStop = False
        Me.cmdGravar.Text = "G"
        '
        'txtDataPagamento
        '
        Me.txtDataPagamento.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataPagamento.Location = New System.Drawing.Point(438, 27)
        Me.txtDataPagamento.Name = "txtDataPagamento"
        Me.txtDataPagamento.Size = New System.Drawing.Size(96, 23)
        Me.txtDataPagamento.TabIndex = 264
        Me.txtDataPagamento.Value = Nothing
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(275, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 16)
        Me.Label2.TabIndex = 262
        Me.Label2.Text = "Quantidade"
        '
        'txtQuantidadeParcela
        '
        Me.txtQuantidadeParcela.Location = New System.Drawing.Point(278, 28)
        Me.txtQuantidadeParcela.MaskInput = "{LOC}-nnnnnnnn"
        Me.txtQuantidadeParcela.Name = "txtQuantidadeParcela"
        Me.txtQuantidadeParcela.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtQuantidadeParcela.Size = New System.Drawing.Size(68, 21)
        Me.txtQuantidadeParcela.TabIndex = 261
        '
        'txtDescricaoOutros
        '
        Me.txtDescricaoOutros.Location = New System.Drawing.Point(4, 70)
        Me.txtDescricaoOutros.Multiline = True
        Me.txtDescricaoOutros.Name = "txtDescricaoOutros"
        Me.txtDescricaoOutros.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescricaoOutros.Size = New System.Drawing.Size(530, 51)
        Me.txtDescricaoOutros.TabIndex = 259
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(0, 54)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(199, 13)
        Me.Label10.TabIndex = 260
        Me.Label10.Text = "Descrição Recebimento Saldo Contratos"
        '
        'optForma
        '
        ValueListItem1.DataValue = "C"
        ValueListItem1.DisplayText = "Cacau"
        ValueListItem2.DataValue = "D"
        ValueListItem2.DisplayText = "Dinheiro"
        ValueListItem3.DataValue = "O"
        ValueListItem3.DisplayText = "Saldo CTR"
        Me.optForma.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem3})
        Me.optForma.Location = New System.Drawing.Point(3, 5)
        Me.optForma.Name = "optForma"
        Me.optForma.Size = New System.Drawing.Size(78, 46)
        Me.optForma.TabIndex = 258
        '
        'lblDataPagamento
        '
        Me.lblDataPagamento.BackColor = System.Drawing.Color.Transparent
        Me.lblDataPagamento.Location = New System.Drawing.Point(435, 12)
        Me.lblDataPagamento.Name = "lblDataPagamento"
        Me.lblDataPagamento.Size = New System.Drawing.Size(99, 16)
        Me.lblDataPagamento.TabIndex = 265
        Me.lblDataPagamento.Text = "Data Pagamento"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(353, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 16)
        Me.Label4.TabIndex = 263
        Me.Label4.Text = "Valor"
        '
        'cboNegociacao
        '
        Me.cboNegociacao.Location = New System.Drawing.Point(191, 29)
        Me.cboNegociacao.Name = "cboNegociacao"
        Me.cboNegociacao.Size = New System.Drawing.Size(38, 21)
        Me.cboNegociacao.TabIndex = 272
        '
        'cboContratoFixo
        '
        Me.cboContratoFixo.Location = New System.Drawing.Point(235, 29)
        Me.cboContratoFixo.Name = "cboContratoFixo"
        Me.cboContratoFixo.Size = New System.Drawing.Size(37, 21)
        Me.cboContratoFixo.TabIndex = 271
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Location = New System.Drawing.Point(84, 15)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(113, 16)
        Me.Label20.TabIndex = 269
        Me.Label20.Text = "Contrato"
        '
        'cboContratoPAF
        '
        Me.cboContratoPAF.Location = New System.Drawing.Point(87, 29)
        Me.cboContratoPAF.Name = "cboContratoPAF"
        Me.cboContratoPAF.Size = New System.Drawing.Size(98, 21)
        Me.cboContratoPAF.TabIndex = 273
        '
        'frmCadastroRecuperacaoParcelaRecebimento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(538, 175)
        Me.Controls.Add(Me.cboContratoPAF)
        Me.Controls.Add(Me.cboNegociacao)
        Me.Controls.Add(Me.cboContratoFixo)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtValorParcela)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.txtDataPagamento)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtQuantidadeParcela)
        Me.Controls.Add(Me.txtDescricaoOutros)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.optForma)
        Me.Controls.Add(Me.lblDataPagamento)
        Me.Controls.Add(Me.Label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCadastroRecuperacaoParcelaRecebimento"
        Me.Text = "Recebimento de Parcela"
        CType(Me.txtValorParcela, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataPagamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantidadeParcela, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optForma, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtValorParcela As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtDataPagamento As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtQuantidadeParcela As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents txtDescricaoOutros As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents optForma As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents lblDataPagamento As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboNegociacao As System.Windows.Forms.ComboBox
    Friend WithEvents cboContratoFixo As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cboContratoPAF As System.Windows.Forms.ComboBox
End Class
