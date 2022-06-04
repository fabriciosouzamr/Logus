<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroArmazem_Pilha
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtNomeArmazem = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lstPilhas = New System.Windows.Forms.ListBox
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.lblR_Pilha = New System.Windows.Forms.Label
        Me.txtPilha = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.lblR_QtdeSacos = New System.Windows.Forms.Label
        Me.txtSacos = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.cmdNovo = New Infragistics.Win.Misc.UltraButton
        Me.lblR_TipoPilha = New System.Windows.Forms.Label
        Me.cboTipoPilha = New System.Windows.Forms.ComboBox
        Me.chkAtivo = New System.Windows.Forms.CheckBox
        Me.grpPilhaMae = New System.Windows.Forms.GroupBox
        Me.lblNomePilha = New System.Windows.Forms.Label
        Me.lblR_NomePilha = New System.Windows.Forms.Label
        Me.cboPilhaMae = New System.Windows.Forms.ComboBox
        Me.cmdExcluir = New Infragistics.Win.Misc.UltraButton
        Me.chkPilhaMae = New System.Windows.Forms.CheckBox
        CType(Me.txtPilha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSacos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpPilhaMae.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nome do Armazém"
        '
        'txtNomeArmazem
        '
        Me.txtNomeArmazem.Location = New System.Drawing.Point(8, 22)
        Me.txtNomeArmazem.MaxLength = 10
        Me.txtNomeArmazem.Name = "txtNomeArmazem"
        Me.txtNomeArmazem.ReadOnly = True
        Me.txtNomeArmazem.Size = New System.Drawing.Size(200, 20)
        Me.txtNomeArmazem.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Listagem de Pilhas"
        '
        'lstPilhas
        '
        Me.lstPilhas.FormattingEnabled = True
        Me.lstPilhas.Location = New System.Drawing.Point(8, 64)
        Me.lstPilhas.Name = "lstPilhas"
        Me.lstPilhas.Size = New System.Drawing.Size(200, 316)
        Me.lstPilhas.TabIndex = 2
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(417, 392)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 377
        Me.cmdFechar.Text = "F"
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(269, 335)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 378
        Me.cmdGravar.TabStop = False
        Me.cmdGravar.Text = "G"
        '
        'lblR_Pilha
        '
        Me.lblR_Pilha.AutoSize = True
        Me.lblR_Pilha.Location = New System.Drawing.Point(216, 50)
        Me.lblR_Pilha.Name = "lblR_Pilha"
        Me.lblR_Pilha.Size = New System.Drawing.Size(30, 13)
        Me.lblR_Pilha.TabIndex = 379
        Me.lblR_Pilha.Text = "Pilha"
        '
        'txtPilha
        '
        Me.txtPilha.Location = New System.Drawing.Point(216, 64)
        Me.txtPilha.MaskInput = "nnnnn"
        Me.txtPilha.MaxValue = 99999
        Me.txtPilha.MinValue = 1
        Me.txtPilha.Name = "txtPilha"
        Me.txtPilha.Size = New System.Drawing.Size(59, 21)
        Me.txtPilha.TabIndex = 380
        '
        'lblR_QtdeSacos
        '
        Me.lblR_QtdeSacos.AutoSize = True
        Me.lblR_QtdeSacos.Location = New System.Drawing.Point(283, 50)
        Me.lblR_QtdeSacos.Name = "lblR_QtdeSacos"
        Me.lblR_QtdeSacos.Size = New System.Drawing.Size(81, 13)
        Me.lblR_QtdeSacos.TabIndex = 379
        Me.lblR_QtdeSacos.Text = "Qtde. de Sacos"
        '
        'txtSacos
        '
        Me.txtSacos.Location = New System.Drawing.Point(283, 64)
        Me.txtSacos.MaskInput = "nnnnn"
        Me.txtSacos.MaxValue = 99999
        Me.txtSacos.MinValue = 0
        Me.txtSacos.Name = "txtSacos"
        Me.txtSacos.Size = New System.Drawing.Size(81, 21)
        Me.txtSacos.TabIndex = 380
        '
        'cmdNovo
        '
        Me.cmdNovo.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdNovo.Location = New System.Drawing.Point(216, 335)
        Me.cmdNovo.Name = "cmdNovo"
        Me.cmdNovo.Size = New System.Drawing.Size(45, 45)
        Me.cmdNovo.TabIndex = 378
        Me.cmdNovo.TabStop = False
        Me.cmdNovo.Text = "N"
        '
        'lblR_TipoPilha
        '
        Me.lblR_TipoPilha.AutoSize = True
        Me.lblR_TipoPilha.Location = New System.Drawing.Point(216, 93)
        Me.lblR_TipoPilha.Name = "lblR_TipoPilha"
        Me.lblR_TipoPilha.Size = New System.Drawing.Size(69, 13)
        Me.lblR_TipoPilha.TabIndex = 379
        Me.lblR_TipoPilha.Text = "Tipo da Pilha"
        '
        'cboTipoPilha
        '
        Me.cboTipoPilha.FormattingEnabled = True
        Me.cboTipoPilha.Location = New System.Drawing.Point(216, 107)
        Me.cboTipoPilha.Name = "cboTipoPilha"
        Me.cboTipoPilha.Size = New System.Drawing.Size(243, 21)
        Me.cboTipoPilha.TabIndex = 381
        '
        'chkAtivo
        '
        Me.chkAtivo.AutoSize = True
        Me.chkAtivo.Location = New System.Drawing.Point(372, 66)
        Me.chkAtivo.Name = "chkAtivo"
        Me.chkAtivo.Size = New System.Drawing.Size(50, 17)
        Me.chkAtivo.TabIndex = 382
        Me.chkAtivo.Text = "Ativo"
        Me.chkAtivo.UseVisualStyleBackColor = True
        '
        'grpPilhaMae
        '
        Me.grpPilhaMae.Controls.Add(Me.lblNomePilha)
        Me.grpPilhaMae.Controls.Add(Me.lblR_NomePilha)
        Me.grpPilhaMae.Controls.Add(Me.cboPilhaMae)
        Me.grpPilhaMae.Location = New System.Drawing.Point(216, 134)
        Me.grpPilhaMae.Name = "grpPilhaMae"
        Me.grpPilhaMae.Size = New System.Drawing.Size(243, 47)
        Me.grpPilhaMae.TabIndex = 383
        Me.grpPilhaMae.TabStop = False
        Me.grpPilhaMae.Text = "      Pilha Mãe"
        '
        'lblNomePilha
        '
        Me.lblNomePilha.AutoSize = True
        Me.lblNomePilha.Location = New System.Drawing.Point(134, 26)
        Me.lblNomePilha.Name = "lblNomePilha"
        Me.lblNomePilha.Size = New System.Drawing.Size(68, 13)
        Me.lblNomePilha.TabIndex = 383
        Me.lblNomePilha.Text = "lblNomePilha"
        '
        'lblR_NomePilha
        '
        Me.lblR_NomePilha.AutoSize = True
        Me.lblR_NomePilha.Location = New System.Drawing.Point(134, 14)
        Me.lblR_NomePilha.Name = "lblR_NomePilha"
        Me.lblR_NomePilha.Size = New System.Drawing.Size(76, 13)
        Me.lblR_NomePilha.TabIndex = 383
        Me.lblR_NomePilha.Text = "Nome da Pilha"
        '
        'cboPilhaMae
        '
        Me.cboPilhaMae.FormattingEnabled = True
        Me.cboPilhaMae.Location = New System.Drawing.Point(8, 18)
        Me.cboPilhaMae.Name = "cboPilhaMae"
        Me.cboPilhaMae.Size = New System.Drawing.Size(118, 21)
        Me.cboPilhaMae.TabIndex = 381
        '
        'cmdExcluir
        '
        Me.cmdExcluir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExcluir.Location = New System.Drawing.Point(322, 335)
        Me.cmdExcluir.Name = "cmdExcluir"
        Me.cmdExcluir.Size = New System.Drawing.Size(45, 45)
        Me.cmdExcluir.TabIndex = 378
        Me.cmdExcluir.TabStop = False
        Me.cmdExcluir.Text = "E"
        '
        'chkPilhaMae
        '
        Me.chkPilhaMae.AutoSize = True
        Me.chkPilhaMae.Location = New System.Drawing.Point(225, 133)
        Me.chkPilhaMae.Name = "chkPilhaMae"
        Me.chkPilhaMae.Size = New System.Drawing.Size(15, 14)
        Me.chkPilhaMae.TabIndex = 384
        Me.chkPilhaMae.UseVisualStyleBackColor = True
        '
        'frmCadastroArmazem_Pilha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(471, 444)
        Me.Controls.Add(Me.chkPilhaMae)
        Me.Controls.Add(Me.grpPilhaMae)
        Me.Controls.Add(Me.chkAtivo)
        Me.Controls.Add(Me.cboTipoPilha)
        Me.Controls.Add(Me.txtSacos)
        Me.Controls.Add(Me.txtPilha)
        Me.Controls.Add(Me.lblR_QtdeSacos)
        Me.Controls.Add(Me.lblR_TipoPilha)
        Me.Controls.Add(Me.lblR_Pilha)
        Me.Controls.Add(Me.cmdNovo)
        Me.Controls.Add(Me.cmdExcluir)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.lstPilhas)
        Me.Controls.Add(Me.txtNomeArmazem)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmCadastroArmazem_Pilha"
        Me.Text = "Cadastro de Armazém - Pilha"
        CType(Me.txtPilha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSacos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPilhaMae.ResumeLayout(False)
        Me.grpPilhaMae.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNomeArmazem As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lstPilhas As System.Windows.Forms.ListBox
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblR_Pilha As System.Windows.Forms.Label
    Friend WithEvents txtPilha As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents lblR_QtdeSacos As System.Windows.Forms.Label
    Friend WithEvents txtSacos As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents cmdNovo As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblR_TipoPilha As System.Windows.Forms.Label
    Friend WithEvents cboTipoPilha As System.Windows.Forms.ComboBox
    Friend WithEvents chkAtivo As System.Windows.Forms.CheckBox
    Friend WithEvents grpPilhaMae As System.Windows.Forms.GroupBox
    Friend WithEvents cboPilhaMae As System.Windows.Forms.ComboBox
    Friend WithEvents lblR_NomePilha As System.Windows.Forms.Label
    Friend WithEvents lblNomePilha As System.Windows.Forms.Label
    Friend WithEvents cmdExcluir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents chkPilhaMae As System.Windows.Forms.CheckBox
End Class
