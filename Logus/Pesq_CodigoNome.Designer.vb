<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pesq_CodigoNome
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Pesq_CodigoNome))
        Me.txtPesquisar = New System.Windows.Forms.TextBox
        Me.cmdFiltro = New System.Windows.Forms.Button
        Me.lblMostrar = New System.Windows.Forms.TextBox
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'txtPesquisar
        '
        Me.txtPesquisar.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtPesquisar.ForeColor = System.Drawing.Color.Black
        Me.txtPesquisar.Location = New System.Drawing.Point(169, 1)
        Me.txtPesquisar.Name = "txtPesquisar"
        Me.txtPesquisar.Size = New System.Drawing.Size(128, 20)
        Me.txtPesquisar.TabIndex = 0
        Me.txtPesquisar.TabStop = False
        Me.txtPesquisar.Text = "Teste"
        '
        'cmdFiltro
        '
        Me.cmdFiltro.Image = CType(resources.GetObject("cmdFiltro.Image"), System.Drawing.Image)
        Me.cmdFiltro.Location = New System.Drawing.Point(0, 0)
        Me.cmdFiltro.Name = "cmdFiltro"
        Me.cmdFiltro.Size = New System.Drawing.Size(23, 23)
        Me.cmdFiltro.TabIndex = 2
        Me.cmdFiltro.TabStop = False
        Me.cmdFiltro.UseVisualStyleBackColor = True
        '
        'lblMostrar
        '
        Me.lblMostrar.BackColor = System.Drawing.Color.White
        Me.lblMostrar.Location = New System.Drawing.Point(25, 1)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.ReadOnly = True
        Me.lblMostrar.Size = New System.Drawing.Size(100, 20)
        Me.lblMostrar.TabIndex = 3
        Me.lblMostrar.TabStop = False
        '
        'Pesq_CodigoNome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdFiltro)
        Me.Controls.Add(Me.txtPesquisar)
        Me.Controls.Add(Me.lblMostrar)
        Me.MaximumSize = New System.Drawing.Size(1000, 23)
        Me.MinimumSize = New System.Drawing.Size(0, 23)
        Me.Name = "Pesq_CodigoNome"
        Me.Size = New System.Drawing.Size(300, 23)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPesquisar As System.Windows.Forms.TextBox
    Friend WithEvents cmdFiltro As System.Windows.Forms.Button
    Friend WithEvents lblMostrar As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip

End Class
