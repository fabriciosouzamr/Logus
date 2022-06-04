<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmREL_Aplicacoes
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmREL_Aplicacoes))
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.chkContratoFixo = New System.Windows.Forms.CheckBox
        Me.chkSemContrato = New System.Windows.Forms.CheckBox
        Me.chkNegociacao = New System.Windows.Forms.CheckBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Pesq_Fornecedor = New Logus.Pesq_CodigoNome
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdImprimir = New Infragistics.Win.Misc.UltraButton
        Me.crvMain = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SelecaoFilial = New Logus.Selecao
        Me.Label7 = New System.Windows.Forms.Label
        Me.optPagRec = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtDataFinal = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtDataInicial = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.cmdExportaRelatorio = New Infragistics.Win.Misc.UltraButton
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.optPagRec, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtDataFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.chkContratoFixo)
        Me.UltraGroupBox1.Controls.Add(Me.chkSemContrato)
        Me.UltraGroupBox1.Controls.Add(Me.chkNegociacao)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(3, 8)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(114, 70)
        Me.UltraGroupBox1.TabIndex = 305
        '
        'chkContratoFixo
        '
        Me.chkContratoFixo.AutoSize = True
        Me.chkContratoFixo.Checked = True
        Me.chkContratoFixo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkContratoFixo.Location = New System.Drawing.Point(6, 46)
        Me.chkContratoFixo.Name = "chkContratoFixo"
        Me.chkContratoFixo.Size = New System.Drawing.Size(88, 17)
        Me.chkContratoFixo.TabIndex = 293
        Me.chkContratoFixo.Text = "Contrato Fixo"
        Me.chkContratoFixo.UseVisualStyleBackColor = True
        '
        'chkSemContrato
        '
        Me.chkSemContrato.AutoSize = True
        Me.chkSemContrato.Checked = True
        Me.chkSemContrato.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSemContrato.Location = New System.Drawing.Point(6, 3)
        Me.chkSemContrato.Name = "chkSemContrato"
        Me.chkSemContrato.Size = New System.Drawing.Size(89, 17)
        Me.chkSemContrato.TabIndex = 291
        Me.chkSemContrato.Text = "Contrato PAF"
        Me.chkSemContrato.UseVisualStyleBackColor = True
        '
        'chkNegociacao
        '
        Me.chkNegociacao.AutoSize = True
        Me.chkNegociacao.Checked = True
        Me.chkNegociacao.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNegociacao.Location = New System.Drawing.Point(6, 25)
        Me.chkNegociacao.Name = "chkNegociacao"
        Me.chkNegociacao.Size = New System.Drawing.Size(84, 17)
        Me.chkNegociacao.TabIndex = 292
        Me.chkNegociacao.Text = "Negociação"
        Me.chkNegociacao.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(123, 45)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(153, 16)
        Me.Label9.TabIndex = 302
        Me.Label9.Text = "Fornecedor da Movimentação"
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
        Me.Pesq_Fornecedor.ExibirCodigo = True
        Me.Pesq_Fornecedor.Location = New System.Drawing.Point(123, 58)
        Me.Pesq_Fornecedor.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_Fornecedor.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_Fornecedor.Name = "Pesq_Fornecedor"
        Me.Pesq_Fornecedor.Size = New System.Drawing.Size(297, 28)
        Me.Pesq_Fornecedor.TabIndex = 301
        Me.Pesq_Fornecedor.TelaFiltro = False
        Me.Pesq_Fornecedor.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(768, 40)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 300
        Me.cmdFechar.Text = "F"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdImprimir.Location = New System.Drawing.Point(666, 40)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(45, 45)
        Me.cmdImprimir.TabIndex = 299
        Me.cmdImprimir.Text = "I"
        '
        'crvMain
        '
        Me.crvMain.ActiveViewIndex = -1
        Me.crvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvMain.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.crvMain.Location = New System.Drawing.Point(3, 92)
        Me.crvMain.Name = "crvMain"
        Me.crvMain.SelectionFormula = ""
        Me.crvMain.ShowCloseButton = False
        Me.crvMain.ShowGroupTreeButton = False
        Me.crvMain.ShowRefreshButton = False
        Me.crvMain.Size = New System.Drawing.Size(401, 369)
        Me.crvMain.TabIndex = 298
        Me.crvMain.ViewTimeSelectionFormula = ""
        '
        'SelecaoFilial
        '
        Me.SelecaoFilial.BackColor = System.Drawing.Color.White
        Me.SelecaoFilial.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoFilial.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoFilial.BancoDados_Campo_OrdenarConsulta = True
        Me.SelecaoFilial.BancoDados_Tabela = Nothing
        Me.SelecaoFilial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoFilial.Location = New System.Drawing.Point(123, 23)
        Me.SelecaoFilial.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoFilial.MultiplaSelecao = False
        Me.SelecaoFilial.Name = "SelecaoFilial"
        Me.SelecaoFilial.Size = New System.Drawing.Size(300, 19)
        Me.SelecaoFilial.TabIndex = 297
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(123, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 13)
        Me.Label7.TabIndex = 306
        Me.Label7.Text = "Filial"
        '
        'optPagRec
        '
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        Me.optPagRec.Appearance = Appearance1
        Me.optPagRec.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.optPagRec.CheckedIndex = 0
        Appearance2.TextHAlignAsString = "Center"
        Appearance2.TextVAlignAsString = "Middle"
        Me.optPagRec.ItemAppearance = Appearance2
        Me.optPagRec.ItemOrigin = New System.Drawing.Point(2, 2)
        ValueListItem3.DataValue = "P"
        ValueListItem3.DisplayText = "Pagamentos"
        ValueListItem4.DataValue = "R"
        ValueListItem4.DisplayText = "Recebimentos"
        Me.optPagRec.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem3, ValueListItem4})
        Me.optPagRec.Location = New System.Drawing.Point(429, 11)
        Me.optPagRec.Name = "optPagRec"
        Me.optPagRec.Size = New System.Drawing.Size(190, 20)
        Me.optPagRec.TabIndex = 307
        Me.optPagRec.Text = "Pagamentos"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDataFinal)
        Me.GroupBox1.Controls.Add(Me.txtDataInicial)
        Me.GroupBox1.Location = New System.Drawing.Point(426, 37)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(235, 49)
        Me.GroupBox1.TabIndex = 308
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
        'cmdExportaRelatorio
        '
        Me.cmdExportaRelatorio.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExportaRelatorio.Location = New System.Drawing.Point(717, 40)
        Me.cmdExportaRelatorio.Name = "cmdExportaRelatorio"
        Me.cmdExportaRelatorio.Size = New System.Drawing.Size(45, 45)
        Me.cmdExportaRelatorio.TabIndex = 492
        Me.cmdExportaRelatorio.Text = "ER"
        '
        'frmREL_Aplicacoes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(821, 729)
        Me.Controls.Add(Me.cmdExportaRelatorio)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.optPagRec)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.Pesq_Fornecedor)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.crvMain)
        Me.Controls.Add(Me.SelecaoFilial)
        Me.Controls.Add(Me.Label9)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmREL_Aplicacoes"
        Me.Text = "Aplicações em Contratos"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.optPagRec, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtDataFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataInicial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents chkContratoFixo As System.Windows.Forms.CheckBox
    Friend WithEvents chkSemContrato As System.Windows.Forms.CheckBox
    Friend WithEvents chkNegociacao As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Pesq_Fornecedor As Logus.Pesq_CodigoNome
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdImprimir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents crvMain As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents SelecaoFilial As Logus.Selecao
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents optPagRec As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDataFinal As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtDataInicial As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents cmdExportaRelatorio As Infragistics.Win.Misc.UltraButton
End Class
