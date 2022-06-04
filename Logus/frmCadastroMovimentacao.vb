Public Class frmCadastroMovimentacao
    Const cnt_CodigoNfComplementar As Integer = 104

    Dim PcAliqICMS As Double

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmCadastroMovimentacao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox_Carregar_Filial(cboFilialMovimentacao)
        ComboBox_Carregar_Tipo_Cacau(cboTipoCacau)
        ComboBox_Carregar_Tipo_Documento(cboTipoDocumento, True)
        ComboBox_Carregar_Local_Entrega(cboLocalEntrega, True)

        Pesq_Fornecedor.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        With Pesq_Municipio
            .Codigo = 0
            .Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Municipio
        End With

        With Pesq_TipoMovimentacao
            .Codigo = 0
            .Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_TipoMovimentacao
            .BancoDados_Filtro_Limpar()
            .BancoDados_Filtro_Adicionar("IC_ATIVO = 'S'")
            .BancoDados_Filtro_Adicionar("IC_VALIDA_QUALIDADE = 'N'")
            .BancoDados_Filtro_Adicionar("IC_VALIDA_KG = 'N'")
        End With

        Limpa_Tela()
    End Sub

    Private Sub Limpa_Tela()
        txtDataMovimentacao.Value = DataSistema()

        ComboBox_Possicionar(cboFilialMovimentacao, FilialLogada)
        ComboBox_Possicionar(cboTipoCacau, 1) 'cacau comum
        Pesq_Fornecedor.Codigo = 0
        Pesq_Municipio.Codigo = 0
        txtDataNF.Value = Nothing
        txtNotaFiscal.Text = ""
        txtQuantidade.Value = 0
        txtSerie.Text = ""
        txtValorDocumento.Value = 0
        txtValorICMS.Value = 0

        If cboLocalEntrega.Enabled Then
            ComboBox_Possicionar(cboLocalEntrega, -1)
        End If

        Pesq_TipoMovimentacao.Codigo = cnt_CodigoNfComplementar
        Pesq_Fornecedor.Focus()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        If Pesq_TipoMovimentacao.Codigo = 0 Then
            Msg_Mensagem("Favor selecionar um tipo de movimentacao valido.")
            Pesq_TipoMovimentacao.Focus()
            Exit Sub
        End If
        If Pesq_Municipio.Codigo = 0 Then
            Msg_Mensagem("Favor selecionar um municipio valido.")
            Pesq_Municipio.Focus()
            Exit Sub
        End If
        If Pesq_Fornecedor.Codigo = 0 Then
            Msg_Mensagem("Favor selecionar um fornecedor valido.")
            Pesq_Fornecedor.Focus()
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboTipoDocumento) Then
            Msg_Mensagem("Favor selecionar um tipo de documento valido.")
            cboTipoDocumento.Focus()
            Exit Sub
        End If
        If txtNotaFiscal.Text = "" Then
            Msg_Mensagem("Favor informar um numero da nota fiscal.")
            txtNotaFiscal.Focus()
            Exit Sub
        End If
        If DBQuery_ValorUnico("SELECT IC_VALIDA_VALOR FROM SOF.TIPO_MOVIMENTACAO WHERE CD_TIPO_MOVIMENTACAO = " & Pesq_TipoMovimentacao.Codigo) = "S" Then
            If txtValorDocumento.Value = 0 Then
                Msg_Mensagem("Favor informar o valor da nota fiscal.")
                txtValorDocumento.Focus()
                Exit Sub
            End If
        End If
        If DBQuery_ValorUnico("SELECT IC_VALIDA_KG FROM SOF.TIPO_MOVIMENTACAO WHERE CD_TIPO_MOVIMENTACAO = " & Pesq_TipoMovimentacao.Codigo) = "S" Then
            If txtQuantidade.Value = 0 Then
                Msg_Mensagem("Favor informa a quantidade de quilos da nota fiscal.")
                txtQuantidade.Focus()
                Exit Sub
            End If
        End If
        If Not ComboBox_LinhaSelecionada(cboFilialMovimentacao) Then
            Msg_Mensagem("Favor selecionar a filial que originou o documento.")
            cboFilialMovimentacao.Focus()
            Exit Sub
        End If
        If Not IsDate(txtDataNF.Text) Then
            Msg_Mensagem("Favor informar uma data da nota fiscal.")
            txtDataNF.Focus()
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboTipoCacau) Then
            Msg_Mensagem("Favor selecionar um tipo de cacau.")
            cboTipoCacau.Focus()
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboLocalEntrega) Then
            Msg_Mensagem("Favor selecionar um local de entrega da mercadoria.")
            cboLocalEntrega.Focus()
            Exit Sub
        End If

        Dim CdFilialOri As Integer
        Dim Parametro(31) As DBParamentro
        Dim SqlText As String

        CdFilialOri = DBQuery_ValorUnico("SELECT CD_FILIAL_ORIGEM FROM SOF.FORNECEDOR WHERE CD_FORNECEDOR = " & Pesq_Fornecedor.Codigo)

        If FilialFechada(CdFilialOri) Then
            Msg_Mensagem("A Filial está fechada. No momento não é possivel realizar essa operação.")
            Exit Sub
        End If

        SqlText = DBMontar_Function("SOF.INCLUI_MOVIMENTACAO", ":FORN", _
                                                               ":TIPONF", _
                                                               ":TPMOV", _
                                                               ":MUNICIPIO", _
                                                               ":FILMOV", _
                                                               ":DATA", _
                                                               ":NF", _
                                                               ":KGNF", _
                                                               ":VLNF", _
                                                               ":VLICMS", _
                                                               ":KGLIQ", _
                                                               ":KGBRUTO", _
                                                               ":FILORIGEM", _
                                                               ":SERIENF", _
                                                               ":QUALI", _
                                                               ":UMIDADE", _
                                                               ":TIPOCACAU", _
                                                               ":PESOAMENDOA", _
                                                               ":MOFO", _
                                                               ":FUMACA", _
                                                               ":ARDOSIA", _
                                                               ":ACHATADA", _
                                                               ":SUJO", _
                                                               ":NFREF", _
                                                               ":DTNFREF", _
                                                               ":LOCALENTREGA", _
                                                               ":NUORDEMDESCARGA", _
                                                               ":CDPROCEDENCIA", _
                                                               ":DSAUTORIZACAO", _
                                                               ":CDTPCACAU", _
                                                               ":DTNF")

        Parametro(0) = DBParametro_Montar("FORN", Pesq_Fornecedor.Codigo)
        Parametro(1) = DBParametro_Montar("TIPONF", cboTipoDocumento.SelectedValue)
        Parametro(2) = DBParametro_Montar("TPMOV", Pesq_TipoMovimentacao.Codigo)
        Parametro(3) = DBParametro_Montar("MUNICIPIO", Pesq_Municipio.Codigo)
        Parametro(4) = DBParametro_Montar("FILMOV", cboFilialMovimentacao.SelectedValue)
        Parametro(5) = DBParametro_Montar("DATA", Date_to_Oracle(DataSistema), OracleClient.OracleType.DateTime)
        Parametro(6) = DBParametro_Montar("NF", txtNotaFiscal.Text)
        Parametro(7) = DBParametro_Montar("KGNF", txtQuantidade.Value)
        Parametro(8) = DBParametro_Montar("VLNF", txtValorDocumento.Value)
        Parametro(9) = DBParametro_Montar("VLICMS", txtValorICMS.Value)
        Parametro(10) = DBParametro_Montar("KGLIQ", 0)
        Parametro(11) = DBParametro_Montar("KGBRUTO", 0)
        Parametro(12) = DBParametro_Montar("FILORIGEM", CdFilialOri)
        Parametro(13) = DBParametro_Montar("SERIENF", txtSerie.Text)
        Parametro(14) = DBParametro_Montar("QUALI", "N")
        Parametro(15) = DBParametro_Montar("UMIDADE", Nothing)
        Parametro(16) = DBParametro_Montar("TIPOCACAU", Nothing)
        Parametro(17) = DBParametro_Montar("PESOAMENDOA", Nothing)
        Parametro(18) = DBParametro_Montar("MOFO", Nothing)
        Parametro(19) = DBParametro_Montar("FUMACA", Nothing)
        Parametro(20) = DBParametro_Montar("ARDOSIA", Nothing)
        Parametro(21) = DBParametro_Montar("ACHATADA", Nothing)
        Parametro(22) = DBParametro_Montar("SUJO", Nothing)
        Parametro(23) = DBParametro_Montar("NFREF", Nothing)
        Parametro(24) = DBParametro_Montar("DTNFREF", Nothing)
        Parametro(25) = DBParametro_Montar("LOCALENTREGA", NULLIf(cboLocalEntrega.SelectedValue, Nothing))
        Parametro(26) = DBParametro_Montar("NUORDEMDESCARGA", Nothing)
        Parametro(27) = DBParametro_Montar("CDPROCEDENCIA", Nothing)
        Parametro(28) = DBParametro_Montar("DSAUTORIZACAO", Nothing)
        Parametro(29) = DBParametro_Montar("CDTPCACAU", cboTipoCacau.SelectedValue)
        Parametro(30) = DBParametro_Montar("DTNF", Date_to_Oracle(txtDataNF.Text), OracleClient.OracleType.DateTime)
        Parametro(31) = DBParametro_Montar("RET", Nothing, , ParameterDirection.ReturnValue)

        If Not DBExecutar(SqlText, Parametro) Then GoTo Erro

        Msg_Mensagem("Inclusão realizada com sucesso.")

        Limpa_Tela()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub Pesq_TipoMovimentacao_AlterouRegistro() Handles Pesq_TipoMovimentacao.AlterouRegistro
        Dim SqlText As String
        Dim oData As DataTable

        If Pesq_TipoMovimentacao.Codigo = 0 Then
            ComboBox_Possicionar(cboLocalEntrega, -1)
            cboLocalEntrega.Enabled = True
        Else
            SqlText = "SELECT IC_POSTO_FIXO, CD_LOCAL_ENTREGA" & _
                      " FROM SOF.TIPO_MOVIMENTACAO" & _
                      " WHERE CD_TIPO_MOVIMENTACAO = " & Pesq_TipoMovimentacao.Codigo
            oData = DBQuery(SqlText)

            If oData.Rows(0).Item("IC_POSTO_FIXO") = "S" Then
                ComboBox_Possicionar(cboLocalEntrega, oData.Rows(0).Item("CD_LOCAL_ENTREGA"))

                If ComboBox_LinhaSelecionada(cboLocalEntrega) Then
                    cboLocalEntrega.Enabled = False
                End If
            Else
                ComboBox_Possicionar(cboLocalEntrega, -1)
                cboLocalEntrega.Enabled = True
            End If
        End If
    End Sub

    Private Sub txtValorDocumento_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValorDocumento.ValueChanged
        txtValorICMS.Value = txtValorDocumento.Value * (PcAliqICMS / 100)
    End Sub

    Private Sub Pesq_Fornecedor_AlterouRegistro() Handles Pesq_Fornecedor.AlterouRegistro
        Dim SqlText As String
        Dim bOk As Boolean
        Dim oData As DataTable

        PcAliqICMS = 0

        If Pesq_Fornecedor.Codigo > 0 Then
            SqlText = "SELECT U.PC_ALIQ_ICMS " & _
                      "FROM SOF.FORNECEDOR F, SOF.MUNICIPIO M, SOF.UF U " & _
                      "WHERE M.CD_MUNICIPIO = F.CD_MUNICIPIO AND " & _
                      "U.CD_UF = M.CD_UF AND " & _
                      "F.CD_FORNECEDOR = " & Pesq_Fornecedor.Codigo
            PcAliqICMS = DBQuery_ValorUnico(SqlText, 0)

            'Verifica se o address number está ok
            bOk = True

            If cboTipoDocumento.SelectedValue = "NT" And Not Debug_Testar() Then
                SqlText = "select FN.CD_ADDRESS_NUMBER," & _
                                 "DECODE(IC_FISICA_JURIDICA, 'J'," & _
                                        "SUBSTR(FN.NU_CGC_CPF, 1, 2) ||" & _
                                        "SUBSTR(FN.NU_CGC_CPF, 4, 3)  ||" & _
                                        "SUBSTR(FN.NU_CGC_CPF, 8, 3)  ||" & _
                                        "SUBSTR(FN.NU_CGC_CPF, 12, 4)  ||" & _
                                        "SUBSTR(FN.NU_CGC_CPF, 17, 2)," & _
                                        "SUBSTR(FN.NU_CGC_CPF, 1, 3) ||" & _
                                        "SUBSTR(FN.NU_CGC_CPF, 5, 3)  ||" & _
                                        "SUBSTR(FN.NU_CGC_CPF, 9, 3)  ||" & _
                                        "SUBSTR(FN.NU_CGC_CPF, 13, 2)) NU_CGC_CPF_FN," & _
                                 "ABForn.ABTAX NU_CGC_CPF_AB," & _
                                 " FN.cd_tipo_pessoa " & _
                          " from SOF.Fornecedor FN," & _
                                "ILH_OW.F0101 ABForn" & _
                          " where FN.cd_Fornecedor = " & Pesq_Fornecedor.Codigo & _
                            " and ABForn.ABAN8 (+) =  FN.cd_Address_Number"
                oData = DBQuery(SqlText)

                If oData.Rows.Count > 0 Then
                    If objDataTable_CampoVazio(oData.Rows(0).Item("CD_ADDRESS_NUMBER")) Then
                        MsgBox("Fornecedor sem Address Number cadastrado")
                        bOk = False
                    Else
                        If objDataTable_CampoVazio(oData.Rows(0).Item("NU_CGC_CPF_AB")) Then
                            MsgBox("Address Number de fornecedor Inválido")
                            bOk = False
                        Else
                            If Trim(oData.Rows(0).Item("NU_CGC_CPF_AB")) <> Trim(oData.Rows(0).Item("NU_CGC_CPF_FN")) And _
                               oData.Rows(0).Item("cd_tipo_pessoa") <> 6 Then
                                MsgBox("Address Number de fornecedor Inválido")
                                bOk = False
                            End If
                        End If
                    End If
                End If
            End If

            If Not bOk Then
                Pesq_Fornecedor.Codigo = 0
            End If
        End If
    End Sub

    Private Sub cboTipoDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoDocumento.SelectedIndexChanged
        Pesq_Fornecedor_AlterouRegistro()
    End Sub
End Class