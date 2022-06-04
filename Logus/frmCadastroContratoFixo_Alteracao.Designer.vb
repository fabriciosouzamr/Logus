<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroContratoFixo_Alteracao
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
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cboBolsa = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.txtValorUnitario = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.txtQuantidade = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.lblR_Quantidade = New System.Windows.Forms.Label
        Me.txtValorINSS = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtAliquotaICMS = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtValorTotal = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.txtValorICMS = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        CType(Me.cboBolsa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorUnitario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantidade, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorINSS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAliquotaICMS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorICMS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(8, 180)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 348
        Me.cmdGravar.Text = "G"
        '
        'cmdFechar
        '
        Me.cmdFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(247, 180)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 349
        Me.cmdFechar.Text = "F"
        '
        'cboBolsa
        '
        Me.cboBolsa.CheckedListSettings.CheckStateMember = ""
        Me.cboBolsa.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cboBolsa.Location = New System.Drawing.Point(146, 112)
        Me.cboBolsa.Name = "cboBolsa"
        Me.cboBolsa.PreferredDropDownSize = New System.Drawing.Size(0, 0)
        Me.cboBolsa.Size = New System.Drawing.Size(146, 22)
        Me.cboBolsa.TabIndex = 359
        Me.cboBolsa.Visible = False
        '
        'txtValorUnitario
        '
        Me.txtValorUnitario.Location = New System.Drawing.Point(146, 64)
        Me.txtValorUnitario.MaskInput = "{currency:-9.2}"
        Me.txtValorUnitario.Name = "txtValorUnitario"
        Me.txtValorUnitario.Size = New System.Drawing.Size(103, 21)
        Me.txtValorUnitario.TabIndex = 356
        Me.txtValorUnitario.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(146, 50)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 13)
        Me.Label17.TabIndex = 357
        Me.Label17.Text = "Valor Unitário"
        Me.Label17.Visible = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Location = New System.Drawing.Point(146, 98)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(33, 13)
        Me.Label26.TabIndex = 358
        Me.Label26.Text = "Bolsa"
        Me.Label26.Visible = False
        '
        'txtQuantidade
        '
        Me.txtQuantidade.Location = New System.Drawing.Point(146, 20)
        Me.txtQuantidade.MaskInput = "{LOC}-nnnn,nnn"
        Me.txtQuantidade.Name = "txtQuantidade"
        Me.txtQuantidade.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtQuantidade.Size = New System.Drawing.Size(80, 21)
        Me.txtQuantidade.TabIndex = 354
        '
        'lblR_Quantidade
        '
        Me.lblR_Quantidade.AutoSize = True
        Me.lblR_Quantidade.BackColor = System.Drawing.Color.Transparent
        Me.lblR_Quantidade.Location = New System.Drawing.Point(146, 6)
        Me.lblR_Quantidade.Name = "lblR_Quantidade"
        Me.lblR_Quantidade.Size = New System.Drawing.Size(62, 13)
        Me.lblR_Quantidade.TabIndex = 355
        Me.lblR_Quantidade.Text = "Quantidade"
        '
        'txtValorINSS
        '
        Me.txtValorINSS.Location = New System.Drawing.Point(8, 151)
        Me.txtValorINSS.Name = "txtValorINSS"
        Me.txtValorINSS.ReadOnly = True
        Me.txtValorINSS.Size = New System.Drawing.Size(109, 21)
        Me.txtValorINSS.TabIndex = 375
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(8, 137)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 374
        Me.Label1.Text = "Valor INSS"
        '
        'txtAliquotaICMS
        '
        Me.txtAliquotaICMS.Location = New System.Drawing.Point(8, 22)
        Me.txtAliquotaICMS.MaskInput = "{LOC}-nn.nnnn"
        Me.txtAliquotaICMS.Name = "txtAliquotaICMS"
        Me.txtAliquotaICMS.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtAliquotaICMS.Size = New System.Drawing.Size(109, 21)
        Me.txtAliquotaICMS.TabIndex = 372
        '
        'txtValorTotal
        '
        Me.txtValorTotal.Location = New System.Drawing.Point(8, 65)
        Me.txtValorTotal.Name = "txtValorTotal"
        Me.txtValorTotal.ReadOnly = True
        Me.txtValorTotal.Size = New System.Drawing.Size(109, 21)
        Me.txtValorTotal.TabIndex = 371
        '
        'txtValorICMS
        '
        Me.txtValorICMS.Location = New System.Drawing.Point(8, 108)
        Me.txtValorICMS.Name = "txtValorICMS"
        Me.txtValorICMS.ReadOnly = True
        Me.txtValorICMS.Size = New System.Drawing.Size(109, 21)
        Me.txtValorICMS.TabIndex = 369
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(8, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 13)
        Me.Label7.TabIndex = 373
        Me.Label7.Text = "Aliquota ICMS%"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Location = New System.Drawing.Point(8, 51)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(58, 13)
        Me.Label20.TabIndex = 370
        Me.Label20.Text = "Valor Total"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Location = New System.Drawing.Point(8, 94)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(60, 13)
        Me.Label18.TabIndex = 368
        Me.Label18.Text = "Valor ICMS"
        '
        'frmCadastroContratoFixo_Alteracao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(299, 231)
        Me.Controls.Add(Me.txtValorINSS)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtAliquotaICMS)
        Me.Controls.Add(Me.txtValorTotal)
        Me.Controls.Add(Me.txtValorICMS)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.cboBolsa)
        Me.Controls.Add(Me.txtValorUnitario)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.txtQuantidade)
        Me.Controls.Add(Me.lblR_Quantidade)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.cmdFechar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmCadastroContratoFixo_Alteracao"
        Me.Text = " Cadastro de Contrato Fixo  - Alteração"
        CType(Me.cboBolsa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorUnitario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantidade, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorINSS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAliquotaICMS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorICMS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cboBolsa As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents txtValorUnitario As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtQuantidade As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents lblR_Quantidade As System.Windows.Forms.Label
    Friend WithEvents txtValorINSS As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAliquotaICMS As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents txtValorTotal As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents txtValorICMS As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
End Class
