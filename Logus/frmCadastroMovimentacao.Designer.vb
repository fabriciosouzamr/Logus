<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroMovimentacao
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadastroMovimentacao))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboTipoDocumento = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtQuantidade = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtDataMovimentacao = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboFilialMovimentacao = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboTipoCacau = New System.Windows.Forms.ComboBox
        Me.txtDataNF = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtNotaFiscal = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtSerie = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.txtValorDocumento = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtValorICMS = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.cboLocalEntrega = New System.Windows.Forms.ComboBox
        Me.Pesq_Municipio = New Logus.Pesq_CodigoNome
        Me.Pesq_TipoMovimentacao = New Logus.Pesq_CodigoNome
        Me.Pesq_Fornecedor = New Logus.Pesq_CodigoNome
        CType(Me.txtQuantidade, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataMovimentacao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataNF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorICMS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(5, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 253
        Me.Label1.Text = "Fornecedor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(443, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 252
        Me.Label2.Text = "Tipo Documento"
        '
        'cboTipoDocumento
        '
        Me.cboTipoDocumento.Location = New System.Drawing.Point(443, 21)
        Me.cboTipoDocumento.Name = "cboTipoDocumento"
        Me.cboTipoDocumento.Size = New System.Drawing.Size(177, 21)
        Me.cboTipoDocumento.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(5, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 13)
        Me.Label3.TabIndex = 255
        Me.Label3.Text = "Tipo Movimentação"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(320, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 257
        Me.Label4.Text = "Municipio"
        '
        'txtQuantidade
        '
        Me.txtQuantidade.Location = New System.Drawing.Point(220, 102)
        Me.txtQuantidade.MaskInput = "{LOC}-nnnn,nnn"
        Me.txtQuantidade.Name = "txtQuantidade"
        Me.txtQuantidade.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtQuantidade.Size = New System.Drawing.Size(66, 21)
        Me.txtQuantidade.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(345, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 263
        Me.Label5.Text = "Data"
        '
        'txtDataMovimentacao
        '
        Me.txtDataMovimentacao.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataMovimentacao.Location = New System.Drawing.Point(345, 19)
        Me.txtDataMovimentacao.Name = "txtDataMovimentacao"
        Me.txtDataMovimentacao.ReadOnly = True
        Me.txtDataMovimentacao.Size = New System.Drawing.Size(90, 23)
        Me.txtDataMovimentacao.TabIndex = 1
        Me.txtDataMovimentacao.Value = Nothing
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(5, 133)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(115, 13)
        Me.Label8.TabIndex = 264
        Me.Label8.Text = "Filial de Movimentação"
        '
        'cboFilialMovimentacao
        '
        Me.cboFilialMovimentacao.Location = New System.Drawing.Point(5, 148)
        Me.cboFilialMovimentacao.Name = "cboFilialMovimentacao"
        Me.cboFilialMovimentacao.Size = New System.Drawing.Size(250, 21)
        Me.cboFilialMovimentacao.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(220, 87)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 261
        Me.Label6.Text = "Quantidade"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(505, 87)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 266
        Me.Label7.Text = "Tipo Cacau"
        '
        'cboTipoCacau
        '
        Me.cboTipoCacau.Location = New System.Drawing.Point(505, 102)
        Me.cboTipoCacau.Name = "cboTipoCacau"
        Me.cboTipoCacau.Size = New System.Drawing.Size(116, 21)
        Me.cboTipoCacau.TabIndex = 11
        '
        'txtDataNF
        '
        Me.txtDataNF.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtDataNF.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataNF.Location = New System.Drawing.Point(5, 102)
        Me.txtDataNF.Name = "txtDataNF"
        Me.txtDataNF.Size = New System.Drawing.Size(91, 23)
        Me.txtDataNF.TabIndex = 5
        Me.txtDataNF.Value = Nothing
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(104, 87)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 268
        Me.Label9.Text = "Nº N.F."
        '
        'txtNotaFiscal
        '
        Me.txtNotaFiscal.Location = New System.Drawing.Point(104, 102)
        Me.txtNotaFiscal.Name = "txtNotaFiscal"
        Me.txtNotaFiscal.Size = New System.Drawing.Size(57, 20)
        Me.txtNotaFiscal.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(169, 87)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 13)
        Me.Label10.TabIndex = 271
        Me.Label10.Text = "Serie"
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(169, 102)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(43, 20)
        Me.txtSerie.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(5, 87)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 13)
        Me.Label11.TabIndex = 272
        Me.Label11.Text = "Data N.F."
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(574, 177)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 274
        Me.cmdFechar.Text = "F"
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(5, 177)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 273
        Me.cmdGravar.TabStop = False
        Me.cmdGravar.Text = "G"
        '
        'txtValorDocumento
        '
        Me.txtValorDocumento.Location = New System.Drawing.Point(294, 102)
        Me.txtValorDocumento.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtValorDocumento.Name = "txtValorDocumento"
        Me.txtValorDocumento.Size = New System.Drawing.Size(100, 21)
        Me.txtValorDocumento.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(294, 87)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(89, 13)
        Me.Label12.TabIndex = 275
        Me.Label12.Text = "Valor Documento"
        '
        'txtValorICMS
        '
        Me.txtValorICMS.Location = New System.Drawing.Point(402, 102)
        Me.txtValorICMS.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtValorICMS.Name = "txtValorICMS"
        Me.txtValorICMS.Size = New System.Drawing.Size(95, 21)
        Me.txtValorICMS.TabIndex = 10
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(402, 87)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(60, 13)
        Me.Label13.TabIndex = 277
        Me.Label13.Text = "Valor ICMS"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(263, 133)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 13)
        Me.Label14.TabIndex = 280
        Me.Label14.Text = "Local de Entrega"
        '
        'cboLocalEntrega
        '
        Me.cboLocalEntrega.Location = New System.Drawing.Point(263, 148)
        Me.cboLocalEntrega.Name = "cboLocalEntrega"
        Me.cboLocalEntrega.Size = New System.Drawing.Size(180, 21)
        Me.cboLocalEntrega.TabIndex = 13
        '
        'Pesq_Municipio
        '
        Me.Pesq_Municipio.BancoDados_Campo_Codigo = "CD_FORNECEDOR"
        Me.Pesq_Municipio.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Municipio.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_Municipio.BancoDados_Campo_Descricao = "NO_RAZAO_SOCIAL"
        Me.Pesq_Municipio.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_Municipio.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Municipio.BancoDados_Tabela = "FORNECEDOR F"
        Me.Pesq_Municipio.Codigo = 0
        Me.Pesq_Municipio.ExibirCodigo = True
        Me.Pesq_Municipio.Location = New System.Drawing.Point(323, 59)
        Me.Pesq_Municipio.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_Municipio.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_Municipio.Name = "Pesq_Municipio"
        Me.Pesq_Municipio.Size = New System.Drawing.Size(300, 28)
        Me.Pesq_Municipio.TabIndex = 4
        Me.Pesq_Municipio.TelaFiltro = False
        Me.Pesq_Municipio.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'Pesq_TipoMovimentacao
        '
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_Codigo = "CD_FORNECEDOR"
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_Descricao = "NO_RAZAO_SOCIAL"
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_TipoMovimentacao.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_TipoMovimentacao.BancoDados_Tabela = "FORNECEDOR F"
        Me.Pesq_TipoMovimentacao.Codigo = 0
        Me.Pesq_TipoMovimentacao.ExibirCodigo = True
        Me.Pesq_TipoMovimentacao.Location = New System.Drawing.Point(5, 18)
        Me.Pesq_TipoMovimentacao.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_TipoMovimentacao.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_TipoMovimentacao.Name = "Pesq_TipoMovimentacao"
        Me.Pesq_TipoMovimentacao.Size = New System.Drawing.Size(332, 28)
        Me.Pesq_TipoMovimentacao.TabIndex = 0
        Me.Pesq_TipoMovimentacao.TelaFiltro = False
        Me.Pesq_TipoMovimentacao.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'Pesq_Fornecedor
        '
        Me.Pesq_Fornecedor.BancoDados_Campo_Codigo = "CD_FORNECEDOR"
        Me.Pesq_Fornecedor.BancoDados_Campo_Codigo_Tipo = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Fornecedor.BancoDados_Campo_Codigo2 = Nothing
        Me.Pesq_Fornecedor.BancoDados_Campo_Descricao = "NO_RAZAO_SOCIAL"
        Me.Pesq_Fornecedor.BancoDados_Campo_Pesquisa = Nothing
        Me.Pesq_Fornecedor.BancoDados_Campo_TipoPesquisa = Logus.Pesq_CodigoNome.TipoCampoPesquisa.SemDefinicao
        Me.Pesq_Fornecedor.BancoDados_Tabela = "FORNECEDOR F"
        Me.Pesq_Fornecedor.Codigo = 0
        Me.Pesq_Fornecedor.ExibirCodigo = True
        Me.Pesq_Fornecedor.Location = New System.Drawing.Point(5, 59)
        Me.Pesq_Fornecedor.MaximumSize = New System.Drawing.Size(1000, 28)
        Me.Pesq_Fornecedor.MinimumSize = New System.Drawing.Size(0, 28)
        Me.Pesq_Fornecedor.Name = "Pesq_Fornecedor"
        Me.Pesq_Fornecedor.Size = New System.Drawing.Size(310, 28)
        Me.Pesq_Fornecedor.TabIndex = 3
        Me.Pesq_Fornecedor.TelaFiltro = False
        Me.Pesq_Fornecedor.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'frmCadastroMovimentacao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(627, 230)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.cboLocalEntrega)
        Me.Controls.Add(Me.txtValorICMS)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtValorDocumento)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtSerie)
        Me.Controls.Add(Me.txtDataNF)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtNotaFiscal)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboTipoCacau)
        Me.Controls.Add(Me.txtQuantidade)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtDataMovimentacao)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboFilialMovimentacao)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Pesq_Municipio)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Pesq_TipoMovimentacao)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Pesq_Fornecedor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboTipoDocumento)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCadastroMovimentacao"
        Me.Text = "Inclusão de Nota Fiscal Complementar"
        CType(Me.txtQuantidade, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataMovimentacao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataNF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorICMS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Pesq_Fornecedor As Logus.Pesq_CodigoNome
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboTipoDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents Pesq_TipoMovimentacao As Logus.Pesq_CodigoNome
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Pesq_Municipio As Logus.Pesq_CodigoNome
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtQuantidade As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDataMovimentacao As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboFilialMovimentacao As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboTipoCacau As System.Windows.Forms.ComboBox
    Friend WithEvents txtDataNF As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNotaFiscal As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtValorDocumento As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtValorICMS As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboLocalEntrega As System.Windows.Forms.ComboBox
End Class
