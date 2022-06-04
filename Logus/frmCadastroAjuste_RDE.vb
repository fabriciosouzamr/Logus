Imports Infragistics.Win

Public Class frmCadastroAjuste_RDE
    Event EfetuouGravacao()

    Const cnt_GridGeral_CD_ARMAZEM As Integer = 0
    Const cnt_GridGeral_CD_TIPO_SACARIA As Integer = 1
    Const cnt_GridGeral_NO_ARMAZEM As Integer = 2
    Const cnt_GridGeral_CD_PILHA As Integer = 3
    Const cnt_GridGeral_NO_TIPO_SACARIA As Integer = 4
    Const cnt_GridGeral_QT_VOLUME As Integer = 5
    Const cnt_GridGeral_QT_SACOS As Integer = 6
    Const cnt_GridGeral_QT_VOLUME_NOVO As Integer = 7
    Const cnt_GridGeral_QT_SACOS_NOVO As Integer = 8

    Enum enAjusteRDE_AcaoTela
        Inclusao = 1
        Aprovacao = 2
        Consulta_Inclusao = 3
        Consulta_Aprovacao = 4
        Alteracao = 5
    End Enum

    Public AjusteRDE_AcaoTela As enAjusteRDE_AcaoTela = enAjusteRDE_AcaoTela.Inclusao
    Public SQ_ACERTO As Integer
    Dim bProcInterno As Boolean

    Dim oDS As New UltraWinDataSource.UltraDataSource

    Private Sub frmCadastroAjuste_RDE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox_Carregar_Processo_Tipo(cboTipoAcerto, cnt_Processo_TipoAjusteRD, True)
        Pesq_Movimentacao.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Movimentacao
        Pesq_TipoMovimentacao.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_TipoMovimentacao
        ComboBox_Carregar_Filial(cboFilial, True, False, , True)
        Pesq_Fornecedor.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        CheckAplicarAjuste_EstoqueFisico_Validar()
        CheckAplicarAjuste_RDE_Validar()
        chkFornecedor_CheckedChanged(Nothing, Nothing)

        objGrid_Inicializar(grdGeral, , oDS)
        objGrid_Coluna_Add(grdGeral, "CD_ARMAZEM", 0)
        objGrid_Coluna_Add(grdGeral, "CD_TIPO_SACARIA", 0)
        objGrid_Coluna_Add(grdGeral, "Armazem", 90)
        objGrid_Coluna_Add(grdGeral, "Pilha", 50)
        objGrid_Coluna_Add(grdGeral, "Tipo de Sacaria", 100)
        objGrid_Coluna_Add(grdGeral, "Vol Atual", 70)
        objGrid_Coluna_Add(grdGeral, "Scs Atuais", 70)
        objGrid_Coluna_Add(grdGeral, "Vol Novo", 70, , True)
        objGrid_Coluna_Add(grdGeral, "Scs Novos", 70, , True)

        AjustarFormulario()

        If SQ_ACERTO > 0 Then
            CarregarDados()
        End If
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim iCont As Integer

        If Not ComboBox_LinhaSelecionada(cboTipoAcerto) Then
            Msg_Mensagem("Selecione o tipo de acerto")
            Exit Sub
        End If
        If Pesq_TipoMovimentacao.Codigo = 0 Then
            Msg_Mensagem("Selecione o tipo de movimentação")
            Exit Sub
        End If
        If Not IsDate(txtDataMovimentacao.Text) Then
            Msg_Mensagem("Informe a data da movimentação a ser ajustada")
            Exit Sub
        End If
        If Pesq_Fornecedor.Enabled Then
            If Pesq_Fornecedor.Codigo = 0 Then
                Msg_Mensagem("Informe o fornecedor da movimentação")
                Exit Sub
            End If
        End If
        If Trim(txtJustificativaAjuste.Text) = "" Then
            Msg_Mensagem("Informe a justificativa do acerto")
            Exit Sub
        End If
        Select Case cboTipoAcerto.SelectedValue
            Case cnt_TipoAjusteRD_Movimentacao
                If txtValor.Value = 0 And txtValorICMS.Value = 0 And txtValorINSS.Value = 0 And _
                   txtQuantidadeNF.Value = 0 Then
                    Msg_Mensagem("É preciso informar os valores ou a quantidade a ser ajustada")
                    Exit Sub
                End If
        End Select
        For iCont = 0 To grdGeral.Rows.Count - 1
            If objGrid_Valor(grdGeral, cnt_GridGeral_QT_SACOS_NOVO, iCont) = 0 Or _
               objGrid_Valor(grdGeral, cnt_GridGeral_QT_VOLUME_NOVO, iCont) = 0 Then
                Msg_Mensagem("Não é possível ajustar volume ou sacos para zero")
                Exit Sub
            End If
        Next
        If chkAplicarAjuste_EstoqueFisico.Checked And txtQuantidadeLiquido.Value <> objGrid_CalcularTotalColuna(grdGeral, cnt_GridGeral_QT_VOLUME_NOVO) Then
            Msg_Mensagem("A quantidade líquida da movimentação tem que ser igual ao volume em estoque")
            Exit Sub
        End If

        Dim SqlText As String
        Dim oParametro(14) As DBParamentro
        Dim SQ_ACERTO_INT As Integer = 0
        Dim sDsAcerto As String = ""

        SQ_ACERTO_INT = SQ_ACERTO

        If Pesq_Movimentacao.Codigo > 0 Then
            SqlText = "SELECT QT_KG_NF, QT_KG_LIQUIDO_NF," & _
                             "VL_NF, VL_NF_ICMS, VL_NF_FUNRURAL" & _
                      " FROM SOF.MOVIMENTACAO" & _
                      " WHERE SQ_MOVIMENTACAO = " & Pesq_Movimentacao.Codigo

            With DBQuery(SqlText).Rows(0)
                If txtQuantidadeNF.Value <> NVL(.Item("QT_KG_NF"), 0) Then Str_Adicionar(sDsAcerto, "Kg. NF: " & NVL(.Item("QT_KG_NF"), 0), " - ")
                If txtQuantidadeLiquido.Value <> NVL(.Item("QT_KG_LIQUIDO_NF"), 0) Then Str_Adicionar(sDsAcerto, "Kg. Líquido NF: " & NVL(.Item("QT_KG_LIQUIDO_NF"), 0), " - ")
                If txtValor.Value <> NVL(.Item("VL_NF"), 0) Then Str_Adicionar(sDsAcerto, "Valor NF: " & NVL(.Item("VL_NF"), 0), " - ")
                If txtValorICMS.Value <> NVL(.Item("VL_NF_ICMS"), 0) Then Str_Adicionar(sDsAcerto, "Valor ICMS: " & NVL(.Item("VL_NF_ICMS"), 0), " - ")
                If txtValorINSS.Value <> NVL(.Item("VL_NF_FUNRURAL"), 0) Then Str_Adicionar(sDsAcerto, "Valor INSS: " & NVL(.Item("VL_NF_FUNRURAL"), 0), " - ")
            End With
        End If

        DBUsarTransacao = True

        If SQ_ACERTO_INT = 0 Then
            SQ_ACERTO_INT = DBNumeroMaisUm("SOF.RESUMO_DIARIO_ESTOQUE_ACERTO", "SQ_ACERTO")

            SqlText = DBMontar_Insert("SOF.RESUMO_DIARIO_ESTOQUE_ACERTO", TipoCampoFixo.Todos, _
                                                                         "SQ_MOVIMENTACAO", ":SQ_MOVIMENTACAO", _
                                                                         "IC_ACERTO_RD", ":IC_ACERTO_RD", _
                                                                         "IC_ACERTO_ESTOQUE", ":IC_ACERTO_ESTOQUE", _
                                                                         "CD_TIPO_ACERTO", ":CD_TIPO_ACERTO", _
                                                                         "CD_TIPO_MOVIMENTACAO", ":CD_TIPO_MOVIMENTACAO", _
                                                                         "CD_FILIAL_ORIGEM", ":CD_FILIAL_ORIGEM", _
                                                                         "CD_FORNECEDOR", ":CD_FORNECEDOR", _
                                                                         "DT_AJUSTE", "SYSDATE", _
                                                                         "QT_AJUSTE", ":QT_AJUSTE", _
                                                                         "QT_AJUSTE_NF", ":QT_AJUSTE_NF", _
                                                                         "VL_AJUSTE", ":VL_AJUSTE", _
                                                                         "VL_AJUSTE_ICMS", ":VL_AJUSTE_ICMS", _
                                                                         "VL_AJUSTE_INSS", ":VL_AJUSTE_INSS", _
                                                                         "CM_JUSTIFICATIVA", ":CM_JUSTIFICATIVA", _
                                                                         "SQ_ACERTO", ":SQ_ACERTO")
        Else
            SqlText = DBMontar_Update("SOF.RESUMO_DIARIO_ESTOQUE_ACERTO", GerarArray("SQ_MOVIMENTACAO", ":SQ_MOVIMENTACAO", _
                                                                                     "IC_ACERTO_RD", ":IC_ACERTO_RD", _
                                                                                     "IC_ACERTO_ESTOQUE", ":IC_ACERTO_ESTOQUE", _
                                                                                     "CD_TIPO_ACERTO", ":CD_TIPO_ACERTO", _
                                                                                     "CD_TIPO_MOVIMENTACAO", ":CD_TIPO_MOVIMENTACAO", _
                                                                                     "CD_FILIAL_ORIGEM", ":CD_FILIAL_ORIGEM", _
                                                                                     "CD_FORNECEDOR", ":CD_FORNECEDOR", _
                                                                                     "DT_AJUSTE", "SYSDATE", _
                                                                                     "QT_AJUSTE", ":QT_AJUSTE", _
                                                                                     "QT_AJUSTE_NF", ":QT_AJUSTE_NF", _
                                                                                     "VL_AJUSTE", ":VL_AJUSTE", _
                                                                                     "VL_AJUSTE_ICMS", ":VL_AJUSTE_ICMS", _
                                                                                     "VL_AJUSTE_INSS", ":VL_AJUSTE_INSS", _
                                                                                     "CM_JUSTIFICATIVA", ":CM_JUSTIFICATIVA"), _
                                                                          GerarArray("SQ_ACERTO", ":SQ_ACERTO"))
        End If

        oParametro(0) = DBParametro_Montar("SQ_MOVIMENTACAO", NULLIf(Pesq_Movimentacao.Codigo, 0))
        oParametro(1) = DBParametro_Montar("IC_ACERTO_RD", IIf(chkAplicarAjuste_RDE.Checked, "S", "N"))
        oParametro(2) = DBParametro_Montar("IC_ACERTO_ESTOQUE", IIf(chkAplicarAjuste_EstoqueFisico.Checked, "S", "N"))
        oParametro(3) = DBParametro_Montar("SQ_MOVIMENTACAO", NULLIf(Pesq_Movimentacao.Codigo, 0))
        oParametro(4) = DBParametro_Montar("CD_TIPO_ACERTO", cboTipoAcerto.SelectedValue)
        oParametro(5) = DBParametro_Montar("CD_TIPO_MOVIMENTACAO", Pesq_TipoMovimentacao.Codigo)
        oParametro(6) = DBParametro_Montar("CD_FILIAL_ORIGEM", cboFilial.SelectedValue)
        If Pesq_Fornecedor.Enabled Or chkAplicarAjuste_EstoqueFisico.Checked Then
            oParametro(7) = DBParametro_Montar("CD_FORNECEDOR", IIf(Pesq_Fornecedor.Codigo = 0, Nothing, Pesq_Fornecedor.Codigo))
        Else
            oParametro(7) = DBParametro_Montar("CD_FORNECEDOR", Nothing)
        End If
        oParametro(8) = DBParametro_Montar("QT_AJUSTE", txtQuantidadeLiquido.Value)
        oParametro(9) = DBParametro_Montar("QT_AJUSTE_NF", txtQuantidadeNF.Value)
        oParametro(10) = DBParametro_Montar("VL_AJUSTE", txtValor.Value)
        oParametro(11) = DBParametro_Montar("VL_AJUSTE_ICMS", txtValorICMS.Value)
        oParametro(12) = DBParametro_Montar("VL_AJUSTE_INSS", txtValorINSS.Value)
        oParametro(13) = DBParametro_Montar("CM_JUSTIFICATIVA", txtJustificativaAjuste.Text & vbCrLf & vbCrLf & "Valores antes da alteração: " & sDsAcerto)
        oParametro(14) = DBParametro_Montar("SQ_ACERTO", SQ_ACERTO_INT)

        If Not DBExecutar(SqlText, oParametro) Then GoTo Erro

        'Gravação da atualização de estoque
        SqlText = "DELETE FROM SOF.RESUMO_DIARIO_ESTOQUE_ACT_AMZ WHERE SQ_ACERTO = " & SQ_ACERTO_INT
        If Not DBExecutar(SqlText) Then GoTo Erro

        SqlText = DBMontar_Insert("SOF.RESUMO_DIARIO_ESTOQUE_ACT_AMZ", TipoCampoFixo.Nenhum, _
                                                                       "SQ_ACERTO", ":SQ_ACERTO", _
                                                                       "CD_ARMAZEM", ":CD_ARMAZEM", _
                                                                       "CD_PILHA", ":CD_PILHA", _
                                                                       "CD_TIPO_SACARIA", ":CD_TIPO_SACARIA", _
                                                                       "QT_SACOS_ANTERIOR", ":QT_SACOS_ANTERIOR", _
                                                                       "QT_MOVIMENTACAO_ANTERIOR", ":QT_MOVIMENTACAO_ANTERIOR", _
                                                                       "QT_SACOS_NOVO", ":QT_SACOS_NOVO", _
                                                                       "QT_MOVIMENTACAO_NOVO", ":QT_MOVIMENTACAO_NOVO")

        For iCont = 0 To grdGeral.Rows.Count - 1
            With grdGeral.Rows(iCont)
                If .Cells(cnt_GridGeral_QT_SACOS).Value <> .Cells(cnt_GridGeral_QT_SACOS_NOVO).Value Or _
                   .Cells(cnt_GridGeral_QT_VOLUME).Value <> .Cells(cnt_GridGeral_QT_VOLUME_NOVO).Value Then
                    If Not DBExecutar(SqlText, DBParametro_Montar("SQ_ACERTO", SQ_ACERTO_INT), _
                                               DBParametro_Montar("CD_ARMAZEM", .Cells(cnt_GridGeral_CD_ARMAZEM).Value), _
                                               DBParametro_Montar("CD_PILHA", .Cells(cnt_GridGeral_CD_PILHA).Value), _
                                               DBParametro_Montar("CD_TIPO_SACARIA", .Cells(cnt_GridGeral_CD_TIPO_SACARIA).Value), _
                                               DBParametro_Montar("QT_SACOS_ANTERIOR", .Cells(cnt_GridGeral_QT_SACOS).Value), _
                                               DBParametro_Montar("QT_MOVIMENTACAO_ANTERIOR", .Cells(cnt_GridGeral_QT_VOLUME).Value), _
                                               DBParametro_Montar("QT_SACOS_NOVO", .Cells(cnt_GridGeral_QT_SACOS_NOVO).Value), _
                                               DBParametro_Montar("QT_MOVIMENTACAO_NOVO", .Cells(cnt_GridGeral_QT_VOLUME_NOVO).Value)) Then GoTo Erro
                End If
            End With
        Next

        If Not DBExecutarTransacao() Then GoTo Erro

        Msg_Mensagem("Gravação Efetuada")

        SQ_ACERTO = SQ_ACERTO_INT

        RaiseEvent EfetuouGravacao()

        Close()

        Exit Sub

