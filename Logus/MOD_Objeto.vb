Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports Infragistics.Win

Module MOD_Objeto
    Public Enum CREmail_Formato
        PDF = 1
        HTML = 2
    End Enum

    Public Enum objData_TipoFiltroCampo
        Faixa = 1
        CampoExato = 2
        Todos = 3
    End Enum

    Public Function ValueList_Carregar(ByVal SqlText As String) As ValueList
        Dim oData As DataTable
        Dim iCont As Integer
        Dim oLista As New ValueList

        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            For iCont = 0 To oData.Rows.Count - 1
                With oData.Rows(iCont)
                    oLista.ValueListItems.Add(.Item(0), .Item(1))
                End With
            Next
        End If

        oData = Nothing

        Return oLista
    End Function

    Public Function ValueList_Montar(ByVal Valores() As Object) As ValueList
        Dim oLista As New ValueList
        Dim iCont As Integer

        If Not Valores Is Nothing Then
            For iCont = LBound(Valores) To UBound(Valores) Step 2
                oLista.ValueListItems.Add(Valores(iCont), Valores(iCont + 1))
            Next
        End If

        Return oLista
    End Function

    Public Function ValueList_Carregar_Processo(ByVal CD_PROCESSO As enProcesso_Status) As ValueList
        Dim SqlText As String

        SqlText = "SELECT CD_STATUS," & _
                         "NO_STATUS" & _
                  " FROM " & sBancoDados_OwnerPadrao & ".PROCESSO_STATUS" & _
                  " WHERE CD_PROCESSO = " & CD_PROCESSO & _
                  " ORDER BY NO_STATUS"
        Return ValueList_Carregar(SqlText)
    End Function

    Public Function objCRView_MontarRodape(Optional ByVal sComplemento As String = "") As String
        Dim sRetorno As String

        sRetorno = Sis_NomeSistema & " (" & sAcesso_UsuarioLogado & ")"
        sRetorno = sRetorno & IIf(Trim(sComplemento) = "", "", " - " & sComplemento)

        If sBancoDados_BancoDadosLogado <> "ILH01P" And _
           sBancoDados_BancoDadosLogado <> "SPO07P" And _
           sBancoDados_BancoDadosLogado <> "PSPSHR02" Then
            sRetorno = sRetorno & " -> Desenvolvimento"
        End If

        Return sRetorno
    End Function

    Public Sub objCRView_Finalizar(ByRef oRelatorio As CrystalReportDocument)
        If Not oRelatorio Is Nothing Then
            oRelatorio.Close()
            oRelatorio.Dispose()
            oRelatorio = Nothing
        End If
    End Sub

    Public Sub objCRView2_Finalizar(ByRef oRelatorio As ReportDocument)
        If Not oRelatorio Is Nothing Then
            oRelatorio.Close()
            oRelatorio.Dispose()
            oRelatorio = Nothing
        End If
    End Sub

    Public Sub objCREmail_Enviar(ByVal oRelatorio As ReportDocument, _
                                 ByVal sTitulo As String, ByVal sEMail As String, _
                                 Optional ByVal Formato As CREmail_Formato = CREmail_Formato.HTML, _
                                 Optional ByVal sMensagem As String = "", _
                                 Optional ByVal EnviarMensagem As Boolean = True)
        If Not oRelatorio.IsLoaded Then
            Msg_Mensagem("É preciso listar o relatório antes de enviar")
        Else
            Dim sArquivo_Caminho As String
            Dim sArquivo_Conteudo As String
            Dim sArquivo_TextoInicial As String
            Dim sArquivo_TextoFinal As String
            Dim sErr As String = ""

            sArquivo_Caminho = Trim(Path.GetTempFileName)

            Select Case Formato
                Case CREmail_Formato.HTML
                    sArquivo_Caminho = Mid(sArquivo_Caminho, 1, Len(sArquivo_Caminho) - 4) + ".htm"

                    oRelatorio.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.HTML40, sArquivo_Caminho)

                    sArquivo_Conteudo = Arquivo_CarregarConteudo(sArquivo_Caminho, sErr)

                    sArquivo_TextoInicial = "style=" & Chr(34) & "position:absolute;"
                    sArquivo_TextoFinal = "style=" & Chr(34) & "position:relative;"

                    sArquivo_Conteudo = Replace(sArquivo_Conteudo, sArquivo_TextoInicial, sArquivo_TextoFinal)

                    EMail_Enviar(sAcesso_UsuarioLogado, _
                                 sEMail, sTitulo, sArquivo_Conteudo, _
                                   True, cnt_EMail_Servidor_SMTP, _
                                 System.Net.Mail.MailPriority.Normal)
                Case CREmail_Formato.PDF
                    sArquivo_Caminho = Mid(sArquivo_Caminho, 1, Len(sArquivo_Caminho) - 4) + ".pdf"
                    oRelatorio.ExportToDisk(ExportFormatType.PortableDocFormat, sArquivo_Caminho)

                    EMail_Enviar(sAcesso_UsuarioLogado, _
                                 sEMail, sTitulo, sMensagem, _
                                 True, cnt_EMail_Servidor_SMTP, _
                                 System.Net.Mail.MailPriority.Normal, New String() {sArquivo_Caminho})
            End Select

            Kill(sArquivo_Caminho)

            If EnviarMensagem Then Msg_Mensagem("Relatório Enviado")
        End If
    End Sub

    Public Function Arquivo_CarregarConteudo(ByVal FullPath As String, _
                                             Optional ByRef ErrInfo As String = "") As String
        Dim strContents As String
        Dim objReader As StreamReader

        Try
            objReader = New StreamReader(FullPath)
            strContents = objReader.ReadToEnd()
            objReader.Close()

            Return strContents
        Catch Ex As Exception
            ErrInfo = Ex.Message
        End Try

        Return Nothing
    End Function

    Public Function objCRView_Filtro_Data(ByVal sTitulo As String, _
                                          ByVal sDataIni As String, _
                                          ByVal sDataFim As String) As String
        Dim sAux As String = ""

        If IsDate(sDataIni) And IsDate(sDataFim) Then
            sAux = " entre " & sDataIni & " e " & sDataFim
        ElseIf IsDate(sDataIni) Then
            sAux = " a partir de " & sDataIni
        ElseIf IsDate(sDataFim) Then
            sAux = " até " & sDataFim
        End If

        If Trim(sAux) = "" Then
            Return ""
        Else
            Return sTitulo & " " & sAux
        End If
    End Function

    Public Sub objUltraOption_Posicionar(ByVal oList As Infragistics.Win.UltraWinEditors.UltraOptionSet, ByVal Valor As Object)
        Dim iCont As Integer

        For iCont = 0 To oList.Items.Count - 1
            If Trim(oList.Items(iCont).DataValue) = Trim(Valor) Then
                oList.CheckedIndex = iCont
            End If
        Next
    End Sub

    Public Sub objCheckList_SelecionarItens(ByVal oCheckList As System.Windows.Forms.CheckedListBox, _
                                            Optional ByVal bSelecionar As Boolean = True)
        Dim iCont As Integer

        For iCont = 0 To oCheckList.Items.Count - 1
            oCheckList.SetItemChecked(iCont, bSelecionar)
        Next
    End Sub

    Public Function objCheckList_SQL_In_Montar(ByVal oCheckList As System.Windows.Forms.CheckedListBox, _
                                               Optional ByVal SomenteChecado As Boolean = True) As String
        Dim iCont As Integer
        Dim sAux As String = ""

        If SomenteChecado Then
            For iCont = 0 To oCheckList.CheckedItems.Count - 1
                Str_Adicionar(sAux, oCheckList.CheckedItems(iCont)(0), ",")
            Next
        Else
            For iCont = 0 To oCheckList.Items.Count - 1
                Str_Adicionar(sAux, oCheckList.Items(iCont)(0), ",")
            Next
        End If

        If Trim(sAux) = "" Then
            sAux = " in (0)"
        Else
            sAux = " in (" & sAux & ")"
        End If

        Return sAux
    End Function

    Public Function objData_ParaArray(ByVal oData As DataTable, _
                                      ByVal iLinha As Integer, _
                                      Optional ByVal FiltroCampo() As Integer = Nothing, _
                                      Optional ByVal FiltroCampo_Tipo As objData_TipoFiltroCampo = objData_TipoFiltroCampo.Faixa) As Object
        Dim iCont As Integer = 0
        Dim iAux As Integer
        Dim Aux As Object = Nothing

        If objDataTable_Vazio(oData) Then
            Aux = Nothing
        ElseIf oData.Rows.Count = 0 Or oData.Rows.Count < (iLinha - 1) Then
            Aux = Nothing
        Else
            With oData.Rows(iLinha)
                If FiltroCampo Is Nothing Or FiltroCampo_Tipo = objData_TipoFiltroCampo.Todos Then
                    For iCont = 0 To oData.Columns.Count - 1
                        Array_Add(Aux, .Item(iCont))
                    Next
                Else
                    Select Case FiltroCampo_Tipo
                        Case objData_TipoFiltroCampo.CampoExato
                            For iCont = LBound(FiltroCampo) To UBound(FiltroCampo)
                                Array_Add(Aux, .Item(FiltroCampo(iCont)))
                            Next
                        Case objData_TipoFiltroCampo.Faixa
                            If UBound(FiltroCampo) > 0 Then
                                iAux = FiltroCampo(1)
                            Else
                                iAux = oData.Columns.Count - 1
                            End If
                            For iCont = FiltroCampo(0) To iAux
                                Array_Add(Aux, .Item(iCont))
                            Next
                    End Select
                End If
            End With
        End If

        Return Aux
    End Function

    Public Function Menu_Item_Add(ByVal Nome As String, _
                                  ByVal Titulo As String, _
                                  ByVal oMenu As ContextMenuStrip, _
                                  Optional ByVal Icone As Integer = -1) As ToolStripMenuItem
        Dim oItem As System.Windows.Forms.ToolStripMenuItem

        oItem = oMenu.Items.Add(Titulo)
        oItem.Name = Nome

        If Icone <> -1 Then
            oItem.Image = oImagemList.Images(Icone)
        End If

        Return oItem
    End Function

    Public Sub Menu_Adicionar_Separador(ByVal oMenu As ContextMenuStrip)
        oMenu.Items.Add(New ToolStripSeparator)
    End Sub
