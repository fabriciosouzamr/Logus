<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMovimentacaoCacau_AjusteSacaria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMovimentacaoCacau_AjusteSacaria))
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtJustificativa = New System.Windows.Forms.TextBox
        Me.lblSaldoFinal = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.lblSaldo = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
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
        Me.lblSacos = New System.Windows.Forms.Label
        Me.lblTipoSacaria = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        CType(Me.txtAjuste, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(11, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 288
        Me.Label5.Text = "Justificativa"
        '
        'txtJustificativa
        '
        Me.txtJustificativa.Location = New System.Drawing.Point(11, 142)
        Me.txtJustificativa.Multiline = True
        Me.txtJustificativa.Name = "txtJustificativa"
        Me.txtJustificativa.Size = New System.Drawing.Size(333, 47)
        Me.txtJustificativa.TabIndex = 289
        '
        'lblSaldoFinal
        '
        Me.lblSaldoFinal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSaldoFinal.Location = New System.Drawing.Point(284, 98)
        Me.lblSaldoFinal.Name = "lblSaldoFinal"
        Me.lblSaldoFinal.Size = New System.Drawing.Size(60, 20)
        Me.lblSaldoFinal.TabIndex = 286
        Me.lblSaldoFinal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(284, 83)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 13)
        Me.Label12.TabIndex = 287
        Me.Label12.Text = "Saldo Final"
        '
        'lblSaldo
        '
        Me.lblSaldo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSaldo.Location = New System.Drawing.Point(284, 50)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(60, 20)
        Me.lblSaldo.TabIndex = 284
        Me.lblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(284, 35)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 13)
        Me.Label10.TabIndex = 285
        Me.Label10.Text = "Saldo"
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(11, 195)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 283
        Me.cmdGravar.Text = "G"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(299, 195)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 282
        Me.cmdFechar.Text = "F"
        '
        'txtAjuste
        '
        Me.txtAjuste.Location = New System.Drawing.Point(218, 98)
        Me.txtAjuste.MaskInput = "-nnnn"
        Me.txtAjuste.Name = "txtAjuste"
        Me.txtAjuste.Size = New System.Drawing.Size(60, 21)
        Me.txtAjuste.TabIndex = 281
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(332, 18)
        Me.Label3.TabIndex = 278
        Me.Label3.Text = "Movimentação Sacaria"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNF
        '
        Me.lblNF.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNF.Location = New System.Drawing.Point(218, 50)
        Me.lblNF.Name = "lblNF"
        Me.lblNF.Size = New System.Drawing.Size(60, 20)
        Me.lblNF.TabIndex = 275
        Me.lblNF.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOrigem_Pilha
        '
        Me.lblOrigem_Pilha.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOrigem_Pilha.Location = New System.Drawing.Point(150, 50)
        Me.lblOrigem_Pilha.Name = "lblOrigem_Pilha"
        Me.lblOrigem_Pilha.Size = New System.Drawing.Size(60, 20)
        Me.lblOrigem_Pilha.TabIndex = 274
        Me.lblOrigem_Pilha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOrigem_Armazem
        '
        Me.lblOrigem_Armazem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOrigem_Armazem.Location = New System.Drawing.Point(12, 50)
        Me.lblOrigem_Armazem.Name = "lblOrigem_Armazem"
        Me.lblOrigem_Armazem.Size = New System.Drawing.Size(130, 20)
        Me.lblOrigem_Armazem.TabIndex = 273
        Me.lblOrigem_Armazem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(218, 83)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 280
        Me.Label7.Text = "Ajuste"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(218, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 13)
        Me.Label2.TabIndex = 277
        Me.Label2.Text = "NF"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(150, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 276
        Me.Label1.Text = "Pilha"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(12, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 279
        Me.Label4.Text = "Armazém"
        '
        'lblSacos
        '
        Me.lblSacos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSacos.Location = New System.Drawing.Point(149, 99)
        Me.lblSacos.Name = "lblSacos"
        Me.lblSacos.Size = New System.Drawing.Size(60, 20)
        Me.lblSacos.TabIndex = 291
        Me.lblSacos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTipoSacaria
        '
        Me.lblTipoSacaria.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTipoSacaria.Location = New System.Drawing.Point(11, 99)
        Me.lblTipoSacaria.Name = "lblTipoSacaria"
        Me.lblTipoSacaria.Size = New System.Drawing.Size(130, 20)
        Me.lblTipoSacaria.TabIndex = 290
        Me.lblTipoSacaria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(149, 84)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 13)
        Me.Label9.TabIndex = 292
        Me.Label9.Text = "Sacos"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(11, 84)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 13)
        Me.Label11.TabIndex = 293
        Me.Label11.Text = "Tipo Sacaria"
        '
        'frmMovimentacaoCacau_AjusteSacaria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(353, 245)
        Me.Controls.Add(Me.lblSacos)
        Me.Controls.Add(Me.lblTipoSacaria)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label11)
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
        Me.Name = "frmMovimentacaoCacau_AjusteSacaria"
        Me.Text = "Ajuste Sacaria"
        CType(Me.txtAjuste, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtJustificativa As System.Windows.Forms.TextBox
    Friend WithEvents lblSaldoFinal As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblSaldo As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
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
    Friend WithEvents lblSacos As System.Windows.Forms.Label
    Friend WithEvents lblTipoSacaria As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
