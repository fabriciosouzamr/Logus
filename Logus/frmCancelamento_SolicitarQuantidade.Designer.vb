<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCancelamento_SolicitarQuantidade
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCancelamento_SolicitarQuantidade))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtQuantidade = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtMotivo = New System.Windows.Forms.TextBox
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
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Quantidade"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Motivo"
        '
        'txtQuantidade
        '
        Me.txtQuantidade.Location = New System.Drawing.Point(5, 20)
        Me.txtQuantidade.MaskInput = "-nnnnnnnnn"
        Me.txtQuantidade.Name = "txtQuantidade"
        Me.txtQuantidade.Size = New System.Drawing.Size(100, 21)
        Me.txtQuantidade.TabIndex = 2
        '
        'txtMotivo
        '
        Me.txtMotivo.Location = New System.Drawing.Point(5, 64)
        Me.txtMotivo.MaxLength = 40
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.Size = New System.Drawing.Size(500, 20)
        Me.txtMotivo.TabIndex = 3
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(5, 92)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 237
        Me.cmdGravar.Text = "G"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(460, 92)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 236
        Me.cmdFechar.Text = "F"
        '
        'frmCancelamento_SolicitarQuantidade
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 143)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.txtMotivo)
        Me.Controls.Add(Me.txtQuantidade)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCancelamento_SolicitarQuantidade"
        Me.Text = "Informe a quantidade de cancelamento"
        CType(Me.txtQuantidade, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtQuantidade As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents txtMotivo As System.Windows.Forms.TextBox
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
End Class
