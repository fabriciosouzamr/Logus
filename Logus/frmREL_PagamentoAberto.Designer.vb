<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmREL_PagamentoAberto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmREL_PagamentoAberto))
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdImprimir = New Infragistics.Win.Misc.UltraButton
        Me.crvMain = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Label7 = New System.Windows.Forms.Label
        Me.chkSemContrato = New System.Windows.Forms.CheckBox
        Me.chkAbertoContratoPAF = New System.Windows.Forms.CheckBox
        Me.chkAbertoNegociacao = New System.Windows.Forms.CheckBox
        Me.chkAgrupaFornecedor = New System.Windows.Forms.CheckBox
        Me.optTipo = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.Pesq_Fornecedor = New Logus.Pesq_CodigoNome
        Me.SelecaoFilial = New Logus.Selecao
        Me.cmdExportaRelatorio = New Infragistics.Win.Misc.UltraButton
        CType(Me.optTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(180, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(153, 16)
        Me.Label9.TabIndex = 290
        Me.Label9.Text = "Fornecedor"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(734, 28)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 286
        Me.cmdFechar.Text = "F"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdImprimir.Location = New System.Drawing.Point(633, 28)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(45, 45)
        Me.cmdImprimir.TabIndex = 285
        Me.cmdImprimir.Text = "I"
        '
        'crvMain
        '
        Me.crvMain.ActiveViewIndex = -1
        Me.crvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvMain.Location = New System.Drawing.Point(2, 87)
        Me.crvMain.Name = "crvMain"
        Me.crvMain.SelectionFormula = ""
        Me.crvMain.ShowCloseButton = False
        Me.crvMain.ShowGroupTreeButton = False
        Me.crvMain.ShowRefreshButton = False
        Me.crvMain.Size = New System.Drawing.Size(401, 369)
        Me.crvMain.TabIndex = 284
        Me.crvMain.ViewTimeSelectionFormula = ""
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(180, 3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 13)
        Me.Label7.TabIndex = 282
        Me.Label7.Text = "Filial"
        '
        'chkSemContrato
        '
        Me.chkSemContrato.AutoSize = True
        Me.chkSemContrato.Checked = True
        Me.chkSemContrato.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSemContrato.Location = New System.Drawing.Point(6, 3)
        Me.chkSemContrato.Name = "chkSemContrato"
        Me.chkSemContrato.Size = New System.Drawing.Size(90, 17)
        Me.chkSemContrato.TabIndex = 291
        Me.chkSemContrato.Text = "Sem Contrato"
        Me.chkSemContrato.UseVisualStyleBackColor = True
        '
        'chkAbertoContratoPAF
        '
        Me.chkAbertoContratoPAF.AutoSize = True
        Me.chkAbertoContratoPAF.Checked = True
        Me.chkAbertoContratoPAF.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAbertoContratoPAF.Location = New System.Drawing.Point(6, 23)
        Me.chkAbertoContratoPAF.Name = "chkAbertoContratoPAF"
        Me.chkAbertoContratoPAF.Size = New System.Drawing.Size(156, 17)
        Me.chkAbertoContratoPAF.TabIndex = 292
        Me.chkAbertoContratoPAF.Text = "Em Aberto no Contrato PAF"
        Me.chkAbertoContratoPAF.UseVisualStyleBackColor = True
        '
        'chkAbertoNegociacao
        '
        Me.chkAbertoNegociacao.AutoSize = True
        Me.chkAbertoNegociacao.Checked = True
        Me.chkAbertoNegociacao.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAbertoNegociacao.Location = New System.Drawing.Point(6, 46)
        Me.chkAbertoNegociacao.Name = "chkAbertoNegociacao"
        Me.chkAbertoNegociacao.Size = New System.Drawing.Size(151, 17)
        Me.chkAbertoNegociacao.TabIndex = 293
        Me.chkAbertoNegociacao.Text = "Em Aberto na Negociacao"
        Me.chkAbertoNegociacao.UseVisualStyleBackColor = True
        '
        'chkAgrupaFornecedor
        '
        Me.chkAgrupaFornecedor.AutoSize = True
        Me.chkAgrupaFornecedor.Location = New System.Drawing.Point(483, 56)
        Me.chkAgrupaFornecedor.Name = "chkAgrupaFornecedor"
        Me.chkAgrupaFornecedor.Size = New System.Drawing.Size(132, 17)
        Me.chkAgrupaFornecedor.TabIndex = 294
        Me.chkAgrupaFornecedor.Text = "Agrupa por Fonecedor"
        Me.chkAgrupaFornecedor.UseVisualStyleBackColor = True
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
        ValueListItem1.DataValue = "S"
        ValueListItem1.DisplayText = "Sintético"
        ValueListItem2.DataValue = "A"
        ValueListItem2.DisplayText = "Analítico"
        Me.optTipo.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2})
        Me.optTipo.Location = New System.Drawing.Point(483, 17)
        Me.optTipo.Name = "optTipo"
        Me.optTipo.Size = New System.Drawing.Size(144, 20)
        Me.optTipo.TabIndex = 295
        Me.optTipo.Text = "Sintético"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.chkAbertoNegociacao)
        Me.UltraGroupBox1.Controls.Add(Me.chkSemContrato)
        Me.UltraGroupBox1.Controls.Add(Me.chkAbertoContratoPAF)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(2, 3)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(172, 70)
        Me.UltraGroupBox1.TabIndex = 296
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
        Me.Pesq_Fornecedor.Location = New System.Drawing.Point(180, 53)
        Me.Pesq_Fornecedor.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_Fornecedor.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_Fornecedor.Name = "Pesq_Fornecedor"
        Me.Pesq_Fornecedor.Size = New System.Drawing.Size(297, 28)
        Me.Pesq_Fornecedor.TabIndex = 289
        Me.Pesq_Fornecedor.TelaFiltro = False
        Me.Pesq_Fornecedor.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'SelecaoFilial
        '
        Me.SelecaoFilial.BackColor = System.Drawing.Color.White
        Me.SelecaoFilial.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoFilial.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoFilial.BancoDados_Tabela = Nothing
        Me.SelecaoFilial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoFilial.Location = New System.Drawing.Point(180, 18)
        Me.SelecaoFilial.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoFilial.MultiplaSelecao = False
        Me.SelecaoFilial.Name = "SelecaoFilial"
        Me.SelecaoFilial.Size = New System.Drawing.Size(300, 19)
        Me.SelecaoFilial.TabIndex = 283
        '
        'cmdExportaRelatorio
        '
        Me.cmdExportaRelatorio.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExportaRelatorio.Location = New System.Drawing.Point(683, 28)
        Me.cmdExportaRelatorio.Name = "cmdExportaRelatorio"
        Me.cmdExportaRelatorio.Size = New System.Drawing.Size(45, 45)
        Me.cmdExportaRelatorio.TabIndex = 493
        Me.cmdExportaRelatorio.Text = "ER"
        '
        'frmREL_PagamentoAberto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(791, 676)
        Me.Controls.Add(Me.cmdExportaRelatorio)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.optTipo)
        Me.Controls.Add(Me.chkAgrupaFornecedor)
        Me.Controls.Add(Me.Pesq_Fornecedor)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.crvMain)
        Me.Controls.Add(Me.SelecaoFilial)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label9)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmREL_PagamentoAberto"
        Me.Text = "Relatório de Pagamentos em Aberto "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.optTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Pesq_Fornecedor As Logus.Pesq_CodigoNome
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdImprimir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents crvMain As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents SelecaoFilial As Logus.Selecao
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkSemContrato As System.Windows.Forms.CheckBox
    Friend WithEvents chkAbertoContratoPAF As System.Windows.Forms.CheckBox
    Friend WithEvents chkAbertoNegociacao As System.Windows.Forms.CheckBox
    Friend WithEvents chkAgrupaFornecedor As System.Windows.Forms.CheckBox
    Friend WithEvents optTipo As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents cmdExportaRelatorio As Infragistics.Win.Misc.UltraButton
End Class
