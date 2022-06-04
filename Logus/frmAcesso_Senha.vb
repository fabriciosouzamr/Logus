Public Class frmAcesso_Senha
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
    Friend WithEvents cmdAcessar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdFechar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents imgIcone As System.Windows.Forms.ImageList
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdGravar As Infragistics.Win.Misc.UltraButton
    Private WithEvents grSenha As System.Windows.Forms.GroupBox
    Friend WithEvents grdNovaSenha As System.Windows.Forms.GroupBox
    Friend WithEvents txtRedigitacao As System.Windows.Forms.TextBox
    Friend WithEvents cboUsuario As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents txtSenha As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblR_Aviso As System.Windows.Forms.Label
    Friend WithEvents txtNovaSenha As System.Windows.Forms.TextBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAcesso_Senha))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.grSenha = New System.Windows.Forms.GroupBox
        Me.lblR_Aviso = New System.Windows.Forms.Label
        Me.cboUsuario = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.txtSenha = New System.Windows.Forms.TextBox
        Me.cmdAcessar = New Infragistics.Win.Misc.UltraButton
        Me.imgIcone = New System.Windows.Forms.ImageList(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdFechar = New Infragistics.Win.Misc.UltraButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.grdNovaSenha = New System.Windows.Forms.GroupBox
        Me.txtNovaSenha = New System.Windows.Forms.TextBox
        Me.txtRedigitacao = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdGravar = New Infragistics.Win.Misc.UltraButton
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.grSenha.SuspendLayout()
        CType(Me.cboUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grdNovaSenha.SuspendLayout()
        Me.SuspendLayout()
        '
        'grSenha
        '
        Me.grSenha.Controls.Add(Me.lblR_Aviso)
        Me.grSenha.Controls.Add(Me.cboUsuario)
        Me.grSenha.Controls.Add(Me.txtSenha)
        Me.grSenha.Controls.Add(Me.cmdAcessar)
        Me.grSenha.Controls.Add(Me.Label2)
        Me.grSenha.Controls.Add(Me.cmdFechar)
        Me.grSenha.Controls.Add(Me.Label1)
        Me.grSenha.Location = New System.Drawing.Point(2, -3)
        Me.grSenha.Name = "grSenha"
        Me.grSenha.Size = New System.Drawing.Size(198, 176)
        Me.grSenha.TabIndex = 0
        Me.grSenha.TabStop = False
        '
        'lblR_Aviso
        '
        Me.lblR_Aviso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblR_Aviso.ForeColor = System.Drawing.Color.Red
        Me.lblR_Aviso.Location = New System.Drawing.Point(2, 156)
        Me.lblR_Aviso.Name = "lblR_Aviso"
        Me.lblR_Aviso.Size = New System.Drawing.Size(190, 17)
        Me.lblR_Aviso.TabIndex = 7
        Me.lblR_Aviso.Text = "Caps Lock Ativado"
        Me.lblR_Aviso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblR_Aviso.Visible = False
        '
        'cboUsuario
        '
        Me.cboUsuario.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cboUsuario.CheckedListSettings.CheckStateMember = ""
        Me.cboUsuario.Location = New System.Drawing.Point(10, 35)
        Me.cboUsuario.Name = "cboUsuario"
        Me.cboUsuario.Size = New System.Drawing.Size(178, 22)
        Me.cboUsuario.TabIndex = 0
        '
        'txtSenha
        '
        Me.txtSenha.Location = New System.Drawing.Point(10, 76)
        Me.txtSenha.Name = "txtSenha"
        Me.txtSenha.Size = New System.Drawing.Size(178, 20)
        Me.txtSenha.TabIndex = 2
        Me.txtSenha.UseSystemPasswordChar = True
        '
        'cmdAcessar
        '
        Appearance4.Image = 1
        Me.cmdAcessar.Appearance = Appearance4
        Me.cmdAcessar.ImageList = Me.imgIcone
        Me.cmdAcessar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdAcessar.Location = New System.Drawing.Point(50, 102)
        Me.cmdAcessar.Name = "cmdAcessar"
        Me.cmdAcessar.Size = New System.Drawing.Size(45, 45)
        Me.cmdAcessar.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.cmdAcessar, "Acessar o Sistema")
        '
        'imgIcone
        '
        Me.imgIcone.ImageStream = CType(resources.GetObject("imgIcone.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgIcone.TransparentColor = System.Drawing.Color.Transparent
        Me.imgIcone.Images.SetKeyName(0, "")
        Me.imgIcone.Images.SetKeyName(1, "")
        Me.imgIcone.Images.SetKeyName(2, "")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(78, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Senha"
        '
        'cmdFechar
        '
        Appearance1.Image = 0
        Me.cmdFechar.Appearance = Appearance1
        Me.cmdFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdFechar.ImageList = Me.imgIcone
        Me.cmdFechar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdFechar.Location = New System.Drawing.Point(111, 102)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(45, 45)
        Me.cmdFechar.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.cmdFechar, "Sair do Sistema")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(75, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Usuário"
        '
        'grdNovaSenha
        '
        Me.grdNovaSenha.Controls.Add(Me.txtNovaSenha)
        Me.grdNovaSenha.Controls.Add(Me.txtRedigitacao)
        Me.grdNovaSenha.Controls.Add(Me.Label3)
        Me.grdNovaSenha.Controls.Add(Me.Label4)
        Me.grdNovaSenha.Controls.Add(Me.cmdGravar)
        Me.grdNovaSenha.Location = New System.Drawing.Point(206, -3)
        Me.grdNovaSenha.Name = "grdNovaSenha"
        Me.grdNovaSenha.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.grdNovaSenha.Size = New System.Drawing.Size(198, 176)
        Me.grdNovaSenha.TabIndex = 14
        Me.grdNovaSenha.TabStop = False
        '
        'txtNovaSenha
        '
        Me.txtNovaSenha.Location = New System.Drawing.Point(24, 32)
        Me.txtNovaSenha.Name = "txtNovaSenha"
        Me.txtNovaSenha.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNovaSenha.Size = New System.Drawing.Size(155, 20)
        Me.txtNovaSenha.TabIndex = 3
        Me.txtNovaSenha.UseSystemPasswordChar = True
        '
        'txtRedigitacao
        '
        Me.txtRedigitacao.Location = New System.Drawing.Point(24, 76)
        Me.txtRedigitacao.Name = "txtRedigitacao"
        Me.txtRedigitacao.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRedigitacao.Size = New System.Drawing.Size(155, 20)
        Me.txtRedigitacao.TabIndex = 4
        Me.txtRedigitacao.UseSystemPasswordChar = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(46, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Redigite Nova Senha"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(67, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Nova Senha"
        '
        'cmdGravar
        '
        Appearance2.Image = 2
        Me.cmdGravar.Appearance = Appearance2
        Me.cmdGravar.ImageList = Me.imgIcone
        Me.cmdGravar.ImageSize = New System.Drawing.Size(32, 32)
        Me.cmdGravar.Location = New System.Drawing.Point(77, 102)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(45, 45)
        Me.cmdGravar.TabIndex = 5
        '
        'frmAcesso_Senha
        '
        Me.AcceptButton = Me.cmdAcessar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(202, 175)
        Me.Controls.Add(Me.grdNovaSenha)
        Me.Controls.Add(Me.grSenha)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAcesso_Senha"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acesso - Senha"
        Me.grSenha.ResumeLayout(False)
        Me.grSenha.PerformLayout()
        CType(Me.cboUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grdNovaSenha.ResumeLayout(False)
        Me.grdNovaSenha.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim sSenha As String
    Dim bAcessoValido As Boolean
    Dim ControleEdicaoTelaLocal As eControleEdicaoTela

    Dim oTipoValidacaoUsuario As TipoValidacaoUsuario
    Dim iTentativa As Integer

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

        If oTipoValidacaoUsuario = Declaracao.TipoValidacaoUsuario._UsuarioLogado Or _
           ControleEdicaoTelaLocal = eControleEdicaoTela.ALTERAR_SENHA Then
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

    Private Sub frmAcesso_Senha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        CapsLockAtivo()
    End Sub

    Private Sub frmAcesso_Senha_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CapsLockAtivo()

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

        ControleEdicaoTelaLocal = ControleEdicaoTela

        If ControleEdicaoTelaLocal = eControleEdicaoTela.ALTERAR_SENHA Then
            Me.Width = 414
            'txtSenha.Enabled = False
            cboUsuario.Enabled = False
            cmdAcessar.Visible = False
            cmdFechar.Left = 60
            Me.Text = "Alteração de Senha"
        End If

        Me.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub CapsLockAtivo()
        'Dim CapsLockOn As New KeyBoardState(CType(Keys.CapsLock, Integer))

        'If CapsLockOn.KeyState = True Then
        '    lblR_Aviso.Visible = True
        'Else
        lblR_Aviso.Visible = False
        'End If
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
                                iTentativa = 0
                            Case "CLAVE DE DIRECTORY SERVICES INCORRECTA"
                                iTentativa = iTentativa + 1

                                If iTentativa >= 3 Then
                                    Msg_Mensagem("Usuário ou senha incorreta. Favor contactar o ServiceDesk e verificar o status de seu usuário no DS.")
                                Else
                                    Msg_Mensagem("Usuário ou senha incorreta")
                                End If

                                bAcessoValido = False
                            Case ""
                                bAcessoValido = False
                            Case Else
                                Msg_Mensagem(sRetorno)
                        End Select
                    Catch ex As Exception
                        bValidarOffLine = True
                    End Try
                End If

                'Faz validação via off-line
                If bValidarOffLine Then
                    bAcessoValido = SEC_ValidarOffLine(sAcesso_UsuarioLogado, sSenha)
                End If
            Case cnt_TipoAcesso_SenhaSistema
                Select Case Pwd_VerificaAcesso(sSenha, sAcesso_UsuarioLogado)
                    Case ePwd_VerificaAcesso.eSenhaValida
                        bAcessoValido = True
                    Case ePwd_VerificaAcesso.eTrocarSenha
                        Me.Width = 414
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

        If bAcessoValido Then
            Try
                Dim oDBControlX As New DBControlX.DBControlX

                oDBControlX.GS_IncluirUsuarioSistema(cnt_DBControl_Sistema, _
                                                     sAcesso_UsuarioLogado, _
                                                     sSenha, _
                                                     cnt_DBControl_Chave, _
                                                     cnt_DBControl_Bit)

                Registro_Write_String("ULTIMO_USUARIO", sAcesso_UsuarioLogado)
            Catch ex As Exception
            End Try
        End If

        Return bAcessoValido
    End Function

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

    Private Sub txtSenha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSenha.KeyDown
        CapsLockAtivo()
    End Sub
End Class