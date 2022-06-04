<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMovimentacaoCacau_MovimentarLote
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
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboArmazem = New System.Windows.Forms.ComboBox
        Me.cboPilha = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblSacosSaldo = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblSacos = New System.Windows.Forms.Label
        Me.lblVolume = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblR_MovimentacaoEstoque = New System.Windows.Forms.Label
        Me.grpPilhaDestino = New System.Windows.Forms.GroupBox
        Me.cboPilhaDestino = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.grdMovimentacaoEstoque = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.grdMovimentarPilhaDestino = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.lblR_MovimentarPilhaDestino = New System.Windows.Forms.Label
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.cmdDesce = New Infragistics.Win.Misc.UltraButton
        Me.cmdSobe = New Infragistics.Win.Misc.UltraButton
        Me.grpMovimentarSacos = New System.Windows.Forms.GroupBox
        Me.cmdMovimentarSacos = New Infragistics.Win.Misc.UltraButton
        Me.txtSacosMovimentar = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.grpPilhaDestino.SuspendLayout()
        CType(Me.grdMovimentacaoEstoque, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdMovimentarPilhaDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMovimentarSacos.SuspendLayout()
        CType(Me.txtSacosMovimentar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboArmazem)
        Me.GroupBox1.Controls.Add(Me.cboPilha)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.lblSacosSaldo)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.lblSacos)
        Me.GroupBox1.Controls.Add(Me.lblVolume)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(510, 60)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Dados da Pilha de Origem"
        '
        'cboArmazem
        '
        Me.cboArmazem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboArmazem.FormattingEnabled = True
        Me.cboArmazem.Location = New System.Drawing.Point(8, 30)
        Me.cboArmazem.Name = "cboArmazem"
        Me.cboArmazem.Size = New System.Drawing.Size(165, 21)
        Me.cboArmazem.TabIndex = 5
        '
        'cboPilha
        '
        Me.cboPilha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPilha.FormattingEnabled = True
        Me.cboPilha.Location = New System.Drawing.Point(181, 30)
        Me.cboPilha.Name = "cboPilha"
        Me.cboPilha.Size = New System.Drawing.Size(100, 21)
        Me.cboPilha.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(380, 37)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(12, 13)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "/"
        '
        'lblSacosSaldo
        '
        Me.lblSacosSaldo.AutoSize = True
        Me.lblSacosSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSacosSaldo.Location = New System.Drawing.Point(392, 37)
        Me.lblSacosSaldo.Name = "lblSacosSaldo"
        Me.lblSacosSaldo.Size = New System.Drawing.Size(14, 13)
        Me.lblSacosSaldo.TabIndex = 3
        Me.lblSacosSaldo.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(289, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Volume:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(289, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Sacos:"
        '
        'lblSacos
        '
        Me.lblSacos.AutoSize = True
        Me.lblSacos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSacos.Location = New System.Drawing.Point(342, 37)
        Me.lblSacos.Name = "lblSacos"
        Me.lblSacos.Size = New System.Drawing.Size(14, 13)
        Me.lblSacos.TabIndex = 0
        Me.lblSacos.Text = "0"
        '
        'lblVolume
        '
        Me.lblVolume.AutoSize = True
        Me.lblVolume.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVolume.Location = New System.Drawing.Point(342, 16)
        Me.lblVolume.Name = "lblVolume"
        Me.lblVolume.Size = New System.Drawing.Size(14, 13)
        Me.lblVolume.TabIndex = 0
        Me.lblVolume.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(181, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Pilha"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Armazém"
        '
        'lblR_MovimentacaoEstoque
        '
        Me.lblR_MovimentacaoEstoque.AutoSize = True
        Me.lblR_MovimentacaoEstoque.Location = New System.Drawing.Point(8, 76)
        Me.lblR_MovimentacaoEstoque.Name = "lblR_MovimentacaoEstoque"
        Me.lblR_MovimentacaoEstoque.Size = New System.Drawing.Size(136, 13)
        Me.lblR_MovimentacaoEstoque.TabIndex = 1
        Me.lblR_MovimentacaoEstoque.Text = "Movimentação em Estoque"
        '
        'grpPilhaDestino
        '
        Me.grpPilhaDestino.Controls.Add(Me.cboPilhaDestino)
        Me.grpPilhaDestino.Controls.Add(Me.Label4)
        Me.grpPilhaDestino.Location = New System.Drawing.Point(526, 8)
        Me.grpPilhaDestino.Name = "grpPilhaDestino"
        Me.grpPilhaDestino.Size = New System.Drawing.Size(118, 60)
        Me.grpPilhaDestino.TabIndex = 2
        Me.grpPilhaDestino.TabStop = False
        Me.grpPilhaDestino.Text = "Pilha de Destino"
        '
        'cboPilhaDestino
        '
        Me.cboPilhaDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPilhaDestino.FormattingEnabled = True
        Me.cboPilhaDestino.Location = New System.Drawing.Point(8, 30)
        Me.cboPilhaDestino.Name = "cboPilhaDestino"
        Me.cboPilhaDestino.Size = New System.Drawing.Size(100, 21)
        Me.cboPilhaDestino.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Pilha"
        '
        'grdMovimentacaoEstoque
        '
        Me.grdMovimentacaoEstoque.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdMovimentacaoEstoque.DisplayLayout.Appearance = Appearance13
        Me.grdMovimentacaoEstoque.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdMovimentacaoEstoque.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.grdMovimentacaoEstoque.DisplayLayout.GroupByBox.Appearance = Appearance14
        Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdMovimentacaoEstoque.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance15
        Me.grdMovimentacaoEstoque.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance16.BackColor2 = System.Drawing.SystemColors.Control
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdMovimentacaoEstoque.DisplayLayout.GroupByBox.PromptAppearance = Appearance16
        Me.grdMovimentacaoEstoque.DisplayLayout.MaxColScrollRegions = 1
        Me.grdMovimentacaoEstoque.DisplayLayout.MaxRowScrollRegions = 1
        Appearance17.BackColor = System.Drawing.SystemColors.Window
        Appearance17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdMovimentacaoEstoque.DisplayLayout.Override.ActiveCellAppearance = Appearance17
        Appearance18.BackColor = System.Drawing.SystemColors.Highlight
        Appearance18.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdMovimentacaoEstoque.DisplayLayout.Override.ActiveRowAppearance = Appearance18
        Me.grdMovimentacaoEstoque.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdMovimentacaoEstoque.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Me.grdMovimentacaoEstoque.DisplayLayout.Override.CardAreaAppearance = Appearance19
        Appearance20.BorderColor = System.Drawing.Color.Silver
        Appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdMovimentacaoEstoque.DisplayLayout.Override.CellAppearance = Appearance20
        Me.grdMovimentacaoEstoque.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdMovimentacaoEstoque.DisplayLayout.Override.CellPadding = 0
        Appearance21.BackColor = System.Drawing.SystemColors.Control
        Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance21.BorderColor = System.Drawing.SystemColors.Window
        Me.grdMovimentacaoEstoque.DisplayLayout.Override.GroupByRowAppearance = Appearance21
        Appearance22.TextHAlignAsString = "Left"
        Me.grdMovimentacaoEstoque.DisplayLayout.Override.HeaderAppearance = Appearance22
        Me.grdMovimentacaoEstoque.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdMovimentacaoEstoque.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Appearance23.BorderColor = System.Drawing.Color.Silver
        Me.grdMovimentacaoEstoque.DisplayLayout.Override.RowAppearance = Appearance23
        Me.grdMovimentacaoEstoque.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance24.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdMovimentacaoEstoque.DisplayLayout.Override.TemplateAddRowAppearance = Appearance24
        Me.grdMovimentacaoEstoque.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdMovimentacaoEstoque.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdMovimentacaoEstoque.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdMovimentacaoEstoque.Location = New System.Drawing.Point(8, 90)
        Me.grdMovimentacaoEstoque.Name = "grdMovimentacaoEstoque"
        Me.grdMovimentacaoEstoque.Size = New System.Drawing.Size(807, 190)
        Me.grdMovimentacaoEstoque.TabIndex = 3
        Me.grdMovimentacaoEstoque.Text = "UltraGrid1"
        '
        'grdMovimentarPilhaDestino
        '
        Me.grdMovimentarPilhaDestino.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance4.BackColor = System.Drawing.SystemColors.Window
        Appearance4.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdMovimentarPilhaDestino.DisplayLayout.Appearance = Appearance4
        Me.grdMovimentarPilhaDestino.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdMovimentarPilhaDestino.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance1.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance1.BorderColor = System.Drawing.SystemColors.Window
        Me.grdMovimentarPilhaDestino.DisplayLayout.GroupByBox.Appearance = Appearance1
        Appearance2.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdMovimentarPilhaDestino.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance2
        Me.grdMovimentarPilhaDestino.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance3.BackColor2 = System.Drawing.SystemColors.Control
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdMovimentarPilhaDestino.DisplayLayout.GroupByBox.PromptAppearance = Appearance3
        Me.grdMovimentarPilhaDestino.DisplayLayout.MaxColScrollRegions = 1
        Me.grdMovimentarPilhaDestino.DisplayLayout.MaxRowScrollRegions = 1
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdMovimentarPilhaDestino.DisplayLayout.Override.ActiveCellAppearance = Appearance12
        Appearance7.BackColor = System.Drawing.SystemColors.Highlight
        Appearance7.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdMovimentarPilhaDestino.DisplayLayout.Override.ActiveRowAppearance = Appearance7
        Me.grdMovimentarPilhaDestino.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdMovimentarPilhaDestino.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance6.BackColor = System.Drawing.SystemColors.Window
        Me.grdMovimentarPilhaDestino.DisplayLayout.Override.CardAreaAppearance = Appearance6
        Appearance5.BorderColor = System.Drawing.Color.Silver
        Appearance5.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdMovimentarPilhaDestino.DisplayLayout.Override.CellAppearance = Appearance5
        Me.grdMovimentarPilhaDestino.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdMovimentarPilhaDestino.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.grdMovimentarPilhaDestino.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance11.TextHAlignAsString = "Left"
        Me.grdMovimentarPilhaDestino.DisplayLayout.Override.HeaderAppearance = Appearance11
        Me.grdMovimentarPilhaDestino.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdMovimentarPilhaDestino.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance10.BackColor = System.Drawing.SystemColors.Window
        Appearance10.BorderColor = System.Drawing.Color.Silver
        Me.grdMovimentarPilhaDestino.DisplayLayout.Override.RowAppearance = Appearance10
        Me.grdMovimentarPilhaDestino.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance8.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdMovimentarPilhaDestino.DisplayLayout.Override.TemplateAddRowAppearance = Appearance8
        Me.grdMovimentarPilhaDestino.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdMovimentarPilhaDestino.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdMovimentarPilhaDestino.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdMovimentarPilhaDestino.Location = New System.Drawing.Point(8, 305)
        Me.grdMovimentarPilhaDestino.Name = "grdMovimentarPilhaDestino"
        Me.grdMovimentarPilhaDestino.Size = New System.Drawing.Size(807, 190)
        Me.grdMovimentarPilhaDestino.TabIndex = 3
        Me.grdMovimentarPilhaDestino.Text = "UltraGrid1"
        '
        'lblR_MovimentarPilhaDestino
        '
        Me.lblR_MovimentarPilhaDestino.AutoSize = True
        Me.lblR_MovimentarPilhaDestino.Location = New System.Drawing.Point(8, 288)
        Me.lblR_MovimentarPilhaDestino.Name = "lblR_MovimentarPilhaDestino"
        Me.lblR_MovimentarPilhaDestino.Size = New System.Drawing.Size(175, 13)
        Me.lblR_MovimentarPilhaDestino.TabIndex = 4
        Me.lblR_MovimentarPilhaDestino.Text = "Movimentar para a Pilha de Destino"
        '
        'cmdFechar
        '
        Me.cmdFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(823, 503)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 250
        Me.cmdFechar.Text = "F"
        '
        'cmdGravar
        '
        Me.cmdGravar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(8, 503)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 251
        Me.cmdGravar.Text = "G"
        '
        'cmdDesce
        '
        Me.cmdDesce.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDesce.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdDesce.Location = New System.Drawing.Point(823, 163)
        Me.cmdDesce.Name = "cmdDesce"
        Me.cmdDesce.Size = New System.Drawing.Size(45, 45)
        Me.cmdDesce.TabIndex = 250
        Me.cmdDesce.Text = "D"
        '
        'cmdSobe
        '
        Me.cmdSobe.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSobe.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdSobe.Location = New System.Drawing.Point(823, 378)
        Me.cmdSobe.Name = "cmdSobe"
        Me.cmdSobe.Size = New System.Drawing.Size(45, 45)
        Me.cmdSobe.TabIndex = 250
        Me.cmdSobe.Text = "S"
        '
        'grpMovimentarSacos
        '
        Me.grpMovimentarSacos.Controls.Add(Me.cmdMovimentarSacos)
        Me.grpMovimentarSacos.Controls.Add(Me.txtSacosMovimentar)
        Me.grpMovimentarSacos.Controls.Add(Me.Label6)
        Me.grpMovimentarSacos.Location = New System.Drawing.Point(652, 8)
        Me.grpMovimentarSacos.Name = "grpMovimentarSacos"
        Me.grpMovimentarSacos.Size = New System.Drawing.Size(153, 60)
        Me.grpMovimentarSacos.TabIndex = 252
        Me.grpMovimentarSacos.TabStop = False
        Me.grpMovimentarSacos.Text = "Movimentar Sacos"
        '
        'cmdMovimentarSacos
        '
        Appearance35.Image = Global.Logus.My.Resources.Resources.Expand_Vertical
        Appearance35.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance35.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.cmdMovimentarSacos.Appearance = Appearance35
        Me.cmdMovimentarSacos.ImageSize = New System.Drawing.Size(20, 20)
        Me.cmdMovimentarSacos.Location = New System.Drawing.Point(116, 23)
        Me.cmdMovimentarSacos.Name = "cmdMovimentarSacos"
        Me.cmdMovimentarSacos.Size = New System.Drawing.Size(28, 28)
        Me.cmdMovimentarSacos.TabIndex = 291
        Me.cmdMovimentarSacos.TabStop = False
        '
        'txtSacosMovimentar
        '
        Me.txtSacosMovimentar.Location = New System.Drawing.Point(8, 30)
        Me.txtSacosMovimentar.Name = "txtSacosMovimentar"
        Me.txtSacosMovimentar.Size = New System.Drawing.Size(100, 21)
        Me.txtSacosMovimentar.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(8, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Qtde. Sacos"
        '
        'frmMovimentacaoCacau_MovimentarLote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(876, 556)
        Me.Controls.Add(Me.grpMovimentarSacos)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.cmdSobe)
        Me.Controls.Add(Me.cmdDesce)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.lblR_MovimentarPilhaDestino)
        Me.Controls.Add(Me.grdMovimentarPilhaDestino)
        Me.Controls.Add(Me.grdMovimentacaoEstoque)
        Me.Controls.Add(Me.grpPilhaDestino)
        Me.Controls.Add(Me.lblR_MovimentacaoEstoque)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMovimentacaoCacau_MovimentarLote"
        Me.Text = "Movimentação de Cacau - Movimentar"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpPilhaDestino.ResumeLayout(False)
        Me.grpPilhaDestino.PerformLayout()
        CType(Me.grdMovimentacaoEstoque, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdMovimentarPilhaDestino, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMovimentarSacos.ResumeLayout(False)
        Me.grpMovimentarSacos.PerformLayout()
        CType(Me.txtSacosMovimentar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblR_MovimentacaoEstoque As System.Windows.Forms.Label
    Friend WithEvents grpPilhaDestino As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboPilhaDestino As System.Windows.Forms.ComboBox
    Friend WithEvents grdMovimentacaoEstoque As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grdMovimentarPilhaDestino As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblR_MovimentarPilhaDestino As System.Windows.Forms.Label
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdDesce As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdSobe As Infragistics.Win.Misc.UltraButton
    Friend WithEvents grpMovimentarSacos As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSacosMovimentar As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents cmdMovimentarSacos As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblSacos As System.Windows.Forms.Label
    Friend WithEvents lblVolume As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblSacosSaldo As System.Windows.Forms.Label
    Friend WithEvents cboPilha As System.Windows.Forms.ComboBox
    Friend WithEvents cboArmazem As System.Windows.Forms.ComboBox
End Class
