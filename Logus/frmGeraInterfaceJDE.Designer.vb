<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGeraInterfaceJDE
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
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.cmdRefazInterface = New Infragistics.Win.Misc.UltraButton
        Me.cmdGeraArquivo = New Infragistics.Win.Misc.UltraButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboTipoInterface = New System.Windows.Forms.ComboBox
        Me.txtData = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.txtData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.cmdRefazInterface)
        Me.UltraGroupBox1.Controls.Add(Me.cmdGeraArquivo)
        Me.UltraGroupBox1.Controls.Add(Me.Label2)
        Me.UltraGroupBox1.Controls.Add(Me.cboTipoInterface)
        Me.UltraGroupBox1.Controls.Add(Me.txtData)
        Me.UltraGroupBox1.Controls.Add(Me.Label6)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(253, 108)
        Me.UltraGroupBox1.TabIndex = 0
        '
        'cmdRefazInterface
        '
        Me.cmdRefazInterface.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdRefazInterface.Location = New System.Drawing.Point(133, 8)
        Me.cmdRefazInterface.Name = "cmdRefazInterface"
        Me.cmdRefazInterface.Size = New System.Drawing.Size(109, 45)
        Me.cmdRefazInterface.TabIndex = 248
        Me.cmdRefazInterface.Text = "Refaz a Interface"
        '
        'cmdGeraArquivo
        '
        Me.cmdGeraArquivo.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGeraArquivo.Location = New System.Drawing.Point(133, 56)
        Me.cmdGeraArquivo.Name = "cmdGeraArquivo"
        Me.cmdGeraArquivo.Size = New System.Drawing.Size(109, 45)
        Me.cmdGeraArquivo.TabIndex = 247
        Me.cmdGeraArquivo.Text = "Gera Arquivo para o JDE"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(7, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 16)
        Me.Label2.TabIndex = 246
        Me.Label2.Text = "Tipo Interface"
        '
        'cboTipoInterface
        '
        Me.cboTipoInterface.Location = New System.Drawing.Point(6, 72)
        Me.cboTipoInterface.Name = "cboTipoInterface"
        Me.cboTipoInterface.Size = New System.Drawing.Size(104, 21)
        Me.cboTipoInterface.TabIndex = 245
        '
        'txtData
        '
        Me.txtData.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtData.Location = New System.Drawing.Point(6, 23)
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(104, 23)
        Me.txtData.TabIndex = 243
        Me.txtData.Value = Nothing
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 244
        Me.Label6.Text = "Data"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(216, 124)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 240
        Me.cmdFechar.Text = "F"
        '
        'frmGeraInterfaceJDE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(269, 175)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmGeraInterfaceJDE"
        Me.Text = "Gera Interface JDE"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.txtData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboTipoInterface As System.Windows.Forms.ComboBox
    Friend WithEvents txtData As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdRefazInterface As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdGeraArquivo As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
End Class
