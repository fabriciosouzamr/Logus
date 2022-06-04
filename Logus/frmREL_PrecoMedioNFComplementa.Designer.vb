<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmREL_PrecoMedioNFComplementa
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmREL_PrecoMedioNFComplementa))
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdImprimir = New Infragistics.Win.Misc.UltraButton
        Me.crvMain = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.lbl_Filial = New System.Windows.Forms.Label
        Me.lbl_dolar = New System.Windows.Forms.Label
        Me.txtTaxaDolar = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.cmdExportaRelatorio = New Infragistics.Win.Misc.UltraButton
        Me.SelecaoFilial = New Logus.Selecao
        Me.optTipo = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        CType(Me.txtTaxaDolar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(748, 2)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 300
        Me.cmdFechar.Text = "F"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdImprimir.Location = New System.Drawing.Point(646, 2)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(45, 45)
        Me.cmdImprimir.TabIndex = 299
        Me.cmdImprimir.Text = "I"
        '
        'crvMain
        '
        Me.crvMain.ActiveViewIndex = -1
        Me.crvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvMain.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.crvMain.Location = New System.Drawing.Point(8, 55)
        Me.crvMain.Name = "crvMain"
        Me.crvMain.ShowCloseButton = False
        Me.crvMain.ShowGroupTreeButton = False
        Me.crvMain.ShowRefreshButton = False
        Me.crvMain.Size = New System.Drawing.Size(401, 369)
        Me.crvMain.TabIndex = 298
        '
        'lbl_Filial
        '
        Me.lbl_Filial.AutoSize = True
        Me.lbl_Filial.Location = New System.Drawing.Point(103, 13)
        Me.lbl_Filial.Name = "lbl_Filial"
        Me.lbl_Filial.Size = New System.Drawing.Size(27, 13)
        Me.lbl_Filial.TabIndex = 296
        Me.lbl_Filial.Text = "Filial"
        '
        'lbl_dolar
        '
        Me.lbl_dolar.AutoSize = True
        Me.lbl_dolar.BackColor = System.Drawing.Color.Transparent
        Me.lbl_dolar.Location = New System.Drawing.Point(8, 8)
        Me.lbl_dolar.Name = "lbl_dolar"
        Me.lbl_dolar.Size = New System.Drawing.Size(59, 13)
        Me.lbl_dolar.TabIndex = 318
        Me.lbl_dolar.Text = "Taxa Dolar"
        '
        'txtTaxaDolar
        '
        Me.txtTaxaDolar.Location = New System.Drawing.Point(8, 28)
        Me.txtTaxaDolar.MaskInput = "{LOC}-n.nnnn"
        Me.txtTaxaDolar.Name = "txtTaxaDolar"
        Me.txtTaxaDolar.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtTaxaDolar.Size = New System.Drawing.Size(89, 21)
        Me.txtTaxaDolar.TabIndex = 317
        '
        'cmdExportaRelatorio
        '
        Me.cmdExportaRelatorio.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExportaRelatorio.Location = New System.Drawing.Point(697, 2)
        Me.cmdExportaRelatorio.Name = "cmdExportaRelatorio"
        Me.cmdExportaRelatorio.Size = New System.Drawing.Size(45, 45)
        Me.cmdExportaRelatorio.TabIndex = 493
        Me.cmdExportaRelatorio.Text = "ER"
        '
        'SelecaoFilial
        '
        Me.SelecaoFilial.BackColor = System.Drawing.Color.White
        Me.SelecaoFilial.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoFilial.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoFilial.BancoDados_Campo_OrdenarConsulta = True
        Me.SelecaoFilial.BancoDados_Tabela = Nothing
        Me.SelecaoFilial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoFilial.Location = New System.Drawing.Point(100, 28)
        Me.SelecaoFilial.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoFilial.MultiplaSelecao = False
        Me.SelecaoFilial.MultiplaSelecao_Codigo_Tipo = Logus.Selecao.enMultiplaSelecao_Codigo_Tipo.Numero
        Me.SelecaoFilial.Name = "SelecaoFilial"
        Me.SelecaoFilial.Size = New System.Drawing.Size(300, 19)
        Me.SelecaoFilial.TabIndex = 297
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
        Me.optTipo.Location = New System.Drawing.Point(406, 28)
        Me.optTipo.Name = "optTipo"
        Me.optTipo.Size = New System.Drawing.Size(144, 20)
        Me.optTipo.TabIndex = 494
        Me.optTipo.Text = "Sintético"
        '
        'frmREL_PrecoMedioNFComplementa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(818, 546)
        Me.Controls.Add(Me.optTipo)
        Me.Controls.Add(Me.cmdExportaRelatorio)
        Me.Controls.Add(Me.lbl_dolar)
        Me.Controls.Add(Me.txtTaxaDolar)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.crvMain)
        Me.Controls.Add(Me.SelecaoFilial)
        Me.Controls.Add(Me.lbl_Filial)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmREL_PrecoMedioNFComplementa"
        Me.Text = "Preço Medio NF Complementa"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.txtTaxaDolar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdImprimir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents crvMain As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents SelecaoFilial As Logus.Selecao
    Friend WithEvents lbl_Filial As System.Windows.Forms.Label
    Friend WithEvents lbl_dolar As System.Windows.Forms.Label
    Friend WithEvents txtTaxaDolar As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents cmdExportaRelatorio As Infragistics.Win.Misc.UltraButton
    Friend WithEvents optTipo As Infragistics.Win.UltraWinEditors.UltraOptionSet
End Class
