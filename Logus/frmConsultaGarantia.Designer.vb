<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaGarantia
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
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaGarantia))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtDataFinal = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtDataInicial = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboTipoGarantia = New System.Windows.Forms.ComboBox
        Me.cmdExcluir = New Infragistics.Win.Misc.UltraButton
        Me.cmdUsuario = New Infragistics.Win.Misc.UltraButton
        Me.cmdNovo = New Infragistics.Win.Misc.UltraButton
        Me.cmdExcell = New Infragistics.Win.Misc.UltraButton
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.grdGeral = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.cmdPesquisar = New Infragistics.Win.Misc.UltraButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.Pesq_CodigoNome = New Logus.Pesq_CodigoNome
        Me.cmdCancelar = New Infragistics.Win.Misc.UltraButton
        Me.cmdAlterar = New Infragistics.Win.Misc.UltraButton
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtDataFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDataFinal)
        Me.GroupBox1.Controls.Add(Me.txtDataInicial)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(235, 49)
        Me.GroupBox1.TabIndex = 248
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Per�odo"
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
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(244, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(202, 16)
        Me.Label2.TabIndex = 247
        Me.Label2.Text = "Tipo Garantia"
        '
        'cboTipoGarantia
        '
        Me.cboTipoGarantia.Location = New System.Drawing.Point(247, 74)
        Me.cboTipoGarantia.Name = "cboTipoGarantia"
        Me.cboTipoGarantia.Size = New System.Drawing.Size(345, 21)
        Me.cboTipoGarantia.TabIndex = 246
        '
        'cmdExcluir
        '
        Me.cmdExcluir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExcluir.Location = New System.Drawing.Point(164, 392)
        Me.cmdExcluir.Name = "cmdExcluir"
        Me.cmdExcluir.Size = New System.Drawing.Size(45, 45)
        Me.cmdExcluir.TabIndex = 240
        Me.cmdExcluir.Text = "E"
        '
        'cmdUsuario
        '
        Me.cmdUsuario.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdUsuario.Location = New System.Drawing.Point(622, 392)
        Me.cmdUsuario.Name = "cmdUsuario"
        Me.cmdUsuario.Size = New System.Drawing.Size(45, 45)
        Me.cmdUsuario.TabIndex = 239
        Me.cmdUsuario.Text = "U"
        '
        'cmdNovo
        '
        Me.cmdNovo.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdNovo.Location = New System.Drawing.Point(58, 392)
        Me.cmdNovo.Name = "cmdNovo"
        Me.cmdNovo.Size = New System.Drawing.Size(45, 45)
        Me.cmdNovo.TabIndex = 238
        Me.cmdNovo.Text = "N"
        '
        'cmdExcell
        '
        Me.cmdExcell.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExcell.Location = New System.Drawing.Point(5, 392)
        Me.cmdExcell.Name = "cmdExcell"
        Me.cmdExcell.Size = New System.Drawing.Size(45, 45)
        Me.cmdExcell.TabIndex = 237
        Me.cmdExcell.Text = "Excell"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(670, 392)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 236
        Me.cmdFechar.Text = "F"
        '
        'grdGeral
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdGeral.DisplayLayout.Appearance = Appearance1
        Me.grdGeral.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdGeral.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdGeral.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.grdGeral.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdGeral.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.grdGeral.DisplayLayout.MaxColScrollRegions = 1
        Me.grdGeral.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdGeral.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdGeral.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.grdGeral.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdGeral.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdGeral.DisplayLayout.Override.CellAppearance = Appearance8
        Me.grdGeral.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdGeral.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.grdGeral.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.grdGeral.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdGeral.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.grdGeral.DisplayLayout.Override.RowAppearance = Appearance11
        Me.grdGeral.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdGeral.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.grdGeral.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdGeral.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdGeral.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdGeral.Location = New System.Drawing.Point(2, 101)
        Me.grdGeral.Name = "grdGeral"
        Me.grdGeral.Size = New System.Drawing.Size(713, 285)
        Me.grdGeral.TabIndex = 235
        Me.grdGeral.Text = "UltraGrid1"
        '
        'cmdPesquisar
        '
        Me.cmdPesquisar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdPesquisar.Location = New System.Drawing.Point(670, 8)
        Me.cmdPesquisar.Name = "cmdPesquisar"
        Me.cmdPesquisar.Size = New System.Drawing.Size(45, 45)
        Me.cmdPesquisar.TabIndex = 234
        Me.cmdPesquisar.Text = "P"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(265, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(188, 16)
        Me.Label1.TabIndex = 249
        Me.Label1.Text = "Fornecedor"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(0, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(202, 16)
        Me.Label3.TabIndex = 252
        Me.Label3.Text = "Status"
        '
        'cboStatus
        '
        Me.cboStatus.Location = New System.Drawing.Point(3, 24)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(238, 21)
        Me.cboStatus.TabIndex = 251
        '
        'Pesq_CodigoNome
        '
        Me.Pesq_CodigoNome.BancoDados_Campo_Codigo = "CD_FORNECEDOR"
        Me.Pesq_CodigoNome.BancoDados_Campo_Descricao = "NO_RAZAO_SOCIAL"
        Me.Pesq_CodigoNome.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_CodigoNome.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_CodigoNome.BancoDados_Tabela = "FORNECEDOR F"
        Me.Pesq_CodigoNome.Codigo = CType(0, Long)
        Me.Pesq_CodigoNome.Location = New System.Drawing.Point(247, 24)
        Me.Pesq_CodigoNome.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_CodigoNome.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_CodigoNome.Name = "Pesq_CodigoNome"
        Me.Pesq_CodigoNome.Size = New System.Drawing.Size(345, 28)
        Me.Pesq_CodigoNome.TabIndex = 250
        Me.Pesq_CodigoNome.TelaFiltro = False
        Me.Pesq_CodigoNome.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'cmdCancelar
        '
        Me.cmdCancelar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdCancelar.Location = New System.Drawing.Point(217, 392)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(45, 45)
        Me.cmdCancelar.TabIndex = 253
        Me.cmdCancelar.Text = "C"
        '
        'cmdAlterar
        '
        Me.cmdAlterar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdAlterar.Location = New System.Drawing.Point(111, 392)
        Me.cmdAlterar.Name = "cmdAlterar"
        Me.cmdAlterar.Size = New System.Drawing.Size(45, 45)
        Me.cmdAlterar.TabIndex = 254
        Me.cmdAlterar.Text = "A"
        '
        'frmConsultaGarantia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(722, 441)
        Me.Controls.Add(Me.cmdAlterar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboStatus)
        Me.Controls.Add(Me.Pesq_CodigoNome)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboTipoGarantia)
        Me.Controls.Add(Me.cmdExcluir)
        Me.Controls.Add(Me.cmdUsuario)
        Me.Controls.Add(Me.cmdNovo)
        Me.Controls.Add(Me.cmdExcell)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.grdGeral)
        Me.Controls.Add(Me.cmdPesquisar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsultaGarantia"
        Me.Text = "Consulta Garantia"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtDataFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDataFinal As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtDataInicial As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboTipoGarantia As System.Windows.Forms.ComboBox
    Friend WithEvents cmdExcluir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdUsuario As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdNovo As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdExcell As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents grdGeral As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cmdPesquisar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Pesq_CodigoNome As Logus.Pesq_CodigoNome
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cmdCancelar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdAlterar As Infragistics.Win.Misc.UltraButton
End Class
