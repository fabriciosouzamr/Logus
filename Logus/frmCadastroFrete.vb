Imports Infragistics.Win

Public Class frmCadastroFrete
    Public Enum enTipoRetorno
        Gravado = 1
        SemFrete = 2
        Cancelado = 3
    End Enum

    Public Enum enTipoLancamentoFrete
        frtNormal = 1
        frtMovimentacao = 2
        frtTransferencia = 3
        frtAvulso = 4
    End Enum

    Const cnt_GridFrete_BTNExcluir As Integer = 0
    Const cnt_GridFrete_CD_FRETISTA As Integer = 1
    Const cnt_GridFrete_CD_TIPO_CALCULO As Integer = 2
    Const cnt_GridFrete_CD_FILIAL_PAGADORA As Integer = 3
    Const cnt_GridFrete_CD_TIPO_FRETE As Integer = 4
    Const cnt_GridFrete_SQ_MOVIMENTACAO As Integer = 5
    Const cnt_GridFrete_PrecoPadrao As Integer = 6
    Const cnt_GridFrete_PrecoUnitario As Integer = 7
    Const cnt_GridFrete_Volume As Integer = 8
    Const cnt_GridFrete_PrecoTotal As Integer = 9
    Const cnt_GridFrete_Fretista As Integer = 10
    Const cnt_GridFrete_FilialPagadora As Integer = 11
    Const cnt_GridFrete_TipoFrete As Integer = 12
    Const cnt_GridFrete_ValorImposto As Integer = 13
    Const cnt_GridFrete_ValorDespesa As Integer = 14
    Const cnt_GridFrete_MOVIMENTACAO As Integer = 15
    Const cnt_GridFrete_CARGA As Integer = 16

    Public TipoRetorno As enTipoRetorno
    Public TipoLancamentoFrete As enTipoLancamentoFrete
    Public QT_SACO_MOVIMENTACAO As Long
    Public QT_VOLUME_MOVIMENTACAO As Long
    Public LocalEntrega As Long
    Public QT_FRETE As Long

    Dim ParametroFreteFilFaz As Double
    Dim ParametroFreteFilFab As Double
    Dim ParametroFreteFab As Double

    Dim PrecoFretePadrao As Double

    Dim iLocalEntrega As Integer
    Dim bSemFrete As Boolean

    Dim ValorImposto As Double
    Dim QT_DEPENDENTE As Double
    Dim VL_TOTAL_LANC_MES As Double
    Dim VL_IMPOSTO_LANC_MES As Double

    Dim oDS As New UltraWinDataSource.UltraDataSource

    Private Sub frmCadastroFrete_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlText As String

        TipoLancamentoFrete = enTipoLancamentoFrete.frtNormal

        With Pesq_Fretista
            .BancoDados_Tabela = "SOF.FRETISTA"
            .BancoDados_Campo_Codigo = "CD_FRETISTA"
            .BancoDados_Campo_Descricao = "NO_FRETISTA"
        End With

        Pesq_Movimentacao.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Movimentacao

        ComboBox_Carregar_Tipo_Frete(cboTipoFrete, True)
        ComboBox_Carregar_Filial(cboFilialPagadora, True)

        objEditorValor_Formatar(txtValorUnitario, , , 6)
        objEditorValor_Formatar(txtValorDespesa, , , 6)
        objEditorValor_Formatar(txtValorTotal, , , 6)
        objEditorValor_Formatar(txtValorTotalPagar, , , 6)

        optValorFretista.Enabled = False
        cmdFechar.Focus()

        objGrid_Inicializar(grdFrete, , oDS)
        objGrid_Coluna_Add(grdFrete, "Excluir", 50, , True, Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton)
        objGrid_Coluna_Add(grdFrete, "CD_FRETISTA", 0)
        objGrid_Coluna_Add(grdFrete, "CD_TIPO_CALCULO", 0)
        objGrid_Coluna_Add(grdFrete, "CD_FILIAL_PAGADORA", 0)
        objGrid_Coluna_Add(grdFrete, "CD_TIPO_FRETE", 0)
        objGrid_Coluna_Add(grdFrete, "SQ_MOVIMENTACAO", 0)
        objGrid_Coluna_Add(grdFrete, "PRECOPADRAO", 0)
        objGrid_Coluna_Add(grdFrete, "Preço Unitário", 120, , , , , cnt_Formato_Valor, , True)
        objGrid_Coluna_Add(grdFrete, "Volume", 100)
        objGrid_Coluna_Add(grdFrete, "Preço Total", 100, , , , , cnt_Formato_Valor, , True)
        objGrid_Coluna_Add(grdFrete, "Fretista", 100)
        objGrid_Coluna_Add(grdFrete, "Filial Pagadora", 120)
        objGrid_Coluna_Add(grdFrete, "Tipo do Frete", 120)
        objGrid_Coluna_Add(grdFrete, "Valor de Impostos", 100, , , , , cnt_Formato_Valor, , True)
        objGrid_Coluna_Add(grdFrete, "Valor de Despesas", 100, , , , , cnt_Formato_Valor, , True)
        objGrid_Coluna_Add(grdFrete, "Movimentação", 300)
        objGrid_Coluna_Add(grdFrete, "Carga", 0)

        ParametroFrete()
        Limpa_Tela()

        Select Case TipoLancamentoFrete
            Case enTipoLancamentoFrete.frtMovimentacao
                SqlText = "SELECT CD_TIPO_FRETE_MOV FROM SOF.PARAMETRO"
                ComboBox_Possicionar(cboTipoFrete, DBQuery_ValorUnico(SqlText, -1))

                optValorSaco.Checked = True
                txtVolume.Value = QT_SACO_MOVIMENTACAO

                Cancela_Controles()

                If LocalEntrega = cnt_LocalEntrega_Fazenda Then
                    txtValorUnitario.Value = ParametroFreteFilFaz
                    PrecoFretePadrao = ParametroFreteFilFaz
                    Calcula_ValorTotalAPagar()
                End If

                cmdSemFrete.Visible = True
            Case enTipoLancamentoFrete.frtNormal
                Pesq_Movimentacao.Codigo = 0
                cmdSemFrete.Visible = False
            Case enTipoLancamentoFrete.frtAvulso
                cmdSemFrete.Visible = False
            Case enTipoLancamentoFrete.frtTransferencia
                SqlText = "SELECT CD_TIPO_FRETE_TRANSF FROM SOF.PARAMETRO"
                ComboBox_Possicionar(cboTipoFrete, DBQuery_ValorUnico(SqlText, -1))

                Cancela_Controles()

                optValorSaco.Checked = True

                txtVolume.Value = QT_SACO_MOVIMENTACAO
                txtValorUnitario.Value = ParametroFreteFilFab
                PrecoFretePadrao = ParametroFreteFilFab
                Calcula_ValorTotalAPagar()
                cmdSemFrete.Visible = True
        End Select
    End Sub

    Private Sub Cancela_Controles()
        cboTipoFrete.Enabled = False
        Me.ControlBox = False
    End Sub

    Public Sub ComboBox_Carregar_Tipo_Frete(ByRef oCombo As System.Windows.Forms.ComboBox, _
                                               Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT CD_TIPO_FRETE, NO_TIPO_FRETE FROM SOF.TIPO_FRETE ORDER BY NO_TIPO_FRETE"

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Private Sub cmdSemFrete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSemFrete.Click
        TipoRetorno = enTipoRetorno.SemFrete
        bSemFrete = True
        Close()
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        TipoRetorno = enTipoRetorno.Cancelado
        Close()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        If Pesq_Fretista.Codigo = 0 Then
            Msg_Mensagem("Favor informar um fretista.")
            Exit Sub
        End If
        If txtValorTotalPagar.Value <= 0 Then
            Msg_Mensagem("Favor informar o valor total a pagar.")
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboTipoFrete) Then
            Msg_Mensagem("Favor selecionar um tipo de frete.")
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboFilialPagadora) Then
            Msg_Mensagem("Favor selecionar uma filial pagadora.")
            Exit Sub
        End If
        If grdFrete.Rows.Count = 0 Then
            Msg_Mensagem("Informe o(s) frete(s) a ser(em) lançado(s)")
            Exit Sub
        End If
        If QT_FRETE > 0 And grdFrete.Rows.Count <> QT_FRETE Then
            Msg_Mensagem("Quantidade de fretes lançados está diferente da quantidade necessária.")
            Exit Sub
        End If

        Select Case TipoLancamentoFrete
            Case enTipoLancamentoFrete.frtMovimentacao, enTipoLancamentoFrete.frtTransferencia
                TipoRetorno = enTipoRetorno.Gravado
                Me.Hide()
            Case enTipoLancamentoFrete.frtNormal
                If Not Gravar() Then Exit Sub
                Limpa_Tela()
            Case enTipoLancamentoFrete.frtAvulso
                If Not Gravar() Then Exit Sub
                Close()
        End Select
    End Sub

    Public Function Gravar() As Boolean
        Dim SqlText As String
        Dim iCont As Integer

        On Error GoTo Erro

        If FilialFechada(cboFilialPagadora.SelectedValue) Then
            Msg_Mensagem("A Filial está fechada. No momento não é possivel realizar a operação.")
            Exit Function
        End If

        If bSemFrete Then
            Return True
            Exit Function
        End If

        If QT_FRETE > 0 Then
            If QT_FRETE <> grdFrete.Rows.Count Then
                Msg_Mensagem("Quantidade de fretes lançados está diferente da quantidade necessária.")

                Return False
                Exit Function
            End If
        End If

        SqlText = DBMontar_Insert("SOF.FRETE", TipoCampoFixo.DadoCriacao, _
                                               "SQ_FRETE", ":SQ_FRETE", _
                                               "CD_FRETISTA", ":CD_FRETISTA", _
                                               "DT_FRETE", ":DT_FRETE", _
                                               "QT_VOLUME", ":QT_VOLUME", _
                                               "VL_UNITARIO", ":VL_UNITARIO", _
                                               "VL_TOTAL", ":VL_TOTAL", _
                                               "CD_TIPO_FRETE", ":CD_TIPO_FRETE", _
                                               "SQ_MOVIMENTACAO", ":SQ_MOVIMENTACAO", _
                                               "CD_FILIAL_ORIGEM", ":CD_FILIAL_ORIGEM", _
                                               "VL_IMPOSTOS", ":VL_IMPOSTOS", _
                                               "VL_UNITARIO_PADRAO", ":VL_UNITARIO_PADRAO", _
                                               "VL_DEPESAS", ":VL_DEPESAS", _
                                               "IC_FRETE_CARGA", ":IC_FRETE_CARGA")

        For iCont = 0 To grdFrete.Rows.Count - 1
            If Not DBExecutar(SqlText, DBParametro_Montar("SQ_FRETE", DBNovaSequence("SOF.SEQ_FRETE")), _
                                       DBParametro_Montar("CD_FRETISTA", objGrid_Valor(grdFrete, cnt_GridFrete_CD_FRETISTA, iCont)), _
                                       DBParametro_Montar("DT_FRETE", Date_to_Oracle(DataSistema)), _
                                       DBParametro_Montar("QT_VOLUME", objGrid_Valor(grdFrete, cnt_GridFrete_Volume, iCont)), _
                                       DBParametro_Montar("VL_UNITARIO", objGrid_Valor(grdFrete, cnt_GridFrete_PrecoUnitario, iCont)), _
                                       DBParametro_Montar("VL_TOTAL", objGrid_Valor(grdFrete, cnt_GridFrete_PrecoTotal, iCont)), _
                                       DBParametro_Montar("CD_TIPO_FRETE", objGrid_Valor(grdFrete, cnt_GridFrete_CD_TIPO_FRETE, iCont)), _
                                       DBParametro_Montar("SQ_MOVIMENTACAO", NVL(objGrid_Valor(grdFrete, cnt_GridFrete_SQ_MOVIMENTACAO, iCont), Nothing)), _
                                       DBParametro_Montar("CD_FILIAL_ORIGEM", objGrid_Valor(grdFrete, cnt_GridFrete_CD_FILIAL_PAGADORA, iCont)), _
                                       DBParametro_Montar("VL_IMPOSTOS", CDbl(objGrid_Valor(grdFrete, cnt_GridFrete_ValorImposto, iCont))), _
                                       DBParametro_Montar("VL_UNITARIO_PADRAO", objGrid_Valor(grdFrete, cnt_GridFrete_PrecoPadrao, iCont)), _
                                       DBParametro_Montar("VL_DEPESAS", objGrid_Valor(grdFrete, cnt_GridFrete_ValorDespesa, iCont)), _
                                       DBParametro_Montar("IC_FRETE_CARGA", objGrid_Valor(grdFrete, cnt_GridFrete_CARGA, iCont))) Then GoTo Erro
        Next

        Return True

        Exit Function

