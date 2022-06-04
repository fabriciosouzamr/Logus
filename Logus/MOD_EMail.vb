Imports System
Imports System.Net.Mail
Imports VB = Microsoft.VisualBasic

Module EMail
    Enum eTipoServico
        ServicoEMail = 1
    End Enum

    Enum ePrioridade
        Baixa = 1
        Media = 2
        Alta = 3
    End Enum

    Public Const cnt_EMail_Servidor_SMTP As String = "mailrelayapp.la.corp.cargill.com" '"10.2.133.50"
    Const cnt_EMail_TecnicoErroDB As String = "Fabricio_Moreira@cargill.com"

    Public EMail_TipoServico As eTipoServico
    Public sEMail_SuporteTecnico As String = ""

    Dim sEMail_To As String

    '>>
    '>> ENVIO ATRAVÉS DO SISTEMA DE ENVIO DE E-MAIL - INÍCIO
    '>>
    Public Function EnvioEmail(ByVal sAssunto As String, _
                               ByVal sMensagem As String, _
                               ByVal sUsuario() As String, _
                               ByVal sEmail() As String, _
                               Optional ByVal sProcesso As String = cnt_EmailProcesso_Padrao, _
                               Optional ByVal DataEnviar As Date = Nothing, _
                               Optional ByVal CodigoMensagem As String = Nothing, _
                               Optional ByVal NumeroVezesRecursividade As Integer = 0, _
                               Optional ByVal Prioridade As ePrioridade = ePrioridade.Media, _
                               Optional ByVal TextoFormatado As Boolean = False) As Boolean
        Dim oData As DataTable
        Dim SQ_EMAIL_MENSAGEM As Integer
        Dim SqlText As String
        Dim bOk As Boolean = True
        Dim iCont As Integer
        Dim bEnviarDiretamente As Boolean = True
        Dim CD_USER_SOLICITA_CADASTRO_MENSAGEM As String = ""
        Dim DS_EMAIL_DESTINARIO As String = ""
        Dim sUsuarioRemetente As String = ""

        If Trim(CodigoMensagem) <> "" Then
            bEnviarDiretamente = False
        End If

        If TextoFormatado Then
            sMensagem = Replace(sMensagem, "&edsp;", "")
        End If

        SqlText = "SELECT * FROM " & sBancoDados_OwnerSistemaEMail & ".EMAIL_PROCESSO" & _
                  " WHERE CD_PROCESSO = " & QuotedStr(sProcesso)
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            If objDataTable_LerCampo(oData.Rows(0).Item("IC_USAR_NOMEPROCESSO_REMETENTE"), "N") = "S" Then
                sUsuarioRemetente = oData.Rows(0).Item("NO_PROCESSO") & " <" & sUsuario_EMail & ">"
            Else
                sUsuarioRemetente = cnt_EMail_From_Proc & " <" & sUsuario_EMail & ">"
            End If

            bEnviarDiretamente = (oData.Rows(0).Item("IC_TIPO_HORARIO") = cnt_TipoHorario_IntervaloMinuto)
        End If

        objData_Finalizar(oData)

        If bEnviarDiretamente Then
            Try
                EMail_Proc_ListarDestinatario(0, sProcesso, DS_EMAIL_DESTINARIO, CD_USER_SOLICITA_CADASTRO_MENSAGEM)
                bEnviarDiretamente = (Trim(CD_USER_SOLICITA_CADASTRO_MENSAGEM) = "")

                If Array_Preenchido(sUsuario) And bEnviarDiretamente Then
                    SqlText = "SELECT COUNT(*) FROM " & sBancoDados_OwnerSistemaEMail & ".SEC_USUARIO" & _
                              " WHERE CD_USUARIO IN (" & Array_Para_Lista(sUsuario, ",", True) & ")" & _
                                " AND IC_ATIVO IN (" & QuotedStr(cnt_Usuario_Status_Ativo) & ", " & QuotedStr(cnt_Usuario_Status_EliminadoSO) & ")" & _
                                " AND DS_EMAIL IS NULL"
                    bEnviarDiretamente = (DBQuery_ValorUnico(SqlText) = 0)
                End If

                If bEnviarDiretamente Then
                    If Array_Preenchido(sUsuario) Then
                        SqlText = "SELECT DS_EMAIL FROM " & sBancoDados_OwnerSistemaEMail & ".SEC_USUARIO" & _
                                  " WHERE CD_USUARIO IN (" & Array_Para_Lista(sUsuario, ",", True) & ")" & _
                                    " AND IC_ATIVO IN (" & QuotedStr(cnt_Usuario_Status_Ativo) & ", " & QuotedStr(cnt_Usuario_Status_EliminadoSO) & ")" & _
                                    " AND DS_EMAIL IS NOT NULL"
                        Str_Adicionar(DS_EMAIL_DESTINARIO, DBQuery_ValorUnico_Lista(SqlText, ";"), ";")
                    End If

                    Str_Adicionar(DS_EMAIL_DESTINARIO, Array_Para_Lista(sEmail, ";"), ";")

                    bEnviarDiretamente = EMail_Enviar_Local(sUsuarioRemetente, DS_EMAIL_DESTINARIO, sAssunto, sMensagem, , sProcesso, True)
                End If
            Catch ex As Exception
                bEnviarDiretamente = False
            End Try
        End If

        'Como o e-mail não será enviado diretamento o mesmo será enviado usando o serviço de e-mail
        If Not bEnviarDiretamente Then
            SqlText = DBMontar_SP(sBancoDados_OwnerSistemaEMail & ".SP_EMAIL_MENSAGEM", False, ":CD_PROCESSO", _
                                                                                               ":CD_USUARIO_CRIACAO", _
                                                                                               ":DS_TITULO", _
                                                                                               ":CM_MENSAGEM", _
                                                                                               ":DT_ENVIAR", _
                                                                                               ":IC_EXCLUIR_APOS_ENVIO", _
                                                                                               ":SQ_EMAIL_MENSAGEM", _
                                                                                               ":IC_HTML", _
                                                                                               ":CM_MENSAGEM_02", _
                                                                                               ":NR_MINUTO_REENVIO", _
                                                                                               ":NR_VEZES_REENVIO", _
                                                                                               ":CD_MENSAGEM", _
                                                                                               ":IC_PRIORIDADE", _
                                                                                               ":CM_MENSAGEM_FORMATADO")

            If Not DBExecutar(SqlText, DBParametro_Montar("CD_PROCESSO", sProcesso), _
                                       DBParametro_Montar("CD_USUARIO_CRIACAO", sAcesso_UsuarioLogado), _
                                       DBParametro_Montar("DS_TITULO", sAssunto), _
                                       DBParametro_Montar("CM_MENSAGEM", IIf(TextoFormatado, Nothing, Left(sMensagem, 4000)), , , 4000), _
                                       DBParametro_Montar("DT_ENVIAR", NVL(DataEnviar, Now), OracleClient.OracleType.DateTime), _
                                       DBParametro_Montar("IC_EXCLUIR_APOS_ENVIO", "N"), _
                                       DBParametro_Montar("SQ_EMAIL_MENSAGEM", Nothing, , ParameterDirection.Output), _
                                       DBParametro_Montar("IC_HTML", "S"), _
                                       DBParametro_Montar("CM_MENSAGEM_02", IIf(TextoFormatado, Nothing, IIf(Len(sMensagem) > 4000, _
                                                                                                             Mid(sMensagem, 4001), Nothing)), , , 4000), _
                                       DBParametro_Montar("NR_MINUTO_REENVIO", IIf(NumeroVezesRecursividade <> 0, 24 * 60, Nothing)), _
                                       DBParametro_Montar("NR_VEZES_REENVIO", NULLIf(NumeroVezesRecursividade, 0)), _
                                       DBParametro_Montar("CD_MENSAGEM", CodigoMensagem), _
                                       DBParametro_Montar("IC_PRIORIDADE", IIf(Prioridade = ePrioridade.Baixa, "B", _
                                                                               IIf(Prioridade = ePrioridade.Alta, "A", "M"))), _
                                       DBParametro_Montar("CM_MENSAGEM_FORMATADO", IIf(TextoFormatado, sMensagem, Nothing), , , -1)) Then GoTo Erro

            If DBTeveRetorno() Then
                SQ_EMAIL_MENSAGEM = DBRetorno(1)
            End If

            SqlText = DBMontar_SP(sBancoDados_OwnerSistemaEMail & ".SP_EMAIL_MENSAGEM_DESTINARIO", False, ":SQ_EMAIL_MENSAGEM", ":CD_USUARIO", ":DS_EMAIL")

            'Carregar os e-mails
            If Not sEmail Is Nothing Then
                Array_Distinto(sEmail)

                For iCont = sEmail.GetLowerBound(0) To sEmail.GetUpperBound(0)
                    If Trim(NVL(sEmail(iCont), "")) <> "" Then
                        If Not DBExecutar(SqlText, DBParametro_Montar("SQ_EMAIL_MENSAGEM", SQ_EMAIL_MENSAGEM), _
                                                   DBParametro_Montar("CD_USUARIO", Nothing), _
                                                   DBParametro_Montar("DS_EMAIL", sEmail(iCont), , , 2000)) Then GoTo Erro
                    End If
                Next
            End If

            'Carregar os usuários
            If Not sUsuario Is Nothing Then
                Array_Distinto(sUsuario)

                For iCont = sUsuario.GetLowerBound(0) To sUsuario.GetUpperBound(0)
                    If Trim(NVL(sUsuario(iCont), "")) <> "" Then
                        If Not DBExecutar(SqlText, DBParametro_Montar("SQ_EMAIL_MENSAGEM", SQ_EMAIL_MENSAGEM), _
                                                   DBParametro_Montar("CD_USUARIO", sUsuario(iCont)), _
                                                   DBParametro_Montar("DS_EMAIL", Nothing)) Then GoTo Erro
                    End If
                Next
            End If
        End If

        GoTo Sair

