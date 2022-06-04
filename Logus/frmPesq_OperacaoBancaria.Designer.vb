<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPesq_OperacaoBancaria
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
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPesq_OperacaoBancaria))
        Me.cmdSelecionar = New Infragistics.Win.Misc.UltraButton
        Me.cmdCancelar = New Infragistics.Win.Misc.UltraButton
        Me.grdGeral = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.cmdPesquisar = New Infragistics.Win.Misc.UltraButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtNomeOperacao = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboCreditoDebito = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCodigo = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Label4 = New System.Windows.Forms.Label
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdSelecionar
        '
        Me.cmdSelecionar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdSelecionar.Location = New System.Drawing.Point(629, 349)
        Me.cmdSelecionar.Name = "cmdSelecionar"
        Me.cmdSelecionar.Size = New System.Drawing.Size(45, 45)
        Me.cmdSelecionar.TabIndex = 163
        Me.cmdSelecionar.Text = "S"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdCancelar.Location = New System.Drawing.Point(680, 349)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(45, 45)
        Me.cmdCancelar.TabIndex = 162
        Me.cmdCancelar.Text = "C"
        '
        'grdGeral
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdGeral.DisplayLayout.Appearance = Appearance1
        Me.grdGeral.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdGeral.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdGeral.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.grdGeral.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdGeral.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.grdGeral.DisplayLayout.MaxColScrollRegions = 1
        Me.grdGeral.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdGeral.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdGeral.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.grdGeral.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdGeral.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdGeral.DisplayLayout.Override.CellAppearance = Appearance8
        Me.grdGeral.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdGeral.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.grdGeral.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.grdGeral.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdGeral.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.grdGeral.DisplayLayout.Override.RowAppearance = Appearance11
        Me.grdGeral.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdGeral.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.grdGeral.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdGeral.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdGeral.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdGeral.Location = New System.Drawing.Point(5, 63)
        Me.grdGeral.Name = "grdGeral"
        Me.grdGeral.Size = New System.Drawing.Size(720, 280)
        Me.grdGeral.TabIndex = 161
        Me.grdGeral.Text = "UltraGrid1"
        '
        'cmdPesquisar
        '
        Me.cmdPesquisar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdPesquisar.Location = New System.Drawing.Point(680, 5)
        Me.cmdPesquisar.Name = "cmdPesquisar"
        Me.cmdPesquisar.Size = New System.Drawing.Size(45, 45)
        Me.cmdPesquisar.TabIndex = 160
        Me.cmdPesquisar.Text = "P"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 164
        Me.Label1.Text = "Nome da Operação"
        '
        'txtNomeOperacao
        '
        Me.txtNomeOperacao.Location = New System.Drawing.Point(5, 20)
        Me.txtNomeOperacao.Name = "txtNomeOperacao"
        Me.txtNomeOperacao.Size = New System.Drawing.Size(371, 20)
        Me.txtNomeOperacao.TabIndex = 165
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(457, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 166
        Me.Label2.Text = "Crédito/Débito"
        Me.Label2.Visible = False
        '
        'cboCreditoDebito
        '
        Me.cboCreditoDebito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCreditoDebito.FormattingEnabled = True
        Me.cboCreditoDebito.Location = New System.Drawing.Point(457, 20)
        Me.cboCreditoDebito.Name = "cboCreditoDebito"
        Me.cboCreditoDebito.Size = New System.Drawing.Size(76, 21)
        Me.cboCreditoDebito.TabIndex = 167
        Me.cboCreditoDebito.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(384, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 168
        Me.Label3.Text = "Código"
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(384, 20)
        Me.txtCodigo.MaxValue = 99999
        Me.txtCodigo.MinValue = 0
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Nullable = True
        Me.txtCodigo.Size = New System.Drawing.Size(65, 21)
        Me.txtCodigo.TabIndex = 173
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(121, 13)
        Me.Label4.TabIndex = 174
        Me.Label4.Text = "Listagem de Fornecedor"
        '
        'frmPesq_OperacaoBancaria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(732, 399)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboCreditoDebito)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNomeOperacao)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdSelecionar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.grdGeral)
        Me.Controls.Add(Me.cmdPesquisar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPesq_OperacaoBancaria"
        Me.ShowIcon = False
        Me.Text = " Pesquisa de Operação Bancária"
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdSelecionar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdCancelar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents grdGeral As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cmdPesquisar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNomeOperacao As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboCreditoDebito As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
