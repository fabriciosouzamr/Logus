<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroInovacao
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadastroInovacao))
        Me.rctDescricao = New System.Windows.Forms.RichTextBox
        Me.pnlRodape = New System.Windows.Forms.Panel
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.pnlCabecalho = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboTipoInovacao = New System.Windows.Forms.ComboBox
        Me.cboFilial = New System.Windows.Forms.ComboBox
        Me.txtData = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtAssunto = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.pnlRodape.SuspendLayout()
        Me.pnlCabecalho.SuspendLayout()
        CType(Me.txtData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rctDescricao
        '
        Me.rctDescricao.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rctDescricao.Location = New System.Drawing.Point(6, 92)
        Me.rctDescricao.Name = "rctDescricao"
        Me.rctDescricao.Size = New System.Drawing.Size(464, 225)
        Me.rctDescricao.TabIndex = 4
        Me.rctDescricao.Text = ""
        '
        'pnlRodape
        '
        Me.pnlRodape.Controls.Add(Me.cmdGravar)
        Me.pnlRodape.Controls.Add(Me.cmdFechar)
        Me.pnlRodape.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlRodape.Location = New System.Drawing.Point(0, 315)
        Me.pnlRodape.Name = "pnlRodape"
        Me.pnlRodape.Size = New System.Drawing.Size(482, 57)
        Me.pnlRodape.TabIndex = 19
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(5, 8)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 5
        Me.cmdGravar.TabStop = False
        Me.cmdGravar.Text = "G"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(431, 8)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 6
        Me.cmdFechar.Text = "F"
        '
        'pnlCabecalho
        '
        Me.pnlCabecalho.Controls.Add(Me.Label2)
        Me.pnlCabecalho.Controls.Add(Me.cboTipoInovacao)
        Me.pnlCabecalho.Controls.Add(Me.cboFilial)
        Me.pnlCabecalho.Controls.Add(Me.txtData)
        Me.pnlCabecalho.Controls.Add(Me.Label8)
        Me.pnlCabecalho.Controls.Add(Me.txtAssunto)
        Me.pnlCabecalho.Controls.Add(Me.Label1)
        Me.pnlCabecalho.Controls.Add(Me.Label3)
        Me.pnlCabecalho.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecalho.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecalho.Name = "pnlCabecalho"
        Me.pnlCabecalho.Size = New System.Drawing.Size(482, 104)
        Me.pnlCabecalho.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(5, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 183
        Me.Label2.Text = "Tipo Inovacao"
        '
        'cboTipoInovacao
        '
        Me.cboTipoInovacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoInovacao.Location = New System.Drawing.Point(5, 20)
        Me.cboTipoInovacao.Name = "cboTipoInovacao"
        Me.cboTipoInovacao.Size = New System.Drawing.Size(160, 21)
        Me.cboTipoInovacao.TabIndex = 0
        '
        'cboFilial
        '
        Me.cboFilial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilial.Location = New System.Drawing.Point(173, 20)
        Me.cboFilial.Name = "cboFilial"
        Me.cboFilial.Size = New System.Drawing.Size(189, 21)
        Me.cboFilial.TabIndex = 1
        '
        'txtData
        '
        Me.txtData.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtData.Location = New System.Drawing.Point(370, 20)
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(104, 23)
        Me.txtData.TabIndex = 2
        Me.txtData.Value = Nothing
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(370, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 13)
        Me.Label8.TabIndex = 179
        Me.Label8.Text = "Data "
        '
        'txtAssunto
        '
        Me.txtAssunto.Location = New System.Drawing.Point(5, 64)
        Me.txtAssunto.Name = "txtAssunto"
        Me.txtAssunto.Size = New System.Drawing.Size(468, 20)
        Me.txtAssunto.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(173, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 181
        Me.Label1.Text = "Filial"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(5, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Assunto"
        '
        'frmCadastroInovacao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(482, 372)
        Me.Controls.Add(Me.rctDescricao)
        Me.Controls.Add(Me.pnlRodape)
        Me.Controls.Add(Me.pnlCabecalho)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCadastroInovacao"
        Me.Text = "Cadastro Inovação"
        Me.pnlRodape.ResumeLayout(False)
        Me.pnlCabecalho.ResumeLayout(False)
        Me.pnlCabecalho.PerformLayout()
        CType(Me.txtData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rctDescricao As System.Windows.Forms.RichTextBox
    Friend WithEvents pnlRodape As System.Windows.Forms.Panel
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents pnlCabecalho As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboTipoInovacao As System.Windows.Forms.ComboBox
    Friend WithEvents cboFilial As System.Windows.Forms.ComboBox
    Friend WithEvents txtData As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAssunto As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
