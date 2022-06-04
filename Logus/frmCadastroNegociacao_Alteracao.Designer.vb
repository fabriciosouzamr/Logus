<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroNegociacao_Alteracao
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
        Me.txtQuantidade = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.lblR_Quantidade = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDataEntrega = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtDataFixacao = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.cboBolsa = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.txtValorUnitarioNegociacao = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.txtAliquotaICMS = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Label7 = New System.Windows.Forms.Label
        CType(Me.txtQuantidade, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataEntrega, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataFixacao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboBolsa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorUnitarioNegociacao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAliquotaICMS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtQuantidade
        '
        Me.txtQuantidade.Location = New System.Drawing.Point(232, 22)
        Me.txtQuantidade.MaskInput = "{LOC}-nnnn,nnn"
        Me.txtQuantidade.Name = "txtQuantidade"
        Me.txtQuantidade.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtQuantidade.Size = New System.Drawing.Size(80, 21)
        Me.txtQuantidade.TabIndex = 312
        '
        'lblR_Quantidade
        '
        Me.lblR_Quantidade.AutoSize = True
        Me.lblR_Quantidade.BackColor = System.Drawing.Color.Transparent
        Me.lblR_Quantidade.Location = New System.Drawing.Point(236, 8)
        Me.lblR_Quantidade.Name = "lblR_Quantidade"
        Me.lblR_Quantidade.Size = New System.Drawing.Size(62, 13)
        Me.lblR_Quantidade.TabIndex = 313
        Me.lblR_Quantidade.Text = "Quantidade"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(120, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 311
        Me.Label5.Text = "Data de Entrega"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 310
        Me.Label4.Text = "Data de Fixação"
        '
        'txtDataEntrega
        '
        Me.txtDataEntrega.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtDataEntrega.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataEntrega.Location = New System.Drawing.Point(120, 22)
        Me.txtDataEntrega.Name = "txtDataEntrega"
        Me.txtDataEntrega.Size = New System.Drawing.Size(104, 23)
        Me.txtDataEntrega.TabIndex = 308
        Me.txtDataEntrega.Value = Nothing
        '
        'txtDataFixacao
        '
        Me.txtDataFixacao.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtDataFixacao.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataFixacao.Location = New System.Drawing.Point(8, 22)
        Me.txtDataFixacao.Name = "txtDataFixacao"
        Me.txtDataFixacao.Size = New System.Drawing.Size(104, 23)
        Me.txtDataFixacao.TabIndex = 309
        Me.txtDataFixacao.Value = Nothing
        '
        'cboBolsa
        '
        Me.cboBolsa.CheckedListSettings.CheckStateMember = ""
        Me.cboBolsa.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cboBolsa.Location = New System.Drawing.Point(119, 67)
        Me.cboBolsa.Name = "cboBolsa"
        Me.cboBolsa.PreferredDropDownSize = New System.Drawing.Size(0, 0)
        Me.cboBolsa.Size = New System.Drawing.Size(146, 22)
        Me.cboBolsa.TabIndex = 345
        '
        'txtValorUnitarioNegociacao
        '
        Me.txtValorUnitarioNegociacao.Location = New System.Drawing.Point(8, 67)
        Me.txtValorUnitarioNegociacao.MaskInput = "{currency:-9.2}"
        Me.txtValorUnitarioNegociacao.Name = "txtValorUnitarioNegociacao"
        Me.txtValorUnitarioNegociacao.Size = New System.Drawing.Size(103, 21)
        Me.txtValorUnitarioNegociacao.TabIndex = 342
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(8, 53)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 13)
        Me.Label17.TabIndex = 343
        Me.Label17.Text = "Valor Unitário"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Location = New System.Drawing.Point(119, 53)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(33, 13)
        Me.Label26.TabIndex = 344
        Me.Label26.Text = "Bolsa"
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(8, 149)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 346
        Me.cmdGravar.Text = "G"
        '
        'cmdFechar
        '
        Me.cmdFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(383, 149)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 347
        Me.cmdFechar.Text = "F"
        '
        'txtAliquotaICMS
        '
        Me.txtAliquotaICMS.Location = New System.Drawing.Point(320, 22)
        Me.txtAliquotaICMS.MaskInput = "{LOC}-n.nnnn"
        Me.txtAliquotaICMS.Name = "txtAliquotaICMS"
        Me.txtAliquotaICMS.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtAliquotaICMS.Size = New System.Drawing.Size(109, 21)
        Me.txtAliquotaICMS.TabIndex = 374
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(320, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 13)
        Me.Label7.TabIndex = 375
        Me.Label7.Text = "Aliquota ICMS%"
        '
        'frmCadastroNegociacao_Alteracao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(436, 202)
        Me.Controls.Add(Me.txtAliquotaICMS)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cboBolsa)
        Me.Controls.Add(Me.txtValorUnitarioNegociacao)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.txtQuantidade)
        Me.Controls.Add(Me.lblR_Quantidade)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDataEntrega)
        Me.Controls.Add(Me.txtDataFixacao)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmCadastroNegociacao_Alteracao"
        Me.Text = " Negociação - Alteração"
        CType(Me.txtQuantidade, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataEntrega, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataFixacao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboBolsa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorUnitarioNegociacao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAliquotaICMS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtQuantidade As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents lblR_Quantidade As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDataEntrega As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtDataFixacao As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents cboBolsa As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents txtValorUnitarioNegociacao As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtAliquotaICMS As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
