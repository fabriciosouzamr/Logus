<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRelatorioGeral_FilialPeriodo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRelatorioGeral_FilialPeriodo))
        Me.Label1 = New System.Windows.Forms.Label
        Me.grpPeriodo = New System.Windows.Forms.GroupBox
        Me.txtDataFinal = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtDataInicial = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.lblSelecao01 = New System.Windows.Forms.Label
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdImprimir = New Infragistics.Win.Misc.UltraButton
        Me.crvMain = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Selecao01 = New Logus.Selecao
        Me.SelecaoFilial = New Logus.Selecao
        Me.chkOpcao = New System.Windows.Forms.CheckBox
        Me.cmdExportaRelatorio = New Infragistics.Win.Misc.UltraButton
        Me.grpPeriodo.SuspendLayout()
        CType(Me.txtDataFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Filial"
        '
        'grpPeriodo
        '
        Me.grpPeriodo.Controls.Add(Me.txtDataFinal)
        Me.grpPeriodo.Controls.Add(Me.txtDataInicial)
        Me.grpPeriodo.Location = New System.Drawing.Point(263, 5)
        Me.grpPeriodo.Name = "grpPeriodo"
        Me.grpPeriodo.Size = New System.Drawing.Size(235, 49)
        Me.grpPeriodo.TabIndex = 229
        Me.grpPeriodo.TabStop = False
        Me.grpPeriodo.Text = "Período"
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
        Me.lblSelecao01.Location = New System.Drawing.Point(5, 48)
        Me.lblSelecao01.Name = "lblSelecao01"
        Me.lblSelecao01.Size = New System.Drawing.Size(68, 13)
        Me.lblSelecao01.TabIndex = 230
        Me.lblSelecao01.Text = "lblSelecao01"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(606, 5)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 255
        Me.cmdFechar.Text = "F"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdImprimir.Location = New System.Drawing.Point(505, 5)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(45, 45)
        Me.cmdImprimir.TabIndex = 254
        Me.cmdImprimir.Text = "I"
        '
        'crvMain
        '
        Me.crvMain.ActiveViewIndex = -1
        Me.crvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvMain.Location = New System.Drawing.Point(5, 89)
        Me.crvMain.Name = "crvMain"
        Me.crvMain.ShowCloseButton = False
        Me.crvMain.ShowGroupTreeButton = False
        Me.crvMain.ShowRefreshButton = False
        Me.crvMain.Size = New System.Drawing.Size(630, 379)
        Me.crvMain.TabIndex = 256
        '
        'Selecao01
        '
        Me.Selecao01.BackColor = System.Drawing.Color.White
        Me.Selecao01.BancoDados_Campo_Codigo = Nothing
        Me.Selecao01.BancoDados_Campo_Descricao = Nothing
        Me.Selecao01.BancoDados_Tabela = Nothing
        Me.Selecao01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Selecao01.Location = New System.Drawing.Point(5, 63)
        Me.Selecao01.MinimumSize = New System.Drawing.Size(200, 2)
        Me.Selecao01.MultiplaSelecao = False
        Me.Selecao01.Name = "Selecao01"
        Me.Selecao01.Size = New System.Drawing.Size(493, 20)
        Me.Selecao01.TabIndex = 257
        '
        'SelecaoFilial
        '
        Me.SelecaoFilial.BackColor = System.Drawing.Color.White
        Me.SelecaoFilial.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoFilial.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoFilial.BancoDados_Tabela = Nothing
        Me.SelecaoFilial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoFilial.Location = New System.Drawing.Point(5, 20)
        Me.SelecaoFilial.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoFilial.MultiplaSelecao = False
        Me.SelecaoFilial.Name = "SelecaoFilial"
        Me.SelecaoFilial.Size = New System.Drawing.Size(250, 20)
        Me.SelecaoFilial.TabIndex = 180
        '
        'chkOpcao
        '
        Me.chkOpcao.AutoSize = True
        Me.chkOpcao.Location = New System.Drawing.Point(505, 66)
        Me.chkOpcao.Name = "chkOpcao"
        Me.chkOpcao.Size = New System.Drawing.Size(81, 17)
        Me.chkOpcao.TabIndex = 258
        Me.chkOpcao.Text = "CheckBox1"
        Me.chkOpcao.UseVisualStyleBackColor = True
        '
        'cmdExportaRelatorio
        '
        Me.cmdExportaRelatorio.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExportaRelatorio.Location = New System.Drawing.Point(556, 5)
        Me.cmdExportaRelatorio.Name = "cmdExportaRelatorio"
        Me.cmdExportaRelatorio.Size = New System.Drawing.Size(45, 45)
        Me.cmdExportaRelatorio.TabIndex = 493
        Me.cmdExportaRelatorio.Text = "ER"
        '
        'frmRelatorioGeral_FilialPeriodo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(655, 471)
        Me.Controls.Add(Me.cmdExportaRelatorio)
        Me.Controls.Add(Me.chkOpcao)
        Me.Controls.Add(Me.Selecao01)
        Me.Controls.Add(Me.crvMain)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.lblSelecao01)
        Me.Controls.Add(Me.grpPeriodo)
        Me.Controls.Add(Me.SelecaoFilial)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRelatorioGeral_FilialPeriodo"
        Me.Text = "frmRelatorioGeral_FilialPeriodo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grpPeriodo.ResumeLayout(False)
        Me.grpPeriodo.PerformLayout()
        CType(Me.txtDataFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataInicial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SelecaoFilial As Logus.Selecao
    Friend WithEvents grpPeriodo As System.Windows.Forms.GroupBox
    Friend WithEvents txtDataFinal As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtDataInicial As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents lblSelecao01 As System.Windows.Forms.Label
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdImprimir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents crvMain As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Selecao01 As Logus.Selecao
    Friend WithEvents chkOpcao As System.Windows.Forms.CheckBox
    Friend WithEvents cmdExportaRelatorio As Infragistics.Win.Misc.UltraButton
End Class