Erro:
        TratarErro()
    End Function

    Private Sub ParametroFrete()
        Dim oData As DataTable
        Dim SqlText As String

        SqlText = "SELECT VL_FRETE_FILIAL_FAZENDA," & _
                         "VL_FRETE_FILIAL_FABRICA," & _
                         "VL_FRETE_FABRICA" & _
                  " FROM SOF.FILIAL" & _
                  " WHERE CD_FILIAL = " & FilialLogada
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            ParametroFreteFilFaz = oData.Rows(0).Item("VL_FRETE_FILIAL_FAZENDA")
            ParametroFreteFilFab = oData.Rows(0).Item("VL_FRETE_FILIAL_FABRICA")
            ParametroFreteFab = oData.Rows(0).Item("VL_FRETE_FABRICA")
        Else
            ParametroFreteFilFaz = 0
            ParametroFreteFilFab = 0
            ParametroFreteFab = 0
        End If

        oData.Dispose()
        oData = Nothing
    End Sub

    Private Sub Limpa_Tela()
        Limpa_Lancamento()
        oDS.Rows.Clear()
        bSemFrete = False
    End Sub

    Private Sub Limpa_Lancamento()
        Pesq_Fretista.Codigo = 0
        optValorSaco.Checked = True
        cboTipoFrete.SelectedIndex = -1
        cboFilialPagadora.SelectedIndex = -1
        Pesq_Movimentacao.Codigo = 0
        lblTipoFrete.Tag = 0
        Limpa_Tela_Calculo()
    End Sub

    Private Sub Limpa_Tela_Calculo()
        txtValorUnitario.Value = 0
        txtVolume.Value = 0
        txtValorDespesa.Value = 0
        txtValorTotal.Value = 0
        txtValorTotalPagar.Value = 0
    End Sub

    Private Sub AjustarControlePorTipoFrete(Optional ByVal LimparCalculo As Boolean = True)
        If LimparCalculo Then Limpa_Tela_Calculo()

        txtVolume.Enabled = optValorSaco.Checked

        If optValorCarga.Checked Then
            lblTipoFrete.Text = "Frete com Valor por Carga"
            txtVolume.Value = 1
            txtValorUnitario.Value = 0
        ElseIf optValorSaco.Checked Then
            lblTipoFrete.Text = "Frete com Valor por Saco"
            txtVolume.Value = QT_SACO_MOVIMENTACAO
            txtValorUnitario.Value = PrecoFretePadrao
        ElseIf optValorFretista.Checked Then
            Call Calcula_ValorTotalAPagar()
        End If
    End Sub

    Private Sub Calcula_ValorTotalAPagar()
        Dim ValorTotal As Double

        txtValorTotal.Value = 0

        ValorTotal = (txtValorUnitario.Value * txtVolume.Value) - txtValorDespesa.Value

        If ValorTotal <= 0 Then Exit Sub

        txtValorTotal.Value = ValorTotal
        ValidarValorLiquido(ValorImposto)
        txtValorTotalPagar.Value = txtValorTotal.Value
    End Sub

    Private Sub optValorCarga_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optValorCarga.Click
        AjustarControlePorTipoFrete()
    End Sub

    Private Sub optValorSaco_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optValorSaco.Click
        AjustarControlePorTipoFrete()
    End Sub

    Private Sub CarregarFretista()
        If Pesq_Fretista.Codigo = 0 Then
            Exit Sub
        End If

        Dim oData As DataTable
        Dim SqlText As String

        lblTipoFrete.Text = ""
        txtValorUnitario.Value = PrecoFretePadrao
        txtVolume.Value = QT_SACO_MOVIMENTACAO
        txtValorDespesa.Value = 0
        txtValorTotal.Value = 0
        txtValorTotal.ReadOnly = True
        txtValorDespesa.Enabled = False
        lblTipoFrete.Tag = 0
        optValorSaco.Checked = True

        objEditorNumero_Formatar(txtVolume, , , 3, )

        'Verifica a qtde. de dependente
        SqlText = "SELECT NVL(QT_DEPENDETES, 0) FROM SOF.FRETISTA WHERE CD_FRETISTA = " & Pesq_Fretista.Codigo
        QT_DEPENDENTE = DBQuery_ValorUnico(SqlText)

        oData = DBQuery("SELECT FT.*, PL.NO_ITEM_LISTA" & _
                        " FROM SOF.FRETISTA FT," & _
                              "(SELECT CD_ITEM_LISTA, NO_ITEM_LISTA" & _
                               " FROM SOF.PROCESSO_LISTA" & _
                               " WHERE CD_PROCESSO = " & cnt_Processo_TipoCobrancaFrete & ") PL" & _
                        " WHERE FT.CD_FRETISTA = " & Pesq_Fretista.Codigo & _
                          " AND PL.CD_ITEM_LISTA (+) = FT.CD_CALCULO_CARGA")

        If Not objDataTable_Vazio(oData) Then
            optValorSaco.Enabled = objDataTable_CampoVazio(oData.Rows(0).Item("CD_CALCULO_CARGA"))
            optValorCarga.Enabled = objDataTable_CampoVazio(oData.Rows(0).Item("CD_CALCULO_CARGA"))
            optValorFretista.Enabled = (Not objDataTable_CampoVazio(oData.Rows(0).Item("CD_CALCULO_CARGA")))

            If Not objDataTable_CampoVazio(oData.Rows(0).Item("CD_CALCULO_CARGA")) Then
                lblTipoFrete.Text = objDataTable_LerCampo(oData.Rows(0).Item("NO_ITEM_LISTA"), "")

                If Not objDataTable_CampoVazio(oData.Rows(0).Item("VL_CALCULO_CARGA")) Then
                    lblTipoFrete.Text = lblTipoFrete.Text + " - Valor " & Format(oData.Rows(0).Item("VL_CALCULO_CARGA"), cnt_Formato_Valor)
                End If

                If objDataTable_LerCampo(oData.Rows(0).Item("VL_DESPESA"), 0) > 0 Or _
                   objDataTable_LerCampo(oData.Rows(0).Item("PC_DESPESA"), 0) > 0 Then
                    lblTipoFrete.Text = lblTipoFrete.Text + " - Despesa "

                    If objDataTable_LerCampo(oData.Rows(0).Item("VL_DESPESA"), 0) > 0 Then
                        lblTipoFrete.Text = lblTipoFrete.Text & Format(oData.Rows(0).Item("VL_DESPESA"), cnt_Formato_Valor)
                    End If

                    If objDataTable_LerCampo(oData.Rows(0).Item("PC_DESPESA"), 0) > 0 Then
                        If Not objDataTable_CampoVazio(oData.Rows(0).Item("VL_DESPESA")) Then
                            lblTipoFrete.Text = lblTipoFrete.Text & ", mais "
                        End If

                        lblTipoFrete.Text = lblTipoFrete.Text & Format(oData.Rows(0).Item("PC_DESPESA"), "##0.00") & " % sobre o valor da carga"
                    End If
                End If

                lblTipoFrete.Tag = objDataTable_LerCampo(oData.Rows(0).Item("CD_CALCULO_CARGA"), 0)
                optValorFretista.Checked = True
            Else
                lblTipoFrete.Text = ""
                optValorFretista.Checked = False
            End If

            txtValorUnitario.Enabled = True
            txtVolume.Enabled = True

            If Not objDataTable_CampoVazio(oData.Rows(0).Item("CD_CALCULO_CARGA")) Then
                Select Case objDataTable_LerCampo(oData.Rows(0).Item("CD_CALCULO_CARGA"), 0)
                    Case cnt_TipoCobrancaFrete_ValorCarga
                        txtValorUnitario.Value = oData.Rows(0).Item("VL_CALCULO_CARGA")
                        txtVolume.Value = 1
                        txtValorDespesa.Value = objDataTable_LerCampo(oData.Rows(0).Item("VL_DESPESA"), 0) + _
                                                (objDataTable_LerCampo(oData.Rows(0).Item("PC_DESPESA"), 0) * _
                                                 oData.Rows(0).Item("VL_CALCULO_CARGA") / 100)
                        txtValorTotal.Value = txtValorUnitario.Value + txtValorDespesa.Value
                        txtVolume.Enabled = False Or (TipoLancamentoFrete = enTipoLancamentoFrete.frtNormal)
                        txtValorDespesa.Enabled = True
                    Case cnt_TipoCobrancaFrete_ValorQuilo
                        txtValorUnitario.Value = oData.Rows(0).Item("VL_CALCULO_CARGA")
                        txtVolume.Value = QT_VOLUME_MOVIMENTACAO
                        txtValorTotal.Value = txtValorUnitario.Value * QT_VOLUME_MOVIMENTACAO
                        txtValorDespesa.Value = objDataTable_LerCampo(oData.Rows(0).Item("VL_DESPESA"), 0) + _
                                                (objDataTable_LerCampo(oData.Rows(0).Item("PC_DESPESA"), 0) * _
                                                 txtValorTotal.Value / 100)
                        txtValorTotal.Value = txtValorTotal.Value + txtValorDespesa.Value
                        txtVolume.Enabled = False Or (TipoLancamentoFrete = enTipoLancamentoFrete.frtNormal)
                        txtValorDespesa.Enabled = True
                    Case cnt_TipoCobrancaFrete_ImpostoInclusoValorCarga
                        txtValorUnitario.Value = oData.Rows(0).Item("VL_CALCULO_CARGA")
                        txtVolume.Value = 1
                        txtValorTotal.Value = txtValorUnitario.Value
                        txtVolume.Enabled = False Or (TipoLancamentoFrete = enTipoLancamentoFrete.frtNormal)
                        txtValorTotal.ReadOnly = False
                    Case cnt_TipoCobrancaFrete_ImpostoInclusoValorTonelada
                        txtValorUnitario.Value = oData.Rows(0).Item("VL_CALCULO_CARGA")
                        objEditorNumero_Formatar(txtVolume, , , 3, 4)
                        txtVolume.Value = (QT_VOLUME_MOVIMENTACAO / 1000)
                        txtValorTotal.Value = txtValorUnitario.Value * txtVolume.Value
                        txtVolume.Enabled = False Or (TipoLancamentoFrete = enTipoLancamentoFrete.frtNormal)
                        txtValorTotal.ReadOnly = False
                    Case Else
                        txtValorTotal.Value = txtValorUnitario.Value * txtVolume.Value
                End Select

                txtValorUnitario.Enabled = (txtValorUnitario.Value <= 0)
            End If
        End If

        AjustarControlePorTipoFrete(False)
    End Sub

    Private Sub Pesq_Fretista_AlterouRegistro() Handles Pesq_Fretista.AlterouRegistro
        CarregarFretista()
    End Sub

    Private Sub cmdLimpar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLancamento_Limpar.Click
        Limpa_Lancamento()
    End Sub

    Private Sub cmdAdicionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLancamento_Adicionar.Click
        Dim SqlText As String
        Dim iLinha As Integer

        If Pesq_Fretista.Codigo = 0 Then
            Msg_Mensagem("Informe o fretista")
            Exit Sub
        End If
        If Not optValorCarga.Checked And Not optValorSaco.Checked And Not optValorFretista.Checked Then
            Msg_Mensagem("Informe a opção de cálculo do valor")
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboTipoFrete) Then
            Msg_Mensagem("Informe o tipo do frete")
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboFilialPagadora) Then
            Msg_Mensagem("Informe a filial pagadora")
            Exit Sub
        End If
        If txtValorUnitario.Value <= 0 Then
            Msg_Mensagem("Informe o preço unitário")
            Exit Sub
        End If
        If txtVolume.Value <= 0 Then
            Msg_Mensagem("Informe o volume")
            Exit Sub
        End If
        If txtValorTotalPagar.Value <= 0 Then
            Msg_Mensagem("Informe o valor total a pagar")
            Exit Sub
        End If
        If txtValorTotalPagar.Value < txtValorTotal.Value Then
            Msg_Mensagem("O valor total a pagar não pode ser menor que o valor a total")
            Exit Sub
        End If

        SqlText = "SELECT CD_TIPO FROM SOF.PROCESSO_LISTA" & _
                  " WHERE CD_ITEM_LISTA = " & lblTipoFrete.Tag & _
                   " AND CD_PROCESSO = " & cnt_Processo_TipoCobrancaFrete
        If Pesq_Movimentacao.Codigo = 0 And _
           DBQuery_ValorUnico(SqlText, 0) = cnt_Processo_CobrancaFrete_Mov_ExigeMovimentacao Then
            Msg_Mensagem("Favor informar a qual movimentação que gerou esse frete.")
            Exit Sub
        End If
        If lblTipoFrete.Tag <> 0 Then
            optValorFretista.Checked = True

            If lblTipoFrete.Tag = cnt_TipoCobrancaFrete_ImpostoInclusoValorCarga Or _
               lblTipoFrete.Tag = cnt_TipoCobrancaFrete_ImpostoInclusoValorTonelada Then
                If Not ValidarValorLiquido(ValorImposto) Then
                    Msg_Mensagem("Valor total informado menos imposto é diferente do líquido")
                    Exit Sub
                End If
            End If
        Else
            ValorImposto = 0
        End If

        oDS.Rows.Add()

        iLinha = grdFrete.Rows.Count - 1

        With grdFrete.Rows(iLinha)
            .Cells(cnt_GridFrete_BTNExcluir).Style = UltraWinGrid.ColumnStyle.Button
            .Cells(cnt_GridFrete_CD_FRETISTA).Value = Pesq_Fretista.Codigo
            .Cells(cnt_GridFrete_CD_TIPO_CALCULO).Value = lblTipoFrete.Text
            .Cells(cnt_GridFrete_CD_FILIAL_PAGADORA).Value = cboFilialPagadora.SelectedValue
            .Cells(cnt_GridFrete_CD_TIPO_FRETE).Value = cboTipoFrete.SelectedValue
            If Pesq_Movimentacao.Codigo = 0 Then
                .Cells(cnt_GridFrete_SQ_MOVIMENTACAO).Value = Nothing
            Else
                .Cells(cnt_GridFrete_SQ_MOVIMENTACAO).Value = Pesq_Movimentacao.Codigo
            End If
            .Cells(cnt_GridFrete_PrecoPadrao).Value = PrecoFretePadrao
            .Cells(cnt_GridFrete_PrecoUnitario).Value = txtValorUnitario.Value
            .Cells(cnt_GridFrete_Volume).Value = txtVolume.Value
            .Cells(cnt_GridFrete_PrecoTotal).Value = txtValorTotalPagar.Value
            .Cells(cnt_GridFrete_Fretista).Value = Pesq_Fretista.Descricao
            .Cells(cnt_GridFrete_FilialPagadora).Value = cboFilialPagadora.SelectedItem(1)
            .Cells(cnt_GridFrete_TipoFrete).Value = cboTipoFrete.SelectedItem(1)
            .Cells(cnt_GridFrete_ValorImposto).Value = ValorImposto
            .Cells(cnt_GridFrete_MOVIMENTACAO).Value = Pesq_Movimentacao.Descricao
            .Cells(cnt_GridFrete_CARGA).Value = (IIf(optValorSaco.Checked, "N", "S"))
        End With
    End Sub

    Private Function ValidarValorLiquido(ByRef VL_IMPOSTO As Double) As Boolean
        Dim oDataL As DataTable
        Dim oData As DataTable
        Dim SqlText As String
        Dim iCont As Integer

        Dim PC_ALIQUOTA_TRIBUTACAO As Double
        Dim VL_DEDUCAO As Double
        Dim PC_BASE_CALCULO As Double
        Dim VL_DEDUCAO_DEPENDENTE As Double
        Dim DEDUCAO_DEPENDENTE As Double
        Dim VL_TETO_TRIBUTACAO As Double
        Dim oTributo As New Collection
        Dim dTributo As Double
        Dim iCont_Deducao As Integer
        Dim sDataSistema As String

        sDataSistema = DataSistema()

        'Verifica os valores lançados no mês
        SqlText = "	SELECT NVL(SUM(FT.VL_TOTAL), 0) VL_TOTAL, NVL(SUM(FT.VL_IMPOSTOS), 0) VL_IMPOSTO" & _
                  "	 FROM SOF.FRETE FT," & _
                         "SOF.FRETISTA FE" & _
                  " WHERE FT.CD_FRETISTA = " & Pesq_Fretista.Codigo & _
                    " AND FT.DT_FRETE BETWEEN LAST_DAY(ADD_MONTHS(" & QuotedStr(Date_to_Oracle(DataSistema)) & ", -1)) + 1" & _
                                        " AND LAST_DAY(" & QuotedStr(Date_to_Oracle(DataSistema)) & ")" & _
                    " AND FE.CD_FRETISTA = FT.CD_FRETISTA"
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            VL_TOTAL_LANC_MES = objDataTable_LerCampo(oData.Rows(0).Item("VL_TOTAL"), 0)
            VL_IMPOSTO_LANC_MES = objDataTable_LerCampo(oData.Rows(0).Item("VL_IMPOSTO"), 0)
        End If

        VL_TOTAL_LANC_MES = Math.Round(VL_TOTAL_LANC_MES + txtValorTotalPagar.Value, 2)

        SqlText = "SELECT TBT.CD_TIPO_FRETISTA_TRIBUTACAO" & _
                  " FROM SOF.FRETISTA FTT," & _
                        "SOF.TIPO_FRETISTA_TRIBUTOS TFT," & _
                        "SOF.TIPO_FRETISTA_TRIBUTACAO TBT" & _
                  " WHERE FTT.CD_FRETISTA = " & Pesq_Fretista.Codigo & _
                    " AND TFT.CD_TIPO_FRETISTA = FTT.CD_TIPO_FRETISTA" & _
                    " AND TBT.CD_TIPO_FRETISTA_TRIBUTACAO = TFT.CD_TIPO_FRETISTA_TRIBUTACAO" & _
                  " ORDER BY TBT.NU_SEQUENCIA"
        oDataL = DBQuery(SqlText)

        For iCont = 0 To oDataL.Rows.Count - 1
            dTributo = Math.Round(VL_TOTAL_LANC_MES, 2)

            PC_BASE_CALCULO = 0
            VL_DEDUCAO_DEPENDENTE = 0
            VL_TETO_TRIBUTACAO = 0
            PC_ALIQUOTA_TRIBUTACAO = 0
            VL_DEDUCAO = 0

            SqlText = "SELECT NVL(TFT.VL_TETO_TRIBUTACAO, 0) VL_TETO_TRIBUTACAO," & _
                             "NVL(TFT.PC_BASE_CALCULO, 0) PC_BASE_CALCULO," & _
                             "NVL(TFT.VL_DEDUCAO_DEPENDENTE, 0) VL_DEDUCAO_DEPENDENTE," & _
                             "TFT.CD_TRIBUTO_DEDUCAO" & _
                      " FROM SOF.TIPO_FRETISTA_TRIBUTACAO TFT" & _
                      " WHERE TFT.CD_TIPO_FRETISTA_TRIBUTACAO = " & oDataL.Rows(iCont).Item("CD_TIPO_FRETISTA_TRIBUTACAO")
            oData = DBQuery(SqlText)

            If Not objDataTable_Vazio(oData) Then
                PC_BASE_CALCULO = objDataTable_LerCampo(oData.Rows(0).Item("PC_BASE_CALCULO"), 0)
                VL_DEDUCAO_DEPENDENTE = objDataTable_LerCampo(oData.Rows(0).Item("VL_DEDUCAO_DEPENDENTE"), 0)
                VL_TETO_TRIBUTACAO = objDataTable_LerCampo(oData.Rows(0).Item("VL_TETO_TRIBUTACAO"), 0)
            End If

            dTributo = dTributo * PC_BASE_CALCULO / 100

            If Not objDataTable_CampoVazio(oData.Rows(0).Item("CD_TRIBUTO_DEDUCAO")) Then
                For iCont_Deducao = 1 To oTributo.Count
                    If oTributo(iCont_Deducao)(0) = oData.Rows(0).Item("CD_TRIBUTO_DEDUCAO") Then
                        dTributo = dTributo - oTributo(iCont_Deducao)(1)
                    End If
                Next
            End If

            DEDUCAO_DEPENDENTE = (QT_DEPENDENTE * VL_DEDUCAO_DEPENDENTE)
            If dTributo > 0 Then dTributo = dTributo - DEDUCAO_DEPENDENTE

            SqlText = "SELECT NVL(TAB.PC_ALIQUOTA_TRIBUTACAO, 0) PC_ALIQUOTA_TRIBUTACAO," & _
                             "NVL(TAB.VL_DEDUCAO, 0) VL_DEDUCAO" & _
                      " FROM SOF.TIPO_FRETISTA_TRIBUTACAO TFT," & _
                            "SOF.TIPO_FRETISTA_TRIBUTACAO_TBL TAB" & _
                      " WHERE TAB.CD_TIPO_FRETISTA_TRIBUTACAO = " & oDataL.Rows(iCont).Item("CD_TIPO_FRETISTA_TRIBUTACAO") & _
                        " AND TAB.VL_RENDA_MINIMA <= " & ConvValorFormatoAmericano(dTributo) & _
                        " AND TAB.VL_RENDA_MAXIMA >= " & ConvValorFormatoAmericano(dTributo)
            oData = DBQuery(SqlText)

            If Not objDataTable_Vazio(oData) Then
                PC_ALIQUOTA_TRIBUTACAO = objDataTable_LerCampo(oData.Rows(0).Item("PC_ALIQUOTA_TRIBUTACAO"), 0)
                VL_DEDUCAO = objDataTable_LerCampo(oData.Rows(0).Item("VL_DEDUCAO"), 0)
            End If

            dTributo = (dTributo * PC_ALIQUOTA_TRIBUTACAO / 100) - VL_DEDUCAO

            If dTributo > VL_TETO_TRIBUTACAO And VL_TETO_TRIBUTACAO > 0 Then
                dTributo = VL_TETO_TRIBUTACAO
            End If

            dTributo = Math.Round(dTributo, 2)
            oTributo.Add(New Double() {oDataL.Rows(iCont).Item("CD_TIPO_FRETISTA_TRIBUTACAO"), dTributo})
        Next

        dTributo = 0

        For iCont_Deducao = 1 To oTributo.Count
            dTributo = dTributo + oTributo(iCont_Deducao)(1)
        Next

        oTributo = Nothing

        If Not oDataL Is Nothing Then
            oDataL.Dispose()
            oDataL = Nothing
        End If
        If Not oData Is Nothing Then
            oData.Dispose()
            oData = Nothing
        End If

        VL_IMPOSTO = dTributo - VL_IMPOSTO_LANC_MES
        dTributo = Math.Abs(Math.Round(txtValorTotalPagar.Value - dTributo + VL_IMPOSTO_LANC_MES, 2) - txtValorTotal.Value)

        Return (dTributo <= 0.02)
    End Function

    Private Sub txtValorUnitario_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValorUnitario.LostFocus
        Calcula_ValorTotalAPagar()
    End Sub

    Private Sub txtVolume_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVolume.LostFocus
        Calcula_ValorTotalAPagar()
    End Sub

    Private Sub txtValorDespesa_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValorDespesa.LostFocus
        Calcula_ValorTotalAPagar()
    End Sub

    Private Sub optValorCarga_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optValorCarga.CheckedChanged
        AjustarControlePorTipoFrete()
    End Sub

    Private Sub optValorSaco_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optValorSaco.CheckedChanged
        AjustarControlePorTipoFrete()
    End Sub

    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        Limpa_Tela()
    End Sub

    Private Sub Pesq_Movimentacao_AlterouRegistro() Handles Pesq_Movimentacao.AlterouRegistro
        If Pesq_Movimentacao.Codigo > 0 Then
            QT_VOLUME_MOVIMENTACAO = DBQuery_ValorUnico("SELECT QT_KG_LIQUIDO_NF FROM SOF.MOVIMENTACAO" & _
                                                        " WHERE SQ_MOVIMENTACAO = " & Pesq_Movimentacao.Codigo)
            QT_SACO_MOVIMENTACAO = DBQuery_ValorUnico("SELECT SUM(QT_SACOS) FROM SOF.SACARIA_FILIAL" & _
                                                      " WHERE SQ_MOVIMENTACAO = " & Pesq_Movimentacao.Codigo)

            CarregarFretista()
        End If
    End Sub
End Class