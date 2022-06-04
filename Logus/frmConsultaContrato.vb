Imports Infragistics.Win
Imports VB = Microsoft.VisualBasic

Public Class frmConsultaContrato
    Const cnt_BotaoStatus_Abrir As Integer = 1
    Const cnt_BotaoStatus_Fechar As Integer = 2

    Const cnt_GridCtrPaf_IC_STATUS As Integer = 0
    Const cnt_GridCtrPaf_CD_CONTRATO_PAF As Integer = 1
    Const cnt_GridCtrPaf_DT_CONTRATO_PAF As Integer = 2
    Const cnt_GridCtrPaf_DT_PRAZO_ENTREGA As Integer = 3
    Const cnt_GridCtrPaf_DT_PRAZO_FIXACAO As Integer = 4
    Const cnt_GridCtrPaf_NO_RAZAO_SOCIAL As Integer = 5
    Const cnt_GridCtrPaf_QT_KGS As Integer = 6
    Const cnt_GridCtrPaf_QT_KG_FIXO As Integer = 7
    Const cnt_GridCtrPaf_QT_CANCELADO As Integer = 8
    Const cnt_GridCtrPaf_QT_SALDO As Integer = 9
    Const cnt_GridCtrPaf_QT_A_NEGOCIAR As Integer = 10
    Const cnt_GridCtrPaf_VL_NF_FIXO As Integer = 11
    Const cnt_GridCtrPaf_VL_PAG_FIXO As Integer = 12
    Const cnt_GridCtrPaf_NO_FILIAL As Integer = 13
    Const cnt_GridCtrPaf_NO_REPASSADOR As Integer = 14
    Const cnt_GridCtrPaf_NO_TIPO_PESSOA As Integer = 15
    Const cnt_GridCtrPaf_NO_TIPO_CONTRATO_PAF As Integer = 16
    Const cnt_GridCtrPaf_VL_ADIANTAMENTO As Integer = 17
    Const cnt_GridCtrPaf_DS_SAFRA As Integer = 18
    Const cnt_GridCtrPaf_DS_SAFRA_COMPETENCIA As Integer = 19
    Const cnt_GridCtrPaf_NO_TIPO_ACONDICIONAMENTO As Integer = 20
    Const cnt_GridCtrPaf_NO_TIPO_MODALIDADE_ENTREGA As Integer = 21
    Const cnt_GridCtrPaf_NO_LOCAL_CONFERENCIA_PESO As Integer = 22
    Const cnt_GridCtrPaf_NO_LOCAL_CONFERENCIA_QUALIDADE As Integer = 23
    Const cnt_GridCtrPaf_NO_TIPO_DESPESA_CARREGAMENTO As Integer = 24
    Const cnt_GridCtrPaf_IC_CALCULA_JUROS As Integer = 25
    Const cnt_GridCtrPaf_QT_DIA_CARENCIA_JUROS As Integer = 26
    Const cnt_GridCtrPaf_IC_JUROS_APOS_CARENCIA As Integer = 27
    Const cnt_GridCtrPaf_PC_TAXA_JUROS As Integer = 28
    Const cnt_GridCtrPaf_NO_UF As Integer = 29
    Const cnt_GridCtrPaf_NO_TIPO_QUALIDADE As Integer = 30
    Const cnt_GridCtrPaf_NO_FILIAL_NF As Integer = 31
    Const cnt_GridCtrPaf_NO_FILIAL_ENTREGA As Integer = 32
    Const cnt_GridCtrPaf_NO_TIPO_CONDICAO_PAGAMENTO As Integer = 33
    Const cnt_GridCtrPaf_CD_CONTRATO_PAF_ORIGEM As Integer = 34
    Const cnt_GridCtrPaf_CD_FORNECEDOR As Integer = 35
    Const cnt_GridCtrPaf_CD_REPASSADOR As Integer = 36
    Const cnt_GridCtrPaf_CD_TIPO_CONTRATO_PAF As Integer = 37
    Const cnt_GridCtrPaf_DT_VENCIMENTO As Integer = 38
    Const cnt_GridCtrPaf_CD_FILIAL_ORIGEM As Integer = 39
    Const cnt_GridCtrPaf_CD_SAFRA As Integer = 40
    Const cnt_GridCtrPaf_DT_CRIACAO As Integer = 41
    Const cnt_GridCtrPaf_NO_USER_CRIACAO As Integer = 42
    Const cnt_GridCtrPaf_DT_ALTERACAO As Integer = 43
    Const cnt_GridCtrPaf_NO_USER_ALTERACAO As Integer = 44
    Const cnt_GridCtrPaf_VL_NF_INSS_FIXO As Integer = 45
    Const cnt_GridCtrPaf_VL_NF_ICMS_FIXO As Integer = 46
    Const cnt_GridCtrPaf_CD_SAFRA_COMPETENCIA As Integer = 47
    Const cnt_GridCtrPaf_CD_TIPO_ACONDICIONAMENTO As Integer = 48
    Const cnt_GridCtrPaf_CD_TIPO_MODALIDADE_ENTREGA As Integer = 49
    Const cnt_GridCtrPaf_CD_TIPO_DESPESA_CARREGAMENTO As Integer = 50
    Const cnt_GridCtrPaf_CD_LOCAL_CONFERENCIA_PESO As Integer = 51
    Const cnt_GridCtrPaf_CD_LOCAL_CONFERENCIA_QUALIDADE As Integer = 52
    Const cnt_GridCtrPaf_CD_TIPO_PESSOA As Integer = 53
    Const cnt_GridCtrPaf_IC_ADIANTAMENTO As Integer = 54
    Const cnt_GridCtrPaf_CD_VERSAO_CONTRATO As Integer = 55
    Const cnt_GridCtrPaf_DT_ASSINATURA_CONTRATO As Integer = 56
    Const cnt_GridCtrPaf_QT_ADITIVO As Integer = 57

    Const cnt_GridNegociacao_IC_STATUS As Integer = 0
    Const cnt_GridNegociacao_CD_CONTRATOPAF As Integer = 1
    Const cnt_GridNegociacao_SQ_NEGOCIACAO As Integer = 2
    Const cnt_GridNegociacao_DT_NEGOCIACAO As Integer = 3
    Const cnt_GridNegociacao_DT_PRAZO_FIXACAO As Integer = 4
    Const cnt_GridNegociacao_DT_PAGAMENTO As Integer = 5
    Const cnt_GridNegociacao_DT_VENCIMENTO As Integer = 6
    Const cnt_GridNegociacao_NO_RAZAO_SOCIAL As Integer = 7
    Const cnt_GridNegociacao_QT_KGS As Integer = 8
    Const cnt_GridNegociacao_QT_KG_FIXO As Integer = 9
    Const cnt_GridNegociacao_QT_CANCELADO As Integer = 10
    Const cnt_GridNegociacao_QT_EM_RENEGOCIACAO As Integer = 11
    Const cnt_GridNegociacao_QT_SALDO As Integer = 12
    Const cnt_GridNegociacao_QT_A_FIXAR As Integer = 13
    Const cnt_GridNegociacao_VL_NEGOCIACAO As Integer = 14
    Const cnt_GridNegociacao_CD_PAPEL_COMPETENCIA As Integer = 15
    Const cnt_GridNegociacao_NO_TIPO_PRECO As Integer = 16
    Const cnt_GridNegociacao_NO_TIPO_UNIDADE As Integer = 17
    Const cnt_GridNegociacao_PC_ALIQ_ICMS As Integer = 18
    Const cnt_GridNegociacao_VL_PRECO_FRETE As Integer = 19
    Const cnt_GridNegociacao_IC_CALCULA_JUROS As Integer = 20
    Const cnt_GridNegociacao_PC_TAXA_JUROS As Integer = 21
    Const cnt_GridNegociacao_QT_DIA_CARENCIA_JUROS As Integer = 22
    Const cnt_GridNegociacao_IC_JUROS_APOS_CARENCIA As Integer = 23
    Const cnt_GridNegociacao_VL_NF_FIXO As Integer = 24
    Const cnt_GridNegociacao_VL_PAG_FIXO As Integer = 25
    Const cnt_GridNegociacao_NO_LOCAL_ENTREGA As Integer = 26
    Const cnt_GridNegociacao_NO_FILIAL_ENTREGA As Integer = 27
    Const cnt_GridNegociacao_NO_FILIAL As Integer = 28
    Const cnt_GridNegociacao_NO_REPASSADOR As Integer = 29
    Const cnt_GridNegociacao_NO_TIPO_PESSOA As Integer = 30
    Const cnt_GridNegociacao_NO_TIPO_NEGOCIACAO As Integer = 31
    Const cnt_GridNegociacao_DS_SAFRA As Integer = 32
    Const cnt_GridNegociacao_IC_BONUS As Integer = 33
    Const cnt_GridNegociacao_CD_PAPEL As Integer = 34
    Const cnt_GridNegociacao_VL_BOLSA As Integer = 35
    Const cnt_GridNegociacao_VL_BOLSA_ALTERNATIVO As Integer = 36
    Const cnt_GridNegociacao_VL_TAXA_DOLAR As Integer = 37
    Const cnt_GridNegociacao_VL_TAXA_DOLAR_ALTERNATIVO As Integer = 38
    Const cnt_GridNegociacao_VL_DIFERENCIAL As Integer = 39
    Const cnt_GridNegociacao_QT_UMIDADE_PADRAO As Integer = 40
    Const cnt_GridNegociacao_PC_SUJIDADE_PADRAO As Integer = 41
    Const cnt_GridNegociacao_NO_TIPO_CACAU As Integer = 42
    Const cnt_GridNegociacao_CD_TIPO_UNIDADE As Integer = 43
    Const cnt_GridNegociacao_CD_TIPO_NEGOCIACAO As Integer = 44
    Const cnt_GridNegociacao_CD_TIPO_PRECO As Integer = 45
    Const cnt_GridNegociacao_CD_LOCAL_ENTREGA As Integer = 46
    Const cnt_GridNegociacao_CD_SAFRA As Integer = 47
    Const cnt_GridNegociacao_DT_CRIACAO As Integer = 48
    Const cnt_GridNegociacao_NO_USER_CRIACAO As Integer = 49
    Const cnt_GridNegociacao_DT_ALTERACAO As Integer = 50
    Const cnt_GridNegociacao_NO_USER_ALTERACAO As Integer = 51
    Const cnt_GridNegociacao_VL_NF_INSS_FIXO As Integer = 52
    Const cnt_GridNegociacao_VL_NF_ICMS_FIXO As Integer = 53
    Const cnt_GridNegociacao_CD_FILIAL_ORIGEM As Integer = 54
    Const cnt_GridNegociacao_IC_BOLSA As Integer = 55
    Const cnt_GridNegociacao_IC_BOLSA_OPERACAO As Integer = 56
    Const cnt_GridNegociacao_IC_DOLAR As Integer = 57
    Const cnt_GridNegociacao_IC_TIPO_PRECO_FIXO As Integer = 58
    Const cnt_GridNegociacao_CD_TIPO_PESSOA As Integer = 59
    Const cnt_GridNegociacao_CD_TIPO_PESSOA_REPASSADOR As Integer = 60
    Const cnt_GridNegociacao_NO_TIPO_PESSOA_REPASSADOR As Integer = 61
    Const cnt_GridNegociacao_IC_IMPRIME_CTR_PAF As Integer = 62
    Const cnt_GridNegociacao_DiferencialReal As Integer = 63
    Const cnt_GridNegociacao_DiffDiferencial As Integer = 64
    Const cnt_GridNegociacao_QT_ADITIVO As Integer = 65

    Const cnt_GridCtrFixo_IC_STATUS As Integer = 0
    Const cnt_GridCtrFixo_CD_CONTRATO_PAF As Integer = 1
    Const cnt_GridCtrFixo_SQ_NEGOCIACAO As Integer = 2
    Const cnt_GridCtrFixo_SQ_CONTRATO_FIXO As Integer = 3
    Const cnt_GridCtrFixo_DT_CONTRATO_FIXO As Integer = 4
    Const cnt_GridCtrFixo_DT_VENCIMENTO As Integer = 5
    Const cnt_GridCtrFixo_DT_PAGAMENTO As Integer = 6
    Const cnt_GridCtrFixo_NO_RAZAO_SOCIAL As Integer = 7
    Const cnt_GridCtrFixo_QT_KGS As Integer = 8
    Const cnt_GridCtrFixo_QT_KG_FIXO As Integer = 9
    Const cnt_GridCtrFixo_QT_CANCELADO As Integer = 10
    Const cnt_GridCtrFixo_QT_SALDO As Integer = 11
    Const cnt_GridCtrFixo_VL_UNITARIO As Integer = 12
    Const cnt_GridCtrFixo_NO_TIPO_UNIDADE As Integer = 13
    Const cnt_GridCtrFixo_PC_ALIQ_ICMS As Integer = 14
    Const cnt_GridCtrFixo_VL_TOTAL As Integer = 15
    Const cnt_GridCtrFixo_VL_ICMS As Integer = 16
    Const cnt_GridCtrFixo_VL_INSS As Integer = 17
    Const cnt_GridCtrFixo_VL_ADENDO As Integer = 18
    Const cnt_GridCtrFixo_VL_ADENDO_ICMS As Integer = 19
    Const cnt_GridCtrFixo_VL_ADENDO_INSS As Integer = 20
    Const cnt_GridCtrFixo_VL_NF_FIXO As Integer = 21
    Const cnt_GridCtrFixo_VL_PAG_FIXO As Integer = 22
    Const cnt_GridCtrFixo_VL_TAXA_DOLAR_FECHADO As Integer = 23
    Const cnt_GridCtrFixo_VL_BOLSA_FECHADO As Integer = 24
    Const cnt_GridCtrFixo_NO_FILIAL As Integer = 25
    Const cnt_GridCtrFixo_NO_REPASSADOR As Integer = 26
    Const cnt_GridCtrFixo_NO_TIPO_PESSOA As Integer = 27
    Const cnt_GridCtrFixo_DS_SAFRA As Integer = 28
    Const cnt_GridCtrFixo_CD_PAPEL As Integer = 29
    Const cnt_GridCtrFixo_VL_BOLSA As Integer = 30
    Const cnt_GridCtrFixo_VL_BOLSA_ALTERNATIVO As Integer = 31
    Const cnt_GridCtrFixo_VL_TAXA_DOLAR As Integer = 32
    Const cnt_GridCtrFixo_VL_TAXA_DOLAR_ALTERNATIVO As Integer = 33
    Const cnt_GridCtrFixo_VL_DIFERENCIAL As Integer = 34
    Const cnt_GridCtrFixo_IC_TAXA_DOLAR_VARIAVEL As Integer = 35
    Const cnt_GridCtrFixo_VL_TAXA_DOLAR_FIXACAO As Integer = 36
    Const cnt_GridCtrFixo_VL_TAXA_DOLAR_FECHAMENTO As Integer = 37
    Const cnt_GridCtrFixo_VL_UNITARIO_US As Integer = 38
    Const cnt_GridCtrFixo_DT_FECHAMENTO_TAXA_DOLAR As Integer = 39
    Const cnt_GridCtrFixo_IC_INCLUI_ICMS_PAG As Integer = 40
    Const cnt_GridCtrFixo_DT_VENCIMENTO_GP As Integer = 41
    Const cnt_GridCtrFixo_DT_CRIACAO As Integer = 42
    Const cnt_GridCtrFixo_NO_USER_CRIACAO As Integer = 43
    Const cnt_GridCtrFixo_DT_ALTERACAO As Integer = 44
    Const cnt_GridCtrFixo_NO_USER_ALTERACAO As Integer = 45
    Const cnt_GridCtrFixo_CD_FILIAL_ORIGEM As Integer = 46
    Const cnt_GridCtrFixo_CD_TIPO_PESSOA As Integer = 47
    Const cnt_GridCtrFixo_IC_TIPO_PRECO_FIXO As Integer = 48
    Const cnt_GridCtrFixo_IC_GP As Integer = 49
    Const cnt_GridCtrFixo_NO_TIPO_NEGOCIACAO As Integer = 50
    Const cnt_GridCtrFixo_DiferencialReal As Integer = 51
    Const cnt_GridCtrFixo_DiffDiferencial As Integer = 52
    Const cnt_GridCtrFixo_QT_ADITIVO As Integer = 53

    Const cnt_TAB_ContratoPAF As Integer = 0
    Const cnt_TAB_Negociacao As Integer = 1
    Const cnt_TAB_ContratoFixo As Integer = 2

    Const cnt_SEC_Tela_ContratoPAF = "Transacao_Contratos_ContratosPAF"
    Const cnt_SEC_Tela_Negociacao = "Transacao_Contratos_Negociacao"
    Const cnt_SEC_Tela_ContratoFixo = "Transacao_Contratos_ContratosFixo"

    Const cnt_Botao_CancelamentoExclusao_Excluir As Integer = 1
    Const cnt_Botao_CancelamentoExclusao_Cancelar As Integer = 2
    Const cnt_Botao_CancelamentoExclusao_Descancelar As Integer = 3

    Dim oDS_ContratoPAF As New UltraWinDataSource.UltraDataSource
    Dim oDS_Negociacao As New UltraWinDataSource.UltraDataSource
    Dim oDS_ContratoFixo As New UltraWinDataSource.UltraDataSource

    Dim bPesquisarAutomatico As Boolean = False

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub frmConsultaContrato_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter
        Form_Ajustar()
    End Sub

    Private Sub frmConsultaContrato_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_Close(Me)
    End Sub

    Private Sub frmConsultaContrato_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Pesq_Fornecedor.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        ComboBox_Carregar_Tipo_ContratoPAF(cboTipoContratoPAF, True)
        ComboBox_Carregar_Tipo_Cacau(cboTipoCacau, True)

        SelecaoFilial.BancoDados_Tabela = SQL_Filial_FilialLiberaUsuario()
        SelecaoFilial.BancoDados_Campo_Codigo = "CD_FILIAL"
        SelecaoFilial.BancoDados_Campo_Descricao = "NO_FILIAL"
        SelecaoFilial.BancoDados_Carregar()

        Form_Inicializar()

        tbcGeral.BackColor = Me.BackColor
        tabContratoPAF.BackColor = Me.BackColor
        tabNegociacao.BackColor = Me.BackColor
        tabContratoFixo.BackColor = Me.BackColor

        Form_Container_IdentificarControles(tabContratoPAF.Controls)
        Form_Container_IdentificarControles(tabNegociacao.Controls)
        Form_Container_IdentificarControles(tabContratoFixo.Controls)

        '>>Formatar icone
        Dim dif As Integer
        dif = Me.Height - 496
        Me.Height = 496
        tbcGeral.Height = tbcGeral.Height + dif
        grpIconeContratoPaf.Top = tbcGeral.Top + tbcGeral.Height
        grpIconeContratoFixo.Top = grpIconeContratoPaf.Top
        grpIconeNegociacao.Top = grpIconeContratoPaf.Top
        grpIconeSair.Top = grpIconeContratoPaf.Top
        grpIconeNegociacao.Text = ""
        grpIconeContratoFixo.Text = ""
        grpIconeContratoPaf.Text = ""
        grpIconeSair.Text = ""
        grpIconeNegociacao.BorderStyle = Misc.GroupBoxBorderStyle.None
        grpIconeContratoFixo.BorderStyle = Misc.GroupBoxBorderStyle.None
        grpIconeContratoPaf.BorderStyle = Misc.GroupBoxBorderStyle.None
        grpIconeSair.BorderStyle = Misc.GroupBoxBorderStyle.None
        grpIconeContratoFixo.Visible = False
        grpIconeNegociacao.Visible = False
       

        '>> Formatação do TAB Contrato PAF - Início
        objGrid_Inicializar(grdContratoPAF, , oDS_ContratoPAF, UltraWinGrid.CellClickAction.CellSelect, DefaultableBoolean.False, , True, , , , True)
        objGrid_Coluna_Add(grdContratoPAF, "Sit", 40)
        objGrid_Coluna_Add(grdContratoPAF, "Número", 80)
        objGrid_Coluna_Add(grdContratoPAF, "Data", 100, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdContratoPAF, "Prazo de Entrega", 100, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdContratoPAF, "Prazo de Fixação", 100, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdContratoPAF, "Fornecedor", 180)
        objGrid_Coluna_Add(grdContratoPAF, "Kgs", 80, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdContratoPAF, "Kgs Aplic", 80, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdContratoPAF, "Kgs Canc", 80, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdContratoPAF, "Saldo", 80, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdContratoPAF, "Kgs a Negociar", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdContratoPAF, "Valor NF Aplicado", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdContratoPAF, "Valor Aplicado", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdContratoPAF, "Filial de Origem", 150)
        objGrid_Coluna_Add(grdContratoPAF, "Repassador", 180)
        objGrid_Coluna_Add(grdContratoPAF, "Tipo de Pessoa", 140)
        objGrid_Coluna_Add(grdContratoPAF, "Tipo de Contrato PAF", 150)
        objGrid_Coluna_Add(grdContratoPAF, "Vl Adiantamento", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdContratoPAF, "Safra", 100)
        objGrid_Coluna_Add(grdContratoPAF, "Safra Competência", 100)
        objGrid_Coluna_Add(grdContratoPAF, "Acondicionamento", 100)
        objGrid_Coluna_Add(grdContratoPAF, "Modalidade de Entrega", 120)
        objGrid_Coluna_Add(grdContratoPAF, "Local de Conf. de Peso", 150)
        objGrid_Coluna_Add(grdContratoPAF, "Local de Conf. de Qualidade", 150)
        objGrid_Coluna_Add(grdContratoPAF, "Despesa de Carregamento", 150)
        objGrid_Coluna_Add(grdContratoPAF, "Juros?", 60)
        objGrid_Coluna_Add(grdContratoPAF, "Dias de Carência Juros", 120)
        objGrid_Coluna_Add(grdContratoPAF, "Juros após Carência ?", 120)
        objGrid_Coluna_Add(grdContratoPAF, "Taxa de Juros", 100)
        objGrid_Coluna_Add(grdContratoPAF, "Origem", 100)
        objGrid_Coluna_Add(grdContratoPAF, "Tipo de Qualidade", 100)
        objGrid_Coluna_Add(grdContratoPAF, "Filial da NF", 140)
        objGrid_Coluna_Add(grdContratoPAF, "Filial de Entrega", 140)
        objGrid_Coluna_Add(grdContratoPAF, "Tipo de Condição de Pagto.", 160)
        objGrid_Coluna_Add(grdContratoPAF, "PAF de Origem", 100)
        objGrid_Coluna_Add(grdContratoPAF, "CD_TIPO_CONTRATO_PAF", 0)
        objGrid_Coluna_Add(grdContratoPAF, "CD_FORNECEDOR", 0)
        objGrid_Coluna_Add(grdContratoPAF, "CD_REPASSADOR", 0)
        objGrid_Coluna_Add(grdContratoPAF, "DT_VENCIMENTO", 0)
        objGrid_Coluna_Add(grdContratoPAF, "CD_FILIAL_ORIGEM", 0)
        objGrid_Coluna_Add(grdContratoPAF, "CD_SAFRA", 0)
        objGrid_Coluna_Add(grdContratoPAF, "DT_CRIACAO", 0)
        objGrid_Coluna_Add(grdContratoPAF, "NO_USER_CRIACAO", 0)
        objGrid_Coluna_Add(grdContratoPAF, "DT_ALTERACAO", 0)
        objGrid_Coluna_Add(grdContratoPAF, "NO_USER_ALTERACAO", 0)
        objGrid_Coluna_Add(grdContratoPAF, "VL_NF_INSS_FIXO", 0)
        objGrid_Coluna_Add(grdContratoPAF, "VL_NF_ICMS_FIXO", 0)
        objGrid_Coluna_Add(grdContratoPAF, "CD_SAFRA_COMPETENCIA", 0)
        objGrid_Coluna_Add(grdContratoPAF, "CD_TIPO_ACONDICIONAMENTO", 0)
        objGrid_Coluna_Add(grdContratoPAF, "CD_TIPO_MODALIDADE_ENTREGA", 0)
        objGrid_Coluna_Add(grdContratoPAF, "CD_TIPO_DESPESA_CARREGAMENTO", 0)
        objGrid_Coluna_Add(grdContratoPAF, "CD_LOCAL_CONFERENCIA_PESO", 0)
        objGrid_Coluna_Add(grdContratoPAF, "CD_LOCAL_CONFERENCIA_QUALIDADE", 0)
        objGrid_Coluna_Add(grdContratoPAF, "CD_TIPO_PESSOA", 0)
        objGrid_Coluna_Add(grdContratoPAF, "IC_ADIANTAMENTO", 0)
        objGrid_Coluna_Add(grdContratoPAF, "CD_VERSAO_CONTRATO", 0)
        objGrid_Coluna_Add(grdContratoPAF, "DT_ASSINATURA_CONTRATO", 0)
        objGrid_Coluna_Add(grdContratoPAF, "Qtde. Aditivo", 100)

        objGrid_ExibirTotal(grdContratoPAF, New Integer() {cnt_GridCtrPaf_QT_KGS, cnt_GridCtrPaf_QT_KG_FIXO, cnt_GridCtrPaf_QT_CANCELADO, cnt_GridCtrPaf_QT_SALDO, _
                                                           cnt_GridCtrPaf_QT_A_NEGOCIAR, cnt_GridCtrPaf_VL_NF_FIXO, cnt_GridCtrPaf_VL_PAG_FIXO, _
                                                           cnt_GridCtrPaf_VL_ADIANTAMENTO, cnt_GridCtrPaf_VL_NF_INSS_FIXO, cnt_GridCtrPaf_VL_NF_ICMS_FIXO})

        SEC_ValidarBotao(cmdCtrPaF_Novo, cnt_SEC_Tela_ContratoPAF, SEC_Validador.SEC_V_Inclusao, True)
        SEC_ValidarBotao(cmdAlterar_CtrPaF, cnt_SEC_Tela_ContratoPAF, SEC_Validador.SEC_V_Alteracao, True)
        SEC_ValidarBotao(cmdAlterar_CtrNeg, cnt_SEC_Tela_Negociacao, SEC_Validador.SEC_V_Alteracao, True)
        SEC_ValidarBotao(cmdAlterar_CtrFixo, cnt_SEC_Tela_ContratoFixo, SEC_Validador.SEC_V_Alteracao, True)
        SEC_ValidarBotao_Permissao(cmdCtrPaF_Juros, SEC_Permissao.SEC_P_Acesso_LancarJurosContratoPAF, True)
        SEC_ValidarBotao_Permissao(cmdRenegociacao, SEC_Permissao.SEC_P_Acesso_CadastroRenegociacao_Consultar, True)

        If Not cmdRenegociacao.Visible Then
            SEC_ValidarBotao_Permissao(cmdRenegociacao, SEC_Permissao.SEC_P_Acesso_CadastroRenegociacao_Solicitar, True)
        End If

        Botao_CtrPAF_ExclusacaoCancelamento()
        '>> Formatação do TAB Contrato PAF - Fim

        '>> Formatação do TAB Negociação - Início
        objGrid_Inicializar(grdNegociacao, , oDS_Negociacao, UltraWinGrid.CellClickAction.RowSelect, , , True, , , , True)
        objGrid_Coluna_Add(grdNegociacao, "Sit.", 25)
        objGrid_Coluna_Add(grdNegociacao, "Número", 100)
        objGrid_Coluna_Add(grdNegociacao, "Seq.Neg.", 100)
        objGrid_Coluna_Add(grdNegociacao, "Data", 100, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdNegociacao, "Prazo Fixação", 100, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdNegociacao, "Data Pagamento", 100, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdNegociacao, "Data Vencimento", 100, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdNegociacao, "Fornecedor", 100)
        objGrid_Coluna_Add(grdNegociacao, "Kgs", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdNegociacao, "Kgs Aplicado", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdNegociacao, "Kgs Cancelado", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdNegociacao, "Kg em Renegociação", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdNegociacao, "Saldo", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdNegociacao, "Kgs a Fixar", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdNegociacao, "Valor", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdNegociacao, "Papel - Bolsa", 100)
        objGrid_Coluna_Add(grdNegociacao, "Tipo Preço", 100)
        objGrid_Coluna_Add(grdNegociacao, "Tipo Unidade", 100)
        objGrid_Coluna_Add(grdNegociacao, "Aliq. ICMS", 100)
        objGrid_Coluna_Add(grdNegociacao, "Preço Frete", 100)
        objGrid_Coluna_Add(grdNegociacao, "Calcula Juros", 100)
        objGrid_Coluna_Add(grdNegociacao, "Taxa de Juros", 100)
        objGrid_Coluna_Add(grdNegociacao, "Carência Dias", 100)
        objGrid_Coluna_Add(grdNegociacao, "Juros após Carência?", 100)
        objGrid_Coluna_Add(grdNegociacao, "Valor NF Aplicado", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdNegociacao, "Valor Pagamento Aplicado", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdNegociacao, "Local de Entrega", 100)
        objGrid_Coluna_Add(grdNegociacao, "Filial de Entrega", 100)
        objGrid_Coluna_Add(grdNegociacao, "Filial de Origem", 100)
        objGrid_Coluna_Add(grdNegociacao, "Repassador", 100)
        objGrid_Coluna_Add(grdNegociacao, "Tipo Pessoa", 100)
        objGrid_Coluna_Add(grdNegociacao, "Tipo de Negociação", 100)
        objGrid_Coluna_Add(grdNegociacao, "Safra", 100)
        objGrid_Coluna_Add(grdNegociacao, "Bônus", 100)
        objGrid_Coluna_Add(grdNegociacao, "Papel", 100)
        objGrid_Coluna_Add(grdNegociacao, "Valor Bolsa", 100, , , , , cnt_Formato_Valor_US)
        objGrid_Coluna_Add(grdNegociacao, "Valor Bolsa Alternativo", 100, , , , , cnt_Formato_Valor_US)
        objGrid_Coluna_Add(grdNegociacao, "Taxa US$", 100, , , , , cnt_Formato_Valor_US_4casas)
        objGrid_Coluna_Add(grdNegociacao, "Taxa US$ Alternativo", 100, , , , , cnt_Formato_Valor_US_4casas)
        objGrid_Coluna_Add(grdNegociacao, "Diferencial", 100, , , , , cnt_Formato_Valor_US)
        objGrid_Coluna_Add(grdNegociacao, "Umidade Padrão", 100)
        objGrid_Coluna_Add(grdNegociacao, "Sujidade Padrão", 100)
        objGrid_Coluna_Add(grdNegociacao, "Tipo de Cacau", 100)
        objGrid_Coluna_Add(grdNegociacao, "CD_TIPO_UNIDADE", 0)
        objGrid_Coluna_Add(grdNegociacao, "CD_TIPO_NEGOCIACAO", 0)
        objGrid_Coluna_Add(grdNegociacao, "CD_TIPO_PRECO", 0)
        objGrid_Coluna_Add(grdNegociacao, "CD_LOCAL_ENTREGA", 0)
        objGrid_Coluna_Add(grdNegociacao, "CD_SAFRA", 0)
        objGrid_Coluna_Add(grdNegociacao, "DT_CRIACAO", 0)
        objGrid_Coluna_Add(grdNegociacao, "NO_USER_CRIACAO", 0)
        objGrid_Coluna_Add(grdNegociacao, "DT_ALTERACAO", 0)
        objGrid_Coluna_Add(grdNegociacao, "NO_USER_ALTERACAO", 0)
        objGrid_Coluna_Add(grdNegociacao, "VL_NF_INSS_FIXO", 0)
        objGrid_Coluna_Add(grdNegociacao, "VL_NF_ICMS_FIXO", 0)
        objGrid_Coluna_Add(grdNegociacao, "CD_FILIAL_ORIGEM", 0)
        objGrid_Coluna_Add(grdNegociacao, "IC_BOLSA", 0)
        objGrid_Coluna_Add(grdNegociacao, "IC_BOLSA_OPERACAO", 0)
        objGrid_Coluna_Add(grdNegociacao, "IC_DOLAR", 0)
        objGrid_Coluna_Add(grdNegociacao, "IC_TIPO_PRECO_FIXO", 0)
        objGrid_Coluna_Add(grdNegociacao, "CD_TIPO_PESSOA", 0)
        objGrid_Coluna_Add(grdNegociacao, "CD_TIPO_PESSOA_REPASSADOR", 0)
        objGrid_Coluna_Add(grdNegociacao, "NO_TIPO_PESSOA_REPASSADOR", 0)
        objGrid_Coluna_Add(grdNegociacao, "IC_IMPRIME_CTR_PAF", 0)
        objGrid_Coluna_Add(grdNegociacao, "Diferencial Real", 130, , , , , cnt_Formato_Valor_US)
        objGrid_Coluna_Add(grdNegociacao, "Diff. Diferencial", 140, , , , , cnt_Formato_Valor_US)
        objGrid_Coluna_Add(grdNegociacao, "Qtde. Aditivo", 100)

        objGrid_ExibirTotal(grdNegociacao, New Integer() {cnt_GridNegociacao_QT_KGS, cnt_GridNegociacao_QT_KG_FIXO, cnt_GridNegociacao_QT_CANCELADO, _
                                                          cnt_GridNegociacao_QT_EM_RENEGOCIACAO, cnt_GridNegociacao_QT_SALDO, cnt_GridNegociacao_QT_A_FIXAR, _
                                                          cnt_GridNegociacao_VL_NEGOCIACAO, cnt_GridNegociacao_VL_PRECO_FRETE, cnt_GridNegociacao_VL_NF_FIXO, _
                                                          cnt_GridNegociacao_VL_PAG_FIXO})

        SEC_ValidarBotao(cmdExcluir_Neg, cnt_SEC_Tela_Negociacao, SEC_Validador.SEC_V_Exclusao, True)
        SEC_ValidarBotao(cmdNeg_Novo, cnt_SEC_Tela_Negociacao, SEC_Validador.SEC_V_Inclusao, True)

        mnuNegCancelar_Cancelamento.Visible = SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_CancelarNegociacaoContrato)
        mnuNegCancelar_Estorno.Visible = SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_EstornoNegociacaoContrato)
        SEC_ValidarBotao_Permissao(cmdNeg_Juros, SEC_Permissao.SEC_P_Acesso_LancarJurosNegociacaoContrato, True)
        '>> Formatação do TAB Negociação - Fim

        '>> Formatação do TAB Contrato Fixo - Início
        objGrid_Inicializar(grdContratoFixo, , oDS_ContratoFixo, UltraWinGrid.CellClickAction.RowSelect, , , True, , , , True)
        objGrid_Coluna_Add(grdContratoFixo, "Sit", 100)
        objGrid_Coluna_Add(grdContratoFixo, "Número", 100)
        objGrid_Coluna_Add(grdContratoFixo, "Seq. Neg.", 100)
        objGrid_Coluna_Add(grdContratoFixo, "Seq. Ctr. Fix.", 100)
        objGrid_Coluna_Add(grdContratoFixo, "Data", 100, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdContratoFixo, "Data de Vencimento", 100, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdContratoFixo, "Data de Pagamento", 100, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdContratoFixo, "Fornecedor", 100)
        objGrid_Coluna_Add(grdContratoFixo, "Kgs", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdContratoFixo, "Kgs Aplicado", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdContratoFixo, "Kgs Cancelado", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdContratoFixo, "Saldo", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdContratoFixo, "Valor", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdContratoFixo, "Tipo de Unidade", 100)
        objGrid_Coluna_Add(grdContratoFixo, "Aliq. ICMS", 100)
        objGrid_Coluna_Add(grdContratoFixo, "Valor Total", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdContratoFixo, "ICMS", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdContratoFixo, "INSS", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdContratoFixo, "Adendo", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdContratoFixo, "Adendo ICMS", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdContratoFixo, "Adendo INSS", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdContratoFixo, "Vl NF Aplicado", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdContratoFixo, "Vl Pagamento Aplicado", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdContratoFixo, "Tx US Acordado", 100, , , , , cnt_Formato_Valor_US)
        objGrid_Coluna_Add(grdContratoFixo, "Bolsa Acordado", 100)
        objGrid_Coluna_Add(grdContratoFixo, "Filial de Origem", 100)
        objGrid_Coluna_Add(grdContratoFixo, "Repassador", 100)
        objGrid_Coluna_Add(grdContratoFixo, "Tipo de Pessoa", 100)
        objGrid_Coluna_Add(grdContratoFixo, "Safra", 100)
        objGrid_Coluna_Add(grdContratoFixo, "Papel", 100)
        objGrid_Coluna_Add(grdContratoFixo, "Vl de Bolsa", 100, , , , , cnt_Formato_Valor_US)
        objGrid_Coluna_Add(grdContratoFixo, "Vl de Bolsa Alternativo", 100, , , , , cnt_Formato_Valor_US)
        objGrid_Coluna_Add(grdContratoFixo, "Tx US", 100, , , , , cnt_Formato_Valor_US_4casas)
        objGrid_Coluna_Add(grdContratoFixo, "Tx US Alternativa", 100, , , , , cnt_Formato_Valor_US_4casas)
        objGrid_Coluna_Add(grdContratoFixo, "Diferencial", 100, , , , , cnt_Formato_Valor_US)
        objGrid_Coluna_Add(grdContratoFixo, "Taxa Dolar Variável", 100)
        objGrid_Coluna_Add(grdContratoFixo, "Dolar de Fixação", 100)
        objGrid_Coluna_Add(grdContratoFixo, "Dolar de Fechamento", 100)
        objGrid_Coluna_Add(grdContratoFixo, "Valor Unitário US", 100, , , , , cnt_Formato_Valor_US)
        objGrid_Coluna_Add(grdContratoFixo, "Data de Fechamento de Câmbio", 100)
        objGrid_Coluna_Add(grdContratoFixo, "Saldo com ICMS?", 100)
        objGrid_Coluna_Add(grdContratoFixo, "Data de Vencimento GP", 100)
        objGrid_Coluna_Add(grdContratoFixo, "DT_CRIACAO", 0)
        objGrid_Coluna_Add(grdContratoFixo, "NO_USER_CRIACAO", 0)
        objGrid_Coluna_Add(grdContratoFixo, "DT_ALTERACAO", 0)
        objGrid_Coluna_Add(grdContratoFixo, "NO_USER_ALTERACAO", 0)
        objGrid_Coluna_Add(grdContratoFixo, "CD_FILIAL_ORIGEM", 0)
        objGrid_Coluna_Add(grdContratoFixo, "CD_TIPO_PESSOA", 0)
        objGrid_Coluna_Add(grdContratoFixo, "IC_TIPO_PRECO_FIXO", 0)
        objGrid_Coluna_Add(grdContratoFixo, "IC_GP", 0)
        objGrid_Coluna_Add(grdContratoFixo, "Tipo de Negociação", 100)
        objGrid_Coluna_Add(grdContratoFixo, "Diferencial Real", 130, , , , , cnt_Formato_Valor_US)
        objGrid_Coluna_Add(grdContratoFixo, "Diff. Diferencial", 140, , , , , cnt_Formato_Valor_US)
        objGrid_Coluna_Add(grdContratoFixo, "Qtde. Aditivo", 100)

        objGrid_ExibirTotal(grdContratoFixo, New Integer() {cnt_GridCtrFixo_QT_KGS, cnt_GridCtrFixo_QT_KG_FIXO, cnt_GridCtrFixo_QT_CANCELADO, _
                                                            cnt_GridCtrFixo_QT_SALDO, cnt_GridCtrFixo_VL_UNITARIO, cnt_GridCtrFixo_VL_TOTAL, _
                                                            cnt_GridCtrFixo_VL_ICMS, cnt_GridCtrFixo_VL_INSS, cnt_GridCtrFixo_VL_ADENDO, _
                                                            cnt_GridCtrFixo_VL_ADENDO_ICMS, cnt_GridCtrFixo_VL_ADENDO_INSS, cnt_GridCtrFixo_VL_NF_FIXO, _
                                                            cnt_GridCtrFixo_VL_PAG_FIXO})

        Form_Carrega_Grid(Me)

        mnuCtrFixAdendo_Inclusao.Visible = SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_IncluirAdendoContratoFixo)
        SEC_ValidarBotao(cmdNovo_CtrFix, cnt_SEC_Tela_ContratoFixo, SEC_Validador.SEC_V_Inclusao, True)
        SEC_ValidarBotao_Permissao(cmdFixarDolar_CtrFix, SEC_Permissao.SEC_P_Acesso_FixarDolarContratoFixo, True)

        AlinharBotoesCtrPAF()
        AlinharBotoesNeg()
        AlinharBotoesCtrFix()
        frmConsultaContrato_Resize(Nothing, Nothing)
        HabilitarTipoCacau(False)
        '>> Formatação do TAB Contrato Fixo - Fim
    End Sub

    Private Sub AjustaIcone()   
        grpIconeContratoFixo.Visible = False
        grpIconeContratoPaf.Visible = False
        grpIconeNegociacao.Visible = False

        Select Case tbcGeral.SelectedIndex
            Case cnt_TAB_ContratoPAF
                grpIconeContratoPaf.Visible = True
            Case cnt_TAB_ContratoFixo
                grpIconeContratoFixo.Visible = True
            Case cnt_TAB_Negociacao
                grpIconeNegociacao.Visible = True
        End Select
    End Sub

    Private Sub Pesquisar()
        Dim SqlText As String

        If Not IsDate(txtDataInicial.Value) And _
            Not IsDate(txtDataFinal.Value) And _
            Pesq_Fornecedor.Codigo = 0 And _
            txtContrato.Text = "" Then
            Msg_Mensagem("É preciso informar pelo menos uma informação de filtro")
            Exit Sub
        End If

        grpIconeContratoFixo.Visible = False
        grpIconeContratoPaf.Visible = False
        grpIconeNegociacao.Visible = False

        bPesquisarAutomatico = True

        Select Case tbcGeral.SelectedIndex
            Case cnt_TAB_ContratoPAF
                grpIconeContratoPaf.Visible = True
                SqlText = "SELECT CP.IC_STATUS," & _
                                     "CP.CD_CONTRATO_PAF," & _
                                     "CP.DT_CONTRATO_PAF," & _
                                     "CP.DT_PRAZO_ENTREGA," & _
                                     "CP.DT_PRAZO_FIXACAO," & _
                                     "F.NO_RAZAO_SOCIAL," & _
                                     "CP.QT_KGS," & _
                                     "CP.QT_KG_FIXO," & _
                                     "CP.QT_CANCELADO, " & _
                                     "NVL(CP.QT_KGS, 0) - NVL(CP.QT_KG_FIXO, 0) - NVL(CP.QT_CANCELADO, 0) QT_SALDO," & _
                                     "(CP.QT_A_NEGOCIAR) QT_A_NEGOCIAR," & _
                                     "CP.VL_NF_FIXO, " & _
                                     "CP.VL_PAG_FIXO," & _
                                     "FIL.NO_FILIAL," & _
                                     "R.NO_RAZAO_SOCIAL NO_REPASSADOR," & _
                                     "TP.NO_TIPO_PESSOA," & _
                                     "TCP.NO_TIPO_CONTRATO_PAF," & _
                                     "CP.VL_ADIANTAMENTO," & _
                                     "S.DS_SAFRA," & _
                                     "SC.DS_SAFRA DS_SAFRA_COMPETENCIA," & _
                                     "TA.NO_TIPO_ACONDICIONAMENTO," & _
                                     "TME.NO_TIPO_MODALIDADE_ENTREGA," & _
                                     "LCP.NO_LOCAL_CONFERENCIA NO_LOCAL_CONFERENCIA_PESO," & _
                                     "LCQ.NO_LOCAL_CONFERENCIA NO_LOCAL_CONFERENCIA_QUALIDADE," & _
                                     "TDC.NO_TIPO_DESPESA_CARREGAMENTO," & _
                                     "CP.IC_CALCULA_JUROS, " & _
                                     "CP.QT_DIA_CARENCIA_JUROS," & _
                                     "CP.IC_JUROS_APOS_CARENCIA," & _
                                     "CP.PC_TAXA_JUROS," & _
                                     "MUNIC.NO_CIDADE || ' - ' || MUNIC.CD_UF AS NO_UF," & _
                                     "TQ.NO_TIPO_QUALIDADE," & _
                                     "FILNF.NO_FILIAL NO_FILIAL_NF," & _
                                     "FILENT.NO_FILIAL NO_FILIAL_ENTREGA," & _
                                     "TCPAG.NO_TIPO_CONDICAO_PAGAMENTO," & _
                                     "CP.CD_CONTRATO_PAF_ORIGEM," & _
                                     "CP.CD_FORNECEDOR," & _
                                     "CP.CD_REPASSADOR," & _
                                     "CP.CD_TIPO_CONTRATO_PAF," & _
                                     "CP.DT_VENCIMENTO," & _
                                     "F.CD_FILIAL_ORIGEM," & _
                                     "CP.CD_SAFRA," & _
                                     "CP.DT_CRIACAO," & _
                                     "CP.NO_USER_CRIACAO," & _
                                     "CP.DT_ALTERACAO," & _
                                     "CP.NO_USER_ALTERACAO," & _
                                     "CP.VL_NF_INSS_FIXO," & _
                                     "CP.VL_NF_ICMS_FIXO," & _
                                     "CP.CD_SAFRA_COMPETENCIA," & _
                                     "CP.CD_TIPO_ACONDICIONAMENTO," & _
                                     "CP.CD_TIPO_MODALIDADE_ENTREGA," & _
                                     "CP.CD_TIPO_DESPESA_CARREGAMENTO," & _
                                     "CP.CD_LOCAL_CONFERENCIA_PESO, " & _
                                     "CP.CD_LOCAL_CONFERENCIA_QUALIDADE," & _
                                     "F.CD_TIPO_PESSOA," & _
                                     "TCP.IC_ADIANTAMENTO," & _
                                     "CP.CD_VERSAO_CONTRATO," & _
                                     "CP.DT_ASSINATURA_CONTRATO," & _
                                     "NVL(ADT.QT_ADITIVO, 0) QT_ADITIVO" & _
                               " FROM SOF.TIPO_CONTRATO_PAF TCP," & _
                                     "SOF.TIPO_ACONDICIONAMENTO TA," & _
                                     "SOF.CONTRATO_PAF CP," & _
                                     "SOF.TIPO_MODALIDADE_ENTREGA TME," & _
                                     "SOF.FILIAL FIL, " & _
                                     "SOF.LOCAL_CONFERENCIA LCP," & _
                                     "SOF.FORNECEDOR F," & _
                                     "SOF.FORNECEDOR R, " & _
                                     "SOF.LOCAL_CONFERENCIA LCQ," & _
                                     "SOF.SAFRA S," & _
                                     "SOF.TIPO_DESPESA_CARREGAMENTO TDC, " & _
                                     "SOF.SAFRA SC," & _
                                     "SOF.TIPO_PESSOA TP," & _
                                     "SOF.MUNICIPIO MUNIC," & _
                                     "SOF.FILIAL FILNF," & _
                                     "SOF.FILIAL FILENT," & _
                                     "SOF.TIPO_QUALIDADE TQ," & _
                                     "SOF.TIPO_CONDICAO_PAGAMENTO TCPAG," & _
                                     "(SELECT CD_CONTRATO_PAF," & _
                                             "COUNT(*) QT_ADITIVO" & _
                                      " FROM SOF.CONTRATO_ADITIVO" & _
                                      " WHERE SQ_NEGOCIACAO IS NULL" & _
                                      " GROUP BY CD_CONTRATO_PAF) ADT" & _
                               " WHERE CP.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                                 " AND CP.CD_REPASSADOR = R.CD_FORNECEDOR" & _
                                 " AND CP.CD_TIPO_CONTRATO_PAF = TCP.CD_TIPO_CONTRATO_PAF" & _
                                 " AND F.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                                 " AND CP.CD_SAFRA = S.CD_SAFRA" & _
                                 " AND CP.CD_SAFRA_COMPETENCIA = SC.CD_SAFRA" & _
                                 " AND CP.CD_TIPO_ACONDICIONAMENTO = TA.CD_TIPO_ACONDICIONAMENTO" & _
                                 " AND CP.CD_TIPO_MODALIDADE_ENTREGA = TME.CD_TIPO_MODALIDADE_ENTREGA" & _
                                 " AND CP.CD_LOCAL_CONFERENCIA_PESO = LCP.CD_LOCAL_CONFERENCIA" & _
                                 " AND CP.CD_LOCAL_CONFERENCIA_QUALIDADE = LCQ.CD_LOCAL_CONFERENCIA" & _
                                 " AND CP.CD_TIPO_DESPESA_CARREGAMENTO = TDC.CD_TIPO_DESPESA_CARREGAMENTO" & _
                                 " AND F.CD_TIPO_PESSOA = TP.CD_TIPO_PESSOA" & _
                                 " AND CP.CD_MUNICIPIO = MUNIC.CD_MUNICIPIO (+)" & _
                                 " AND CP.CD_FILIAL_NF = FILNF.CD_FILIAL" & _
                                 " AND CP.CD_FILIAL_ENTREGA = FILENT.CD_FILIAL(+)" & _
                                 " AND CP.CD_TIPO_QUALIDADE = TQ.CD_TIPO_QUALIDADE(+)" & _
                                 " AND CP.CD_TIPO_CONDICAO_PAGAMENTO = TCPAG.CD_TIPO_CONDICAO_PAGAMENTO(+)" & _
                                 " AND F.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")" & _
                                 " AND ADT.CD_CONTRATO_PAF (+) = CP.CD_CONTRATO_PAF"

                If Pesq_Fornecedor.Codigo > 0 Then
                    SqlText = SqlText & " AND CP.CD_FORNECEDOR = " & Pesq_Fornecedor.Codigo
                End If
                If txtContrato.Text <> "" And IsNumeric(txtContrato.Text) Then
                    SqlText = SqlText & " AND CP.CD_CONTRATO_PAF = " & txtContrato.Text
                End If
                If IsDate(txtDataInicial.Value) Then
                    SqlText = SqlText & " AND CP.DT_CONTRATO_PAF >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Value))
                End If
                If IsDate(txtDataFinal.Value) Then
                    SqlText = SqlText & " AND CP.DT_CONTRATO_PAF <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Value))
                End If
                If SelecaoFilial.Lista_Quantidade > 0 Then
                    SqlText = SqlText & " AND F.cd_filial_origem in (" & SelecaoFilial.Lista_ID & ") "
                Else
                    SqlText = SqlText & " AND F.cd_filial_origem in (" & ListarIDFiliaisLiberadaUsuario() & ") "
                End If
                If ComboBox_LinhaSelecionada(cboTipoContratoPAF) Then
                    SqlText = SqlText & " AND CP.CD_TIPO_CONTRATO_PAF =" & cboTipoContratoPAF.SelectedValue
                End If
                If chkCtrNaoAssinado.Checked Then
                    SqlText = SqlText & " AND CP.DT_ASSINATURA_CONTRATO IS NULL "
                End If

                SqlText = SqlText & _
                           " ORDER BY CP.CD_CONTRATO_PAF"

                objGrid_Carregar(grdContratoPAF, SqlText, New Integer() {cnt_GridCtrPaf_IC_STATUS, cnt_GridCtrPaf_CD_CONTRATO_PAF, _
                                                                         cnt_GridCtrPaf_DT_CONTRATO_PAF, cnt_GridCtrPaf_DT_PRAZO_ENTREGA, _
                                                                         cnt_GridCtrPaf_DT_PRAZO_FIXACAO, cnt_GridCtrPaf_NO_RAZAO_SOCIAL, _
                                                                         cnt_GridCtrPaf_QT_KGS, cnt_GridCtrPaf_QT_KG_FIXO, _
                                                                         cnt_GridCtrPaf_QT_CANCELADO, cnt_GridCtrPaf_QT_SALDO, _
                                                                         cnt_GridCtrPaf_QT_A_NEGOCIAR, cnt_GridCtrPaf_VL_NF_FIXO, _
                                                                         cnt_GridCtrPaf_VL_PAG_FIXO, cnt_GridCtrPaf_NO_FILIAL, _
                                                                         cnt_GridCtrPaf_NO_REPASSADOR, cnt_GridCtrPaf_NO_TIPO_PESSOA, _
                                                                         cnt_GridCtrPaf_NO_TIPO_CONTRATO_PAF, cnt_GridCtrPaf_VL_ADIANTAMENTO, _
                                                                         cnt_GridCtrPaf_DS_SAFRA, cnt_GridCtrPaf_DS_SAFRA_COMPETENCIA, _
                                                                         cnt_GridCtrPaf_NO_TIPO_ACONDICIONAMENTO, cnt_GridCtrPaf_NO_TIPO_MODALIDADE_ENTREGA, _
                                                                         cnt_GridCtrPaf_NO_LOCAL_CONFERENCIA_PESO, cnt_GridCtrPaf_NO_LOCAL_CONFERENCIA_QUALIDADE, _
                                                                         cnt_GridCtrPaf_NO_TIPO_DESPESA_CARREGAMENTO, cnt_GridCtrPaf_IC_CALCULA_JUROS, _
                                                                         cnt_GridCtrPaf_QT_DIA_CARENCIA_JUROS, cnt_GridCtrPaf_IC_JUROS_APOS_CARENCIA, _
                                                                         cnt_GridCtrPaf_PC_TAXA_JUROS, cnt_GridCtrPaf_NO_UF, cnt_GridCtrPaf_NO_TIPO_QUALIDADE, _
                                                                         cnt_GridCtrPaf_NO_FILIAL_NF, cnt_GridCtrPaf_NO_FILIAL_ENTREGA, _
                                                                         cnt_GridCtrPaf_NO_TIPO_CONDICAO_PAGAMENTO, cnt_GridCtrPaf_CD_CONTRATO_PAF_ORIGEM, _
                                                                         cnt_GridCtrPaf_CD_FORNECEDOR, cnt_GridCtrPaf_CD_REPASSADOR, _
                                                                         cnt_GridCtrPaf_CD_TIPO_CONTRATO_PAF, cnt_GridCtrPaf_DT_VENCIMENTO, _
                                                                         cnt_GridCtrPaf_CD_FILIAL_ORIGEM, cnt_GridCtrPaf_CD_SAFRA, cnt_GridCtrPaf_DT_CRIACAO, _
                                                                         cnt_GridCtrPaf_NO_USER_CRIACAO, cnt_GridCtrPaf_DT_ALTERACAO, cnt_GridCtrPaf_NO_USER_ALTERACAO, _
                                                                         cnt_GridCtrPaf_VL_NF_INSS_FIXO, cnt_GridCtrPaf_VL_NF_ICMS_FIXO, cnt_GridCtrPaf_CD_SAFRA_COMPETENCIA, _
                                                                         cnt_GridCtrPaf_CD_TIPO_ACONDICIONAMENTO, cnt_GridCtrPaf_CD_TIPO_MODALIDADE_ENTREGA, _
                                                                         cnt_GridCtrPaf_CD_TIPO_DESPESA_CARREGAMENTO, cnt_GridCtrPaf_CD_LOCAL_CONFERENCIA_PESO, _
                                                                         cnt_GridCtrPaf_CD_LOCAL_CONFERENCIA_QUALIDADE, cnt_GridCtrPaf_CD_TIPO_PESSOA, _
                                                                         cnt_GridCtrPaf_IC_ADIANTAMENTO, cnt_GridCtrPaf_CD_VERSAO_CONTRATO, _
                                                                         cnt_GridCtrPaf_DT_ASSINATURA_CONTRATO, cnt_GridCtrPaf_QT_ADITIVO})
            Case cnt_TAB_Negociacao
                grpIconeNegociacao.Visible = True
                SqlText = "SELECT N.IC_STATUS," & _
                                 "N.CD_CONTRATO_PAF," & _
                                 "N.SQ_NEGOCIACAO," & _
                                 "N.DT_NEGOCIACAO," & _
                                 "N.DT_PRAZO_FIXACAO," & _
                                 "N.DT_PAGAMENTO," & _
                                 "N.DT_VENCIMENTO," & _
                                 "F.NO_RAZAO_SOCIAL," & _
                                 "N.QT_KGS," & _
                                 "N.QT_KG_FIXO," & _
                                 "N.QT_CANCELADO," & _
                                 "N.QT_EM_RENEGOCIACAO," & _
                                 "NVL(N.QT_KGS, 0) - NVL(N.QT_KG_FIXO, 0) - NVL(N.QT_CANCELADO, 0) - NVL(N.QT_EM_RENEGOCIACAO, 0) QT_SALDO," & _
                                 "(N.QT_A_FIXAR) QT_A_FIXAR," & _
                                 "N.VL_NEGOCIACAO," & _
                                 "N.CD_PAPEL_COMPETENCIA," & _
                                 "TP.NO_TIPO_PRECO," & _
                                 "TU.NO_TIPO_UNIDADE," & _
                                 "N.PC_ALIQ_ICMS," & _
                                 "N.VL_PRECO_FRETE," & _
                                 "N.IC_CALCULA_JUROS," & _
                                 "N.PC_TAXA_JUROS," & _
                                 "N.QT_DIA_CARENCIA_JUROS," & _
                                 "N.IC_JUROS_APOS_CARENCIA," & _
                                 "N.VL_NF_FIXO," & _
                                 "N.VL_PAG_FIXO," & _
                                 "LC.NO_LOCAL_ENTREGA," & _
                                 "FE.NO_FILIAL NO_FILIAL_ENTREGA," & _
                                 "FIL.NO_FILIAL," & _
                                 "R.NO_RAZAO_SOCIAL NO_REPASSADOR," & _
                                 "TPP.NO_TIPO_PESSOA," & _
                                 "TN.NO_TIPO_NEGOCIACAO," & _
                                 "S.DS_SAFRA," & _
                                 "N.IC_BONUS," & _
                                 "N.CD_PAPEL," & _
                                 "N.VL_BOLSA," & _
                                 "N.VL_BOLSA_ALTERNATIVO," & _
                                 "N.VL_TAXA_DOLAR," & _
                                 "N.VL_TAXA_DOLAR_ALTERNATIVO," & _
                                 "N.VL_DIFERENCIAL," & _
                                 "N.QT_UMIDADE_PADRAO," & _
                                 "N.PC_SUJIDADE_PADRAO," & _
                                 "TC.NO_TIPO_CACAU," & _
                                 "N.CD_TIPO_UNIDADE," & _
                                 "N.CD_TIPO_NEGOCIACAO," & _
                                 "N.CD_TIPO_PRECO," & _
                                 "N.CD_LOCAL_ENTREGA," & _
                                 "N.CD_SAFRA," & _
                                 "N.DT_CRIACAO," & _
                                 "N.NO_USER_CRIACAO," & _
                                 "N.DT_ALTERACAO," & _
                                 "N.NO_USER_ALTERACAO," & _
                                 "N.VL_NF_INSS_FIXO," & _
                                 "N.VL_NF_ICMS_FIXO," & _
                                 "F.CD_FILIAL_ORIGEM," & _
                                 "TN.IC_BOLSA," & _
                                 "TN.IC_BOLSA_OPERACAO," & _
                                 "TN.IC_DOLAR," & _
                                 "TN.IC_TIPO_PRECO_FIXO," & _
                                 "F.CD_TIPO_PESSOA," & _
                                 "TPPR.CD_TIPO_PESSOA CD_TIPO_PESSOA_REPASSADOR," & _
                                 "TPPR.NO_TIPO_PESSOA NO_TIPO_PESSOA_REPASSADOR," & _
                                 "N.IC_IMPRIME_CTR_PAF," & _
                                 "N.VL_DIFERENCIAL_REAL," & _
                                 "ROUND(N.VL_DIFERENCIAL - N.VL_DIFERENCIAL_REAL, 4) VL_DIFF_DIFERENCIAL," & _
                                 "NVL(ADT.QT_ADITIVO, 0) QT_ADITIVO" & _
                          " FROM SOF.TIPO_UNIDADE TU," & _
                                "SOF.TIPO_PRECO TP," & _
                                "SOF.FORNECEDOR F," & _
                                "SOF.FORNECEDOR R," & _
                                "SOF.LOCAL_ENTREGA LC," & _
                                "SOF.SAFRA S," & _
                                "SOF.TIPO_NEGOCIACAO TN," & _
                                "SOF.CONTRATO_PAF CP," & _
                                "SOF.TIPO_PESSOA TPP," & _
                                "SOF.TIPO_PESSOA TPPR," & _
                                "SOF.NEGOCIACAO N," & _
                                "SOF.FILIAL FIL," & _
                                "SOF.FILIAL FE," & _
                                "SOF.TIPO_CACAU TC," & _
                                "(SELECT CD_CONTRATO_PAF," & _
                                        "SQ_NEGOCIACAO," & _
                                        "COUNT(*) QT_ADITIVO" & _
                                 " FROM SOF.CONTRATO_ADITIVO" & _
                                 " WHERE SQ_NEGOCIACAO IS NOT NULL" & _
                                   " AND SQ_CONTRATO_FIXO IS NULL" & _
                                 " GROUP BY CD_CONTRATO_PAF," & _
                                           "SQ_NEGOCIACAO) ADT" & _
                          " WHERE N.CD_CONTRATO_PAF = CP.CD_CONTRATO_PAF" & _
                            " AND CP.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                            " AND CP.CD_REPASSADOR = R.CD_FORNECEDOR" & _
                            " AND N.CD_TIPO_NEGOCIACAO = TN.CD_TIPO_NEGOCIACAO" & _
                            " AND N.CD_TIPO_PRECO = TP.CD_TIPO_PRECO" & _
                            " AND N.CD_TIPO_UNIDADE = TU.CD_TIPO_UNIDADE" & _
                            " AND N.CD_LOCAL_ENTREGA = LC.CD_LOCAL_ENTREGA" & _
                            " AND N.CD_SAFRA = S.CD_SAFRA" & _
                            " AND F.CD_TIPO_PESSOA = TPP.CD_TIPO_PESSOA" & _
                            " AND F.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                            " AND R.CD_TIPO_PESSOA = TPPR.CD_TIPO_PESSOA" & _
                            " AND N.CD_TIPO_CACAU = TC.CD_TIPO_CACAU (+)" & _
                            " AND  N.CD_FILIAL_ENTREGA = FE.CD_FILIAL (+) " & _
                            " AND F.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")" & _
                            " AND ADT.CD_CONTRATO_PAF (+) = N.CD_CONTRATO_PAF" & _
                            " AND ADT.SQ_NEGOCIACAO (+) = N.SQ_NEGOCIACAO"

                If Pesq_Fornecedor.Codigo > 0 Then
                    SqlText = SqlText & " AND CP.CD_FORNECEDOR = " & Pesq_Fornecedor.Codigo
                End If
                If txtContrato.Text <> "" And IsNumeric(txtContrato.Text) Then
                    SqlText = SqlText & " AND CP.CD_CONTRATO_PAF = " & txtContrato.Text
                End If
                If IsDate(txtDataInicial.Value) Then
                    SqlText = SqlText & " AND N.DT_NEGOCIACAO >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Value))
                End If
                If IsDate(txtDataFinal.Value) Then
                    SqlText = SqlText & " AND N.DT_NEGOCIACAO <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Value))
                End If
                If ComboBox_LinhaSelecionada(cboTipoCacau) Then
                    SqlText = SqlText & " AND N.CD_TIPO_CACAU = " & cboTipoCacau.SelectedValue
                End If
                If SelecaoFilial.Lista_Quantidade > 0 Then
                    SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & SelecaoFilial.Lista_ID & ") "
                Else
                    SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ") "
                End If

                objGrid_Carregar(grdNegociacao, SqlText, New Integer() {cnt_GridNegociacao_IC_STATUS, cnt_GridNegociacao_CD_CONTRATOPAF, _
                                                                        cnt_GridNegociacao_SQ_NEGOCIACAO, cnt_GridNegociacao_DT_NEGOCIACAO, _
                                                                        cnt_GridNegociacao_DT_PRAZO_FIXACAO, cnt_GridNegociacao_DT_PAGAMENTO, _
                                                                        cnt_GridNegociacao_DT_VENCIMENTO, cnt_GridNegociacao_NO_RAZAO_SOCIAL, _
                                                                        cnt_GridNegociacao_QT_KGS, cnt_GridNegociacao_QT_KG_FIXO, _
                                                                        cnt_GridNegociacao_QT_CANCELADO, cnt_GridNegociacao_QT_EM_RENEGOCIACAO, _
                                                                        cnt_GridNegociacao_QT_SALDO, cnt_GridNegociacao_QT_A_FIXAR, _
                                                                        cnt_GridNegociacao_VL_NEGOCIACAO, cnt_GridNegociacao_CD_PAPEL_COMPETENCIA, _
                                                                        cnt_GridNegociacao_NO_TIPO_PRECO, cnt_GridNegociacao_NO_TIPO_UNIDADE, _
                                                                        cnt_GridNegociacao_PC_ALIQ_ICMS, cnt_GridNegociacao_VL_PRECO_FRETE, _
                                                                        cnt_GridNegociacao_IC_CALCULA_JUROS, cnt_GridNegociacao_PC_TAXA_JUROS, _
                                                                        cnt_GridNegociacao_QT_DIA_CARENCIA_JUROS, cnt_GridNegociacao_IC_JUROS_APOS_CARENCIA, _
                                                                        cnt_GridNegociacao_VL_NF_FIXO, cnt_GridNegociacao_VL_PAG_FIXO, _
                                                                        cnt_GridNegociacao_NO_LOCAL_ENTREGA, cnt_GridNegociacao_NO_FILIAL_ENTREGA, _
                                                                        cnt_GridNegociacao_NO_FILIAL, cnt_GridNegociacao_NO_REPASSADOR, _
                                                                        cnt_GridNegociacao_NO_TIPO_PESSOA, cnt_GridNegociacao_NO_TIPO_NEGOCIACAO, _
                                                                        cnt_GridNegociacao_DS_SAFRA, cnt_GridNegociacao_IC_BONUS, _
                                                                        cnt_GridNegociacao_CD_PAPEL, cnt_GridNegociacao_VL_BOLSA, _
                                                                        cnt_GridNegociacao_VL_BOLSA_ALTERNATIVO, cnt_GridNegociacao_VL_TAXA_DOLAR, _
                                                                        cnt_GridNegociacao_VL_TAXA_DOLAR_ALTERNATIVO, cnt_GridNegociacao_VL_DIFERENCIAL, _
                                                                        cnt_GridNegociacao_QT_UMIDADE_PADRAO, cnt_GridNegociacao_PC_SUJIDADE_PADRAO, _
                                                                        cnt_GridNegociacao_NO_TIPO_CACAU, cnt_GridNegociacao_CD_TIPO_UNIDADE, _
                                                                        cnt_GridNegociacao_CD_TIPO_NEGOCIACAO, cnt_GridNegociacao_CD_TIPO_PRECO, _
                                                                        cnt_GridNegociacao_CD_LOCAL_ENTREGA, cnt_GridNegociacao_CD_SAFRA, _
                                                                        cnt_GridNegociacao_DT_CRIACAO, cnt_GridNegociacao_NO_USER_CRIACAO, _
                                                                        cnt_GridNegociacao_DT_ALTERACAO, cnt_GridNegociacao_NO_USER_ALTERACAO, _
                                                                        cnt_GridNegociacao_VL_NF_INSS_FIXO, cnt_GridNegociacao_VL_NF_ICMS_FIXO, _
                                                                        cnt_GridNegociacao_CD_FILIAL_ORIGEM, cnt_GridNegociacao_IC_BOLSA, _
                                                                        cnt_GridNegociacao_IC_BOLSA_OPERACAO, cnt_GridNegociacao_IC_DOLAR, _
                                                                        cnt_GridNegociacao_IC_TIPO_PRECO_FIXO, cnt_GridNegociacao_CD_TIPO_PESSOA, _
                                                                        cnt_GridNegociacao_CD_TIPO_PESSOA_REPASSADOR, cnt_GridNegociacao_NO_TIPO_PESSOA_REPASSADOR, _
                                                                        cnt_GridNegociacao_IC_IMPRIME_CTR_PAF, cnt_GridNegociacao_DiferencialReal, _
                                                                        cnt_GridNegociacao_DiffDiferencial, cnt_GridNegociacao_QT_ADITIVO})
            Case cnt_TAB_ContratoFixo
                grpIconeContratoFixo.Visible = True
                SqlText = "SELECT CF.IC_STATUS," & _
                                 "CF.CD_CONTRATO_PAF," & _
                                 "CF.SQ_NEGOCIACAO," & _
                                 "CF.SQ_CONTRATO_FIXO," & _
                                 "CF.DT_CONTRATO_FIXO," & _
                                 "CF.DT_VENCIMENTO," & _
                                 "CF.DT_PAGAMENTO," & _
                                 "FORN.NO_RAZAO_SOCIAL," & _
                                 "CF.QT_KGS," & _
                                 "CF.QT_KG_FIXO," & _
                                 "CF.QT_CANCELADO," & _
                                 "CF.QT_KGS - CF.QT_KG_FIXO - CF.QT_CANCELADO QT_SALDO," & _
                                 "CF.VL_UNITARIO," & _
                                 "TU.NO_TIPO_UNIDADE," & _
                                 "CF.PC_ALIQ_ICMS," & _
                                 "CF.VL_TOTAL," & _
                                 "CF.VL_ICMS," & _
                                 "CF.VL_INSS," & _
                                 "CF.VL_ADENDO," & _
                                 "CF.VL_ADENDO_ICMS," & _
                                 "CF.VL_ADENDO_INSS," & _
                                 "CF.VL_NF_FIXO," & _
                                 "CF.VL_PAG_FIXO," & _
                                 "CF.VL_TAXA_DOLAR_FECHADO," & _
                                 "CF.VL_BOLSA_FECHADO," & _
                                 "FIL.NO_FILIAL," & _
                                 "REP.NO_RAZAO_SOCIAL NO_REPASSADOR," & _
                                 "TP.NO_TIPO_PESSOA," & _
                                 "S.DS_SAFRA," & _
                                 "CF.CD_PAPEL," & _
                                 "CF.VL_BOLSA," & _
                                 "CF.VL_BOLSA_ALTERNATIVO," & _
                                 "CF.VL_TAXA_DOLAR," & _
                                 "CF.VL_TAXA_DOLAR_ALTERNATIVO," & _
                                 "CF.VL_DIFERENCIAL," & _
                                 "CF.IC_TAXA_DOLAR_VARIAVEL," & _
                                 "CF.VL_TAXA_DOLAR_FIXACAO," & _
                                 "CF.VL_TAXA_DOLAR_FECHAMENTO," & _
                                 "CF.VL_UNITARIO_US," & _
                                 "CF.DT_FECHAMENTO_TAXA_DOLAR," & _
                                 "CF.IC_INCLUI_ICMS_PAG," & _
                                 "CF.DT_VENCIMENTO_GP," & _
                                 "CF.DT_CRIACAO," & _
                                 "CF.NO_USER_CRIACAO," & _
                                 "CF.DT_ALTERACAO," & _
                                 "CF.NO_USER_ALTERACAO," & _
                                 "FORN.CD_FILIAL_ORIGEM, " & _
                                 "FORN.CD_TIPO_PESSOA," & _
                                 "TN.IC_TIPO_PRECO_FIXO," & _
                                 "CF.IC_GP," & _
                                 "TN.NO_TIPO_NEGOCIACAO," & _
                                 "CF.VL_DIFERENCIAL_REAL," & _
                                 "ROUND(CF.VL_DIFERENCIAL - CF.VL_DIFERENCIAL_REAL, 4) VL_DIFF_DIFERENCIAL," & _
                                 "NVL(ADT.QT_ADITIVO, 0) QT_ADITIVO" & _
                          " FROM SOF.CONTRATO_FIXO CF," & _
                                "SOF.NEGOCIACAO N," & _
                                "SOF.CONTRATO_PAF CP," & _
                                "SOF.FORNECEDOR FORN," & _
                                "SOF.FORNECEDOR REP," & _
                                "SOF.TIPO_UNIDADE TU," & _
                                "SOF.FILIAL FIL," & _
                                "SOF.TIPO_PESSOA TP," & _
                                "SOF.SAFRA S," & _
                                "SOF.TIPO_NEGOCIACAO TN," & _
                                "(SELECT CD_CONTRATO_PAF," & _
                                        "SQ_NEGOCIACAO," & _
                                        "SQ_CONTRATO_FIXO," & _
                                        "COUNT(*) QT_ADITIVO" & _
                                 " FROM SOF.CONTRATO_ADITIVO" & _
                                 " WHERE SQ_CONTRATO_FIXO IS NOT NULL" & _
                                 " GROUP BY CD_CONTRATO_PAF," & _
                                           "SQ_NEGOCIACAO," & _
                                           "SQ_CONTRATO_FIXO) ADT" & _
                          " WHERE N.CD_CONTRATO_PAF = CF.CD_CONTRATO_PAF" & _
                            " AND N.SQ_NEGOCIACAO = CF.SQ_NEGOCIACAO" & _
                            " AND CP.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF" & _
                            " AND FORN.CD_FORNECEDOR = CP.CD_FORNECEDOR" & _
                            " AND REP.CD_FORNECEDOR = CP.CD_REPASSADOR" & _
                            " AND TU.CD_TIPO_UNIDADE = CF.CD_TIPO_UNIDADE" & _
                            " AND FIL.CD_FILIAL = FORN.CD_FILIAL_ORIGEM" & _
                            " AND TP.CD_TIPO_PESSOA = FORN.CD_TIPO_PESSOA" & _
                            " AND S.CD_SAFRA = CF.CD_SAFRA" & _
                            " AND N.CD_TIPO_NEGOCIACAO = TN.CD_TIPO_NEGOCIACAO" & _
                            " AND FORN.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")" & _
                            " AND ADT.CD_CONTRATO_PAF (+) = CF.CD_CONTRATO_PAF" & _
                            " AND ADT.SQ_NEGOCIACAO (+) = CF.SQ_NEGOCIACAO" & _
                            " AND ADT.SQ_CONTRATO_FIXO (+) = CF.SQ_CONTRATO_FIXO"

                If Pesq_Fornecedor.Codigo > 0 Then
                    SqlText = SqlText & " AND CP.CD_FORNECEDOR = " & Pesq_Fornecedor.Codigo
                End If
                If txtContrato.Text <> "" And IsNumeric(txtContrato.Text) Then
                    SqlText = SqlText & " AND CP.CD_CONTRATO_PAF = " & txtContrato.Text
                End If
                If IsDate(txtDataInicial.Value) Then
                    SqlText = SqlText & " AND CF.DT_CONTRATO_FIXO >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Value))
                End If
                If IsDate(txtDataFinal.Value) Then
                    SqlText = SqlText & " AND CF.DT_CONTRATO_FIXO <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Value))
                End If
                If SelecaoFilial.Lista_Quantidade > 0 Then
                    SqlText = SqlText & " AND FORN.CD_FILIAL_ORIGEM IN (" & SelecaoFilial.Lista_ID & ") "
                Else
                    SqlText = SqlText & " AND FORN.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ") "
                End If

                objGrid_Carregar(grdContratoFixo, SqlText, New Integer() {cnt_GridCtrFixo_IC_STATUS, cnt_GridCtrFixo_CD_CONTRATO_PAF, _
                                                                          cnt_GridCtrFixo_SQ_NEGOCIACAO, cnt_GridCtrFixo_SQ_CONTRATO_FIXO, _
                                                                          cnt_GridCtrFixo_DT_CONTRATO_FIXO, cnt_GridCtrFixo_DT_VENCIMENTO, _
                                                                          cnt_GridCtrFixo_DT_PAGAMENTO, cnt_GridCtrFixo_NO_RAZAO_SOCIAL, _
                                                                          cnt_GridCtrFixo_QT_KGS, cnt_GridCtrFixo_QT_KG_FIXO, _
                                                                          cnt_GridCtrFixo_QT_CANCELADO, cnt_GridCtrFixo_QT_SALDO, _
                                                                          cnt_GridCtrFixo_VL_UNITARIO, cnt_GridCtrFixo_NO_TIPO_UNIDADE, _
                                                                          cnt_GridCtrFixo_PC_ALIQ_ICMS, cnt_GridCtrFixo_VL_TOTAL, _
                                                                          cnt_GridCtrFixo_VL_ICMS, cnt_GridCtrFixo_VL_INSS, _
                                                                          cnt_GridCtrFixo_VL_ADENDO, cnt_GridCtrFixo_VL_ADENDO_ICMS, _
                                                                          cnt_GridCtrFixo_VL_ADENDO_INSS, cnt_GridCtrFixo_VL_NF_FIXO, _
                                                                          cnt_GridCtrFixo_VL_PAG_FIXO, cnt_GridCtrFixo_VL_TAXA_DOLAR_FECHADO, _
                                                                          cnt_GridCtrFixo_VL_BOLSA_FECHADO, cnt_GridCtrFixo_NO_FILIAL, _
                                                                          cnt_GridCtrFixo_NO_REPASSADOR, cnt_GridCtrFixo_NO_TIPO_PESSOA, _
                                                                          cnt_GridCtrFixo_DS_SAFRA, cnt_GridCtrFixo_CD_PAPEL, _
                                                                          cnt_GridCtrFixo_VL_BOLSA, cnt_GridCtrFixo_VL_BOLSA_ALTERNATIVO, _
                                                                          cnt_GridCtrFixo_VL_TAXA_DOLAR, cnt_GridCtrFixo_VL_TAXA_DOLAR_ALTERNATIVO, _
                                                                          cnt_GridCtrFixo_VL_DIFERENCIAL, cnt_GridCtrFixo_IC_TAXA_DOLAR_VARIAVEL, _
                                                                          cnt_GridCtrFixo_VL_TAXA_DOLAR_FIXACAO, cnt_GridCtrFixo_VL_TAXA_DOLAR_FECHAMENTO, _
                                                                          cnt_GridCtrFixo_VL_UNITARIO_US, cnt_GridCtrFixo_DT_FECHAMENTO_TAXA_DOLAR, _
                                                                          cnt_GridCtrFixo_IC_INCLUI_ICMS_PAG, cnt_GridCtrFixo_DT_VENCIMENTO_GP, _
                                                                          cnt_GridCtrFixo_DT_CRIACAO, cnt_GridCtrFixo_NO_USER_CRIACAO, _
                                                                          cnt_GridCtrFixo_DT_ALTERACAO, cnt_GridCtrFixo_NO_USER_ALTERACAO, _
                                                                          cnt_GridCtrFixo_CD_FILIAL_ORIGEM, cnt_GridCtrFixo_CD_TIPO_PESSOA, _
                                                                          cnt_GridCtrFixo_IC_TIPO_PRECO_FIXO, cnt_GridCtrFixo_IC_GP, _
                                                                          cnt_GridCtrFixo_NO_TIPO_NEGOCIACAO, cnt_GridCtrFixo_DiferencialReal, _
                                                                          cnt_GridCtrFixo_DiffDiferencial, cnt_GridCtrFixo_QT_ADITIVO})

                ContratoFixo_GridIdentificar(cnt_GridCtrFixo_DT_VENCIMENTO_GP, cnt_GridCtrFixo_IC_GP)
        End Select
    End Sub

    Private Sub Form_Inicializar()
        BotaoStatus_Formatar(cmdStatusFechaAbre_CtrPaF, cnt_BotaoStatus_Fechar)
        BotaoStatus_Formatar(cmdStatusFechaAbre_Neg, cnt_BotaoStatus_Fechar)
        BotaoStatus_Formatar(cmdStatusFechaAbre_CtrFix, cnt_BotaoStatus_Fechar)

        cmdStatusFechaAbre_CtrPaF.Visible = False
        cmdStatusFechaAbre_Neg.Visible = False
        cmdStatusFechaAbre_CtrFix.Visible = False
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        Pesquisar()
    End Sub

    Private Sub BotaoStatus_Formatar(ByVal oBotao As Misc.UltraButton, _
                                     ByVal NovoTipo As Integer)
        oBotao.Appearance.Image = IIf(NovoTipo = cnt_BotaoStatus_Abrir, _
                                      picStatus_Abrir.Image, _
                                      picStatus_Fechar.Image)
        oBotao.Tag = NovoTipo
    End Sub

    Private Sub cmdCtrFix_Status_FechaAbre_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdStatusFechaAbre_CtrFix.Click
        If objGrid_LinhaSelecionada(grdContratoFixo) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        If objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_IC_STATUS) = "E" Then Exit Sub

        If objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_IC_STATUS) = "A" Then
            If Msg_Perguntar("Fecha o Contrato Fixo ?") = False Then Exit Sub
            MUDA_SITUACAO_CONTRATO_FIXO(objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_CD_CONTRATO_PAF), _
                             objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_SQ_NEGOCIACAO), _
                             objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_SQ_CONTRATO_FIXO), "F")
        Else
            If Msg_Perguntar("Abre o Contrato Fixo ?") = False Then Exit Sub
            MUDA_SITUACAO_CONTRATO_FIXO(objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_CD_CONTRATO_PAF), _
                             objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_SQ_NEGOCIACAO), _
                             objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_SQ_CONTRATO_FIXO), "A")
        End If

        Pesquisar()
    End Sub

    Private Sub cmdCtrPaF_Status_FechaAbre_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdStatusFechaAbre_CtrPaF.Click
        If objGrid_LinhaSelecionada(grdContratoPAF) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        If objGrid_Valor(grdContratoPAF, cnt_GridCtrPaf_IC_STATUS) = "A" Then
            If objGrid_Valor(grdContratoPAF, cnt_GridCtrPaf_IC_STATUS) = "F" Or objGrid_Valor(grdContratoPAF, cnt_GridCtrPaf_IC_STATUS) = "E" Then Exit Sub
            If Msg_Perguntar("Fecha o contrato PAF ?") = False Then Exit Sub
            MUDA_SITUACAO_CONTRATO_PAF(objGrid_Valor(grdContratoPAF, cnt_GridCtrPaf_CD_CONTRATO_PAF), "F")
        Else
            If objGrid_Valor(grdContratoPAF, cnt_GridCtrPaf_IC_STATUS) = "A" Or objGrid_Valor(grdContratoPAF, cnt_GridCtrPaf_IC_STATUS) = "E" Then Exit Sub
            If Msg_Perguntar("Abre o contrato PAF ?") = False Then Exit Sub
            MUDA_SITUACAO_CONTRATO_PAF(objGrid_Valor(grdContratoPAF, cnt_GridCtrPaf_CD_CONTRATO_PAF), "A")
        End If

        Pesquisar()
    End Sub

    Private Function StatusValido_ContratoPAF() As Boolean
        If objGrid_Valor(grdContratoPAF, cnt_GridCtrPaf_IC_STATUS) = cnt_Contrato_Status_Fechado Then
            Msg_Mensagem("Contrato PAF já fechado.")
            Return False
        End If
        If objGrid_Valor(grdContratoPAF, cnt_GridCtrPaf_IC_STATUS) = cnt_Contrato_Status_Excluido Then
            Msg_Mensagem("Contrato PAF já eliminado.")
            Return False
        End If

        Return True
    End Function

    Private Function StatusValido_Negociacao() As Boolean
        If objGrid_Valor(grdNegociacao, cnt_GridNegociacao_IC_STATUS) = cnt_Contrato_Status_Fechado Then
            Msg_Mensagem("Contrato PAF já fechado.")
            Return False
        End If
        If objGrid_Valor(grdNegociacao, cnt_GridNegociacao_IC_STATUS) = cnt_Contrato_Status_Excluido Then
            Msg_Mensagem("Contrato PAF já eliminado.")
            Return False
        End If

        Return True
    End Function

    Private Function StatusValido_ContratoFixo() As Boolean
        If objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_IC_STATUS) = cnt_Contrato_Status_Fechado Then
            Msg_Mensagem("Contrato PAF já fechado.")
            Return False
        End If
        If objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_IC_STATUS) = cnt_Contrato_Status_Excluido Then
            Msg_Mensagem("Contrato PAF já eliminado.")
            Return False
        End If

        Return True
    End Function

    Private Sub cmdCtrPaF_Alterar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAlterar_CtrPaF.Click
        If objGrid_LinhaSelecionada(grdContratoPAF) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        If Not StatusValido_ContratoPAF() Then Exit Sub

        Dim oForm As New frmCadastroContratoPAF_Alteracao

        oForm.CD_CONTRATO_PAF = objGrid_Valor(grdContratoPAF, cnt_GridCtrPaf_CD_CONTRATO_PAF)

        Form_Show(Nothing, oForm, True, True)

        If Not oForm.Cancelado Then Pesquisar()

        oForm.Dispose()
    End Sub

    Private Sub CtrPaF_Excluir()
        If objGrid_LinhaSelecionada(grdContratoPAF) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Dim SqlText As String

        If Not StatusValido_ContratoPAF() Then Exit Sub

        If CDate(objGrid_Valor(grdContratoPAF, cnt_GridCtrPaf_DT_CONTRATO_PAF)) <> CDate(DataSistema()) Then
            Msg_Mensagem("Este Contrato PAF foi criado em uma data diferente da data atual," & _
                         " por esse motivo não é possível prosseguir com a exclusão do mesmo.")
            Exit Sub
        End If

        SqlText = "SELECT COUNT(*) " & _
                  " FROM SOF.FILIAL " & _
                  " WHERE CD_FILIAL = " & objGrid_Valor(grdContratoPAF, cnt_GridCtrPaf_CD_FILIAL_ORIGEM) & _
                    " AND CD_FILIAL IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        If DBQuery_ValorUnico(SqlText) = 0 Then
            Msg_Mensagem("Usuário sem acesso a filial desse Contrato PAF")
            Exit Sub
        End If

        If Not Msg_Perguntar("Elimina o contrato PAF ?") Then Exit Sub

        On Error GoTo Erro

        If FilialFechada(FilialLogada) Then Exit Sub

        SqlText = DBMontar_SP("SOF.SP_ELIMINA_CONTRATO_PAF", False, ":CTR")

        If Not DBExecutar(SqlText, DBParametro_Montar("CTR", objGrid_Valor(grdContratoPAF, cnt_GridCtrPaf_CD_CONTRATO_PAF))) Then GoTo Erro

        Pesquisar()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub CtrPaF_Cancelar()
        If objGrid_LinhaSelecionada(grdContratoPAF) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        If Not StatusValido_ContratoPAF() Then Exit Sub

        Dim oForm As New frmCancelamento_SolicitarQuantidade

        Form_Show(Nothing, oForm, True, True)

        If Not oForm.Cancelado Then
            If Cancela_Contrato_PAF(objGrid_Valor(grdContratoPAF, cnt_GridCtrPaf_CD_CONTRATO_PAF), _
                                    oForm.txtQuantidade.Value, _
                                    oForm.txtMotivo.Text) = True Then
                Pesquisar()
            End If
        End If

        oForm.Dispose()
    End Sub

    Private Sub CtrPaF_Descancelar()
        If objGrid_LinhaSelecionada(grdContratoPAF) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Dim oForm As New frmConsultaGeral

        oForm.FiltroLocal_01 = objGrid_Valor(grdContratoPAF, cnt_GridCtrPaf_CD_CONTRATO_PAF)
        oForm.FormatarTela(frmConsultaGeral.eConsultaGeral.Cancelamento_ContratoPAF)

        Form_Show(Nothing, oForm, True, True)

        If oForm.GerouAlteracaoInformacao Then Pesquisar()

        oForm.Dispose()
    End Sub

    Private Sub cmdCtrPaF_Excell_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExcell_CtrPaF.Click
        objGrid_ExportarExcell(grdContratoPAF, Me.Text, cmdExcell_CtrPaF)
    End Sub

    Private Sub cmdCtrPaF_Imprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdImprimir_CtrPaF.Click
        If objGrid_LinhaSelecionada(grdContratoPAF) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If
        If objGrid_Valor(grdContratoPAF, cnt_GridCtrPaf_IC_STATUS) = cnt_Contrato_Status_Excluido Then
            Msg_Mensagem("Contrato eliminado.")
            Exit Sub
        End If
        If objGrid_Valor(grdContratoPAF, cnt_GridCtrPaf_QT_ADITIVO) = 0 Then
            Impressao_ContratoPAF(objGrid_Valor(grdContratoPAF, cnt_GridCtrPaf_CD_CONTRATO_PAF))
        Else
            PopUp_Aditivo(objGrid_Valor(grdContratoPAF, cnt_GridCtrPaf_CD_CONTRATO_PAF))
        End If
    End Sub

    Private Sub cmdCtrPaF_Juros_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCtrPaF_Juros.Click
        If objGrid_LinhaSelecionada(grdContratoPAF) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If
        If objGrid_Valor(grdContratoPAF, cnt_GridCtrPaf_VL_ADIANTAMENTO) = "N" Then
            Msg_Mensagem("Esse tipo de contrato não pode ser cobrado juros")
            Exit Sub
        End If

        Dim oForm As New frmCadastroContratoPAF_AlteracaoJuros

        oForm.CD_Contrato_PAF = objGrid_Valor(grdContratoPAF, cnt_GridCtrPaf_CD_CONTRATO_PAF)

        Form_Show(Nothing, oForm, True, True)

        oForm.Dispose()
    End Sub

    Private Sub cmdCtrPaF_Novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCtrPaF_Novo.Click
        Form_Show(Me.MdiParent, frmCadastroContratoPAF)
    End Sub

    Private Sub cmdCtrPaF_Resumo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCtrPaF_Resumo.Click
        Dim oForm As New frmCadastroContratoResumo
        Dim oData As New DataTable
        Dim oRow As DataRow
        Dim iCont_01 As Integer
        Dim iCont_02 As Integer
        Dim bAchou As Boolean
        Dim Kg As Double = 0
        Dim Kg_Cancelado As Double = 0
        Dim Quantidade As Double = 0

        With oData.Columns
            .Add("CD_TIPO_PESSOA")
            .Add("NO_TIPO_PESSOA")
            .Add("VALOR").DataType = System.Type.GetType("System.Double")
            .Add("VALOR_US").DataType = System.Type.GetType("System.Double")
            .Add("QUANTIDADE").DataType = System.Type.GetType("System.Double")
        End With

        For iCont_01 = 0 To grdContratoPAF.Rows.Count - 1
            bAchou = False

            With grdContratoPAF.Rows(iCont_01)
                If .Cells(cnt_GridCtrPaf_IC_STATUS).Value <> cnt_Contrato_Status_Excluido Then
                    Kg = Kg + .Cells(cnt_GridCtrPaf_QT_KGS).Value
                    Kg_Cancelado = Kg_Cancelado + .Cells(cnt_GridCtrPaf_QT_CANCELADO).Value
                    Quantidade = .Cells(cnt_GridCtrPaf_QT_KGS).Value - .Cells(cnt_GridCtrPaf_QT_CANCELADO).Value

                    For iCont_02 = 0 To oData.Rows.Count - 1
                        If oData.Rows(iCont_02).Item("CD_TIPO_PESSOA") = _
                           .Cells(cnt_GridCtrPaf_CD_TIPO_PESSOA).Value Then
                            oData.Rows(iCont_02).Item("QUANTIDADE") = oData.Rows(iCont_02).Item("QUANTIDADE") + _
                                                                      Quantidade
                            bAchou = True
                        End If
                    Next

                    If Not bAchou Then
                        oRow = oData.NewRow

                        oRow.Item("CD_TIPO_PESSOA") = .Cells(cnt_GridCtrPaf_CD_TIPO_PESSOA).Value
                        oRow.Item("NO_TIPO_PESSOA") = .Cells(cnt_GridCtrPaf_NO_TIPO_PESSOA).Value
                        oRow.Item("VALOR") = 0
                        oRow.Item("VALOR_US") = 0
                        oRow.Item("QUANTIDADE") = Quantidade

                        oData.Rows.Add(oRow)
                    End If
                End If

            End With
        Next

        oForm.Par_SubTotal_03 = Kg
        oForm.Par_Cancelados_03 = Kg_Cancelado
        oForm.Par_Total_03 = (Kg - Kg_Cancelado)
        oForm.Carregar(frmCadastroContratoResumo.TipoTela.ContratoPAF, oData)

        Form_Show(Nothing, oForm, True, True)

        oForm.Dispose()
        oData.Dispose()
    End Sub

    Private Sub cmdUsuario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdUsuario.Click
        Select Case tbcGeral.SelectedIndex
            Case cnt_TAB_ContratoPAF
                If objGrid_LinhaSelecionada(grdContratoPAF) = -1 Then
                    Msg_Mensagem("Favor selecionar uma linha.")
                    Exit Sub
                End If

                Auditoria(TipoCampoFixo.Todos, "CONTRATO_PAF", "CD_CONTRATO_PAF = " & objGrid_Valor(grdContratoPAF, cnt_GridCtrPaf_CD_CONTRATO_PAF))
            Case cnt_TAB_Negociacao
                If objGrid_LinhaSelecionada(grdNegociacao) = -1 Then
                    Msg_Mensagem("Favor selecionar uma linha.")
                    Exit Sub
                End If

                Auditoria(TipoCampoFixo.Todos, "NEGOCIACAO", "CD_CONTRATO_PAF = " & objGrid_Valor(grdNegociacao, cnt_GridNegociacao_CD_CONTRATOPAF) & _
                                                        " AND SQ_NEGOCIACAO = " & objGrid_Valor(grdNegociacao, cnt_GridNegociacao_SQ_NEGOCIACAO))
            Case cnt_TAB_ContratoFixo
                If objGrid_LinhaSelecionada(grdContratoFixo) = -1 Then
                    Msg_Mensagem("Favor selecionar uma linha.")
                    Exit Sub
                End If

                Auditoria(TipoCampoFixo.Todos, "CONTRATO_FIXO", "CD_CONTRATO_PAF = " & objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_CD_CONTRATO_PAF) & _
                                                           " AND SQ_NEGOCIACAO = " & objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_SQ_NEGOCIACAO) & _
                                                           " AND SQ_CONTRATO_FIXO = " & objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_SQ_CONTRATO_FIXO))
        End Select
    End Sub

    Private Sub grdContratoPAF_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdContratoPAF.AfterRowActivate
        If objGrid_TipoLinha(grdContratoPAF) = gridTipoLinha.Linha_Dados Then
            'Formatação do botão de Abrir/Fechar contrato
            Select Case objGrid_Valor(grdContratoPAF, cnt_GridCtrPaf_IC_STATUS)
                Case cnt_Contrato_Status_Fechado
                    BotaoStatus_Formatar(cmdStatusFechaAbre_CtrPaF, cnt_BotaoStatus_Abrir)
                Case cnt_Contrato_Status_Aberto
                    BotaoStatus_Formatar(cmdStatusFechaAbre_CtrPaF, cnt_BotaoStatus_Fechar)
            End Select

            If objGrid_Valor(grdContratoPAF, cnt_GridCtrPaf_IC_STATUS) = cnt_Contrato_Status_Excluido Then
                cmdStatusFechaAbre_CtrPaF.Visible = False
            Else
                SEC_ValidarBotao_Permissao(cmdStatusFechaAbre_CtrPaF, SEC_Permissao.SEC_P_Acesso_Abrir_FecharContratoPAF, True)
            End If

            'Formatação do botão de Excluir/Cancelar/Descancelar contrato
            Botao_CtrPAF_ExclusacaoCancelamento()
        Else
            cmdStatusFechaAbre_CtrPaF.Visible = False
        End If

        AlinharBotoesCtrPAF()
    End Sub

    Private Sub cmdNeg_Status_FechaAbre_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdStatusFechaAbre_Neg.Click
        If objGrid_LinhaSelecionada(grdNegociacao) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        If objGrid_Valor(grdNegociacao, cnt_GridNegociacao_IC_STATUS) = cnt_Contrato_Status_Excluido Then Exit Sub

        If objGrid_Valor(grdNegociacao, cnt_GridNegociacao_IC_STATUS) = "A" Then
            If Msg_Perguntar("Fecha a Negociação ?") = False Then Exit Sub
            MUDA_SITUACAO_NEGOCIACAO(objGrid_Valor(grdNegociacao, cnt_GridNegociacao_CD_CONTRATOPAF), _
                                     objGrid_Valor(grdNegociacao, cnt_GridNegociacao_SQ_NEGOCIACAO), "F")
        Else
            If Msg_Perguntar("Abre a Negociação ?") = False Then Exit Sub
            MUDA_SITUACAO_NEGOCIACAO(objGrid_Valor(grdNegociacao, cnt_GridNegociacao_CD_CONTRATOPAF), _
                                     objGrid_Valor(grdNegociacao, cnt_GridNegociacao_SQ_NEGOCIACAO), "A")
        End If

        Pesquisar()
    End Sub

    Private Sub cmdNeg_Excluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExcluir_Neg.Click
        If objGrid_LinhaSelecionada(grdNegociacao) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Dim DS_Motivo As String
        Dim SqlText As String

        If Not StatusValido_Negociacao() Then Exit Sub

        SqlText = "SELECT COUNT(*) " & _
                  " FROM SOF.FILIAL " & _
                  " WHERE CD_FILIAL = " & objGrid_Valor(grdNegociacao, cnt_GridNegociacao_CD_FILIAL_ORIGEM) & _
                    " AND CD_FILIAL IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        If DBQuery_ValorUnico(SqlText) = 0 Then
            Msg_Mensagem("Usuário sem acesso a filial dessa Negociação")
            Exit Sub
        End If

        If CDate(objGrid_Valor(grdNegociacao, cnt_GridNegociacao_DT_NEGOCIACAO)) <> CDate(DataSistema()) Then
            Msg_Mensagem("Esta Negociação foi criada em uma data diferente da data atual," & _
                         " por esse motivo não é possível prosseguir com a exclusão da mesma.")
            Exit Sub
        End If

        Dim oForm As New frmObservacao

        oForm.Carregar("Motivo de Eliminação de Negociação", "", True)
        Form_Show(Nothing, oForm, True, True)

        If oForm.Cancelado Then
            oForm.Dispose()
            Exit Sub
        End If

        DS_Motivo = oForm.DS_Motivo
        oForm.Dispose()

        If Not Msg_Perguntar("Elimina a negociação ?") Then Exit Sub

        On Error GoTo Erro

        If FilialFechada(FilialLogada) Then Exit Sub

        SqlText = DBMontar_SP("SOF.SP_ELIMINA_NEGOCIACAO", False, ":CTR", ":NEG", ":DSMOTIVO")

        If Not DBExecutar(SqlText, DBParametro_Montar("CTR", objGrid_Valor(grdNegociacao, cnt_GridNegociacao_CD_CONTRATOPAF)), _
                                   DBParametro_Montar("NEG", objGrid_Valor(grdNegociacao, cnt_GridNegociacao_SQ_NEGOCIACAO)), _
                                   DBParametro_Montar("DSMOTIVO", DS_Motivo)) Then GoTo Erro

        Pesquisar()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub cmdNeg_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNeg_Cancelar.Click
        mnuNegCancelar.Show(cmdNeg_Cancelar, Nothing)
    End Sub

    Private Sub cmdNeg_MotivoEliminacao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdMotivoEliminacao_Neg.Click
        If objGrid_LinhaSelecionada(grdNegociacao) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If
        If objGrid_Valor(grdNegociacao, cnt_GridNegociacao_IC_STATUS) <> cnt_Contrato_Status_Excluido Then
            Msg_Mensagem("Essa negociação não foi eliminada.")
            Exit Sub
        End If

        Dim oForm As New frmObservacao
        Dim SqlText As String
        Dim DS_Motivo As String

        SqlText = "SELECT DS_MOTIVO " & _
                  " FROM SOF.NEGOCIACAO_ELIMINADA " & _
                  " WHERE CD_CONTRATO_PAF = " & objGrid_Valor(grdNegociacao, cnt_GridNegociacao_CD_CONTRATOPAF) & _
                    " AND SQ_NEGOCIACAO = " & objGrid_Valor(grdNegociacao, cnt_GridNegociacao_SQ_NEGOCIACAO)
        DS_Motivo = DBQuery_ValorUnico(SqlText, "")

        If Trim(DS_Motivo) = "" Then
            Msg_Mensagem("Não existe motivo para a eliminação da negociação.")
            Exit Sub
        End If

        oForm.Carregar("Motivo de Eliminação de Negociação", DS_Motivo, True, True, True)
        Form_Show(Nothing, oForm, True, True)
        oForm.Dispose()
    End Sub

    Private Sub cmdNeg_Excell_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExcell_Neg.Click
        objGrid_ExportarExcell(grdNegociacao, Me.Text, cmdExcell_Neg)
    End Sub

    Private Sub cmdNeg_Imprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdImprimir_Neg.Click
        If objGrid_LinhaSelecionada(grdNegociacao) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If
        If objGrid_Valor(grdNegociacao, cnt_GridNegociacao_IC_STATUS) = cnt_Contrato_Status_Excluido Then
            Msg_Mensagem("Essa negociação não foi eliminada.")
            Exit Sub
        End If
        If objGrid_Valor(grdNegociacao, cnt_GridNegociacao_QT_ADITIVO) = 0 Then
            Impressao_Negociacao(objGrid_Valor(grdNegociacao, cnt_GridNegociacao_CD_CONTRATOPAF), _
                                 objGrid_Valor(grdNegociacao, cnt_GridNegociacao_SQ_NEGOCIACAO))
        Else
            PopUp_Aditivo(objGrid_Valor(grdNegociacao, cnt_GridNegociacao_CD_CONTRATOPAF), _
                          objGrid_Valor(grdNegociacao, cnt_GridNegociacao_SQ_NEGOCIACAO))
        End If
    End Sub

    Private Sub cmdNeg_Juros_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNeg_Juros.Click
        If objGrid_LinhaSelecionada(grdNegociacao) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Dim oForm As New frmCadastroNegociacao_AlteracaoJuros

        oForm.Carregar(objGrid_Valor(grdNegociacao, cnt_GridNegociacao_CD_CONTRATOPAF), _
                       objGrid_Valor(grdNegociacao, cnt_GridNegociacao_SQ_NEGOCIACAO))
        Form_Show(Nothing, oForm, True, True)

        oForm.Dispose()
    End Sub

    Private Sub cmdNeg_Novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNeg_Novo.Click
        Form_Show(Me.MdiParent, frmCadastroNegociacao)
    End Sub

    Private Sub cmdNeg_Resumo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNeg_Resumo.Click
        Dim oForm As New frmCadastroContratoResumo
        Dim oData As New DataTable
        Dim oRow As DataRow
        Dim iCont_01 As Integer
        Dim iCont_02 As Integer
        Dim bAchou As Boolean
        Dim Kg As Double = 0
        Dim Kg_Cancelado As Double = 0
        Dim Quantidade As Double = 0

        With oData.Columns
            .Add("CD_TIPO_PESSOA")
            .Add("NO_TIPO_PESSOA")
            .Add("VALOR")
            .Add("VALOR_US")
            .Add("QUANTIDADE")
        End With

        For iCont_01 = 0 To grdNegociacao.Rows.Count - 1
            bAchou = False

            With grdNegociacao.Rows(iCont_01)
                If .Cells(cnt_GridNegociacao_IC_STATUS).Value <> cnt_Contrato_Status_Excluido Then
                    Kg = Kg + .Cells(cnt_GridNegociacao_QT_KGS).Value
                    Kg_Cancelado = Kg_Cancelado + .Cells(cnt_GridNegociacao_QT_CANCELADO).Value
                    Quantidade = .Cells(cnt_GridNegociacao_QT_KGS).Value - .Cells(cnt_GridNegociacao_QT_CANCELADO).Value

                    For iCont_02 = 0 To oData.Rows.Count - 1
                        If oData.Rows(iCont_02).Item("CD_TIPO_PESSOA") = _
                           .Cells(cnt_GridNegociacao_CD_TIPO_PESSOA).Value Then
                            oData.Rows(iCont_02).Item("QUANTIDADE") = oData.Rows(iCont_02).Item("QUANTIDADE") + _
                                                                      Quantidade
                            bAchou = True
                        End If
                    Next

                    If Not bAchou Then
                        oRow = oData.NewRow

                        oRow.Item("CD_TIPO_PESSOA") = .Cells(cnt_GridNegociacao_CD_TIPO_PESSOA).Value
                        oRow.Item("NO_TIPO_PESSOA") = .Cells(cnt_GridNegociacao_NO_TIPO_PESSOA).Value
                        oRow.Item("VALOR") = 0
                        oRow.Item("VALOR_US") = 0
                        oRow.Item("QUANTIDADE") = Quantidade

                        oData.Rows.Add(oRow)
                    End If
                End If
            End With
        Next

        oForm.Par_SubTotal_03 = Kg
        oForm.Par_Cancelados_03 = Kg_Cancelado
        oForm.Par_Total_03 = (Kg - Kg_Cancelado)
        oForm.Carregar(frmCadastroContratoResumo.TipoTela.ContratoNegociacao, oData)

        Form_Show(Nothing, oForm, True, True)

        oForm.Dispose()
        oData.Dispose()
    End Sub

    Private Sub mnuNegCancelar_Cancelamento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuNegCancelar_Cancelamento.Click
        If objGrid_LinhaSelecionada(grdNegociacao) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If
        If objGrid_Valor(grdNegociacao, cnt_GridNegociacao_IC_STATUS) = cnt_Contrato_Status_Excluido Then
            Msg_Mensagem("Negociação eliminada.")
            Exit Sub
        End If
        If objGrid_Valor(grdNegociacao, cnt_GridNegociacao_IC_STATUS) = cnt_Contrato_Status_Fechado Then
            Msg_Mensagem("Negociação ja fechada.")
            Exit Sub
        End If

        On Error GoTo Erro

        Dim oForm As New frmCancelamento_SolicitarQuantidade

        Form_Show(Nothing, oForm, True, True)

        If Not oForm.Cancelado Then
            If Cancela_Negociacao(objGrid_Valor(grdNegociacao, cnt_GridNegociacao_CD_CONTRATOPAF), _
                                  objGrid_Valor(grdNegociacao, cnt_GridNegociacao_SQ_NEGOCIACAO), _
                                  oForm.txtQuantidade.Value, _
                                  oForm.txtMotivo.Text, _
                                  "C") Then
                If SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_LiberacaoSaldoPreNegociacao) Then
                    If Msg_Perguntar("Deseja liberar esse saldo para pre-negociação?") Then
                        If Not Inclui_PreNegociacao(objGrid_Valor(grdNegociacao, cnt_GridNegociacao_CD_CONTRATOPAF), _
                                                    objGrid_Valor(grdNegociacao, cnt_GridNegociacao_SQ_NEGOCIACAO), _
                                                    oForm.txtQuantidade.Value, _
                                                    objGrid_Valor(grdNegociacao, cnt_GridNegociacao_NO_RAZAO_SOCIAL)) Then GoTo Erro
                    End If
                End If

                Pesquisar()
            End If
        End If

        oForm.Dispose()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub mnuNegCancelar_Consulta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuNegCancelar_Consulta.Click
        If objGrid_LinhaSelecionada(grdNegociacao) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Dim oForm As New frmConsultaGeral

        oForm.FiltroLocal_01 = objGrid_Valor(grdNegociacao, cnt_GridNegociacao_CD_CONTRATOPAF)
        oForm.FiltroLocal_02 = objGrid_Valor(grdNegociacao, cnt_GridNegociacao_SQ_NEGOCIACAO)
        oForm.FormatarTela(frmConsultaGeral.eConsultaGeral.Cancelamento_Negociacao)

        Form_Show(Nothing, oForm, True, True)

        If oForm.GerouAlteracaoInformacao Then Pesquisar()

        oForm.Dispose()
    End Sub

    Private Sub mnuNegCancelar_Estorno_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuNegCancelar_Estorno.Click
        If objGrid_LinhaSelecionada(grdNegociacao) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If
        If Not StatusValido_Negociacao() Then Exit Sub

        Dim oForm As New frmCancelamento_SolicitarQuantidade

        Form_Show(Nothing, oForm, True, True)

        If Not oForm.Cancelado Then
            If Cancela_Negociacao(objGrid_Valor(grdNegociacao, cnt_GridNegociacao_CD_CONTRATOPAF), _
                                  objGrid_Valor(grdNegociacao, cnt_GridNegociacao_SQ_NEGOCIACAO), _
                                  oForm.txtQuantidade.Value, _
                                  oForm.txtMotivo.Text, _
                                  "E") = True Then
                Pesquisar()
            End If
        End If

        oForm.Dispose()
    End Sub

    Private Sub grdNegociacao_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdNegociacao.AfterRowActivate
        If objGrid_TipoLinha(grdNegociacao) = gridTipoLinha.Linha_Dados Then
            Select Case objGrid_Valor(grdNegociacao, cnt_GridNegociacao_IC_STATUS)
                Case cnt_Contrato_Status_Fechado
                    BotaoStatus_Formatar(cmdStatusFechaAbre_Neg, cnt_BotaoStatus_Abrir)
                Case cnt_Contrato_Status_Aberto
                    BotaoStatus_Formatar(cmdStatusFechaAbre_Neg, cnt_BotaoStatus_Fechar)
            End Select

            If objGrid_Valor(grdNegociacao, cnt_GridNegociacao_IC_STATUS) = cnt_Contrato_Status_Excluido Then
                cmdStatusFechaAbre_Neg.Visible = False
            Else
                SEC_ValidarBotao_Permissao(cmdStatusFechaAbre_Neg, SEC_Permissao.SEC_P_Acesso_Abrir_FecharNegociacao, True)
            End If

            AlinharBotoesNeg()
        End If
    End Sub

    Private Sub cmdCtrFix_Adendo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdendo_CtrFix.Click
        mnuCtrFixAdendo.Show(cmdAdendo_CtrFix, Nothing)
    End Sub

    Private Sub CtrFix_Excluir()
        Dim SqlText As String
        Dim DS_Motivo As String

        If objGrid_LinhaSelecionada(grdContratoFixo) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        If Not StatusValido_ContratoFixo() Then Exit Sub

        SqlText = "SELECT * " & _
                  " FROM SOF.FILIAL " & _
                  " WHERE CD_FILIAL = " & objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_CD_FILIAL_ORIGEM) & _
                    " AND CD_FILIAL IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        If DBQuery_ValorUnico(SqlText) = 0 Then
            Msg_Mensagem("Usuário sem acesso a filial desse Contrato Fixo")
            Exit Sub
        End If

        If CDate(objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_DT_CONTRATO_FIXO)) <> CDate(DataSistema()) Then
            Msg_Mensagem("Este Contrato Fixo foi criado em uma data diferente da data atual," & _
                         " por esse motivo não é possível prosseguir com a exclusão do mesmo.")
            Exit Sub
        End If

        Dim oForm As New frmObservacao

        oForm.Carregar("Motivo de Eliminação de Contrato Fixo", "", True)
        Form_Show(Nothing, oForm, True, True)

        If oForm.Cancelado Then
            oForm.Dispose()
            Exit Sub
        End If

        DS_Motivo = oForm.DS_Motivo
        oForm.Dispose()

        If Not Msg_Perguntar("Elimina o contrato fixo?") Then Exit Sub

        If FilialFechada(FilialLogada) Then Exit Sub

        On Error GoTo Erro

        SqlText = DBMontar_SP("SOF.SP_ELIMINA_CONTRATO_FIXO", False, ":CTR", _
                                                                     ":NEG", _
                                                                     ":CTRFIX", _
                                                                     ":DSMOTIVO")

        If Not DBExecutar(SqlText, DBParametro_Montar("CTR", objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_CD_CONTRATO_PAF)), _
                                   DBParametro_Montar("NEG", objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_SQ_NEGOCIACAO)), _
                                   DBParametro_Montar("CTRFIX", objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_SQ_CONTRATO_FIXO)), _
                                   DBParametro_Montar("DSMOTIVO", DS_Motivo)) Then GoTo Erro

        Pesquisar()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub CtrFix_Cancelar()
        If objGrid_LinhaSelecionada(grdContratoFixo) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        If objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_IC_STATUS) = cnt_Contrato_Status_Fechado Then
            Msg_Mensagem("Contrato fixo ja fechado.")
            Exit Sub
        End If
        If objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_IC_STATUS) = cnt_Contrato_Status_Excluido Then
            Msg_Mensagem("Contrato fixo ja eliminado.")
            Exit Sub
        End If
        If objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_DT_CONTRATO_FIXO) = CDate(DataSistema()) Then
            Msg_Mensagem("Este Contrato Fixo foi criado na data atual," & _
                         " por esse motivo não é possível prosseguir com a exclusão do mesmo.")
            Exit Sub
        End If

        Dim oForm As New frmCancelamento_SolicitarQuantidade

        Form_Show(Nothing, oForm, True, True)

        If Not oForm.Cancelado Then
            If Cancela_Contrato_Fixo(objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_CD_CONTRATO_PAF), _
                                     objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_SQ_NEGOCIACAO), _
                                     objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_SQ_CONTRATO_FIXO), _
                                     oForm.txtQuantidade.Value, _
                                     oForm.txtMotivo.Text) = True Then
                Pesquisar()
            End If
        End If

        oForm.Dispose()
    End Sub

    Private Sub CtrFix_Descancelar()
        If objGrid_LinhaSelecionada(grdContratoFixo) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Dim oForm As New frmConsultaGeral

        oForm.FiltroLocal_01 = objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_CD_CONTRATO_PAF)
        oForm.FiltroLocal_02 = objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_SQ_NEGOCIACAO)
        oForm.FiltroLocal_03 = objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_SQ_CONTRATO_FIXO)
        oForm.FormatarTela(frmConsultaGeral.eConsultaGeral.Cancelamento_ContratoFixo)

        Form_Show(Nothing, oForm, True, True)

        If oForm.GerouAlteracaoInformacao Then Pesquisar()

        oForm.Dispose()
    End Sub

    Private Sub cmdCtrFix_MotivoEliminacao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdMotivoEliminacao_CtrFix.Click
        If objGrid_LinhaSelecionada(grdContratoFixo) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If
        If objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_IC_STATUS) <> cnt_Contrato_Status_Excluido Then
            Msg_Mensagem("Esse Contrato Fixo não foi eliminado.")
            Exit Sub
        End If

        Dim oForm As New frmObservacao
        Dim SqlText As String
        Dim DS_Motivo As String

        SqlText = "SELECT DS_MOTIVO" & _
                  " FROM SOF.CONTRATO_FIXO_ELIMINADO" & _
                  " WHERE CD_CONTRATO_PAF = " & objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_CD_CONTRATO_PAF) & _
                    " AND SQ_NEGOCIACAO = " & objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_SQ_NEGOCIACAO) & _
                    " AND SQ_CONTRATO_FIXO = " & objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_SQ_CONTRATO_FIXO)
        DS_Motivo = DBQuery_ValorUnico(SqlText, "")

        If Trim(DS_Motivo) = "" Then
            Msg_Mensagem("Não existe motivo para a eliminação do Contrato Fixo.")
            Exit Sub
        End If

        oForm.Carregar("Motivo de Eliminação de Contrato Fixo", DS_Motivo, True, True, True)
        Form_Show(Nothing, oForm, True, True)
        oForm.Dispose()
    End Sub

    Private Sub cmdCtrFix_Excell_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExcell_CtrFix.Click
        objGrid_ExportarExcell(grdContratoFixo, Me.Text, cmdExcell_CtrFix)
    End Sub

    Private Sub cmdCtrFix_FixarDolar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFixarDolar_CtrFix.Click
        If objGrid_LinhaSelecionada(grdContratoFixo) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If
        If objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_IC_TAXA_DOLAR_VARIAVEL) = "N" Then
            Msg_Mensagem("Esse contrato fixo não de dolar variável")
            Exit Sub
        End If

        Dim oForm As New frmCadastroContratoFixo_FixarDolar

        oForm.Carregar(objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_CD_CONTRATO_PAF), _
                       objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_SQ_NEGOCIACAO), _
                       objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_SQ_CONTRATO_FIXO))

        Form_Show(Nothing, oForm, True, True)

        If Not oForm.Cancelado Then
            Pesquisar()
        End If

        oForm.Dispose()
    End Sub

    Private Sub cmdCtrFix_Imprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdImprimir_CtrFix.Click
        If objGrid_LinhaSelecionada(grdContratoFixo) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If
        If objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_IC_STATUS) = cnt_Contrato_Status_Excluido Then
            Msg_Mensagem("Contrato eliminado.")
            Exit Sub
        End If
        If objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_QT_ADITIVO) = 0 Then
            Impressao_ContratoFixo(objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_CD_CONTRATO_PAF), _
                                   objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_SQ_NEGOCIACAO), _
                                   objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_SQ_CONTRATO_FIXO))
        Else
            PopUp_Aditivo(objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_CD_CONTRATO_PAF), _
                          objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_SQ_NEGOCIACAO), _
                          objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_SQ_CONTRATO_FIXO))
        End If

        Exit Sub
    End Sub

    Private Sub cmdCtrFix_Resumo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCtrFix_Resumo.Click
        Dim oForm As New frmCadastroContratoResumo
        Dim oData As New DataTable
        Dim oRow As DataRow
        Dim iCont_01 As Integer
        Dim iCont_02 As Integer
        Dim bAchou As Boolean
        Dim VL_TotalAdendo As Double
        Dim QT_Kgs As Double
        Dim ValorCancelado As Double
        Dim Kg_Cancelado As Double
        Dim QuantidadeContrato As Double
        Dim ValorContrato As Double

        With oData.Columns
            .Add("CD_TIPO_PESSOA")
            .Add("NO_TIPO_PESSOA")
            .Add("VALOR")
            .Add("VALOR_US")
            .Add("QUANTIDADE")
        End With

        For iCont_01 = 0 To grdContratoFixo.Rows.Count - 1
            bAchou = False

            With grdContratoFixo.Rows(iCont_01)
                If .Cells(cnt_GridCtrFixo_IC_STATUS).Value <> cnt_Contrato_Status_Excluido Then
                    VL_TotalAdendo = VL_TotalAdendo + .Cells(cnt_GridCtrFixo_VL_TOTAL).Value + _
                                                      .Cells(cnt_GridCtrFixo_VL_ADENDO).Value
                    QT_Kgs = QT_Kgs + .Cells(cnt_GridCtrFixo_QT_KGS).Value
                    ValorCancelado = ValorCancelado + (.Cells(cnt_GridCtrFixo_QT_CANCELADO).Value * _
                                                       ((.Cells(cnt_GridCtrFixo_VL_TOTAL).Value + _
                                                         .Cells(cnt_GridCtrFixo_VL_ADENDO).Value) / _
                                                       .Cells(cnt_GridCtrFixo_QT_KGS).Value))
                    Kg_Cancelado = Kg_Cancelado + .Cells(cnt_GridCtrFixo_QT_CANCELADO).Value
                    QuantidadeContrato = .Cells(cnt_GridCtrFixo_QT_KGS).Value - _
                                         .Cells(cnt_GridCtrFixo_QT_CANCELADO).Value
                    ValorContrato = .Cells(cnt_GridCtrFixo_VL_TOTAL).Value + _
                                    .Cells(cnt_GridCtrFixo_VL_ADENDO).Value - _
                                    (.Cells(cnt_GridCtrFixo_QT_CANCELADO).Value * _
                                     ((.Cells(cnt_GridCtrFixo_VL_TOTAL).Value + _
                                       .Cells(cnt_GridCtrFixo_VL_ADENDO).Value) / _
                                      .Cells(cnt_GridCtrFixo_QT_KGS).Value))

                    For iCont_02 = 0 To oData.Rows.Count - 1
                        If oData.Rows(iCont_02).Item("CD_TIPO_PESSOA") = _
                           .Cells(cnt_GridCtrFixo_CD_TIPO_PESSOA).Value Then
                            oData.Rows(iCont_02).Item("VALOR") = oData.Rows(iCont_02).Item("VALOR") + _
                                                                 ValorContrato
                            oData.Rows(iCont_02).Item("QUANTIDADE") = oData.Rows(iCont_02).Item("QUANTIDADE") + _
                                                                      QuantidadeContrato
                            bAchou = True
                        End If
                    Next

                    If Not bAchou Then
                        oRow = oData.NewRow

                        oRow.Item("CD_TIPO_PESSOA") = .Cells(cnt_GridCtrFixo_CD_TIPO_PESSOA).Value
                        oRow.Item("NO_TIPO_PESSOA") = .Cells(cnt_GridCtrFixo_NO_TIPO_PESSOA).Value
                        oRow.Item("VALOR") = ValorContrato
                        oRow.Item("VALOR_US") = 0
                        oRow.Item("QUANTIDADE") = QuantidadeContrato

                        oData.Rows.Add(oRow)
                    End If
                End If
            End With
        Next

        oForm.Par_SubTotal_01 = VL_TotalAdendo
        oForm.Par_SubTotal_03 = QT_Kgs
        oForm.Par_Cancelados_01 = ValorCancelado
        oForm.Par_Cancelados_03 = Kg_Cancelado
        oForm.Par_Total_01 = VL_TotalAdendo - ValorCancelado
        oForm.Par_Total_03 = QT_Kgs - Kg_Cancelado

        oForm.Carregar(frmCadastroContratoResumo.TipoTela.ContratoFixo, oData)

        Form_Show(Nothing, oForm, True, True)

        oData.Dispose()
        oForm.Dispose()
    End Sub

    Public Sub ContratoFixo_GridIdentificar(Optional ByVal iColDataVencimento_GP As Integer = -1, _
                                            Optional ByVal iColIC_GP As Integer = -1)
        Dim iCont As Integer
        Dim dDataSistema As Date

        dDataSistema = CDate(DataSistema())

        For iCont = 0 To grdContratoFixo.Rows.Count - 1
            If CDate(NVL(objGrid_Valor(grdContratoFixo, iColDataVencimento_GP, iCont), dDataSistema)) < dDataSistema Then
                With grdContratoFixo.Rows(iCont).Appearance
                    .ForeColor = Color.Black
                    .BackColor = Color.Yellow
                    .FontData.Bold = DefaultableBoolean.True
                End With
            Else
                If objGrid_Valor_SN(grdContratoFixo, iColIC_GP, iCont) Then
                    With grdContratoFixo.Rows(iCont).Appearance
                        .ForeColor = Color.Black
                        .BackColor = Color.Green
                        .FontData.Bold = DefaultableBoolean.False
                    End With
                End If
            End If
        Next
    End Sub

    Private Sub mnuCtrFixAdendo_Consulta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCtrFixAdendo_Consulta.Click
        If objGrid_LinhaSelecionada(grdContratoFixo) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Dim oForm As New frmConsultaGeral

        oForm.FiltroLocal_01 = objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_CD_CONTRATO_PAF)
        oForm.FiltroLocal_02 = objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_SQ_NEGOCIACAO)
        oForm.FiltroLocal_03 = objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_SQ_CONTRATO_FIXO)
        oForm.FormatarTela(frmConsultaGeral.eConsultaGeral.ContratoFixo_Adendo)

        Form_Show(Nothing, oForm, True, True)

        If oForm.GerouAlteracaoInformacao Then Pesquisar()

        oForm.Dispose()
    End Sub

    Private Sub mnuCtrFixAdendo_Inclusao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCtrFixAdendo_Inclusao.Click
        If objGrid_LinhaSelecionada(grdContratoFixo) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Dim oForm As New frmCadastroContratoFixo_Adendo

        oForm.Carregar(objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_CD_CONTRATO_PAF), _
                       objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_SQ_NEGOCIACAO), _
                       objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_SQ_CONTRATO_FIXO))

        Form_Show(Nothing, oForm, True, True)

        If Not oForm.Cancelado Then Pesquisar()

        oForm.Dispose()
    End Sub

    Private Sub tbcGeral_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles tbcGeral.Selecting
        AjustaIcone()
        If bPesquisarAutomatico Then Pesquisar()

        HabilitarTipoCacau(e.TabPage Is tabNegociacao)
    End Sub

    Private Sub frmConsultaContrato_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_Ajustar()
    End Sub

    Private Sub Form_Ajustar()

        cmdPesquisar.Left = Me.ClientSize.Width - cmdPesquisar.Width - 15

    End Sub

    Private Sub cmdCtrFix_Novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNovo_CtrFix.Click
        Form_Show(Nothing, New frmCadastroContratoFixo, , , , True)
    End Sub

    Private Sub AlinharBotoesCtrPAF()
        Const cnt_Tamanho As Integer = 45
        Const cnt_Espacamento As Integer = 8
        Const cnt_1Posicao As Integer = 5

        Dim iCont As Integer = 0

        If cmdExcell_CtrPaF.Visible Then cmdExcell_CtrPaF.Left = cnt_1Posicao + ((iCont) * (cnt_Tamanho + cnt_Espacamento))
        If cmdCtrPaF_Novo.Visible Then iCont = iCont + 1 : cmdCtrPaF_Novo.Left = cnt_1Posicao + (iCont * (cnt_Tamanho + cnt_Espacamento))
        If cmdAlterar_CtrPaF.Visible Then iCont = iCont + 1 : cmdAlterar_CtrPaF.Left = cnt_1Posicao + (iCont * (cnt_Tamanho + cnt_Espacamento))
        If cmdCtrPaF_ExclusaoCancelamento.Visible Then iCont = iCont + 1 : cmdCtrPaF_ExclusaoCancelamento.Left = cnt_1Posicao + ((iCont) * (cnt_Tamanho + cnt_Espacamento))
        If cmdCtrPaF_Resumo.Visible Then iCont = iCont + 1 : cmdCtrPaF_Resumo.Left = cnt_1Posicao + (iCont * (cnt_Tamanho + cnt_Espacamento))
        If cmdCtrPaF_Juros.Visible Then iCont = iCont + 1 : cmdCtrPaF_Juros.Left = cnt_1Posicao + (iCont * (cnt_Tamanho + cnt_Espacamento))
        If cmdStatusFechaAbre_CtrPaF.Visible Then iCont = iCont + 1 : cmdStatusFechaAbre_CtrPaF.Left = cnt_1Posicao + (iCont * (cnt_Tamanho + cnt_Espacamento))
        If cmdImprimir_CtrPaF.Visible Then iCont = iCont + 1 : cmdImprimir_CtrPaF.Left = cnt_1Posicao + (iCont * (cnt_Tamanho + cnt_Espacamento))
    End Sub

    Private Sub AlinharBotoesNeg()
        Const cnt_Tamanho As Integer = 45
        Const cnt_Espacamento As Integer = 8
        Const cnt_1Posicao As Integer = 5

        Dim iCont As Integer = 0

        If cmdExcell_Neg.Visible Then cmdExcell_Neg.Left = cnt_1Posicao + ((iCont) * (cnt_Tamanho + cnt_Espacamento))
        If cmdNeg_Novo.Visible Then iCont = iCont + 1 : cmdNeg_Novo.Left = cnt_1Posicao + (iCont * (cnt_Tamanho + cnt_Espacamento))
        If cmdAlterar_CtrNeg.Visible Then iCont = iCont + 1 : cmdAlterar_CtrNeg.Left = cnt_1Posicao + (iCont * (cnt_Tamanho + cnt_Espacamento))
        If cmdNeg_Cancelar.Visible Then iCont = iCont + 1 : cmdNeg_Cancelar.Left = cnt_1Posicao + (iCont * (cnt_Tamanho + cnt_Espacamento))
        If cmdNeg_Resumo.Visible Then iCont = iCont + 1 : cmdNeg_Resumo.Left = cnt_1Posicao + ((iCont) * (cnt_Tamanho + cnt_Espacamento))
        If cmdNeg_Juros.Visible Then iCont = iCont + 1 : cmdNeg_Juros.Left = cnt_1Posicao + (iCont * (cnt_Tamanho + cnt_Espacamento))
        If cmdStatusFechaAbre_Neg.Visible Then iCont = iCont + 1 : cmdStatusFechaAbre_Neg.Left = cnt_1Posicao + (iCont * (cnt_Tamanho + cnt_Espacamento))
        If cmdMotivoEliminacao_Neg.Visible Then iCont = iCont + 1 : cmdMotivoEliminacao_Neg.Left = cnt_1Posicao + (iCont * (cnt_Tamanho + cnt_Espacamento))
        If cmdExcluir_Neg.Visible Then iCont = iCont + 1 : cmdExcluir_Neg.Left = cnt_1Posicao + (iCont * (cnt_Tamanho + cnt_Espacamento))
        If cmdImprimir_Neg.Visible Then iCont = iCont + 1 : cmdImprimir_Neg.Left = cnt_1Posicao + (iCont * (cnt_Tamanho + cnt_Espacamento))
        If cmdRenegociacao.Visible Then iCont = iCont + 1 : cmdRenegociacao.Left = cnt_1Posicao + (iCont * (cnt_Tamanho + cnt_Espacamento))
    End Sub

    Private Sub AlinharBotoesCtrFix()
        Const cnt_Tamanho As Integer = 45
        Const cnt_Espacamento As Integer = 8
        Const cnt_1Posicao As Integer = 5

        Dim iCont As Integer = 0

        If cmdExcell_CtrFix.Visible Then cmdExcell_CtrFix.Left = cnt_1Posicao + ((iCont) * (cnt_Tamanho + cnt_Espacamento))
        If cmdNovo_CtrFix.Visible Then iCont = iCont + 1 : cmdNovo_CtrFix.Left = cnt_1Posicao + (iCont * (cnt_Tamanho + cnt_Espacamento))
        If cmdAlterar_CtrFixo.Visible Then iCont = iCont + 1 : cmdAlterar_CtrFixo.Left = cnt_1Posicao + (iCont * (cnt_Tamanho + cnt_Espacamento))
        If cmdAdendo_CtrFix.Visible Then iCont = iCont + 1 : cmdAdendo_CtrFix.Left = cnt_1Posicao + (iCont * (cnt_Tamanho + cnt_Espacamento))
        If cmdCtrFix_ExclusaoCancelamento.Visible Then iCont = iCont + 1 : cmdCtrFix_ExclusaoCancelamento.Left = cnt_1Posicao + ((iCont) * (cnt_Tamanho + cnt_Espacamento))
        If cmdCtrFix_Resumo.Visible Then iCont = iCont + 1 : cmdCtrFix_Resumo.Left = cnt_1Posicao + (iCont * (cnt_Tamanho + cnt_Espacamento))
        If cmdStatusFechaAbre_CtrFix.Visible Then iCont = iCont + 1 : cmdStatusFechaAbre_CtrFix.Left = cnt_1Posicao + (iCont * (cnt_Tamanho + cnt_Espacamento))
        If cmdMotivoEliminacao_CtrFix.Visible Then iCont = iCont + 1 : cmdMotivoEliminacao_CtrFix.Left = cnt_1Posicao + (iCont * (cnt_Tamanho + cnt_Espacamento))
        If cmdFixarDolar_CtrFix.Visible Then iCont = iCont + 1 : cmdFixarDolar_CtrFix.Left = cnt_1Posicao + (iCont * (cnt_Tamanho + cnt_Espacamento))
        If cmdImprimir_CtrFix.Visible Then iCont = iCont + 1 : cmdImprimir_CtrFix.Left = cnt_1Posicao + (iCont * (cnt_Tamanho + cnt_Espacamento))
    End Sub

    Private Sub Botao_CtrPAF_ExclusacaoCancelamento()
        Dim iTipo As Integer

        If grdContratoPAF.ActiveRow Is Nothing Then
            iTipo = cnt_Botao_CancelamentoExclusao_Excluir
        Else
            If objGrid_Valor(grdContratoPAF, cnt_GridCtrPaf_IC_STATUS, , "") = "C" Then
                iTipo = cnt_Botao_CancelamentoExclusao_Descancelar
            ElseIf CDate(objGrid_Valor(grdContratoPAF, cnt_GridCtrPaf_DT_CONTRATO_PAF)) <> CDate(DataSistema()) Then
                iTipo = cnt_Botao_CancelamentoExclusao_Cancelar
            Else
                iTipo = cnt_Botao_CancelamentoExclusao_Excluir
            End If
        End If

        Select Case iTipo
            Case cnt_Botao_CancelamentoExclusao_Excluir
                SEC_ValidarBotao(cmdCtrPaF_ExclusaoCancelamento, cnt_SEC_Tela_ContratoPAF, SEC_Validador.SEC_V_Exclusao, True)
                cmdCtrPaF_ExclusaoCancelamento.Appearance.Image = picExcCanc_Excluir.Image
            Case cnt_Botao_CancelamentoExclusao_Cancelar
                SEC_ValidarBotao_Permissao(cmdCtrPaF_ExclusaoCancelamento, SEC_Permissao.SEC_P_Acesso_CancelarContratoPAF, True)
                cmdCtrPaF_ExclusaoCancelamento.Appearance.Image = picExcCanc_Cancelar.Image
            Case cnt_Botao_CancelamentoExclusao_Descancelar
                SEC_ValidarBotao_Permissao(cmdCtrPaF_ExclusaoCancelamento, SEC_Permissao.SEC_P_Acesso_CancelarContratoPAF, True)
                cmdCtrPaF_ExclusaoCancelamento.Appearance.Image = picExcCanc_Descancelar.Image
        End Select

        cmdCtrPaF_ExclusaoCancelamento.Tag = iTipo
    End Sub

    Private Sub cmdCtrPaF_ExclusaoCancelamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCtrPaF_ExclusaoCancelamento.Click
        Select Case cmdCtrPaF_ExclusaoCancelamento.Tag
            Case cnt_Botao_CancelamentoExclusao_Excluir
                CtrPaF_Excluir()
            Case cnt_Botao_CancelamentoExclusao_Cancelar
                CtrPaF_Cancelar()
            Case cnt_Botao_CancelamentoExclusao_Descancelar
                CtrPaF_Descancelar()
        End Select
    End Sub

    Private Sub Botao_CtrFix_ExclusacaoCancelamento()
        Dim iTipo As Integer

        If grdContratoFixo.ActiveRow Is Nothing Then
            iTipo = cnt_Botao_CancelamentoExclusao_Excluir
        Else
            If objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_IC_STATUS, , "") = "C" Then
                iTipo = cnt_Botao_CancelamentoExclusao_Descancelar
            ElseIf CDate(objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_DT_CONTRATO_FIXO)) <> CDate(DataSistema()) Then
                iTipo = cnt_Botao_CancelamentoExclusao_Cancelar
            Else
                iTipo = cnt_Botao_CancelamentoExclusao_Excluir
            End If
        End If

        Select Case iTipo
            Case cnt_Botao_CancelamentoExclusao_Excluir
                SEC_ValidarBotao(cmdCtrFix_ExclusaoCancelamento, cnt_SEC_Tela_ContratoFixo, SEC_Validador.SEC_V_Exclusao, True)
                cmdCtrFix_ExclusaoCancelamento.Appearance.Image = picExcCanc_Excluir.Image
            Case cnt_Botao_CancelamentoExclusao_Cancelar
                SEC_ValidarBotao_Permissao(cmdCtrFix_ExclusaoCancelamento, SEC_Permissao.SEC_P_Acesso_CancelarContratoFixo, True)
                cmdCtrFix_ExclusaoCancelamento.Appearance.Image = picExcCanc_Cancelar.Image
            Case cnt_Botao_CancelamentoExclusao_Descancelar
                SEC_ValidarBotao_Permissao(cmdCtrFix_ExclusaoCancelamento, SEC_Permissao.SEC_P_Acesso_CancelarContratoFixo, True)
                cmdCtrFix_ExclusaoCancelamento.Appearance.Image = picExcCanc_Descancelar.Image
        End Select

        cmdCtrFix_ExclusaoCancelamento.Tag = iTipo
    End Sub

    Private Sub cmdCtrFix_ExclusaoCancelamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCtrFix_ExclusaoCancelamento.Click
        Select Case cmdCtrFix_ExclusaoCancelamento.Tag
            Case cnt_Botao_CancelamentoExclusao_Excluir
                CtrFix_Excluir()
            Case cnt_Botao_CancelamentoExclusao_Cancelar
                CtrFix_Cancelar()
            Case cnt_Botao_CancelamentoExclusao_Descancelar
                CtrFix_Descancelar()
        End Select
    End Sub

    Private Sub grdContratoFixo_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdContratoFixo.AfterRowActivate
        If objGrid_TipoLinha(grdContratoFixo) = gridTipoLinha.Linha_Dados Then
            Select Case objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_IC_STATUS)
                Case cnt_Contrato_Status_Fechado
                    BotaoStatus_Formatar(cmdStatusFechaAbre_CtrFix, cnt_BotaoStatus_Abrir)
                Case cnt_Contrato_Status_Aberto
                    BotaoStatus_Formatar(cmdStatusFechaAbre_CtrFix, cnt_BotaoStatus_Fechar)
            End Select

            If objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_IC_STATUS) = cnt_Contrato_Status_Excluido Then
                cmdStatusFechaAbre_Neg.Visible = False
            Else
                SEC_ValidarBotao_Permissao(cmdStatusFechaAbre_CtrFix, SEC_Permissao.SEC_P_Acesso_Abrir_FecharContratoFixo, True)
            End If

            Botao_CtrFix_ExclusacaoCancelamento()

            AlinharBotoesCtrFix()
        End If
    End Sub

    Private Sub HabilitarTipoCacau(ByVal bHabilitar As Boolean)
        lblR_TipoCacau.Visible = bHabilitar
        cboTipoCacau.Visible = bHabilitar
    End Sub

    Private Sub cmdRenegociacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRenegociacao.Click
        If objGrid_LinhaSelecionada(grdNegociacao) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Dim oForm As New frmConsultaReNegociacao

        oForm.CD_CONTRATO_PAF = objGrid_Valor(grdNegociacao, cnt_GridNegociacao_CD_CONTRATOPAF)
        oForm.SQ_NEGOCIACAO = objGrid_Valor(grdNegociacao, cnt_GridNegociacao_SQ_NEGOCIACAO)

        Form_Show(Me, oForm, , , )
    End Sub

    Private Sub cmdAlterar_CtrNeg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAlterar_CtrNeg.Click
        If objGrid_LinhaSelecionada(grdNegociacao) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        If Not StatusValido_Negociacao() Then Exit Sub

        Dim oForm As New frmCadastroNegociacao_Alteracao

        oForm.CD_CONTRATO_PAF = objGrid_Valor(grdNegociacao, cnt_GridNegociacao_CD_CONTRATOPAF)
        oForm.SQ_NEGOCIACAO = objGrid_Valor(grdNegociacao, cnt_GridNegociacao_SQ_NEGOCIACAO)

        Form_Show(Nothing, oForm, True, True)

        If Not oForm.Cancelado Then Pesquisar()

        oForm.Dispose()
    End Sub

    Private Sub cmdAlterar_CtrFixo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAlterar_CtrFixo.Click
        If objGrid_LinhaSelecionada(grdContratoFixo) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If
        If objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_IC_TIPO_PRECO_FIXO) = "S" Then
            Msg_Mensagem("Não é possível alterar contrato fixo de negociação 'FIXO EM REAL'")
            Exit Sub
        End If

        If Not StatusValido_ContratoFixo() Then Exit Sub

        Dim oForm As New frmCadastroContratoFixo_Alteracao

        oForm.CD_CONTRATO_PAF = objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_CD_CONTRATO_PAF)
        oForm.SQ_NEGOCIACAO = objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_SQ_NEGOCIACAO)
        oForm.SQ_CONTRATO_FIXO = objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_SQ_CONTRATO_FIXO)

        Form_Show(Nothing, oForm, True, True)

        If Not oForm.Cancelado Then Pesquisar()

        oForm.Dispose()
    End Sub

    Private Sub PopUp_Aditivo(ByVal CD_CONTRATO_PAF As Integer, _
                              Optional ByVal SQ_NEGOCIACAO As Integer = 0, _
                              Optional ByVal SQ_CONTRATO_FIXO As Integer = 0)
        Dim oData As DataTable
        Dim SqlText As String
        Dim iCont As Integer

        mnuAditivo.Items.Clear()

        '>> Iten para impressão do contrato
        mnuAditivo.Items.Add("Impressão do Contrato").Tag = GerarArray(IIf(SQ_CONTRATO_FIXO = 0, If(SQ_NEGOCIACAO = 0, -1, -2), -3))
        mnuAditivo.Items.Add("-")

        SqlText = "SELECT *" & _
                  " FROM SOF.CONTRATO_ADITIVO" & _
                  " WHERE CD_CONTRATO_PAF = " & CD_CONTRATO_PAF
        If SQ_NEGOCIACAO > 0 Then
            SqlText = SqlText & _
                    " AND SQ_NEGOCIACAO = " & SQ_NEGOCIACAO
        End If
        If SQ_CONTRATO_FIXO > 0 Then
            SqlText = SqlText & _
                    " AND SQ_CONTRATO_FIXO = " & SQ_CONTRATO_FIXO
        End If

        SqlText = SqlText & _
                  " ORDER BY DT_CRIACAO"

        oData = DBQuery(SqlText)

        For iCont = 0 To oData.Rows.Count - 1
            With oData.Rows(iCont)
                mnuAditivo.Items.Add("Aditivo: " & .Item("SQ_ADITIVO") & " de " & Format(.Item("DT_CRIACAO"), "dd/MM/yyyy")).Tag = GerarArray(CD_CONTRATO_PAF, _
                                                                                                                                              SQ_NEGOCIACAO, _
                                                                                                                                              SQ_CONTRATO_FIXO, _
                                                                                                                                              .Item("SQ_ADITIVO"))
            End With
        Next

        If SQ_CONTRATO_FIXO > 0 Then
            mnuAditivo.Show(cmdImprimir_CtrFix, Nothing)
        Else
            If SQ_NEGOCIACAO > 0 Then
                mnuAditivo.Show(cmdImprimir_Neg, Nothing)
            Else
                mnuAditivo.Show(cmdImprimir_CtrPaF, Nothing)
            End If
        End If
    End Sub

    Private Sub mnuAditivo_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles mnuAditivo.ItemClicked
        Select Case e.ClickedItem.Tag(0)
            Case -3
                Impressao_ContratoFixo(objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_CD_CONTRATO_PAF), _
                                       objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_SQ_NEGOCIACAO), _
                                       objGrid_Valor(grdContratoFixo, cnt_GridCtrFixo_SQ_CONTRATO_FIXO))
            Case -2
                Impressao_Negociacao(objGrid_Valor(grdNegociacao, cnt_GridNegociacao_CD_CONTRATOPAF), _
                                     objGrid_Valor(grdNegociacao, cnt_GridNegociacao_SQ_NEGOCIACAO))
            Case -1
                Impressao_ContratoPAF(objGrid_Valor(grdContratoPAF, cnt_GridCtrPaf_CD_CONTRATO_PAF))
            Case Else
                Dim oForm As New frmRelatorioGeral

                oForm.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eContrato_Aditivo
                oForm.Filtro01 = e.ClickedItem.Tag(0)
                oForm.Filtro02 = e.ClickedItem.Tag(1)
                oForm.Filtro03 = e.ClickedItem.Tag(2)
                oForm.Filtro04 = e.ClickedItem.Tag(3)
                Form_Show(Nothing, oForm)
        End Select

        mnuAditivo.Hide()
    End Sub
End Class