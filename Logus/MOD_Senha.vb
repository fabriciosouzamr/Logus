Module Senha
    Public Const cnt_DiasExpirar As Integer = 180

    Public Enum ePwd_VerificaAcesso
        eSenhaValida = 1
        sSenhaInvalida = 2
        eTrocarSenha = 3
        sSenhaNaoCadastrada = 4
    End Enum

    Public Function Pwd_InseriSenha(ByVal vNewPassword As String, ByVal vUsuario As String, _
                                    Optional ByVal bAlterar_TrocarSenha As Boolean = True) As Boolean
        Dim cCRP As Cripto
        Dim vIniPWD As String
        Dim vNewSenha As String

        On Error GoTo Erro

        vIniPWD = "XY"

        cCRP = New Cripto
        vNewSenha = cCRP.Cypher(CStr(vNewPassword), CDbl(cnt_DBControl_Chave), CDbl(cnt_DBControl_Bit))
        vNewSenha = vIniPWD & vNewSenha

        DBExecutar("INSERT INTO " & sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO_SENHA VALUES ('" & vUsuario & "','" & vNewSenha & "',SYSDATE)")

        If bAlterar_TrocarSenha Then
            DBExecutar("UPDATE " & sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO SET IC_TROCA_SENHA = 'N' WHERE CD_USUARIO = " & QuotedStr(vUsuario))
        End If

        Return True

Erro:
        Return False
    End Function

    Public Function Pwd_VerificaJaUsado(ByVal vNewPassword As String, ByVal vUsuario As String) As Boolean
        Dim oData As DataTable
        Dim SqlText As String
        Dim cCRP As Cripto
        Dim vIniPWD As String
        Dim vNewSenha As String

        vIniPWD = "XY"

        cCRP = New Cripto
        vNewSenha = cCRP.Cypher(CStr(vNewPassword), CDbl(cnt_DBControl_Chave), CDbl(cnt_DBControl_Bit))
        vNewSenha = vIniPWD & vNewSenha

        SqlText = "SELECT * " & _
                  " FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO_SENHA S " & _
                  " WHERE S.CD_USUARIO =" & QuotedStr(vUsuario) & _
                    " AND S.DS_SENHA =" & QuotedStr(vNewSenha)
        oData = DBQuery(SqlText)

        Return (Not objDataTable_Vazio(oData))
    End Function

    Public Function Pwd_VerificaAcesso(ByVal vPassword As String, ByVal vUsuario As String) As ePwd_VerificaAcesso
        Dim oData As DataTable
        Dim SqlText As String
        Dim cCRP As Cripto
        Dim vIniPWD As String
        Dim vNewSenha As String
        Dim DtSenha As Date

        vIniPWD = "XY"

        cCRP = New Cripto
        vNewSenha = cCRP.Cypher(CStr(vPassword), CDbl(cnt_DBControl_Chave), CDbl(cnt_DBControl_Bit))
        vNewSenha = vIniPWD & vNewSenha

        SqlText = "SELECT SU.DS_SENHA, SU.DT_CRIACAO, US.IC_TROCA_SENHA" & _
                  " FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO_SENHA SU" & _
                  "  INNER JOIN " & sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO US ON US.CD_USUARIO = SU.CD_USUARIO " & _
                  " WHERE (SU.DT_CRIACAO, SU.CD_USUARIO) IN (SELECT MAX (S.DT_CRIACAO) AS DT_SENHA, " & _
                                                                  " S.CD_USUARIO " & _
                                                            " FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO_SENHA S " & _
                                                            " WHERE S.CD_USUARIO = " & QuotedStr(vUsuario) & _
                                                            " GROUP BY S.CD_USUARIO) "
        oData = DBQuery(SqlText)

        If objDataTable_Vazio(oData) Then
            Msg_Mensagem("Usuário não cadastrado, favor entrar em contato com o administrador.")
            Return ePwd_VerificaAcesso.sSenhaNaoCadastrada
        End If

        DtSenha = oData.Rows(0).Item("DT_CRIACAO")

        If DateDiff(DateInterval.Day, DtSenha, Today) >= (cnt_DiasExpirar - 7) And DateDiff(DateInterval.Day, DtSenha, Today) <= cnt_DiasExpirar And oData.Rows(0).Item("DS_SENHA") = vNewSenha Then
            If Msg_Perguntar("Falta " & cnt_DiasExpirar - DateDiff(DateInterval.Day, DtSenha, Today) & " dias para expirar sua senha. Deseja alterar agora?") Then
                Return ePwd_VerificaAcesso.eTrocarSenha
            Else
                Return ePwd_VerificaAcesso.eSenhaValida
            End If
        Else
            If oData.Rows(0).Item("DS_SENHA") <> vNewSenha Then
                Return ePwd_VerificaAcesso.sSenhaInvalida
            ElseIf DateDiff(DateInterval.Day, DtSenha, Today) > cnt_DiasExpirar And oData.Rows(0).Item("DS_SENHA") = vNewSenha Then
                Msg_Mensagem("Sua senha deve ser trocada.")
                Return ePwd_VerificaAcesso.eTrocarSenha
            ElseIf objDataTable_LerCampo(oData.Rows(0).Item("IC_TROCA_SENHA"), "N") = "S" Then
                Return ePwd_VerificaAcesso.eTrocarSenha
            ElseIf oData.Rows(0).Item("DS_SENHA") = vNewSenha Then
                Return ePwd_VerificaAcesso.eSenhaValida
            Else
                Msg_Mensagem("Senha invalida.")
                Return ePwd_VerificaAcesso.sSenhaInvalida
            End If
        End If
    End Function

    Public Function Pwd_ValidaSenha(ByVal vPassword As String, ByVal vUsuario As String) As Boolean
        Dim icont As Integer
        Dim iChar As Integer
        Dim iNumer As Integer

        If Pwd_VerificaJaUsado(vPassword, vUsuario) Then
            Msg_Mensagem("Senha já utilizada.")
            Return False
        End If

        If Len(vPassword) < 6 Then
            Msg_Mensagem("A senha deve começar com letras.")
            Return False
        End If

        If IsNumeric(Left(vPassword, 1)) Then
            Msg_Mensagem("A senha deve começar com letras.")
            Return False
        End If
        For icont = 1 To Len(vPassword)
            If IsNumeric(Mid(vPassword, icont, 1)) Then
                iNumer = iNumer + 1
            Else
                iChar = iChar + 1
            End If
        Next
        If iChar < 2 Then
            Msg_Mensagem("A senha teve ter pelo menos 2 letras.")
            Return False
        End If
        If iNumer < 2 Then
            Msg_Mensagem("A senha teve ter pelo menos 2 números.")
            Return False
        End If
        Return True
    End Function
End Module
