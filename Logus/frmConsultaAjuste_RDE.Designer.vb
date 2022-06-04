<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaAjuste_RDE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaAjuste_RDE))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.optDataAprovacao = New System.Windows.Forms.RadioButton
        Me.optDataSolicitacao = New System.Windows.Forms.RadioButton
        Me.txtDataFinal = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtDataInicial = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.Pesq_UsuarioSolicitacao = New Logus.Pesq_CodigoNome
        Me.Pesq_UsuarioAprovacao = New Logus.Pesq_CodigoNome
        Me.Label2 = New System.Windows.Forms.Label
        Me.Pesq_TipoMovimentacao = New Logus.Pesq_CodigoNome
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboFilial = New System.Windows.Forms.ComboBox
        Me.cboTipoAcerto = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdAlterar = New Infragistics.Win.Misc.UltraButton
        Me.cmdExcluir = New Infragistics.Win.Misc.UltraButton
        Me.cmdUsuario = New Infragistics.Win.Misc.UltraButton
        Me.cmdNovo = New Infragistics.Win.Misc.UltraButton
        Me.cmdExcell = New Infragistics.Win.Misc.UltraButton
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.grdGeral = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.cmdPesquisar = New Infragistics.Win.Misc.UltraButton
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtDataFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optDataAprovacao)
        Me.GroupBox1.Controls.Add(Me.optDataSolicitacao)
        Me.GroupBox1.Controls.Add(Me.txtDataFinal)
        Me.GroupBox1.Controls.Add(Me.txtDataInicial)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(362, 49)
        Me.GroupBox1.TabIndex = 229
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Período"
        '
        'optDataAprovacao
        '
        Me.optDataAprovacao.AutoSize = True
        Me.optDataAprovacao.Location = New System.Drawing.Point(234, 27)
        Me.optDataAprovacao.Name = "optDataAprovacao"
        Me.optDataAprovacao.Size = New System.Drawing.Size(118, 17)
        Me.optDataAprovacao.TabIndex = 233
        Me.optDataAprovacao.TabStop = True
        Me.optDataAprovacao.Text = "Data de Aprovação"
        Me.optDataAprovacao.UseVisualStyleBackColor = True
        '
        'optDataSolicitacao
        '
        Me.optDataSolicitacao.AutoSize = True
        Me.optDataSolicitacao.Checked = True
        Me.optDataSolicitacao.Location = New System.Drawing.Point(234, 10)
        Me.optDataSolicitacao.Name = "optDataSolicitacao"
        Me.optDataSolicitacao.Size = New System.Drawing.Size(118, 17)
        Me.optDataSolicitacao.TabIndex = 233
        Me.optDataSolicitacao.TabStop = True
        Me.optDataSolicitacao.Text = "Data de Solicitação"
        Me.optDataSolicitacao.UseVisualStyleBackColor = True
        '
        'txtDataFinal
        '
        Me.txtDataFinal.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtDataFinal.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataFinal.Location = New System.Drawing.Point(122, 17)
        Me.txtDataFinal.Name = "txtDataFinal"
        Me.txtDataFinal.Size = New System.Drawing.Size(104, 23)
        Me.txtDataFinal.TabIndex = 226
        Me.txtDataFinal.Value = Nothing
        '
        'txtDataInicial
        '
        Me.txtDataInicial.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtDataInicial.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataInicial.Location = New System.Drawing.Point(10, 17)
        Me.txtDataInicial.Name = "txtDataInicial"
        Me.txtDataInicial.Size = New System.Drawing.Size(104, 23)
        Me.txtDataInicial.TabIndex = 225
        Me.txtDataInicial.Value = Nothing
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 13)
        Me.Label1.TabIndex = 230
        Me.Label1.Text = "Usuário que solicitou o ajuste"
        '
        'Pesq_UsuarioSolicitacao
        '
        Me.Pesq_UsuarioSolicitacao.Ativo = True
        Me.Pesq_UsuarioSolicitacao.BancoDados_Campo_Codigo = Nothing
        Me.Pesq_UsuarioSolicitacao.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_UsuarioSolicitacao.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_UsuarioSolicitacao.BancoDados_Campo_Descricao = Nothing
        Me.Pesq_UsuarioSolicitacao.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_UsuarioSolicitacao.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_UsuarioSolicitacao.BancoDados_Tabela = Nothing
        Me.Pesq_UsuarioSolicitacao.Codigo = 0
        Me.Pesq_UsuarioSolicitacao.Descricao = ""
        Me.Pesq_UsuarioSolicitacao.ExibirCodigo = True
        Me.Pesq_UsuarioSolicitacao.Location = New System.Drawing.Point(8, 79)
        Me.Pesq_UsuarioSolicitacao.MaximumSize = New System.Drawing.Size(1000, 23)
        Me.Pesq_UsuarioSolicitacao.MinimumSize = New System.Drawing.Size(0, 23)
        Me.Pesq_UsuarioSolicitacao.Name = "Pesq_UsuarioSolicitacao"
        Me.Pesq_UsuarioSolicitacao.Size = New System.Drawing.Size(300, 23)
        Me.Pesq_UsuarioSolicitacao.TabIndex = 231
        Me.Pesq_UsuarioSolicitacao.TelaFiltro = False
        Me.Pesq_UsuarioSolicitacao.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Inicializar
        '
        'Pesq_UsuarioAprovacao
        '
        Me.Pesq_UsuarioAprovacao.Ativo = True
        Me.Pesq_UsuarioAprovacao.BancoDados_Campo_Codigo = Nothing
        Me.Pesq_UsuarioAprovacao.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_UsuarioAprovacao.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_UsuarioAprovacao.BancoDados_Campo_Descricao = Nothing
        Me.Pesq_UsuarioAprovacao.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_UsuarioAprovacao.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_UsuarioAprovacao.BancoDados_Tabela = Nothing
        Me.Pesq_UsuarioAprovacao.Codigo = 0
        Me.Pesq_UsuarioAprovacao.Descricao = ""
        Me.Pesq_UsuarioAprovacao.ExibirCodigo = True
        Me.Pesq_UsuarioAprovacao.Location = New System.Drawing.Point(316, 79)
        Me.Pesq_UsuarioAprovacao.MaximumSize = New System.Drawing.Size(1000, 23)
        Me.Pesq_UsuarioAprovacao.MinimumSize = New System.Drawing.Size(0, 23)
        Me.Pesq_UsuarioAprovacao.Name = "Pesq_UsuarioAprovacao"
        Me.Pesq_UsuarioAprovacao.Size = New System.Drawing.Size(300, 23)
        Me.Pesq_UsuarioAprovacao.TabIndex = 231
        Me.Pesq_UsuarioAprovacao.TelaFiltro = False
        Me.Pesq_UsuarioAprovacao.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Inicializar
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(316, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(169, 13)
        Me.Label2.TabIndex = 230
        Me.Label2.Text = "Usuário que analisou a aprovação"
        '
        'Pesq_TipoMovimentacao
        '
        Me.Pesq_TipoMovimentacao.Ativo = True
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_Codigo = Nothing
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_Descricao = Nothing
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_TipoMovimentacao.BancoDados_Tabela = Nothing
        Me.Pesq_TipoMovimentacao.Codigo = 0
        Me.Pesq_TipoMovimentacao.Descricao = ""
        Me.Pesq_TipoMovimentacao.ExibirCodigo = True
        Me.Pesq_TipoMovimentacao.Location = New System.Drawing.Point(8, 123)
        Me.Pesq_TipoMovimentacao.MaximumSize = New System.Drawing.Size(1000, 23)
        Me.Pesq_TipoMovimentacao.MinimumSize = New System.Drawing.Size(0, 23)
        Me.Pesq_TipoMovimentacao.Name = "Pesq_TipoMovimentacao"
        Me.Pesq_TipoMovimentacao.Size = New System.Drawing.Size(300, 23)
        Me.Pesq_TipoMovimentacao.TabIndex = 231
        Me.Pesq_TipoMovimentacao.TelaFiltro = False
        Me.Pesq_TipoMovimentacao.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Inicializar
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 13)
        Me.Label3.TabIndex = 230
        Me.Label3.Text = "Tipo de Movimentacao"
        '
        'cboFilial
        '
        Me.cboFilial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilial.FormattingEnabled = True
        Me.cboFilial.Location = New System.Drawing.Point(316, 123)
        Me.cboFilial.Name = "cboFilial"
        Me.cboFilial.Size = New System.Drawing.Size(176, 21)
        Me.cboFilial.TabIndex = 232
        '
        'cboTipoAcerto
        '
        Me.cboTipoAcerto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoAcerto.FormattingEnabled = True
        Me.cboTipoAcerto.Location = New System.Drawing.Point(500, 123)
        Me.cboTipoAcerto.Name = "cboTipoAcerto"
        Me.cboTipoAcerto.Size = New System.Drawing.Size(116, 21)
        Me.cboTipoAcerto.TabIndex = 232
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(316, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 13)
        Me.Label4.TabIndex = 230
        Me.Label4.Text = "Filial"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(500, 110)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 230
        Me.Label5.Text = "Tipo de Acerto"
        '
        'cmdAlterar
        '
        Me.cmdAlterar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdAlterar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdAlterar.Location = New System.Drawing.Point(114, 456)
        Me.cmdAlterar.Name = "cmdAlterar"
        Me.cmdAlterar.Size = New System.Drawing.Size(45, 45)
        Me.cmdAlterar.TabIndex = 240
        Me.cmdAlterar.Text = "A"
        '
        'cmdExcluir
        '
        Me.cmdExcluir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdExcluir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExcluir.Location = New System.Drawing.Point(167, 456)
        Me.cmdExcluir.Name = "cmdExcluir"
        Me.cmdExcluir.Size = New System.Drawing.Size(45, 45)
        Me.cmdExcluir.TabIndex = 239
        Me.cmdExcluir.Text = "E"
        '
        'cmdUsuario
        '
        Me.cmdUsuario.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUsuario.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdUsuario.Location = New System.Drawing.Point(700, 456)
        Me.cmdUsuario.Name = "cmdUsuario"
        Me.cmdUsuario.Size = New System.Drawing.Size(45, 45)
        Me.cmdUsuario.TabIndex = 238
        Me.cmdUsuario.Text = "U"
        '
        'cmdNovo
        '
        Me.cmdNovo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdNovo.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdNovo.Location = New System.Drawing.Point(61, 456)
        Me.cmdNovo.Name = "cmdNovo"
        Me.cmdNovo.Size = New System.Drawing.Size(45, 45)
        Me.cmdNovo.TabIndex = 237
        Me.cmdNovo.Text = "N"
        '
        'cmdExcell
        '
        Me.cmdExcell.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdExcell.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExcell.Location = New System.Drawing.Point(8, 456)
        Me.cmdExcell.Name = "cmdExcell"
        Me.cmdExcell.Size = New System.Drawing.Size(45, 45)
        Me.cmdExcell.TabIndex = 236
        Me.cmdExcell.Text = "Excell"
        '
        'cmdFechar
        '
        Me.cmdFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(751, 456)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 235
        Me.cmdFechar.Text = "F"
        '
        'grdGeral
        '
        Me.grdGeral.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.grdGeral.Location = New System.Drawing.Point(8, 154)
        Me.grdGeral.Name = "grdGeral"
        Me.grdGeral.Size = New System.Drawing.Size(788, 294)
        Me.grdGeral.TabIndex = 234
        Me.grdGeral.Text = "UltraGrid1"
        '
        'cmdPesquisar
        '
        Me.cmdPesquisar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdPesquisar.Location = New System.Drawing.Point(571, 8)
        Me.cmdPesquisar.Name = "cmdPesquisar"
        Me.cmdPesquisar.Size = New System.Drawing.Size(45, 45)
        Me.cmdPesquisar.TabIndex = 233
        Me.cmdPesquisar.Text = "P"
        '
        'frmConsultaAjuste_RDE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 509)
        Me.Controls.Add(Me.cmdAlterar)
        Me.Controls.Add(Me.cmdExcluir)
        Me.Controls.Add(Me.cmdUsuario)
        Me.Controls.Add(Me.cmdNovo)
        Me.Controls.Add(Me.cmdExcell)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.grdGeral)
        Me.Controls.Add(Me.cmdPesquisar)
        Me.Controls.Add(Me.cboTipoAcerto)
        Me.Controls.Add(Me.cboFilial)
        Me.Controls.Add(Me.Pesq_UsuarioAprovacao)
        Me.Controls.Add(Me.Pesq_TipoMovimentacao)
        Me.Controls.Add(Me.Pesq_UsuarioSolicitacao)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsultaAjuste_RDE"
        Me.Text = "Consulta de Ajuste de RD"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtDataFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDataFinal As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtDataInicial As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Pesq_UsuarioSolicitacao As Logus.Pesq_CodigoNome
    Friend WithEvents Pesq_UsuarioAprovacao As Logus.Pesq_CodigoNome
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents optDataAprovacao As System.Windows.Forms.RadioButton
    Friend WithEvents optDataSolicitacao As System.Windows.Forms.RadioButton
    Friend WithEvents Pesq_TipoMovimentacao As Logus.Pesq_CodigoNome
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboFilial As System.Windows.Forms.ComboBox
    Friend WithEvents cboTipoAcerto As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdAlterar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdExcluir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdUsuario As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdNovo As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdExcell As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents grdGeral As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cmdPesquisar As Infragistics.Win.Misc.UltraButton
End Class
