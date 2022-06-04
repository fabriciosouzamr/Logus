<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmControleCompras
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
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
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
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
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
        Me.tbcGeral = New System.Windows.Forms.TabControl
        Me.tabContratoPAF = New System.Windows.Forms.TabPage
        Me.grdContratoPAF = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.tabNegociacao = New System.Windows.Forms.TabPage
        Me.grdNegociacao = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.tabContratoFixo = New System.Windows.Forms.TabPage
        Me.grdContratoFixo = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.SelecaoTipoCacau = New Logus.Selecao
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboOpcoes = New System.Windows.Forms.ComboBox
        Me.chkExcluiCancelado = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtDataFinal = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtDataInicial = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.cmdPesquisar = New Infragistics.Win.Misc.UltraButton
        Me.tbcGeral.SuspendLayout()
        Me.tabContratoPAF.SuspendLayout()
        CType(Me.grdContratoPAF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabNegociacao.SuspendLayout()
        CType(Me.grdNegociacao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabContratoFixo.SuspendLayout()
        CType(Me.grdContratoFixo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtDataFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbcGeral
        '
        Me.tbcGeral.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tbcGeral.Controls.Add(Me.tabContratoPAF)
        Me.tbcGeral.Controls.Add(Me.tabNegociacao)
        Me.tbcGeral.Controls.Add(Me.tabContratoFixo)
        Me.tbcGeral.Location = New System.Drawing.Point(2, 67)
        Me.tbcGeral.Name = "tbcGeral"
        Me.tbcGeral.SelectedIndex = 0
        Me.tbcGeral.Size = New System.Drawing.Size(764, 474)
        Me.tbcGeral.TabIndex = 235
        '
        'tabContratoPAF
        '
        Me.tabContratoPAF.Controls.Add(Me.grdContratoPAF)
        Me.tabContratoPAF.Location = New System.Drawing.Point(4, 25)
        Me.tabContratoPAF.Name = "tabContratoPAF"
        Me.tabContratoPAF.Padding = New System.Windows.Forms.Padding(3)
        Me.tabContratoPAF.Size = New System.Drawing.Size(756, 445)
        Me.tabContratoPAF.TabIndex = 0
        Me.tabContratoPAF.Text = "Contrato PAF"
        Me.tabContratoPAF.UseVisualStyleBackColor = True
        '
        'grdContratoPAF
        '
        Appearance20.BackColor = System.Drawing.SystemColors.Window
        Appearance20.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdContratoPAF.DisplayLayout.Appearance = Appearance20
        Me.grdContratoPAF.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdContratoPAF.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance21.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance21.BorderColor = System.Drawing.SystemColors.Window
        Me.grdContratoPAF.DisplayLayout.GroupByBox.Appearance = Appearance21
        Appearance22.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdContratoPAF.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance22
        Me.grdContratoPAF.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance23.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance23.BackColor2 = System.Drawing.SystemColors.Control
        Appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance23.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdContratoPAF.DisplayLayout.GroupByBox.PromptAppearance = Appearance23
        Me.grdContratoPAF.DisplayLayout.MaxColScrollRegions = 1
        Me.grdContratoPAF.DisplayLayout.MaxRowScrollRegions = 1
        Appearance24.BackColor = System.Drawing.SystemColors.Window
        Appearance24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdContratoPAF.DisplayLayout.Override.ActiveCellAppearance = Appearance24
        Appearance25.BackColor = System.Drawing.SystemColors.Highlight
        Appearance25.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdContratoPAF.DisplayLayout.Override.ActiveRowAppearance = Appearance25
        Me.grdContratoPAF.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdContratoPAF.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance26.BackColor = System.Drawing.SystemColors.Window
        Me.grdContratoPAF.DisplayLayout.Override.CardAreaAppearance = Appearance26
        Appearance27.BorderColor = System.Drawing.Color.Silver
        Appearance27.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdContratoPAF.DisplayLayout.Override.CellAppearance = Appearance27
        Me.grdContratoPAF.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdContratoPAF.DisplayLayout.Override.CellPadding = 0
        Appearance28.BackColor = System.Drawing.SystemColors.Control
        Appearance28.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance28.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance28.BorderColor = System.Drawing.SystemColors.Window
        Me.grdContratoPAF.DisplayLayout.Override.GroupByRowAppearance = Appearance28
        Appearance29.TextHAlignAsString = "Left"
        Me.grdContratoPAF.DisplayLayout.Override.HeaderAppearance = Appearance29
        Me.grdContratoPAF.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdContratoPAF.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance30.BackColor = System.Drawing.SystemColors.Window
        Appearance30.BorderColor = System.Drawing.Color.Silver
        Me.grdContratoPAF.DisplayLayout.Override.RowAppearance = Appearance30
        Me.grdContratoPAF.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance31.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdContratoPAF.DisplayLayout.Override.TemplateAddRowAppearance = Appearance31
        Me.grdContratoPAF.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdContratoPAF.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdContratoPAF.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdContratoPAF.Location = New System.Drawing.Point(5, 6)
        Me.grdContratoPAF.Name = "grdContratoPAF"
        Me.grdContratoPAF.Size = New System.Drawing.Size(835, 341)
        Me.grdContratoPAF.TabIndex = 235
        Me.grdContratoPAF.Text = "UltraGrid1"
        '
        'tabNegociacao
        '
        Me.tabNegociacao.Controls.Add(Me.grdNegociacao)
        Me.tabNegociacao.Location = New System.Drawing.Point(4, 25)
        Me.tabNegociacao.Name = "tabNegociacao"
        Me.tabNegociacao.Padding = New System.Windows.Forms.Padding(3)
        Me.tabNegociacao.Size = New System.Drawing.Size(846, 445)
        Me.tabNegociacao.TabIndex = 2
        Me.tabNegociacao.Text = "Negociação"
        Me.tabNegociacao.UseVisualStyleBackColor = True
        '
        'grdNegociacao
        '
        Appearance32.BackColor = System.Drawing.SystemColors.Window
        Appearance32.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdNegociacao.DisplayLayout.Appearance = Appearance32
        Me.grdNegociacao.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdNegociacao.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance33.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance33.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance33.BorderColor = System.Drawing.SystemColors.Window
        Me.grdNegociacao.DisplayLayout.GroupByBox.Appearance = Appearance33
        Appearance34.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdNegociacao.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance34
        Me.grdNegociacao.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance35.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance35.BackColor2 = System.Drawing.SystemColors.Control
        Appearance35.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance35.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdNegociacao.DisplayLayout.GroupByBox.PromptAppearance = Appearance35
        Me.grdNegociacao.DisplayLayout.MaxColScrollRegions = 1
        Me.grdNegociacao.DisplayLayout.MaxRowScrollRegions = 1
        Appearance36.BackColor = System.Drawing.SystemColors.Window
        Appearance36.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdNegociacao.DisplayLayout.Override.ActiveCellAppearance = Appearance36
        Appearance37.BackColor = System.Drawing.SystemColors.Highlight
        Appearance37.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdNegociacao.DisplayLayout.Override.ActiveRowAppearance = Appearance37
        Me.grdNegociacao.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdNegociacao.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance38.BackColor = System.Drawing.SystemColors.Window
        Me.grdNegociacao.DisplayLayout.Override.CardAreaAppearance = Appearance38
        Appearance39.BorderColor = System.Drawing.Color.Silver
        Appearance39.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdNegociacao.DisplayLayout.Override.CellAppearance = Appearance39
        Me.grdNegociacao.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdNegociacao.DisplayLayout.Override.CellPadding = 0
        Appearance40.BackColor = System.Drawing.SystemColors.Control
        Appearance40.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance40.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance40.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance40.BorderColor = System.Drawing.SystemColors.Window
        Me.grdNegociacao.DisplayLayout.Override.GroupByRowAppearance = Appearance40
        Appearance41.TextHAlignAsString = "Left"
        Me.grdNegociacao.DisplayLayout.Override.HeaderAppearance = Appearance41
        Me.grdNegociacao.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdNegociacao.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance42.BackColor = System.Drawing.SystemColors.Window
        Appearance42.BorderColor = System.Drawing.Color.Silver
        Me.grdNegociacao.DisplayLayout.Override.RowAppearance = Appearance42
        Me.grdNegociacao.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance43.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdNegociacao.DisplayLayout.Override.TemplateAddRowAppearance = Appearance43
        Me.grdNegociacao.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdNegociacao.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdNegociacao.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdNegociacao.Location = New System.Drawing.Point(5, 6)
        Me.grdNegociacao.Name = "grdNegociacao"
        Me.grdNegociacao.Size = New System.Drawing.Size(726, 210)
        Me.grdNegociacao.TabIndex = 237
        Me.grdNegociacao.Text = "UltraGrid1"
        '
        'tabContratoFixo
        '
        Me.tabContratoFixo.Controls.Add(Me.grdContratoFixo)
        Me.tabContratoFixo.Location = New System.Drawing.Point(4, 25)
        Me.tabContratoFixo.Name = "tabContratoFixo"
        Me.tabContratoFixo.Padding = New System.Windows.Forms.Padding(3)
        Me.tabContratoFixo.Size = New System.Drawing.Size(756, 445)
        Me.tabContratoFixo.TabIndex = 3
        Me.tabContratoFixo.Text = "Contrato Fixo"
        Me.tabContratoFixo.UseVisualStyleBackColor = True
        '
        'grdContratoFixo
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdContratoFixo.DisplayLayout.Appearance = Appearance1
        Me.grdContratoFixo.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdContratoFixo.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.grdContratoFixo.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdContratoFixo.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.grdContratoFixo.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdContratoFixo.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.grdContratoFixo.DisplayLayout.MaxColScrollRegions = 1
        Me.grdContratoFixo.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdContratoFixo.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdContratoFixo.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.grdContratoFixo.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdContratoFixo.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.grdContratoFixo.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdContratoFixo.DisplayLayout.Override.CellAppearance = Appearance8
        Me.grdContratoFixo.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdContratoFixo.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.grdContratoFixo.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.grdContratoFixo.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.grdContratoFixo.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdContratoFixo.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.grdContratoFixo.DisplayLayout.Override.RowAppearance = Appearance11
        Me.grdContratoFixo.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdContratoFixo.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.grdContratoFixo.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdContratoFixo.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdContratoFixo.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdContratoFixo.Location = New System.Drawing.Point(5, 6)
        Me.grdContratoFixo.Name = "grdContratoFixo"
        Me.grdContratoFixo.Size = New System.Drawing.Size(726, 210)
        Me.grdContratoFixo.TabIndex = 239
        Me.grdContratoFixo.Text = "UltraGrid1"
        '
        'SelecaoTipoCacau
        '
        Me.SelecaoTipoCacau.BackColor = System.Drawing.Color.White
        Me.SelecaoTipoCacau.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoTipoCacau.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoTipoCacau.BancoDados_Tabela = Nothing
        Me.SelecaoTipoCacau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoTipoCacau.Location = New System.Drawing.Point(396, 40)
        Me.SelecaoTipoCacau.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoTipoCacau.MultiplaSelecao = False
        Me.SelecaoTipoCacau.Name = "SelecaoTipoCacau"
        Me.SelecaoTipoCacau.Size = New System.Drawing.Size(200, 20)
        Me.SelecaoTipoCacau.TabIndex = 347
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(396, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 346
        Me.Label3.Text = "Tipo Cacau"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(210, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 345
        Me.Label2.Text = "Opções"
        '
        'cboOpcoes
        '
        Me.cboOpcoes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOpcoes.Location = New System.Drawing.Point(210, 40)
        Me.cboOpcoes.Name = "cboOpcoes"
        Me.cboOpcoes.Size = New System.Drawing.Size(180, 21)
        Me.cboOpcoes.TabIndex = 344
        '
        'chkExcluiCancelado
        '
        Me.chkExcluiCancelado.AutoSize = True
        Me.chkExcluiCancelado.Location = New System.Drawing.Point(602, 40)
        Me.chkExcluiCancelado.Name = "chkExcluiCancelado"
        Me.chkExcluiCancelado.Size = New System.Drawing.Size(113, 17)
        Me.chkExcluiCancelado.TabIndex = 343
        Me.chkExcluiCancelado.Text = "Exclui Cancelados"
        Me.chkExcluiCancelado.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDataFinal)
        Me.GroupBox1.Controls.Add(Me.txtDataInicial)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(202, 49)
        Me.GroupBox1.TabIndex = 342
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Período"
        '
        'txtDataFinal
        '
        Me.txtDataFinal.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtDataFinal.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataFinal.Location = New System.Drawing.Point(107, 17)
        Me.txtDataFinal.Name = "txtDataFinal"
        Me.txtDataFinal.Size = New System.Drawing.Size(86, 23)
        Me.txtDataFinal.TabIndex = 226
        Me.txtDataFinal.Value = Nothing
        '
        'txtDataInicial
        '
        Me.txtDataInicial.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtDataInicial.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataInicial.Location = New System.Drawing.Point(10, 17)
        Me.txtDataInicial.Name = "txtDataInicial"
        Me.txtDataInicial.Size = New System.Drawing.Size(91, 23)
        Me.txtDataInicial.TabIndex = 225
        Me.txtDataInicial.Value = Nothing
        '
        'cmdPesquisar
        '
        Me.cmdPesquisar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdPesquisar.Location = New System.Drawing.Point(721, 21)
        Me.cmdPesquisar.Name = "cmdPesquisar"
        Me.cmdPesquisar.Size = New System.Drawing.Size(45, 45)
        Me.cmdPesquisar.TabIndex = 348
        Me.cmdPesquisar.Text = "P"
        '
        'frmControleCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(776, 548)
        Me.Controls.Add(Me.cmdPesquisar)
        Me.Controls.Add(Me.SelecaoTipoCacau)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboOpcoes)
        Me.Controls.Add(Me.chkExcluiCancelado)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tbcGeral)
        Me.Name = "frmControleCompras"
        Me.Text = "frmControleCompras"
        Me.tbcGeral.ResumeLayout(False)
        Me.tabContratoPAF.ResumeLayout(False)
        CType(Me.grdContratoPAF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabNegociacao.ResumeLayout(False)
        CType(Me.grdNegociacao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabContratoFixo.ResumeLayout(False)
        CType(Me.grdContratoFixo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtDataFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataInicial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbcGeral As System.Windows.Forms.TabControl
    Friend WithEvents tabContratoPAF As System.Windows.Forms.TabPage
    Friend WithEvents grdContratoPAF As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents tabNegociacao As System.Windows.Forms.TabPage
    Friend WithEvents grdNegociacao As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents tabContratoFixo As System.Windows.Forms.TabPage
    Friend WithEvents grdContratoFixo As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents SelecaoTipoCacau As Logus.Selecao
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboOpcoes As System.Windows.Forms.ComboBox
    Friend WithEvents chkExcluiCancelado As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDataFinal As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtDataInicial As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents cmdPesquisar As Infragistics.Win.Misc.UltraButton
End Class
