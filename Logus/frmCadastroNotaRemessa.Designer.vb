<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroNotaRemessa
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
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.txtDataMovimentacao_Fim = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.grdGeral = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.cmdPesquisar = New Infragistics.Win.Misc.UltraButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtDataMovimentacao_Ini = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.grdNotaRemessa = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtSerie = New System.Windows.Forms.TextBox
        Me.txtDataNF = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtNotaFiscal = New System.Windows.Forms.TextBox
        Me.txtQuantidade = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.cmdCopiar = New Infragistics.Win.Misc.UltraButton
        Me.cmdExcluir = New Infragistics.Win.Misc.UltraButton
        Me.cmdNovo = New Infragistics.Win.Misc.UltraButton
        Me.txtQuantidadeNFs = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtSaldo = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Label7 = New System.Windows.Forms.Label
        Me.SelecaoFilial = New Logus.Selecao
        Me.Pesq_TipoMovimentacao = New Logus.Pesq_CodigoNome
        CType(Me.txtDataMovimentacao_Fim, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataMovimentacao_Ini, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdNotaRemessa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataNF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantidade, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantidadeNFs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtDataMovimentacao_Fim
        '
        Me.txtDataMovimentacao_Fim.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtDataMovimentacao_Fim.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataMovimentacao_Fim.Location = New System.Drawing.Point(111, 23)
        Me.txtDataMovimentacao_Fim.Name = "txtDataMovimentacao_Fim"
        Me.txtDataMovimentacao_Fim.Size = New System.Drawing.Size(91, 23)
        Me.txtDataMovimentacao_Fim.TabIndex = 175
        Me.txtDataMovimentacao_Fim.Value = Nothing
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
        Me.grdGeral.Location = New System.Drawing.Point(3, 57)
        Me.grdGeral.Name = "grdGeral"
        Me.grdGeral.Size = New System.Drawing.Size(740, 198)
        Me.grdGeral.TabIndex = 174
        '
        'cmdPesquisar
        '
        Me.cmdPesquisar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdPesquisar.Location = New System.Drawing.Point(647, 6)
        Me.cmdPesquisar.Name = "cmdPesquisar"
        Me.cmdPesquisar.Size = New System.Drawing.Size(45, 45)
        Me.cmdPesquisar.TabIndex = 173
        Me.cmdPesquisar.Text = "P"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(205, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 13)
        Me.Label4.TabIndex = 172
        Me.Label4.Text = "Tipo de Movimentação"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(438, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 13)
        Me.Label3.TabIndex = 169
        Me.Label3.Text = "Filial de Movimentação"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(96, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(13, 13)
        Me.Label2.TabIndex = 168
        Me.Label2.Text = "a"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 13)
        Me.Label1.TabIndex = 167
        Me.Label1.Text = "Período da Movimentação"
        '
        'txtDataMovimentacao_Ini
        '
        Me.txtDataMovimentacao_Ini.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtDataMovimentacao_Ini.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataMovimentacao_Ini.Location = New System.Drawing.Point(3, 23)
        Me.txtDataMovimentacao_Ini.Name = "txtDataMovimentacao_Ini"
        Me.txtDataMovimentacao_Ini.Size = New System.Drawing.Size(91, 23)
        Me.txtDataMovimentacao_Ini.TabIndex = 166
        Me.txtDataMovimentacao_Ini.Value = Nothing
        '
        'grdNotaRemessa
        '
        Appearance25.BackColor = System.Drawing.SystemColors.Window
        Appearance25.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdNotaRemessa.DisplayLayout.Appearance = Appearance25
        Me.grdNotaRemessa.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdNotaRemessa.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance26.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance26.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance26.BorderColor = System.Drawing.SystemColors.Window
        Me.grdNotaRemessa.DisplayLayout.GroupByBox.Appearance = Appearance26
        Appearance27.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdNotaRemessa.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance27
        Me.grdNotaRemessa.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance28.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance28.BackColor2 = System.Drawing.SystemColors.Control
        Appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance28.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdNotaRemessa.DisplayLayout.GroupByBox.PromptAppearance = Appearance28
        Me.grdNotaRemessa.DisplayLayout.MaxColScrollRegions = 1
        Me.grdNotaRemessa.DisplayLayout.MaxRowScrollRegions = 1
        Appearance29.BackColor = System.Drawing.SystemColors.Window
        Appearance29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdNotaRemessa.DisplayLayout.Override.ActiveCellAppearance = Appearance29
        Appearance30.BackColor = System.Drawing.SystemColors.Highlight
        Appearance30.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdNotaRemessa.DisplayLayout.Override.ActiveRowAppearance = Appearance30
        Me.grdNotaRemessa.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdNotaRemessa.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance31.BackColor = System.Drawing.SystemColors.Window
        Me.grdNotaRemessa.DisplayLayout.Override.CardAreaAppearance = Appearance31
        Appearance32.BorderColor = System.Drawing.Color.Silver
        Appearance32.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdNotaRemessa.DisplayLayout.Override.CellAppearance = Appearance32
        Me.grdNotaRemessa.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdNotaRemessa.DisplayLayout.Override.CellPadding = 0
        Appearance33.BackColor = System.Drawing.SystemColors.Control
        Appearance33.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance33.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance33.BorderColor = System.Drawing.SystemColors.Window
        Me.grdNotaRemessa.DisplayLayout.Override.GroupByRowAppearance = Appearance33
        Appearance34.TextHAlignAsString = "Left"
        Me.grdNotaRemessa.DisplayLayout.Override.HeaderAppearance = Appearance34
        Me.grdNotaRemessa.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdNotaRemessa.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance35.BackColor = System.Drawing.SystemColors.Window
        Appearance35.BorderColor = System.Drawing.Color.Silver
        Me.grdNotaRemessa.DisplayLayout.Override.RowAppearance = Appearance35
        Me.grdNotaRemessa.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance36.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdNotaRemessa.DisplayLayout.Override.TemplateAddRowAppearance = Appearance36
        Me.grdNotaRemessa.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdNotaRemessa.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdNotaRemessa.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdNotaRemessa.Location = New System.Drawing.Point(3, 309)
        Me.grdNotaRemessa.Name = "grdNotaRemessa"
        Me.grdNotaRemessa.Size = New System.Drawing.Size(740, 174)
        Me.grdNotaRemessa.TabIndex = 176
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(698, 6)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 234
        Me.cmdFechar.Text = "F"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(0, 263)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 13)
        Me.Label11.TabIndex = 284
        Me.Label11.Text = "Data N.F."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(160, 263)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 13)
        Me.Label10.TabIndex = 283
        Me.Label10.Text = "Serie"
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(160, 282)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(43, 20)
        Me.txtSerie.TabIndex = 279
        '
        'txtDataNF
        '
        Me.txtDataNF.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtDataNF.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataNF.Location = New System.Drawing.Point(3, 280)
        Me.txtDataNF.Name = "txtDataNF"
        Me.txtDataNF.Size = New System.Drawing.Size(91, 23)
        Me.txtDataNF.TabIndex = 277
        Me.txtDataNF.Value = Nothing
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(100, 263)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 282
        Me.Label9.Text = "Nº N.F."
        '
        'txtNotaFiscal
        '
        Me.txtNotaFiscal.Location = New System.Drawing.Point(97, 282)
        Me.txtNotaFiscal.Name = "txtNotaFiscal"
        Me.txtNotaFiscal.Size = New System.Drawing.Size(57, 20)
        Me.txtNotaFiscal.TabIndex = 278
        '
        'txtQuantidade
        '
        Me.txtQuantidade.Location = New System.Drawing.Point(212, 282)
        Me.txtQuantidade.MaskInput = "{LOC}-nnnnnn,nnn"
        Me.txtQuantidade.Name = "txtQuantidade"
        Me.txtQuantidade.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtQuantidade.Size = New System.Drawing.Size(73, 21)
        Me.txtQuantidade.TabIndex = 280
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(209, 263)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 281
        Me.Label6.Text = "Quantidade"
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(468, 261)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 287
        Me.cmdGravar.TabStop = False
        Me.cmdGravar.Text = "G"
        '
        'cmdCopiar
        '
        Me.cmdCopiar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdCopiar.Location = New System.Drawing.Point(694, 261)
        Me.cmdCopiar.Name = "cmdCopiar"
        Me.cmdCopiar.Size = New System.Drawing.Size(45, 45)
        Me.cmdCopiar.TabIndex = 290
        Me.cmdCopiar.Text = "AD"
        '
        'cmdExcluir
        '
        Me.cmdExcluir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExcluir.Location = New System.Drawing.Point(643, 261)
        Me.cmdExcluir.Name = "cmdExcluir"
        Me.cmdExcluir.Size = New System.Drawing.Size(45, 45)
        Me.cmdExcluir.TabIndex = 289
        Me.cmdExcluir.Text = "E"
        '
        'cmdNovo
        '
        Me.cmdNovo.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdNovo.Location = New System.Drawing.Point(519, 261)
        Me.cmdNovo.Name = "cmdNovo"
        Me.cmdNovo.Size = New System.Drawing.Size(45, 45)
        Me.cmdNovo.TabIndex = 288
        Me.cmdNovo.Text = "N"
        '
        'txtQuantidadeNFs
        '
        Me.txtQuantidadeNFs.Location = New System.Drawing.Point(291, 282)
        Me.txtQuantidadeNFs.MaskInput = "{LOC}-nnnnnn,nnn"
        Me.txtQuantidadeNFs.Name = "txtQuantidadeNFs"
        Me.txtQuantidadeNFs.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtQuantidadeNFs.ReadOnly = True
        Me.txtQuantidadeNFs.Size = New System.Drawing.Size(81, 21)
        Me.txtQuantidadeNFs.TabIndex = 291
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(288, 263)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 13)
        Me.Label5.TabIndex = 292
        Me.Label5.Text = "Quantidade NFs"
        '
        'txtSaldo
        '
        Me.txtSaldo.Location = New System.Drawing.Point(385, 281)
        Me.txtSaldo.MaskInput = "{LOC}-nnnnnn,nnn"
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtSaldo.ReadOnly = True
        Me.txtSaldo.Size = New System.Drawing.Size(73, 21)
        Me.txtSaldo.TabIndex = 293
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(382, 263)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 294
        Me.Label7.Text = "Saldo"
        '
        'SelecaoFilial
        '
        Me.SelecaoFilial.BackColor = System.Drawing.Color.White
        Me.SelecaoFilial.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoFilial.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoFilial.BancoDados_Tabela = Nothing
        Me.SelecaoFilial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoFilial.Location = New System.Drawing.Point(441, 26)
        Me.SelecaoFilial.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoFilial.Name = "SelecaoFilial"
        Me.SelecaoFilial.Size = New System.Drawing.Size(200, 20)
        Me.SelecaoFilial.TabIndex = 295
        '
        'Pesq_TipoMovimentacao
        '
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_Codigo = "CD_FORNECEDOR"
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_Descricao = "NO_RAZAO_SOCIAL"
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_TipoMovimentacao.BancoDados_Tabela = "FORNECEDOR F"
        Me.Pesq_TipoMovimentacao.Codigo = 0
        Me.Pesq_TipoMovimentacao.ExibirCodigo = True
        Me.Pesq_TipoMovimentacao.Location = New System.Drawing.Point(208, 23)
        Me.Pesq_TipoMovimentacao.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_TipoMovimentacao.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_TipoMovimentacao.Name = "Pesq_TipoMovimentacao"
        Me.Pesq_TipoMovimentacao.Size = New System.Drawing.Size(227, 28)
        Me.Pesq_TipoMovimentacao.TabIndex = 171
        Me.Pesq_TipoMovimentacao.TelaFiltro = False
        Me.Pesq_TipoMovimentacao.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'frmCadastroNotaRemessa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(748, 488)
        Me.Controls.Add(Me.SelecaoFilial)
        Me.Controls.Add(Me.txtSaldo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtQuantidadeNFs)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmdCopiar)
        Me.Controls.Add(Me.cmdExcluir)
        Me.Controls.Add(Me.cmdNovo)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtSerie)
        Me.Controls.Add(Me.txtDataNF)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtNotaFiscal)
        Me.Controls.Add(Me.txtQuantidade)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.grdNotaRemessa)
        Me.Controls.Add(Me.txtDataMovimentacao_Fim)
        Me.Controls.Add(Me.grdGeral)
        Me.Controls.Add(Me.cmdPesquisar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Pesq_TipoMovimentacao)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDataMovimentacao_Ini)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmCadastroNotaRemessa"
        Me.Text = "Cadastro Nota de Remessa"
        CType(Me.txtDataMovimentacao_Fim, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataMovimentacao_Ini, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdNotaRemessa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataNF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantidade, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantidadeNFs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSaldo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDataMovimentacao_Fim As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents grdGeral As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cmdPesquisar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Pesq_TipoMovimentacao As Logus.Pesq_CodigoNome
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDataMovimentacao_Ini As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents grdNotaRemessa As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents txtDataNF As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNotaFiscal As System.Windows.Forms.TextBox
    Friend WithEvents txtQuantidade As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdCopiar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdExcluir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdNovo As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtQuantidadeNFs As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSaldo As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents SelecaoFilial As Logus.Selecao
End Class
