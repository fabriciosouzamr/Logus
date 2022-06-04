<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroGarantia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadastroGarantia))
        Me.txtDataValidade = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.rctDescricao = New System.Windows.Forms.RichTextBox
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cboTipoGarantia = New System.Windows.Forms.ComboBox
        Me.cboMoeda = New System.Windows.Forms.ComboBox
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraGroupBox4 = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraGroupBox5 = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraGroupBox6 = New Infragistics.Win.Misc.UltraGroupBox
        Me.grdGeral = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Pesq_Repassador = New Logus.Pesq_CodigoNome
        Me.lblStatus = New System.Windows.Forms.Label
        Me.txtValorGarantia = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.txtValorCreditoMaximo = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        CType(Me.txtDataValidade, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox4.SuspendLayout()
        CType(Me.UltraGroupBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox5.SuspendLayout()
        CType(Me.UltraGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox6.SuspendLayout()
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorGarantia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorCreditoMaximo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtDataValidade
        '
        Me.txtDataValidade.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataValidade.Location = New System.Drawing.Point(6, 18)
        Me.txtDataValidade.Name = "txtDataValidade"
        Me.txtDataValidade.Size = New System.Drawing.Size(90, 23)
        Me.txtDataValidade.TabIndex = 219
        Me.txtDataValidade.Value = Nothing
        '
        'rctDescricao
        '
        Me.rctDescricao.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rctDescricao.Location = New System.Drawing.Point(6, 19)
        Me.rctDescricao.Name = "rctDescricao"
        Me.rctDescricao.Size = New System.Drawing.Size(330, 320)
        Me.rctDescricao.TabIndex = 218
        Me.rctDescricao.Text = ""
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(3, 384)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 223
        Me.cmdGravar.TabStop = False
        Me.cmdGravar.Text = "G"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(632, 384)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 217
        Me.cmdFechar.Text = "F"
        '
        'cboTipoGarantia
        '
        Me.cboTipoGarantia.Location = New System.Drawing.Point(6, 25)
        Me.cboTipoGarantia.Name = "cboTipoGarantia"
        Me.cboTipoGarantia.Size = New System.Drawing.Size(198, 21)
        Me.cboTipoGarantia.TabIndex = 224
        '
        'cboMoeda
        '
        Me.cboMoeda.Location = New System.Drawing.Point(6, 23)
        Me.cboMoeda.Name = "cboMoeda"
        Me.cboMoeda.Size = New System.Drawing.Size(58, 21)
        Me.cboMoeda.TabIndex = 221
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.cboMoeda)
        Me.UltraGroupBox1.Controls.Add(Me.txtValorGarantia)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(3, 2)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(184, 52)
        Me.UltraGroupBox1.TabIndex = 228
        Me.UltraGroupBox1.Text = "Valor Garantia"
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.cboTipoGarantia)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(3, 59)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(210, 54)
        Me.UltraGroupBox2.TabIndex = 261
        Me.UltraGroupBox2.Text = "Tipo Garantia"
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Controls.Add(Me.txtDataValidade)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(219, 64)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(104, 49)
        Me.UltraGroupBox3.TabIndex = 262
        Me.UltraGroupBox3.Text = "Validade"
        '
        'UltraGroupBox4
        '
        Me.UltraGroupBox4.Controls.Add(Me.txtValorCreditoMaximo)
        Me.UltraGroupBox4.Location = New System.Drawing.Point(193, 5)
        Me.UltraGroupBox4.Name = "UltraGroupBox4"
        Me.UltraGroupBox4.Size = New System.Drawing.Size(130, 49)
        Me.UltraGroupBox4.TabIndex = 263
        Me.UltraGroupBox4.Text = "Crédito Maxímo"
        '
        'UltraGroupBox5
        '
        Me.UltraGroupBox5.Controls.Add(Me.rctDescricao)
        Me.UltraGroupBox5.Location = New System.Drawing.Point(335, 5)
        Me.UltraGroupBox5.Name = "UltraGroupBox5"
        Me.UltraGroupBox5.Size = New System.Drawing.Size(342, 350)
        Me.UltraGroupBox5.TabIndex = 264
        Me.UltraGroupBox5.Text = "Descrição"
        '
        'UltraGroupBox6
        '
        Me.UltraGroupBox6.Controls.Add(Me.grdGeral)
        Me.UltraGroupBox6.Controls.Add(Me.Pesq_Repassador)
        Me.UltraGroupBox6.Location = New System.Drawing.Point(3, 119)
        Me.UltraGroupBox6.Name = "UltraGroupBox6"
        Me.UltraGroupBox6.Size = New System.Drawing.Size(326, 236)
        Me.UltraGroupBox6.TabIndex = 265
        Me.UltraGroupBox6.Text = "Fornecedor"
        '
        'grdGeral
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdGeral.DisplayLayout.Appearance = Appearance1
        Me.grdGeral.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdGeral.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdGeral.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.grdGeral.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdGeral.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.grdGeral.DisplayLayout.MaxColScrollRegions = 1
        Me.grdGeral.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdGeral.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdGeral.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.grdGeral.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdGeral.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdGeral.DisplayLayout.Override.CellAppearance = Appearance8
        Me.grdGeral.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdGeral.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.grdGeral.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.grdGeral.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.grdGeral.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdGeral.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.grdGeral.DisplayLayout.Override.RowAppearance = Appearance11
        Me.grdGeral.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdGeral.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.grdGeral.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdGeral.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdGeral.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdGeral.Location = New System.Drawing.Point(8, 53)
        Me.grdGeral.Name = "grdGeral"
        Me.grdGeral.Size = New System.Drawing.Size(312, 177)
        Me.grdGeral.TabIndex = 266
        Me.grdGeral.Text = "UltraGrid1"
        '
        'Pesq_Repassador
        '
        Me.Pesq_Repassador.BancoDados_Campo_Codigo = "CD_FORNECEDOR"
        Me.Pesq_Repassador.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Repassador.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_Repassador.BancoDados_Campo_Descricao = "NO_RAZAO_SOCIAL"
        Me.Pesq_Repassador.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_Repassador.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Repassador.BancoDados_Tabela = "FORNECEDOR F"
        Me.Pesq_Repassador.Codigo = 0
        Me.Pesq_Repassador.ExibirCodigo = True
        Me.Pesq_Repassador.Location = New System.Drawing.Point(6, 19)
        Me.Pesq_Repassador.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_Repassador.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_Repassador.Name = "Pesq_Repassador"
        Me.Pesq_Repassador.Size = New System.Drawing.Size(312, 28)
        Me.Pesq_Repassador.TabIndex = 227
        Me.Pesq_Repassador.TelaFiltro = False
        Me.Pesq_Repassador.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(3, 363)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(47, 13)
        Me.lblStatus.TabIndex = 266
        Me.lblStatus.Text = "lblStatus"
        '
        'txtValorGarantia
        '
        Me.txtValorGarantia.Location = New System.Drawing.Point(70, 22)
        Me.txtValorGarantia.Name = "txtValorGarantia"
        Me.txtValorGarantia.Size = New System.Drawing.Size(108, 21)
        Me.txtValorGarantia.TabIndex = 386
        '
        'txtValorCreditoMaximo
        '
        Me.txtValorCreditoMaximo.Location = New System.Drawing.Point(6, 19)
        Me.txtValorCreditoMaximo.Name = "txtValorCreditoMaximo"
        Me.txtValorCreditoMaximo.Size = New System.Drawing.Size(116, 21)
        Me.txtValorCreditoMaximo.TabIndex = 387
        '
        'frmCadastroGarantia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(683, 433)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.UltraGroupBox6)
        Me.Controls.Add(Me.UltraGroupBox5)
        Me.Controls.Add(Me.UltraGroupBox4)
        Me.Controls.Add(Me.UltraGroupBox3)
        Me.Controls.Add(Me.UltraGroupBox2)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.cmdFechar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCadastroGarantia"
        Me.Text = "Cadastro Garantia"
        CType(Me.txtDataValidade, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox4.ResumeLayout(False)
        Me.UltraGroupBox4.PerformLayout()
        CType(Me.UltraGroupBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox5.ResumeLayout(False)
        CType(Me.UltraGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox6.ResumeLayout(False)
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorGarantia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorCreditoMaximo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDataValidade As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents rctDescricao As System.Windows.Forms.RichTextBox
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Pesq_Repassador As Logus.Pesq_CodigoNome
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cboTipoGarantia As System.Windows.Forms.ComboBox
    Friend WithEvents cboMoeda As System.Windows.Forms.ComboBox
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox4 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox5 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox6 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents grdGeral As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents txtValorGarantia As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents txtValorCreditoMaximo As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
End Class
