<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRelatorioGeracaoAutomatica
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
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdImprimir = New Infragistics.Win.Misc.UltraButton
        Me.grdGeral = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.grdValores = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtValorDif = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtDolar = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.cmdAtualizar = New Infragistics.Win.Misc.UltraButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtBolsa = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.lblR_Bolsa = New System.Windows.Forms.Label
        Me.txtValorArroba = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.lblR_ValorArroba = New System.Windows.Forms.Label
        Me.txtValorDividasIncobraveis = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtDiretorioExportacao = New System.Windows.Forms.TextBox
        Me.lblStatus = New System.Windows.Forms.Label
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdValores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grdValores.SuspendLayout()
        CType(Me.txtValorDif, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDolar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBolsa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorArroba, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorDividasIncobraveis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdFechar
        '
        Me.cmdFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(729, 15)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 195
        Me.cmdFechar.Text = "F"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdImprimir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdImprimir.Location = New System.Drawing.Point(678, 15)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(45, 45)
        Me.cmdImprimir.TabIndex = 194
        Me.cmdImprimir.Text = "I"
        '
        'grdGeral
        '
        Me.grdGeral.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance4.BackColor = System.Drawing.SystemColors.Window
        Appearance4.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdGeral.DisplayLayout.Appearance = Appearance4
        Me.grdGeral.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdGeral.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance1.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance1.BorderColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.GroupByBox.Appearance = Appearance1
        Appearance2.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdGeral.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance2
        Me.grdGeral.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance3.BackColor2 = System.Drawing.SystemColors.Control
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdGeral.DisplayLayout.GroupByBox.PromptAppearance = Appearance3
        Me.grdGeral.DisplayLayout.MaxColScrollRegions = 1
        Me.grdGeral.DisplayLayout.MaxRowScrollRegions = 1
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdGeral.DisplayLayout.Override.ActiveCellAppearance = Appearance12
        Appearance7.BackColor = System.Drawing.SystemColors.Highlight
        Appearance7.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdGeral.DisplayLayout.Override.ActiveRowAppearance = Appearance7
        Me.grdGeral.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdGeral.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance6.BackColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.Override.CardAreaAppearance = Appearance6
        Appearance5.BorderColor = System.Drawing.Color.Silver
        Appearance5.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdGeral.DisplayLayout.Override.CellAppearance = Appearance5
        Me.grdGeral.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdGeral.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance11.TextHAlignAsString = "Left"
        Me.grdGeral.DisplayLayout.Override.HeaderAppearance = Appearance11
        Me.grdGeral.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdGeral.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance10.BackColor = System.Drawing.SystemColors.Window
        Appearance10.BorderColor = System.Drawing.Color.Silver
        Me.grdGeral.DisplayLayout.Override.RowAppearance = Appearance10
        Me.grdGeral.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance13.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdGeral.DisplayLayout.Override.TemplateAddRowAppearance = Appearance13
        Me.grdGeral.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdGeral.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdGeral.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdGeral.Location = New System.Drawing.Point(8, 66)
        Me.grdGeral.Name = "grdGeral"
        Me.grdGeral.Size = New System.Drawing.Size(766, 379)
        Me.grdGeral.TabIndex = 196
        Me.grdGeral.Text = "UltraGrid1"
        '
        'grdValores
        '
        Me.grdValores.Controls.Add(Me.txtValorDif)
        Me.grdValores.Controls.Add(Me.Label6)
        Me.grdValores.Controls.Add(Me.txtDolar)
        Me.grdValores.Controls.Add(Me.cmdAtualizar)
        Me.grdValores.Controls.Add(Me.Label3)
        Me.grdValores.Controls.Add(Me.txtBolsa)
        Me.grdValores.Controls.Add(Me.lblR_Bolsa)
        Me.grdValores.Controls.Add(Me.txtValorArroba)
        Me.grdValores.Controls.Add(Me.lblR_ValorArroba)
        Me.grdValores.Location = New System.Drawing.Point(8, 8)
        Me.grdValores.Name = "grdValores"
        Me.grdValores.Size = New System.Drawing.Size(280, 52)
        Me.grdValores.TabIndex = 494
        '
        'txtValorDif
        '
        Me.txtValorDif.Location = New System.Drawing.Point(174, 22)
        Me.txtValorDif.MaskInput = "{LOC}-nnn.nn"
        Me.txtValorDif.MaxValue = 999
        Me.txtValorDif.MinValue = -999
        Me.txtValorDif.Name = "txtValorDif"
        Me.txtValorDif.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtValorDif.Size = New System.Drawing.Size(62, 21)
        Me.txtValorDif.TabIndex = 319
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(174, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 13)
        Me.Label6.TabIndex = 320
        Me.Label6.Text = "Diferencial"
        '
        'txtDolar
        '
        Me.txtDolar.Location = New System.Drawing.Point(63, 22)
        Me.txtDolar.MaskInput = "{LOC}nn.nnnn"
        Me.txtDolar.MaxValue = 99
        Me.txtDolar.MinValue = 0
        Me.txtDolar.Name = "txtDolar"
        Me.txtDolar.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtDolar.Size = New System.Drawing.Size(49, 21)
        Me.txtDolar.TabIndex = 317
        '
        'cmdAtualizar
        '
        Appearance8.Image = Global.Logus.My.Resources.Resources.replace2
        Me.cmdAtualizar.Appearance = Appearance8
        Me.cmdAtualizar.ImageSize = New System.Drawing.Size(20, 20)
        Me.cmdAtualizar.Location = New System.Drawing.Point(244, 17)
        Me.cmdAtualizar.Name = "cmdAtualizar"
        Me.cmdAtualizar.Size = New System.Drawing.Size(28, 28)
        Me.cmdAtualizar.TabIndex = 315
        Me.cmdAtualizar.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(63, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 318
        Me.Label3.Text = "Dolar"
        '
        'txtBolsa
        '
        Me.txtBolsa.Location = New System.Drawing.Point(6, 22)
        Me.txtBolsa.MaskInput = "{LOC}nnnnn"
        Me.txtBolsa.MaxValue = 99999
        Me.txtBolsa.MinValue = 0
        Me.txtBolsa.Name = "txtBolsa"
        Me.txtBolsa.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtBolsa.Size = New System.Drawing.Size(49, 21)
        Me.txtBolsa.TabIndex = 315
        '
        'lblR_Bolsa
        '
        Me.lblR_Bolsa.AutoSize = True
        Me.lblR_Bolsa.BackColor = System.Drawing.Color.Transparent
        Me.lblR_Bolsa.Location = New System.Drawing.Point(3, 8)
        Me.lblR_Bolsa.Name = "lblR_Bolsa"
        Me.lblR_Bolsa.Size = New System.Drawing.Size(33, 13)
        Me.lblR_Bolsa.TabIndex = 316
        Me.lblR_Bolsa.Text = "Bolsa"
        '
        'txtValorArroba
        '
        Me.txtValorArroba.Location = New System.Drawing.Point(120, 22)
        Me.txtValorArroba.MaskInput = "{LOC}nnn.nn"
        Me.txtValorArroba.MaxValue = 999
        Me.txtValorArroba.MinValue = 0
        Me.txtValorArroba.Name = "txtValorArroba"
        Me.txtValorArroba.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtValorArroba.Size = New System.Drawing.Size(46, 21)
        Me.txtValorArroba.TabIndex = 313
        '
        'lblR_ValorArroba
        '
        Me.lblR_ValorArroba.AutoSize = True
        Me.lblR_ValorArroba.BackColor = System.Drawing.Color.Transparent
        Me.lblR_ValorArroba.Location = New System.Drawing.Point(120, 8)
        Me.lblR_ValorArroba.Name = "lblR_ValorArroba"
        Me.lblR_ValorArroba.Size = New System.Drawing.Size(45, 13)
        Me.lblR_ValorArroba.TabIndex = 314
        Me.lblR_ValorArroba.Text = "Valor @"
        '
        'txtValorDividasIncobraveis
        '
        Me.txtValorDividasIncobraveis.Location = New System.Drawing.Point(296, 39)
        Me.txtValorDividasIncobraveis.MaskInput = "{LOC}R$ n,nnn,nnn.nn"
        Me.txtValorDividasIncobraveis.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtValorDividasIncobraveis.Name = "txtValorDividasIncobraveis"
        Me.txtValorDividasIncobraveis.Size = New System.Drawing.Size(113, 21)
        Me.txtValorDividasIncobraveis.TabIndex = 502
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(296, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 13)
        Me.Label1.TabIndex = 501
        Me.Label1.Text = "Vl. Dívidas Incobráveis"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(417, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 13)
        Me.Label2.TabIndex = 501
        Me.Label2.Text = "Diretório para exportação"
        '
        'txtDiretorioExportacao
        '
        Me.txtDiretorioExportacao.Location = New System.Drawing.Point(417, 40)
        Me.txtDiretorioExportacao.Name = "txtDiretorioExportacao"
        Me.txtDiretorioExportacao.Size = New System.Drawing.Size(250, 20)
        Me.txtDiretorioExportacao.TabIndex = 503
        Me.txtDiretorioExportacao.Text = "\\msbrilhe0001\Data1\Logus\Rel"
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.Red
        Me.lblStatus.Location = New System.Drawing.Point(8, 453)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(56, 13)
        Me.lblStatus.TabIndex = 505
        Me.lblStatus.Text = "lblStatus"
        '
        'frmRelatorioGeracaoAutomatica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 470)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.txtDiretorioExportacao)
        Me.Controls.Add(Me.txtValorDividasIncobraveis)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grdValores)
        Me.Controls.Add(Me.grdGeral)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Name = "frmRelatorioGeracaoAutomatica"
        Me.Text = "Geração Automática de Relatórios"
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdValores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grdValores.ResumeLayout(False)
        Me.grdValores.PerformLayout()
        CType(Me.txtValorDif, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDolar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBolsa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorArroba, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorDividasIncobraveis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdImprimir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents grdGeral As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grdValores As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtDolar As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents cmdAtualizar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtBolsa As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents lblR_Bolsa As System.Windows.Forms.Label
    Friend WithEvents txtValorArroba As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents lblR_ValorArroba As System.Windows.Forms.Label
    Friend WithEvents txtValorDividasIncobraveis As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDiretorioExportacao As System.Windows.Forms.TextBox
    Friend WithEvents txtValorDif As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
End Class
