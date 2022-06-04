<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroContratoResumo
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
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.grdResumo = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtSubTotal_01 = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.txtCancelados_03 = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCancelados_01 = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.txtTotal_01 = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.txtCancelados_02 = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.txtSubTotal_02 = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.txtTotal_02 = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.txtTotal_03 = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtSubTotal_03 = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdExcell = New Infragistics.Win.Misc.UltraButton
        CType(Me.grdResumo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSubTotal_01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCancelados_03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCancelados_01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotal_01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCancelados_02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSubTotal_02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotal_02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotal_03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSubTotal_03, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdResumo
        '
        Appearance20.BackColor = System.Drawing.SystemColors.Window
        Appearance20.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdResumo.DisplayLayout.Appearance = Appearance20
        Me.grdResumo.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdResumo.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance21.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance21.BorderColor = System.Drawing.SystemColors.Window
        Me.grdResumo.DisplayLayout.GroupByBox.Appearance = Appearance21
        Appearance22.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdResumo.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance22
        Me.grdResumo.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance23.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance23.BackColor2 = System.Drawing.SystemColors.Control
        Appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance23.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdResumo.DisplayLayout.GroupByBox.PromptAppearance = Appearance23
        Me.grdResumo.DisplayLayout.MaxColScrollRegions = 1
        Me.grdResumo.DisplayLayout.MaxRowScrollRegions = 1
        Appearance24.BackColor = System.Drawing.SystemColors.Window
        Appearance24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdResumo.DisplayLayout.Override.ActiveCellAppearance = Appearance24
        Appearance25.BackColor = System.Drawing.SystemColors.Highlight
        Appearance25.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdResumo.DisplayLayout.Override.ActiveRowAppearance = Appearance25
        Me.grdResumo.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdResumo.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance26.BackColor = System.Drawing.SystemColors.Window
        Me.grdResumo.DisplayLayout.Override.CardAreaAppearance = Appearance26
        Appearance27.BorderColor = System.Drawing.Color.Silver
        Appearance27.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdResumo.DisplayLayout.Override.CellAppearance = Appearance27
        Me.grdResumo.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdResumo.DisplayLayout.Override.CellPadding = 0
        Appearance28.BackColor = System.Drawing.SystemColors.Control
        Appearance28.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance28.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance28.BorderColor = System.Drawing.SystemColors.Window
        Me.grdResumo.DisplayLayout.Override.GroupByRowAppearance = Appearance28
        Appearance29.TextHAlignAsString = "Left"
        Me.grdResumo.DisplayLayout.Override.HeaderAppearance = Appearance29
        Me.grdResumo.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdResumo.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance30.BackColor = System.Drawing.SystemColors.Window
        Appearance30.BorderColor = System.Drawing.Color.Silver
        Me.grdResumo.DisplayLayout.Override.RowAppearance = Appearance30
        Me.grdResumo.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance31.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdResumo.DisplayLayout.Override.TemplateAddRowAppearance = Appearance31
        Me.grdResumo.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdResumo.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdResumo.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdResumo.Location = New System.Drawing.Point(12, 12)
        Me.grdResumo.Name = "grdResumo"
        Me.grdResumo.Size = New System.Drawing.Size(477, 159)
        Me.grdResumo.TabIndex = 236
        Me.grdResumo.Text = "UltraGrid1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 195)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 24)
        Me.Label1.TabIndex = 237
        Me.Label1.Text = "Sub-Total:"
        '
        'txtSubTotal_01
        '
        Me.txtSubTotal_01.Location = New System.Drawing.Point(165, 197)
        Me.txtSubTotal_01.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtSubTotal_01.Name = "txtSubTotal_01"
        Me.txtSubTotal_01.Size = New System.Drawing.Size(103, 21)
        Me.txtSubTotal_01.TabIndex = 273
        '
        'txtCancelados_03
        '
        Me.txtCancelados_03.Location = New System.Drawing.Point(387, 237)
        Me.txtCancelados_03.MaskInput = "{LOC}-nnnn,nnn"
        Me.txtCancelados_03.Name = "txtCancelados_03"
        Me.txtCancelados_03.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtCancelados_03.Size = New System.Drawing.Size(89, 21)
        Me.txtCancelados_03.TabIndex = 274
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 235)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 24)
        Me.Label2.TabIndex = 275
        Me.Label2.Text = "Cancelados:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 275)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 24)
        Me.Label3.TabIndex = 276
        Me.Label3.Text = "Total:"
        '
        'txtCancelados_01
        '
        Me.txtCancelados_01.Location = New System.Drawing.Point(165, 237)
        Me.txtCancelados_01.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCancelados_01.Name = "txtCancelados_01"
        Me.txtCancelados_01.Size = New System.Drawing.Size(103, 21)
        Me.txtCancelados_01.TabIndex = 277
        '
        'txtTotal_01
        '
        Me.txtTotal_01.Location = New System.Drawing.Point(165, 277)
        Me.txtTotal_01.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtTotal_01.Name = "txtTotal_01"
        Me.txtTotal_01.Size = New System.Drawing.Size(103, 21)
        Me.txtTotal_01.TabIndex = 278
        '
        'txtCancelados_02
        '
        Me.txtCancelados_02.Location = New System.Drawing.Point(276, 237)
        Me.txtCancelados_02.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCancelados_02.Name = "txtCancelados_02"
        Me.txtCancelados_02.Size = New System.Drawing.Size(103, 21)
        Me.txtCancelados_02.TabIndex = 279
        '
        'txtSubTotal_02
        '
        Me.txtSubTotal_02.Location = New System.Drawing.Point(276, 197)
        Me.txtSubTotal_02.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtSubTotal_02.Name = "txtSubTotal_02"
        Me.txtSubTotal_02.Size = New System.Drawing.Size(103, 21)
        Me.txtSubTotal_02.TabIndex = 280
        '
        'txtTotal_02
        '
        Me.txtTotal_02.Location = New System.Drawing.Point(276, 277)
        Me.txtTotal_02.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtTotal_02.Name = "txtTotal_02"
        Me.txtTotal_02.Size = New System.Drawing.Size(103, 21)
        Me.txtTotal_02.TabIndex = 281
        '
        'txtTotal_03
        '
        Me.txtTotal_03.Location = New System.Drawing.Point(387, 277)
        Me.txtTotal_03.MaskInput = "{LOC}-nnnn,nnn"
        Me.txtTotal_03.Name = "txtTotal_03"
        Me.txtTotal_03.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtTotal_03.Size = New System.Drawing.Size(89, 21)
        Me.txtTotal_03.TabIndex = 282
        '
        'txtSubTotal_03
        '
        Me.txtSubTotal_03.Location = New System.Drawing.Point(387, 197)
        Me.txtSubTotal_03.MaskInput = "{LOC}-nnnn,nnn"
        Me.txtSubTotal_03.Name = "txtSubTotal_03"
        Me.txtSubTotal_03.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtSubTotal_03.Size = New System.Drawing.Size(89, 21)
        Me.txtSubTotal_03.TabIndex = 283
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(444, 314)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 284
        Me.cmdFechar.Text = "F"
        '
        'cmdExcell
        '
        Me.cmdExcell.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExcell.Location = New System.Drawing.Point(393, 314)
        Me.cmdExcell.Name = "cmdExcell"
        Me.cmdExcell.Size = New System.Drawing.Size(45, 45)
        Me.cmdExcell.TabIndex = 285
        Me.cmdExcell.Text = "Excell"
        '
        'frmCadastroContratoResumo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(499, 371)
        Me.Controls.Add(Me.cmdExcell)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.txtSubTotal_03)
        Me.Controls.Add(Me.txtTotal_03)
        Me.Controls.Add(Me.txtTotal_02)
        Me.Controls.Add(Me.txtSubTotal_02)
        Me.Controls.Add(Me.txtCancelados_02)
        Me.Controls.Add(Me.txtTotal_01)
        Me.Controls.Add(Me.txtCancelados_01)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSubTotal_01)
        Me.Controls.Add(Me.txtCancelados_03)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grdResumo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmCadastroContratoResumo"
        Me.Text = "Cadastro de Contrato - Resumo"
        CType(Me.grdResumo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSubTotal_01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCancelados_03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCancelados_01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotal_01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCancelados_02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSubTotal_02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotal_02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotal_03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSubTotal_03, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdResumo As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSubTotal_01 As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents txtCancelados_03 As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCancelados_01 As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents txtTotal_01 As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents txtCancelados_02 As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents txtSubTotal_02 As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents txtTotal_02 As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents txtTotal_03 As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents txtSubTotal_03 As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdExcell As Infragistics.Win.Misc.UltraButton
End Class
