<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmREL_NegociacoesAbertoComFixacoes
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
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmREL_NegociacoesAbertoComFixacoes))
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.optTipo = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.txtDataBolsa = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtDataLimite = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.crvMain = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdImprimir = New Infragistics.Win.Misc.UltraButton
        Me.chkDataBolsa = New System.Windows.Forms.CheckBox
        Me.chkDataLimite = New System.Windows.Forms.CheckBox
        Me.chkFixacoes = New System.Windows.Forms.CheckBox
        Me.cmdExportaRelatorio = New Infragistics.Win.Misc.UltraButton
        Me.chkSaldo = New System.Windows.Forms.CheckBox
        Me.SelecaoTipoNegociacao = New Logus.Selecao
        Me.SelecaoFilial = New Logus.Selecao
        Me.chkUsarBolsaCalcSaldo = New System.Windows.Forms.CheckBox
        CType(Me.optTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataBolsa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataLimite, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 256
        Me.Label3.Text = "Filial"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(262, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 258
        Me.Label1.Text = "Tipo Negociação"
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
        Me.optTipo.Location = New System.Drawing.Point(12, 27)
        Me.optTipo.Name = "optTipo"
        Me.optTipo.Size = New System.Drawing.Size(247, 20)
        Me.optTipo.TabIndex = 296
        Me.optTipo.Text = "Sintético"
        '
        'txtDataBolsa
        '
        Me.txtDataBolsa.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtDataBolsa.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataBolsa.Location = New System.Drawing.Point(287, 24)
        Me.txtDataBolsa.Name = "txtDataBolsa"
        Me.txtDataBolsa.Size = New System.Drawing.Size(86, 23)
        Me.txtDataBolsa.TabIndex = 297
        Me.txtDataBolsa.Value = Nothing
        '
        'txtDataLimite
        '
        Me.txtDataLimite.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtDataLimite.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataLimite.Location = New System.Drawing.Point(402, 24)
        Me.txtDataLimite.Name = "txtDataLimite"
        Me.txtDataLimite.Size = New System.Drawing.Size(85, 23)
        Me.txtDataLimite.TabIndex = 298
        Me.txtDataLimite.Value = Nothing
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(262, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 299
        Me.Label2.Text = "Data da Bolsa"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(376, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 300
        Me.Label4.Text = "Até a Data"
        '
        'crvMain
        '
        Me.crvMain.ActiveViewIndex = -1
        Me.crvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvMain.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.crvMain.Location = New System.Drawing.Point(12, 92)
        Me.crvMain.Name = "crvMain"
        Me.crvMain.ShowCloseButton = False
        Me.crvMain.ShowGroupTreeButton = False
        Me.crvMain.ShowRefreshButton = False
        Me.crvMain.Size = New System.Drawing.Size(647, 369)
        Me.crvMain.TabIndex = 322
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(700, 41)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 331
        Me.cmdFechar.Text = "F"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdImprimir.Location = New System.Drawing.Point(598, 41)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(45, 45)
        Me.cmdImprimir.TabIndex = 330
        Me.cmdImprimir.Text = "I"
        '
        'chkDataBolsa
        '
        Me.chkDataBolsa.AutoSize = True
        Me.chkDataBolsa.Location = New System.Drawing.Point(266, 29)
        Me.chkDataBolsa.Name = "chkDataBolsa"
        Me.chkDataBolsa.Size = New System.Drawing.Size(15, 14)
        Me.chkDataBolsa.TabIndex = 332
        Me.chkDataBolsa.UseVisualStyleBackColor = True
        '
        'chkDataLimite
        '
        Me.chkDataLimite.AutoSize = True
        Me.chkDataLimite.Location = New System.Drawing.Point(381, 29)
        Me.chkDataLimite.Name = "chkDataLimite"
        Me.chkDataLimite.Size = New System.Drawing.Size(15, 14)
        Me.chkDataLimite.TabIndex = 333
        Me.chkDataLimite.UseVisualStyleBackColor = True
        '
        'chkFixacoes
        '
        Me.chkFixacoes.AutoSize = True
        Me.chkFixacoes.Checked = True
        Me.chkFixacoes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFixacoes.Location = New System.Drawing.Point(500, 20)
        Me.chkFixacoes.Name = "chkFixacoes"
        Me.chkFixacoes.Size = New System.Drawing.Size(96, 17)
        Me.chkFixacoes.TabIndex = 334
        Me.chkFixacoes.Text = "Exibir Fixações"
        Me.chkFixacoes.UseVisualStyleBackColor = True
        '
        'cmdExportaRelatorio
        '
        Me.cmdExportaRelatorio.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExportaRelatorio.Location = New System.Drawing.Point(649, 41)
        Me.cmdExportaRelatorio.Name = "cmdExportaRelatorio"
        Me.cmdExportaRelatorio.Size = New System.Drawing.Size(45, 45)
        Me.cmdExportaRelatorio.TabIndex = 493
        Me.cmdExportaRelatorio.Text = "ER"
        '
        'chkSaldo
        '
        Me.chkSaldo.Location = New System.Drawing.Point(500, 51)
        Me.chkSaldo.Name = "chkSaldo"
        Me.chkSaldo.Size = New System.Drawing.Size(96, 31)
        Me.chkSaldo.TabIndex = 494
        Me.chkSaldo.Text = "Somente com Saldo"
        Me.chkSaldo.UseVisualStyleBackColor = True
        '
        'SelecaoTipoNegociacao
        '
        Me.SelecaoTipoNegociacao.BackColor = System.Drawing.Color.White
        Me.SelecaoTipoNegociacao.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoTipoNegociacao.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoTipoNegociacao.BancoDados_Campo_OrdenarConsulta = True
        Me.SelecaoTipoNegociacao.BancoDados_Tabela = Nothing
        Me.SelecaoTipoNegociacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoTipoNegociacao.Location = New System.Drawing.Point(265, 66)
        Me.SelecaoTipoNegociacao.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoTipoNegociacao.MultiplaSelecao = False
        Me.SelecaoTipoNegociacao.MultiplaSelecao_Codigo_Tipo = Logus.Selecao.enMultiplaSelecao_Codigo_Tipo.Numero
        Me.SelecaoTipoNegociacao.Name = "SelecaoTipoNegociacao"
        Me.SelecaoTipoNegociacao.Size = New System.Drawing.Size(222, 20)
        Me.SelecaoTipoNegociacao.TabIndex = 259
        '
        'SelecaoFilial
        '
        Me.SelecaoFilial.BackColor = System.Drawing.Color.White
        Me.SelecaoFilial.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoFilial.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoFilial.BancoDados_Campo_OrdenarConsulta = True
        Me.SelecaoFilial.BancoDados_Tabela = Nothing
        Me.SelecaoFilial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoFilial.Location = New System.Drawing.Point(12, 66)
        Me.SelecaoFilial.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoFilial.MultiplaSelecao = False
        Me.SelecaoFilial.MultiplaSelecao_Codigo_Tipo = Logus.Selecao.enMultiplaSelecao_Codigo_Tipo.Numero
        Me.SelecaoFilial.Name = "SelecaoFilial"
        Me.SelecaoFilial.Size = New System.Drawing.Size(247, 20)
        Me.SelecaoFilial.TabIndex = 257
        '
        'chkUsarBolsaCalcSaldo
        '
        Me.chkUsarBolsaCalcSaldo.AutoSize = True
        Me.chkUsarBolsaCalcSaldo.Checked = True
        Me.chkUsarBolsaCalcSaldo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUsarBolsaCalcSaldo.Location = New System.Drawing.Point(604, 20)
        Me.chkUsarBolsaCalcSaldo.Name = "chkUsarBolsaCalcSaldo"
        Me.chkUsarBolsaCalcSaldo.Size = New System.Drawing.Size(149, 17)
        Me.chkUsarBolsaCalcSaldo.TabIndex = 495
        Me.chkUsarBolsaCalcSaldo.Text = "Usar Bolsa no Calc. Saldo"
        Me.chkUsarBolsaCalcSaldo.UseVisualStyleBackColor = True
        '
        'frmREL_NegociacoesAbertoComFixacoes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(760, 490)
        Me.Controls.Add(Me.chkUsarBolsaCalcSaldo)
        Me.Controls.Add(Me.chkSaldo)
        Me.Controls.Add(Me.cmdExportaRelatorio)
        Me.Controls.Add(Me.chkFixacoes)
        Me.Controls.Add(Me.chkDataLimite)
        Me.Controls.Add(Me.chkDataBolsa)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.crvMain)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDataLimite)
        Me.Controls.Add(Me.txtDataBolsa)
        Me.Controls.Add(Me.optTipo)
        Me.Controls.Add(Me.SelecaoTipoNegociacao)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SelecaoFilial)
        Me.Controls.Add(Me.Label3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmREL_NegociacoesAbertoComFixacoes"
        Me.Text = "Relatório Negociações em Aberto com suas Fixações"
        CType(Me.optTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataBolsa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataLimite, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SelecaoFilial As Logus.Selecao
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SelecaoTipoNegociacao As Logus.Selecao
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents optTipo As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents txtDataBolsa As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtDataLimite As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents crvMain As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdImprimir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents chkDataBolsa As System.Windows.Forms.CheckBox
    Friend WithEvents chkDataLimite As System.Windows.Forms.CheckBox
    Friend WithEvents chkFixacoes As System.Windows.Forms.CheckBox
    Friend WithEvents cmdExportaRelatorio As Infragistics.Win.Misc.UltraButton
    Friend WithEvents chkSaldo As System.Windows.Forms.CheckBox
    Friend WithEvents chkUsarBolsaCalcSaldo As System.Windows.Forms.CheckBox
End Class
