Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmConsultaTransferencia
    Const cnt_GridGeral_SqMovimentacao As Integer = 0
    Const cnt_GridGeral_DataTransferencia As Integer = 1
    Const cnt_GridGeral_DataChegada As Integer = 2
    Const cnt_GridGeral_ModalidadenoTransferencia As Integer = 3
    Const cnt_GridGeral_FilialOrigem As Integer = 4
    Const cnt_GridGeral_FilialDestino As Integer = 5
    Const cnt_GridGeral_SerieNF As Integer = 6
    Const cnt_GridGeral_NF As Integer = 7
    Const cnt_GridGeral_Quantidade As Integer = 8
    Const cnt_GridGeral_QuantidadeBruta As Integer = 9
    Const cnt_GridGeral_Valor As Integer = 10
    Const cnt_GridGeral_ValorICMS As Integer = 11
    Const cnt_GridGeral_SobraQuebra As Integer = 12
    Const cnt_GridGeral_PlacaVeiculo As Integer = 13
    Const cnt_GridGeral_Codigo As Integer = 14
    Const cnt_GridGeral_OrdemDescarga As Integer = 15

    Dim oDS As New UltraWinDataSource.UltraDataSource

    Private Sub frmConsultaTransferencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With SelecaoFilialOrigem
            .BancoDados_Tabela = "SOF.FILIAL"
            .BancoDados_Campo_Codigo = "CD_FILIAL"
            .BancoDados_Campo_Descricao = "NO_FILIAL"
            .BancoDados_Carregar()
        End With
        With SelecaoFilialDestino
            .BancoDados_Tabela = "SOF.FILIAL"
            .BancoDados_Campo_Codigo = "CD_FILIAL"
            .BancoDados_Campo_Descricao = "NO_FILIAL"
            .BancoDados_Carregar()
        End With
        With SelecaoModalidadeTransferencia
            .BancoDados_Tabela = "(SELECT * FROM SOF.TRANSFERENCIA_MODALIDADE WHERE NVL(IC_TIPO_UTILIZACAO, 'U') = 'U')"
            .BancoDados_Campo_Codigo = "CD_TRANSFERENCIA_MODALIDADE"
            .BancoDados_Campo_Descricao = "NO_TRANSFERENCIA_MODALIDADE"
            .BancoDados_Carregar()
        End With

        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False, , , , , True)

        objGrid_Coluna_Add(grdGeral, "SqMovimentacao", 0)
        objGrid_Coluna_Add(grdGeral, "Data Transferência", 120)
        objGrid_Coluna_Add(grdGeral, "Data Chegada", 100)
        objGrid_Coluna_Add(grdGeral, "Modalidade Transferência", 160)
        objGrid_Coluna_Add(grdGeral, "Filial Origem", 120)
        objGrid_Coluna_Add(grdGeral, "Filial Destino", 120)
        objGrid_Coluna_Add(grdGeral, "Serie NF", 80)
        objGrid_Coluna_Add(grdGeral, "NF", 60)
        objGrid_Coluna_Add(grdGeral, "Quant NF", 80, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "Quant NF Bruta", 110, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "Valor NF", 90, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Valor ICMS NF", 110, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Quebra\Sobra", 80, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "Placa Veiculo", 100)
        objGrid_Coluna_Add(grdGeral, "Código", 120)
        objGrid_Coluna_Add(grdGeral, "Ordem de Descarga", 120)

        objGrid_ExibirTotal(grdGeral, New Integer() {cnt_GridGeral_Quantidade, _
                                                     cnt_GridGeral_QuantidadeBruta, _
                                                     cnt_GridGeral_Valor, _
                                                     cnt_GridGeral_ValorICMS, _
                                                     cnt_GridGeral_SobraQuebra})
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String
        Dim SqlFiltro As String = ""

        If Not IsDate(txtDataInicial.Text) And Not IsDate(txtDataFinal.Text) _
           And Not chkEmTransito.Checked _
           And SelecaoFilialOrigem.Lista_Quantidade = 0 _
           And SelecaoFilialDestino.Lista_Quantidade = 0 _
           And SelecaoModalidadeTransferencia.Lista_Quantidade = 0 Then
            Msg_Mensagem("Informe pelo menos uma informação para filtro da pesquisa")
            Exit Sub
        End If

        SqlText = "SELECT M.SQ_MOVIMENTACAO," & _
                         "T.DT_TRANSFERENCIA," & _
                         "T.DT_CHEGADA," & _
                         "TM.NO_TRANSFERENCIA_MODALIDADE," & _
                         "F.NO_FILIAL AS NO_FILIAL_ORIGEM," & _
                         "F1.NO_FILIAL AS NO_FILIAL_DESTINO," & _
                         "M.NU_SERIE_NF," & _
                         "M.NU_NF," & _
                         "M.QT_KG_NF," & _
                         "M.QT_KG_BRUTO_NF," & _
                         "M.VL_NF," & _
                         "M.VL_NF_ICMS," & _
                         "M.QT_KG_SOBRA," & _
                         "T.NU_PLACA_VEICULO," & _
                         "T.SQ_TRANSFERENCIA," & _
                         "TS.CD_ORDEM_DESCARGA" & _
                  " FROM SOF.TRANSFERENCIA T," & _
                        "SOF.MOVIMENTACAO_QUALIDADE MQ," & _
                        "SOF.MOVIMENTACAO M," & _
                        "SOF.FILIAL F," & _
                        "SOF.FILIAL F1," & _
                        "SOF.TRANSFERENCIA_MODALIDADE TM," & _
                        "SOF.TRANSFERENCIA_SUMMUS TS" & _
                  " WHERE T.SQ_MOVIMENTACAO_SAIDA = M.SQ_MOVIMENTACAO" & _
                    " AND T.CD_FILIAL_ORIGEM = F.CD_FILIAL" & _
                    " AND T.CD_FILIAL_DESTINO = F1.CD_FILIAL" & _
                    " AND T.CD_TRANSFERENCIA_MODALIDADE = TM.CD_TRANSFERENCIA_MODALIDADE" & _
                    " AND NVL(TM.IC_TIPO_UTILIZACAO, 'X') NOT IN ('T')" & _
                    " AND M.SQ_MOVIMENTACAO = MQ.SQ_MOVIMENTACAO (+)" & _
                    " AND TS.SQ_TRANSFERENCIA_LOGUS (+) = T.SQ_TRANSFERENCIA "

        'FILTRO FILIAL ORIGEM
        If SelecaoFilialOrigem.Lista_Quantidade > 0 Then
            SqlText = SqlText & "  AND T.CD_FILIAL_ORIGEM IN (" & SelecaoFilialOrigem.Lista_ID & ")"
        Else
            SqlText = SqlText & "  AND T.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If

        'FILTRO FILIAL DESTINO
        If SelecaoFilialDestino.Lista_Quantidade > 0 Then
            SqlText = SqlText & "  AND T.CD_FILIAL_DESTINO IN (" & SelecaoFilialDestino.Lista_ID & ")"
        End If
        If chkEmTransito.Checked = True Then
            SqlText = SqlText & " AND T.DT_CHEGADA IS NULL"
        Else
            SqlText = SqlText & " AND T.DT_CHEGADA IS NOT NULL"
        End If
        If IsDate(txtDataInicial.Text) Then
            SqlText = SqlText & " AND TRUNC( T.DT_TRANSFERENCIA ) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text))
        End If
        If IsDate(txtDataFinal.Text) Then
            SqlText = SqlText & " AND TRUNC( T.DT_TRANSFERENCIA ) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        End If
        If SelecaoModalidadeTransferencia.Lista_Quantidade > 0 Then
            SqlText = SqlText & "  AND T.CD_TRANSFERENCIA_MODALIDADE  IN (" & SelecaoModalidadeTransferencia.Lista_ID & ")"
        End If

        SqlText = SqlText & " ORDER BY T.DT_TRANSFERENCIA"

        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_SqMovimentacao, _
                                                           cnt_GridGeral_DataTransferencia, _
                                                           cnt_GridGeral_DataChegada, _
                                                           cnt_GridGeral_ModalidadenoTransferencia, _
                                                           cnt_GridGeral_FilialOrigem, _
                                                           cnt_GridGeral_FilialDestino, _
                                                           cnt_GridGeral_SerieNF, _
                                                           cnt_GridGeral_NF, _
                                                           cnt_GridGeral_Quantidade, _
                                                           cnt_GridGeral_QuantidadeBruta, _
                                                           cnt_GridGeral_Valor, _
                                                           cnt_GridGeral_ValorICMS, _
                                                           cnt_GridGeral_SobraQuebra, _
                                                           cnt_GridGeral_PlacaVeiculo, _
                                                           cnt_GridGeral_Codigo, _
                                                           cnt_GridGeral_OrdemDescarga})
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsulta()
    End Sub

    Private Sub cmdUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Auditoria(TipoCampoFixo.Todos, "transferencia", "sq_transferencia = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo))
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub frmConsultaTransferencia_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Altura
        grdGeral.Height = Me.ClientSize.Height - grdGeral.Top - 53
        'Largura
        grdGeral.Width = Me.ClientSize.Width - grdGeral.Left - 15
        'Posição horizontal
        cmdFechar.Left = Me.ClientSize.Width - cmdFechar.Width - 15
        cmdUsuario.Left = Me.ClientSize.Width - cmdUsuario.Width - 65
        'Posição vertical
        cmdExcell.Top = Me.ClientSize.Height - cmdFechar.Height - 6
        cmdInformacoes.Top = Me.ClientSize.Height - cmdInformacoes.Height - 6
        cmdRastreabilidade.Top = Me.ClientSize.Height - cmdRastreabilidade.Height - 6
        cmdUsuario.Top = Me.ClientSize.Height - cmdFechar.Height - 6
        cmdFechar.Top = Me.ClientSize.Height - cmdFechar.Height - 6
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub cmdInformacoes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInformacoes.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Dim oForm As New frmMovimentacaoCacau_Info

        oForm.Carregar(objGrid_Valor(grdGeral, cnt_GridGeral_SqMovimentacao))

        Form_Show(Nothing, oForm, True, True)

        oForm.Dispose()
    End Sub

    Private Sub cmdRastreabilidade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRastreabilidade.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Dim oForm As New frmMovimentacaoCacau_Rastreabilidade

        oForm.Movimentacao(objGrid_Valor(grdGeral, cnt_GridGeral_SqMovimentacao))

        Form_Show(Me.MdiParent, oForm)
    End Sub
End Class