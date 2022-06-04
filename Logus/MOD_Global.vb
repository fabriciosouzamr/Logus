Imports VB = Microsoft.VisualBasic
Imports Infragistics.Win.UltraMessageBox

Enum DataFormato
    eSemFormatacao = 1
    eInicioDia = 2
    eFimDia = 3
    eFormatoParaQuery = 4
End Enum

Module Global_L
    Dim sErro_UltimoErro As String = ""
    Dim iErro_UltimoErro_Repeticao As Integer = 0

    Public Function Check_Aspas(ByVal texto As String) As String
        Dim cont As Integer
        Dim retorno As String = ""

        cont = 1

        Do Until cont > Len(texto)
            If Mid(texto, cont, 1) = "'" Then
                retorno = retorno & "''"
            Else
                retorno = retorno & Mid(texto, cont, 1)
            End If
            cont = cont + 1
        Loop

        Check_Aspas = retorno
    End Function

    Public Function ConvValorFormatoAmericano(ByVal Valor As String) As String
        Dim iCont As Integer
        Dim sAux As String
        Dim sRet As String = ""

        sAux = Valor.ToString

        If InStr(sAux, ",") = 0 Then
            sAux = Replace(sAux, ".", ",")
        End If

        For iCont = 1 To Len(Trim(sAux))
            If IsNumeric(Mid(Trim(sAux), iCont, 1)) Or _
               Mid(Trim(sAux), iCont, 1) = "-" Or _
               Mid(Trim(sAux), iCont, 1) = "." Or _
               Mid(Trim(sAux), iCont, 1) = "," Then
                If Mid(Trim(sAux), iCont, 1) = "," Then
                    sRet = sRet & "."
                ElseIf Mid(Trim(sAux), iCont, 1) = "." Then
                    sRet = sRet
                Else
                    sRet = sRet & Mid(Trim(sAux), iCont, 1)
                End If
            End If
        Next

        If Trim(sRet) = "" Then sRet = "0"

        Return sRet
    End Function

    Public Function NuloString(ByVal Valor As Object) As Object
        If Valor = "" Or Valor = QuotedStr("") Then
            Return "Null"
        Else
            Return Valor
        End If
    End Function

    Public Function QuotedStr(ByVal vValor As Object) As String
        QuotedStr = "'" & Check_Aspas(vValor) & "'"
    End Function

    Public Function GerarArray(ByVal ParamArray Valor() As Object) As Object
        Return Valor
    End Function

    Public Function CampoNulo(ByVal oValor As Object) As Boolean
        If oValor Is Nothing Then
            Return True
        ElseIf oValor Is System.DBNull.Value Then
            Return True
        End If
    End Function

    Public Function NuloParaString(ByVal Valor As Object) As String
        Try
            Return Valor
        Catch
            Return ""
        End Try
    End Function
    Public Function NuloParaValor(ByVal Valor As Object) As Double
        Try
            Return Valor
        Catch
            Return 0
        End Try
    End Function

    '>>>> Mensagem
    Public Sub Msg_Mensagem(ByVal sMens As String, Optional ByVal bErro As Boolean = False, Optional ByVal Titulo As String = "")
        If Titulo = "" Then
            Titulo = Sis_NomeSistema
        End If
        If bErro Then
            '    MsgBox(sMens, MsgBoxStyle.Critical, "E R R O")
            UltraMessageBoxManager.Show(sMens, "E R R O", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            '    MsgBox(sMens, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Sis_NomeSistema)
            UltraMessageBoxManager.Show(sMens, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Public Function Msg_Perguntar(ByVal sMens As String) As Boolean
        'Return MsgBox(sMens, MsgBoxStyle.YesNo Or _
        '                     MsgBoxStyle.Question Or _
        '                     MsgBoxStyle.DefaultButton2, _
        '              Sis_NomeSistema) = MsgBoxResult.Yes
        Return UltraMessageBoxManager.Show(sMens, Sis_NomeSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
    End Function

    Public Function TratarErro(Optional ByVal sErro As String = "", _
                               Optional ByVal bExibirErro As Boolean = True, _
                               Optional ByVal LocalErro As String = "", _
                               Optional ByVal ErroComplemento As String = "") As String
        Dim Msg As String
        Dim oBancoConeccao As BancoConeccao

        oBancoConeccao = DBBanco_Atual()
        DBBanco_Uso(BancoConeccao.Sistema)
        DBUsarTransacao = False

        Msg = Err.Description

        'Caso o erro seja o mesmo repetidamente, na terceira vez encerra o sistema
        If Trim(UCase(Msg)) = Trim(UCase(sErro_UltimoErro)) Then
            iErro_UltimoErro_Repeticao = iErro_UltimoErro_Repeticao + 1

            If iErro_UltimoErro_Repeticao = 3 Then
                End
            End If
        Else
            sErro_UltimoErro = Msg
            iErro_UltimoErro_Repeticao = 1
        End If

        If Trim(sErro) <> "" And Trim(sErro) <> Trim(Msg) Then Msg = Msg & vbCrLf & sErro

        If bExibirErro And Trim(Msg) <> "" Then
            Msg_Mensagem(Msg)
        End If

        Try
            If Trim(Msg) <> "" Then
                If Not Debug_Testar() Then
                    EnvioEmail("ERRO - " & Application.ProductName, _
                               EMail_HTML_Negrito("O Sistema encontrou um erro. Favor abrir chamado e anexar  a mensagem desse e-mail no corpo do chamado. " & _
                                                  "Inclua tambem mais informações que ajudem a equipe de suporte no entendimento da operação que você estava realizando no sistema.") & vbCrLf & vbCrLf & _
                               "Máquina Logada: " & My.Computer.Name & vbCrLf & _
                               "Usuário Logado: " & sAcesso_UsuarioLogado & " - " & sAcesso_NomeUsuarioLogado & vbCrLf & _
                               "Data/Hora do Erro: " & Now.ToString & vbCrLf & _
                               "Data da Versão do Sistema: " & FileDateTime(Application.ExecutablePath).ToString & vbCrLf & _
                               "Origem do Erro: " & NVL(Err.Source, "Não identificado") & vbCrLf & _
                               "Form do Erro: " & Form_Ativo() & vbCrLf & _
                               "Local do Erro: " & LocalErro & vbCrLf & vbCrLf & _
                                Msg & _
                               IIf(Trim(ErroComplemento) = "", "", _
                                   vbCrLf & "<<< COMPLEMENTO DO ERRO >>>" & _
                                   vbCrLf & ErroComplemento), _
                               Nothing, _
                               New String() {sEMail_SuporteTecnico})
                End If
            End If
        Catch ex As Exception
        End Try

        DBBanco_Uso(oBancoConeccao)

        Return Msg
    End Function

    Public Function Form_Ativo() As String
        Dim sForm As String = "Não identificado"

        If Not oMDI Is Nothing Then
            If Not oMDI.ActiveForm Is Nothing Then
                sForm = oMDI.ActiveForm.Name
            End If
        End If

        Return sForm
    End Function

    Public Function NVL(ByVal Valor1 As Object, ByVal Valor2 As Object) As Object
        If CampoNulo(Valor1) Then
            Return Valor2
        Else
            Return Valor1
        End If
    End Function

    Public Function fIN(ByVal Valor As Object, ByVal ParamArray Valores() As Object) As Boolean
        Dim iCont As Integer
        Dim bOk As Boolean = False

        If Not Valores Is Nothing Then
            For iCont = Valores.GetLowerBound(0) To Valores.GetUpperBound(0)
                If Valor = Valores(iCont) Then
                    bOk = True
                    Exit For
                End If
            Next
        End If

        Return bOk
    End Function

    Public Function NVL2(ByVal Valor1 As Object, ByVal Valor2 As Object, ByVal Valor3 As Object) As Object
        If CampoNulo(Valor1) Then
            Return Valor3
        Else
            Return Valor2
        End If
    End Function

    Public Function NULLIf(ByVal Valor1 As Object, ByVal Valor2 As Object) As Object
        If NVL(Valor1, Nothing) = NVL(Valor2, Nothing) Then
            Return Nothing
        Else
            Return Valor1
        End If
    End Function

    Public Function Data_UltimoDiaMes(ByVal iMes As Integer, ByVal iAno As Integer) As Date
        Return DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, CDate("01/" & Trim(iMes) & "/" & Trim(iAno))))
    End Function

    Public Function Data_1DiaMes(ByVal dData As Date) As Date
        Return New Date(dData.Year, dData.Month, 1)
    End Function

    Public Function Data_UltimoDiaMes(ByVal dData As Date) As Date
        Return New Date(dData.Year, dData.Month, 1).AddMonths(1).AddDays(-1)
    End Function

    Public Function Data_DiaSemana(ByVal Data As Date, Optional ByVal bNomeCurto As Boolean = False) As String
        Select Case Weekday(Data)
            Case FirstDayOfWeek.Sunday
                Return IIf(bNomeCurto, "Dom", "Domingo")
            Case FirstDayOfWeek.Monday
                Return IIf(bNomeCurto, "Seg", "Segunda-feira")
            Case FirstDayOfWeek.Tuesday
                Return IIf(bNomeCurto, "Ter", "Terça-feira")
            Case FirstDayOfWeek.Wednesday
                Return IIf(bNomeCurto, "Qua", "Quarta-feira")
            Case FirstDayOfWeek.Thursday
                Return IIf(bNomeCurto, "Qui", "Quinta-feira")
            Case FirstDayOfWeek.Friday
                Return IIf(bNomeCurto, "Sex", "Sexta-feira")
            Case FirstDayOfWeek.Saturday
                Return IIf(bNomeCurto, "Sab", "Sábado")
            Case Else
                Return ""
        End Select
    End Function

    Public Function Date_to_Oracle_Nulo(ByVal Data As String, _
                                        Optional ByVal bDesmontarData As Boolean = False, _
                                        Optional ByVal FormatoData As DataFormato = DataFormato.eSemFormatacao, _
                                        Optional ByVal bFormato24Horas As Boolean = True) As Object
        If IsDate(Data) Then
            Return Date_to_Oracle(Data, bDesmontarData, FormatoData, bFormato24Horas)
        Else
            Return Nothing
        End If
    End Function

    Public Function Date_TratarBancoDados(ByVal Data As String) As Date
        Dim iPonteiro As Integer
        Dim iMes As Integer
        Dim sMes As String
        Dim iDia As Integer
        Dim Hora As String = ""
        Dim iAno As Integer
        Dim iHora As Integer
        Dim iMinuto As Integer
        Dim iSegundo As Integer

        If Trim(Data) = "" Then Exit Function

        'Formatação data e hora
        If Len(Data) > 10 Then
            'Separacao hora
            iHora = CDate(Data).Hour
            iMinuto = CDate(Data).Minute
            iSegundo = CDate(Data).Second

            Hora = StrZero(CDate(Data).Hour, 2) & ":" & _
                   StrZero(CDate(Data).Minute, 2) & ":" & _
                   StrZero(CDate(Data).Second, 2)
        End If

        'Separacao data
        iPonteiro = InStr(Data, "/") + 1

        iDia = Left(Data, iPonteiro - 2)

        iMes = Val(Mid(Data, iPonteiro, InStr(iPonteiro, Data, "/") - iPonteiro))

        sMes = Choose(iMes, "JAN", "FEB", "MAR", "APR", "MAY", "JUN", _
                            "JUL", "AUG", "SEP", "OCT", "NOV", "DEC")

        iPonteiro = InStr(iPonteiro, Data, "/")

        iAno = Mid(Data, iPonteiro + 1, 4)

        If Trim(Hora) = "" Then
            Return New Date(iAno, iMes, iDia)
        Else
            Return New Date(iAno, iMes, iDia, iHora, iMinuto, iSegundo)
        End If
    End Function

    Public Function Date_Mes(ByVal Data As Date, Optional ByVal Resumido As Boolean = False) As String
        Dim sAux As String

        sAux = Choose(Data.Month, "JANEIRO", "FEVEREIRO", "MARÇO", "ABRIL", "MAIO", "JUNHO", _
                                  "JULHO", "AGOSTO", "SETEMBRO", "OUTUBRO", "NOVEMBRO", "DEZEMBRO")

        Return IIf(Resumido, VB.Left(sAux, 3), sAux)
    End Function

    Public Function Date_to_Oracle(ByVal Data As String, _
                                   Optional ByVal bDesmontarData As Boolean = False, _
                                   Optional ByVal FormatoData As DataFormato = DataFormato.eSemFormatacao, _
                                   Optional ByVal bFormato24Horas As Boolean = True, _
                                   Optional ByVal SomenteData As Boolean = False) As String
        Dim iPonteiro As Integer
        Dim iMes As Integer
        Dim sMes As String
        Dim iDia As Integer
        Dim iAno As Integer
        Dim sData As String
        Dim Hora As String = ""

        Data = Trim(Data)

        If Trim(Data) = "" Then Return ""

        If Len(Data) > 10 Then
            Hora = Trim(Mid(Data, 11))

            If Len(Hora) = 5 Then
                Hora = Hora & ":00"
            End If
        End If

        If bDesmontarData Then
            iPonteiro = InStr(Data, "/") + 1

            iDia = Left(Data, iPonteiro - 2)

            iMes = Val(Mid(Data, iPonteiro, InStr(iPonteiro, Data, "/") - iPonteiro))

            sMes = Choose(iMes, "JAN", "FEB", "MAR", "APR", "MAY", "JUN", _
                                "JUL", "AUG", "SEP", "OCT", "NOV", "DEC")

            iPonteiro = InStr(iPonteiro, Data, "/")

            iAno = Mid(Data, iPonteiro + 1, 4)
        Else
            iDia = Microsoft.VisualBasic.DateAndTime.Day(CDate(Data))

            sMes = Choose(Month(CDate(Data)), "JAN", "FEB", "MAR", "APR", "MAY", "JUN", _
                                              "JUL", "AUG", "SEP", "OCT", "NOV", "DEC")

            iAno = Year(CDate(Data))
        End If

        sData = Trim(iDia) & "-" & sMes & "-" & Trim(iAno)

        Select Case FormatoData
            Case DataFormato.eInicioDia
                sData = "TO_DATE('" & sData & " 00:00:00', 'DD-MON-YYYY HH24:MI:SS')"
            Case DataFormato.eFimDia
                sData = "TO_DATE('" & sData & " 23:59:59', 'DD-MON-YYYY HH24:MI:SS')"
            Case Else
                If Trim(Hora) <> "" And Not SomenteData Then
                    If bFormato24Horas Then
                        sData = "TO_DATE('" & sData & " " & Hora & "', 'DD-MON-YYYY HH24:MI:SS')"
                    Else
                        If Val(Left(Hora, 2)) > 12 Then
                            Hora = Val(Left(Hora, 2)) - 12 & Mid(Hora, 3) & " PM"
                        Else
                            Hora = Hora & " AM"
                        End If

                        sData = sData & " " & Hora
                    End If
                End If
        End Select

        Return Trim(sData)
    End Function

    Public Function Arquivo_Dialogo_Salvar(Optional ByVal sExtensao As String = "") As String
        Dim oDialogoSalvar As New SaveFileDialog
        Dim sArquivo As String

        With oDialogoSalvar
            .CheckPathExists = True
            .Filter = sExtensao
            .ShowDialog()
            sArquivo = .FileName
            .Dispose()
        End With

        Return sArquivo
    End Function

    Public Sub Str_Adicionar(ByRef vVariavel As String, ByVal sValor As String, ByVal sSeparador As String)
        If Trim(sValor) <> "" Then
            If Trim(vVariavel) <> "" Then vVariavel = vVariavel & sSeparador
            vVariavel = vVariavel & sValor
        End If
    End Sub

    Public Function Data_ProximaHora(ByVal dData As Date, ByVal sHora As String) As Date
        If CDate(Format(dData, "dd/MM/yyyy") + " " + sHora) < Now Then
            Return DateAdd(DateInterval.Day, 1, CDate(Format(dData, "dd/MM/yyyy") + " " + sHora))
        Else
            Return CDate(Format(dData, "dd/MM/yyyy") + " " + sHora)
        End If
    End Function

    Public Function Data_HoraAnterior(ByVal dData As Date, ByVal sHora As String) As Date
        Return DateAdd(DateInterval.Day, -1, CDate(Format(dData, "dd/MM/yyyy") + " " + sHora))
    End Function

    Public Function SoNumero(ByVal sValor As String) As String
        Dim iCont As Integer
        Dim sAux As String = ""

        For iCont = 1 To Len(sValor)
            If IsNumeric(Mid(sValor, iCont, 1)) Then
                sAux = sAux & Mid(sValor, iCont, 1)
            End If
        Next

        Return sAux
    End Function

    Public Function SQL_FormatarLike(ByVal sCampo As String) As String
        Do While True
            If InStr(sCampo, " ") > 0 Then
                sCampo = Left(sCampo, InStr(sCampo, " ") - 1) & "%" & _
                             Mid(sCampo, InStr(sCampo, " ") + 1)
            Else
                Exit Do
            End If
        Loop

        Return QuotedStr("%" & Replace(Replace(Replace(UCase(sCampo), "'", "''"), "´", ""), "`", "") & "%")
    End Function
End Module