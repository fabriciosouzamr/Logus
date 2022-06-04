Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmCadastroUsuario
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
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabListagem As System.Windows.Forms.TabPage
    Friend WithEvents tabDados As System.Windows.Forms.TabPage
    Friend WithEvents cmdNovo As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFiltro_CodigoUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFiltro_NomeUsuario As System.Windows.Forms.TextBox
    Friend WithEvents txtFiltro_EMail As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdPesquisar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents grdGeral As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cmdAlterar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdAcesso As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdGrupoUsuario As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdLinkarUsuario As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdExcell As Infragistics.Win.Misc.UltraButton
    Friend WithEvents tabAcessoUsuario As System.Windows.Forms.TabPage
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboUsuarioCopia As System.Windows.Forms.ComboBox
    Friend WithEvents cmdGravar_AcessoUsuario As Infragistics.Win.Misc.UltraButton
    Friend WithEvents grdAreaAcesso As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblUsuarioAcessoUsuario As System.Windows.Forms.Label
    Friend WithEvents tabGrupoAcesso As System.Windows.Forms.TabPage
    Friend WithEvents tabLinkarAcesso As System.Windows.Forms.TabPage
    Friend WithEvents cmdCancelar_Acesso As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdCancelar_Grupo As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdCancelar_Link As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblUsuarioGrupoUsuario As System.Windows.Forms.Label
    Friend WithEvents grdGrupoUsuario As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cmdGravar_Grupo As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblUsuarioLinkUsuario As System.Windows.Forms.Label
    Friend WithEvents grdLinkUsuario As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cmdGravar_Link As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdCancelar_Usuario As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdGravar_Usuario As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents tabDadosGerais As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents txtDtFimUtilizacao As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtEMail As System.Windows.Forms.TextBox
    Friend WithEvents txtNomeUsuario As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lstFilialLiberadasUsuario As System.Windows.Forms.CheckedListBox
    Friend WithEvents tabDadosComplementares As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents grdAprovacao As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Validade As System.Windows.Forms.Label
    Friend WithEvents txtAprovacao_SacoMaximo As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents txtAprovacao_SacoMinimo As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lstFilialUsuarioAprova As System.Windows.Forms.CheckedListBox
    Friend WithEvents cboAprovacao_TipoAprovacao As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtValorMinimo As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtValorMaximo As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents chkAprovadorPagamento As System.Windows.Forms.CheckBox
    Friend WithEvents chkAprovadorReNegociacao As System.Windows.Forms.CheckBox
    Friend WithEvents chkAutorizaDescontoJuros As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmdAprovacao_Novo As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdAprovacao_Adicionar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtAprovacao_Validade As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents chkAprovacao_Validade As System.Windows.Forms.CheckBox
    Friend WithEvents chkBloqueadoTempoUso As System.Windows.Forms.CheckBox
    Friend WithEvents cboStatus_Filtro As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoUsuarioDS As System.Windows.Forms.TextBox
    Friend WithEvents txtRhId As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmdUsuarioBloqueado As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Pesq_UsuarioCopia As Logus.Pesq_CodigoNome
    Friend WithEvents lblR_UsuarioCopia As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblUltimoAcesso As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents cboNivelAprovacaoPagamento As System.Windows.Forms.ComboBox
    Friend WithEvents cmdExcluir As Infragistics.Win.Misc.UltraButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
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
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadastroUsuario))
        Me.tabDadosGerais = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblUltimoAcesso = New System.Windows.Forms.Label
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Pesq_UsuarioCopia = New Logus.Pesq_CodigoNome
        Me.txtRhId = New System.Windows.Forms.TextBox
        Me.txtCodigoUsuarioDS = New System.Windows.Forms.TextBox
        Me.chkBloqueadoTempoUso = New System.Windows.Forms.CheckBox
        Me.lstFilialLiberadasUsuario = New System.Windows.Forms.CheckedListBox
        Me.txtDtFimUtilizacao = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtEMail = New System.Windows.Forms.TextBox
        Me.txtNomeUsuario = New System.Windows.Forms.TextBox
        Me.txtCodigoUsuario = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblR_UsuarioCopia = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.tabDadosComplementares = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Label21 = New System.Windows.Forms.Label
        Me.chkAprovacao_Validade = New System.Windows.Forms.CheckBox
        Me.txtAprovacao_Validade = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.cmdAprovacao_Novo = New Infragistics.Win.Misc.UltraButton
        Me.cmdAprovacao_Adicionar = New Infragistics.Win.Misc.UltraButton
        Me.chkAprovadorPagamento = New System.Windows.Forms.CheckBox
        Me.chkAprovadorReNegociacao = New System.Windows.Forms.CheckBox
        Me.chkAutorizaDescontoJuros = New System.Windows.Forms.CheckBox
        Me.txtValorMaximo = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.txtValorMinimo = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.grdAprovacao = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.txtAprovacao_SacoMaximo = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtAprovacao_SacoMinimo = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.lstFilialUsuarioAprova = New System.Windows.Forms.CheckedListBox
        Me.cboAprovacao_TipoAprovacao = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Validade = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabListagem = New System.Windows.Forms.TabPage
        Me.cboStatus_Filtro = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmdPesquisar = New Infragistics.Win.Misc.UltraButton
        Me.txtFiltro_EMail = New System.Windows.Forms.TextBox
        Me.txtFiltro_NomeUsuario = New System.Windows.Forms.TextBox
        Me.txtFiltro_CodigoUsuario = New System.Windows.Forms.TextBox
        Me.grdGeral = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.tabDados = New System.Windows.Forms.TabPage
        Me.cmdCancelar_Usuario = New Infragistics.Win.Misc.UltraButton
        Me.cmdGravar_Usuario = New Infragistics.Win.Misc.UltraButton
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.tabAcessoUsuario = New System.Windows.Forms.TabPage
        Me.cmdCancelar_Acesso = New Infragistics.Win.Misc.UltraButton
        Me.lblUsuarioAcessoUsuario = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.cboUsuarioCopia = New System.Windows.Forms.ComboBox
        Me.cmdGravar_AcessoUsuario = New Infragistics.Win.Misc.UltraButton
        Me.grdAreaAcesso = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.tabGrupoAcesso = New System.Windows.Forms.TabPage
        Me.cmdGravar_Grupo = New Infragistics.Win.Misc.UltraButton
        Me.lblUsuarioGrupoUsuario = New System.Windows.Forms.Label
        Me.grdGrupoUsuario = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.cmdCancelar_Grupo = New Infragistics.Win.Misc.UltraButton
        Me.tabLinkarAcesso = New System.Windows.Forms.TabPage
        Me.cmdGravar_Link = New Infragistics.Win.Misc.UltraButton
        Me.lblUsuarioLinkUsuario = New System.Windows.Forms.Label
        Me.grdLinkUsuario = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.cmdCancelar_Link = New Infragistics.Win.Misc.UltraButton
        Me.cmdNovo = New Infragistics.Win.Misc.UltraButton
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdAlterar = New Infragistics.Win.Misc.UltraButton
        Me.cmdAcesso = New Infragistics.Win.Misc.UltraButton
        Me.cmdGrupoUsuario = New Infragistics.Win.Misc.UltraButton
        Me.cmdLinkarUsuario = New Infragistics.Win.Misc.UltraButton
        Me.cmdExcell = New Infragistics.Win.Misc.UltraButton
        Me.cmdExcluir = New Infragistics.Win.Misc.UltraButton
        Me.cmdUsuarioBloqueado = New Infragistics.Win.Misc.UltraButton
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.cboNivelAprovacaoPagamento = New System.Windows.Forms.ComboBox
        Me.tabDadosGerais.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtDtFimUtilizacao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDadosComplementares.SuspendLayout()
        CType(Me.txtAprovacao_Validade, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorMaximo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorMinimo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdAprovacao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAprovacao_SacoMaximo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAprovacao_SacoMinimo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tabListagem.SuspendLayout()
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDados.SuspendLayout()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        Me.tabAcessoUsuario.SuspendLayout()
        CType(Me.grdAreaAcesso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabGrupoAcesso.SuspendLayout()
        CType(Me.grdGrupoUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabLinkarAcesso.SuspendLayout()
        CType(Me.grdLinkUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabDadosGerais
        '
        Me.tabDadosGerais.Controls.Add(Me.GroupBox1)
        Me.tabDadosGerais.Controls.Add(Me.cboStatus)
        Me.tabDadosGerais.Controls.Add(Me.Label12)
        Me.tabDadosGerais.Controls.Add(Me.Pesq_UsuarioCopia)
        Me.tabDadosGerais.Controls.Add(Me.txtRhId)
        Me.tabDadosGerais.Controls.Add(Me.txtCodigoUsuarioDS)
        Me.tabDadosGerais.Controls.Add(Me.chkBloqueadoTempoUso)
        Me.tabDadosGerais.Controls.Add(Me.lstFilialLiberadasUsuario)
        Me.tabDadosGerais.Controls.Add(Me.txtDtFimUtilizacao)
        Me.tabDadosGerais.Controls.Add(Me.txtEMail)
        Me.tabDadosGerais.Controls.Add(Me.txtNomeUsuario)
        Me.tabDadosGerais.Controls.Add(Me.txtCodigoUsuario)
        Me.tabDadosGerais.Controls.Add(Me.Label8)
        Me.tabDadosGerais.Controls.Add(Me.Label9)
        Me.tabDadosGerais.Controls.Add(Me.Label10)
        Me.tabDadosGerais.Controls.Add(Me.Label7)
        Me.tabDadosGerais.Controls.Add(Me.lblR_UsuarioCopia)
        Me.tabDadosGerais.Controls.Add(Me.Label2)
        Me.tabDadosGerais.Controls.Add(Me.Label13)
        Me.tabDadosGerais.Controls.Add(Me.Label1)
        Me.tabDadosGerais.Location = New System.Drawing.Point(-10000, -10000)
        Me.tabDadosGerais.Name = "tabDadosGerais"
        Me.tabDadosGerais.Size = New System.Drawing.Size(818, 332)
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lblUltimoAcesso)
        Me.GroupBox1.Location = New System.Drawing.Point(669, 275)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(141, 37)
        Me.GroupBox1.TabIndex = 270
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Último Acesso "
        '
        'lblUltimoAcesso
        '
        Me.lblUltimoAcesso.AutoSize = True
        Me.lblUltimoAcesso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUltimoAcesso.Location = New System.Drawing.Point(6, 18)
        Me.lblUltimoAcesso.Name = "lblUltimoAcesso"
        Me.lblUltimoAcesso.Size = New System.Drawing.Size(129, 13)
        Me.lblUltimoAcesso.TabIndex = 3
        Me.lblUltimoAcesso.Text = "99/99/9999 99:99:99"
        '
        'cboStatus
        '
        Me.cboStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(672, 117)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(100, 21)
        Me.cboStatus.TabIndex = 269
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(672, 102)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(37, 13)
        Me.Label12.TabIndex = 268
        Me.Label12.Text = "Status"
        '
        'Pesq_UsuarioCopia
        '
        Me.Pesq_UsuarioCopia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pesq_UsuarioCopia.Ativo = True
        Me.Pesq_UsuarioCopia.BackColor = System.Drawing.Color.Transparent
        Me.Pesq_UsuarioCopia.BancoDados_Campo_Codigo = Nothing
        Me.Pesq_UsuarioCopia.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_UsuarioCopia.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_UsuarioCopia.BancoDados_Campo_Descricao = Nothing
        Me.Pesq_UsuarioCopia.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_UsuarioCopia.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_UsuarioCopia.BancoDados_Tabela = Nothing
        Me.Pesq_UsuarioCopia.Codigo = 0
        Me.Pesq_UsuarioCopia.Descricao = ""
        Me.Pesq_UsuarioCopia.ExibirCodigo = True
        Me.Pesq_UsuarioCopia.Location = New System.Drawing.Point(282, 66)
        Me.Pesq_UsuarioCopia.MaximumSize = New System.Drawing.Size(1000, 23)
        Me.Pesq_UsuarioCopia.MinimumSize = New System.Drawing.Size(0, 23)
        Me.Pesq_UsuarioCopia.Name = "Pesq_UsuarioCopia"
        Me.Pesq_UsuarioCopia.Size = New System.Drawing.Size(526, 23)
        Me.Pesq_UsuarioCopia.TabIndex = 266
        Me.Pesq_UsuarioCopia.TelaFiltro = False
        Me.Pesq_UsuarioCopia.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Inicializar
        '
        'txtRhId
        '
        Me.txtRhId.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRhId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRhId.Location = New System.Drawing.Point(704, 23)
        Me.txtRhId.MaxLength = 10
        Me.txtRhId.Name = "txtRhId"
        Me.txtRhId.Size = New System.Drawing.Size(104, 20)
        Me.txtRhId.TabIndex = 265
        '
        'txtCodigoUsuarioDS
        '
        Me.txtCodigoUsuarioDS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoUsuarioDS.Location = New System.Drawing.Point(128, 23)
        Me.txtCodigoUsuarioDS.MaxLength = 10
        Me.txtCodigoUsuarioDS.Name = "txtCodigoUsuarioDS"
        Me.txtCodigoUsuarioDS.Size = New System.Drawing.Size(112, 20)
        Me.txtCodigoUsuarioDS.TabIndex = 262
        '
        'chkBloqueadoTempoUso
        '
        Me.chkBloqueadoTempoUso.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkBloqueadoTempoUso.BackColor = System.Drawing.Color.Transparent
        Me.chkBloqueadoTempoUso.Checked = True
        Me.chkBloqueadoTempoUso.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBloqueadoTempoUso.Location = New System.Drawing.Point(672, 197)
        Me.chkBloqueadoTempoUso.Name = "chkBloqueadoTempoUso"
        Me.chkBloqueadoTempoUso.Size = New System.Drawing.Size(136, 30)
        Me.chkBloqueadoTempoUso.TabIndex = 38
        Me.chkBloqueadoTempoUso.Text = "Bloqueado por Tempo sem Uso do Sistema"
        Me.chkBloqueadoTempoUso.UseVisualStyleBackColor = False
        '
        'lstFilialLiberadasUsuario
        '
        Me.lstFilialLiberadasUsuario.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstFilialLiberadasUsuario.CheckOnClick = True
        Me.lstFilialLiberadasUsuario.FormattingEnabled = True
        Me.lstFilialLiberadasUsuario.Location = New System.Drawing.Point(8, 117)
        Me.lstFilialLiberadasUsuario.Name = "lstFilialLiberadasUsuario"
        Me.lstFilialLiberadasUsuario.Size = New System.Drawing.Size(656, 184)
        Me.lstFilialLiberadasUsuario.TabIndex = 36
        Me.lstFilialLiberadasUsuario.ThreeDCheckBoxes = True
        '
        'txtDtFimUtilizacao
        '
        Me.txtDtFimUtilizacao.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDtFimUtilizacao.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtDtFimUtilizacao.Location = New System.Drawing.Point(672, 160)
        Me.txtDtFimUtilizacao.Name = "txtDtFimUtilizacao"
        Me.txtDtFimUtilizacao.Size = New System.Drawing.Size(102, 21)
        Me.txtDtFimUtilizacao.TabIndex = 35
        Me.txtDtFimUtilizacao.Value = Nothing
        '
        'txtEMail
        '
        Me.txtEMail.Location = New System.Drawing.Point(8, 66)
        Me.txtEMail.MaxLength = 50
        Me.txtEMail.Name = "txtEMail"
        Me.txtEMail.Size = New System.Drawing.Size(266, 20)
        Me.txtEMail.TabIndex = 27
        '
        'txtNomeUsuario
        '
        Me.txtNomeUsuario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNomeUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNomeUsuario.Location = New System.Drawing.Point(248, 23)
        Me.txtNomeUsuario.MaxLength = 50
        Me.txtNomeUsuario.Name = "txtNomeUsuario"
        Me.txtNomeUsuario.Size = New System.Drawing.Size(450, 20)
        Me.txtNomeUsuario.TabIndex = 24
        '
        'txtCodigoUsuario
        '
        Me.txtCodigoUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoUsuario.Location = New System.Drawing.Point(8, 23)
        Me.txtCodigoUsuario.MaxLength = 10
        Me.txtCodigoUsuario.Name = "txtCodigoUsuario"
        Me.txtCodigoUsuario.Size = New System.Drawing.Size(112, 20)
        Me.txtCodigoUsuario.TabIndex = 22
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(672, 146)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 13)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Limite de Utilização"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(8, 102)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(153, 13)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "Filiais Liberadas para o Usuário"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(128, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 13)
        Me.Label10.TabIndex = 263
        Me.Label10.Text = "Código do Usuário DS"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(8, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "E-Mail"
        '
        'lblR_UsuarioCopia
        '
        Me.lblR_UsuarioCopia.AutoSize = True
        Me.lblR_UsuarioCopia.BackColor = System.Drawing.Color.Transparent
        Me.lblR_UsuarioCopia.Location = New System.Drawing.Point(282, 51)
        Me.lblR_UsuarioCopia.Name = "lblR_UsuarioCopia"
        Me.lblR_UsuarioCopia.Size = New System.Drawing.Size(73, 13)
        Me.lblR_UsuarioCopia.TabIndex = 267
        Me.lblR_UsuarioCopia.Text = "Usuário Copia"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(248, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Nome do Usuário"
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(704, 8)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(35, 13)
        Me.Label13.TabIndex = 264
        Me.Label13.Text = "Rh ID"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Código do Usuário"
        '
        'tabDadosComplementares
        '
        Me.tabDadosComplementares.Controls.Add(Me.cboNivelAprovacaoPagamento)
        Me.tabDadosComplementares.Controls.Add(Me.Label21)
        Me.tabDadosComplementares.Controls.Add(Me.chkAprovacao_Validade)
        Me.tabDadosComplementares.Controls.Add(Me.txtAprovacao_Validade)
        Me.tabDadosComplementares.Controls.Add(Me.cmdAprovacao_Novo)
        Me.tabDadosComplementares.Controls.Add(Me.cmdAprovacao_Adicionar)
        Me.tabDadosComplementares.Controls.Add(Me.chkAprovadorPagamento)
        Me.tabDadosComplementares.Controls.Add(Me.chkAprovadorReNegociacao)
        Me.tabDadosComplementares.Controls.Add(Me.chkAutorizaDescontoJuros)
        Me.tabDadosComplementares.Controls.Add(Me.txtValorMaximo)
        Me.tabDadosComplementares.Controls.Add(Me.txtValorMinimo)
        Me.tabDadosComplementares.Controls.Add(Me.grdAprovacao)
        Me.tabDadosComplementares.Controls.Add(Me.txtAprovacao_SacoMaximo)
        Me.tabDadosComplementares.Controls.Add(Me.txtAprovacao_SacoMinimo)
        Me.tabDadosComplementares.Controls.Add(Me.lstFilialUsuarioAprova)
        Me.tabDadosComplementares.Controls.Add(Me.cboAprovacao_TipoAprovacao)
        Me.tabDadosComplementares.Controls.Add(Me.Label15)
        Me.tabDadosComplementares.Controls.Add(Me.Label11)
        Me.tabDadosComplementares.Controls.Add(Me.Label20)
        Me.tabDadosComplementares.Controls.Add(Me.Label19)
        Me.tabDadosComplementares.Controls.Add(Me.Label17)
        Me.tabDadosComplementares.Controls.Add(Me.Validade)
        Me.tabDadosComplementares.Controls.Add(Me.Label18)
        Me.tabDadosComplementares.Location = New System.Drawing.Point(1, 23)
        Me.tabDadosComplementares.Name = "tabDadosComplementares"
        Me.tabDadosComplementares.Size = New System.Drawing.Size(818, 332)
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Location = New System.Drawing.Point(204, 31)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(55, 13)
        Me.Label21.TabIndex = 394
        Me.Label21.Text = "Nível Apr."
        '
        'chkAprovacao_Validade
        '
        Me.chkAprovacao_Validade.AutoSize = True
        Me.chkAprovacao_Validade.BackColor = System.Drawing.Color.Transparent
        Me.chkAprovacao_Validade.Location = New System.Drawing.Point(314, 74)
        Me.chkAprovacao_Validade.Name = "chkAprovacao_Validade"
        Me.chkAprovacao_Validade.Size = New System.Drawing.Size(15, 14)
        Me.chkAprovacao_Validade.TabIndex = 254
        Me.chkAprovacao_Validade.UseVisualStyleBackColor = False
        '
        'txtAprovacao_Validade
        '
        Me.txtAprovacao_Validade.DateTime = New Date(2010, 12, 30, 0, 0, 0, 0)
        Me.txtAprovacao_Validade.Location = New System.Drawing.Point(258, 90)
        Me.txtAprovacao_Validade.Name = "txtAprovacao_Validade"
        Me.txtAprovacao_Validade.Size = New System.Drawing.Size(100, 21)
        Me.txtAprovacao_Validade.TabIndex = 253
        Me.txtAprovacao_Validade.Value = New Date(2010, 12, 30, 0, 0, 0, 0)
        '
        'cmdAprovacao_Novo
        '
        Me.cmdAprovacao_Novo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance7.Image = Global.Logus.My.Resources.Resources.Novo
        Appearance7.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance7.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.cmdAprovacao_Novo.Appearance = Appearance7
        Me.cmdAprovacao_Novo.Location = New System.Drawing.Point(747, 83)
        Me.cmdAprovacao_Novo.Name = "cmdAprovacao_Novo"
        Me.cmdAprovacao_Novo.Size = New System.Drawing.Size(28, 28)
        Me.cmdAprovacao_Novo.TabIndex = 251
        Me.cmdAprovacao_Novo.TabStop = False
        '
        'cmdAprovacao_Adicionar
        '
        Me.cmdAprovacao_Adicionar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance8.Image = Global.Logus.My.Resources.Resources.Expand_Vertical
        Appearance8.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance8.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.cmdAprovacao_Adicionar.Appearance = Appearance8
        Me.cmdAprovacao_Adicionar.Location = New System.Drawing.Point(781, 83)
        Me.cmdAprovacao_Adicionar.Name = "cmdAprovacao_Adicionar"
        Me.cmdAprovacao_Adicionar.Size = New System.Drawing.Size(28, 28)
        Me.cmdAprovacao_Adicionar.TabIndex = 252
        Me.cmdAprovacao_Adicionar.TabStop = False
        '
        'chkAprovadorPagamento
        '
        Me.chkAprovadorPagamento.AutoSize = True
        Me.chkAprovadorPagamento.BackColor = System.Drawing.Color.Transparent
        Me.chkAprovadorPagamento.Location = New System.Drawing.Point(150, 6)
        Me.chkAprovadorPagamento.Name = "chkAprovadorPagamento"
        Me.chkAprovadorPagamento.Size = New System.Drawing.Size(132, 17)
        Me.chkAprovadorPagamento.TabIndex = 61
        Me.chkAprovadorPagamento.Text = "Aprovador Pagamento"
        Me.chkAprovadorPagamento.UseVisualStyleBackColor = False
        '
        'chkAprovadorReNegociacao
        '
        Me.chkAprovadorReNegociacao.AutoSize = True
        Me.chkAprovadorReNegociacao.BackColor = System.Drawing.Color.Transparent
        Me.chkAprovadorReNegociacao.Location = New System.Drawing.Point(290, 6)
        Me.chkAprovadorReNegociacao.Name = "chkAprovadorReNegociacao"
        Me.chkAprovadorReNegociacao.Size = New System.Drawing.Size(168, 17)
        Me.chkAprovadorReNegociacao.TabIndex = 60
        Me.chkAprovadorReNegociacao.Text = "Aprovador de Re-Negociação"
        Me.chkAprovadorReNegociacao.UseVisualStyleBackColor = False
        '
        'chkAutorizaDescontoJuros
        '
        Me.chkAutorizaDescontoJuros.AutoSize = True
        Me.chkAutorizaDescontoJuros.BackColor = System.Drawing.Color.Transparent
        Me.chkAutorizaDescontoJuros.Location = New System.Drawing.Point(6, 6)
        Me.chkAutorizaDescontoJuros.Name = "chkAutorizaDescontoJuros"
        Me.chkAutorizaDescontoJuros.Size = New System.Drawing.Size(136, 17)
        Me.chkAutorizaDescontoJuros.TabIndex = 59
        Me.chkAutorizaDescontoJuros.Text = "Autoriza desconto juros"
        Me.chkAutorizaDescontoJuros.UseVisualStyleBackColor = False
        '
        'txtValorMaximo
        '
        Me.txtValorMaximo.Location = New System.Drawing.Point(106, 46)
        Me.txtValorMaximo.Name = "txtValorMaximo"
        Me.txtValorMaximo.Size = New System.Drawing.Size(90, 21)
        Me.txtValorMaximo.TabIndex = 57
        '
        'txtValorMinimo
        '
        Me.txtValorMinimo.Location = New System.Drawing.Point(8, 46)
        Me.txtValorMinimo.Name = "txtValorMinimo"
        Me.txtValorMinimo.Size = New System.Drawing.Size(90, 21)
        Me.txtValorMinimo.TabIndex = 55
        '
        'grdAprovacao
        '
        Me.grdAprovacao.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdAprovacao.DisplayLayout.Appearance = Appearance1
        Me.grdAprovacao.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdAprovacao.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance63.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance63.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance63.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance63.BorderColor = System.Drawing.SystemColors.Window
        Me.grdAprovacao.DisplayLayout.GroupByBox.Appearance = Appearance63
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdAprovacao.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.grdAprovacao.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdAprovacao.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.grdAprovacao.DisplayLayout.MaxColScrollRegions = 1
        Me.grdAprovacao.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdAprovacao.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdAprovacao.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.grdAprovacao.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdAprovacao.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance61.BackColor = System.Drawing.SystemColors.Window
        Me.grdAprovacao.DisplayLayout.Override.CardAreaAppearance = Appearance61
        Appearance62.BorderColor = System.Drawing.Color.Silver
        Appearance62.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdAprovacao.DisplayLayout.Override.CellAppearance = Appearance62
        Me.grdAprovacao.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdAprovacao.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.grdAprovacao.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.grdAprovacao.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.grdAprovacao.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdAprovacao.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.grdAprovacao.DisplayLayout.Override.RowAppearance = Appearance11
        Me.grdAprovacao.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdAprovacao.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.grdAprovacao.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdAprovacao.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdAprovacao.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdAprovacao.Location = New System.Drawing.Point(258, 117)
        Me.grdAprovacao.Name = "grdAprovacao"
        Me.grdAprovacao.Size = New System.Drawing.Size(551, 207)
        Me.grdAprovacao.TabIndex = 54
        Me.grdAprovacao.Text = "UltraGrid1"
        '
        'txtAprovacao_SacoMaximo
        '
        Me.txtAprovacao_SacoMaximo.Location = New System.Drawing.Point(593, 46)
        Me.txtAprovacao_SacoMaximo.Name = "txtAprovacao_SacoMaximo"
        Me.txtAprovacao_SacoMaximo.Size = New System.Drawing.Size(84, 21)
        Me.txtAprovacao_SacoMaximo.TabIndex = 51
        '
        'txtAprovacao_SacoMinimo
        '
        Me.txtAprovacao_SacoMinimo.Location = New System.Drawing.Point(501, 46)
        Me.txtAprovacao_SacoMinimo.Name = "txtAprovacao_SacoMinimo"
        Me.txtAprovacao_SacoMinimo.Size = New System.Drawing.Size(84, 21)
        Me.txtAprovacao_SacoMinimo.TabIndex = 50
        '
        'lstFilialUsuarioAprova
        '
        Me.lstFilialUsuarioAprova.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstFilialUsuarioAprova.CheckOnClick = True
        Me.lstFilialUsuarioAprova.FormattingEnabled = True
        Me.lstFilialUsuarioAprova.Location = New System.Drawing.Point(6, 90)
        Me.lstFilialUsuarioAprova.Name = "lstFilialUsuarioAprova"
        Me.lstFilialUsuarioAprova.Size = New System.Drawing.Size(246, 229)
        Me.lstFilialUsuarioAprova.TabIndex = 48
        Me.lstFilialUsuarioAprova.ThreeDCheckBoxes = True
        '
        'cboAprovacao_TipoAprovacao
        '
        Me.cboAprovacao_TipoAprovacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAprovacao_TipoAprovacao.FormattingEnabled = True
        Me.cboAprovacao_TipoAprovacao.Location = New System.Drawing.Point(258, 46)
        Me.cboAprovacao_TipoAprovacao.Name = "cboAprovacao_TipoAprovacao"
        Me.cboAprovacao_TipoAprovacao.Size = New System.Drawing.Size(235, 21)
        Me.cboAprovacao_TipoAprovacao.TabIndex = 47
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(593, 31)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(43, 13)
        Me.Label15.TabIndex = 63
        Me.Label15.Text = "Máximo"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(501, 31)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 13)
        Me.Label11.TabIndex = 62
        Me.Label11.Text = "Mínimo"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Location = New System.Drawing.Point(106, 31)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(70, 13)
        Me.Label20.TabIndex = 58
        Me.Label20.Text = "Valor Máximo"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(8, 31)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(69, 13)
        Me.Label19.TabIndex = 56
        Me.Label19.Text = "Valor Mínimo"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(258, 31)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(98, 13)
        Me.Label17.TabIndex = 46
        Me.Label17.Text = "Tipo de Aprovação"
        '
        'Validade
        '
        Me.Validade.AutoSize = True
        Me.Validade.BackColor = System.Drawing.Color.Transparent
        Me.Validade.Location = New System.Drawing.Point(258, 75)
        Me.Validade.Name = "Validade"
        Me.Validade.Size = New System.Drawing.Size(48, 13)
        Me.Validade.TabIndex = 52
        Me.Validade.Text = "Validade"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Location = New System.Drawing.Point(6, 75)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(170, 13)
        Me.Label18.TabIndex = 49
        Me.Label18.Text = "Filiais pelas quais o usuário aprova"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.tabListagem)
        Me.TabControl1.Controls.Add(Me.tabDados)
        Me.TabControl1.Controls.Add(Me.tabAcessoUsuario)
        Me.TabControl1.Controls.Add(Me.tabGrupoAcesso)
        Me.TabControl1.Controls.Add(Me.tabLinkarAcesso)
        Me.TabControl1.Location = New System.Drawing.Point(8, 8)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(844, 447)
        Me.TabControl1.TabIndex = 0
        '
        'tabListagem
        '
        Me.tabListagem.Controls.Add(Me.cboStatus_Filtro)
        Me.tabListagem.Controls.Add(Me.Label16)
        Me.tabListagem.Controls.Add(Me.cmdPesquisar)
        Me.tabListagem.Controls.Add(Me.txtFiltro_EMail)
        Me.tabListagem.Controls.Add(Me.txtFiltro_NomeUsuario)
        Me.tabListagem.Controls.Add(Me.txtFiltro_CodigoUsuario)
        Me.tabListagem.Controls.Add(Me.grdGeral)
        Me.tabListagem.Controls.Add(Me.Label5)
        Me.tabListagem.Controls.Add(Me.Label4)
        Me.tabListagem.Controls.Add(Me.Label3)
        Me.tabListagem.Controls.Add(Me.Label6)
        Me.tabListagem.ImageIndex = 4
        Me.tabListagem.Location = New System.Drawing.Point(4, 25)
        Me.tabListagem.Name = "tabListagem"
        Me.tabListagem.Size = New System.Drawing.Size(836, 418)
        Me.tabListagem.TabIndex = 0
        Me.tabListagem.Text = "Listagem"
        Me.tabListagem.UseVisualStyleBackColor = True
        '
        'cboStatus_Filtro
        '
        Me.cboStatus_Filtro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboStatus_Filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus_Filtro.FormattingEnabled = True
        Me.cboStatus_Filtro.Location = New System.Drawing.Point(687, 65)
        Me.cboStatus_Filtro.Name = "cboStatus_Filtro"
        Me.cboStatus_Filtro.Size = New System.Drawing.Size(90, 21)
        Me.cboStatus_Filtro.TabIndex = 11
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(687, 51)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(37, 13)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "Status"
        '
        'cmdPesquisar
        '
        Me.cmdPesquisar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPesquisar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdPesquisar.Location = New System.Drawing.Point(783, 50)
        Me.cmdPesquisar.Name = "cmdPesquisar"
        Me.cmdPesquisar.Size = New System.Drawing.Size(45, 45)
        Me.cmdPesquisar.TabIndex = 7
        '
        'txtFiltro_EMail
        '
        Me.txtFiltro_EMail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltro_EMail.Location = New System.Drawing.Point(6, 66)
        Me.txtFiltro_EMail.Name = "txtFiltro_EMail"
        Me.txtFiltro_EMail.Size = New System.Drawing.Size(675, 20)
        Me.txtFiltro_EMail.TabIndex = 5
        '
        'txtFiltro_NomeUsuario
        '
        Me.txtFiltro_NomeUsuario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltro_NomeUsuario.Location = New System.Drawing.Point(136, 22)
        Me.txtFiltro_NomeUsuario.MaxLength = 50
        Me.txtFiltro_NomeUsuario.Name = "txtFiltro_NomeUsuario"
        Me.txtFiltro_NomeUsuario.Size = New System.Drawing.Size(692, 20)
        Me.txtFiltro_NomeUsuario.TabIndex = 3
        '
        'txtFiltro_CodigoUsuario
        '
        Me.txtFiltro_CodigoUsuario.Location = New System.Drawing.Point(6, 22)
        Me.txtFiltro_CodigoUsuario.Name = "txtFiltro_CodigoUsuario"
        Me.txtFiltro_CodigoUsuario.Size = New System.Drawing.Size(122, 20)
        Me.txtFiltro_CodigoUsuario.TabIndex = 2
        '
        'grdGeral
        '
        Me.grdGeral.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance49.BackColor = System.Drawing.SystemColors.Window
        Appearance49.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdGeral.DisplayLayout.Appearance = Appearance49
        Me.grdGeral.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdGeral.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance50.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance50.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance50.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance50.BorderColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.GroupByBox.Appearance = Appearance50
        Appearance51.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdGeral.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance51
        Me.grdGeral.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance52.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance52.BackColor2 = System.Drawing.SystemColors.Control
        Appearance52.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance52.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdGeral.DisplayLayout.GroupByBox.PromptAppearance = Appearance52
        Me.grdGeral.DisplayLayout.MaxColScrollRegions = 1
        Me.grdGeral.DisplayLayout.MaxRowScrollRegions = 1
        Appearance53.BackColor = System.Drawing.SystemColors.Window
        Appearance53.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdGeral.DisplayLayout.Override.ActiveCellAppearance = Appearance53
        Appearance54.BackColor = System.Drawing.SystemColors.Highlight
        Appearance54.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdGeral.DisplayLayout.Override.ActiveRowAppearance = Appearance54
        Me.grdGeral.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdGeral.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance55.BackColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.Override.CardAreaAppearance = Appearance55
        Appearance56.BorderColor = System.Drawing.Color.Silver
        Appearance56.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdGeral.DisplayLayout.Override.CellAppearance = Appearance56
        Me.grdGeral.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdGeral.DisplayLayout.Override.CellPadding = 0
        Appearance57.BackColor = System.Drawing.SystemColors.Control
        Appearance57.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance57.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance57.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance57.BorderColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.Override.GroupByRowAppearance = Appearance57
        Appearance58.TextHAlignAsString = "Left"
        Me.grdGeral.DisplayLayout.Override.HeaderAppearance = Appearance58
        Me.grdGeral.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdGeral.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance59.BackColor = System.Drawing.SystemColors.Window
        Appearance59.BorderColor = System.Drawing.Color.Silver
        Me.grdGeral.DisplayLayout.Override.RowAppearance = Appearance59
        Me.grdGeral.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance60.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdGeral.DisplayLayout.Override.TemplateAddRowAppearance = Appearance60
        Me.grdGeral.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdGeral.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdGeral.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdGeral.Location = New System.Drawing.Point(8, 110)
        Me.grdGeral.Name = "grdGeral"
        Me.grdGeral.Size = New System.Drawing.Size(820, 303)
        Me.grdGeral.TabIndex = 0
        Me.grdGeral.Text = "UltraGrid1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "E-Mail"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(136, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Nome do Usuário"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Código do Usuário"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Listagem de Usuário"
        '
        'tabDados
        '
        Me.tabDados.Controls.Add(Me.cmdCancelar_Usuario)
        Me.tabDados.Controls.Add(Me.cmdGravar_Usuario)
        Me.tabDados.Controls.Add(Me.UltraTabControl1)
        Me.tabDados.ImageIndex = 3
        Me.tabDados.Location = New System.Drawing.Point(4, 25)
        Me.tabDados.Name = "tabDados"
        Me.tabDados.Size = New System.Drawing.Size(836, 418)
        Me.tabDados.TabIndex = 1
        Me.tabDados.Text = "Dados Usuário"
        Me.tabDados.UseVisualStyleBackColor = True
        '
        'cmdCancelar_Usuario
        '
        Me.cmdCancelar_Usuario.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar_Usuario.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdCancelar_Usuario.Location = New System.Drawing.Point(6, 370)
        Me.cmdCancelar_Usuario.Name = "cmdCancelar_Usuario"
        Me.cmdCancelar_Usuario.Size = New System.Drawing.Size(45, 45)
        Me.cmdCancelar_Usuario.TabIndex = 33
        '
        'cmdGravar_Usuario
        '
        Me.cmdGravar_Usuario.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGravar_Usuario.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar_Usuario.Location = New System.Drawing.Point(783, 370)
        Me.cmdGravar_Usuario.Name = "cmdGravar_Usuario"
        Me.cmdGravar_Usuario.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar_Usuario.TabIndex = 34
        '
        'UltraTabControl1
        '
        Me.UltraTabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.tabDadosGerais)
        Me.UltraTabControl1.Controls.Add(Me.tabDadosComplementares)
        Me.UltraTabControl1.Location = New System.Drawing.Point(6, 6)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl1.Size = New System.Drawing.Size(822, 358)
        Me.UltraTabControl1.TabIndex = 0
        UltraTab1.TabPage = Me.tabDadosGerais
        UltraTab1.Text = "Dados Gerais"
        UltraTab2.TabPage = Me.tabDadosComplementares
        UltraTab2.Text = "Dados Complementares"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(818, 332)
        '
        'tabAcessoUsuario
        '
        Me.tabAcessoUsuario.Controls.Add(Me.cmdCancelar_Acesso)
        Me.tabAcessoUsuario.Controls.Add(Me.lblUsuarioAcessoUsuario)
        Me.tabAcessoUsuario.Controls.Add(Me.Label14)
        Me.tabAcessoUsuario.Controls.Add(Me.cboUsuarioCopia)
        Me.tabAcessoUsuario.Controls.Add(Me.cmdGravar_AcessoUsuario)
        Me.tabAcessoUsuario.Controls.Add(Me.grdAreaAcesso)
        Me.tabAcessoUsuario.ImageIndex = 0
        Me.tabAcessoUsuario.Location = New System.Drawing.Point(4, 25)
        Me.tabAcessoUsuario.Name = "tabAcessoUsuario"
        Me.tabAcessoUsuario.Size = New System.Drawing.Size(836, 418)
        Me.tabAcessoUsuario.TabIndex = 2
        Me.tabAcessoUsuario.Text = "Acesso Usuário"
        Me.tabAcessoUsuario.UseVisualStyleBackColor = True
        '
        'cmdCancelar_Acesso
        '
        Me.cmdCancelar_Acesso.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar_Acesso.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdCancelar_Acesso.Location = New System.Drawing.Point(10, 362)
        Me.cmdCancelar_Acesso.Name = "cmdCancelar_Acesso"
        Me.cmdCancelar_Acesso.Size = New System.Drawing.Size(45, 45)
        Me.cmdCancelar_Acesso.TabIndex = 43
        '
        'lblUsuarioAcessoUsuario
        '
        Me.lblUsuarioAcessoUsuario.AutoSize = True
        Me.lblUsuarioAcessoUsuario.BackColor = System.Drawing.Color.White
        Me.lblUsuarioAcessoUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUsuarioAcessoUsuario.Location = New System.Drawing.Point(10, 13)
        Me.lblUsuarioAcessoUsuario.Name = "lblUsuarioAcessoUsuario"
        Me.lblUsuarioAcessoUsuario.Size = New System.Drawing.Size(40, 15)
        Me.lblUsuarioAcessoUsuario.TabIndex = 42
        Me.lblUsuarioAcessoUsuario.Text = " Nome"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(301, 14)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(136, 13)
        Me.Label14.TabIndex = 41
        Me.Label14.Text = " Copiar acessos de Usuário"
        '
        'cboUsuarioCopia
        '
        Me.cboUsuarioCopia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboUsuarioCopia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUsuarioCopia.Location = New System.Drawing.Point(443, 10)
        Me.cboUsuarioCopia.Name = "cboUsuarioCopia"
        Me.cboUsuarioCopia.Size = New System.Drawing.Size(381, 21)
        Me.cboUsuarioCopia.TabIndex = 40
        '
        'cmdGravar_AcessoUsuario
        '
        Me.cmdGravar_AcessoUsuario.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGravar_AcessoUsuario.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar_AcessoUsuario.Location = New System.Drawing.Point(779, 362)
        Me.cmdGravar_AcessoUsuario.Name = "cmdGravar_AcessoUsuario"
        Me.cmdGravar_AcessoUsuario.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar_AcessoUsuario.TabIndex = 39
        '
        'grdAreaAcesso
        '
        Me.grdAreaAcesso.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdAreaAcesso.DisplayLayout.Appearance = Appearance13
        Me.grdAreaAcesso.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdAreaAcesso.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.grdAreaAcesso.DisplayLayout.GroupByBox.Appearance = Appearance14
        Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdAreaAcesso.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance15
        Me.grdAreaAcesso.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance16.BackColor2 = System.Drawing.SystemColors.Control
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdAreaAcesso.DisplayLayout.GroupByBox.PromptAppearance = Appearance16
        Me.grdAreaAcesso.DisplayLayout.MaxColScrollRegions = 1
        Me.grdAreaAcesso.DisplayLayout.MaxRowScrollRegions = 1
        Appearance17.BackColor = System.Drawing.SystemColors.Window
        Appearance17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdAreaAcesso.DisplayLayout.Override.ActiveCellAppearance = Appearance17
        Appearance18.BackColor = System.Drawing.SystemColors.Highlight
        Appearance18.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdAreaAcesso.DisplayLayout.Override.ActiveRowAppearance = Appearance18
        Me.grdAreaAcesso.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdAreaAcesso.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Me.grdAreaAcesso.DisplayLayout.Override.CardAreaAppearance = Appearance19
        Appearance20.BorderColor = System.Drawing.Color.Silver
        Appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdAreaAcesso.DisplayLayout.Override.CellAppearance = Appearance20
        Me.grdAreaAcesso.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdAreaAcesso.DisplayLayout.Override.CellPadding = 0
        Appearance21.BackColor = System.Drawing.SystemColors.Control
        Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance21.BorderColor = System.Drawing.SystemColors.Window
        Me.grdAreaAcesso.DisplayLayout.Override.GroupByRowAppearance = Appearance21
        Appearance22.TextHAlignAsString = "Left"
        Me.grdAreaAcesso.DisplayLayout.Override.HeaderAppearance = Appearance22
        Me.grdAreaAcesso.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdAreaAcesso.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Appearance23.BorderColor = System.Drawing.Color.Silver
        Me.grdAreaAcesso.DisplayLayout.Override.RowAppearance = Appearance23
        Me.grdAreaAcesso.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance24.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdAreaAcesso.DisplayLayout.Override.TemplateAddRowAppearance = Appearance24
        Me.grdAreaAcesso.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdAreaAcesso.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdAreaAcesso.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdAreaAcesso.Location = New System.Drawing.Point(10, 36)
        Me.grdAreaAcesso.Name = "grdAreaAcesso"
        Me.grdAreaAcesso.Size = New System.Drawing.Size(814, 318)
        Me.grdAreaAcesso.TabIndex = 38
        Me.grdAreaAcesso.Text = "UltraGrid1"
        '
        'tabGrupoAcesso
        '
        Me.tabGrupoAcesso.Controls.Add(Me.cmdGravar_Grupo)
        Me.tabGrupoAcesso.Controls.Add(Me.lblUsuarioGrupoUsuario)
        Me.tabGrupoAcesso.Controls.Add(Me.grdGrupoUsuario)
        Me.tabGrupoAcesso.Controls.Add(Me.cmdCancelar_Grupo)
        Me.tabGrupoAcesso.ImageIndex = 1
        Me.tabGrupoAcesso.Location = New System.Drawing.Point(4, 25)
        Me.tabGrupoAcesso.Name = "tabGrupoAcesso"
        Me.tabGrupoAcesso.Padding = New System.Windows.Forms.Padding(3)
        Me.tabGrupoAcesso.Size = New System.Drawing.Size(836, 418)
        Me.tabGrupoAcesso.TabIndex = 3
        Me.tabGrupoAcesso.Text = "Grupo de Acesso"
        Me.tabGrupoAcesso.UseVisualStyleBackColor = True
        '
        'cmdGravar_Grupo
        '
        Me.cmdGravar_Grupo.AcceptsFocus = False
        Me.cmdGravar_Grupo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGravar_Grupo.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar_Grupo.Location = New System.Drawing.Point(779, 362)
        Me.cmdGravar_Grupo.Name = "cmdGravar_Grupo"
        Me.cmdGravar_Grupo.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar_Grupo.TabIndex = 45
        '
        'lblUsuarioGrupoUsuario
        '
        Me.lblUsuarioGrupoUsuario.AutoSize = True
        Me.lblUsuarioGrupoUsuario.BackColor = System.Drawing.Color.White
        Me.lblUsuarioGrupoUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUsuarioGrupoUsuario.Location = New System.Drawing.Point(10, 13)
        Me.lblUsuarioGrupoUsuario.Name = "lblUsuarioGrupoUsuario"
        Me.lblUsuarioGrupoUsuario.Size = New System.Drawing.Size(40, 15)
        Me.lblUsuarioGrupoUsuario.TabIndex = 44
        Me.lblUsuarioGrupoUsuario.Text = " Nome"
        '
        'grdGrupoUsuario
        '
        Me.grdGrupoUsuario.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance25.BackColor = System.Drawing.SystemColors.Window
        Appearance25.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdGrupoUsuario.DisplayLayout.Appearance = Appearance25
        Me.grdGrupoUsuario.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdGrupoUsuario.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance26.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance26.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance26.BorderColor = System.Drawing.SystemColors.Window
        Me.grdGrupoUsuario.DisplayLayout.GroupByBox.Appearance = Appearance26
        Appearance27.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdGrupoUsuario.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance27
        Me.grdGrupoUsuario.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance28.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance28.BackColor2 = System.Drawing.SystemColors.Control
        Appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance28.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdGrupoUsuario.DisplayLayout.GroupByBox.PromptAppearance = Appearance28
        Me.grdGrupoUsuario.DisplayLayout.MaxColScrollRegions = 1
        Me.grdGrupoUsuario.DisplayLayout.MaxRowScrollRegions = 1
        Appearance29.BackColor = System.Drawing.SystemColors.Window
        Appearance29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdGrupoUsuario.DisplayLayout.Override.ActiveCellAppearance = Appearance29
        Appearance30.BackColor = System.Drawing.SystemColors.Highlight
        Appearance30.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdGrupoUsuario.DisplayLayout.Override.ActiveRowAppearance = Appearance30
        Me.grdGrupoUsuario.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdGrupoUsuario.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance31.BackColor = System.Drawing.SystemColors.Window
        Me.grdGrupoUsuario.DisplayLayout.Override.CardAreaAppearance = Appearance31
        Appearance32.BorderColor = System.Drawing.Color.Silver
        Appearance32.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdGrupoUsuario.DisplayLayout.Override.CellAppearance = Appearance32
        Me.grdGrupoUsuario.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdGrupoUsuario.DisplayLayout.Override.CellPadding = 0
        Appearance33.BackColor = System.Drawing.SystemColors.Control
        Appearance33.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance33.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance33.BorderColor = System.Drawing.SystemColors.Window
        Me.grdGrupoUsuario.DisplayLayout.Override.GroupByRowAppearance = Appearance33
        Appearance34.TextHAlignAsString = "Left"
        Me.grdGrupoUsuario.DisplayLayout.Override.HeaderAppearance = Appearance34
        Me.grdGrupoUsuario.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdGrupoUsuario.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance35.BackColor = System.Drawing.SystemColors.Window
        Appearance35.BorderColor = System.Drawing.Color.Silver
        Me.grdGrupoUsuario.DisplayLayout.Override.RowAppearance = Appearance35
        Me.grdGrupoUsuario.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance36.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdGrupoUsuario.DisplayLayout.Override.TemplateAddRowAppearance = Appearance36
        Me.grdGrupoUsuario.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdGrupoUsuario.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdGrupoUsuario.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdGrupoUsuario.Location = New System.Drawing.Point(10, 36)
        Me.grdGrupoUsuario.Name = "grdGrupoUsuario"
        Me.grdGrupoUsuario.Size = New System.Drawing.Size(814, 318)
        Me.grdGrupoUsuario.TabIndex = 43
        Me.grdGrupoUsuario.Text = "UltraGrid2"
        '
        'cmdCancelar_Grupo
        '
        Me.cmdCancelar_Grupo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar_Grupo.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdCancelar_Grupo.Location = New System.Drawing.Point(10, 362)
        Me.cmdCancelar_Grupo.Name = "cmdCancelar_Grupo"
        Me.cmdCancelar_Grupo.Size = New System.Drawing.Size(45, 45)
        Me.cmdCancelar_Grupo.TabIndex = 39
        '
        'tabLinkarAcesso
        '
        Me.tabLinkarAcesso.Controls.Add(Me.cmdGravar_Link)
        Me.tabLinkarAcesso.Controls.Add(Me.lblUsuarioLinkUsuario)
        Me.tabLinkarAcesso.Controls.Add(Me.grdLinkUsuario)
        Me.tabLinkarAcesso.Controls.Add(Me.cmdCancelar_Link)
        Me.tabLinkarAcesso.ImageIndex = 2
        Me.tabLinkarAcesso.Location = New System.Drawing.Point(4, 25)
        Me.tabLinkarAcesso.Name = "tabLinkarAcesso"
        Me.tabLinkarAcesso.Padding = New System.Windows.Forms.Padding(3)
        Me.tabLinkarAcesso.Size = New System.Drawing.Size(836, 418)
        Me.tabLinkarAcesso.TabIndex = 4
        Me.tabLinkarAcesso.Text = "Linkar Acesso"
        Me.tabLinkarAcesso.UseVisualStyleBackColor = True
        '
        'cmdGravar_Link
        '
        Me.cmdGravar_Link.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGravar_Link.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar_Link.Location = New System.Drawing.Point(779, 362)
        Me.cmdGravar_Link.Name = "cmdGravar_Link"
        Me.cmdGravar_Link.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar_Link.TabIndex = 47
        '
        'lblUsuarioLinkUsuario
        '
        Me.lblUsuarioLinkUsuario.AutoSize = True
        Me.lblUsuarioLinkUsuario.BackColor = System.Drawing.Color.White
        Me.lblUsuarioLinkUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUsuarioLinkUsuario.Location = New System.Drawing.Point(10, 13)
        Me.lblUsuarioLinkUsuario.Name = "lblUsuarioLinkUsuario"
        Me.lblUsuarioLinkUsuario.Size = New System.Drawing.Size(40, 15)
        Me.lblUsuarioLinkUsuario.TabIndex = 46
        Me.lblUsuarioLinkUsuario.Text = " Nome"
        '
        'grdLinkUsuario
        '
        Me.grdLinkUsuario.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance37.BackColor = System.Drawing.SystemColors.Window
        Appearance37.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdLinkUsuario.DisplayLayout.Appearance = Appearance37
        Me.grdLinkUsuario.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdLinkUsuario.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance38.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance38.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance38.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance38.BorderColor = System.Drawing.SystemColors.Window
        Me.grdLinkUsuario.DisplayLayout.GroupByBox.Appearance = Appearance38
        Appearance39.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdLinkUsuario.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance39
        Me.grdLinkUsuario.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance40.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance40.BackColor2 = System.Drawing.SystemColors.Control
        Appearance40.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance40.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdLinkUsuario.DisplayLayout.GroupByBox.PromptAppearance = Appearance40
        Me.grdLinkUsuario.DisplayLayout.MaxColScrollRegions = 1
        Me.grdLinkUsuario.DisplayLayout.MaxRowScrollRegions = 1
        Appearance41.BackColor = System.Drawing.SystemColors.Window
        Appearance41.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdLinkUsuario.DisplayLayout.Override.ActiveCellAppearance = Appearance41
        Appearance42.BackColor = System.Drawing.SystemColors.Highlight
        Appearance42.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdLinkUsuario.DisplayLayout.Override.ActiveRowAppearance = Appearance42
        Me.grdLinkUsuario.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdLinkUsuario.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance43.BackColor = System.Drawing.SystemColors.Window
        Me.grdLinkUsuario.DisplayLayout.Override.CardAreaAppearance = Appearance43
        Appearance44.BorderColor = System.Drawing.Color.Silver
        Appearance44.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdLinkUsuario.DisplayLayout.Override.CellAppearance = Appearance44
        Me.grdLinkUsuario.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdLinkUsuario.DisplayLayout.Override.CellPadding = 0
        Appearance45.BackColor = System.Drawing.SystemColors.Control
        Appearance45.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance45.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance45.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance45.BorderColor = System.Drawing.SystemColors.Window
        Me.grdLinkUsuario.DisplayLayout.Override.GroupByRowAppearance = Appearance45
        Appearance46.TextHAlignAsString = "Left"
        Me.grdLinkUsuario.DisplayLayout.Override.HeaderAppearance = Appearance46
        Me.grdLinkUsuario.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdLinkUsuario.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance47.BackColor = System.Drawing.SystemColors.Window
        Appearance47.BorderColor = System.Drawing.Color.Silver
        Me.grdLinkUsuario.DisplayLayout.Override.RowAppearance = Appearance47
        Me.grdLinkUsuario.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance48.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdLinkUsuario.DisplayLayout.Override.TemplateAddRowAppearance = Appearance48
        Me.grdLinkUsuario.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdLinkUsuario.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdLinkUsuario.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdLinkUsuario.Location = New System.Drawing.Point(10, 36)
        Me.grdLinkUsuario.Name = "grdLinkUsuario"
        Me.grdLinkUsuario.Size = New System.Drawing.Size(814, 318)
        Me.grdLinkUsuario.TabIndex = 45
        Me.grdLinkUsuario.Text = "UltraGrid2"
        '
        'cmdCancelar_Link
        '
        Me.cmdCancelar_Link.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar_Link.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdCancelar_Link.Location = New System.Drawing.Point(10, 362)
        Me.cmdCancelar_Link.Name = "cmdCancelar_Link"
        Me.cmdCancelar_Link.Size = New System.Drawing.Size(45, 45)
        Me.cmdCancelar_Link.TabIndex = 39
        '
        'cmdNovo
        '
        Me.cmdNovo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdNovo.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdNovo.Location = New System.Drawing.Point(58, 459)
        Me.cmdNovo.Name = "cmdNovo"
        Me.cmdNovo.Size = New System.Drawing.Size(45, 45)
        Me.cmdNovo.TabIndex = 2
        Me.cmdNovo.Text = "N"
        '
        'cmdFechar
        '
        Me.cmdFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(807, 459)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 3
        Me.cmdFechar.Text = "F"
        '
        'cmdAlterar
        '
        Me.cmdAlterar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdAlterar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdAlterar.Location = New System.Drawing.Point(109, 459)
        Me.cmdAlterar.Name = "cmdAlterar"
        Me.cmdAlterar.Size = New System.Drawing.Size(45, 45)
        Me.cmdAlterar.TabIndex = 64
        Me.cmdAlterar.Text = "A"
        '
        'cmdAcesso
        '
        Me.cmdAcesso.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdAcesso.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdAcesso.Location = New System.Drawing.Point(372, 459)
        Me.cmdAcesso.Name = "cmdAcesso"
        Me.cmdAcesso.Size = New System.Drawing.Size(45, 45)
        Me.cmdAcesso.TabIndex = 65
        Me.cmdAcesso.Text = "AC"
        '
        'cmdGrupoUsuario
        '
        Me.cmdGrupoUsuario.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdGrupoUsuario.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGrupoUsuario.Location = New System.Drawing.Point(213, 459)
        Me.cmdGrupoUsuario.Name = "cmdGrupoUsuario"
        Me.cmdGrupoUsuario.Size = New System.Drawing.Size(45, 45)
        Me.cmdGrupoUsuario.TabIndex = 66
        Me.cmdGrupoUsuario.Text = "UA"
        '
        'cmdLinkarUsuario
        '
        Me.cmdLinkarUsuario.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdLinkarUsuario.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdLinkarUsuario.Location = New System.Drawing.Point(266, 459)
        Me.cmdLinkarUsuario.Name = "cmdLinkarUsuario"
        Me.cmdLinkarUsuario.Size = New System.Drawing.Size(45, 45)
        Me.cmdLinkarUsuario.TabIndex = 67
        Me.cmdLinkarUsuario.Text = "LU"
        '
        'cmdExcell
        '
        Me.cmdExcell.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdExcell.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExcell.Location = New System.Drawing.Point(7, 459)
        Me.cmdExcell.Name = "cmdExcell"
        Me.cmdExcell.Size = New System.Drawing.Size(45, 45)
        Me.cmdExcell.TabIndex = 68
        Me.cmdExcell.Text = "Excell"
        '
        'cmdExcluir
        '
        Me.cmdExcluir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdExcluir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExcluir.Location = New System.Drawing.Point(160, 459)
        Me.cmdExcluir.Name = "cmdExcluir"
        Me.cmdExcluir.Size = New System.Drawing.Size(45, 45)
        Me.cmdExcluir.TabIndex = 69
        Me.cmdExcluir.Text = "E"
        '
        'cmdUsuarioBloqueado
        '
        Me.cmdUsuarioBloqueado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance2.Image = Global.Logus.My.Resources.Resources.Usuario_Bloqueado
        Me.cmdUsuarioBloqueado.Appearance = Appearance2
        Me.cmdUsuarioBloqueado.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdUsuarioBloqueado.Location = New System.Drawing.Point(319, 459)
        Me.cmdUsuarioBloqueado.Name = "cmdUsuarioBloqueado"
        Me.cmdUsuarioBloqueado.Size = New System.Drawing.Size(45, 45)
        Me.cmdUsuarioBloqueado.TabIndex = 70
        '
        'cboNivelAprovacaoPagamento
        '
        Me.cboNivelAprovacaoPagamento.FormattingEnabled = True
        Me.cboNivelAprovacaoPagamento.Location = New System.Drawing.Point(204, 46)
        Me.cboNivelAprovacaoPagamento.Name = "cboNivelAprovacaoPagamento"
        Me.cboNivelAprovacaoPagamento.Size = New System.Drawing.Size(45, 21)
        Me.cboNivelAprovacaoPagamento.TabIndex = 395
        '
        'frmCadastroUsuario
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(864, 511)
        Me.Controls.Add(Me.cmdUsuarioBloqueado)
        Me.Controls.Add(Me.cmdExcluir)
        Me.Controls.Add(Me.cmdExcell)
        Me.Controls.Add(Me.cmdLinkarUsuario)
        Me.Controls.Add(Me.cmdGrupoUsuario)
        Me.Controls.Add(Me.cmdAcesso)
        Me.Controls.Add(Me.cmdAlterar)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdNovo)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCadastroUsuario"
        Me.RightToLeftLayout = True
        Me.Text = "Cadastro de Usuário"
        Me.tabDadosGerais.ResumeLayout(False)
        Me.tabDadosGerais.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtDtFimUtilizacao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDadosComplementares.ResumeLayout(False)
        Me.tabDadosComplementares.PerformLayout()
        CType(Me.txtAprovacao_Validade, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorMaximo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorMinimo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdAprovacao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAprovacao_SacoMaximo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAprovacao_SacoMinimo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tabListagem.ResumeLayout(False)
        Me.tabListagem.PerformLayout()
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDados.ResumeLayout(False)
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        Me.tabAcessoUsuario.ResumeLayout(False)
        Me.tabAcessoUsuario.PerformLayout()
        CType(Me.grdAreaAcesso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabGrupoAcesso.ResumeLayout(False)
        Me.tabGrupoAcesso.PerformLayout()
        CType(Me.grdGrupoUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabLinkarAcesso.ResumeLayout(False)
        Me.tabLinkarAcesso.PerformLayout()
        CType(Me.grdLinkUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Const cnt_GridGeral_CD_USUARIO = 0
    Const cnt_GridGeral_NO_USUARIO = 1
    Const cnt_GridGeral_IC_ATIVO = 2
    Const cnt_GridGeral_DS_EMAIL = 3
    Const cnt_GridGeral_DT_CRIACAO = 4
    Const cnt_GridGeral_DT_ULTIMO_ACESSO = 5
    Const cnt_GridGeral_RH_ID = 6
    Const cnt_GridGeral_QT_DIGITAL = 7

    Const cnt_GridArea_Sq_Area = 0
    Const cnt_GridArea_CheckBox = 1
    Const cnt_GridArea_No_Area = 2

    Const cnt_GridGrupo_SQ_GRUPOACESSO = 0
    Const cnt_GridGrupo_CheckBox = 1
    Const cnt_GridGrupo_NO_GRUPOACESSO = 2
    Const cnt_GridGrupo_DT_EXPIRACAO = 3

    Const cnt_GridLink_CheckBox = 0
    Const cnt_GridLink_CD_USUARIO = 1
    Const cnt_Gridlink_NO_USUARIO = 2
    Const cnt_Gridlink_DT_EXPIRACAO = 3

    Const cnt_GridAprovacao_CD_TIPO_APROVACAO As Integer = 0
    Const cnt_GridAprovacao_NO_TIPO_APROVACAO As Integer = 1
    Const cnt_GridAprovacao_VL_MINIMO_APROVACAO As Integer = 2
    Const cnt_GridAprovacao_VL_MAXIMO_APROVACAO As Integer = 3
    Const cnt_GridAprovacao_DT_VALIDADE As Integer = 4
    Const cnt_GridAprovacao_IC_POSSUI_LIMITE As Integer = 5
    Const cnt_GridAprovacao_IC_OBRIGATORIO As Integer = 6
    Const cnt_GridAprovacao_IC_HOUVE_ALTERACAO As Integer = 7

    Const cnt_GridAreaAcesso_CD_AREAACESSO As Integer = 0
    Const cnt_GridAreaAcesso_NomeAcesso As Integer = 1

    Dim oDS As New UltraWinDataSource.UltraDataSource
    Dim oDS_Link As New UltraWinDataSource.UltraDataSource
    Dim oDS_AreaAcesso As New UltraWinDataSource.UltraDataSource
    Dim oDS_Aprovacao As New UltraWinDataSource.UltraDataSource

    Dim ControleEdicaoTelaLocal As eControleEdicaoTela
    Dim sUsuario As String
    Dim bViaBotao As Boolean
    Dim cnt_SEC_Tela As String = "SEC_CadastroUsuario"
    Dim SEC_P_Acesso_Usuario_Desbloquear As Boolean = False
    Dim sTituloTela As String

    Const cnt_ValidaAcessoDS As Integer = 1

    Const cnt_TABListagem As Integer = 0
    Const cnt_TABDados As Integer = 1
    Const cnt_TABAcessoUsuario As Integer = 2
    Const cnt_TABGrupoAcesso As Integer = 3
    Const cnt_TABLinkarAcesso As Integer = 4

    Dim GridAprovacao_LinhaSelecionada As Integer = -1

    Private Sub frmCadastroUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlText As String
        Dim iCont As Integer
        Dim sAux As String

        sTituloTela = Me.Text

        Pesq_UsuarioCopia.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Seguranca_Usuario_ComAcesso

        ComboBox_Carregar_SEC_Usuaro_Status(cboStatus)
        ComboBox_Carregar_SEC_Usuaro_Status(cboStatus_Filtro, True)

        Form_Container_IdentificarControles(tabListagem.Controls)
        Form_Container_IdentificarControles(tabDados.Controls)
        Form_Container_IdentificarControles(tabAcessoUsuario.Controls)
        Form_Container_IdentificarControles(tabGrupoAcesso.Controls)
        Form_Container_IdentificarControles(tabLinkarAcesso.Controls)

        ListBox_Carregar_Filial2(lstFilialLiberadasUsuario, False)
        ListBox_Carregar_Filial2(lstFilialUsuarioAprova)

        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect)
        objGrid_Coluna_Add(grdGeral, "Código do Usuário", 120)
        objGrid_Coluna_Add(grdGeral, "Nome do Usuário", 200)
        objGrid_Coluna_Add(grdGeral, "Ativo", 50)
        objGrid_Coluna_Add(grdGeral, "E-Mail do Usuário", 220)
        objGrid_Coluna_Add(grdGeral, "Criação", 120, , , , , cnt_Formato_DataHoraCurta)
        objGrid_Coluna_Add(grdGeral, "Último Acesso", 120, , , , , cnt_Formato_DataHoraCurta)
        objGrid_Coluna_Add(grdGeral, "Rh ID", 70)
        objGrid_Coluna_Add(grdGeral, "Digitais", 0)

        'Configura Grid Grupo de Acesso
        SqlText = "SELECT SQ_GRUPOACESSO, 0 AS IC_ATIVO," & _
                         "NO_GRUPOACESSO, NULL AS DT_EXPIRACAO" & _
                  " FROM AGC.SEC_GRUPOACESSO" & _
                  " WHERE CD_SISTEMA = " & cnt_Sistema_ControleAcesso & _
                  " ORDER BY NO_GRUPOACESSO"
        objGrid_Carregar(grdGrupoUsuario, SqlText)

        objGrid_Inicializar(grdGrupoUsuario)
        objGrid_Coluna_Add(grdGrupoUsuario, " ", 0, cnt_GridGrupo_SQ_GRUPOACESSO)
        objGrid_Coluna_Add(grdGrupoUsuario, " ", 25, cnt_GridGrupo_CheckBox, True, ColumnStyle.CheckBox)
        objGrid_Coluna_Add(grdGrupoUsuario, "Grupo de Acesso", 300, cnt_GridGrupo_NO_GRUPOACESSO)
        objGrid_Coluna_Add(grdGrupoUsuario, "Data de Expiração", 150, cnt_GridGrupo_DT_EXPIRACAO, True, ColumnStyle.Date, , cnt_Formato_Data)

        grdGrupoUsuario.DisplayLayout.Bands(0).Columns(cnt_GridGrupo_CheckBox).Header.CheckBoxVisibility = Infragistics.Win.UltraWinGrid.HeaderCheckBoxVisibility.WhenUsingCheckEditor

        'Configura Grid Linkar Usuario
        objGrid_Inicializar(grdLinkUsuario, , oDS_Link, UltraWinGrid.CellClickAction.RowSelect)
        objGrid_Coluna_Add(grdLinkUsuario, " ", 25, , True, ColumnStyle.CheckBox)
        objGrid_Coluna_Add(grdLinkUsuario, "Código do Usuário", 150)
        objGrid_Coluna_Add(grdLinkUsuario, "Nome do Usuário", 300)
        objGrid_Coluna_Add(grdLinkUsuario, "Data de Expiração", 150, , True, ColumnStyle.Date)

        objGrid_Inicializar(grdAreaAcesso, , oDS_AreaAcesso, CellClickAction.Edit)
        objGrid_Coluna_Add(grdAreaAcesso, "CD_AREAACESSO", 0, , False)
        objGrid_Coluna_Add(grdAreaAcesso, "Nome do Acesso", 270, , False)

        bViaBotao = False
        tabListagem.BackColor = Me.BackColor
        tabDados.BackColor = Me.BackColor
        tabAcessoUsuario.BackColor = Me.BackColor
        tabGrupoAcesso.BackColor = Me.BackColor
        tabLinkarAcesso.BackColor = Me.BackColor

        SEC_CarregarAcessos(grdAreaAcesso, cnt_GridAreaAcesso_NomeAcesso, cnt_GridAreaAcesso_CD_AREAACESSO)

        SEC_ValidarBotao(cmdAcesso, cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao, True)
        SEC_ValidarBotao(cmdGravar_Grupo, cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao, True)
        SEC_ValidarBotao(cmdGrupoUsuario, cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao, True)
        SEC_ValidarBotao(cmdLinkarUsuario, cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao, True)
        SEC_ValidarBotao(cmdAlterar, cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao, True)
        SEC_ValidarBotao(cmdNovo, cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao, True)
        SEC_ValidarBotao(cmdExcluir, cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao, True)
        cmdAcesso.Visible = False

        If cmdAlterar.Enabled Then
            SEC_P_Acesso_Usuario_Desbloquear = True
        Else
            SEC_P_Acesso_Usuario_Desbloquear = SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_Usuario_Desbloquear)
        End If

        cmdUsuarioBloqueado.Visible = False

        objGrid_Inicializar(grdAprovacao, , oDS_Aprovacao, CellClickAction.RowSelect)
        objGrid_Coluna_Add(grdAprovacao, "CD_TIPO_APROVACAO", 0)
        objGrid_Coluna_Add(grdAprovacao, "Tipo da Aprovação", 150)
        objGrid_Coluna_Add(grdAprovacao, "Valor Mínimo", 100)
        objGrid_Coluna_Add(grdAprovacao, "Valor Máximo", 100)
        objGrid_Coluna_Add(grdAprovacao, "Validade", 100)
        objGrid_Coluna_Add(grdAprovacao, "IC_POSSUI_LIMITE", 0)
        objGrid_Coluna_Add(grdAprovacao, "IC_OBRIGATORIO", 0)
        objGrid_Coluna_Add(grdAprovacao, "IC_HOUVE_ALTERACAO", 0)

        ComboBox_Carregar_Tipo_Aprovacao(cboAprovacao_TipoAprovacao, True)
        cboAprovacao_TipoAprovacao_SelectedIndexChanged(Nothing, Nothing)
        chkAprovacao_Validade_CheckedChanged(Nothing, Nothing)
        chkAprovadorPagamento_CheckedChanged(Nothing, Nothing)
        Aprovacao_Limpar()

        cboAprovacao_TipoAprovacao.Enabled = False

        sAux = ""
        SqlText = "SELECT MAX(QT_NIVEL_APROVACAO_PAGAMENTO) FROM SOF.PARAMETRO"

        For iCont = 1 To DBQuery_ValorUnico(SqlText, -1)
            Str_Adicionar(sAux, Trim(iCont.ToString), ",")
        Next

        sAux = " ," & sAux

        ComboBox_Carregar(cboNivelAprovacaoPagamento, Lista_Para_Array(sAux), Lista_Para_Array(sAux))
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String

        SqlText = "SELECT SU.CD_USUARIO," & _
                         "SU.NO_USUARIO, " & _
                         "DECODE(SS.IC_ATIVO, 'S', 'SIM', 'E', 'El. SO', 'NÃO') IC_ATIVO," & _
                         "SU.DS_EMAIL," & _
                         "SS.DT_CRIACAO," & _
                         "SS.DT_ULTIMO_ACESSO," & _
                         "SU.NU_RH_ID," & _
                         "SUM(DECODE(SUD.CD_USUARIO,NULL,0,1)) QT_DIGITAL" & _
                  " FROM AGC.SEC_USUARIO SU," & _
                        "AGC.SEC_USUARIO_SISTEMA SS," & _
                        "AGC.SEC_USUARIO_DIGITAL SUD" & _
                  " WHERE SS.CD_USUARIO = SU.CD_USUARIO" & _
                    " AND SS.CD_SISTEMA = " & cnt_Sistema_ControleAcesso & _
                    " AND SUD.CD_USUARIO (+) = SU.CD_USUARIO"

        If Trim(txtFiltro_CodigoUsuario.Text) <> "" Then
            SqlText = SqlText & " AND (UPPER(SU.CD_USUARIO) LIKE " & SQL_FormatarLike(txtFiltro_CodigoUsuario.Text) & " OR UPPER(SU.CD_USUARIO_DS) LIKE " & SQL_FormatarLike(txtFiltro_CodigoUsuario.Text) & ")"
        End If
        If Trim(txtFiltro_NomeUsuario.Text) <> "" Then
            Str_Adicionar(SqlText, " UPPER(SU.NO_USUARIO) LIKE " & SQL_FormatarLike(txtFiltro_NomeUsuario.Text), " AND ")
        End If
        If Trim(txtFiltro_EMail.Text) <> "" Then
            Str_Adicionar(SqlText, " UPPER(SU.DS_EMAIL) LIKE " & SQL_FormatarLike(txtFiltro_EMail.Text), " AND ")
        End If
        If ComboBox_LinhaSelecionada(cboStatus_Filtro) Then
            Str_Adicionar(SqlText, " DECODE(SU.IC_ATIVO, 'S', SS.IC_ATIVO, SU.IC_ATIVO) = " & QuotedStr(cboStatus_Filtro.SelectedValue), " AND ")
        End If

        SqlText = SqlText & " GROUP BY SU.CD_USUARIO," & _
                                      "SU.NO_USUARIO," & _
                                      "DECODE(SS.IC_ATIVO, 'S', 'SIM', 'E', 'El. SO', 'NÃO')," & _
                                      "SU.DS_EMAIL," & _
                                      "SS.DT_CRIACAO," & _
                                      "SS.DT_ULTIMO_ACESSO," & _
                                      "SU.NU_RH_ID" & _
                            " ORDER BY SU.NO_USUARIO"

        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_CD_USUARIO, _
                                                           cnt_GridGeral_NO_USUARIO, _
                                                           cnt_GridGeral_IC_ATIVO, _
                                                           cnt_GridGeral_DS_EMAIL, _
                                                           cnt_GridGeral_DT_CRIACAO, _
                                                           cnt_GridGeral_DT_ULTIMO_ACESSO, _
                                                           cnt_GridGeral_RH_ID, _
                                                           cnt_GridGeral_QT_DIGITAL})

        Dim iCont As Integer

        For iCont = 0 To grdGeral.Rows.Count - 1
            With grdGeral.Rows(iCont)
                If NVL(.Cells(cnt_GridGeral_IC_ATIVO).Value, "") <> "SIM" Then
                    .Appearance.ForeColor = Color.Red
                    .Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                End If
            End With
        Next
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsulta()
    End Sub

    Private Sub cmdGravarUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar_Usuario.Click
        If Trim(txtCodigoUsuario.Text) = "" Then
            Msg_Mensagem("Informe o código do usuário")
            Exit Sub
        End If
        If Trim(txtNomeUsuario.Text) = "" Then
            Msg_Mensagem("Informe o nome do usuário")
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboStatus) Then
            Msg_Mensagem("Selecione o status do usuário")
            Exit Sub
        End If
        If Trim(txtCodigoUsuarioDS.Text) = "" Then
            txtCodigoUsuarioDS.Text = txtCodigoUsuario.Text
        End If

        If Not Acesso_PodeAlterar() Then Exit Sub

        Dim oData As DataTable
        Dim SqlText As String
        Dim SqlText_Manter As String
        Dim iCont As Integer
        Dim Parametro_USUARIO(6) As DBParamentro
        Dim Parametro_USUARIO_SISTEMA(3) As DBParamentro
        Dim Acao As eControleEdicaoTela = eControleEdicaoTela.SemDefinicao
        Dim NR_NIVEL_APROVACAO_PAGAMENTO As Integer

        On Error GoTo Erro

        DBUsarTransacao = True

        If ComboBox_LinhaSelecionada(cboNivelAprovacaoPagamento) Then
            NR_NIVEL_APROVACAO_PAGAMENTO = Val(cboNivelAprovacaoPagamento.SelectedValue)
        Else
            NR_NIVEL_APROVACAO_PAGAMENTO = 0
        End If

        'Gravação de dados geral ref. a usuário
        SqlText = "SELECT COUNT(*) FROM AGC.SEC_USUARIO WHERE CD_USUARIO = " & QuotedStr(UCase(Trim(txtCodigoUsuario.Text)))
        iCont = DBQuery_ValorUnico(SqlText)

        If iCont = 0 Then
            SqlText = DBMontar_Insert("AGC.SEC_USUARIO", TipoCampoFixo.Todos, _
                                                         "NO_USUARIO", ":NO_USUARIO", _
                                                         "DS_EMAIL", ":DS_EMAIL", _
                                                         "IC_ATIVO", "'S'", _
                                                         "IC_TROCA_SENHA", ":IC_TROCA_SENHA", _
                                                         "CD_TIPOVALIDACAOSENHA", ":CD_TIPOVALIDACAOSENHA", _
                                                         "NU_RH_ID", ":NU_RH_ID", _
                                                         "CD_USUARIO_DS", ":CD_USUARIO_DS", _
                                                         "CD_USUARIO", ":CD_USUARIO")
        Else
            SqlText = DBMontar_Update("AGC.SEC_USUARIO", GerarArray("NO_USUARIO", ":NO_USUARIO", _
                                                                    "DS_EMAIL", ":DS_EMAIL", _
                                                                    "IC_TROCA_SENHA", ":IC_TROCA_SENHA", _
                                                                    "CD_TIPOVALIDACAOSENHA", ":CD_TIPOVALIDACAOSENHA", _
                                                                    "NU_RH_ID", ":NU_RH_ID", _
                                                                    "CD_USUARIO_DS", ":CD_USUARIO_DS"), _
                                                         GerarArray("CD_USUARIO", ":CD_USUARIO"), True)
        End If

        Parametro_USUARIO(0) = DBParametro_Montar("NO_USUARIO", Trim(txtNomeUsuario.Text))
        Parametro_USUARIO(1) = DBParametro_Montar("DS_EMAIL", NULLIf(Trim(txtEMail.Text), ""))
        Parametro_USUARIO(2) = DBParametro_Montar("IC_TROCA_SENHA", "N")
        Parametro_USUARIO(3) = DBParametro_Montar("CD_TIPOVALIDACAOSENHA", cnt_ValidaAcessoDS)
        Parametro_USUARIO(4) = DBParametro_Montar("NU_RH_ID", Trim(UCase(txtRhId.Text)))
        Parametro_USUARIO(5) = DBParametro_Montar("CD_USUARIO_DS", Trim(UCase(txtCodigoUsuarioDS.Text)))
        Parametro_USUARIO(6) = DBParametro_Montar("CD_USUARIO", Trim(UCase(txtCodigoUsuario.Text)))

        If Not DBExecutar(SqlText, Parametro_USUARIO) Then GoTo Erro

        'Associação Sistema e Usuário
        SqlText = "SELECT COUNT(*) FROM AGC.SEC_USUARIO_SISTEMA" & _
                  " WHERE CD_USUARIO = " & QuotedStr(Trim(txtCodigoUsuario.Text)) & _
                    " AND CD_SISTEMA = " & cnt_Sistema_ControleAcesso

        If DBQuery_ValorUnico(SqlText) = 0 Then
            SqlText = DBMontar_Insert("AGC.SEC_USUARIO_SISTEMA", TipoCampoFixo.Nenhum, _
                                                                 "IC_ATIVO", ":IC_ATIVO", _
                                                                 "DT_LIMITE_UTILIZACAO", ":DT_LIMITE_UTILIZACAO", _
                                                                 "CD_USUARIO", ":CD_USUARIO", _
                                                                 "CD_SISTEMA", ":CD_SISTEMA", _
                                                                 "DT_ULTIMO_ACESSO", "SYSDATE")
        Else
            SqlText = DBMontar_Update("AGC.SEC_USUARIO_SISTEMA", GerarArray("DT_ULTIMO_ACESSO", IIf(chkBloqueadoTempoUso.Visible And Not chkBloqueadoTempoUso.Checked, "SYSDATE", "DT_ULTIMO_ACESSO"), _
                                                                            "IC_ATIVO", ":IC_ATIVO", _
                                                                            "DT_LIMITE_UTILIZACAO", ":DT_LIMITE_UTILIZACAO"), _
                                                                 GerarArray("CD_USUARIO", ":CD_USUARIO", "AND", _
                                                                            "CD_SISTEMA", ":CD_SISTEMA"), False)
        End If

        Parametro_USUARIO_SISTEMA(0) = DBParametro_Montar("IC_ATIVO", cboStatus.SelectedValue)

        If IsDate(txtDtFimUtilizacao.Text) Then
            Parametro_USUARIO_SISTEMA(1) = DBParametro_Montar("DT_LIMITE_UTILIZACAO", Date_to_Oracle(txtDtFimUtilizacao.Text))
        Else
            Parametro_USUARIO_SISTEMA(1) = DBParametro_Montar("DT_LIMITE_UTILIZACAO", Nothing)
        End If

        Parametro_USUARIO_SISTEMA(2) = DBParametro_Montar("CD_USUARIO", txtCodigoUsuario.Text)
        Parametro_USUARIO_SISTEMA(3) = DBParametro_Montar("CD_SISTEMA", cnt_Sistema_ControleAcesso)

        If Not DBExecutar(SqlText, Parametro_USUARIO_SISTEMA) Then GoTo Erro

        SEC_UsuarioAtivo_SistemasAtivo(txtCodigoUsuario.Text)

        'Gravação de Usuário Complemento
        SqlText = "SELECT COUNT(*) FROM SOF.USUARIO_COMPLEMENTO WHERE CD_USER = " & QuotedStr(txtCodigoUsuario.Text)

        If DBQuery_ValorUnico(SqlText) = 0 Then
            SqlText = DBMontar_Insert("SOF.USUARIO_COMPLEMENTO", TipoCampoFixo.Todos, "IC_APROVADOR", ":IC_APROVADOR", _
                                                                                      "VL_MINIMO", ":VL_MINIMO", _
                                                                                      "VL_MAXIMO", ":VL_MAXIMO", _
                                                                                      "IC_AUTORIZA", ":IC_AUTORIZA", _
                                                                                      "IC_APROVA_RENEGOCIACAO", ":IC_APROVA_RENEGOCIACAO", _
                                                                                      "NR_NIVEL_APROVACAO_PAGAMENTO", ":NR_NIVEL_APROVACAO_PAGAMENTO", _
                                                                                      "CD_USER", ":CD_USER")
        Else
            SqlText = DBMontar_Update("SOF.USUARIO_COMPLEMENTO", GerarArray("IC_APROVADOR", ":IC_APROVADOR", _
                                                                            "VL_MINIMO", ":VL_MINIMO", _
                                                                            "VL_MAXIMO", ":VL_MAXIMO", _
                                                                            "IC_AUTORIZA", ":IC_AUTORIZA", _
                                                                            "IC_APROVA_RENEGOCIACAO", ":IC_APROVA_RENEGOCIACAO", _
                                                                            "NR_NIVEL_APROVACAO_PAGAMENTO", ":NR_NIVEL_APROVACAO_PAGAMENTO"), _
                                                                 GerarArray("CD_USER", ":CD_USER"))
        End If

        If Not DBExecutar(SqlText, DBParametro_Montar("IC_APROVADOR", IIf(chkAprovadorPagamento.Checked, "S", "N")), _
                                   DBParametro_Montar("VL_MINIMO", txtValorMinimo.Value), _
                                   DBParametro_Montar("VL_MAXIMO", txtValorMaximo.Value), _
                                   DBParametro_Montar("IC_AUTORIZA", IIf(chkAutorizaDescontoJuros.Checked, "S", "N")), _
                                   DBParametro_Montar("IC_APROVA_RENEGOCIACAO", IIf(chkAprovadorReNegociacao.Checked, "S", "N")), _
                                   DBParametro_Montar("NR_NIVEL_APROVACAO_PAGAMENTO", NULLIf(NR_NIVEL_APROVACAO_PAGAMENTO, 0)), _
                                   DBParametro_Montar("CD_USER", txtCodigoUsuario.Text)) Then GoTo Erro

        'Gravação do SEC_Usuario
        SqlText = "SELECT COUNT(*) FROM SOF.SEC_USUARIO" & _
                  " WHERE CD_USUARIO = " & QuotedStr(UCase(Trim(txtCodigoUsuario.Text)))

        If DBQuery_ValorUnico(SqlText) = 0 Then
            SqlText = DBMontar_Insert("SOF.SEC_USUARIO", TipoCampoFixo.Todos, "IC_ATIVO", ":IC_ATIVO", _
                                                                              "CD_USUARIO", ":CD_USUARIO")
        Else
            SqlText = DBMontar_Update("SOF.SEC_USUARIO", GerarArray("IC_ATIVO", ":IC_ATIVO"), _
                                                         GerarArray("CD_USUARIO", ":CD_USUARIO"))
        End If

        If Not DBExecutar(SqlText, DBParametro_Montar("IC_ATIVO", IIf(cboStatus.SelectedValue = cnt_Usuario_Status_Ativo, "S", "N")), _
                                   DBParametro_Montar("CD_USUARIO", Trim(UCase(txtCodigoUsuario.Text)))) Then GoTo Erro

        'Grava as filiais liberada
        SqlText_Manter = ""

        For iCont = 0 To lstFilialLiberadasUsuario.CheckedItems.Count - 1
            Str_Adicionar(SqlText_Manter, lstFilialLiberadasUsuario.CheckedItems(iCont)(0), ",")

            SqlText = "SELECT COUNT(*) FROM SOF.FILIAL_LIBERADA" & _
                      " WHERE CD_USER = " & QuotedStr(Trim(txtCodigoUsuario.Text)) & _
                        " AND CD_FILIAL = " & lstFilialLiberadasUsuario.CheckedItems(iCont)(0)

            If DBQuery_ValorUnico(SqlText) = 0 Then
                SqlText = DBMontar_Insert("FILIAL_LIBERADA", TipoCampoFixo.Todos, "CD_FILIAL", ":CD_FILIAL", _
                                                                                  "CD_USER", ":CD_USER")

                If Not DBExecutar(SqlText, _
                                  DBParametro_Montar("CD_FILIAL", lstFilialLiberadasUsuario.CheckedItems(iCont)(0)), _
                                  DBParametro_Montar("CD_USER", Trim(txtCodigoUsuario.Text))) Then GoTo Erro
            End If
        Next

        If Trim(SqlText_Manter) <> "" Then
            SqlText = "DELETE FROM SOF.FILIAL_LIBERADA" & _
                      " WHERE CD_USER = " & QuotedStr(Trim(txtCodigoUsuario.Text)) & _
                        " AND CD_FILIAL NOT IN (" & SqlText_Manter & ")"
            If Not DBExecutar(SqlText) Then GoTo Erro
        End If

        'Grava as filiais aprovadora
        SqlText_Manter = ""

        For iCont = 0 To lstFilialUsuarioAprova.CheckedItems.Count - 1
            Str_Adicionar(SqlText_Manter, lstFilialUsuarioAprova.CheckedItems(iCont)(0), ",")

            SqlText = "SELECT COUNT(*) FROM SOF.APROVADOR_FILIAL" & _
                      " WHERE CD_USER = " & QuotedStr(Trim(txtCodigoUsuario.Text)) & _
                        " AND CD_FILIAL = " & lstFilialUsuarioAprova.CheckedItems(iCont)(0)

            If DBQuery_ValorUnico(SqlText) = 0 Then
                SqlText = DBMontar_Insert("APROVADOR_FILIAL", TipoCampoFixo.DadoCriacao, "CD_FILIAL", ":CD_FILIAL", _
                                                                                         "CD_USER", ":CD_USER")

                If Not DBExecutar(SqlText, _
                                  DBParametro_Montar("CD_FILIAL", lstFilialUsuarioAprova.CheckedItems(iCont)(0)), _
                                  DBParametro_Montar("CD_USER", Trim(txtCodigoUsuario.Text))) Then GoTo Erro
            End If
        Next

        If Trim(SqlText_Manter) <> "" Then
            SqlText = "DELETE FROM SOF.APROVADOR_FILIAL" & _
                      " WHERE CD_USER = " & QuotedStr(Trim(txtCodigoUsuario.Text)) & _
                        " AND CD_FILIAL NOT IN (" & SqlText_Manter & ")"
            If Not DBExecutar(SqlText) Then GoTo Erro
        End If

        'Grava os limites de aprovação
        SqlText_Manter = ""

        Dim oParametro(4) As DBParamentro

        For iCont = 0 To grdAprovacao.Rows.Count - 1
            Str_Adicionar(SqlText_Manter, objGrid_Valor(grdAprovacao, cnt_GridAprovacao_CD_TIPO_APROVACAO, iCont), ",")

            Acao = eControleEdicaoTela.SemDefinicao

            SqlText = "SELECT COUNT(*) FROM SOF.USUARIO_TIPO_APROVACAO" & _
                      " WHERE CD_USER = " & QuotedStr(Trim(txtCodigoUsuario.Text)) & _
                        " AND CD_TIPO_APROVACAO = " & objGrid_Valor(grdAprovacao, cnt_GridAprovacao_CD_TIPO_APROVACAO, iCont)

            If DBQuery_ValorUnico(SqlText) = 0 Then
                Acao = eControleEdicaoTela.INCLUIR
            Else
                If objGrid_Valor(grdAprovacao, cnt_GridAprovacao_IC_HOUVE_ALTERACAO, iCont, "N") = "S" Then
                    Acao = eControleEdicaoTela.ALTERAR
                Else
                    Acao = eControleEdicaoTela.SemDefinicao
                End If
            End If

            If Acao <> eControleEdicaoTela.SemDefinicao Then
                Select Case Acao
                    Case eControleEdicaoTela.INCLUIR
                        SqlText = DBMontar_Insert("SOF.USUARIO_TIPO_APROVACAO", TipoCampoFixo.Todos, _
                                                                                "VL_MINIMO_APROVACAO", ":VL_MINIMO_APROVACAO", _
                                                                                "VL_MAXIMO_APROVACAO", ":VL_MAXIMO_APROVACAO", _
                                                                                "DT_VALIDADE", ":DT_VALIDADE", _
                                                                                "CD_USER", ":CD_USER", _
                                                                                "CD_TIPO_APROVACAO", ":CD_TIPO_APROVACAO")
                    Case eControleEdicaoTela.ALTERAR
                        SqlText = DBMontar_Update("SOF.USUARIO_TIPO_APROVACAO", GerarArray("VL_MINIMO_APROVACAO", ":VL_MINIMO_APROVACAO", _
                                                                                           "VL_MAXIMO_APROVACAO", ":VL_MAXIMO_APROVACAO", _
                                                                                           "DT_VALIDADE", ":DT_VALIDADE"), _
                                                                               GerarArray("CD_USER", ":CD_USER", " AND ", _
                                                                                          "CD_TIPO_APROVACAO", ":CD_TIPO_APROVACAO"))
                End Select

                oParametro(0) = DBParametro_Montar("VL_MINIMO_APROVACAO", objGrid_Valor(grdAprovacao, cnt_GridAprovacao_VL_MINIMO_APROVACAO, iCont))
                oParametro(1) = DBParametro_Montar("VL_MAXIMO_APROVACAO", objGrid_Valor(grdAprovacao, cnt_GridAprovacao_VL_MAXIMO_APROVACAO, iCont))

                If IsDate(objGrid_Valor(grdAprovacao, cnt_GridAprovacao_DT_VALIDADE, iCont)) Then
                    oParametro(2) = DBParametro_Montar("DT_VALIDADE", Date_to_Oracle(objGrid_Valor(grdAprovacao, cnt_GridAprovacao_DT_VALIDADE, iCont)), OracleClient.OracleType.DateTime)
                Else
                    oParametro(2) = DBParametro_Montar("DT_VALIDADE", Nothing)
                End If
                oParametro(3) = DBParametro_Montar("CD_USER", txtCodigoUsuario.Text)
                oParametro(4) = DBParametro_Montar("CD_TIPO_APROVACAO", objGrid_Valor(grdAprovacao, cnt_GridAprovacao_CD_TIPO_APROVACAO, iCont))

                If Not DBExecutar(SqlText, oParametro) Then GoTo Erro
            End If
        Next

        If Trim(SqlText_Manter) <> "" Then
            SqlText = "DELETE FROM SOF.USUARIO_TIPO_APROVACAO" & _
                      " WHERE CD_USER = " & QuotedStr(txtCodigoUsuario.Text) & _
                        " AND CD_TIPO_APROVACAO NOT IN (" & SqlText_Manter & ")"
            If Not DBExecutar(SqlText) Then GoTo Erro
        End If

        'Gravar grupos se tiver usuário de cópia
        If Pesq_UsuarioCopia.Codigo <> "" Then
            SqlText = "DELETE FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO_GRUPOACESSO" & _
                      " WHERE CD_USUARIO = " & QuotedStr(Trim(txtCodigoUsuario.Text)) & _
                        " AND CD_SISTEMA = " & cnt_Sistema_ControleAcesso
            If Not DBExecutar(SqlText) Then GoTo Erro

            SqlText = "SELECT * FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO_GRUPOACESSO" & _
                      " WHERE CD_USUARIO = " & QuotedStr(Pesq_UsuarioCopia.Codigo) & _
                        " AND CD_SISTEMA = " & cnt_Sistema_ControleAcesso
            oData = DBQuery(SqlText)

            For iCont = 0 To oData.Rows.Count - 1
                SqlText = DBMontar_Insert(sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO_GRUPOACESSO", TipoCampoFixo.Todos, _
                                                                                                    "CD_USUARIO", ":CD_USUARIO", _
                                                                                                    "CD_SISTEMA", ":CD_SISTEMA", _
                                                                                                    "SQ_GRUPOACESSO", ":SQ_GRUPOACESSO", _
                                                                                                    "DT_EXPIRACAO", ":DT_EXPIRACAO")
                If Not DBExecutar(SqlText, DBParametro_Montar("CD_USUARIO", Trim(txtCodigoUsuario.Text)), _
                                           DBParametro_Montar("CD_SISTEMA", cnt_Sistema_ControleAcesso), _
                                           DBParametro_Montar("SQ_GRUPOACESSO", oData.Rows(iCont).Item("SQ_GRUPOACESSO")), _
                                           DBParametro_Montar("DT_EXPIRACAO", oData.Rows(iCont).Item("DT_EXPIRACAO"))) Then GoTo Erro
            Next
        End If

        If Not DBExecutarTransacao() Then GoTo Erro

        bViaBotao = True
        AtivarBotao(True)
        TabControl1.SelectTab(0)

        Msg_Mensagem("Operação salva.")

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub CarregarDadosUsuario()
        Dim oData As DataTable
        Dim SqlText As String

        'Verifica os dados do usuário
        SqlText = "SELECT AGC.CD_USUARIO," & _
                         "AGC.CD_USUARIO_DS," & _
                         "AGC.NO_USUARIO," & _
                         "AGC.DS_EMAIL," & _
                         "AGC.NU_RH_ID," & _
                         "USS.IC_ATIVO," & _
                         "USS.DT_LIMITE_UTILIZACAO," & _
                         "NVL(USS.DT_ULTIMO_ACESSO, SYSDATE) DT_ULTIMO_ACESSO" & _
                  " FROM AGC.SEC_USUARIO AGC," & _
                        "(SELECT CD_USUARIO," & _
                                "DT_ULTIMO_ACESSO," & _
                                "DT_LIMITE_UTILIZACAO," & _
                                "IC_ATIVO" & _
                         " FROM AGC.SEC_USUARIO_SISTEMA" & _
                         " WHERE CD_SISTEMA = " & cnt_Sistema_ControleAcesso & ") USS" & _
                  " WHERE AGC.CD_USUARIO = " & QuotedStr(sUsuario) & _
                    " AND USS.CD_USUARIO (+) = AGC.CD_USUARIO"
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            txtCodigoUsuario.Text = oData.Rows(0).Item("CD_USUARIO")
            txtCodigoUsuario.Enabled = False
            txtCodigoUsuarioDS.Text = NVL(oData.Rows(0).Item("CD_USUARIO_DS"), "")
            txtNomeUsuario.Text = oData.Rows(0).Item("NO_USUARIO")
            If Not objDataTable_CampoVazio(oData.Rows(0).Item("DS_EMAIL")) Then
                txtEMail.Text = oData.Rows(0).Item("DS_EMAIL")
            End If
            txtRhId.Text = NVL(oData.Rows(0).Item("NU_RH_ID"), "")
            ComboBox_Possicionar(cboStatus, NVL(oData.Rows(0).Item("IC_ATIVO"), cnt_Usuario_Status_Inativo))
            If Not objDataTable_CampoVazio(oData.Rows(0).Item("DT_LIMITE_UTILIZACAO")) Then
                txtDtFimUtilizacao.Text = oData.Rows(0).Item("DT_LIMITE_UTILIZACAO")
            End If
            If CampoNulo(oData.Rows(0).Item("DT_ULTIMO_ACESSO")) Then
                chkBloqueadoTempoUso.Visible = False
            Else
                lblUltimoAcesso.Text = oData.Rows(0).Item("DT_ULTIMO_ACESSO").ToString

                If DateDiff(DateInterval.Day, oData.Rows(0).Item("DT_ULTIMO_ACESSO"), Now.Date) > iAcesso_DiaSemUsoBloqueio Then
                    chkBloqueadoTempoUso.Visible = True
                    chkBloqueadoTempoUso.Checked = True
                Else
                    chkBloqueadoTempoUso.Visible = False
                End If
            End If

            CarregarComplementoUsuario(sUsuario)
        End If
    End Sub

    Private Sub CarregarComplementoUsuario(ByVal CdUsuario As String)
        Dim SqlText As String
        Dim oData As DataTable
        Dim iCont As Integer

        SqlText = "SELECT CD_FILIAL FROM SOF.FILIAL_LIBERADA WHERE CD_USER = " & QuotedStr(CdUsuario)
        oData = DBQuery(SqlText)

        For iCont = 0 To oData.Rows.Count - 1
            CheckListBox_Possicionar(lstFilialLiberadasUsuario, oData.Rows(iCont).Item("CD_FILIAL"))
        Next

        SqlText = "SELECT CD_FILIAL FROM SOF.APROVADOR_FILIAL WHERE CD_USER = " & QuotedStr(CdUsuario)
        oData = DBQuery(SqlText)

        For iCont = 0 To oData.Rows.Count - 1
            CheckListBox_Possicionar(lstFilialUsuarioAprova, oData.Rows(iCont).Item("CD_FILIAL"))
        Next

        SqlText = "SELECT * FROM SOF.USUARIO_COMPLEMENTO WHERE CD_USER = " & QuotedStr(CdUsuario)
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            chkAprovadorPagamento.Checked = (objDataTable_LerCampo(oData.Rows(0).Item("IC_APROVADOR"), "N") = "S")
            chkAprovadorPagamento_CheckedChanged(Nothing, Nothing)
            chkAprovadorReNegociacao.Checked = (objDataTable_LerCampo(oData.Rows(0).Item("IC_APROVA_RENEGOCIACAO"), "N") = "S")
            chkAutorizaDescontoJuros.Checked = (objDataTable_LerCampo(oData.Rows(0).Item("IC_AUTORIZA"), "N") = "S")
            txtValorMinimo.Value = objDataTable_LerCampo(oData.Rows(0).Item("VL_MINIMO"), 0)
            txtValorMaximo.Value = objDataTable_LerCampo(oData.Rows(0).Item("VL_MAXIMO"), 0)
            ComboBox_Possicionar(cboNivelAprovacaoPagamento, objDataTable_LerCampo(oData.Rows(0).Item("NR_NIVEL_APROVACAO_PAGAMENTO"), 0))
        End If

        objData_Finalizar(oData)

        SqlText = "SELECT TA.CD_TIPO_APROVACAO," & _
                         "TA.NO_TIPO_APROVACAO," & _
                         "UTA.VL_MINIMO_APROVACAO," & _
                         "UTA.VL_MAXIMO_APROVACAO," & _
                         "UTA.DT_VALIDADE," & _
                         "TA.IC_POSSUI_LIMITE," & _
                         "TA.IC_OBRIGATORIO," & _
                         "'N' IC_HOUVE_ALTERACAO" & _
                  " FROM SOF.TIPO_APROVACAO TA," & _
                        "SOF.USUARIO_TIPO_APROVACAO UTA " & _
                  " WHERE UTA.CD_TIPO_APROVACAO = TA.CD_TIPO_APROVACAO" & _
                    " AND UTA.CD_USER = " & QuotedStr(CdUsuario)
        objGrid_Carregar(grdAprovacao, SqlText, New Integer() {cnt_GridAprovacao_CD_TIPO_APROVACAO, _
                                                               cnt_GridAprovacao_NO_TIPO_APROVACAO, _
                                                               cnt_GridAprovacao_VL_MINIMO_APROVACAO, _
                                                               cnt_GridAprovacao_VL_MAXIMO_APROVACAO, _
                                                               cnt_GridAprovacao_DT_VALIDADE, _
                                                               cnt_GridAprovacao_IC_POSSUI_LIMITE, _
                                                               cnt_GridAprovacao_IC_OBRIGATORIO, _
                                                               cnt_GridAprovacao_IC_HOUVE_ALTERACAO})
    End Sub

    Private Sub cmdAlterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAlterar.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar um registro.")
            Exit Sub
        End If

        bViaBotao = True
        AtivarBotao(False)
        LimpaUsuario()
        ControleEdicaoTelaLocal = Declaracao.eControleEdicaoTela.ALTERAR
        sUsuario = objGrid_Valor(grdGeral, cnt_GridGeral_CD_USUARIO)
        CarregarDadosUsuario()
        TabControl1.SelectTab(1)
        txtCodigoUsuario.Enabled = False
    End Sub

    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        bViaBotao = True
        AtivarBotao(False)
        LimpaUsuario()
        ControleEdicaoTelaLocal = Declaracao.eControleEdicaoTela.INCLUIR
        sUsuario = Nothing
        txtCodigoUsuario.Enabled = True

        TabControl1.SelectTab(1)
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Function Acesso_PodeAlterar() As Boolean
        If txtCodigoUsuario.Text = sAcesso_UsuarioLogado Then
            Msg_Mensagem("Não é permitido que o usuário altere os acessos do seu respectivo usuário")
            Exit Function
        End If

        Return True
    End Function

    Private Sub cmdAcesso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAcesso.Click
        Carregar_Acessos()
    End Sub

    Private Function Carregar_Acessos() As Boolean
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar um registro.")
            TabControl1.SelectTab(cnt_TABListagem)
            Exit Function
        End If

        If Not Acesso_PodeAlterar() Then Exit Function

        Dim SqlText As String

        sUsuario = objGrid_Valor(grdGeral, cnt_GridGeral_CD_USUARIO)

        SqlText = "SELECT DISTINCT SU.CD_USUARIO," & _
                                  "SU.NO_USUARIO" & _
                      " FROM AGC.SEC_USUARIO_ACESSO UAC," & _
                            "AGC.SEC_USUARIO SU" & _
                      " WHERE UAC.CD_USUARIO = SU.CD_USUARIO" & _
                        " AND UAC.CD_SISTEMA = " & cnt_Sistema_ControleAcesso & _
                        " AND UAC.CD_USUARIO <> " & QuotedStr(sUsuario) & _
                      " ORDER BY SU.NO_USUARIO"
        DBCarregarComboBox(cboUsuarioCopia, SqlText, True)

        SEC_CarregarDiretosAcesso(grdAreaAcesso, 0, sUsuario, cnt_GridAreaAcesso_CD_AREAACESSO, cnt_GridAreaAcesso_NomeAcesso)
        grdAreaAcesso.UpdateData()
        lblUsuarioAcessoUsuario.Text = objGrid_Valor(grdGeral, cnt_GridGeral_NO_USUARIO)
        bViaBotao = True
        AtivarBotao(False)
        TabControl1.SelectTab(2)

        Return True
    End Function

    Private Sub cmdUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrupoUsuario.Click
        Carregar_Grupos()
    End Sub

    Private Function Carregar_Grupos() As Boolean
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar um registro.")
            TabControl1.SelectTab(cnt_TABListagem)
            Exit Function
        End If

        If Not Acesso_PodeAlterar() Then Exit Function

        sUsuario = objGrid_Valor(grdGeral, cnt_GridGeral_CD_USUARIO)
        lblUsuarioGrupoUsuario.Text = objGrid_Valor(grdGeral, cnt_GridGeral_NO_USUARIO)
        CarregarDadosGrupo()
        bViaBotao = True
        AtivarBotao(False)
        TabControl1.SelectTab(3)

        Return True
    End Function

    Private Sub cmdLinkarUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLinkarUsuario.Click
        Carregar_Usuario()
    End Sub

    Private Function Carregar_Usuario() As Boolean
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar um registro.")
            TabControl1.SelectTab(cnt_TABListagem)
            Exit Function
        End If

        If Not Acesso_PodeAlterar() Then Exit Function

        sUsuario = objGrid_Valor(grdGeral, cnt_GridGeral_CD_USUARIO)
        lblUsuarioLinkUsuario.Text = objGrid_Valor(grdGeral, cnt_GridGeral_NO_USUARIO)
        CarregarDadosLink()
        bViaBotao = True
        AtivarBotao(False)
        TabControl1.SelectTab(4)

        Return True
    End Function

    Private Sub TabControl1_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl1.Selecting
        If bViaBotao = False Then
            e.Cancel = True
        Else
            bViaBotao = False
        End If
    End Sub

    Private Sub cmdCancelar_Usuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar_Usuario.Click
        bViaBotao = True
        AtivarBotao(True)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub AtivarBotao(ByVal Ativar As Boolean)
        cmdAcesso.Enabled = Ativar
        cmdExcell.Enabled = Ativar

        If Ativar = True Then
            SEC_ValidarBotao(cmdAlterar, cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao)
            SEC_ValidarBotao(cmdNovo, cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao)
            SEC_ValidarBotao(cmdExcluir, cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao)
        Else
            cmdAlterar.Enabled = Ativar
            cmdNovo.Enabled = Ativar
            cmdExcluir.Enabled = Ativar
        End If

        cmdGrupoUsuario.Enabled = Ativar
        cmdLinkarUsuario.Enabled = Ativar
    End Sub

    Private Sub cmdCancelar_Acesso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar_Acesso.Click
        bViaBotao = True
        AtivarBotao(True)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub cmdCancelar_Grupo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar_Grupo.Click
        bViaBotao = True
        AtivarBotao(True)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub cmdCancelar_Link_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar_Link.Click
        bViaBotao = True
        AtivarBotao(True)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub CarregarDadosGrupo()
        Dim oData As DataTable
        Dim SqlText As String
        Dim iCont_1 As Integer
        Dim iCont_2 As Integer

        DesmarcarGrid(grdGrupoUsuario, cnt_GridGrupo_CheckBox)

        SqlText = "SELECT UG.*" & _
                  " FROM AGC.SEC_USUARIO_GRUPOACESSO UG," & _
                        "AGC.SEC_GRUPOACESSO GA" & _
                  " WHERE UG.CD_USUARIO = " & QuotedStr(sUsuario) & _
                    " AND GA.SQ_GRUPOACESSO = UG.SQ_GRUPOACESSO" & _
                    " AND GA.CD_SISTEMA = " & cnt_Sistema_ControleAcesso
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            For iCont_1 = 0 To oData.Rows.Count - 1
                For iCont_2 = 0 To grdGrupoUsuario.Rows.Count - 1
                    If objGrid_Valor(grdGrupoUsuario, cnt_GridGrupo_SQ_GRUPOACESSO, iCont_2) = oData.Rows(iCont_1).Item("SQ_GRUPOACESSO") Then
                        grdGrupoUsuario.Rows(iCont_2).Cells(cnt_GridGrupo_CheckBox).Value = True
                        If Not objDataTable_CampoVazio(oData.Rows(iCont_1).Item("DT_EXPIRACAO")) Then
                            grdGrupoUsuario.Rows(iCont_2).Cells(cnt_GridGrupo_DT_EXPIRACAO).Value = oData.Rows(iCont_1).Item("DT_EXPIRACAO")
                        End If
                    End If
                Next
            Next

            oData.Dispose()
        End If

        grdGrupoUsuario.UpdateData()
    End Sub

    Private Sub DesmarcarGrid(ByVal oGrid As UltraGrid, ByVal Coluna As Integer)
        Dim iCont As Integer

        For iCont = 0 To oGrid.Rows.Count - 1
            oGrid.Rows(iCont).Cells(Coluna).Value = False
        Next
    End Sub

    Private Sub cmdGrava_Grupo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar_Grupo.Click
        If Not Acesso_PodeAlterar() Then Exit Sub

        Dim oData As DataTable = Nothing
        Dim oParametro(2) As DBParamentro
        Dim Acao As eControleEdicaoTela
        Dim SqlText As String
        Dim SqlText_Manter As String = ""
        Dim iCont As Integer

        On Error GoTo Erro

        DBUsarTransacao = True

        For iCont = 0 To grdGrupoUsuario.Rows.Count - 1
            If objGrid_CheckBox_Selecionado(grdGrupoUsuario, cnt_GridGrupo_CheckBox, iCont) Then
                Acao = eControleEdicaoTela.SemDefinicao

                Str_Adicionar(SqlText_Manter, objGrid_Valor(grdGrupoUsuario, cnt_GridGrupo_SQ_GRUPOACESSO, iCont, , gridTipoValor.ValorNumero), ",")

                SqlText = "SELECT DT_EXPIRACAO FROM AGC.SEC_USUARIO_GRUPOACESSO" & _
                          " WHERE CD_USUARIO = " & QuotedStr(sUsuario) & _
                            " AND CD_SISTEMA = " & cnt_Sistema_ControleAcesso & _
                            " AND SQ_GRUPOACESSO = " & objGrid_Valor(grdGrupoUsuario, cnt_GridGrupo_SQ_GRUPOACESSO, iCont, , gridTipoValor.ValorNumero)
                oData = DBQuery(SqlText)

                If objDataTable_Vazio(oData) Then
                    Acao = eControleEdicaoTela.INCLUIR
                Else
                    If objDataTable_LerCampo(oData.Rows(0).Item("DT_EXPIRACAO"), New Date(1900, 1, 1)) <> _
                       objGrid_Valor(grdGrupoUsuario, cnt_GridGrupo_DT_EXPIRACAO, iCont, New Date(1900, 1, 1)) Then
                        Acao = eControleEdicaoTela.ALTERAR
                    Else
                        Acao = eControleEdicaoTela.SemDefinicao
                    End If
                End If

                If Acao <> eControleEdicaoTela.SemDefinicao Then
                    If Acao = eControleEdicaoTela.INCLUIR Then
                        SqlText = DBMontar_Insert("AGC.SEC_USUARIO_GRUPOACESSO", TipoCampoFixo.Todos, _
                                                                                "DT_EXPIRACAO", ":DT_EXPIRACAO", _
                                                                                "CD_SISTEMA", cnt_Sistema_ControleAcesso, _
                                                                                "CD_USUARIO", ":CD_USUARIO", _
                                                                                "SQ_GRUPOACESSO", ":SQ_GRUPOACESSO")
                    Else
                        SqlText = DBMontar_Update("CRM.SEC_USUARIO_GRUPOACESSO", GerarArray("DT_EXPIRACAO", ":DT_EXPIRACAO"), _
                                                                                 GerarArray("CD_SISTEMA", cnt_Sistema_ControleAcesso, " AND ", _
                                                                                            "CD_USUARIO", ":CD_USUARIO", " AND ", _
                                                                                            "SQ_GRUPOACESSO", ":SQ_GRUPOACESSO"))
                    End If

                    If CampoNulo(objGrid_Valor(grdGrupoUsuario, cnt_GridGrupo_DT_EXPIRACAO, iCont)) Then
                        oParametro(0) = DBParametro_Montar("DT_EXPIRACAO", Nothing)
                    Else
                        oParametro(0) = DBParametro_Montar("DT_EXPIRACAO", Date_to_Oracle(objGrid_Valor(grdGrupoUsuario, cnt_GridGrupo_DT_EXPIRACAO, iCont), True, , False, True), DbType.Date)
                    End If

                    oParametro(1) = DBParametro_Montar("CD_USUARIO", sUsuario)
                    oParametro(2) = DBParametro_Montar("SQ_GRUPOACESSO", objGrid_Valor(grdGrupoUsuario, cnt_GridGrupo_SQ_GRUPOACESSO, iCont, , gridTipoValor.ValorNumero))

                    If Not DBExecutar(SqlText, oParametro) Then GoTo Erro
                End If
            End If
        Next

        SqlText = "DELETE FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO_GRUPOACESSO" & _
                  " WHERE CD_USUARIO = " & QuotedStr(sUsuario) & _
                    " AND CD_SISTEMA = " & cnt_Sistema_ControleAcesso & _
                    " AND SQ_GRUPOACESSO NOT IN (" & SqlText_Manter & ")"
        If Not DBExecutar(SqlText) Then GoTo Erro

        If Not DBExecutarTransacao() Then GoTo Erro

        Msg_Mensagem("Grupos alterados com sucesso.")

        bViaBotao = True
        AtivarBotao(True)
        TabControl1.SelectTab(0)

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub CarregarDadosLink()
        Dim oData As DataTable
        Dim SqlText As String
        Dim iCont_1 As Integer
        Dim iCont_2 As Integer

        SqlText = "SELECT 0 AS IC_ATIVO," & _
                         "SU.CD_USUARIO," & _
                         "SU.NO_USUARIO," & _
                         "NULL DT_EXPIRACAO" & _
                  " FROM AGC.SEC_USUARIO_ACESSO UAC," & _
                        "AGC.SEC_USUARIO SU" & _
                  " WHERE UAC.CD_USUARIO = SU.CD_USUARIO" & _
                    " AND UAC.CD_SISTEMA = " & cnt_Sistema_ControleAcesso & _
                    " AND UAC.CD_USUARIO <> " & QuotedStr(sUsuario) & _
                  " UNION ALL " & _
                  "SELECT 0 AS IC_ATIVO," & _
                         "SU.CD_USUARIO," & _
                         "SU.NO_USUARIO," & _
                         "NULL DT_EXPIRACAO" & _
                  " FROM AGC.SEC_USUARIO_GRUPOACESSO UGA," & _
                        "AGC.SEC_GRUPOACESSO GA," & _
                        "AGC.SEC_USUARIO SU" & _
                  " WHERE GA.CD_SISTEMA = " & cnt_Sistema_ControleAcesso & _
                    " AND UGA.SQ_GRUPOACESSO = GA.SQ_GRUPOACESSO" & _
                    " AND UGA.CD_USUARIO <> " & QuotedStr(sUsuario) & _
                    " AND SU.CD_USUARIO = UGA.CD_USUARIO"

        SqlText = "SELECT DISTINCT IC_ATIVO," & _
                                  "CD_USUARIO," & _
                                  "NO_USUARIO," & _
                                  "DT_EXPIRACAO" & _
                  " FROM (" & SqlText & ")"
        objGrid_Carregar(grdLinkUsuario, SqlText, New Integer() {cnt_GridLink_CheckBox, _
                                                                 cnt_GridLink_CD_USUARIO, _
                                                                 cnt_Gridlink_NO_USUARIO, _
                                                                 cnt_Gridlink_DT_EXPIRACAO})

        DesmarcarGrid(grdLinkUsuario, cnt_GridLink_CheckBox)

        SqlText = "SELECT * " & _
                  " FROM AGC.SEC_USUARIO_USUARIOACESSO" & _
                  " WHERE CD_USUARIO = " & QuotedStr(sUsuario)
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            For iCont_1 = 0 To oData.Rows.Count - 1
                For iCont_2 = 0 To grdLinkUsuario.Rows.Count - 1
                    If objGrid_Valor(grdLinkUsuario, cnt_GridLink_CD_USUARIO, iCont_2) = oData.Rows(iCont_1).Item("CD_USUARIOACESSO") Then
                        grdLinkUsuario.Rows(iCont_2).Cells(cnt_GridLink_CheckBox).Value = True
                        If Not objDataTable_CampoVazio(oData.Rows(iCont_1).Item("DT_EXPIRACAO")) Then
                            grdLinkUsuario.Rows(iCont_2).Cells(cnt_Gridlink_DT_EXPIRACAO).Value = oData.Rows(iCont_1).Item("DT_EXPIRACAO")
                        End If
                    End If
                Next
            Next
        End If

        grdLinkUsuario.UpdateData()
    End Sub

    Private Sub cmdGravar_Link_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar_Link.Click
        If Not Acesso_PodeAlterar() Then Exit Sub

        Dim oParametro(2) As DBParamentro
        Dim SqlText As String
        Dim iCont As Integer

        On Error GoTo Erro

        DBUsarTransacao = True

        SqlText = "DELETE FROM AGC.SEC_USUARIO_USUARIOACESSO" & _
                  " WHERE CD_USUARIO = " & QuotedStr(sUsuario) & _
                    " AND CD_SISTEMA = " & cnt_Sistema_ControleAcesso
        If Not DBExecutar(SqlText) Then GoTo Erro

        For iCont = 0 To grdLinkUsuario.Rows.Count - 1
            If objGrid_CheckBox_Selecionado(grdLinkUsuario, cnt_GridLink_CheckBox, iCont) Then
                If CampoNulo(objGrid_Valor(grdLinkUsuario, cnt_Gridlink_DT_EXPIRACAO, iCont)) Then
                    Msg_Mensagem("É necessário informar uma data de expiração para utilização dos acessos de " & _
                                   UCase(objGrid_Valor(grdLinkUsuario, cnt_GridLink_CD_USUARIO, iCont)))
                    Exit Sub
                End If

                SqlText = DBMontar_Insert("AGC.SEC_USUARIO_USUARIOACESSO", TipoCampoFixo.Todos, _
                                                                          "CD_SISTEMA", cnt_Sistema_ControleAcesso, _
                                                                          "CD_USUARIO", ":CD_USUARIO", _
                                                                          "CD_USUARIOACESSO", ":CD_USUARIOACESSO", _
                                                                          "DT_EXPIRACAO", ":DT_EXPIRACAO")

                oParametro(0) = DBParametro_Montar("CD_USUARIO", sUsuario)
                oParametro(1) = DBParametro_Montar("CD_USUARIOACESSO", objGrid_Valor(grdLinkUsuario, cnt_GridLink_CD_USUARIO, iCont))
                oParametro(2) = DBParametro_Montar("DT_EXPIRACAO", Date_to_Oracle(objGrid_Valor(grdLinkUsuario, cnt_Gridlink_DT_EXPIRACAO, iCont), True, , False, True))

                If Not DBExecutar(SqlText, oParametro) Then GoTo Erro
            End If
        Next

        If Not DBExecutarTransacao() Then GoTo Erro

        Msg_Mensagem("Usuário linkado com sucesso.")

        bViaBotao = True
        AtivarBotao(True)
        TabControl1.SelectTab(0)

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Sub LimpaUsuario()
        Dim iCont As Integer

        txtCodigoUsuario.Text = ""
        txtCodigoUsuarioDS.Text = ""
        txtDtFimUtilizacao.Value = Nothing
        txtEMail.Text = ""
        txtNomeUsuario.Text = ""
        txtRhId.Text = ""
        Pesq_UsuarioCopia.Codigo = ""
        ComboBox_Possicionar(cboStatus, cnt_Usuario_Status_Ativo)

        For iCont = 0 To lstFilialLiberadasUsuario.Items.Count - 1
            lstFilialLiberadasUsuario.SetItemChecked(iCont, False)
        Next
        For iCont = 0 To lstFilialUsuarioAprova.Items.Count - 1
            lstFilialUsuarioAprova.SetItemChecked(iCont, False)
        Next

        chkAutorizaDescontoJuros.Checked = False
        chkAprovadorPagamento.Checked = False
        chkAprovadorReNegociacao.Checked = False
        txtValorMinimo.Value = 0
        txtValorMaximo.Value = 0
        cboAprovacao_TipoAprovacao.SelectedIndex = -1
        txtAprovacao_SacoMinimo.Value = 0
        txtAprovacao_SacoMaximo.Value = 0
        txtAprovacao_Validade.Text = ""
        oDS_Aprovacao.Rows.Clear()
        lblUltimoAcesso.Text = ""
        chkBloqueadoTempoUso.Checked = False
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar um registro.")
            Exit Sub
        End If

        Dim SqlText As String

        On Error GoTo Erro

        'Exclue os acessos do usuário ao sistema
        SqlText = "DELETE FROM AGC.SEC_USUARIO_ACESSO" & _
                  " WHERE CD_USUARIO = " & QuotedStr(objGrid_Valor(grdGeral, cnt_GridGeral_CD_USUARIO)) & _
                    " AND CD_SISTEMA = " & cnt_Sistema_ControleAcesso
        If Not DBExecutar(SqlText) Then GoTo Erro

        'Exclue os grupos de acesso do usuário ao sistema
        SqlText = "DELETE FROM AGC.SEC_USUARIO_GRUPOACESSO" & _
                  " WHERE CD_USUARIO = " & QuotedStr(objGrid_Valor(grdGeral, cnt_GridGeral_CD_USUARIO)) & _
                    " AND CD_SISTEMA = " & cnt_Sistema_ControleAcesso
        If Not DBExecutar(SqlText) Then GoTo Erro

        'Exclue os links de acesso a outro usuário do usuário ao sistema
        SqlText = "DELETE FROM AGC.SEC_USUARIO_USUARIOACESSO" & _
                  " WHERE CD_USUARIO = " & QuotedStr(objGrid_Valor(grdGeral, cnt_GridGeral_CD_USUARIO)) & _
                    " AND CD_SISTEMA = " & cnt_Sistema_ControleAcesso
        If Not DBExecutar(SqlText) Then GoTo Erro

        'Exclue o acesso do usuário ao sistema
        SqlText = "DELETE FROM AGC.SEC_USUARIO_SISTEMA" & _
                  " WHERE CD_USUARIO = " & QuotedStr(objGrid_Valor(grdGeral, cnt_GridGeral_CD_USUARIO)) & _
                    " AND CD_SISTEMA = " & cnt_Sistema_ControleAcesso
        If Not DBExecutar(SqlText) Then GoTo Erro

        SqlText = "UPDATE AGC.SEC_USUARIO" & _
                  " SET IC_ATIVO = 'N'" & _
                  " WHERE CD_USUARIO = " & QuotedStr(objGrid_Valor(grdGeral, cnt_GridGeral_CD_USUARIO))
        If Not DBExecutar(SqlText) Then GoTo Erro

        ExecutaConsulta()

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

    Private Sub cmdGrava_AcessoUsuario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGravar_AcessoUsuario.Click
        If Not Acesso_PodeAlterar() Then Exit Sub

        SEC_Gravar(grdAreaAcesso, 0, _
                   objGrid_Valor(grdGeral, cnt_GridGeral_CD_USUARIO), _
                   cnt_GridAreaAcesso_CD_AREAACESSO, _
                   cnt_GridAreaAcesso_NomeAcesso)

        Msg_Mensagem("Acessos do usuário alterados com sucesso.")

        bViaBotao = True
        AtivarBotao(True)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub cmdUsuarioBloqueado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuarioBloqueado.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar um registro.")
            Exit Sub
        End If

        Dim SqlText As String

        If Not Msg_Perguntar("Deseja realmente debloquear esse usuário?") Then Exit Sub

        SqlText = "UPDATE " & sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO" & _
                  " SET DT_ULTIMO_ACESSO = SYSDATE" & _
                  " WHERE CD_USUARIO = " & QuotedStr(objGrid_Valor(grdGeral, cnt_GridGeral_CD_USUARIO))

        If Not DBExecutar(SqlText) Then GoTo Erro

        cmdUsuarioBloqueado.Visible = False

        grdGeral.DisplayLayout.ActiveRow.Cells(cnt_GridGeral_DT_ULTIMO_ACESSO).Value = Now

        Exit Sub

