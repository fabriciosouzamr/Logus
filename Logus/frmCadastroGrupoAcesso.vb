Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmCadastroGrupoAcesso
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents cmdNovo As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdAlterar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdAcesso As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdExcell As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents tabAcesso As System.Windows.Forms.TabPage
    Friend WithEvents cmdCancelar_Acesso As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdGravar_Acesso As Infragistics.Win.Misc.UltraButton
    Friend WithEvents grdAreaAcesso As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents tabGrupoAcesso As System.Windows.Forms.TabPage
    Friend WithEvents txtNomeGrupoAcesso As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents grdGeral As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdCancelar_GrupoAcesso As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdGravar_GrupoAcesso As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdExcluir As Infragistics.Win.Misc.UltraButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadastroGrupoAcesso))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
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
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdNovo = New Infragistics.Win.Misc.UltraButton
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdAlterar = New Infragistics.Win.Misc.UltraButton
        Me.cmdAcesso = New Infragistics.Win.Misc.UltraButton
        Me.cmdExcell = New Infragistics.Win.Misc.UltraButton
        Me.cmdExcluir = New Infragistics.Win.Misc.UltraButton
        Me.tabAcesso = New System.Windows.Forms.TabPage
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdCancelar_Acesso = New Infragistics.Win.Misc.UltraButton
        Me.cmdGravar_Acesso = New Infragistics.Win.Misc.UltraButton
        Me.grdAreaAcesso = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.tabGrupoAcesso = New System.Windows.Forms.TabPage
        Me.cmdCancelar_GrupoAcesso = New Infragistics.Win.Misc.UltraButton
        Me.cmdGravar_GrupoAcesso = New Infragistics.Win.Misc.UltraButton
        Me.txtNomeGrupoAcesso = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.grdGeral = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Label6 = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabAcesso.SuspendLayout()
        CType(Me.grdAreaAcesso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabGrupoAcesso.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "xcccccccccc.ico")
        Me.ImageList.Images.SetKeyName(1, "Usuarios.ico")
        Me.ImageList.Images.SetKeyName(2, "sdddddddddddddddddddddd.ico")
        Me.ImageList.Images.SetKeyName(3, "Usuario.ico")
        Me.ImageList.Images.SetKeyName(4, "Consulta.ico")
        '
        'cmdNovo
        '
        Me.cmdNovo.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdNovo.Location = New System.Drawing.Point(58, 356)
        Me.cmdNovo.Name = "cmdNovo"
        Me.cmdNovo.Size = New System.Drawing.Size(45, 45)
        Me.cmdNovo.TabIndex = 2
        Me.cmdNovo.Text = "N"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(635, 356)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 3
        Me.cmdFechar.Text = "F"
        '
        'cmdAlterar
        '
        Me.cmdAlterar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdAlterar.Location = New System.Drawing.Point(109, 356)
        Me.cmdAlterar.Name = "cmdAlterar"
        Me.cmdAlterar.Size = New System.Drawing.Size(45, 45)
        Me.cmdAlterar.TabIndex = 64
        Me.cmdAlterar.Text = "A"
        '
        'cmdAcesso
        '
        Me.cmdAcesso.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdAcesso.Location = New System.Drawing.Point(211, 356)
        Me.cmdAcesso.Name = "cmdAcesso"
        Me.cmdAcesso.Size = New System.Drawing.Size(45, 45)
        Me.cmdAcesso.TabIndex = 65
        Me.cmdAcesso.Text = "AC"
        '
        'cmdExcell
        '
        Me.cmdExcell.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExcell.Location = New System.Drawing.Point(7, 356)
        Me.cmdExcell.Name = "cmdExcell"
        Me.cmdExcell.Size = New System.Drawing.Size(45, 45)
        Me.cmdExcell.TabIndex = 68
        Me.cmdExcell.Text = "Excell"
        '
        'cmdExcluir
        '
        Me.cmdExcluir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExcluir.Location = New System.Drawing.Point(160, 356)
        Me.cmdExcluir.Name = "cmdExcluir"
        Me.cmdExcluir.Size = New System.Drawing.Size(45, 45)
        Me.cmdExcluir.TabIndex = 69
        Me.cmdExcluir.Text = "E"
        '
        'tabAcesso
        '
        Me.tabAcesso.Controls.Add(Me.Label1)
        Me.tabAcesso.Controls.Add(Me.cmdCancelar_Acesso)
        Me.tabAcesso.Controls.Add(Me.cmdGravar_Acesso)
        Me.tabAcesso.Controls.Add(Me.grdAreaAcesso)
        Me.tabAcesso.ImageIndex = 0
        Me.tabAcesso.Location = New System.Drawing.Point(4, 26)
        Me.tabAcesso.Name = "tabAcesso"
        Me.tabAcesso.Size = New System.Drawing.Size(664, 314)
        Me.tabAcesso.TabIndex = 2
        Me.tabAcesso.Text = "Acesso do Grupo de Acesso"
        Me.tabAcesso.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(149, 13)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Listagem de Grupo de Acesso"
        '
        'cmdCancelar_Acesso
        '
        Me.cmdCancelar_Acesso.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdCancelar_Acesso.Location = New System.Drawing.Point(10, 259)
        Me.cmdCancelar_Acesso.Name = "cmdCancelar_Acesso"
        Me.cmdCancelar_Acesso.Size = New System.Drawing.Size(45, 45)
        Me.cmdCancelar_Acesso.TabIndex = 43
        '
        'cmdGravar_Acesso
        '
        Me.cmdGravar_Acesso.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled
        Me.cmdGravar_Acesso.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar_Acesso.Location = New System.Drawing.Point(607, 259)
        Me.cmdGravar_Acesso.Name = "cmdGravar_Acesso"
        Me.cmdGravar_Acesso.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar_Acesso.TabIndex = 39
        '
        'grdAreaAcesso
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdAreaAcesso.DisplayLayout.Appearance = Appearance1
        Me.grdAreaAcesso.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdAreaAcesso.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.grdAreaAcesso.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdAreaAcesso.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.grdAreaAcesso.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdAreaAcesso.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.grdAreaAcesso.DisplayLayout.MaxColScrollRegions = 1
        Me.grdAreaAcesso.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdAreaAcesso.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdAreaAcesso.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.grdAreaAcesso.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdAreaAcesso.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.grdAreaAcesso.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdAreaAcesso.DisplayLayout.Override.CellAppearance = Appearance8
        Me.grdAreaAcesso.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdAreaAcesso.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.grdAreaAcesso.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.grdAreaAcesso.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.grdAreaAcesso.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdAreaAcesso.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.grdAreaAcesso.DisplayLayout.Override.RowAppearance = Appearance11
        Me.grdAreaAcesso.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdAreaAcesso.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.grdAreaAcesso.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdAreaAcesso.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdAreaAcesso.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdAreaAcesso.Location = New System.Drawing.Point(8, 24)
        Me.grdAreaAcesso.Name = "grdAreaAcesso"
        Me.grdAreaAcesso.Size = New System.Drawing.Size(644, 229)
        Me.grdAreaAcesso.TabIndex = 38
        Me.grdAreaAcesso.Text = "UltraGrid1"
        '
        'tabGrupoAcesso
        '
        Me.tabGrupoAcesso.Controls.Add(Me.cmdCancelar_GrupoAcesso)
        Me.tabGrupoAcesso.Controls.Add(Me.cmdGravar_GrupoAcesso)
        Me.tabGrupoAcesso.Controls.Add(Me.txtNomeGrupoAcesso)
        Me.tabGrupoAcesso.Controls.Add(Me.Label2)
        Me.tabGrupoAcesso.ImageIndex = 3
        Me.tabGrupoAcesso.Location = New System.Drawing.Point(4, 26)
        Me.tabGrupoAcesso.Name = "tabGrupoAcesso"
        Me.tabGrupoAcesso.Size = New System.Drawing.Size(664, 314)
        Me.tabGrupoAcesso.TabIndex = 1
        Me.tabGrupoAcesso.Text = "Dados do Grupo de Acesso"
        Me.tabGrupoAcesso.UseVisualStyleBackColor = True
        '
        'cmdCancelar_GrupoAcesso
        '
        Me.cmdCancelar_GrupoAcesso.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdCancelar_GrupoAcesso.Location = New System.Drawing.Point(9, 260)
        Me.cmdCancelar_GrupoAcesso.Name = "cmdCancelar_GrupoAcesso"
        Me.cmdCancelar_GrupoAcesso.Size = New System.Drawing.Size(45, 45)
        Me.cmdCancelar_GrupoAcesso.TabIndex = 40
        '
        'cmdGravar_GrupoAcesso
        '
        Me.cmdGravar_GrupoAcesso.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar_GrupoAcesso.Location = New System.Drawing.Point(604, 260)
        Me.cmdGravar_GrupoAcesso.Name = "cmdGravar_GrupoAcesso"
        Me.cmdGravar_GrupoAcesso.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar_GrupoAcesso.TabIndex = 39
        '
        'txtNomeGrupoAcesso
        '
        Me.txtNomeGrupoAcesso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNomeGrupoAcesso.Location = New System.Drawing.Point(6, 24)
        Me.txtNomeGrupoAcesso.MaxLength = 40
        Me.txtNomeGrupoAcesso.Name = "txtNomeGrupoAcesso"
        Me.txtNomeGrupoAcesso.Size = New System.Drawing.Size(643, 20)
        Me.txtNomeGrupoAcesso.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nome do Grupo de Acesso"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.grdGeral)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.ImageIndex = 4
        Me.TabPage1.Location = New System.Drawing.Point(4, 26)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(664, 314)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Listagem"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'grdGeral
        '
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdGeral.DisplayLayout.Appearance = Appearance13
        Me.grdGeral.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdGeral.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.GroupByBox.Appearance = Appearance14
        Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdGeral.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance15
        Me.grdGeral.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance16.BackColor2 = System.Drawing.SystemColors.Control
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdGeral.DisplayLayout.GroupByBox.PromptAppearance = Appearance16
        Me.grdGeral.DisplayLayout.MaxColScrollRegions = 1
        Me.grdGeral.DisplayLayout.MaxRowScrollRegions = 1
        Appearance17.BackColor = System.Drawing.SystemColors.Window
        Appearance17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdGeral.DisplayLayout.Override.ActiveCellAppearance = Appearance17
        Appearance18.BackColor = System.Drawing.SystemColors.Highlight
        Appearance18.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdGeral.DisplayLayout.Override.ActiveRowAppearance = Appearance18
        Me.grdGeral.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdGeral.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.Override.CardAreaAppearance = Appearance19
        Appearance20.BorderColor = System.Drawing.Color.Silver
        Appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdGeral.DisplayLayout.Override.CellAppearance = Appearance20
        Me.grdGeral.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdGeral.DisplayLayout.Override.CellPadding = 0
        Appearance21.BackColor = System.Drawing.SystemColors.Control
        Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance21.BorderColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.Override.GroupByRowAppearance = Appearance21
        Appearance22.TextHAlignAsString = "Left"
        Me.grdGeral.DisplayLayout.Override.HeaderAppearance = Appearance22
        Me.grdGeral.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdGeral.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Appearance23.BorderColor = System.Drawing.Color.Silver
        Me.grdGeral.DisplayLayout.Override.RowAppearance = Appearance23
        Me.grdGeral.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance24.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdGeral.DisplayLayout.Override.TemplateAddRowAppearance = Appearance24
        Me.grdGeral.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdGeral.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdGeral.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdGeral.Location = New System.Drawing.Point(8, 24)
        Me.grdGeral.Name = "grdGeral"
        Me.grdGeral.Size = New System.Drawing.Size(648, 286)
        Me.grdGeral.TabIndex = 0
        Me.grdGeral.Text = "UltraGrid1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(149, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Listagem de Grupo de Acesso"
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.tabGrupoAcesso)
        Me.TabControl1.Controls.Add(Me.tabAcesso)
        Me.TabControl1.ImageList = Me.ImageList
        Me.TabControl1.Location = New System.Drawing.Point(8, 8)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(672, 344)
        Me.TabControl1.TabIndex = 0
        '
        'frmCadastroGrupoAcesso
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(692, 408)
        Me.Controls.Add(Me.cmdExcluir)
        Me.Controls.Add(Me.cmdExcell)
        Me.Controls.Add(Me.cmdAcesso)
        Me.Controls.Add(Me.cmdAlterar)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdNovo)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCadastroGrupoAcesso"
        Me.Text = "Cadastro de Grupo de Acesso"
        Me.tabAcesso.ResumeLayout(False)
        Me.tabAcesso.PerformLayout()
        CType(Me.grdAreaAcesso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabGrupoAcesso.ResumeLayout(False)
        Me.tabGrupoAcesso.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Const cnt_GridGeral_SQ_GRUPO_ACESSO = 0
    Const cnt_GridGeral_NO_GRUPO_ACESSO = 1

    Const cnt_GridAreaAcesso_CD_AREAACESSO As Integer = 0
    Const cnt_GridAreaAcesso_NomeAcesso As Integer = 1

    Dim oDS As New UltraWinDataSource.UltraDataSource
    Dim oDS_AreaAcesso As New UltraWinDataSource.UltraDataSource

    Dim ControleEdicaoTelaLocal As eControleEdicaoTela
    Dim bViaBotao As Boolean

    Private Sub frmCadastroGrupoAcesso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Form_Container_IdentificarControles(tabGrupoAcesso.Controls)
        Form_Container_IdentificarControles(tabAcesso.Controls)

        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect)
        objGrid_Coluna_Add(grdGeral, "SQ_GRUPO_ACESSO", 0)
        objGrid_Coluna_Add(grdGeral, "Nome do Grupo de Acesso", 400)

        objGrid_Inicializar(grdAreaAcesso, , oDS_AreaAcesso, CellClickAction.Edit)
        objGrid_Coluna_Add(grdAreaAcesso, "CD_AREAACESSO", 0, , False)
        objGrid_Coluna_Add(grdAreaAcesso, "Nome do Acesso", 270, , False)

        bViaBotao = False
        TabPage1.BackColor = Me.BackColor
        tabGrupoAcesso.BackColor = Me.BackColor
        tabAcesso.BackColor = Me.BackColor

        SEC_CarregarAcessos(grdAreaAcesso, cnt_GridAreaAcesso_NomeAcesso, cnt_GridAreaAcesso_CD_AREAACESSO)

        ExecutaConsulta()

        Dim cnt_SEC_Tela As String = "SEC_CadastroGrupoAcesso"

        SEC_ValidarBotao(cmdAcesso, cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao, True)
        SEC_ValidarBotao(cmdAlterar, cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao, True)
        SEC_ValidarBotao(cmdNovo, cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao, True)
        SEC_ValidarBotao(cmdExcluir, cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao, True)
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String

        SqlText = "SELECT SQ_GRUPOACESSO," & _
                         "NO_GRUPOACESSO" & _
                  " FROM AGC.SEC_GRUPOACESSO" & _
                  " WHERE CD_SISTEMA = " & cnt_Sistema_ControleAcesso & _
                  " ORDER BY NO_GRUPOACESSO"
        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_SQ_GRUPO_ACESSO, cnt_GridGeral_NO_GRUPO_ACESSO})
    End Sub

    Private Sub cmdGravar_GrupoAcesso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar_GrupoAcesso.Click
        If Trim(txtNomeGrupoAcesso.Text) = "" Then
            Msg_Mensagem("Informe o nome do grupo de acesso")
            Exit Sub
        End If

        Dim SqlText As String
        Dim iCont As Integer
        Dim SQ_GRUPOACESSO As Integer

        On Error GoTo Erro

        DBUsarTransacao = True

        'Gravação de dados geral ref. a usuário
        If ControleEdicaoTelaLocal = eControleEdicaoTela.INCLUIR Then
            SqlText = "SELECT COUNT(*)" & _
                      " FROM AGC.SEC_GRUPOACESSO" & _
                      " WHERE UPPER(NO_GRUPOACESSO) = " & QuotedStr(Trim(UCase(txtNomeGrupoAcesso.Text))) & _
                        " AND CD_SISTEMA = " & cnt_Sistema_ControleAcesso
            If DBQuery_ValorUnico(SqlText) > 0 Then
                Msg_Mensagem("O nome do Grupo de Acesso já existe")
                Exit Sub
            End If

            SqlText = DBMontar_Insert("AGC.SEC_GRUPOACESSO", TipoCampoFixo.Todos, _
                                                             "CD_SISTEMA", cnt_Sistema_ControleAcesso, _
                                                             "NO_GRUPOACESSO", ":NO_GRUPOACESSO", _
                                                             "SQ_GRUPOACESSO", ":SQ_GRUPOACESSO")

            SQ_GRUPOACESSO = DBNumeroMaisUm("AGC.SEC_GRUPOACESSO", "SQ_GRUPOACESSO")
        Else
            SqlText = DBMontar_Update("AGC.SEC_GRUPOACESSO", GerarArray("NO_GRUPOACESSO", ":NO_GRUPOACESSO"), _
                                                             GerarArray("SQ_GRUPOACESSO", ":SQ_GRUPOACESSO"), True)

            SQ_GRUPOACESSO = objGrid_Valor(grdGeral, cnt_GridGeral_SQ_GRUPO_ACESSO)
        End If

        If Not DBExecutar(SqlText, DBParametro_Montar("NO_GRUPOACESSO", Trim(txtNomeGrupoAcesso.Text)), _
                                   DBParametro_Montar("SQ_GRUPOACESSO", SQ_GRUPOACESSO)) Then GoTo Erro

        If Not DBExecutarTransacao() Then GoTo Erro

        ExecutaConsulta()

        bViaBotao = True
        AtivarBotao(True)
        TabControl1.SelectTab(0)

        If ControleEdicaoTelaLocal = eControleEdicaoTela.INCLUIR Then
            Msg_Mensagem("Inclusão de Grupo de Acesso realizada.")
        Else
            Msg_Mensagem("Alteração de Grupo de Acesso realizada.")
        End If

        Exit Sub
