Module MOD_InscricaoEstadual
    'Public Sub FormataInscricao(ByVal pctxt_Inscricao As Control, ByVal pvstr_UF, ByVal mTpPessoa As String)
    '    If pctxt_Inscricao.RawData <> "ISENTO" Then
    '        pctxt_Inscricao.RawData = SoNumero(CStr(pctxt_Inscricao.RawData))
    '        Select Case pvstr_UF
    '            Case "AC"
    '                ' 99.99.9999-9
    '                pctxt_Inscricao.RawData = Left$(pctxt_Inscricao.RawData, 2) & _
    '                                          "." & Mid$(pctxt_Inscricao.RawData, 3, 2) & _
    '                                          "." & Mid$(pctxt_Inscricao.RawData, 5, 4) & _
    '                                          "-" & Right$(pctxt_Inscricao.RawData, 1)
    '            Case "AL"
    '                ' 24XNNNNND
    '                pctxt_Inscricao.RawData = pctxt_Inscricao.RawData
    '            Case "AP"
    '                ' 999999999
    '                pctxt_Inscricao.RawData = CStr(pctxt_Inscricao.RawData)
    '            Case "BA"
    '                ' 999999-99
    '                pctxt_Inscricao.RawData = Left$(pctxt_Inscricao.RawData, 6) & _
    '                                          "-" & Right$(pctxt_Inscricao.RawData, 2)
    '            Case "GO"
    '                ' 99.999.999-9
    '                pctxt_Inscricao.RawData = Left$(pctxt_Inscricao.RawData, 2) & _
    '                                          "." & Mid$(pctxt_Inscricao.RawData, 3, 3) & _
    '                                          "." & Mid$(pctxt_Inscricao.RawData, 6, 3) & _
    '                                          "-" & Right$(pctxt_Inscricao.RawData, 1)
    '            Case "MS"
    '                ' 999999999
    '                pctxt_Inscricao.RawData = pctxt_Inscricao.RawData
    '            Case "PI"
    '                ' 999999999
    '                pctxt_Inscricao.RawData = CStr(pctxt_Inscricao.RawData)
    '            Case "RS"
    '                ' 999/9999990
    '                pctxt_Inscricao.RawData = Left$(pctxt_Inscricao.RawData, 3) & _
    '                                          "/" & Mid$(pctxt_Inscricao.RawData, 4)
    '            Case "RO"
    '                ' 999999999
    '                pctxt_Inscricao.RawData = pctxt_Inscricao.RawData
    '            Case "SC"
    '                ' 999.999.999 ou
    '                ' 99.999.999.999
    '                If mTpPessoa = "F" Then
    '                    pctxt_Inscricao.RawData = Format$(pctxt_Inscricao.RawData, "@@.@@@.@@@.@@@")
    '                Else
    '                    pctxt_Inscricao.RawData = Left$(pctxt_Inscricao.RawData, 3) & _
    '                                              "." & Mid$(pctxt_Inscricao.RawData, 4, 3) & _
    '                                              "." & Right$(pctxt_Inscricao.RawData, 3)
    '                End If
    '            Case "SP"
    '                If mTpPessoa = "F" Then
    '                    ' P-01100424.3/002
    '                    pctxt_Inscricao.RawData = "P-" & Left$(pctxt_Inscricao.RawData, 8) & _
    '                                              "." & Mid$(pctxt_Inscricao.RawData, 9, 1) & _
    '                                              "/" & Right$(pctxt_Inscricao.RawData, 3)
    '                Else
    '                    ' 110.042.490.114
    '                    pctxt_Inscricao.RawData = Format$(pctxt_Inscricao.RawData, "@@@.@@@.@@@.@@@")
    '                End If
    '            Case "SE"
    '                ' 99999999-9
    '                pctxt_Inscricao.RawData = Format$(pctxt_Inscricao.RawData, "@@@@@@@@-@")
    '            Case "RJ"
    '                ' 99.999.99-9
    '                pctxt_Inscricao.RawData = Format$(pctxt_Inscricao.RawData, "@@.@@@.@@-@")
    '            Case "CE"
    '                ' 99999999-9
    '                pctxt_Inscricao.RawData = Format$(pctxt_Inscricao.RawData, "@@@@@@@@-@")
    '            Case "ES"
    '                ' 99999999-9
    '                pctxt_Inscricao.RawData = Format$(pctxt_Inscricao.RawData, "@@@@@@@@-@")
    '            Case "MT"
    '                ' NNNNNNNNNN-D
    '                pctxt_Inscricao.RawData = Format$(pctxt_Inscricao.RawData, "@@@@@@@@@@-@")
    '            Case "PA"
    '                ' 15-999999-9
    '                pctxt_Inscricao.RawData = Format$(pctxt_Inscricao.RawData, "@@-@@@@@@-@")
    '            Case "PB"
    '                ' 99999999-9
    '                pctxt_Inscricao.RawData = Format$(pctxt_Inscricao.RawData, "@@@@@@@@-@")
    '            Case "PR"
    '                ' NNN.NNNNN-DD
    '                pctxt_Inscricao.RawData = Format$(pctxt_Inscricao.RawData, "@@@.@@@@@-@@")
    '            Case "PE"
    '                ' 99.9.999.9999999-9
    '                pctxt_Inscricao.RawData = Format$(pctxt_Inscricao.RawData, "@@.@.@@@.@@@@@@@-@")
    '            Case "TO"
    '                ' 99 99 999999 9
    '                pctxt_Inscricao.RawData = Format$(pctxt_Inscricao.RawData, "@@ @@ @@@@@@ @")
    '            Case "AM"
    '                ' 99.999.999-9
    '                pctxt_Inscricao.RawData = Format$(pctxt_Inscricao.RawData, "@@.@@@.@@@-@")
    '            Case "DF"
    '                ' 999 99999 999-99
    '                pctxt_Inscricao.RawData = Format$(pctxt_Inscricao.RawData, "@@@ @@@@@ @@@-@@")
    '            Case "MG"
    '                ' 999.999.999/9999
    '                'If Len(SoNumero(CStr(frmPessoa!chkProdutorRural.Value))) <= 7 Then
    '                If mTpPessoa = "P" Then
    '                    pctxt_Inscricao.RawData = Format$(Val(pctxt_Inscricao.RawData), "000/0000")
    '                Else
    '                    pctxt_Inscricao.RawData = Left$(pctxt_Inscricao.RawData, 3) & _
    '                                              "." & Mid$(pctxt_Inscricao.RawData, 4, 3) & _
    '                                              "." & Mid$(pctxt_Inscricao.RawData, 7, 3) & _
    '                                              "/" & Right$(pctxt_Inscricao.RawData, 4)
    '                End If
    '            Case "RN"
    '                ' 99.999.999-9
    '                pctxt_Inscricao.RawData = Format$(pctxt_Inscricao.RawData, "@@.@@@.@@@-@")
    '            Case "MA"
    '                ' 12999999-9
    '                pctxt_Inscricao.RawData = Format$(pctxt_Inscricao.RawData, "@@@@@@@@-@")
    '            Case "RR"
    '                ' 240000000
    '                pctxt_Inscricao.RawData = Format$(pctxt_Inscricao.RawData, "@@@@@@@@@")
    '            Case Else
    '                Mensagem("Unidade da Federação não possui formatação. Verificar: " & pvstr_UF)
    '        End Select
    '    Else
    '        pctxt_Inscricao.RawData = pctxt_Inscricao.RawData
    '    End If
    'End Sub
    Private Function Modulo(ByVal pvstr_Inscricao As String, ByVal pvstr_Peso As String, _
    ByVal pvbool_Subtrai As Integer, ByVal pvint_Modulo As Integer) As String
        ' Função Módulo
        ' Passar como parâmetro a Inscrição Estadual
        ' e o peso (string com os valores da esquerda para a direita)
        ' Exemplo para peso: "9876543298765432"
        Dim i As Integer
        Dim a, b, c As Integer
        a = 0
        b = 0
        For i = 1 To Len(pvstr_Inscricao)
            a = Val(Mid$(pvstr_Peso, i, 1))
            c = Val(Mid$(pvstr_Inscricao, i, 1))
            b = b + (a * c)
        Next i
        b = pvint_Modulo - (b Mod pvint_Modulo)
        If pvbool_Subtrai Then
            If b >= 10 Then b = b - 10
        Else
            If b >= 10 Then b = 0
        End If
        Modulo = CStr(b)
    End Function
    Private Function ModuloAP(ByVal pvstr_Inscricao As String, ByVal pvstr_Peso As String, _
    ByVal pvbool_Subtrai As Integer) As String
        ' Função Módulo - Exclusivo para Amapá
        ' Passar como parâmetro a Inscrição Estadual
        ' e o peso (string com os valores da esquerda para a direita)
        ' Exemplo para peso: "9876543298765432"
        Dim i As Integer
        Dim a, b, c As Integer
        Dim p, D As Integer
        Select Case Val(pvstr_Inscricao)
            Case 3000001 To 3017000
                p = 5
                D = 0
            Case 3017001 To 3019022
                p = 9
                D = 1
            Case Else
                p = 0
                D = 0
        End Select
        a = 0
        b = 0
        For i = 1 To Len(pvstr_Inscricao)
            a = Val(Mid$(pvstr_Peso, i, 1))
            c = Val(Mid$(pvstr_Inscricao, i, 1))
            b = b + (a * c)
        Next i
        b = p + b
        b = 11 - (b Mod 11)
        If b = 10 Then b = 0
        If b = 11 Then b = D
        ModuloAP = CStr(b)
    End Function
    Private Function ModuloBA(ByVal pvstr_Inscricao As String, ByVal pvstr_Peso As String, _
                              ByVal pvint_Modulo As Integer, ByVal PrimeiroDigito As Boolean) As String
        Dim i As Integer
        Dim a, b, c As Integer
        a = 0
        b = 0
        For i = 1 To Len(pvstr_Inscricao)
            a = Val(Mid$(pvstr_Peso, i, 1))
            c = Val(Mid$(pvstr_Inscricao, i, 1))
            b = b + (a * c)
        Next i
        b = pvint_Modulo - (b Mod pvint_Modulo)
        If b >= 10 Then b = 0
        If pvint_Modulo = 11 Then
            If PrimeiroDigito = False Then
                If b = 0 Then  'Or b = 1 - Tem no site, mais da calculo errado
                    b = 0
                End If
            End If
        End If
        ModuloBA = CStr(b)
    End Function
    Private Function ModuloMG(ByVal pvstr_Inscricao As String, ByVal pvbool_Subtrai As Integer) As String
        ' Função de cálculo de módulo específico para Minas Gerais
        Dim lvint_Peso As Integer
        Dim i As Integer, ii As Integer
        Dim lvint_altera As Integer
        Dim lvint_Digito As Integer
        Dim lvint_Multiplicacao As Integer
        lvint_altera = 0
        lvint_Digito = 0
        ' Acrescenta um "0" após o código do município (3 posições iniciais)
        pvstr_Inscricao = Left$(pvstr_Inscricao, 3) & "0" & Mid$(pvstr_Inscricao, 4)
        'Calcula 1o dígito
        For i = 1 To Len(pvstr_Inscricao)
            lvint_Multiplicacao = Val(Mid$(pvstr_Inscricao, i, 1)) * (1 + Math.Abs(lvint_altera))
            For ii = 1 To Len(CStr(lvint_Multiplicacao))
                lvint_Digito = lvint_Digito + Val(Mid$(CStr(lvint_Multiplicacao), ii, 1))
            Next ii
            lvint_altera = Not lvint_altera
        Next i
        lvint_Digito = (((Int(lvint_Digito / 10)) + 1) * 10) - lvint_Digito
        If lvint_Digito >= 10 Then
            lvint_Digito = 0
        End If
        pvstr_Inscricao = pvstr_Inscricao & CStr((lvint_Digito))
        ' Retira o "0" inserido para o cálculo do primeiro dígito
        pvstr_Inscricao = Left$(pvstr_Inscricao, 3) & Mid$(pvstr_Inscricao, 5)
        ' Calcula 2o dígito
        lvint_Digito = 0
        lvint_Peso = 3
        For i = 1 To Len(pvstr_Inscricao)
            lvint_Digito = lvint_Digito + Val(Mid$(pvstr_Inscricao, i, 1)) * lvint_Peso
            lvint_Peso = lvint_Peso - 1
            If lvint_Peso < 2 Then lvint_Peso = 11
        Next i
        lvint_Digito = 11 - (lvint_Digito Mod 11)
        If lvint_Digito >= 10 Then lvint_Digito = 0
        pvstr_Inscricao = pvstr_Inscricao & CStr(lvint_Digito)
        ModuloMG = Right$(pvstr_Inscricao, 2)
    End Function
    Private Function ModuloRR(ByVal pvstr_Inscricao As String, ByVal pvstr_Peso As String, _
    ByVal pvint_Modulo As Integer) As String
        Dim i As Integer
        Dim a, b, c As Integer
        a = 0
        b = 0
        For i = 1 To Len(pvstr_Inscricao)
            a = Val(Mid$(pvstr_Peso, i, 1))
            c = Val(Mid$(pvstr_Inscricao, i, 1))
            b = b + (a * c)
        Next i
        b = (b Mod pvint_Modulo)
        If b >= 10 Then b = 0
        ModuloRR = CStr(b)
    End Function
    Private Function ModuloSP1(ByVal pvstr_Inscricao As String) As String
        ' Função Módulo
        ' Específico para São Paulo
        ' Calcula o primeiro dígito da Insc Est de Pessoa Jurídica,
        ' e o único dígito de Pessoa Física
        ' Passar como parâmetro a Inscrição Estadual
        Dim i As Integer
        Dim a, b, c As Integer
        a = 1
        b = 0
        For i = 1 To Len(pvstr_Inscricao)
            c = Val(Mid$(pvstr_Inscricao, i, 1))
            b = b + (a * c)
            a = a + 1
            If (a = 2) Or (a = 9) Then a = a + 1
        Next i
        b = (b Mod 11)
        ModuloSP1 = Right$(CStr(b), 1)
    End Function
    Private Function ModuloSP2(ByVal pvstr_Inscricao As String) As String
        ' Função Módulo
        ' Específico para São Paulo
        ' Calcula o segundo dígito da Insc Est de Pessoa Jurídica
        ' Passar como parâmetro a Inscrição Estadual
        Dim i As Integer
        Dim a, b, c As Integer
        a = 3
        b = 0
        For i = 1 To Len(pvstr_Inscricao)
            c = Val(Mid$(pvstr_Inscricao, i, 1))
            b = b + (a * c)
            a = a - 1
            If (a = 1) Then a = 10
        Next i
        b = (b Mod 11)
        ModuloSP2 = Right$(CStr(b), 1)
    End Function
    Private Function SoNumero(ByVal pvstr_Inscricao As String) As String
        Dim lvstr_Retorno As String
        lvstr_Retorno = ""
        Dim i As Integer
        Dim a As Integer
        For i = 1 To Len(pvstr_Inscricao)
            a = Asc(Mid$(pvstr_Inscricao, i, 1))
            If a < 48 Or a > 58 Then
                '
            Else
                lvstr_Retorno = lvstr_Retorno & Chr(a)
            End If
        Next i
        If lvstr_Retorno = "" Then
            SoNumero = 0
        Else
            SoNumero = CStr(lvstr_Retorno)
        End If
    End Function
    Private Function ValidaAC(ByVal lvstr_Inscricao As String) As Boolean
        Dim lvstr_InscricaoCalculada As String
        lvstr_Inscricao = StrZero(SoNumero(lvstr_Inscricao), 9)
        If Val(lvstr_Inscricao) <> 0 Then
            'Código da UF deve ser "01" e código do Município deve ser <> "00"
            If (Left$(lvstr_Inscricao, 2) <> "01") Or (Mid$(lvstr_Inscricao, 3, 2) = "00") Then
                ValidaAC = False
            Else
                lvstr_InscricaoCalculada = Left$(lvstr_Inscricao, 8)
                lvstr_InscricaoCalculada = lvstr_InscricaoCalculada & _
                                           Modulo(lvstr_InscricaoCalculada, "98765432", False, 11)
                If lvstr_InscricaoCalculada = lvstr_Inscricao Then
                    'Inscrição Válida
                    ValidaAC = True
                Else
                    'Inscrição Inválida
                    ValidaAC = False
                End If
            End If
        Else
            ValidaAC = False
        End If
    End Function
    Private Function ValidaAL(ByVal lvstr_Inscricao As String) As Boolean
        Dim lvstr_InscricaoCalculada As String
        lvstr_Inscricao = StrZero(SoNumero(lvstr_Inscricao), 9)
        If Val(lvstr_Inscricao) <> 0 Then
            If Left$(lvstr_Inscricao, 2) <> "24" Then 'Código da UF
                ValidaAL = False
            Else
                Select Case Val(Mid$(lvstr_Inscricao, 3, 1))
                    Case 0, 3, 5, 7, 8
                        lvstr_InscricaoCalculada = Left$(lvstr_Inscricao, 8)
                        lvstr_InscricaoCalculada = lvstr_InscricaoCalculada & _
                                                   Modulo(lvstr_InscricaoCalculada, "98765432", False, 11)
                        If lvstr_InscricaoCalculada = lvstr_Inscricao Then
                            'Inscrição Válida
                            ValidaAL = True
                        Else
                            'Inscrição Inválida
                            ValidaAL = False
                        End If
                    Case Else
                        'Inscrição Inválida
                        ValidaAL = False
                End Select
            End If
        Else
            'Inscrição Inválida
            ValidaAL = False
        End If
    End Function
    Private Function ValidaAM(ByVal lvstr_Inscricao As String) As Boolean
        Dim lvstr_InscricaoCalculada As String
        lvstr_Inscricao = StrZero(SoNumero(lvstr_Inscricao), 9)
        If Val(lvstr_Inscricao) <> 0 Then
            lvstr_InscricaoCalculada = Left$(lvstr_Inscricao, 8)
            lvstr_InscricaoCalculada = lvstr_InscricaoCalculada & _
                                       Modulo(lvstr_InscricaoCalculada, "98765432", False, 11)
            If lvstr_InscricaoCalculada = lvstr_Inscricao Then
                'Inscrição Válida
                ValidaAM = True
            Else
                'Inscrição Inválida
                ValidaAM = False
            End If
        Else
            'Inscrição Inválida
            ValidaAM = False
        End If
    End Function
    Private Function ValidaAP(ByVal lvstr_Inscricao As String) As Boolean
        Dim lvstr_InscricaoCalculada As String
        lvstr_Inscricao = StrZero(SoNumero(lvstr_Inscricao), 9)
        If Val(lvstr_Inscricao) <> 0 Then
            If Left$(lvstr_Inscricao, 2) <> "03" Then
                'Inscrição Inválida
                ValidaAP = False
            Else
                lvstr_InscricaoCalculada = Left$(lvstr_Inscricao, 8)
                lvstr_InscricaoCalculada = lvstr_InscricaoCalculada & _
                                           ModuloAP(lvstr_InscricaoCalculada, "98765432", False)
                If lvstr_InscricaoCalculada = lvstr_Inscricao Then
                    'Inscrição Válida
                    ValidaAP = True
                Else
                    'Inscrição Inválida
                    ValidaAP = False
                End If
            End If
        Else
            ValidaAP = False
        End If
    End Function
    Private Function ValidaBA(ByVal lvstr_Inscricao As String) As Boolean
        Dim lvstr_SegundoDigito As String
        Dim lvstr_InscricaoCalculada As String
        Dim lvstr_Peso As Integer
        lvstr_Inscricao = StrZero(SoNumero(lvstr_Inscricao), 8)
        If Val(lvstr_Inscricao) <> 0 Then
            lvstr_InscricaoCalculada = Left$(lvstr_Inscricao, 6)
            Select Case Val(Left$(lvstr_Inscricao, 1))
                Case 0, 1, 2, 3, 4, 5, 8
                    lvstr_Peso = 10
                Case Else
                    lvstr_Peso = 11
            End Select
            lvstr_SegundoDigito = ModuloBA(lvstr_InscricaoCalculada, "765432", lvstr_Peso, False)
            lvstr_InscricaoCalculada = Left$(lvstr_InscricaoCalculada, 6) & _
                                       ModuloBA(lvstr_InscricaoCalculada + lvstr_SegundoDigito, "8765432", lvstr_Peso, True) & _
                                       lvstr_SegundoDigito
            If lvstr_InscricaoCalculada = lvstr_Inscricao Then
                ValidaBA = True
            Else
                ValidaBA = False
            End If
        Else
            ValidaBA = False
        End If
    End Function
    Private Function ValidaCE(ByVal lvstr_Inscricao As String) As Boolean
        Dim lvstr_InscricaoCalculada As String
        lvstr_Inscricao = StrZero(SoNumero(lvstr_Inscricao), 9)
        If Val(lvstr_Inscricao) <> 0 Then
            lvstr_InscricaoCalculada = Left$(lvstr_Inscricao, 8)
            lvstr_InscricaoCalculada = lvstr_InscricaoCalculada & _
                                       Modulo(lvstr_InscricaoCalculada, "98765432", False, 11)
            If lvstr_InscricaoCalculada = lvstr_Inscricao Then
                ValidaCE = True
            Else
                ValidaCE = False
            End If
        Else
            ValidaCE = False
        End If
    End Function
    Private Function ValidaDF(ByVal lvstr_Inscricao As String) As Boolean
        Dim lvstr_InscricaoCalculada As String
        lvstr_Inscricao = StrZero(SoNumero(lvstr_Inscricao), 13)
        If (Val(lvstr_Inscricao) <> 0) Then
            lvstr_InscricaoCalculada = Left$(lvstr_Inscricao, 11)
            lvstr_InscricaoCalculada = lvstr_InscricaoCalculada & _
                                       Modulo(lvstr_InscricaoCalculada, "43298765432", False, 11)
            lvstr_InscricaoCalculada = lvstr_InscricaoCalculada & _
                                       Modulo(lvstr_InscricaoCalculada, "543298765432", False, 11)
            If lvstr_InscricaoCalculada = lvstr_Inscricao Then
                ValidaDF = True
            Else
                ValidaDF = False
            End If
        Else
            ValidaDF = False
        End If
    End Function
    Private Function ValidaES(ByVal lvstr_Inscricao As String) As Boolean
        Dim lvstr_InscricaoCalculada As String
        lvstr_Inscricao = StrZero(SoNumero(lvstr_Inscricao), 9)
        If Val(lvstr_Inscricao) <> 0 Then
            lvstr_InscricaoCalculada = Left$(lvstr_Inscricao, 8)
            lvstr_InscricaoCalculada = lvstr_InscricaoCalculada & _
                                       Modulo(lvstr_InscricaoCalculada, "98765432", False, 11)
            If lvstr_InscricaoCalculada = lvstr_Inscricao Then
                ValidaES = True
            Else
                ValidaES = False
            End If
        Else
            ValidaES = False
        End If
    End Function
    Private Function ValidaGO(ByVal lvstr_Inscricao As String) As Boolean
        Dim lvstr_InscricaoCalculada As String
        lvstr_Inscricao = StrZero(SoNumero(lvstr_Inscricao), 9)
        If Val(lvstr_Inscricao) <> 0 Then
            lvstr_InscricaoCalculada = Left$(lvstr_Inscricao, 8)
            lvstr_InscricaoCalculada = lvstr_InscricaoCalculada & _
                                       Modulo(lvstr_InscricaoCalculada, "98765432", False, 11)
            If lvstr_InscricaoCalculada = lvstr_Inscricao Then
                ValidaGO = True
            Else
                ValidaGO = False
            End If
        Else
            ValidaGO = False
        End If
    End Function
    Private Function ValidaMA(ByVal lvstr_Inscricao As String) As Boolean
        Dim lvstr_InscricaoCalculada As String
        lvstr_Inscricao = StrZero(SoNumero(lvstr_Inscricao), 9)
        If Val(lvstr_Inscricao) <> 0 Then
            lvstr_InscricaoCalculada = Left$(lvstr_Inscricao, 8)
            lvstr_InscricaoCalculada = lvstr_InscricaoCalculada & _
                                       Modulo(lvstr_InscricaoCalculada, "98765432", False, 11)
            If Left$(lvstr_InscricaoCalculada, 2) <> "12" Then
                ValidaMA = False
            Else
                If lvstr_InscricaoCalculada = lvstr_Inscricao Then
                    ValidaMA = True
                Else
                    ValidaMA = False
                End If
            End If
        Else
            ValidaMA = False
        End If
    End Function
    Private Function ValidaMG(ByVal lvstr_Inscricao As String) As Boolean
        Dim lvstr_InscricaoCalculada As String
        ' Se for Pessoa Física, não checa dígito, e grava como usuário digitou.
        lvstr_Inscricao = SoNumero(lvstr_Inscricao)
        If Val(lvstr_Inscricao) <> 0 Then
            If Len(lvstr_Inscricao) <= 7 Then
                lvstr_Inscricao = StrZero(SoNumero(lvstr_Inscricao), 7)
                ValidaMG = True
                Exit Function
            End If
            lvstr_Inscricao = StrZero(SoNumero(lvstr_Inscricao), 13)
            lvstr_InscricaoCalculada = Left$(lvstr_Inscricao, 11)
            lvstr_InscricaoCalculada = lvstr_InscricaoCalculada & _
                                       ModuloMG(lvstr_InscricaoCalculada, False)
            If lvstr_InscricaoCalculada = lvstr_Inscricao Then
                ValidaMG = True
            Else
                ValidaMG = False
            End If
        Else
            ValidaMG = False
        End If
    End Function
    Private Function ValidaMS(ByVal lvstr_Inscricao As String) As Boolean
        Dim lvstr_InscricaoCalculada As String
        lvstr_Inscricao = StrZero(SoNumero(lvstr_Inscricao), 9)
        If Val(lvstr_Inscricao) <> 0 Then
            If Left$(lvstr_Inscricao, 2) <> "28" Then
                ValidaMS = False
            Else
                lvstr_InscricaoCalculada = Left$(lvstr_Inscricao, 8)
                lvstr_InscricaoCalculada = lvstr_InscricaoCalculada & _
                                           Modulo(lvstr_InscricaoCalculada, "98765432", False, 11)
                If lvstr_InscricaoCalculada = lvstr_Inscricao Then
                    ValidaMS = True
                Else
                    ValidaMS = False
                End If
            End If
        Else
            ValidaMS = False
        End If
    End Function
    Private Function ValidaMT(ByVal lvstr_Inscricao As String) As Boolean
        Dim lvstr_InscricaoCalculada As String
        lvstr_Inscricao = StrZero(SoNumero(lvstr_Inscricao), 11)
        If Val(lvstr_Inscricao) <> 0 Then
            lvstr_InscricaoCalculada = Left$(lvstr_Inscricao, 10)
            lvstr_InscricaoCalculada = lvstr_InscricaoCalculada & _
                                       Modulo(lvstr_InscricaoCalculada, "3298765432", False, 11)
            If lvstr_InscricaoCalculada = lvstr_Inscricao Then
                ValidaMT = True
            Else
                ValidaMT = False
            End If
        Else
            ValidaMT = False
        End If
    End Function
    Private Function ValidaPA(ByVal lvstr_Inscricao As String) As Boolean
        Dim lvstr_InscricaoCalculada As String
        lvstr_Inscricao = StrZero(SoNumero(lvstr_Inscricao), 9)
        If (Left$(lvstr_Inscricao, 2) = "15") And (Val(lvstr_Inscricao) <> 0) Then
            lvstr_InscricaoCalculada = Left$(lvstr_Inscricao, 8)
            lvstr_InscricaoCalculada = lvstr_InscricaoCalculada & _
                                       Modulo(lvstr_InscricaoCalculada, "98765432", False, 11)
            If lvstr_InscricaoCalculada = lvstr_Inscricao Then
                ValidaPA = True
            Else
                ValidaPA = False
            End If
        Else
            ValidaPA = False
        End If
    End Function
    Private Function ValidaPB(ByVal lvstr_Inscricao As String) As Boolean
        Dim lvstr_InscricaoCalculada As String
        lvstr_Inscricao = StrZero(SoNumero(lvstr_Inscricao), 9)
        If Val(lvstr_Inscricao) <> 0 Then
            lvstr_InscricaoCalculada = Left$(lvstr_Inscricao, 8)
            lvstr_InscricaoCalculada = lvstr_InscricaoCalculada & _
                                       Modulo(lvstr_InscricaoCalculada, "98765432", False, 11)
            If lvstr_InscricaoCalculada = lvstr_Inscricao Then
                ValidaPB = True
            Else
                ValidaPB = False
            End If
        Else
            ValidaPB = False
        End If
    End Function
    Private Function ValidaPE(ByVal lvstr_Inscricao As String) As Boolean
        ' Formato: 99.9.999.9999999-9
        Dim lvstr_InscricaoCalculada As String
        lvstr_Inscricao = StrZero(SoNumero(lvstr_Inscricao), 14)
        If Val(lvstr_Inscricao) <> 0 Then
            lvstr_InscricaoCalculada = Left$(lvstr_Inscricao, 13)
            lvstr_InscricaoCalculada = lvstr_InscricaoCalculada & _
                                       Modulo(lvstr_InscricaoCalculada, "5432198765432", True, 11)
            If lvstr_InscricaoCalculada = lvstr_Inscricao Then
                ValidaPE = True
            Else
                ValidaPE = False
            End If
        Else
            ValidaPE = False
        End If
    End Function
    Private Function ValidaPI(ByVal lvstr_Inscricao As String) As Boolean
        Dim lvstr_InscricaoCalculada As String
        lvstr_Inscricao = StrZero(SoNumero(lvstr_Inscricao), 9)
        If Val(lvstr_Inscricao) <> 0 Then
            lvstr_InscricaoCalculada = Left$(lvstr_Inscricao, 8)
            lvstr_InscricaoCalculada = lvstr_InscricaoCalculada & _
                                       Modulo(lvstr_InscricaoCalculada, "98765432", False, 11)
            If lvstr_InscricaoCalculada = lvstr_Inscricao Then
                ValidaPI = True
            Else
                ValidaPI = False
            End If
        Else
            ValidaPI = False
        End If
    End Function
    Private Function ValidaPR(ByVal lvstr_Inscricao As String) As Boolean
        Dim lvdbl_Inscricao As Double
        Dim lvstr_InscricaoCalculada As String
        lvdbl_Inscricao = SoNumero(lvstr_Inscricao)
        lvstr_Inscricao = StrZero(SoNumero(lvstr_Inscricao), 10)
        If Val(lvstr_Inscricao) <> 0 Then
            lvstr_InscricaoCalculada = Left$(lvstr_Inscricao, 8)
            lvstr_InscricaoCalculada = lvstr_InscricaoCalculada & _
                                       Modulo(lvstr_InscricaoCalculada, "32765432", False, 11)
            lvstr_InscricaoCalculada = lvstr_InscricaoCalculada & _
                                       Modulo(lvstr_InscricaoCalculada, "432765432", False, 11)
            If Val(lvstr_InscricaoCalculada) = lvdbl_Inscricao Then
                ValidaPR = True
            Else
                ValidaPR = False
            End If
        Else
            ValidaPR = False
        End If
    End Function
    Private Function ValidaRJ(ByVal lvstr_Inscricao As String) As Boolean
        Dim lvstr_InscricaoCalculada As String
        lvstr_Inscricao = StrZero(SoNumero(lvstr_Inscricao), 8)
        If Val(lvstr_Inscricao) <> 0 Then
            lvstr_InscricaoCalculada = Left$(lvstr_Inscricao, 7)
            lvstr_InscricaoCalculada = lvstr_InscricaoCalculada & _
                                       Modulo(lvstr_InscricaoCalculada, "2765432", False, 11)
            If lvstr_InscricaoCalculada = lvstr_Inscricao Then
                ValidaRJ = True
            Else
                ValidaRJ = False
            End If
        Else
            ValidaRJ = False
        End If
    End Function
    Private Function ValidaRN(ByVal lvstr_Inscricao As String) As Boolean
        Dim lvstr_InscricaoCalculada As String
        lvstr_Inscricao = StrZero(SoNumero(lvstr_Inscricao), 9)
        If Val(lvstr_Inscricao) <> 0 Then
            lvstr_InscricaoCalculada = Left$(lvstr_Inscricao, 8)
            lvstr_InscricaoCalculada = lvstr_InscricaoCalculada & _
                                       Modulo(lvstr_InscricaoCalculada, "98765432", False, 11)
            If lvstr_InscricaoCalculada = lvstr_Inscricao Then
                ValidaRN = True
            Else
                ValidaRN = False
            End If
        Else
            ValidaRN = False
        End If
    End Function
    Private Function ValidaRO(ByVal lvstr_Inscricao As String) As Boolean
        Dim lvstr_InscricaoCalculada As String

        ValidaRO = False

        Select Case True
            Case InStr(1, lvstr_Inscricao, ".") = 4 And InStr(1, lvstr_Inscricao, "-") = 10
                lvstr_Inscricao = StrZero(SoNumero(lvstr_Inscricao), 9)
                If Val(lvstr_Inscricao) <> 0 Then
                    lvstr_InscricaoCalculada = Mid$(lvstr_Inscricao, 4, 5)
                    lvstr_InscricaoCalculada = Left$(lvstr_Inscricao, 3) & _
                                               lvstr_InscricaoCalculada & _
                                               Modulo(lvstr_InscricaoCalculada, "65432", True, 11)
                    If lvstr_InscricaoCalculada = lvstr_Inscricao Then
                        ValidaRO = True
                    End If
                End If
            Case InStr(1, lvstr_Inscricao, ".") = 0 And Mid(Right(lvstr_Inscricao, 2), 1, 1) = "-"
                lvstr_Inscricao = StrZero(SoNumero(lvstr_Inscricao), 14)
                If Val(lvstr_Inscricao) <> 0 Then
                    lvstr_InscricaoCalculada = Left$(lvstr_Inscricao, 13) & _
                                               Modulo(Left$(lvstr_Inscricao, 13), "6543298765432", True, 11)
                    If lvstr_InscricaoCalculada = lvstr_Inscricao Then
                        ValidaRO = True
                    End If
                End If
            Case Else
                ValidaRO = False
        End Select
    End Function
    Private Function ValidaRR(ByVal lvstr_Inscricao As String) As Boolean
        Dim lvint_Retorno As Integer
        Dim lvstr_InscricaoCalculada As String
        lvint_Retorno = False
        lvstr_Inscricao = StrZero(SoNumero(lvstr_Inscricao), 9)
        If (Val(lvstr_Inscricao) <> 0) And (Left$(lvstr_Inscricao, 2) = "24") Then
            lvstr_InscricaoCalculada = Left$(lvstr_Inscricao, 8)
            lvstr_InscricaoCalculada = lvstr_InscricaoCalculada & _
                                       ModuloRR(lvstr_InscricaoCalculada, "12345678", 9)
            If lvstr_InscricaoCalculada = lvstr_Inscricao Then
                ValidaRR = True
            Else
                ValidaRR = False
            End If
        Else
            ValidaRR = False
        End If
    End Function
    Private Function ValidaRS(ByVal lvstr_Inscricao As String) As Boolean
        Dim lvstr_InscricaoCalculada As String
        If Len(lvstr_Inscricao) < 10 Then
            ValidaRS = False
            Exit Function
        End If
        lvstr_Inscricao = StrZero(SoNumero(lvstr_Inscricao), 10)
        If Val(lvstr_Inscricao) <> 0 Then
            lvstr_InscricaoCalculada = Left$(lvstr_Inscricao, 9)
            lvstr_InscricaoCalculada = lvstr_InscricaoCalculada & _
                                       Modulo(lvstr_InscricaoCalculada, "298765432", False, 11)
            If lvstr_InscricaoCalculada = lvstr_Inscricao Then
                ValidaRS = True
            Else
                ValidaRS = False
            End If
        Else
            ValidaRS = False
        End If
    End Function
    Private Function ValidaSC(ByVal lvstr_Inscricao As String, ByVal mTpPessoa As String, _
                      ByVal mProd As Boolean) As Boolean
        Dim lvstr_InscricaoCalculada As String = ""
        If (mTpPessoa = "F") And (mProd) Then
            lvstr_Inscricao = StrZero(SoNumero(lvstr_Inscricao), 11)
        ElseIf mTpPessoa = "J" Then
            lvstr_Inscricao = StrZero(SoNumero(lvstr_Inscricao), 9)
        Else
            ValidaSC = True
            Exit Function
        End If
        If Val(lvstr_Inscricao) <> 0 Then
            If mTpPessoa = "F" Then
                lvstr_InscricaoCalculada = Left$(lvstr_Inscricao, 10)
                lvstr_InscricaoCalculada = lvstr_InscricaoCalculada & _
                                           Modulo(lvstr_InscricaoCalculada, "3298765432", False, 11)
            ElseIf mTpPessoa = "J" Then
                lvstr_InscricaoCalculada = Left$(lvstr_Inscricao, 8)
                lvstr_InscricaoCalculada = lvstr_InscricaoCalculada & _
                                           Modulo(lvstr_InscricaoCalculada, "98765432", False, 11)
            End If
            If lvstr_InscricaoCalculada = lvstr_Inscricao Then
                ValidaSC = True
            Else
                ValidaSC = False
            End If
        Else
            ValidaSC = False
        End If
    End Function
    Private Function ValidaSE(ByVal lvstr_Inscricao As String) As Boolean
        Dim lvstr_InscricaoCalculada As String
        lvstr_Inscricao = StrZero(SoNumero(lvstr_Inscricao), 9)
        If Val(lvstr_Inscricao) <> 0 Then
            lvstr_InscricaoCalculada = Left$(lvstr_Inscricao, 8)
            lvstr_InscricaoCalculada = lvstr_InscricaoCalculada & _
                                       Modulo(lvstr_InscricaoCalculada, "98765432", False, 11)
            If lvstr_InscricaoCalculada = lvstr_Inscricao Then
                ValidaSE = True
            Else
                ValidaSE = False
            End If
        Else
            ValidaSE = False
        End If
    End Function
    Private Function ValidaSP(ByVal lvstr_Inscricao As String, ByVal mTpPessoa As String, _
                      ByVal mProd As Boolean) As Boolean
        ' São Paulo possui dois cálculos diferentes
        ' de Inscrição Estadual
        Dim lvstr_InscricaoCalculada As String
        If (mTpPessoa = "F") And (mProd) Then
            ' Produtor Rural
            If Left$(lvstr_Inscricao, 1) <> "P" Then
                ValidaSP = False
            Else
                lvstr_Inscricao = StrZero(SoNumero(lvstr_Inscricao), 12)
                If Val(lvstr_Inscricao) <> 0 Then
                    lvstr_InscricaoCalculada = Left$(lvstr_Inscricao, 8)
                    lvstr_InscricaoCalculada = lvstr_InscricaoCalculada & _
                                               ModuloSP1(lvstr_InscricaoCalculada)
                    lvstr_InscricaoCalculada = lvstr_InscricaoCalculada & _
                                               Right$(lvstr_Inscricao, 3)
                    If lvstr_InscricaoCalculada = lvstr_Inscricao Then
                        ValidaSP = True
                    Else
                        ValidaSP = False
                    End If
                Else
                    ValidaSP = False
                End If
            End If
        ElseIf mTpPessoa = "J" Then
            lvstr_Inscricao = StrZero(SoNumero(lvstr_Inscricao), 12)
            If Val(lvstr_Inscricao) <> 0 Then
                lvstr_InscricaoCalculada = Left$(lvstr_Inscricao, 8)
                lvstr_InscricaoCalculada = lvstr_InscricaoCalculada & _
                                           ModuloSP1(lvstr_InscricaoCalculada)
                lvstr_InscricaoCalculada = lvstr_InscricaoCalculada & _
                                           Mid$(lvstr_Inscricao, 10, 2)
                lvstr_InscricaoCalculada = lvstr_InscricaoCalculada & _
                                           ModuloSP2(lvstr_InscricaoCalculada)
                If lvstr_InscricaoCalculada = lvstr_Inscricao Then
                    ValidaSP = True
                Else
                    ValidaSP = False
                End If
            Else
                ValidaSP = False
            End If
        Else
            ValidaSP = True
        End If
    End Function
    Private Function ValidaTO(ByVal lvstr_Inscricao As String) As Boolean
        Dim lvstr_InscricaoCalculada As String
        Dim lvstr_TipoProdutor As String
        lvstr_Inscricao = StrZero(SoNumero(lvstr_Inscricao), 11)
        lvstr_TipoProdutor = Mid$(lvstr_Inscricao, 3, 2)
        If Val(lvstr_Inscricao) <> 0 Then
            Select Case lvstr_TipoProdutor
                Case "01", "02", "03", "99"
                    lvstr_Inscricao = Left$(lvstr_Inscricao, 2) & Mid$(lvstr_Inscricao, 5)
                    lvstr_InscricaoCalculada = Left$(lvstr_Inscricao, 8)
                    lvstr_InscricaoCalculada = lvstr_InscricaoCalculada & _
                                               Modulo(lvstr_InscricaoCalculada, "98765432", False, 11)
                    lvstr_Inscricao = Left$(lvstr_Inscricao, 2) & _
                                      lvstr_TipoProdutor + Mid$(lvstr_Inscricao, 5)
                    lvstr_InscricaoCalculada = Left$(lvstr_InscricaoCalculada, 2) & _
                                               lvstr_TipoProdutor + Mid$(lvstr_InscricaoCalculada, 5)
                    If lvstr_InscricaoCalculada = lvstr_Inscricao Then
                        ValidaTO = True
                    Else
                        ValidaTO = False
                    End If
                Case Else
                    ValidaTO = False
            End Select
        Else
            ValidaTO = False
        End If
    End Function
    Public Function Valida_InscricaoEstadual(ByVal pvstr_UF As String, ByVal mIE As String) As Boolean
        If (Left$(mIE, 5) = "ISENT") Then
            Return True
        ElseIf (mIE = "AGUARDANDO") Then
            Return True
        Else
            Select Case pvstr_UF
                Case "AC"
                    Return ValidaAC(mIE)
                Case "AL"
                    Return ValidaAL(mIE)
                Case "AP"
                    Return ValidaAP(mIE)
                Case "BA"
                    Return ValidaBA(mIE)
                Case "CE"
                    Return ValidaCE(mIE)
                Case "GO"
                    Return ValidaGO(mIE)
                Case "MA"
                    Return ValidaMA(mIE)
                Case "MS"
                    Return ValidaMS(mIE)
                Case "PI"
                    Return ValidaPI(mIE)
                Case "RS"
                    Return ValidaRS(mIE)
                Case "RO"
                    Return ValidaRO(mIE)
                Case "SC"
                    Return ValidaSC(mIE, "J", False)
                Case "SP"
                    Return ValidaSP(mIE, "J", False)
                Case "SE"
                    Return ValidaSE(mIE)
                Case "RJ"
                    Return ValidaRJ(mIE)
                Case "ES"
                    Return ValidaES(mIE)
                Case "MT"
                    Return ValidaMT(mIE)
                Case "PA"
                    Return ValidaPA(mIE)
                Case "PB"
                    Return ValidaPB(mIE)
                Case "PR"
                    Return ValidaPR(mIE)
                Case "PE"
                    Return ValidaPE(mIE)
                Case "TO"
                    Return ValidaTO(mIE)
                Case "AM"
                    Return ValidaAM(mIE)
                Case "DF"
                    Return ValidaDF(mIE)
                Case "MG"
                    Return ValidaMG(mIE)
                Case "RN"
                    Return ValidaRN(mIE)
                Case "RR"
                    Return ValidaRR(mIE)
                Case Else
                    Return False
            End Select
        End If
    End Function
End Module