Erro:
        TratarErro(, , "frmCadastroUsuario.cmdUsuarioBloqueado_Click")
    End Sub

    Private Sub cboUsuarioCopia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUsuarioCopia.SelectedIndexChanged
        If cboUsuarioCopia.SelectedIndex > -1 Then
            SEC_CarregarDiretosAcesso(grdAreaAcesso, 0, _
                                      cboUsuarioCopia.SelectedItem(0), _
                                      cnt_GridAreaAcesso_CD_AREAACESSO, _
                                      cnt_GridAreaAcesso_NomeAcesso, _
                                      False)
        End If
    End Sub

    Private Sub tabGrupoAcesso_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabGrupoAcesso.Enter
        If Not Carregar_Grupos() Then TabControl1.SelectTab(tabListagem)
    End Sub

    Private Sub tabLinkarAcesso_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabLinkarAcesso.Enter
        If Not Carregar_Usuario() Then TabControl1.SelectTab(tabListagem)
    End Sub

    Private Sub tabAcessoUsuario_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabAcessoUsuario.Enter
        If Not Carregar_Acessos() Then TabControl1.SelectTab(tabListagem)
    End Sub

    Private Sub Aprovacao_Limpar()
        cboAprovacao_TipoAprovacao.Enabled = True
        cboAprovacao_TipoAprovacao.SelectedIndex = -1
        txtAprovacao_SacoMinimo.Value = 0
        txtAprovacao_SacoMaximo.Value = 0
        txtAprovacao_Validade.Text = ""
        txtAprovacao_Validade.Enabled = False
        chkAprovacao_Validade.Checked = False
        GridAprovacao_LinhaSelecionada = -1
    End Sub

    Private Sub chkAprovacao_Validade_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAprovacao_Validade.CheckedChanged
        txtAprovacao_Validade.Enabled = chkAprovacao_Validade.Checked
        txtAprovacao_Validade.Value = Nothing
    End Sub

    Private Sub cmdAprovacao_Novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAprovacao_Novo.Click
        Aprovacao_Limpar()
    End Sub

    Private Sub grdAprovacao_AfterRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles grdAprovacao.AfterRowUpdate
        e.Row.Cells(cnt_GridAprovacao_IC_HOUVE_ALTERACAO).Value = "S"
    End Sub

    Private Sub grdAprovacao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdAprovacao.Click
        If Not grdAprovacao.DisplayLayout.ActiveRow Is Nothing Then
            cboAprovacao_TipoAprovacao.Enabled = True
            ComboBox_Possicionar(cboAprovacao_TipoAprovacao, objGrid_Valor(grdAprovacao, cnt_GridAprovacao_CD_TIPO_APROVACAO))
            cboAprovacao_TipoAprovacao_SelectedIndexChanged(Nothing, Nothing)
            txtAprovacao_SacoMinimo.Value = objGrid_Valor(grdAprovacao, cnt_GridAprovacao_VL_MINIMO_APROVACAO)
            txtAprovacao_SacoMaximo.Value = objGrid_Valor(grdAprovacao, cnt_GridAprovacao_VL_MAXIMO_APROVACAO)
            If Not CampoNulo(objGrid_Valor(grdAprovacao, cnt_GridAprovacao_DT_VALIDADE)) Then
                txtAprovacao_Validade.Value = objGrid_Valor(grdAprovacao, cnt_GridAprovacao_DT_VALIDADE)
                chkAprovacao_Validade.Checked = True
            Else
                txtAprovacao_Validade.Value = Nothing
                chkAprovacao_Validade.Checked = False
            End If
            chkAprovacao_Validade_CheckedChanged(Nothing, Nothing)
            GridAprovacao_LinhaSelecionada = grdAprovacao.DisplayLayout.ActiveRow.Index
        End If
    End Sub

    Private Sub cmdAprovacao_Adicionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAprovacao_Adicionar.Click
        If GridAprovacao_LinhaSelecionada = -1 Then
            grdAprovacao.Rows(oDS_Aprovacao.Rows.Add.Index).Activate()
        End If
        If Not ComboBox_LinhaSelecionada(cboAprovacao_TipoAprovacao) Then
            Msg_Mensagem("Selecione o tipo da aprovação")
            Exit Sub
        End If

        Dim oData As DataTable

        With grdAprovacao.DisplayLayout.ActiveRow
            oData = DBQuery("SELECT * FROM SOF.TIPO_APROVACAO" & _
                                    " WHERE CD_TIPO_APROVACAO = " & cboAprovacao_TipoAprovacao.SelectedValue)

            If objDataTable_LerCampo(oData.Rows(0).Item("IC_POSSUI_LIMITE"), "N") = "S" Then
                If txtAprovacao_SacoMinimo.Value < 0 Then
                    Msg_Mensagem("Favor informar um valor mínimo positivo.")
                    txtAprovacao_SacoMinimo.Focus()
                    GoTo Sair
                End If
                If txtAprovacao_SacoMaximo.Value < 0 Then
                    Msg_Mensagem("Favor informar um valor máximo positivo.")
                    txtAprovacao_SacoMaximo.Focus()
                    GoTo Sair
                End If
                If txtAprovacao_SacoMaximo.Value < txtAprovacao_SacoMinimo.Value Then
                    Msg_Mensagem("Favor informar um valor máximo igual pu maior do que o mínimo.")
                    txtAprovacao_SacoMaximo.Focus()
                    GoTo Sair
                End If
            End If

            .Cells(cnt_GridAprovacao_CD_TIPO_APROVACAO).Value = cboAprovacao_TipoAprovacao.SelectedValue
            .Cells(cnt_GridAprovacao_NO_TIPO_APROVACAO).Value = cboAprovacao_TipoAprovacao.Text
            .Cells(cnt_GridAprovacao_VL_MINIMO_APROVACAO).Value = txtAprovacao_SacoMinimo.Value
            .Cells(cnt_GridAprovacao_VL_MAXIMO_APROVACAO).Value = txtAprovacao_SacoMaximo.Value
            If chkAprovacao_Validade.Checked = True Then
                .Cells(cnt_GridAprovacao_DT_VALIDADE).Value = txtAprovacao_Validade.Value
            End If
            If objDataTable_Vazio(oData) Then
                .Cells(cnt_GridAprovacao_IC_POSSUI_LIMITE).Value = oData.Rows(0).Item("IC_POSSUI_LIMITE")
                .Cells(cnt_GridAprovacao_IC_OBRIGATORIO).Value = oData.Rows(0).Item("IC_OBRIGATORIO")
            End If
            .Cells(cnt_GridAprovacao_IC_HOUVE_ALTERACAO).Value = "S"
        End With

