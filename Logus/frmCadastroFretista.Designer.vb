<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroFretista
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadastroFretista))
        Me.cboTipoFretista = New System.Windows.Forms.ComboBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.txtNome = New System.Windows.Forms.TextBox
        Me.optTipoPessoa = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtCPF_CNPJ = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.txtINSS = New System.Windows.Forms.TextBox
        Me.lblR_INSS = New System.Windows.Forms.Label
        Me.txtFavorecido = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPIS = New System.Windows.Forms.TextBox
        Me.lblR_PIS = New System.Windows.Forms.Label
        Me.cboTipoCobranca = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtAddressNumber = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtValorFrete = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.lblR_ValorFrete = New System.Windows.Forms.Label
        Me.txtValorDespesa = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.lblR_ValorDespesa = New System.Windows.Forms.Label
        Me.txtPercentualDespesa = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.lblR_PercentualDespesa = New System.Windows.Forms.Label
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.txtDependentes = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.optTipoPessoa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAddressNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorFrete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorDespesa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPercentualDespesa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDependentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboTipoFretista
        '
        Me.cboTipoFretista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoFretista.Location = New System.Drawing.Point(5, 21)
        Me.cboTipoFretista.Name = "cboTipoFretista"
        Me.cboTipoFretista.Size = New System.Drawing.Size(120, 21)
        Me.cboTipoFretista.TabIndex = 0
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Location = New System.Drawing.Point(2, 7)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(65, 13)
        Me.Label31.TabIndex = 240
        Me.Label31.Text = "Tipo Fretista"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Location = New System.Drawing.Point(4, 51)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(66, 13)
        Me.Label24.TabIndex = 239
        Me.Label24.Text = "Tipo Pessoa"
        '
        'txtNome
        '
        Me.txtNome.Location = New System.Drawing.Point(134, 22)
        Me.txtNome.MaxLength = 40
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(376, 20)
        Me.txtNome.TabIndex = 1
        '
        'optTipoPessoa
        '
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        Me.optTipoPessoa.Appearance = Appearance1
        Me.optTipoPessoa.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.optTipoPessoa.CheckedIndex = 0
        Appearance2.TextHAlignAsString = "Center"
        Appearance2.TextVAlignAsString = "Middle"
        Me.optTipoPessoa.ItemAppearance = Appearance2
        Me.optTipoPessoa.ItemOrigin = New System.Drawing.Point(2, 2)
        ValueListItem1.DataValue = "F"
        ValueListItem1.DisplayText = "Física"
        ValueListItem2.DataValue = "J"
        ValueListItem2.DisplayText = "Jurídica"
        Me.optTipoPessoa.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2})
        Me.optTipoPessoa.Location = New System.Drawing.Point(5, 66)
        Me.optTipoPessoa.Name = "optTipoPessoa"
        Me.optTipoPessoa.Size = New System.Drawing.Size(120, 20)
        Me.optTipoPessoa.TabIndex = 2
        Me.optTipoPessoa.Text = "Física"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(131, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 238
        Me.Label3.Text = "Nome"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Location = New System.Drawing.Point(134, 51)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(59, 13)
        Me.Label23.TabIndex = 237
        Me.Label23.Text = "CPF\CNPJ"
        '
        'txtCPF_CNPJ
        '
        Me.txtCPF_CNPJ.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.txtCPF_CNPJ.InputMask = "##.###.###/####-##"
        Me.txtCPF_CNPJ.Location = New System.Drawing.Point(134, 66)
        Me.txtCPF_CNPJ.Name = "txtCPF_CNPJ"
        Me.txtCPF_CNPJ.Size = New System.Drawing.Size(114, 20)
        Me.txtCPF_CNPJ.TabIndex = 3
        Me.txtCPF_CNPJ.Text = "../-"
        '
        'txtINSS
        '
        Me.txtINSS.Location = New System.Drawing.Point(254, 66)
        Me.txtINSS.MaxLength = 11
        Me.txtINSS.Name = "txtINSS"
        Me.txtINSS.Size = New System.Drawing.Size(119, 20)
        Me.txtINSS.TabIndex = 4
        '
        'lblR_INSS
        '
        Me.lblR_INSS.AutoSize = True
        Me.lblR_INSS.BackColor = System.Drawing.Color.Transparent
        Me.lblR_INSS.Location = New System.Drawing.Point(251, 51)
        Me.lblR_INSS.Name = "lblR_INSS"
        Me.lblR_INSS.Size = New System.Drawing.Size(78, 13)
        Me.lblR_INSS.TabIndex = 242
        Me.lblR_INSS.Text = "Inscrição INSS"
        '
        'txtFavorecido
        '
        Me.txtFavorecido.Location = New System.Drawing.Point(134, 110)
        Me.txtFavorecido.MaxLength = 40
        Me.txtFavorecido.Name = "txtFavorecido"
        Me.txtFavorecido.Size = New System.Drawing.Size(296, 20)
        Me.txtFavorecido.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(131, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 244
        Me.Label2.Text = "Favorecido"
        '
        'txtPIS
        '
        Me.txtPIS.Location = New System.Drawing.Point(379, 66)
        Me.txtPIS.MaxLength = 11
        Me.txtPIS.Name = "txtPIS"
        Me.txtPIS.Size = New System.Drawing.Size(131, 20)
        Me.txtPIS.TabIndex = 5
        '
        'lblR_PIS
        '
        Me.lblR_PIS.AutoSize = True
        Me.lblR_PIS.BackColor = System.Drawing.Color.Transparent
        Me.lblR_PIS.Location = New System.Drawing.Point(376, 50)
        Me.lblR_PIS.Name = "lblR_PIS"
        Me.lblR_PIS.Size = New System.Drawing.Size(110, 13)
        Me.lblR_PIS.TabIndex = 246
        Me.lblR_PIS.Text = "Inscrição PIS/PASEP"
        '
        'cboTipoCobranca
        '
        Me.cboTipoCobranca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoCobranca.Location = New System.Drawing.Point(5, 164)
        Me.cboTipoCobranca.Name = "cboTipoCobranca"
        Me.cboTipoCobranca.Size = New System.Drawing.Size(163, 21)
        Me.cboTipoCobranca.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(5, 148)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(134, 13)
        Me.Label5.TabIndex = 248
        Me.Label5.Text = "Tipo de Cobrança do Frete"
        '
        'txtAddressNumber
        '
        Me.txtAddressNumber.Location = New System.Drawing.Point(5, 109)
        Me.txtAddressNumber.MaxValue = 99999999
        Me.txtAddressNumber.MinValue = 0
        Me.txtAddressNumber.Name = "txtAddressNumber"
        Me.txtAddressNumber.Nullable = True
        Me.txtAddressNumber.Size = New System.Drawing.Size(120, 21)
        Me.txtAddressNumber.TabIndex = 6
        Me.txtAddressNumber.Value = Nothing
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(5, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 13)
        Me.Label6.TabIndex = 250
        Me.Label6.Text = "Address Number"
        '
        'txtValorFrete
        '
        Me.txtValorFrete.Location = New System.Drawing.Point(174, 164)
        Me.txtValorFrete.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtValorFrete.Name = "txtValorFrete"
        Me.txtValorFrete.Size = New System.Drawing.Size(109, 21)
        Me.txtValorFrete.TabIndex = 10
        '
        'lblR_ValorFrete
        '
        Me.lblR_ValorFrete.AutoSize = True
        Me.lblR_ValorFrete.BackColor = System.Drawing.Color.Transparent
        Me.lblR_ValorFrete.Location = New System.Drawing.Point(171, 149)
        Me.lblR_ValorFrete.Name = "lblR_ValorFrete"
        Me.lblR_ValorFrete.Size = New System.Drawing.Size(73, 13)
        Me.lblR_ValorFrete.TabIndex = 259
        Me.lblR_ValorFrete.Text = "Valor do Frete"
        '
        'txtValorDespesa
        '
        Me.txtValorDespesa.Location = New System.Drawing.Point(286, 164)
        Me.txtValorDespesa.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtValorDespesa.Name = "txtValorDespesa"
        Me.txtValorDespesa.Size = New System.Drawing.Size(109, 21)
        Me.txtValorDespesa.TabIndex = 11
        '
        'lblR_ValorDespesa
        '
        Me.lblR_ValorDespesa.AutoSize = True
        Me.lblR_ValorDespesa.BackColor = System.Drawing.Color.Transparent
        Me.lblR_ValorDespesa.Location = New System.Drawing.Point(283, 149)
        Me.lblR_ValorDespesa.Name = "lblR_ValorDespesa"
        Me.lblR_ValorDespesa.Size = New System.Drawing.Size(91, 13)
        Me.lblR_ValorDespesa.TabIndex = 261
        Me.lblR_ValorDespesa.Text = "Valor de Despesa"
        '
        'txtPercentualDespesa
        '
        Me.txtPercentualDespesa.Location = New System.Drawing.Point(401, 164)
        Me.txtPercentualDespesa.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtPercentualDespesa.Name = "txtPercentualDespesa"
        Me.txtPercentualDespesa.Size = New System.Drawing.Size(109, 21)
        Me.txtPercentualDespesa.TabIndex = 12
        '
        'lblR_PercentualDespesa
        '
        Me.lblR_PercentualDespesa.AutoSize = True
        Me.lblR_PercentualDespesa.BackColor = System.Drawing.Color.Transparent
        Me.lblR_PercentualDespesa.Location = New System.Drawing.Point(398, 149)
        Me.lblR_PercentualDespesa.Name = "lblR_PercentualDespesa"
        Me.lblR_PercentualDespesa.Size = New System.Drawing.Size(75, 13)
        Me.lblR_PercentualDespesa.TabIndex = 263
        Me.lblR_PercentualDespesa.Text = "% de Despesa"
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(5, 191)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 13
        Me.cmdGravar.TabStop = False
        Me.cmdGravar.Text = "G"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(465, 191)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 14
        Me.cmdFechar.Text = "F"
        '
        'txtDependentes
        '
        Me.txtDependentes.Location = New System.Drawing.Point(436, 109)
        Me.txtDependentes.MaxValue = 99
        Me.txtDependentes.MinValue = 0
        Me.txtDependentes.Name = "txtDependentes"
        Me.txtDependentes.Size = New System.Drawing.Size(74, 21)
        Me.txtDependentes.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(433, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 268
        Me.Label1.Text = "Dependentes"
        '
        'frmCadastroFretista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(516, 240)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDependentes)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.txtPercentualDespesa)
        Me.Controls.Add(Me.lblR_PercentualDespesa)
        Me.Controls.Add(Me.txtValorDespesa)
        Me.Controls.Add(Me.lblR_ValorDespesa)
        Me.Controls.Add(Me.txtValorFrete)
        Me.Controls.Add(Me.lblR_ValorFrete)
        Me.Controls.Add(Me.txtAddressNumber)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cboTipoCobranca)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPIS)
        Me.Controls.Add(Me.lblR_PIS)
        Me.Controls.Add(Me.txtFavorecido)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtINSS)
        Me.Controls.Add(Me.lblR_INSS)
        Me.Controls.Add(Me.cboTipoFretista)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txtNome)
        Me.Controls.Add(Me.optTipoPessoa)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.txtCPF_CNPJ)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCadastroFretista"
        Me.Text = "Cadastro Fretista"
        CType(Me.optTipoPessoa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAddressNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorFrete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorDespesa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPercentualDespesa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDependentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboTipoFretista As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtNome As System.Windows.Forms.TextBox
    Friend WithEvents optTipoPessoa As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtCPF_CNPJ As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents txtINSS As System.Windows.Forms.TextBox
    Friend WithEvents lblR_INSS As System.Windows.Forms.Label
    Friend WithEvents txtFavorecido As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPIS As System.Windows.Forms.TextBox
    Friend WithEvents lblR_PIS As System.Windows.Forms.Label
    Friend WithEvents cboTipoCobranca As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAddressNumber As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtValorFrete As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents lblR_ValorFrete As System.Windows.Forms.Label
    Friend WithEvents txtValorDespesa As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents lblR_ValorDespesa As System.Windows.Forms.Label
    Friend WithEvents txtPercentualDespesa As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents lblR_PercentualDespesa As System.Windows.Forms.Label
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtDependentes As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
