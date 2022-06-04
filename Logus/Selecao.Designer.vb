<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Selecao
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Selecao))
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.lblSelecao = New System.Windows.Forms.Label
        Me.clbSelecao = New System.Windows.Forms.CheckedListBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdConfirmar = New Infragistics.Win.Misc.UltraButton
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdDescarmarTodos = New Infragistics.Win.Misc.UltraButton
        Me.cmdMarcarTodos = New Infragistics.Win.Misc.UltraButton
        Me.cmdPesquisa = New Infragistics.Win.Misc.UltraButton
        Me.SuspendLayout()
        '
        'lblSelecao
        '
        Me.lblSelecao.AutoSize = True
        Me.lblSelecao.BackColor = System.Drawing.Color.White
        Me.lblSelecao.Location = New System.Drawing.Point(0, 0)
        Me.lblSelecao.Name = "lblSelecao"
        Me.lblSelecao.Size = New System.Drawing.Size(0, 13)
        Me.lblSelecao.TabIndex = 1
        Me.lblSelecao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'clbSelecao
        '
        Me.clbSelecao.CheckOnClick = True
        Me.clbSelecao.FormattingEnabled = True
        Me.clbSelecao.Location = New System.Drawing.Point(0, 0)
        Me.clbSelecao.Name = "clbSelecao"
        Me.clbSelecao.Size = New System.Drawing.Size(200, 109)
        Me.clbSelecao.TabIndex = 2
        Me.clbSelecao.ThreeDCheckBoxes = True
        Me.clbSelecao.Visible = False
        '
        'cmdConfirmar
        '
        Appearance1.Image = CType(resources.GetObject("Appearance1.Image"), Object)
        Appearance1.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.cmdConfirmar.Appearance = Appearance1
        Me.cmdConfirmar.Location = New System.Drawing.Point(157, 110)
        Me.cmdConfirmar.Name = "cmdConfirmar"
        Me.cmdConfirmar.Size = New System.Drawing.Size(43, 23)
        Me.cmdConfirmar.TabIndex = 181
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Voltar.ico")
        Me.ImageList1.Images.SetKeyName(1, "DesmarcarTodos.ico")
        Me.ImageList1.Images.SetKeyName(2, "MarcarTodos.ico")
        '
        'cmdDescarmarTodos
        '
        Appearance4.Image = CType(resources.GetObject("Appearance4.Image"), Object)
        Appearance4.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.cmdDescarmarTodos.Appearance = Appearance4
        Me.cmdDescarmarTodos.Location = New System.Drawing.Point(45, 110)
        Me.cmdDescarmarTodos.Name = "cmdDescarmarTodos"
        Me.cmdDescarmarTodos.Size = New System.Drawing.Size(43, 23)
        Me.cmdDescarmarTodos.TabIndex = 182
        '
        'cmdMarcarTodos
        '
        Appearance3.Image = CType(resources.GetObject("Appearance3.Image"), Object)
        Appearance3.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.cmdMarcarTodos.Appearance = Appearance3
        Me.cmdMarcarTodos.Location = New System.Drawing.Point(0, 110)
        Me.cmdMarcarTodos.Name = "cmdMarcarTodos"
        Me.cmdMarcarTodos.Size = New System.Drawing.Size(43, 23)
        Me.cmdMarcarTodos.TabIndex = 183
        '
        'cmdPesquisa
        '
        Appearance2.Image = My.Resources.Resources.Visuzalizar
        Appearance2.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.cmdPesquisa.Appearance = Appearance2
        Me.cmdPesquisa.Location = New System.Drawing.Point(90, 110)
        Me.cmdPesquisa.Name = "cmdPesquisa"
        Me.cmdPesquisa.Size = New System.Drawing.Size(43, 23)
        Me.cmdPesquisa.TabIndex = 184
        Me.cmdPesquisa.Visible = False
        '
        'Selecao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Controls.Add(Me.cmdPesquisa)
        Me.Controls.Add(Me.cmdMarcarTodos)
        Me.Controls.Add(Me.cmdDescarmarTodos)
        Me.Controls.Add(Me.cmdConfirmar)
        Me.Controls.Add(Me.clbSelecao)
        Me.Controls.Add(Me.lblSelecao)
        Me.MinimumSize = New System.Drawing.Size(137, 4)
        Me.Name = "Selecao"
        Me.Size = New System.Drawing.Size(199, 133)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSelecao As System.Windows.Forms.Label
    Friend WithEvents clbSelecao As System.Windows.Forms.CheckedListBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmdConfirmar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents cmdDescarmarTodos As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdMarcarTodos As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdPesquisa As Infragistics.Win.Misc.UltraButton

End Class