Sair:
        objData_Finalizar(oData)
    End Sub

    Private Sub txtCodigoUsuario_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoUsuario.LostFocus
        Dim oData As DataTable
        Dim SqlText As String

        txtCodigoUsuario.Text = UCase(Trim(txtCodigoUsuario.Text))

        SqlText = "SELECT SU.*" & _
                  " FROM AGC.SEC_USUARIO SU" & _
                  " WHERE SU.CD_USUARIO = " & QuotedStr(txtCodigoUsuario.Text) & _
                     " OR NVL(SU.CD_USUARIO_DS, SU.CD_USUARIO) = " & QuotedStr(txtCodigoUsuario.Text)
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            txtCodigoUsuario.Text = oData.Rows(0).Item("CD_USUARIO")
            txtCodigoUsuarioDS.Text = oData.Rows(0).Item("CD_USUARIO_DS")
            txtNomeUsuario.Text = oData.Rows(0).Item("NO_USUARIO")
            txtEMail.Text = objDataTable_LerCampo(oData.Rows(0).Item("DS_EMAIL"), "")
            txtRhId.Text = NVL(oData.Rows(0).Item("NU_RH_ID"), "")
            ComboBox_Possicionar(cboStatus, oData.Rows(0).Item("IC_ATIVO"))

            ControleEdicaoTelaLocal = eControleEdicaoTela.ALTERAR
        Else
            If Trim(txtCodigoUsuarioDS.Text) = "" Then
                txtCodigoUsuarioDS.Text = txtCodigoUsuario.Text
            End If
        End If

        objData_Finalizar(oData)
    End Sub

    Private Sub grdAprovacao_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdAprovacao.BeforeRowsDeleted
        e.DisplayPromptMsg = False

        If Msg_Perguntar("Deseja realmente excluir essa aprovação?") Then
            e.Cancel = False
            GridAprovacao_LinhaSelecionada = -1
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub chkAprovadorPagamento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAprovadorPagamento.CheckedChanged
        If chkAprovadorPagamento.Checked = True Then
            txtValorMinimo.Enabled = True
            txtValorMaximo.Enabled = True
            lstFilialUsuarioAprova.Enabled = True
            cboNivelAprovacaoPagamento.Enabled = True
        Else
            txtValorMinimo.Value = 0
            txtValorMinimo.Enabled = False
            txtValorMaximo.Value = 0
            txtValorMaximo.Enabled = False

            Dim iCont As Integer

            For iCont = 0 To lstFilialUsuarioAprova.Items.Count - 1
                lstFilialUsuarioAprova.SetItemChecked(iCont, False)
            Next

            lstFilialUsuarioAprova.Enabled = False
            cboNivelAprovacaoPagamento.Enabled = False
        End If
    End Sub

    Private Sub cboAprovacao_TipoAprovacao_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAprovacao_TipoAprovacao.SelectedIndexChanged
        Dim SqlText As String

        txtAprovacao_SacoMinimo.Enabled = False
        txtAprovacao_SacoMaximo.Enabled = False

        If Not ComboBox_LinhaSelecionada(cboAprovacao_TipoAprovacao) Then
            txtAprovacao_SacoMaximo.Value = 0
            txtAprovacao_SacoMinimo.Value = 0
            Exit Sub
        Else
            SqlText = "select t.ic_possui_limite  from sof.tipo_aprovacao t where t.cd_tipo_aprovacao =" & cboAprovacao_TipoAprovacao.SelectedValue
            If DBQuery_ValorUnico(SqlText) = "S" Then
                txtAprovacao_SacoMaximo.Enabled = True
                txtAprovacao_SacoMinimo.Enabled = True
            Else
                txtAprovacao_SacoMaximo.Enabled = False
                txtAprovacao_SacoMinimo.Enabled = False
                txtAprovacao_SacoMaximo.Value = 0
                txtAprovacao_SacoMinimo.Value = 0
            End If
        End If
    End Sub

    Private Sub grdGeral_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdGeral.AfterRowActivate
        If NVL(grdGeral.ActiveRow.Cells(cnt_GridGeral_CD_USUARIO).Value, "") = "" Then
            Me.Text = sTituloTela
            sUsuario = ""
        Else
            Me.Text = sTituloTela & " (" & Trim(NVL(grdGeral.ActiveRow.Cells(cnt_GridGeral_CD_USUARIO).Value, "")) & " - " & _
                                               Trim(NVL(grdGeral.ActiveRow.Cells(cnt_GridGeral_NO_USUARIO).Value, "")) & ")"
            sUsuario = Trim(NVL(grdGeral.ActiveRow.Cells(cnt_GridGeral_CD_USUARIO).Value, ""))

            Try
                If CampoNulo(objGrid_Valor(grdGeral, cnt_GridGeral_DT_ULTIMO_ACESSO)) Then
                    cmdUsuarioBloqueado.Visible = False
                Else
                    cmdUsuarioBloqueado.Visible = (DateDiff(DateInterval.Day, objGrid_Valor(grdGeral, cnt_GridGeral_DT_ULTIMO_ACESSO), Now) > iAcesso_DiaSemUsoBloqueio) And _
                                                  SEC_P_Acesso_Usuario_Desbloquear
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub cboStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStatus.SelectedIndexChanged
        If NVL(cboStatus.SelectedValue, "X") = cnt_Usuario_Status_Ativo Then
            lstFilialLiberadasUsuario.Enabled = True
            chkAprovadorPagamento.Enabled = True
        Else
            Dim iCont As Integer

            For iCont = 0 To lstFilialLiberadasUsuario.Items.Count - 1
                lstFilialLiberadasUsuario.SetItemChecked(iCont, False)
            Next

            lstFilialLiberadasUsuario.Enabled = False
            chkAprovadorPagamento.Checked = False
            chkAprovadorPagamento_CheckedChanged(Nothing, Nothing)
            chkAprovadorPagamento.Enabled = False
        End If
    End Sub
End Class