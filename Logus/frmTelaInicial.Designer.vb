<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTelaInicial
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
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTelaInicial))
        Me.Label1 = New System.Windows.Forms.Label
        Me.lstListagemFilial = New System.Windows.Forms.ListBox
        Me.cmdCancelar = New Infragistics.Win.Misc.UltraButton
        Me.cmdOk = New Infragistics.Win.Misc.UltraButton
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Listagem de Filiais"
        '
        'lstListagemFilial
        '
        Me.lstListagemFilial.FormattingEnabled = True
        Me.lstListagemFilial.Location = New System.Drawing.Point(8, 23)
        Me.lstListagemFilial.Name = "lstListagemFilial"
        Me.lstListagemFilial.Size = New System.Drawing.Size(200, 199)
        Me.lstListagemFilial.Sorted = True
        Me.lstListagemFilial.TabIndex = 1
        '
        'cmdCancelar
        '
        Appearance2.Image = Global.Logus.My.Resources.Resources.Cancelar
        Me.cmdCancelar.Appearance = Appearance2
        Me.cmdCancelar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdCancelar.Location = New System.Drawing.Point(163, 230)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(45, 45)
        Me.cmdCancelar.TabIndex = 6
        Me.cmdCancelar.TabStop = False
        '
        'cmdOk
        '
        Appearance1.Image = Global.Logus.My.Resources.Resources._27
        Appearance1.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.cmdOk.Appearance = Appearance1
        Me.cmdOk.ImageSize = New System.Drawing.Size(24, 20)
        Me.cmdOk.Location = New System.Drawing.Point(8, 230)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(45, 45)
        Me.cmdOk.TabIndex = 5
        '
        'frmTelaInicial
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(215, 283)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.lstListagemFilial)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmTelaInicial"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = " Informções Iniciais"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lstListagemFilial As System.Windows.Forms.ListBox
    Friend WithEvents cmdCancelar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdOk As Infragistics.Win.Misc.UltraButton
End Class
