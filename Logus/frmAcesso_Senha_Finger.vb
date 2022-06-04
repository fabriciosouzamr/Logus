Imports GrFingerXLib

Public Class frmAcesso_Senha_Finger
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSenha As System.Windows.Forms.TextBox
    Friend WithEvents cmdAcessar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents imgIcone As System.Windows.Forms.ImageList
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents grSenha As System.Windows.Forms.GroupBox
    Friend WithEvents grdDigital As System.Windows.Forms.GroupBox
    Friend WithEvents grdNovaSenha As System.Windows.Forms.GroupBox
    Friend WithEvents txtRedigitacao As System.Windows.Forms.TextBox
    Friend WithEvents txtNovaSenha As System.Windows.Forms.TextBox
    Friend WithEvents cboUsuario As Infragistics.Win.UltraWinGrid.UltraCombo


    Friend WithEvents AxGrFingerXCtrl1 As AxGrFingerXLib.AxGrFingerXCtrl


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAcesso_Senha_Finger))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.grSenha = New System.Windows.Forms.GroupBox
        Me.cboUsuario = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.txtSenha = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdAcessar = New Infragistics.Win.Misc.UltraButton
        Me.imgIcone = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblInfo = New System.Windows.Forms.Label
        Me.grdDigital = New System.Windows.Forms.GroupBox
        Me.grdNovaSenha = New System.Windows.Forms.GroupBox
        Me.txtNovaSenha = New System.Windows.Forms.TextBox
        Me.txtRedigitacao = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.AxGrFingerXCtrl1 = New AxGrFingerXLib.AxGrFingerXCtrl
        Me.grSenha.SuspendLayout()
        CType(Me.cboUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grdDigital.SuspendLayout()
        Me.grdNovaSenha.SuspendLayout()
        CType(Me.AxGrFingerXCtrl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grSenha
        '
        Me.grSenha.Controls.Add(Me.cboUsuario)
        Me.grSenha.Controls.Add(Me.txtSenha)
        Me.grSenha.Controls.Add(Me.Label2)
        Me.grSenha.Controls.Add(Me.Label1)
        Me.grSenha.Controls.Add(Me.cmdAcessar)
        Me.grSenha.Controls.Add(Me.cmdFechar)
        Me.grSenha.Location = New System.Drawing.Point(10, 8)
        Me.grSenha.Name = "grSenha"
        Me.grSenha.Size = New System.Drawing.Size(144, 176)
        Me.grSenha.TabIndex = 0
        Me.grSenha.TabStop = False
        '
        'cboUsuario
        '
        Me.cboUsuario.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
        Me.cboUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboUsuario.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.[Default]
        Me.cboUsuario.Location = New System.Drawing.Point(11, 35)
        Me.cboUsuario.Name = "cboUsuario"
        Me.cboUsuario.Size = New System.Drawing.Size(127, 22)
        Me.cboUsuario.TabIndex = 0
        '
        'txtSenha
        '
        Me.txtSenha.Location = New System.Drawing.Point(11, 76)
        Me.txtSenha.Name = "txtSenha"
        Me.txtSenha.Size = New System.Drawing.Size(127, 20)
        Me.txtSenha.TabIndex = 1
        Me.txtSenha.UseSystemPasswordChar = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(55, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Senha"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(52, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Usuário"
        '
        'cmdAcessar
        '
        Appearance2.Image = 1
        Me.cmdAcessar.Appearance = Appearance2
        Me.cmdAcessar.ImageList = Me.imgIcone
        Me.cmdAcessar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdAcessar.Location = New System.Drawing.Point(23, 120)
        Me.cmdAcessar.Name = "cmdAcessar"
        Me.cmdAcessar.Size = New System.Drawing.Size(45, 45)
        Me.cmdAcessar.TabIndex = 2
        '
        'imgIcone
        '
        Me.imgIcone.ImageStream = CType(resources.GetObject("imgIcone.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgIcone.TransparentColor = System.Drawing.Color.Transparent
        Me.imgIcone.Images.SetKeyName(0, "")
        Me.imgIcone.Images.SetKeyName(1, "")
        Me.imgIcone.Images.SetKeyName(2, "")
        '
        'cmdFechar
        '
        Appearance1.Image = 0
        Me.cmdFechar.Appearance = Appearance1
        Me.cmdFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdFechar.ImageList = Me.imgIcone
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(87, 120)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 6
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.Control
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(8, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(128, 152)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'lblInfo
        '
        Me.lblInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.ForeColor = System.Drawing.Color.Navy
        Me.lblInfo.Location = New System.Drawing.Point(8, 192)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(304, 16)
        Me.lblInfo.TabIndex = 12
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grdDigital
        '
        Me.grdDigital.Controls.Add(Me.PictureBox1)
        Me.grdDigital.Location = New System.Drawing.Point(160, 8)
        Me.grdDigital.Name = "grdDigital"
        Me.grdDigital.Size = New System.Drawing.Size(144, 176)
        Me.grdDigital.TabIndex = 13
        Me.grdDigital.TabStop = False
        '
        'grdNovaSenha
        '
        Me.grdNovaSenha.Controls.Add(Me.txtNovaSenha)
        Me.grdNovaSenha.Controls.Add(Me.txtRedigitacao)
        Me.grdNovaSenha.Controls.Add(Me.Label3)
        Me.grdNovaSenha.Controls.Add(Me.Label4)
        Me.grdNovaSenha.Controls.Add(Me.cmdGravar)
        Me.grdNovaSenha.Location = New System.Drawing.Point(310, 8)
        Me.grdNovaSenha.Name = "grdNovaSenha"
        Me.grdNovaSenha.Size = New System.Drawing.Size(144, 176)
        Me.grdNovaSenha.TabIndex = 14
        Me.grdNovaSenha.TabStop = False
        '
        'txtNovaSenha
        '
        Me.txtNovaSenha.Location = New System.Drawing.Point(12, 32)
        Me.txtNovaSenha.Name = "txtNovaSenha"
        Me.txtNovaSenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNovaSenha.Size = New System.Drawing.Size(120, 20)
        Me.txtNovaSenha.TabIndex = 3
        '
        'txtRedigitacao
        '
        Me.txtRedigitacao.Location = New System.Drawing.Point(11, 80)
        Me.txtRedigitacao.Name = "txtRedigitacao"
        Me.txtRedigitacao.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtRedigitacao.Size = New System.Drawing.Size(120, 20)
        Me.txtRedigitacao.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Redigite Nova Senha"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Nova Senha"
        '
        'cmdGravar
        '
        Appearance3.Image = 2
        Me.cmdGravar.Appearance = Appearance3
        Me.cmdGravar.ImageList = Me.imgIcone
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(48, 120)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 5
        '
        'AxGrFingerXCtrl1
        '
        Me.AxGrFingerXCtrl1.Enabled = True
        Me.AxGrFingerXCtrl1.Location = New System.Drawing.Point(320, 184)
        Me.AxGrFingerXCtrl1.Name = "AxGrFingerXCtrl1"
        Me.AxGrFingerXCtrl1.OcxState = CType(resources.GetObject("AxGrFingerXCtrl1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxGrFingerXCtrl1.Size = New System.Drawing.Size(32, 32)
        Me.AxGrFingerXCtrl1.TabIndex = 15
        '
        'frmAcesso_Senha_Finger
        '
        Me.AcceptButton = Me.cmdAcessar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(461, 213)
        Me.Controls.Add(Me.AxGrFingerXCtrl1)
        Me.Controls.Add(Me.grdNovaSenha)
        Me.Controls.Add(Me.grdDigital)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.grSenha)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAcesso_Senha_Finger"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acesso - Senha"
        Me.grSenha.ResumeLayout(False)
        Me.grSenha.PerformLayout()
        CType(Me.cboUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grdDigital.ResumeLayout(False)
        Me.grdNovaSenha.ResumeLayout(False)
        Me.grdNovaSenha.PerformLayout()
        CType(Me.AxGrFingerXCtrl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim sSenha As String
    Dim bAcessoValido As Boolean
    Dim myUtil As Util
    Dim oTipoValidacaoUsuario As TipoValidacaoUsuario

    Public Property TipoValidacaoUsuario() As Integer
        Get
            Return oTipoValidacaoUsuario
        End Get
        Set(ByVal Valor As Integer)
            oTipoValidacaoUsuario = Valor
        End Set
    End Property

    Private Sub cmdFechar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        bAcessoValido = False

        If oTipoValidacaoUsuario = Declaracao.TipoValidacaoUsuario._UsuarioLogado Then
            Close()
        Else
            End
        End If
    End Sub

    Public ReadOnly Property Acesso_Valido() As Boolean
        Get
            Return bAcessoValido
        End Get
    End Property

    Private Sub cmdAcessar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAcessar.Click
        If Not ObjUltraComboBox_LinhaSelecionada(cboUsuario) Then
            Msg_Mensagem("Informe o usuário")
            Exit Sub
        End If
        If Trim(txtSenha.Text) = "" Then
            Msg_Mensagem("Informe a senha")
            Exit Sub
        End If

        'Verifica se no momento do desbloquei o usuario é o q estava logado
        If Not VerificarUsuario(cboUsuario.SelectedRow.Cells(0).Value, oTipoValidacaoUsuario) Then Exit Sub

        sAcesso_UsuarioLogado = cboUsuario.SelectedRow.Cells(0).Value

        sAcesso_UsuarioLogado_DS = NVL(cboUsuario.SelectedRow.Cells(2).Value, "")
        sSenha = txtSenha.Text

        If Not Form_Acesso_ValidarPermissao() Then Exit Sub
        Me.Close()
    End Sub

    Private Sub frmAcesso_Senha_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Err As Integer

        UltraComboBox_Carregar_Usuario(cboUsuario, True, True)

        If Not sAcesso_UsuarioLogado = Nothing Then
            objUltraComboBox_Possicionar(cboUsuario, 0, sAcesso_UsuarioLogado)
            txtSenha.Focus()

            If oTipoValidacaoUsuario = Declaracao.TipoValidacaoUsuario._UsuarioLogado And _
               Trim(cboUsuario.SelectedRow.Cells(0).Value) <> "" Then
                cboUsuario.Enabled = False
            End If
        Else
            If Registro_Read_String("ULTIMO_USUARIO") <> "" Then
                objUltraComboBox_Possicionar(cboUsuario, 0, Registro_Read_String("ULTIMO_USUARIO"))
                txtSenha.Focus()
            End If
        End If

        'Inicializa Class Util
        myUtil = New Util(Nothing, PictureBox1, AxGrFingerXCtrl1)
        'Inicializa GrFingerX Library
        Err = myUtil.InitializeGrFinger()

        'Verifica se retornou erro, nesse caso é abilitado apenas o acesso via usuario e senha
        If Err < 0 Then
            Me.Width = 168
        Else
            Me.Width = 320
        End If
    End Sub

    Private Function Form_Acesso_ValidarPermissao() As Boolean
        Dim oData As DataTable
        Dim CD_TIPOVALIDACAOSENHA As Integer
        Dim DT_ACESSAR_OFFLINE_ATE As Date

        Dim sRetorno As String
        Dim SqlText As String

        Dim bValidarOffLine As Boolean = False

        SqlText = "SELECT CD_TIPOVALIDACAOSENHA, DT_ACESSAR_OFFLINE_ATE" & _
                  " FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO" & _
                  " WHERE TRIM(CD_USUARIO) = " & QuotedStr(sAcesso_UsuarioLogado)
        oData = DBQuery(SqlText)

        With oData.Rows(0)
            CD_TIPOVALIDACAOSENHA = NVL(.Item("CD_TIPOVALIDACAOSENHA"), cnt_TipoAcesso_DS_DirectoryService)
            DT_ACESSAR_OFFLINE_ATE = NVL(.Item("DT_ACESSAR_OFFLINE_ATE"), Now.AddDays(-1))
        End With

        objData_Finalizar(oData)

        Select Case CD_TIPOVALIDACAOSENHA
            Case -1
                bAcessoValido = False

                Msg_Mensagem("Usuário não cadastrado no sistema")
            Case cnt_TipoAcesso_DS_DirectoryService
                If DT_ACESSAR_OFFLINE_ATE >= Now.Date Then
                    bValidarOffLine = True
                Else
                    Try
                        Dim objLogin As New CargillCAISServ.CargillDSWS.CCargillDS

                        sRetorno = objLogin.autenticarUsuario(sAcesso_UsuarioLogado_DS, sSenha)

                        objLogin.Dispose()

                        Select Case UCase(sRetorno)
                            Case "OK"
                                bAcessoValido = True
                            Case "CLAVE DE DIRECTORY SERVICES INCORRECTA"
                                Msg_Mensagem("Usuário ou senha incorreta")
                                bAcessoValido = False
                            Case ""
                                bAcessoValido = ""
                            Case Else
                                Msg_Mensagem(sRetorno)
                        End Select
                    Catch ex As Exception
                        bValidarOffLine = True
                    End Try
                End If

                If bValidarOffLine Then
                    bAcessoValido = SEC_ValidarOffLine(sAcesso_UsuarioLogado, sSenha)
                End If
            Case cnt_TipoAcesso_SenhaSistema
                Select Case Pwd_VerificaAcesso(sSenha, sAcesso_UsuarioLogado)
                    Case ePwd_VerificaAcesso.eSenhaValida
                        bAcessoValido = True
                    Case ePwd_VerificaAcesso.eTrocarSenha
                        Me.Width = 320
                        Me.grdNovaSenha.Left = Me.grdDigital.Left
                        Me.grdDigital.Visible = False

                        txtSenha.Enabled = False
                        cboUsuario.Enabled = False
                        cmdAcessar.Enabled = False
                    Case ePwd_VerificaAcesso.sSenhaInvalida
                        Msg_Mensagem("Senha Inválida")
                        bAcessoValido = False
                        txtSenha.Text = ""
                    Case ePwd_VerificaAcesso.sSenhaNaoCadastrada
                        Me.Close()
                End Select
        End Select

        If Not bAcessoValido And Not oTipoValidacaoUsuario = Declaracao.TipoValidacaoUsuario._UsuarioLogado Then
            sAcesso_UsuarioLogado = Nothing
        End If

        If bAcessoValido Then
            Registro_Write_String("ULTIMO_USUARIO", sAcesso_UsuarioLogado)
        End If

        Return bAcessoValido
    End Function

    Private Sub frmAcesso_Senha_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        myUtil.FinalizeGrFinger()
    End Sub

    ' -----------------------------------------------------------------------------------
    ' GrFingerX events
    ' -----------------------------------------------------------------------------------

    'Quando um leito é plugado
    Private Sub AxGrFingerXCtrl1_SensorPlug(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_SensorPlugEvent) Handles AxGrFingerXCtrl1.SensorPlug
        AxGrFingerXCtrl1.CapStartCapture(e.idSensor)
    End Sub

    'Quando o leito é desplugado
    Private Sub AxGrFingerXCtrl1_SensorUnplug(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_SensorUnplugEvent) Handles AxGrFingerXCtrl1.SensorUnplug
        AxGrFingerXCtrl1.CapStopCapture(e.idSensor)
    End Sub

    'Adquirindo imagem do leitor
    Private Sub AxGrFingerXCtrl1_ImageAcquired(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_ImageAcquiredEvent) Handles AxGrFingerXCtrl1.ImageAcquired
        lblInfo.Text = ""
        lblInfo.Refresh()

        'copia a imagem adquiraida
        myUtil.raw.height = e.height
        myUtil.raw.width = e.width
        myUtil.raw.res = e.res
        myUtil.raw.img = e.rawImage

        'exibe a imagem adquirida
        myUtil.PrintBiometricDisplay(False, GRConstants.GR_DEFAULT_CONTEXT)

        'extrai digital
        ExtractDigital()
        'verifica digital
        VerificaDigital()
    End Sub

    Private Sub ExtractDigital()
        Dim ret As Integer

        'extrai a digital
        ret = myUtil.ExtractTemplate()
        'verifica qualidade da digital
        If ret = GRConstants.GR_BAD_QUALITY Then
            lblInfo.Text = "Digital com má qualidade, favor tentar novamente."
        ElseIf ret = GRConstants.GR_MEDIUM_QUALITY Then
            lblInfo.Text = "Digital extraida com sucesso."
        ElseIf ret = GRConstants.GR_HIGH_QUALITY Then
            lblInfo.Text = "Digital extraida com sucesso. Excelente qualidade."
        End If
        If ret >= 0 Then
            myUtil.PrintBiometricDisplay(True, GRConstants.GR_NO_CONTEXT)
        Else
            lblInfo.Text = "Erro na leitura da digital."
        End If
    End Sub

    Private Sub VerificaDigital()
        Dim ret As Integer, score As Integer
        Dim oData As DataTable

        score = 0

        'Identifica digital
        ret = myUtil.Identify(score)

        'Escreve log
        If ret > 0 Then
            oData = DBQuery("SELECT U.NO_USUARIO, U.CD_USUARIO " & _
                            " FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO_DIGITAL UD," & _
                                       sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO U " & _
                            " WHERE UD.CD_USUARIO = U.CD_USUARIO " & _
                              " AND UD.SQ_USUARIO_DIGITAL = " & ret)
            lblInfo.Text = "Bem vindo " & oData.Rows(0).Item("no_usuario")

            myUtil.PrintBiometricDisplay(True, GRConstants.GR_DEFAULT_CONTEXT)

            'verifica se no momento do desbloquei o usuario é o q estava logado
            If Not VerificarUsuario(oData.Rows(0).Item("CD_USUARIO"), oTipoValidacaoUsuario) Then Exit Sub

            sAcesso_UsuarioLogado = oData.Rows(0).Item("CD_USUARIO")
            bAcessoValido = True

            Me.Close()
        ElseIf ret = 0 Then
            lblInfo.Text = "Digital não encontrada."
        Else
            lblInfo.Text = ret
        End If
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        If Trim(txtNovaSenha.Text) = "" Then
            Msg_Mensagem("Informe a nova senha")
            Exit Sub
        End If
        If Trim(txtRedigitacao.Text) = "" Then
            Msg_Mensagem("Redigite a nova senha")
            Exit Sub
        End If
        If txtNovaSenha.Text <> txtRedigitacao.Text Then
            Msg_Mensagem("Senha redigitada não confere.")
            txtNovaSenha.Text = ""
            txtRedigitacao.Text = ""
            Exit Sub
        End If
        If Not Pwd_ValidaSenha(txtNovaSenha.Text, cboUsuario.SelectedRow.Cells(0).Value) Then
            txtNovaSenha.Text = ""
            txtRedigitacao.Text = ""
            Exit Sub
        End If

        sAcesso_UsuarioLogado = cboUsuario.SelectedRow.Cells(0).Value
        sSenha = txtNovaSenha.Text
        Pwd_InseriSenha(txtNovaSenha.Text, sAcesso_UsuarioLogado)

        Msg_Mensagem("Troca realizada com sucesso.")

        bAcessoValido = True
        Me.Close()
    End Sub
End Class