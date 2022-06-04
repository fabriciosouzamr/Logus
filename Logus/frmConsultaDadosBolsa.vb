Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmConsultaDadosBolsa
    Const cnt_GridGeral_Data As Integer = 0
    Const cnt_GridGeral_TipoMoeda As Integer = 1
    Const cnt_GridGeral_Valor As Integer = 2
    Const cnt_GridGeral_Codigo As Integer = 3

    Const cnt_SEC_Tela As String = "Transacao_Bolsa_Dados_Bolsa"

    Const cnt_PrecoUnitario As Integer = 100
    Dim oDS As New UltraWinDataSource.UltraDataSource
    Dim WithEvents oForm As frmCadastroDadosBolsa

    Private Sub frmConsultaDadosBolsa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlText As String

        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False, True)

        objGrid_Coluna_Add(grdGeral, "Data", 80)
        objGrid_Coluna_Add(grdGeral, "Tipo Moeda", 160)
        objGrid_Coluna_Add(grdGeral, "Valor", 120, , , , , "###,###,##0.0000")
        objGrid_Coluna_Add(grdGeral, "Código", 0)

        SqlText = "(SELECT T.CD_TIPO_MOEDA, T.NO_TIPO_MOEDA" & _
                   " FROM SOF.LIMITE_CREDITO_TIPO_MOEDA T" & _
                   " UNION ALL " & _
                   "SELECT " & cnt_PrecoUnitario & ", 'Preço Unitario' FROM DUAL" & _
                   " UNION ALL " & _
                   "SELECT 0 - CD_STATUS, NO_STATUS" & _
                   " FROM SOF.PROCESSO_STATUS" & _
                   " WHERE CD_PROCESSO = " & cnt_Processo_DadosBolsa & ")"

        With Selecao01
            .BancoDados_Tabela = SqlText
            .BancoDados_Campo_Codigo = "CD_TIPO_MOEDA"
            .BancoDados_Campo_Descricao = "NO_TIPO_MOEDA"
            .BancoDados_Carregar()
        End With

        SEC_ValidarBotao(cmdNovo, cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao, True)
        SEC_ValidarBotao(cmdExcluir, cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao, True)
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String
        Dim SqlText_Where As String = ""

        If Not Data_ValidarPeriodo("", txtDataInicial.Value, txtDataFinal.Value, False) Then Exit Sub

        If IsDate(txtDataInicial.Text) Then
            Str_Adicionar(SqlText_Where, "TRUNC(DATA) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text)), " AND ")
        End If
        If IsDate(txtDataFinal.Text) Then
            Str_Adicionar(SqlText_Where, "TRUNC(DATA) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text)), " AND ")
        End If

        SqlText = "SELECT LCM.DT_COTACAO," & _
                         "LCTM.NO_TIPO_MOEDA," & _
                         "LCM.VL_TAXA," & _
                         "LCM.CD_TIPO_MOEDA" & _
                  " FROM SOF.LIMITE_CREDITO_TIPO_MOEDA LCTM," & _
                        "SOF.LIMITE_CREDITO_MOEDA LCM" & _
                  " WHERE LCM.CD_TIPO_MOEDA = LCTM.CD_TIPO_MOEDA"
        Str_Adicionar(SqlText, Replace(SqlText_Where, "DATA", "LCM.DT_COTACAO"), " AND ")

        SqlText = SqlText & " UNION ALL " & _
                            "SELECT DT_COTACAO," & _
                                   "'Preço Cacau' AS NO_TIPO_MOEDA," & _
                                   "VL_PRECO, " & _
                                   cnt_PrecoUnitario & " AS CD_TIPO_MOEDA" & _
                            " FROM SOF.PRECO_CACAU"
        Str_Adicionar(SqlText, Replace(SqlText_Where, "DATA", "DT_COTACAO"), " WHERE ")

        'Indice valores
        SqlText = SqlText & " UNION ALL " & _
                            "SELECT IV.DT_INDICE_VALOR," & _
                                   "PS.NO_STATUS," & _
                                   "IV.VL_INDICE," & _
                                   "0 - IV.CD_INDICE" & _
                            " FROM SOF.INDICE_VALORES IV," & _
                                  "SOF.PROCESSO_STATUS PS" & _
                            " WHERE IV.CD_PROCESSO = " & cnt_Processo_DadosBolsa & _
                              " AND PS.CD_STATUS = IV.CD_INDICE" & _
                              " AND PS.CD_PROCESSO = " & cnt_Processo_DadosBolsa
        Str_Adicionar(SqlText, Replace(SqlText_Where, "DATA", "IV.DT_INDICE_VALOR"), " AND ")

        'Query final
        SqlText = " SELECT * FROM (" & SqlText & ")"

        If Selecao01.Lista_Quantidade <> 0 Then
            SqlText = SqlText & " WHERE CD_TIPO_MOEDA IN (" & Selecao01.Lista_ID & ")"
        End If

        SqlText = SqlText & " ORDER BY DT_COTACAO "

        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_Data, _
                                                           cnt_GridGeral_TipoMoeda, _
                                                           cnt_GridGeral_Valor, _
                                                           cnt_GridGeral_Codigo})
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsulta()
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub frmConsultaDadosBolsa_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Altura
        grdGeral.Height = Me.ClientSize.Height - grdGeral.Top - 53
        'Largura
        grdGeral.Width = Me.ClientSize.Width - grdGeral.Left - 15
        'Posição horizontal
        cmdFechar.Left = Me.ClientSize.Width - cmdFechar.Width - 15
        'Posição vertical
        cmdNovo.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdExcell.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdFechar.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdExcluir.Top = Me.ClientSize.Height - cmdExcell.Height - 6
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        Dim bExcluir As Boolean

        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If
        If CDate(objGrid_Valor(grdGeral, cnt_GridGeral_Data)) < DataSistema() Then
            Msg_Mensagem("Não é permitido excluir. Data anterior a data atual")
            Exit Sub
        Else
            bExcluir = Msg_Perguntar("Deseja excluir o registro?")
        End If
        If bExcluir Then
            If objGrid_Valor(grdGeral, cnt_GridGeral_Codigo) < 0 Then
                If Not DBExecutar_Delete("SOF.INDICE_VALORES", "CD_INDICE", Math.Abs(Val(objGrid_Valor(grdGeral, cnt_GridGeral_Codigo, , 0))), " AND ", _
                                                               "CD_PROCESSO", cnt_Processo_DadosBolsa, " AND ", _
                                                               "DT_INDICE_VALOR", QuotedStr(Date_to_Oracle(objGrid_Valor(grdGeral, cnt_GridGeral_Data)))) Then GoTo ERRO
            ElseIf objGrid_Valor(grdGeral, cnt_GridGeral_Codigo) = cnt_PrecoUnitario Then
                If Not DBExecutar_Delete("SOF.PRECO_CACAU", "DT_COTACAO", QuotedStr(Date_to_Oracle(objGrid_Valor(grdGeral, cnt_GridGeral_Data)))) Then GoTo ERRO
            Else
                If Not DBExecutar_Delete("SOF.LIMITE_CREDITO_MOEDA", "CD_TIPO_MOEDA", objGrid_Valor(grdGeral, cnt_GridGeral_Codigo), " AND ", _
                                                                     "DT_COTACAO", QuotedStr(Date_to_Oracle(objGrid_Valor(grdGeral, cnt_GridGeral_Data)))) Then GoTo ERRO
            End If
        End If

        ExecutaConsulta()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        oForm = New frmCadastroDadosBolsa
        Form_Show(Me.MdiParent, oForm, , True)
    End Sub

    Private Sub grdGeral_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdGeral.AfterCellUpdate
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If
        If CDate(objGrid_Valor(grdGeral, cnt_GridGeral_Data)) < DataSistema() Then
            Msg_Mensagem("Não é permitido excluir. Data anterior a data atual")
            Exit Sub
        End If

        Dim SqlText As String

        If objGrid_Valor(grdGeral, cnt_GridGeral_Codigo) < 0 Then
            SqlText = DBMontar_Update("SOF.INDICE_VALORES", GerarArray("VL_INDICE", ":VL_INDICE"), _
                                                            GerarArray("CD_INDICE", ":CD_INDICE", "AND", _
                                                                       "CD_PROCESSO", ":CD_PROCESSO", "AND", _
                                                                       "DT_INDICE_VALOR", ":DT_INDICE_VALOR"))

            If Not DBExecutar(SqlText, DBParametro_Montar("VL_INDICE", objGrid_Valor(grdGeral, cnt_GridGeral_Valor, , 0)), _
                                       DBParametro_Montar("CD_INDICE", Math.Abs(Val(objGrid_Valor(grdGeral, cnt_GridGeral_Codigo, , 0)))), _
                                       DBParametro_Montar("CD_PROCESSO", cnt_Processo_DadosBolsa), _
                                       DBParametro_Montar("DT_INDICE_VALOR", QuotedStr(Date_to_Oracle(objGrid_Valor(grdGeral, cnt_GridGeral_Data))))) Then GoTo Erro
        ElseIf objGrid_Valor(grdGeral, cnt_GridGeral_Codigo) = cnt_PrecoUnitario Then
            SqlText = DBMontar_Update("SOF.PRECO_CACAU", GerarArray("VL_PRECO", ":VL_PRECO"), _
                                                         GerarArray("DT_COTACAO", ":DT_COTACAO"))

            If Not DBExecutar(SqlText, DBParametro_Montar("VL_PRECO", objGrid_Valor(grdGeral, cnt_GridGeral_Valor)), _
                                       DBParametro_Montar("DT_COTACAO", QuotedStr(Date_to_Oracle(objGrid_Valor(grdGeral, cnt_GridGeral_Data))))) Then GoTo Erro
        Else
            SqlText = DBMontar_Update("SOF.LIMITE_CREDITO_MOEDA", GerarArray("VL_TAXA", ":VL_TAXA"), _
                                                                  GerarArray("CD_TIPO_MOEDA", ":CD_TIPO_MOEDA", "AND", _
                                                                            "DT_COTACAO", ":DT_COTACAO"))

            If Not DBExecutar(SqlText, DBParametro_Montar("VL_TAXA", objGrid_Valor(grdGeral, cnt_GridGeral_Valor)), _
                                       DBParametro_Montar("CD_TIPO_MOEDA", objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)), _
                                       DBParametro_Montar("DT_COTACAO", QuotedStr(Date_to_Oracle(objGrid_Valor(grdGeral, cnt_GridGeral_Data))))) Then GoTo Erro
        End If

        ExecutaConsulta()

        Exit Sub

Erro:
        TratarErro()
    End Sub
End Class