Erro:
        bOk = False

Sair:
        Return bOk
    End Function

    Public Sub EnvioEmail_AtualizarMensagem(ByVal SQ_EMAIL_MENSAGEM As Integer, _
                                            ByVal CD_MENSAGEM As String, _
                                            Optional ByVal DT_ENVIADA As String = "", _
                                            Optional ByVal DT_ENVIAR As String = "")
        Dim SqlText As String
        Dim oParametro(3) As DBParamentro

        SqlText = DBMontar_SP(sBancoDados_OwnerSistemaEMail & ".SP_EMAIL_MENSAGEM_UPD", False, ":SQ_EMAIL_MENSAGEM", ":CD_MENSAGEM", ":DT_ENVIAR", ":DT_ENVIADA")

        oParametro(0) = DBParametro_Montar("SQ_EMAIL_MENSAGEM", NULLIf(SQ_EMAIL_MENSAGEM, 0))
        oParametro(1) = DBParametro_Montar("CD_MENSAGEM", NULLIf(Trim(CD_MENSAGEM), ""))
        If IsDate(DT_ENVIAR) Then
            oParametro(2) = DBParametro_Montar("DT_ENVIAR", Date_TratarBancoDados(DT_ENVIAR), OracleClient.OracleType.DateTime)
        Else
            oParametro(2) = DBParametro_Montar("DT_ENVIAR", Nothing)
        End If
        If IsDate(DT_ENVIADA) Then
            oParametro(3) = DBParametro_Montar("DT_ENVIADA", Date_TratarBancoDados(DT_ENVIADA), OracleClient.OracleType.DateTime)
        Else
            oParametro(3) = DBParametro_Montar("DT_ENVIADA", Nothing)
        End If

        DBExecutar(SqlText, oParametro)
    End Sub

    Public Sub EnvioEmail_ExcluirMensagem(ByVal SQ_EMAIL_MENSAGEM As Integer, _
                                          ByVal CD_MENSAGEM As String)
        Dim SqlText As String

        SqlText = DBMontar_SP(sBancoDados_OwnerSistemaEMail & ".SP_EMAIL_MENSAGEM_DEL", False, ":SQ_EMAIL_MENSAGEM", _
                                                                                               ":CD_MENSAGEM")

        DBExecutar(SqlText, DBParametro_Montar("SQ_EMAIL_MENSAGEM", NULLIf(SQ_EMAIL_MENSAGEM, 0)), _
                            DBParametro_Montar("CD_MENSAGEM", NULLIf(Trim(CD_MENSAGEM), "")))
    End Sub

    '>>
    '>> ENVIO DIRETAMENTE PARA O SERVIDOR DE E-MAIL - INÍCIO
    '>>
    Private Function EMail_Mensagem_Tratar(ByVal strMensagem As String) As String
        Dim iCont_01 As Integer = 0
        Dim iCont_02 As Integer = 0
        Dim sMensagem As String = ""

        For iCont_01 = 1 To Len(strMensagem)
            iCont_02 = iCont_02 + 1

            If Asc(Mid(strMensagem, iCont_01, 1)) = 10 Then
                iCont_02 = 0
            End If

            If Mid(strMensagem, iCont_01, 1) = " " And iCont_02 >= 80 Then
                sMensagem = sMensagem & vbCrLf
                iCont_02 = 0
            End If

            sMensagem = sMensagem & Mid(strMensagem, iCont_01, 1)
        Next

        Return sMensagem
    End Function

    Private Function EMail_MontarHTML_Linha(ByVal Coluna_01_Texto As String, _
                                            ByVal Coluna_02_Texto As String, _
                                            Optional ByVal Coluna_02_Memo As Boolean = False, _
                                            Optional ByVal Coluna_01_Negrito As Boolean = False, _
                                            Optional ByVal Coluna_02_Negrito As Boolean = False, _
                                            Optional ByVal Coluna_02_Link As Boolean = False, _
                                            Optional ByVal Coluna_02_Link_Texto As String = "") As cEmail_HTML_Linha
        Dim oLinha As New cEmail_HTML_Linha

        With oLinha
            .Coluna_01_Texto = Coluna_01_Texto
            .Coluna_01_Negrito = Coluna_01_Negrito
            .Coluna_02_Texto = Coluna_02_Texto
            .Coluna_02_Memo = Coluna_02_Memo
            .Coluna_02_Negrito = Coluna_02_Negrito
            .Coluna_02_Link = Coluna_02_Link
            .Coluna_02_Link_Texto = Coluna_02_Link_Texto
        End With

        Return oLinha
    End Function

    Private Function EMail_TratarPara(ByVal sEMail As String, ByRef sTo_Filtro As String) As Collection
        Dim oAux As New Collection

        sTo_Filtro = ""

        sEMail = Trim(sEMail)

        Do While InStr(sEMail, ";") > 0
            If InStr(UCase(Left(sEMail, InStr(sEMail, ";") - 1)), "@CARGILL.COM") > 0 Or _
               InStr(UCase(Left(sEMail, InStr(sEMail, ";") - 1)), "@CRGL-THIRDPARTY.COM") > 0 Or _
               InStr(UCase(Left(sEMail, InStr(sEMail, ";") - 1)), "@AGXKR-THIRDPARTY.COM") > 0 Or _
               InStr(UCase(Left(sEMail, InStr(sEMail, ";") - 1)), "@EXCH.CARGILL.COM") > 0 Then
                oAux.Add(Left(sEMail, InStr(sEMail, ";") - 1))
            Else
                Str_Adicionar(sTo_Filtro, Left(sEMail, InStr(sEMail, ";") - 1), vbCrLf)
            End If

            sEMail = Trim(Mid(sEMail, InStr(sEMail, ";") + 1))
        Loop

        If InStr(UCase(sEMail), "@CARGILL.COM") > 0 Or _
           InStr(UCase(sEMail), "@CRGL-THIRDPARTY.COM") Or _
            InStr(UCase(sEMail), "@AGXKR-THIRDPARTY.COM") Or _
           InStr(UCase(sEMail), "@EXCH.CARGILL.COM") > 0 Then
            oAux.Add(sEMail)
        Else
            Str_Adicionar(sTo_Filtro, sEMail, vbCrLf)
        End If

        Return oAux
    End Function

    Private Function EMail_MontarHTML(ByVal sTitulo As String, _
                                      ByVal sProcesso As String, _
                                      ByVal Linha() As cEmail_HTML_Linha) As String
        Dim sTexto As String = ""
        Dim iCont As Integer
        Dim Style_Font As String = "font-size: 10pt; font-family: Arial, Verdana, Courier New, Helvetica, sans-serif"
        Dim Style_Td As String = "" 'Style_Font & "; color: #c0c0c0"
        Dim Style_Td_Top_Left As String = Style_Font & ";" & Style_Td & ";" & "border-top: solid 1px; border-left: solid 1px; border-bottom: solid 1px; text-align=left; background-color=#f0f0f0"
        Dim Style_Td_Top_Right As String = Style_Font & ";" & Style_Td & ";" & "border-top: solid 1px; border-right: solid 1px; border-bottom: solid 1px; text-align=center; color=#008a00; background-color=#f0f0f0; font-weight: bold"
        Dim Style_Td_Row_Left As String = Style_Font & ";" & Style_Td & ";" & "border: solid 1px; text-align=left; background-color=#f0f0f0; vertical-align: top"
        Dim Style_Td_Row_Right As String = Style_Font & ";" & Style_Td & ";" & "border-right: solid 1px; text-align=justify"
        Dim Style_Td_Row_Right_Bottom As String = Style_Font & ";" & Style_Td & ";" & "border-right: solid 1px; border-bottom: solid 1px; text-align=justify"
        Dim Style_Td_Row As String = Style_Font & ";" & Style_Td & ";" & "border-left: solid 1px; border-right: solid 1px; text-align=justify"
        Dim Style_Td_Row_Bottom As String = Style_Font & ";" & Style_Td & ";" & "border-left: solid 1px; border-right: solid 1px; border-bottom: solid 1px; text-align=justify"

        sTexto = "<html>" & vbCrLf & _
                 "<head>" & vbCrLf & _
                 "<title></title>" & vbCrLf & _
                 "  <style type=text/css>" & vbCrLf & _
                 "      * {font-size: 10pt; font-family: Arial, Verdana, Courier New, Helvetica, sans-serif}" & vbCrLf & _
                 "      a {text-decoration:none}" & vbCrLf & _
                 "      a:hover {color: #ff0000; border-bottom: solid 1px #ff0000; font-weight:bold}" & vbCrLf & _
                 "      td {#c0c0c0}" & vbCrLf & _
                 "      .td_top_left {border-top: solid 1px; border-left: solid 1px; border-bottom: solid 1px; text-align=left; background-color=#f0f0f0;}" & vbCrLf & _
                 "      .td_top_right {border-top: solid 1px; border-right: solid 1px; border-bottom: solid 1px; text-align=center; color=#008a00; background-color=#f0f0f0; font-weight: bold}" & vbCrLf & _
                 "      .td_row_left {border: solid 1px; text-align=left; background-color=#f0f0f0; vertical-align: top;}" & vbCrLf & _
                 "      .td_row_right {border-right: solid 1px; text-align=justify}" & vbCrLf & _
                 "      .td_row_right_bottom {border-right: solid 1px; border-bottom: solid 1px; text-align=justify}" & vbCrLf & _
                 "      .td_row {border-left: solid 1px; border-right: solid 1px; text-align=justify}" & vbCrLf & _
                 "      .td_row_bottom {border-left: solid 1px; border-right: solid 1px; border-bottom: solid 1px; text-align=justify}" & vbCrLf & _
                 "      .value {font-weight:bold}" & vbCrLf & _
                 "  </style>" & vbCrLf & _
                 "</head>" & vbCrLf & _
                 "<body topmargin=15 leftmargin=4>" & vbCrLf & _
                 "<table cellpadding=4 cellspacing=0 align='center'>" & vbCrLf & _
                 "  <tr>" & vbCrLf & _
                 "      <td class=td_top_left lign=center width=10><img src='cid:logoCargill'></td>" & vbCrLf & _
                 "      <td class=td_top_right align=center>" & sTitulo & "</td>" & vbCrLf & _
                 "  </tr>" & vbCrLf

        For iCont = Linha.GetLowerBound(0) To Linha.GetUpperBound(0)
            With Linha(iCont)
                If sProcesso = "LMC" Then
                    sTexto = sTexto & _
                             "  <tr>" & vbCrLf & _
                             "      <td style='" & IIf(iCont = Linha.GetUpperBound(0), Style_Td_Row_Bottom, Style_Td_Row) & _
                                                        IIf(.Coluna_02_Negrito, "; font-weight: bold", "") & "' colspan=2>" & IIf(.Coluna_02_Memo, "<pre>", "") _
                                                      & IIf(.Coluna_02_Link, "<a href='mailto:" & .Coluna_02_Texto & "'>", "") & IIf(Trim(.Coluna_02_Link_Texto) = "", _
                                                                                                                                          .Coluna_02_Texto, _
                                                                                                                                          .Coluna_02_Link_Texto) _
                                                            & IIf(.Coluna_02_Link, "</a>", "") & IIf(.Coluna_02_Memo, "</pre>", "") & "</td>" & vbCrLf & _
                             "  </tr>" & vbCrLf
                Else
                    sTexto = sTexto & _
                             "  <tr>" & vbCrLf & _
                             "      <td style='" & Style_Td_Row_Left & IIf(.Coluna_01_Negrito, "; font-weight: bold", "") & "'>" _
                                                               & .Coluna_01_Texto & "</td>" & vbCrLf & _
                             "      <td style='" & IIf(iCont = Linha.GetUpperBound(0), Style_Td_Row_Right_Bottom, Style_Td_Row_Right) & _
                                                              IIf(.Coluna_02_Negrito, "; font-weight: bold", "") & "'>" & IIf(.Coluna_02_Memo, "<pre>", "") _
                                                            & IIf(.Coluna_02_Link, "<a href='mailto:" & .Coluna_02_Texto & "'>", "") & IIf(Trim(.Coluna_02_Link_Texto) = "", _
                                                                                                                                                .Coluna_02_Texto, _
                                                                                                                                                .Coluna_02_Link_Texto) _
                                                            & IIf(.Coluna_02_Link, "</a>", "") & IIf(.Coluna_02_Memo, "</pre>", "") & "</td>" & vbCrLf & _
                             "  </tr>" & vbCrLf
                End If
            End With
        Next

        sTexto = sTexto & _
                 "</table>" & vbCrLf & _
                 "</body>" & vbCrLf & _
                 "</html>"
        Return sTexto
    End Function

    Private Function EMail_EMailTecnico() As String
        If Trim(sEMail_Usuario_Tecnico) = "" Then
            Return cnt_EMail_TecnicoErroDB
        Else
            Return sEMail_Usuario_Tecnico
        End If
    End Function

    Private Function EMail_Configuracao() As Boolean
        Dim SqlText As String
        Dim oData As DataTable
        Dim bOk As Boolean

        Try
            SqlText = "SELECT * FROM " & sBancoDados_OwnerSistemaEMail & ".EMAIL_CONFIGURACAO"
            oData = DBQuery(SqlText)

            If Not objDataTable_Vazio(oData) Then
                With oData.Rows(0)
                    'E-Mail de usuários responsáveis pelo cadastro de usuário
                    If Not objDataTable_CampoVazio(.Item("DS_EMAIL_USUARIO_CADASTRO_01")) Then
                        sEMail_Usuario_Cadastro = .Item("DS_EMAIL_USUARIO_CADASTRO_01")
                        sNome_Usuario_Cadastro = .Item("NO_USUARIO_CADASTRO_01")
                    End If
                    If Not objDataTable_CampoVazio(.Item("DS_EMAIL_USUARIO_CADASTRO_02")) Then
                        Str_Adicionar(sEMail_Usuario_Cadastro, .Item("DS_EMAIL_USUARIO_CADASTRO_02"), ";")
                        Str_Adicionar(sNome_Usuario_Cadastro, .Item("NO_USUARIO_CADASTRO_02"), ", ")
                    End If

                    'E-Mail de usuários responsáveis técnico
                    If Not objDataTable_CampoVazio(.Item("DS_EMAIL_USUARIO_TECNICO_01")) Then
                        sEMail_Usuario_Tecnico = .Item("DS_EMAIL_USUARIO_TECNICO_01")
                        sNome_Usuario_Tecnico = .Item("NO_USUARIO_TECNICO_01")
                    End If
                    If Not objDataTable_CampoVazio(.Item("DS_EMAIL_USUARIO_TECNICO_02")) Then
                        Str_Adicionar(sEMail_Usuario_Tecnico, .Item("DS_EMAIL_USUARIO_TECNICO_02"), ";")
                        Str_Adicionar(sNome_Usuario_Tecnico, .Item("NO_USUARIO_TECNICO_02"), ", ")
                    End If
                End With
            End If

            bOk = True
        Catch ex As Exception
            EMail_Enviar_Local(cnt_EMail_From_Proc, EMail_EMailTecnico, _
                               EMail_MontarTitulo("Banco de Dados - Carregando Configuração"), _
                               "Ocorreu o erro, ao carregar as configurações de e-mail, descriminado abaixo e o sistema de E-Mail está sendo abortado." _
                               & vbCrLf & vbCrLf & ex.Message)
        End Try

        Return bOk
    End Function

    Private Function EMail_Proc_ListarDestinatario(ByVal SQ_Mensagem As Integer, ByVal CD_Processo As String, _
                                                   ByRef DS_EMAIL_DESTINARIO As String, _
                                                   Optional ByRef CD_USER_SOLICITA_CADASTRO_MENSAGEM As String = "") As Boolean
        Dim oData As DataTable
        Dim iCont As Integer
        Dim SqlText As String = ""
        Dim sTo As String = ""
        Dim sUsuario_SemEMail As String = ""
        Dim bOk As Boolean
        Dim dDataUltimoEnvio As Date
        Dim bSolicitarCadastro As Boolean
        Dim CD_USER_SOLICITA_CADASTRO_PROCESSO As String = ""
        Dim sAux As String = ""

        Try
            bOk = True

            '>>> Destinatário da mensagem
            If SQ_Mensagem > 0 Then
                SqlText = "SELECT EMD.CD_USUARIO," & _
                                 "DUS.NO_USUARIO," & _
                                 "DUS.DS_EMAIL DS_EMAIL_USUARIO," & _
                                 "DUS.DT_SOLICITACAO_CADASTRO_EMAIL," & _
                                 "EMD.DS_EMAIL" & _
                          " FROM " & sBancoDados_OwnerSistemaEMail & ".EMAIL_DESTINATARIO EMD," & _
                                 "(SELECT * FROM " & sBancoDados_OwnerSistemaEMail & ".SEC_USUARIO WHERE IC_ATIVO = 'S') DUS" & _
                          " WHERE EMD.SQ_EMAIL_MENSAGEM = " & SQ_Mensagem & _
                            " AND EMD.DT_ENVIADA IS NULL" & _
                            " AND DUS.CD_USUARIO (+) = EMD.CD_USUARIO"
                oData = DBQuery(SqlText)

                If Not objDataTable_Vazio(oData) Then
                    For iCont = 0 To oData.Rows.Count - 1
                        With oData.Rows(iCont)
                            If Not objDataTable_CampoVazio(.Item("CD_USUARIO")) Then
                                If objDataTable_CampoVazio(.Item("DS_EMAIL_USUARIO")) Then
                                    dDataUltimoEnvio = objDataTable_LerCampo(.Item("DT_SOLICITACAO_CADASTRO_EMAIL"), _
                                                                             "01/01/1900 00:00:00")
                                    bSolicitarCadastro = False

                                    If Data_ProximaHora(dDataUltimoEnvio, cnt_HoraTrabalho_Ini) > dDataUltimoEnvio And _
                                       Data_HoraAnterior(Data_ProximaHora(dDataUltimoEnvio, cnt_HoraTrabalho_Fim), _
                                                         cnt_HoraTrabalho_Fim) < dDataUltimoEnvio Then
                                        If DateAdd(DateInterval.Hour, cnt_EMail_NrHoraIntervaloSolicitacaoCadastroEMail, _
                                                   Data_ProximaHora(dDataUltimoEnvio, cnt_HoraTrabalho_Ini)) < Now Then
                                            bSolicitarCadastro = True
                                        End If
                                    Else
                                        If DateAdd(DateInterval.Hour, cnt_EMail_NrHoraIntervaloSolicitacaoCadastroEMail, _
                                                   dDataUltimoEnvio) < Now Then
                                            bSolicitarCadastro = True
                                        End If
                                    End If

                                    If bSolicitarCadastro Then
                                        Str_Adicionar(sUsuario_SemEMail, .Item("CD_USUARIO") & " - " & .Item("NO_USUARIO"), vbCrLf)
                                    End If
                                    Str_Adicionar(CD_USER_SOLICITA_CADASTRO_MENSAGEM, QuotedStr(.Item("CD_USUARIO")), ",")
                                Else
                                    If InStr(oData.Rows(iCont).Item("DS_EMAIL_USUARIO"), "@") > 1 Then
                                        Str_Adicionar(sTo, oData.Rows(iCont).Item("DS_EMAIL_USUARIO"), ";")
                                    End If
                                End If
                            ElseIf Not objDataTable_CampoVazio(oData.Rows(iCont).Item("DS_EMAIL")) Then
                                If InStr(oData.Rows(iCont).Item("DS_EMAIL"), "@") > 1 Then
                                    Str_Adicionar(sTo, oData.Rows(iCont).Item("DS_EMAIL"), ";")
                                End If
                            End If
                        End With
                    Next
                End If

                oData.Dispose()
            End If

            '>>> Destinatário do processo
            If Trim(CD_Processo) <> "" Then
                SqlText = "SELECT EPD.CD_USUARIO," & _
                                 "DUS.NO_USUARIO," & _
                                 "DUS.DS_EMAIL DS_EMAIL_USUARIO," & _
                                 "SYSDATE DT_SOLICITACAO_CADASTRO_EMAIL," & _
                                 "EPD.DS_EMAIL" & _
                          " FROM " & sBancoDados_OwnerSistemaEMail & ".EMAIL_PROCESSO_DESTINATARIO EPD," & _
                                 "(SELECT * FROM " & sBancoDados_OwnerSistemaEMail & ".SEC_USUARIO WHERE IC_ATIVO = 'S') DUS" & _
                          " WHERE EPD.CD_PROCESSO = " & QuotedStr(CD_Processo) & _
                            " AND DUS.CD_USUARIO (+) = EPD.CD_USUARIO"
                oData = DBQuery(SqlText)

                If Not objDataTable_Vazio(oData) Then
                    For iCont = 0 To oData.Rows.Count - 1
                        With oData.Rows(iCont)
                            If Not objDataTable_CampoVazio(.Item("CD_USUARIO")) Then
                                If objDataTable_CampoVazio(.Item("DS_EMAIL_USUARIO")) Then
                                    dDataUltimoEnvio = objDataTable_LerCampo(.Item("DT_SOLICITACAO_CADASTRO_EMAIL"), _
                                                                             "01/01/1900 00:00:00")
                                    bSolicitarCadastro = False

                                    If Data_ProximaHora(dDataUltimoEnvio, cnt_HoraTrabalho_Ini) > dDataUltimoEnvio And _
                                       Data_HoraAnterior(Data_ProximaHora(dDataUltimoEnvio, cnt_HoraTrabalho_Ini), _
                                                         cnt_HoraTrabalho_Fim) < dDataUltimoEnvio Then
                                        If DateAdd(DateInterval.Hour, cnt_EMail_NrHoraIntervaloSolicitacaoCadastroEMail, _
                                                   Data_ProximaHora(dDataUltimoEnvio, cnt_HoraTrabalho_Ini)) < Now Then
                                            bSolicitarCadastro = True
                                        End If
                                    Else
                                        If DateAdd(DateInterval.Hour, cnt_EMail_NrHoraIntervaloSolicitacaoCadastroEMail, _
                                                   dDataUltimoEnvio) < Now Then
                                            bSolicitarCadastro = True
                                        End If
                                    End If

                                    If bSolicitarCadastro Then
                                        Str_Adicionar(CD_USER_SOLICITA_CADASTRO_PROCESSO, QuotedStr(.Item("CD_USUARIO")), ",")
                                        Str_Adicionar(sUsuario_SemEMail, .Item("CD_USUARIO") & " - " & .Item("NO_USUARIO"), vbCrLf)
                                    End If
                                Else
                                    If InStr(oData.Rows(iCont).Item("DS_EMAIL_USUARIO"), "@") > 1 Then
                                        Str_Adicionar(sTo, oData.Rows(iCont).Item("DS_EMAIL_USUARIO"), ";")
                                    End If
                                End If
                            ElseIf Not objDataTable_CampoVazio(oData.Rows(iCont).Item("DS_EMAIL")) Then
                                If InStr(oData.Rows(iCont).Item("DS_EMAIL"), "@") > 1 Then
                                    Str_Adicionar(sTo, oData.Rows(iCont).Item("DS_EMAIL"), ";")
                                End If
                            End If
                        End With
                    Next
                End If

                oData.Dispose()
            End If

            oData = Nothing

            If Trim(sUsuario_SemEMail) <> "" Or _
               Trim(CD_USER_SOLICITA_CADASTRO_PROCESSO) <> "" Then
                sAux = CD_USER_SOLICITA_CADASTRO_MENSAGEM
                If Trim(CD_USER_SOLICITA_CADASTRO_PROCESSO) <> "" Then
                    Str_Adicionar(sAux, CD_USER_SOLICITA_CADASTRO_PROCESSO, ",")
                End If

                SqlText = "UPDATE " & sBancoDados_OwnerSistemaEMail & ".SEC_USUARIO" & _
                          " SET DT_SOLICITACAO_CADASTRO_EMAIL = SYSDATE" & _
                          " WHERE CD_USUARIO IN (" & sAux & ")" & _
                            " AND IC_ATIVO = 'S'"
                DBExecutar(SqlText)
            End If

            If Trim(sTo) = "" Then
                bOk = False
            End If

            If bOk Then
                DS_EMAIL_DESTINARIO = sTo
            End If

            If Trim(sUsuario_SemEMail) <> "" Then
                Dim sEMail As String

                sEMail = sEMail_Usuario_Cadastro
                Str_Adicionar(sEMail, EMail_EMailTecnico, ";")

                EMail_Enviar_Local(cnt_EMail_From_Proc, sEMail, _
                                   EMail_MontarTitulo("Cadastro de E-Mail de Usuário (" & Trim(CD_Processo) & "/" & sBancoDados_BancoDadosLogado & ")"), _
                                   sNome_Usuario_Cadastro _
                                   & vbCrLf & vbCrLf & _
                                   "Favor cadastrar o e-mail do(s) usuário(s) listado(s) abaixo. Existem mensagens a serem enviadas" & _
                                   ", para este(s), pendentes, por motivo deste(s) não ter(em) o e-mail cadastrado." _
                                   & vbCrLf & vbCrLf & sUsuario_SemEMail)
            End If
        Catch ex As Exception
            EMail_Enviar_Local(cnt_EMail_From_Proc, EMail_EMailTecnico, _
                               EMail_MontarTitulo("Envio de E-Mail - Listagem de Destinatário"), _
                               "Ocorreu o erro, de listagem de destinatário de e-mail, descriminado abaixo" _
                               & vbCrLf & vbCrLf & ex.Message)

            bOk = False
        End Try

