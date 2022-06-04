Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmCadastroGarantia
    Const cnt_GridGeral_Codigo = 0
    Const cnt_GridGeral_CheckBox = 1
    Const cnt_GridGeral_NomeFornecedor = 2

    Dim oDS As New UltraWinDataSource.UltraDataSource
    Public SQ_GARANTIA As Long

    Private Sub frmCadastroGarantia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox_Carregar_Moeda(cboMoeda)
        ComboBox_Carregar_Tipo_Garantia(cboTipoGarantia, True)

        Pesq_Repassador.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect)
        objGrid_Coluna_Add(grdGeral, "Código", 0)
        objGrid_Coluna_Add(grdGeral, " ", 30, , True, ColumnStyle.CheckBox)
        objGrid_Coluna_Add(grdGeral, "Fornecedor", 200)

        lblStatus.Text = ""

        If SQ_GARANTIA > 0 Then
            CarregarGarantia()
        End If
    End Sub

    Private Sub Pesq_Repassador_AlterouRegistro() Handles Pesq_Repassador.AlterouRegistro
        Dim SqlText As String

        If Pesq_Repassador.Codigo <= 0 Then Exit Sub

        SqlText = "SELECT COUNT(*)" & _
                  " FROM SOF.FORNECEDOR" & _
                  " WHERE CD_FORNECEDOR = " & Pesq_Repassador.Codigo & _
                    " AND CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        If DBQuery_ValorUnico(SqlText) = 0 Then
            Msg_Mensagem("Este repassador não pertence a nenhuma das filiais nas quais você tem acesso.")
            Exit Sub
        End If

        SqlText = "SELECT CD_FORNECEDOR," & _
                         "0 SELECIONADO," & _
                         "NO_RAZAO_SOCIAL" & _
                  " FROM SOF.FORNECEDOR" & _
                  " WHERE CD_REPASSADOR = " & Pesq_Repassador.Codigo
        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_Codigo, _
                                                           cnt_GridGeral_CheckBox, _
                                                           cnt_GridGeral_NomeFornecedor})
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String
        Dim iCont As Integer
        Dim oParametro(6) As DBParamentro

        If Pesq_Repassador.Codigo <= 0 Then
            Msg_Mensagem("Favor informar um repassador ou fornecedor valido.")
            Pesq_Repassador.Focus()
            Exit Sub
        End If
        If rctDescricao.Text = "" Then
            Msg_Mensagem("Favor informar uma descrição da garantia")
            rctDescricao.Focus()
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboMoeda) Then
            Msg_Mensagem("Favor informar um tipo de moeda.")
            cboMoeda.Focus()
            Exit Sub
        End If
        If txtValorGarantia.Value <= 0 Then
            Msg_Mensagem("Favor informar um valor da garantia.")
            txtValorGarantia.Focus()
            Exit Sub
        End If
        If txtValorCreditoMaximo.Value <= 0 Then
            Msg_Mensagem("Favor informar um valor de crédito máximo.")
            txtValorCreditoMaximo.Focus()
            Exit Sub
        End If
        If Not IsDate(txtDataValidade.Text) Then
            Msg_Mensagem("Informe uma data de validade válida.")
            Exit Sub
        End If
        If CDate(txtDataValidade.Text) < CDate(DataSistema()) Then
            Msg_Mensagem("A data de validade da garantia não pode ser inferior a " & DataSistema())
            txtDataValidade.Focus()
            Exit Sub
        End If

        DBUsarTransacao = True

        If SQ_GARANTIA = 0 Then
            SQ_GARANTIA = DBNumeroMaisUm("SOF.GARANTIA", "SQ_GARANTIA")

            SqlText = DBMontar_Insert("SOF.GARANTIA", TipoCampoFixo.Todos, "IC_MOEDA_GARANTIA", ":IC_MOEDA_GARANTIA", _
                                                                           "VL_GARANTIA", ":VL_GARANTIA", _
                                                                           "CD_TIPO_GARANTIA", ":CD_TIPO_GARANTIA", _
                                                                           "DT_GARANTIA_VALIDADE", ":DT_GARANTIA_VALIDADE", _
                                                                           "DS_DESCRICAO", ":DS_DESCRICAO", _
                                                                           "CD_TIPO_STATUS", "'A'", _
                                                                           "CD_REPASSADOR", ":CD_REPASSADOR", _
                                                                           "SQ_GARANTIA", ":SQ_GARANTIA")
        Else
            SqlText = DBMontar_Update("SOF.GARANTIA", GerarArray("IC_MOEDA_GARANTIA", ":IC_MOEDA_GARANTIA", _
                                                                 "VL_GARANTIA", ":VL_GARANTIA", _
                                                                 "CD_TIPO_GARANTIA", ":CD_TIPO_GARANTIA", _
                                                                 "DT_GARANTIA_VALIDADE", ":DT_GARANTIA_VALIDADE", _
                                                                 "DS_DESCRICAO", ":DS_DESCRICAO", _
                                                                 "CD_REPASSADOR", ":CD_REPASSADOR"), _
                                                      GerarArray("SQ_GARANTIA", ":SQ_GARANTIA"))
        End If

        oParametro(0) = DBParametro_Montar("IC_MOEDA_GARANTIA", cboMoeda.SelectedValue)
        oParametro(1) = DBParametro_Montar("VL_GARANTIA", txtValorGarantia.Value)
        oParametro(2) = DBParametro_Montar("CD_TIPO_GARANTIA", cboTipoGarantia.SelectedValue)
        oParametro(3) = DBParametro_Montar("DT_GARANTIA_VALIDADE", Date_to_Oracle(txtDataValidade.Text), DbType.DateTime)
        oParametro(4) = DBParametro_Montar("DS_DESCRICAO", rctDescricao.Text, OracleClient.OracleType.VarChar, , 4000)
        oParametro(5) = DBParametro_Montar("CD_REPASSADOR", Pesq_Repassador.Codigo)
        oParametro(6) = DBParametro_Montar("SQ_GARANTIA", SQ_GARANTIA)

        If Not DBExecutar(SqlText, oParametro) Then GoTo Erro

        SqlText = "DELETE FROM SOF.GARANTIA_FORNECEDOR" & _
                  " WHERE SQ_GARANTIA = " & SQ_GARANTIA
        If Not DBExecutar(SqlText) Then GoTo Erro

        'Inclui o repassador
        SqlText = DBMontar_Insert("SOF.GARANTIA_FORNECEDOR", TipoCampoFixo.DadoCriacao, _
                                                             "CD_FORNECEDOR", ":CD_FORNECEDOR", _
                                                             "SQ_GARANTIA", ":SQ_GARANTIA")

        If Not DBExecutar(SqlText, DBParametro_Montar("CD_FORNECEDOR", Pesq_Repassador.Codigo), _
                                   DBParametro_Montar("SQ_GARANTIA", SQ_GARANTIA)) Then GoTo Erro

        'Inclui os fornecedores
        For iCont = 0 To grdGeral.Rows.Count - 1
            If objGrid_CheckBox_Selecionado(grdGeral, cnt_GridGeral_CheckBox, iCont) Then
                SqlText = DBMontar_Insert("SOF.GARANTIA_FORNECEDOR", TipoCampoFixo.DadoCriacao, _
                                                                     "CD_FORNECEDOR", ":CD_FORNECEDOR", _
                                                                     "SQ_GARANTIA", ":SQ_GARANTIA")

                If Not DBExecutar(SqlText, DBParametro_Montar("CD_FORNECEDOR", objGrid_Valor(grdGeral, cnt_GridGeral_Codigo, iCont)), _
                                           DBParametro_Montar("SQ_GARANTIA", SQ_GARANTIA)) Then GoTo Erro
            End If
        Next

        If Not DBExecutarTransacao() Then GoTo Erro

        Close()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub CarregarGarantia()
        Dim oData As DataTable
        Dim SqlText As String
        Dim iCont_01 As Integer
        Dim iCont_02 As Integer

        SqlText = "SELECT IC_MOEDA_GARANTIA," & _
                         "VL_GARANTIA," & _
                         "CD_TIPO_GARANTIA," & _
                         "DT_GARANTIA_VALIDADE," & _
                         "DS_DESCRICAO," & _
                         "CD_TIPO_STATUS," & _
                         "CD_REPASSADOR," & _
                         "VL_CREDITO_MAXIMO" & _
                  " FROM SOF.GARANTIA" & _
                  " WHERE SQ_GARANTIA = " & SQ_GARANTIA
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            With oData.Rows(0)
                ComboBox_Possicionar(cboMoeda, NVL(.Item("IC_MOEDA_GARANTIA"), ""))
                txtValorGarantia.Value = NVL(.Item("VL_GARANTIA"), 0)
                ComboBox_Possicionar(cboTipoGarantia, .Item("CD_TIPO_GARANTIA"))
                If IsDate(.Item("DT_GARANTIA_VALIDADE")) Then
                    txtDataValidade.Text = .Item("DT_GARANTIA_VALIDADE")
                Else
                    txtDataValidade.Text = ""
                End If
                rctDescricao.Text = NVL(.Item("DS_DESCRICAO"), "")
                lblStatus.Text = "Status: " & .Item("CD_TIPO_STATUS")
                Pesq_Repassador.Codigo = NVL(.Item("CD_REPASSADOR"), 0)
                Pesq_Repassador_AlterouRegistro()
                txtValorCreditoMaximo.Value = NVL(.Item("VL_CREDITO_MAXIMO"), 0)
            End With
        End If

        SqlText = "SELECT GF.CD_FORNECEDOR," & _
                         "FN.NO_RAZAO_SOCIAL" & _
                  " FROM SOF.GARANTIA_FORNECEDOR GF," & _
                        "SOF.FORNECEDOR FN" & _
                  " WHERE GF.SQ_GARANTIA = " & SQ_GARANTIA & _
                    " AND FN.CD_FORNECEDOR = GF.CD_FORNECEDOR" & _
                    " AND FN.CD_FORNECEDOR NOT IN (" & Pesq_Repassador.Codigo & ")"
        oData = DBQuery(SqlText)

        For iCont_01 = 0 To oData.Rows.Count - 1
            For iCont_02 = 0 To grdGeral.Rows.Count - 1
                If objGrid_Valor(grdGeral, cnt_GridGeral_Codigo, iCont_02) = _
                   oData.Rows(iCont_01).Item("CD_FORNECEDOR") Then
                    grdGeral.Rows(iCont_02).Cells(cnt_GridGeral_CheckBox).Value = True
                    Exit For
                End If
            Next
        Next
    End Sub
End Class