<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmREL_Transferencia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmREL_Transferencia))
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtDataFinal = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtDataInicial = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.grdData = New System.Windows.Forms.GroupBox
        Me.optUtilizarDataChegadaTransferencia = New System.Windows.Forms.RadioButton
        Me.optUtilizarDataCriacaoTransferencia = New System.Windows.Forms.RadioButton
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdImprimir = New Infragistics.Win.Misc.UltraButton
        Me.crvMain = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SelecaoFilialDestino = New Logus.Selecao
        Me.SelecaoFilialOrigem = New Logus.Selecao
        Me.cmdExportaRelatorio = New Infragistics.Win.Misc.UltraButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.SelecaoOpcao = New Logus.Selecao
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtDataFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grdData.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Filial de Origem"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDataFinal)
        Me.GroupBox1.Controls.Add(Me.txtDataInicial)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(235, 49)
        Me.GroupBox1.TabIndex = 229
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Período"
        '
        'txtDataFinal
        '
        Me.txtDataFinal.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataFinal.Location = New System.Drawing.Point(122, 17)
        Me.txtDataFinal.Name = "txtDataFinal"
        Me.txtDataFinal.Size = New System.Drawing.Size(104, 23)
        Me.txtDataFinal.TabIndex = 226
        Me.txtDataFinal.Value = Nothing
        '
        'txtDataInicial
        '
        Me.txtDataInicial.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataInicial.Location = New System.Drawing.Point(10, 17)
        Me.txtDataInicial.Name = "txtDataInicial"
        Me.txtDataInicial.Size = New System.Drawing.Size(104, 23)
        Me.txtDataInicial.TabIndex = 225
        Me.txtDataInicial.Value = Nothing
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(335, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 230
        Me.Label2.Text = "Filial de Destino"
        '
        'grdData
        '
        Me.grdData.Controls.Add(Me.optUtilizarDataChegadaTransferencia)
        Me.grdData.Controls.Add(Me.optUtilizarDataCriacaoTransferencia)
        Me.grdData.Location = New System.Drawing.Point(248, 48)
        Me.grdData.Name = "grdData"
        Me.grdData.Size = New System.Drawing.Size(234, 49)
        Me.grdData.TabIndex = 232
        Me.grdData.TabStop = False
        Me.grdData.Text = "Data"
        '
        'optUtilizarDataChegadaTransferencia
        '
        Me.optUtilizarDataChegadaTransferencia.AutoSize = True
        Me.optUtilizarDataChegadaTransferencia.Location = New System.Drawing.Point(10, 28)
        Me.optUtilizarDataChegadaTransferencia.Name = "optUtilizarDataChegadaTransferencia"
        Me.optUtilizarDataChegadaTransferencia.Size = New System.Drawing.Size(151, 17)
        Me.optUtilizarDataChegadaTransferencia.TabIndex = 1
        Me.optUtilizarDataChegadaTransferencia.Text = "Chegada da Transferência"
        Me.optUtilizarDataChegadaTransferencia.UseVisualStyleBackColor = True
        '
        'optUtilizarDataCriacaoTransferencia
        '
        Me.optUtilizarDataCriacaoTransferencia.AutoSize = True
        Me.optUtilizarDataCriacaoTransferencia.Checked = True
        Me.optUtilizarDataCriacaoTransferencia.Location = New System.Drawing.Point(10, 13)
        Me.optUtilizarDataCriacaoTransferencia.Name = "optUtilizarDataCriacaoTransferencia"
        Me.optUtilizarDataCriacaoTransferencia.Size = New System.Drawing.Size(144, 17)
        Me.optUtilizarDataCriacaoTransferencia.TabIndex = 0
        Me.optUtilizarDataCriacaoTransferencia.TabStop = True
        Me.optUtilizarDataCriacaoTransferencia.Text = "Criação da Transferência"
        Me.optUtilizarDataCriacaoTransferencia.UseVisualStyleBackColor = True
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(705, 52)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 234
        Me.cmdFechar.Text = "F"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdImprimir.Location = New System.Drawing.Point(654, 52)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(45, 45)
        Me.cmdImprimir.TabIndex = 233
        Me.cmdImprimir.Text = "I"
        '
        'crvMain
        '
        Me.crvMain.ActiveViewIndex = -1
        Me.crvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvMain.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.crvMain.Location = New System.Drawing.Point(5, 105)
        Me.crvMain.Name = "crvMain"
        Me.crvMain.SelectionFormula = ""
        Me.crvMain.ShowCloseButton = False
        Me.crvMain.ShowGroupTreeButton = False
        Me.crvMain.ShowRefreshButton = False
        Me.crvMain.Size = New System.Drawing.Size(745, 506)
        Me.crvMain.TabIndex = 235
        Me.crvMain.ViewTimeSelectionFormula = ""
        '
        'SelecaoFilialDestino
        '
        Me.SelecaoFilialDestino.BackColor = System.Drawing.Color.White
        Me.SelecaoFilialDestino.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoFilialDestino.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoFilialDestino.BancoDados_Campo_OrdenarConsulta = True
        Me.SelecaoFilialDestino.BancoDados_Tabela = Nothing
        Me.SelecaoFilialDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoFilialDestino.Location = New System.Drawing.Point(335, 20)
        Me.SelecaoFilialDestino.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoFilialDestino.MultiplaSelecao = False
        Me.SelecaoFilialDestino.MultiplaSelecao_Codigo_Tipo = Logus.Selecao.enMultiplaSelecao_Codigo_Tipo.Numero
        Me.SelecaoFilialDestino.Name = "SelecaoFilialDestino"
        Me.SelecaoFilialDestino.Size = New System.Drawing.Size(322, 20)
        Me.SelecaoFilialDestino.TabIndex = 231
        '
        'SelecaoFilialOrigem
        '
        Me.SelecaoFilialOrigem.BackColor = System.Drawing.Color.White
        Me.SelecaoFilialOrigem.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoFilialOrigem.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoFilialOrigem.BancoDados_Campo_OrdenarConsulta = True
        Me.SelecaoFilialOrigem.BancoDados_Tabela = Nothing
        Me.SelecaoFilialOrigem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoFilialOrigem.Location = New System.Drawing.Point(5, 20)
        Me.SelecaoFilialOrigem.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoFilialOrigem.MultiplaSelecao = False
        Me.SelecaoFilialOrigem.MultiplaSelecao_Codigo_Tipo = Logus.Selecao.enMultiplaSelecao_Codigo_Tipo.Numero
        Me.SelecaoFilialOrigem.Name = "SelecaoFilialOrigem"
        Me.SelecaoFilialOrigem.Size = New System.Drawing.Size(322, 20)
        Me.SelecaoFilialOrigem.TabIndex = 180
        '
        'cmdExportaRelatorio
        '
        Me.cmdExportaRelatorio.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExportaRelatorio.Location = New System.Drawing.Point(705, 1)
        Me.cmdExportaRelatorio.Name = "cmdExportaRelatorio"
        Me.cmdExportaRelatorio.Size = New System.Drawing.Size(45, 45)
        Me.cmdExportaRelatorio.TabIndex = 493
        Me.cmdExportaRelatorio.Text = "ER"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(490, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 230
        Me.Label3.Text = "Opções"
        '
        'SelecaoOpcao
        '
        Me.SelecaoOpcao.BackColor = System.Drawing.Color.White
        Me.SelecaoOpcao.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoOpcao.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoOpcao.BancoDados_Campo_OrdenarConsulta = True
        Me.SelecaoOpcao.BancoDados_Tabela = Nothing
        Me.SelecaoOpcao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoOpcao.Location = New System.Drawing.Point(490, 62)
        Me.SelecaoOpcao.MinimumSize = New System.Drawing.Size(150, 2)
        Me.SelecaoOpcao.MultiplaSelecao = False
        Me.SelecaoOpcao.MultiplaSelecao_Codigo_Tipo = Logus.Selecao.enMultiplaSelecao_Codigo_Tipo.Numero
        Me.SelecaoOpcao.Name = "SelecaoOpcao"
        Me.SelecaoOpcao.Size = New System.Drawing.Size(157, 20)
        Me.SelecaoOpcao.TabIndex = 231
        '
        'frmREL_Transferencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 616)
        Me.Controls.Add(Me.cmdExportaRelatorio)
        Me.Controls.Add(Me.crvMain)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.grdData)
        Me.Controls.Add(Me.SelecaoOpcao)
        Me.Controls.Add(Me.SelecaoFilialDestino)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.SelecaoFilialOrigem)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmREL_Transferencia"
        Me.Text = "Relatório de Transferência"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtDataFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataInicial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grdData.ResumeLayout(False)
        Me.grdData.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SelecaoFilialOrigem As Logus.Selecao
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDataFinal As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtDataInicial As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents SelecaoFilialDestino As Logus.Selecao
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grdData As System.Windows.Forms.GroupBox
    Friend WithEvents optUtilizarDataChegadaTransferencia As System.Windows.Forms.RadioButton
    Friend WithEvents optUtilizarDataCriacaoTransferencia As System.Windows.Forms.RadioButton
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdImprimir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents crvMain As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents cmdExportaRelatorio As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SelecaoOpcao As Logus.Selecao
End Class
