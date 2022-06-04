<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaTransferencia
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
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaTransferencia))
        Me.cmdUsuario = New Infragistics.Win.Misc.UltraButton
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.grdGeral = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.cmdPesquisar = New Infragistics.Win.Misc.UltraButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtDataFinal = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtDataInicial = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.lblSelecao01 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.chkEmTransito = New System.Windows.Forms.CheckBox
        Me.cmdExcell = New Infragistics.Win.Misc.UltraButton
        Me.SelecaoFilialDestino = New Logus.Selecao
        Me.SelecaoModalidadeTransferencia = New Logus.Selecao
        Me.SelecaoFilialOrigem = New Logus.Selecao
        Me.cmdInformacoes = New Infragistics.Win.Misc.UltraButton
        Me.cmdRastreabilidade = New Infragistics.Win.Misc.UltraButton
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtDataFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdUsuario
        '
        Me.cmdUsuario.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdUsuario.Location = New System.Drawing.Point(631, 361)
        Me.cmdUsuario.Name = "cmdUsuario"
        Me.cmdUsuario.Size = New System.Drawing.Size(45, 45)
        Me.cmdUsuario.TabIndex = 243
        Me.cmdUsuario.Text = "U"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(682, 361)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 242
        Me.cmdFechar.Text = "F"
        '
        'grdGeral
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdGeral.DisplayLayout.Appearance = Appearance1
        Me.grdGeral.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdGeral.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.GroupByBox.Appearance = Appearance14
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdGeral.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.grdGeral.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance13.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance13.BackColor2 = System.Drawing.SystemColors.Control
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance13.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdGeral.DisplayLayout.GroupByBox.PromptAppearance = Appearance13
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
        Me.grdGeral.Location = New System.Drawing.Point(5, 105)
        Me.grdGeral.Name = "grdGeral"
        Me.grdGeral.Size = New System.Drawing.Size(722, 248)
        Me.grdGeral.TabIndex = 241
        Me.grdGeral.Text = "UltraGrid1"
        '
        'cmdPesquisar
        '
        Me.cmdPesquisar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdPesquisar.Location = New System.Drawing.Point(680, 52)
        Me.cmdPesquisar.Name = "cmdPesquisar"
        Me.cmdPesquisar.Size = New System.Drawing.Size(45, 45)
        Me.cmdPesquisar.TabIndex = 240
        Me.cmdPesquisar.Text = "P"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDataFinal)
        Me.GroupBox1.Controls.Add(Me.txtDataInicial)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(235, 49)
        Me.GroupBox1.TabIndex = 249
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
        'lblSelecao01
        '
        Me.lblSelecao01.AutoSize = True
        Me.lblSelecao01.Location = New System.Drawing.Point(248, 5)
        Me.lblSelecao01.Name = "lblSelecao01"
        Me.lblSelecao01.Size = New System.Drawing.Size(130, 13)
        Me.lblSelecao01.TabIndex = 268
        Me.lblSelecao01.Text = "Modalidade Transferência"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 266
        Me.Label1.Text = "Filial Origem"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(313, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 270
        Me.Label2.Text = "Filial Destino"
        '
        'chkEmTransito
        '
        Me.chkEmTransito.AutoSize = True
        Me.chkEmTransito.Location = New System.Drawing.Point(605, 22)
        Me.chkEmTransito.Name = "chkEmTransito"
        Me.chkEmTransito.Size = New System.Drawing.Size(82, 17)
        Me.chkEmTransito.TabIndex = 272
        Me.chkEmTransito.Text = "Em Transito"
        Me.chkEmTransito.UseVisualStyleBackColor = True
        '
        'cmdExcell
        '
        Me.cmdExcell.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExcell.Location = New System.Drawing.Point(5, 361)
        Me.cmdExcell.Name = "cmdExcell"
        Me.cmdExcell.Size = New System.Drawing.Size(45, 45)
        Me.cmdExcell.TabIndex = 273
        Me.cmdExcell.Text = "Excell"
        '
        'SelecaoFilialDestino
        '
        Me.SelecaoFilialDestino.BackColor = System.Drawing.Color.White
        Me.SelecaoFilialDestino.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoFilialDestino.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoFilialDestino.BancoDados_Tabela = Nothing
        Me.SelecaoFilialDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoFilialDestino.Location = New System.Drawing.Point(313, 77)
        Me.SelecaoFilialDestino.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoFilialDestino.Name = "SelecaoFilialDestino"
        Me.SelecaoFilialDestino.Size = New System.Drawing.Size(300, 20)
        Me.SelecaoFilialDestino.TabIndex = 271
        '
        'SelecaoModalidadeTransferencia
        '
        Me.SelecaoModalidadeTransferencia.BackColor = System.Drawing.Color.White
        Me.SelecaoModalidadeTransferencia.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoModalidadeTransferencia.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoModalidadeTransferencia.BancoDados_Tabela = Nothing
        Me.SelecaoModalidadeTransferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoModalidadeTransferencia.Location = New System.Drawing.Point(248, 20)
        Me.SelecaoModalidadeTransferencia.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoModalidadeTransferencia.Name = "SelecaoModalidadeTransferencia"
        Me.SelecaoModalidadeTransferencia.Size = New System.Drawing.Size(349, 20)
        Me.SelecaoModalidadeTransferencia.TabIndex = 269
        '
        'SelecaoFilialOrigem
        '
        Me.SelecaoFilialOrigem.BackColor = System.Drawing.Color.White
        Me.SelecaoFilialOrigem.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoFilialOrigem.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoFilialOrigem.BancoDados_Tabela = Nothing
        Me.SelecaoFilialOrigem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoFilialOrigem.Location = New System.Drawing.Point(5, 77)
        Me.SelecaoFilialOrigem.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoFilialOrigem.Name = "SelecaoFilialOrigem"
        Me.SelecaoFilialOrigem.Size = New System.Drawing.Size(300, 20)
        Me.SelecaoFilialOrigem.TabIndex = 267
        '
        'cmdInformacoes
        '
        Appearance4.Image = Global.Logus.My.Resources.Resources.Informações
        Me.cmdInformacoes.Appearance = Appearance4
        Me.cmdInformacoes.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdInformacoes.Location = New System.Drawing.Point(58, 361)
        Me.cmdInformacoes.Name = "cmdInformacoes"
        Me.cmdInformacoes.Size = New System.Drawing.Size(45, 45)
        Me.cmdInformacoes.TabIndex = 274
        '
        'cmdRastreabilidade
        '
        Appearance2.Image = CType(resources.GetObject("Appearance2.Image"), Object)
        Me.cmdRastreabilidade.Appearance = Appearance2
        Me.cmdRastreabilidade.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdRastreabilidade.Location = New System.Drawing.Point(111, 361)
        Me.cmdRastreabilidade.Name = "cmdRastreabilidade"
        Me.cmdRastreabilidade.Size = New System.Drawing.Size(45, 45)
        Me.cmdRastreabilidade.TabIndex = 275
        '
        'frmConsultaTransferencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(733, 411)
        Me.Controls.Add(Me.cmdRastreabilidade)
        Me.Controls.Add(Me.cmdInformacoes)
        Me.Controls.Add(Me.cmdExcell)
        Me.Controls.Add(Me.chkEmTransito)
        Me.Controls.Add(Me.SelecaoFilialDestino)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.SelecaoModalidadeTransferencia)
        Me.Controls.Add(Me.lblSelecao01)
        Me.Controls.Add(Me.SelecaoFilialOrigem)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdUsuario)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.grdGeral)
        Me.Controls.Add(Me.cmdPesquisar)
        Me.Name = "frmConsultaTransferencia"
        Me.Text = "Consulta de Transferência"
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtDataFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataInicial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdUsuario As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents grdGeral As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cmdPesquisar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDataFinal As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtDataInicial As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents SelecaoModalidadeTransferencia As Logus.Selecao
    Friend WithEvents lblSelecao01 As System.Windows.Forms.Label
    Friend WithEvents SelecaoFilialOrigem As Logus.Selecao
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SelecaoFilialDestino As Logus.Selecao
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkEmTransito As System.Windows.Forms.CheckBox
    Friend WithEvents cmdExcell As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdInformacoes As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdRastreabilidade As Infragistics.Win.Misc.UltraButton
End Class
