<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroArmazem
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.cboFilial = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtNome = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtCapacidade = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.chkArmazemInterno = New System.Windows.Forms.CheckBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.lstModalidadeTransferencia = New System.Windows.Forms.CheckedListBox
        Me.chkAtivo = New System.Windows.Forms.CheckBox
        Me.cmdPilha = New Infragistics.Win.Misc.UltraButton
        CType(Me.txtCapacidade, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código"
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(8, 22)
        Me.txtCodigo.MaxLength = 5
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(65, 20)
        Me.txtCodigo.TabIndex = 1
        '
        'cboFilial
        '
        Me.cboFilial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilial.FormattingEnabled = True
        Me.cboFilial.Location = New System.Drawing.Point(81, 22)
        Me.cboFilial.Name = "cboFilial"
        Me.cboFilial.Size = New System.Drawing.Size(150, 21)
        Me.cboFilial.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(239, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nome"
        '
        'txtNome
        '
        Me.txtNome.Location = New System.Drawing.Point(239, 22)
        Me.txtNome.MaxLength = 10
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(223, 20)
        Me.txtNome.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(81, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Filial de Origem"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Capacidade (Ton.)"
        '
        'txtCapacidade
        '
        Me.txtCapacidade.Location = New System.Drawing.Point(8, 64)
        Me.txtCapacidade.Name = "txtCapacidade"
        Me.txtCapacidade.Size = New System.Drawing.Size(100, 21)
        Me.txtCapacidade.TabIndex = 5
        '
        'chkArmazemInterno
        '
        Me.chkArmazemInterno.AutoSize = True
        Me.chkArmazemInterno.Location = New System.Drawing.Point(174, 66)
        Me.chkArmazemInterno.Name = "chkArmazemInterno"
        Me.chkArmazemInterno.Size = New System.Drawing.Size(105, 17)
        Me.chkArmazemInterno.TabIndex = 6
        Me.chkArmazemInterno.Text = "Armazém Interno"
        Me.chkArmazemInterno.UseVisualStyleBackColor = True
        Me.chkArmazemInterno.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(205, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Listagem de Modalidade de Transferência"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(417, 392)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 376
        Me.cmdFechar.Text = "F"
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(8, 392)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 377
        Me.cmdGravar.TabStop = False
        Me.cmdGravar.Text = "G"
        '
        'lstModalidadeTransferencia
        '
        Me.lstModalidadeTransferencia.FormattingEnabled = True
        Me.lstModalidadeTransferencia.Location = New System.Drawing.Point(8, 107)
        Me.lstModalidadeTransferencia.Name = "lstModalidadeTransferencia"
        Me.lstModalidadeTransferencia.Size = New System.Drawing.Size(454, 274)
        Me.lstModalidadeTransferencia.TabIndex = 378
        '
        'chkAtivo
        '
        Me.chkAtivo.AutoSize = True
        Me.chkAtivo.Location = New System.Drawing.Point(116, 66)
        Me.chkAtivo.Name = "chkAtivo"
        Me.chkAtivo.Size = New System.Drawing.Size(50, 17)
        Me.chkAtivo.TabIndex = 6
        Me.chkAtivo.Text = "Ativo"
        Me.chkAtivo.UseVisualStyleBackColor = True
        '
        'cmdPilha
        '
        Appearance1.Image = Global.Logus.My.Resources.Resources.Pilha
        Me.cmdPilha.Appearance = Appearance1
        Me.cmdPilha.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdPilha.Location = New System.Drawing.Point(61, 392)
        Me.cmdPilha.Name = "cmdPilha"
        Me.cmdPilha.Size = New System.Drawing.Size(45, 45)
        Me.cmdPilha.TabIndex = 377
        Me.cmdPilha.TabStop = False
        '
        'frmCadastroArmazem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(471, 444)
        Me.Controls.Add(Me.lstModalidadeTransferencia)
        Me.Controls.Add(Me.cmdPilha)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.chkAtivo)
        Me.Controls.Add(Me.chkArmazemInterno)
        Me.Controls.Add(Me.txtCapacidade)
        Me.Controls.Add(Me.txtNome)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboFilial)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmCadastroArmazem"
        Me.Text = "Cadastro de Armazém"
        CType(Me.txtCapacidade, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents cboFilial As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNome As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCapacidade As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents chkArmazemInterno As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lstModalidadeTransferencia As System.Windows.Forms.CheckedListBox
    Friend WithEvents chkAtivo As System.Windows.Forms.CheckBox
    Friend WithEvents cmdPilha As Infragistics.Win.Misc.UltraButton
End Class
