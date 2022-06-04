<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAplicacao_QuebrarValor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAplicacao_QuebrarValor))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtValorMaximo = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblQuantidadeMaxima = New System.Windows.Forms.Label
        Me.txtQuantidadeMaxima = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtValorSolicitado = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblQuantidadeSolicitada = New System.Windows.Forms.Label
        Me.txtQuantidadeSolicitada = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtValorMaximo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantidadeMaxima, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.txtValorSolicitado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantidadeSolicitada, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtValorMaximo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblQuantidadeMaxima)
        Me.GroupBox1.Controls.Add(Me.txtQuantidadeMaxima)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(360, 48)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Máximo"
        '
        'txtValorMaximo
        '
        Me.txtValorMaximo.Location = New System.Drawing.Point(242, 18)
        Me.txtValorMaximo.Name = "txtValorMaximo"
        Me.txtValorMaximo.ReadOnly = True
        Me.txtValorMaximo.Size = New System.Drawing.Size(91, 21)
        Me.txtValorMaximo.TabIndex = 261
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(203, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 219
        Me.Label2.Text = "Valor"
        '
        'lblQuantidadeMaxima
        '
        Me.lblQuantidadeMaxima.AutoSize = True
        Me.lblQuantidadeMaxima.Location = New System.Drawing.Point(20, 22)
        Me.lblQuantidadeMaxima.Name = "lblQuantidadeMaxima"
        Me.lblQuantidadeMaxima.Size = New System.Drawing.Size(62, 13)
        Me.lblQuantidadeMaxima.TabIndex = 218
        Me.lblQuantidadeMaxima.Text = "Quantidade"
        '
        'txtQuantidadeMaxima
        '
        Me.txtQuantidadeMaxima.Location = New System.Drawing.Point(90, 18)
        Me.txtQuantidadeMaxima.Name = "txtQuantidadeMaxima"
        Me.txtQuantidadeMaxima.ReadOnly = True
        Me.txtQuantidadeMaxima.Size = New System.Drawing.Size(89, 21)
        Me.txtQuantidadeMaxima.TabIndex = 217
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtValorSolicitado)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.lblQuantidadeSolicitada)
        Me.GroupBox2.Controls.Add(Me.txtQuantidadeSolicitada)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 61)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(360, 48)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Solicitado"
        '
        'txtValorSolicitado
        '
        Me.txtValorSolicitado.Location = New System.Drawing.Point(242, 18)
        Me.txtValorSolicitado.Name = "txtValorSolicitado"
        Me.txtValorSolicitado.Size = New System.Drawing.Size(91, 21)
        Me.txtValorSolicitado.TabIndex = 260
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(203, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 219
        Me.Label3.Text = "Valor"
        '
        'lblQuantidadeSolicitada
        '
        Me.lblQuantidadeSolicitada.AutoSize = True
        Me.lblQuantidadeSolicitada.Location = New System.Drawing.Point(20, 22)
        Me.lblQuantidadeSolicitada.Name = "lblQuantidadeSolicitada"
        Me.lblQuantidadeSolicitada.Size = New System.Drawing.Size(62, 13)
        Me.lblQuantidadeSolicitada.TabIndex = 218
        Me.lblQuantidadeSolicitada.Text = "Quantidade"
        '
        'txtQuantidadeSolicitada
        '
        Me.txtQuantidadeSolicitada.Location = New System.Drawing.Point(90, 18)
        Me.txtQuantidadeSolicitada.Name = "txtQuantidadeSolicitada"
        Me.txtQuantidadeSolicitada.Size = New System.Drawing.Size(89, 21)
        Me.txtQuantidadeSolicitada.TabIndex = 217
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(320, 117)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 13
        Me.cmdFechar.Text = "F"
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(5, 117)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 183
        Me.cmdGravar.TabStop = False
        Me.cmdGravar.Text = "G"
        '
        'frmAplicacao_QuebrarValor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(371, 169)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmAplicacao_QuebrarValor"
        Me.Text = "Favor informar os dados da alteração ..."
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtValorMaximo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantidadeMaxima, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.txtValorSolicitado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantidadeSolicitada, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtQuantidadeMaxima As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents lblQuantidadeMaxima As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblQuantidadeSolicitada As System.Windows.Forms.Label
    Friend WithEvents txtQuantidadeSolicitada As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtValorSolicitado As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents txtValorMaximo As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
End Class
