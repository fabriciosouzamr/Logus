<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSacaria_InclusaoFilial
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSacaria_InclusaoFilial))
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboTipoSacaria = New System.Windows.Forms.ComboBox
        Me.txtQuantidade = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtDocumento = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboEntradaSaida = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboFilialDebito = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.chkTransferencia = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboTipoMovimentacao = New System.Windows.Forms.ComboBox
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        CType(Me.txtQuantidade, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tipo de Sacaria"
        '
        'cboTipoSacaria
        '
        Me.cboTipoSacaria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoSacaria.FormattingEnabled = True
        Me.cboTipoSacaria.Location = New System.Drawing.Point(8, 20)
        Me.cboTipoSacaria.Name = "cboTipoSacaria"
        Me.cboTipoSacaria.Size = New System.Drawing.Size(150, 21)
        Me.cboTipoSacaria.TabIndex = 1
        '
        'txtQuantidade
        '
        Me.txtQuantidade.Location = New System.Drawing.Point(164, 20)
        Me.txtQuantidade.Name = "txtQuantidade"
        Me.txtQuantidade.Size = New System.Drawing.Size(70, 21)
        Me.txtQuantidade.TabIndex = 2
        '
        'txtDocumento
        '
        Me.txtDocumento.Location = New System.Drawing.Point(242, 20)
        Me.txtDocumento.MaxLength = 10
        Me.txtDocumento.Name = "txtDocumento"
        Me.txtDocumento.Size = New System.Drawing.Size(100, 20)
        Me.txtDocumento.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(164, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Quantidade"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(242, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Documento"
        '
        'cboEntradaSaida
        '
        Me.cboEntradaSaida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEntradaSaida.FormattingEnabled = True
        Me.cboEntradaSaida.Location = New System.Drawing.Point(8, 64)
        Me.cboEntradaSaida.Name = "cboEntradaSaida"
        Me.cboEntradaSaida.Size = New System.Drawing.Size(78, 21)
        Me.cboEntradaSaida.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Entrada/Saída"
        '
        'cboFilialDebito
        '
        Me.cboFilialDebito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilialDebito.FormattingEnabled = True
        Me.cboFilialDebito.Location = New System.Drawing.Point(191, 64)
        Me.cboFilialDebito.Name = "cboFilialDebito"
        Me.cboFilialDebito.Size = New System.Drawing.Size(151, 21)
        Me.cboFilialDebito.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(191, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Filial de Débito"
        '
        'chkTransferencia
        '
        Me.chkTransferencia.AutoSize = True
        Me.chkTransferencia.Location = New System.Drawing.Point(94, 66)
        Me.chkTransferencia.Name = "chkTransferencia"
        Me.chkTransferencia.Size = New System.Drawing.Size(91, 17)
        Me.chkTransferencia.TabIndex = 10
        Me.chkTransferencia.Text = "Transferência"
        Me.chkTransferencia.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Tipo de Movimentação"
        '
        'cboTipoMovimentacao
        '
        Me.cboTipoMovimentacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoMovimentacao.FormattingEnabled = True
        Me.cboTipoMovimentacao.Location = New System.Drawing.Point(8, 108)
        Me.cboTipoMovimentacao.Name = "cboTipoMovimentacao"
        Me.cboTipoMovimentacao.Size = New System.Drawing.Size(334, 21)
        Me.cboTipoMovimentacao.TabIndex = 12
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(8, 145)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 224
        Me.cmdGravar.TabStop = False
        Me.cmdGravar.Text = "G"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(297, 145)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 225
        Me.cmdFechar.Text = "F"
        '
        'frmSacaria_InclusaoFilial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(350, 196)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.cboTipoMovimentacao)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.chkTransferencia)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboFilialDebito)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboEntradaSaida)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDocumento)
        Me.Controls.Add(Me.txtQuantidade)
        Me.Controls.Add(Me.cboTipoSacaria)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmSacaria_InclusaoFilial"
        Me.Text = "Sacaria - Lançamento no Saldo da Filial"
        CType(Me.txtQuantidade, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboTipoSacaria As System.Windows.Forms.ComboBox
    Friend WithEvents txtQuantidade As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents txtDocumento As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboEntradaSaida As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboFilialDebito As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkTransferencia As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboTipoMovimentacao As System.Windows.Forms.ComboBox
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
End Class
