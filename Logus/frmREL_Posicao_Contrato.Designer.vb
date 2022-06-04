<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmREL_Posicao_Contrato
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmREL_Posicao_Contrato))
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdImprimir = New Infragistics.Win.Misc.UltraButton
        Me.crvMain = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtDiasVencer = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtValorArroba = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.cmdAtualizar = New Infragistics.Win.Misc.UltraButton
        Me.SelecaoOpcao = New Logus.Selecao
        Me.SelecaoSafra = New Logus.Selecao
        Me.Pesq_Fornecedor = New Logus.Pesq_CodigoNome
        Me.SelecaoFilial = New Logus.Selecao
        Me.cmdExportaRelatorio = New Infragistics.Win.Misc.UltraButton
        CType(Me.txtDiasVencer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorArroba, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(12, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(153, 16)
        Me.Label9.TabIndex = 297
        Me.Label9.Text = "Fornecedor"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(748, 44)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 295
        Me.cmdFechar.Text = "F"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdImprimir.Location = New System.Drawing.Point(647, 44)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(45, 45)
        Me.cmdImprimir.TabIndex = 294
        Me.cmdImprimir.Text = "I"
        '
        'crvMain
        '
        Me.crvMain.ActiveViewIndex = -1
        Me.crvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvMain.Location = New System.Drawing.Point(12, 95)
        Me.crvMain.Name = "crvMain"
        Me.crvMain.SelectionFormula = ""
        Me.crvMain.ShowCloseButton = False
        Me.crvMain.ShowGroupTreeButton = False
        Me.crvMain.ShowRefreshButton = False
        Me.crvMain.Size = New System.Drawing.Size(401, 369)
        Me.crvMain.TabIndex = 293
        Me.crvMain.ViewTimeSelectionFormula = ""
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 13)
        Me.Label7.TabIndex = 291
        Me.Label7.Text = "Filial"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(319, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 299
        Me.Label1.Text = "Safra"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(319, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 301
        Me.Label2.Text = "Opções"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(564, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 304
        Me.Label3.Text = "Dias a Vencer"
        '
        'txtDiasVencer
        '
        Me.txtDiasVencer.Location = New System.Drawing.Point(567, 24)
        Me.txtDiasVencer.MaxValue = 99
        Me.txtDiasVencer.MinValue = 0
        Me.txtDiasVencer.Name = "txtDiasVencer"
        Me.txtDiasVencer.Size = New System.Drawing.Size(74, 21)
        Me.txtDiasVencer.TabIndex = 303
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(564, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 306
        Me.Label4.Text = "Valor @"
        '
        'txtValorArroba
        '
        Me.txtValorArroba.Location = New System.Drawing.Point(567, 68)
        Me.txtValorArroba.MaskInput = "{LOC}nnn.nn"
        Me.txtValorArroba.MaxValue = 999
        Me.txtValorArroba.MinValue = 0
        Me.txtValorArroba.Name = "txtValorArroba"
        Me.txtValorArroba.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtValorArroba.Size = New System.Drawing.Size(42, 21)
        Me.txtValorArroba.TabIndex = 305
        '
        'cmdAtualizar
        '
        Appearance8.Image = Global.Logus.My.Resources.Resources.replace2
        Me.cmdAtualizar.Appearance = Appearance8
        Me.cmdAtualizar.ImageSize = New System.Drawing.Size(20, 20)
        Me.cmdAtualizar.Location = New System.Drawing.Point(615, 61)
        Me.cmdAtualizar.Name = "cmdAtualizar"
        Me.cmdAtualizar.Size = New System.Drawing.Size(28, 28)
        Me.cmdAtualizar.TabIndex = 307
        Me.cmdAtualizar.TabStop = False
        '
        'SelecaoOpcao
        '
        Me.SelecaoOpcao.BackColor = System.Drawing.Color.White
        Me.SelecaoOpcao.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoOpcao.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoOpcao.BancoDados_Campo_OrdenarConsulta = True
        Me.SelecaoOpcao.BancoDados_Tabela = Nothing
        Me.SelecaoOpcao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoOpcao.Location = New System.Drawing.Point(319, 70)
        Me.SelecaoOpcao.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoOpcao.MultiplaSelecao = False
        Me.SelecaoOpcao.Name = "SelecaoOpcao"
        Me.SelecaoOpcao.Size = New System.Drawing.Size(233, 19)
        Me.SelecaoOpcao.TabIndex = 302
        '
        'SelecaoSafra
        '
        Me.SelecaoSafra.BackColor = System.Drawing.Color.White
        Me.SelecaoSafra.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoSafra.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoSafra.BancoDados_Campo_OrdenarConsulta = True
        Me.SelecaoSafra.BancoDados_Tabela = Nothing
        Me.SelecaoSafra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoSafra.Location = New System.Drawing.Point(319, 26)
        Me.SelecaoSafra.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoSafra.MultiplaSelecao = False
        Me.SelecaoSafra.Name = "SelecaoSafra"
        Me.SelecaoSafra.Size = New System.Drawing.Size(233, 19)
        Me.SelecaoSafra.TabIndex = 300
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
        Me.Pesq_Fornecedor.Location = New System.Drawing.Point(12, 61)
        Me.Pesq_Fornecedor.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_Fornecedor.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_Fornecedor.Name = "Pesq_Fornecedor"
        Me.Pesq_Fornecedor.Size = New System.Drawing.Size(297, 28)
        Me.Pesq_Fornecedor.TabIndex = 296
        Me.Pesq_Fornecedor.TelaFiltro = False
        Me.Pesq_Fornecedor.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'SelecaoFilial
        '
        Me.SelecaoFilial.BackColor = System.Drawing.Color.White
        Me.SelecaoFilial.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoFilial.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoFilial.BancoDados_Campo_OrdenarConsulta = True
        Me.SelecaoFilial.BancoDados_Tabela = Nothing
        Me.SelecaoFilial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoFilial.Location = New System.Drawing.Point(12, 26)
        Me.SelecaoFilial.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoFilial.MultiplaSelecao = False
        Me.SelecaoFilial.Name = "SelecaoFilial"
        Me.SelecaoFilial.Size = New System.Drawing.Size(300, 19)
        Me.SelecaoFilial.TabIndex = 292
        '
        'cmdExportaRelatorio
        '
        Me.cmdExportaRelatorio.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExportaRelatorio.Location = New System.Drawing.Point(697, 44)
        Me.cmdExportaRelatorio.Name = "cmdExportaRelatorio"
        Me.cmdExportaRelatorio.Size = New System.Drawing.Size(45, 45)
        Me.cmdExportaRelatorio.TabIndex = 493
        Me.cmdExportaRelatorio.Text = "ER"
        '
        'frmREL_Posicao_Contrato
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 581)
        Me.Controls.Add(Me.cmdExportaRelatorio)
        Me.Controls.Add(Me.cmdAtualizar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtValorArroba)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDiasVencer)
        Me.Controls.Add(Me.SelecaoOpcao)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.SelecaoSafra)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Pesq_Fornecedor)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.crvMain)
        Me.Controls.Add(Me.SelecaoFilial)
        Me.Controls.Add(Me.Label7)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmREL_Posicao_Contrato"
        Me.Text = "Relatório Posição Contratos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.txtDiasVencer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorArroba, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Pesq_Fornecedor As Logus.Pesq_CodigoNome
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdImprimir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents crvMain As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents SelecaoFilial As Logus.Selecao
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents SelecaoSafra As Logus.Selecao
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SelecaoOpcao As Logus.Selecao
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDiasVencer As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtValorArroba As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents cmdAtualizar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdExportaRelatorio As Infragistics.Win.Misc.UltraButton
End Class