Sair:
        Return bOk
    End Function

    Private Function EMail_Enviar_Local(ByVal strDe As String, _
                                        ByVal strPara As String, _
                                        ByVal strAssunto As String, _
                                        ByVal strMensagem As String, _
                                        Optional ByVal strCaminhoAnexo() As String = Nothing, _
                                        Optional ByVal CD_Processo As String = "", _
                                        Optional ByVal HTML As Boolean = False, _
                                        Optional ByVal NOME_REMETENTE As String = "", _
                                        Optional ByVal EMAIL_REMETENTE As String = "", _
                                        Optional ByVal PRIORIDADE As String = cnt_EMail_Prioridade_Media, _
                                        Optional ByVal TratarTexto As Boolean = True) As Boolean
        Dim sAux As String = ""
        Dim iPonteiro As Integer = 0
        Dim sTermo As String = ""

        strPara = Nome_Tratar(Trim(strPara), True)

        Try
            If TratarTexto Then
                strMensagem = EMail_Mensagem_Tratar(strMensagem)
            End If

            If Trim(UCase(sBancoDados_BancoDadosLogado)) <> "ILH01P" And _
               Trim(UCase(sBancoDados_BancoDadosLogado)) <> "SPO07P" And _
               Trim(UCase(sBancoDados_BancoDadosLogado)) <> "PSPSHR02" Then
                strMensagem = strMensagem & vbCrLf & vbCrLf & _
                              "BANCO DE DADOS: " & sBancoDados_BancoDadosLogado
            End If

            If HTML Then
                Dim Email_HTML_Linhas() As cEmail_HTML_Linha

                If Trim(NOME_REMETENTE) = "" Then
                    If Email_HTML_Linhas Is Nothing Then
                        ReDim Email_HTML_Linhas(0)
                    Else
                        ReDim Preserve Email_HTML_Linhas(UBound(Email_HTML_Linhas) + 1)
                    End If

                    Email_HTML_Linhas(UBound(Email_HTML_Linhas)) = EMail_MontarHTML_Linha("Remetente", EMAIL_REMETENTE, False, False, , True, NOME_REMETENTE)
                End If

                Do While True
                    If Numero_Menor(New Double() {InStr(UCase(strMensagem), "<BR>"), _
                                                  InStr(UCase(strMensagem), "<PRE>"), _
                                                  InStr(UCase(strMensagem), "<FIM>")}, True) > 0 Then
                        sTermo = Mid(strMensagem, Numero_Menor(New Double() {InStr(UCase(strMensagem), "<BR>"), _
                                                                             InStr(UCase(strMensagem), "<PRE>"), _
                                                                             InStr(UCase(strMensagem), "<FIM>")}, True), 5)
                    End If

                    If InStr(sTermo, "<BR>") > 0 Then
                        sTermo = "BR"
                    ElseIf InStr(sTermo, "<PRE>") > 0 Then
                        sTermo = "PRE"
                    ElseIf InStr(sTermo, "<FIM>") > 0 Then
                        sTermo = "FIM"
                    End If

                    If Trim(sTermo) <> "" Then
                        iPonteiro = InStr(strMensagem, "<" & sTermo & ">")

                        If InStr(strMensagem, "</" & sTermo & ">" & vbCrLf) > 0 Then
                            sAux = Trim(Mid(strMensagem, iPonteiro + Len("<" & sTermo & ">"), InStr(strMensagem, "</" & sTermo & ">" & vbCrLf) - Len("</" & sTermo & ">")))
                        ElseIf InStr(strMensagem, "</" & sTermo & ">") > 0 Then
                            sAux = Trim(Mid(strMensagem, iPonteiro + Len("<" & sTermo & ">"), InStr(strMensagem, "</" & sTermo & ">") - Len("</" & sTermo & ">")))
                        Else
                            sAux = strMensagem
                            strMensagem = ""
                        End If

                        If VB.Right(Trim(sAux), 1) = "<" Then
                            sAux = Mid(Trim(sAux), 1, Len(Trim(sAux)) - 1)
                        End If

                        If InStr(strMensagem, "</" & sTermo & ">" & vbCrLf) > 0 Then
                            strMensagem = Mid(strMensagem, InStr(strMensagem, "</" & sTermo & ">") + 7)
                        ElseIf InStr(strMensagem, "</" & sTermo & ">") > 0 Then
                            strMensagem = Mid(strMensagem, InStr(strMensagem, "</" & sTermo & ">") + 5)
                        End If

                        If Email_HTML_Linhas Is Nothing Then
                            ReDim Email_HTML_Linhas(0)
                        Else
                            ReDim Preserve Email_HTML_Linhas(UBound(Email_HTML_Linhas) + 1)
                        End If

                        If InStr(sAux, "<CAB>") > 0 Then
                            Email_HTML_Linhas(UBound(Email_HTML_Linhas)) = EMail_MontarHTML_Linha(Mid(sAux, 1, InStr(sAux, "<CAB>") - 1), _
                                                                                                  Mid(sAux, InStr(sAux, "<CAB>") + 5), _
                                                                                                  sTermo = "PRE", False, False)
                        Else
                            Email_HTML_Linhas(UBound(Email_HTML_Linhas)) = EMail_MontarHTML_Linha("", sAux, _
                                                                                                  sTermo = "PRE", False, False)
                        End If

                        If Trim(strMensagem) = "" Then
                            Exit Do
                        End If
                    Else
                        Exit Do
                    End If
                Loop

                If Trim(strMensagem) <> "" Then
                    If Email_HTML_Linhas Is Nothing Then
                        ReDim Email_HTML_Linhas(0)
                    Else
                        ReDim Preserve Email_HTML_Linhas(UBound(Email_HTML_Linhas) + 1)
                    End If

                    Email_HTML_Linhas(UBound(Email_HTML_Linhas)) = EMail_MontarHTML_Linha("Mensagem", strMensagem, True, True, False)
                End If

                'Montagem do texto final
                strMensagem = EMail_MontarHTML(strAssunto, CD_Processo, Email_HTML_Linhas)
            End If

            strDe = Nome_Tratar(strDe, True, False)

            EMail_Enviar(strDe, strPara, strAssunto, strMensagem, _
                         HTML, cnt_EMail_Servidor_SMTP, _
                         IIf(PRIORIDADE = cnt_EMail_Prioridade_Baixa, _
                             System.Net.Mail.MailPriority.Low, _
                             IIf(PRIORIDADE = cnt_EMail_Prioridade_Alta, _
                                 System.Net.Mail.MailPriority.High, _
                                 System.Net.Mail.MailPriority.Normal)), _
                         strCaminhoAnexo, EMail_EMailTecnico)

            Return True
        Catch ex As Exception
            EMail_Enviar(cnt_EMail_From_Proc, _
                         EMail_EMailTecnico, EMail_MontarTitulo("Envio de E-Mail - Erro no envio de mensagem"), _
                         "Ocorreu o erro no envio de mensagem." _
                         & vbCrLf & vbCrLf & "Assunto: " & Trim(strAssunto) & " - Para: " & Trim(strPara) _
                         & vbCrLf & vbCrLf & ex.Message, _
                         HTML, cnt_EMail_Servidor_SMTP, _
                         System.Net.Mail.MailPriority.Normal)

            Return False
        End Try
    End Function

    Public Function EMail_Enviar(ByVal strDe As String, ByVal strPara As String, _
                                 ByVal strAssunto As String, ByVal strMensagem As String, _
                                 ByVal HTML As Boolean, ByVal strSMTP As String, _
                                 ByVal enumPrioridade As MailPriority, _
                                 Optional ByVal strCaminhoAnexo() As String = Nothing, _
                                 Optional ByVal EMail_Tecnico As String = "") As Boolean
        Try
            Dim oTo As New Collection
            Dim oTo_Externo As New Collection
            Dim sTo_Filtro As String = ""

            oTo = EMail_TratarPara(strPara, sTo_Filtro)

            If Trim(EMail_Tecnico) <> "" Then
                oTo_Externo = EMail_TratarPara(EMail_Tecnico, "")
            End If

            'Envio de e-mail para a área técnica sobre os bloqueados
            If Trim(sTo_Filtro) <> "" And Trim(EMail_Tecnico) <> "" Then
                EMail_EnviarMensagem(strDe, oTo_Externo, strAssunto, _
                                     "A mensagem mais abaixo foi direcionada para os destinatários listados," & _
                                     " sendo que a mesma foi bloqueada pelo sistema de e-mail." & _
                                     vbCrLf & vbCrLf & sTo_Filtro & vbCrLf & vbCrLf & _
                                     strMensagem, _
                                     HTML, strSMTP, enumPrioridade, strCaminhoAnexo)
            End If

            'Envio de e-mail para os destinatario autorizados
            If oTo.Count = 0 Then
                Return True
            Else
                Return EMail_EnviarMensagem(strDe, oTo, strAssunto, strMensagem, HTML, _
                                            strSMTP, enumPrioridade, strCaminhoAnexo)
            End If
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Source, ex.Message)

            Return False
        End Try
    End Function

    Private Function EMail_EnviarMensagem(ByVal strDe As String, ByVal strPara As Collection, _
                                          ByVal strAssunto As String, ByVal strMensagem As String, _
                                          ByVal HTML As Boolean, ByVal strSMTP As String, _
                                          ByVal enumPrioridade As MailPriority, _
                                          Optional ByVal strCaminhoAnexo() As String = Nothing) As Boolean
        If strPara.Count = 0 Then
            Return True
            Exit Function
        End If

        Try
            Dim mSmtpClient As New SmtpClient(strSMTP)
            Dim oMail As New MailMessage
            Dim mailAnexo As Attachment = Nothing
            Dim oAlternateView As AlternateView
            Dim oResource As LinkedResource

            Dim sFrom As String
            Dim iCont As Integer

            'Armazem a imagem caso seja um e-mail em HTML
            If HTML Then
                oAlternateView = AlternateView.CreateAlternateViewFromString(strMensagem, New System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Text.Html))

                oResource = New LinkedResource("logoCargill.jpg")
                oResource.ContentId = "logoCargill"
                oAlternateView.LinkedResources.Add(oResource)
                oMail.AlternateViews.Add(oAlternateView)
            End If

            '>> Montagem e enviado do e-mail
            If InStr(strDe, "@") = 0 Then
                sFrom = strDe & " <donotreply@cargill.com>"
            Else
                sFrom = strDe
            End If

            With oMail
                .From = New MailAddress(sFrom)

                For iCont = 1 To strPara.Count
                    .To.Add(Trim(strPara(iCont)))
                Next

                .Subject = Trim(strAssunto)
                .Body = strMensagem
                .Priority = enumPrioridade
                .IsBodyHtml = HTML
                '.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1")
                '.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1")

                If Not IsNothing(strCaminhoAnexo) Then
                    Dim strAnexo As String

                    For Each strAnexo In strCaminhoAnexo
                        mailAnexo = New Attachment(strAnexo)
                        oMail.Attachments.Add(mailAnexo)
                    Next
                End If

                mSmtpClient.Send(oMail)

                oMail.Dispose()
                oMail = Nothing
                mSmtpClient = Nothing

                If Not mailAnexo Is Nothing Then
                    mailAnexo.Dispose()
                    mailAnexo = Nothing
                End If
            End With

            Return True
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Source, ex.Message)

            Return False
        End Try
    End Function

    Public Function EMail_MontarTitulo(ByVal sTitulo As String) As String
        Dim sTextoTitulo As String = ""

        Select Case EMail_TipoServico
            Case eTipoServico.ServicoEMail
                sTextoTitulo = "SSE - Sistema de Serviço de E-Mail"
        End Select

        If Trim(sTextoTitulo) <> "" Then sTextoTitulo = sTextoTitulo & " - "

        sTextoTitulo = sTextoTitulo & sTitulo

        Return sTextoTitulo
    End Function

    Public Sub EMail_Inicializar()
        sEMail_To = ""
    End Sub

    Public Sub EMail_To_Adicionar(ByVal sEMail As String)
        If Trim(sEMail_To) <> "" Then sEMail_To = sEMail_To & ";"

        sEMail_To = sEMail_To & sEMail
    End Sub

    Public Function EMail_To() As String
        Return sEMail_To
    End Function

    Public Function EMail_HTML_Negrito(ByVal Texto As String) As String
        Return "<strong>" & Texto & "</strong>"
    End Function

    Public Function EMail_HTML_CompletaEspaco(ByVal Texto As String, ByVal Tamanho As String)
        Return Texto & StrReplicate(Tamanho - Len(Trim(Texto)), "&nbsp;")
    End Function

    Public Function EMail_HTML_Linha(ByVal Cabecalho As String, ByVal Texto As String)
        If Trim(Cabecalho) = "" Then
            Return "<BR>" & Texto & "</BR>"
        Else
            Return "<BR>" & Cabecalho & "<CAB>" & Texto & "</BR>"
        End If
    End Function

    Public Sub EMail_SuporteTecnico_Carregar()
        Dim oData As DataTable

        oData = DBQuery("SELECT * FROM " & sBancoDados_OwnerSistemaEMail & ".EMAIL_CONFIGURACAO")

        If Not objDataTable_Vazio(oData) Then
            With oData.Rows(0)
                If Not objDataTable_CampoVazio(.Item("DS_EMAIL_USUARIO_TECNICO_01")) Then
                    sEMail_SuporteTecnico = .Item("DS_EMAIL_USUARIO_TECNICO_01")
                End If
                If Not objDataTable_CampoVazio(.Item("DS_EMAIL_USUARIO_TECNICO_02")) Then
                    Str_Adicionar(sEMail_SuporteTecnico, .Item("DS_EMAIL_USUARIO_TECNICO_02"), ";")
                End If
            End With
        End If
    End Sub
End Module