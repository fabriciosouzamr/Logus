Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmCadastroNotaRemessa
    Const cnt_GridGeral_Selecao As Integer = 0
    Const cnt_GridGeral_DT_MOVIMENTACAO As Integer = 1
    Const cnt_GridGeral_NO_TIPO_MOVIMENTACAO As Integer = 2
    Const cnt_GridGeral_NO_RAZAO_SOCIAL As Integer = 3
    Const cnt_GridGeral_NU_SERIE_NF As Integer = 4
    Const cnt_GridGeral_NU_NF As Integer = 5
    Const cnt_GridGeral_QT_KG_NF As Integer = 6
    Const cnt_GridGeral_QT_KG_BRUTO_NF As Integer = 7
    Const cnt_GridGeral_QT_KG_LIQUIDO_NF As Integer = 8
    Const cnt_GridGeral_VL_NF As Integer = 9
    Const cnt_GridGeral_NO_FILIAL_MOVIMENTACAO As Integer = 10
    Const cnt_GridGeral_NO_FILIAL_ORIGEM As Integer = 11
    Const cnt_GridGeral_NO_CIDADE As Integer = 12
    Const cnt_GridGeral_CD_TIPO_NF As Integer = 13
    Const cnt_GridGeral_NO_LOCAL_ENTREGA As Integer = 14
    Const cnt_GridGeral_SQ_MOVIMENTACAO As Integer = 15

    Dim oDS As New UltraWinDataSource.UltraDataSource
    Dim oDSNotaRemessa As New UltraWinDataSource.UltraDataSource
    Dim ControleEdicaoTelaLocal As eControleEdicaoTela

    Dim SqNFRemessa As Integer

    Private Sub frmCadastroNotaRemessa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Pesq_TipoMovimentacao
            .BancoDados_Tabela = "SOF.TIPO_MOVIMENTACAO"
            .BancoDados_Campo_Codigo = "CD_TIPO_MOVIMENTACAO"
            .BancoDados_Campo_Descricao = "NO_TIPO_MOVIMENTACAO"
            .BancoDados_Filtro_Limpar()
            .BancoDados_Filtro_Adicionar("IC_ATIVO = 'S'")
        End With

        SelecaoFilial.BancoDados_Tabela = SQL_Filial_FilialLiberaUsuario()
        SelecaoFilial.BancoDados_Campo_Codigo = "CD_FILIAL"
        SelecaoFilial.BancoDados_Campo_Descricao = "NO_FILIAL"
        SelecaoFilial.BancoDados_Carregar()

        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False, True)
        objGrid_Coluna_Add(grdGeral, "Seleção", 70, , True, ColumnStyle.CheckBox)
        objGrid_Coluna_Add(grdGeral, "Data", 100)
        objGrid_Coluna_Add(grdGeral, "Tipo Movimentação", 100)
        objGrid_Coluna_Add(grdGeral, "Fornecedor", 100)
        objGrid_Coluna_Add(grdGeral, "Série", 60)
        objGrid_Coluna_Add(grdGeral, "NF", 50)
        objGrid_Coluna_Add(grdGeral, "KG NF", 70)
        objGrid_Coluna_Add(grdGeral, "KG Bruto", 90)
        objGrid_Coluna_Add(grdGeral, "KG Líquido", 90)
        objGrid_Coluna_Add(grdGeral, "Valor NF", 100)
        objGrid_Coluna_Add(grdGeral, "Filial Movimentação", 150)
        objGrid_Coluna_Add(grdGeral, "Filial Origem", 120)
        objGrid_Coluna_Add(grdGeral, "Município", 110)
        objGrid_Coluna_Add(grdGeral, "Tipo Doc", 100)
        objGrid_Coluna_Add(grdGeral, "Local Entrega", 100)
        objGrid_Coluna_Add(grdGeral, "Código", 100)

        objGrid_Inicializar(grdNotaRemessa, , oDSNotaRemessa, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)
        objGrid_Coluna_Add(grdNotaRemessa, "Seleção", 0, , True, ColumnStyle.CheckBox)
        objGrid_Coluna_Add(grdNotaRemessa, "Data", 100)
        objGrid_Coluna_Add(grdNotaRemessa, "Tipo Movimentação", 100)
        objGrid_Coluna_Add(grdNotaRemessa, "Fornecedor", 100)
        objGrid_Coluna_Add(grdNotaRemessa, "Série", 60)
        objGrid_Coluna_Add(grdNotaRemessa, "NF", 50)
        objGrid_Coluna_Add(grdNotaRemessa, "KG NF", 70)
        objGrid_Coluna_Add(grdNotaRemessa, "KG Bruto", 90)
        objGrid_Coluna_Add(grdNotaRemessa, "KG Líquido", 90)
        objGrid_Coluna_Add(grdNotaRemessa, "Valor NF", 100)
        objGrid_Coluna_Add(grdNotaRemessa, "Filial Movimentação", 150)
        objGrid_Coluna_Add(grdNotaRemessa, "Filial Origem", 120)
        objGrid_Coluna_Add(grdNotaRemessa, "Município", 110)
        objGrid_Coluna_Add(grdNotaRemessa, "Tipo Doc", 100)
        objGrid_Coluna_Add(grdNotaRemessa, "Local Entrega", 100)
        objGrid_Coluna_Add(grdNotaRemessa, "Código", 100)

        ControleEdicaoTelaLocal = ControleEdicaoTela

        Select Case ControleEdicaoTelaLocal
            Case eControleEdicaoTela.INCLUIR
                SqNFRemessa = -1

                cmdExcluir.Enabled = False
                cmdCopiar.Enabled = False
                cmdNovo.Enabled = False
            Case eControleEdicaoTela.ALTERAR
                SqNFRemessa = Filtro

                Dim oData As DataTable
                Dim SqlText As String

                SqlText = "SELECT * FROM SOF.NF_REMESSA WHERE SQ_NF_REMESSA=" & SqNFRemessa
                oData = DBQuery(SqlText)

                txtNotaFiscal.Text = oData.Rows(0).Item("NU_NF")
                txtSerie.Text = "" & oData.Rows(0).Item("NU_SERIE_NF")
                txtQuantidade.Value = oData.Rows(0).Item("QT_KG_NF")
                txtDataNF.Text = oData.Rows(0).Item("DT_NF_REMESSA")

                ExecutaConsultaNotaRemessa()

                cmdExcluir.Enabled = True
                cmdCopiar.Enabled = True
                cmdNovo.Enabled = False
        End Select

    End Sub

    Private Sub ExecutaConsultaMovimentacao()
        Dim SqlText As String

        If Not IsDate(txtDataMovimentacao_Ini.Value) And Not IsDate(txtDataMovimentacao_Fim.Value) And _
           SelecaoFilial.Lista_Quantidade = 0 And _
           Pesq_TipoMovimentacao.Codigo = 0 Then
            Msg_Mensagem("Informe algum dado para filtro")
            Exit Sub
        End If

        SqlText = "SELECT 0 AS SELECAO, MV.DT_MOVIMENTACAO," & _
                         "TM.NO_TIPO_MOVIMENTACAO," & _
                         "FN.NO_RAZAO_SOCIAL," & _
                         "MV.NU_SERIE_NF," & _
                         "MV.NU_NF," & _
                         "MV.QT_KG_NF," & _
                         "MV.QT_KG_BRUTO_NF," & _
                         "MV.QT_KG_LIQUIDO_NF," & _
                         "MV.VL_NF," & _
                         "FM.NO_FILIAL," & _
                         "FO.NO_FILIAL," & _
                         "MC.NO_CIDADE," & _
                         "MV.CD_TIPO_NF," & _
                         "LE.NO_LOCAL_ENTREGA," & _
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
        If SelecaoFilial.Lista_Quantidade > 0 Then
            SqlText = SqlText & " AND MV.CD_FILIAL_MOVIMENTACAO in ( " & SelecaoFilial.Lista_ID & ") "
        End If
        If Pesq_TipoMovimentacao.Codigo > 0 Then
            SqlText = SqlText & " AND MV.CD_TIPO_MOVIMENTACAO = " & Pesq_TipoMovimentacao.Codigo
        End If


        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_Selecao, cnt_GridGeral_DT_MOVIMENTACAO, _
                                                           cnt_GridGeral_NO_TIPO_MOVIMENTACAO, _
                                                           cnt_GridGeral_NO_RAZAO_SOCIAL, _
                                                           cnt_GridGeral_NU_SERIE_NF, _
                                                           cnt_GridGeral_NU_NF, _
                                                           cnt_GridGeral_QT_KG_NF, _
                                                           cnt_GridGeral_QT_KG_BRUTO_NF, _
                                                           cnt_GridGeral_QT_KG_LIQUIDO_NF, _
                                                           cnt_GridGeral_VL_NF, _
                                                           cnt_GridGeral_NO_FILIAL_MOVIMENTACAO, _
                                                           cnt_GridGeral_NO_FILIAL_ORIGEM, _
                                                           cnt_GridGeral_NO_CIDADE, _
                                                           cnt_GridGeral_CD_TIPO_NF, _
                                                           cnt_GridGeral_NO_LOCAL_ENTREGA, _
                                                           cnt_GridGeral_SQ_MOVIMENTACAO})
    End Sub

    Private Sub ExecutaConsultaNotaRemessa()
        Dim SqlText As String


        SqlText = "SELECT 0 AS SELECAO, MV.DT_MOVIMENTACAO," & _
                         "TM.NO_TIPO_MOVIMENTACAO," & _
                         "FN.NO_RAZAO_SOCIAL," & _
                         "MV.NU_SERIE_NF," & _
                         "MV.NU_NF," & _
                         "MV.QT_KG_NF," & _
                         "MV.QT_KG_BRUTO_NF," & _
                         "MV.QT_KG_LIQUIDO_NF," & _
                         "MV.VL_NF," & _
                         "FM.NO_FILIAL," & _
                         "FO.NO_FILIAL," & _
                         "MC.NO_CIDADE," & _
                         "MV.CD_TIPO_NF," & _
                         "LE.NO_LOCAL_ENTREGA," & _
                         "MV.SQ_MOVIMENTACAO" & _
                  " FROM SOF.MOVIMENTACAO MV," & _
                        "SOF.FORNECEDOR FN," & _
                        "SOF.FILIAL FM," & _
                        "SOF.FILIAL FO," & _
                        "SOF.TIPO_MOVIMENTACAO TM," & _
                        "SOF.MUNICIPIO MC," & _
                        "SOF.LOCAL_ENTREGA LE," & _
                        "sof.nf_remessa_movimentacao nrm " & _
                  " WHERE FM.CD_FILIAL = MV.CD_FILIAL_MOVIMENTACAO" & _
                    " AND TM.CD_TIPO_MOVIMENTACAO = MV.CD_TIPO_MOVIMENTACAO" & _
                    " AND MC.CD_MUNICIPIO (+) = MV.CD_MUNICIPIO_ORIGEM" & _
                    " AND FN.CD_FORNECEDOR (+) = MV.CD_FORNECEDOR" & _
                    " AND FO.CD_FILIAL (+) = MV.CD_FILIAL_ORIGEM" & _
                    " AND LE.CD_LOCAL_ENTREGA (+) = MV.CD_LOCAL_ENTREGA" & _
                    " and mv.sq_movimentacao = nrm.sq_movimentacao " & _
                    " and nrm.sq_nf_remessa=" & SqNFRemessa



        objGrid_Carregar(grdNotaRemessa, SqlText, New Integer() {cnt_GridGeral_Selecao, cnt_GridGeral_DT_MOVIMENTACAO, _
                                                           cnt_GridGeral_NO_TIPO_MOVIMENTACAO, _
                                                           cnt_GridGeral_NO_RAZAO_SOCIAL, _
                                                           cnt_GridGeral_NU_SERIE_NF, _
                                                           cnt_GridGeral_NU_NF, _
                                                           cnt_GridGeral_QT_KG_NF, _
                                                           cnt_GridGeral_QT_KG_BRUTO_NF, _
                                                           cnt_GridGeral_QT_KG_LIQUIDO_NF, _
                                                           cnt_GridGeral_VL_NF, _
                                                           cnt_GridGeral_NO_FILIAL_MOVIMENTACAO, _
                                                           cnt_GridGeral_NO_FILIAL_ORIGEM, _
                                                           cnt_GridGeral_NO_CIDADE, _
                                                           cnt_GridGeral_CD_TIPO_NF, _
                                                           cnt_GridGeral_NO_LOCAL_ENTREGA, _
                                                           cnt_GridGeral_SQ_MOVIMENTACAO})


        Dim Kg_Liquido As Double
        Dim iCont As Integer

        For iCont = 0 To grdNotaRemessa.Rows.Count - 1
            Kg_Liquido = Kg_Liquido + objGrid_Valor(grdNotaRemessa, cnt_GridGeral_QT_KG_LIQUIDO_NF, iCont)
        Next

        txtQuantidadeNFs.Value = Kg_Liquido
        txtSaldo.Value = txtQuantidade.Value - Kg_Liquido
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsultaMovimentacao()
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        Dim bExcluir As Boolean

        If objGrid_LinhaSelecionada(grdNotaRemessa) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        bExcluir = Msg_Perguntar("Deseja remover a NF?")

        If bExcluir Then
            If Not DBExecutar_Delete("SOF.nf_remessa_movimentacao", "SQ_nf_remessa", SqNFRemessa, " AND ", _
                                        "sq_movimentacao", objGrid_Valor(grdNotaRemessa, cnt_GridGeral_SQ_MOVIMENTACAO)) Then GoTo Erro
        End If

        ExecutaConsultaNotaRemessa()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String = ""
        Dim oParametro(4) As DBParamentro

        If txtNotaFiscal.Text = "" Then
            Msg_Mensagem("Favor informar o número da NF.")
            txtNotaFiscal.Focus()
            Exit Sub
        End If
        If txtQuantidade.Value = 0 Then
            Msg_Mensagem("Favor informar a quantidade.")
            txtQuantidade.Focus()
            Exit Sub
        End If
        If Not IsDate(txtDataNF.Text) Then
            Msg_Mensagem("Favor informar uma data valida para a NF.")
            txtDataNF.Focus()
            Exit Sub
        End If

        If ControleEdicaoTelaLocal = eControleEdicaoTela.INCLUIR Then
            SqNFRemessa = DBNumeroMaisUm("SOF.NF_REMESSA", "SQ_NF_REMESSA")

            If BancoDados_ExisteDados("Nota de remessa já cadastrada.", _
                                      "SOF.NF_REMESSA", "NU_NF", txtNotaFiscal.Text) Then GoTo sair

            SqlText = DBMontar_Insert("SOF.NF_REMESSA", TipoCampoFixo.Todos, "NU_NF", ":NU_NF", _
                                                                           "NU_SERIE_NF", ":NU_SERIE_NF", _
                                                                           "QT_KG_NF", ":QT_KG_NF", _
                                                                           "DT_NF_REMESSA", ":DT_NF_REMESSA", _
                                                                           "SQ_NF_REMESSA", ":SQ_NF_REMESSA")
        Else

            If BancoDados_ExisteDados("Nota de remessa já cadastrada.", _
                                     "SOF.NF_REMESSA", "NU_NF", txtNotaFiscal.Text, _
                                                            "SQ_NF_REMESSA", "NOT IN", SqNFRemessa) Then GoTo Sair

            SqlText = DBMontar_Update("SOF.NF_REMESSA", GerarArray("NU_NF", ":NU_NF", _
                                                                    "NU_SERIE_NF", ":NU_SERIE_NF", _
                                                                    "QT_KG_NF", ":QT_KG_NF", _
                                                                    "DT_NF_REMESSA", ":DT_NF_REMESSA"), _
                                                GerarArray("SQ_NF_REMESSA", ":SQ_NF_REMESSA"))
        End If

        oParametro(0) = DBParametro_Montar("NU_NF", txtNotaFiscal.Text)
        oParametro(1) = DBParametro_Montar("NU_SERIE_NF", txtSerie.Text)
        oParametro(2) = DBParametro_Montar("QT_KG_NF", txtQuantidade.Value)
        oParametro(3) = DBParametro_Montar("DT_NF_REMESSA", Date_to_Oracle(txtDataNF.Text), DbType.DateTime)
        oParametro(4) = DBParametro_Montar("SQ_NF_REMESSA", SqNFRemessa)

        If Not DBExecutar(SqlText, oParametro) Then GoTo Erro

        Msg_Mensagem("Salvo com sucesso.")
        ControleEdicaoTelaLocal = eControleEdicaoTela.ALTERAR
        cmdExcluir.Enabled = True
        cmdCopiar.Enabled = True
        cmdNovo.Enabled = True
