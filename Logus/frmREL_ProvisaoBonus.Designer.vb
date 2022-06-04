<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmREL_ProvisaoBonus
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
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmREL_ProvisaoBonus))
        Me.Label9 = New System.Windows.Forms.Label
        Me.Pesq_Fornecedor = New Logus.Pesq_CodigoNome
        Me.crvMain = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdImprimir = New Infragistics.Win.Misc.UltraButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtDataFinal = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtDataInicial = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.SelecaoFilial = New Logus.Selecao
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtTaxaDolar = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.optTipo = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.optNivel = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.cmdExportaRelatorio = New Infragistics.Win.Misc.UltraButton
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtDataFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTaxaDolar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optNivel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(1, 58)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(153, 16)
        Me.Label9.TabIndex = 288
        Me.Label9.Text = "Fornecedor"
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
        Me.Pesq_Fornecedor.Location = New System.Drawing.Point(1, 71)
        Me.Pesq_Fornecedor.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_Fornecedor.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_Fornecedor.Name = "Pesq_Fornecedor"
        Me.Pesq_Fornecedor.Size = New System.Drawing.Size(297, 28)
        Me.Pesq_Fornecedor.TabIndex = 287
        Me.Pesq_Fornecedor.TelaFiltro = False
        Me.Pesq_Fornecedor.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'crvMain
        '
        Me.crvMain.ActiveViewIndex = -1
        Me.crvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvMain.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.crvMain.Location = New System.Drawing.Point(4, 105)
        Me.crvMain.Name = "crvMain"
        Me.crvMain.SelectionFormula = ""
        Me.crvMain.ShowCloseButton = False
        Me.crvMain.ShowGroupTreeButton = False
        Me.crvMain.ShowRefreshButton = False
        Me.crvMain.Size = New System.Drawing.Size(630, 379)
        Me.crvMain.TabIndex = 286
        Me.crvMain.ViewTimeSelectionFormula = ""
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(667, 46)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 285
        Me.cmdFechar.Text = "F"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdImprimir.Location = New System.Drawing.Point(565, 46)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(45, 45)
        Me.cmdImprimir.TabIndex = 284
        Me.cmdImprimir.Text = "I"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDataFinal)
        Me.GroupBox1.Controls.Add(Me.txtDataInicial)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(235, 49)
        Me.GroupBox1.TabIndex = 283
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
        'SelecaoFilial
        '
        Me.SelecaoFilial.BackColor = System.Drawing.Color.White
        Me.SelecaoFilial.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoFilial.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoFilial.BancoDados_Campo_OrdenarConsulta = True
        Me.SelecaoFilial.BancoDados_Tabela = Nothing
        Me.SelecaoFilial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoFilial.Location = New System.Drawing.Point(307, 71)
        Me.SelecaoFilial.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoFilial.MultiplaSelecao = False
        Me.SelecaoFilial.MultiplaSelecao_Codigo_Tipo = Logus.Selecao.enMultiplaSelecao_Codigo_Tipo.Numero
        Me.SelecaoFilial.Name = "SelecaoFilial"
        Me.SelecaoFilial.Size = New System.Drawing.Size(250, 20)
        Me.SelecaoFilial.TabIndex = 282
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(307, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 281
        Me.Label1.Text = "Filial"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(242, 14)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 13)
        Me.Label11.TabIndex = 321
        Me.Label11.Text = "Taxa Dolar"
        '
        'txtTaxaDolar
        '
        Me.txtTaxaDolar.Location = New System.Drawing.Point(245, 31)
        Me.txtTaxaDolar.MaskInput = "{LOC}-n.nnnn"
        Me.txtTaxaDolar.Name = "txtTaxaDolar"
        Me.txtTaxaDolar.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtTaxaDolar.Size = New System.Drawing.Size(56, 21)
        Me.txtTaxaDolar.TabIndex = 320
        '
        'optTipo
        '
        Appearance3.TextHAlignAsString = "Center"
        Appearance3.TextVAlignAsString = "Middle"
        Me.optTipo.Appearance = Appearance3
        Me.optTipo.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.optTipo.CheckedIndex = 0
        Appearance4.TextHAlignAsString = "Center"
        Appearance4.TextVAlignAsString = "Middle"
        Me.optTipo.ItemAppearance = Appearance4
        Me.optTipo.ItemOrigin = New System.Drawing.Point(2, 2)
        ValueListItem1.DataValue = "A"
        ValueListItem1.DisplayText = "A Provisionar"
        ValueListItem2.DataValue = "P"
        ValueListItem2.DisplayText = "Provisionado"
        ValueListItem3.DataValue = "C"
        ValueListItem3.DisplayText = "Cancelado"
        Me.optTipo.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem3})
        Me.optTipo.Location = New System.Drawing.Point(307, 4)
        Me.optTipo.Name = "optTipo"
        Me.optTipo.Size = New System.Drawing.Size(124, 49)
        Me.optTipo.TabIndex = 319
        Me.optTipo.Text = "A Provisionar"
        '
        'optNivel
        '
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        Me.optNivel.Appearance = Appearance1
        Me.optNivel.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.optNivel.CheckedIndex = 0
        Appearance2.TextHAlignAsString = "Center"
        Appearance2.TextVAlignAsString = "Middle"
        Me.optNivel.ItemAppearance = Appearance2
        Me.optNivel.ItemOrigin = New System.Drawing.Point(2, 2)
        ValueListItem4.DataValue = "P"
        ValueListItem4.DisplayText = "Premio"
        ValueListItem5.DataValue = "M"
        ValueListItem5.DisplayText = "Movimentação"
        ValueListItem6.DataValue = "F"
        ValueListItem6.DisplayText = "Fornecedor"
        Me.optNivel.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem4, ValueListItem5, ValueListItem6})
        Me.optNivel.Location = New System.Drawing.Point(437, 4)
        Me.optNivel.Name = "optNivel"
        Me.optNivel.Size = New System.Drawing.Size(120, 49)
        Me.optNivel.TabIndex = 322
        Me.optNivel.Text = "Premio"
        '
        'cmdExportaRelatorio
        '
        Me.cmdExportaRelatorio.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExportaRelatorio.Location = New System.Drawing.Point(616, 46)
        Me.cmdExportaRelatorio.Name = "cmdExportaRelatorio"
        Me.cmdExportaRelatorio.Size = New System.Drawing.Size(45, 45)
        Me.cmdExportaRelatorio.TabIndex = 493
        Me.cmdExportaRelatorio.Text = "ER"
        '
        'frmREL_ProvisaoBonus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(799, 592)
        Me.Controls.Add(Me.cmdExportaRelatorio)
        Me.Controls.Add(Me.optNivel)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtTaxaDolar)
        Me.Controls.Add(Me.optTipo)
        Me.Controls.Add(Me.Pesq_Fornecedor)
        Me.Controls.Add(Me.crvMain)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.SelecaoFilial)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label9)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmREL_ProvisaoBonus"
        Me.Text = "Relatório Provisão de Bonus "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtDataFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTaxaDolar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optNivel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTaxaDolar As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents optTipo As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents optNivel As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents cmdExportaRelatorio As Infragistics.Win.Misc.UltraButton
End Class
