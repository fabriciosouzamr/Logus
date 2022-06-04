Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmCadastroTipoFretistaTributacao

    Dim ControleEdicaoTelaLocal As eControleEdicaoTela
    Dim CdTipoFretistaTributacao As Integer

    Const cnt_GridGeral_Sequencia As Integer = 0
    Const cnt_GridGeral_RendaMinima As Integer = 1
    Const cnt_GridGeral_RendaMaxima As Integer = 2
    Const cnt_GridGeral_Aliquota As Integer = 3
    Const cnt_GridGeral_Deducao As Integer = 4

    Const cnt_SEC_Tela As String = "Cadastro_Administrativo_TipoFretistaTributacao"

    Dim oDS As New UltraWinDataSource.UltraDataSource

    Private Sub frmCadastroTipoFretistaTributacao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox_Carregar_Provisao(cboProvisao, True)
        ComboBox_Carregar_Tipo_Fretista_Tributacao(cboTributoDeducao, True)
        ListBox_Carregar_Tipo_Fretista(lstTipoFretista)

        ControleEdicaoTelaLocal = ControleEdicaoTela
        CdTipoFretistaTributacao = Filtro

        objGrid_Inicializar(grdGeral, AllowAddNew.FixedAddRowOnTop, oDS, CellClickAction.EditAndSelectText)
        objGrid_Coluna_Add(grdGeral, "Sequência", 60)
        objGrid_Coluna_Add(grdGeral, "Renda Minimo", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Renda Maxima", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Aliquota", 100)
        objGrid_Coluna_Add(grdGeral, "Dedução", 100, , , , , cnt_Formato_Valor)

        cmdGravar.Visible = SEC_ValidarAcessoInterno(cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao) Or _
                            SEC_ValidarAcessoInterno(cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao)

        grdGeral.DisplayLayout.Bands(0).Override.AllowDelete = DefaultableBoolean.True

        If ControleEdicaoTelaLocal = eControleEdicaoTela.ALTERAR Then
            CarregarDados()
        End If
    End Sub

    Private Sub CarregarDados()
        Dim SqlText As String
        Dim oData As DataTable
        Dim iCont As Integer


        SqlText = "select * from sof.tipo_fretista_tributacao where cd_tipo_fretista_tributacao=" & CdTipoFretistaTributacao
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            txtDescricao.Text = oData.Rows(0).Item("no_tipo_fretista_tributacao")
            txtBaseCalculo.Value = oData.Rows(0).Item("pc_base_calculo")
            txtDeducaoDependente.Value = oData.Rows(0).Item("vl_deducao_dependente")
            ComboBox_Possicionar(cboProvisao, oData.Rows(0).Item("cd_provisao"))
            txtValorMaximo.Value = oData.Rows(0).Item("vl_teto_tributacao")
            txtValorMinimo.Value = oData.Rows(0).Item("VL_MINIMO_TRIBUTACAO")
            ComboBox_Possicionar(cboTributoDeducao, oData.Rows(0).Item("cd_tributo_deducao"))
            txtSequencia.Value = oData.Rows(0).Item("nu_sequencia")
            chkISS.Checked = IIf(oData.Rows(0).Item("ic_iss") = "S", True, False)


            SqlText = "select cd_tipo_fretista from sof.tipo_fretista_tributos where cd_tipo_fretista_tributacao=" & CdTipoFretistaTributacao

            oData = DBQuery(SqlText)

            For iCont = 0 To oData.Rows.Count - 1
                CheckListBox_Possicionar(lstTipoFretista, oData.Rows(iCont).Item("cd_tipo_fretista"))
            Next

            '>> Grid 
            SqlText = "SELECT TFTT.SQ_TP_FRETISTA_TRIBUTACAO_TBL, TFTT.VL_RENDA_MINIMA, " & _
            "TFTT.VL_RENDA_MAXIMA, TFTT.PC_ALIQUOTA_TRIBUTACAO, TFTT.VL_DEDUCAO " & _
            "FROM SOF.TIPO_FRETISTA_TRIBUTACAO_TBL TFTT " & _
            "where cd_tipo_fretista_tributacao = " & CdTipoFretistaTributacao & " " & _
            "order by TFTT.SQ_TP_FRETISTA_TRIBUTACAO_TBL"
            objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_Sequencia, _
                                                                cnt_GridGeral_RendaMinima, _
                                                                cnt_GridGeral_RendaMaxima, _
                                                                cnt_GridGeral_Aliquota, _
                                                                cnt_GridGeral_Deducao})
        End If
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim iCont As Integer
        Dim SqlText As String
        Dim Parametro(10) As DBParamentro

        If txtDescricao.Text = "" Then
            Msg_Mensagem("Favor informar uma descrição")
            txtDescricao.Focus()
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboProvisao) Then
            Msg_Mensagem("Favor selecionar um tipo de provisão.")
            cboProvisao.Focus()
            Exit Sub
        End If

        If chkISS.Checked = False Then
            If txtBaseCalculo.Value = 0 Then
                Msg_Mensagem("Favor informar uma base de calculo.")
                txtBaseCalculo.Focus()
                Exit Sub
            End If

            If lstTipoFretista.CheckedItems.Count = 0 Then
                Msg_Mensagem("Favor selecionar um tipo de fretista.")
                Exit Sub
            End If

            If grdGeral.Rows.Count = 0 Then
                Msg_Mensagem("Favor informar uma tabela do tributo.")
                grdGeral.Focus()
                Exit Sub
            End If


            If txtSequencia.Value = 0 Then
                Msg_Mensagem("Favor informar um número de sequência.")
                txtSequencia.Focus()
                Exit Sub
            End If
        End If

        DBUsarTransacao = True


        If ControleEdicaoTelaLocal = eControleEdicaoTela.INCLUIR Then
            CdTipoFretistaTributacao = DBNumeroMaisUm("SOF.TIPO_FRETISTA_TRIBUTACAO", "CD_TIPO_FRETISTA_TRIBUTACAO")

            SqlText = DBMontar_Insert("SOF.TIPO_FRETISTA_TRIBUTACAO", TipoCampoFixo.Todos, "NO_TIPO_FRETISTA_TRIBUTACAO", ":NO_TIPO_FRETISTA_TRIBUTACAO", _
                                                                                        "PC_BASE_CALCULO", ":PC_BASE_CALCULO", _
                                                                                        "VL_DEDUCAO_DEPENDENTE", ":VL_DEDUCAO_DEPENDENTE", _
                                                                                        "CD_PROVISAO", ":CD_PROVISAO", _
                                                                                        "VL_TETO_TRIBUTACAO", ":VL_TETO_TRIBUTACAO", _
                                                                                        "IC_TABELA_TRIBUTACAO", ":IC_TABELA_TRIBUTACAO", _
                                                                                        "CD_TRIBUTO_DEDUCAO", ":CD_TRIBUTO_DEDUCAO", _
                                                                                        "NU_SEQUENCIA", ":NU_SEQUENCIA", _
                                                                                        "VL_MINIMO_TRIBUTACAO", ":VL_MINIMO_TRIBUTACAO", _
                                                                                        "IC_ISS", ":IC_ISS", _
                                                                           "CD_TIPO_FRETISTA_TRIBUTACAO", ":CD_TIPO_FRETISTA_TRIBUTACAO")
        Else
            SqlText = DBMontar_Update("SOF.TIPO_FRETISTA_TRIBUTACAO", GerarArray("NO_TIPO_FRETISTA_TRIBUTACAO", ":NO_TIPO_FRETISTA_TRIBUTACAO", _
                                                                                        "PC_BASE_CALCULO", ":PC_BASE_CALCULO", _
                                                                                        "VL_DEDUCAO_DEPENDENTE", ":VL_DEDUCAO_DEPENDENTE", _
                                                                                        "CD_PROVISAO", ":CD_PROVISAO", _
                                                                                        "VL_TETO_TRIBUTACAO", ":VL_TETO_TRIBUTACAO", _
                                                                                        "IC_TABELA_TRIBUTACAO", ":IC_TABELA_TRIBUTACAO", _
                                                                                        "CD_TRIBUTO_DEDUCAO", ":CD_TRIBUTO_DEDUCAO", _
                                                                                        "NU_SEQUENCIA", ":NU_SEQUENCIA", _
                                                                                        "VL_MINIMO_TRIBUTACAO", ":VL_MINIMO_TRIBUTACAO", _
                                                                                        "IC_ISS", ":IC_ISS"), _
                                                      GerarArray("CD_TIPO_FRETISTA_TRIBUTACAO", ":CD_TIPO_FRETISTA_TRIBUTACAO"))
        End If

        Parametro(0) = DBParametro_Montar("NO_TIPO_FRETISTA_TRIBUTACAO", txtDescricao.Text)
        Parametro(1) = DBParametro_Montar("PC_BASE_CALCULO", txtBaseCalculo.Value)
        Parametro(2) = DBParametro_Montar("VL_DEDUCAO_DEPENDENTE", txtDeducaoDependente.Value)
        Parametro(3) = DBParametro_Montar("CD_PROVISAO", cboProvisao.SelectedValue)
        Parametro(4) = DBParametro_Montar("VL_TETO_TRIBUTACAO", txtValorMaximo.Value)
        Parametro(5) = DBParametro_Montar("IC_TABELA_TRIBUTACAO", "S")
        If ComboBox_LinhaSelecionada(cboTributoDeducao) Then
            Parametro(6) = DBParametro_Montar("CD_TRIBUTO_DEDUCAO", cboTributoDeducao.SelectedValue)
        Else
            Parametro(6) = DBParametro_Montar("CD_TRIBUTO_DEDUCAO", Nothing)
        End If
        Parametro(7) = DBParametro_Montar("NU_SEQUENCIA", txtSequencia.Value)
        Parametro(8) = DBParametro_Montar("VL_MINIMO_TRIBUTACAO", txtValorMinimo.Value)
        Parametro(9) = DBParametro_Montar("IC_ISS", IIf(chkISS.Checked, "S", "N"))
        Parametro(10) = DBParametro_Montar("CD_TIPO_FRETISTA_TRIBUTACAO", CdTipoFretistaTributacao)


        If Not DBExecutar(SqlText, Parametro) Then GoTo Erro


        SqlText = "DELETE FROM SOF.TIPO_FRETISTA_TRIBUTOS WHERE CD_TIPO_FRETISTA_TRIBUTACAO=" & CdTipoFretistaTributacao
        If Not DBExecutar(SqlText) Then GoTo Erro

        If chkISS.Checked = False Then
            For iCont = 0 To lstTipoFretista.CheckedItems.Count - 1
                SqlText = "INSERT INTO SOF.TIPO_FRETISTA_TRIBUTOS " & _
                          "(CD_TIPO_FRETISTA, CD_TIPO_FRETISTA_TRIBUTACAO, DT_CRIACAO, NO_USER_CRIACAO) " & _
                          "VALUES (" & lstTipoFretista.CheckedItems(iCont)(0) & ", " & CdTipoFretistaTributacao & ", SYSDATE, '" & sAcesso_UsuarioLogado & "')"
                If Not DBExecutar(SqlText) Then GoTo Erro
            Next
        End If


        SqlText = "DELETE FROM SOF.TIPO_FRETISTA_TRIBUTACAO_TBL WHERE CD_TIPO_FRETISTA_TRIBUTACAO=" & CdTipoFretistaTributacao
        If Not DBExecutar(SqlText) Then GoTo Erro

        If chkISS.Checked = False Then

            For iCont = 0 To grdGeral.Rows.Count - 1
                SqlText = "INSERT INTO SOF.TIPO_FRETISTA_TRIBUTACAO_TBL " & _
                          "(CD_TIPO_FRETISTA_TRIBUTACAO, SQ_TP_FRETISTA_TRIBUTACAO_TBL, VL_RENDA_MINIMA, " & _
                          "VL_RENDA_MAXIMA, PC_ALIQUOTA_TRIBUTACAO, VL_DEDUCAO, DT_CRIACAO, NO_USER_CRIACAO) " & _
                          "VALUES (" & CdTipoFretistaTributacao & ", " & objGrid_Valor(grdGeral, cnt_GridGeral_Sequencia, iCont) & _
                          ", " & objGrid_Valor(grdGeral, cnt_GridGeral_RendaMinima, iCont) & ", " & objGrid_Valor(grdGeral, cnt_GridGeral_RendaMaxima, iCont) & _
                          ", " & objGrid_Valor(grdGeral, cnt_GridGeral_Aliquota, iCont) & ", " & objGrid_Valor(grdGeral, cnt_GridGeral_Deducao, iCont) & _
                          ", SYSDATE, '" & sAcesso_UsuarioLogado & "')"
                If Not DBExecutar(SqlText) Then GoTo Erro
            Next
        End If

        If chkISS.Checked = True Then
            SqlText = "update sof.TIPO_FRETISTA_TRIBUTACAO set ic_iss='N' where cd_TIPO_FRETISTA_TRIBUTACAO<>" & CdTipoFretistaTributacao
            If Not DBExecutar(SqlText) Then GoTo Erro
        End If


        If Not DBExecutarTransacao() Then GoTo Erro
        Me.Close()
        Exit Sub
