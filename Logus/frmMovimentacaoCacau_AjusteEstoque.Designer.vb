<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMovimentacaoCacau_AjusteEstoque
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMovimentacaoCacau_AjusteEstoque))
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.txtAjuste = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblNF = New System.Windows.Forms.Label
        Me.lblOrigem_Pilha = New System.Windows.Forms.Label
        Me.lblOrigem_Armazem = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblSaldo = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblSaldoFinal = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtJustificativa = New System.Windows.Forms.TextBox
        CType(Me.txtAjuste, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(9, 152)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 266
        Me.cmdGravar.Text = "G"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(428, 152)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 265
        Me.cmdFechar.Text = "F"
        '
        'txtAjuste
        '
        Me.txtAjuste.Location = New System.Drawing.Point(347, 53)
        Me.txtAjuste.MaskInput = "-nnnn"
        Me.txtAjuste.Name = "txtAjuste"
        Me.txtAjuste.Size = New System.Drawing.Size(60, 21)
        Me.txtAjuste.TabIndex = 264
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Location = New System.Drawing.Point(9, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(464, 18)
        Me.Label3.TabIndex = 256
        Me.Label3.Text = "Movimentação"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNF
        '
        Me.lblNF.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNF.Location = New System.Drawing.Point(215, 54)
        Me.lblNF.Name = "lblNF"
        Me.lblNF.Size = New System.Drawing.Size(60, 20)
        Me.lblNF.TabIndex = 253
        Me.lblNF.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOrigem_Pilha
        '
        Me.lblOrigem_Pilha.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOrigem_Pilha.Location = New System.Drawing.Point(147, 54)
        Me.lblOrigem_Pilha.Name = "lblOrigem_Pilha"
        Me.lblOrigem_Pilha.Size = New System.Drawing.Size(60, 20)
        Me.lblOrigem_Pilha.TabIndex = 252
        Me.lblOrigem_Pilha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOrigem_Armazem
        '
        Me.lblOrigem_Armazem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOrigem_Armazem.Location = New System.Drawing.Point(9, 54)
        Me.lblOrigem_Armazem.Name = "lblOrigem_Armazem"
        Me.lblOrigem_Armazem.Size = New System.Drawing.Size(130, 20)
        Me.lblOrigem_Armazem.TabIndex = 251
        Me.lblOrigem_Armazem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(347, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 261
        Me.Label7.Text = "Ajuste"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(215, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 13)
        Me.Label2.TabIndex = 255
        Me.Label2.Text = "NF"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(147, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 254
        Me.Label1.Text = "Pilha"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(9, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 257
        Me.Label4.Text = "Armazém"
        '
        'lblSaldo
        '
        Me.lblSaldo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSaldo.Location = New System.Drawing.Point(281, 54)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(60, 20)
        Me.lblSaldo.TabIndex = 267
        Me.lblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(281, 39)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 13)
        Me.Label10.TabIndex = 268
        Me.Label10.Text = "Saldo"
        '
        'lblSaldoFinal
        '
        Me.lblSaldoFinal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSaldoFinal.Location = New System.Drawing.Point(413, 53)
        Me.lblSaldoFinal.Name = "lblSaldoFinal"
        Me.lblSaldoFinal.Size = New System.Drawing.Size(60, 20)
        Me.lblSaldoFinal.TabIndex = 269
        Me.lblSaldoFinal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(413, 38)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 13)
        Me.Label12.TabIndex = 270
        Me.Label12.Text = "Saldo Final"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(9, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 271
        Me.Label5.Text = "Justificativa"
        '
        'txtJustificativa
        '
        Me.txtJustificativa.Location = New System.Drawing.Point(9, 99)
        Me.txtJustificativa.Multiline = True
        Me.txtJustificativa.Name = "txtJustificativa"
        Me.txtJustificativa.Size = New System.Drawing.Size(464, 47)
        Me.txtJustificativa.TabIndex = 272
        '
        'frmMovimentacaoCacau_AjusteEstoque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(480, 204)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtJustificativa)
        Me.Controls.Add(Me.lblSaldoFinal)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.lblSaldo)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.txtAjuste)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblNF)
        Me.Controls.Add(Me.lblOrigem_Pilha)
        Me.Controls.Add(Me.lblOrigem_Armazem)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMovimentacaoCacau_AjusteEstoque"
        Me.Text = "Ajuste Estoque"
        CType(Me.txtAjuste, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtAjuste As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblNF As System.Windows.Forms.Label
    Friend WithEvents lblOrigem_Pilha As System.Windows.Forms.Label
    Friend WithEvents lblOrigem_Armazem As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblSaldo As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblSaldoFinal As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtJustificativa As System.Windows.Forms.TextBox
End Class
