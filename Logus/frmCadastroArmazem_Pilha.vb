Public Class frmCadastroArmazem_Pilha
    Dim CD_ARMAZEM As Integer
    Dim CD_PILHA As Integer

    Private Sub chkPilhaMae_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Edicao_PilhaMae_Habilitar(chkPilhaMae.Checked)
    End Sub

    Private Sub Novo()
        CD_PILHA = 0

        txtPilha.Value = Nothing
        txtSacos.Value = 0
        chkAtivo.Checked = False
        cboTipoPilha.SelectedIndex = -1

        'Pilha Mãe
        cboPilhaMae.SelectedIndex = -1
        lblNomePilha.Text = ""
        chkPilhaMae.Checked = False
        chkPilhaMae_CheckedChanged(Nothing, Nothing)
    End Sub

    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        Novo()
        chkAtivo.Checked = True
        lstPilhas.SelectedItems.Clear()
        Edicao_Habilitar(True)
    End Sub

    Private Sub frmCadastroArmazem_Pilha_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlText As String

        CD_ARMAZEM = Filtro

        SqlText = "SELECT NO_ARMAZEM FROM SOF.ARMAZEM WHERE CD_ARMAZEM = " & CD_ARMAZEM
        txtNomeArmazem.Text = DBQuery_ValorUnico(SqlText)

        ComboBox_Carregar_Tipo_Fornecedor_Pessoa(cboTipoPilha, False)

        SqlText = "SELECT CD_PILHA, CAST(CD_PILHA AS VARCHAR2(10)) NO_PILHA FROM " & View_ARMAZEM_PILHA_LASTRO() & " WHERE CD_PILHA_MAE IS NULL"
        DBCarregarComboBox(cboPilhaMae, SqlText, True)

        Novo()
        CarregarDados()
    End Sub

    Private Sub CarregarDados()
        Dim SqlText As String

        SqlText = "SELECT CD_PILHA, CD_PILHA_FILHA" & _
                  " FROM " & View_ARMAZEM_PILHA_LASTRO() & _
                  " WHERE CD_ARMAZEM = " & CD_ARMAZEM & _
                  " ORDER BY CD_PILHA_FILHA"

        With lstPilhas
            .DataSource = DBQuery(SqlText)
            .ValueMember = "CD_PILHA"
            .DisplayMember = "CD_PILHA_FILHA"
        End With
    End Sub

    Private Sub Edicao_Habilitar(ByVal bHabilitar As Boolean)
        lblR_Pilha.Enabled = bHabilitar
        txtPilha.Enabled = bHabilitar
        lblR_QtdeSacos.Enabled = bHabilitar
        txtSacos.Enabled = bHabilitar
        chkAtivo.Enabled = bHabilitar
        lblR_TipoPilha.Enabled = bHabilitar
        cboTipoPilha.Enabled = bHabilitar
        chkPilhaMae.Enabled = bHabilitar
        'Pilha Mãe
        Edicao_PilhaMae_Habilitar(chkPilhaMae.Checked)
    End Sub

    Private Sub Edicao_PilhaMae_Habilitar(ByVal bHabilitar As Boolean)
        grpPilhaMae.Enabled = bHabilitar
        cboPilhaMae.Enabled = bHabilitar
        lblR_NomePilha.Enabled = bHabilitar
        lblNomePilha.Enabled = bHabilitar
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String
        Dim NO_PILHA As Integer

        If txtPilha.Value < 1 Then
            Msg_Mensagem("Informe o número da pilha")
            Exit Sub
        End If
        If txtSacos.Value <= 1 And Not chkPilhaMae.Checked Then
            Msg_Mensagem("Informe a quantidade máxima de saco na pilha")
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboTipoPilha) Then
            Msg_Mensagem("Selecione o tipo de pilha")
            Exit Sub
        End If

        If CD_PILHA = 0 Then
            If ComboBox_LinhaSelecionada(cboPilhaMae) Then
                CD_PILHA = cboPilhaMae.SelectedValue + txtPilha.Value
                NO_PILHA = txtNomeArmazem.Text & " - " & cboPilhaMae.SelectedValue + (txtPilha.Value / 10)
            Else
                CD_PILHA = txtPilha.Value
                NO_PILHA = txtNomeArmazem.Text & " - " & CD_PILHA
            End If

            SqlText = DBMontar_Insert("SOF.ARMAZEM_PILHA_LASTRO", TipoCampoFixo.Todos, "SQ_TIPO_ENDERECO_ARMAZEM", ":SQ_TIPO_ENDERECO_ARMAZEM", _
                                                                                       "NR_PILHA_FILHA", ":NR_PILHA_FILHA", _
                                                                                       "QT_LASTRO", ":QT_LASTRO", _
                                                                                       "NO_PILHA", ":NO_PILHA", _
                                                                                       "QT_SACOS", ":QT_SACOS", _
                                                                                       "CD_PILHA_MAE", ":CD_PILHA_MAE", _
                                                                                       "CD_ARMAZEM", ":CD_ARMAZEM", " AND ", _
                                                                                       "CD_PILHA", ":CD_PILHA")
        Else
            SqlText = DBMontar_Update("SOF.ARMAZEM_PILHA_LASTRO", GerarArray("SQ_TIPO_ENDERECO_ARMAZEM", ":SQ_TIPO_ENDERECO_ARMAZEM", _
                                                                             "NR_PILHA_FILHA", ":NR_PILHA_FILHA", _
                                                                             "QT_LASTRO", ":QT_LASTRO", _
                                                                             "NO_PILHA", ":NO_PILHA", _
                                                                             "QT_SACOS", ":QT_SACOS", _
                                                                             "CD_PILHA_MAE", ":CD_PILHA_MAE"), _
                                                                  GerarArray("CD_ARMAZEM", ":CD_ARMAZEM", " AND ", _
                                                                             "CD_PILHA", ":CD_PILHA"))
        End If

        SqlText = DBMontar_SP("SOF.SP_ARMAZEM_PILHA_LASTRO", False, ":CD_ARMAZEM", _
                                                                    ":CD_PILHA", _
                                                                    ":QT_LASTRO", _
                                                                    ":NO_PILHA", _
                                                                    ":QT_SACOS", _
                                                                    ":SQ_TIPO_ENDERECO_ARMAZEM")

        If Not DBExecutar(SqlText, DBParametro_Montar("CD_ARMAZEM", CD_ARMAZEM), _
                                   DBParametro_Montar("CD_PILHA", CD_PILHA), _
                                   DBParametro_Montar("QT_LASTRO", 1), _
                                   DBParametro_Montar("NO_PILHA", NO_PILHA), _
                                   DBParametro_Montar("QT_SACOS", txtSacos.Value), _
                                   DBParametro_Montar("SQ_TIPO_ENDERECO_ARMAZEM", cboTipoPilha.SelectedValue)) Then GoTo Erro

        SqlText = DBMontar_Update("SOF.SP_ARMAZEM_PILHA_LASTRO", GerarArray("CD_PILHA_MAE", ":CD_PILHA_MAE", _
                                                                            "NR_PILHA_FILHA", ":NR_PILHA_FILHA", _
                                                                            "IC_ATIVO", ":IC_ATIVO"), _
                                                                 GerarArray("CD_ARMAZEM", ":CD_ARMAZEM", " AND ", _
                                                                            "CD_PILHA", ":CD_PILHA"))

        If Not DBExecutar(SqlText, DBParametro_Montar("CD_PILHA_MAE", If(chkPilhaMae.Checked, cboPilhaMae.SelectedValue, Nothing)), _
                                   DBParametro_Montar("NR_PILHA_FILHA", If(chkPilhaMae.Checked, txtPilha.Value, Nothing)), _
                                   DBParametro_Montar("CD_ARMAZEM", CD_ARMAZEM), _
                                   DBParametro_Montar("CD_PILHA", CD_PILHA)) Then GoTo Erro

        Msg_Mensagem("Gravação Efetuada")

        Novo()
        CarregarDados()

        Exit Sub

