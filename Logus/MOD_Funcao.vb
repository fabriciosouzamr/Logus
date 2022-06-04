Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Windows.Forms
Imports Infragistics.Win
Imports System
Imports System.Math
Imports System.Reflection
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Threading
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinEditors

Module Funcao
    Public Declare Function WNetAddConnection2 Lib "mpr.dll" Alias "WNetAddConnection2A" (ByRef lpNetResource As NETRESOURCE, ByVal lpPassword As String, ByVal lpUserName As String, ByVal dwFlags As Integer) As Integer
    Public Declare Function WNetCancelConnection2 Lib "mpr" Alias "WNetCancelConnection2A" (ByVal lpName As String, ByVal dwFlags As Integer, ByVal fForce As Integer) As Integer

    Public Structure NETRESOURCE
        Public dwScope As Integer
        Public dwType As Integer
        Public dwDisplayType As Integer
        Public dwUsage As Integer
        Public lpLocalName As String
        Public lpRemoteName As String
        Public lpComment As String
        Public lpProvider As String
    End Structure

    Public Const ForceDisconnect As Integer = 1
    Public Const RESOURCETYPE_DISK As Long = &H1

    Dim Debug_EmDebug As Boolean = False

    Public Function AVI_AbrirTela() As System.Windows.Forms.Form
        Dim oForm As New frmAvi

        oForm.StartPosition = FormStartPosition.CenterScreen
        oForm.BackColor = System.Drawing.Color.FromArgb(CType(230, Byte), CType(238, Byte), CType(249, Byte))
        oForm.ShowInTaskbar = False
        oForm.Show()
        oForm.acFilme.Play()
        oForm.Refresh()

        Return oForm
    End Function

    Public Function Control_FormParent(ByVal oObjeto As Object) As System.Windows.Forms.Form
        Dim oForm As System.Windows.Forms.Form = Nothing

        If oObjeto.Parent Is Nothing Then
            If oObjeto.GetType.BaseType.Name = "Form" Then
                oForm = oObjeto
            End If
        Else
            Do While True
                If oObjeto.Parent Is Nothing Then
                    Exit Do
                End If
                If oObjeto.Parent.GetType.BaseType.Name = "Form" Then
                    oForm = oObjeto.Parent
                    Exit Do
                Else
                    oObjeto = oObjeto.Parent
                End If
            Loop
        End If

        Return oForm
    End Function

    Public Sub AVI_Carregar(Optional ByVal oFormChamado As Object = Nothing)
        oFormChamado = Control_FormParent(oFormChamado)
        If oFormChamado Is Nothing Then Exit Sub

        Dim oControle As New usrAVI
        Dim iCont As Integer = 0
        Dim bAchou As Boolean = False

        oControle.Name = "usrAVI"

        For iCont = 0 To oFormChamado.Controls.Count - 1
            If oFormChamado.Controls(iCont).GetType.Name Is oControle.GetType.Name Then
                oControle = oFormChamado.Controls(iCont)
                bAchou = True
                Exit For
            End If
        Next

        If Not bAchou Then
            oFormChamado.Controls.Add(oControle)
        End If

        oControle.Left = ((oFormChamado.ClientSize.Width - oControle.Width) / 2)
        oControle.Top = ((oFormChamado.ClientSize.Height - oControle.Height) / 2)
        oControle.Inicializar()
        oControle.BringToFront()
        oControle.Refresh()
    End Sub

    Public Sub AVI_Fechar(Optional ByVal oFormChamado As Object = Nothing)
        oFormChamado = Control_FormParent(oFormChamado)
        If oFormChamado Is Nothing Then Exit Sub

        Dim oControle As usrAVI = Nothing
        Dim iCont As Integer = 0

        For iCont = 0 To oFormChamado.Controls.Count - 1
            If oFormChamado.Controls(iCont).GetType.Name = "usrAVI" Then
                oControle = oFormChamado.Controls(iCont)
                oControle.Dispose()
                oControle = Nothing
                Exit For
            End If
        Next

        oFormChamado.Enabled = True

        'Limpeza de memoria
        MemoryManagement.FlushMemory()
    End Sub

    Public Function String_Porcentagem(ByVal Valor As Double) As String
        Return FormatPercent(Valor / 100, 2)
    End Function

    Public Sub AVI_FechaTela(ByVal oForm As System.Windows.Forms.Form)
        If Not oForm Is Nothing Then
            oForm.Dispose()
            oForm = Nothing
        End If
    End Sub

    Public Function NormalDataToJulian(ByVal datDate As Date) As Long
        Dim iDays As Integer

        iDays = DateDiff("d", DateSerial(datDate.Year, 1, 1), datDate) + 1

        NormalDataToJulian = CLng("1" & Format(datDate, "yy") & Format(iDays, "000"))
    End Function

    Public Function CalculaTamanhoArquivo(ByVal lTamanho As Long) As String
        Dim Resultado As Integer
        Dim Unidade As String

        Resultado = lTamanho / 1024
        Unidade = "KB"

        If Resultado > 1024 Then
            Resultado = Resultado / 1024
            Unidade = "MB"
        End If

        Return CStr(FC_Round(Resultado, 1)) & " " & Unidade
    End Function

    Public Sub SetWorkingMemory(ByVal lnMaxSize As System.IntPtr, ByVal lnMinSize As System.IntPtr)
        Try
            Dim loProcess As System.Diagnostics.Process = System.Diagnostics.Process.GetCurrentProcess()

            loProcess.MaxWorkingSet = lnMaxSize
            loProcess.MinWorkingSet = lnMinSize

        Catch
            'do nothing. this only works on a machine_ onwhich the user has admin rights 
        End Try
    End Sub

    Public Function FC_Round(ByVal Numero As Double, ByVal Casa As Integer) As Double
        If Casa > 0 Then
            FC_Round = CDbl(Format(Numero, "#,##0." & StrZero(0, Casa)))
        Else
            FC_Round = CDbl(Format(Numero, "#,##0"))
        End If
    End Function

    Public Function StrZero(ByVal Numero As Long, ByVal Tamanho As Long) As String
        Dim x As String
        If Numero = Nothing Then
            StrZero = StrReplicate(Tamanho, "0")
        Else
            x = CStr(Numero)
            If Len(x) > Tamanho Then
                Tamanho = Len(x)
            End If
            x = Format$(Numero, StrReplicate(Tamanho, "0"))
            StrZero = StrReplicate(Tamanho - Len(x), "0") & x
        End If
    End Function

    Public Function Extenso(ByVal Valor As Double, _
                            Optional ByVal MoedaPlural As String = "reais", _
                            Optional ByVal MoedaSingular As String = "real") As String
        Dim StrValor As String, Negativo As Boolean
        Dim Buf As String, Parcial As Integer
        Dim Posicao As Integer, Unidades
        Dim Dezenas, Centenas, PotenciasSingular
        Dim PotenciasPlural

        Negativo = (Valor < 0)
        Valor = Abs(CDec(Valor))
        If Valor Then
            Unidades = GerarArray(vbNullString, "Um", "Dois", "Três", "Quatro", "Cinco", _
                        "Seis", "Sete", "Oito", "Nove", "Dez", "Onze", "Doze", "Treze", _
                        "Quatorze", "Quinze", "Dezesseis", "Dezessete", "Dezoito", "Dezenove")
            Dezenas = GerarArray(vbNullString, vbNullString, "Vinte", "Trinta", "Quarenta", _
                        "Cinqüenta", "Sessenta", "Setenta", "Oitenta", "Noventa")
            Centenas = GerarArray(vbNullString, "Cento", "Duzentos", "Trezentos", "Quatrocentos", _
                        "Quinhentos", "Seiscentos", "Setecentos", "Oitocentos", "Novecentos")
            PotenciasSingular = GerarArray(vbNullString, " Mil", " Milhão", " Bilhão", " Trilhão", " Quatrilhão")
            PotenciasPlural = GerarArray(vbNullString, " Mil", " Milhões", " Bilhões", " Trilhões", " Quatrilhões")

            StrValor = Left(Format(Valor, StrReplicate(18, "0") & ".000"), 18)

            For Posicao = 1 To 18 Step 3
                Parcial = Val(Mid(StrValor, Posicao, 3))
                If Parcial Then
                    If Parcial = 1 Then
                        Buf = "Um" & PotenciasSingular((18 - Posicao) \ 3)
                    ElseIf Parcial = 100 Then
                        Buf = "Cem" & PotenciasSingular((18 - Posicao) \ 3)
                    Else
                        Buf = Centenas(Parcial \ 100)
                        Parcial = Parcial Mod 100
                        If Parcial <> 0 And Buf <> vbNullString Then
                            Buf = Buf & " e "
                        End If
                        If Parcial < 20 Then
                            Buf = Buf & Unidades(Parcial)
                        Else
                            Buf = Buf & Dezenas(Parcial \ 10)
                            Parcial = Parcial Mod 10
                            If Parcial <> 0 And Buf <> vbNullString Then
                                Buf = Buf & " e "
                            End If
                            Buf = Buf & Unidades(Parcial)
                        End If
                        Buf = Buf & PotenciasPlural((18 - Posicao) \ 3)
                    End If
                    If Buf <> vbNullString Then
                        If Extenso <> vbNullString Then
                            Parcial = Val(Mid(StrValor, Posicao, 3))
                            If Posicao = 16 And (Parcial < 100 Or (Parcial Mod 100) = 0) Then
                                Extenso = Extenso & " e "
                            Else
                                Extenso = Extenso & ", "
                            End If
                        End If
                        Extenso = Extenso & Buf
                    End If
                End If
            Next
            If Extenso <> vbNullString Then
                If Negativo Then
                    Extenso = "Menos " & Extenso
                End If
                If Int(Valor) = 1 Then
                    Extenso = Extenso & " " & MoedaSingular
                Else
                    Extenso = Extenso & " " & MoedaPlural
                End If
            End If
            Parcial = Int((Valor - Int(Valor)) * 100 + 0.1)
            If Parcial Then
                Buf = Extenso(Parcial, "Centavos", "Centavo")
                If Extenso <> vbNullString Then
                    Extenso = Extenso & " e "
                End If
                Extenso = Extenso & Buf
            End If
        End If
        Return Extenso
    End Function

    Public Function VerMes(ByVal mData As String) As String
        VerMes = ""
        If Not IsDate(mData) Then Exit Function
        Dim Mes As String = ""

        Select Case CDate(mData).Month
            Case 1
                Mes = "Janeiro"
            Case 2
                Mes = "Fevereiro"
            Case 3
                Mes = "Março"
            Case 4
                Mes = "Abril"
            Case 5
                Mes = "Maio"
            Case 6
                Mes = "Junho"
            Case 7
                Mes = "Julho"
            Case 8
                Mes = "Agosto"
            Case 9
                Mes = "Setembro"
            Case 10
                Mes = "Outubro"
            Case 11
                Mes = "Novembro"
            Case 12
                Mes = "Dezembro"
        End Select
        VerMes = Mes
    End Function

    Public Function StrReplicate(ByVal Numero As Integer, ByVal Caracter As String) As String
        Dim iCont As Integer
        Dim sAux As String = ""

        For iCont = 1 To Numero
            sAux = sAux & Caracter
        Next

        Return Microsoft.VisualBasic.Left(sAux, Numero * Len(Caracter))
    End Function

    Public Function Nome_Tratar(ByVal sNome As String, _
                                Optional ByVal EMail As Boolean = False, _
                                Optional ByVal Upper As Boolean = True) As String
        Dim iCont As Integer = 0
        Dim sAux As String = ""

        If Upper Then
            sNome = UCase(Trim(sNome))
        Else
            sNome = Trim(sNome)
        End If

        If Not EMail Then sNome = Replace(sNome, " ", "_")

        For iCont = 1 To Len(sNome)
            If InStr("ÀÁÂÃÄÅ", UCase(Mid(sNome, iCont, 1))) > 0 Then
                sAux = sAux & "A"
            ElseIf InStr("Ç", UCase(Mid(sNome, iCont, 1))) > 0 Then
                sAux = sAux & "C"
            ElseIf InStr("ÈÉÊË", UCase(Mid(sNome, iCont, 1))) > 0 Then
                sAux = sAux & "E"
            ElseIf InStr("ÌÍÎÏ", UCase(Mid(sNome, iCont, 1))) > 0 Then
                sAux = sAux & "I"
            ElseIf InStr("ÒÓÔÕÖ", UCase(Mid(sNome, iCont, 1))) > 0 Then
                sAux = sAux & "O"
            ElseIf InStr("ÙÚÛÜ", UCase(Mid(sNome, iCont, 1))) > 0 Then
                sAux = sAux & "U"
            Else
                sAux = sAux & Mid(sNome, iCont, 1)
            End If
        Next

        Return sAux
    End Function

    Public Function VerificarUsuario(ByVal CD_USUARIO As String, ByVal oTipoValidacaoUsuario As TipoValidacaoUsuario) As Boolean
        Dim bOk As Boolean = True

        If sAcesso_UsuarioLogado <> CD_USUARIO And Not sAcesso_UsuarioLogado Is Nothing Then
            Select Case oTipoValidacaoUsuario
                Case TipoValidacaoUsuario._UsuarioLogado
                    Msg_Mensagem("O usuário informado é diferente do usuário logado no sistema.")
                Case Else
                    Msg_Mensagem("o sistema esta sendo usado por " & sAcesso_NomeUsuarioLogado & " só ele poderá desbloquear o sistema.")
            End Select

            bOk = False
        End If

        Return bOk
    End Function

    Public Function SEC_ValidarUsuario(Optional ByVal oTipoValidacaoUsuario As TipoValidacaoUsuario = TipoValidacaoUsuario._Acesso, _
                                       Optional ByVal UsaFinger As Boolean = True) As Boolean
        Dim bUtilizaFinger As Boolean
        Dim bOk As Boolean = False

        'Verifica se será usado o Finger - Início
        If UsaFinger = False Then
            bUtilizaFinger = False
        Else
            Try
                Dim oForm_Finger As New frmAcesso_Senha_Finger

                oForm_Finger.Dispose()
                oForm_Finger = Nothing

                bUtilizaFinger = True
            Catch ex As Exception
                bUtilizaFinger = False
            End Try
        End If
        'Verifica se será usado o Finger - Fim

        Try
            If bUtilizaFinger Then
                Dim oForm As New frmAcesso_Senha_Finger
                oForm.TipoValidacaoUsuario = oTipoValidacaoUsuario
                Form_Show(Nothing, oForm, True)
                bOk = oForm.Acesso_Valido
                oForm.Dispose()
                oForm = Nothing
            Else
                Dim oForm As New frmAcesso_Senha
                oForm.TipoValidacaoUsuario = oTipoValidacaoUsuario
                Form_Show(Nothing, oForm, True)
                bOk = oForm.Acesso_Valido
                oForm.Dispose()
                oForm = Nothing
            End If
        Catch ex As Exception
            Msg_Mensagem(ex.Message)
            bOk = False
        End Try

        Return bOk
    End Function

    Public Sub SEC_UsuarioAtivo_SistemasAtivo(ByVal CD_USUARIO As String)
        Dim SqlText As String

        'Ativa/Inativa usuário segundo sistemas ativos
        SqlText = "SELECT COUNT(*) FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO_SISTEMA" & _
                  " WHERE CD_USUARIO = " & QuotedStr(CD_USUARIO) & _
                    " AND IC_ATIVO = " & QuotedStr(cnt_Usuario_Status_Ativo)

        SqlText = "UPDATE " & sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO SET IC_ATIVO = " & IIf(DBQuery_ValorUnico(SqlText) = 0, "'N'", "'S'") & _
                  " WHERE CD_USUARIO = " & QuotedStr(CD_USUARIO)
        DBExecutar(SqlText)
    End Sub

    Public Sub Form_CrystalReport_AjustarView(ByVal oForm As Form, ByVal oView As CrystalReportViewer)
        oView.Height = oForm.ClientSize.Height - oView.Top - 8
        oView.Width = oForm.ClientSize.Width - 16

        oView.ShowCloseButton = True
        oView.ShowGroupTreeButton = True
        oView.ShowParameterPanelButton = False
        oView.ToolPanelWidth = 150
        oView.EnableRefresh = False
    End Sub

    Public Sub MaskEditor(ByVal oMask As UltraWinMaskedEdit.UltraMaskedEdit, ByVal sMascara As String)
        oMask.InputMask = sMascara
    End Sub

    Public Function Formatar(ByVal Texto As String, ByVal Expressao As String)
        Dim iCont As Integer = 0
        Dim Indice As Integer = 0
        Dim sAux As String = ""

        For iCont = 1 To Len(Expressao)
            If Mid(Expressao, iCont, 1) = "@" Then
                Indice = Indice + 1

                If Len(Texto) < Indice Then
                    sAux = sAux + " "
                Else
                    sAux = sAux + Mid(Texto, Indice, 1)
                End If
            Else
                sAux = sAux + Mid(Expressao, iCont, 1)
            End If
        Next

        Return sAux
    End Function

    Public Function ConvTextoParaBoolean(ByVal Texto As String) As Boolean
        Return ((Trim(UCase(Texto)) = "SIM") Or (Trim(UCase(Texto)) = "S"))
    End Function

    Public Function Data_ValidarPeriodo(ByVal Termo As String, _
                                        ByVal DataIni As String, _
                                        ByVal DataFim As String, _
                                        ByVal Obrigatorio As Boolean, _
                                        Optional ByVal ExibirMensagem As Boolean = True, _
                                        Optional ByVal MenorDataHoje As Boolean = True) As Boolean
        If Not IsDate(DataIni) And Obrigatorio Then
            If ExibirMensagem Then Msg_Mensagem("Informe a data " & Termo & " inicial.")
            Exit Function
        End If
        If Not IsDate(DataFim) And Obrigatorio Then
            If ExibirMensagem Then Msg_Mensagem("Informe a data " & Termo & " final.")
            Exit Function
        End If

        If IsDate(DataIni) And MenorDataHoje Then
            If DataIni > Now Then
                If ExibirMensagem Then Msg_Mensagem("A data inicial " & Termo & " tem que ser inferior ou igual a data de hoje.")
                Exit Function
            End If
        End If

        If IsDate(DataIni) And IsDate(DataFim) Then
            If CDate(DataIni) > CDate(DataFim) Then
                If ExibirMensagem Then Msg_Mensagem("A " & Termo & " inicial não pode ser maior que a " & Termo & " final.")
                Exit Function
            End If
        End If

        Return True
    End Function

    Public Function Data_PrimeiroDiaSemana(ByVal Data As Date, _
                                           Optional ByVal SemanaMes As Boolean = False) As Date
        Dim dAux As Date

        dAux = Data.AddDays((DatePart(DateInterval.Weekday, Data) * -1) + 1)

        If SemanaMes And dAux < New Date(Data.Year, Data.Month, 1) Then
            dAux = New Date(Data.Year, Data.Month, 1)
        End If

        Return dAux
    End Function

    Public Function Data_UltimoDiaSemana(ByVal Data As Date, _
                                         ByVal DataMaxima As Date, _
                                         Optional ByVal SemanaMes As Boolean = False) As Date
        Dim dAux As Date

        dAux = Data.AddDays(7 - DatePart(DateInterval.Weekday, Data, FirstDayOfWeek.Sunday))

        If dAux > DataMaxima Then
            dAux = DataMaxima
        End If

        Return dAux
    End Function

    Public Function Data_SegundoHora_String(ByVal Segundos As Long) As String
        Dim sHora As String

        Segundos = Math.Abs(Segundos)

        'Hora
        sHora = StrZero(Int(Segundos / 3600), 2)
        Segundos = Segundos - (Int(Segundos / 3600) * 3600)
        'Minuto
        sHora = sHora & ":" & StrZero(Int(Segundos / 60), 2)
        Segundos = Segundos - (Int(Segundos / 60) * 60)
        'Segundo
        sHora = sHora & ":" & StrZero(Segundos, 2)

        Return sHora
    End Function

    Public Sub Data_ValidarDiaMaiorHoje(ByVal TxtData As UltraWinEditors.UltraDateTimeEditor, _
                                        ByVal maxDate As Date)
        Dim ultraValidator1 As New Misc.UltraValidator

        ultraValidator1.ErrorAppearance.BackColor = Color.Red
        ultraValidator1.ErrorAppearance.ForeColor = Color.White

        Dim minDate As Date = New Date(1900, 1, 1)

        If maxDate = New Date(1900, 1, 1) Then
            maxDate = Now.Date
        End If

        ultraValidator1.SetValidationSettings(TxtData, Nothing)

        ' Pega ValidationSettings da data. 
        Dim validationSettings As ValidationSettings = ultraValidator1.GetValidationSettings(TxtData)
        Dim rangeCondition As RangeCondition = CType(validationSettings.Condition, RangeCondition)
        rangeCondition = New RangeCondition(minDate, maxDate, GetType(DateTime))
        validationSettings.NotificationSettings.Caption = "Data Invalida"
        validationSettings.Condition = rangeCondition
        validationSettings.RetainFocusOnError = True
        validationSettings.NotificationSettings.Action = NotificationAction.BalloonTip

        ultraValidator1.Validate(TxtData)
    End Sub

    Public Sub ComboBox_Carregar_SEC_TipoAcesso(ByRef oCombo As System.Windows.Forms.ComboBox, _
                                      Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT CD_TIPOACESSO, NO_TIPOACESSO" & _
                  " FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_TIPOACESSO" & _
                  " ORDER BY NO_TIPOACESSO"

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_SEC_TipoAcao(ByRef oCombo As System.Windows.Forms.ComboBox)
        Dim oRow As DataRow
        Dim oDataCombo As New DataTable
        oDataCombo.Columns.Add(0)
        oDataCombo.Columns.Add(1)

        oRow = oDataCombo.NewRow
        oRow(0) = "-"
        oRow(1) = ""
        oDataCombo.Rows.Add(oRow)

        oRow = oDataCombo.NewRow
        oRow(0) = "M"
        oRow(1) = "Acesso a tela"
        oDataCombo.Rows.Add(oRow)

        oRow = oDataCombo.NewRow
        oRow(0) = "C"
        oRow(1) = "Configuração"
        oDataCombo.Rows.Add(oRow)

        oRow = oDataCombo.NewRow
        oRow(0) = "P"
        oRow(1) = "Permissão"
        oDataCombo.Rows.Add(oRow)

        If Not oDataCombo Is Nothing Then
            oCombo.ValueMember = oDataCombo.Columns(0).ColumnName
            oCombo.DisplayMember = oDataCombo.Columns(1).ColumnName
            oCombo.DataSource = oDataCombo
            oCombo.Refresh()
        End If
    End Sub

    Public Sub ComboBox_Carregar_SEC_TipoOrigemAcesso(ByRef oCombo As System.Windows.Forms.ComboBox)
        Dim oRow As DataRow
        Dim oDataCombo As New DataTable
        oDataCombo.Columns.Add(0)
        oDataCombo.Columns.Add(1)

        oRow = oDataCombo.NewRow
        oRow(0) = "-"
        oRow(1) = ""
        oDataCombo.Rows.Add(oRow)


        oRow = oDataCombo.NewRow
        oRow(0) = "USUARIO_USUARIO"
        oRow(1) = "Acesso de outro usuário"
        oDataCombo.Rows.Add(oRow)

        oRow = oDataCombo.NewRow
        oRow(0) = "ACESSO_DIRETO"
        oRow(1) = "Acesso do usuário"
        oDataCombo.Rows.Add(oRow)

        oRow = oDataCombo.NewRow
        oRow(0) = "ACESSO_GRUPO"
        oRow(1) = "Acesso por Grupo"
        oDataCombo.Rows.Add(oRow)

        If Not oDataCombo Is Nothing Then
            oCombo.ValueMember = oDataCombo.Columns(0).ColumnName
            oCombo.DisplayMember = oDataCombo.Columns(1).ColumnName
            oCombo.DataSource = oDataCombo
            oCombo.Refresh()
        End If
    End Sub

    Public Sub ComboBox_Carregar_SEC_Usuaro_Status(ByRef oCombo As System.Windows.Forms.ComboBox, _
                                                   Optional ByVal LinhaBranco As Boolean = False)

        If LinhaBranco Then
            ComboBox_Carregar(oCombo, New String() {""}, New String() {"-1"})
        End If

        ComboBox_Carregar(oCombo, New String() {cnt_Usuario_StatusDescricao_Ativo, cnt_Usuario_StatusDescricao_Inativo, cnt_Usuario_StatusDescricao_EliminadoSO}, _
                                  New String() {cnt_Usuario_Status_Ativo, cnt_Usuario_Status_Inativo, cnt_Usuario_Status_EliminadoSO}, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_SEC_GrupoAcesso(ByRef oCombo As System.Windows.Forms.ComboBox, _
                                                 Optional ByVal LinhaBranco As Boolean = False, _
                                                 Optional ByVal BranchPlant As Boolean = False)
        Dim SqlText As String

        If BranchPlant Then
            SqlText = "SELECT G.SQ_GRUPOACESSO, BP.NO_BRANCH_PLANT || '-' || G.NO_GRUPOACESSO AS NO_GRUPOACESSO" & _
                                " FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_GRUPOACESSO G, " & sBancoDados_OwnerCtrlAcesso & ".BRANCH_PLANT BP" & _
                                " WHERE G.CD_BRANCH_PLANT=BP.CD_BRANCH_PLANT" & _
                                " ORDER BY NO_GRUPOACESSO"
        Else
            SqlText = "SELECT SQ_GRUPOACESSO, NO_GRUPOACESSO" & _
                      " FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_GRUPOACESSO"

            If bBancoDados_CtrlAcesso_MultiSistema Then
                SqlText = SqlText & " WHERE CD_SISTEMA = " & cnt_Sistema_ControleAcesso
            End If

            SqlText = SqlText & _
                      " ORDER BY NO_GRUPOACESSO"
        End If

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_SEC_StatusAcesso(ByRef oCombo As System.Windows.Forms.ComboBox)
        Dim oRow As DataRow
        Dim oDataCombo As New DataTable
        oDataCombo.Columns.Add(0)
        oDataCombo.Columns.Add(1)

        oRow = oDataCombo.NewRow
        oRow(0) = "S"
        oRow(1) = "Ativo"
        oDataCombo.Rows.Add(oRow)

        oRow = oDataCombo.NewRow
        oRow(0) = "N"
        oRow(1) = "Inativo"
        oDataCombo.Rows.Add(oRow)

        oRow = oDataCombo.NewRow
        oRow(0) = "T"
        oRow(1) = "Todos"
        oDataCombo.Rows.Add(oRow)

        If Not oDataCombo Is Nothing Then
            oCombo.ValueMember = oDataCombo.Columns(0).ColumnName
            oCombo.DisplayMember = oDataCombo.Columns(1).ColumnName
            oCombo.DataSource = oDataCombo
            oCombo.Refresh()
        End If
    End Sub

    Public Sub ComboBox_Carregar_SEC_GrupoMenu(ByRef oCombo As System.Windows.Forms.ComboBox)
        SEC_GrupoMenu("", "", oCombo)
    End Sub

    Public Function Montar_Filtro(ByVal oFiltro As Microsoft.VisualBasic.Collection, _
                                  Optional ByVal Conector As String = " AND ") As String
        If Not oFiltro Is Nothing Then
            If oFiltro.Count = 0 Then
                Return ""
            Else
                Dim iCont As Integer
                Dim sAux As String = ""

                For iCont = 1 To oFiltro.Count
                    If Trim(oFiltro(iCont)) <> "" Then
                        Str_Adicionar(sAux, oFiltro(iCont), " AND ")
                    End If
                Next

                Return " " & Conector & " " & sAux
            End If
        Else
            Return ""
        End If
    End Function

    Public Function CombineBitmaps(ByVal bitmaps() As Bitmap) As Bitmap
        If bitmaps.Length = 0 Then
            Return New Bitmap(1, 1)
        End If
        Dim width As Integer = 0
        Dim height As Integer = 0
        Dim bmp As Bitmap
        For Each bmp In bitmaps
            width = width + bmp.Width
            If height < bmp.Height Then
                height = bmp.Height
            End If
        Next bmp
        Dim newBitmap As New Bitmap(width, height)
        Dim grfx As Graphics = Graphics.FromImage(newBitmap)
        Try
            Dim x As Integer = 0
            For Each bmp In bitmaps
                grfx.DrawImage(bmp, x, 0, bmp.Width, height)
                x = x + bmp.Width
            Next bmp
        Finally
            grfx.Dispose()
        End Try
        Return newBitmap
    End Function

    Function ValidacaoExclusao(ByVal Tabela As String, ByVal Filtro As String, ByVal Mensagem As String, Optional ByVal bExibeMsgBox As Boolean = True) As Boolean
        Dim SqlText As String

        If InStr(Tabela, sBancoDados_OwnerPadrao & ".") = 0 Then
            SqlText = "SELECT COUNT(*) FROM " & sBancoDados_OwnerPadrao & "." & Tabela & "  WHERE  " & Filtro
        Else
            SqlText = "SELECT COUNT(*) FROM " & Tabela & "  WHERE  " & Filtro
        End If
        Return ValidacaoExclusao(SqlText, Mensagem, bExibeMsgBox)
    End Function

    Function ValidacaoExclusao(ByVal SqlText As String, ByVal Mensagem As String, Optional ByVal bExibeMsgBox As Boolean = True) As Boolean
        Dim oData As DataTable

        oData = DBQuery(SqlText)

        If DBQuery_ValorUnico(SqlText) <> 0 Then
            If bExibeMsgBox Then
                Msg_Mensagem("Registro não pode ser excluido. " & Mensagem)
            End If
            ValidacaoExclusao = False
        Else
            ValidacaoExclusao = True
        End If
    End Function

    Public Sub Auditoria(ByVal CampoFixo As TipoCampoFixo, ByVal Tabela As String, ByVal Filtro As String)
        Dim SqlText As String
        Dim sMSG As String = String.Empty
        Dim oData As DataTable

        If CampoFixo = TipoCampoFixo.Todos Or CampoFixo = TipoCampoFixo.DadoCriacao Then
            SqlText = "SELECT T.DT_CRIACAO, U.NO_USUARIO || ' (' || T.NO_USER_CRIACAO || ')' AS NO_USER_CRIACAO" & _
                      " FROM " & sBancoDados_OwnerPadrao & "." & Tabela & " T," _
                               & sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO U" & _
                      " WHERE U.CD_USUARIO (+) = T.NO_USER_CRIACAO" & _
                        " AND " & Filtro
            oData = DBQuery(SqlText)

            If Not objDataTable_Vazio(oData) Then
                sMSG = "Criação: " & oData.Rows(0).Item("no_user_criacao") & " em " & Format(oData.Rows(0).Item("dt_criacao"), "dd/MM/yyyy HH:mm:ss")
            End If
        End If

        If CampoFixo = TipoCampoFixo.Todos Or CampoFixo = TipoCampoFixo.DadoAlteracao Then
            sMSG = sMSG & vbCrLf

            SqlText = "SELECT T.DT_ALTERACAO, U.NO_USUARIO || ' (' || T.NO_USER_ALTERACAO || ')' AS NO_USER_ALTERACAO" & _
                      " FROM " & sBancoDados_OwnerPadrao & "." & Tabela & " T," _
                               & sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO U" & _
                      " WHERE U.CD_USUARIO (+) = T.NO_USER_ALTERACAO" & _
                        " AND " & Filtro
            oData = DBQuery(SqlText)

            If Not objDataTable_Vazio(oData) Then
                If Not objDataTable_CampoVazio(oData.Rows(0).Item("dt_Alteracao")) Then
                    sMSG = sMSG & "Alteração: " & oData.Rows(0).Item("no_user_alteracao") & " em " & Format(oData.Rows(0).Item("dt_alteracao"), "dd/MM/yyyy HH:mm:ss")
                End If
            End If
        End If

        Msg_Mensagem(sMSG)
    End Sub

    Public Sub objEditorNumerico_Formatar(ByVal oEditor As UltraWinEditors.UltraCurrencyEditor, ByVal CdMoeda As Integer)
        Dim overrideCultureUS = New System.Globalization.CultureInfo("en-US")
        Dim overrideCultureBR = New System.Globalization.CultureInfo("pt-BR")
        Dim overrideCultureGB = New System.Globalization.CultureInfo("en-GB")
        Select Case CdMoeda
            Case Moeda.Real
                oEditor.FormatProvider = overrideCultureBR
            Case Moeda.Dolar
                oEditor.FormatProvider = overrideCultureUS
            Case Moeda.Euro
                oEditor.FormatProvider = overrideCultureGB
        End Select
    End Sub

    Public Function BancoDados_ExisteDados(ByVal Mensagem As String, _
                                           ByVal Tabela As String, _
                                           ByVal Descricao_Campo As String, ByVal Descricao_Valor As String, _
                                           ByVal ParamArray Where() As Object) As Boolean
        Dim SqlText As String
        Dim iCont As Integer
        Dim Aux As String
        Dim sWhere As String = ""
        Dim bCampo As Boolean
        Dim bOperador As Boolean
        Dim sInNotIn As String = ""

        SqlText = "SELECT COUNT(*)" & _
                  " FROM " & Tabela & _
                  " WHERE UPPER(TRIM(" & Descricao_Campo & ")) = UPPER(" & QuotedStr(Trim(Descricao_Valor)) & ")"

        bCampo = True

        For Each Aux In Where
            If bCampo Then
                sWhere = sWhere + Aux
                bCampo = False
            ElseIf bOperador Then
                sWhere = sWhere + " " + Aux + " "
                bCampo = True
                bOperador = False
            Else
                If UCase(Aux) = "IN" Or UCase(Aux) = "NOT IN" Then
                    sInNotIn = UCase(Aux)
                Else
                    If UCase(Aux) = "IS NULL" Then
                        sWhere = sWhere & " is null "
                    Else
                        If Trim(sInNotIn) = "" Then
                            sWhere = sWhere & " = " & Aux
                        Else
                            sWhere = sWhere & " " & sInNotIn & " (" & Aux & ")"
                        End If
                    End If

                    sInNotIn = ""
                    bOperador = True
                End If
            End If
        Next

        If Trim(sWhere) <> "" Then
            SqlText = SqlText & _
                        " AND " & sWhere
        End If

        iCont = DBQuery_ValorUnico(SqlText)

        If iCont > 0 Then
            Msg_Mensagem(Mensagem)
        End If

        Return (iCont > 0)
    End Function

    Public Function ListBox_ListarSelecionados(ByRef oList As System.Windows.Forms.CheckedListBox, _
                                               Optional ByVal Separador As Object = ",", _
                                               Optional ByVal ListaCodigo As Boolean = False) As String
        Dim sLista As String = ""
        Dim iCont As Integer

        For iCont = 0 To oList.CheckedItems.Count - 1
            If Trim(sLista) = "" Then
                sLista = oList.CheckedItems(iCont)(IIf(ListaCodigo, 0, 1))
            Else
                sLista = sLista & Separador & _
                         oList.CheckedItems(iCont)(IIf(ListaCodigo, 0, 1))
            End If
        Next

        Return sLista
    End Function

    Public Function ListBox_ListarItems(ByRef oList As System.Windows.Forms.CheckedListBox, _
                                        Optional ByVal Separador As Object = ",", _
                                        Optional ByVal ListaCodigo As Boolean = False) As String
        Dim sLista As String = ""
        Dim iCont As Integer

        For iCont = 0 To oList.Items.Count - 1
            If Trim(sLista) = "" Then
                sLista = oList.Items(iCont)(IIf(ListaCodigo, 0, 1))
            Else
                sLista = sLista & Separador & _
                         oList.Items(iCont)(IIf(ListaCodigo, 0, 1))
            End If
        Next

        Return sLista
    End Function

    Public Sub Array_Add(ByRef oArray() As String, _
                         ByVal Valor As Object, _
                         Optional ByVal Distinto As Boolean = False)
        Dim iCont As Integer
        Dim bExiste As Boolean = False

        If Distinto And Not oArray Is Nothing Then
            For iCont = LBound(oArray) To UBound(oArray)
                If oArray(iCont) = Valor Then
                    bExiste = True
                    Exit For
                End If
            Next
        End If

        If Not bExiste Then
            If oArray Is Nothing Then
                ReDim oArray(0)
            Else
                ReDim Preserve oArray(UBound(oArray) + 1)
            End If

            oArray(UBound(oArray)) = Valor
        End If
    End Sub

    Public Function Array_EliminaValor(ByRef oArray() As String, _
                                       ByVal oValores() As String) As Object
        Dim iCont_01 As Integer
        Dim iCont_02 As Integer
        Dim bAcbou As Boolean
        Dim oArray_Destino() As String = Nothing

        For iCont_01 = LBound(oArray) To UBound(oArray)
            bAcbou = False

            For iCont_02 = LBound(oValores) To UBound(oValores)
                If oArray(iCont_01) = oValores(iCont_02) Then
                    bAcbou = True
                    Exit For
                End If
            Next

            If Not bAcbou Then
                Array_Add(oArray_Destino, oArray(iCont_01), True)
            End If
        Next

        oArray = oArray_Destino

        Return oArray_Destino
    End Function

    Public Function Array_Para_Lista(ByRef oArray() As String, _
                                     Optional ByVal sSeparador As String = ",", _
                                     Optional ByVal bQuotedStr As Boolean = False) As String
        Dim iCont As Integer
        Dim sAux As String = ""

        If Array_Preenchido(oArray) Then
            For iCont = LBound(oArray) To UBound(oArray)
                If bQuotedStr Then
                    Str_Adicionar(sAux, QuotedStr(oArray(iCont)), sSeparador)
                Else
                    Str_Adicionar(sAux, oArray(iCont), sSeparador)
                End If
            Next

            Return sAux
        Else
            Return ""
        End If
    End Function

    Public Sub Array_Mesclar(ByVal oArray_Origem() As String, _
                             ByRef oArray_Destino() As String, _
                             Optional ByVal Distinto As Boolean = False)
        Dim iCont_01 As Integer
        Dim iCont_02 As Integer
        Dim bExiste As Boolean = False

        For iCont_01 = LBound(oArray_Origem) To UBound(oArray_Origem)
            bExiste = False

            For iCont_02 = LBound(oArray_Destino) To UBound(oArray_Destino)
                If UCase(oArray_Origem(iCont_01)) = UCase(oArray_Destino(iCont_02)) Then
                    bExiste = True
                    Exit For
                End If
            Next

            If Not bExiste Then
                Array_Add(oArray_Destino, oArray_Origem(iCont_01), Distinto)
            End If
        Next
    End Sub

    Public Sub ArrayO_Add(ByRef oArray() As Object, _
                          ByVal Valor As Object, _
                          Optional ByVal Distinto As Boolean = False)
        Dim iCont As Integer
        Dim bExiste As Boolean = False

        If Distinto And Not oArray Is Nothing Then
            For iCont = LBound(oArray) To UBound(oArray)
                If oArray(iCont) = Valor Then
                    bExiste = True
                    Exit For
                End If
            Next
        End If

        If Not bExiste Then
            If oArray Is Nothing Then
                ReDim oArray(0)
            Else
                ReDim Preserve oArray(UBound(oArray) + 1)
            End If

            oArray(UBound(oArray)) = Valor
        End If
    End Sub

    Public Sub Array_Distinto(ByRef oArray() As String)
        Dim iCont As Integer
        Dim oArray_Destino() As String = Nothing

        For iCont = LBound(oArray) To UBound(oArray)
            Array_Add(oArray_Destino, oArray(iCont), True)
        Next

        oArray = oArray_Destino
    End Sub

    Public Function Array_ExisteValor(ByVal Variavel As Object, ByVal Valor As Object) As Boolean
        Dim bOk As Boolean = False

        If Array_Preenchido(Variavel) Then
            Dim iCont As Integer

            For iCont = LBound(Variavel) To UBound(Variavel)
                If Variavel(iCont) = Valor Then
                    bOk = True
                    Exit For
                End If
            Next
        Else
            bOk = False
        End If

        Return bOk
    End Function

    Public Function Array_Preenchido(ByVal Variavel As Object) As Boolean
        If IsArray(Variavel) Then
            Return (LBound(Variavel) >= 0)
        Else
            Return False
        End If
    End Function

    Public Function Collection_Preenchido(ByVal Variavel As Collection) As Boolean
        If Variavel Is Nothing Then
            Return False
        Else
            Return (Variavel.Count > 0)
        End If
    End Function

    Public Function Collection_Para_Lista(ByVal Variavel As Collection, _
                                          Optional ByVal Separador As String = ",") As String
        Dim iCont As Integer
        Dim sAux As String = ""

        If Variavel Is Nothing Then
            sAux = ""
        Else
            If Variavel.Count = 0 Then
                sAux = ""
            Else
                For iCont = 1 To Variavel.Count
                    Str_Adicionar(sAux, Variavel(iCont), Separador)
                Next
            End If
        End If

        Return sAux
    End Function

    Public Function MapDrive(ByVal UNCPath As String) As Boolean
        Dim nr As NETRESOURCE
        Dim strUsername As String
        Dim strPassword As String
        Dim CONNECT_UPDATE_PROFILE As Int32 = &H1

        sGerenciadorArquivo_DriveMap = DriveLivre()
        sGerenciadorArquivo_DriveUnMap = sGerenciadorArquivo_DriveMap

        If Trim(sGerenciadorArquivo_DriveMap) = "" Then
            Return False
        Else
            UnMapDrive()

            nr = New NETRESOURCE
            nr.lpRemoteName = UNCPath
            nr.lpLocalName = sGerenciadorArquivo_DriveMap & ":"
            nr.dwScope = 2
            nr.dwType = RESOURCETYPE_DISK
            nr.dwDisplayType = 3
            nr.dwUsage = 1

            strUsername = sGerenciadorArquivo_Usuario
            strPassword = GerenciadorArquivo_Senha()
            nr.dwType = RESOURCETYPE_DISK

            Dim result As Integer
            result = WNetAddConnection2(nr, strPassword, strUsername, 0)

            If result > 0 Then
                Throw New System.ComponentModel.Win32Exception(result)
                Return False
            Else
                Return True
            End If
        End If
    End Function

    Private Function DriveLivre() As String
        Dim iCont As Integer
        Dim Aux As String = ""
        Dim bAchou As Boolean = False

        For iCont = 8 To 5 Step -1
            If Not IO.Directory.Exists(Chr(65 + iCont) & ":\") Then
                bAchou = True
                Aux = Chr(65 + iCont)
                Exit For
            End If
        Next

        If bAchou Then
            Return Aux
        Else
            Return ""
        End If
    End Function

    Public Function UnMapDrive() As Boolean
        Dim WshNetwork As Object
        Dim oDrives As Object
        Dim i As Integer

        On Error GoTo deupau

        WshNetwork = CreateObject("WScript.Network")
        oDrives = WshNetwork.EnumNetworkDrives

        If Trim(sGerenciadorArquivo_DriveUnMap) <> "" Then
            For i = 0 To oDrives.Count - 1 Step 2
                If oDrives.item(i) = sGerenciadorArquivo_DriveUnMap & ":" Then
                    WshNetwork.RemoveNetworkDrive(oDrives.item(i), True)
                    Return True
                End If
            Next
        End If

        Return False

deupau:
        MsgBox("Ocorreu um erro. Numero: " & Err.Number & vbCrLf & "Descrição: " & Err.Description, vbCritical, "Atenção - Erro")
    End Function

    Public Sub OnThreadException(ByVal sender As Object, ByVal t As ThreadExceptionEventArgs)
        TratarErro(, , "MOD_Funcao.OnThreadException")
    End Sub

    Public Function Formatar_ValorPadraoBrasileiro(ByVal Valor As Double, Optional ByVal Simbolo As String = "") As String
        Dim sValor As String

        sValor = FormatCurrency(Valor)

        If Trim(Simbolo) <> "" Then
            If InStr(sValor, "$") > 0 Then
                sValor = Simbolo & Mid(sValor, InStr(sValor, "$") + 1)
            End If
        End If

        Return Replace(Replace(Replace(sValor, ",", "#"), ".", ","), "#", ".")
    End Function

    Public Function Formatar_NumeroPadraoBrasileiro(ByVal Valor As Double, Optional ByVal NumeroCasaDecimal As Integer = -1) As String
        Dim sValor As String

        sValor = FormatNumber(Valor, NumeroCasaDecimal)

        Return Replace(Replace(Replace(sValor, ",", "#"), ".", ","), "#", ".")
    End Function

    Public Function Lista_Para_Array(ByVal sLista As String, _
                                     Optional ByVal sSeparador As String = ",") As Object
        Dim oArray() As String = Nothing

        If Trim(sLista) <> "" Then
            Do While True
                If InStr(sLista, sSeparador) > 0 Then
                    Array_Add(oArray, Left(sLista, InStr(sLista, sSeparador) - 1), True)
                    sLista = Mid(sLista, InStr(sLista, sSeparador) + 1)
                Else
                    Array_Add(oArray, sLista, True)
                    Exit Do
                End If
            Loop
        End If

        Return oArray
    End Function

    Public Function EhNumero(ByVal Texto As String) As Boolean
        Dim iCont As Integer
        Dim bOk As Boolean = True

        Texto = Trim(Texto)

        For iCont = 1 To Len(Texto)
            If InStr("1;2;3;4;5;6;7;8;9;0;.", Mid(Texto, iCont, 1)) = 0 Or _
               Mid(Texto, iCont, 1) = ";" Then
                bOk = False
                Exit For
            End If
        Next

        Return bOk
    End Function

    Public Function EhData(ByVal Texto As String) As Boolean
        Dim bOk As Boolean = True

        Texto = Trim(Texto)

        With CDate(Texto)
            If .Day = 1 And .Month = 1 And .Year = 1 Then
                bOk = False
            Else
                bOk = IsDate(Texto)
            End If
        End With

        Return bOk
    End Function

    Public Sub UltraComboBox_Carregar_Usuario(ByRef oCombo As Infragistics.Win.UltraWinGrid.UltraCombo, _
                                              Optional ByVal UsuariosAtivos As Boolean = False, _
                                              Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        If bBancoDados_CtrlAcesso_MultiSistema Then
            SqlText = "SELECT USR.CD_USUARIO," & _
                             "UPPER(USR.NO_USUARIO) NO_USUARIO," & _
                             "USR.CD_USUARIO_DS" & _
                      " FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO USR," _
                               & sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO_SISTEMA UST" & _
                      " WHERE UST.CD_USUARIO = USR.CD_USUARIO" & _
                        " AND UST.CD_SISTEMA = " & cnt_Sistema_ControleAcesso

            If UsuariosAtivos = True Then
                SqlText = SqlText & _
                        " AND USR.IC_ATIVO = 'S'" & _
                        " AND UST.IC_ATIVO = 'S'" & _
                        " AND NVL(UST.DT_LIMITE_UTILIZACAO, TRUNC(SYSDATE)) >= TRUNC(SYSDATE)" & _
                        " AND UST.CD_USUARIO = USR.CD_USUARIO" & _
                        " AND UST.CD_SISTEMA = " & cnt_Sistema_ControleAcesso
            End If

            SqlText = SqlText & _
                      " ORDER BY USR.NO_USUARIO"
        Else
            SqlText = "SELECT USR.CD_USUARIO," & _
                             "UPPER(USR.NO_USUARIO) NO_USUARIO," & _
                             "USR.CD_USUARIO_DS" & _
                      " FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO USR"

            If UsuariosAtivos = True Then
                SqlText = SqlText & _
                      " WHERE USR.IC_ATIVO = 'S'" & _
                        " AND NVL(USR.DT_LIMITE_UTILIZACAO, TRUNC(SYSDATE)) >= TRUNC(SYSDATE)"
            End If

            SqlText = SqlText & _
                      " ORDER BY USR.NO_USUARIO"
        End If

        objUltraComboBox_Carregar(oCombo, SqlText, _
                                              New Combo_Informacao() {objUltraComboBox_Informacao("CD_USUARIO", False, 0, False, True), _
                                                                      objUltraComboBox_Informacao("Usuário", True, 180, True, False), _
                                                                      objUltraComboBox_Informacao("CD_USUARIO_DS", False, 0, False, False)}, , LinhaBranco)
    End Sub

    Public Function ListBox_Existe(ByRef oList As System.Windows.Forms.ListBox, _
                                   ByVal oTexto As String, _
                                   Optional ByVal bSelecionado As Boolean = False) As Boolean
        Dim bReturn As Boolean = False
        Dim icont As Integer

        For icont = 0 To oList.Items.Count - 1
            If oList.DataSource Is Nothing Then
                If UCase(Trim(oList.Items.Item(icont))) = UCase(Trim(oTexto)) Then
                    bReturn = True
                    Exit For
                End If
            Else
                If UCase(Trim(oList.Items(icont)(1))) = UCase(Trim(oTexto)) Then
                    bReturn = True
                    Exit For
                End If
            End If
        Next

        Return bReturn
    End Function

    Public Function CheckListBox_Existe(ByRef oList As System.Windows.Forms.CheckedListBox, _
                                        ByVal oTexto As String, _
                                        Optional ByVal bSelecionado As Boolean = True) As Boolean
        Dim bReturn As Boolean = False
        Dim iCont As Integer

        If bSelecionado Then
            For iCont = 0 To oList.CheckedItems.Count - 1
                If UCase(Trim(oList.CheckedItems.Item(iCont))) = UCase(Trim(oTexto)) Then
                    bReturn = True
                    Exit For
                End If
            Next
        Else
            For iCont = 0 To oList.Items.Count - 1
                If UCase(Trim(oList.Items.Item(iCont))) = UCase(Trim(oTexto)) Then
                    bReturn = True
                    Exit For
                End If
            Next
        End If

        Return bReturn
    End Function

    Public Sub TraducaoInfragistics()
        Dim rc As Infragistics.Shared.ResourceCustomizer

        rc = Infragistics.Win.UltraWinGrid.Resources.Customizer

        rc.SetCustomizedString("DeleteSingleRowPrompt", "Deseja Excluir o registro?")
        rc.SetCustomizedString("RowFilterDropDownAllItem", "(Todos)")   '	(All)
        rc.SetCustomizedString("RowFilterDropDownBlanksItem", "(Em Branco)")  '	(Blanks)
        rc.SetCustomizedString("RowFilterDropDownCustomItem", "(Customizar)")   '	(Custom)
        rc.SetCustomizedString("ColumnChooserAllBandsItem", "Todas") '	All
        rc.SetCustomizedString("ColumnChooserButtonToolTip", "Clique aqui para selecionar as colunas.") '	Click here to show Field Chooser.
        rc.SetCustomizedString("ColumnChooserDialogCaption", "Seleção de Colunas") '	Field Chooser
        rc.SetCustomizedString("Outlook_GroupByMode_Description_LastMonth", "Ultimo Mês") '	Last Month
        rc.SetCustomizedString("Outlook_GroupByMode_Description_LastWeek", "Ultima Semana") '	Last Week
        rc.SetCustomizedString("Outlook_GroupByMode_Description_Today", "Hoje") '	Today
        rc.SetCustomizedString("Outlook_GroupByMode_Description_Yesterday", "Ontem") '	Yesterday
        rc.SetCustomizedString("RowFilterDialogEmptyTextItem", "(Texto Vazio)") '	(Empty Text)
        rc.SetCustomizedString("RowFilterDropDown_Operator_Contains", "Contenha") '	Contains
        rc.SetCustomizedString("RowFilterDropDown_Operator_DoesNotContain", "Que não contenha") '	Does not contain
        rc.SetCustomizedString("RowFilterDropDown_Operator_DoesNotEndWith", "Que não termine com") '	Does not end with
        rc.SetCustomizedString("RowFilterDropDown_Operator_DoesNotStartWith", "Que não comece com") '	Does not start with
        rc.SetCustomizedString("RowFilterDropDown_Operator_StartsWith", "Começando com") '	Starts with
        rc.SetCustomizedString("RowFilterDropDownEquals", "Igual") '	Equals
        rc.SetCustomizedString("RowFilterDropDownGreaterThan", "Maior que") '	Greater than
        rc.SetCustomizedString("RowFilterDropDownGreaterThanOrEqualTo", "Maior ou igual que") '	Greater than or equal to
        rc.SetCustomizedString("RowFilterDropDownLessThan", "Menor que") '	Less than
        rc.SetCustomizedString("RowFilterDropDownLessThanOrEqualTo", "Menor ou igual que") '	Less than or equal to
        rc.SetCustomizedString("RowFilterDropDownNonBlanksItem", "(Não Vazios)") '	(NonBlanks)
        rc.SetCustomizedString("RowFilterDropDownNotEquals", "Que não seja igual") '	Does not equal
        rc.SetCustomizedString("SpecialFilterOperand_April", "&Abril") '	&April
        rc.SetCustomizedString("SpecialFilterOperand_August", "Agosto") '	Augus&t
        rc.SetCustomizedString("SpecialFilterOperand_December", "Dezembro") '	&December
        rc.SetCustomizedString("SpecialFilterOperand_February", "Fevereiro") '	&February
        rc.SetCustomizedString("SpecialFilterOperand_January", "Janeiro") '	&January
        rc.SetCustomizedString("SpecialFilterOperand_July", "Julho") '	Ju&ly
        rc.SetCustomizedString("SpecialFilterOperand_June", "Junho") '	J&une
        rc.SetCustomizedString("SpecialFilterOperand_LastMonth", "Ultimo Mês") '	Last Mo&nth
        rc.SetCustomizedString("SpecialFilterOperand_LastQuarter", "Ultimo Quadrimestre") '	Last Qua&rter
        rc.SetCustomizedString("SpecialFilterOperand_LastWeek", "Ultima Semana") '	&Last Week
        rc.SetCustomizedString("SpecialFilterOperand_LastYear", "Ultimo Ano") '	Last &Year
        rc.SetCustomizedString("SpecialFilterOperand_March", "Março") '	&March
        rc.SetCustomizedString("SpecialFilterOperand_May", "Maio") '	Ma&y
        rc.SetCustomizedString("SpecialFilterOperand_NextMonth", "Proximo Mês") '	Next &Month
        rc.SetCustomizedString("SpecialFilterOperand_NextQuarter", "Proximo Quadrimestre") '	Next &Quarter
        rc.SetCustomizedString("SpecialFilterOperand_NextWeek", "Proxima Semana") '	Next Wee&k
        rc.SetCustomizedString("SpecialFilterOperand_NextYear", "Proximo Ano") '	Ne&xt Year
        rc.SetCustomizedString("SpecialFilterOperand_November", "Novembro") '	&November
        rc.SetCustomizedString("SpecialFilterOperand_October", "Outubro") '	&October
        rc.SetCustomizedString("SpecialFilterOperand_Quarter1", "Quadrimestre 1") '	Quarter &1
        rc.SetCustomizedString("SpecialFilterOperand_Quarter2", "Quadrimestre 2") '	Quarter &2
        rc.SetCustomizedString("SpecialFilterOperand_Quarter3", "Quadrimestre 3") '	Quarter &3
        rc.SetCustomizedString("SpecialFilterOperand_Quarter4", "Quadrimestre 4") '	Quarter &4
        rc.SetCustomizedString("SpecialFilterOperand_September", "Setembro") '	&September
        rc.SetCustomizedString("SpecialFilterOperand_ThisMonth", "Esse Mês") '	Thi&s Month
        rc.SetCustomizedString("SpecialFilterOperand_ThisQuarter", "Esse Quadrimestre") '	This Q&uarter
        rc.SetCustomizedString("SpecialFilterOperand_ThisWeek", "Essa Semana") '	T&his Week
        rc.SetCustomizedString("SpecialFilterOperand_ThisYear", "Esse Ano") '	Th&is Year
        rc.SetCustomizedString("SpecialFilterOperand_Today", "Hoje") '	T&oday
        rc.SetCustomizedString("SpecialFilterOperand_Tomorrow", "Amanhã") '	&Tomorrow
        rc.SetCustomizedString("SpecialFilterOperand_Yesterday", "Ontem") '	Yester&day
        rc.SetCustomizedString("SummaryDialog_Button_Cancel", "Cancelar") '	&Cancel
        rc.SetCustomizedString("SummaryDialogAverage", "Media") '	Average
        rc.SetCustomizedString("SummaryDialogCount", "Contar") '	Count
        rc.SetCustomizedString("SummaryDialogMaximum", "Maximo") '	Maximum
        rc.SetCustomizedString("SummaryDialogMinimum", "Minimo") '	Minimum
        rc.SetCustomizedString("SummaryDialogSum", "Soma") '	Sum
        rc.SetCustomizedString("SummaryTypeAverage", "Media") '	Average
        rc.SetCustomizedString("SummaryTypeCount", "Conta") '	Count
        rc.SetCustomizedString("SummaryTypeMaximum", "Maximo") '	Maximum
        rc.SetCustomizedString("SummaryTypeMinimum", "Minimo") '	Minimum
        rc.SetCustomizedString("SummaryTypeSum", "Soma") '	Sum
        rc.SetCustomizedString("RowFilterDialogTitlePrefix", "Entre Com os Criterios Para Filtrar") '	Enter filter criteria for
        rc.SetCustomizedString("FilterDialogAndRadioText", "Adicionar Condições") '	And conditions
        rc.SetCustomizedString("FilterDialogCancelButtonText", "Cancelar") '	&Cancel
        rc.SetCustomizedString("FilterDialogDeleteButtonText", "Deletar Condições") '	Delete Condition
        rc.SetCustomizedString("FilterDialogOkButtonNoFiltersText", "Sem Filtros") '	N&o filters
        rc.SetCustomizedString("RowFilterDialogBlanksItem", "(Branco)") '	(Blanks)
        rc.SetCustomizedString("RowFilterDialogOperandHeaderCaption", "Operando") '	Operand
        rc.SetCustomizedString("RowFilterDialogOperatorHeaderCaption", "Operador") '	Operator
        rc.SetCustomizedString("RowFilterDropDown_Operator_DoesNotMatch", "Não Combina") '	Does not match
        rc.SetCustomizedString("RowFilterDropDown_Operator_EndsWith", "Terminados com") '	Ends with
        rc.SetCustomizedString("RowFilterDropDown_Operator_Match", "Combina") '	Match
        rc.SetCustomizedString("RowFilterLogicalOperator_And", "E") '	AND
        rc.SetCustomizedString("RowFilterLogicalOperator_Or", "ou") '	OR
        rc.SetCustomizedString("SpecialFilterOperand_YearToDate", "Inicio do Ano Ate Hoje") '	Year To Date
        rc.SetCustomizedString("GroupByBoxDefaultPrompt", "Arraste aqui o cabeçalho da coluna para agrupar pela coluna.") 'Drag a column header here to group by that column. 

        rc = Infragistics.Win.SupportDialogs.Resources.Customizer

        rc.SetCustomizedString("FilterUIProvider_Menu_ClearFilter", "Limpar Filtros") '	&Clear Filter	
        rc.SetCustomizedString("FilterUIProvider_Menu_CustomFilters", "Filtros Customizados") '	Custom &Filters
        rc.SetCustomizedString("FilterUIProvider_Menu_DateFilters", "Filtros de Data") '	Date &Filters	
        rc.SetCustomizedString("FilterUIProvider_Menu_NumberFilters", "Filtros de Número") '	Number &Filters	
        rc.SetCustomizedString("FilterUIProvider_Menu_TextFilters", "Filtros de Texto") '	Text &Filters	
        rc.SetCustomizedString("UltraGridFilterUIProvider_AfterOperand", "Depois...")   '	&After...
        rc.SetCustomizedString("UltraGridFilterUIProvider_AllDatesInPeriod_Menu", "Todas as Datas no Periodo")        'All Dates in the &Period
        rc.SetCustomizedString("UltraGridFilterUIProvider_BeforeOperand", "Antes...") '	&Before...
        rc.SetCustomizedString("UltraGridFilterUIProvider_BeginsWithOperand", "Começando Com...") '	Begins W&ith...
        rc.SetCustomizedString("UltraGridFilterUIProvider_BetweenOperand", "Entre...")    '	Bet&ween...
        rc.SetCustomizedString("UltraGridFilterUIProvider_ContainsOperand", "Contenha...") '	Cont&ains...
        rc.SetCustomizedString("UltraGridFilterUIProvider_CustomFilter", "Filtro Customizado...")   '	Custom &Filter...
        rc.SetCustomizedString("UltraGridFilterUIProvider_DoesNotContainOperand", "Que Não Contenha...") '	&Does Not Contain...
        rc.SetCustomizedString("UltraGridFilterUIProvider_DoesNotEqualOperand", "Que Não Seja Igual...")   '	Does &Not Equal...
        rc.SetCustomizedString("UltraGridFilterUIProvider_EndsWithOperand", "Terminando Com...")   '	Ends Wi&th...
        rc.SetCustomizedString("UltraGridFilterUIProvider_EqualsOperand", "Iguais...")    '	&Equals...
        rc.SetCustomizedString("UltraGridFilterUIProvider_GreaterThanOperand", "Maior Que...") '	&Greater Than...
        rc.SetCustomizedString("UltraGridFilterUIProvider_GreaterThanOrEqualToOperand", "Maior ou Igual Que...")    '	Greater Than &Or Equal To...
        rc.SetCustomizedString("UltraGridFilterUIProvider_LessThanOperand", "Menor Que...") '	&Less Than...
        rc.SetCustomizedString("UltraGridFilterUIProvider_LessThanOrEqualToOperand", "Menor ou Igual Que...")    '	Less Than Or E&qual To...
        rc.SetCustomizedString("Button_Apply", "Aplicar") '	A&pply
        rc.SetCustomizedString("Button_Cancel", "Cancelar") ' & Cancel)
        'rc.SetCustomizedString("ConditionalFormatting_AddConditionAppearanceMappings"		Add Condition/Appearance Mappings
        rc.SetCustomizedString("ConditionalFormatting_AddConditionGroup_Button", "Adicionar Grupo de Condições") '	Add Condition Group
        rc.SetCustomizedString("ConditionalFormatting_AddFormulaCondition_Button", "Adicionar Formula") '	Add Formula Condition
        rc.SetCustomizedString("ConditionalFormatting_AddOperatorCondition_Button", "Adicionar Operador") '	Add Operator Condition
        rc.SetCustomizedString("ConditionalFormatting_AddTrueCondition_Button", "Adicionar Condição Verdadeira") '	Add True Condition
        'ConditionalFormatting_ApplyAllMatchingConditions_Checkbox		Apply All Matching Conditions
        rc.SetCustomizedString("ConditionalFormatting_CreateConditionGroup_Form", "Criar Grupo de Condições") '	Create Condition Group
        rc.SetCustomizedString("ConditionalFormatting_DeleteCondition_Button", "Deletar Condição") '	Delete Condition
        rc.SetCustomizedString("ConditionalFormatting_Edit_ConditionGroup", "Editar Grupo de Condições") '	Edit Condition Group
        rc.SetCustomizedString("ConditionalFormatting_Edit_FormulaCondition", "Editar Formula") '	Edit Formula Condition

    End Sub

    Public Function MaiorValor(ByVal oData As DataTable, ByVal Coluna As Integer) As Double
        Dim iCont As Integer
        Dim valor As Double = 0

        For iCont = 0 To oData.Rows.Count - 1
            If valor < NVL(oData.Rows(iCont).Item(Coluna), 0) Then
                valor = oData.Rows(iCont).Item(Coluna)
            End If
        Next
        Return IIf(valor = 0, 1, valor)
    End Function

    Public Function Configuracao_Usuario_LerValor(ByVal Usuario As String, _
                                                  ByVal Item_Configuracao() As Integer) As Object
        Dim SqlText As String
        Dim sItem_Configuracao As String = ""
        Dim iCont As Integer
        Dim oRetorno As Object = Nothing

        For iCont = LBound(Item_Configuracao) To UBound(Item_Configuracao)
            sItem_Configuracao = Trim(sItem_Configuracao & "," & Item_Configuracao(iCont))
        Next

        sItem_Configuracao = Mid(sItem_Configuracao, 2)

        SqlText = "SELECT IC.IC_TIPO_CAMPO," & _
                         "UC.DT_ITEM_CONFIGURACAO DATA," & _
                         "UC.NR_ITEM_CONFIGURACAO NUMERO," & _
                         "UC.IC_ITEM_CONFIGURACAO IC," & _
                         "UC.TX_ITEM_CONFIGURACAO TEXTO," & _
                         "IC.CD_ITEM_CONFIGURACAO CODIGO" & _
                  " FROM " & sBancoDados_OwnerPadrao & ".USUARIO_CONFIGURACAO UC," & _
                             sBancoDados_OwnerPadrao & ".ITEM_CONFIGURACAO IC" & _
                  " WHERE UC.CD_USUARIO = " & QuotedStr(Usuario) & _
                    " AND UC.CD_ITEM_CONFIGURACAO IN (" & sItem_Configuracao & ")" & _
                    " AND IC.CD_ITEM_CONFIGURACAO = UC.CD_ITEM_CONFIGURACAO"

        If UBound(Item_Configuracao) = 0 Then
            Dim oData As DataTable

            oData = DBQuery(SqlText)

            If Not objDataTable_Vazio(oData) Then
                Select Case oData.Rows(0).Item("IC_TIPO_CAMPO")
                    Case "D"
                        oRetorno = oData.Rows(0).Item("DATA")
                    Case "N"
                        oRetorno = oData.Rows(0).Item("NUMERO")
                    Case "T"
                        oRetorno = oData.Rows(0).Item("TEXTO")
                    Case "I"
                        oRetorno = oData.Rows(0).Item("IC")
                End Select
            Else
                If UBound(Item_Configuracao) > 0 Then
                    oRetorno = Item_Configuracao(1)
                End If
            End If

            oData.Dispose()
            oData = Nothing
        Else
            oRetorno = DBQuery(SqlText)
        End If

        Return oRetorno
    End Function

    Public Sub Configuracao_Usuario_ListBox_Gravar(ByVal ListBox As ListBox, ByVal CD_ITEM_CONFIGURACAO As Integer, Optional ByVal ColunaDescricao As Integer = 0)
        Dim SqlText As String
        Dim oParametro(2) As DBParamentro
        Dim iCont As Integer


        SqlText = "Delete" & _
                  " FROM " & sBancoDados_OwnerPadrao & ".USUARIO_CONFIGURACAO" & _
                  " WHERE CD_ITEM_CONFIGURACAO = " & CD_ITEM_CONFIGURACAO & _
                    " AND CD_USUARIO = " & QuotedStr(sAcesso_UsuarioLogado)

        If Not DBExecutar(SqlText) Then GoTo Erro


        For iCont = 0 To ListBox.Items.Count - 1
            SqlText = DBMontar_Insert("USUARIO_CONFIGURACAO", TipoCampoFixo.Todos, _
                                                              "TX_ITEM_CONFIGURACAO", ":TX_ITEM_CONFIGURACAO", _
                                                              "CD_ITEM_CONFIGURACAO", ":CD_ITEM_CONFIGURACAO", _
                                                              "CD_USUARIO", ":CD_USUARIO")





            If ColunaDescricao = 0 Then
                oParametro(0) = DBParametro_Montar("TX_ITEM_CONFIGURACAO", ListBox.Items.Item(iCont))
            Else
                oParametro(0) = DBParametro_Montar("TX_ITEM_CONFIGURACAO", ListBox.Items.Item(iCont)(ColunaDescricao))
            End If
            oParametro(1) = DBParametro_Montar("CD_ITEM_CONFIGURACAO", CD_ITEM_CONFIGURACAO)
            oParametro(2) = DBParametro_Montar("CD_USUARIO", sAcesso_UsuarioLogado)

            If Not DBExecutar(SqlText, oParametro) Then GoTo Erro
        Next

        Exit Sub

Erro:
        TratarErro(, , "Funcao.Configuracao_Usuario_ListBox_Gravar")
    End Sub

    Public Sub Configuracao_Usuario_CheckList_Gravar(ByVal CheckBox As CheckedListBox, ByVal CD_ITEM_CONFIGURACAO As Integer)
        Dim SqlText As String
        Dim oParametro(2) As DBParamentro
        Dim iCont As Integer


        SqlText = "Delete" & _
                  " FROM " & sBancoDados_OwnerPadrao & ".USUARIO_CONFIGURACAO" & _
                  " WHERE CD_ITEM_CONFIGURACAO = " & CD_ITEM_CONFIGURACAO & _
                    " AND CD_USUARIO = " & QuotedStr(sAcesso_UsuarioLogado)

        If Not DBExecutar(SqlText) Then GoTo Erro


        For iCont = 0 To CheckBox.CheckedItems.Count - 1
            SqlText = DBMontar_Insert("USUARIO_CONFIGURACAO", TipoCampoFixo.Todos, _
                                                              "TX_ITEM_CONFIGURACAO", ":TX_ITEM_CONFIGURACAO", _
                                                              "CD_ITEM_CONFIGURACAO", ":CD_ITEM_CONFIGURACAO", _
                                                              "CD_USUARIO", ":CD_USUARIO")





            oParametro(0) = DBParametro_Montar("TX_ITEM_CONFIGURACAO", CheckBox.CheckedItems(iCont))
            oParametro(1) = DBParametro_Montar("CD_ITEM_CONFIGURACAO", CD_ITEM_CONFIGURACAO)
            oParametro(2) = DBParametro_Montar("CD_USUARIO", sAcesso_UsuarioLogado)

            If Not DBExecutar(SqlText, oParametro) Then GoTo Erro
        Next

        Exit Sub

Erro:
        TratarErro(, , "Funcao.Configuracao_Usuario_CheckList_Gravar")
    End Sub

    Public Sub Configuracao_Usuario_CheckList_Ler(ByVal CheckBox As CheckedListBox, ByVal CD_ITEM_CONFIGURACAO As Integer)
        Dim SqlText As String
        Dim iCont As Integer

        CheckBox.ClearSelected()

        For iCont = 0 To CheckBox.Items.Count - 1
            SqlText = "Select count(*)" & _
                 " FROM " & sBancoDados_OwnerPadrao & ".USUARIO_CONFIGURACAO" & _
                 " WHERE CD_ITEM_CONFIGURACAO = " & CD_ITEM_CONFIGURACAO & _
                   " AND CD_USUARIO = " & QuotedStr(sAcesso_UsuarioLogado) & _
                   " AND TX_ITEM_CONFIGURACAO=" & QuotedStr(CheckBox.Items(iCont))

            If DBQuery_ValorUnico(SqlText, 0) Then
                CheckBox.SetItemChecked(iCont, True)
            End If
        Next

        Exit Sub

Erro:
        TratarErro(, , "Funcao.Configuracao_Usuario_CheckList_Ler")
    End Sub



    Function Arredondar(ByVal valor As Double, ByVal casas As Integer, ByVal bTrueMaior_FalseMenor As Boolean) As Double
        Dim arredondado As Double = valor
        arredondado *= (Math.Pow(10, casas))
        If bTrueMaior_FalseMenor = True Then
            arredondado = Math.Ceiling(arredondado)
        Else
            arredondado = Math.Floor(arredondado)
        End If
        arredondado /= (Math.Pow(10, casas))
        Return arredondado
    End Function

    Public Sub Configuracao_Usuario_GravarValor(ByVal CD_USUARIO As String, _
                                                ByVal CD_ITEM_CONFIGURACAO As Integer, _
                                                ByVal Valor As Object)
        Dim SqlText As String
        Dim Campo As String = ""
        Dim IC_TIPO_CAMPO As String
        Dim oParametro(2) As DBParamentro

        SqlText = "SELECT IC_TIPO_CAMPO" & _
                  " FROM " & sBancoDados_OwnerPadrao & ".ITEM_CONFIGURACAO" & _
                  " WHERE CD_ITEM_CONFIGURACAO = " & CD_ITEM_CONFIGURACAO
        IC_TIPO_CAMPO = DBQuery_ValorUnico(SqlText)

        Select Case IC_TIPO_CAMPO
            Case "D"
                Campo = "DT_ITEM_CONFIGURACAO"
            Case "N"
                Campo = "NR_ITEM_CONFIGURACAO"
            Case "I"
                Campo = "IC_ITEM_CONFIGURACAO"
            Case "T"
                Campo = "TX_ITEM_CONFIGURACAO"
        End Select

        SqlText = "SELECT COUNT(*)" & _
                  " FROM " & sBancoDados_OwnerPadrao & ".USUARIO_CONFIGURACAO" & _
                  " WHERE CD_ITEM_CONFIGURACAO = " & CD_ITEM_CONFIGURACAO & _
                    " AND CD_USUARIO = " & QuotedStr(sAcesso_UsuarioLogado)

        If DBQuery_ValorUnico(SqlText) = 0 Then
            SqlText = DBMontar_Insert("USUARIO_CONFIGURACAO", TipoCampoFixo.Todos, _
                                                              Campo, ":" & Campo, _
                                                                         "CD_ITEM_CONFIGURACAO", ":CD_ITEM_CONFIGURACAO", _
                                                                         "CD_USUARIO", ":CD_USUARIO")
        Else
            SqlText = DBMontar_Update("USUARIO_CONFIGURACAO", GerarArray(Campo, ":" & Campo), _
                                                              GerarArray("CD_ITEM_CONFIGURACAO", ":CD_ITEM_CONFIGURACAO", " AND ", _
                                                                         "CD_USUARIO", ":CD_USUARIO"))
        End If

        Select Case IC_TIPO_CAMPO
            Case "D"
                oParametro(0) = DBParametro_Montar(Campo, Valor, OracleClient.OracleType.DateTime)
            Case Else
                oParametro(0) = DBParametro_Montar(Campo, Valor)
        End Select

        oParametro(1) = DBParametro_Montar("CD_ITEM_CONFIGURACAO", CD_ITEM_CONFIGURACAO)
        oParametro(2) = DBParametro_Montar("CD_USUARIO", CD_USUARIO)

        If Not DBExecutar(SqlText, oParametro) Then GoTo Erro

        Exit Sub

Erro:
        TratarErro(, , "Funcao.Configuracao_Usuario_GravarValor")
    End Sub

    Public Function Numero_Menor(ByRef oArray() As Double, ByVal DesconsiderarZero As Boolean) As Double
        Dim iCont As Integer
        Dim iMaior As Double

        If Not oArray Is Nothing Then
            iMaior = oArray(0)

            For iCont = LBound(oArray) + 1 To UBound(oArray)
                If oArray(iCont) <> 0 Or Not DesconsiderarZero Then
                    If iMaior > oArray(iCont) Then
                        iMaior = oArray(iCont)
                    End If
                End If
            Next
        End If

        Return iMaior
    End Function

    Public Function Numero_Adicionar(ByRef Valor As Double, Optional ByVal Adicionar As Double = 1) As Double
        Valor = Valor + Adicionar

        Return Valor
    End Function

    Private Function Debug_Assert() As Boolean
        Debug_EmDebug = True
        Return True
    End Function

    Public Function Debug_Testar() As Boolean
        Debug_EmDebug = False

        Debug.Assert(Debug_Assert)

        Return Debug_EmDebug
    End Function

    Public Function GetNewPassword() As Object
        Dim upperbound, lowerbound As Integer
        lowerbound = 100000
        upperbound = 99999999
        Randomize()

        GetNewPassword = CStr(CInt((upperbound - lowerbound + 1) * Rnd() + lowerbound))
    End Function
End Module

Public Class KeyBoardState
    Declare Function GetKeyboardState Lib "user32" Alias "GetKeyboardState" (ByVal pbKeyState() As Byte) As Long
    Private KeyCode As Integer

    Public Sub New(ByVal keycode As Integer)
        Me.KeyCode = keycode
    End Sub

    Public Function KeyState() As Boolean
        Dim state(256) As Byte
        GetKeyboardState(state)
        Return (iif(state(Me.KeyCode) = 1, True, False))
    End Function
End Class