<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmREL_SEC_Usuario_Acesso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmREL_SEC_Usuario_Acesso))
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboGrupoAcesso = New System.Windows.Forms.ComboBox
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdImprimir = New Infragistics.Win.Misc.UltraButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboTipoAcao = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboTipoAcesso = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboGrupoMenu = New System.Windows.Forms.ComboBox
        Me.crvMain = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.txtNomeUsuario = New System.Windows.Forms.TextBox
        Me.txtCodigoUsuario = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboTipoOrigemAcesso = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboStatusAcesso = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboAcesso = New System.Windows.Forms.ComboBox
        Me.cmdExportaRelatorio = New Infragistics.Win.Misc.UltraButton
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(7, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 16)
        Me.Label4.TabIndex = 94
        Me.Label4.Text = "Grupo Acesso"
        '
        'cboGrupoAcesso
        '
        Me.cboGrupoAcesso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGrupoAcesso.Location = New System.Drawing.Point(7, 105)
        Me.cboGrupoAcesso.Name = "cboGrupoAcesso"
        Me.cboGrupoAcesso.Size = New System.Drawing.Size(297, 21)
        Me.cboGrupoAcesso.TabIndex = 93
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(627, 121)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 92
        Me.cmdFechar.Text = "F"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdImprimir.Location = New System.Drawing.Point(571, 121)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(45, 45)
        Me.cmdImprimir.TabIndex = 91
        Me.cmdImprimir.Text = "I"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(444, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 16)
        Me.Label3.TabIndex = 90
        Me.Label3.Text = "Tipo de Ação"
        '
        'cboTipoAcao
        '
        Me.cboTipoAcao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoAcao.Location = New System.Drawing.Point(441, 23)
        Me.cboTipoAcao.Name = "cboTipoAcao"
        Me.cboTipoAcao.Size = New System.Drawing.Size(115, 21)
        Me.cboTipoAcao.TabIndex = 89
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(319, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 16)
        Me.Label2.TabIndex = 88
        Me.Label2.Text = "Tipo de Acesso"
        '
        'cboTipoAcesso
        '
        Me.cboTipoAcesso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoAcesso.Location = New System.Drawing.Point(319, 105)
        Me.cboTipoAcesso.Name = "cboTipoAcesso"
        Me.cboTipoAcesso.Size = New System.Drawing.Size(115, 21)
        Me.cboTipoAcesso.TabIndex = 87
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(7, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 16)
        Me.Label1.TabIndex = 86
        Me.Label1.Text = "Grupo de Menu"
        '
        'cboGrupoMenu
        '
        Me.cboGrupoMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGrupoMenu.Location = New System.Drawing.Point(7, 62)
        Me.cboGrupoMenu.Name = "cboGrupoMenu"
        Me.cboGrupoMenu.Size = New System.Drawing.Size(297, 21)
        Me.cboGrupoMenu.TabIndex = 85
        '
        'crvMain
        '
        Me.crvMain.ActiveViewIndex = -1
        Me.crvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvMain.Location = New System.Drawing.Point(7, 172)
        Me.crvMain.Name = "crvMain"
        Me.crvMain.SelectionFormula = ""
        Me.crvMain.ShowCloseButton = False
        Me.crvMain.ShowGroupTreeButton = False
        Me.crvMain.ShowRefreshButton = False
        Me.crvMain.Size = New System.Drawing.Size(401, 369)
        Me.crvMain.TabIndex = 84
        Me.crvMain.ViewTimeSelectionFormula = ""
        '
        'txtNomeUsuario
        '
        Me.txtNomeUsuario.Enabled = False
        Me.txtNomeUsuario.Location = New System.Drawing.Point(137, 23)
        Me.txtNomeUsuario.Name = "txtNomeUsuario"
        Me.txtNomeUsuario.Size = New System.Drawing.Size(297, 20)
        Me.txtNomeUsuario.TabIndex = 97
        '
        'txtCodigoUsuario
        '
        Me.txtCodigoUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoUsuario.Location = New System.Drawing.Point(7, 23)
        Me.txtCodigoUsuario.Name = "txtCodigoUsuario"
        Me.txtCodigoUsuario.Size = New System.Drawing.Size(122, 20)
        Me.txtCodigoUsuario.TabIndex = 96
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(137, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 98
        Me.Label5.Text = "Nome do Usuário"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 13)
        Me.Label6.TabIndex = 95
        Me.Label6.Text = "Código do Usuário"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(316, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(152, 16)
        Me.Label7.TabIndex = 102
        Me.Label7.Text = "Tipo de Origem do Acesso"
        '
        'cboTipoOrigemAcesso
        '
        Me.cboTipoOrigemAcesso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoOrigemAcesso.Location = New System.Drawing.Point(319, 62)
        Me.cboTipoOrigemAcesso.Name = "cboTipoOrigemAcesso"
        Me.cboTipoOrigemAcesso.Size = New System.Drawing.Size(237, 21)
        Me.cboTipoOrigemAcesso.TabIndex = 101
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(441, 86)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 16)
        Me.Label8.TabIndex = 100
        Me.Label8.Text = "Estado do Acesso"
        '
        'cboStatusAcesso
        '
        Me.cboStatusAcesso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatusAcesso.Location = New System.Drawing.Point(441, 105)
        Me.cboStatusAcesso.Name = "cboStatusAcesso"
        Me.cboStatusAcesso.Size = New System.Drawing.Size(115, 21)
        Me.cboStatusAcesso.TabIndex = 99
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(7, 129)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 16)
        Me.Label9.TabIndex = 104
        Me.Label9.Text = "Acesso"
        '
        'cboAcesso
        '
        Me.cboAcesso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAcesso.Location = New System.Drawing.Point(7, 145)
        Me.cboAcesso.Name = "cboAcesso"
        Me.cboAcesso.Size = New System.Drawing.Size(549, 21)
        Me.cboAcesso.TabIndex = 103
        '
        'cmdExportaRelatorio
        '
        Me.cmdExportaRelatorio.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExportaRelatorio.Location = New System.Drawing.Point(571, 71)
        Me.cmdExportaRelatorio.Name = "cmdExportaRelatorio"
        Me.cmdExportaRelatorio.Size = New System.Drawing.Size(45, 45)
        Me.cmdExportaRelatorio.TabIndex = 493
        Me.cmdExportaRelatorio.Text = "ER"
        '
        'frmREL_SEC_Usuario_Acesso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(750, 565)
        Me.Controls.Add(Me.cmdExportaRelatorio)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboAcesso)
        Me.Controls.Add(Me.cboTipoOrigemAcesso)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboStatusAcesso)
        Me.Controls.Add(Me.txtNomeUsuario)
        Me.Controls.Add(Me.txtCodigoUsuario)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
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
        Me.Controls.Add(Me.Label7)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmREL_SEC_Usuario_Acesso"
        Me.Text = "Relatório de Acesso por Usuário"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboGrupoAcesso As System.Windows.Forms.ComboBox
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdImprimir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboTipoAcao As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboTipoAcesso As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboGrupoMenu As System.Windows.Forms.ComboBox
    Friend WithEvents crvMain As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents txtNomeUsuario As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboTipoOrigemAcesso As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboStatusAcesso As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboAcesso As System.Windows.Forms.ComboBox
    Friend WithEvents cmdExportaRelatorio As Infragistics.Win.Misc.UltraButton
End Class
