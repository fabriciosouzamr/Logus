<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmREL_UmidadeMedia
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
        Me.cmdExportaRelatorio = New Infragistics.Win.Misc.UltraButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtData = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdImprimir = New Infragistics.Win.Misc.UltraButton
        Me.crvMain = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdExportaRelatorio
        '
        Me.cmdExportaRelatorio.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExportaRelatorio.Location = New System.Drawing.Point(614, 12)
        Me.cmdExportaRelatorio.Name = "cmdExportaRelatorio"
        Me.cmdExportaRelatorio.Size = New System.Drawing.Size(45, 45)
        Me.cmdExportaRelatorio.TabIndex = 497
        Me.cmdExportaRelatorio.Text = "ER"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtData)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(93, 49)
        Me.GroupBox1.TabIndex = 496
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Data"
        '
        'txtData
        '
        Me.txtData.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtData.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtData.Location = New System.Drawing.Point(10, 17)
        Me.txtData.MaskInput = "{LOC} mm/yyyy"
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(75, 23)
        Me.txtData.TabIndex = 225
        Me.txtData.Value = Nothing
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(665, 12)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 495
        Me.cmdFechar.Text = "F"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdImprimir.Location = New System.Drawing.Point(563, 12)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(45, 45)
        Me.cmdImprimir.TabIndex = 494
        Me.cmdImprimir.Text = "I"
        '
        'crvMain
        '
        Me.crvMain.ActiveViewIndex = -1
        Me.crvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvMain.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.crvMain.Location = New System.Drawing.Point(8, 65)
        Me.crvMain.Name = "crvMain"
        Me.crvMain.SelectionFormula = ""
        Me.crvMain.ShowCloseButton = False
        Me.crvMain.ShowGroupTreeButton = False
        Me.crvMain.ShowRefreshButton = False
        Me.crvMain.Size = New System.Drawing.Size(702, 553)
        Me.crvMain.TabIndex = 493
        Me.crvMain.ViewTimeSelectionFormula = ""
        '
        'frmREL_UmidadeMedia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(838, 630)
        Me.Controls.Add(Me.cmdExportaRelatorio)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.crvMain)
        Me.Name = "frmREL_UmidadeMedia"
        Me.Text = "Relatório de Umidade Média"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdExportaRelatorio As Infragistics.Win.Misc.UltraButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtData As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdImprimir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents crvMain As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
