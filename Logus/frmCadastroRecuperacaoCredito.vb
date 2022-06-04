Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmCadastroRecuperacaoCredito
    Const cnt_GridParcela_Forma As Integer = 0
    Const cnt_GridParcela_Quantidade As Integer = 1
    Const cnt_GridParcela_Valor As Integer = 2
    Const cnt_GridParcela_Vencimento As Integer = 3
    Const cnt_GridParcela_Descricao As Integer = 4

    Const cnt_GridContrato_contrato_PAF As Integer = 0
    Const cnt_GridContrato_Negociacao As Integer = 1
    Const cnt_GridContrato_Contrato_Fixo As Integer = 2
    Const cnt_GridContrato_Valor As Integer = 3
    Const cnt_GridContrato_Quantidade As Integer = 4

    Dim oDSContrato As New UltraWinDataSource.UltraDataSource
    Dim oDSParcela As New UltraWinDataSource.UltraDataSource

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmCadastroRecuperacaoCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim oLista As New ValueList
        oLista.ValueListItems.Add("C", "Cacau")
        oLista.ValueListItems.Add("D", "Dinheiro")
        oLista.ValueListItems.Add("O", "Saldo CTR")

        objGrid_Inicializar(grdContratos, , oDSContrato, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)

        objGrid_Coluna_Add(grdContratos, "Contrato PAF", 100)
        objGrid_Coluna_Add(grdContratos, "Negociação", 100)
        objGrid_Coluna_Add(grdContratos, "Contrato Fixo", 100)
        objGrid_Coluna_Add(grdContratos, "Valor", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdContratos, "Quantidade", 140, , , , , cnt_Formato_Kilos)

        objGrid_ExibirTotal(grdContratos, New Integer() {cnt_GridContrato_Valor, cnt_GridContrato_Quantidade})

        objGrid_Inicializar(grdParcelas, , oDSParcela, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)
        objGrid_Coluna_Add(grdParcelas, "Forma", 60, , , UltraWinGrid.ColumnStyle.DropDownList, oLista)
        objGrid_Coluna_Add(grdParcelas, "Quantidade", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdParcelas, "Valor", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdParcelas, "Vencimento", 100)
        objGrid_Coluna_Add(grdParcelas, "Descrição", 240)

        objGrid_ExibirTotal(grdParcelas, New Integer() {cnt_GridParcela_Valor, cnt_GridParcela_Quantidade})

        objUltraComboBox_Inicializar(cboContratoPaf, 270)

        ComboBox_Carregar_Modalidade_Recuperacao(cboModalidade, True)

        Pesq_FornecedorContrato.Enabled = SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_AlterarFornecCtrRecuperacaoCredito)

        Pesq_FornecedorContrato.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        Pesq_FornecedorRecuperacao.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        chkJuros_CheckedChanged(Nothing, Nothing)
        optForma_ValueChanged(Nothing, Nothing)
        txtJurosAoMes.Value = DBQuery_ValorUnico("SELECT P.PC_JUROS_AO_MES FROM SOF.PARAMETRO P")

        grdContratos.DisplayLayout.Bands(0).Override.AllowDelete = DefaultableBoolean.True
        grdParcelas.DisplayLayout.Bands(0).Override.AllowDelete = DefaultableBoolean.True
    End Sub

    Private Sub chkJuros_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkJuros.CheckedChanged
        If chkJuros.Checked = True Then
            txtJurosAoMes.Enabled = True
            txtDataInicioCobraJuros.Enabled = True
        Else
            txtJurosAoMes.Enabled = False
            txtDataInicioCobraJuros.Enabled = False
            txtDataInicioCobraJuros.Value = Nothing
        End If
    End Sub

    Private Sub Pesq_FornecedorRecuperacao_AlterouRegistro() Handles Pesq_FornecedorRecuperacao.AlterouRegistro
        Pesq_FornecedorContrato.Codigo = Pesq_FornecedorRecuperacao.Codigo
    End Sub

    Private Sub Pesq_FornecedorContrato_AlterouRegistro() Handles Pesq_FornecedorContrato.AlterouRegistro
        Dim SqlText As String

        SqlText = "select cp.cd_contrato_paf, tcp.no_tipo_contrato_paf,tcp.ic_adiantamento " & _
                  "from sof.contrato_paf cp, sof.tipo_contrato_paf tcp " & _
                  "where cp.cd_tipo_contrato_paf = tcp.cd_tipo_contrato_paf and " & _
                  "CP.cd_fornecedor = " & Pesq_FornecedorContrato.Codigo & " AND " & _
                  "CP.IC_STATUS in ('A') " & _
                  "order by CP.cd_contrato_paf"

        objUltraComboBox_Carregar(cboContratoPaf, SqlText, _
                          New Combo_Informacao() {objUltraComboBox_Informacao("Contrato PAF", True, 120, True, True), _
                                                  objUltraComboBox_Informacao("Tipo Contrato", True, 140, False, False), _
                                                  objUltraComboBox_Informacao("ADTO", False, 0, False, False)})
    End Sub

    Private Sub cboContratoPaf_RowSelected(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowSelectedEventArgs) Handles cboContratoPaf.RowSelected
        Dim SqlText As String

        If cboContratoPaf.SelectedRow Is Nothing Then
            cboNegociacao.DataSource = Nothing
            cboContratoFixo.DataSource = Nothing
            Exit Sub
        End If

        'Para saldo em Contrato PAF
        SqlText = "SELECT CP.QT_KGS - CP.QT_CANCELADO-GREATEST(CP.QT_KG_FIXO, CP.QT_KGS - CP.QT_CANCELADO - CP.QT_A_NEGOCIAR) QT_KGS" & _
                  " FROM SOF.CONTRATO_PAF CP " & _
                  " WHERE CP.CD_CONTRATO_PAF = " & cboContratoPaf.Rows(cboContratoPaf.ActiveRow.Index).Cells(0).Value
        txtQuantidadeContrato.Value = DBQuery_ValorUnico(SqlText, 0)

        SqlText = "SELECT NVL(SUM(PCP.VL_A_FIXAR), 0) VL_SALDO " & _
                  " FROM SOF.PAG_CTR_PAF PCP " & _
                  " WHERE PCP.CD_CONTRATO_PAF = " & cboContratoPaf.Rows(cboContratoPaf.ActiveRow.Index).Cells(0).Value
        txtValorContrato.Value = DBQuery_ValorUnico(SqlText, 0)

        cboNegociacao.DataSource = Nothing

        'Para saldo em contrato fixo
        SqlText = "SELECT N.SQ_NEGOCIACAO," & _
                             "TO_CHAR(N.SQ_NEGOCIACAO) AS NO_NEGOCIACAO " & _
                      " FROM SOF.NEGOCIACAO N," & _
                            "SOF.TIPO_NEGOCIACAO TN " & _
                      " WHERE TN.CD_TIPO_NEGOCIACAO = N.CD_TIPO_NEGOCIACAO" & _
                        " AND N.CD_CONTRATO_PAF = " & cboContratoPaf.Rows(cboContratoPaf.ActiveRow.Index).Cells(0).Value & _
                        " AND N.IC_STATUS = 'A'"
        DBCarregarComboBox(cboNegociacao, SqlText, True)
    End Sub

    Private Sub cboNegociacao_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNegociacao.SelectedIndexChanged
        Dim SqlText As String

        If cboContratoPaf.SelectedRow Is Nothing Then
            cboNegociacao.DataSource = Nothing
            cboContratoFixo.DataSource = Nothing
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboNegociacao) Then
            cboContratoFixo.DataSource = Nothing
            Exit Sub
        End If

        SqlText = "SELECT SQ_CONTRATO_FIXO," & _
                         "TO_CHAR(SQ_CONTRATO_FIXO) AS NO_CONTRATO_FIXO" & _
                  " FROM SOF.CONTRATO_FIXO" & _
                  " WHERE CD_CONTRATO_PAF = " & cboContratoPaf.Rows(cboContratoPaf.ActiveRow.Index).Cells(0).Value & _
                    " AND SQ_NEGOCIACAO = " & cboNegociacao.SelectedValue & _
                    " AND IC_STATUS = 'A'"
        DBCarregarComboBox(cboContratoFixo, SqlText, True)
    End Sub

    Private Sub cboContratoFixo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboContratoFixo.SelectedIndexChanged
        Dim SqlText As String
        Dim oData As DataTable

        If cboContratoPaf.SelectedRow Is Nothing Then
            cboNegociacao.DataSource = Nothing
            cboContratoFixo.DataSource = Nothing
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboNegociacao) Then
            cboContratoFixo.DataSource = Nothing
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboContratoFixo) Then
            Exit Sub
        End If

        SqlText = "SELECT (CF.QT_KGS - CF.QT_CANCELADO - CF.QT_KG_FIXO) QT_KGS," & _
                         "ROUND(CF.VL_PAG_FIXO - (((CF.VL_TOTAL + DECODE(CF.IC_INCLUI_ICMS_PAG , 'S', CF.VL_ICMS, 0) + " & _
                               "CF.VL_ADENDO + " & _
                               "DECODE(CF.IC_INCLUI_ICMS_PAG, 'S', CF.VL_ADENDO_ICMS, 0)) / CF.QT_KGS) * CF.QT_KG_FIXO), 2) VL_SALDO " & _
                  " FROM SOF.CONTRATO_FIXO CF " & _
                  " WHERE CF.CD_CONTRATO_PAF = " & cboContratoPaf.Rows(cboContratoPaf.ActiveRow.Index).Cells(0).Value & _
                    " AND CF.SQ_NEGOCIACAO = " & cboNegociacao.SelectedValue & _
                    " AND CF.SQ_CONTRATO_FIXO = " & cboContratoFixo.SelectedValue
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            txtQuantidadeContrato.Value = oData.Rows(0).Item("QT_KGS")
            If oData.Rows(0).Item("VL_SALDO") > 0 Then txtValorContrato.Value = oData.Rows(0).Item("VL_SALDO")
        End If
    End Sub

    Private Sub cmdAdiciona_Parcela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdiciona_Parcela.Click
        If txtValorParcela.Value <= 0 Then
            Msg_Mensagem("Valor invalido.")
            txtValorParcela.Focus()
            Exit Sub
        End If

        Select Case optForma.Value
            Case "C"
                If txtQuantidadeParcela.Value <= 0 Then
                    Msg_Mensagem("Quantidade invalida.")
                    txtQuantidadeParcela.Focus()
                    Exit Sub
                End If
            Case "O"
                If txtQuantidadeParcela.Value <= 0 Then
                    Msg_Mensagem("Quantidade invalida.")
                    txtQuantidadeParcela.Focus()
                    Exit Sub
                End If
                If Trim(Me.txtDescricaoOutros.Text) = "" Then
                    Msg_Mensagem("Favor informar uma descrição.")
                    txtDescricaoOutros.Focus()
                    Exit Sub
                End If
            Case "D"
            Case Else
                Msg_Mensagem("Favor selecionar uma forma.")
                Exit Sub
        End Select

        If Not txtDataVencimentoParcela Is Nothing Then
            If Not IsDate(txtDataVencimentoParcela.Text) Then
                Msg_Mensagem("Data de vencimento invalida.")
                txtDataVencimentoParcela.Focus()
                Exit Sub
            End If

            If Not SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_IncluirRecuperacaoCreditoDataRetroativa) Then
                If txtDataVencimentoParcela.DateTime.Date <= CDate(DataSistema()) Then
                    Msg_Mensagem("A data de vencimento não pode ser inferior a data atual.")
                    txtDataVencimentoParcela.Focus()
                    Exit Sub
                End If
            End If
        End If

        Dim oRow As Infragistics.Win.UltraWinDataSource.UltraDataRow

        oRow = oDSParcela.Rows.Add()
        oRow.Item(cnt_GridParcela_Forma) = optForma.Value
        oRow.Item(cnt_GridParcela_Quantidade) = txtQuantidadeParcela.Value
        oRow.Item(cnt_GridParcela_Valor) = txtValorParcela.Value
        If IsDate(txtDataVencimentoParcela.Text) Then
            oRow.Item(cnt_GridParcela_Vencimento) = txtDataVencimentoParcela.Text
        End If
        oRow.Item(cnt_GridParcela_Descricao) = txtDescricaoOutros.Text

        txtValorNegociado.Value = txtValorNegociado.Value + txtValorParcela.Value

        optForma.Value = Nothing

        txtQuantidadeParcela.Value = 0
        txtValorParcela.Value = 0
        txtDescricaoOutros.Text = ""
        txtDataVencimentoParcela.Value = Nothing

        optForma.Focus()
    End Sub

    Private Sub optForma_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optForma.ValueChanged
        Select Case optForma.Value
            Case "D"
                Me.txtDescricaoOutros.Text = ""
                Me.txtDescricaoOutros.Enabled = False
                Me.txtQuantidadeParcela.Value = 1
                Me.txtQuantidadeParcela.Enabled = False
            Case "C"
                Me.txtDescricaoOutros.Text = ""
                Me.txtDescricaoOutros.Enabled = False
                Me.txtQuantidadeParcela.Value = 0
                Me.txtQuantidadeParcela.Enabled = True
            Case "O"
                Me.txtDescricaoOutros.Enabled = True
                Me.txtQuantidadeParcela.Value = 0
                Me.txtQuantidadeParcela.Enabled = True
            Case Else
                Me.txtDescricaoOutros.Text = ""
                Me.txtDescricaoOutros.Enabled = False
                Me.txtQuantidadeParcela.Value = 0
                Me.txtQuantidadeParcela.Enabled = True
        End Select
    End Sub

    Private Sub cmdAdicionar_Contrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdicionar_Contrato.Click
        If cboContratoPaf.SelectedRow Is Nothing Then
            Msg_Mensagem("Favor selecionar um contrato PAF.")
            cboContratoPaf.Focus()
            Exit Sub
        End If
        If ComboBox_LinhaSelecionada(cboNegociacao) And Not ComboBox_LinhaSelecionada(cboContratoFixo) Then
            Msg_Mensagem("Favor selecionar um contrato fixo.")
            cboContratoFixo.Focus()
            Exit Sub
        End If
        If txtValorContrato.Value = 0 And txtQuantidadeContrato.Value = 0 Then
            Msg_Mensagem("Contrato não possue saldo.")
            cboContratoFixo.Focus()
            Exit Sub
        End If

        Dim iCont As Integer

        For iCont = 0 To grdContratos.Rows.Count - 1
            If ComboBox_LinhaSelecionada(cboContratoFixo) Then
                If grdContratos.Rows(iCont).Cells(cnt_GridContrato_contrato_PAF).Value = cboContratoPaf.Rows(cboContratoPaf.ActiveRow.Index).Cells(0).Value And _
                   grdContratos.Rows(iCont).Cells(cnt_GridContrato_Negociacao).Value = cboNegociacao.SelectedValue And _
                   grdContratos.Rows(iCont).Cells(cnt_GridContrato_Contrato_Fixo).Value = cboContratoFixo.SelectedValue Then
                    Msg_Mensagem("Esse contrato fixo ja foi lançado.")
                    cboContratoPaf.Focus()
                    Exit Sub
                End If
            Else
                If grdContratos.Rows(iCont).Cells(cnt_GridContrato_contrato_PAF).Value = cboContratoPaf.Rows(cboContratoPaf.ActiveRow.Index).Cells(0).Value And _
                   CampoNulo(grdContratos.Rows(iCont).Cells(cnt_GridContrato_Negociacao).Value) And _
                   CampoNulo(grdContratos.Rows(iCont).Cells(cnt_GridContrato_Contrato_Fixo).Value) Then
                    Msg_Mensagem("Esse contrato PAF ja foi lançado.")
                    cboContratoPaf.Focus()
                    Exit Sub
                End If
            End If
        Next

        Dim oRow As Infragistics.Win.UltraWinDataSource.UltraDataRow

        oRow = oDSContrato.Rows.Add()
        oRow.Item(cnt_GridContrato_contrato_PAF) = cboContratoPaf.Rows(cboContratoPaf.ActiveRow.Index).Cells(0).Value
        If ComboBox_LinhaSelecionada(cboContratoFixo) Then
            oRow.Item(cnt_GridContrato_Negociacao) = cboNegociacao.SelectedValue
            oRow.Item(cnt_GridContrato_Contrato_Fixo) = cboContratoFixo.SelectedValue
        End If
        oRow.Item(cnt_GridContrato_Valor) = txtValorContrato.Value
        oRow.Item(cnt_GridContrato_Quantidade) = txtQuantidadeContrato.Value

        cboContratoPaf.SelectedRow = Nothing
        ComboBox_Possicionar(cboNegociacao, -1)
        ComboBox_Possicionar(cboContratoFixo, -1)
        txtValorContrato.Value = 0
        txtQuantidadeContrato.Value = 0
        cboContratoPaf.Focus()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqConfissaoDivida As Integer
        Dim SqlText As String
        Dim VlOriginal As Double
        Dim QtOriginal As Double
        Dim iCont As Integer
        Dim Parametro(10) As DBParamentro

        If Pesq_FornecedorRecuperacao.Codigo <= 0 Then
            Msg_Mensagem("Favor informar um fornecedor.")
            Pesq_FornecedorRecuperacao.Focus()
            Exit Sub
        End If

        If Pesq_FornecedorContrato.Codigo <= 0 Then
            Msg_Mensagem("Favor informar um fornecedor para os contratos.")
            Pesq_FornecedorContrato.Focus()
            Exit Sub
        End If

        If Not ComboBox_LinhaSelecionada(cboModalidade) Then
            Msg_Mensagem("Favor selecionar uma modalidade.")
            cboModalidade.Focus()
            Exit Sub
        End If

        If grdContratos.Rows.Count = 0 Then
            Msg_Mensagem("Favor informar uma origem da recuperação de credito.")
            Exit Sub
        End If

        If grpParcelas.Enabled = True Then
            If grdParcelas.Rows.Count = 0 Then
                Msg_Mensagem("Favor informar a forma como sera pago.")
                Exit Sub
            End If
        End If

        If chkJuros.Checked = True Then
            If Not IsDate(txtDataInicioCobraJuros.Text) Then
                Msg_Mensagem("Data de inicio da cobrança de juros invalida.")
                txtDataInicioCobraJuros.Focus()
                Exit Sub
            End If
        End If

        For iCont = 0 To grdContratos.Rows.Count - 1
            VlOriginal = VlOriginal + grdContratos.Rows(iCont).Cells(cnt_GridContrato_Valor).Value
            QtOriginal = QtOriginal + grdContratos.Rows(iCont).Cells(cnt_GridContrato_Quantidade).Value
        Next

        txtValorNegociado.Value = objGrid_CalcularTotalColuna(grdParcelas, cnt_GridParcela_Valor)

        DBUsarTransacao = True

        SqlText = DBMontar_SP("SOF.SP_INCLUI_CONF_DIV", False, ":CDFORNECEDOR", _
                                                               ":VLORIGINAL", _
                                                               ":QTORIGINAL", _
                                                               ":VLNEGOCIADO", _
                                                               ":ICSTATUS", _
                                                               ":CDMODALIDADE", _
                                                               ":CDFORNCTR", _
                                                               ":ICCOBRAJUROS", _
                                                               ":DTCOBRAJUROS", _
                                                               ":PCJUROS", _
                                                               ":SQCONFISSAODIVIDA")

        Parametro(0) = DBParametro_Montar("CDFORNECEDOR", Pesq_FornecedorRecuperacao.Codigo)
        Parametro(1) = DBParametro_Montar("VLORIGINAL", VlOriginal)
        Parametro(2) = DBParametro_Montar("QTORIGINAL", QtOriginal)
        Parametro(3) = DBParametro_Montar("VLNEGOCIADO", txtValorNegociado.Value)
        Parametro(4) = DBParametro_Montar("ICSTATUS", "A")
        Parametro(5) = DBParametro_Montar("CDMODALIDADE", cboModalidade.SelectedValue)
        Parametro(6) = DBParametro_Montar("CDFORNCTR", Pesq_FornecedorContrato.Codigo)
        If chkJuros.Checked Then
            Parametro(7) = DBParametro_Montar("ICCOBRAJUROS", "S")
            Parametro(8) = DBParametro_Montar("DTCOBRAJUROS", Date_to_Oracle(txtDataInicioCobraJuros.Text), OracleClient.OracleType.DateTime)
            Parametro(9) = DBParametro_Montar("PCJUROS", txtJurosAoMes.Value)
        Else
            Parametro(7) = DBParametro_Montar("ICCOBRAJUROS", "N")
            Parametro(8) = DBParametro_Montar("DTCOBRAJUROS", Nothing, OracleClient.OracleType.DateTime)
            Parametro(9) = DBParametro_Montar("PCJUROS", 0)
        End If
        Parametro(10) = DBParametro_Montar("SQCONFISSAODIVIDA", Nothing, , ParameterDirection.Output)

        If Not DBExecutar(SqlText, Parametro) Then GoTo Erro

        If DBTeveRetorno() Then
            SqConfissaoDivida = DBRetorno(1)
        End If

        Inclui_Contrato(SqConfissaoDivida)
        If grpParcelas.Enabled Then Gera_Parcelas(SqConfissaoDivida)

        If Not DBExecutarTransacao() Then GoTo Erro

        Limpa_Tela()

        Pesq_FornecedorRecuperacao.Focus()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub cboModalidade_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboModalidade.SelectedIndexChanged
        Dim SqlText As String

        grpParcelas.Enabled = False

        SqlText = "SELECT IC_PROVISSORIA" & _
                  " FROM SOF.CONFISSAO_DIVIDA_MODALIDADE" & _
                  " WHERE CD_CONFISSAO_DIVIDA_MODALIDADE = " & cboModalidade.SelectedValue
        If DBQuery_ValorUnico(SqlText) = "S" Then
            grpParcelas.Enabled = False
            oDSParcela.Rows.Clear()
        Else
            grpParcelas.Enabled = True
        End If
    End Sub

    Private Sub Inclui_Contrato(ByVal SqConfDiv As Long)
        Dim SqlText As String
        Dim SqConcil As Long
        Dim CdModalConcil As Long
        Dim VlEstorno As Double
        Dim SqPagCtrPAF As Long
        Dim SqPagNeg As Long
        Dim SqPagNegCtrFix As Long
        Dim icJuros As String
        Dim iCont_01 As Integer
        Dim iCont_02 As Integer
        Dim VlSaldoFinal As Double
        Dim VlFinal As Double
        Dim oData As DataTable
        Dim bContratoFixo As Boolean

        SqlText = "SELECT CD_CONCILIACAO_MODALIDADE_PAG" & _
                  " FROM SOF.CONFISSAO_DIVIDA_PARAMETRO" & _
                  " WHERE CD_CONFISSAO_DIVIDA_MODALIDADE=" & cboModalidade.SelectedValue
        CdModalConcil = DBQuery_ValorUnico(SqlText, 0)

        If CdModalConcil = 0 Then
            Msg_Mensagem("Recuperação de Credito", "Os parametros da recuperação de credito ainda não foram setados")
            Exit Sub
        End If

        For iCont_01 = 0 To grdContratos.Rows.Count - 1
            VlSaldoFinal = grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_Valor).Value

            If CampoNulo(grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_Contrato_Fixo).Value) Then
                bContratoFixo = False
            Else
                bContratoFixo = True
            End If

            If bContratoFixo Then
                SqlText = "SELECT P.VL_FIXO," & _
                                 "P.SQ_PAGAMENTO," & _
                                 "P.SQ_PAG_CTR_PAF," & _
                                 "P.SQ_PAG_NEG," & _
                                 "P.SQ_PAG_NEG_CTR_FIX" & _
                          " FROM SOF.PAG_NEG_CTR_FIX P" & _
                          " WHERE P.CD_CONTRATO_PAF = " & grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_contrato_PAF).Value & _
                            " AND P.SQ_NEGOCIACAO = " & grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_Negociacao).Value & _
                            " AND P.SQ_CONTRATO_FIXO = " & grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_Contrato_Fixo).Value
            Else
                SqlText = "SELECT PCP.SQ_PAGAMENTO," & _
                                 "PCP.VL_A_FIXAR," & _
                                 "PCP.SQ_PAG_CTR_PAF " & _
                          " FROM SOF.PAG_CTR_PAF PCP " & _
                          " WHERE PCP.CD_CONTRATO_PAF = " & grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_contrato_PAF).Value & _
                            " AND PCP.VL_A_FIXAR <> 0"
            End If

            oData = DBQuery(SqlText)

            If Not objDataTable_Vazio(oData) Then
                SqlText = DBMontar_SP("SOF.SP_INCLUI_CONCILIACAO", False, ":CDCONCILMODAL", _
                                                                          ":CDFORN", _
                                                                          ":QTCONCIL", _
                                                                          ":VLCONCIL", _
                                                                          ":DSCONCIL", _
                                                                          ":SQCONCIL")

                If bContratoFixo Then
                    If Not DBExecutar(SqlText, DBParametro_Montar("CDCONCILMODAL", CdModalConcil), _
                                               DBParametro_Montar("CDFORN", Pesq_FornecedorRecuperacao.Codigo), _
                                               DBParametro_Montar("QTCONCIL", 0), _
                                               DBParametro_Montar("VLCONCIL", grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_Valor).Value), _
                                               DBParametro_Montar("DSCONCIL", "Recuperação de Credito - Contrato Fixo: " & _
                                                                              grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_contrato_PAF).Value & _
                                                                              " - " & grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_Negociacao).Value & _
                                                                              " - " & grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_Contrato_Fixo).Value, OracleClient.OracleType.VarChar, , 4000), _
                                               DBParametro_Montar("SQCONCIL", Nothing, , ParameterDirection.Output)) Then GoTo Erro
                Else
                    If Not DBExecutar(SqlText, DBParametro_Montar("CDCONCILMODAL", CdModalConcil), _
                                               DBParametro_Montar("CDFORN", Pesq_FornecedorRecuperacao.Codigo), _
                                               DBParametro_Montar("QTCONCIL", 0), _
                                               DBParametro_Montar("VLCONCIL", grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_Valor).Value), _
                                               DBParametro_Montar("DSCONCIL", "Recuperação de Credito - Contrato: " & _
                                                                              grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_contrato_PAF).Value, OracleClient.OracleType.VarChar, , 4000), _
                                               DBParametro_Montar("SQCONCIL", Nothing, , ParameterDirection.Output)) Then GoTo Erro
                End If

                If DBTeveRetorno() Then
                    SqConcil = DBRetorno(1)
                End If

                If bContratoFixo Then
                    SqlText = "UPDATE SOF.CONCILIACAO " & _
                              " SET SQ_CONFISSAO_DIVIDA = " & SqConfDiv & " " & _
                              " WHERE SQ_CONCILIACAO = " & SqConcil
                    If Not DBExecutar(SqlText) Then GoTo erro
                End If

                VlFinal = 0

                For iCont_02 = 0 To oData.Rows.Count - 1
                    SqlText = "UPDATE SOF.PAG_CTR_PAF " & _
                              " SET SQ_CONFISSAO_DIVIDA = " & SqConfDiv & ", " & _
                                   "IC_CONFISSAO_DIVIDA_ESTORNO = 'N'" & _
                              " WHERE CD_CONTRATO_PAF = " & grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_contrato_PAF).Value & _
                                " AND SQ_PAGAMENTO = " & oData.Rows(iCont_02).Item("SQ_PAGAMENTO") & _
                                " AND SQ_PAG_CTR_PAF = " & oData.Rows(iCont_02).Item("SQ_PAG_CTR_PAF")
                    If Not DBExecutar(SqlText) Then GoTo erro

                    If bContratoFixo Then
                        If oData.Rows(iCont_02).Item("VL_FIXO") > VlSaldoFinal Then
                            VlEstorno = VlSaldoFinal
                        Else
                            VlEstorno = oData.Rows(iCont_02).Item("VL_FIXO")
                        End If
                    End If

                    If bContratoFixo Then
                        If Not AplicacaoPagamentoContratoPAF(grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_contrato_PAF).Value, _
                                                             oData.Rows(iCont_02).Item("SQ_PAGAMENTO"), _
                                                             0 - VlEstorno, _
                                                             SqPagCtrPAF) Then GoTo Erro
                    Else
                        If Not AplicacaoPagamentoContratoPAF(grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_contrato_PAF).Value, _
                                                             oData.Rows(iCont_02).Item("SQ_PAGAMENTO"), _
                                                             oData.Rows(iCont_02).Item("VL_A_FIXAR"), _
                                                             SqPagCtrPAF) Then GoTo Erro
                    End If

                    SqlText = "UPDATE SOF.PAG_CTR_PAF " & _
                              " SET SQ_CONFISSAO_DIVIDA = " & SqConfDiv & ", " & _
                                   "IC_CONFISSAO_DIVIDA_ESTORNO = 'S'" & _
                              " WHERE CD_CONTRATO_PAF = " & grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_contrato_PAF).Value & _
                                " AND SQ_PAGAMENTO = " & oData.Rows(iCont_02).Item("SQ_PAGAMENTO") & _
                                " AND SQ_PAG_CTR_PAF = " & SqPagCtrPAF
                    If Not DBExecutar(SqlText) Then GoTo erro

                    If bContratoFixo Then
                        SqlText = "SELECT CP.IC_CALCULA_JUROS" & _
                                  " FROM SOF.CONTRATO_PAF CP" & _
                                  " WHERE CP.CD_CONTRATO_PAF = " & grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_contrato_PAF).Value
                        icJuros = DBQuery_ValorUnico(SqlText, "N")

                        SqlText = "UPDATE SOF.CONTRATO_PAF " & _
                                  " SET IC_CALCULA_JUROS = 'N'" & _
                                  " WHERE CD_CONTRATO_PAF = " & grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_contrato_PAF).Value
                        If Not DBExecutar(SqlText) Then GoTo Erro

                        If Not AplicacaoPagamentoNegociacao(grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_contrato_PAF).Value, _
                                                            grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_Negociacao).Value, _
                                                            oData.Rows(iCont_02).Item("sq_pagamento"), _
                                                            SqPagCtrPAF, _
                                                            0 - VlEstorno, _
                                                            SqPagNeg) Then GoTo Erro

                        SqlText = "UPDATE SOF.PAG_NEG " & _
                                  " SET SQ_CONFISSAO_DIVIDA = " & SqConfDiv & " " & _
                                  " WHERE CD_CONTRATO_PAF = " & grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_contrato_PAF).Value & _
                                    " AND SQ_PAGAMENTO = " & oData.Rows(iCont_02).Item("SQ_PAGAMENTO") & _
                                    " AND SQ_PAG_CTR_PAF = " & SqPagCtrPAF & _
                                    " AND SQ_NEGOCIACAO = " & grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_Negociacao).Value & _
                                    " AND SQ_PAG_NEG = " & SqPagNeg
                        If Not DBExecutar(SqlText) Then GoTo erro

                        SqlText = "UPDATE SOF.PAG_NEG " & _
                                  " SET SQ_CONFISSAO_DIVIDA = " & SqConfDiv & " " & _
                                  " WHERE CD_CONTRATO_PAF = " & grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_contrato_PAF).Value & _
                                    " AND SQ_PAGAMENTO = " & oData.Rows(iCont_02).Item("SQ_PAGAMENTO") & _
                                    " AND SQ_PAG_CTR_PAF = " & oData.Rows(iCont_02).Item("SQ_PAG_CTR_PAF") & _
                                    " AND SQ_NEGOCIACAO = " & grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_Negociacao).Value & _
                                    " AND SQ_PAG_NEG = " & oData.Rows(iCont_02).Item("SQ_PAG_NEG")
                        If Not DBExecutar(SqlText) Then GoTo erro

                        SqlText = "UPDATE SOF.CONTRATO_PAF " & _
                                  " SET IC_CALCULA_JUROS = " & QuotedStr(icJuros) & _
                                  " WHERE CD_CONTRATO_PAF = " & grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_contrato_PAF).Value
                        If Not DBExecutar(SqlText) Then GoTo erro

                        SqlText = "SELECT IC_CALCULA_JUROS " & _
                                  " FROM SOF.NEGOCIACAO " & _
                                  " WHERE CD_CONTRATO_PAF = " & grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_contrato_PAF).Value & _
                                    " AND SQ_NEGOCIACAO = " & grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_Negociacao).Value
                        icJuros = DBQuery_ValorUnico(SqlText)

                        SqlText = "UPDATE SOF.NEGOCIACAO" & _
                                  " SET IC_CALCULA_JUROS = 'N'" & _
                                  " WHERE CD_CONTRATO_PAF = " & grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_contrato_PAF).Value & _
                                    " AND SQ_NEGOCIACAO = " & grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_Negociacao).Value
                        If Not DBExecutar(SqlText) Then GoTo erro

                        If Not AplicacaoPagamentoContratoFixo(grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_contrato_PAF).Value, _
                                                              grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_Negociacao).Value, _
                                                              grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_Contrato_Fixo).Value, _
                                                              oData.Rows(iCont_02).Item("sq_pagamento"), _
                                                              SqPagCtrPAF, _
                                                              SqPagNeg, _
                                                              0 - VlEstorno, _
                                                              SqPagNegCtrFix) Then GoTo Erro

                        SqlText = "UPDATE SOF.PAG_NEG_CTR_FIX" & _
                                  " SET SQ_CONFISSAO_DIVIDA = " & SqConfDiv & " " & _
                                  " WHERE CD_CONTRATO_PAF = " & grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_contrato_PAF).Value & _
                                    " AND SQ_PAGAMENTO = " & oData.Rows(iCont_02).Item("SQ_PAGAMENTO") & _
                                    " AND SQ_PAG_CTR_PAF = " & SqPagCtrPAF & _
                                    " AND SQ_NEGOCIACAO = " & grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_Negociacao).Value & _
                                    " AND SQ_PAG_NEG = " & SqPagNeg & _
                                    " AND SQ_CONTRATO_FIXO = " & grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_Contrato_Fixo).Value & _
                                    " AND SQ_PAG_NEG_CTR_FIX = " & SqPagNegCtrFix
                        If Not DBExecutar(SqlText) Then GoTo erro

                        SqlText = "UPDATE SOF.PAG_NEG_CTR_FIX " & _
                                  " SET SQ_CONFISSAO_DIVIDA = " & SqConfDiv & " " & _
                                  " WHERE CD_CONTRATO_PAF = " & grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_contrato_PAF).Value & _
                                    " AND SQ_PAGAMENTO = " & oData.Rows(iCont_02).Item("SQ_PAGAMENTO") & _
                                    " AND SQ_PAG_CTR_PAF = " & oData.Rows(iCont_02).Item("SQ_PAG_CTR_PAF") & _
                                    " AND SQ_NEGOCIACAO = " & grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_Negociacao).Value & _
                                    " AND SQ_PAG_NEG = " & oData.Rows(iCont_02).Item("SQ_PAG_NEG") & _
                                    " AND SQ_CONTRATO_FIXO = " & grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_Contrato_Fixo).Value & _
                                    " AND SQ_PAG_NEG_CTR_FIX = " & oData.Rows(iCont_02).Item("SQ_PAG_NEG_CTR_FIX")
                        If Not DBExecutar(SqlText) Then GoTo erro

                        SqlText = "UPDATE SOF.NEGOCIACAO " & _
                                  " SET IC_CALCULA_JUROS = " & QuotedStr(icJuros) & _
                                  " WHERE CD_CONTRATO_PAF = " & grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_contrato_PAF).Value & _
                                    " AND SQ_NEGOCIACAO = " & grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_Negociacao).Value
                        If Not DBExecutar(SqlText) Then GoTo erro
                    End If

                    If bContratoFixo Then
                        SqlText = DBMontar_SP("SOF.SP_INCLUI_CONCILIACAO_PAG", False, ":SQCONCIL", _
                                                                                      ":SQPAG", _
                                                                                      ":VLAPLICACAO")

                        If Not DBExecutar(SqlText, DBParametro_Montar("SQCONCIL", SqConcil), _
                                                   DBParametro_Montar("SQPAG", oData.Rows(iCont_02).Item("SQ_PAGAMENTO")), _
                                                   DBParametro_Montar("VLAPLICACAO", VlEstorno)) Then GoTo Erro
                    Else
                        SqlText = DBMontar_SP("SOF.SP_INCLUI_CONCILIACAO_PAG", False, ":SQCONCIL", _
                                                                                      ":SQPAG", _
                                                                                      ":VLAPLICACAO")

                        If Not DBExecutar(SqlText, DBParametro_Montar("SQCONCIL", SqConcil), _
                                                   DBParametro_Montar("SQPAG", oData.Rows(iCont_02).Item("SQ_PAGAMENTO")), _
                                                   DBParametro_Montar("VLAPLICACAO", oData.Rows(iCont_02).Item("VL_A_FIXAR"))) Then GoTo ERRO
                    End If

                    VlSaldoFinal = VlSaldoFinal - VlEstorno
                    If bContratoFixo Then
                        VlFinal = VlFinal + oData.Rows(iCont_02).Item("VL_FIXO")
                    Else
                        VlFinal = VlFinal + oData.Rows(iCont_02).Item("VL_A_FIXAR")
                    End If

                    If VlSaldoFinal <= 0 Then Exit For
                Next
            End If

            If Not bContratoFixo Then
                SqlText = "UPDATE SOF.CONCILIACAO " & _
                          " SET SQ_CONFISSAO_DIVIDA = " & SqConfDiv & ", " & _
                               "VL_CONCILIACAO = " & VlFinal & _
                          " WHERE SQ_CONCILIACAO = " & SqConcil
                If Not DBExecutar(SqlText) Then GoTo erro
            End If

            If grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_Quantidade).Value > 0 Then
                If bContratoFixo Then
                    Cancela_Contrato_Fixo(grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_contrato_PAF).Value, _
                                          grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_Negociacao).Value, _
                                          grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_Contrato_Fixo).Value, _
                                          grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_Quantidade).Value, _
                                          "Recuperação de Credito", _
                                          SqConfDiv)

                    Cancela_Negociacao(grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_contrato_PAF).Value, _
                                       grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_Negociacao).Value, _
                                       grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_Quantidade).Value, _
                                       "Recuperação de Credito", _
                                       "C", _
                                       SqConfDiv)
                End If

                Cancela_Contrato_PAF(grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_contrato_PAF).Value, _
                                     grdContratos.Rows(iCont_01).Cells(cnt_GridContrato_Quantidade).Value, _
                                     "Recuperação de Credito", _
                                     SqConfDiv)
            End If
        Next

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub Gera_Parcelas(ByVal SqConfDiv As Long)
        Dim SqlText As String
        Dim icont As Integer

        For icont = 0 To grdParcelas.Rows.Count - 1
            SqlText = DBMontar_SP("SOF.SP_INCLUI_CONF_DIV_PARCELA", False, ":SQCONFISSAODIVIDA", _
                                                               ":ICSITUACAO", _
                                                               ":ICCACAU", _
                                                               ":ICMOEDA", _
                                                               ":ICOUTROS", _
                                                               ":DSOUTROS", _
                                                               ":DTVENCIMENTO", _
                                                               ":VLPARCELA", _
                                                               ":QTITEMPARCELA", _
                                                               ":NUPARCELAANTERIOR", _
                                                               ":NUPARCELA")

            If Not DBExecutar(SqlText, DBParametro_Montar("SQCONFISSAODIVIDA", SqConfDiv), _
                                       DBParametro_Montar("ICSITUACAO", "A"), _
                                       DBParametro_Montar("ICCACAU", IIf(grdParcelas.Rows(icont).Cells(cnt_GridParcela_Forma).Value = "C", "S", "N")), _
                                       DBParametro_Montar("ICMOEDA", IIf(grdParcelas.Rows(icont).Cells(cnt_GridParcela_Forma).Value = "D", "S", "N")), _
                                       DBParametro_Montar("ICOUTROS", IIf(grdParcelas.Rows(icont).Cells(cnt_GridParcela_Forma).Value = "O", "S", "N")), _
                                       DBParametro_Montar("DSOUTROS", IIf(grdParcelas.Rows(icont).Cells(cnt_GridParcela_Forma).Value = "O", grdParcelas.Rows(icont).Cells(cnt_GridParcela_Descricao).Value, Nothing)), _
                                       DBParametro_Montar("DTVENCIMENTO", Date_to_Oracle(grdParcelas.Rows(icont).Cells(cnt_GridParcela_Vencimento).Value), OracleClient.OracleType.DateTime), _
                                       DBParametro_Montar("VLPARCELA", grdParcelas.Rows(icont).Cells(cnt_GridParcela_Valor).Value), _
                                       DBParametro_Montar("QTITEMPARCELA", grdParcelas.Rows(icont).Cells(cnt_GridParcela_Quantidade).Value), _
                                       DBParametro_Montar("NUPARCELAANTERIOR", Nothing), _
                                       DBParametro_Montar("NUPARCELA", Nothing, , ParameterDirection.Output)) Then GoTo Erro

        Next

        Exit Sub
