<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGridEscolheColuna
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
        Me.grdEscolheColuna = New Infragistics.Win.UltraWinGrid.UltraGridColumnChooser
        Me.cboEscolheBand = New Infragistics.Win.UltraWinGrid.UltraCombo
        CType(Me.grdEscolheColuna, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboEscolheBand, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdEscolheColuna
        '
        Me.grdEscolheColuna.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.grdEscolheColuna.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdEscolheColuna.DisplayLayout.MaxColScrollRegions = 1
        Me.grdEscolheColuna.DisplayLayout.MaxRowScrollRegions = 1
        Me.grdEscolheColuna.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.grdEscolheColuna.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None
        Me.grdEscolheColuna.DisplayLayout.Override.AllowRowLayoutCellSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None
        Me.grdEscolheColuna.DisplayLayout.Override.AllowRowLayoutLabelSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None
        Me.grdEscolheColuna.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.grdEscolheColuna.DisplayLayout.Override.CellPadding = 2
        Me.grdEscolheColuna.DisplayLayout.Override.ExpansionIndicator = Infragistics.Win.UltraWinGrid.ShowExpansionIndicator.Never
        Me.grdEscolheColuna.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.[Select]
        Me.grdEscolheColuna.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdEscolheColuna.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed
        Me.grdEscolheColuna.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.grdEscolheColuna.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.grdEscolheColuna.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.grdEscolheColuna.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None
        Me.grdEscolheColuna.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdEscolheColuna.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdEscolheColuna.Location = New System.Drawing.Point(5, 35)
        Me.grdEscolheColuna.MultipleBandSupport = Infragistics.Win.UltraWinGrid.MultipleBandSupport.SingleBandOnly
        Me.grdEscolheColuna.Name = "grdEscolheColuna"
        Me.grdEscolheColuna.Size = New System.Drawing.Size(459, 450)
        Me.grdEscolheColuna.Style = Infragistics.Win.UltraWinGrid.ColumnChooserStyle.AllColumnsWithCheckBoxes
        Me.grdEscolheColuna.StyleLibraryName = ""
        Me.grdEscolheColuna.StyleSetName = ""
        Me.grdEscolheColuna.TabIndex = 5
        Me.grdEscolheColuna.Text = "ultraGridColumnChooser1"
        '
        'cboEscolheBand
        '
        Me.cboEscolheBand.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboEscolheBand.DisplayLayout.MaxColScrollRegions = 1
        Me.cboEscolheBand.DisplayLayout.MaxRowScrollRegions = 1
        Me.cboEscolheBand.DisplayLayout.Override.CellPadding = 0
        Me.cboEscolheBand.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.[Default]
        Me.cboEscolheBand.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cboEscolheBand.Location = New System.Drawing.Point(5, 5)
        Me.cboEscolheBand.Name = "cboEscolheBand"
        Me.cboEscolheBand.Size = New System.Drawing.Size(300, 22)
        Me.cboEscolheBand.TabIndex = 8
        '
        'frmGridEscolheColuna
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(470, 491)
        Me.Controls.Add(Me.cboEscolheBand)
        Me.Controls.Add(Me.grdEscolheColuna)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmGridEscolheColuna"
        Me.ShowInTaskbar = False
        Me.Text = "Escolhe Coluna"
        CType(Me.grdEscolheColuna, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboEscolheBand, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdEscolheColuna As Infragistics.Win.UltraWinGrid.UltraGridColumnChooser
    Friend WithEvents cboEscolheBand As Infragistics.Win.UltraWinGrid.UltraCombo
End Class
