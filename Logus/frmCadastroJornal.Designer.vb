<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroJornal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadastroJornal))
        Me.pnlCabecalho = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboFilial = New System.Windows.Forms.ComboBox
        Me.txtData = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtAssunto = New System.Windows.Forms.TextBox
        Me.pnlRodape = New System.Windows.Forms.Panel
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.rctJornal = New Logus.Editor
        Me.pnlCabecalho.SuspendLayout()
        CType(Me.txtData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlRodape.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlCabecalho
        '
        Me.pnlCabecalho.Controls.Add(Me.Label1)
        Me.pnlCabecalho.Controls.Add(Me.cboFilial)
        Me.pnlCabecalho.Controls.Add(Me.txtData)
        Me.pnlCabecalho.Controls.Add(Me.Label8)
        Me.pnlCabecalho.Controls.Add(Me.Label3)
        Me.pnlCabecalho.Controls.Add(Me.txtAssunto)
        Me.pnlCabecalho.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecalho.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecalho.Name = "pnlCabecalho"
        Me.pnlCabecalho.Size = New System.Drawing.Size(644, 81)
        Me.pnlCabecalho.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(11, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 181
        Me.Label1.Text = "Filial"
        '
        'cboFilial
        '
        Me.cboFilial.Location = New System.Drawing.Point(11, 25)
        Me.cboFilial.Name = "cboFilial"
        Me.cboFilial.Size = New System.Drawing.Size(202, 21)
        Me.cboFilial.TabIndex = 180
        '
        'txtData
        '
        Me.txtData.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtData.Location = New System.Drawing.Point(228, 23)
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(104, 23)
        Me.txtData.TabIndex = 178
        Me.txtData.Value = Nothing
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(226, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 179
        Me.Label8.Text = "Data Jornal"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Assunto"
        '
        'txtAssunto
        '
        Me.txtAssunto.Location = New System.Drawing.Point(61, 52)
        Me.txtAssunto.Name = "txtAssunto"
        Me.txtAssunto.Size = New System.Drawing.Size(571, 20)
        Me.txtAssunto.TabIndex = 10
        '
        'pnlRodape
        '
        Me.pnlRodape.Controls.Add(Me.cmdGravar)
        Me.pnlRodape.Controls.Add(Me.cmdFechar)
        Me.pnlRodape.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlRodape.Location = New System.Drawing.Point(0, 421)
        Me.pnlRodape.Name = "pnlRodape"
        Me.pnlRodape.Size = New System.Drawing.Size(644, 56)
        Me.pnlRodape.TabIndex = 4
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(8, 8)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 182
        Me.cmdGravar.TabStop = False
        Me.cmdGravar.Text = "G"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(590, 8)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 12
        Me.cmdFechar.Text = "F"
        '
        'rctJornal
        '
        Me.rctJornal.Leitura = False
        Me.rctJornal.Location = New System.Drawing.Point(11, 87)
        Me.rctJornal.Name = "rctJornal"
        Me.rctJornal.Size = New System.Drawing.Size(620, 328)
        Me.rctJornal.TabIndex = 15
        Me.rctJornal.Texto = ""
        Me.rctJornal.Texto_Selecao = ""
        Me.rctJornal.Texto_Selecao_Inicio = 0
        Me.rctJornal.Texto_Selecao_Tamanho = 0
        '
        'frmCadastroJornal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(644, 477)
        Me.Controls.Add(Me.pnlRodape)
        Me.Controls.Add(Me.pnlCabecalho)
        Me.Controls.Add(Me.rctJornal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCadastroJornal"
        Me.Text = "Jornal"
        Me.pnlCabecalho.ResumeLayout(False)
        Me.pnlCabecalho.PerformLayout()
        CType(Me.txtData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlRodape.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlCabecalho As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAssunto As System.Windows.Forms.TextBox
    Friend WithEvents pnlRodape As System.Windows.Forms.Panel
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboFilial As System.Windows.Forms.ComboBox
    Friend WithEvents txtData As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents rctJornal As Logus.Editor
End Class
