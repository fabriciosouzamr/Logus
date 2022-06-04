<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmREL_Movimentacao_DataCacau
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
        Me.cmdExportaRelatorio = New Infragistics.Win.Misc.UltraButton
        Me.grpPeriodo = New System.Windows.Forms.GroupBox
        Me.txtDataFinal = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtDataInicial = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.cmdImprimir = New Infragistics.Win.Misc.UltraButton
        Me.lblR_FilialMovimentacao = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.crvMain = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.optOrigem_Industrializacao = New System.Windows.Forms.RadioButton
        Me.optOrigem_EstoqueAtual = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.optTipo_Analitico = New System.Windows.Forms.RadioButton
        Me.optTipo_Sintetico = New System.Windows.Forms.RadioButton
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtIntervalo_08 = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtIntervalo_07 = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtIntervalo_06 = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtIntervalo_05 = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtIntervalo_04 = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtIntervalo_03 = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtIntervalo_02 = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.txtIntervalo_01 = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.cboTipoIntervalo_08 = New System.Windows.Forms.ComboBox
        Me.cboTipoIntervalo_07 = New System.Windows.Forms.ComboBox
        Me.cboTipoIntervalo_06 = New System.Windows.Forms.ComboBox
        Me.cboTipoIntervalo_05 = New System.Windows.Forms.ComboBox
        Me.cboTipoIntervalo_04 = New System.Windows.Forms.ComboBox
        Me.cboTipoIntervalo_03 = New System.Windows.Forms.ComboBox
        Me.cboTipoIntervalo_02 = New System.Windows.Forms.ComboBox
        Me.cboTipoIntervalo_01 = New System.Windows.Forms.ComboBox
        Me.txtIntervalo = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.cboTipoIntervalo = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.grpVisualizarPor = New System.Windows.Forms.GroupBox
        Me.chkVisualizarPor_Tipo = New System.Windows.Forms.CheckBox
        Me.chkVisualizarPor_Pilha = New System.Windows.Forms.CheckBox
        Me.chkVisualizarPor_Armazem = New System.Windows.Forms.CheckBox
        Me.SelecaoFilialRecebimento = New Logus.Selecao
        Me.SelecaoFilialMovimentacao = New Logus.Selecao
        Me.grpPeriodo.SuspendLayout()
        CType(Me.txtDataFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.txtIntervalo_08, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIntervalo_07, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIntervalo_06, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIntervalo_05, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIntervalo_04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIntervalo_03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIntervalo_02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIntervalo_01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIntervalo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpVisualizarPor.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdExportaRelatorio
        '
        Me.cmdExportaRelatorio.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdExportaRelatorio.Location = New System.Drawing.Point(750, 59)
        Me.cmdExportaRelatorio.Name = "cmdExportaRelatorio"
        Me.cmdExportaRelatorio.Size = New System.Drawing.Size(45, 45)
        Me.cmdExportaRelatorio.TabIndex = 512
        Me.cmdExportaRelatorio.Text = "ER"
        '
        'grpPeriodo
        '
        Me.grpPeriodo.Controls.Add(Me.txtDataFinal)
        Me.grpPeriodo.Controls.Add(Me.txtDataInicial)
        Me.grpPeriodo.Location = New System.Drawing.Point(140, 8)
        Me.grpPeriodo.Name = "grpPeriodo"
        Me.grpPeriodo.Size = New System.Drawing.Size(235, 55)
        Me.grpPeriodo.TabIndex = 502
        Me.grpPeriodo.TabStop = False
        Me.grpPeriodo.Text = "Período"
        '
        'txtDataFinal
        '
        Me.txtDataFinal.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtDataFinal.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataFinal.Location = New System.Drawing.Point(122, 19)
        Me.txtDataFinal.Name = "txtDataFinal"
        Me.txtDataFinal.Size = New System.Drawing.Size(104, 23)
        Me.txtDataFinal.TabIndex = 226
        Me.txtDataFinal.Value = Nothing
        '
        'txtDataInicial
        '
        Me.txtDataInicial.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtDataInicial.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.txtDataInicial.Location = New System.Drawing.Point(10, 19)
        Me.txtDataInicial.Name = "txtDataInicial"
        Me.txtDataInicial.Size = New System.Drawing.Size(104, 23)
        Me.txtDataInicial.TabIndex = 225
        Me.txtDataInicial.Value = Nothing
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(750, 110)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 501
        Me.cmdFechar.Text = "F"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdImprimir.Location = New System.Drawing.Point(750, 8)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(45, 45)
        Me.cmdImprimir.TabIndex = 500
        Me.cmdImprimir.Text = "I"
        '
        'lblR_FilialMovimentacao
        '
        Me.lblR_FilialMovimentacao.AutoSize = True
        Me.lblR_FilialMovimentacao.Location = New System.Drawing.Point(11, 69)
        Me.lblR_FilialMovimentacao.Name = "lblR_FilialMovimentacao"
        Me.lblR_FilialMovimentacao.Size = New System.Drawing.Size(100, 13)
        Me.lblR_FilialMovimentacao.TabIndex = 495
        Me.lblR_FilialMovimentacao.Text = "Filial Movimentação"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(366, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 13)
        Me.Label5.TabIndex = 508
        Me.Label5.Text = "Filial Recebimento"
        '
        'crvMain
        '
        Me.crvMain.ActiveViewIndex = -1
        Me.crvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvMain.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.crvMain.Location = New System.Drawing.Point(11, 172)
        Me.crvMain.Name = "crvMain"
        Me.crvMain.SelectionFormula = ""
        Me.crvMain.ShowCloseButton = False
        Me.crvMain.ShowGroupTreeButton = False
        Me.crvMain.ShowRefreshButton = False
        Me.crvMain.Size = New System.Drawing.Size(784, 504)
        Me.crvMain.TabIndex = 493
        Me.crvMain.ViewTimeSelectionFormula = ""
        '
        'optOrigem_Industrializacao
        '
        Me.optOrigem_Industrializacao.AutoSize = True
        Me.optOrigem_Industrializacao.Location = New System.Drawing.Point(11, 15)
        Me.optOrigem_Industrializacao.Name = "optOrigem_Industrializacao"
        Me.optOrigem_Industrializacao.Size = New System.Drawing.Size(98, 17)
        Me.optOrigem_Industrializacao.TabIndex = 513
        Me.optOrigem_Industrializacao.TabStop = True
        Me.optOrigem_Industrializacao.Text = "Industrialização"
        Me.optOrigem_Industrializacao.UseVisualStyleBackColor = True
        '
        'optOrigem_EstoqueAtual
        '
        Me.optOrigem_EstoqueAtual.AutoSize = True
        Me.optOrigem_EstoqueAtual.Checked = True
        Me.optOrigem_EstoqueAtual.Location = New System.Drawing.Point(11, 34)
        Me.optOrigem_EstoqueAtual.Name = "optOrigem_EstoqueAtual"
        Me.optOrigem_EstoqueAtual.Size = New System.Drawing.Size(91, 17)
        Me.optOrigem_EstoqueAtual.TabIndex = 513
        Me.optOrigem_EstoqueAtual.TabStop = True
        Me.optOrigem_EstoqueAtual.Text = "Estoque Atual"
        Me.optOrigem_EstoqueAtual.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.optOrigem_EstoqueAtual)
        Me.GroupBox2.Controls.Add(Me.optOrigem_Industrializacao)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(124, 55)
        Me.GroupBox2.TabIndex = 514
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Origem"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.optTipo_Analitico)
        Me.GroupBox3.Controls.Add(Me.optTipo_Sintetico)
        Me.GroupBox3.Location = New System.Drawing.Point(383, 8)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(88, 55)
        Me.GroupBox3.TabIndex = 514
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tipo"
        '
        'optTipo_Analitico
        '
        Me.optTipo_Analitico.AutoSize = True
        Me.optTipo_Analitico.Location = New System.Drawing.Point(11, 15)
        Me.optTipo_Analitico.Name = "optTipo_Analitico"
        Me.optTipo_Analitico.Size = New System.Drawing.Size(67, 17)
        Me.optTipo_Analitico.TabIndex = 513
        Me.optTipo_Analitico.TabStop = True
        Me.optTipo_Analitico.Text = "Analítico"
        Me.optTipo_Analitico.UseVisualStyleBackColor = True
        '
        'optTipo_Sintetico
        '
        Me.optTipo_Sintetico.AutoSize = True
        Me.optTipo_Sintetico.Checked = True
        Me.optTipo_Sintetico.Location = New System.Drawing.Point(11, 34)
        Me.optTipo_Sintetico.Name = "optTipo_Sintetico"
        Me.optTipo_Sintetico.Size = New System.Drawing.Size(66, 17)
        Me.optTipo_Sintetico.TabIndex = 513
        Me.optTipo_Sintetico.TabStop = True
        Me.optTipo_Sintetico.Text = "Sintético"
        Me.optTipo_Sintetico.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtIntervalo_08)
        Me.GroupBox4.Controls.Add(Me.txtIntervalo_07)
        Me.GroupBox4.Controls.Add(Me.txtIntervalo_06)
        Me.GroupBox4.Controls.Add(Me.txtIntervalo_05)
        Me.GroupBox4.Controls.Add(Me.txtIntervalo_04)
        Me.GroupBox4.Controls.Add(Me.txtIntervalo_03)
        Me.GroupBox4.Controls.Add(Me.txtIntervalo_02)
        Me.GroupBox4.Controls.Add(Me.txtIntervalo_01)
        Me.GroupBox4.Controls.Add(Me.cboTipoIntervalo_08)
        Me.GroupBox4.Controls.Add(Me.cboTipoIntervalo_07)
        Me.GroupBox4.Controls.Add(Me.cboTipoIntervalo_06)
        Me.GroupBox4.Controls.Add(Me.cboTipoIntervalo_05)
        Me.GroupBox4.Controls.Add(Me.cboTipoIntervalo_04)
        Me.GroupBox4.Controls.Add(Me.cboTipoIntervalo_03)
        Me.GroupBox4.Controls.Add(Me.cboTipoIntervalo_02)
        Me.GroupBox4.Controls.Add(Me.cboTipoIntervalo_01)
        Me.GroupBox4.Controls.Add(Me.txtIntervalo)
        Me.GroupBox4.Controls.Add(Me.cboTipoIntervalo)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Location = New System.Drawing.Point(11, 109)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(710, 57)
        Me.GroupBox4.TabIndex = 514
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Intervalos"
        '
        'txtIntervalo_08
        '
        Me.txtIntervalo_08.Location = New System.Drawing.Point(639, 10)
        Me.txtIntervalo_08.MaskInput = "nnn"
        Me.txtIntervalo_08.MinValue = 1
        Me.txtIntervalo_08.Name = "txtIntervalo_08"
        Me.txtIntervalo_08.Size = New System.Drawing.Size(65, 21)
        Me.txtIntervalo_08.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always
        Me.txtIntervalo_08.TabIndex = 506
        '
        'txtIntervalo_07
        '
        Me.txtIntervalo_07.Location = New System.Drawing.Point(570, 10)
        Me.txtIntervalo_07.MaskInput = "nnn"
        Me.txtIntervalo_07.MinValue = 1
        Me.txtIntervalo_07.Name = "txtIntervalo_07"
        Me.txtIntervalo_07.Size = New System.Drawing.Size(65, 21)
        Me.txtIntervalo_07.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always
        Me.txtIntervalo_07.TabIndex = 506
        '
        'txtIntervalo_06
        '
        Me.txtIntervalo_06.Location = New System.Drawing.Point(501, 10)
        Me.txtIntervalo_06.MaskInput = "nnn"
        Me.txtIntervalo_06.MinValue = 1
        Me.txtIntervalo_06.Name = "txtIntervalo_06"
        Me.txtIntervalo_06.Size = New System.Drawing.Size(65, 21)
        Me.txtIntervalo_06.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always
        Me.txtIntervalo_06.TabIndex = 506
        '
        'txtIntervalo_05
        '
        Me.txtIntervalo_05.Location = New System.Drawing.Point(432, 10)
        Me.txtIntervalo_05.MaskInput = "nnn"
        Me.txtIntervalo_05.MinValue = 1
        Me.txtIntervalo_05.Name = "txtIntervalo_05"
        Me.txtIntervalo_05.Size = New System.Drawing.Size(65, 21)
        Me.txtIntervalo_05.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always
        Me.txtIntervalo_05.TabIndex = 506
        '
        'txtIntervalo_04
        '
        Me.txtIntervalo_04.Location = New System.Drawing.Point(363, 10)
        Me.txtIntervalo_04.MaskInput = "nnn"
        Me.txtIntervalo_04.MinValue = 1
        Me.txtIntervalo_04.Name = "txtIntervalo_04"
        Me.txtIntervalo_04.Size = New System.Drawing.Size(65, 21)
        Me.txtIntervalo_04.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always
        Me.txtIntervalo_04.TabIndex = 506
        '
        'txtIntervalo_03
        '
        Me.txtIntervalo_03.Location = New System.Drawing.Point(294, 10)
        Me.txtIntervalo_03.MaskInput = "nnn"
        Me.txtIntervalo_03.MinValue = 1
        Me.txtIntervalo_03.Name = "txtIntervalo_03"
        Me.txtIntervalo_03.Size = New System.Drawing.Size(65, 21)
        Me.txtIntervalo_03.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always
        Me.txtIntervalo_03.TabIndex = 506
        '
        'txtIntervalo_02
        '
        Me.txtIntervalo_02.Location = New System.Drawing.Point(225, 10)
        Me.txtIntervalo_02.MaskInput = "nnn"
        Me.txtIntervalo_02.MinValue = 1
        Me.txtIntervalo_02.Name = "txtIntervalo_02"
        Me.txtIntervalo_02.Size = New System.Drawing.Size(65, 21)
        Me.txtIntervalo_02.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always
        Me.txtIntervalo_02.TabIndex = 506
        '
        'txtIntervalo_01
        '
        Me.txtIntervalo_01.Location = New System.Drawing.Point(156, 10)
        Me.txtIntervalo_01.MaskInput = "nnn"
        Me.txtIntervalo_01.MinValue = 1
        Me.txtIntervalo_01.Name = "txtIntervalo_01"
        Me.txtIntervalo_01.Size = New System.Drawing.Size(65, 21)
        Me.txtIntervalo_01.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always
        Me.txtIntervalo_01.TabIndex = 506
        '
        'cboTipoIntervalo_08
        '
        Me.cboTipoIntervalo_08.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoIntervalo_08.Location = New System.Drawing.Point(639, 33)
        Me.cboTipoIntervalo_08.Name = "cboTipoIntervalo_08"
        Me.cboTipoIntervalo_08.Size = New System.Drawing.Size(65, 21)
        Me.cboTipoIntervalo_08.TabIndex = 505
        '
        'cboTipoIntervalo_07
        '
        Me.cboTipoIntervalo_07.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoIntervalo_07.Location = New System.Drawing.Point(570, 33)
        Me.cboTipoIntervalo_07.Name = "cboTipoIntervalo_07"
        Me.cboTipoIntervalo_07.Size = New System.Drawing.Size(65, 21)
        Me.cboTipoIntervalo_07.TabIndex = 505
        '
        'cboTipoIntervalo_06
        '
        Me.cboTipoIntervalo_06.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoIntervalo_06.Location = New System.Drawing.Point(501, 33)
        Me.cboTipoIntervalo_06.Name = "cboTipoIntervalo_06"
        Me.cboTipoIntervalo_06.Size = New System.Drawing.Size(65, 21)
        Me.cboTipoIntervalo_06.TabIndex = 505
        '
        'cboTipoIntervalo_05
        '
        Me.cboTipoIntervalo_05.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoIntervalo_05.Location = New System.Drawing.Point(432, 33)
        Me.cboTipoIntervalo_05.Name = "cboTipoIntervalo_05"
        Me.cboTipoIntervalo_05.Size = New System.Drawing.Size(65, 21)
        Me.cboTipoIntervalo_05.TabIndex = 505
        '
        'cboTipoIntervalo_04
        '
        Me.cboTipoIntervalo_04.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoIntervalo_04.Location = New System.Drawing.Point(363, 33)
        Me.cboTipoIntervalo_04.Name = "cboTipoIntervalo_04"
        Me.cboTipoIntervalo_04.Size = New System.Drawing.Size(65, 21)
        Me.cboTipoIntervalo_04.TabIndex = 505
        '
        'cboTipoIntervalo_03
        '
        Me.cboTipoIntervalo_03.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoIntervalo_03.Location = New System.Drawing.Point(294, 33)
        Me.cboTipoIntervalo_03.Name = "cboTipoIntervalo_03"
        Me.cboTipoIntervalo_03.Size = New System.Drawing.Size(65, 21)
        Me.cboTipoIntervalo_03.TabIndex = 505
        '
        'cboTipoIntervalo_02
        '
        Me.cboTipoIntervalo_02.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoIntervalo_02.Location = New System.Drawing.Point(225, 33)
        Me.cboTipoIntervalo_02.Name = "cboTipoIntervalo_02"
        Me.cboTipoIntervalo_02.Size = New System.Drawing.Size(65, 21)
        Me.cboTipoIntervalo_02.TabIndex = 505
        '
        'cboTipoIntervalo_01
        '
        Me.cboTipoIntervalo_01.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoIntervalo_01.Location = New System.Drawing.Point(156, 33)
        Me.cboTipoIntervalo_01.Name = "cboTipoIntervalo_01"
        Me.cboTipoIntervalo_01.Size = New System.Drawing.Size(65, 21)
        Me.cboTipoIntervalo_01.TabIndex = 505
        '
        'txtIntervalo
        '
        Me.txtIntervalo.Location = New System.Drawing.Point(100, 27)
        Me.txtIntervalo.MaskInput = "nnn"
        Me.txtIntervalo.MinValue = 1
        Me.txtIntervalo.Name = "txtIntervalo"
        Me.txtIntervalo.Size = New System.Drawing.Size(50, 21)
        Me.txtIntervalo.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always
        Me.txtIntervalo.TabIndex = 2
        '
        'cboTipoIntervalo
        '
        Me.cboTipoIntervalo.FormattingEnabled = True
        Me.cboTipoIntervalo.Location = New System.Drawing.Point(7, 27)
        Me.cboTipoIntervalo.Name = "cboTipoIntervalo"
        Me.cboTipoIntervalo.Size = New System.Drawing.Size(87, 21)
        Me.cboTipoIntervalo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(100, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Intervalo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tipo de Intervalo"
        '
        'grpVisualizarPor
        '
        Me.grpVisualizarPor.Controls.Add(Me.chkVisualizarPor_Tipo)
        Me.grpVisualizarPor.Controls.Add(Me.chkVisualizarPor_Pilha)
        Me.grpVisualizarPor.Controls.Add(Me.chkVisualizarPor_Armazem)
        Me.grpVisualizarPor.Location = New System.Drawing.Point(479, 8)
        Me.grpVisualizarPor.Name = "grpVisualizarPor"
        Me.grpVisualizarPor.Size = New System.Drawing.Size(159, 55)
        Me.grpVisualizarPor.TabIndex = 514
        Me.grpVisualizarPor.TabStop = False
        Me.grpVisualizarPor.Text = "Visuzalizar por"
        '
        'chkVisualizarPor_Tipo
        '
        Me.chkVisualizarPor_Tipo.AutoSize = True
        Me.chkVisualizarPor_Tipo.Location = New System.Drawing.Point(10, 33)
        Me.chkVisualizarPor_Tipo.Name = "chkVisualizarPor_Tipo"
        Me.chkVisualizarPor_Tipo.Size = New System.Drawing.Size(47, 17)
        Me.chkVisualizarPor_Tipo.TabIndex = 0
        Me.chkVisualizarPor_Tipo.Text = "Tipo"
        Me.chkVisualizarPor_Tipo.UseVisualStyleBackColor = True
        '
        'chkVisualizarPor_Pilha
        '
        Me.chkVisualizarPor_Pilha.AutoSize = True
        Me.chkVisualizarPor_Pilha.Location = New System.Drawing.Point(95, 16)
        Me.chkVisualizarPor_Pilha.Name = "chkVisualizarPor_Pilha"
        Me.chkVisualizarPor_Pilha.Size = New System.Drawing.Size(49, 17)
        Me.chkVisualizarPor_Pilha.TabIndex = 0
        Me.chkVisualizarPor_Pilha.Text = "Pilha"
        Me.chkVisualizarPor_Pilha.UseVisualStyleBackColor = True
        '
        'chkVisualizarPor_Armazem
        '
        Me.chkVisualizarPor_Armazem.AutoSize = True
        Me.chkVisualizarPor_Armazem.Location = New System.Drawing.Point(10, 16)
        Me.chkVisualizarPor_Armazem.Name = "chkVisualizarPor_Armazem"
        Me.chkVisualizarPor_Armazem.Size = New System.Drawing.Size(69, 17)
        Me.chkVisualizarPor_Armazem.TabIndex = 0
        Me.chkVisualizarPor_Armazem.Text = "Armazém"
        Me.chkVisualizarPor_Armazem.UseVisualStyleBackColor = True
        '
        'SelecaoFilialRecebimento
        '
        Me.SelecaoFilialRecebimento.BackColor = System.Drawing.Color.White
        Me.SelecaoFilialRecebimento.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoFilialRecebimento.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoFilialRecebimento.BancoDados_Campo_OrdenarConsulta = True
        Me.SelecaoFilialRecebimento.BancoDados_Tabela = Nothing
        Me.SelecaoFilialRecebimento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoFilialRecebimento.Location = New System.Drawing.Point(369, 83)
        Me.SelecaoFilialRecebimento.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoFilialRecebimento.MultiplaSelecao = False
        Me.SelecaoFilialRecebimento.Name = "SelecaoFilialRecebimento"
        Me.SelecaoFilialRecebimento.Size = New System.Drawing.Size(350, 20)
        Me.SelecaoFilialRecebimento.TabIndex = 509
        '
        'SelecaoFilialMovimentacao
        '
        Me.SelecaoFilialMovimentacao.BackColor = System.Drawing.Color.White
        Me.SelecaoFilialMovimentacao.BancoDados_Campo_Codigo = Nothing
        Me.SelecaoFilialMovimentacao.BancoDados_Campo_Descricao = Nothing
        Me.SelecaoFilialMovimentacao.BancoDados_Campo_OrdenarConsulta = True
        Me.SelecaoFilialMovimentacao.BancoDados_Tabela = Nothing
        Me.SelecaoFilialMovimentacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelecaoFilialMovimentacao.Location = New System.Drawing.Point(11, 83)
        Me.SelecaoFilialMovimentacao.MinimumSize = New System.Drawing.Size(200, 2)
        Me.SelecaoFilialMovimentacao.MultiplaSelecao = False
        Me.SelecaoFilialMovimentacao.Name = "SelecaoFilialMovimentacao"
        Me.SelecaoFilialMovimentacao.Size = New System.Drawing.Size(350, 20)
        Me.SelecaoFilialMovimentacao.TabIndex = 496
        '
        'frmREL_Movimentacao_DataCacau
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 697)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.grpVisualizarPor)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdExportaRelatorio)
        Me.Controls.Add(Me.SelecaoFilialRecebimento)
        Me.Controls.Add(Me.grpPeriodo)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.lblR_FilialMovimentacao)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.SelecaoFilialMovimentacao)
        Me.Controls.Add(Me.crvMain)
        Me.Name = "frmREL_Movimentacao_DataCacau"
        Me.Text = "Relatório de Movimentação de Cacau - Data Cacau"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grpPeriodo.ResumeLayout(False)
        Me.grpPeriodo.PerformLayout()
        CType(Me.txtDataFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataInicial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.txtIntervalo_08, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIntervalo_07, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIntervalo_06, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIntervalo_05, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIntervalo_04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIntervalo_03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIntervalo_02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIntervalo_01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIntervalo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpVisualizarPor.ResumeLayout(False)
        Me.grpVisualizarPor.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExportaRelatorio As Infragistics.Win.Misc.UltraButton
    Friend WithEvents SelecaoFilialRecebimento As Logus.Selecao
    Friend WithEvents grpPeriodo As System.Windows.Forms.GroupBox
    Friend WithEvents txtDataFinal As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtDataInicial As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdImprimir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblR_FilialMovimentacao As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents SelecaoFilialMovimentacao As Logus.Selecao
    Friend WithEvents crvMain As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents optOrigem_Industrializacao As System.Windows.Forms.RadioButton
    Friend WithEvents optOrigem_EstoqueAtual As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents optTipo_Analitico As System.Windows.Forms.RadioButton
    Friend WithEvents optTipo_Sintetico As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cboTipoIntervalo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtIntervalo As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIntervalo_01 As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents cboTipoIntervalo_06 As System.Windows.Forms.ComboBox
    Friend WithEvents cboTipoIntervalo_05 As System.Windows.Forms.ComboBox
    Friend WithEvents cboTipoIntervalo_04 As System.Windows.Forms.ComboBox
    Friend WithEvents cboTipoIntervalo_03 As System.Windows.Forms.ComboBox
    Friend WithEvents cboTipoIntervalo_02 As System.Windows.Forms.ComboBox
    Friend WithEvents cboTipoIntervalo_01 As System.Windows.Forms.ComboBox
    Friend WithEvents txtIntervalo_06 As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents txtIntervalo_05 As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents txtIntervalo_04 As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents txtIntervalo_03 As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents txtIntervalo_02 As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents txtIntervalo_08 As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents txtIntervalo_07 As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents cboTipoIntervalo_08 As System.Windows.Forms.ComboBox
    Friend WithEvents cboTipoIntervalo_07 As System.Windows.Forms.ComboBox
    Friend WithEvents grpVisualizarPor As System.Windows.Forms.GroupBox
    Friend WithEvents chkVisualizarPor_Armazem As System.Windows.Forms.CheckBox
    Friend WithEvents chkVisualizarPor_Tipo As System.Windows.Forms.CheckBox
    Friend WithEvents chkVisualizarPor_Pilha As System.Windows.Forms.CheckBox
End Class
