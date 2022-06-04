Imports Infragistics.Win

Public Class frmRequisicaoSacaria
    Public Enum TipoAcao
        TA_EntregaSacaria = 1
        TA_Devolucao = 2
        TA_Requisicao = 3
    End Enum

    Const cnt_GridReqSacaria_CDTipoSacaria As Integer = 0
    Const cnt_GridReqSacaria_TipoSacaria As Integer = 1
    Const cnt_GridReqSacaria_Qt_Sacos As Integer = 2

    Const cnt_GridSaldo_TipoSacaria As Integer = 0
    Const cnt_GridSaldo_Qt_Sacos As Integer = 1

    Dim Tipo As TipoAcao
    Dim SQ_REQUISICAO As Integer

    Dim oDS_RequisacaoSacaria As New UltraWinDataSource.UltraDataSource
    Dim oDS_SaldoFornecedor As New UltraWinDataSource.UltraDataSource

    Public Cancelado As Boolean

    Private Sub frmRequisicaoSacaria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlText As String
        Dim oData As DataTable = Nothing

        Pesq_Fornecedor.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        objGrid_Inicializar(grdSacariaRequisicao, , oDS_RequisacaoSacaria)
        objGrid_Coluna_Add(grdSacariaRequisicao, "CDTipoSacaria", 0)
        objGrid_Coluna_Add(grdSacariaRequisicao, "Tipo de Sacaria", 140)
        objGrid_Coluna_Add(grdSacariaRequisicao, "Qtde. de Sacos", 105, , True)

        objGrid_Inicializar(grdSaldo, , oDS_SaldoFornecedor)
        objGrid_Coluna_Add(grdSaldo, "Tipo de Sacaria", 140)
        objGrid_Coluna_Add(grdSaldo, "Qtde. de Sacos", 105)

        Select Case Tipo
            Case TipoAcao.TA_Requisicao
                Me.Text = Me.Text & " - Inclusão"

                fraTomador.Enabled = False
            Case TipoAcao.TA_EntregaSacaria
                Me.Text = Me.Text & " - Entrega de Sacraria"

                SqlText = "SELECT * FROM SOF.SACARIA_REQUISICAO" & _
                          " WHERE SQ_SACARIA_REQUISICAO = " & SQ_REQUISICAO
                oData = DBQuery(SqlText)

                If oData.Rows.Count = 0 Then
                    Msg_Mensagem("Algum usuario do sistema eliminou o registro")
                    Exit Sub
                End If

                Pesq_Fornecedor.Codigo = oData.Rows(0).Item("CD_FORNECEDOR")
                txtQuantidadeRequisicao.Value = oData.Rows(0).Item("QT_SACOS")

                Pesq_Fornecedor.Enabled = False
                txtQuantidadeRequisicao.Enabled = False

                CarregarGrid_SaldoFornecedor()
                CarregarGrid_SacariaRequisitavel()
            Case TipoAcao.TA_Devolucao
                Me.Text = Me.Text & " - Devolução de Sacaria"

                txtQuantidadeRequisicao.Enabled = False

                fraTomador.Enabled = False
        End Select

        objData_Finalizar(oData)
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim Transacao As Boolean
        Dim QtdeSelecionada As Integer
        Dim SqlText As String
        Dim iCont As Integer

        QtdeSelecionada = objGrid_CalcularTotalColuna(grdSacariaRequisicao, cnt_GridReqSacaria_Qt_Sacos)

        If Pesq_Fornecedor.Codigo = 0 Then
            Msg_Mensagem("Favor informar um codigo de fornecedor valido.")
            Exit Sub
        End If
        If txtQuantidadeRequisicao.Value = 0 Then
            Msg_Mensagem("Quantidade de sacos invalida.")
            Exit Sub
        End If
        If txtQuantidadeRequisicao.Value > 5000 Then
            Msg_Mensagem("Quantidade de sacos não pode ser maior que 5000.")
            Exit Sub
        End If
        If QtdeSelecionada = 0 Then
            Msg_Mensagem("Escolha os tipos de Sacos.")
            Exit Sub
        End If

        If Tipo = TipoAcao.TA_EntregaSacaria Then
            If Trim(txtTomador_Nome.Text) = "" Then
                Msg_Mensagem("Favor informar o nome da pessoal que veio retirar a sacaria.")
                Exit Sub
            End If
        End If

        If Tipo = TipoAcao.TA_EntregaSacaria Then
            If QtdeSelecionada < txtQuantidadeRequisicao.Value Then
                If Not Msg_Perguntar("Deseja fechar entregando apenas " & QtdeSelecionada & " sacos," & _
                                     " foram solicitados " & txtQuantidadeRequisicao.Value) Then Exit Sub
                txtQuantidadeRequisicao.Value = QtdeSelecionada
            Else
                If QtdeSelecionada > txtQuantidadeRequisicao.Value Then
                    Msg_Mensagem("Quantidade de sacos maior que a quantidade requisitada.")
                    Exit Sub
                End If
            End If
        End If

        On Error GoTo Erro

        Dim SQ_REQUISICAO_INT As Integer
        Dim Parametro(7) As DBParamentro

        DBUsarTransacao = True

        SQ_REQUISICAO_INT = SQ_REQUISICAO

        SqlText = DBMontar_SP("SOF.SP_INCLUI_REQUISICAO_SACARIA", False, ":CDFORN", _
                                                                         ":QTSACOS", _
                                                                         ":NOTOMADOR", _
                                                                         ":NORG", _
                                                                         ":CDSTATUS", _
                                                                         ":CDFIL", _
                                                                         ":ICENTSAI", _
                                                                         ":SQ_REQUISICAO")

        Parametro(0) = DBParametro_Montar("CDFORN", Pesq_Fornecedor.Codigo)
        Parametro(1) = DBParametro_Montar("QTSACOS", txtQuantidadeRequisicao.Value)

        Select Case Tipo
            Case TipoAcao.TA_EntregaSacaria
                Parametro(2) = DBParametro_Montar("NOTOMADOR", txtTomador_Nome.Text)
                Parametro(3) = DBParametro_Montar("NORG", txtTomador_RG.Text)
                Parametro(4) = DBParametro_Montar("CDSTATUS", Val(enProcesso_Status.ReqSaca_Entregue))
                Parametro(5) = DBParametro_Montar("CDFIL", FilialLogada)
                Parametro(6) = DBParametro_Montar("ICENTSAI", "S")
                Parametro(7) = DBParametro_Montar("SQ_REQUISICAO", SQ_REQUISICAO_INT, , ParameterDirection.InputOutput)
            Case TipoAcao.TA_Requisicao
                Parametro(2) = DBParametro_Montar("NOTOMADOR", Nothing)
                Parametro(3) = DBParametro_Montar("NORG", Nothing)
                Parametro(4) = DBParametro_Montar("CDSTATUS", Val(enProcesso_Status.ReqSaca_AguardandoEntrega))
                Parametro(5) = DBParametro_Montar("CDFIL", Nothing)
                Parametro(6) = DBParametro_Montar("ICENTSAI", "S")
                Parametro(7) = DBParametro_Montar("SQ_REQUISICAO", Nothing, , ParameterDirection.Output)
            Case TipoAcao.TA_Devolucao
                Parametro(2) = DBParametro_Montar("NOTOMADOR", NULLIf(txtTomador_Nome.Text, ""))
                Parametro(3) = DBParametro_Montar("NORG", NULLIf(txtTomador_RG.Text, ""))
                Parametro(4) = DBParametro_Montar("CDSTATUS", Val(enProcesso_Status.ReqSaca_Entregue))
                Parametro(5) = DBParametro_Montar("CDFIL", FilialLogada)
                Parametro(6) = DBParametro_Montar("ICENTSAI", "E")
                Parametro(7) = DBParametro_Montar("SQ_REQUISICAO", Nothing, , ParameterDirection.Output)
        End Select

        If Not DBExecutar(SqlText, Parametro) Then GoTo Erro

        If DBTeveRetorno() Then
            SQ_REQUISICAO_INT = Val(DBRetorno(1))
        End If

        For iCont = 0 To grdSacariaRequisicao.Rows.Count - 1
            If objGrid_Valor(grdSacariaRequisicao, cnt_GridReqSacaria_Qt_Sacos, iCont) <> 0 Then
                SqlText = DBMontar_SP("SOF.SP_INCLUI_REQ_SACARIA_ITEM", False, ":CDTIPO", _
                                                                               ":QTSACOS", _
                                                                               ":SQ_REQUISICAO", _
                                                                               ":ICENT", _
                                                                               ":DT")

                If Not DBExecutar(SqlText, DBParametro_Montar("CDTIPO", objGrid_Valor(grdSacariaRequisicao, cnt_GridReqSacaria_CDTipoSacaria, iCont)), _
                                           DBParametro_Montar("QTSACOS", objGrid_Valor(grdSacariaRequisicao, cnt_GridReqSacaria_Qt_Sacos, iCont)), _
                                           DBParametro_Montar("SQ_REQUISICAO", SQ_REQUISICAO_INT), _
                                           DBParametro_Montar("ICENT", IIf(Tipo = TipoAcao.TA_Requisicao, "N", "S")), _
                                           DBParametro_Montar("DT", Date_TratarBancoDados(DataSistema), OracleClient.OracleType.DateTime)) Then GoTo Erro
            Else
                'SE FOR ALTERAÇÃO TENTO EXCLUIR POIS PODERIA TER SACOS E SER ZERADO
                If Tipo = TipoAcao.TA_EntregaSacaria Then
                    SqlText = "DELETE FROM SOF.SACARIA_REQUISICAO_ITEM SRI " & _
                              " WHERE SRI.SQ_SACARIA_REQUISICAO = " & SQ_REQUISICAO_INT & _
                                " AND SRI.CD_TIPO_SACARIA = " & objGrid_Valor(grdSacariaRequisicao, cnt_GridReqSacaria_CDTipoSacaria, iCont)
                    If Not DBExecutar(SqlText) Then GoTo Erro
                End If
            End If
        Next

        If Not DBExecutarTransacao() Then GoTo Erro

        'Se for entrega ou devolução já gero o comprovante
        If Tipo = TipoAcao.TA_EntregaSacaria Or Tipo = TipoAcao.TA_Devolucao Then
            Dim oRelatorio As New frmRelatorioGeral

            oRelatorio.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eSacariaRequisicao
            oRelatorio.Filtro01 = SQ_REQUISICAO_INT

            Form_Show(Nothing, oRelatorio)
        End If

        Cancelado = False

        If SQ_REQUISICAO > 0 Then
            Msg_Mensagem("Gravação efetuada")
            Close()
        Else
            Msg_Mensagem("Requisição salva com o nº " & SQ_REQUISICAO_INT)
            LimparTela()
        End If

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Cancelado = True
        Close()
    End Sub

    Private Sub grdSacariaRequisicao_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdSacariaRequisicao.AfterCellUpdate
        Select Case Tipo
            Case TipoAcao.TA_Requisicao, TipoAcao.TA_Devolucao
                txtQuantidadeRequisicao.Value = objGrid_CalcularTotalColuna(grdSacariaRequisicao, cnt_GridReqSacaria_Qt_Sacos)
        End Select
    End Sub

    Private Sub CarregarGrid_SaldoFornecedor()
        Dim SqlText As String

        If Pesq_Fornecedor.Codigo = 0 Then Exit Sub

        SqlText = "SELECT TS.NO_TIPO_SACARIA," & _
                         "NVL(SUM(DECODE(SF.IC_ENTRADA_SAIDA, 'S', - SF.QT_SACOS, SF.QT_SACOS)), 0) AS QT_SACOS" & _
                  " FROM SOF.SACARIA_FORNECEDOR SF," & _
                        "SOF.TIPO_SACARIA TS," & _
                        "SOF.FORNECEDOR FN" & _
                  " WHERE SF.CD_TIPO_SACARIA = TS.CD_TIPO_SACARIA" & _
                    " AND TS.IC_CONTABILIZA_FORNECEDOR = 'S'" & _
                    " AND FN.CD_FORNECEDOR = SF.CD_FORNECEDOR" & _
                    " AND (FN.CD_FORNECEDOR = " & Pesq_Fornecedor.Codigo & " OR " & _
                          "FN.CD_REPASSADOR = " & Pesq_Fornecedor.Codigo & ")" & _
                  " GROUP BY TS.NO_TIPO_SACARIA"

        objGrid_Carregar(grdSaldo, SqlText, New Integer() {cnt_GridSaldo_TipoSacaria, _
                                                           cnt_GridSaldo_Qt_Sacos})

        objGrid_ExibirTotal(grdSaldo, cnt_GridSaldo_Qt_Sacos)
    End Sub

    Private Sub CarregarGrid_SacariaRequisitavel()
        Dim SqlText As String

        If Tipo = TipoAcao.TA_Requisicao Or Tipo = TipoAcao.TA_Devolucao Then
            SqlText = "SELECT TS.CD_TIPO_SACARIA," & _
                             "TS.NO_TIPO_SACARIA," & _
                             "0 QT_SACOS" & _
                      " FROM SOF.TIPO_SACARIA TS" & _
                      " WHERE TS.IC_CONTABILIZA_FORNECEDOR = 'S'" & _
                      " ORDER BY TS.NO_TIPO_SACARIA"
        Else
            SqlText = "SELECT TS.CD_TIPO_SACARIA," & _
                             "TS.NO_TIPO_SACARIA," & _
                             "NVL(SRI.QT_SACOS,0) AS QT_SACOS" & _
                      " FROM  SOF.TIPO_SACARIA TS," & _
                             "SOF.SACARIA_REQUISICAO_ITEM SRI" & _
                      " WHERE TS.IC_CONTABILIZA_FORNECEDOR = 'S'" & _
                        " AND SRI.CD_TIPO_SACARIA (+) = TS.CD_TIPO_SACARIA" & _
                        " AND SRI.SQ_SACARIA_REQUISICAO (+)= " & SQ_REQUISICAO & _
                      " ORDER BY TS.NO_TIPO_SACARIA"
        End If

        objGrid_Carregar(grdSacariaRequisicao, SqlText, New Integer() {cnt_GridReqSacaria_CDTipoSacaria, _
                                                                       cnt_GridReqSacaria_TipoSacaria, _
                                                                       cnt_GridReqSacaria_Qt_Sacos})
        objGrid_ExibirTotal(grdSacariaRequisicao, cnt_GridReqSacaria_Qt_Sacos)
    End Sub

    Public Sub Carregar(ByVal parTipo As TipoAcao, ByVal parSQ_REQUISICAO As Integer)
        Tipo = parTipo
        SQ_REQUISICAO = parSQ_REQUISICAO
    End Sub

    Private Sub Pesq_Fornecedor_AlterouRegistro() Handles Pesq_Fornecedor.AlterouRegistro
        CarregarGrid_SacariaRequisitavel()
        CarregarGrid_SaldoFornecedor()
    End Sub

    Private Sub grdSacariaRequisicao_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdSacariaRequisicao.KeyDown
        If e.KeyCode = Keys.Enter Then
            grdSacariaRequisicao.PerformAction(UltraWinGrid.UltraGridAction.ExitEditMode)
        End If
    End Sub

    Private Sub LimparTela()
        oDS_RequisacaoSacaria.Rows.Clear()
        oDS_SaldoFornecedor.Rows.Clear()

        Pesq_Fornecedor.Codigo = 0
        txtQuantidadeRequisicao.Value = 0
        txtTomador_Nome.Text = ""
        txtTomador_RG.Text = ""
    End Sub

    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        LimparTela()
    End Sub
End Class