<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelecao_MultiplaSelecao
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtTermoPesquisa = New System.Windows.Forms.TextBox
        Me.lstEncontratos = New System.Windows.Forms.ListBox
        Me.lstSelecionado = New System.Windows.Forms.ListBox
        Me.cmdPesquisa = New Infragistics.Win.Misc.UltraButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdCancelar = New Infragistics.Win.Misc.UltraButton
        Me.cmdSelecionar = New Infragistics.Win.Misc.UltraButton
        Me.cmdSeleciona = New Infragistics.Win.Misc.UltraButton
        Me.cmdExclui = New Infragistics.Win.Misc.UltraButton
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Digite o termo de pesquisa"
        '
        'txtTermoPesquisa
        '
        Me.txtTermoPesquisa.Location = New System.Drawing.Point(5, 20)
        Me.txtTermoPesquisa.Name = "txtTermoPesquisa"
        Me.txtTermoPesquisa.Size = New System.Drawing.Size(441, 20)
        Me.txtTermoPesquisa.TabIndex = 1
        '
        'lstEncontratos
        '
        Me.lstEncontratos.FormattingEnabled = True
        Me.lstEncontratos.Location = New System.Drawing.Point(5, 63)
        Me.lstEncontratos.Name = "lstEncontratos"
        Me.lstEncontratos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstEncontratos.Size = New System.Drawing.Size(470, 95)
        Me.lstEncontratos.TabIndex = 3
        '
        'lstSelecionado
        '
        Me.lstSelecionado.FormattingEnabled = True
        Me.lstSelecionado.Location = New System.Drawing.Point(5, 181)
        Me.lstSelecionado.Name = "lstSelecionado"
        Me.lstSelecionado.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstSelecionado.Size = New System.Drawing.Size(470, 95)
        Me.lstSelecionado.Sorted = True
        Me.lstSelecionado.TabIndex = 4
        '
        'cmdPesquisa
        '
        Appearance1.Image = My.Resources.Resources.Visuzalizar
        Appearance1.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.cmdPesquisa.Appearance = Appearance1
        Me.cmdPesquisa.Location = New System.Drawing.Point(452, 17)
        Me.cmdPesquisa.Name = "cmdPesquisa"
        Me.cmdPesquisa.Size = New System.Drawing.Size(23, 23)
        Me.cmdPesquisa.TabIndex = 185
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(151, 13)
        Me.Label2.TabIndex = 186
        Me.Label2.Text = "Listagem de itens encontrados"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 166)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(154, 13)
        Me.Label3.TabIndex = 187
        Me.Label3.Text = "Listagem de itens selecionados"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdCancelar.Location = New System.Drawing.Point(457, 284)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(45, 45)
        Me.cmdCancelar.TabIndex = 309
        Me.cmdCancelar.Text = "F"
        '
        'cmdSelecionar
        '
        Me.cmdSelecionar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdSelecionar.Location = New System.Drawing.Point(5, 284)
        Me.cmdSelecionar.Name = "cmdSelecionar"
        Me.cmdSelecionar.Size = New System.Drawing.Size(45, 45)
        Me.cmdSelecionar.TabIndex = 308
        Me.cmdSelecionar.TabStop = False
        Me.cmdSelecionar.Text = "G"
        '
        'cmdSeleciona
        '
        Appearance3.Image = My.Resources.Resources.Adicionar
        Appearance3.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.cmdSeleciona.Appearance = Appearance3
        Me.cmdSeleciona.Location = New System.Drawing.Point(479, 135)
        Me.cmdSeleciona.Name = "cmdSeleciona"
        Me.cmdSeleciona.Size = New System.Drawing.Size(23, 23)
        Me.cmdSeleciona.TabIndex = 312
        '
        'cmdExclui
        '
        Appearance2.Image = My.Resources.Resources.Cancelar1
        Appearance2.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.cmdExclui.Appearance = Appearance2
        Me.cmdExclui.Location = New System.Drawing.Point(479, 253)
        Me.cmdExclui.Name = "cmdExclui"
        Me.cmdExclui.Size = New System.Drawing.Size(23, 23)
        Me.cmdExclui.TabIndex = 313
        '
        'frmSelecao_MultiplaSelecao
        '
        Me.AcceptButton = Me.cmdPesquisa
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 334)
        Me.Controls.Add(Me.cmdExclui)
        Me.Controls.Add(Me.cmdSeleciona)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdSelecionar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdPesquisa)
        Me.Controls.Add(Me.lstSelecionado)
        Me.Controls.Add(Me.lstEncontratos)
        Me.Controls.Add(Me.txtTermoPesquisa)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmSelecao_MultiplaSelecao"
        Me.Text = " Seleção"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTermoPesquisa As System.Windows.Forms.TextBox
    Friend WithEvents lstEncontratos As System.Windows.Forms.ListBox
    Friend WithEvents lstSelecionado As System.Windows.Forms.ListBox
    Friend WithEvents cmdPesquisa As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdCancelar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdSelecionar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdSeleciona As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdExclui As Infragistics.Win.Misc.UltraButton
End Class
