<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAvi
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
        Me.acFilme = New Infragistics.Win.Misc.CommonControls.AnimationControl
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'acFilme
        '
        Me.acFilme.AnimationSource = Infragistics.Win.Misc.CommonControls.AnimationType.FileMove
        Me.acFilme.AutoCenter = True
        Me.acFilme.AutoPlay = True
        Me.acFilme.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.acFilme.Location = New System.Drawing.Point(6, 10)
        Me.acFilme.Name = "acFilme"
        Me.acFilme.Size = New System.Drawing.Size(261, 53)
        Me.acFilme.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.acFilme)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(270, 67)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'UltraLabel1
        '
        Appearance1.ForeColor = System.Drawing.Color.Navy
        Appearance1.TextHAlignAsString = "Center"
        Me.UltraLabel1.Appearance = Appearance1
        Me.UltraLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel1.Location = New System.Drawing.Point(13, 69)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(261, 23)
        Me.UltraLabel1.TabIndex = 2
        Me.UltraLabel1.Text = "Por favor aguarde..."
        '
        'frmAvi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(283, 96)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmAvi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmAvi"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents acFilme As Infragistics.Win.Misc.CommonControls.AnimationControl
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
End Class
