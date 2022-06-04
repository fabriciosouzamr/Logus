<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmREL_Movimentacao
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
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmREL_Movimentacao))
        Me.crvMain = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.lblR_Filial = New System.Windows.Forms.Label
        Me.lblR_Fornecedor = New System.Windows.Forms.Label
        Me.optTipoPessoa = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdImprimir = New Infragistics.Win.Misc.UltraButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtDataFinal = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtDataInicial = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.cboTipoCacau = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.chkExibeCessaoDireito = New System.Windows.Forms.CheckBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdExportaRelatorio = New Infragistics.Win.Misc.UltraButton
        Me.grpAnalise = New System.Windows.Forms.GroupBox
        Me.grdAnalise = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.lblR_SelecaoOpcoes = New System.Windows.Forms.Label
        Me.SelecaoFornecedor = New Logus.Selecao
        Me.SelecaoOpcoes = New Logus.Selecao
        Me.SelecaoFilialRecebimento = New Logus.Selecao
        Me.SelecaoTipoNovimentacao = New Logus.Selecao
        Me.SelecaoFilialMovimentacao = New Logus.Selecao
        CType(Me.optTipoPessoa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtDataFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpAnalise.SuspendLayout()
        CType(Me.grdAnalise, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'crvMain
        '
        Me.crvMain.ActiveViewIndex = -1
        Me.crvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvMain.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.crvMain.Location = New System.Drawing.Point(5, 166)
        Me.crvMain.Name = "crvMain"
        Me.crvMain.SelectionFormula = ""
        Me.crvMain.ShowCloseButton = False
        Me.crvMain.ShowGroupTreeButton = False
        Me.crvMain.ShowRefreshButton = False
        Me.crvMain.Size = New System.Drawing.Size(838, 384)
        Me.crvMain.TabIndex = 285
        Me.crvMain.ViewTimeSelectionFormula = ""
        '
        'lblR_Filial
        '
        Me.lblR_Filial.AutoSize = True
        Me.lblR_Filial.Location = New System.Drawing.Point(5, 62)
        Me.lblR_Filial.Name = "lblR_Filial"
        Me.lblR_Filial.Size = New System.Drawing.Size(100, 13)
        Me.lblR_Filial.TabIndex = 291
        Me.lblR_Filial.Text = "Filial Movimentação"
        '
        'lblR_Fornecedor
        '
        Me.lblR_Fornecedor.AutoSize = True
        Me.lblR_Fornecedor.Location = New System.Drawing.Point(5, 104)
        Me.lblR_Fornecedor.Name = "lblR_Fornecedor"
        Me.lblR_Fornecedor.Size = New System.Drawing.Size(61, 13)
        Me.lblR_Fornecedor.TabIndex = 289
        Me.lblR_Fornecedor.Text = "Fornecedor"
        '
        'optTipoPessoa
        '
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        Me.optTipoPessoa.Appearance = Appearance1
        Me.optTipoPessoa.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.optTipoPessoa.CheckedIndex = 0
        Appearance2.TextHAlignAsString = "Center"
        Appearance2.TextVAlignAsString = "Middle"
        Me.optTipoPessoa.ItemAppearance = Appearance2
        Me.optTipoPessoa.ItemOrigin = New System.Drawing.Point(2, 2)
        ValueListItem1.DataValue = "T"
        ValueListItem1.DisplayText = "Todos"
        ValueListItem2.DataValue = "F"
        ValueListItem2.DisplayText = "Física"
        ValueListItem3.DataValue = "J"
        ValueListItem3.DisplayText = "Jurídica"
        Me.optTipoPessoa.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem3})
        Me.optTipoPessoa.Location = New System.Drawing.Point(625, 12)
        Me.optTipoPessoa.Name = "optTipoPessoa"
        Me.optTipoPessoa.Size = New System.Drawing.Size(82, 58)
        Me.optTipoPessoa.TabIndex = 293
        Me.optTipoPessoa.Text = "Todos"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(248, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 13)
        Me.Label3.TabIndex = 294
        Me.Label3.Text = "Tipo de Movimentação"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(662, 114)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 297
        Me.cmdFechar.Text = "F"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdImprimir.Location = New System.Drawing.Point(560, 114)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(45, 45)
        Me.cmdImprimir.TabIndex = 296
        Me.cmdImprimir.Text = "I"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDataFinal)
        Me.GroupBox1.Controls.Add(Me.txtDataInicial)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(235, 49)
        Me.GroupBox1.TabIndex = 298
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Período"
        '
        'txtDataFinal
        '
        Me.txtDataFinal.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataFinal.Location = New System.Drawing.Point(122, 17)
        Me.txtDataFinal.Name = "txtDataFinal"
        Me.txtDataFinal.Size = New System.Drawing.Size(104, 23)
        Me.txtDataFinal.TabIndex = 226
        Me.txtDataFinal.Value = Nothing
        '
        'txtDataInicial
        '
        Me.txtDataInicial.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataInicial.Location = New System.Drawing.Point(10, 17)
        Me.txtDataInicial.Name = "txtDataInicial"
        Me.txtDataInicial.Size = New System.Drawing.Size(104, 23)
        Me.txtDataInicial.TabIndex = 225
        Me.txtDataInicial.Value = Nothing
        '
        'cboTipoCacau
        '
        Me.cboTipoCacau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoCacau.Location = New System.Drawing.Point(528, 19)
        Me.cboTipoCacau.Name = "cboTipoCacau"
        Me.cboTipoCacau.Size = New System.Drawing.Size(91, 21)
        Me.cboTipoCacau.TabIndex = 299
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(528, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 300
        Me.Label4.Text = "Tipo Cacau"
        '
        'chkExibeCessaoDireito
        '
        Me.chkExibeCessaoDireito.AutoSize = True
        Me.chkExibeCessaoDireito.BackColor = System.Drawing.Color.Transparent
        Me.chkExibeCessaoDireito.Location = New System.Drawing.Point(495, 96)
        Me.chkExibeCessaoDireito.Name = "chkExibeCessaoDireito"
        Me.chkExibeCessaoDireito.Size = New System.Drawing.Size(123, 17)
        Me.chkExibeCessaoDireito.TabIndex = 302
        Me.chkExibeCessaoDireito.Text = "Exibe Cessão Direito"
        Me.chkExibeCessaoDireito.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(247, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 13)
        Me.Label5.TabIndex = 305
        Me.Label5.Text = "Filial Recebimento"
        '
        'cmdExportaRelatorio
        '
        Me.cmdExportaRelatorio.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExportaRelatorio.Location = New System.Drawing.Point(611, 114)
        Me.cmdExportaRelatorio.Name = "cmdExportaRelatorio"
        Me.cmdExportaRelatorio.Size = New System.Drawing.Size(45, 45)
        Me.cmdExportaRelatorio.TabIndex = 492
        Me.cmdExportaRelatorio.Text = "ER"
        '
        'grpAnalise
        '
        Me.grpAnalise.Controls.Add(Me.grdAnalise)
        Me.grpAnalise.Location = New System.Drawing.Point(715, 5)
        Me.grpAnalise.Name = "grpAnalise"
        Me.grpAnalise.Size = New System.Drawing.Size(245, 112)
        Me.grpAnalise.TabIndex = 298
        Me.grpAnalise.TabStop = False
        Me.grpAnalise.Text = "Análise"
        '
        'grdAnalise
        '
        Appearance15.BackColor = System.Drawing.SystemColors.Window
        Appearance15.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdAnalise.DisplayLayout.Appearance = Appearance15
        Me.grdAnalise.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdAnalise.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance16.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance16.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance16.BorderColor = System.Drawing.SystemColors.Window
        Me.grdAnalise.DisplayLayout.GroupByBox.Appearance = Appearance16
        Appearance17.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdAnalise.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance17
        Me.grdAnalise.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance18.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance18.BackColor2 = System.Drawing.SystemColors.Control
        Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance18.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdAnalise.DisplayLayout.GroupByBox.PromptAppearance = Appearance18
        Me.grdAnalise.DisplayLayout.MaxColScrollRegions = 1
        Me.grdAnalise.DisplayLayout.MaxRowScrollRegions = 1
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Appearance19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdAnalise.DisplayLayout.Override.ActiveCellAppearance = Appearance19
        Appearance20.BackColor = System.Drawing.SystemColors.Highlight
        Appearance20.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdAnalise.DisplayLayout.Override.ActiveRowAppearance = Appearance20
        Me.grdAnalise.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdAnalise.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance21.BackColor = System.Drawing.SystemColors.Window
        Me.grdAnalise.DisplayLayout.Override.CardAreaAppearance = Appearance21
        Appearance22.BorderColor = System.Drawing.Color.Silver
        Appearance22.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdAnalise.DisplayLayout.Override.CellAppearance = Appearance22
        Me.grdAnalise.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdAnalise.DisplayLayout.Override.CellPadding = 0
        Appearance23.BackColor = System.Drawing.SystemColors.Control
        Appearance23.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance23.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance23.BorderColor = System.Drawing.SystemColors.Window
        Me.grdAnalise.DisplayLayout.Override.GroupByRowAppearance = Appearance23
        Appearance24.TextHAlignAsString = "Left"
        Me.grdAnalise.DisplayLayout.Override.HeaderAppearance = Appearance24
        Me.grdAnalise.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdAnalise.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance25.BackColor = System.Drawing.SystemColors.Window
        Appearance25.BorderColor = System.Drawing.Color.Silver
        Me.grdAnalise.DisplayLayout.Override.RowAppearance = Appearance25
        Me.grdAnalise.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance26.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdAnalise.DisplayLayout.Override.TemplateAddRowAppearance = Appearance26
        Me.grdAnalise.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdAnalise.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdAnalise.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdAnalise.Location = New System.Drawing.Point(6, 15)
        Me.grdAnalise.Name = "grdAnalise"
        Me.grdAnalise.Size = New System.Drawing.Size(233, 91)
        Me.grdAnalise.TabIndex = 494
        Me.grdAnalise.Text = "UltraGrid1"
        '
        'lblR_SelecaoOpcoes
        '
        Me.lblR_SelecaoOpcoes.AutoSize = True
        Me.lblR_SelecaoOpcoes.Location = New System.Drawing.Point(493, 62)
        Me.lblR_SelecaoOpcoes.Name = "lblR_SelecaoOpcoes"
        Me.lblR_SelecaoOpcoes.Size = New System.Drawing.Size(44, 13)
        Me.lblR_SelecaoOpcoes.TabIndex = 300
        Me.lblR_SelecaoOpcoes.Text = "Agrupar"
        '
        'SelecaoFornecedor
        '
        Me.SelecaoFornecedor.BackColor = System.Drawing.Color.White
        Me.SelecaoFornecedor.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoFornecedor.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoFornecedor.BancoDados_Campo_OrdenarConsulta = True
        Me.SelecaoFornecedor.BancoDados_Tabela = Nothing
        Me.SelecaoFornecedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoFornecedor.Location = New System.Drawing.Point(5, 118)
        Me.SelecaoFornecedor.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoFornecedor.MultiplaSelecao = False
        Me.SelecaoFornecedor.Name = "SelecaoFornecedor"
        Me.SelecaoFornecedor.Size = New System.Drawing.Size(482, 20)
        Me.SelecaoFornecedor.TabIndex = 307
        '
        'SelecaoOpcoes
        '
        Me.SelecaoOpcoes.BackColor = System.Drawing.Color.White
        Me.SelecaoOpcoes.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoOpcoes.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoOpcoes.BancoDados_Campo_OrdenarConsulta = True
        Me.SelecaoOpcoes.BancoDados_Tabela = Nothing
        Me.SelecaoOpcoes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoOpcoes.Location = New System.Drawing.Point(495, 76)
        Me.SelecaoOpcoes.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoOpcoes.MultiplaSelecao = False
        Me.SelecaoOpcoes.Name = "SelecaoOpcoes"
        Me.SelecaoOpcoes.Size = New System.Drawing.Size(212, 20)
        Me.SelecaoOpcoes.TabIndex = 306
        '
        'SelecaoFilialRecebimento
        '
        Me.SelecaoFilialRecebimento.BackColor = System.Drawing.Color.White
        Me.SelecaoFilialRecebimento.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoFilialRecebimento.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoFilialRecebimento.BancoDados_Campo_OrdenarConsulta = True
        Me.SelecaoFilialRecebimento.BancoDados_Tabela = Nothing
        Me.SelecaoFilialRecebimento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoFilialRecebimento.Location = New System.Drawing.Point(247, 76)
        Me.SelecaoFilialRecebimento.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoFilialRecebimento.MultiplaSelecao = False
        Me.SelecaoFilialRecebimento.Name = "SelecaoFilialRecebimento"
        Me.SelecaoFilialRecebimento.Size = New System.Drawing.Size(240, 20)
        Me.SelecaoFilialRecebimento.TabIndex = 306
        '
        'SelecaoTipoNovimentacao
        '
        Me.SelecaoTipoNovimentacao.BackColor = System.Drawing.Color.White
        Me.SelecaoTipoNovimentacao.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoTipoNovimentacao.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoTipoNovimentacao.BancoDados_Campo_OrdenarConsulta = True
        Me.SelecaoTipoNovimentacao.BancoDados_Tabela = Nothing
        Me.SelecaoTipoNovimentacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoTipoNovimentacao.Location = New System.Drawing.Point(248, 19)
        Me.SelecaoTipoNovimentacao.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoTipoNovimentacao.MultiplaSelecao = False
        Me.SelecaoTipoNovimentacao.Name = "SelecaoTipoNovimentacao"
        Me.SelecaoTipoNovimentacao.Size = New System.Drawing.Size(272, 20)
        Me.SelecaoTipoNovimentacao.TabIndex = 295
        '
        'SelecaoFilialMovimentacao
        '
        Me.SelecaoFilialMovimentacao.BackColor = System.Drawing.Color.White
        Me.SelecaoFilialMovimentacao.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoFilialMovimentacao.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoFilialMovimentacao.BancoDados_Campo_OrdenarConsulta = True
        Me.SelecaoFilialMovimentacao.BancoDados_Tabela = Nothing
        Me.SelecaoFilialMovimentacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoFilialMovimentacao.Location = New System.Drawing.Point(5, 76)
        Me.SelecaoFilialMovimentacao.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoFilialMovimentacao.MultiplaSelecao = False
        Me.SelecaoFilialMovimentacao.Name = "SelecaoFilialMovimentacao"
        Me.SelecaoFilialMovimentacao.Size = New System.Drawing.Size(234, 20)
        Me.SelecaoFilialMovimentacao.TabIndex = 292
        '
        'frmREL_Movimentacao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1216, 638)
        Me.Controls.Add(Me.cmdExportaRelatorio)
        Me.Controls.Add(Me.SelecaoFornecedor)
        Me.Controls.Add(Me.SelecaoOpcoes)
        Me.Controls.Add(Me.SelecaoFilialRecebimento)
        Me.Controls.Add(Me.chkExibeCessaoDireito)
        Me.Controls.Add(Me.grpAnalise)
        Me.Controls.Add(Me.lblR_SelecaoOpcoes)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboTipoCacau)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.SelecaoTipoNovimentacao)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.optTipoPessoa)
        Me.Controls.Add(Me.SelecaoFilialMovimentacao)
        Me.Controls.Add(Me.lblR_Filial)
        Me.Controls.Add(Me.lblR_Fornecedor)
        Me.Controls.Add(Me.crvMain)
        Me.Controls.Add(Me.Label5)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmREL_Movimentacao"
        Me.Text = "Relatório Movimentação"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.optTipoPessoa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtDataFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataInicial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpAnalise.ResumeLayout(False)
        CType(Me.grdAnalise, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents crvMain As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents SelecaoFilialMovimentacao As Logus.Selecao
    Friend WithEvents lblR_Filial As System.Windows.Forms.Label
    Friend WithEvents lblR_Fornecedor As System.Windows.Forms.Label
    Friend WithEvents optTipoPessoa As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents SelecaoTipoNovimentacao As Logus.Selecao
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdImprimir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDataFinal As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtDataInicial As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents cboTipoCacau As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkExibeCessaoDireito As System.Windows.Forms.CheckBox
    Friend WithEvents SelecaoFilialRecebimento As Logus.Selecao
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents SelecaoFornecedor As Logus.Selecao
    Friend WithEvents cmdExportaRelatorio As Infragistics.Win.Misc.UltraButton
    Friend WithEvents grpAnalise As System.Windows.Forms.GroupBox
    Friend WithEvents grdAnalise As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents SelecaoOpcoes As Logus.Selecao
    Friend WithEvents lblR_SelecaoOpcoes As System.Windows.Forms.Label
End Class
