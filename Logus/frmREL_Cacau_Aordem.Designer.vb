<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmREL_Cacau_Aordem
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
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmREL_Cacau_Aordem))
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.chkSemMovimentacao = New System.Windows.Forms.CheckBox
        Me.chkValoresAberto = New System.Windows.Forms.CheckBox
        Me.cboPrazo = New System.Windows.Forms.ComboBox
        Me.crvMain = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdImprimir = New Infragistics.Win.Misc.UltraButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtDataVencimento = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.optTipo = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.optDadosRel = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.SelecaoFilial = New Logus.Selecao
        Me.cmdExportaRelatorio = New Infragistics.Win.Misc.UltraButton
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtDataVencimento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optDadosRel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.chkSemMovimentacao)
        Me.UltraGroupBox1.Controls.Add(Me.chkValoresAberto)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(342, 9)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(270, 35)
        Me.UltraGroupBox1.TabIndex = 366
        '
        'chkSemMovimentacao
        '
        Me.chkSemMovimentacao.AutoSize = True
        Me.chkSemMovimentacao.Location = New System.Drawing.Point(6, 8)
        Me.chkSemMovimentacao.Name = "chkSemMovimentacao"
        Me.chkSemMovimentacao.Size = New System.Drawing.Size(120, 17)
        Me.chkSemMovimentacao.TabIndex = 350
        Me.chkSemMovimentacao.Text = "Sem Movimentação"
        Me.chkSemMovimentacao.UseVisualStyleBackColor = True
        '
        'chkValoresAberto
        '
        Me.chkValoresAberto.AutoSize = True
        Me.chkValoresAberto.Location = New System.Drawing.Point(132, 8)
        Me.chkValoresAberto.Name = "chkValoresAberto"
        Me.chkValoresAberto.Size = New System.Drawing.Size(136, 17)
        Me.chkValoresAberto.TabIndex = 351
        Me.chkValoresAberto.Text = "Com Valores em Aberto"
        Me.chkValoresAberto.UseVisualStyleBackColor = True
        '
        'cboPrazo
        '
        Me.cboPrazo.Location = New System.Drawing.Point(3, 17)
        Me.cboPrazo.Name = "cboPrazo"
        Me.cboPrazo.Size = New System.Drawing.Size(228, 21)
        Me.cboPrazo.TabIndex = 363
        '
        'crvMain
        '
        Me.crvMain.ActiveViewIndex = -1
        Me.crvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvMain.Location = New System.Drawing.Point(3, 111)
        Me.crvMain.Name = "crvMain"
        Me.crvMain.SelectionFormula = ""
        Me.crvMain.ShowCloseButton = False
        Me.crvMain.ShowGroupTreeButton = False
        Me.crvMain.ShowRefreshButton = False
        Me.crvMain.Size = New System.Drawing.Size(631, 379)
        Me.crvMain.TabIndex = 361
        Me.crvMain.ViewTimeSelectionFormula = ""
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(640, 49)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 360
        Me.cmdFechar.Text = "F"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdImprimir.Location = New System.Drawing.Point(539, 50)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(45, 45)
        Me.cmdImprimir.TabIndex = 359
        Me.cmdImprimir.Text = "I"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDataVencimento)
        Me.GroupBox1.Controls.Add(Me.cboPrazo)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(334, 49)
        Me.GroupBox1.TabIndex = 358
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Prazo Vencimento"
        '
        'txtDataVencimento
        '
        Me.txtDataVencimento.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtDataVencimento.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataVencimento.Location = New System.Drawing.Point(237, 17)
        Me.txtDataVencimento.Name = "txtDataVencimento"
        Me.txtDataVencimento.Size = New System.Drawing.Size(91, 23)
        Me.txtDataVencimento.TabIndex = 225
        Me.txtDataVencimento.Value = Nothing
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 356
        Me.Label1.Text = "Filial"
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
        ValueListItem1.DataValue = "S"
        ValueListItem1.DisplayText = "Sintético"
        ValueListItem2.DataValue = "A"
        ValueListItem2.DisplayText = "Analítico"
        Me.optTipo.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2})
        Me.optTipo.Location = New System.Drawing.Point(451, 61)
        Me.optTipo.Name = "optTipo"
        Me.optTipo.Size = New System.Drawing.Size(82, 36)
        Me.optTipo.TabIndex = 367
        Me.optTipo.Text = "Sintético"
        '
        'optDadosRel
        '
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        Me.optDadosRel.Appearance = Appearance1
        Me.optDadosRel.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.optDadosRel.CheckedIndex = 0
        Appearance2.TextHAlignAsString = "Center"
        Appearance2.TextVAlignAsString = "Middle"
        Me.optDadosRel.ItemAppearance = Appearance2
        Me.optDadosRel.ItemOrigin = New System.Drawing.Point(2, 2)
        ValueListItem3.DataValue = "EC"
        ValueListItem3.DisplayText = "Em Contrato"
        ValueListItem4.DataValue = "SC"
        ValueListItem4.DisplayText = "Sem Contrato"
        Me.optDadosRel.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem3, ValueListItem4})
        Me.optDadosRel.Location = New System.Drawing.Point(338, 62)
        Me.optDadosRel.Name = "optDadosRel"
        Me.optDadosRel.Size = New System.Drawing.Size(107, 34)
        Me.optDadosRel.TabIndex = 368
        Me.optDadosRel.Text = "Em Contrato"
        '
        'SelecaoFilial
        '
        Me.SelecaoFilial.BackColor = System.Drawing.Color.White
        Me.SelecaoFilial.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoFilial.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoFilial.BancoDados_Campo_OrdenarConsulta = True
        Me.SelecaoFilial.BancoDados_Tabela = Nothing
        Me.SelecaoFilial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoFilial.Location = New System.Drawing.Point(5, 75)
        Me.SelecaoFilial.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoFilial.MultiplaSelecao = False
        Me.SelecaoFilial.Name = "SelecaoFilial"
        Me.SelecaoFilial.Size = New System.Drawing.Size(309, 20)
        Me.SelecaoFilial.TabIndex = 357
        '
        'cmdExportaRelatorio
        '
        Me.cmdExportaRelatorio.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExportaRelatorio.Location = New System.Drawing.Point(589, 50)
        Me.cmdExportaRelatorio.Name = "cmdExportaRelatorio"
        Me.cmdExportaRelatorio.Size = New System.Drawing.Size(45, 45)
        Me.cmdExportaRelatorio.TabIndex = 492
        Me.cmdExportaRelatorio.Text = "ER"
        '
        'frmREL_Cacau_Aordem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 523)
        Me.Controls.Add(Me.cmdExportaRelatorio)
        Me.Controls.Add(Me.optDadosRel)
        Me.Controls.Add(Me.optTipo)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.crvMain)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.SelecaoFilial)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmREL_Cacau_Aordem"
        Me.Text = "Relatório Cacau NPE"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtDataVencimento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optDadosRel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents chkSemMovimentacao As System.Windows.Forms.CheckBox
    Friend WithEvents chkValoresAberto As System.Windows.Forms.CheckBox
    Friend WithEvents cboPrazo As System.Windows.Forms.ComboBox
    Friend WithEvents crvMain As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdImprimir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDataVencimento As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents SelecaoFilial As Logus.Selecao
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents optTipo As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents optDadosRel As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents cmdExportaRelatorio As Infragistics.Win.Misc.UltraButton
End Class
