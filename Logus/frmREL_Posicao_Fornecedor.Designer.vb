<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmREL_Posicao_Fornecedor
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
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmREL_Posicao_Fornecedor))
        Me.cmdAtualizar = New Infragistics.Win.Misc.UltraButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtValorArroba = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.crvMain = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtDolar = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtBolsa = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdImprimir = New Infragistics.Win.Misc.UltraButton
        Me.optTipo = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.chkTodosContratosAberto = New System.Windows.Forms.CheckBox
        Me.SelecaoSafra = New Logus.Selecao
        Me.Pesq_Fornecedor = New Logus.Pesq_CodigoNome
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdExportaRelatorio = New Infragistics.Win.Misc.UltraButton
        CType(Me.txtValorArroba, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.txtDolar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBolsa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 311
        Me.Label1.Text = "Safra"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(8, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(95, 13)
        Me.Label9.TabIndex = 310
        Me.Label9.Text = "Fornecedor\Titular"
        '
        'crvMain
        '
        Me.crvMain.ActiveViewIndex = -1
        Me.crvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvMain.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.crvMain.Location = New System.Drawing.Point(8, 113)
        Me.crvMain.Name = "crvMain"
        Me.crvMain.ShowCloseButton = False
        Me.crvMain.ShowGroupTreeButton = False
        Me.crvMain.ShowRefreshButton = False
        Me.crvMain.Size = New System.Drawing.Size(717, 401)
        Me.crvMain.TabIndex = 308
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
        Me.UltraGroupBox1.Location = New System.Drawing.Point(387, 53)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(204, 52)
        Me.UltraGroupBox1.TabIndex = 316
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
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(648, 53)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 318
        Me.cmdFechar.Text = "F"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdImprimir.Location = New System.Drawing.Point(597, 53)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(45, 45)
        Me.cmdImprimir.TabIndex = 317
        Me.cmdImprimir.Text = "I"
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
        Me.optTipo.ItemOrigin = New System.Drawing.Point(6, 4)
        ValueListItem1.DataValue = "FO"
        ValueListItem1.DisplayText = "Por Fornecedor"
        ValueListItem2.DataValue = "TI"
        ValueListItem2.DisplayText = "Por Titular"
        Me.optTipo.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2})
        Me.optTipo.Location = New System.Drawing.Point(387, 23)
        Me.optTipo.Name = "optTipo"
        Me.optTipo.Size = New System.Drawing.Size(204, 23)
        Me.optTipo.TabIndex = 319
        Me.optTipo.Text = "Por Fornecedor"
        '
        'chkTodosContratosAberto
        '
        Me.chkTodosContratosAberto.Location = New System.Drawing.Point(310, 58)
        Me.chkTodosContratosAberto.Name = "chkTodosContratosAberto"
        Me.chkTodosContratosAberto.Size = New System.Drawing.Size(71, 43)
        Me.chkTodosContratosAberto.TabIndex = 320
        Me.chkTodosContratosAberto.Text = "Todos os Contratos Abertos"
        Me.chkTodosContratosAberto.UseVisualStyleBackColor = True
        '
        'SelecaoSafra
        '
        Me.SelecaoSafra.BackColor = System.Drawing.Color.White
        Me.SelecaoSafra.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoSafra.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoSafra.BancoDados_Campo_OrdenarConsulta = True
        Me.SelecaoSafra.BancoDados_Tabela = Nothing
        Me.SelecaoSafra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoSafra.Location = New System.Drawing.Point(8, 67)
        Me.SelecaoSafra.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoSafra.MultiplaSelecao = False
        Me.SelecaoSafra.Name = "SelecaoSafra"
        Me.SelecaoSafra.Size = New System.Drawing.Size(296, 19)
        Me.SelecaoSafra.TabIndex = 312
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
        Me.Pesq_Fornecedor.Location = New System.Drawing.Point(8, 22)
        Me.Pesq_Fornecedor.MaximumSize = New System.Drawing.Size(1000, 23)
        Me.Pesq_Fornecedor.MinimumSize = New System.Drawing.Size(0, 23)
        Me.Pesq_Fornecedor.Name = "Pesq_Fornecedor"
        Me.Pesq_Fornecedor.Size = New System.Drawing.Size(373, 23)
        Me.Pesq_Fornecedor.TabIndex = 309
        Me.Pesq_Fornecedor.TelaFiltro = False
        Me.Pesq_Fornecedor.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(387, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 13)
        Me.Label5.TabIndex = 321
        Me.Label5.Text = "Agrupado Por:"
        '
        'cmdExportaRelatorio
        '
        Me.cmdExportaRelatorio.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExportaRelatorio.Location = New System.Drawing.Point(597, 4)
        Me.cmdExportaRelatorio.Name = "cmdExportaRelatorio"
        Me.cmdExportaRelatorio.Size = New System.Drawing.Size(45, 45)
        Me.cmdExportaRelatorio.TabIndex = 493
        Me.cmdExportaRelatorio.Text = "ER"
        '
        'frmREL_Posicao_Fornecedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 526)
        Me.Controls.Add(Me.cmdExportaRelatorio)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.chkTodosContratosAberto)
        Me.Controls.Add(Me.optTipo)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.SelecaoSafra)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Pesq_Fornecedor)
        Me.Controls.Add(Me.crvMain)
        Me.Controls.Add(Me.Label9)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmREL_Posicao_Fornecedor"
        Me.Text = "Posição do Fornecedor"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.txtValorArroba, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.txtDolar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBolsa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdAtualizar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtValorArroba As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents SelecaoSafra As Logus.Selecao
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Pesq_Fornecedor As Logus.Pesq_CodigoNome
    Friend WithEvents crvMain As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtDolar As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtBolsa As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdImprimir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents optTipo As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents chkTodosContratosAberto As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdExportaRelatorio As Infragistics.Win.Misc.UltraButton
End Class
