Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmCadastroPagamento
    Const cnt_GridCTR_ContratoPAF As Integer = 0
    Const cnt_GridCTR_Negociacao As Integer = 1
    Const cnt_GridCTR_ContratoFixo As Integer = 2
    Const cnt_GridCTR_ValorAplicado As Integer = 3

    Const cnt_GridICMS_ContratoPAF As Integer = 0
    Const cnt_GridICMS_NF As Integer = 1
    Const cnt_GridICMS_Descricao As Integer = 2
    Const cnt_GridICMS_ValorAplicado As Integer = 3

    Dim CdTipoPagICMS As Integer
    Dim CdOperacaoBancaria As Integer
    Dim CdTipoPessoa As Integer
    Dim VlTotalAplicado As Double
    Dim oDS As New UltraWinDataSource.UltraDataSource
    Dim oTipoGrid As eTipoGrid

    Enum eTipoGrid
        Contrato = 1
        ICMS = 2
    End Enum

    Private Sub frmCadastroPagamento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlText As String

        ComboBox_Carregar_Tipo_Pagamento(cboTipoPagamento, True)
        ComboBox_Carregar_Forma_Pagamento(cboFormaPagamento, True)
        ComboBox_Carregar_Filial(cboFilialPagadora, True)

        'Pego o codigo do tipo de pagamento de icms, será a unica forma de pagamento de icms
        SqlText = "SELECT P.CD_TIPO_PAG_ICMS FROM SOF.PARAMETRO P "

        CdTipoPagICMS = DBQuery_ValorUnico(SqlText)
        chkFavorecidoAlternativo_CheckedChanged(Nothing, Nothing)
        chkValorPagamento_CheckedChanged(Nothing, Nothing)

        objUltraComboBox_Inicializar(cboContratoPaf, 340)
        objUltraComboBox_Inicializar(cboContratoPafICMS, 340)
        objUltraComboBox_Inicializar(cboNegociacao, 380)
        objUltraComboBox_Inicializar(cboContaCorrente)
        Pesq_Fornecedor.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        Pesq_Fornecedor.BancoDados_Filtro_Adicionar("F.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")")
        FavorecidoAlternativo.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        MontaGrid(eTipoGrid.Contrato)
    End Sub

    Private Sub cboTipoPagamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoPagamento.SelectedIndexChanged
        Dim SqlText As String
        Dim oData As DataTable

        ComboBox_Possicionar(cboFormaPagamento, -1)
        cboFormaPagamento.Enabled = True
        grpContrato.Visible = True
        grpICMS.Visible = False

        txtValor.Value = 0
        Calcula_Saldo_Pagamento()

        SqlText = "SELECT T.CD_FORMA_PAGAMENTO," & _
                         "T.IC_PAGAMENTO_ICMS," & _
                         "T.CD_OPERACAO_BANCARIA" & _
                  " FROM SOF.TIPO_PAGAMENTO T" & _
                  " WHERE T.CD_TIPO_PAGAMENTO = " & cboTipoPagamento.SelectedValue
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            If Not objDataTable_CampoVazio(oData.Rows(0).Item("cd_forma_pagamento")) Then
                ComboBox_Possicionar(cboFormaPagamento, oData.Rows(0).Item("cd_forma_pagamento"))
                cboFormaPagamento.Enabled = False
            End If

            CdOperacaoBancaria = oData.Rows(0).Item("CD_OPERACAO_BANCARIA")

            If oData.Rows(0).Item("ic_pagamento_icms") = "S" Then
                grpContrato.Visible = False
                grpICMS.Visible = True
                grpICMS.Top = grpContrato.Top
                txtDescricao.Text = ""
                txtDescricao.Enabled = False
                oTipoGrid = eTipoGrid.ICMS
            Else
                txtDescricao.Enabled = True
                oTipoGrid = eTipoGrid.Contrato
            End If
            MontaGrid(oTipoGrid)
        End If
    End Sub

    Sub MontaGrid(ByVal Tipo As eTipoGrid)
        oDS.Rows.Clear()
        Select Case Tipo
            Case eTipoGrid.Contrato
                objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)

                objGrid_Coluna_Add(grdGeral, "Contrato PAF", 120)
                objGrid_Coluna_Add(grdGeral, "Negociação", 120)
                objGrid_Coluna_Add(grdGeral, "Contrato Fixo", 120)
                objGrid_Coluna_Add(grdGeral, "Valor Aplicado", 120, , , , , cnt_Formato_Valor)

            Case eTipoGrid.ICMS
                objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)

                objGrid_Coluna_Add(grdGeral, "Contrato PAF", 120)
                objGrid_Coluna_Add(grdGeral, "NF", 80)
                objGrid_Coluna_Add(grdGeral, "Descrição", 200, , , , , , , , 40)
                objGrid_Coluna_Add(grdGeral, "Valor Aplicado", 120, , , , , cnt_Formato_Valor)
        End Select
        grdGeral.DisplayLayout.Bands(0).Override.AllowDelete = DefaultableBoolean.True
    End Sub

    Private Sub Carrega_Favorecido(ByVal CdFornecedor As Long)
        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "SELECT * " & _
                  "FROM SOF.FORNECEDOR " & _
                  "WHERE CD_FORNECEDOR = " & CdFornecedor
        oData = DBQuery(SqlText)

        If objDataTable_Vazio(oData) Then Exit Sub

        If CampoNulo(oData.Rows(0).Item("CD_ADDRESS_NUMBER")) Then
            Msg_Mensagem("Address Number não esta cadastrado.")

            Exit Sub
        End If

        ComboBox_Carregar_ContaCorrente(oData.Rows(0).Item("CD_ADDRESS_NUMBER"))
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim iCont As Integer

        If Not ComboBox_LinhaSelecionada(cboTipoPagamento) Then
            Msg_Mensagem("Favor informa um tipo de pagamento.")
            cboTipoPagamento.Focus()
            Exit Sub
        End If
        If txtValor.Value <= 0 Then
            Msg_Mensagem("Favor informar o valor do pagamento maior do que 0.")
            txtValor.Focus()
            Exit Sub
        End If
        If Pesq_Fornecedor.Codigo <= 0 Then
            Msg_Mensagem("Favor informar um fornecedor valido.")
            Pesq_Fornecedor.Focus()
            Exit Sub
        End If
        If txtDescricao.Enabled = True And txtDescricao.Text = "" Then
            Msg_Mensagem("Favor informar uma descrição para o pagamento.")
            txtDescricao.Focus()
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboFormaPagamento) Then
            Msg_Mensagem("Favor escolher uma forma de pagamento.")
            cboFormaPagamento.Focus()
            Exit Sub
        End If
        If chkFavorecidoAlternativo.Checked = False Then
            If Not ComboBox_LinhaSelecionada(cboFavorecido) Then
                Msg_Mensagem("Favor informar um favorecido.")
                Me.cboFavorecido.Focus()
                Exit Sub
            End If
        Else
            If FavorecidoAlternativo.Codigo <= 0 Then
                Msg_Mensagem("Favor informar um fornecedor favorecido.")
                FavorecidoAlternativo.Focus()
                Exit Sub
            End If
            If Msg_Perguntar("Voce informou um favorecido que não possue procuração cadastrada no sistema com o fornecedor." & _
                      vbCrLf & "Voce podera ser auditado escolhendo essa opção." & vbCrLf & _
                      "Continua a inclusão ?") = False Then
                Exit Sub
            End If
        End If
        If Not ComboBox_LinhaSelecionada(cboFilialPagadora) Then
            Msg_Mensagem("Favor escolher a filial que efetuara o pagamento.")
            cboFilialPagadora.Focus()
            Exit Sub
        End If
        If cboContaCorrente.Enabled = True And cboContaCorrente.SelectedRow Is Nothing Then
            Msg_Mensagem("Favor selecionar uma conta corrente.")
            cboContaCorrente.Focus()
            Exit Sub
        End If

        Calcula_Saldo_Pagamento()

        If oTipoGrid = eTipoGrid.Contrato Then
            If txtSaldoPagamento.Value <> 0 Then
                Msg_Mensagem("O pagamento tem de ser todo aplicado num contrato.")
                Exit Sub
            End If
        Else
            If txtSaldoPagamentoICMS.Value <> 0 Then
                Msg_Mensagem("O pagamento tem de ser todo aplicado num contrato.")
                Exit Sub
            End If
        End If
        If FilialFechada(cboFilialPagadora.SelectedValue) Then
            Msg_Mensagem("A Filial está fechada. No momento não é possivel realizar o pagamento.")
            Exit Sub
        End If
        If CdTipoPessoa <> 6 Then  'Se o tipo de pessoa for importado tambem nao verifica saldo
            If DBQuery_ValorUnico("SELECT F.IC_VALIDA_CREDITO" & _
                                  " FROM SOF.FORMA_PAGAMENTO F " & _
                                  " WHERE F.CD_FORMA_PAGAMENTO =" & cboFormaPagamento.SelectedValue) = "S" Then
                If Not Valida_Limite() Then Exit Sub
            End If
        End If

        If oTipoGrid = eTipoGrid.Contrato Then
            Inclui_Pagamento(txtDescricao.Text, txtValor.Value)
        Else
            For iCont = 0 To grdGeral.Rows.Count - 1
                Inclui_Pagamento(grdGeral.Rows(iCont).Cells(cnt_GridICMS_Descricao).Value, _
                                 grdGeral.Rows(iCont).Cells(cnt_GridICMS_ValorAplicado).Value, _
                                 grdGeral.Rows(iCont).Cells(cnt_GridICMS_NF).Value, _
                                 grdGeral.Rows(iCont).Cells(cnt_GridICMS_ContratoPAF).Value)
            Next
        End If

        Limpa_Tela()
        cboTipoPagamento.Focus()
    End Sub

    Private Sub Limpa_Tela()
        VlTotalAplicado = 0
        Pesq_Fornecedor.Codigo = 0
        ComboBox_Possicionar(cboTipoPagamento, -1)
        ComboBox_Possicionar(cboFilialPagadora, -1)
        ComboBox_Possicionar(cboFormaPagamento, -1)
        txtValor.Value = 0
        txtValorAplicado.Value = 0
        txtValorICMS.Value = 0
        txtSaldoPagamento.Value = 0
        txtSaldoPagamentoICMS.Value = 0
        chkFavorecidoAlternativo.Checked = False
        chkValorPagamento.Checked = False
        txtDescricao.Text = ""
        oDS.Rows.Clear()
        Pesq_Fornecedor_AlterouFornecedor()
    End Sub

    Private Sub cboFormaPagamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFormaPagamento.SelectedIndexChanged
        If cboFormaPagamento.SelectedValue = cnt_FormaPagamentoJDE Then
            cboContaCorrente.Enabled = True
        Else
            cboContaCorrente.Enabled = False
        End If
    End Sub

    Private Sub Inclui_Pagamento(ByVal Descricao As String, _
                                 ByVal Valor As Double, _
                                 Optional ByVal NumeroNF As String = Nothing, _
                                 Optional ByVal ContratoPAF As String = Nothing)
        Dim SqlText As String
        Dim sConta As String
        Dim SqPagamento As Long
        Dim Parametro(17) As DBParamentro
        Dim CdFilialOrigem As Integer

        CdFilialOrigem = DBQuery_ValorUnico("select cd_filial_origem from  sof.fornecedor where cd_fornecedor=" & Pesq_Fornecedor.Codigo)

        DBUsarTransacao = True

        SqlText = DBMontar_SP("SOF.INCLUI_PAGAMENTO", False, ":FORMAPAG", _
                                                                   ":FORN", _
                                                                   ":TIPOPAG", _
                                                                   ":DTPAG", _
                                                                   ":VLPAG", _
                                                                   ":VLTAXA", _
                                                                   ":TAXASIST", _
                                                                   ":VLDOLAR", _
                                                                   ":DESCRICAO", _
                                                                   ":FILORIGEM", _
                                                                   ":FILPAG", _
                                                                   ":FAVORECIDO", _
                                                                   ":OPERACAO", _
                                                                   ":RET", _
                                                                   ":FORNFAV", _
                                                                   ":CDCONTA", _
                                                                   ":ICFAVORECIDOALTERNATIVO", _
                                                                   ":NUNF")

        Parametro(0) = DBParametro_Montar("FORMAPAG", cboFormaPagamento.SelectedValue)
        Parametro(1) = DBParametro_Montar("FORN", Pesq_Fornecedor.Codigo)
        Parametro(2) = DBParametro_Montar("TIPOPAG", cboTipoPagamento.SelectedValue)
        Parametro(3) = DBParametro_Montar("DTPAG", Date_to_Oracle(DataSistema), OracleClient.OracleType.DateTime)
        Parametro(4) = DBParametro_Montar("VLPAG", Valor)
        Parametro(5) = DBParametro_Montar("VLTAXA", Nothing)
        Parametro(6) = DBParametro_Montar("TAXASIST", "S")
        Parametro(7) = DBParametro_Montar("VLDOLAR", Nothing)
        Parametro(8) = DBParametro_Montar("DESCRICAO", Descricao, OracleClient.OracleType.VarChar, , 40)
        Parametro(9) = DBParametro_Montar("FILORIGEM", CdFilialOrigem)
        Parametro(10) = DBParametro_Montar("FILPAG", cboFilialPagadora.SelectedValue)
        If Me.chkFavorecidoAlternativo.Checked = True Then
            Parametro(11) = DBParametro_Montar("FAVORECIDO", FavorecidoAlternativo.Descricao)
        Else
            Parametro(11) = DBParametro_Montar("FAVORECIDO", cboFavorecido.SelectedItem(1))
        End If
        Parametro(12) = DBParametro_Montar("OPERACAO", CdOperacaoBancaria)
        Parametro(13) = DBParametro_Montar("RET", Nothing, , ParameterDirection.Output)
        If Me.chkFavorecidoAlternativo.Checked = True Then
            Parametro(14) = DBParametro_Montar("FORNFAV", FavorecidoAlternativo.Codigo)
        Else
            Parametro(14) = DBParametro_Montar("FORNFAV", cboFavorecido.SelectedValue)
        End If
        If cboContaCorrente.Enabled = True Then
            With cboContaCorrente.SelectedRow
                sConta = .Cells(0).Value + "-" + .Cells(1).Value + "-" + .Cells(2).Value
            End With
            Parametro(15) = DBParametro_Montar("CDCONTA", sConta)

        Else
            Parametro(15) = DBParametro_Montar("CDCONTA", Nothing)
        End If

        If Me.chkFavorecidoAlternativo.Checked = True Then
            Parametro(16) = DBParametro_Montar("ICFAVORECIDOALTERNATIVO", "S")
        Else
            Parametro(16) = DBParametro_Montar("ICFAVORECIDOALTERNATIVO", "N")
        End If
        Parametro(17) = DBParametro_Montar("NUNF", NumeroNF)

        If Not DBExecutar(SqlText, Parametro) Then GoTo Erro

        If DBTeveRetorno() Then
            SqPagamento = DBRetorno(1)
        End If

        Dim iCont As Integer
        Dim SqPagamentoCtrPAF As Integer
        Dim SqPagamentoNegociacao As Integer
        Dim iAux As Integer

        If oTipoGrid = eTipoGrid.Contrato Then
            For iCont = 0 To grdGeral.Rows.Count - 1
                If Not AplicacaoPagamentoContratoPAF(grdGeral.Rows(iCont).Cells(cnt_GridCTR_ContratoPAF).Value, _
                                                     SqPagamento, _
                                                     grdGeral.Rows(iCont).Cells(cnt_GridCTR_ValorAplicado).Value, _
                                                     SqPagamentoCtrPAF) Then GoTo Erro

                If Not CampoNulo(grdGeral.Rows(iCont).Cells(cnt_GridCTR_Negociacao).Value) Then
                    If Not AplicacaoPagamentoNegociacao(grdGeral.Rows(iCont).Cells(cnt_GridCTR_ContratoPAF).Value, _
                                                        grdGeral.Rows(iCont).Cells(cnt_GridCTR_Negociacao).Value, _
                                                        SqPagamento, _
                                                        SqPagamentoCtrPAF, _
                                                        grdGeral.Rows(iCont).Cells(cnt_GridCTR_ValorAplicado).Value, _
                                                        SqPagamentoNegociacao) Then GoTo Erro
                End If

                If Not CampoNulo(grdGeral.Rows(iCont).Cells(cnt_GridCTR_ContratoFixo).Value) Then
                    If Not AplicacaoPagamentoContratoFixo(grdGeral.Rows(iCont).Cells(cnt_GridCTR_ContratoPAF).Value, _
                                                          grdGeral.Rows(iCont).Cells(cnt_GridCTR_Negociacao).Value, _
                                                          grdGeral.Rows(iCont).Cells(cnt_GridCTR_ContratoFixo).Value, _
                                                          SqPagamento, _
                                                          SqPagamentoCtrPAF, _
                                                          SqPagamentoNegociacao, _
                                                          grdGeral.Rows(iCont).Cells(cnt_GridCTR_ValorAplicado).Value, _
                                                          iAux) Then GoTo Erro
                End If
            Next
        Else
            If Not AplicacaoPagamentoContratoPAF(ContratoPAF, SqPagamento, Valor, SqPagamentoCtrPAF) Then GoTo Erro
        End If

        If Not DBExecutarTransacao() Then GoTo Erro

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub chkFavorecidoAlternativo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFavorecidoAlternativo.CheckedChanged
        If chkFavorecidoAlternativo.Checked = True Then
            FavorecidoAlternativo.Enabled = True
            ComboBox_Possicionar(cboFavorecido, -1)
            cboFavorecido.Enabled = False
        Else
            FavorecidoAlternativo.Codigo = 0
            FavorecidoAlternativo.Enabled = False
            cboFavorecido.Enabled = True
        End If
    End Sub

    Private Sub Pesq_Fornecedor_AlterouFornecedor() Handles Pesq_Fornecedor.AlterouRegistro
        Dim SqlText As String
        Dim oData As DataTable

        If Pesq_Fornecedor.Codigo > 0 Then
            SqlText = "SELECT IC_LISTA_NEGRA," & _
                             "CD_FILIAL_ORIGEM," & _
                             "CD_TIPO_PESSOA " & _
                      " FROM SOF.FORNECEDOR" & _
                      " WHERE CD_FORNECEDOR = " & Pesq_Fornecedor.Codigo
            oData = DBQuery(SqlText)

            If oData.Rows(0).Item("IC_LISTA_NEGRA") = "S" Then
                Msg_Mensagem("Este fornecedor está na Lista Negra")
                Exit Sub
            End If

            CdTipoPessoa = oData.Rows(0).Item("CD_TIPO_PESSOA")
            ComboBox_Possicionar(cboFilialPagadora, oData.Rows(0).Item("CD_FILIAL_ORIGEM"))

            objData_Finalizar(oData)

            ComboBox_Carregar_Favorecido(cboFavorecido, Pesq_Fornecedor.Codigo)

            SqlText = "SELECT CP.CD_CONTRATO_PAF," & _
                             "CP.QT_KGS," & _
                             "CP.VL_PAG_FIXO" & _
                      " FROM SOF.CONTRATO_PAF CP," & _
                            "SOF.TIPO_CONTRATO_PAF TCP" & _
                      " WHERE CP.CD_TIPO_CONTRATO_PAF = TCP.CD_TIPO_CONTRATO_PAF" & _
                        " AND CP.CD_FORNECEDOR = " & Pesq_Fornecedor.Codigo & _
                        " AND CP.IC_STATUS = 'A'" & _
                        " AND TCP.IC_ADIANTAMENTO = 'S'" & _
                      " ORDER BY CP.CD_CONTRATO_PAF"
            objUltraComboBox_Carregar(cboContratoPaf, SqlText, _
                                      New Combo_Informacao() {objUltraComboBox_Informacao("Contrato PAF", True, 120, True, True), _
                                                              objUltraComboBox_Informacao("Quantidade", True, 100, False, False, cnt_Formato_Kilos), _
                                                              objUltraComboBox_Informacao("Valor Aplicado", True, 100, False, False, cnt_Formato_Valor)})

            SqlText = "SELECT CP.CD_CONTRATO_PAF," & _
                             "CP.QT_KGS," & _
                             "CP.VL_PAG_FIXO" & _
                      " FROM SOF.CONTRATO_PAF CP," & _
                            "SOF.TIPO_CONTRATO_PAF TCP" & _
                      " WHERE CP.CD_TIPO_CONTRATO_PAF = TCP.CD_TIPO_CONTRATO_PAF" & _
                        " AND CP.CD_FORNECEDOR = " & Pesq_Fornecedor.Codigo & _
                        " AND CP.IC_STATUS = 'A'" & _
                        " AND TCP.IC_ADIANTAMENTO = 'N'" & _
                      " ORDER BY CP.CD_CONTRATO_PAF"
            objUltraComboBox_Carregar(cboContratoPafICMS, SqlText, _
                                      New Combo_Informacao() {objUltraComboBox_Informacao("Contrato PAF", True, 120, True, True), _
                                                              objUltraComboBox_Informacao("Quantidade", True, 100, False, False, cnt_Formato_Kilos), _
                                                              objUltraComboBox_Informacao("Valor Aplicado", True, 100, False, False, cnt_Formato_Valor)})

            oDS.Rows.Clear()
        Else
            CdTipoPessoa = 0
            ComboBox_Possicionar(cboFilialPagadora, -1)
            cboFavorecido.DataSource = Nothing
            cboContratoPaf.DataSource = Nothing
            cboContratoPafICMS.DataSource = Nothing
        End If
    End Sub

    Public Sub ComboBox_Carregar_ContaCorrente(ByVal CdAddressNumber As Integer)
        Dim SqlText As String

        If Not Debug_Testar() Then
            SqlText = "SELECT AYDL01, AYCBNK, AYTNST, AYBKTP " & _
                      " FROM SOF.VW_ONEWORLD_F0030 " & _
                      " WHERE AYAN8 = " & CdAddressNumber

            objUltraComboBox_Carregar(cboContaCorrente, SqlText, _
                                      New Combo_Informacao() {objUltraComboBox_Informacao("Banco", True, 120, True, True), _
                                                              objUltraComboBox_Informacao("Conta", True, 60, False, False), _
                                                              objUltraComboBox_Informacao("Agência", True, 60, False, False), _
                                                              objUltraComboBox_Informacao("Default?", False, 0, False, False)})

            Dim iCont As Integer

            For iCont = 0 To cboContaCorrente.Rows.Count - 1
                If cboContaCorrente.Rows(iCont).Cells(3).Value = "V" Then
                    cboContaCorrente.SelectedRow = cboContaCorrente.Rows(iCont)
                End If
            Next
        End If
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cboFavorecido_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFavorecido.SelectedIndexChanged
        Carrega_Favorecido(cboFavorecido.SelectedValue)
    End Sub

    Private Sub FavorecidoAlternativo_AlterouFornecedor() Handles FavorecidoAlternativo.AlterouRegistro
        Carrega_Favorecido(FavorecidoAlternativo.Codigo)
    End Sub


    Private Sub cboContratoFixo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboContratoFixo.SelectedIndexChanged
        txtSaldoContrato.Value = 0
        If cboContratoPaf.SelectedRow Is Nothing Then
            cboNegociacao.DataSource = Nothing
            cboContratoFixo.DataSource = Nothing
            Exit Sub
        End If
        If cboNegociacao.SelectedRow Is Nothing Then
            cboContratoFixo.DataSource = Nothing
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboContratoFixo) Then
            Exit Sub
        End If

        Dim SqlText As String

        SqlText = "SELECT ( sof.FC_SALDO_CTR_FIX(cf.cd_contrato_paf,cf.sq_negociacao ,cf.sq_contrato_fixo ) - cf.vl_pag_fixo) VL_SALDO " & _
                   "FROM SOF.contrato_fixo CF " & _
                   "WHERE CF.cd_contrato_paf = " & cboContratoPaf.Rows(cboContratoPaf.ActiveRow.Index).Cells(0).Value & " AND " & _
                   "CF.sq_negociacao = " & cboNegociacao.Rows(cboNegociacao.ActiveRow.Index).Cells(0).Value & " AND " & _
                   "CF.sq_contrato_fixo = " & cboContratoFixo.SelectedValue

        txtSaldoContrato.Value = DBQuery_ValorUnico(SqlText, 0)
    End Sub

    Private Sub cboContratoPaf_RowSelected(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowSelectedEventArgs) Handles cboContratoPaf.RowSelected
        Dim SqlText As String
        If cboContratoPaf.SelectedRow Is Nothing Then
            cboNegociacao.DataSource = Nothing
            cboContratoFixo.DataSource = Nothing
            Exit Sub
        End If

        SqlText = "SELECT N.SQ_NEGOCIACAO, N.QT_KGS, N.VL_NEGOCIACAO, N.DT_NEGOCIACAO " & _
                  "FROM SOF.NEGOCIACAO N, SOF.TIPO_NEGOCIACAO TN " & _
                  "WHERE TN.CD_TIPO_NEGOCIACAO = N.CD_TIPO_NEGOCIACAO AND " & _
                  "N.CD_CONTRATO_PAF = " & cboContratoPaf.Rows(cboContratoPaf.ActiveRow.Index).Cells(0).Value & " AND " & _
                  "N.IC_STATUS = 'A'"

        objUltraComboBox_Carregar(cboNegociacao, SqlText, _
                                  New Combo_Informacao() {objUltraComboBox_Informacao("Negociação", True, 100, True, True), _
                                                          objUltraComboBox_Informacao("Quantidade", True, 100, False, False, cnt_Formato_Kilos), _
                                                          objUltraComboBox_Informacao("Valor Negociado", True, 120, False, False, cnt_Formato_Valor), _
                                                          objUltraComboBox_Informacao("Data", True, 0, False, False)})


    End Sub

    Private Sub cboNegociacao_RowSelected(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowSelectedEventArgs) Handles cboNegociacao.RowSelected
        Dim SqlText As String

        If cboContratoPaf.SelectedRow Is Nothing Then
            cboNegociacao.DataSource = Nothing
            cboContratoFixo.DataSource = Nothing
            Exit Sub
        End If
        If cboNegociacao.SelectedRow Is Nothing Then
            cboContratoFixo.DataSource = Nothing
            Exit Sub
        End If
        SqlText = "select sq_contrato_fixo, TO_CHAR(sq_contrato_fixo) AS no_contrato_fixo from sof.contrato_fixo " & _
                  "where cd_contrato_paf = " & cboContratoPaf.Rows(cboContratoPaf.ActiveRow.Index).Cells(0).Value & " and " & _
                  "sq_negociacao = " & cboNegociacao.Rows(cboNegociacao.ActiveRow.Index).Cells(0).Value & " and " & _
                  "ic_status = 'A'"

        DBCarregarComboBox(cboContratoFixo, SqlText, True)
    End Sub

    Private Sub cmdAdiciona_Contrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdiciona_Contrato.Click
        Dim SqlText As String
        Dim VlJaFixo As Double
        Dim VlMaxAdto As Double
        Dim PcAdto As Double
        Dim VlaFixar As Double
        Dim oData As DataTable
        Dim icont As IndicatorAlignment

        If cboContratoPaf.SelectedRow Is Nothing Then
            Msg_Mensagem("Favor selecionar um Contrato PAF.")
            Exit Sub
        End If

        For icont = 0 To grdGeral.Rows.Count - 1
            If grdGeral.Rows(icont).Cells(cnt_GridCTR_ContratoPAF).Value = cboContratoPaf.Rows(cboContratoPaf.ActiveRow.Index).Cells(0).Value And _
               NVL(grdGeral.Rows(icont).Cells(cnt_GridCTR_Negociacao).Value, 0) = cboNegociacao.Rows(cboNegociacao.ActiveRow.Index).Cells(0).Value And _
               NVL(grdGeral.Rows(icont).Cells(cnt_GridCTR_ContratoFixo).Value, 0) = cboContratoFixo.SelectedValue Then
                Msg_Mensagem("Esse contrato fixo ja foi incluido.")
                cboContratoPaf.Focus()
                Exit Sub
            End If
        Next

        SqlText = "SELECT NVL(SUM(PCP.VL_A_FIXAR),0) VL_A_FIXAR " & _
                  " FROM SOF.PAG_CTR_PAF PCP" & _
                  " WHERE PCP.CD_CONTRATO_PAF = " & cboContratoPaf.Rows(cboContratoPaf.ActiveRow.Index).Cells(0).Value
        VlaFixar = DBQuery_ValorUnico(SqlText)

        If VlaFixar <> 0 Then
            If Msg_Perguntar("O contrato PAF dessa negociação possui adiantamento em aberto." & vbCrLf & _
                             "Valor em aberto: R$ " & Format(VlaFixar, "#,##0.00") & vbCrLf & _
                             "Voce ainda deseja continuar ?") = False Then
                Exit Sub
            End If
        End If

        If ObjUltraComboBox_LinhaSelecionada(cboNegociacao) Then
            SqlText = "SELECT NVL(SUM(A.QT_KG_FIXO), 0) QT_KG_FIXO" & _
                      " FROM SOF.CTR_PAF_NEG_MOVIMENTACAO A" & _
                      " WHERE A.CD_CONTRATO_PAF = " & cboContratoPaf.Rows(cboContratoPaf.ActiveRow.Index).Cells(0).Value & _
                        " AND A.SQ_NEGOCIACAO = " & cboNegociacao.Rows(cboNegociacao.ActiveRow.Index).Cells(0).Value

            If DBQuery_ValorUnico(SqlText) = 0 Then
                If Msg_Perguntar("Essa negociação não possui cacau aplicado nela. Deseja prosseguir ?") = False Then
                    Exit Sub
                End If
            End If

            If Not ComboBox_LinhaSelecionada(cboContratoFixo) Then
                SqlText = "SELECT PC_PAG_APLICA_CTR_FIX FROM SOF.PARAMETRO"
                PcAdto = DBQuery_ValorUnico(SqlText) / 100

                SqlText = "SELECT NVL(SUM((CF.QT_KGS - CF.QT_CANCELADO)),0) QT_KGS," & _
                                 "NVL(SUM(CF.QT_KG_FIXO),0) QT_KG_FIXO," & _
                                 "NVL(SUM(SOF.FC_SALDO_CTR_FIX(CF.CD_CONTRATO_PAF,CF.SQ_NEGOCIACAO, CF.SQ_CONTRATO_FIXO )),0) VL_TOTAL," & _
                                 "NVL(SUM(CF.VL_PAG_FIXO),0) VL_PAG_FIXO" & _
                          " FROM SOF.CONTRATO_FIXO CF" & _
                          " WHERE CF.CD_CONTRATO_PAF = " & cboContratoPaf.Rows(cboContratoPaf.ActiveRow.Index).Cells(0).Value & _
                            " AND CF.SQ_NEGOCIACAO = " & cboNegociacao.Rows(cboNegociacao.ActiveRow.Index).Cells(0).Value & _
                            " AND CF.IC_STATUS = 'A' "
                oData = DBQuery(SqlText)

                If oData.Rows(0).Item("QT_KGS") <> 0 Then
                    If oData.Rows(0).Item("QT_KGS") = oData.Rows(0).Item("QT_KG_FIXO") Then
                        If oData.Rows(0).Item("VL_TOTAL") <> oData.Rows(0).Item("VL_PAG_FIXO") Then
                            Msg_Mensagem("É necessario pagar o contrato fixo em aberto.")
                            Exit Sub
                        Else
                            SqlText = "SELECT N.QT_A_FIXAR" & _
                                      " FROM SOF.NEGOCIACAO N" & _
                                      " WHERE N.CD_CONTRATO_PAF = " & cboContratoPaf.Rows(cboContratoPaf.ActiveRow.Index).Cells(0).Value & _
                                      " AND N.SQ_NEGOCIACAO = " & cboNegociacao.Rows(cboNegociacao.ActiveRow.Index).Cells(0).Value

                            If DBQuery_ValorUnico(SqlText) = 0 Then
                                Msg_Mensagem("Essa negociação ja foi toda fixada e não ha espaço para esse pagamento.")
                                Exit Sub
                            End If
                        End If
                    End If
                End If

                oData.Dispose()
                oData = Nothing
            End If
        Else
            SqlText = "SELECT NVL(SUM(P.VL_FIXO), 0) VL_FIXO " & _
                           " FROM SOF.PAG_CTR_PAF P " & _
                           " WHERE P.CD_CONTRATO_PAF = " & cboContratoPaf.Rows(cboContratoPaf.ActiveRow.Index).Cells(0).Value
            VlJaFixo = DBQuery_ValorUnico(SqlText)

            SqlText = "SELECT NVL(CP.VL_ADIANTAMENTO,0) VL_ADIANTAMENTO" & _
                      " FROM SOF.CONTRATO_PAF CP" & _
                      " WHERE CP.CD_CONTRATO_PAF = " & cboContratoPaf.Rows(cboContratoPaf.ActiveRow.Index).Cells(0).Value
            VlMaxAdto = DBQuery_ValorUnico(SqlText)

            If VlJaFixo > VlMaxAdto Then
                Msg_Mensagem("Esse contrato PAF já possui adiantamento.")
                Exit Sub
            End If

            If (VlMaxAdto - VlJaFixo) < Me.txtValorAplicado.Value Then
                Msg_Mensagem("Valor do adiantamento maior que o valor informado no contrato PAF. (R$ " & Format((VlMaxAdto - VlJaFixo), "#,##0.00") & ")")
                Exit Sub
            End If
        End If

        If txtValorAplicado.Value <= 0 Then
            Msg_Mensagem("Favor informar um valor maior do que 0.")
            txtValorAplicado.Focus()
            Exit Sub
        End If

        If ComboBox_LinhaSelecionada(cboContratoFixo) Then
            If txtValorAplicado.Value > Math.Round(txtSaldoContrato.Value, 2) Then
                Msg_Mensagem("Valor a aplicar maior do que o saldo do contrato.")
                txtValorAplicado.Focus()
                Exit Sub
            End If
        End If

        If chkValorPagamento.Checked = True Then
            If txtValorAplicado.Value > txtSaldoPagamento.Value Then
                Msg_Mensagem("Valor a aplicar maior do que o saldo do pagamento.")
                txtValorAplicado.Focus()
                Exit Sub
            End If
        End If

        Dim oRow As Infragistics.Win.UltraWinDataSource.UltraDataRow

        oRow = oDS.Rows.Add()
        oRow.Item(cnt_GridCTR_ContratoPAF) = cboContratoPaf.Rows(cboContratoPaf.ActiveRow.Index).Cells(0).Value

        If Not cboNegociacao.SelectedRow Is Nothing Then
            oRow.Item(cnt_GridCTR_Negociacao) = cboNegociacao.Rows(cboNegociacao.ActiveRow.Index).Cells(0).Value
        End If
        If ComboBox_LinhaSelecionada(cboContratoFixo) Then
            oRow.Item(cnt_GridCTR_ContratoFixo) = cboContratoFixo.SelectedValue
        End If
        oRow.Item(cnt_GridCTR_ValorAplicado) = txtValorAplicado.Value

        VlTotalAplicado = VlTotalAplicado + txtValorAplicado.Value

        'Caso o calculo seja automatico
        If chkValorPagamento.Checked = False Then
            txtValor.Value = VlTotalAplicado
        End If

        Calcula_Saldo_Pagamento()

        cboContratoPaf.SelectedRow = Nothing
        txtValorAplicado.Value = 0
        cboContratoPaf.Focus()
    End Sub

    Private Sub chkValorPagamento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkValorPagamento.CheckedChanged
        If chkValorPagamento.Checked = True Then
            txtValor.Enabled = True
        Else
            txtValor.Enabled = False
            txtValor.Value = VlTotalAplicado
            txtValorAplicado.Value = 0
            txtValorICMS.Value = 0
        End If
    End Sub

    Private Sub Calcula_Saldo_Pagamento()
        Dim iCont As Integer

        VlTotalAplicado = 0

        For iCont = 0 To grdGeral.Rows.Count - 1
            If oTipoGrid = eTipoGrid.Contrato Then
                VlTotalAplicado = VlTotalAplicado + grdGeral.Rows(iCont).Cells(cnt_GridCTR_ValorAplicado).Value
            Else
                VlTotalAplicado = VlTotalAplicado + grdGeral.Rows(iCont).Cells(cnt_GridICMS_ValorAplicado).Value
            End If
        Next

        txtSaldoPagamento.Value = txtValor.Value - Math.Round(VlTotalAplicado, 4)
    End Sub

    Private Sub txtValor_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValor.ValueChanged
        Calcula_Saldo_Pagamento()
    End Sub

    Private Sub cmdAdiciona_ICMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdiciona_ICMS.Click
        Dim SqlText As String

        If cboContratoPafICMS.SelectedRow Is Nothing Then
            Msg_Mensagem("Favor selecionar um Contrato PAF.")
            Exit Sub
        End If

        SqlText = "select cp.qt_a_negociar "
        SqlText = SqlText & "from sof.contrato_paf cp "
        SqlText = SqlText & "where cp.cd_contrato_paf = " & cboContratoPafICMS.Rows(cboContratoPafICMS.ActiveRow.Index).Cells(0).Value

        If DBQuery_ValorUnico(SqlText) = 0 Then
            Msg_Mensagem("Esse contrato ja foi totalmente negociado e não aceita mais adiantamento dentro dele.")
            Exit Sub
        End If

        If txtNF.Text = "" Then
            Msg_Mensagem("Favor informar a NF.")
            txtNF.Focus()
            Exit Sub
        End If

        If txtValorICMS.Value <= 0 Then
            Msg_Mensagem("Favor informar um valor maior do que 0.")
            txtValorICMS.Focus()
            Exit Sub
        End If

        If chkValorPagamento.Checked = True Then
            If txtValorICMS.Value > txtSaldoPagamentoICMS.Value Then
                Msg_Mensagem("Valor a aplicar maior do que o saldo do pagamento.")
                txtValorICMS.Focus()
                Exit Sub
            End If
        End If

        Dim oRow As Infragistics.Win.UltraWinDataSource.UltraDataRow

        oRow = oDS.Rows.Add()

        oRow.Item(cnt_GridICMS_ContratoPAF) = cboContratoPafICMS.Rows(cboContratoPafICMS.ActiveRow.Index).Cells(0).Value
        oRow.Item(cnt_GridICMS_NF) = txtNF.Text
        oRow.Item(cnt_GridICMS_Descricao) = "Adiantamento Fornecedor NF nº" & txtNF.Text
        oRow.Item(cnt_GridICMS_ValorAplicado) = txtValorICMS.Value

        VlTotalAplicado = VlTotalAplicado + txtValorICMS.Value
        'caso o calculo seja automatico
        If chkValorPagamento.Checked = False Then
            txtValor.Value = VlTotalAplicado
        End If

        Calcula_Saldo_Pagamento()

        cboContratoPafICMS.SelectedRow = Nothing
        txtValorICMS.Value = 0
        txtNF.Text = ""
        cboContratoPafICMS.Focus()
    End Sub

    Private Sub grdGeral_AfterRowsDeleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdGeral.AfterRowsDeleted
        Calcula_Saldo_Pagamento()

        If Not chkValorPagamento.Checked Then
            txtValor.Value = VlTotalAplicado
        End If
    End Sub

    Private Sub grdGeral_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdGeral.BeforeRowsDeleted
        e.DisplayPromptMsg = False

        If Not Msg_Perguntar("Deseja excluir o registro?") Then
            e.Cancel = True
        End If
    End Sub

    Private Function Valida_Limite() As Boolean
        Dim SqlText As String
        Dim VlSolicitado As Double
        Dim IcFixo As String
        Dim IcDolar As String
        Dim IcBolsa As String
        Dim IcBolsaOpe As String
        Dim VlSaldo As Double

        Valida_Limite = False

        IcFixo = "N"
        IcDolar = "N"
        IcBolsa = "N"
        IcBolsaOpe = ""

        VlSolicitado = txtValor.Value

        SqlText = DBMontar_SP("SOF.SP_SALDO_FORNECEDOR", False, ":CDFORN", _
                                                                ":ICNEG", _
                                                                    ":VLUNITARIO", _
                                                                    ":ICFIXONEG", _
                                                                    ":ICDOLARNEG", _
                                                                    ":ICBOLSANEG", _
                                                                    ":ICBOLSAOPERACAONEG", _
                                                                    ":PCALIQINSS", _
                                                                    ":VLSALDO", _
                                                                    ":VLLCMOEDA", _
                                                                    ":VLBOLSA", _
                                                                    ":VLLIMITECREDITO", _
                                                                    ":VLAORDEM", _
                                                                    ":VLPAGAB", _
                                                                    ":VLPRECOCACAU", _
                                                                    ":QTAORDEM", _
                                                                    ":VLJUROS", _
                                                                    ":VLCONFDIV", _
                                                                    ":VLICMSNFCOMP")

        If Not DBExecutar(SqlText, DBParametro_Montar("CDFORN", Pesq_Fornecedor.Codigo), _
                                   DBParametro_Montar("ICNEG", "N"), _
                                   DBParametro_Montar("VLUNITARIO", VlSolicitado), _
                                   DBParametro_Montar("ICFIXONEG", IcFixo), _
                                   DBParametro_Montar("ICDOLARNEG", IcDolar), _
                                   DBParametro_Montar("ICBOLSANEG", IcBolsa), _
                                   DBParametro_Montar("ICBOLSAOPERACAONEG", IcBolsaOpe), _
                                   DBParametro_Montar("PCALIQINSS", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("VLSALDO", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("VLLCMOEDA", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("VLBOLSA", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("VLLIMITECREDITO", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("VLAORDEM", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("VLPAGAB", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("VLPRECOCACAU", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("QTAORDEM", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("VLJUROS", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("VLCONFDIV", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("VLICMSNFCOMP", Nothing, , ParameterDirection.Output)) Then GoTo Erro


        If DBTeveRetorno() Then
            VlSaldo = Val(DBRetorno(2))
        End If

        If VlSaldo < 0 Then
            Msg_Mensagem("O fornecedor não possue saldo em aberto no limite de credito")
            Exit Function
        End If

        If VlSolicitado > Math.Round(VlSaldo, 2) Then
            Msg_Mensagem("Fornecedor não possue saldo para realizar esse pagamento.")
            Exit Function
        End If

        Valida_Limite = True
        Exit Function
Erro:
        TratarErro()
    End Function
End Class