<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMovimentacaoCacau_Movimentar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMovimentacaoCacau_Movimentar))
        Me.lblOrigem_Armazem = New System.Windows.Forms.Label
        Me.lblOrigem_Pilha = New System.Windows.Forms.Label
        Me.lblOrigem_Volume = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboArmazem = New System.Windows.Forms.ComboBox
        Me.cboPilha = New System.Windows.Forms.ComboBox
        Me.txtVolume = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        CType(Me.txtVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblOrigem_Armazem
        '
        Me.lblOrigem_Armazem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOrigem_Armazem.Location = New System.Drawing.Point(5, 46)
        Me.lblOrigem_Armazem.Name = "lblOrigem_Armazem"
        Me.lblOrigem_Armazem.Size = New System.Drawing.Size(130, 20)
        Me.lblOrigem_Armazem.TabIndex = 0
        Me.lblOrigem_Armazem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOrigem_Pilha
        '
        Me.lblOrigem_Pilha.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOrigem_Pilha.Location = New System.Drawing.Point(143, 46)
        Me.lblOrigem_Pilha.Name = "lblOrigem_Pilha"
        Me.lblOrigem_Pilha.Size = New System.Drawing.Size(60, 20)
        Me.lblOrigem_Pilha.TabIndex = 1
        Me.lblOrigem_Pilha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOrigem_Volume
        '
        Me.lblOrigem_Volume.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOrigem_Volume.Location = New System.Drawing.Point(211, 46)
        Me.lblOrigem_Volume.Name = "lblOrigem_Volume"
        Me.lblOrigem_Volume.Size = New System.Drawing.Size(60, 20)
        Me.lblOrigem_Volume.TabIndex = 2
        Me.lblOrigem_Volume.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(143, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Pilha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(211, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Volume"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Location = New System.Drawing.Point(5, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(266, 18)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Origem"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(5, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Armazém"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Location = New System.Drawing.Point(5, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(266, 18)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Destino"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 100)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Armazém"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(211, 100)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Volume"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(143, 100)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Pilha"
        '
        'cboArmazem
        '
        Me.cboArmazem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboArmazem.FormattingEnabled = True
        Me.cboArmazem.Location = New System.Drawing.Point(5, 115)
        Me.cboArmazem.Name = "cboArmazem"
        Me.cboArmazem.Size = New System.Drawing.Size(130, 21)
        Me.cboArmazem.TabIndex = 11
        '
        'cboPilha
        '
        Me.cboPilha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPilha.FormattingEnabled = True
        Me.cboPilha.Location = New System.Drawing.Point(143, 115)
        Me.cboPilha.Name = "cboPilha"
        Me.cboPilha.Size = New System.Drawing.Size(60, 21)
        Me.cboPilha.TabIndex = 12
        '
        'txtVolume
        '
        Me.txtVolume.Location = New System.Drawing.Point(211, 115)
        Me.txtVolume.MaskInput = "nnnnnnn"
        Me.txtVolume.Name = "txtVolume"
        Me.txtVolume.Size = New System.Drawing.Size(60, 21)
        Me.txtVolume.TabIndex = 13
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(226, 144)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 249
        Me.cmdFechar.Text = "F"
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(5, 144)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 250
        Me.cmdGravar.Text = "G"
        '
        'frmMovimentacaoCacau_Movimentar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(277, 195)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.txtVolume)
        Me.Controls.Add(Me.cboPilha)
        Me.Controls.Add(Me.cboArmazem)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblOrigem_Volume)
        Me.Controls.Add(Me.lblOrigem_Pilha)
        Me.Controls.Add(Me.lblOrigem_Armazem)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMovimentacaoCacau_Movimentar"
        Me.Text = "Movimentação de Cacau - Movimentar"
        CType(Me.txtVolume, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblOrigem_Armazem As System.Windows.Forms.Label
    Friend WithEvents lblOrigem_Pilha As System.Windows.Forms.Label
    Friend WithEvents lblOrigem_Volume As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboArmazem As System.Windows.Forms.ComboBox
    Friend WithEvents cboPilha As System.Windows.Forms.ComboBox
    Friend WithEvents txtVolume As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
End Class
