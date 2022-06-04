<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRelatorioGeral
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRelatorioGeral))
        Me.imlIcone = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdBotao02 = New Infragistics.Win.Misc.UltraButton
        Me.cmdBotao03 = New Infragistics.Win.Misc.UltraButton
        Me.cmdBotao01 = New Infragistics.Win.Misc.UltraButton
        Me.cmdBotao04 = New Infragistics.Win.Misc.UltraButton
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdAtualizar = New Infragistics.Win.Misc.UltraButton
        Me.crvMain = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.cmdExportaRelatorio = New Infragistics.Win.Misc.UltraButton
        Me.SuspendLayout()
        '
        'imlIcone
        '
        Me.imlIcone.ImageStream = CType(resources.GetObject("imlIcone.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlIcone.TransparentColor = System.Drawing.Color.Transparent
        Me.imlIcone.Images.SetKeyName(0, "EnviarEMail.jpg")
        Me.imlIcone.Images.SetKeyName(1, "Contrato.gif")
        '
        'cmdBotao02
        '
        Me.cmdBotao02.AcceptsFocus = False
        Me.cmdBotao02.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdBotao02.Location = New System.Drawing.Point(207, 3)
        Me.cmdBotao02.Name = "cmdBotao02"
        Me.cmdBotao02.Size = New System.Drawing.Size(45, 45)
        Me.cmdBotao02.TabIndex = 237
        Me.cmdBotao02.Text = "BTN 02"
        '
        'cmdBotao03
        '
        Me.cmdBotao03.AcceptsFocus = False
        Me.cmdBotao03.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdBotao03.Location = New System.Drawing.Point(258, 3)
        Me.cmdBotao03.Name = "cmdBotao03"
        Me.cmdBotao03.Size = New System.Drawing.Size(45, 45)
        Me.cmdBotao03.TabIndex = 238
        Me.cmdBotao03.Text = "BTN 03"
        '
        'cmdBotao01
        '
        Me.cmdBotao01.AcceptsFocus = False
        Me.cmdBotao01.ImageList = Me.imlIcone
        Me.cmdBotao01.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdBotao01.Location = New System.Drawing.Point(156, 3)
        Me.cmdBotao01.Name = "cmdBotao01"
        Me.cmdBotao01.Size = New System.Drawing.Size(45, 45)
        Me.cmdBotao01.TabIndex = 236
        Me.cmdBotao01.Text = "BTN 01"
        '
        'cmdBotao04
        '
        Me.cmdBotao04.AcceptsFocus = False
        Me.cmdBotao04.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdBotao04.Location = New System.Drawing.Point(309, 3)
        Me.cmdBotao04.Name = "cmdBotao04"
        Me.cmdBotao04.Size = New System.Drawing.Size(45, 45)
        Me.cmdBotao04.TabIndex = 239
        Me.cmdBotao04.Text = "BTN 04"
        '
        'cmdFechar
        '
        Me.cmdFechar.AcceptsFocus = False
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(105, 3)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 235
        Me.cmdFechar.Text = "F"
        '
        'cmdAtualizar
        '
        Me.cmdAtualizar.AcceptsFocus = False
        Me.cmdAtualizar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdAtualizar.Location = New System.Drawing.Point(1, 3)
        Me.cmdAtualizar.Name = "cmdAtualizar"
        Me.cmdAtualizar.Size = New System.Drawing.Size(45, 45)
        Me.cmdAtualizar.TabIndex = 240
        Me.cmdAtualizar.Text = "A"
        '
        'crvMain
        '
        Me.crvMain.ActiveViewIndex = -1
        Me.crvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvMain.Location = New System.Drawing.Point(1, 54)
        Me.crvMain.Name = "crvMain"
        Me.crvMain.SelectionFormula = ""
        Me.crvMain.ShowRefreshButton = False
        Me.crvMain.Size = New System.Drawing.Size(1015, 551)
        Me.crvMain.TabIndex = 255
        Me.crvMain.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.crvMain.ViewTimeSelectionFormula = ""
        '
        'cmdExportaRelatorio
        '
        Me.cmdExportaRelatorio.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExportaRelatorio.Location = New System.Drawing.Point(52, 3)
        Me.cmdExportaRelatorio.Name = "cmdExportaRelatorio"
        Me.cmdExportaRelatorio.Size = New System.Drawing.Size(45, 45)
        Me.cmdExportaRelatorio.TabIndex = 493
        Me.cmdExportaRelatorio.Text = "ER"
        '
        'frmRelatorioGeral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 663)
        Me.Controls.Add(Me.crvMain)
        Me.Controls.Add(Me.cmdExportaRelatorio)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdAtualizar)
        Me.Controls.Add(Me.cmdBotao02)
        Me.Controls.Add(Me.cmdBotao03)
        Me.Controls.Add(Me.cmdBotao04)
        Me.Controls.Add(Me.cmdBotao01)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRelatorioGeral"
        Me.Text = "frmRelatorioGeral"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents imlIcone As System.Windows.Forms.ImageList
    Friend WithEvents cmdBotao02 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdBotao03 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdBotao01 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdBotao04 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdAtualizar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents crvMain As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents cmdExportaRelatorio As Infragistics.Win.Misc.UltraButton
End Class
