Module MOD_Exportar_Util
    Public Const cnt_Menu_Item_Excel As String = "Excel"
    Public Const cnt_Menu_Item_PDF As String = "PDF"
    Public Const cnt_Menu_Item_Word As String = "Word"
    Public Const cnt_Menu_Item_HTML As String = "HTML"

    Public Const cnt_ExportarGrid_EnviarEMail As String = "ExportarGrid_EnviarEMail"
    Public Const cnt_ExportarGrid_ExportarComputador As String = "ExportarGrid_ExportarComputador"
End Module

Class MOD_Exportar_Relatorio
    Dim WithEvents oMenuExport As System.Windows.Forms.ContextMenuStrip

    Dim oForm_Local As System.Windows.Forms.Form
    Dim oBotao As Infragistics.Win.Misc.UltraButton

    Public Sub Form(ByVal oForm As System.Windows.Forms.Form)
        If oForm.Controls.IndexOfKey("cmdExportaRelatorio") > -1 Then
            oMenuExport = New System.Windows.Forms.ContextMenuStrip

            Menu_Item_Add(cnt_Menu_Item_Excel, "Excel", oMenuExport, cnt_ImagemIcone_Excell)
            Menu_Item_Add(cnt_Menu_Item_PDF, "PDF", oMenuExport, cnt_ImagemIcone_PDF)
            Menu_Item_Add(cnt_Menu_Item_Word, "Word", oMenuExport, cnt_ImagemIcone_Word)
            Menu_Item_Add(cnt_Menu_Item_HTML, "HTML", oMenuExport, cnt_ImagemIcone_HTML)

            oForm_Local = oForm

            oBotao = oForm_Local.Controls(oForm_Local.Controls.IndexOfKey("cmdExportaRelatorio"))
            AddHandler oBotao.Click, AddressOf ExportaRelatorio_Click
            oBotao.ContextMenuStrip = oMenuExport
        End If
    End Sub

    Private Function ExportRelatorio_Relatorio(ByVal Formato As CrystalDecisions.Shared.ExportFormatType, _
                                               ByVal oTempRelatorioExportacao As CrystalReportDocument) As Boolean
        Dim crExportOptions As CrystalDecisions.Shared.ExportOptions
        Dim crDiskFileDestinationOptions As CrystalDecisions.Shared.DiskFileDestinationOptions
        Dim ExportPath As String
        Dim NomeArquivo As String

        If sUsuario_EMail = "" Then
            Msg_Mensagem("Não existe e-mail cadastrado para o seu usuário. Exportação cancelada.")
            Exit Function
        End If

        Try
            ExportPath = My.Computer.FileSystem.SpecialDirectories.Temp + "\Exported\"

            If System.IO.Directory.Exists(ExportPath) = False Then
                System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\Exported\")
            End If

            Dim fname As String

            NomeArquivo = "Arquivo"

            frmUserDialogo_Texto.Carregar("Exportação de Relatório", "Informe o nome do arquivo")

            If frmUserDialogo_Texto.Cancelado Then
                Exit Function
            Else
                NomeArquivo = frmUserDialogo_Texto.Texto
            End If

            frmUserDialogo_Texto.Dispose()

            Select Case Formato
                Case CrystalDecisions.Shared.ExportFormatType.Excel
                    NomeArquivo = NomeArquivo & ".xls"
                Case CrystalDecisions.Shared.ExportFormatType.PortableDocFormat
                    NomeArquivo = NomeArquivo & ".pdf"
                Case CrystalDecisions.Shared.ExportFormatType.RichText
                    NomeArquivo = NomeArquivo & ".rtf"
                Case CrystalDecisions.Shared.ExportFormatType.HTML40
                    NomeArquivo = NomeArquivo & ".html"
            End Select

            fname = ExportPath + NomeArquivo

            If Dir(fname) <> "" Then
                Kill(fname)
            End If

            crDiskFileDestinationOptions = New CrystalDecisions.Shared.DiskFileDestinationOptions()
            crDiskFileDestinationOptions.DiskFileName = fname

            crExportOptions = oTempRelatorioExportacao.ExportOptions

            With crExportOptions
                .DestinationOptions = crDiskFileDestinationOptions
                .ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile
                .ExportFormatType = Formato
            End With

            oTempRelatorioExportacao.Export()

            EMail_Enviar(cnt_EmailExportacaoRelatorio, _
                         sUsuario_EMail, _
                         "Exportação de Relatório - " & NomeArquivo, "", _
                         False, _
                         cnt_EMail_Servidor_SMTP, _
                          System.Net.Mail.MailPriority.Normal, _
                         New String() {fname})

            Return True
        Catch ex As Exception
            TratarErro(ex.Message, , "MOD_Exportar_Relatorio.ExportRelatorio_Relatorio")
        End Try
    End Function

    Private Sub ExportRelatorio(ByVal Formato As CrystalDecisions.Shared.ExportFormatType)
        Dim iCont As Integer
        Dim oView As CrystalDecisions.Windows.Forms.CrystalReportViewer
        Dim bAchou As Boolean = False

        For iCont = 0 To oForm_Local.Controls.Count - 1
            If TypeOf oForm_Local.Controls(iCont) Is CrystalDecisions.Windows.Forms.CrystalReportViewer Then
                oView = oForm_Local.Controls(iCont)

                If Not oView.ReportSource Is Nothing Then
                    If Not ExportRelatorio_Relatorio(Formato, oView.ReportSource) Then Exit Sub
                    bAchou = True
                End If
            End If
        Next

        oView = Nothing

        If bAchou Then
            Msg_Mensagem("Mensagem enviada")
        Else
            Msg_Mensagem("Favor gerar o relatório antes.")
        End If
    End Sub

    Private Sub oMenu_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles oMenuExport.ItemClicked
        Select Case e.ClickedItem.Name
            Case cnt_Menu_Item_Excel
                ExportRelatorio(CrystalDecisions.Shared.ExportFormatType.Excel)
            Case cnt_Menu_Item_PDF
                ExportRelatorio(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
            Case cnt_Menu_Item_Word
                ExportRelatorio(CrystalDecisions.Shared.ExportFormatType.RichText)
            Case cnt_Menu_Item_HTML
                ExportRelatorio(CrystalDecisions.Shared.ExportFormatType.HTML40)
        End Select
    End Sub

    Protected Overrides Sub Finalize()
        oForm_Local = Nothing

        MyBase.Finalize()
    End Sub

    Private Sub ExportaRelatorio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        oMenuExport.Show(oBotao.MousePosition)
    End Sub
End Class

Class MOD_Exportar_Grid
    Dim WithEvents oMenuExport As System.Windows.Forms.ContextMenuStrip
    Dim oBotao_Local As Infragistics.Win.Misc.UltraButton

    Public Sub Botao(ByVal oBotao As Infragistics.Win.Misc.UltraButton)
        oBotao_Local = oBotao

        oMenuExport = New System.Windows.Forms.ContextMenuStrip

        Menu_Item_Add(cnt_ExportarGrid_EnviarEMail, "Enviar por E-Mail", oMenuExport, cnt_ImagemIcone_ExportacaoEmail)
        Menu_Item_Add(cnt_ExportarGrid_ExportarComputador, "Exportar para o Computador", oMenuExport, cnt_ImagemIcone_Pasta)

        oBotao_Local.ContextMenuStrip = oMenuExport
    End Sub

    Private Sub oMenu_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles oMenuExport.ItemClicked
        Dim bTagOcupado As Boolean

        If oBotao_Local.Tag Is Nothing Then
            bTagOcupado = False
        Else
            If oBotao_Local.Tag <> cnt_ExportarGrid_EnviarEMail And _
               oBotao_Local.Tag <> cnt_ExportarGrid_ExportarComputador Then
                bTagOcupado = True
            End If
        End If

        If bTagOcupado Then
            EnvioEmail("Erro - MOD_Exportar_Grid - " & oBotao_Local.Parent.Name, _
                       "Não foi possível enviar a planilha por e-mail. O atributo .TAG desse botão está sendo utilizado", _
                       Nothing, New String() {sEMail_SuporteTecnico})

            Msg_Mensagem("Não foi possível enviar a planilha por e-mail. O atributo .TAG desse botão está sendo utilizado")

            Exit Sub
        Else
            oBotao_Local.Tag = e.ClickedItem.Name
            oBotao_Local.PerformClick()
        End If
    End Sub
End Class