End Module

Public Class CrystalReportDocument
    Inherits ReportDocument
    Implements IDisposable

    'Frees resources used
    Public Shadows Sub Dispose()
        MyBase.Dispose(True)
        GC.SuppressFinalize(Me)
        MyBase.Dispose()
    End Sub

    Private Sub CleanGlobalEvents()
        Try
            Dim domainUnloadDelegate As [Delegate] = GetType(AppDomain).GetField("_domainUnload", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(AppDomain.CurrentDomain)
            Dim invocationList As [Delegate]() = domainUnloadDelegate.GetInvocationList()
            Dim ev As [Delegate] = Nothing
            For i As Short = 0 To invocationList.Length - 1
                ev = invocationList(i)
                If ev.Target IsNot Nothing AndAlso ev.Target.Equals(Me) Then
                    RemoveHandler AppDomain.CurrentDomain.DomainUnload, ev
                End If
            Next
            Dim processExitDelegate As [Delegate] = GetType(AppDomain).GetField("_processExit", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(AppDomain.CurrentDomain)
            invocationList = processExitDelegate.GetInvocationList()
            For i As Short = 0 To invocationList.Length - 1
                ev = invocationList(i)
                If ev.Target IsNot Nothing AndAlso ev.Target.Equals(Me) Then
                    RemoveHandler AppDomain.CurrentDomain.ProcessExit, ev
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    Protected Shadows Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            Me.Close()
        End If
        Me.CleanGlobalEvents()
        MyBase.Dispose(disposing)
    End Sub

    Protected Overrides Sub Finalize()
        Dispose(False)
        MyBase.Finalize()
    End Sub
End Class

Public Class MemoryManagement
    Private Declare Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal process As IntPtr, ByVal minimumWorkingSetSize As Integer, ByVal maximumWorkingSetSize As Integer) As Integer

    Public Shared Sub FlushMemory()
        'GC.Collect()
        'GC.WaitForPendingFinalizers()
        'If (Environment.OSVersion.Platform = PlatformID.Win32NT) Then
        '    SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1)
        'End If
    End Sub
End Class