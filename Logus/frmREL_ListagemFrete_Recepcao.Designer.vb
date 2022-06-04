<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmREL_ListagemFrete_Recepcao
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
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Me.cmdExportaRelatorio = New Infragistics.Win.Misc.UltraButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtDataFinal = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtDataInicial = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdImprimir = New Infragistics.Win.Misc.UltraButton
        Me.optTipoPessoa = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.lblR_Filial = New System.Windows.Forms.Label
        Me.lblR_Fornecedor = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.crvMain = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lblR_OutrosTipos = New System.Windows.Forms.Label
        Me.optTipoCacau_Outros = New System.Windows.Forms.RadioButton
        Me.optTipoCacau_Todos = New System.Windows.Forms.RadioButton
        Me.optTipoCacau_SomenteCacauNPE = New System.Windows.Forms.RadioButton
        Me.optAgruparFilial = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkSoValorFrete = New System.Windows.Forms.CheckBox
        Me.SelecaoFornecedor = New Logus.Selecao
        Me.SelecaoFilialFrete = New Logus.Selecao
        Me.SelecaoFilialMovimentacao = New Logus.Selecao
        Me.SelecaoOutrosTipos = New Logus.Selecao
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtDataFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optTipoPessoa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.optAgruparFilial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdExportaRelatorio
        '
        Me.cmdExportaRelatorio.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExportaRelatorio.Location = New System.Drawing.Point(696, 96)
        Me.cmdExportaRelatorio.Name = "cmdExportaRelatorio"
        Me.cmdExportaRelatorio.Size = New System.Drawing.Size(45, 45)
        Me.cmdExportaRelatorio.TabIndex = 512
        Me.cmdExportaRelatorio.Text = "ER"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDataFinal)
        Me.GroupBox1.Controls.Add(Me.txtDataInicial)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(235, 49)
        Me.GroupBox1.TabIndex = 502
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Período"
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
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(745, 96)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 501
        Me.cmdFechar.Text = "F"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdImprimir.Location = New System.Drawing.Point(645, 96)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(45, 45)
        Me.cmdImprimir.TabIndex = 500
        Me.cmdImprimir.Text = "I"
        '
        'optTipoPessoa
        '
        Appearance3.TextHAlignAsString = "Center"
        Appearance3.TextVAlignAsString = "Middle"
        Me.optTipoPessoa.Appearance = Appearance3
        Me.optTipoPessoa.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.optTipoPessoa.CheckedIndex = 0
        Appearance4.TextHAlignAsString = "Center"
        Appearance4.TextVAlignAsString = "Middle"
        Me.optTipoPessoa.ItemAppearance = Appearance4
        Me.optTipoPessoa.ItemOrigin = New System.Drawing.Point(5, 4)
        ValueListItem4.DataValue = "T"
        ValueListItem4.DisplayText = "Todos"
        ValueListItem5.DataValue = "F"
        ValueListItem5.DisplayText = "Pessoa Física"
        ValueListItem6.DataValue = "J"
        ValueListItem6.DisplayText = "Pessoa Jurídica"
        Me.optTipoPessoa.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem4, ValueListItem5, ValueListItem6})
        Me.optTipoPessoa.Location = New System.Drawing.Point(251, 12)
        Me.optTipoPessoa.Name = "optTipoPessoa"
        Me.optTipoPessoa.Size = New System.Drawing.Size(121, 55)
        Me.optTipoPessoa.TabIndex = 497
        Me.optTipoPessoa.Text = "Todos"
        '
        'lblR_Filial
        '
        Me.lblR_Filial.AutoSize = True
        Me.lblR_Filial.Location = New System.Drawing.Point(8, 107)
        Me.lblR_Filial.Name = "lblR_Filial"
        Me.lblR_Filial.Size = New System.Drawing.Size(100, 13)
        Me.lblR_Filial.TabIndex = 495
        Me.lblR_Filial.Text = "Filial Movimentação"
        '
        'lblR_Fornecedor
        '
        Me.lblR_Fornecedor.AutoSize = True
        Me.lblR_Fornecedor.Location = New System.Drawing.Point(8, 65)
        Me.lblR_Fornecedor.Name = "lblR_Fornecedor"
        Me.lblR_Fornecedor.Size = New System.Drawing.Size(61, 13)
        Me.lblR_Fornecedor.TabIndex = 494
        Me.lblR_Fornecedor.Text = "Fornecedor"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(250, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 508
        Me.Label5.Text = "Filial Frete"
        '
        'crvMain
        '
        Me.crvMain.ActiveViewIndex = -1
        Me.crvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvMain.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.crvMain.Location = New System.Drawing.Point(8, 149)
        Me.crvMain.Name = "crvMain"
        Me.crvMain.SelectionFormula = ""
        Me.crvMain.ShowCloseButton = False
        Me.crvMain.ShowGroupTreeButton = False
        Me.crvMain.ShowRefreshButton = False
        Me.crvMain.Size = New System.Drawing.Size(782, 384)
        Me.crvMain.TabIndex = 493
        Me.crvMain.ViewTimeSelectionFormula = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblR_OutrosTipos)
        Me.GroupBox2.Controls.Add(Me.optTipoCacau_Outros)
        Me.GroupBox2.Controls.Add(Me.optTipoCacau_Todos)
        Me.GroupBox2.Controls.Add(Me.optTipoCacau_SomenteCacauNPE)
        Me.GroupBox2.Location = New System.Drawing.Point(382, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(404, 55)
        Me.GroupBox2.TabIndex = 513
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo de Cacau"
        '
        'lblR_OutrosTipos
        '
        Me.lblR_OutrosTipos.AutoSize = True
        Me.lblR_OutrosTipos.Location = New System.Drawing.Point(144, 14)
        Me.lblR_OutrosTipos.Name = "lblR_OutrosTipos"
        Me.lblR_OutrosTipos.Size = New System.Drawing.Size(67, 13)
        Me.lblR_OutrosTipos.TabIndex = 510
        Me.lblR_OutrosTipos.Text = "Outros Tipos"
        '
        'optTipoCacau_Outros
        '
        Me.optTipoCacau_Outros.AutoSize = True
        Me.optTipoCacau_Outros.Location = New System.Drawing.Point(73, 33)
        Me.optTipoCacau_Outros.Name = "optTipoCacau_Outros"
        Me.optTipoCacau_Outros.Size = New System.Drawing.Size(56, 17)
        Me.optTipoCacau_Outros.TabIndex = 0
        Me.optTipoCacau_Outros.Text = "Outros"
        Me.optTipoCacau_Outros.UseVisualStyleBackColor = True
        '
        'optTipoCacau_Todos
        '
        Me.optTipoCacau_Todos.AutoSize = True
        Me.optTipoCacau_Todos.Checked = True
        Me.optTipoCacau_Todos.Location = New System.Drawing.Point(10, 33)
        Me.optTipoCacau_Todos.Name = "optTipoCacau_Todos"
        Me.optTipoCacau_Todos.Size = New System.Drawing.Size(55, 17)
        Me.optTipoCacau_Todos.TabIndex = 0
        Me.optTipoCacau_Todos.TabStop = True
        Me.optTipoCacau_Todos.Text = "Todos"
        Me.optTipoCacau_Todos.UseVisualStyleBackColor = True
        '
        'optTipoCacau_SomenteCacauNPE
        '
        Me.optTipoCacau_SomenteCacauNPE.AutoSize = True
        Me.optTipoCacau_SomenteCacauNPE.Location = New System.Drawing.Point(10, 16)
        Me.optTipoCacau_SomenteCacauNPE.Name = "optTipoCacau_SomenteCacauNPE"
        Me.optTipoCacau_SomenteCacauNPE.Size = New System.Drawing.Size(126, 17)
        Me.optTipoCacau_SomenteCacauNPE.TabIndex = 0
        Me.optTipoCacau_SomenteCacauNPE.Text = "Somente Cacau NPE"
        Me.optTipoCacau_SomenteCacauNPE.UseVisualStyleBackColor = True
        '
        'optAgruparFilial
        '
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        Me.optAgruparFilial.Appearance = Appearance1
        Me.optAgruparFilial.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.optAgruparFilial.CheckedIndex = 0
        Appearance2.TextHAlignAsString = "Center"
        Appearance2.TextVAlignAsString = "Middle"
        Me.optAgruparFilial.ItemAppearance = Appearance2
        Me.optAgruparFilial.ItemOrigin = New System.Drawing.Point(5, 4)
        ValueListItem1.DataValue = "F"
        ValueListItem1.DisplayText = "Filial Fornecedor"
        ValueListItem2.DataValue = "M"
        ValueListItem2.DisplayText = "Filial Movimentação"
        Me.optAgruparFilial.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2})
        Me.optAgruparFilial.Location = New System.Drawing.Point(498, 93)
        Me.optAgruparFilial.Name = "optAgruparFilial"
        Me.optAgruparFilial.Size = New System.Drawing.Size(133, 38)
        Me.optAgruparFilial.TabIndex = 514
        Me.optAgruparFilial.Text = "Filial Fornecedor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(498, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 508
        Me.Label1.Text = "Agrupar por"
        '
        'chkSoValorFrete
        '
        Me.chkSoValorFrete.AutoSize = True
        Me.chkSoValorFrete.Checked = True
        Me.chkSoValorFrete.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSoValorFrete.Location = New System.Drawing.Point(645, 79)
        Me.chkSoValorFrete.Name = "chkSoValorFrete"
        Me.chkSoValorFrete.Size = New System.Drawing.Size(131, 17)
        Me.chkSoValorFrete.TabIndex = 515
        Me.chkSoValorFrete.Text = "Só com Valor de Frete"
        Me.chkSoValorFrete.UseVisualStyleBackColor = True
        '
        'SelecaoFornecedor
        '
        Me.SelecaoFornecedor.BackColor = System.Drawing.Color.White
        Me.SelecaoFornecedor.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoFornecedor.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoFornecedor.BancoDados_Campo_OrdenarConsulta = True
        Me.SelecaoFornecedor.BancoDados_Tabela = Nothing
        Me.SelecaoFornecedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoFornecedor.Location = New System.Drawing.Point(8, 79)
        Me.SelecaoFornecedor.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoFornecedor.MultiplaSelecao = False
        Me.SelecaoFornecedor.MultiplaSelecao_Codigo_Tipo = Logus.Selecao.enMultiplaSelecao_Codigo_Tipo.Numero
        Me.SelecaoFornecedor.Name = "SelecaoFornecedor"
        Me.SelecaoFornecedor.Size = New System.Drawing.Size(482, 20)
        Me.SelecaoFornecedor.TabIndex = 511
        '
        'SelecaoFilialFrete
        '
        Me.SelecaoFilialFrete.BackColor = System.Drawing.Color.White
        Me.SelecaoFilialFrete.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoFilialFrete.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoFilialFrete.BancoDados_Campo_OrdenarConsulta = True
        Me.SelecaoFilialFrete.BancoDados_Tabela = Nothing
        Me.SelecaoFilialFrete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoFilialFrete.Location = New System.Drawing.Point(250, 121)
        Me.SelecaoFilialFrete.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoFilialFrete.MultiplaSelecao = False
        Me.SelecaoFilialFrete.MultiplaSelecao_Codigo_Tipo = Logus.Selecao.enMultiplaSelecao_Codigo_Tipo.Numero
        Me.SelecaoFilialFrete.Name = "SelecaoFilialFrete"
        Me.SelecaoFilialFrete.Size = New System.Drawing.Size(240, 20)
        Me.SelecaoFilialFrete.TabIndex = 509
        '
        'SelecaoFilialMovimentacao
        '
        Me.SelecaoFilialMovimentacao.BackColor = System.Drawing.Color.White
        Me.SelecaoFilialMovimentacao.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoFilialMovimentacao.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoFilialMovimentacao.BancoDados_Campo_OrdenarConsulta = True
        Me.SelecaoFilialMovimentacao.BancoDados_Tabela = Nothing
        Me.SelecaoFilialMovimentacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoFilialMovimentacao.Location = New System.Drawing.Point(8, 121)
        Me.SelecaoFilialMovimentacao.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoFilialMovimentacao.MultiplaSelecao = False
        Me.SelecaoFilialMovimentacao.MultiplaSelecao_Codigo_Tipo = Logus.Selecao.enMultiplaSelecao_Codigo_Tipo.Numero
        Me.SelecaoFilialMovimentacao.Name = "SelecaoFilialMovimentacao"
        Me.SelecaoFilialMovimentacao.Size = New System.Drawing.Size(234, 20)
        Me.SelecaoFilialMovimentacao.TabIndex = 496
        '
        'SelecaoOutrosTipos
        '
        Me.SelecaoOutrosTipos.BackColor = System.Drawing.Color.White
        Me.SelecaoOutrosTipos.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoOutrosTipos.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoOutrosTipos.BancoDados_Campo_OrdenarConsulta = True
        Me.SelecaoOutrosTipos.BancoDados_Tabela = Nothing
        Me.SelecaoOutrosTipos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoOutrosTipos.Location = New System.Drawing.Point(529, 40)
        Me.SelecaoOutrosTipos.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoOutrosTipos.MultiplaSelecao = False
        Me.SelecaoOutrosTipos.MultiplaSelecao_Codigo_Tipo = Logus.Selecao.enMultiplaSelecao_Codigo_Tipo.Numero
        Me.SelecaoOutrosTipos.Name = "SelecaoOutrosTipos"
        Me.SelecaoOutrosTipos.Size = New System.Drawing.Size(251, 20)
        Me.SelecaoOutrosTipos.TabIndex = 516
        '
        'frmREL_ListagemFrete_Recepcao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 764)
        Me.Controls.Add(Me.SelecaoOutrosTipos)
        Me.Controls.Add(Me.chkSoValorFrete)
        Me.Controls.Add(Me.optAgruparFilial)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.SelecaoFornecedor)
        Me.Controls.Add(Me.cmdExportaRelatorio)
        Me.Controls.Add(Me.SelecaoFilialFrete)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.optTipoPessoa)
        Me.Controls.Add(Me.lblR_Filial)
        Me.Controls.Add(Me.lblR_Fornecedor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.SelecaoFilialMovimentacao)
        Me.Controls.Add(Me.crvMain)
        Me.Name = "frmREL_ListagemFrete_Recepcao"
        Me.Text = "Listagem de Frete de Recepção de Cacau"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtDataFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optTipoPessoa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.optAgruparFilial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SelecaoFornecedor As Logus.Selecao
    Friend WithEvents cmdExportaRelatorio As Infragistics.Win.Misc.UltraButton
    Friend WithEvents SelecaoFilialFrete As Logus.Selecao
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDataFinal As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtDataInicial As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdImprimir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents optTipoPessoa As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents lblR_Filial As System.Windows.Forms.Label
    Friend WithEvents lblR_Fornecedor As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents SelecaoFilialMovimentacao As Logus.Selecao
    Friend WithEvents crvMain As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents optTipoCacau_SomenteCacauNPE As System.Windows.Forms.RadioButton
    Friend WithEvents optTipoCacau_Todos As System.Windows.Forms.RadioButton
    Friend WithEvents optTipoCacau_Outros As System.Windows.Forms.RadioButton
    Friend WithEvents lblR_OutrosTipos As System.Windows.Forms.Label
    Friend WithEvents optAgruparFilial As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkSoValorFrete As System.Windows.Forms.CheckBox
    Friend WithEvents SelecaoOutrosTipos As Logus.Selecao
End Class
