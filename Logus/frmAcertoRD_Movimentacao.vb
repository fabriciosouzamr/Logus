Public Class frmAcertoRD_Movimentacao
    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmAcertoRD_Movimentacao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_TipoMovimentacao.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_TipoMovimentacao
        Pesq_TipoMovimentacao.BancoDados_Filtro_Limpar()
        Pesq_TipoMovimentacao.BancoDados_Filtro_Adicionar("IC_ATIVO = 'S'")

        Pesq_CodigoNome.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        chkFornecedor_CheckedChanged(Nothing, Nothing)
        ComboBox_Carregar_Qualidade(cboQualidade, True)
    End Sub

    Private Sub chkFornecedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFornecedor.CheckedChanged
        If chkFornecedor.Checked = True Then
            Pesq_CodigoNome.Enabled = True
            cboQualidade.Enabled = True
        Else
            Pesq_CodigoNome.Codigo = 0
            Pesq_CodigoNome.Enabled = False
            cboQualidade.Enabled = False
            ComboBox_Possicionar(cboQualidade, -1)
        End If
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String
        Dim Parametro(3) As DBParamentro

        If Pesq_TipoMovimentacao.Codigo < 1 Then
            Msg_Mensagem("Favor escolher um tipo de movimentação valida.")
            Pesq_TipoMovimentacao.Focus()
            Exit Sub
        End If
        If txtValor.Value = 0 And txtValorICMS.Value = 0 And txtValorINSS.Value = 0 And _
          txtQuantidade.Value = 0 Then
            Msg_Mensagem("Os valores estão zerados.")
            txtValor.Focus()
            Exit Sub
        End If
        If chkFornecedor.Checked = True Then
            If Pesq_CodigoNome.Codigo < 1 Then
                Msg_Mensagem("Favor selecionar um fornecedor valido.")
                Pesq_CodigoNome.Focus()
                Exit Sub
            End If
        End If
        If txtDescricao.Text = "" Then
            Msg_Mensagem("Favor informar o motivo do acerto.")
            txtDescricao.Focus()
            Exit Sub
        End If
        If FilialFechada(FilialLogada) Then
            Msg_Mensagem("A Filial está fechada. No momento não é possivel realizar a operação.")
            Exit Sub
        End If

        DBUsarTransacao = True

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

        If Not DBExecutar(SqlText, DBParametro_Montar("FORN", IIf(chkFornecedor.Checked, Pesq_CodigoNome.Codigo, Nothing)), _
                                   DBParametro_Montar("TPMOV", Pesq_TipoMovimentacao.Codigo), _
                                   DBParametro_Montar("FILMOV", FilialLogada), _
                                   DBParametro_Montar("DATA", Date_to_Oracle(DataSistema), OracleClient.OracleType.DateTime), _
                                   DBParametro_Montar("NF", "ACERTO"), _
                                   DBParametro_Montar("VLNF", txtValor.Value), _
                                   DBParametro_Montar("VLICMS", txtValorICMS.Value), _
                                   DBParametro_Montar("VLFUN", txtValorINSS.Value), _
                                   DBParametro_Montar("KGLIQ", txtQuantidade.Value), _
                                   DBParametro_Montar("TIPOCACAU", IIf(cboQualidade.Enabled, cboQualidade.SelectedValue, Nothing)), _
                                   DBParametro_Montar("DSACERTO", txtDescricao.Text, OracleClient.OracleType.VarChar, , 4000), _
                                   DBParametro_Montar("P_MOV", Nothing, , ParameterDirection.Output)) Then GoTo Erro

        SqlText = DBMontar_Insert("SOF.MOVIMENTACAO_ACERTO", TipoCampoFixo.DadoCriacao, _
                                                             "SQ_MOVIMENTACAO", ":SQ_MOVIMENTACAO", _
                                                             "DS_ACERTO", ":DS_ACERTO")

        If Not DBExecutar(SqlText, DBParametro_Montar("SQ_MOVIMENTACAO", DBRetorno(1)), _
                                   DBParametro_Montar("DS_ACERTO", txtDescricao.Text, OracleClient.OracleType.VarChar, , 4000)) Then GoTo Erro

        If Not DBExecutarTransacao() Then GoTo Erro

        chkFornecedor.Checked = False
        Pesq_TipoMovimentacao.Codigo = 0
        txtValor.Value = 0
        txtValorICMS.Value = 0
        txtValorINSS.Value = 0
        txtQuantidade.Value = 0
        ComboBox_Possicionar(cboQualidade, -1)
        txtDescricao.Text = ""

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub Pesq_TipoMovimentacao_AlterouRegistro() Handles Pesq_TipoMovimentacao.AlterouRegistro
        txtValor.Enabled = True
        txtQuantidade.Enabled = True

        If DBQuery_ValorUnico("SELECT IC_ACERTO_ICMS FROM SOF.TIPO_MOVIMENTACAO WHERE CD_TIPO_MOVIMENTACAO = " & Pesq_TipoMovimentacao.Codigo) = "S" Then
            txtValor.Enabled = False
            txtValor.Value = 0
            txtQuantidade.Enabled = False
            txtQuantidade.Value = 0
        End If
    End Sub
End Class