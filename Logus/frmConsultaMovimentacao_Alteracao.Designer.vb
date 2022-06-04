<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaMovimentacao_Alteracao
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaMovimentacao_Alteracao))
        Me.Label14 = New System.Windows.Forms.Label
        Me.cboLocalEntrega = New System.Windows.Forms.ComboBox
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtSerie = New System.Windows.Forms.TextBox
        Me.txtDataNF = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtNotaFiscal = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboTipoCacau = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboFilialOrigem = New System.Windows.Forms.ComboBox
        Me.Pesq_Municipio = New Logus.Pesq_CodigoNome
        Me.Label4 = New System.Windows.Forms.Label
        Me.Pesq_Fornecedor = New Logus.Pesq_CodigoNome
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboTipoDocumento = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboProcedencia = New System.Windows.Forms.ComboBox
        Me.txtQuantidade = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Label6 = New System.Windows.Forms.Label
        CType(Me.txtDataNF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantidade, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(129, 137)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 13)
        Me.Label14.TabIndex = 310
        Me.Label14.Text = "Local de Entrega"
        '
        'cboLocalEntrega
        '
        Me.cboLocalEntrega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLocalEntrega.Location = New System.Drawing.Point(129, 150)
        Me.cboLocalEntrega.Name = "cboLocalEntrega"
        Me.cboLocalEntrega.Size = New System.Drawing.Size(188, 21)
        Me.cboLocalEntrega.TabIndex = 294
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(396, 179)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 307
        Me.cmdFechar.Text = "F"
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(5, 179)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 306
        Me.cmdGravar.TabStop = False
        Me.cmdGravar.Text = "G"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(5, 93)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 13)
        Me.Label11.TabIndex = 305
        Me.Label11.Text = "Data N.F."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(169, 93)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 13)
        Me.Label10.TabIndex = 304
        Me.Label10.Text = "Serie"
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(169, 106)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(43, 20)
        Me.txtSerie.TabIndex = 288
        '
        'txtDataNF
        '
        Me.txtDataNF.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtDataNF.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataNF.Location = New System.Drawing.Point(5, 106)
        Me.txtDataNF.Name = "txtDataNF"
        Me.txtDataNF.Size = New System.Drawing.Size(91, 23)
        Me.txtDataNF.TabIndex = 286
        Me.txtDataNF.Value = Nothing
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(104, 93)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 303
        Me.Label9.Text = "Nº N.F."
        '
        'txtNotaFiscal
        '
        Me.txtNotaFiscal.Location = New System.Drawing.Point(104, 106)
        Me.txtNotaFiscal.Name = "txtNotaFiscal"
        Me.txtNotaFiscal.Size = New System.Drawing.Size(57, 20)
        Me.txtNotaFiscal.TabIndex = 287
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(325, 137)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 302
        Me.Label7.Text = "Tipo Cacau"
        '
        'cboTipoCacau
        '
        Me.cboTipoCacau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoCacau.Location = New System.Drawing.Point(325, 150)
        Me.cboTipoCacau.Name = "cboTipoCacau"
        Me.cboTipoCacau.Size = New System.Drawing.Size(116, 21)
        Me.cboTipoCacau.TabIndex = 292
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(220, 93)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 13)
        Me.Label8.TabIndex = 301
        Me.Label8.Text = "Filial de Origem"
        '
        'cboFilialOrigem
        '
        Me.cboFilialOrigem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilialOrigem.Location = New System.Drawing.Point(220, 106)
        Me.cboFilialOrigem.Name = "cboFilialOrigem"
        Me.cboFilialOrigem.Size = New System.Drawing.Size(219, 21)
        Me.cboFilialOrigem.TabIndex = 293
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
        Me.Pesq_Municipio.Location = New System.Drawing.Point(5, 62)
        Me.Pesq_Municipio.MaximumSize = New System.Drawing.Size(1000, 23)
        Me.Pesq_Municipio.MinimumSize = New System.Drawing.Size(0, 23)
        Me.Pesq_Municipio.Name = "Pesq_Municipio"
        Me.Pesq_Municipio.Size = New System.Drawing.Size(301, 23)
        Me.Pesq_Municipio.TabIndex = 285
        Me.Pesq_Municipio.TelaFiltro = False
        Me.Pesq_Municipio.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(5, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 298
        Me.Label4.Text = "Municipio"
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
        Me.Pesq_Fornecedor.Location = New System.Drawing.Point(5, 18)
        Me.Pesq_Fornecedor.MaximumSize = New System.Drawing.Size(1000, 23)
        Me.Pesq_Fornecedor.MinimumSize = New System.Drawing.Size(0, 23)
        Me.Pesq_Fornecedor.Name = "Pesq_Fornecedor"
        Me.Pesq_Fornecedor.Size = New System.Drawing.Size(364, 23)
        Me.Pesq_Fornecedor.TabIndex = 284
        Me.Pesq_Fornecedor.TelaFiltro = False
        Me.Pesq_Fornecedor.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(5, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 296
        Me.Label1.Text = "Fornecedor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(314, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 295
        Me.Label2.Text = "Tipo Documento"
        '
        'cboTipoDocumento
        '
        Me.cboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDocumento.Location = New System.Drawing.Point(314, 62)
        Me.cboTipoDocumento.Name = "cboTipoDocumento"
        Me.cboTipoDocumento.Size = New System.Drawing.Size(127, 21)
        Me.cboTipoDocumento.TabIndex = 283
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(5, 137)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 312
        Me.Label3.Text = "Procedencia"
        '
        'cboProcedencia
        '
        Me.cboProcedencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProcedencia.Location = New System.Drawing.Point(5, 150)
        Me.cboProcedencia.Name = "cboProcedencia"
        Me.cboProcedencia.Size = New System.Drawing.Size(116, 21)
        Me.cboProcedencia.TabIndex = 311
        '
        'txtQuantidade
        '
        Me.txtQuantidade.Location = New System.Drawing.Point(375, 18)
        Me.txtQuantidade.MaskInput = "{LOC}-nnnn,nnn"
        Me.txtQuantidade.Name = "txtQuantidade"
        Me.txtQuantidade.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtQuantidade.Size = New System.Drawing.Size(66, 21)
        Me.txtQuantidade.TabIndex = 313
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(375, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 314
        Me.Label6.Text = "Quantidade"
        '
        'frmConsultaMovimentacao_Alteracao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(447, 230)
        Me.Controls.Add(Me.txtQuantidade)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboProcedencia)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.cboLocalEntrega)
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
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboFilialOrigem)
        Me.Controls.Add(Me.Pesq_Municipio)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Pesq_Fornecedor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboTipoDocumento)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsultaMovimentacao_Alteracao"
        Me.Text = "Altera Movimentação"
        CType(Me.txtDataNF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantidade, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboLocalEntrega As System.Windows.Forms.ComboBox
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents txtDataNF As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNotaFiscal As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboTipoCacau As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboFilialOrigem As System.Windows.Forms.ComboBox
    Friend WithEvents Pesq_Municipio As Logus.Pesq_CodigoNome
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Pesq_Fornecedor As Logus.Pesq_CodigoNome
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboTipoDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboProcedencia As System.Windows.Forms.ComboBox
    Friend WithEvents txtQuantidade As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
