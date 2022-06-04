<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGeraFretePagamento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGeraFretePagamento))
        Me.Label3 = New System.Windows.Forms.Label
        Me.Pesq_Fretista = New Logus.Pesq_CodigoNome
        Me.optStatus = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboFilialPagadora = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Pesq_OperacaoBancaria = New Logus.Pesq_CodigoNome
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtFavorecido = New System.Windows.Forms.TextBox
        Me.chkISS = New System.Windows.Forms.CheckBox
        Me.Pesq_CodigoNome1 = New Logus.Pesq_CodigoNome
        Me.cboTipoFrete = New System.Windows.Forms.ComboBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.grdGeral = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.cmdPesquisar = New Infragistics.Win.Misc.UltraButton
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.txtValor = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label7 = New System.Windows.Forms.Label
        CType(Me.optStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 274
        Me.Label3.Text = "Fretista"
        '
        'Pesq_Fretista
        '
        Me.Pesq_Fretista.BancoDados_Campo_Codigo = "CD_FORNECEDOR"
        Me.Pesq_Fretista.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Fretista.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_Fretista.BancoDados_Campo_Descricao = "NO_RAZAO_SOCIAL"
        Me.Pesq_Fretista.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_Fretista.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Fretista.BancoDados_Tabela = "FORNECEDOR F"
        Me.Pesq_Fretista.Codigo = 0
        Me.Pesq_Fretista.ExibirCodigo = True
        Me.Pesq_Fretista.Location = New System.Drawing.Point(6, 27)
        Me.Pesq_Fretista.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_Fretista.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_Fretista.Name = "Pesq_Fretista"
        Me.Pesq_Fretista.Size = New System.Drawing.Size(300, 28)
        Me.Pesq_Fretista.TabIndex = 273
        Me.Pesq_Fretista.TelaFiltro = False
        Me.Pesq_Fretista.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'optStatus
        '
        Me.optStatus.Location = New System.Drawing.Point(0, 0)
        Me.optStatus.Name = "optStatus"
        Me.optStatus.Size = New System.Drawing.Size(96, 32)
        Me.optStatus.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(306, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 276
        Me.Label2.Text = "Filial Pagadora"
        '
        'cboFilialPagadora
        '
        Me.cboFilialPagadora.Location = New System.Drawing.Point(309, 77)
        Me.cboFilialPagadora.Name = "cboFilialPagadora"
        Me.cboFilialPagadora.Size = New System.Drawing.Size(203, 21)
        Me.cboFilialPagadora.TabIndex = 275
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(309, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 278
        Me.Label1.Text = "Operação Bancaria"
        '
        'Pesq_OperacaoBancaria
        '
        Me.Pesq_OperacaoBancaria.BancoDados_Campo_Codigo = "CD_FORNECEDOR"
        Me.Pesq_OperacaoBancaria.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_OperacaoBancaria.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_OperacaoBancaria.BancoDados_Campo_Descricao = "NO_RAZAO_SOCIAL"
        Me.Pesq_OperacaoBancaria.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_OperacaoBancaria.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_OperacaoBancaria.BancoDados_Tabela = "FORNECEDOR F"
        Me.Pesq_OperacaoBancaria.Codigo = 0
        Me.Pesq_OperacaoBancaria.ExibirCodigo = True
        Me.Pesq_OperacaoBancaria.Location = New System.Drawing.Point(312, 27)
        Me.Pesq_OperacaoBancaria.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_OperacaoBancaria.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_OperacaoBancaria.Name = "Pesq_OperacaoBancaria"
        Me.Pesq_OperacaoBancaria.Size = New System.Drawing.Size(300, 28)
        Me.Pesq_OperacaoBancaria.TabIndex = 277
        Me.Pesq_OperacaoBancaria.TelaFiltro = False
        Me.Pesq_OperacaoBancaria.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(3, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 279
        Me.Label4.Text = "Favorecido"
        '
        'txtFavorecido
        '
        Me.txtFavorecido.Location = New System.Drawing.Point(3, 78)
        Me.txtFavorecido.Name = "txtFavorecido"
        Me.txtFavorecido.Size = New System.Drawing.Size(300, 20)
        Me.txtFavorecido.TabIndex = 280
        '
        'chkISS
        '
        Me.chkISS.AutoSize = True
        Me.chkISS.Location = New System.Drawing.Point(518, 79)
        Me.chkISS.Name = "chkISS"
        Me.chkISS.Size = New System.Drawing.Size(81, 17)
        Me.chkISS.TabIndex = 281
        Me.chkISS.Text = "Calcula ISS"
        Me.chkISS.UseVisualStyleBackColor = True
        '
        'Pesq_CodigoNome1
        '
        Me.Pesq_CodigoNome1.BancoDados_Campo_Codigo = "CD_FORNECEDOR"
        Me.Pesq_CodigoNome1.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_CodigoNome1.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_CodigoNome1.BancoDados_Campo_Descricao = "NO_RAZAO_SOCIAL"
        Me.Pesq_CodigoNome1.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_CodigoNome1.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_CodigoNome1.BancoDados_Tabela = "FORNECEDOR F"
        Me.Pesq_CodigoNome1.Codigo = 0
        Me.Pesq_CodigoNome1.ExibirCodigo = True
        Me.Pesq_CodigoNome1.Location = New System.Drawing.Point(309, 25)
        Me.Pesq_CodigoNome1.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_CodigoNome1.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_CodigoNome1.Name = "Pesq_CodigoNome1"
        Me.Pesq_CodigoNome1.Size = New System.Drawing.Size(300, 28)
        Me.Pesq_CodigoNome1.TabIndex = 277
        Me.Pesq_CodigoNome1.TelaFiltro = False
        Me.Pesq_CodigoNome1.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'cboTipoFrete
        '
        Me.cboTipoFrete.Location = New System.Drawing.Point(309, 77)
        Me.cboTipoFrete.Name = "cboTipoFrete"
        Me.cboTipoFrete.Size = New System.Drawing.Size(213, 21)
        Me.cboTipoFrete.TabIndex = 275
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(528, 77)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox1.TabIndex = 281
        Me.CheckBox1.Text = "Calcula ISS"
        Me.CheckBox1.UseVisualStyleBackColor = True
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
        Me.grdGeral.Location = New System.Drawing.Point(3, 104)
        Me.grdGeral.Name = "grdGeral"
        Me.grdGeral.Size = New System.Drawing.Size(713, 285)
        Me.grdGeral.TabIndex = 283
        Me.grdGeral.Text = "UltraGrid1"
        '
        'cmdPesquisar
        '
        Me.cmdPesquisar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdPesquisar.Location = New System.Drawing.Point(671, 8)
        Me.cmdPesquisar.Name = "cmdPesquisar"
        Me.cmdPesquisar.Size = New System.Drawing.Size(45, 45)
        Me.cmdPesquisar.TabIndex = 282
        Me.cmdPesquisar.Text = "P"
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(3, 395)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 285
        Me.cmdGravar.TabStop = False
        Me.cmdGravar.Text = "G"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(671, 395)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 284
        Me.cmdFechar.Text = "F"
        '
        'txtValor
        '
        Me.txtValor.Location = New System.Drawing.Point(605, 76)
        Me.txtValor.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtValor.Name = "txtValor"
        Me.txtValor.ReadOnly = True
        Me.txtValor.Size = New System.Drawing.Size(107, 21)
        Me.txtValor.TabIndex = 287
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(605, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 16)
        Me.Label7.TabIndex = 286
        Me.Label7.Text = "Valor"
        '
        'frmGeraFretePagamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 446)
        Me.Controls.Add(Me.txtValor)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.grdGeral)
        Me.Controls.Add(Me.cmdPesquisar)
        Me.Controls.Add(Me.chkISS)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtFavorecido)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Pesq_OperacaoBancaria)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboFilialPagadora)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Pesq_Fretista)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmGeraFretePagamento"
        Me.Text = "Gera Frete Pagamento"
        CType(Me.optStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Pesq_Fretista As Logus.Pesq_CodigoNome
    Friend WithEvents optStatus As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboFilialPagadora As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Pesq_OperacaoBancaria As Logus.Pesq_CodigoNome
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFavorecido As System.Windows.Forms.TextBox
    Friend WithEvents chkISS As System.Windows.Forms.CheckBox
    Friend WithEvents Pesq_CodigoNome1 As Logus.Pesq_CodigoNome
    Friend WithEvents cboTipoFrete As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents grdGeral As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cmdPesquisar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtValor As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
