<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmREL_AdiantamentoExposure
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
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmREL_AdiantamentoExposure))
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdImprimir = New Infragistics.Win.Misc.UltraButton
        Me.crvMain = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.cmdExportaRelatorio = New Infragistics.Win.Misc.UltraButton
        Me.grdValores = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtDolar = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.cmdAtualizar = New Infragistics.Win.Misc.UltraButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtBolsa = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.lblR_Bolsa = New System.Windows.Forms.Label
        Me.txtValorArroba = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.lblR_ValorArroba = New System.Windows.Forms.Label
        Me.optTipo = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        CType(Me.grdValores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grdValores.SuspendLayout()
        CType(Me.txtDolar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBolsa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorArroba, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(542, 13)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 321
        Me.cmdFechar.Text = "F"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdImprimir.Location = New System.Drawing.Point(440, 13)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(45, 45)
        Me.cmdImprimir.TabIndex = 320
        Me.cmdImprimir.Text = "I"
        '
        'crvMain
        '
        Me.crvMain.ActiveViewIndex = -1
        Me.crvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvMain.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.crvMain.Location = New System.Drawing.Point(8, 66)
        Me.crvMain.Name = "crvMain"
        Me.crvMain.SelectionFormula = ""
        Me.crvMain.ShowParameterPanelButton = False
        Me.crvMain.ShowRefreshButton = False
        Me.crvMain.Size = New System.Drawing.Size(401, 369)
        Me.crvMain.TabIndex = 319
        Me.crvMain.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.crvMain.ViewTimeSelectionFormula = ""
        '
        'cmdExportaRelatorio
        '
        Me.cmdExportaRelatorio.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExportaRelatorio.Location = New System.Drawing.Point(491, 13)
        Me.cmdExportaRelatorio.Name = "cmdExportaRelatorio"
        Me.cmdExportaRelatorio.Size = New System.Drawing.Size(45, 45)
        Me.cmdExportaRelatorio.TabIndex = 492
        Me.cmdExportaRelatorio.Text = "ER"
        '
        'grdValores
        '
        Me.grdValores.Controls.Add(Me.txtDolar)
        Me.grdValores.Controls.Add(Me.cmdAtualizar)
        Me.grdValores.Controls.Add(Me.Label3)
        Me.grdValores.Controls.Add(Me.txtBolsa)
        Me.grdValores.Controls.Add(Me.lblR_Bolsa)
        Me.grdValores.Controls.Add(Me.txtValorArroba)
        Me.grdValores.Controls.Add(Me.lblR_ValorArroba)
        Me.grdValores.Location = New System.Drawing.Point(230, 6)
        Me.grdValores.Name = "grdValores"
        Me.grdValores.Size = New System.Drawing.Size(204, 52)
        Me.grdValores.TabIndex = 493
        '
        'txtDolar
        '
        Me.txtDolar.Location = New System.Drawing.Point(61, 24)
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
        Me.cmdAtualizar.Location = New System.Drawing.Point(168, 17)
        Me.cmdAtualizar.Name = "cmdAtualizar"
        Me.cmdAtualizar.Size = New System.Drawing.Size(28, 28)
        Me.cmdAtualizar.TabIndex = 315
        Me.cmdAtualizar.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(58, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 318
        Me.Label3.Text = "Dolar"
        '
        'txtBolsa
        '
        Me.txtBolsa.Location = New System.Drawing.Point(6, 24)
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
        Me.txtValorArroba.Location = New System.Drawing.Point(116, 24)
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
        Me.lblR_ValorArroba.Location = New System.Drawing.Point(117, 8)
        Me.lblR_ValorArroba.Name = "lblR_ValorArroba"
        Me.lblR_ValorArroba.Size = New System.Drawing.Size(45, 13)
        Me.lblR_ValorArroba.TabIndex = 314
        Me.lblR_ValorArroba.Text = "Valor @"
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
        Me.optTipo.ItemOrigin = New System.Drawing.Point(10, 2)
        ValueListItem1.DataValue = "S"
        ValueListItem1.DisplayText = "Sintético"
        ValueListItem2.DataValue = "ACC"
        ValueListItem2.DisplayText = "Analítico - Adto c/ Ctr Base"
        ValueListItem3.DataValue = "ASC"
        ValueListItem3.DisplayText = "Analítico - Adto s/ Ctr Base"
        Me.optTipo.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem3})
        Me.optTipo.ItemSpacingVertical = 1
        Me.optTipo.Location = New System.Drawing.Point(8, 8)
        Me.optTipo.Name = "optTipo"
        Me.optTipo.Size = New System.Drawing.Size(222, 50)
        Me.optTipo.TabIndex = 494
        Me.optTipo.Text = "Sintético"
        '
        'frmREL_AdiantamentoExposure
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(825, 553)
        Me.Controls.Add(Me.optTipo)
        Me.Controls.Add(Me.grdValores)
        Me.Controls.Add(Me.cmdExportaRelatorio)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.crvMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmREL_AdiantamentoExposure"
        Me.Text = "Relatório Adiantamento Exposure"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grdValores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grdValores.ResumeLayout(False)
        Me.grdValores.PerformLayout()
        CType(Me.txtDolar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBolsa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorArroba, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdImprimir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents crvMain As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents cmdExportaRelatorio As Infragistics.Win.Misc.UltraButton
    Friend WithEvents grdValores As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtDolar As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents cmdAtualizar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtBolsa As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents lblR_Bolsa As System.Windows.Forms.Label
    Friend WithEvents txtValorArroba As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents lblR_ValorArroba As System.Windows.Forms.Label
    Friend WithEvents optTipo As Infragistics.Win.UltraWinEditors.UltraOptionSet
End Class
