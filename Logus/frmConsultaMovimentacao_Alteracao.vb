Public Class frmConsultaMovimentacao_Alteracao
    Public SQ_Movimentacao As Integer = Nothing
    Dim LocalNulo As Boolean

    Private Sub frmConsultaMovimentacao_Alteracao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlText As String

        ComboBox_Carregar_Filial(cboFilialOrigem, True)
        ComboBox_Carregar_Tipo_Cacau(cboTipoCacau, True)
        ComboBox_Carregar_Tipo_Documento(cboTipoDocumento, True)
        ComboBox_Carregar_Local_Entrega(cboLocalEntrega, True)
        ComboBox_Carregar_Procedencia(cboProcedencia, True)

        Pesq_Fornecedor.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        SqlText = "(SELECT CD_MUNICIPIO," & _
                           "TRIM(MC.NO_CIDADE) || ' - ' || TRIM(UF.NO_UF) NO_CIDADE" & _
                   " FROM SOF.MUNICIPIO MC," & _
                         "SOF.UF UF" & _
                   " WHERE UF.CD_UF = MC.CD_UF)"

        With Pesq_Municipio
            .Codigo = 0
            .Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Municipio
        End With

        CarregarDados()
    End Sub

    Private Sub CarregarDados()
        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "SELECT * FROM SOF.MOVIMENTACAO WHERE SQ_MOVIMENTACAO = " & SQ_Movimentacao
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            Pesq_Fornecedor.Codigo = NVL(oData.Rows(0).Item("CD_FORNECEDOR"), 0)
            Pesq_Fornecedor.Enabled = False

            If Not objDataTable_CampoVazio(oData.Rows(0).Item("cd_municipio_origem")) Then
                Pesq_Municipio.Codigo = oData.Rows(0).Item("cd_municipio_origem")
                Pesq_Municipio.Enabled = True
            Else
                Pesq_Municipio.Enabled = False
            End If

            If Not objDataTable_CampoVazio(oData.Rows(0).Item("cd_tipo_nf")) Then
                ComboBox_Possicionar(cboTipoDocumento, oData.Rows(0).Item("cd_tipo_nf"))
                cboTipoDocumento.Enabled = True
            Else
                cboTipoDocumento.Enabled = False
            End If

            If Not objDataTable_CampoVazio(oData.Rows(0).Item("cd_filial_origem")) Then
                ComboBox_Possicionar(cboFilialOrigem, oData.Rows(0).Item("cd_filial_origem"))
                cboFilialOrigem.Enabled = True
            Else
                cboFilialOrigem.Enabled = False
            End If

            If Not objDataTable_CampoVazio(oData.Rows(0).Item("cd_local_entrega")) Then
                LocalNulo = False
                ComboBox_Possicionar(cboLocalEntrega, oData.Rows(0).Item("cd_local_entrega"))
                cboLocalEntrega.Enabled = True
            Else
                LocalNulo = True
                cboLocalEntrega.Enabled = False
            End If

            If Not objDataTable_CampoVazio(oData.Rows(0).Item("cd_procedencia")) Then
                ComboBox_Possicionar(cboProcedencia, oData.Rows(0).Item("cd_procedencia"))
                cboProcedencia.Enabled = True
            Else
                cboProcedencia.Enabled = False
            End If

            If Not objDataTable_CampoVazio(oData.Rows(0).Item("QT_KG_NF")) Then
                txtQuantidade.Value = oData.Rows(0).Item("QT_KG_NF")
                txtQuantidade.Enabled = True
            Else
                txtQuantidade.Enabled = False
            End If

            If Not objDataTable_CampoVazio(oData.Rows(0).Item("cd_tipo_cacau")) Then
                ComboBox_Possicionar(cboTipoCacau, oData.Rows(0).Item("cd_tipo_cacau"))
            End If

            If Not objDataTable_CampoVazio(oData.Rows(0).Item("DT_NOTA_FISCAL")) Then
                txtDataNF.Value = oData.Rows(0).Item("DT_NOTA_FISCAL")
            End If

            SqlText = "select count(*) as qt from sof.frete where sq_movimentacao = " & SQ_Movimentacao


            If DBQuery_ValorUnico(SqlText) <> 0 Then
                cboLocalEntrega.Enabled = False
            End If

            txtNotaFiscal.Text = "" & oData.Rows(0).Item("nu_nf")
            txtSerie.Text = "" & oData.Rows(0).Item("nu_serie_nf")
        End If
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        If Pesq_Fornecedor.Enabled Then
            If Pesq_Fornecedor.Codigo = 0 Then
                Msg_Mensagem("Favor selecionar um fornecedor valido.")
                Pesq_Fornecedor.Focus()
                Exit Sub
            End If
        End If
        If Pesq_Municipio.Enabled Then
            If Pesq_Municipio.Codigo = 0 Then
                Msg_Mensagem("Favor selecionar um municipio valido.")
                Pesq_Municipio.Focus()
                Exit Sub
            End If
        End If
        If cboTipoDocumento.Enabled Then
            If Not ComboBox_LinhaSelecionada(cboTipoDocumento) Then
                Msg_Mensagem("Favor selecionar um tipo de documento valido.")
                cboTipoDocumento.Focus()
                Exit Sub
            End If
        End If
        If txtNotaFiscal.Text = "" Then
            Msg_Mensagem("Favor informar um numero da nota fiscal.")
            txtNotaFiscal.Focus()
            Exit Sub
        End If
        If cboFilialOrigem.Enabled Then
            If Not ComboBox_LinhaSelecionada(cboFilialOrigem) Then
                Msg_Mensagem("Favor selecionar a filial que originou o documento.")
                cboFilialOrigem.Focus()
                Exit Sub
            End If
        End If
        If Not IsDate(txtDataNF.Text) Then
            Msg_Mensagem("Favor informar uma data da nota fiscal.")
            txtDataNF.Focus()
            Exit Sub
        End If
        If cboTipoCacau.Enabled Then
            If Not ComboBox_LinhaSelecionada(cboTipoCacau) Then
                Msg_Mensagem("Favor selecionar um tipo de cacau.")
                cboTipoCacau.Focus()
                Exit Sub
            End If
        End If
        If cboLocalEntrega.Enabled Then
            If Not ComboBox_LinhaSelecionada(cboLocalEntrega) Then
                Msg_Mensagem("Favor selecionar um local de entrega da mercadoria.")
                cboLocalEntrega.Focus()
                Exit Sub
            End If
        End If

        Dim Parametro(11) As DBParamentro
        Dim SqlText As String

        SqlText = DBMontar_Update("SOF.MOVIMENTACAO", GerarArray("CD_FORNECEDOR", ":CD_FORNECEDOR", _
                                                                 "CD_TIPO_NF", ":CD_TIPO_NF", _
                                                                 "CD_MUNICIPIO_ORIGEM", ":CD_MUNICIPIO_ORIGEM", _
                                                                 "NU_NF", ":NU_NF", _
                                                                 "QT_KG_NF", ":QT_KG_NF", _
                                                                 "CD_FILIAL_ORIGEM", ":CD_FILIAL_ORIGEM", _
                                                                 "NU_SERIE_NF", ":NU_SERIE_NF", _
                                                                 "CD_LOCAL_ENTREGA", ":CD_LOCAL_ENTREGA", _
                                                                 "CD_PROCEDENCIA", ":CD_PROCEDENCIA", _
                                                                 "CD_TIPO_CACAU", ":CD_TIPO_CACAU", _
                                                                 "DT_NOTA_FISCAL", ":DT_NOTA_FISCAL"), _
                                                      GerarArray("SQ_MOVIMENTACAO", ":SQ_MOVIMENTACAO"))

        Parametro(0) = DBParametro_Montar("CD_FORNECEDOR", NULLIf(Pesq_Fornecedor.Codigo, 0))
        Parametro(1) = DBParametro_Montar("CD_TIPO_NF", NULLIf(cboTipoDocumento.SelectedValue, -1))
        Parametro(2) = DBParametro_Montar("CD_MUNICIPIO_ORIGEM", NULLIf(Pesq_Municipio.Codigo, Nothing))
        Parametro(3) = DBParametro_Montar("NU_NF", txtNotaFiscal.Text)
        Parametro(4) = DBParametro_Montar("QT_KG_NF", txtQuantidade.Value)
        Parametro(5) = DBParametro_Montar("CD_FILIAL_ORIGEM", NULLIf(cboFilialOrigem.SelectedValue, -1))
        Parametro(6) = DBParametro_Montar("NU_SERIE_NF", txtSerie.Text)
        If ComboBox_LinhaSelecionada(cboLocalEntrega) Then
            Parametro(7) = DBParametro_Montar("CD_LOCAL_ENTREGA", cboLocalEntrega.SelectedValue)
        Else
            Parametro(7) = DBParametro_Montar("CD_LOCAL_ENTREGA", Nothing)
        End If
        If ComboBox_LinhaSelecionada(cboProcedencia) Then
            Parametro(8) = DBParametro_Montar("CD_PROCEDENCIA", cboProcedencia.SelectedValue)
        Else
            Parametro(8) = DBParametro_Montar("CD_PROCEDENCIA", Nothing)
        End If
        If ComboBox_LinhaSelecionada(cboTipoCacau) Then
            Parametro(9) = DBParametro_Montar("CD_TIPO_CACAU", cboTipoCacau.SelectedValue)
        Else
            Parametro(9) = DBParametro_Montar("CD_TIPO_CACAU", Nothing)
        End If
        If IsDate(txtDataNF.Value) Then
            Parametro(10) = DBParametro_Montar("DT_NOTA_FISCAL", Date_to_Oracle(txtDataNF.Text), OracleClient.OracleType.DateTime)
        Else
            Parametro(10) = DBParametro_Montar("DT_NOTA_FISCAL", Nothing)
        End If
        Parametro(11) = DBParametro_Montar("SQ_MOVIMENTACAO", SQ_Movimentacao)
        If Not DBExecutar(SqlText, Parametro) Then GoTo Erro

        Msg_Mensagem("Atualização realizada com sucesso.")

        Close()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub
End Class