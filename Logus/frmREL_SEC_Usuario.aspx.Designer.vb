<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmREL_SEC_Usuario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmREL_SEC_Usuario))
        Me.txtNomeUsuario = New System.Windows.Forms.TextBox
        Me.txtCodigoUsuario = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdImprimir = New Infragistics.Win.Misc.UltraButton
        Me.crvMain = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.chkUsuarioAtivo = New System.Windows.Forms.CheckBox
        Me.chkListarSetoresLiberados = New System.Windows.Forms.CheckBox
        Me.cmdExportaRelatorio = New Infragistics.Win.Misc.UltraButton
        Me.SuspendLayout()
        '
        'txtNomeUsuario
        '
        Me.txtNomeUsuario.Enabled = False
        Me.txtNomeUsuario.Location = New System.Drawing.Point(135, 20)
        Me.txtNomeUsuario.Name = "txtNomeUsuario"
        Me.txtNomeUsuario.Size = New System.Drawing.Size(297, 20)
        Me.txtNomeUsuario.TabIndex = 104
        '
        'txtCodigoUsuario
        '
        Me.txtCodigoUsuario.Location = New System.Drawing.Point(5, 20)
        Me.txtCodigoUsuario.Name = "txtCodigoUsuario"
        Me.txtCodigoUsuario.Size = New System.Drawing.Size(122, 20)
        Me.txtCodigoUsuario.TabIndex = 103
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(135, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 105
        Me.Label5.Text = "Nome do Usuário"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 13)
        Me.Label6.TabIndex = 102
        Me.Label6.Text = "Código do Usuário"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(537, 20)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 101
        Me.cmdFechar.Text = "F"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdImprimir.Location = New System.Drawing.Point(436, 20)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(45, 45)
        Me.cmdImprimir.TabIndex = 100
        Me.cmdImprimir.Text = "I"
        '
        'crvMain
        '
        Me.crvMain.ActiveViewIndex = -1
        Me.crvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvMain.Location = New System.Drawing.Point(5, 73)
        Me.crvMain.Name = "crvMain"
        Me.crvMain.SelectionFormula = ""
        Me.crvMain.ShowCloseButton = False
        Me.crvMain.ShowGroupTreeButton = False
        Me.crvMain.ShowRefreshButton = False
        Me.crvMain.Size = New System.Drawing.Size(401, 369)
        Me.crvMain.TabIndex = 99
        Me.crvMain.ViewTimeSelectionFormula = ""
        '
        'chkUsuarioAtivo
        '
        Me.chkUsuarioAtivo.AutoSize = True
        Me.chkUsuarioAtivo.Location = New System.Drawing.Point(5, 48)
        Me.chkUsuarioAtivo.Name = "chkUsuarioAtivo"
        Me.chkUsuarioAtivo.Size = New System.Drawing.Size(89, 17)
        Me.chkUsuarioAtivo.TabIndex = 134
        Me.chkUsuarioAtivo.Text = "Usuário Ativo"
        Me.chkUsuarioAtivo.UseVisualStyleBackColor = True
        '
        'chkListarSetoresLiberados
        '
        Me.chkListarSetoresLiberados.AutoSize = True
        Me.chkListarSetoresLiberados.Location = New System.Drawing.Point(135, 48)
        Me.chkListarSetoresLiberados.Name = "chkListarSetoresLiberados"
        Me.chkListarSetoresLiberados.Size = New System.Drawing.Size(139, 17)
        Me.chkListarSetoresLiberados.TabIndex = 135
        Me.chkListarSetoresLiberados.Text = "Listar Setores Liberadas"
        Me.chkListarSetoresLiberados.UseVisualStyleBackColor = True
        '
        'cmdExportaRelatorio
        '
        Me.cmdExportaRelatorio.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExportaRelatorio.Location = New System.Drawing.Point(487, 20)
        Me.cmdExportaRelatorio.Name = "cmdExportaRelatorio"
        Me.cmdExportaRelatorio.Size = New System.Drawing.Size(45, 45)
        Me.cmdExportaRelatorio.TabIndex = 493
        Me.cmdExportaRelatorio.Text = "ER"
        '
        'frmREL_SEC_Usuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(935, 689)
        Me.Controls.Add(Me.cmdExportaRelatorio)
        Me.Controls.Add(Me.chkListarSetoresLiberados)
        Me.Controls.Add(Me.chkUsuarioAtivo)
        Me.Controls.Add(Me.txtNomeUsuario)
        Me.Controls.Add(Me.txtCodigoUsuario)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.crvMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmREL_SEC_Usuario"
        Me.Text = "Relatório de Cadastro de Usuário"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNomeUsuario As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdImprimir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents crvMain As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents chkUsuarioAtivo As System.Windows.Forms.CheckBox
    Friend WithEvents chkListarSetoresLiberados As System.Windows.Forms.CheckBox
    Friend WithEvents cmdExportaRelatorio As Infragistics.Win.Misc.UltraButton
End Class