Erro:
        TratarErro()
    End Sub

    Private Sub cmdAlterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAlterar.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar um registro.")
            Exit Sub
        End If

        txtNomeGrupoAcesso.Text = objGrid_Valor(grdGeral, cnt_GridGeral_NO_GRUPO_ACESSO)

        bViaBotao = True
        AtivarBotao(False)
        ControleEdicaoTelaLocal = Declaracao.eControleEdicaoTela.ALTERAR
        TabControl1.SelectTab(1)
    End Sub

    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        txtNomeGrupoAcesso.Text = ""

        bViaBotao = True
        AtivarBotao(False)
        ControleEdicaoTelaLocal = Declaracao.eControleEdicaoTela.INCLUIR

        TabControl1.SelectTab(1)
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub cmdAcesso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAcesso.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar um registro.")
            Exit Sub
        End If

        SEC_CarregarDiretosAcesso(grdAreaAcesso, objGrid_Valor(grdGeral, cnt_GridGeral_SQ_GRUPO_ACESSO), "", _
                                  cnt_GridAreaAcesso_CD_AREAACESSO, cnt_GridAreaAcesso_NomeAcesso)
        grdAreaAcesso.UpdateData()
        bViaBotao = True
        AtivarBotao(False)
        TabControl1.SelectTab(2)
    End Sub

    Private Sub TabControl1_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl1.Selecting
        If bViaBotao = False Then
            e.Cancel = True
        Else
            bViaBotao = False
        End If
    End Sub

    Private Sub cmdCancelar_Usuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar_GrupoAcesso.Click
        bViaBotao = True
        AtivarBotao(True)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub AtivarBotao(ByVal Ativar As Boolean)
        cmdAcesso.Enabled = Ativar
        cmdAlterar.Enabled = Ativar
        cmdNovo.Enabled = Ativar
        cmdExcell.Enabled = Ativar
    End Sub

    Private Sub cmdCancelar_Acesso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar_Acesso.Click
        bViaBotao = True
        AtivarBotao(True)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub DesmarcarGrid(ByVal oGrid As UltraGrid, ByVal Coluna As Integer)
        Dim iCont As Integer

        For iCont = 0 To oGrid.Rows.Count - 1
            oGrid.Rows(iCont).Cells(Coluna).Value = False
        Next
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar um registro.")
            Exit Sub
        End If

        Dim SqlText As String

        On Error GoTo Erro

        SqlText = "SELECT COUNT(*) FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO_GRUPOACESSO" & _
                  " WHERE SQ_GRUPOACESSO = " & objGrid_Valor(grdGeral, cnt_GridGeral_SQ_GRUPO_ACESSO)

        If DBQuery_ValorUnico(SqlText) > 0 Then
            Msg_Mensagem("Esse grupo de acesso está associado a algum usuário")
        Else
            'Exclue o grupo de acesso 
            SqlText = "DELETE FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_GRUPOACESSO_ACESSO" & _
                      " WHERE SQ_GRUPOACESSO = " & objGrid_Valor(grdGeral, cnt_GridGeral_SQ_GRUPO_ACESSO)
            If Not DBExecutar(SqlText) Then GoTo Erro

            SqlText = "DELETE FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_GRUPOACESSO" & _
                      " WHERE SQ_GRUPOACESSO = " & objGrid_Valor(grdGeral, cnt_GridGeral_SQ_GRUPO_ACESSO)
            If Not DBExecutar(SqlText) Then GoTo Erro

            ExecutaConsulta()
        End If

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub grdAreaAcesso_BeforeCellActivate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableCellEventArgs) Handles grdAreaAcesso.BeforeCellActivate
        If e.Cell.Column.Index = cnt_GridAreaAcesso_NomeAcesso Then
            e.Cancel = True
        Else
            e.Cancel = (Not e.Cell.Style = ColumnStyle.CheckBox)
        End If
    End Sub

    Private Sub cmdGrava_AcessoUsuario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGravar_Acesso.Click
        SEC_Gravar(grdAreaAcesso, objGrid_Valor(grdGeral, cnt_GridGeral_SQ_GRUPO_ACESSO), _
                   0, cnt_GridAreaAcesso_CD_AREAACESSO, cnt_GridAreaAcesso_NomeAcesso)

        Msg_Mensagem("Acessos do grupo de acesso alterados com sucesso.")

        bViaBotao = True
        AtivarBotao(True)
        TabControl1.SelectTab(0)
    End Sub
End Class