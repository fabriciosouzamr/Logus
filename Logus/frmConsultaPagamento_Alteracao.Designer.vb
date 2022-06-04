<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaPagamento_Alteracao
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaPagamento_Alteracao))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.chkInterfaceEnviadaJDE = New System.Windows.Forms.CheckBox
        Me.chkICMS_Pago = New System.Windows.Forms.CheckBox
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.cboTipoPagamento = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Pesq_CodigoNome = New Logus.Pesq_CodigoNome
        CType(Me.cboTipoPagamento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Fornecedor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Tipo de Pagamento"
        '
        'chkInterfaceEnviadaJDE
        '
        Me.chkInterfaceEnviadaJDE.AutoSize = True
        Me.chkInterfaceEnviadaJDE.Location = New System.Drawing.Point(5, 90)
        Me.chkInterfaceEnviadaJDE.Name = "chkInterfaceEnviadaJDE"
        Me.chkInterfaceEnviadaJDE.Size = New System.Drawing.Size(226, 17)
        Me.chkInterfaceEnviadaJDE.TabIndex = 4
        Me.chkInterfaceEnviadaJDE.Text = "Interface Enviada para o JDE - One Wolrd"
        Me.chkInterfaceEnviadaJDE.UseVisualStyleBackColor = True
        '
        'chkICMS_Pago
        '
        Me.chkICMS_Pago.AutoSize = True
        Me.chkICMS_Pago.Location = New System.Drawing.Point(239, 90)
        Me.chkICMS_Pago.Name = "chkICMS_Pago"
        Me.chkICMS_Pago.Size = New System.Drawing.Size(91, 17)
        Me.chkICMS_Pago.TabIndex = 5
        Me.chkICMS_Pago.Text = "I.C.M.S. pago"
        Me.chkICMS_Pago.UseVisualStyleBackColor = True
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(360, 115)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 11
        Me.cmdFechar.Text = "F"
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(309, 115)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 12
        Me.cmdGravar.Text = "G"
        '
        'cboTipoPagamento
        '
        Me.cboTipoPagamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.cboTipoPagamento.DisplayLayout.Appearance = Appearance1
        Me.cboTipoPagamento.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.cboTipoPagamento.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.cboTipoPagamento.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cboTipoPagamento.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.cboTipoPagamento.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cboTipoPagamento.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.cboTipoPagamento.DisplayLayout.MaxColScrollRegions = 1
        Me.cboTipoPagamento.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cboTipoPagamento.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.cboTipoPagamento.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.cboTipoPagamento.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.cboTipoPagamento.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.cboTipoPagamento.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.cboTipoPagamento.DisplayLayout.Override.CellAppearance = Appearance8
        Me.cboTipoPagamento.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.cboTipoPagamento.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.cboTipoPagamento.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.cboTipoPagamento.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.cboTipoPagamento.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.cboTipoPagamento.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.cboTipoPagamento.DisplayLayout.Override.RowAppearance = Appearance11
        Me.cboTipoPagamento.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cboTipoPagamento.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.cboTipoPagamento.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.cboTipoPagamento.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.cboTipoPagamento.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.cboTipoPagamento.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.[Default]
        Me.cboTipoPagamento.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cboTipoPagamento.Location = New System.Drawing.Point(5, 61)
        Me.cboTipoPagamento.Name = "cboTipoPagamento"
        Me.cboTipoPagamento.Size = New System.Drawing.Size(400, 22)
        Me.cboTipoPagamento.TabIndex = 13
        '
        'Pesq_CodigoNome
        '
        Me.Pesq_CodigoNome.BancoDados_Campo_Codigo = "CD_FORNECEDOR"
        Me.Pesq_CodigoNome.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_CodigoNome.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_CodigoNome.BancoDados_Campo_Descricao = "NO_RAZAO_SOCIAL"
        Me.Pesq_CodigoNome.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_CodigoNome.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_CodigoNome.BancoDados_Tabela = "FORNECEDOR F"
        Me.Pesq_CodigoNome.Codigo = 0
        Me.Pesq_CodigoNome.ExibirCodigo = True
        Me.Pesq_CodigoNome.Location = New System.Drawing.Point(5, 18)
        Me.Pesq_CodigoNome.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_CodigoNome.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_CodigoNome.Name = "Pesq_CodigoNome"
        Me.Pesq_CodigoNome.Size = New System.Drawing.Size(400, 28)
        Me.Pesq_CodigoNome.TabIndex = 0
        Me.Pesq_CodigoNome.TelaFiltro = False
        Me.Pesq_CodigoNome.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'frmConsultaPagamento_Alteracao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(412, 165)
        Me.Controls.Add(Me.cboTipoPagamento)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.chkICMS_Pago)
        Me.Controls.Add(Me.chkInterfaceEnviadaJDE)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Pesq_CodigoNome)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConsultaPagamento_Alteracao"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Consulta de Pagamento - Alteração"
        CType(Me.cboTipoPagamento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Pesq_CodigoNome As Logus.Pesq_CodigoNome
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkInterfaceEnviadaJDE As System.Windows.Forms.CheckBox
    Friend WithEvents chkICMS_Pago As System.Windows.Forms.CheckBox
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cboTipoPagamento As Infragistics.Win.UltraWinGrid.UltraCombo
End Class
