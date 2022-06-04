<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroAjuste_RDE
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
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadastroAjuste_RDE))
        Me.lblR_DataMovimentacao = New System.Windows.Forms.Label
        Me.txtValorICMS = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.grpDaoAjuste = New System.Windows.Forms.GroupBox
        Me.grdGeral = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.txtQuantidadeLiquido = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtJustificativaAjuste = New System.Windows.Forms.TextBox
        Me.lblR_JustificativaAjuste = New System.Windows.Forms.Label
        Me.txtQuantidadeNF = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.lblR_QuantidadeLiquido = New System.Windows.Forms.Label
        Me.lblR_DadosAjusteQuantidadeEstoque = New System.Windows.Forms.Label
        Me.lblR_QuantidadeNF = New System.Windows.Forms.Label
        Me.txtValorINSS = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.lblR_ValorINSS = New System.Windows.Forms.Label
        Me.lblR_ICMS = New System.Windows.Forms.Label
        Me.txtValor = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.lblR_Valor = New System.Windows.Forms.Label
        Me.lblR_TipoMovimentacao = New System.Windows.Forms.Label
        Me.Pesq_TipoMovimentacao = New Logus.Pesq_CodigoNome
        Me.txtDataMovimentacao = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.lblR_Fornecedor = New System.Windows.Forms.Label
        Me.cboFilial = New System.Windows.Forms.ComboBox
        Me.Pesq_Fornecedor = New Logus.Pesq_CodigoNome
        Me.lblR_Filial = New System.Windows.Forms.Label
        Me.chkFornecedor = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.txtDataAprovacao = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.cmdAprovacao = New Infragistics.Win.Misc.UltraButton
        Me.cmdReprovar = New Infragistics.Win.Misc.UltraButton
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.txtJustificativaAprovacao = New System.Windows.Forms.TextBox
        Me.lblR_JustificativaAprovacao = New System.Windows.Forms.Label
        Me.txtDataLancamento = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.lblR_TipoAcerto = New System.Windows.Forms.Label
        Me.cboTipoAcerto = New System.Windows.Forms.ComboBox
        Me.grpAplicarAjusteEm = New System.Windows.Forms.GroupBox
        Me.chkAplicarAjuste_EstoqueFisico = New System.Windows.Forms.CheckBox
        Me.chkAplicarAjuste_RDE = New System.Windows.Forms.CheckBox
        Me.lblR_Movimentacao = New System.Windows.Forms.Label
        Me.lblR_DataLancamento = New System.Windows.Forms.Label
        Me.lblR_DataAprovacao = New System.Windows.Forms.Label
        Me.Pesq_Movimentacao = New Logus.Pesq_CodigoNome
        CType(Me.txtValorICMS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDaoAjuste.SuspendLayout()
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantidadeLiquido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantidadeNF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorINSS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataMovimentacao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkFornecedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataAprovacao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataLancamento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpAplicarAjusteEm.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblR_DataMovimentacao
        '
        Me.lblR_DataMovimentacao.AutoSize = True
        Me.lblR_DataMovimentacao.BackColor = System.Drawing.Color.Transparent
        Me.lblR_DataMovimentacao.Location = New System.Drawing.Point(472, 16)
        Me.lblR_DataMovimentacao.Name = "lblR_DataMovimentacao"
        Me.lblR_DataMovimentacao.Size = New System.Drawing.Size(103, 13)
        Me.lblR_DataMovimentacao.TabIndex = 332
        Me.lblR_DataMovimentacao.Text = "Data Movimentação"
        '
        'txtValorICMS
        '
        Me.txtValorICMS.Location = New System.Drawing.Point(347, 120)
        Me.txtValorICMS.MinValue = New Decimal(New Integer() {-727379969, 232, 0, -2147483648})
        Me.txtValorICMS.Name = "txtValorICMS"
        Me.txtValorICMS.Size = New System.Drawing.Size(105, 21)
        Me.txtValorICMS.TabIndex = 322
        '
        'grpDaoAjuste
        '
        Me.grpDaoAjuste.Controls.Add(Me.grdGeral)
        Me.grpDaoAjuste.Controls.Add(Me.txtQuantidadeLiquido)
        Me.grpDaoAjuste.Controls.Add(Me.lblR_DataMovimentacao)
        Me.grpDaoAjuste.Controls.Add(Me.txtJustificativaAjuste)
        Me.grpDaoAjuste.Controls.Add(Me.lblR_JustificativaAjuste)
        Me.grpDaoAjuste.Controls.Add(Me.txtQuantidadeNF)
        Me.grpDaoAjuste.Controls.Add(Me.lblR_QuantidadeLiquido)
        Me.grpDaoAjuste.Controls.Add(Me.lblR_DadosAjusteQuantidadeEstoque)
        Me.grpDaoAjuste.Controls.Add(Me.lblR_QuantidadeNF)
        Me.grpDaoAjuste.Controls.Add(Me.txtValorINSS)
        Me.grpDaoAjuste.Controls.Add(Me.lblR_ValorINSS)
        Me.grpDaoAjuste.Controls.Add(Me.txtValorICMS)
        Me.grpDaoAjuste.Controls.Add(Me.lblR_ICMS)
        Me.grpDaoAjuste.Controls.Add(Me.txtValor)
        Me.grpDaoAjuste.Controls.Add(Me.lblR_Valor)
        Me.grpDaoAjuste.Controls.Add(Me.lblR_TipoMovimentacao)
        Me.grpDaoAjuste.Controls.Add(Me.Pesq_TipoMovimentacao)
        Me.grpDaoAjuste.Controls.Add(Me.txtDataMovimentacao)
        Me.grpDaoAjuste.Controls.Add(Me.lblR_Fornecedor)
        Me.grpDaoAjuste.Controls.Add(Me.cboFilial)
        Me.grpDaoAjuste.Controls.Add(Me.Pesq_Fornecedor)
        Me.grpDaoAjuste.Controls.Add(Me.lblR_Filial)
        Me.grpDaoAjuste.Controls.Add(Me.chkFornecedor)
        Me.grpDaoAjuste.Location = New System.Drawing.Point(11, 95)
        Me.grpDaoAjuste.Name = "grpDaoAjuste"
        Me.grpDaoAjuste.Size = New System.Drawing.Size(581, 329)
        Me.grpDaoAjuste.TabIndex = 351
        Me.grpDaoAjuste.TabStop = False
        Me.grpDaoAjuste.Text = "Dados de Ajuste da Movimentação"
        '
        'grdGeral
        '
        Appearance4.BackColor = System.Drawing.SystemColors.Window
        Appearance4.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdGeral.DisplayLayout.Appearance = Appearance4
        Me.grdGeral.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdGeral.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance1.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance1.BorderColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.GroupByBox.Appearance = Appearance1
        Appearance2.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdGeral.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance2
        Me.grdGeral.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance3.BackColor2 = System.Drawing.SystemColors.Control
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdGeral.DisplayLayout.GroupByBox.PromptAppearance = Appearance3
        Me.grdGeral.DisplayLayout.MaxColScrollRegions = 1
        Me.grdGeral.DisplayLayout.MaxRowScrollRegions = 1
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdGeral.DisplayLayout.Override.ActiveCellAppearance = Appearance12
        Appearance7.BackColor = System.Drawing.SystemColors.Highlight
        Appearance7.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdGeral.DisplayLayout.Override.ActiveRowAppearance = Appearance7
        Me.grdGeral.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdGeral.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance6.BackColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.Override.CardAreaAppearance = Appearance6
        Appearance5.BorderColor = System.Drawing.Color.Silver
        Appearance5.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdGeral.DisplayLayout.Override.CellAppearance = Appearance5
        Me.grdGeral.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdGeral.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance11.TextHAlignAsString = "Left"
        Me.grdGeral.DisplayLayout.Override.HeaderAppearance = Appearance11
        Me.grdGeral.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdGeral.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance10.BackColor = System.Drawing.SystemColors.Window
        Appearance10.BorderColor = System.Drawing.Color.Silver
        Me.grdGeral.DisplayLayout.Override.RowAppearance = Appearance10
        Me.grdGeral.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance8.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdGeral.DisplayLayout.Override.TemplateAddRowAppearance = Appearance8
        Me.grdGeral.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdGeral.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdGeral.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdGeral.Location = New System.Drawing.Point(8, 163)
        Me.grdGeral.Name = "grdGeral"
        Me.grdGeral.Size = New System.Drawing.Size(567, 84)
        Me.grdGeral.TabIndex = 350
        Me.grdGeral.Text = "UltraGrid1"
        '
        'txtQuantidadeLiquido
        '
        Me.txtQuantidadeLiquido.Location = New System.Drawing.Point(8, 120)
        Me.txtQuantidadeLiquido.MaskInput = "-n,nnn,nnn"
        Me.txtQuantidadeLiquido.Name = "txtQuantidadeLiquido"
        Me.txtQuantidadeLiquido.Size = New System.Drawing.Size(105, 21)
        Me.txtQuantidadeLiquido.TabIndex = 333
        '
        'txtJustificativaAjuste
        '
        Me.txtJustificativaAjuste.Location = New System.Drawing.Point(8, 269)
        Me.txtJustificativaAjuste.MaxLength = 4000
        Me.txtJustificativaAjuste.Multiline = True
        Me.txtJustificativaAjuste.Name = "txtJustificativaAjuste"
        Me.txtJustificativaAjuste.Size = New System.Drawing.Size(567, 51)
        Me.txtJustificativaAjuste.TabIndex = 331
        '
        'lblR_JustificativaAjuste
        '
        Me.lblR_JustificativaAjuste.AutoSize = True
        Me.lblR_JustificativaAjuste.BackColor = System.Drawing.Color.Transparent
        Me.lblR_JustificativaAjuste.Location = New System.Drawing.Point(8, 255)
        Me.lblR_JustificativaAjuste.Name = "lblR_JustificativaAjuste"
        Me.lblR_JustificativaAjuste.Size = New System.Drawing.Size(94, 13)
        Me.lblR_JustificativaAjuste.TabIndex = 330
        Me.lblR_JustificativaAjuste.Text = "Justificativa Ajuste"
        '
        'txtQuantidadeNF
        '
        Me.txtQuantidadeNF.Location = New System.Drawing.Point(121, 120)
        Me.txtQuantidadeNF.MaskInput = "-n,nnn,nnn"
        Me.txtQuantidadeNF.Name = "txtQuantidadeNF"
        Me.txtQuantidadeNF.Size = New System.Drawing.Size(105, 21)
        Me.txtQuantidadeNF.TabIndex = 327
        '
        'lblR_QuantidadeLiquido
        '
        Me.lblR_QuantidadeLiquido.AutoSize = True
        Me.lblR_QuantidadeLiquido.BackColor = System.Drawing.Color.Transparent
        Me.lblR_QuantidadeLiquido.Location = New System.Drawing.Point(8, 106)
        Me.lblR_QuantidadeLiquido.Name = "lblR_QuantidadeLiquido"
        Me.lblR_QuantidadeLiquido.Size = New System.Drawing.Size(99, 13)
        Me.lblR_QuantidadeLiquido.TabIndex = 329
        Me.lblR_QuantidadeLiquido.Text = "Quantidade Liquida"
        '
        'lblR_DadosAjusteQuantidadeEstoque
        '
        Me.lblR_DadosAjusteQuantidadeEstoque.AutoSize = True
        Me.lblR_DadosAjusteQuantidadeEstoque.BackColor = System.Drawing.Color.Transparent
        Me.lblR_DadosAjusteQuantidadeEstoque.Location = New System.Drawing.Point(8, 149)
        Me.lblR_DadosAjusteQuantidadeEstoque.Name = "lblR_DadosAjusteQuantidadeEstoque"
        Me.lblR_DadosAjusteQuantidadeEstoque.Size = New System.Drawing.Size(215, 13)
        Me.lblR_DadosAjusteQuantidadeEstoque.TabIndex = 329
        Me.lblR_DadosAjusteQuantidadeEstoque.Text = "Dados de Ajuste de Quantidade de Estoque"
        '
        'lblR_QuantidadeNF
        '
        Me.lblR_QuantidadeNF.AutoSize = True
        Me.lblR_QuantidadeNF.BackColor = System.Drawing.Color.Transparent
        Me.lblR_QuantidadeNF.Location = New System.Drawing.Point(124, 106)
        Me.lblR_QuantidadeNF.Name = "lblR_QuantidadeNF"
        Me.lblR_QuantidadeNF.Size = New System.Drawing.Size(79, 13)
        Me.lblR_QuantidadeNF.TabIndex = 329
        Me.lblR_QuantidadeNF.Text = "Quantidade NF"
        '
        'txtValorINSS
        '
        Me.txtValorINSS.Location = New System.Drawing.Point(460, 120)
        Me.txtValorINSS.MinValue = New Decimal(New Integer() {1874919423, 2328306, 0, -2147483648})
        Me.txtValorINSS.Name = "txtValorINSS"
        Me.txtValorINSS.Size = New System.Drawing.Size(105, 21)
        Me.txtValorINSS.TabIndex = 323
        '
        'lblR_ValorINSS
        '
        Me.lblR_ValorINSS.AutoSize = True
        Me.lblR_ValorINSS.BackColor = System.Drawing.Color.Transparent
        Me.lblR_ValorINSS.Location = New System.Drawing.Point(463, 106)
        Me.lblR_ValorINSS.Name = "lblR_ValorINSS"
        Me.lblR_ValorINSS.Size = New System.Drawing.Size(32, 13)
        Me.lblR_ValorINSS.TabIndex = 326
        Me.lblR_ValorINSS.Text = "INSS"
        '
        'lblR_ICMS
        '
        Me.lblR_ICMS.AutoSize = True
        Me.lblR_ICMS.BackColor = System.Drawing.Color.Transparent
        Me.lblR_ICMS.Location = New System.Drawing.Point(350, 106)
        Me.lblR_ICMS.Name = "lblR_ICMS"
        Me.lblR_ICMS.Size = New System.Drawing.Size(33, 13)
        Me.lblR_ICMS.TabIndex = 325
        Me.lblR_ICMS.Text = "ICMS"
        '
        'txtValor
        '
        Me.txtValor.Location = New System.Drawing.Point(234, 120)
        Me.txtValor.MinValue = New Decimal(New Integer() {-727379969, 232, 0, -2147483648})
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(105, 21)
        Me.txtValor.TabIndex = 321
        '
        'lblR_Valor
        '
        Me.lblR_Valor.AutoSize = True
        Me.lblR_Valor.BackColor = System.Drawing.Color.Transparent
        Me.lblR_Valor.Location = New System.Drawing.Point(237, 106)
        Me.lblR_Valor.Name = "lblR_Valor"
        Me.lblR_Valor.Size = New System.Drawing.Size(31, 13)
        Me.lblR_Valor.TabIndex = 324
        Me.lblR_Valor.Text = "Valor"
        '
        'lblR_TipoMovimentacao
        '
        Me.lblR_TipoMovimentacao.AutoSize = True
        Me.lblR_TipoMovimentacao.BackColor = System.Drawing.Color.Transparent
        Me.lblR_TipoMovimentacao.Location = New System.Drawing.Point(8, 16)
        Me.lblR_TipoMovimentacao.Name = "lblR_TipoMovimentacao"
        Me.lblR_TipoMovimentacao.Size = New System.Drawing.Size(116, 13)
        Me.lblR_TipoMovimentacao.TabIndex = 276
        Me.lblR_TipoMovimentacao.Text = "Tipo de Movimentação"
        '
        'Pesq_TipoMovimentacao
        '
        Me.Pesq_TipoMovimentacao.Ativo = True
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_Codigo = "CD_FORNECEDOR"
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_Descricao = "NO_RAZAO_SOCIAL"
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_TipoMovimentacao.BancoDados_Tabela = "FORNECEDOR F"
        Me.Pesq_TipoMovimentacao.Codigo = 0
        Me.Pesq_TipoMovimentacao.Descricao = ""
        Me.Pesq_TipoMovimentacao.ExibirCodigo = True
        Me.Pesq_TipoMovimentacao.Location = New System.Drawing.Point(8, 30)
        Me.Pesq_TipoMovimentacao.MaximumSize = New System.Drawing.Size(1000, 23)
        Me.Pesq_TipoMovimentacao.MinimumSize = New System.Drawing.Size(0, 23)
        Me.Pesq_TipoMovimentacao.Name = "Pesq_TipoMovimentacao"
        Me.Pesq_TipoMovimentacao.Size = New System.Drawing.Size(303, 23)
        Me.Pesq_TipoMovimentacao.TabIndex = 275
        Me.Pesq_TipoMovimentacao.TelaFiltro = False
        Me.Pesq_TipoMovimentacao.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'txtDataMovimentacao
        '
        Me.txtDataMovimentacao.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtDataMovimentacao.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataMovimentacao.Location = New System.Drawing.Point(472, 30)
        Me.txtDataMovimentacao.Name = "txtDataMovimentacao"
        Me.txtDataMovimentacao.Size = New System.Drawing.Size(91, 23)
        Me.txtDataMovimentacao.TabIndex = 273
        Me.txtDataMovimentacao.Value = Nothing
        '
        'lblR_Fornecedor
        '
        Me.lblR_Fornecedor.AutoSize = True
        Me.lblR_Fornecedor.BackColor = System.Drawing.Color.Transparent
        Me.lblR_Fornecedor.Location = New System.Drawing.Point(8, 61)
        Me.lblR_Fornecedor.Name = "lblR_Fornecedor"
        Me.lblR_Fornecedor.Size = New System.Drawing.Size(61, 13)
        Me.lblR_Fornecedor.TabIndex = 257
        Me.lblR_Fornecedor.Text = "Fornecedor"
        '
        'cboFilial
        '
        Me.cboFilial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilial.Location = New System.Drawing.Point(319, 30)
        Me.cboFilial.Name = "cboFilial"
        Me.cboFilial.Size = New System.Drawing.Size(145, 21)
        Me.cboFilial.TabIndex = 256
        '
        'Pesq_Fornecedor
        '
        Me.Pesq_Fornecedor.Ativo = True
        Me.Pesq_Fornecedor.BancoDados_Campo_Codigo = "CD_FORNECEDOR"
        Me.Pesq_Fornecedor.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Fornecedor.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_Fornecedor.BancoDados_Campo_Descricao = "NO_RAZAO_SOCIAL"
        Me.Pesq_Fornecedor.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_Fornecedor.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Fornecedor.BancoDados_Tabela = "FORNECEDOR F"
        Me.Pesq_Fornecedor.Codigo = 0
        Me.Pesq_Fornecedor.Descricao = ""
        Me.Pesq_Fornecedor.ExibirCodigo = True
        Me.Pesq_Fornecedor.Location = New System.Drawing.Point(28, 75)
        Me.Pesq_Fornecedor.MaximumSize = New System.Drawing.Size(1000, 23)
        Me.Pesq_Fornecedor.MinimumSize = New System.Drawing.Size(0, 23)
        Me.Pesq_Fornecedor.Name = "Pesq_Fornecedor"
        Me.Pesq_Fornecedor.Size = New System.Drawing.Size(547, 23)
        Me.Pesq_Fornecedor.TabIndex = 254
        Me.Pesq_Fornecedor.TelaFiltro = False
        Me.Pesq_Fornecedor.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'lblR_Filial
        '
        Me.lblR_Filial.AutoSize = True
        Me.lblR_Filial.BackColor = System.Drawing.Color.Transparent
        Me.lblR_Filial.Location = New System.Drawing.Point(319, 16)
        Me.lblR_Filial.Name = "lblR_Filial"
        Me.lblR_Filial.Size = New System.Drawing.Size(27, 13)
        Me.lblR_Filial.TabIndex = 255
        Me.lblR_Filial.Text = "Filial"
        '
        'chkFornecedor
        '
        Me.chkFornecedor.BackColor = System.Drawing.Color.Transparent
        Me.chkFornecedor.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkFornecedor.Location = New System.Drawing.Point(11, 77)
        Me.chkFornecedor.Name = "chkFornecedor"
        Me.chkFornecedor.Size = New System.Drawing.Size(20, 20)
        Me.chkFornecedor.TabIndex = 351
        '
        'txtDataAprovacao
        '
        Me.txtDataAprovacao.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtDataAprovacao.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataAprovacao.Location = New System.Drawing.Point(449, 20)
        Me.txtDataAprovacao.Name = "txtDataAprovacao"
        Me.txtDataAprovacao.ReadOnly = True
        Me.txtDataAprovacao.Size = New System.Drawing.Size(91, 23)
        Me.txtDataAprovacao.TabIndex = 349
        Me.txtDataAprovacao.Value = Nothing
        '
        'cmdAprovacao
        '
        Me.cmdAprovacao.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdAprovacao.Location = New System.Drawing.Point(11, 504)
        Me.cmdAprovacao.Name = "cmdAprovacao"
        Me.cmdAprovacao.Size = New System.Drawing.Size(45, 45)
        Me.cmdAprovacao.TabIndex = 348
        Me.cmdAprovacao.Text = "AP"
        '
        'cmdReprovar
        '
        Me.cmdReprovar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdReprovar.Location = New System.Drawing.Point(64, 504)
        Me.cmdReprovar.Name = "cmdReprovar"
        Me.cmdReprovar.Size = New System.Drawing.Size(45, 45)
        Me.cmdReprovar.TabIndex = 347
        Me.cmdReprovar.Text = "RP"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(547, 504)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 346
        Me.cmdFechar.Text = "F"
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(333, 504)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 345
        Me.cmdGravar.TabStop = False
        Me.cmdGravar.Text = "G"
        '
        'txtJustificativaAprovacao
        '
        Me.txtJustificativaAprovacao.Location = New System.Drawing.Point(11, 446)
        Me.txtJustificativaAprovacao.MaxLength = 4000
        Me.txtJustificativaAprovacao.Multiline = True
        Me.txtJustificativaAprovacao.Name = "txtJustificativaAprovacao"
        Me.txtJustificativaAprovacao.Size = New System.Drawing.Size(581, 50)
        Me.txtJustificativaAprovacao.TabIndex = 344
        '
        'lblR_JustificativaAprovacao
        '
        Me.lblR_JustificativaAprovacao.AutoSize = True
        Me.lblR_JustificativaAprovacao.BackColor = System.Drawing.Color.Transparent
        Me.lblR_JustificativaAprovacao.Location = New System.Drawing.Point(11, 432)
        Me.lblR_JustificativaAprovacao.Name = "lblR_JustificativaAprovacao"
        Me.lblR_JustificativaAprovacao.Size = New System.Drawing.Size(181, 13)
        Me.lblR_JustificativaAprovacao.TabIndex = 343
        Me.lblR_JustificativaAprovacao.Text = "Justificativa Aprovação/Reprovação"
        '
        'txtDataLancamento
        '
        Me.txtDataLancamento.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtDataLancamento.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataLancamento.Location = New System.Drawing.Point(350, 20)
        Me.txtDataLancamento.Name = "txtDataLancamento"
        Me.txtDataLancamento.ReadOnly = True
        Me.txtDataLancamento.Size = New System.Drawing.Size(91, 23)
        Me.txtDataLancamento.TabIndex = 341
        Me.txtDataLancamento.Value = Nothing
        '
        'lblR_TipoAcerto
        '
        Me.lblR_TipoAcerto.AutoSize = True
        Me.lblR_TipoAcerto.Location = New System.Drawing.Point(11, 9)
        Me.lblR_TipoAcerto.Name = "lblR_TipoAcerto"
        Me.lblR_TipoAcerto.Size = New System.Drawing.Size(77, 13)
        Me.lblR_TipoAcerto.TabIndex = 339
        Me.lblR_TipoAcerto.Text = "Tipo de Acerto"
        '
        'cboTipoAcerto
        '
        Me.cboTipoAcerto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoAcerto.FormattingEnabled = True
        Me.cboTipoAcerto.Location = New System.Drawing.Point(11, 22)
        Me.cboTipoAcerto.Name = "cboTipoAcerto"
        Me.cboTipoAcerto.Size = New System.Drawing.Size(150, 21)
        Me.cboTipoAcerto.TabIndex = 340
        '
        'grpAplicarAjusteEm
        '
        Me.grpAplicarAjusteEm.Controls.Add(Me.chkAplicarAjuste_EstoqueFisico)
        Me.grpAplicarAjusteEm.Controls.Add(Me.chkAplicarAjuste_RDE)
        Me.grpAplicarAjusteEm.Location = New System.Drawing.Point(169, 8)
        Me.grpAplicarAjusteEm.Name = "grpAplicarAjusteEm"
        Me.grpAplicarAjusteEm.Size = New System.Drawing.Size(173, 35)
        Me.grpAplicarAjusteEm.TabIndex = 352
        Me.grpAplicarAjusteEm.TabStop = False
        Me.grpAplicarAjusteEm.Text = "Aplicar Ajuste em ..."
        '
        'chkAplicarAjuste_EstoqueFisico
        '
        Me.chkAplicarAjuste_EstoqueFisico.AutoSize = True
        Me.chkAplicarAjuste_EstoqueFisico.Location = New System.Drawing.Point(73, 15)
        Me.chkAplicarAjuste_EstoqueFisico.Name = "chkAplicarAjuste_EstoqueFisico"
        Me.chkAplicarAjuste_EstoqueFisico.Size = New System.Drawing.Size(97, 17)
        Me.chkAplicarAjuste_EstoqueFisico.TabIndex = 3
        Me.chkAplicarAjuste_EstoqueFisico.Text = "Estoque Físico"
        Me.chkAplicarAjuste_EstoqueFisico.UseVisualStyleBackColor = True
        '
        'chkAplicarAjuste_RDE
        '
        Me.chkAplicarAjuste_RDE.AutoSize = True
        Me.chkAplicarAjuste_RDE.Location = New System.Drawing.Point(8, 15)
        Me.chkAplicarAjuste_RDE.Name = "chkAplicarAjuste_RDE"
        Me.chkAplicarAjuste_RDE.Size = New System.Drawing.Size(58, 17)
        Me.chkAplicarAjuste_RDE.TabIndex = 2
        Me.chkAplicarAjuste_RDE.Text = "R.D.E."
        Me.chkAplicarAjuste_RDE.UseVisualStyleBackColor = True
        '
        'lblR_Movimentacao
        '
        Me.lblR_Movimentacao.AutoSize = True
        Me.lblR_Movimentacao.Location = New System.Drawing.Point(11, 51)
        Me.lblR_Movimentacao.Name = "lblR_Movimentacao"
        Me.lblR_Movimentacao.Size = New System.Drawing.Size(77, 13)
        Me.lblR_Movimentacao.TabIndex = 354
        Me.lblR_Movimentacao.Text = "Movimentação"
        '
        'lblR_DataLancamento
        '
        Me.lblR_DataLancamento.AutoSize = True
        Me.lblR_DataLancamento.BackColor = System.Drawing.Color.Transparent
        Me.lblR_DataLancamento.Location = New System.Drawing.Point(350, 7)
        Me.lblR_DataLancamento.Name = "lblR_DataLancamento"
        Me.lblR_DataLancamento.Size = New System.Drawing.Size(92, 13)
        Me.lblR_DataLancamento.TabIndex = 342
        Me.lblR_DataLancamento.Text = "Data Lançamento"
        '
        'lblR_DataAprovacao
        '
        Me.lblR_DataAprovacao.AutoSize = True
        Me.lblR_DataAprovacao.BackColor = System.Drawing.Color.Transparent
        Me.lblR_DataAprovacao.Location = New System.Drawing.Point(449, 7)
        Me.lblR_DataAprovacao.Name = "lblR_DataAprovacao"
        Me.lblR_DataAprovacao.Size = New System.Drawing.Size(85, 13)
        Me.lblR_DataAprovacao.TabIndex = 350
        Me.lblR_DataAprovacao.Text = "Data Aprovação"
        '
        'Pesq_Movimentacao
        '
        Me.Pesq_Movimentacao.Ativo = True
        Me.Pesq_Movimentacao.BancoDados_Campo_Codigo = "CD_FORNECEDOR"
        Me.Pesq_Movimentacao.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Movimentacao.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_Movimentacao.BancoDados_Campo_Descricao = "NO_RAZAO_SOCIAL"
        Me.Pesq_Movimentacao.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_Movimentacao.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Movimentacao.BancoDados_Tabela = "FORNECEDOR F"
        Me.Pesq_Movimentacao.Codigo = 0
        Me.Pesq_Movimentacao.Descricao = ""
        Me.Pesq_Movimentacao.ExibirCodigo = True
        Me.Pesq_Movimentacao.Location = New System.Drawing.Point(11, 64)
        Me.Pesq_Movimentacao.MaximumSize = New System.Drawing.Size(1000, 23)
        Me.Pesq_Movimentacao.MinimumSize = New System.Drawing.Size(0, 23)
        Me.Pesq_Movimentacao.Name = "Pesq_Movimentacao"
        Me.Pesq_Movimentacao.Size = New System.Drawing.Size(581, 23)
        Me.Pesq_Movimentacao.TabIndex = 353
        Me.Pesq_Movimentacao.TelaFiltro = False
        Me.Pesq_Movimentacao.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'frmCadastroAjuste_RDE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 559)
        Me.Controls.Add(Me.Pesq_Movimentacao)
        Me.Controls.Add(Me.lblR_Movimentacao)
        Me.Controls.Add(Me.grpAplicarAjusteEm)
        Me.Controls.Add(Me.grpDaoAjuste)
        Me.Controls.Add(Me.lblR_DataAprovacao)
        Me.Controls.Add(Me.txtDataAprovacao)
        Me.Controls.Add(Me.cmdAprovacao)
        Me.Controls.Add(Me.cmdReprovar)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.txtJustificativaAprovacao)
        Me.Controls.Add(Me.lblR_JustificativaAprovacao)
        Me.Controls.Add(Me.lblR_DataLancamento)
        Me.Controls.Add(Me.txtDataLancamento)
        Me.Controls.Add(Me.lblR_TipoAcerto)
        Me.Controls.Add(Me.cboTipoAcerto)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCadastroAjuste_RDE"
        Me.Text = "Lançamento de Ajuste de RD"
        CType(Me.txtValorICMS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDaoAjuste.ResumeLayout(False)
        Me.grpDaoAjuste.PerformLayout()
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantidadeLiquido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantidadeNF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorINSS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataMovimentacao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkFornecedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataAprovacao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataLancamento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpAplicarAjusteEm.ResumeLayout(False)
        Me.grpAplicarAjusteEm.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblR_DataMovimentacao As System.Windows.Forms.Label
    Friend WithEvents txtValorICMS As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents grpDaoAjuste As System.Windows.Forms.GroupBox
    Friend WithEvents txtJustificativaAjuste As System.Windows.Forms.TextBox
    Friend WithEvents lblR_JustificativaAjuste As System.Windows.Forms.Label
    Friend WithEvents txtQuantidadeNF As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents lblR_QuantidadeNF As System.Windows.Forms.Label
    Friend WithEvents txtValorINSS As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents lblR_ValorINSS As System.Windows.Forms.Label
    Friend WithEvents lblR_ICMS As System.Windows.Forms.Label
    Friend WithEvents txtValor As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents lblR_Valor As System.Windows.Forms.Label
    Friend WithEvents lblR_TipoMovimentacao As System.Windows.Forms.Label
    Friend WithEvents Pesq_TipoMovimentacao As Logus.Pesq_CodigoNome
    Friend WithEvents txtDataMovimentacao As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents lblR_Fornecedor As System.Windows.Forms.Label
    Friend WithEvents cboFilial As System.Windows.Forms.ComboBox
    Friend WithEvents Pesq_Fornecedor As Logus.Pesq_CodigoNome
    Friend WithEvents lblR_Filial As System.Windows.Forms.Label
    Friend WithEvents txtDataAprovacao As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents cmdAprovacao As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdReprovar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtJustificativaAprovacao As System.Windows.Forms.TextBox
    Friend WithEvents lblR_JustificativaAprovacao As System.Windows.Forms.Label
    Friend WithEvents txtDataLancamento As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents lblR_TipoAcerto As System.Windows.Forms.Label
    Friend WithEvents cboTipoAcerto As System.Windows.Forms.ComboBox
    Friend WithEvents grpAplicarAjusteEm As System.Windows.Forms.GroupBox
    Friend WithEvents chkAplicarAjuste_RDE As System.Windows.Forms.CheckBox
    Friend WithEvents chkAplicarAjuste_EstoqueFisico As System.Windows.Forms.CheckBox
    Friend WithEvents Pesq_Movimentacao As Logus.Pesq_CodigoNome
    Friend WithEvents lblR_Movimentacao As System.Windows.Forms.Label
    Friend WithEvents lblR_DataLancamento As System.Windows.Forms.Label
    Friend WithEvents lblR_DataAprovacao As System.Windows.Forms.Label
    Friend WithEvents txtQuantidadeLiquido As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents lblR_QuantidadeLiquido As System.Windows.Forms.Label
    Friend WithEvents grdGeral As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblR_DadosAjusteQuantidadeEstoque As System.Windows.Forms.Label
    Friend WithEvents chkFornecedor As Infragistics.Win.UltraWinEditors.UltraCheckEditor
End Class
