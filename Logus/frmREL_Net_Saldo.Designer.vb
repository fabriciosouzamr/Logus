<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmREL_Net_Saldo
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
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmREL_Net_Saldo))
        Me.chkSomenteNegativos = New System.Windows.Forms.CheckBox
        Me.optTipo = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdImprimir = New Infragistics.Win.Misc.UltraButton
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtDolar = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.cmdAtualizar = New Infragistics.Win.Misc.UltraButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtBolsa = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtValorArroba = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Label4 = New System.Windows.Forms.Label
        Me.crvMain = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.chkOrdemCrescente = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.SelecaoModalidadeCredito = New Logus.Selecao
        Me.SelecaoFilial = New Logus.Selecao
        Me.SelecaoSafra = New Logus.Selecao
        Me.cmdExportaRelatorio = New Infragistics.Win.Misc.UltraButton
        CType(Me.optTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.txtDolar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBolsa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorArroba, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkSomenteNegativos
        '
        Me.chkSomenteNegativos.Location = New System.Drawing.Point(249, 63)
        Me.chkSomenteNegativos.Name = "chkSomenteNegativos"
        Me.chkSomenteNegativos.Size = New System.Drawing.Size(162, 34)
        Me.chkSomenteNegativos.TabIndex = 329
        Me.chkSomenteNegativos.Text = "Somente Titular com Saldo Negativo"
        Me.chkSomenteNegativos.UseVisualStyleBackColor = True
        '
        'optTipo
        '
        Appearance5.TextHAlignAsString = "Center"
        Appearance5.TextVAlignAsString = "Middle"
        Me.optTipo.Appearance = Appearance5
        Me.optTipo.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.optTipo.CheckedIndex = 0
        Appearance6.TextHAlignAsString = "Center"
        Appearance6.TextVAlignAsString = "Middle"
        Me.optTipo.ItemAppearance = Appearance6
        Me.optTipo.ItemOrigin = New System.Drawing.Point(5, 5)
        ValueListItem1.DataValue = "FO"
        ValueListItem1.DisplayText = "Fornecedor"
        ValueListItem2.DataValue = "TI"
        ValueListItem2.DisplayText = "Titular"
        ValueListItem3.DataValue = "FI"
        ValueListItem3.DisplayText = "Filial"
        ValueListItem4.DataValue = "SI"
        ValueListItem4.DisplayText = "Sintetico"
        Me.optTipo.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem3, ValueListItem4})
        Me.optTipo.Location = New System.Drawing.Point(462, 11)
        Me.optTipo.Name = "optTipo"
        Me.optTipo.Size = New System.Drawing.Size(264, 28)
        Me.optTipo.TabIndex = 328
        Me.optTipo.Text = "Fornecedor"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(732, 52)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 327
        Me.cmdFechar.Text = "F"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdImprimir.Location = New System.Drawing.Point(630, 52)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(45, 45)
        Me.cmdImprimir.TabIndex = 326
        Me.cmdImprimir.Text = "I"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.txtDolar)
        Me.UltraGroupBox1.Controls.Add(Me.cmdAtualizar)
        Me.UltraGroupBox1.Controls.Add(Me.Label3)
        Me.UltraGroupBox1.Controls.Add(Me.txtBolsa)
        Me.UltraGroupBox1.Controls.Add(Me.Label2)
        Me.UltraGroupBox1.Controls.Add(Me.txtValorArroba)
        Me.UltraGroupBox1.Controls.Add(Me.Label4)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(417, 46)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(204, 52)
        Me.UltraGroupBox1.TabIndex = 325
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(3, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 316
        Me.Label2.Text = "Bolsa"
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(117, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 314
        Me.Label4.Text = "Valor @"
        '
        'crvMain
        '
        Me.crvMain.ActiveViewIndex = -1
        Me.crvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvMain.Location = New System.Drawing.Point(2, 104)
        Me.crvMain.Name = "crvMain"
        Me.crvMain.SelectionFormula = ""
        Me.crvMain.ShowCloseButton = False
        Me.crvMain.ShowGroupTreeButton = False
        Me.crvMain.ShowRefreshButton = False
        Me.crvMain.Size = New System.Drawing.Size(647, 369)
        Me.crvMain.TabIndex = 321
        Me.crvMain.ViewTimeSelectionFormula = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 330
        Me.Label1.Text = "Safra"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(2, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 13)
        Me.Label5.TabIndex = 331
        Me.Label5.Text = "Filial"
        '
        'chkOrdemCrescente
        '
        Me.chkOrdemCrescente.Location = New System.Drawing.Point(249, 36)
        Me.chkOrdemCrescente.Name = "chkOrdemCrescente"
        Me.chkOrdemCrescente.Size = New System.Drawing.Size(162, 34)
        Me.chkOrdemCrescente.TabIndex = 333
        Me.chkOrdemCrescente.Text = "Ordem Crescente de Saldo"
        Me.chkOrdemCrescente.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(239, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(166, 13)
        Me.Label6.TabIndex = 335
        Me.Label6.Text = "Modalidade Recuperação Crédito"
        '
        'SelecaoModalidadeCredito
        '
        Me.SelecaoModalidadeCredito.BackColor = System.Drawing.Color.White
        Me.SelecaoModalidadeCredito.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoModalidadeCredito.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoModalidadeCredito.BancoDados_Tabela = Nothing
        Me.SelecaoModalidadeCredito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoModalidadeCredito.Location = New System.Drawing.Point(239, 20)
        Me.SelecaoModalidadeCredito.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoModalidadeCredito.MultiplaSelecao = False
        Me.SelecaoModalidadeCredito.Name = "SelecaoModalidadeCredito"
        Me.SelecaoModalidadeCredito.Size = New System.Drawing.Size(214, 19)
        Me.SelecaoModalidadeCredito.TabIndex = 334
        '
        'SelecaoFilial
        '
        Me.SelecaoFilial.BackColor = System.Drawing.Color.White
        Me.SelecaoFilial.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoFilial.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoFilial.BancoDados_Tabela = Nothing
        Me.SelecaoFilial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoFilial.Location = New System.Drawing.Point(2, 20)
        Me.SelecaoFilial.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoFilial.MultiplaSelecao = False
        Me.SelecaoFilial.Name = "SelecaoFilial"
        Me.SelecaoFilial.Size = New System.Drawing.Size(233, 20)
        Me.SelecaoFilial.TabIndex = 332
        '
        'SelecaoSafra
        '
        Me.SelecaoSafra.BackColor = System.Drawing.Color.White
        Me.SelecaoSafra.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoSafra.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoSafra.BancoDados_Tabela = Nothing
        Me.SelecaoSafra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoSafra.Location = New System.Drawing.Point(2, 70)
        Me.SelecaoSafra.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoSafra.MultiplaSelecao = False
        Me.SelecaoSafra.Name = "SelecaoSafra"
        Me.SelecaoSafra.Size = New System.Drawing.Size(233, 19)
        Me.SelecaoSafra.TabIndex = 324
        '
        'cmdExportaRelatorio
        '
        Me.cmdExportaRelatorio.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExportaRelatorio.Location = New System.Drawing.Point(681, 52)
        Me.cmdExportaRelatorio.Name = "cmdExportaRelatorio"
        Me.cmdExportaRelatorio.Size = New System.Drawing.Size(45, 45)
        Me.cmdExportaRelatorio.TabIndex = 493
        Me.cmdExportaRelatorio.Text = "ER"
        '
        'frmREL_Net_Saldo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 613)
        Me.Controls.Add(Me.cmdExportaRelatorio)
        Me.Controls.Add(Me.chkSomenteNegativos)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.SelecaoModalidadeCredito)
        Me.Controls.Add(Me.chkOrdemCrescente)
        Me.Controls.Add(Me.SelecaoFilial)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.optTipo)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.SelecaoSafra)
        Me.Controls.Add(Me.crvMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmREL_Net_Saldo"
        Me.Text = "Posição Net de Saldos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.optTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.txtDolar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBolsa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorArroba, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkSomenteNegativos As System.Windows.Forms.CheckBox
    Friend WithEvents optTipo As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdImprimir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtDolar As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents cmdAtualizar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtBolsa As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtValorArroba As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SelecaoSafra As Logus.Selecao
    Friend WithEvents crvMain As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SelecaoFilial As Logus.Selecao
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkOrdemCrescente As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents SelecaoModalidadeCredito As Logus.Selecao
    Friend WithEvents cmdExportaRelatorio As Infragistics.Win.Misc.UltraButton
End Class
