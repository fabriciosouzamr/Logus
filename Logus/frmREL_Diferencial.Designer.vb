<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmREL_Diferencial
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
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmREL_Diferencial))
        Me.optRelatorio = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.Label9 = New System.Windows.Forms.Label
        Me.crvMain = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdImprimir = New Infragistics.Win.Misc.UltraButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtDataFinal = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtDataInicial = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.optTipo = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.chkAgrupaFornecedor = New System.Windows.Forms.CheckBox
        Me.chkExcluiCancelado = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboOpcoes = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdExportaRelatorio = New Infragistics.Win.Misc.UltraButton
        Me.SelecaoTipoCacau = New Logus.Selecao
        Me.Pesq_Fornecedor = New Logus.Pesq_CodigoNome
        Me.SelecaoFilial = New Logus.Selecao
        Me.chkFilialEntregaCtr = New System.Windows.Forms.CheckBox
        Me.SelecaoTipoPessoa = New Logus.Selecao
        Me.SelecaoUF = New Logus.Selecao
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        CType(Me.optRelatorio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtDataFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'optRelatorio
        '
        Appearance5.TextHAlignAsString = "Center"
        Appearance5.TextVAlignAsString = "Middle"
        Me.optRelatorio.Appearance = Appearance5
        Me.optRelatorio.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.optRelatorio.CheckedIndex = 0
        Appearance6.TextHAlignAsString = "Center"
        Appearance6.TextVAlignAsString = "Middle"
        Me.optRelatorio.ItemAppearance = Appearance6
        Me.optRelatorio.ItemOrigin = New System.Drawing.Point(2, 2)
        ValueListItem1.DataValue = "D"
        ValueListItem1.DisplayText = "Diferencial"
        ValueListItem2.DataValue = "P"
        ValueListItem2.DisplayText = "Preço Base"
        Me.optRelatorio.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2})
        Me.optRelatorio.ItemSpacingHorizontal = 2
        Me.optRelatorio.ItemSpacingVertical = 5
        Me.optRelatorio.Location = New System.Drawing.Point(218, 34)
        Me.optRelatorio.Name = "optRelatorio"
        Me.optRelatorio.Size = New System.Drawing.Size(167, 24)
        Me.optRelatorio.TabIndex = 334
        Me.optRelatorio.Text = "Diferencial"
        Me.optRelatorio.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(8, 65)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 13)
        Me.Label9.TabIndex = 330
        Me.Label9.Text = "Fornecedor"
        '
        'crvMain
        '
        Me.crvMain.ActiveViewIndex = -1
        Me.crvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvMain.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.crvMain.Location = New System.Drawing.Point(8, 150)
        Me.crvMain.Name = "crvMain"
        Me.crvMain.SelectionFormula = ""
        Me.crvMain.ShowCloseButton = False
        Me.crvMain.ShowGroupTreeButton = False
        Me.crvMain.ShowRefreshButton = False
        Me.crvMain.Size = New System.Drawing.Size(669, 273)
        Me.crvMain.TabIndex = 328
        Me.crvMain.ToolPanelWidth = 150
        Me.crvMain.ViewTimeSelectionFormula = ""
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(745, 97)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 327
        Me.cmdFechar.Text = "F"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdImprimir.Location = New System.Drawing.Point(745, 46)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(45, 45)
        Me.cmdImprimir.TabIndex = 326
        Me.cmdImprimir.Text = "I"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDataFinal)
        Me.GroupBox1.Controls.Add(Me.txtDataInicial)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(202, 49)
        Me.GroupBox1.TabIndex = 325
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Período"
        '
        'txtDataFinal
        '
        Me.txtDataFinal.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataFinal.Location = New System.Drawing.Point(107, 17)
        Me.txtDataFinal.Name = "txtDataFinal"
        Me.txtDataFinal.Size = New System.Drawing.Size(86, 23)
        Me.txtDataFinal.TabIndex = 226
        Me.txtDataFinal.Value = Nothing
        '
        'txtDataInicial
        '
        Me.txtDataInicial.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataInicial.Location = New System.Drawing.Point(10, 17)
        Me.txtDataInicial.Name = "txtDataInicial"
        Me.txtDataInicial.Size = New System.Drawing.Size(91, 23)
        Me.txtDataInicial.TabIndex = 225
        Me.txtDataInicial.Value = Nothing
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 323
        Me.Label1.Text = "Filial"
        '
        'optTipo
        '
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        Me.optTipo.Appearance = Appearance1
        Me.optTipo.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.optTipo.CheckedIndex = 0
        Appearance2.TextHAlignAsString = "Center"
        Appearance2.TextVAlignAsString = "Middle"
        Me.optTipo.ItemAppearance = Appearance2
        Me.optTipo.ItemOrigin = New System.Drawing.Point(2, 2)
        ValueListItem3.DataValue = "S"
        ValueListItem3.DisplayText = "Sintético"
        ValueListItem4.DataValue = "A"
        ValueListItem4.DisplayText = "Analítico"
        Me.optTipo.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem3, ValueListItem4})
        Me.optTipo.ItemSpacingHorizontal = 2
        Me.optTipo.ItemSpacingVertical = 5
        Me.optTipo.Location = New System.Drawing.Point(218, 8)
        Me.optTipo.Name = "optTipo"
        Me.optTipo.Size = New System.Drawing.Size(167, 24)
        Me.optTipo.TabIndex = 335
        Me.optTipo.Text = "Sintético"
        '
        'chkAgrupaFornecedor
        '
        Me.chkAgrupaFornecedor.AutoSize = True
        Me.chkAgrupaFornecedor.Location = New System.Drawing.Point(579, 24)
        Me.chkAgrupaFornecedor.Name = "chkAgrupaFornecedor"
        Me.chkAgrupaFornecedor.Size = New System.Drawing.Size(136, 17)
        Me.chkAgrupaFornecedor.TabIndex = 336
        Me.chkAgrupaFornecedor.Text = "Agrupa Por Fornecedor"
        Me.chkAgrupaFornecedor.UseVisualStyleBackColor = True
        '
        'chkExcluiCancelado
        '
        Me.chkExcluiCancelado.AutoSize = True
        Me.chkExcluiCancelado.Location = New System.Drawing.Point(579, 41)
        Me.chkExcluiCancelado.Name = "chkExcluiCancelado"
        Me.chkExcluiCancelado.Size = New System.Drawing.Size(113, 17)
        Me.chkExcluiCancelado.TabIndex = 337
        Me.chkExcluiCancelado.Text = "Exclui Cancelados"
        Me.chkExcluiCancelado.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(391, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 339
        Me.Label2.Text = "Opções"
        '
        'cboOpcoes
        '
        Me.cboOpcoes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOpcoes.Location = New System.Drawing.Point(391, 22)
        Me.cboOpcoes.Name = "cboOpcoes"
        Me.cboOpcoes.Size = New System.Drawing.Size(180, 21)
        Me.cboOpcoes.TabIndex = 338
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(516, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 340
        Me.Label3.Text = "Tipo Cacau"
        '
        'cmdExportaRelatorio
        '
        Me.cmdExportaRelatorio.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExportaRelatorio.Location = New System.Drawing.Point(692, 97)
        Me.cmdExportaRelatorio.Name = "cmdExportaRelatorio"
        Me.cmdExportaRelatorio.Size = New System.Drawing.Size(45, 45)
        Me.cmdExportaRelatorio.TabIndex = 492
        Me.cmdExportaRelatorio.Text = "ER"
        '
        'SelecaoTipoCacau
        '
        Me.SelecaoTipoCacau.BackColor = System.Drawing.Color.White
        Me.SelecaoTipoCacau.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoTipoCacau.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoTipoCacau.BancoDados_Campo_OrdenarConsulta = True
        Me.SelecaoTipoCacau.BancoDados_Tabela = Nothing
        Me.SelecaoTipoCacau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoTipoCacau.Location = New System.Drawing.Point(516, 79)
        Me.SelecaoTipoCacau.MinimumSize = New System.Drawing.Size(100, 2)
        Me.SelecaoTipoCacau.MultiplaSelecao = False
        Me.SelecaoTipoCacau.Name = "SelecaoTipoCacau"
        Me.SelecaoTipoCacau.Size = New System.Drawing.Size(167, 20)
        Me.SelecaoTipoCacau.TabIndex = 341
        '
        'Pesq_Fornecedor
        '
        Me.Pesq_Fornecedor.BancoDados_Campo_Codigo = "CD_FORNECEDOR"
        Me.Pesq_Fornecedor.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Fornecedor.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_Fornecedor.BancoDados_Campo_Descricao = "NO_RAZAO_SOCIAL"
        Me.Pesq_Fornecedor.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_Fornecedor.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Fornecedor.BancoDados_Tabela = "FORNECEDOR F"
        Me.Pesq_Fornecedor.Codigo = 0
        Me.Pesq_Fornecedor.Enabled = False
        Me.Pesq_Fornecedor.ExibirCodigo = True
        Me.Pesq_Fornecedor.Location = New System.Drawing.Point(8, 79)
        Me.Pesq_Fornecedor.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_Fornecedor.MinimumSize = New System.Drawing.Size(0, 20)
        Me.Pesq_Fornecedor.Name = "Pesq_Fornecedor"
        Me.Pesq_Fornecedor.Size = New System.Drawing.Size(500, 21)
        Me.Pesq_Fornecedor.TabIndex = 329
        Me.Pesq_Fornecedor.TelaFiltro = False
        Me.Pesq_Fornecedor.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'SelecaoFilial
        '
        Me.SelecaoFilial.BackColor = System.Drawing.Color.White
        Me.SelecaoFilial.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoFilial.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoFilial.BancoDados_Campo_OrdenarConsulta = True
        Me.SelecaoFilial.BancoDados_Tabela = Nothing
        Me.SelecaoFilial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoFilial.Location = New System.Drawing.Point(8, 122)
        Me.SelecaoFilial.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoFilial.MultiplaSelecao = False
        Me.SelecaoFilial.Name = "SelecaoFilial"
        Me.SelecaoFilial.Size = New System.Drawing.Size(313, 20)
        Me.SelecaoFilial.TabIndex = 324
        '
        'chkFilialEntregaCtr
        '
        Me.chkFilialEntregaCtr.AutoSize = True
        Me.chkFilialEntregaCtr.Location = New System.Drawing.Point(579, 7)
        Me.chkFilialEntregaCtr.Name = "chkFilialEntregaCtr"
        Me.chkFilialEntregaCtr.Size = New System.Drawing.Size(135, 17)
        Me.chkFilialEntregaCtr.TabIndex = 336
        Me.chkFilialEntregaCtr.Text = "Filial de Entrega do Ctr."
        Me.chkFilialEntregaCtr.UseVisualStyleBackColor = True
        '
        'SelecaoTipoPessoa
        '
        Me.SelecaoTipoPessoa.BackColor = System.Drawing.Color.White
        Me.SelecaoTipoPessoa.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoTipoPessoa.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoTipoPessoa.BancoDados_Campo_OrdenarConsulta = True
        Me.SelecaoTipoPessoa.BancoDados_Tabela = Nothing
        Me.SelecaoTipoPessoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoTipoPessoa.Location = New System.Drawing.Point(327, 122)
        Me.SelecaoTipoPessoa.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoTipoPessoa.MultiplaSelecao = False
        Me.SelecaoTipoPessoa.Name = "SelecaoTipoPessoa"
        Me.SelecaoTipoPessoa.Size = New System.Drawing.Size(200, 20)
        Me.SelecaoTipoPessoa.TabIndex = 324
        '
        'SelecaoUF
        '
        Me.SelecaoUF.BackColor = System.Drawing.Color.White
        Me.SelecaoUF.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoUF.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoUF.BancoDados_Campo_OrdenarConsulta = True
        Me.SelecaoUF.BancoDados_Tabela = Nothing
        Me.SelecaoUF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoUF.Location = New System.Drawing.Point(533, 122)
        Me.SelecaoUF.MinimumSize = New System.Drawing.Size(100, 2)
        Me.SelecaoUF.MultiplaSelecao = False
        Me.SelecaoUF.Name = "SelecaoUF"
        Me.SelecaoUF.Size = New System.Drawing.Size(150, 20)
        Me.SelecaoUF.TabIndex = 324
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(327, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 323
        Me.Label4.Text = "Tipo de Pessoa"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(533, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 13)
        Me.Label5.TabIndex = 323
        Me.Label5.Text = "U.F."
        '
        'frmREL_Diferencial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(827, 536)
        Me.Controls.Add(Me.cmdExportaRelatorio)
        Me.Controls.Add(Me.SelecaoTipoCacau)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboOpcoes)
        Me.Controls.Add(Me.chkExcluiCancelado)
        Me.Controls.Add(Me.chkFilialEntregaCtr)
        Me.Controls.Add(Me.chkAgrupaFornecedor)
        Me.Controls.Add(Me.optTipo)
        Me.Controls.Add(Me.optRelatorio)
        Me.Controls.Add(Me.Pesq_Fornecedor)
        Me.Controls.Add(Me.crvMain)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.SelecaoUF)
        Me.Controls.Add(Me.SelecaoTipoPessoa)
        Me.Controls.Add(Me.SelecaoFilial)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label9)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmREL_Diferencial"
        Me.Text = "Relatório de Cálculo de Diferencial"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.optRelatorio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtDataFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents optRelatorio As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Pesq_Fornecedor As Logus.Pesq_CodigoNome
    Friend WithEvents crvMain As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdImprimir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDataFinal As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtDataInicial As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents SelecaoFilial As Logus.Selecao
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents optTipo As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents chkAgrupaFornecedor As System.Windows.Forms.CheckBox
    Friend WithEvents chkExcluiCancelado As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboOpcoes As System.Windows.Forms.ComboBox
    Friend WithEvents SelecaoTipoCacau As Logus.Selecao
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdExportaRelatorio As Infragistics.Win.Misc.UltraButton
    Friend WithEvents chkFilialEntregaCtr As System.Windows.Forms.CheckBox
    Friend WithEvents SelecaoTipoPessoa As Logus.Selecao
    Friend WithEvents SelecaoUF As Logus.Selecao
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
