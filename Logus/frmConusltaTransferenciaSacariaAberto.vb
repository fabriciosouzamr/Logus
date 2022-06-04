Imports Infragistics.Win

Public Class frmConusltaTransferenciaSacariaAberto
    Const cnt_GridGeral_SQ_SACARIA_TRANSFERENCIA As Integer = 0
    Const cnt_GridGeral_Data As Integer = 1
    Const cnt_GridGeral_Documento As Integer = 2
    Const cnt_GridGeral_FilialOrigem As Integer = 3
    Const cnt_GridGeral_TipoSacaria As Integer = 4
    Const cnt_GridGeral_Quantidade As Integer = 5
    Const cnt_GridGeral_FilialDestino As Integer = 6
    Const cnt_GridGeral_CD_FILIAL_DESTINO As Integer = 7

    Dim oDS As New UltraWinDataSource.UltraDataSource

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub frmConusltaTransferenciaSacariaAberto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox_Carregar_Filial(cboFilial, True, , , True)

        objGrid_Inicializar(grdGeral, , oDS)
        objGrid_Coluna_Add(grdGeral, "SQ_SACARIA_TRANSFERENCIA", 0)
        objGrid_Coluna_Add(grdGeral, "Data", 80)
        objGrid_Coluna_Add(grdGeral, "Documento", 100)
        objGrid_Coluna_Add(grdGeral, "Filial de Origem", 120)
        objGrid_Coluna_Add(grdGeral, "Tipo de Sacaria", 120)
        objGrid_Coluna_Add(grdGeral, "Quantidade", 100)
        objGrid_Coluna_Add(grdGeral, "Filial de Destino", 130)
        objGrid_Coluna_Add(grdGeral, "CD_FILIAL_DESTINO", 0)

        SEC_ValidarBotao_Permissao(cmdRecepcionarTransferencia, SEC_Permissao.SEC_P_Acesso_RecepcionarTransferenciaSacariaAberto, True)
    End Sub

    Private Sub Pesquisar()
        Dim SqlText As String

        If Not ComboBox_LinhaSelecionada(cboFilial) Then
            Msg_Mensagem("Selecione uma filial")
            Exit Sub
        End If
        
        SqlText = "SELECT ST.SQ_SACARIA_TRANSFERENCIA," & _
                         "ST.DT_MOVIMENTACAO," & _
                         "ST.NU_DOCUMENTO," & _
                         "F.NO_FILIAL," & _
                         "TS.NO_TIPO_SACARIA," & _
                         "ST.QT_SACOS," & _
                         "FDES.NO_FILIAL AS NO_FILDES," & _
                         "FDES.CD_FILIAL CD_FILIAL_DESTINO" & _
                  " FROM SOF.SACARIA_TRANSFERENCIA ST," & _
                        "SOF.TIPO_SACARIA TS," & _
                        "SOF.FILIAL F," & _
                        "SOF.FILIAL FDES" & _
                  " WHERE ST.CD_FILIAL_DESTINO = " & cboFilial.SelectedValue & _
                    " AND ST.SQ_SACARIA_FILIAL_REC IS NULL" & _
                    " AND TS.CD_TIPO_SACARIA = ST.CD_TIPO_SACARIA" & _
                    " AND F.CD_FILIAL = ST.CD_FILIAL_ORIGEM" & _
                    " AND FDES.CD_FILIAL = ST.CD_FILIAL_DESTINO" & _
                 " ORDER BY ST.DT_MOVIMENTACAO"

        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_SQ_SACARIA_TRANSFERENCIA, cnt_GridGeral_Data, _
                                                           cnt_GridGeral_Documento, cnt_GridGeral_FilialOrigem, _
                                                           cnt_GridGeral_TipoSacaria, cnt_GridGeral_Quantidade, _
                                                           cnt_GridGeral_FilialDestino, cnt_GridGeral_CD_FILIAL_DESTINO})
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        Pesquisar()
    End Sub

    Private Sub cmdRecepcionarTransferencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRecepcionarTransferencia.Click
        Dim SqlText As String

        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Selecione um registro")
            Exit Sub
        End If

        If FilialFechada(objGrid_Valor(grdGeral, cnt_GridGeral_CD_FILIAL_DESTINO)) Then Exit Sub

        If Not Msg_Perguntar("Recebe a transferencia ?") Then Exit Sub

        SqlText = DBMontar_SP("SOF.SACARIA_TRANSF_RECEBE", False, ":SQ")

        If Not DBExecutar(SqlText, _
                          DBParametro_Montar("SQ", objGrid_Valor(grdGeral, cnt_GridGeral_SQ_SACARIA_TRANSFERENCIA))) Then GoTo Erro

        Pesquisar()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub cmdUsuario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdUsuario.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Auditoria(TipoCampoFixo.Todos, "SACARIA_TRANSFERENCIA", "SQ_SACARIA_TRANSFERENCIA = " & _
                                                                objGrid_Valor(grdGeral, cnt_GridGeral_SQ_SACARIA_TRANSFERENCIA))
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub frmConusltaTransferenciaSacariaAberto_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Altura
        grdGeral.Height = Me.ClientSize.Height - grdGeral.Top - 53
        'Largura
        grdGeral.Width = Me.ClientSize.Width - grdGeral.Left - 15
        'Posição horizontal
        cmdFechar.Left = Me.ClientSize.Width - cmdFechar.Width - 15
        cmdUsuario.Left = Me.ClientSize.Width - cmdUsuario.Width - 65
        'Posição vertical
        cmdExcell.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdRecepcionarTransferencia.Top = Me.ClientSize.Height - cmdRecepcionarTransferencia.Height - 6
        cmdFechar.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdUsuario.Top = Me.ClientSize.Height - cmdExcell.Height - 6
    End Sub
End Class