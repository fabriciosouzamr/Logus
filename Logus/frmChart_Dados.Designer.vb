<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChart_Dados
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
        Me.chkColunas = New System.Windows.Forms.CheckedListBox
        Me.cmdCancelar = New Infragistics.Win.Misc.UltraButton
        Me.cmdRetornar = New Infragistics.Win.Misc.UltraButton
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(157, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Listagem de Colunas do Gráfico"
        '
        'chkColunas
        '
        Me.chkColunas.CheckOnClick = True
        Me.chkColunas.FormattingEnabled = True
        Me.chkColunas.Location = New System.Drawing.Point(5, 21)
        Me.chkColunas.Name = "chkColunas"
        Me.chkColunas.Size = New System.Drawing.Size(340, 304)
        Me.chkColunas.TabIndex = 1
        Me.chkColunas.ThreeDCheckBoxes = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdCancelar.Location = New System.Drawing.Point(300, 331)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(45, 45)
        Me.cmdCancelar.TabIndex = 153
        Me.cmdCancelar.Text = "C"
        '
        'cmdRetornar
        '
        Me.cmdRetornar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdRetornar.Location = New System.Drawing.Point(249, 331)
        Me.cmdRetornar.Name = "cmdRetornar"
        Me.cmdRetornar.Size = New System.Drawing.Size(45, 45)
        Me.cmdRetornar.TabIndex = 154
        Me.cmdRetornar.Text = "R"
        '
        'frmChart_Dados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(350, 380)
        Me.Controls.Add(Me.cmdRetornar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.chkColunas)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "frmChart_Dados"
        Me.Text = "Gráficos - Manipulação de Dados"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkColunas As System.Windows.Forms.CheckedListBox
    Friend WithEvents cmdCancelar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdRetornar As Infragistics.Win.Misc.UltraButton
End Class
