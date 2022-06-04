Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmPesq_Movimentacao
    Const cnt_GridGeral_DT_MOVIMENTACAO As Integer = 0
    Const cnt_GridGeral_NO_TIPO_MOVIMENTACAO As Integer = 1
    Const cnt_GridGeral_NO_RAZAO_SOCIAL As Integer = 2
    Const cnt_GridGeral_NU_SERIE_NF As Integer = 3
    Const cnt_GridGeral_NU_NF As Integer = 4
    Const cnt_GridGeral_NU_NF_REFERENCIA As Integer = 5
    Const cnt_GridGeral_DT_NF_REFERENCIA As Integer = 6
    Const cnt_GridGeral_QT_KG_NF As Integer = 7
    Const cnt_GridGeral_QT_KG_BRUTO_NF As Integer = 8
    Const cnt_GridGeral_QT_KG_LIQUIDO_NF As Integer = 9
    Const cnt_GridGeral_QT_DESCONTO_QUALIDADE As Integer = 10
    Const cnt_GridGeral_QT_KG_A_TRANSFERIR As Integer = 11
    Const cnt_GridGeral_VL_NF As Integer = 12
    Const cnt_GridGeral_VL_NF_ICMS As Integer = 13
    Const cnt_GridGeral_VL_NF_FUNRURAL As Integer = 14
    Const cnt_GridGeral_QT_KG_SOBRA As Integer = 15
    Const cnt_GridGeral_NO_FILIAL_MOVIMENTACAO As Integer = 16
    Const cnt_GridGeral_NO_FILIAL_ORIGEM As Integer = 17
    Const cnt_GridGeral_NO_CIDADE As Integer = 18
    Const cnt_GridGeral_CD_TIPO_NF As Integer = 19
    Const cnt_GridGeral_NO_LOCAL_ENTREGA As Integer = 20
    Const cnt_GridGeral_CD_PROCEDENCIA As Integer = 21
    Const cnt_GridGeral_NU_ORDEM_DESCARGA As Integer = 22
    Const cnt_GridGeral_SQ_ITEM_MOV_BANCARIO As Integer = 23
    Const cnt_GridGeral_SQ_MOVIMENTACAO As Integer = 24

    Dim oPesq_CodigoNome As Pesq_CodigoNome
    Dim oDS As New UltraWinDataSource.UltraDataSource

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Close()
    End Sub

    Private Sub cmdSelecionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelecionar.Click
        RegistroSelecionado()
    End Sub

    Private Sub frmPesq_Movimentacao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_FilialMovimentacao.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Filial
        Pesq_Fornecedor.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        With Pesq_TipoMovimentacao
            .BancoDados_Tabela = "SOF.TIPO_MOVIMENTACAO"
            .BancoDados_Campo_Codigo = "CD_TIPO_MOVIMENTACAO"
            .BancoDados_Campo_Descricao = "NO_TIPO_MOVIMENTACAO"
        End With

        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False, True)
        objGrid_Coluna_Add(grdGeral, "Data", 100)
        objGrid_Coluna_Add(grdGeral, "Tipo Movimentação", 100)
        objGrid_Coluna_Add(grdGeral, "Fornecedor", 100)
        objGrid_Coluna_Add(grdGeral, "Série", 60)
        objGrid_Coluna_Add(grdGeral, "NF", 50)
        objGrid_Coluna_Add(grdGeral, "NF Ref", 100)
        objGrid_Coluna_Add(grdGeral, "Dt Ref", 80)
        objGrid_Coluna_Add(grdGeral, "KG NF", 70)
        objGrid_Coluna_Add(grdGeral, "KG Bruto", 90)
        objGrid_Coluna_Add(grdGeral, "KG Líquido", 90)
        objGrid_Coluna_Add(grdGeral, "KG Desconto Qualidade", 150)
        objGrid_Coluna_Add(grdGeral, "KG a Transferir", 180)
        objGrid_Coluna_Add(grdGeral, "Valor NF", 100)
        objGrid_Coluna_Add(grdGeral, "Valor ICMS", 100)
        objGrid_Coluna_Add(grdGeral, "Valor Funrural", 130)
        objGrid_Coluna_Add(grdGeral, "Quebra/Sobra", 100)
        objGrid_Coluna_Add(grdGeral, "Filial Movimentação", 150)
        objGrid_Coluna_Add(grdGeral, "Filial Origem", 120)
        objGrid_Coluna_Add(grdGeral, "Município", 110)
        objGrid_Coluna_Add(grdGeral, "Tipo Doc", 100)
        objGrid_Coluna_Add(grdGeral, "Local Entrega", 100)
        objGrid_Coluna_Add(grdGeral, "Procedência", 100)
        objGrid_Coluna_Add(grdGeral, "Ordem Descarga", 100)
        objGrid_Coluna_Add(grdGeral, "Mov. Bancário", 100)
        objGrid_Coluna_Add(grdGeral, "Código", 100)
    End Sub

    Property Form_Pesq_CodigoNome() As Pesq_CodigoNome
        Get
            Return oPesq_CodigoNome
        End Get
        Set(ByVal Valor As Pesq_CodigoNome)
            oPesq_CodigoNome = Valor
        End Set
    End Property

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsulta()
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String

        If Not IsDate(txtDataMovimentacao_Ini.Value) And Not IsDate(txtDataMovimentacao_Fim.Value) And _
           Pesq_FilialMovimentacao.Codigo = 0 And Pesq_Fornecedor.Codigo = 0 And _
           Pesq_TipoMovimentacao.Codigo = 0 And txtOrdemDescarga.Value <= 0 And _
           Trim(txtNotaFiscal.Text) = "" Then
            Msg_Mensagem("Informe algum dado para filtro")
            Exit Sub
        End If

        SqlText = "SELECT MV.DT_MOVIMENTACAO," & _
                         "TM.NO_TIPO_MOVIMENTACAO," & _
                         "FN.NO_RAZAO_SOCIAL," & _
                         "MV.NU_SERIE_NF," & _
                         "MV.NU_NF," & _
                         "MV.NU_NF_REFERENCIA," & _
                         "MV.DT_NF_REFERENCIA," & _
                         "MV.QT_KG_NF," & _
                         "MV.QT_KG_BRUTO_NF," & _
                         "MV.QT_KG_LIQUIDO_NF," & _
                         "MV.QT_DESCONTO_QUALIDADE," & _
                         "MV.QT_KG_A_TRANSFERIR," & _
                         "MV.VL_NF," & _
                         "MV.VL_NF_ICMS," & _
                         "MV.VL_NF_FUNRURAL," & _
                         "MV.QT_KG_SOBRA," & _
                         "FM.NO_FILIAL," & _
                         "FO.NO_FILIAL," & _
                         "MC.NO_CIDADE," & _
                         "MV.CD_TIPO_NF," & _
                         "LE.NO_LOCAL_ENTREGA," & _
                         "MV.CD_PROCEDENCIA," & _
                         "MV.NU_ORDEM_DESCARGA," & _
                         "MV.SQ_ITEM_MOV_BANCARIO," & _
                         "MV.SQ_MOVIMENTACAO" & _
                  " FROM SOF.MOVIMENTACAO MV," & _
                        "SOF.FORNECEDOR FN," & _
                        "SOF.FILIAL FM," & _
                        "SOF.FILIAL FO," & _
                        "SOF.TIPO_MOVIMENTACAO TM," & _
                        "SOF.MUNICIPIO MC," & _
                        "SOF.LOCAL_ENTREGA LE" & _
                  " WHERE FM.CD_FILIAL = MV.CD_FILIAL_MOVIMENTACAO" & _
                    " AND TM.CD_TIPO_MOVIMENTACAO = MV.CD_TIPO_MOVIMENTACAO" & _
                    " AND MC.CD_MUNICIPIO (+) = MV.CD_MUNICIPIO_ORIGEM" & _
                    " AND FN.CD_FORNECEDOR (+) = MV.CD_FORNECEDOR" & _
                    " AND FO.CD_FILIAL (+) = MV.CD_FILIAL_ORIGEM" & _
                    " AND LE.CD_LOCAL_ENTREGA (+) = MV.CD_LOCAL_ENTREGA"

        If IsDate(txtDataMovimentacao_Ini.Value) Then
            SqlText = SqlText & " AND TRUNC(MV.DT_MOVIMENTACAO) >= " & QuotedStr(Date_to_Oracle(txtDataMovimentacao_Ini.Value))
        End If
        If IsDate(txtDataMovimentacao_Fim.Value) Then
            SqlText = SqlText & " AND TRUNC(MV.DT_MOVIMENTACAO) <= " & QuotedStr(Date_to_Oracle(txtDataMovimentacao_Fim.Value))
        End If
        If Pesq_FilialMovimentacao.Codigo > 0 Then
            SqlText = SqlText & " AND MV.CD_FILIAL_MOVIMENTACAO = " & Pesq_FilialMovimentacao.Codigo
        End If
        If Pesq_Fornecedor.Codigo > 0 Then
            SqlText = SqlText & " AND MV.CD_FORNECEDOR = " & Pesq_Fornecedor.Codigo
        End If
        If Pesq_TipoMovimentacao.Codigo > 0 Then
            SqlText = SqlText & " AND MV.CD_TIPO_MOVIMENTACAO = " & Pesq_TipoMovimentacao.Codigo
        End If
        If txtOrdemDescarga.Value > 0 Then
            SqlText = SqlText & " AND TRIM(MV.NU_ORDEM_DESCARGA) = " & QuotedStr(Trim(txtOrdemDescarga.Value))
        End If
        If Trim(txtNotaFiscal.Text) <> "" Then
            SqlText = SqlText & " AND MV.NU_NF = " & QuotedStr(Trim(txtNotaFiscal.Text))
        End If

        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_DT_MOVIMENTACAO, _
                                                           cnt_GridGeral_NO_TIPO_MOVIMENTACAO, _
                                                           cnt_GridGeral_NO_RAZAO_SOCIAL, _
                                                           cnt_GridGeral_NU_SERIE_NF, _
                                                           cnt_GridGeral_NU_NF, _
                                                           cnt_GridGeral_NU_NF_REFERENCIA, _
                                                           cnt_GridGeral_DT_NF_REFERENCIA, _
                                                           cnt_GridGeral_QT_KG_NF, _
                                                           cnt_GridGeral_QT_KG_BRUTO_NF, _
                                                           cnt_GridGeral_QT_KG_LIQUIDO_NF, _
                                                           cnt_GridGeral_QT_DESCONTO_QUALIDADE, _
                                                           cnt_GridGeral_QT_KG_A_TRANSFERIR, _
                                                           cnt_GridGeral_VL_NF, _
                                                           cnt_GridGeral_VL_NF_ICMS, _
                                                           cnt_GridGeral_VL_NF_FUNRURAL, _
                                                           cnt_GridGeral_QT_KG_SOBRA, _
                                                           cnt_GridGeral_NO_FILIAL_MOVIMENTACAO, _
                                                           cnt_GridGeral_NO_FILIAL_ORIGEM, _
                                                           cnt_GridGeral_NO_CIDADE, _
                                                           cnt_GridGeral_CD_TIPO_NF, _
                                                           cnt_GridGeral_NO_LOCAL_ENTREGA, _
                                                           cnt_GridGeral_CD_PROCEDENCIA, _
                                                           cnt_GridGeral_NU_ORDEM_DESCARGA, _
                                                           cnt_GridGeral_SQ_ITEM_MOV_BANCARIO, _
                                                           cnt_GridGeral_SQ_MOVIMENTACAO})
    End Sub

    Private Sub RegistroSelecionado()
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        With oPesq_CodigoNome
            .TelaFiltro = True
            .Codigo = objGrid_Valor(grdGeral, cnt_GridGeral_SQ_MOVIMENTACAO)
            .TelaFiltro = False
        End With

        Close()
    End Sub

    Private Sub grdGeral_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles grdGeral.DoubleClickRow
        RegistroSelecionado()
    End Sub
End Class