Erro:
        TratarErro()
    End Sub

    Private Sub chkISS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkISS.CheckedChanged
        Dim iCont As Integer

        If chkISS.Checked = False Then
            txtBaseCalculo.Enabled = True
            txtDeducaoDependente.Enabled = True
            cboTributoDeducao.Enabled = True
            txtSequencia.Enabled = True
            txtValorMinimo.Enabled = True
            txtValorMaximo.Enabled = True
            lstTipoFretista.Enabled = True
            grdGeral.Enabled = True
        Else
            txtBaseCalculo.Value = 0
            txtBaseCalculo.Enabled = False
            txtDeducaoDependente.Value = 0
            txtDeducaoDependente.Enabled = False
            ComboBox_Possicionar(cboTributoDeducao, -1)
            cboTributoDeducao.Enabled = False
            txtSequencia.Value = 0
            txtSequencia.Enabled = False
            txtValorMinimo.Value = 0
            txtValorMinimo.Enabled = False
            txtValorMaximo.Value = 0
            txtValorMaximo.Enabled = False
            For iCont = 0 To lstTipoFretista.Items.Count - 1
                lstTipoFretista.SetItemCheckState(iCont, CheckState.Unchecked)
            Next
            lstTipoFretista.Enabled = False
            grdGeral.Enabled = False
        End If
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub
End Class