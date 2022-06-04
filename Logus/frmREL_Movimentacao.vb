Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_Movimentacao
    Const cnt_Opcoes_Agrupar_Por_Filial As Integer = 1
    Const cnt_Opcoes_Agrupar_Por_Tipo_Movimentacao As Integer = 2
    Const cnt_Opcoes_Agrupar_Por_Tipo_Documento As Integer = 3
    Const cnt_Opcoes_Agrupar_Por_Municipio As Integer = 4

    Const cnt_GridAnaliseLinha_Umidade As Integer = 0
    Const cnt_GridAnaliseLinha_Sujidade As Integer = 1
    Const cnt_GridAnaliseLinha_Achatada As Integer = 2
    Const cnt_GridAnaliseLinha_Ardosia As Integer = 3
    Const cnt_GridAnaliseLinha_Fumaca As Integer = 4
    Const cnt_GridAnaliseLinha_Mofo As Integer = 5
    Const cnt_GridAnaliseLinha_PAmendoa As Integer = 6

    Public oTipoRelatorio As RGFP_TipoRelatorio

    Dim oRelatorio As New CrystalReportDocument
    Dim oDS As New Infragistics.Win.UltraWinDataSource.UltraDataSource

    Public Enum RGFP_TipoRelatorio
        Fornecedor = 1
        Filial = 2
    End Enum

    Private Sub frmREL_Movimentacao_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_Movimentacao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlText As String

        ComboBox_Carregar_Tipo_Cacau(cboTipoCacau, True)

        'Seleção Filial Movimentação
        SelecaoFilialMovimentacao.BancoDados_Tabela = SQL_Filial_FilialLiberaUsuario()
        SelecaoFilialMovimentacao.BancoDados_Campo_Codigo = "CD_FILIAL"
        SelecaoFilialMovimentacao.BancoDados_Campo_Descricao = "NO_FILIAL"
        SelecaoFilialMovimentacao.BancoDados_Carregar()
        'Seleção Filial Recebimento
        SelecaoFilialRecebimento.BancoDados_Tabela = SQL_Filial_FilialLiberaUsuario()
        SelecaoFilialRecebimento.BancoDados_Campo_Codigo = "CD_FILIAL"
        SelecaoFilialRecebimento.BancoDados_Campo_Descricao = "NO_FILIAL"
        SelecaoFilialRecebimento.BancoDados_Carregar()
        'Seleção Fornecedor
        SelecaoFornecedor.BancoDados_Tabela = "FORNECEDOR"
        SelecaoFornecedor.BancoDados_Campo_Codigo = "CD_FORNECEDOR"
        SelecaoFornecedor.BancoDados_Campo_Descricao = "NO_RAZAO_SOCIAL"
        SelecaoFornecedor.MultiplaSelecao = True
        'Seleção Opções Agrupamento
        SqlText = "(SELECT * " & _
                   " FROM (SELECT 1 CD_TIPO, 'Por Filial' NO_TIPO FROM DUAL UNION " & _
                          "SELECT 2 CD_TIPO, 'Por Tipo de Movimentação' NO_TIPO FROM DUAL UNION " & _
                          "SELECT 3 CD_TIPO, 'Por Tipo de Documento' NO_TIPO FROM DUAL UNION " & _
                          "SELECT 4 CD_TIPO, 'Por Município' NO_TIPO FROM DUAL))"
        SelecaoOpcoes.BancoDados_Tabela = SqlText
        SelecaoOpcoes.BancoDados_Campo_Codigo = "CD_TIPO"
        SelecaoOpcoes.BancoDados_Campo_Descricao = "NO_TIPO"
        SelecaoOpcoes.BancoDados_Filtro_Limpar()
        SelecaoOpcoes.BancoDados_Carregar()

        'Seleção Tipo de Movimentação - Valido apenas os ativos
        SqlText = "(SELECT TM.CD_TIPO_MOVIMENTACAO," & _
                          "TM.CD_TIPO_MOVIMENTACAO || '-' || TM.NO_TIPO_MOVIMENTACAO AS NO_TIPO_MOVIMENTACAO" & _
                   " FROM  SOF.TIPO_MOVIMENTACAO TM" & _
                   " WHERE  NVL (TM.IC_ATIVO, 'S') = 'S')"
        SelecaoTipoNovimentacao.BancoDados_Tabela = SqlText
        SelecaoTipoNovimentacao.BancoDados_Campo_Codigo = "CD_TIPO_MOVIMENTACAO"
        SelecaoTipoNovimentacao.BancoDados_Campo_Descricao = "NO_TIPO_MOVIMENTACAO"
        SelecaoTipoNovimentacao.BancoDados_Filtro_Limpar()
        SelecaoTipoNovimentacao.BancoDados_Carregar()
        'Grid Análise
        objGrid_Inicializar(grdAnalise, , oDS)
        objGrid_Coluna_Add(grdAnalise, "CD_ANALISE", 0)
        objGrid_Coluna_Add(grdAnalise, "Análise", 65)
        objGrid_Coluna_Add(grdAnalise, "Mínimo", 65, , True, , , cnt_Formato_Fracao_Simples)
        objGrid_Coluna_Add(grdAnalise, "Máximo", 65, , True, , , cnt_Formato_Fracao_Simples)
        With oDS.Rows.Add
            .Item(0) = cnt_GridAnaliseLinha_Umidade
            .Item(1) = "Umidade"
        End With
        With oDS.Rows.Add
            .Item(0) = cnt_GridAnaliseLinha_Sujidade
            .Item(1) = "Sujidade"
        End With
        With oDS.Rows.Add
            .Item(0) = cnt_GridAnaliseLinha_Achatada
            .Item(1) = "Achatada"
        End With
        With oDS.Rows.Add
            .Item(0) = cnt_GridAnaliseLinha_Ardosia
            .Item(1) = "Ardosia"
        End With
        With oDS.Rows.Add
            .Item(0) = cnt_GridAnaliseLinha_Fumaca
            .Item(1) = "Fumaça"
        End With
        With oDS.Rows.Add
            .Item(0) = cnt_GridAnaliseLinha_Mofo
            .Item(1) = "Mofo"
        End With
        With oDS.Rows.Add
            .Item(0) = cnt_GridAnaliseLinha_PAmendoa
            .Item(1) = "P.Amêndoa"
        End With

        Select Case oTipoRelatorio
            Case RGFP_TipoRelatorio.Filial
                Me.Text = "Relatório Movimentação de Cacau por Filial"

                optTipoPessoa.Visible = False
                chkExibeCessaoDireito.Visible = False
                SelecaoFornecedor.Visible = False
                lblR_Fornecedor.Visible = False
                lblR_Filial.Text = "Filial do Fornecedor"
        End Select

        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub frmREL_Movimentacao_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Imprimir()
    End Sub

    Private Sub Imprimir()
        Dim oData As DataTable
        Dim SqlText As String = ""
        Dim SqlText_Analise As String = ""
        Dim sFiltro As String = ""
        Dim bAgruparFilial As Boolean = False
        Dim bAgruparMunicipio As Boolean = False
        Dim bAgruparTipoDocumento As Boolean = False
        Dim bAgruparTipoMovimentacao As Boolean = False
        Dim iLinha As Integer

        With SelecaoOpcoes
            bAgruparFilial = (InStr("," & Replace(.Lista_ID, " ", "") & ",", "," & Trim(cnt_Opcoes_Agrupar_Por_Filial) & ",") > 0)
            bAgruparMunicipio = (InStr("," & Replace(.Lista_ID, " ", "") & ",", "," & Trim(cnt_Opcoes_Agrupar_Por_Municipio) & ",") > 0)
            bAgruparTipoDocumento = (InStr("," & Replace(.Lista_ID, " ", "") & ",", "," & Trim(cnt_Opcoes_Agrupar_Por_Tipo_Documento) & ",") > 0)
            bAgruparTipoMovimentacao = (InStr("," & Replace(.Lista_ID, " ", "") & ",", "," & Trim(cnt_Opcoes_Agrupar_Por_Tipo_Movimentacao) & ",") > 0)
        End With

        If Not Data_ValidarPeriodo("da movimentação", txtDataInicial.Value, txtDataFinal.Value, True) Then Exit Sub

        'Valida as análises
        For iLinha = 0 To grdAnalise.Rows.Count - 1
            With grdAnalise.Rows(iLinha)
                Select Case .Cells(0).Value
                    Case cnt_GridAnaliseLinha_Umidade
                        If NVL(.Cells(2).Value, -1) > NVL(.Cells(2).Value, NVL(.Cells(3).Value, -1)) Then Msg_Mensagem("O Mínimo não pode ser maior Máximo para Umidade") : Exit Sub
                        If Not CampoNulo(.Cells(2).Value) Then Str_Adicionar(SqlText_Analise, "MQ.QT_UMIDADE >= " & ConvValorFormatoAmericano(.Cells(2).Value), " AND ")
                        If Not CampoNulo(.Cells(3).Value) Then Str_Adicionar(SqlText_Analise, "MQ.QT_UMIDADE <= " & ConvValorFormatoAmericano(.Cells(3).Value), " AND ")
                    Case cnt_GridAnaliseLinha_Sujidade
                        If NVL(.Cells(2).Value, -1) > NVL(.Cells(2).Value, NVL(.Cells(3).Value, -1)) Then Msg_Mensagem("O Mínimo não pode ser maior Máximo para Sujidade") : Exit Sub
                        If Not CampoNulo(.Cells(2).Value) Then Str_Adicionar(SqlText_Analise, "MQ.PC_SUJIDADE >= " & ConvValorFormatoAmericano(.Cells(2).Value), " AND ")
                        If Not CampoNulo(.Cells(3).Value) Then Str_Adicionar(SqlText_Analise, "MQ.PC_SUJIDADE <= " & ConvValorFormatoAmericano(.Cells(3).Value), " AND ")
                    Case cnt_GridAnaliseLinha_Achatada
                        If NVL(.Cells(2).Value, -1) > NVL(.Cells(2).Value, NVL(.Cells(3).Value, -1)) Then Msg_Mensagem("O Mínimo não pode ser maior Máximo para Achatada") : Exit Sub
                        If Not CampoNulo(.Cells(2).Value) Then Str_Adicionar(SqlText_Analise, "MQ.QT_ACHATADA >= " & ConvValorFormatoAmericano(.Cells(2).Value), " AND ")
                        If Not CampoNulo(.Cells(3).Value) Then Str_Adicionar(SqlText_Analise, "MQ.QT_ACHATADA <= " & ConvValorFormatoAmericano(.Cells(3).Value), " AND ")
                    Case cnt_GridAnaliseLinha_Ardosia
                        If NVL(.Cells(2).Value, -1) > NVL(.Cells(2).Value, NVL(.Cells(3).Value, -1)) Then Msg_Mensagem("O Mínimo não pode ser maior Máximo para Ardosia") : Exit Sub
                        If Not CampoNulo(.Cells(2).Value) Then Str_Adicionar(SqlText_Analise, "MQ.QT_ARDOSIA >= " & ConvValorFormatoAmericano(.Cells(2).Value), " AND ")
                        If Not CampoNulo(.Cells(3).Value) Then Str_Adicionar(SqlText_Analise, "MQ.QT_ARDOSIA <= " & ConvValorFormatoAmericano(.Cells(3).Value), " AND ")
                    Case cnt_GridAnaliseLinha_Fumaca
                        If NVL(.Cells(2).Value, -1) > NVL(.Cells(2).Value, NVL(.Cells(3).Value, -1)) Then Msg_Mensagem("O Mínimo não pode ser maior Máximo para Fumaça") : Exit Sub
                        If Not CampoNulo(.Cells(2).Value) Then Str_Adicionar(SqlText_Analise, "MQ.QT_FUMACA >= " & ConvValorFormatoAmericano(.Cells(2).Value), " AND ")
                        If Not CampoNulo(.Cells(3).Value) Then Str_Adicionar(SqlText_Analise, "MQ.QT_FUMACA <= " & ConvValorFormatoAmericano(.Cells(3).Value), " AND ")
                    Case cnt_GridAnaliseLinha_Mofo
                        If NVL(.Cells(2).Value, -1) > NVL(.Cells(2).Value, NVL(.Cells(3).Value, -1)) Then Msg_Mensagem("O Mínimo não pode ser maior Máximo para Mofo") : Exit Sub
                        If Not CampoNulo(.Cells(2).Value) Then Str_Adicionar(SqlText_Analise, "MQ.QT_MOFO >= " & ConvValorFormatoAmericano(.Cells(2).Value), " AND ")
                        If Not CampoNulo(.Cells(3).Value) Then Str_Adicionar(SqlText_Analise, "MQ.QT_MOFO <= " & ConvValorFormatoAmericano(.Cells(3).Value), " AND ")
                    Case cnt_GridAnaliseLinha_PAmendoa
                        If NVL(.Cells(2).Value, -1) > NVL(.Cells(2).Value, NVL(.Cells(3).Value, -1)) Then Msg_Mensagem("O Mínimo não pode ser maior Máximo para P. Amêndoas") : Exit Sub
                        If Not CampoNulo(.Cells(2).Value) Then Str_Adicionar(SqlText_Analise, "MQ.QT_PESO_AMENDOA >= " & ConvValorFormatoAmericano(.Cells(2).Value), " AND ")
                        If Not CampoNulo(.Cells(3).Value) Then Str_Adicionar(SqlText_Analise, "MQ.QT_PESO_AMENDOA <= " & ConvValorFormatoAmericano(.Cells(3).Value), " AND ")
                End Select
            End With
        Next

        AVI_Carregar(Me)

        SqlText = "SELECT M.DT_MOVIMENTACAO," & _
                         "F.NO_RAZAO_SOCIAL," & _
                         "TM.NO_TIPO_MOVIMENTACAO," & _
                         "T.SQ_TRANSFERENCIA," & _
                         "F.CD_FILIAL_ORIGEM AS CD_FILIAL_FORN," & _
                         "T.CD_FILIAL_ORIGEM AS CD_FILIAL_TRANSF," & _
                         "M.CD_FILIAL_MOVIMENTACAO," & _
                         "F.CD_REPRESENTANTE," & _
                         "M.NU_NF," & _
                         "M.QT_KG_NF," & _
                         "M.VL_NF," & _
                         "M.QT_KG_LIQUIDO_NF AS QT_KG_LIQ_NF," & _
                         "MQ.QT_UMIDADE," & _
                         "MQ.QT_ACERTO_UMIDADE," & _
                         "MQ.DT_ACERTO_UMIDADE," & _
                         "MQ.QT_PESO_AMENDOA," & _
                         "MQ.IC_TIPO_CACAU," & _
                         "MQ.QT_MOFO," & _
                         "MQ.QT_ARDOSIA," & _
                         "MQ.QT_FUMACA," & _
                         "MQ.QT_ACHATADA," & _
                         "FIL.CD_FILIAL," & _
                         "FIL.NO_FILIAL," & _
                         "P.CD_TP_MOV_DESAGIO," & _
                         "TM.CD_TIPO_MOVIMENTACAO," & _
                         "SUM (DECODE (SF.CD_TIPO_SACARIA, 7, 0, SF.QT_SACOS)) AS QT_VOLUME," & _
                         "MQ.PC_SUJIDADE," & _
                         "M.CD_TIPO_NF," & _
                         "M.VL_NF_FUNRURAL," & _
                         "M.VL_NF_ICMS," & _
                         "MUN.NO_CIDADE" & _
                  " FROM SOF.TIPO_MOVIMENTACAO TM," & _
                        "SOF.MOVIMENTACAO M," & _
                        "SOF.FILIAL FIL," & _
                        "SOF.SACARIA_FILIAL SF," & _
                        "SOF.FORNECEDOR F," & _
                        "SOF.MOVIMENTACAO_QUALIDADE MQ," & _
                        "SOF.TRANSFERENCIA T," & _
                        "SOF.PARAMETRO P," & _
                        "SOF.MUNICIPIO MUN" & _
                  " WHERE TM.CD_TIPO_MOVIMENTACAO = M.CD_TIPO_MOVIMENTACAO" & _
                    " AND tm.IC_TIPO_UTILIZACAO NOT IN ('T')"

        If oTipoRelatorio = RGFP_TipoRelatorio.Filial Then
            SqlText = SqlText & _
                    " AND F.CD_FILIAL_ORIGEM = FIL.CD_FILIAL"
        Else
            SqlText = SqlText & _
                    " AND M.CD_FILIAL_MOVIMENTACAO = FIL.CD_FILIAL"
        End If

        SqlText = SqlText & _
                    " AND M.SQ_MOVIMENTACAO = SF.SQ_MOVIMENTACAO(+)" & _
                    " AND M.CD_FORNECEDOR = F.CD_FORNECEDOR(+)" & _
                    " AND M.SQ_MOVIMENTACAO = MQ.SQ_MOVIMENTACAO(+)" & _
                    " AND M.SQ_MOVIMENTACAO = T.SQ_MOVIMENTACAO_SAIDA(+)" & _
                    " AND M.CD_MUNICIPIO_ORIGEM = MUN.CD_MUNICIPIO(+)"

        If IsDate(txtDataInicial.Text) Then
            SqlText = SqlText & _
                    " AND M.DT_MOVIMENTACAO >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text))
            sFiltro = sFiltro & " - Data Inicial: " & txtDataInicial.Text
        End If
        If IsDate(txtDataFinal.Text) Then
            SqlText = SqlText & _
                    " AND M.DT_MOVIMENTACAO <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
            sFiltro = sFiltro & " - Data Final: " & txtDataFinal.Text
        End If
        If oTipoRelatorio = RGFP_TipoRelatorio.Filial Then
            If SelecaoFilialMovimentacao.Lista_Quantidade > 0 Then
                SqlText = SqlText & _
                    " AND F.CD_FILIAL_ORIGEM IN (" & SelecaoFilialMovimentacao.Lista_ID & ")"
                sFiltro = sFiltro & " - Filial do Fornecedor: " & SelecaoFilialMovimentacao.Lista_Descricao
            End If
        Else
            If SelecaoFilialMovimentacao.Lista_Quantidade > 0 Then
                SqlText = SqlText & _
                    " AND M.CD_FILIAL_MOVIMENTACAO IN (" & SelecaoFilialMovimentacao.Lista_ID & ")"
                sFiltro = sFiltro & " - Filial Movimentação: " & SelecaoFilialMovimentacao.Lista_Descricao
            End If
        End If

        SqlText = SqlText & _
                    " AND (T.CD_FILIAL_DESTINO IN (" & ListarIDFiliaisLiberadaUsuario() & ") OR M.CD_FILIAL_MOVIMENTACAO IN (" & ListarIDFiliaisLiberadaUsuario() & ") OR F.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & "))"

        If SelecaoFilialRecebimento.Lista_Quantidade > 0 Then
            SqlText = SqlText & _
                    " AND M.CD_FILIAL_MOVIMENTACAO IN (" & SelecaoFilialRecebimento.Lista_ID & ")"
            sFiltro = sFiltro & " - Filial Recepção: " & SelecaoFilialMovimentacao.Lista_Descricao
        End If
        If SelecaoTipoNovimentacao.Lista_Quantidade > 0 Then
            SqlText = SqlText & _
                    " AND M.CD_TIPO_MOVIMENTACAO IN (" & SelecaoTipoNovimentacao.Lista_ID & ")"
            sFiltro = sFiltro & " - Tipo de documentaçãol: " & SelecaoTipoNovimentacao.Lista_Descricao
        End If
        If SelecaoFornecedor.Lista_Quantidade > 0 Then
            SqlText = SqlText & _
                    " AND (F.CD_FORNECEDOR IN (" & SelecaoFornecedor.Lista_ID & ") OR T.CD_FILIAL_DESTINO IN (" & SelecaoFornecedor.Lista_ID & "))"
            sFiltro = sFiltro & " - Fornecedor: " & SelecaoFornecedor.Lista_Descricao
        End If
        If ComboBox_LinhaSelecionada(cboTipoCacau) Then
            SqlText = SqlText & _
                    " AND M.CD_TIPO_CACAU = " & cboTipoCacau.SelectedValue
            sFiltro = sFiltro & " - Cacau: " & cboTipoCacau.SelectedItem(1)
        End If

        Str_Adicionar(SqlText, SqlText_Analise, " AND ")

        Select Case optTipoPessoa.Value
            Case "F"
                SqlText = SqlText & _
                    " AND F.IC_FISICA_JURIDICA = 'F'"
                sFiltro = sFiltro & " - Somente Pessoa Física "
            Case "J"
                SqlText = SqlText & _
                    " AND F.IC_FISICA_JURIDICA = 'J'"
                sFiltro = sFiltro & " - Somente Pessoa Jurídica "
        End Select

        SqlText = SqlText & _
                  " GROUP BY M.DT_MOVIMENTACAO," & _
                            "F.NO_RAZAO_SOCIAL," & _
                            "TM.NO_TIPO_MOVIMENTACAO," & _
                            "T.SQ_TRANSFERENCIA," & _
                            "F.CD_FILIAL_ORIGEM," & _
                            "T.CD_FILIAL_ORIGEM," & _
                            "M.CD_FILIAL_MOVIMENTACAO," & _
                            "F.CD_REPRESENTANTE," & _
                            "M.NU_NF," & _
                            "M.QT_KG_NF," & _
                            "M.VL_NF," & _
                            "M.QT_KG_LIQUIDO_NF," & _
                            "MQ.QT_UMIDADE," & _
                            "MQ.QT_ACERTO_UMIDADE," & _
                            "MQ.DT_ACERTO_UMIDADE," & _
                            "MQ.QT_PESO_AMENDOA," & _
                            "MQ.IC_TIPO_CACAU," & _
                            "MQ.QT_MOFO," & _
                            "MQ.QT_ARDOSIA," & _
                            "MQ.QT_FUMACA," & _
                            "MQ.QT_ACHATADA," & _
                            "FIL.CD_FILIAL," & _
                            "FIL.NO_FILIAL," & _
                            "P.CD_TP_MOV_DESAGIO," & _
                            "TM.CD_TIPO_MOVIMENTACAO," & _
                            "MQ.PC_SUJIDADE," & _
                            "M.SQ_MOVIMENTACAO," & _
                            "M.CD_TIPO_NF," & _
                            "M.VL_NF_FUNRURAL," & _
                            "M.VL_NF_ICMS," & _
                            "MUN.NO_CIDADE"
        oData = DBQuery(SqlText)

        oRelatorio.Load(Application.StartupPath & "\RPT_Movimentacao.rpt")
        oRelatorio.SetDataSource(oData)

        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

        If bAgruparFilial Then
            oRelatorio.SetParameterValue("AgrupaFilial", "S")
            sFiltro = sFiltro & " - Agrupado Por Filial "
        Else
            oRelatorio.SetParameterValue("AgrupaFilial", "N")
        End If
        If bAgruparMunicipio Then
            oRelatorio.SetParameterValue("AgrupaMunicipio", "S")
            sFiltro = sFiltro & " - Agrupado Por Municipio"
        Else
            oRelatorio.SetParameterValue("AgrupaMunicipio", "N")
        End If
        If bAgruparTipoDocumento Then
            oRelatorio.SetParameterValue("AgrupaTipoDocumento", "S")
            sFiltro = sFiltro & " - Agrupado Por Tipo de Documento "
        Else
            oRelatorio.SetParameterValue("AgrupaTipoDocumento", "N")
        End If
        If bAgruparTipoMovimentacao Then
            oRelatorio.SetParameterValue("AgrupaTipoMovimentacao", "S")
            sFiltro = sFiltro & " - Agrupado Por Tipo de Movimentação "
        Else
            oRelatorio.SetParameterValue("AgrupaTipoMovimentacao", "N")
        End If
        If oTipoRelatorio = RGFP_TipoRelatorio.Filial Then
            oRelatorio.SetParameterValue("Titulo", "Relatório Movimentação Por Filial")
        Else
            oRelatorio.SetParameterValue("Titulo", "Relatório Movimentação de Cacau")
        End If

        crvMain.ReportSource = oRelatorio

        AVI_Fechar(Me)
    End Sub
End Class