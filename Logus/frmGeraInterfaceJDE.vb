Public Class frmGeraInterfaceJDE
    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmGeraInterfaceJDE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtData.Value = DataSistema()
        ComboBox_Carregar_Tipo_Interface_JDE(cboTipoInterface)
    End Sub

    Private Function Valida_Dados() As Boolean
        Valida_Dados = True
        If Not ComboBox_LinhaSelecionada(cboTipoInterface) Then
            Msg_Mensagem("Favor selecionar um tipo de interface.")
            Valida_Dados = False
            Exit Function
        End If
        If Not IsDate(txtData.Text) Then
            Msg_Mensagem("Data invalida.")
            Valida_Dados = False
            Exit Function
        End If
    End Function

    Private Sub cmdRefazInterface_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefazInterface.Click
        RefazInterface()
    End Sub

    Private Sub RefazInterface(Optional ByVal bExibirMensagem As Boolean = True, _
                               Optional ByVal bGerarDiaAnterior As Boolean = False)
        If Not Valida_Dados() Then Exit Sub

        If CDate(txtData.Value) < CDate(DataSistema()) And Not bGerarDiaAnterior Then
            Msg_Mensagem("Não é permitido refaz a interface de dia anterior.")
            Exit Sub
        End If
        If CDate(txtData.Value) >= CDate(DataSistema()) Then
            If Not Msg_Perguntar("É possível que não exista movimentações para a data informada. Deseja continuar?") Then Exit Sub
        End If

        Dim SqlText As String = ""

        Select Case cboTipoInterface.SelectedValue
            Case 1
                SqlText = DBMontar_SP("SOF.INTERFACE_JDE_REC", False, ":DATA")
            Case 2
                SqlText = DBMontar_SP("SOF.INTERFACE_JDE_PAG", False, ":DATA")
        End Select

        If Not DBExecutar(SqlText, DBParametro_Montar("DATA", Date_to_Oracle(txtData.Text))) Then GoTo Erro

        If bExibirMensagem Then
            Msg_Mensagem("Interface refeita com sucesso.")
        End If

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub cmdGeraArquivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGeraArquivo.Click
        If Not Valida_Dados() Then Exit Sub

        Dim SqlText As String
        Dim NomeArq As String = ""
        Dim Diretorio As String = System.Web.Configuration.WebConfigurationManager.AppSettings("DIRETORIO_JDE").ToString.ToUpper()

        If Msg_Perguntar("Deseja realizar a Interface? ?") = False Then Exit Sub

        RefazInterface(False, True)

        Select Case cboTipoInterface.SelectedValue
            Case 1
                NomeArq = "crc" & Format(Now.Date, "MMdd") & ".069"
            Case 2
                NomeArq = "cpg" & Format(Now.Date, "MMdd") & ".069"
        End Select

        SqlText = DBMontar_SP("SOF.GERA_ARQUIVO_JDE", False, ":TIPOINTER", _
                                                              ":DATA", _
                                                              ":NOMEARQ", _
                                                              ":DIRETORIO")

        If Not DBExecutar(SqlText, DBParametro_Montar("TIPOINTER", cboTipoInterface.SelectedValue), _
                                   DBParametro_Montar("DATA", Date_to_Oracle(txtData.Text)), _
                                   DBParametro_Montar("NOMEARQ", NomeArq), _
                                   DBParametro_Montar("DIRETORIO", Diretorio)) Then GoTo Erro

        Msg_Mensagem("Arquivo " & NomeArq & " gerado com sucesso.")

        Exit Sub

Erro:
        TratarErro()
    End Sub
End Class