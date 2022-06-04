Public Class frmCadastroArmazem
    Dim CD_ARMAZEM As Integer

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub frmCadastroArmazem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CD_ARMAZEM = Filtro

        ComboBox_Carregar_Filial(cboFilial)

        With lstModalidadeTransferencia
            .DataSource = DBQuery("SELECT CD_TRANSFERENCIA_MODALIDADE, NO_TRANSFERENCIA_MODALIDADE FROM SOF.TRANSFERENCIA_MODALIDADE ORDER BY NO_TRANSFERENCIA_MODALIDADE")
            .ValueMember = "CD_TRANSFERENCIA_MODALIDADE"
            .DisplayMember = "NO_TRANSFERENCIA_MODALIDADE"
        End With

        If CD_ARMAZEM > 0 Then
            CarregarDados()
        End If
    End Sub

    Private Sub CarregarDados()
        Dim oData As DataTable
        Dim SqlText As String
        Dim iCont As Integer

        SqlText = "SELECT * FROM SOF.ARMAZEM WHERE CD_ARMAZEM = " & CD_ARMAZEM
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            With oData.Rows(0)
                txtCodigo.Text = NVL(.Item("COD_ARMAZEM"), "")
                txtNome.Text = .Item("NO_ARMAZEM")
                txtCapacidade.Value = NVL(.Item("QT_CAPACIDADE"), 0)
                ComboBox_Possicionar(cboFilial, .Item("CD_FILIAL_ORIGEM"))
                chkArmazemInterno.Checked = (NVL(.Item("IC_ARMAZEMINTERNO"), "N") = "S")
                chkAtivo.Checked = (NVL(.Item("IC_ATIVO"), "N") = "S")
            End With

            SqlText = "SELECT CD_TRANSFERENCIA_MODALIDADE FROM SOF.TRANSF_MODALIDADE_ARMAZEM" & _
                      " WHERE CD_ARMAZEM  = " & CD_ARMAZEM
            oData = DBQuery(SqlText)

            For iCont = 0 To oData.Rows.Count - 1
                With oData.Rows(iCont)
                    CheckListBox_Possicionar(lstModalidadeTransferencia, .Item("CD_TRANSFERENCIA_MODALIDADE"))
                End With
            Next
        End If

        objData_Finalizar(oData)
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String
        Dim iCont As Integer
        Dim Aux As String = ""

        If Not ComboBox_LinhaSelecionada(cboFilial) Then
            Msg_Mensagem("Selecione a filial de origem")
            Exit Sub
        End If
        If Trim(txtNome.Text) = "" Then
            Msg_Mensagem("Informe o nome do armazém")
            Exit Sub
        End If

        If CD_ARMAZEM = 0 Then
            CD_ARMAZEM = DBNumeroMaisUm("SOF.ARMAZEM", "CD_ARMAZEM")

            SqlText = DBMontar_Insert("SOF.ARMAZEM", TipoCampoFixo.Todos, _
                                                     "COD_ARMAZEM", ":COD_ARMAZEM", _
                                                     "NO_ARMAZEM", ":NO_ARMAZEM", _
                                                     "CD_FILIAL_ORIGEM", ":CD_FILIAL_ORIGEM", _
                                                     "QT_CAPACIDADE", ":QT_CAPACIDADE", _
                                                     "IC_ARMAZEMINTERNO", ":IC_ARMAZEMINTERNO", _
                                                     "IC_ATIVO", ":IC_ATIVO", _
                                                     "CD_ARMAZEM", ":CD_ARMAZEM")
        Else
            SqlText = DBMontar_Update("SOF.ARMAZEM", GerarArray("COD_ARMAZEM", ":COD_ARMAZEM", _
                                                                "NO_ARMAZEM", ":NO_ARMAZEM", _
                                                                "CD_FILIAL_ORIGEM", ":CD_FILIAL_ORIGEM", _
                                                                "QT_CAPACIDADE", ":QT_CAPACIDADE", _
                                                                "IC_ARMAZEMINTERNO", ":IC_ARMAZEMINTERNO", _
                                                                "IC_ATIVO", ":IC_ATIVO"), _
                                                     GerarArray("CD_ARMAZEM", ":CD_ARMAZEM"))
        End If

        If Not DBExecutar(SqlText, DBParametro_Montar("COD_ARMAZEM", txtCodigo.Text), _
                                   DBParametro_Montar("NO_ARMAZEM", txtNome.Text), _
                                   DBParametro_Montar("CD_FILIAL_ORIGEM", cboFilial.SelectedValue), _
                                   DBParametro_Montar("QT_CAPACIDADE", txtCapacidade.Value), _
                                   DBParametro_Montar("IC_ARMAZEMINTERNO", IIf(chkArmazemInterno.Checked, "S", "N")), _
                                   DBParametro_Montar("IC_ATIVO", IIf(chkAtivo.Checked, "S", "N")), _
                                   DBParametro_Montar("CD_ARMAZEM", CD_ARMAZEM)) Then GoTo Erro

        For iCont = 0 To lstModalidadeTransferencia.CheckedItems.Count - 1
            SqlText = "SELECT COUNT(*) FROM SOF.TRANSF_MODALIDADE_ARMAZEM" & _
                      " WHERE CD_ARMAZEM = " & CD_ARMAZEM & _
                        " AND CD_TRANSFERENCIA_MODALIDADE = " & lstModalidadeTransferencia.CheckedItems(iCont)(0)

            If DBQuery_ValorUnico(SqlText) = 0 Then
                SqlText = DBMontar_Insert("SOF.TRANSF_MODALIDADE_ARMAZEM", TipoCampoFixo.Todos, _
                                                                           "CD_TRANSFERENCIA_MODALIDADE", ":CD_TRANSFERENCIA_MODALIDADE", _
                                                                           "CD_ARMAZEM", ":CD_ARMAZEM")
                If Not DBExecutar(SqlText, DBParametro_Montar("CD_TRANSFERENCIA_MODALIDADE", lstModalidadeTransferencia.CheckedItems(iCont)(0)), _
                                           DBParametro_Montar("CD_ARMAZEM", CD_ARMAZEM)) Then GoTo Erro
            End If

            Str_Adicionar(Aux, lstModalidadeTransferencia.CheckedItems(iCont)(0), ",")
        Next

        If Trim(Aux) <> "" Then
            SqlText = "DELETE FROM SOF.TRANSF_MODALIDADE_ARMAZEM" & _
                      " WHERE CD_ARMAZEM = " & CD_ARMAZEM & _
                        " AND CD_TRANSFERENCIA_MODALIDADE NOT IN (" & Aux & ")"
            If Not DBExecutar(SqlText) Then GoTo Erro
        End If

        Msg_Mensagem("Gravação Efetuada")

        Exit Sub

Erro:
        TratarErro(, , "frmCadastroArmazem.cmdGravar_Click")
    End Sub

    Private Sub cmdPilha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPilha.Click
        Filtro = CD_ARMAZEM
        Form_Show(Me.MdiParent, frmCadastroArmazem_Pilha, True, True)
    End Sub
End Class