Erro:
        TratarErro(, , "frmCadastroArmazem_Pilha.cmdGravar_Click")
    End Sub

    Private Sub lstPilhas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstPilhas.SelectedIndexChanged
        Dim oData As DataTable
        Dim SqlText As String

        If lstPilhas.SelectedItems.Count > 0 Then
            SqlText = "SELECT * FROM " & View_ARMAZEM_PILHA_LASTRO() & _
                      " WHERE CD_ARMAZEM = " & CD_ARMAZEM & _
                        " AND CD_PILHA = " & lstPilhas.SelectedItems(0)(0)
            oData = DBQuery(SqlText)

            If Not objDataTable_Vazio(oData) Then
                With oData.Rows(0)
                    txtPilha.Value = NVL(.Item("NR_PILHA_FILHA"), .Item("CD_PILHA"))
                    txtSacos.Value = .Item("QT_SACOS")
                    chkAtivo.Checked = (.Item("IC_ATIVO") = "S")
                    ComboBox_Possicionar(cboTipoPilha, .Item("SQ_TIPO_ENDERECO_ARMAZEM"))

                    If Not CampoNulo(.Item("CD_PILHA_MAE")) Then
                        chkPilhaMae.Checked = True
                        ComboBox_Possicionar(cboPilhaMae, .Item("CD_PILHA_MAE"))
                        lblNomePilha.Text = .Item("CD_PILHA_FILHA")
                    End If
                End With
            End If
        End If
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        If lstPilhas.SelectedItems.Count > 0 Then
            Dim SqlText As String

            SqlText = "DELETE FROM SOF.ARMAZEM_PILHA_LASTRO" & _
                      " WHERE CD_ARMAZEM = " & CD_ARMAZEM & _
                        " AND CD_PILHA = " & CD_PILHA
            If Not DBExecutar(SqlText) Then GoTo Erro
        End If

        Exit Sub

Erro:
        TratarErro(, , "frmCadastroArmazem_Pilha.cmdExcluir_Click")
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub
End Class