Erro:
        TratarErro(, , "frmAjuste_RDE.cmdGravar_Click")
    End Sub

    Private Sub cboTipoAcerto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoAcerto.SelectedIndexChanged
        Dim bAjusteValor As Boolean

        bAjusteValor = (NVL(cboTipoAcerto.SelectedValue, cnt_TipoAjusteRD_Movimentacao) = cnt_TipoAjusteRD_Valor)

        'lblR_Fornecedor.Enabled = bAjusteValor
        'Pesq_Fornecedor.Enabled = bAjusteValor
        'Pesq_Fornecedor.Codigo = 0
     
        AtivaFornecedor()

        lblR_ICMS.Enabled = bAjusteValor
        txtValorICMS.Enabled = bAjusteValor
        txtValorICMS.Value = 0

        lblR_ValorINSS.Enabled = bAjusteValor
        txtValorINSS.Enabled = bAjusteValor
        txtValorINSS.Value = 0

        chkAplicarAjuste_RDE.Checked = IIf(bAjusteValor, True, chkAplicarAjuste_RDE.Checked)
        chkAplicarAjuste_RDE.Enabled = (Not bAjusteValor)
        chkAplicarAjuste_EstoqueFisico.Enabled = (Not bAjusteValor)
        chkAplicarAjuste_EstoqueFisico.Checked = (chkAplicarAjuste_EstoqueFisico.Enabled And chkAplicarAjuste_EstoqueFisico.Checked)
    End Sub

    Private Sub AjustarFormulario()
        'Ajuste visibilidade de controles e tamanho de tela
        Select Case AjusteRDE_AcaoTela
            Case enAjusteRDE_AcaoTela.Inclusao, enAjusteRDE_AcaoTela.Consulta_Inclusao, enAjusteRDE_AcaoTela.Alteracao
                cmdGravar.Top = 432
                cmdGravar.Left = 8

                cmdFechar.Top = 432

                lblR_JustificativaAprovacao.Visible = False
                txtJustificativaAprovacao.Visible = False

                Me.Width = 608
                Me.Height = 511
        End Select

        'Ajuste de controle ativos/inativos
        Dim bHabilitarInclusao As Boolean = False
        Dim bHabilitarAprovacao As Boolean = False

        'Campos de data de lançamento e aprovação de ajuste
        lblR_DataLancamento.Visible = (fIN(AjusteRDE_AcaoTela, enAjusteRDE_AcaoTela.Consulta_Inclusao, enAjusteRDE_AcaoTela.Consulta_Aprovacao))
        txtDataLancamento.Enabled = lblR_DataLancamento.Enabled
        lblR_DataAprovacao.Enabled = (AjusteRDE_AcaoTela = enAjusteRDE_AcaoTela.Consulta_Aprovacao)
        txtDataAprovacao.Enabled = lblR_DataAprovacao.Enabled

        bHabilitarInclusao = (AjusteRDE_AcaoTela = enAjusteRDE_AcaoTela.Inclusao Or AjusteRDE_AcaoTela = enAjusteRDE_AcaoTela.Alteracao)
        bHabilitarAprovacao = (AjusteRDE_AcaoTela = enAjusteRDE_AcaoTela.Aprovacao)

        'Campos de inclusão de ajuste
        grpAplicarAjusteEm.Enabled = bHabilitarInclusao
        grpDaoAjuste.Enabled = bHabilitarInclusao
        cmdGravar.Visible = bHabilitarInclusao

        'Campos de aprovação de ajuste
        lblR_JustificativaAprovacao.Enabled = bHabilitarAprovacao
        txtJustificativaAprovacao.Enabled = bHabilitarAprovacao
        cmdAprovacao.Visible = bHabilitarAprovacao
        cmdReprovar.Visible = bHabilitarAprovacao

        chkAplicarAjuste_RDE.Checked = True
        chkAplicarAjuste_EstoqueFisico.Checked = False
    End Sub

    Private Sub cmdAprovacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAprovacao.Click
        Aprovacao(True)
    End Sub

    Private Sub Aprovacao(ByVal bAprovar As Boolean)
        Dim SqlText As String
        Dim SQ_MOVIMENTACAO As Integer

        Dim QT_KG_LIQUIDO_NF As Double = 0
        Dim VL_NF As Double = 0
        Dim VL_NF_ICMS As Double = 0
        Dim VL_NF_FUNRURAL As Double = 0

        If SQ_ACERTO = 0 Then
            Msg_Mensagem("Não existe lançamento de acerto")
            Exit Sub
        End If
        If Trim(txtJustificativaAprovacao.Text) = "" Then
            Msg_Mensagem("É necessário informar a justificativa para o ajuste")
            Exit Sub
        End If
        If FilialFechada(cboFilial.SelectedValue) Then
            Msg_Mensagem("A Filial está fechada. No momento não é possivel realizar a operação.")
            Exit Sub
        End If

        SqlText = "SELECT COUNT(*) FROM SOF.RESUMO_DIARIO_ESTOQUE_ACERTO" & _
                  " WHERE SQ_ACERTO = " & SQ_ACERTO & " AND IC_APROVADO IS NOT NULL"
        If DBQuery_ValorUnico(SqlText) > 0 Then
            Msg_Mensagem("Já foi efetuada a análise de aprovação desse ajuste. Favor validar.")
            Exit Sub
        End If

        DBUsarTransacao = True

        SqlText = DBMontar_Update("SOF.RESUMO_DIARIO_ESTOQUE_ACERTO", GerarArray("DT_MOVIMENTO", ":DT_MOVIMENTO", _
                                                                                 "CD_USUARIO_APROVACAO", ":CD_USUARIO_APROVACAO", _
                                                                                 "IC_APROVADO", ":IC_APROVADO", _
                                                                                 "DT_APROVACAO", "SYSDATE", _
                                                                                 "CM_APROVACAO", ":CM_APROVACAO"), _
                                                                      GerarArray("SQ_ACERTO", ":SQ_ACERTO"))

        If Not DBExecutar(SqlText, DBParametro_Montar("DT_MOVIMENTO", Date_to_Oracle(DataSistema)), _
                                   DBParametro_Montar("CD_USUARIO_APROVACAO", sAcesso_UsuarioLogado), _
                                   DBParametro_Montar("IC_APROVADO", IIf(bAprovar, "S", "N")), _
                                   DBParametro_Montar("CM_APROVACAO", NULLIf(Trim(txtJustificativaAprovacao.Text), "")), _
                                   DBParametro_Montar("SQ_ACERTO", SQ_ACERTO)) Then GoTo Erro

        If Pesq_Movimentacao.Codigo > 0 Then
            SQ_MOVIMENTACAO = Pesq_Movimentacao.Codigo
        End If

        If bAprovar Then
            If chkAplicarAjuste_RDE.Checked Then
                Select Case cboTipoAcerto.SelectedValue
                    Case cnt_TipoAjusteRD_Movimentacao
                        If Pesq_Movimentacao.Codigo > 0 Then
                            SqlText = "SELECT QT_KG_NF, QT_KG_LIQUIDO_NF, VL_NF, VL_NF_ICMS, VL_NF_FUNRURAL" & _
                                      " FROM SOF.MOVIMENTACAO WHERE SQ_MOVIMENTACAO = " & SQ_MOVIMENTACAO

                            With DBQuery(SqlText).Rows(0)
                                QT_KG_LIQUIDO_NF = NVL(.Item("QT_KG_LIQUIDO_NF"), 0)
                                VL_NF = NVL(.Item("VL_NF"), 0)
                                VL_NF_ICMS = NVL(.Item("VL_NF_ICMS"), 0)
                                VL_NF_FUNRURAL = NVL(.Item("VL_NF_FUNRURAL"), 0)
                            End With

                            SqlText = DBMontar_Update("SOF.MOVIMENTACAO", GerarArray("QT_KG_NF", ":QT_KG_NF", _
                                                                                     "QT_KG_LIQUIDO_NF", ":QT_KG_LIQUIDO_NF", _
                                                                                     "VL_NF", ":VL_NF", _
                                                                                     "VL_NF_ICMS", ":VL_NF_ICMS", _
                                                                                     "VL_NF_FUNRURAL", ":VL_NF_FUNRURAL"), _
                                                                          GerarArray("SQ_MOVIMENTACAO", ":SQ_MOVIMENTACAO"))

                            If Not DBExecutar(SqlText, DBParametro_Montar("QT_KG_NF", txtQuantidadeNF.Value), _
                                                       DBParametro_Montar("QT_KG_LIQUIDO_NF", txtQuantidadeLiquido.Value), _
                                                       DBParametro_Montar("VL_NF", txtValor.Value), _
                                                       DBParametro_Montar("VL_NF_ICMS", txtValorICMS.Value), _
                                                       DBParametro_Montar("VL_NF_FUNRURAL", txtValorINSS.Value), _
                                                       DBParametro_Montar("SQ_MOVIMENTACAO", Pesq_Movimentacao.Codigo)) Then GoTo Erro
                        End If

                        SqlText = DBMontar_SP("SOF.ACERTO_RD", False, ":FORN", _
                                                                      ":TPMOV", _
                                                                      ":FILMOV", _
                                                                      ":DATA", _
                                                                      ":NF", _
                                                                      ":VLNF", _
                                                                      ":VLICMS", _
                                                                      ":VLFUN", _
                                                                      ":KGLIQ", _
                                                                      ":TIPOCACAU", _
                                                                      ":DSACERTO", _
                                                                      ":P_MOV")

                        If Not DBExecutar(SqlText, DBParametro_Montar("FORN", NULLIf(Pesq_Fornecedor.Codigo, 0)), _
                                                   DBParametro_Montar("TPMOV", Pesq_TipoMovimentacao.Codigo), _
                                                   DBParametro_Montar("FILMOV", cboFilial.SelectedValue), _
                                                   DBParametro_Montar("DATA", Date_to_Oracle(DataSistema), OracleClient.OracleType.DateTime), _
                                                   DBParametro_Montar("NF", "ACERTO"), _
                                                   DBParametro_Montar("VLNF", IIf(VL_NF = 0, NVL(txtValor.Value, 0), NVL(txtValor.Value, 0) - VL_NF)), _
                                                   DBParametro_Montar("VLICMS", IIf(VL_NF_ICMS = 0, NVL(txtValorICMS.Value, 0), NVL(txtValorICMS.Value, 0) - VL_NF_ICMS)), _
                                                   DBParametro_Montar("VLFUN", IIf(VL_NF_FUNRURAL = 0, NVL(txtValorINSS.Value, 0), NVL(txtValorINSS.Value, 0) - VL_NF_FUNRURAL)), _
                                                   DBParametro_Montar("KGLIQ", IIf(QT_KG_LIQUIDO_NF = 0, NVL(txtQuantidadeLiquido.Value, 0), NVL(txtQuantidadeLiquido.Value, 0) - QT_KG_LIQUIDO_NF)), _
                                                   DBParametro_Montar("TIPOCACAU", 0), _
                                                   DBParametro_Montar("DSACERTO", txtJustificativaAjuste.Text, OracleClient.OracleType.VarChar, , 4000), _
                                                   DBParametro_Montar("P_MOV", NULLIf(SQ_MOVIMENTACAO, 0), , ParameterDirection.InputOutput)) Then GoTo Erro

                        SQ_MOVIMENTACAO = Val(DBRetorno(1))
                    Case cnt_TipoAjusteRD_Valor
                        SqlText = DBMontar_SP("SOF.INCLUI_RD", False, ":TPMOV", _
                                                                       ":DATA", _
                                                                       ":FILIAL", _
                                                                       ":VALOR", _
                                                                       ":QUANT")

                        If Not DBExecutar(SqlText, DBParametro_Montar("TPMOV", Pesq_TipoMovimentacao.Codigo), _
                                                   DBParametro_Montar("DATA", Date_to_Oracle(DataSistema), OracleClient.OracleType.DateTime), _
                                                   DBParametro_Montar("FILIAL", cboFilial.SelectedValue), _
                                                   DBParametro_Montar("VALOR", txtValor.Value), _
                                                   DBParametro_Montar("QUANT", txtQuantidadeNF.Value)) Then GoTo Erro
                End Select
            End If

            If chkAplicarAjuste_EstoqueFisico.Checked Then
                AjustarEstoque(SQ_MOVIMENTACAO)
            End If
        End If

        If Not DBExecutarTransacao() Then GoTo Erro

        Msg_Mensagem("Aprovação Efetuada")

        RaiseEvent EfetuouGravacao()

        Close()

        Exit Sub

