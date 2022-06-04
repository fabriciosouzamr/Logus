<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmREL_Ajuste_RDE
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.optTipoRelatorio_AcertoEstoqueFisico = New System.Windows.Forms.RadioButton
        Me.optTipoRelatorio_AcertoRD = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtDataFinal = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtDataInicial = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.optStatus_AguardandoAprovacao = New System.Windows.Forms.RadioButton
        Me.optStatus_Reprovado = New System.Windows.Forms.RadioButton
        Me.optStatus_Aprovado = New System.Windows.Forms.RadioButton
        Me.optStatus_Todos = New System.Windows.Forms.RadioButton
        Me.grpFornecedor = New System.Windows.Forms.GroupBox
        Me.Pesq_Fornecedor = New Logus.Pesq_CodigoNome
        Me.grpTipoMovimentacao = New System.Windows.Forms.GroupBox
        Me.Pesq_TipoMovimentacao = New Logus.Pesq_CodigoNome
        Me.cmdExportaRelatorio = New Infragistics.Win.Misc.UltraButton
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdImprimir = New Infragistics.Win.Misc.UltraButton
        Me.crvMain = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.chkExibirJustificativas = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.txtDataFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.grpFornecedor.SuspendLayout()
        Me.grpTipoMovimentacao.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optTipoRelatorio_AcertoEstoqueFisico)
        Me.GroupBox1.Controls.Add(Me.optTipoRelatorio_AcertoRD)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(167, 49)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo de Relatório"
        '
        'optTipoRelatorio_AcertoEstoqueFisico
        '
        Me.optTipoRelatorio_AcertoEstoqueFisico.AutoSize = True
        Me.optTipoRelatorio_AcertoEstoqueFisico.Location = New System.Drawing.Point(12, 30)
        Me.optTipoRelatorio_AcertoEstoqueFisico.Name = "optTipoRelatorio_AcertoEstoqueFisico"
        Me.optTipoRelatorio_AcertoEstoqueFisico.Size = New System.Drawing.Size(145, 17)
        Me.optTipoRelatorio_AcertoEstoqueFisico.TabIndex = 0
        Me.optTipoRelatorio_AcertoEstoqueFisico.TabStop = True
        Me.optTipoRelatorio_AcertoEstoqueFisico.Text = "Acerto de Estoque Físico"
        Me.optTipoRelatorio_AcertoEstoqueFisico.UseVisualStyleBackColor = True
        '
        'optTipoRelatorio_AcertoRD
        '
        Me.optTipoRelatorio_AcertoRD.AutoSize = True
        Me.optTipoRelatorio_AcertoRD.Location = New System.Drawing.Point(12, 14)
        Me.optTipoRelatorio_AcertoRD.Name = "optTipoRelatorio_AcertoRD"
        Me.optTipoRelatorio_AcertoRD.Size = New System.Drawing.Size(90, 17)
        Me.optTipoRelatorio_AcertoRD.TabIndex = 0
        Me.optTipoRelatorio_AcertoRD.TabStop = True
        Me.optTipoRelatorio_AcertoRD.Text = "Acerto de RD"
        Me.optTipoRelatorio_AcertoRD.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtDataFinal)
        Me.GroupBox2.Controls.Add(Me.txtDataInicial)
        Me.GroupBox2.Location = New System.Drawing.Point(183, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(235, 49)
        Me.GroupBox2.TabIndex = 299
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Período"
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
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.optStatus_AguardandoAprovacao)
        Me.GroupBox3.Controls.Add(Me.optStatus_Reprovado)
        Me.GroupBox3.Controls.Add(Me.optStatus_Aprovado)
        Me.GroupBox3.Controls.Add(Me.optStatus_Todos)
        Me.GroupBox3.Location = New System.Drawing.Point(426, 8)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(234, 49)
        Me.GroupBox3.TabIndex = 300
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Status"
        '
        'optStatus_AguardandoAprovacao
        '
        Me.optStatus_AguardandoAprovacao.AutoSize = True
        Me.optStatus_AguardandoAprovacao.Location = New System.Drawing.Point(91, 14)
        Me.optStatus_AguardandoAprovacao.Name = "optStatus_AguardandoAprovacao"
        Me.optStatus_AguardandoAprovacao.Size = New System.Drawing.Size(138, 17)
        Me.optStatus_AguardandoAprovacao.TabIndex = 0
        Me.optStatus_AguardandoAprovacao.TabStop = True
        Me.optStatus_AguardandoAprovacao.Text = "Aguardando Aprovação"
        Me.optStatus_AguardandoAprovacao.UseVisualStyleBackColor = True
        '
        'optStatus_Reprovado
        '
        Me.optStatus_Reprovado.AutoSize = True
        Me.optStatus_Reprovado.Location = New System.Drawing.Point(91, 30)
        Me.optStatus_Reprovado.Name = "optStatus_Reprovado"
        Me.optStatus_Reprovado.Size = New System.Drawing.Size(78, 17)
        Me.optStatus_Reprovado.TabIndex = 0
        Me.optStatus_Reprovado.TabStop = True
        Me.optStatus_Reprovado.Text = "Reprovado"
        Me.optStatus_Reprovado.UseVisualStyleBackColor = True
        '
        'optStatus_Aprovado
        '
        Me.optStatus_Aprovado.AutoSize = True
        Me.optStatus_Aprovado.Location = New System.Drawing.Point(12, 30)
        Me.optStatus_Aprovado.Name = "optStatus_Aprovado"
        Me.optStatus_Aprovado.Size = New System.Drawing.Size(71, 17)
        Me.optStatus_Aprovado.TabIndex = 0
        Me.optStatus_Aprovado.TabStop = True
        Me.optStatus_Aprovado.Text = "Aprovado"
        Me.optStatus_Aprovado.UseVisualStyleBackColor = True
        '
        'optStatus_Todos
        '
        Me.optStatus_Todos.AutoSize = True
        Me.optStatus_Todos.Checked = True
        Me.optStatus_Todos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.optStatus_Todos.Location = New System.Drawing.Point(12, 14)
        Me.optStatus_Todos.Name = "optStatus_Todos"
        Me.optStatus_Todos.Size = New System.Drawing.Size(55, 17)
        Me.optStatus_Todos.TabIndex = 0
        Me.optStatus_Todos.TabStop = True
        Me.optStatus_Todos.Text = "Todos"
        Me.optStatus_Todos.UseVisualStyleBackColor = True
        '
        'grpFornecedor
        '
        Me.grpFornecedor.Controls.Add(Me.Pesq_Fornecedor)
        Me.grpFornecedor.Location = New System.Drawing.Point(8, 60)
        Me.grpFornecedor.Name = "grpFornecedor"
        Me.grpFornecedor.Size = New System.Drawing.Size(352, 43)
        Me.grpFornecedor.TabIndex = 301
        Me.grpFornecedor.TabStop = False
        Me.grpFornecedor.Text = "Fornecedor"
        '
        'Pesq_Fornecedor
        '
        Me.Pesq_Fornecedor.Ativo = True
        Me.Pesq_Fornecedor.BancoDados_Campo_Codigo = Nothing
        Me.Pesq_Fornecedor.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Fornecedor.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_Fornecedor.BancoDados_Campo_Descricao = Nothing
        Me.Pesq_Fornecedor.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_Fornecedor.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Fornecedor.BancoDados_Tabela = Nothing
        Me.Pesq_Fornecedor.Codigo = 0
        Me.Pesq_Fornecedor.Descricao = ""
        Me.Pesq_Fornecedor.ExibirCodigo = True
        Me.Pesq_Fornecedor.Location = New System.Drawing.Point(10, 14)
        Me.Pesq_Fornecedor.MaximumSize = New System.Drawing.Size(1000, 23)
        Me.Pesq_Fornecedor.MinimumSize = New System.Drawing.Size(0, 23)
        Me.Pesq_Fornecedor.Name = "Pesq_Fornecedor"
        Me.Pesq_Fornecedor.Size = New System.Drawing.Size(334, 23)
        Me.Pesq_Fornecedor.TabIndex = 0
        Me.Pesq_Fornecedor.TelaFiltro = False
        Me.Pesq_Fornecedor.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Inicializar
        '
        'grpTipoMovimentacao
        '
        Me.grpTipoMovimentacao.Controls.Add(Me.Pesq_TipoMovimentacao)
        Me.grpTipoMovimentacao.Location = New System.Drawing.Point(366, 60)
        Me.grpTipoMovimentacao.Name = "grpTipoMovimentacao"
        Me.grpTipoMovimentacao.Size = New System.Drawing.Size(294, 43)
        Me.grpTipoMovimentacao.TabIndex = 302
        Me.grpTipoMovimentacao.TabStop = False
        Me.grpTipoMovimentacao.Text = "Tipo de Movimentação"
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
        Me.Pesq_TipoMovimentacao.Location = New System.Drawing.Point(10, 14)
        Me.Pesq_TipoMovimentacao.MaximumSize = New System.Drawing.Size(1000, 23)
        Me.Pesq_TipoMovimentacao.MinimumSize = New System.Drawing.Size(0, 23)
        Me.Pesq_TipoMovimentacao.Name = "Pesq_TipoMovimentacao"
        Me.Pesq_TipoMovimentacao.Size = New System.Drawing.Size(277, 23)
        Me.Pesq_TipoMovimentacao.TabIndex = 1
        Me.Pesq_TipoMovimentacao.TelaFiltro = False
        Me.Pesq_TipoMovimentacao.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Inicializar
        '
        'cmdExportaRelatorio
        '
        Me.cmdExportaRelatorio.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExportaRelatorio.Location = New System.Drawing.Point(717, 63)
        Me.cmdExportaRelatorio.Name = "cmdExportaRelatorio"
        Me.cmdExportaRelatorio.Size = New System.Drawing.Size(45, 45)
        Me.cmdExportaRelatorio.TabIndex = 496
        Me.cmdExportaRelatorio.Text = "ER"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(766, 63)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 495
        Me.cmdFechar.Text = "F"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdImprimir.Location = New System.Drawing.Point(666, 63)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(45, 45)
        Me.cmdImprimir.TabIndex = 494
        Me.cmdImprimir.Text = "I"
        '
        'crvMain
        '
        Me.crvMain.ActiveViewIndex = -1
        Me.crvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvMain.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.crvMain.Location = New System.Drawing.Point(8, 111)
        Me.crvMain.Name = "crvMain"
        Me.crvMain.SelectionFormula = ""
        Me.crvMain.ShowCloseButton = False
        Me.crvMain.ShowGroupTreeButton = False
        Me.crvMain.ShowRefreshButton = False
        Me.crvMain.Size = New System.Drawing.Size(803, 384)
        Me.crvMain.TabIndex = 493
        Me.crvMain.ViewTimeSelectionFormula = ""
        '
        'chkExibirJustificativas
        '
        Me.chkExibirJustificativas.AutoSize = True
        Me.chkExibirJustificativas.Location = New System.Drawing.Point(666, 40)
        Me.chkExibirJustificativas.Name = "chkExibirJustificativas"
        Me.chkExibirJustificativas.Size = New System.Drawing.Size(114, 17)
        Me.chkExibirJustificativas.TabIndex = 497
        Me.chkExibirJustificativas.Text = "Exibir Justificativas"
        Me.chkExibirJustificativas.UseVisualStyleBackColor = True
        '
        'frmREL_Ajuste_RDE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(820, 506)
        Me.Controls.Add(Me.chkExibirJustificativas)
        Me.Controls.Add(Me.cmdExportaRelatorio)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.crvMain)
        Me.Controls.Add(Me.grpTipoMovimentacao)
        Me.Controls.Add(Me.grpFornecedor)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmREL_Ajuste_RDE"
        Me.Text = "Relatório de Ajuste de RDE"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.txtDataFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataInicial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.grpFornecedor.ResumeLayout(False)
        Me.grpTipoMovimentacao.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optTipoRelatorio_AcertoEstoqueFisico As System.Windows.Forms.RadioButton
    Friend WithEvents optTipoRelatorio_AcertoRD As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDataFinal As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtDataInicial As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents optStatus_Aprovado As System.Windows.Forms.RadioButton
    Friend WithEvents optStatus_Todos As System.Windows.Forms.RadioButton
    Friend WithEvents optStatus_Reprovado As System.Windows.Forms.RadioButton
    Friend WithEvents optStatus_AguardandoAprovacao As System.Windows.Forms.RadioButton
    Friend WithEvents grpFornecedor As System.Windows.Forms.GroupBox
    Friend WithEvents grpTipoMovimentacao As System.Windows.Forms.GroupBox
    Friend WithEvents Pesq_Fornecedor As Logus.Pesq_CodigoNome
    Friend WithEvents Pesq_TipoMovimentacao As Logus.Pesq_CodigoNome
    Friend WithEvents cmdExportaRelatorio As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdImprimir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents crvMain As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents chkExibirJustificativas As System.Windows.Forms.CheckBox
End Class
