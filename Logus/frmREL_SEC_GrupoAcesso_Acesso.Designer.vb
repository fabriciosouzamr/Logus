<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmREL_SEC_GrupoAcesso_Acesso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmREL_SEC_GrupoAcesso_Acesso))
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdImprimir = New Infragistics.Win.Misc.UltraButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboTipoAcao = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboTipoAcesso = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboGrupoMenu = New System.Windows.Forms.ComboBox
        Me.crvMain = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboGrupoAcesso = New System.Windows.Forms.ComboBox
        Me.cmdExportaRelatorio = New Infragistics.Win.Misc.UltraButton
        Me.SuspendLayout()
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(547, 41)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 81
        Me.cmdFechar.Text = "F"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdImprimir.Location = New System.Drawing.Point(445, 41)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(45, 45)
        Me.cmdImprimir.TabIndex = 80
        Me.cmdImprimir.Text = "I"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(327, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 16)
        Me.Label3.TabIndex = 79
        Me.Label3.Text = "Tipo de A��o"
        '
        'cboTipoAcao
        '
        Me.cboTipoAcao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoAcao.Location = New System.Drawing.Point(324, 22)
        Me.cboTipoAcao.Name = "cboTipoAcao"
        Me.cboTipoAcao.Size = New System.Drawing.Size(115, 21)
        Me.cboTipoAcao.TabIndex = 78
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(324, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 16)
        Me.Label2.TabIndex = 77
        Me.Label2.Text = "Tipo de Acesso"
        '
        'cboTipoAcesso
        '
        Me.cboTipoAcesso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoAcesso.Location = New System.Drawing.Point(324, 65)
        Me.cboTipoAcesso.Name = "cboTipoAcesso"
        Me.cboTipoAcesso.Size = New System.Drawing.Size(115, 21)
        Me.cboTipoAcesso.TabIndex = 76
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 16)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "Grupo de Menu"
        '
        'cboGrupoMenu
        '
        Me.cboGrupoMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGrupoMenu.Location = New System.Drawing.Point(12, 22)
        Me.cboGrupoMenu.Name = "cboGrupoMenu"
        Me.cboGrupoMenu.Size = New System.Drawing.Size(297, 21)
        Me.cboGrupoMenu.TabIndex = 74
        '
        'crvMain
        '
        Me.crvMain.ActiveViewIndex = -1
        Me.crvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvMain.Location = New System.Drawing.Point(12, 92)
        Me.crvMain.Name = "crvMain"
        Me.crvMain.SelectionFormula = ""
        Me.crvMain.ShowCloseButton = False
        Me.crvMain.ShowGroupTreeButton = False
        Me.crvMain.ShowRefreshButton = False
        Me.crvMain.Size = New System.Drawing.Size(401, 369)
        Me.crvMain.TabIndex = 73
        Me.crvMain.ViewTimeSelectionFormula = ""
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(12, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 16)
        Me.Label4.TabIndex = 83
        Me.Label4.Text = "Grupo Acesso"
        '
        'cboGrupoAcesso
        '
        Me.cboGrupoAcesso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGrupoAcesso.Location = New System.Drawing.Point(12, 65)
        Me.cboGrupoAcesso.Name = "cboGrupoAcesso"
        Me.cboGrupoAcesso.Size = New System.Drawing.Size(297, 21)
        Me.cboGrupoAcesso.TabIndex = 82
        '
        'cmdExportaRelatorio
        '
        Me.cmdExportaRelatorio.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExportaRelatorio.Location = New System.Drawing.Point(496, 41)
        Me.cmdExportaRelatorio.Name = "cmdExportaRelatorio"
        Me.cmdExportaRelatorio.Size = New System.Drawing.Size(45, 45)
        Me.cmdExportaRelatorio.TabIndex = 493
        Me.cmdExportaRelatorio.Text = "ER"
        '
        'frmREL_SEC_GrupoAcesso_Acesso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(699, 659)
        Me.Controls.Add(Me.cmdExportaRelatorio)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboGrupoAcesso)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboTipoAcao)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboTipoAcesso)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboGrupoMenu)
        Me.Controls.Add(Me.crvMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmREL_SEC_GrupoAcesso_Acesso"
        Me.Text = "Relat�rio de Acesso por Grupo de Acesso"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdImprimir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboTipoAcao As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboTipoAcesso As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboGrupoMenu As System.Windows.Forms.ComboBox
    Friend WithEvents crvMain As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboGrupoAcesso As System.Windows.Forms.ComboBox
    Friend WithEvents cmdExportaRelatorio As Infragistics.Win.Misc.UltraButton
End Class