Erro:
        TratarErro(, , "frmAjuste_RDE.Aprovacao")
    End Sub

    Private Sub AjustarEstoque(ByVal SQ_MOVIMENTACAO As Integer)
        Dim oData As DataTable = Nothing
        Dim SqlText As String
        Dim iCont_Grid As Integer
        Dim iCont As Integer
        Dim QT_AJUSTE As Double
        Dim SQ_MOVIMENTACAO_PILHA_ARMAZEM As Integer
        Dim SQ_MOV_PILHA_ARMAZEM_HISTORICO As Integer

        For iCont_Grid = 0 To grdGeral.Rows.Count - 1
            With grdGeral.Rows(iCont_Grid)
                SqlText = "SELECT COUNT(*)" & _
                          " FROM SOF.ARMAZEM_PILHA_LASTRO" & _
                          " WHERE CD_ARMAZEM =  " & .Cells(cnt_GridGeral_CD_ARMAZEM).Value & _
                            " AND CD_PILHA =  " & .Cells(cnt_GridGeral_CD_PILHA).Value & _
                            " AND NVL(CD_STATUS_FORMACAO, 0) = " & cnt_StatusFormacaoPilha_Sendodesmanchada
                If DBQuery_ValorUnico(SqlText, 0) > 0 Then
                    Msg_Mensagem("Existe pilha em processo de desmanche e por isso não poderá ser dado proseguimento no processo de aprovação.")
                    Exit Sub
                End If

                SqlText = "SELECT COUNT(*)" & _
                          " FROM SOF.MOVIMENTACAO_PILHA_ARMAZEM" & _
                          " WHERE SQ_MOVIMENTACAO = " & SQ_MOVIMENTACAO & _
                            " AND CD_ARMAZEM = " & .Cells(cnt_GridGeral_CD_ARMAZEM).Value & _
                            " AND CD_PILHA_ARMAZEM = " & .Cells(cnt_GridGeral_CD_PILHA).Value
                If DBQuery_ValorUnico(SqlText, 0) = 0 Then
                    Msg_Mensagem("Existe pilha que não está mais em estoque e por isso não poderá ser dado proseguimento no processo de aprovação.")
                    Exit Sub
                End If
            End With
        Next

        SqlText = "INSERT INTO SOF.TMP_PROCESSO (SQ_MOVIMENTACAO_AJUSTE) VALUES (" & SQ_MOVIMENTACAO & ")"
        If Not DBExecutar(SqlText) Then GoTo Erro

        For iCont_Grid = 0 To grdGeral.Rows.Count - 1
            With grdGeral.Rows(iCont_Grid)
                QT_AJUSTE = (.Cells(cnt_GridGeral_QT_SACOS_NOVO).Value - .Cells(cnt_GridGeral_QT_SACOS).Value)

                '>>> AJUSTE DE VOLUME EM PILHA
                If QT_AJUSTE <> 0 Then
                    SqlText = DBMontar_SP("SOF.SP_INCLUI_MOV_PILHA_ARM_HIST", False, ":CDARMAZEM", _
                                                                                     ":CDPILHAARMAZEM", _
                                                                                     ":SQMOVIMENTACAO", _
                                                                                     ":DTTRANSACAO", _
                                                                                     ":QTVOLUME", _
                                                                                     ":SQESTOQUESILO", _
                                                                                     ":ICSAIDA", _
                                                                                     ":SQTRANSF", _
                                                                                     ":SQITEMTRANSF", _
                                                                                     ":SQMOVPILHAARMAZEMHIST", _
                                                                                     ":CMLANCAMENTO")

                    If Not DBExecutar(SqlText, DBParametro_Montar("CDARMAZEM", .Cells(cnt_GridGeral_CD_ARMAZEM).Value), _
                                               DBParametro_Montar("CDPILHAARMAZEM", .Cells(cnt_GridGeral_CD_PILHA).Value), _
                                               DBParametro_Montar("SQMOVIMENTACAO", SQ_MOVIMENTACAO), _
                                               DBParametro_Montar("DTTRANSACAO", Date_to_Oracle(DataSistema)), _
                                               DBParametro_Montar("QTVOLUME", 0), _
                                               DBParametro_Montar("SQESTOQUESILO", Nothing), _
                                               DBParametro_Montar("ICSAIDA", IIf(QT_AJUSTE < 0, "S", "N")), _
                                               DBParametro_Montar("SQTRANSF", Nothing), _
                                               DBParametro_Montar("SQITEMTRANSF", Nothing), _
                                               DBParametro_Montar("SQMOVPILHAARMAZEMHIST", Nothing, , ParameterDirection.Output), _
                                               DBParametro_Montar("CMLANCAMENTO", Trim(txtJustificativaAjuste.Text), OracleClient.OracleType.VarChar, , 4000)) Then GoTo Erro

                    If DBTeveRetorno() Then
                        SQ_MOV_PILHA_ARMAZEM_HISTORICO = DBRetorno(1)
                    End If

                    SqlText = DBMontar_SP("SOF.SP_INCLUI_MOV_PILHA_ARM_HI_SAC", False, ":CDARMAZEM", _
                                                                                       ":CDPILHAARMAZEM", _
                                                                                       ":SQMOVIMENTACAO", _
                                                                                       ":SQMOVPILHAARMAZEMHIST", _
                                                                                       ":CDTIPOSACARIA", _
                                                                                       ":QTSACOS", _
                                                                                       ":CMLANCAMENTO")

                    If Not DBExecutar(SqlText, DBParametro_Montar("CDARMAZEM", .Cells(cnt_GridGeral_CD_ARMAZEM).Value), _
                                               DBParametro_Montar("CDPILHAARMAZEM", .Cells(cnt_GridGeral_CD_PILHA).Value), _
                                               DBParametro_Montar("SQMOVIMENTACAO", SQ_MOVIMENTACAO), _
                                               DBParametro_Montar("SQMOVPILHAARMAZEMHIST", SQ_MOV_PILHA_ARMAZEM_HISTORICO), _
                                               DBParametro_Montar("CDTIPOSACARIA", .Cells(cnt_GridGeral_CD_TIPO_SACARIA).Value), _
                                               DBParametro_Montar("QTSACOS", Math.Abs(QT_AJUSTE)), _
                                               DBParametro_Montar("CMLANCAMENTO", Trim(txtJustificativaAjuste.Text), OracleClient.OracleType.VarChar, , 4000)) Then GoTo Erro

                    SqlText = "SELECT SQ_MOVIMENTACAO, SQ_MOVIMENTACAO_PILHA_ARMAZEM, SQ_MOV_PILHA_ARMAZEM_SACARIA, QT_SACOS" & _
                              " FROM SOF.MOV_PILHA_ARMAZEM_SACARIA " & _
                              " WHERE CD_ARMAZEM = " & .Cells(cnt_GridGeral_CD_ARMAZEM).Value & _
                                " AND CD_PILHA_ARMAZEM = " & .Cells(cnt_GridGeral_CD_PILHA).Value & _
                                " AND SQ_MOVIMENTACAO = " & SQ_MOVIMENTACAO & _
                                " AND CD_TIPO_SACARIA = " & .Cells(cnt_GridGeral_CD_TIPO_SACARIA).Value
                    oData = DBQuery(SqlText)

                    For iCont = 0 To oData.Rows.Count - 1
                        If oData.Rows(iCont).Item("QT_SACOS") + QT_AJUSTE <= 0 Then
                            QT_AJUSTE = (oData.Rows(iCont).Item("QT_SACOS") + QT_AJUSTE)

                            SqlText = "DELETE FROM SOF.MOV_PILHA_ARMAZEM_SACARIA" & _
                                      " WHERE CD_ARMAZEM = " & .Cells(cnt_GridGeral_CD_ARMAZEM).Value & _
                                        " AND CD_PILHA_ARMAZEM = " & .Cells(cnt_GridGeral_CD_PILHA).Value & _
                                        " AND SQ_MOVIMENTACAO = " & SQ_MOVIMENTACAO & _
                                        " AND SQ_MOVIMENTACAO_PILHA_ARMAZEM = " & oData.Rows(iCont).Item("SQ_MOVIMENTACAO_PILHA_ARMAZEM") & _
                                        " AND SQ_MOV_PILHA_ARMAZEM_SACARIA = " & oData.Rows(iCont).Item("SQ_MOV_PILHA_ARMAZEM_SACARIA") & _
                                        " AND CD_TIPO_SACARIA = " & .Cells(cnt_GridGeral_CD_TIPO_SACARIA).Value
                            If Not DBExecutar(SqlText) Then GoTo Erro
                        Else
                            SqlText = "UPDATE SOF.MOV_PILHA_ARMAZEM_SACARIA" & _
                                      " SET QT_SACOS = " & oData.Rows(iCont).Item("QT_SACOS") + QT_AJUSTE & _
                                      " WHERE CD_ARMAZEM = " & .Cells(cnt_GridGeral_CD_ARMAZEM).Value & _
                                        " AND CD_PILHA_ARMAZEM = " & .Cells(cnt_GridGeral_CD_PILHA).Value & _
                                        " AND SQ_MOVIMENTACAO = " & SQ_MOVIMENTACAO & _
                                        " AND SQ_MOVIMENTACAO_PILHA_ARMAZEM = " & oData.Rows(iCont).Item("SQ_MOVIMENTACAO_PILHA_ARMAZEM") & _
                                        " AND SQ_MOV_PILHA_ARMAZEM_SACARIA = " & oData.Rows(iCont).Item("SQ_MOV_PILHA_ARMAZEM_SACARIA") & _
                                        " AND CD_TIPO_SACARIA = " & .Cells(cnt_GridGeral_CD_TIPO_SACARIA).Value
                            If Not DBExecutar(SqlText) Then GoTo Erro

                            QT_AJUSTE = 0
                        End If

                        If QT_AJUSTE = 0 Then
                            Exit For
                        End If
                    Next
                End If

                '>>> AJUSTE DE VOLUME EM PILHA
                QT_AJUSTE = (.Cells(cnt_GridGeral_QT_VOLUME_NOVO).Value - .Cells(cnt_GridGeral_QT_VOLUME).Value)

                If QT_AJUSTE <> 0 Then
                    SqlText = DBMontar_SP("SOF.SP_INCLUI_MOV_PILHA_ARM_HIST", False, ":CDARMAZEM", _
                                                                                     ":CDPILHAARMAZEM", _
                                                                                     ":SQMOVIMENTACAO", _
                                                                                     ":DTTRANSACAO", _
                                                                                     ":QTVOLUME", _
                                                                                     ":SQESTOQUESILO", _
                                                                                     ":ICSAIDA", _
                                                                                     ":SQTRANSF", _
                                                                                     ":SQITEMTRANSF", _
                                                                                     ":SQMOVPILHAARMAZEMHIST", _
                                                                                     ":CMLANCAMENTO")

                    If Not DBExecutar(SqlText, DBParametro_Montar("CDARMAZEM", .Cells(cnt_GridGeral_CD_ARMAZEM).Value), _
                                               DBParametro_Montar("CDPILHAARMAZEM", .Cells(cnt_GridGeral_CD_PILHA).Value), _
                                               DBParametro_Montar("SQMOVIMENTACAO", SQ_MOVIMENTACAO), _
                                               DBParametro_Montar("DTTRANSACAO", Date_to_Oracle(DataSistema)), _
                                               DBParametro_Montar("QTVOLUME", Math.Abs(QT_AJUSTE)), _
                                               DBParametro_Montar("SQESTOQUESILO", Nothing), _
                                               DBParametro_Montar("ICSAIDA", IIf(QT_AJUSTE < 0, "S", "N")), _
                                               DBParametro_Montar("SQTRANSF", Nothing), _
                                               DBParametro_Montar("SQITEMTRANSF", Nothing), _
                                               DBParametro_Montar("SQMOVPILHAARMAZEMHIST", Nothing, , ParameterDirection.Output), _
                                               DBParametro_Montar("CMLANCAMENTO", Trim(txtJustificativaAjuste.Text), OracleClient.OracleType.VarChar, , 4000)) Then GoTo Erro

                    SqlText = "SELECT SQ_MOVIMENTACAO_PILHA_ARMAZEM" & _
                              " FROM SOF.MOV_PILHA_ARMAZEM_SACARIA" & _
                              " WHERE CD_ARMAZEM = " & .Cells(cnt_GridGeral_CD_ARMAZEM).Value & _
                                " AND CD_PILHA_ARMAZEM = " & .Cells(cnt_GridGeral_CD_PILHA).Value & _
                                " AND SQ_MOVIMENTACAO = " & SQ_MOVIMENTACAO & _
                                " AND CD_TIPO_SACARIA = " & .Cells(cnt_GridGeral_CD_TIPO_SACARIA).Value
                    SQ_MOVIMENTACAO_PILHA_ARMAZEM = DBQuery_ValorUnico(SqlText)

                    SqlText = "SELECT SQ_MOVIMENTACAO_PILHA_ARMAZEM, QT_VOLUME" & _
                              " FROM SOF.MOVIMENTACAO_PILHA_ARMAZEM" & _
                              " WHERE CD_ARMAZEM = " & .Cells(cnt_GridGeral_CD_ARMAZEM).Value & _
                                " AND CD_PILHA_ARMAZEM = " & .Cells(cnt_GridGeral_CD_PILHA).Value & _
                                " AND SQ_MOVIMENTACAO = " & SQ_MOVIMENTACAO & _
                                " AND SQ_MOVIMENTACAO_PILHA_ARMAZEM = " & SQ_MOVIMENTACAO_PILHA_ARMAZEM
                    oData = DBQuery(SqlText)

                    For iCont = 0 To oData.Rows.Count - 1
                        If QT_AJUSTE <> 0 Then
                            SqlText = "UPDATE SOF.MOVIMENTACAO_PILHA_ARMAZEM" & _
                                      " SET QT_VOLUME = QT_VOLUME + " & QT_AJUSTE & _
                                      " WHERE CD_ARMAZEM = " & .Cells(cnt_GridGeral_CD_ARMAZEM).Value & _
                                        " AND CD_PILHA_ARMAZEM = " & .Cells(cnt_GridGeral_CD_PILHA).Value & _
                                        " AND SQ_MOVIMENTACAO = " & SQ_MOVIMENTACAO & _
                                        " AND SQ_MOVIMENTACAO_PILHA_ARMAZEM = " & oData.Rows(iCont).Item("SQ_MOVIMENTACAO_PILHA_ARMAZEM")
                            If Not DBExecutar(SqlText) Then GoTo Erro
                        Else
                            Exit For
                        End If
                    Next

                    SqlText = "UPDATE SOF.MOVIMENTACAO " & _
                              " SET QT_KG_A_TRANSFERIR = QT_KG_A_TRANSFERIR + " & QT_AJUSTE & _
                              " WHERE SQ_MOVIMENTACAO = " & SQ_MOVIMENTACAO
                    If Not DBExecutar(SqlText) Then GoTo Erro
                End If

                SqlText = "DELETE FROM SOF.TMP_PROCESSO WHERE SQ_MOVIMENTACAO_AJUSTE = " & SQ_MOVIMENTACAO
                If Not DBExecutar(SqlText) Then GoTo Erro
            End With
        Next
        objData_Finalizar(oData)

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub cmdReprovar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdReprovar.Click
        Aprovacao(False)
    End Sub

    Private Sub CarregarDados()
        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "SELECT * FROM SOF.RESUMO_DIARIO_ESTOQUE_ACERTO WHERE SQ_ACERTO = " & SQ_ACERTO
        oData = DBQuery(SqlText)

        bProcInterno = True

        With oData.Rows(0)
            ComboBox_Possicionar(cboTipoAcerto, NVL(.Item("CD_TIPO_ACERTO"), 0))
            chkAplicarAjuste_RDE.Checked = (NVL(.Item("IC_ACERTO_RD"), "N") = "S")
            chkAplicarAjuste_EstoqueFisico.Checked = (NVL(.Item("IC_ACERTO_ESTOQUE"), "N") = "S")
            Pesq_Movimentacao.Codigo = NVL(.Item("SQ_MOVIMENTACAO"), 0)
            Pesq_TipoMovimentacao.Codigo = NVL(.Item("CD_TIPO_MOVIMENTACAO"), 0)
            ComboBox_Possicionar(cboFilial, NVL(.Item("CD_FILIAL_ORIGEM"), 0))
            Pesq_Fornecedor.Codigo = NVL(.Item("CD_FORNECEDOR"), 0)
            txtDataLancamento.Text = .Item("DT_AJUSTE")
            txtQuantidadeNF.Value = NVL(.Item("QT_AJUSTE_NF"), 0)
            txtQuantidadeLiquido.Value = NVL(.Item("QT_AJUSTE"), 0)
            txtValor.Value = NVL(.Item("VL_AJUSTE"), 0)
            txtValorICMS.Value = NVL(.Item("VL_AJUSTE_ICMS"), 0)
            txtValorINSS.Value = NVL(.Item("VL_AJUSTE_INSS"), 0)
            txtJustificativaAjuste.Text = NVL(.Item("CM_JUSTIFICATIVA"), "")
            txtJustificativaAprovacao.Text = NVL(.Item("CD_USUARIO_APROVACAO"), "")
        End With

        objData_Finalizar(oData)

        SqlText = "SELECT ACT.CD_ARMAZEM," & _
                         "ACT.CD_TIPO_SACARIA," & _
                         "ARM.NO_ARMAZEM," & _
                         "ACT.CD_PILHA," & _
                         "TPS.NO_TIPO_SACARIA," & _
                         "ACT.QT_MOVIMENTACAO_ANTERIOR," & _
                         "ACT.QT_SACOS_ANTERIOR," & _
                         "ACT.QT_MOVIMENTACAO_NOVO," & _
                         "ACT.QT_SACOS_NOVO" & _
                  " FROM SOF.RESUMO_DIARIO_ESTOQUE_ACT_AMZ ACT," & _
                        "SOF.ARMAZEM ARM," & _
                        "SOF.TIPO_SACARIA TPS" & _
                  " WHERE ACT.SQ_ACERTO = " & SQ_ACERTO & _
                    " AND ARM.CD_ARMAZEM = ACT.CD_ARMAZEM" & _
                    " AND TPS.CD_TIPO_SACARIA = ACT.CD_TIPO_SACARIA" & _
                 " ORDER BY ARM.NO_ARMAZEM," & _
                           "ACT.CD_PILHA"
        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_CD_ARMAZEM, _
                                                           cnt_GridGeral_CD_TIPO_SACARIA, _
                                                           cnt_GridGeral_NO_ARMAZEM, _
                                                           cnt_GridGeral_CD_PILHA, _
                                                           cnt_GridGeral_NO_TIPO_SACARIA, _
                                                           cnt_GridGeral_QT_VOLUME, _
                                                           cnt_GridGeral_QT_SACOS, _
                                                           cnt_GridGeral_QT_VOLUME_NOVO, _
                                                           cnt_GridGeral_QT_SACOS_NOVO})

        bProcInterno = False
    End Sub

    Private Sub chkAplicarAjuste_EstoqueFisico_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAplicarAjuste_EstoqueFisico.CheckedChanged
        CheckAplicarAjuste_EstoqueFisico_Validar()
    End Sub

    Private Sub CheckAplicarAjuste_EstoqueFisico_Validar()
        Dim bEstoqueFisico As Boolean

        bEstoqueFisico = chkAplicarAjuste_EstoqueFisico.Checked

        lblR_Movimentacao.Enabled = bEstoqueFisico
        Pesq_Movimentacao.Enabled = bEstoqueFisico
        lblR_TipoMovimentacao.Enabled = (Not bEstoqueFisico)
        Pesq_TipoMovimentacao.Enabled = (Not bEstoqueFisico)
        lblR_Filial.Enabled = (Not bEstoqueFisico)
        cboFilial.Enabled = (Not bEstoqueFisico)
        lblR_DataMovimentacao.Enabled = (Not bEstoqueFisico)
        txtDataMovimentacao.Enabled = (Not bEstoqueFisico)
        AtivaFornecedor()
        chkAplicarAjuste_RDE.Enabled = (Not bEstoqueFisico)
        chkAplicarAjuste_RDE.Checked = IIf(bEstoqueFisico, True, chkAplicarAjuste_RDE.Checked)

        CampoEstoqueFisico_Limpar()
    End Sub

    Private Sub AtivaFornecedor()
        If (NVL(cboTipoAcerto.SelectedValue, cnt_TipoAjusteRD_Movimentacao) = cnt_TipoAjusteRD_Movimentacao) Then
            chkFornecedor.Enabled = True
        Else
            chkFornecedor.Checked = False
            chkFornecedor.Enabled = False
        End If
    End Sub

    Private Sub Pesq_Movimentacao_AlterouRegistro() Handles Pesq_Movimentacao.AlterouRegistro
        If bProcInterno Then Exit Sub

        CampoEstoqueFisico_Limpar(False)

        If Pesq_Movimentacao.Codigo > 0 Then
            Dim oData As DataTable
            Dim SqlText As String
            Dim iCont As Integer

            SqlText = "SELECT * FROM SOF.MOVIMENTACAO WHERE SQ_MOVIMENTACAO = " & Pesq_Movimentacao.Codigo
            oData = DBQuery(SqlText)

            With oData.Rows(0)
                Pesq_TipoMovimentacao.Codigo = .Item("CD_TIPO_MOVIMENTACAO")
                ComboBox_Possicionar(cboFilial, .Item("CD_FILIAL_ORIGEM"))
                txtDataMovimentacao.Text = .Item("DT_MOVIMENTACAO")
                Pesq_Fornecedor.Codigo = NVL(.Item("CD_FORNECEDOR"), 0)
                txtQuantidadeNF.Value = .Item("QT_KG_NF")
                txtQuantidadeLiquido.Value = .Item("QT_KG_LIQUIDO_NF")
                txtQuantidadeLiquido.Tag = .Item("QT_KG_LIQUIDO_NF")
                txtValor.Value = .Item("VL_NF")
                txtValorICMS.Value = .Item("VL_NF_ICMS")
                txtValorINSS.Value = .Item("VL_NF_FUNRURAL")
            End With

            SqlText = "SELECT MPA.CD_ARMAZEM," & _
                             "MPS.CD_TIPO_SACARIA," & _
                             "ARM.NO_ARMAZEM," & _
                             "MPA.CD_PILHA_ARMAZEM," & _
                             "TPS.NO_TIPO_SACARIA," & _
                             "SUM(MPA.QT_VOLUME) QT_VOLUME," & _
                             "SUM(MPS.QT_SACOS) QT_SACOS" & _
                      " FROM SOF.MOVIMENTACAO_PILHA_ARMAZEM MPA," & _
                            "SOF.MOV_PILHA_ARMAZEM_SACARIA MPS," & _
                            "SOF.ARMAZEM ARM," & _
                            "SOF.TIPO_SACARIA TPS" & _
                      " WHERE MPA.SQ_MOVIMENTACAO = " & Pesq_Movimentacao.Codigo & _
                        " AND MPS.CD_ARMAZEM = MPA.CD_ARMAZEM" & _
                        " AND MPS.CD_PILHA_ARMAZEM = MPA.CD_PILHA_ARMAZEM" & _
                        " AND MPS.SQ_MOVIMENTACAO = MPA.SQ_MOVIMENTACAO" & _
                        " AND MPS.SQ_MOVIMENTACAO_PILHA_ARMAZEM = MPA.SQ_MOVIMENTACAO_PILHA_ARMAZEM" & _
                        " AND ARM.CD_ARMAZEM = MPS.CD_ARMAZEM" & _
                        " AND TPS.CD_TIPO_SACARIA = MPS.CD_TIPO_SACARIA" & _
                     " GROUP BY MPA.CD_ARMAZEM," & _
                               "MPS.CD_TIPO_SACARIA," & _
                               "ARM.NO_ARMAZEM," & _
                               "MPA.CD_PILHA_ARMAZEM," & _
                               "TPS.NO_TIPO_SACARIA" & _
                     " ORDER BY ARM.NO_ARMAZEM," & _
                               "MPA.CD_PILHA_ARMAZEM"
            oData = DBQuery(SqlText)

            oDS.Rows.Clear()

            For iCont = 0 To oData.Rows.Count - 1
                With oDS.Rows.Add
                    .Item(cnt_GridGeral_CD_ARMAZEM) = oData.Rows(iCont).Item("CD_ARMAZEM")
                    .Item(cnt_GridGeral_CD_TIPO_SACARIA) = oData.Rows(iCont).Item("CD_TIPO_SACARIA")
                    .Item(cnt_GridGeral_NO_ARMAZEM) = oData.Rows(iCont).Item("NO_ARMAZEM")
                    .Item(cnt_GridGeral_CD_PILHA) = oData.Rows(iCont).Item("CD_PILHA_ARMAZEM")
                    .Item(cnt_GridGeral_NO_TIPO_SACARIA) = oData.Rows(iCont).Item("NO_TIPO_SACARIA")
                    .Item(cnt_GridGeral_QT_VOLUME) = oData.Rows(iCont).Item("QT_VOLUME")
                    .Item(cnt_GridGeral_QT_SACOS) = oData.Rows(iCont).Item("QT_SACOS")
                    .Item(cnt_GridGeral_QT_VOLUME_NOVO) = oData.Rows(iCont).Item("QT_VOLUME")
                    .Item(cnt_GridGeral_QT_SACOS_NOVO) = oData.Rows(iCont).Item("QT_SACOS")
                End With
            Next
        End If
    End Sub

    Private Sub CampoEstoqueFisico_Limpar(Optional ByVal bLimparMovimentacao As Boolean = True)
        If bLimparMovimentacao Then Pesq_Movimentacao.Codigo = 0
        Pesq_TipoMovimentacao.Codigo = 0
        cboFilial.SelectedIndex = -1
        txtDataMovimentacao.Text = ""
        Pesq_Fornecedor.Codigo = 0
        txtQuantidadeLiquido.Tag = 0
        txtQuantidadeNF.Tag = 0
        txtValor.Tag = 0
        txtValorICMS.Tag = 0
        txtValorINSS.Tag = 0

        oDS.Rows.Clear()
    End Sub

    Private Sub chkAplicarAjuste_RDE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAplicarAjuste_RDE.CheckedChanged
        CheckAplicarAjuste_RDE_Validar()
    End Sub

    Private Sub CheckAplicarAjuste_RDE_Validar()
        Dim bRDE As Boolean

        bRDE = chkAplicarAjuste_RDE.Checked

        lblR_QuantidadeNF.Enabled = bRDE
        txtQuantidadeNF.Enabled = bRDE
        lblR_QuantidadeLiquido.Enabled = bRDE
        txtQuantidadeLiquido.Enabled = bRDE
        lblR_Valor.Enabled = bRDE
        txtValor.Enabled = bRDE
        lblR_ICMS.Enabled = bRDE
        txtValorICMS.Enabled = bRDE
        lblR_ValorINSS.Enabled = bRDE
        txtValorINSS.Enabled = bRDE
    End Sub

    Private Sub chkFornecedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFornecedor.CheckedChanged
        If chkFornecedor.Checked = True Then
            Pesq_Fornecedor.Enabled = True
        Else
            Pesq_Fornecedor.Codigo = 0
            Pesq_Fornecedor.Enabled = False
        End If
    End Sub
End Class