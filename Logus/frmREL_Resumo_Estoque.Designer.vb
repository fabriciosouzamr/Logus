<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmREL_Resumo_Estoque
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmREL_Resumo_Estoque))
        Me.lblSelecao01 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.crvMain = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdImprimir = New Infragistics.Win.Misc.UltraButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.chkAgrupaArmazem = New System.Windows.Forms.CheckBox
        Me.chkAgrupaPilha = New System.Windows.Forms.CheckBox
        Me.chkAgrupaProcedencia = New System.Windows.Forms.CheckBox
        Me.chkAgupaOrigem = New System.Windows.Forms.CheckBox
        Me.SelecaoProcedencia = New Logus.Selecao
        Me.SelecaoFilial = New Logus.Selecao
        Me.cboPilha = New System.Windows.Forms.ComboBox
        Me.lblPilha = New System.Windows.Forms.Label
        Me.cboArmazem = New System.Windows.Forms.ComboBox
        Me.grpPeriodo = New System.Windows.Forms.GroupBox
        Me.txtDataFinal = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtDataInicial = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.grpGrupo = New Infragistics.Win.Misc.UltraGroupBox
        Me.cboTipoCacau = New System.Windows.Forms.ComboBox
        Me.lblTipoCacau = New System.Windows.Forms.Label
        Me.optUnidade = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.grpOpcoes = New Infragistics.Win.Misc.UltraGroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.optProcedencia = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.cmdExportaRelatorio = New Infragistics.Win.Misc.UltraButton
        Me.grpPeriodo.SuspendLayout()
        CType(Me.txtDataFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpGrupo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpGrupo.SuspendLayout()
        CType(Me.optUnidade, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpOpcoes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpOpcoes.SuspendLayout()
        CType(Me.optProcedencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSelecao01
        '
        Me.lblSelecao01.AutoSize = True
        Me.lblSelecao01.Location = New System.Drawing.Point(3, 62)
        Me.lblSelecao01.Name = "lblSelecao01"
        Me.lblSelecao01.Size = New System.Drawing.Size(50, 13)
        Me.lblSelecao01.TabIndex = 260
        Me.lblSelecao01.Text = "Armazem"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 258
        Me.Label1.Text = "Filial"
        '
        'crvMain
        '
        Me.crvMain.ActiveViewIndex = -1
        Me.crvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvMain.Location = New System.Drawing.Point(3, 105)
        Me.crvMain.Name = "crvMain"
        Me.crvMain.SelectionFormula = ""
        Me.crvMain.ShowCloseButton = False
        Me.crvMain.ShowGroupTreeButton = False
        Me.crvMain.ShowRefreshButton = False
        Me.crvMain.Size = New System.Drawing.Size(630, 379)
        Me.crvMain.TabIndex = 264
        Me.crvMain.ViewTimeSelectionFormula = ""
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(761, 54)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 263
        Me.cmdFechar.Text = "F"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdImprimir.Location = New System.Drawing.Point(659, 54)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(45, 45)
        Me.cmdImprimir.TabIndex = 262
        Me.cmdImprimir.Text = "I"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(259, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 265
        Me.Label2.Text = "Procedência"
        '
        'chkAgrupaArmazem
        '
        Me.chkAgrupaArmazem.AutoSize = True
        Me.chkAgrupaArmazem.Checked = True
        Me.chkAgrupaArmazem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAgrupaArmazem.Location = New System.Drawing.Point(6, 25)
        Me.chkAgrupaArmazem.Name = "chkAgrupaArmazem"
        Me.chkAgrupaArmazem.Size = New System.Drawing.Size(124, 17)
        Me.chkAgrupaArmazem.TabIndex = 268
        Me.chkAgrupaArmazem.Text = "Agrupa por Armazem"
        Me.chkAgrupaArmazem.UseVisualStyleBackColor = True
        '
        'chkAgrupaPilha
        '
        Me.chkAgrupaPilha.AutoSize = True
        Me.chkAgrupaPilha.Checked = True
        Me.chkAgrupaPilha.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAgrupaPilha.Location = New System.Drawing.Point(6, 46)
        Me.chkAgrupaPilha.Name = "chkAgrupaPilha"
        Me.chkAgrupaPilha.Size = New System.Drawing.Size(104, 17)
        Me.chkAgrupaPilha.TabIndex = 269
        Me.chkAgrupaPilha.Text = "Agrupa por Pilha"
        Me.chkAgrupaPilha.UseVisualStyleBackColor = True
        '
        'chkAgrupaProcedencia
        '
        Me.chkAgrupaProcedencia.AutoSize = True
        Me.chkAgrupaProcedencia.Checked = True
        Me.chkAgrupaProcedencia.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAgrupaProcedencia.Location = New System.Drawing.Point(6, 65)
        Me.chkAgrupaProcedencia.Name = "chkAgrupaProcedencia"
        Me.chkAgrupaProcedencia.Size = New System.Drawing.Size(141, 17)
        Me.chkAgrupaProcedencia.TabIndex = 270
        Me.chkAgrupaProcedencia.Text = "Agrupa por Procedencia"
        Me.chkAgrupaProcedencia.UseVisualStyleBackColor = True
        '
        'chkAgupaOrigem
        '
        Me.chkAgupaOrigem.AutoSize = True
        Me.chkAgupaOrigem.Checked = True
        Me.chkAgupaOrigem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAgupaOrigem.Location = New System.Drawing.Point(6, 6)
        Me.chkAgupaOrigem.Name = "chkAgupaOrigem"
        Me.chkAgupaOrigem.Size = New System.Drawing.Size(114, 17)
        Me.chkAgupaOrigem.TabIndex = 267
        Me.chkAgupaOrigem.Text = "Agrupa por Origem"
        Me.chkAgupaOrigem.UseVisualStyleBackColor = True
        '
        'SelecaoProcedencia
        '
        Me.SelecaoProcedencia.BackColor = System.Drawing.Color.White
        Me.SelecaoProcedencia.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoProcedencia.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoProcedencia.BancoDados_Tabela = Nothing
        Me.SelecaoProcedencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoProcedencia.Location = New System.Drawing.Point(262, 24)
        Me.SelecaoProcedencia.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoProcedencia.MultiplaSelecao = False
        Me.SelecaoProcedencia.Name = "SelecaoProcedencia"
        Me.SelecaoProcedencia.Size = New System.Drawing.Size(235, 20)
        Me.SelecaoProcedencia.TabIndex = 266
        '
        'SelecaoFilial
        '
        Me.SelecaoFilial.BackColor = System.Drawing.Color.White
        Me.SelecaoFilial.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoFilial.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoFilial.BancoDados_Tabela = Nothing
        Me.SelecaoFilial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoFilial.Location = New System.Drawing.Point(3, 24)
        Me.SelecaoFilial.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoFilial.MultiplaSelecao = False
        Me.SelecaoFilial.Name = "SelecaoFilial"
        Me.SelecaoFilial.Size = New System.Drawing.Size(250, 20)
        Me.SelecaoFilial.TabIndex = 259
        '
        'cboPilha
        '
        Me.cboPilha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPilha.Location = New System.Drawing.Point(172, 78)
        Me.cboPilha.Name = "cboPilha"
        Me.cboPilha.Size = New System.Drawing.Size(81, 21)
        Me.cboPilha.TabIndex = 271
        '
        'lblPilha
        '
        Me.lblPilha.AutoSize = True
        Me.lblPilha.BackColor = System.Drawing.Color.Transparent
        Me.lblPilha.Location = New System.Drawing.Point(169, 62)
        Me.lblPilha.Name = "lblPilha"
        Me.lblPilha.Size = New System.Drawing.Size(30, 13)
        Me.lblPilha.TabIndex = 272
        Me.lblPilha.Text = "Pilha"
        '
        'cboArmazem
        '
        Me.cboArmazem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboArmazem.Location = New System.Drawing.Point(3, 78)
        Me.cboArmazem.Name = "cboArmazem"
        Me.cboArmazem.Size = New System.Drawing.Size(163, 21)
        Me.cboArmazem.TabIndex = 273
        '
        'grpPeriodo
        '
        Me.grpPeriodo.Controls.Add(Me.txtDataFinal)
        Me.grpPeriodo.Controls.Add(Me.txtDataInicial)
        Me.grpPeriodo.Location = New System.Drawing.Point(262, 50)
        Me.grpPeriodo.Name = "grpPeriodo"
        Me.grpPeriodo.Size = New System.Drawing.Size(235, 49)
        Me.grpPeriodo.TabIndex = 274
        Me.grpPeriodo.TabStop = False
        Me.grpPeriodo.Text = "Período"
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
        'grpGrupo
        '
        Me.grpGrupo.Controls.Add(Me.chkAgrupaArmazem)
        Me.grpGrupo.Controls.Add(Me.chkAgupaOrigem)
        Me.grpGrupo.Controls.Add(Me.chkAgrupaPilha)
        Me.grpGrupo.Controls.Add(Me.chkAgrupaProcedencia)
        Me.grpGrupo.Location = New System.Drawing.Point(503, 13)
        Me.grpGrupo.Name = "grpGrupo"
        Me.grpGrupo.Size = New System.Drawing.Size(149, 86)
        Me.grpGrupo.TabIndex = 275
        '
        'cboTipoCacau
        '
        Me.cboTipoCacau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoCacau.Location = New System.Drawing.Point(659, 23)
        Me.cboTipoCacau.Name = "cboTipoCacau"
        Me.cboTipoCacau.Size = New System.Drawing.Size(96, 21)
        Me.cboTipoCacau.TabIndex = 276
        '
        'lblTipoCacau
        '
        Me.lblTipoCacau.AutoSize = True
        Me.lblTipoCacau.BackColor = System.Drawing.Color.Transparent
        Me.lblTipoCacau.Location = New System.Drawing.Point(656, 7)
        Me.lblTipoCacau.Name = "lblTipoCacau"
        Me.lblTipoCacau.Size = New System.Drawing.Size(62, 13)
        Me.lblTipoCacau.TabIndex = 277
        Me.lblTipoCacau.Text = "Tipo Cacau"
        '
        'optUnidade
        '
        Appearance3.TextHAlignAsString = "Center"
        Appearance3.TextVAlignAsString = "Middle"
        Me.optUnidade.Appearance = Appearance3
        Me.optUnidade.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.optUnidade.CheckedIndex = 0
        Appearance4.TextHAlignAsString = "Center"
        Appearance4.TextVAlignAsString = "Middle"
        Me.optUnidade.ItemAppearance = Appearance4
        Me.optUnidade.ItemOrigin = New System.Drawing.Point(2, 2)
        ValueListItem1.DataValue = "S"
        ValueListItem1.DisplayText = "Sacos"
        ValueListItem2.DataValue = "Q"
        ValueListItem2.DisplayText = "Quilos"
        Me.optUnidade.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2})
        Me.optUnidade.Location = New System.Drawing.Point(6, 19)
        Me.optUnidade.Name = "optUnidade"
        Me.optUnidade.Size = New System.Drawing.Size(139, 20)
        Me.optUnidade.TabIndex = 278
        Me.optUnidade.Text = "Sacos"
        '
        'grpOpcoes
        '
        Me.grpOpcoes.Controls.Add(Me.Label4)
        Me.grpOpcoes.Controls.Add(Me.Label3)
        Me.grpOpcoes.Controls.Add(Me.optProcedencia)
        Me.grpOpcoes.Controls.Add(Me.optUnidade)
        Me.grpOpcoes.Location = New System.Drawing.Point(509, 153)
        Me.grpOpcoes.Name = "grpOpcoes"
        Me.grpOpcoes.Size = New System.Drawing.Size(149, 86)
        Me.grpOpcoes.TabIndex = 279
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(6, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 281
        Me.Label4.Text = "Unidade Medida"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(6, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 280
        Me.Label3.Text = "Tipo Procedência"
        '
        'optProcedencia
        '
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        Me.optProcedencia.Appearance = Appearance1
        Me.optProcedencia.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.optProcedencia.CheckedIndex = 0
        Appearance2.TextHAlignAsString = "Center"
        Appearance2.TextVAlignAsString = "Middle"
        Me.optProcedencia.ItemAppearance = Appearance2
        Me.optProcedencia.ItemOrigin = New System.Drawing.Point(2, 2)
        ValueListItem3.DataValue = "P"
        ValueListItem3.DisplayText = "Pilha"
        ValueListItem4.DataValue = "L"
        ValueListItem4.DisplayText = "Lote"
        Me.optProcedencia.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem3, ValueListItem4})
        Me.optProcedencia.Location = New System.Drawing.Point(6, 60)
        Me.optProcedencia.Name = "optProcedencia"
        Me.optProcedencia.Size = New System.Drawing.Size(139, 20)
        Me.optProcedencia.TabIndex = 279
        Me.optProcedencia.Text = "Pilha"
        '
        'cmdExportaRelatorio
        '
        Me.cmdExportaRelatorio.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExportaRelatorio.Location = New System.Drawing.Point(710, 54)
        Me.cmdExportaRelatorio.Name = "cmdExportaRelatorio"
        Me.cmdExportaRelatorio.Size = New System.Drawing.Size(45, 45)
        Me.cmdExportaRelatorio.TabIndex = 493
        Me.cmdExportaRelatorio.Text = "ER"
        '
        'frmREL_Resumo_Estoque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(812, 484)
        Me.Controls.Add(Me.cmdExportaRelatorio)
        Me.Controls.Add(Me.grpOpcoes)
        Me.Controls.Add(Me.cboTipoCacau)
        Me.Controls.Add(Me.lblTipoCacau)
        Me.Controls.Add(Me.grpGrupo)
        Me.Controls.Add(Me.grpPeriodo)
        Me.Controls.Add(Me.cboArmazem)
        Me.Controls.Add(Me.cboPilha)
        Me.Controls.Add(Me.lblPilha)
        Me.Controls.Add(Me.SelecaoProcedencia)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.crvMain)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.lblSelecao01)
        Me.Controls.Add(Me.SelecaoFilial)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmREL_Resumo_Estoque"
        Me.Text = "Relatório Resumo dos Estoques"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grpPeriodo.ResumeLayout(False)
        Me.grpPeriodo.PerformLayout()
        CType(Me.txtDataFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpGrupo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpGrupo.ResumeLayout(False)
        Me.grpGrupo.PerformLayout()
        CType(Me.optUnidade, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpOpcoes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpOpcoes.ResumeLayout(False)
        Me.grpOpcoes.PerformLayout()
        CType(Me.optProcedencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSelecao01 As System.Windows.Forms.Label
    Friend WithEvents SelecaoFilial As Logus.Selecao
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents crvMain As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdImprimir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents SelecaoProcedencia As Logus.Selecao
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkAgrupaArmazem As System.Windows.Forms.CheckBox
    Friend WithEvents chkAgrupaPilha As System.Windows.Forms.CheckBox
    Friend WithEvents chkAgrupaProcedencia As System.Windows.Forms.CheckBox
    Friend WithEvents chkAgupaOrigem As System.Windows.Forms.CheckBox
    Friend WithEvents cboPilha As System.Windows.Forms.ComboBox
    Friend WithEvents lblPilha As System.Windows.Forms.Label
    Friend WithEvents cboArmazem As System.Windows.Forms.ComboBox
    Friend WithEvents grpPeriodo As System.Windows.Forms.GroupBox
    Friend WithEvents txtDataFinal As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtDataInicial As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents grpGrupo As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents cboTipoCacau As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipoCacau As System.Windows.Forms.Label
    Friend WithEvents optUnidade As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents grpOpcoes As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents optProcedencia As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdExportaRelatorio As Infragistics.Win.Misc.UltraButton
End Class
