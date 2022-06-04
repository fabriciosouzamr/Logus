<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmREL_Adiantamento_Em_Aberto
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmREL_Adiantamento_Em_Aberto))
        Me.crvMain = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdImprimir = New Infragistics.Win.Misc.UltraButton
        Me.SelecaoFilial = New Logus.Selecao
        Me.Label1 = New System.Windows.Forms.Label
        Me.optTipo = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboOpcao = New System.Windows.Forms.ComboBox
        Me.cmdExportaRelatorio = New Infragistics.Win.Misc.UltraButton
        CType(Me.optTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'crvMain
        '
        Me.crvMain.ActiveViewIndex = -1
        Me.crvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvMain.Location = New System.Drawing.Point(12, 94)
        Me.crvMain.Name = "crvMain"
        Me.crvMain.ShowCloseButton = False
        Me.crvMain.ShowParameterPanelButton = False
        Me.crvMain.ShowRefreshButton = False
        Me.crvMain.Size = New System.Drawing.Size(630, 379)
        Me.crvMain.TabIndex = 263
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(597, 43)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 262
        Me.cmdFechar.Text = "F"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdImprimir.Location = New System.Drawing.Point(498, 43)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(45, 45)
        Me.cmdImprimir.TabIndex = 261
        Me.cmdImprimir.Text = "I"
        '
        'SelecaoFilial
        '
        Me.SelecaoFilial.BackColor = System.Drawing.Color.White
        Me.SelecaoFilial.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoFilial.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoFilial.BancoDados_Tabela = Nothing
        Me.SelecaoFilial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoFilial.Location = New System.Drawing.Point(12, 25)
        Me.SelecaoFilial.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoFilial.MultiplaSelecao = False
        Me.SelecaoFilial.Name = "SelecaoFilial"
        Me.SelecaoFilial.Size = New System.Drawing.Size(250, 20)
        Me.SelecaoFilial.TabIndex = 259
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 258
        Me.Label1.Text = "Filial"
        '
        'optTipo
        '
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        Me.optTipo.Appearance = Appearance1
        Me.optTipo.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.optTipo.CheckedIndex = 0
        Appearance2.TextHAlignAsString = "Center"
        Appearance2.TextVAlignAsString = "Middle"
        Me.optTipo.ItemAppearance = Appearance2
        Me.optTipo.ItemOrigin = New System.Drawing.Point(2, 2)
        ValueListItem1.DataValue = "S"
        ValueListItem1.DisplayText = "Sintético"
        ValueListItem2.DataValue = "A"
        ValueListItem2.DisplayText = "Analítico"
        Me.optTipo.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2})
        Me.optTipo.Location = New System.Drawing.Point(277, 25)
        Me.optTipo.Name = "optTipo"
        Me.optTipo.Size = New System.Drawing.Size(144, 20)
        Me.optTipo.TabIndex = 296
        Me.optTipo.Text = "Sintético"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(126, 16)
        Me.Label3.TabIndex = 298
        Me.Label3.Text = "Opções"
        '
        'cboOpcao
        '
        Me.cboOpcao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOpcao.Location = New System.Drawing.Point(12, 67)
        Me.cboOpcao.Name = "cboOpcao"
        Me.cboOpcao.Size = New System.Drawing.Size(250, 21)
        Me.cboOpcao.TabIndex = 297
        '
        'cmdExportaRelatorio
        '
        Me.cmdExportaRelatorio.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExportaRelatorio.Location = New System.Drawing.Point(549, 43)
        Me.cmdExportaRelatorio.Name = "cmdExportaRelatorio"
        Me.cmdExportaRelatorio.Size = New System.Drawing.Size(45, 45)
        Me.cmdExportaRelatorio.TabIndex = 492
        Me.cmdExportaRelatorio.Text = "ER"
        '
        'frmREL_Adiantamento_Em_Aberto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(838, 599)
        Me.Controls.Add(Me.cmdExportaRelatorio)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboOpcao)
        Me.Controls.Add(Me.optTipo)
        Me.Controls.Add(Me.crvMain)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.SelecaoFilial)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmREL_Adiantamento_Em_Aberto"
        Me.Text = "Adiantamento em Aberto"
        CType(Me.optTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents crvMain As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdImprimir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents SelecaoFilial As Logus.Selecao
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents optTipo As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboOpcao As System.Windows.Forms.ComboBox
    Friend WithEvents cmdExportaRelatorio As Infragistics.Win.Misc.UltraButton
End Class
