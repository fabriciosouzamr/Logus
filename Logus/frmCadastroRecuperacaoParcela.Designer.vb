<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroRecuperacaoParcela
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
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadastroRecuperacaoParcela))
        Me.txtDataVencimentoParcela = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtQuantidadeParcela = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtDescricaoOutros = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.optForma = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.txtValorParcela = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        CType(Me.txtDataVencimentoParcela, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantidadeParcela, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optForma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorParcela, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtDataVencimentoParcela
        '
        Me.txtDataVencimentoParcela.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataVencimentoParcela.Location = New System.Drawing.Point(250, 27)
        Me.txtDataVencimentoParcela.Name = "txtDataVencimentoParcela"
        Me.txtDataVencimentoParcela.Size = New System.Drawing.Size(96, 23)
        Me.txtDataVencimentoParcela.TabIndex = 213
        Me.txtDataVencimentoParcela.Value = Nothing
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(84, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 16)
        Me.Label2.TabIndex = 211
        Me.Label2.Text = "Quantidade"
        '
        'txtQuantidadeParcela
        '
        Me.txtQuantidadeParcela.Location = New System.Drawing.Point(87, 28)
        Me.txtQuantidadeParcela.MaskInput = "{LOC}-nnnnnnnn"
        Me.txtQuantidadeParcela.Name = "txtQuantidadeParcela"
        Me.txtQuantidadeParcela.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtQuantidadeParcela.Size = New System.Drawing.Size(68, 21)
        Me.txtQuantidadeParcela.TabIndex = 209
        '
        'txtDescricaoOutros
        '
        Me.txtDescricaoOutros.Location = New System.Drawing.Point(3, 72)
        Me.txtDescricaoOutros.Multiline = True
        Me.txtDescricaoOutros.Name = "txtDescricaoOutros"
        Me.txtDescricaoOutros.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescricaoOutros.Size = New System.Drawing.Size(346, 41)
        Me.txtDescricaoOutros.TabIndex = 207
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(0, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(199, 13)
        Me.Label10.TabIndex = 208
        Me.Label10.Text = "Descrição Recebimento Saldo Contratos"
        '
        'optForma
        '
        ValueListItem1.DataValue = "C"
        ValueListItem1.DisplayText = "Cacau"
        ValueListItem2.DataValue = "D"
        ValueListItem2.DisplayText = "Dinheiro"
        ValueListItem3.DataValue = "O"
        ValueListItem3.DisplayText = "Saldo CTR"
        Me.optForma.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem3})
        Me.optForma.Location = New System.Drawing.Point(3, 3)
        Me.optForma.Name = "optForma"
        Me.optForma.Size = New System.Drawing.Size(78, 46)
        Me.optForma.TabIndex = 206
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(247, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 16)
        Me.Label1.TabIndex = 214
        Me.Label1.Text = "Data Vencimento"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(162, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 16)
        Me.Label4.TabIndex = 212
        Me.Label4.Text = "Valor"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(304, 119)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 228
        Me.cmdFechar.Text = "F"
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(3, 119)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 227
        Me.cmdGravar.TabStop = False
        Me.cmdGravar.Text = "G"
        '
        'txtValorParcela
        '
        Me.txtValorParcela.Location = New System.Drawing.Point(161, 28)
        Me.txtValorParcela.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtValorParcela.Name = "txtValorParcela"
        Me.txtValorParcela.Size = New System.Drawing.Size(80, 21)
        Me.txtValorParcela.TabIndex = 257
        '
        'frmCadastroRecuperacaoParcela
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(354, 167)
        Me.Controls.Add(Me.txtValorParcela)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.txtDataVencimentoParcela)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtQuantidadeParcela)
        Me.Controls.Add(Me.txtDescricaoOutros)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.optForma)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCadastroRecuperacaoParcela"
        Me.Text = "Cadastro Parcela"
        CType(Me.txtDataVencimentoParcela, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantidadeParcela, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optForma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorParcela, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDataVencimentoParcela As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtQuantidadeParcela As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents txtDescricaoOutros As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents optForma As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtValorParcela As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
End Class
