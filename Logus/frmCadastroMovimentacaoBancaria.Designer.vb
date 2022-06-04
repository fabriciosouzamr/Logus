<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroMovimentacaoBancaria
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
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadastroMovimentacaoBancaria))
        Me.grdGeral = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtDescricao = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboFilialPagadora = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboContaBancaria = New System.Windows.Forms.ComboBox
        Me.grpProvisaoImpostos = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtValorLiquido = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.txtValorBruto = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtValorProvisao = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtFavorecido = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboFilialDebito = New System.Windows.Forms.ComboBox
        Me.optTipo = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.txtValor = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Pesq_OperacaoBancaria = New Logus.Pesq_CodigoNome
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpProvisaoImpostos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpProvisaoImpostos.SuspendLayout()
        CType(Me.txtValorLiquido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorBruto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorProvisao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.grdGeral.Location = New System.Drawing.Point(8, 18)
        Me.grdGeral.Name = "grdGeral"
        Me.grdGeral.Size = New System.Drawing.Size(306, 128)
        Me.grdGeral.TabIndex = 62
        Me.grdGeral.Text = "UltraGrid1"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(303, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 16)
        Me.Label5.TabIndex = 222
        Me.Label5.Text = "Valor"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 219
        Me.Label6.Text = "Descrição"
        '
        'txtDescricao
        '
        Me.txtDescricao.Location = New System.Drawing.Point(5, 110)
        Me.txtDescricao.MaxLength = 40
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(416, 20)
        Me.txtDescricao.TabIndex = 220
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(5, 181)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(188, 16)
        Me.Label1.TabIndex = 218
        Me.Label1.Text = "Filial Pagadora"
        '
        'cboFilialPagadora
        '
        Me.cboFilialPagadora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilialPagadora.Location = New System.Drawing.Point(5, 197)
        Me.cboFilialPagadora.Name = "cboFilialPagadora"
        Me.cboFilialPagadora.Size = New System.Drawing.Size(196, 21)
        Me.cboFilialPagadora.TabIndex = 217
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(5, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(188, 16)
        Me.Label2.TabIndex = 224
        Me.Label2.Text = "Conta Bancaria"
        '
        'cboContaBancaria
        '
        Me.cboContaBancaria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboContaBancaria.Location = New System.Drawing.Point(5, 66)
        Me.cboContaBancaria.Name = "cboContaBancaria"
        Me.cboContaBancaria.Size = New System.Drawing.Size(295, 21)
        Me.cboContaBancaria.TabIndex = 223
        '
        'grpProvisaoImpostos
        '
        Me.grpProvisaoImpostos.Controls.Add(Me.txtValorLiquido)
        Me.grpProvisaoImpostos.Controls.Add(Me.txtValorBruto)
        Me.grpProvisaoImpostos.Controls.Add(Me.Label10)
        Me.grpProvisaoImpostos.Controls.Add(Me.txtValorProvisao)
        Me.grpProvisaoImpostos.Controls.Add(Me.Label9)
        Me.grpProvisaoImpostos.Controls.Add(Me.Label8)
        Me.grpProvisaoImpostos.Controls.Add(Me.grdGeral)
        Me.grpProvisaoImpostos.Location = New System.Drawing.Point(5, 226)
        Me.grpProvisaoImpostos.Name = "grpProvisaoImpostos"
        Me.grpProvisaoImpostos.Size = New System.Drawing.Size(416, 156)
        Me.grpProvisaoImpostos.TabIndex = 225
        Me.grpProvisaoImpostos.Text = "Provisão Impostos"
        '
        'txtValorLiquido
        '
        Me.txtValorLiquido.Location = New System.Drawing.Point(320, 125)
        Me.txtValorLiquido.Name = "txtValorLiquido"
        Me.txtValorLiquido.ReadOnly = True
        Me.txtValorLiquido.Size = New System.Drawing.Size(93, 21)
        Me.txtValorLiquido.TabIndex = 388
        '
        'txtValorBruto
        '
        Me.txtValorBruto.Location = New System.Drawing.Point(320, 37)
        Me.txtValorBruto.Name = "txtValorBruto"
        Me.txtValorBruto.ReadOnly = True
        Me.txtValorBruto.Size = New System.Drawing.Size(93, 21)
        Me.txtValorBruto.TabIndex = 387
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(331, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 16)
        Me.Label10.TabIndex = 228
        Me.Label10.Text = "Valor Bruto"
        '
        'txtValorProvisao
        '
        Me.txtValorProvisao.Location = New System.Drawing.Point(320, 82)
        Me.txtValorProvisao.Name = "txtValorProvisao"
        Me.txtValorProvisao.ReadOnly = True
        Me.txtValorProvisao.Size = New System.Drawing.Size(93, 21)
        Me.txtValorProvisao.TabIndex = 386
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(331, 108)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 16)
        Me.Label9.TabIndex = 226
        Me.Label9.Text = "Valor Liquido"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(331, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 16)
        Me.Label8.TabIndex = 224
        Me.Label8.Text = "Valor Provisão"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(86, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 16)
        Me.Label3.TabIndex = 226
        Me.Label3.Text = "Operação Bancaria"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 227
        Me.Label4.Text = "Favorecido"
        '
        'txtFavorecido
        '
        Me.txtFavorecido.Location = New System.Drawing.Point(5, 153)
        Me.txtFavorecido.Name = "txtFavorecido"
        Me.txtFavorecido.Size = New System.Drawing.Size(416, 20)
        Me.txtFavorecido.TabIndex = 228
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(207, 181)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(188, 16)
        Me.Label7.TabIndex = 229
        Me.Label7.Text = "Filial Debito"
        '
        'cboFilialDebito
        '
        Me.cboFilialDebito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilialDebito.Location = New System.Drawing.Point(207, 198)
        Me.cboFilialDebito.Name = "cboFilialDebito"
        Me.cboFilialDebito.Size = New System.Drawing.Size(216, 21)
        Me.cboFilialDebito.TabIndex = 230
        '
        'optTipo
        '
        Appearance13.TextHAlignAsString = "Center"
        Appearance13.TextVAlignAsString = "Middle"
        Me.optTipo.Appearance = Appearance13
        Me.optTipo.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance14.TextHAlignAsString = "Center"
        Appearance14.TextVAlignAsString = "Middle"
        Me.optTipo.ItemAppearance = Appearance14
        Me.optTipo.ItemOrigin = New System.Drawing.Point(4, 1)
        ValueListItem1.DataValue = "C"
        ValueListItem1.DisplayText = "Credito"
        ValueListItem2.DataValue = "D"
        ValueListItem2.DisplayText = "Debito"
        Me.optTipo.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2})
        Me.optTipo.ItemSpacingVertical = 2
        Me.optTipo.Location = New System.Drawing.Point(5, 5)
        Me.optTipo.Name = "optTipo"
        Me.optTipo.Size = New System.Drawing.Size(73, 37)
        Me.optTipo.TabIndex = 231
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(5, 390)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 232
        Me.cmdGravar.TabStop = False
        Me.cmdGravar.Text = "G"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(376, 390)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 233
        Me.cmdFechar.Text = "F"
        '
        'txtValor
        '
        Me.txtValor.Location = New System.Drawing.Point(306, 66)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(115, 21)
        Me.txtValor.TabIndex = 387
        '
        'Pesq_OperacaoBancaria
        '
        Me.Pesq_OperacaoBancaria.BancoDados_Campo_Codigo = "CD_FORNECEDOR"
        Me.Pesq_OperacaoBancaria.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_OperacaoBancaria.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_OperacaoBancaria.BancoDados_Campo_Descricao = "NO_RAZAO_SOCIAL"
        Me.Pesq_OperacaoBancaria.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_OperacaoBancaria.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_OperacaoBancaria.BancoDados_Tabela = "FORNECEDOR F"
        Me.Pesq_OperacaoBancaria.Codigo = 0
        Me.Pesq_OperacaoBancaria.ExibirCodigo = True
        Me.Pesq_OperacaoBancaria.Location = New System.Drawing.Point(86, 19)
        Me.Pesq_OperacaoBancaria.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_OperacaoBancaria.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_OperacaoBancaria.Name = "Pesq_OperacaoBancaria"
        Me.Pesq_OperacaoBancaria.Size = New System.Drawing.Size(337, 28)
        Me.Pesq_OperacaoBancaria.TabIndex = 63
        Me.Pesq_OperacaoBancaria.TelaFiltro = False
        Me.Pesq_OperacaoBancaria.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'frmCadastroMovimentacaoBancaria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(426, 440)
        Me.Controls.Add(Me.txtValor)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.optTipo)
        Me.Controls.Add(Me.cboFilialDebito)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtFavorecido)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.grpProvisaoImpostos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboContaBancaria)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtDescricao)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboFilialPagadora)
        Me.Controls.Add(Me.Pesq_OperacaoBancaria)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCadastroMovimentacaoBancaria"
        Me.Text = "Movimentação Bancaria"
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpProvisaoImpostos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpProvisaoImpostos.ResumeLayout(False)
        Me.grpProvisaoImpostos.PerformLayout()
        CType(Me.txtValorLiquido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorBruto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorProvisao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdGeral As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Pesq_OperacaoBancaria As Logus.Pesq_CodigoNome
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDescricao As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboFilialPagadora As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboContaBancaria As System.Windows.Forms.ComboBox
    Friend WithEvents grpProvisaoImpostos As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFavorecido As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboFilialDebito As System.Windows.Forms.ComboBox
    Friend WithEvents optTipo As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtValorLiquido As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents txtValorBruto As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents txtValorProvisao As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents txtValor As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
End Class
