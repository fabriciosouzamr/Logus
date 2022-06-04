<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmREL_ContratosComSaldo
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmREL_ContratosComSaldo))
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtTaxaDolar = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdImprimir = New Infragistics.Win.Misc.UltraButton
        Me.crvMain = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SelecaoFilial = New Logus.Selecao
        Me.Label7 = New System.Windows.Forms.Label
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmdExportaRelatorio = New Infragistics.Win.Misc.UltraButton
        Me.lblR_TipoCacau = New System.Windows.Forms.Label
        Me.cboTipoCacau = New System.Windows.Forms.ComboBox
        Me.Pesq_Fornecedor = New Logus.Pesq_CodigoNome
        Me.Label9 = New System.Windows.Forms.Label
        Me.chkComIncidenciaINSS = New System.Windows.Forms.CheckBox
        CType(Me.txtTaxaDolar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(8, 8)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 13)
        Me.Label11.TabIndex = 328
        Me.Label11.Text = "Taxa Dolar"
        '
        'txtTaxaDolar
        '
        Me.txtTaxaDolar.Location = New System.Drawing.Point(8, 22)
        Me.txtTaxaDolar.MaskInput = "{LOC}-n.nnnn"
        Me.txtTaxaDolar.Name = "txtTaxaDolar"
        Me.txtTaxaDolar.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtTaxaDolar.Size = New System.Drawing.Size(89, 21)
        Me.txtTaxaDolar.TabIndex = 327
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(602, 41)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 326
        Me.cmdFechar.Text = "F"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdImprimir.Location = New System.Drawing.Point(496, 41)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(45, 45)
        Me.cmdImprimir.TabIndex = 325
        Me.cmdImprimir.Text = "I"
        '
        'crvMain
        '
        Me.crvMain.ActiveViewIndex = -1
        Me.crvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvMain.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.crvMain.Location = New System.Drawing.Point(8, 96)
        Me.crvMain.Name = "crvMain"
        Me.crvMain.SelectionFormula = ""
        Me.crvMain.ShowParameterPanelButton = False
        Me.crvMain.ShowRefreshButton = False
        Me.crvMain.Size = New System.Drawing.Size(892, 310)
        Me.crvMain.TabIndex = 324
        Me.crvMain.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.crvMain.ViewTimeSelectionFormula = ""
        '
        'SelecaoFilial
        '
        Me.SelecaoFilial.BackColor = System.Drawing.Color.White
        Me.SelecaoFilial.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoFilial.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoFilial.BancoDados_Campo_OrdenarConsulta = True
        Me.SelecaoFilial.BancoDados_Tabela = Nothing
        Me.SelecaoFilial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoFilial.Location = New System.Drawing.Point(105, 22)
        Me.SelecaoFilial.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoFilial.MultiplaSelecao = False
        Me.SelecaoFilial.Name = "SelecaoFilial"
        Me.SelecaoFilial.Size = New System.Drawing.Size(383, 19)
        Me.SelecaoFilial.TabIndex = 330
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(105, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 13)
        Me.Label7.TabIndex = 329
        Me.Label7.Text = "Filial"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'cmdExportaRelatorio
        '
        Me.cmdExportaRelatorio.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExportaRelatorio.Location = New System.Drawing.Point(549, 41)
        Me.cmdExportaRelatorio.Name = "cmdExportaRelatorio"
        Me.cmdExportaRelatorio.Size = New System.Drawing.Size(45, 45)
        Me.cmdExportaRelatorio.TabIndex = 492
        Me.cmdExportaRelatorio.Text = "ER"
        '
        'lblR_TipoCacau
        '
        Me.lblR_TipoCacau.AutoSize = True
        Me.lblR_TipoCacau.Location = New System.Drawing.Point(370, 51)
        Me.lblR_TipoCacau.Name = "lblR_TipoCacau"
        Me.lblR_TipoCacau.Size = New System.Drawing.Size(77, 13)
        Me.lblR_TipoCacau.TabIndex = 498
        Me.lblR_TipoCacau.Text = "Tipo de Cacau"
        '
        'cboTipoCacau
        '
        Me.cboTipoCacau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoCacau.Location = New System.Drawing.Point(369, 65)
        Me.cboTipoCacau.Name = "cboTipoCacau"
        Me.cboTipoCacau.Size = New System.Drawing.Size(119, 21)
        Me.cboTipoCacau.TabIndex = 497
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
        Me.Pesq_Fornecedor.Location = New System.Drawing.Point(8, 65)
        Me.Pesq_Fornecedor.MaximumSize = New System.Drawing.Size(1000, 23)
        Me.Pesq_Fornecedor.MinimumSize = New System.Drawing.Size(0, 23)
        Me.Pesq_Fornecedor.Name = "Pesq_Fornecedor"
        Me.Pesq_Fornecedor.Size = New System.Drawing.Size(353, 23)
        Me.Pesq_Fornecedor.TabIndex = 495
        Me.Pesq_Fornecedor.TelaFiltro = False
        Me.Pesq_Fornecedor.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(8, 51)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 13)
        Me.Label9.TabIndex = 496
        Me.Label9.Text = "Fornecedor"
        '
        'chkComIncidenciaINSS
        '
        Me.chkComIncidenciaINSS.AutoSize = True
        Me.chkComIncidenciaINSS.Checked = True
        Me.chkComIncidenciaINSS.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkComIncidenciaINSS.Location = New System.Drawing.Point(496, 24)
        Me.chkComIncidenciaINSS.Name = "chkComIncidenciaINSS"
        Me.chkComIncidenciaINSS.Size = New System.Drawing.Size(141, 17)
        Me.chkComIncidenciaINSS.TabIndex = 499
        Me.chkComIncidenciaINSS.Text = "Com incidência de INSS"
        Me.chkComIncidenciaINSS.UseVisualStyleBackColor = True
        '
        'frmREL_ContratosComSaldo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(938, 554)
        Me.Controls.Add(Me.chkComIncidenciaINSS)
        Me.Controls.Add(Me.lblR_TipoCacau)
        Me.Controls.Add(Me.cboTipoCacau)
        Me.Controls.Add(Me.Pesq_Fornecedor)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.SelecaoFilial)
        Me.Controls.Add(Me.cmdExportaRelatorio)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtTaxaDolar)
        Me.Controls.Add(Me.crvMain)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmREL_ContratosComSaldo"
        Me.Text = "Relatório de Contratos Com Saldo"
        CType(Me.txtTaxaDolar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTaxaDolar As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdImprimir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents crvMain As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents SelecaoFilial As Logus.Selecao
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmdExportaRelatorio As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblR_TipoCacau As System.Windows.Forms.Label
    Friend WithEvents cboTipoCacau As System.Windows.Forms.ComboBox
    Friend WithEvents Pesq_Fornecedor As Logus.Pesq_CodigoNome
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkComIncidenciaINSS As System.Windows.Forms.CheckBox
End Class
