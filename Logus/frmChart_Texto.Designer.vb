<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChart_Texto
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
        Me.txtTituloSuperior = New System.Windows.Forms.TextBox
        Me.txtTituloInferior = New System.Windows.Forms.TextBox
        Me.txtTituloEsquerdo = New System.Windows.Forms.TextBox
        Me.txtTituloDireito = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdRetornar = New Infragistics.Win.Misc.UltraButton
        Me.cmdCancelar = New Infragistics.Win.Misc.UltraButton
        Me.SuspendLayout()
        '
        'txtTituloSuperior
        '
        Me.txtTituloSuperior.Location = New System.Drawing.Point(12, 25)
        Me.txtTituloSuperior.Name = "txtTituloSuperior"
        Me.txtTituloSuperior.Size = New System.Drawing.Size(350, 20)
        Me.txtTituloSuperior.TabIndex = 0
        '
        'txtTituloInferior
        '
        Me.txtTituloInferior.Location = New System.Drawing.Point(12, 69)
        Me.txtTituloInferior.Name = "txtTituloInferior"
        Me.txtTituloInferior.Size = New System.Drawing.Size(350, 20)
        Me.txtTituloInferior.TabIndex = 1
        '
        'txtTituloEsquerdo
        '
        Me.txtTituloEsquerdo.Location = New System.Drawing.Point(12, 113)
        Me.txtTituloEsquerdo.Name = "txtTituloEsquerdo"
        Me.txtTituloEsquerdo.Size = New System.Drawing.Size(350, 20)
        Me.txtTituloEsquerdo.TabIndex = 2
        '
        'txtTituloDireito
        '
        Me.txtTituloDireito.Location = New System.Drawing.Point(12, 157)
        Me.txtTituloDireito.Name = "txtTituloDireito"
        Me.txtTituloDireito.Size = New System.Drawing.Size(350, 20)
        Me.txtTituloDireito.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Título Superior"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Título Inferior"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Título Esquerdo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 141)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Título Direito"
        '
        'cmdRetornar
        '
        Me.cmdRetornar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdRetornar.Location = New System.Drawing.Point(266, 183)
        Me.cmdRetornar.Name = "cmdRetornar"
        Me.cmdRetornar.Size = New System.Drawing.Size(45, 45)
        Me.cmdRetornar.TabIndex = 156
        Me.cmdRetornar.Text = "R"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdCancelar.Location = New System.Drawing.Point(317, 183)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(45, 45)
        Me.cmdCancelar.TabIndex = 155
        Me.cmdCancelar.Text = "C"
        '
        'frmChart_Texto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(373, 238)
        Me.Controls.Add(Me.cmdRetornar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTituloDireito)
        Me.Controls.Add(Me.txtTituloEsquerdo)
        Me.Controls.Add(Me.txtTituloInferior)
        Me.Controls.Add(Me.txtTituloSuperior)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "frmChart_Texto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Textos do Chart"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtTituloSuperior As System.Windows.Forms.TextBox
    Friend WithEvents txtTituloInferior As System.Windows.Forms.TextBox
    Friend WithEvents txtTituloEsquerdo As System.Windows.Forms.TextBox
    Friend WithEvents txtTituloDireito As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdRetornar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdCancelar As Infragistics.Win.Misc.UltraButton
End Class