Erro:
        TratarErro()
    End Sub

    Private Sub grdContratos_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdContratos.BeforeRowsDeleted
        e.DisplayPromptMsg = False

        If Not Msg_Perguntar("Deseja excluir a contrato?") Then
            e.Cancel = True
        End If
    End Sub

    Private Sub grdParcelas_AfterRowsDeleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdParcelas.AfterRowsDeleted
        txtValorNegociado.Value = objGrid_CalcularTotalColuna(grdParcelas, cnt_GridParcela_Valor)
    End Sub

    Private Sub grdParcelas_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdParcelas.BeforeRowsDeleted
        e.DisplayPromptMsg = False

        If Not Msg_Perguntar("Deseja excluir a parcela?") Then
            e.Cancel = True
        End If
    End Sub

    Private Sub Limpa_Tela()
        txtQuantidadeParcela.Value = 0
        txtValorParcela.Value = 0
        txtDescricaoOutros.Text = ""
        txtDataVencimentoParcela.Value = Nothing
        oDSParcela.Rows.Clear()
        oDSContrato.Rows.Clear()
        txtValorNegociado.Value = 0
        Pesq_FornecedorRecuperacao.Codigo = 0
        Pesq_FornecedorRecuperacao_AlterouRegistro()
        optForma.Value = Nothing
        chkJuros.Checked = False
        ComboBox_Possicionar(cboModalidade, -1)
        chkJuros_CheckedChanged(Nothing, Nothing)
        optForma_ValueChanged(Nothing, Nothing)
        txtJurosAoMes.Value = DBQuery_ValorUnico("SELECT P.PC_JUROS_AO_MES FROM SOF.PARAMETRO P")
    End Sub
End Class