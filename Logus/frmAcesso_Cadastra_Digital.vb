Imports GrFingerXLib
Imports System.io

Public Class frmAcesso_Cadastra_Digital
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
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents AxGrFingerXCtrl1 As AxGrFingerXLib.AxGrFingerXCtrl
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblNome As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbltext1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lbltext2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lbltext3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents grdGeral As Infragistics.Win.UltraWinGrid.UltraGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAcesso_Cadastra_Digital))
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.AxGrFingerXCtrl1 = New AxGrFingerXLib.AxGrFingerXCtrl
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.lblNome = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.grdGeral = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.lbltext1 = New Infragistics.Win.Misc.UltraLabel
        Me.lbltext2 = New Infragistics.Win.Misc.UltraLabel
        Me.lbltext3 = New Infragistics.Win.Misc.UltraLabel
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxGrFingerXCtrl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.Control
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(209, 35)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(233, 255)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'AxGrFingerXCtrl1
        '
        Me.AxGrFingerXCtrl1.Enabled = True
        Me.AxGrFingerXCtrl1.Location = New System.Drawing.Point(428, -1)
        Me.AxGrFingerXCtrl1.Name = "AxGrFingerXCtrl1"
        Me.AxGrFingerXCtrl1.OcxState = CType(resources.GetObject("AxGrFingerXCtrl1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxGrFingerXCtrl1.Size = New System.Drawing.Size(32, 32)
        Me.AxGrFingerXCtrl1.TabIndex = 11
        '
        'cmdGravar
        '
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(158, 229)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 13
        Me.cmdGravar.Text = "G"
        '
        'cmdFechar
        '
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(562, 296)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 14
        Me.cmdFechar.Text = "F"
        '
        'lblNome
        '
        Me.lblNome.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNome.Location = New System.Drawing.Point(265, 16)
        Me.lblNome.Name = "lblNome"
        Me.lblNome.Size = New System.Drawing.Size(264, 16)
        Me.lblNome.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(209, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Nome:"
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
        Me.grdGeral.Location = New System.Drawing.Point(448, -1)
        Me.grdGeral.Name = "grdGeral"
        Me.grdGeral.Size = New System.Drawing.Size(159, 291)
        Me.grdGeral.TabIndex = 20
        Me.grdGeral.Text = "UltraGrid1"
        '
        'lbltext1
        '
        Appearance13.ForeColor = System.Drawing.Color.Black
        Me.lbltext1.Appearance = Appearance13
        Me.lbltext1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltext1.Location = New System.Drawing.Point(12, 12)
        Me.lbltext1.Name = "lbltext1"
        Me.lbltext1.Size = New System.Drawing.Size(180, 61)
        Me.lbltext1.TabIndex = 21
        Me.lbltext1.Text = "1 - Coloque o dedo no sensor do leitor de digital."
        '
        'lbltext2
        '
        Appearance14.ForeColor = System.Drawing.Color.Black
        Me.lbltext2.Appearance = Appearance14
        Me.lbltext2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltext2.Location = New System.Drawing.Point(12, 95)
        Me.lbltext2.Name = "lbltext2"
        Me.lbltext2.Size = New System.Drawing.Size(180, 104)
        Me.lbltext2.TabIndex = 22
        Me.lbltext2.Text = "2 - Verificação da qualidade da digital."
        '
        'lbltext3
        '
        Appearance15.ForeColor = System.Drawing.Color.Black
        Me.lbltext3.Appearance = Appearance15
        Me.lbltext3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltext3.Location = New System.Drawing.Point(12, 229)
        Me.lbltext3.Name = "lbltext3"
        Me.lbltext3.Size = New System.Drawing.Size(140, 61)
        Me.lbltext3.TabIndex = 23
        Me.lbltext3.Text = "3- Salvar a digital"
        '
        'Timer1
        '
        Me.Timer1.Interval = 3000
        '
        'frmAcesso_Cadastra_Digital
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(613, 347)
        Me.Controls.Add(Me.cmdGravar)
        Me.Controls.Add(Me.lbltext3)
        Me.Controls.Add(Me.lbltext2)
        Me.Controls.Add(Me.lbltext1)
        Me.Controls.Add(Me.grdGeral)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblNome)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.AxGrFingerXCtrl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmAcesso_Cadastra_Digital"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastra Digital "
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxGrFingerXCtrl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdGeral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim myUtil As Util
    Dim oDS As New Infragistics.Win.UltraWinDataSource.UltraDataSource

    Const cnt_GridGeral_nu_digital As Integer = 0
    Const cnt_GridGeral_Digital As Integer = 1

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim ret As Integer, score As Integer

        'verifica se já ta cadastrada a digital
        score = 0
        ' identifica digital
        ret = myUtil.Identify(score)
        ' escreve log
        If ret > 0 Then
            lbltext3.Text = "3 - Digital já cadastrada."
            lbltext3.Appearance.ForeColor = Color.Red
            Timer1.Start()
        Else
            lbltext3.Text = "3 - Digital cadastrada."
            lbltext3.Appearance.ForeColor = Color.Green
        End If
        cmdGravar.Enabled = False

        myUtil.Enroll()
        AtualizaDados()
    End Sub

    Private Sub AxGrFingerXCtrl1_FingerDown(ByVal sender As Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_FingerDownEvent) Handles AxGrFingerXCtrl1.FingerDown
        IniciaColeta()
        lbltext1.Appearance.ForeColor = Color.Green
    End Sub

    ' -----------------------------------------------------------------------------------
    ' GrFingerX events
    ' -----------------------------------------------------------------------------------

    'quando um leito é plugado
    Private Sub AxGrFingerXCtrl1_SensorPlug(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_SensorPlugEvent) Handles AxGrFingerXCtrl1.SensorPlug
        AxGrFingerXCtrl1.CapStartCapture(e.idSensor)
    End Sub

    'Quando o leito é desplugado
    Private Sub AxGrFingerXCtrl1_SensorUnplug(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_SensorUnplugEvent) Handles AxGrFingerXCtrl1.SensorUnplug
        AxGrFingerXCtrl1.CapStopCapture(e.idSensor)
    End Sub

    'Adquirindo imagem do leitor
    Private Sub AxGrFingerXCtrl1_ImageAcquired(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_ImageAcquiredEvent) Handles AxGrFingerXCtrl1.ImageAcquired
        'copia a imagem adquiraida
        myUtil.raw.height = e.height
        myUtil.raw.width = e.width
        myUtil.raw.res = e.res
        myUtil.raw.img = e.rawImage

        'exibe a imagem adquirida
        myUtil.PrintBiometricDisplay(False, GRConstants.GR_DEFAULT_CONTEXT)

        'extrai digital
        ExtractDigital()
    End Sub

    Private Sub ExtractDigital()
        Dim ret As Integer

        'extrai a digital
        ret = myUtil.ExtractTemplate()
        'verifica qualidade da digital
        If ret = GRConstants.GR_BAD_QUALITY Then
            lbltext2.Text = "2 - Digital capturada com má qualidade. Favor voltar ao passo 1."
            lbltext2.Appearance.ForeColor = Color.Red
            Timer1.Start()
        ElseIf ret = GRConstants.GR_MEDIUM_QUALITY Then
            lbltext2.Text = "2 - Digital capturada com sucesso, a qualidade poderia ser melhor."
            lbltext2.Appearance.ForeColor = Color.Green
            cmdGravar.Enabled = True
        ElseIf ret = GRConstants.GR_HIGH_QUALITY Then
            lbltext2.Text = "2 - Digital capturada com sucesso e com uma excelente qualidade."
            lbltext2.Appearance.ForeColor = Color.Green
            cmdGravar.Enabled = True
        End If
        If ret >= 0 Then
            myUtil.PrintBiometricDisplay(True, GRConstants.GR_NO_CONTEXT)
        Else
            lbltext2.Text = "2 - Erro na leitura da digital."
            lbltext2.Appearance.ForeColor = Color.Red
            Timer1.Start()
        End If
    End Sub

    Private Sub frmAcesso_Altera_Senha_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim err As Integer

        'Inicializa class util
        myUtil = New Util(Nothing, PictureBox1, AxGrFingerXCtrl1)

        'Inicializa GrFingerX Library
        err = myUtil.InitializeGrFinger()

        'verifica se retornou erro, nesse caso é abilitado apenas o acesso via usuario e senha
        If err < 0 Then
            Msg_Mensagem("Encontramos algum problema e a digital não poderá ser incluida.")
        End If

        '>>>> Formato grid 
        objGrid_Inicializar(grdGeral, , oDS, Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect)
        objGrid_Coluna_Add(grdGeral, "nu_digital", 0)
        objGrid_Coluna_Add(grdGeral, "Digital", 100)

        IniciaColeta()

        AtualizaDados()
    End Sub

    Private Sub AtualizaDados()
        Dim SqlText As String
        Dim oData As DataTable
        Dim i As Integer

        SqlText = "SELECT UD.SQ_USUARIO_DIGITAL" & _
                  " FROM AGC.SEC_USUARIO_DIGITAL UD," & _
                        "AGC.SEC_USUARIO U" & _
                  " WHERE UD.CD_USUARIO = U.CD_USUARIO" & _
                    " AND UD.IM_DIGITAL IS NOT NULL" & _
                    " AND  U.CD_USUARIO =" & QuotedStr(sAcesso_UsuarioLogado)
        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_nu_digital})

        SqlText = "SELECT UD.SQ_USUARIO_DIGITAL," & _
                          "U.NO_USUARIO," & _
                         "UD.IM_DIGITAL" & _
                  " FROM AGC.SEC_USUARIO_DIGITAL UD," & _
                        "AGC.SEC_USUARIO U" & _
                  " WHERE UD.CD_USUARIO = U.CD_USUARIO" & _
                    " AND UD.IM_DIGITAL IS NOT NULL " & _
                    " AND  U.CD_USUARIO = " & QuotedStr(sAcesso_UsuarioLogado)
        oData = DBQuery(SqlText)

        'prepara para exibir a imagem no grid
        Dim bt() As Byte
        Dim ms As MemoryStream

        If Not objDataTable_Vazio(oData) Then
            For i = 0 To oData.Rows.Count - 1
                bt = oData.Rows(i).Item("IM_DIGITAL")
                ms = New MemoryStream(bt)
                grdGeral.Rows(i).Cells(1).Appearance.ImageHAlign = Infragistics.Win.HAlign.Center
                grdGeral.Rows(i).Cells(1).Appearance.Image = Image.FromStream(ms)
                grdGeral.Rows(i).Height = 100
            Next

            lblNome.Text = oData.Rows(0).Item("NO_USUARIO")
        End If
    End Sub

    Private Sub frmAcesso_Altera_Senha_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        myUtil.FinalizeGrFinger()
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub
    Private Sub IniciaColeta()
        lbltext1.Appearance.ForeColor = Color.Blue
        lbltext2.Appearance.ForeColor = Color.Blue
        lbltext2.Text = "2 - Verificação da qualidade da digital."
        lbltext3.Appearance.ForeColor = Color.Blue
        PictureBox1 = Nothing
        cmdGravar.Enabled = False
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        IniciaColeta()
        Timer1.Stop()
    End Sub

    Private Sub grdGeral_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdGeral.BeforeRowsDeleted
        Try
            e.DisplayPromptMsg = False

            If Msg_Perguntar("Deseja excluir a digital?") Then
                If Not CampoNulo(e.Rows(0).Cells(cnt_GridGeral_nu_digital).Value) Then
                    If Not DBExecutar_Delete("AGC.SEC_USUARIO_DIGITAL", "SQ_USUARIO_DIGITAL", e.Rows(0).Cells(cnt_GridGeral_nu_digital).Value) Then GoTo Erro
                End If
            Else
                e.Cancel = True
            End If
        Catch ex As Exception
            Msg_Mensagem(ex.Message)
            e.Cancel = True
        End Try

        Exit Sub
Erro:
        e.Cancel = True
    End Sub
End Class
