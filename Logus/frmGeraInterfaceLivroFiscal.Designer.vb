<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGeraInterfaceLivroFiscal
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
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.cmdRefazInterface = New Infragistics.Win.Misc.UltraButton
        Me.cmdEnviaOW = New Infragistics.Win.Misc.UltraButton
        Me.txtData = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label6 = New System.Windows.Forms.Label
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.txtData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(210, 117)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 242
        Me.cmdFechar.Text = "F"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.cmdRefazInterface)
        Me.UltraGroupBox1.Controls.Add(Me.cmdEnviaOW)
        Me.UltraGroupBox1.Controls.Add(Me.txtData)
        Me.UltraGroupBox1.Controls.Add(Me.Label6)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(2, 3)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(253, 108)
        Me.UltraGroupBox1.TabIndex = 241
        '
        'cmdRefazInterface
        '
        Me.cmdRefazInterface.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdRefazInterface.Location = New System.Drawing.Point(137, 6)
        Me.cmdRefazInterface.Name = "cmdRefazInterface"
        Me.cmdRefazInterface.Size = New System.Drawing.Size(109, 45)
        Me.cmdRefazInterface.TabIndex = 248
        Me.cmdRefazInterface.Text = "Refaz a Interface"
        '
        'cmdEnviaOW
        '
        Me.cmdEnviaOW.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdEnviaOW.Location = New System.Drawing.Point(138, 57)
        Me.cmdEnviaOW.Name = "cmdEnviaOW"
        Me.cmdEnviaOW.Size = New System.Drawing.Size(109, 45)
        Me.cmdEnviaOW.TabIndex = 247
        Me.cmdEnviaOW.Text = "Envia para o OW"
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
        'frmGeraInterfaceLivroFiscal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(260, 168)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmGeraInterfaceLivroFiscal"
        Me.Text = "Interface Livro Fiscal"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.txtData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents cmdRefazInterface As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdEnviaOW As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtData As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
