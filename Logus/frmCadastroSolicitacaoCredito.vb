Public Class frmCadastroSolicitacaoCredito
    Enum eTipoMoeda
        Dolar = 1
        Sacos = 2
        Reais = 3
    End Enum

    Dim oTipoMoeda As eTipoMoeda
    Dim VlDolar As Double
    Dim VlPreco As Double
    Dim IcMoeda As String

    Private Sub frmCadastroSolicitacaoCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_Fornecedor.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        objUltraComboBox_Inicializar(cboGarantia, 380)

        Limpa_Tela()
        Pega_Valores()
    End Sub

    Private Sub Pega_Valores()
        Dim SqlText As String
        Dim DtCotacao As Date

        SqlText = "SELECT MAX(LCM.DT_COTACAO) DT_COTACAO " & _
                  "FROM SOF.LIMITE_CREDITO_MOEDA LCM " & _
                  "WHERE LCM.DT_COTACAO <= TO_DATE('" & Date_to_Oracle(DataSistema) & "')"

        DtCotacao = DBQuery_ValorUnico(SqlText)


        SqlText = "SELECT LCM.VL_TAXA " & _
                  "FROM SOF.LIMITE_CREDITO_MOEDA LCM " & _
                  "WHERE LCM.DT_COTACAO = to_date('" & Date_to_Oracle(DtCotacao) & "') AND " & _
                  "LCM.CD_TIPO_MOEDA = 1"


        VlDolar = DBQuery_ValorUnico(SqlText, 1)


        SqlText = "SELECT p.ic_moeda_credito FROM sof.parametro p "
        IcMoeda = DBQuery_ValorUnico(SqlText)

        Select Case IcMoeda
            Case "D"
                oTipoMoeda = eTipoMoeda.Dolar
            Case "S"
                oTipoMoeda = eTipoMoeda.Sacos
            Case "R"
                oTipoMoeda = eTipoMoeda.Reais
        End Select


        Select Case oTipoMoeda
            Case eTipoMoeda.Dolar
                grpSolicitado.Text = "Valor U$"
                txtSolicitado.MaskInput = "{LOC}-nnnnn,nnn.nn"
            Case eTipoMoeda.Reais
                grpSolicitado.Text = "Valor R$"
                txtSolicitado.MaskInput = "{LOC}-nnnnn,nnn.nn"
            Case eTipoMoeda.Sacos
                grpSolicitado.Text = "Sacos"
                txtSolicitado.MaskInput = "{LOC}-nnnnn,nnn"
        End Select
    End Sub

    Private Sub optTipo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTipo.ValueChanged
        Select Case optTipo.Value
            Case "G"
                grpGarantia.Enabled = True
                grpRevisao.Enabled = True
            Case "E"
                grpGarantia.Enabled = False
                grpRevisao.Enabled = False
            Case "P"
                grpGarantia.Enabled = False
                grpRevisao.Enabled = True
        End Select
    End Sub

    Private Sub Limpa_Tela()
        Pesq_Fornecedor.Codigo = 0
        txtDataRevisao.Value = DataSistema()
        txtDataValidade.Value = DataSistema()
        grpGarantia.Enabled = False
        grpRevisao.Enabled = False
        txtSolicitado.Value = 0
        optTipo.Value = Nothing
        txtDescricao.Text = ""
        txtSaldo.Value = 0
        txtValorAPagar.Value = 0
        txtValorASolicitar.Value = 0
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String

        If Pesq_Fornecedor.Codigo <= 0 Then
            Msg_Mensagem("Favor informar um fornecedor valido.")
            Pesq_Fornecedor.Focus()
            Exit Sub
        End If

        If optTipo.Value = Nothing Then
            Msg_Mensagem("Escolha o tipo de solicitação de credito.")
            Exit Sub
        End If

        If txtSolicitado.Value <= 0 Then
            Msg_Mensagem("Favor informar um valor valido.")
            txtSolicitado.Focus()
            Exit Sub
        End If

        If txtDescricao.Text = "" Then
            Msg_Mensagem("Favor informar uma descrição.")
            txtDescricao.Focus()
            Exit Sub
        End If
        If optTipo.Value = "G" Then
            If cboGarantia.SelectedRow Is Nothing Then
                Msg_Mensagem("Favor informar a garantia.")
                Exit Sub
            End If
        End If

        If grpRevisao.Visible = False Then
            txtDataRevisao.Value = txtDataValidade.Value
        End If


        Dim Parametro(12) As DBParamentro

        DBUsarTransacao = True

        SqlText = DBMontar_SP("SOF.SP_SOLITACAO_CREDITO", False, ":CDFORN", _
                                                                 ":VLSOLICITADO", _
                                                                 ":ICMOEDA", _
                                                                 ":DSOBS", _
                                                                 ":DTVALIDADE", _
                                                                 ":DESCRICAO", _
                                                                 ":DTREVISAO", _
                                                                 ":VLADIANTAMENTO", _
                                                                 ":QTSACOSPROMETIDOS", _
                                                                 ":DTENTREGA", _
                                                                 ":ICPREAPROVADO", _
                                                                 ":ICEXCECAO", _
                                                                 ":SQGARANTIA")

        Parametro(0) = DBParametro_Montar("CDFORN", Pesq_Fornecedor.Codigo)
        Parametro(1) = DBParametro_Montar("VLSOLICITADO", txtSolicitado.Value)
        Parametro(2) = DBParametro_Montar("ICMOEDA", IcMoeda)
        Parametro(3) = DBParametro_Montar("DSOBS", txtDescricao.Text, OracleClient.OracleType.VarChar, , 4000)
        Parametro(4) = DBParametro_Montar("DTVALIDADE", Date_to_Oracle(txtDataValidade.Text), DbType.Date)
        Parametro(5) = DBParametro_Montar("DESCRICAO", Nothing)
        Parametro(6) = DBParametro_Montar("DTREVISAO", Date_to_Oracle(txtDataRevisao.Text), DbType.Date)
        Parametro(7) = DBParametro_Montar("VLADIANTAMENTO", Nothing)
        Parametro(8) = DBParametro_Montar("QTSACOSPROMETIDOS", Nothing)
        Parametro(9) = DBParametro_Montar("DTENTREGA", Nothing)
        Parametro(10) = DBParametro_Montar("ICPREAPROVADO", IIf(optTipo.Value = "P", "S", "N"))
        Parametro(11) = DBParametro_Montar("ICEXCECAO", IIf(optTipo.Value = "E", "S", "N"))
        If grpGarantia.Enabled = True Then
            Parametro(12) = DBParametro_Montar("SQGARANTIA", cboGarantia.Rows(cboGarantia.ActiveRow.Index).Cells(0).Value)
        Else
            Parametro(12) = DBParametro_Montar("SQGARANTIA", Nothing)
        End If

        If Not DBExecutar(SqlText, Parametro) Then GoTo Erro

        If Not DBExecutarTransacao() Then GoTo Erro

        Limpa_Tela()

        Pesq_Fornecedor.Focus()
        Exit Sub
