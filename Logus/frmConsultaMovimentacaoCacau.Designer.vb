<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaMovimentacaoCacau
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
        Me.components = New System.ComponentModel.Container
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
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
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaMovimentacaoCacau))
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtDataFinal = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtDataInicial = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtOrdemDescarga = New System.Windows.Forms.TextBox
        Me.txtNotaFiscal = New System.Windows.Forms.TextBox
        Me.cmdPesquisar = New Infragistics.Win.Misc.UltraButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.grdGeral = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.cmdExcell = New Infragistics.Win.Misc.UltraButton
        Me.cmdAlterar = New Infragistics.Win.Misc.UltraButton
        Me.cmdExcluir = New Infragistics.Win.Misc.UltraButton
        Me.cmdNovo = New Infragistics.Win.Misc.UltraButton
        Me.cmdUsuario = New Infragistics.Win.Misc.UltraButton
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdRastreabilidade = New Infragistics.Win.Misc.UltraButton
        Me.cmdPilha = New Infragistics.Win.Misc.UltraButton
        Me.cmdInformacoes = New Infragistics.Win.Misc.UltraButton
        Me.cmdNFReferencia = New Infragistics.Win.Misc.UltraButton
        Me.mnuNFReferencia = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuNFReferencia_Incluir = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuNFReferencia_Apagar = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdObsAcerto = New Infragistics.Win.Misc.UltraButton
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdLivroFiscal = New Infragistics.Win.Misc.UltraButton
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdICMS = New Infragistics.Win.Misc.UltraButton
        Me.SelecaoTipoNovimentacao = New Logus.Selecao
        Me.SelecaoEstadoOrigem = New Logus.Selecao
        Me.Pesq_Fornecedor = New Logus.Pesq_CodigoNome
        Me.SelecaoFilial = New Logus.Selecao
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtDataFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuNFReferencia.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDataFinal)
        Me.GroupBox1.Controls.Add(Me.txtDataInicial)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(235, 49)
        Me.GroupBox1.TabIndex = 229
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(246, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 13)
        Me.Label1.TabIndex = 232
        Me.Label1.Text = "Tipo de Movimentação"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(517, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 13)
        Me.Label2.TabIndex = 233
        Me.Label2.Text = "Filial de Movimentação"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 235
        Me.Label3.Text = "Fornecedor"
        '
        'txtOrdemDescarga
        '
        Me.txtOrdemDescarga.Location = New System.Drawing.Point(398, 77)
        Me.txtOrdemDescarga.Name = "txtOrdemDescarga"
        Me.txtOrdemDescarga.Size = New System.Drawing.Size(45, 20)
        Me.txtOrdemDescarga.TabIndex = 236
        '
        'txtNotaFiscal
        '
        Me.txtNotaFiscal.Location = New System.Drawing.Point(451, 77)
        Me.txtNotaFiscal.Name = "txtNotaFiscal"
        Me.txtNotaFiscal.Size = New System.Drawing.Size(60, 20)
        Me.txtNotaFiscal.TabIndex = 237
        '
        'cmdPesquisar
        '
        Me.cmdPesquisar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdPesquisar.Location = New System.Drawing.Point(677, 53)
        Me.cmdPesquisar.Name = "cmdPesquisar"
        Me.cmdPesquisar.Size = New System.Drawing.Size(45, 45)
        Me.cmdPesquisar.TabIndex = 238
        Me.cmdPesquisar.Text = "P"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(398, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 239
        Me.Label4.Text = "O.D."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(451, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 240
        Me.Label5.Text = "Nota Fiscal"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 103)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(142, 13)
        Me.Label6.TabIndex = 241
        Me.Label6.Text = "Listagem de Movimentações"
        '
        'grdGeral
        '
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdGeral.DisplayLayout.Appearance = Appearance13
        Me.grdGeral.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdGeral.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.GroupByBox.Appearance = Appearance14
        Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdGeral.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance15
        Me.grdGeral.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance16.BackColor2 = System.Drawing.SystemColors.Control
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdGeral.DisplayLayout.GroupByBox.PromptAppearance = Appearance16
        Me.grdGeral.DisplayLayout.MaxColScrollRegions = 1
        Me.grdGeral.DisplayLayout.MaxRowScrollRegions = 1
        Appearance17.BackColor = System.Drawing.SystemColors.Window
        Appearance17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdGeral.DisplayLayout.Override.ActiveCellAppearance = Appearance17
        Appearance18.BackColor = System.Drawing.SystemColors.Highlight
        Appearance18.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdGeral.DisplayLayout.Override.ActiveRowAppearance = Appearance18
        Me.grdGeral.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdGeral.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.Override.CardAreaAppearance = Appearance19
        Appearance20.BorderColor = System.Drawing.Color.Silver
        Appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdGeral.DisplayLayout.Override.CellAppearance = Appearance20
        Me.grdGeral.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdGeral.DisplayLayout.Override.CellPadding = 0
        Appearance21.BackColor = System.Drawing.SystemColors.Control
        Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance21.BorderColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.Override.GroupByRowAppearance = Appearance21
        Appearance22.TextHAlignAsString = "Left"
        Me.grdGeral.DisplayLayout.Override.HeaderAppearance = Appearance22
        Me.grdGeral.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdGeral.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Appearance23.BorderColor = System.Drawing.Color.Silver
        Me.grdGeral.DisplayLayout.Override.RowAppearance = Appearance23
        Me.grdGeral.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance24.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdGeral.DisplayLayout.Override.TemplateAddRowAppearance = Appearance24
        Me.grdGeral.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdGeral.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdGeral.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdGeral.Location = New System.Drawing.Point(5, 118)
        Me.grdGeral.Name = "grdGeral"
        Me.grdGeral.Size = New System.Drawing.Size(717, 270)
        Me.grdGeral.TabIndex = 242
        Me.grdGeral.Text = "UltraGrid1"
        '
        'cmdExcell
        '
        Me.cmdExcell.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExcell.Location = New System.Drawing.Point(5, 396)
        Me.cmdExcell.Name = "cmdExcell"
        Me.cmdExcell.Size = New System.Drawing.Size(45, 45)
        Me.cmdExcell.TabIndex = 243
        Me.cmdExcell.Text = "Excell"
        '
        'cmdAlterar
        '
        Me.cmdAlterar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdAlterar.Location = New System.Drawing.Point(111, 396)
        Me.cmdAlterar.Name = "cmdAlterar"
        Me.cmdAlterar.Size = New System.Drawing.Size(45, 45)
        Me.cmdAlterar.TabIndex = 246
        Me.cmdAlterar.Text = "A"
        '
        'cmdExcluir
        '
        Me.cmdExcluir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExcluir.Location = New System.Drawing.Point(164, 396)
        Me.cmdExcluir.Name = "cmdExcluir"
        Me.cmdExcluir.Size = New System.Drawing.Size(45, 45)
        Me.cmdExcluir.TabIndex = 245
        Me.cmdExcluir.Text = "E"
        '
        'cmdNovo
        '
        Me.cmdNovo.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdNovo.Location = New System.Drawing.Point(58, 396)
        Me.cmdNovo.Name = "cmdNovo"
        Me.cmdNovo.Size = New System.Drawing.Size(45, 45)
        Me.cmdNovo.TabIndex = 244
        Me.cmdNovo.Text = "N"
        '
        'cmdUsuario
        '
        Me.cmdUsuario.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdUsuario.Location = New System.Drawing.Point(626, 396)
        Me.cmdUsuario.Name = "cmdUsuario"
        Me.cmdUsuario.Size = New System.Drawing.Size(45, 45)
        Me.cmdUsuario.TabIndex = 248
        Me.cmdUsuario.Text = "U"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(677, 396)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 247
        Me.cmdFechar.Text = "F"
        '
        'cmdRastreabilidade
        '
        Appearance2.Image = CType(resources.GetObject("Appearance2.Image"), Object)
        Me.cmdRastreabilidade.Appearance = Appearance2
        Me.cmdRastreabilidade.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdRastreabilidade.Location = New System.Drawing.Point(217, 396)
        Me.cmdRastreabilidade.Name = "cmdRastreabilidade"
        Me.cmdRastreabilidade.Size = New System.Drawing.Size(45, 45)
        Me.cmdRastreabilidade.TabIndex = 249
        Me.ToolTip1.SetToolTip(Me.cmdRastreabilidade, "Rastreabilidade da Movimentação")
        '
        'cmdPilha
        '
        Appearance3.Image = Global.Logus.My.Resources.Resources.Pilha
        Me.cmdPilha.Appearance = Appearance3
        Me.cmdPilha.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdPilha.Location = New System.Drawing.Point(270, 396)
        Me.cmdPilha.Name = "cmdPilha"
        Me.cmdPilha.Size = New System.Drawing.Size(45, 45)
        Me.cmdPilha.TabIndex = 250
        Me.ToolTip1.SetToolTip(Me.cmdPilha, "Consulta a Pilha")
        '
        'cmdInformacoes
        '
        Appearance4.Image = Global.Logus.My.Resources.Resources.Informações
        Me.cmdInformacoes.Appearance = Appearance4
        Me.cmdInformacoes.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdInformacoes.Location = New System.Drawing.Point(321, 396)
        Me.cmdInformacoes.Name = "cmdInformacoes"
        Me.cmdInformacoes.Size = New System.Drawing.Size(45, 45)
        Me.cmdInformacoes.TabIndex = 251
        Me.ToolTip1.SetToolTip(Me.cmdInformacoes, "Visualiza Informações da Qualidade e Sacaria")
        '
        'cmdNFReferencia
        '
        Me.cmdNFReferencia.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdNFReferencia.Location = New System.Drawing.Point(372, 396)
        Me.cmdNFReferencia.Name = "cmdNFReferencia"
        Me.cmdNFReferencia.Size = New System.Drawing.Size(45, 45)
        Me.cmdNFReferencia.TabIndex = 252
        Me.cmdNFReferencia.Text = "NF Ref."
        '
        'mnuNFReferencia
        '
        Me.mnuNFReferencia.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNFReferencia_Incluir, Me.mnuNFReferencia_Apagar})
        Me.mnuNFReferencia.Name = "mnuExclusao"
        Me.mnuNFReferencia.Size = New System.Drawing.Size(236, 48)
        '
        'mnuNFReferencia_Incluir
        '
        Me.mnuNFReferencia_Incluir.Name = "mnuNFReferencia_Incluir"
        Me.mnuNFReferencia_Incluir.Size = New System.Drawing.Size(235, 22)
        Me.mnuNFReferencia_Incluir.Text = "Inclui dados da NF de referência"
        '
        'mnuNFReferencia_Apagar
        '
        Me.mnuNFReferencia_Apagar.Name = "mnuNFReferencia_Apagar"
        Me.mnuNFReferencia_Apagar.Size = New System.Drawing.Size(235, 22)
        Me.mnuNFReferencia_Apagar.Text = "Apaga dados da NF de referência"
        '
        'cmdObsAcerto
        '
        Me.cmdObsAcerto.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdObsAcerto.Location = New System.Drawing.Point(423, 396)
        Me.cmdObsAcerto.Name = "cmdObsAcerto"
        Me.cmdObsAcerto.Size = New System.Drawing.Size(45, 45)
        Me.cmdObsAcerto.TabIndex = 253
        Me.cmdObsAcerto.Text = "OA"
        '
        'cmdLivroFiscal
        '
        Appearance1.Image = Global.Logus.My.Resources.Resources.Remover_Livro_Fiscal
        Me.cmdLivroFiscal.Appearance = Appearance1
        Me.cmdLivroFiscal.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdLivroFiscal.Location = New System.Drawing.Point(527, 396)
        Me.cmdLivroFiscal.Name = "cmdLivroFiscal"
        Me.cmdLivroFiscal.Size = New System.Drawing.Size(45, 45)
        Me.cmdLivroFiscal.TabIndex = 297
        Me.ToolTip1.SetToolTip(Me.cmdLivroFiscal, "Remover da Interface Livro Fiscal")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(521, 62)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 13)
        Me.Label7.TabIndex = 255
        Me.Label7.Text = "Estado de Origem"
        '
        'cmdICMS
        '
        Me.cmdICMS.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdICMS.Location = New System.Drawing.Point(474, 396)
        Me.cmdICMS.Name = "cmdICMS"
        Me.cmdICMS.Size = New System.Drawing.Size(45, 45)
        Me.cmdICMS.TabIndex = 297
        Me.cmdICMS.Text = "IC"
        '
        'SelecaoTipoNovimentacao
        '
        Me.SelecaoTipoNovimentacao.BackColor = System.Drawing.Color.White
        Me.SelecaoTipoNovimentacao.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoTipoNovimentacao.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoTipoNovimentacao.BancoDados_Campo_OrdenarConsulta = True
        Me.SelecaoTipoNovimentacao.BancoDados_Tabela = Nothing
        Me.SelecaoTipoNovimentacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoTipoNovimentacao.Location = New System.Drawing.Point(246, 20)
        Me.SelecaoTipoNovimentacao.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoTipoNovimentacao.MultiplaSelecao = False
        Me.SelecaoTipoNovimentacao.Name = "SelecaoTipoNovimentacao"
        Me.SelecaoTipoNovimentacao.Size = New System.Drawing.Size(265, 20)
        Me.SelecaoTipoNovimentacao.TabIndex = 296
        '
        'SelecaoEstadoOrigem
        '
        Me.SelecaoEstadoOrigem.BackColor = System.Drawing.Color.White
        Me.SelecaoEstadoOrigem.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoEstadoOrigem.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoEstadoOrigem.BancoDados_Campo_OrdenarConsulta = True
        Me.SelecaoEstadoOrigem.BancoDados_Tabela = Nothing
        Me.SelecaoEstadoOrigem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoEstadoOrigem.Location = New System.Drawing.Point(521, 77)
        Me.SelecaoEstadoOrigem.MinimumSize = New System.Drawing.Size(150, 2)
        Me.SelecaoEstadoOrigem.MultiplaSelecao = False
        Me.SelecaoEstadoOrigem.Name = "SelecaoEstadoOrigem"
        Me.SelecaoEstadoOrigem.Size = New System.Drawing.Size(150, 20)
        Me.SelecaoEstadoOrigem.TabIndex = 254
        '
        'Pesq_Fornecedor
        '
        Me.Pesq_Fornecedor.BancoDados_Campo_Codigo = Nothing
        Me.Pesq_Fornecedor.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Fornecedor.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_Fornecedor.BancoDados_Campo_Descricao = Nothing
        Me.Pesq_Fornecedor.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_Fornecedor.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Fornecedor.BancoDados_Tabela = Nothing
        Me.Pesq_Fornecedor.Codigo = 0
        Me.Pesq_Fornecedor.ExibirCodigo = True
        Me.Pesq_Fornecedor.Location = New System.Drawing.Point(5, 77)
        Me.Pesq_Fornecedor.MaximumSize = New System.Drawing.Size(1000, 23)
        Me.Pesq_Fornecedor.MinimumSize = New System.Drawing.Size(0, 23)
        Me.Pesq_Fornecedor.Name = "Pesq_Fornecedor"
        Me.Pesq_Fornecedor.Size = New System.Drawing.Size(387, 23)
        Me.Pesq_Fornecedor.TabIndex = 234
        Me.Pesq_Fornecedor.TelaFiltro = False
        Me.Pesq_Fornecedor.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Inicializar
        '
        'SelecaoFilial
        '
        Me.SelecaoFilial.BackColor = System.Drawing.Color.White
        Me.SelecaoFilial.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoFilial.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoFilial.BancoDados_Campo_OrdenarConsulta = True
        Me.SelecaoFilial.BancoDados_Tabela = Nothing
        Me.SelecaoFilial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoFilial.Location = New System.Drawing.Point(517, 20)
        Me.SelecaoFilial.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoFilial.MultiplaSelecao = False
        Me.SelecaoFilial.Name = "SelecaoFilial"
        Me.SelecaoFilial.Size = New System.Drawing.Size(205, 20)
        Me.SelecaoFilial.TabIndex = 231
        '
        'frmConsultaMovimentacaoCacau
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(730, 448)
        Me.Controls.Add(Me.cmdICMS)
        Me.Controls.Add(Me.cmdLivroFiscal)
        Me.Controls.Add(Me.SelecaoTipoNovimentacao)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.SelecaoEstadoOrigem)
        Me.Controls.Add(Me.cmdObsAcerto)
        Me.Controls.Add(Me.cmdNFReferencia)
        Me.Controls.Add(Me.cmdInformacoes)
        Me.Controls.Add(Me.cmdPilha)
        Me.Controls.Add(Me.cmdRastreabilidade)
        Me.Controls.Add(Me.cmdUsuario)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdAlterar)
        Me.Controls.Add(Me.cmdExcluir)
        Me.Controls.Add(Me.cmdNovo)
        Me.Controls.Add(Me.cmdExcell)
        Me.Controls.Add(Me.grdGeral)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmdPesquisar)
        Me.Controls.Add(Me.txtNotaFiscal)
        Me.Controls.Add(Me.txtOrdemDescarga)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Pesq_Fornecedor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.SelecaoFilial)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsultaMovimentacaoCacau"
        Me.RightToLeftLayout = True
        Me.Text = "Consulta de  Movimentações de Cacau"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtDataFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuNFReferencia.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDataFinal As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtDataInicial As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents SelecaoFilial As Logus.Selecao
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Pesq_Fornecedor As Logus.Pesq_CodigoNome
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtOrdemDescarga As System.Windows.Forms.TextBox
    Friend WithEvents txtNotaFiscal As System.Windows.Forms.TextBox
    Friend WithEvents cmdPesquisar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents grdGeral As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cmdExcell As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdAlterar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdExcluir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdNovo As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdUsuario As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdRastreabilidade As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdPilha As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdInformacoes As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdNFReferencia As Infragistics.Win.Misc.UltraButton
    Friend WithEvents mnuNFReferencia As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuNFReferencia_Incluir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuNFReferencia_Apagar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdObsAcerto As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents SelecaoEstadoOrigem As Logus.Selecao
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents SelecaoTipoNovimentacao As Logus.Selecao
    Friend WithEvents cmdICMS As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdLivroFiscal As Infragistics.Win.Misc.UltraButton
End Class