Sair:
        Exit Sub

Erro:
        TratarErro()
    End Sub


    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        SqNFRemessa = -1
        ControleEdicaoTelaLocal = eControleEdicaoTela.INCLUIR
        ExecutaConsultaNotaRemessa()

        txtNotaFiscal.Text = ""
        txtSerie.Text = ""
        txtQuantidade.Value = 0
        txtDataNF.Value = Nothing
        txtQuantidadeNFs.Value = 0
        txtSaldo.Value = 0

        cmdExcluir.Enabled = False
        cmdCopiar.Enabled = False
        cmdNovo.Enabled = False
        cmdGravar.Enabled = True
    End Sub

    Private Sub cmdAdicionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopiar.Click
        Dim SqlText As String
        Dim iCont As Integer


        For iCont = 0 To grdGeral.Rows.Count - 1
            If objGrid_CheckBox_Selecionado(grdGeral, cnt_GridGeral_Selecao, iCont) Then
                SqlText = DBMontar_Insert("sof.nf_remessa_movimentacao", TipoCampoFixo.DadoCriacao, _
                                                                         "SQ_NF_REMESSA", ":SQ_NF_REMESSA", _
                                                                         "SQ_MOVIMENTACAO", ":SQ_MOVIMENTACAO")

                If Not DBExecutar(SqlText, DBParametro_Montar("SQ_NF_REMESSA", SqNFRemessa), _
                                               DBParametro_Montar("SQ_MOVIMENTACAO", objGrid_Valor(grdGeral, cnt_GridGeral_SQ_MOVIMENTACAO, iCont))) Then GoTo Erro

                grdGeral.Rows(iCont).Cells(cnt_GridGeral_Selecao).Value = 0
            End If
        Next

        ExecutaConsultaNotaRemessa()
        Exit Sub
Erro:
        TratarErro()
    End Sub

    Private Sub frmCadastroNotaRemessa_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Altura
        grdNotaRemessa.Height = Me.ClientSize.Height - grdNotaRemessa.Top - 5
        'Largura
        grdGeral.Width = Me.ClientSize.Width - grdGeral.Left - 5
        grdNotaRemessa.Width = Me.ClientSize.Width - grdNotaRemessa.Left - 5
        'Posição horizontal
        cmdCopiar.Left = Me.ClientSize.Width - cmdCopiar.Width - 5
        cmdExcluir.Left = Me.ClientSize.Width - cmdExcluir.Width - 55
    End Sub
End Class