Erro:
        TratarErro()
    End Sub

    Private Sub Pesq_Fornecedor_AlterouRegistro() Handles Pesq_Fornecedor.AlterouRegistro

        If Not Pesq_Fornecedor.Codigo > 0 Then Exit Sub

        Dim SqlText As String

        SqlText = "SELECT  g.sq_garantia ,tg.no_tipo_garantia , g.vl_garantia ,g.dt_garantia_validade "
        SqlText = SqlText & "  FROM sof.garantia_fornecedor gf, sof.garantia g, sof.tipo_garantia tg "
        SqlText = SqlText & " WHERE gf.sq_garantia = g.sq_garantia "
        SqlText = SqlText & " and g.cd_tipo_garantia =tg.cd_tipo_garantia  and cd_tipo_status='A' "
        SqlText = SqlText & " and gf.cd_fornecedor = " & Pesq_Fornecedor.Codigo


        objUltraComboBox_Carregar(cboGarantia, SqlText, _
                          New Combo_Informacao() {objUltraComboBox_Informacao("Código", False, 0, False, True), _
                                                  objUltraComboBox_Informacao("Tipo Garantia", True, 220, True, False), _
                                                  objUltraComboBox_Informacao("Valor", True, 80, False, False, cnt_Formato_Valor), _
                                                  objUltraComboBox_Informacao("Validade", True, 80, False, False)})

        Atualiza_Saldo()
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub Atualiza_Saldo()
        If Pesq_Fornecedor.Codigo <= 0 Then
            Msg_Mensagem("Favor selecionar um fornecedor valido.")
            Pesq_Fornecedor.Focus()
            Exit Sub
        End If

        Dim SqlText As String



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
                                   DBParametro_Montar("VLUNITARIO", 1), _
                                   DBParametro_Montar("ICFIXONEG", "N"), _
                                   DBParametro_Montar("ICDOLARNEG", "N"), _
                                   DBParametro_Montar("ICBOLSANEG", "N"), _
                                   DBParametro_Montar("ICBOLSAOPERACAONEG", ""), _
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
            txtSaldo.Value = Val(DBRetorno(2))
            VlPreco = Val(DBRetorno(8))
        End If

        txtValorAPagar.Value = 0
        txtValorASolicitar.Value = 0

        Exit Sub
Erro:
        TratarErro()
    End Sub

    Private Sub txtValorAPagar_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValorAPagar.ValueChanged
        If VlPreco <> 0 And (txtSaldo.Value - txtValorAPagar.Value) < 0 Then
            Select Case oTipoMoeda
                Case eTipoMoeda.Sacos
                    txtValorASolicitar.Value = (0 - (txtSaldo.Value - txtValorAPagar.Value)) / VlPreco / 60
                Case eTipoMoeda.Reais
                    txtValorASolicitar.Value = (0 - (txtSaldo.Value - txtValorAPagar.Value))
                Case eTipoMoeda.Dolar
                    txtValorASolicitar.Value = (0 - (txtSaldo.Value - txtValorAPagar.Value)) / VlDolar
            End Select
        Else
            txtValorASolicitar.Value = 0
        End If

    End Sub
End Class