<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmREL_ContaCorrenteContratoFixo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmREL_ContaCorrenteContratoFixo))
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboNegociacao = New System.Windows.Forms.ComboBox
        Me.Pesq_ContratoPAF = New Logus.Pesq_CodigoNome
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboContratoFixo = New System.Windows.Forms.ComboBox
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdImprimir = New Infragistics.Win.Misc.UltraButton
        Me.crvMain = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.cmdExportaRelatorio = New Infragistics.Win.Misc.UltraButton
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(39, 14)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 302
        Me.Label9.Text = "Contrato PAF"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(286, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 13)
        Me.Label8.TabIndex = 301
        Me.Label8.Text = "Negociação"
        '
        'cboNegociacao
        '
        Me.cboNegociacao.Location = New System.Drawing.Point(286, 30)
        Me.cboNegociacao.Name = "cboNegociacao"
        Me.cboNegociacao.Size = New System.Drawing.Size(82, 21)
        Me.cboNegociacao.TabIndex = 300
        '
        'Pesq_ContratoPAF
        '
        Me.Pesq_ContratoPAF.BancoDados_Campo_Codigo = "CD_FORNECEDOR"
        Me.Pesq_ContratoPAF.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_ContratoPAF.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_ContratoPAF.BancoDados_Campo_Descricao = "NO_RAZAO_SOCIAL"
        Me.Pesq_ContratoPAF.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_ContratoPAF.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_ContratoPAF.BancoDados_Tabela = "FORNECEDOR F"
        Me.Pesq_ContratoPAF.Codigo = 0
        Me.Pesq_ContratoPAF.ExibirCodigo = True
        Me.Pesq_ContratoPAF.Location = New System.Drawing.Point(3, 30)
        Me.Pesq_ContratoPAF.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_ContratoPAF.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_ContratoPAF.Name = "Pesq_ContratoPAF"
        Me.Pesq_ContratoPAF.Size = New System.Drawing.Size(277, 28)
        Me.Pesq_ContratoPAF.TabIndex = 299
        Me.Pesq_ContratoPAF.TelaFiltro = False
        Me.Pesq_ContratoPAF.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(374, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 304
        Me.Label1.Text = "Contrato Fixo"
        '
        'cboContratoFixo
        '
        Me.cboContratoFixo.Location = New System.Drawing.Point(374, 30)
        Me.cboContratoFixo.Name = "cboContratoFixo"
        Me.cboContratoFixo.Size = New System.Drawing.Size(84, 21)
        Me.cboContratoFixo.TabIndex = 303
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(568, 7)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 307
        Me.cmdFechar.Text = "F"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdImprimir.Location = New System.Drawing.Point(466, 7)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(45, 45)
        Me.cmdImprimir.TabIndex = 306
        Me.cmdImprimir.Text = "I"
        '
        'crvMain
        '
        Me.crvMain.ActiveViewIndex = -1
        Me.crvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvMain.Location = New System.Drawing.Point(3, 58)
        Me.crvMain.Name = "crvMain"
        Me.crvMain.SelectionFormula = ""
        Me.crvMain.ShowCloseButton = False
        Me.crvMain.ShowGroupTreeButton = False
        Me.crvMain.ShowRefreshButton = False
        Me.crvMain.Size = New System.Drawing.Size(508, 369)
        Me.crvMain.TabIndex = 305
        Me.crvMain.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.crvMain.ViewTimeSelectionFormula = ""
        '
        'cmdExportaRelatorio
        '
        Me.cmdExportaRelatorio.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExportaRelatorio.Location = New System.Drawing.Point(517, 7)
        Me.cmdExportaRelatorio.Name = "cmdExportaRelatorio"
        Me.cmdExportaRelatorio.Size = New System.Drawing.Size(45, 45)
        Me.cmdExportaRelatorio.TabIndex = 492
        Me.cmdExportaRelatorio.Text = "ER"
        '
        'frmREL_ContaCorrenteContratoFixo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(691, 523)
        Me.Controls.Add(Me.cmdExportaRelatorio)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.crvMain)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboContratoFixo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboNegociacao)
        Me.Controls.Add(Me.Pesq_ContratoPAF)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmREL_ContaCorrenteContratoFixo"
        Me.Text = "Conta Corrente do Contrato Fixo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboNegociacao As System.Windows.Forms.ComboBox
    Friend WithEvents Pesq_ContratoPAF As Logus.Pesq_CodigoNome
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboContratoFixo As System.Windows.Forms.ComboBox
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdImprimir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents crvMain As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents cmdExportaRelatorio As Infragistics.Win.Misc.UltraButton
End Class
