Imports System.Drawing.Color

Public Class frmCadastroReNegociacao_Aprovacao
    Const cnt_GridGeral_Filial As Integer = 0
    Const cnt_GridGeral_Usuario As Integer = 1
    Const cnt_GridGeral_Data As Integer = 2
    Const cnt_GridGeral_ContratoPAF As Integer = 3
    Const cnt_GridGeral_Neg As Integer = 4
    Const cnt_GridGeral_Fornecedor As Integer = 5
    Const cnt_GridGeral_Repassador As Integer = 6
    Const cnt_GridGeral_QT_KGS As Integer = 7
    Const cnt_GridGeral_NO_TIPO_UNIDADE As Integer = 8
    Const cnt_GridGeral_CD_TIPO_UNIDADE As Integer = 9
    Const cnt_GridGeral_CD_TIPO_UNIDADE_NEG As Integer = 10
    Const cnt_GridGeral_DT_VENCIMENTO As Integer = 11
    Const cnt_GridGeral_DT_VENCIMENTO_NEG As Integer = 12
    Const cnt_GridGeral_DT_PAGAMENTO As Integer = 13
    Const cnt_GridGeral_DT_PAGAMENTO_NEG As Integer = 14
    Const cnt_GridGeral_NO_LOCAL_ENTREGA As Integer = 15
    Const cnt_GridGeral_CD_LOCAL_ENTREGA As Integer = 16
    Const cnt_GridGeral_CD_LOCAL_ENTREGA_NEG As Integer = 17
    Const cnt_GridGeral_PC_TAXA_JUROS As Integer = 18
    Const cnt_GridGeral_PC_TAXA_JUROS_NEG As Integer = 19
    Const cnt_GridGeral_NO_TIPO_NEGOCIACAO As Integer = 20
    Const cnt_GridGeral_CD_TIPO_NEGOCIACAO As Integer = 21
    Const cnt_GridGeral_CD_TIPO_NEGOCIACAO_NEG As Integer = 22
    Const cnt_GridGeral_DT_PRAZO_FIXACAO As Integer = 23
    Const cnt_GridGeral_DT_PRAZO_FIXACAO_NEG As Integer = 24
    Const cnt_GridGeral_CD_PAPEL_COMPETENCIA As Integer = 25
    Const cnt_GridGeral_CD_PAPEL_COMPETENCIA_NEG As Integer = 26
    Const cnt_GridGeral_VL_NEGOCIACAO As Integer = 27
    Const cnt_GridGeral_VL_NEGOCIACAO_NEG As Integer = 28
    Const cnt_GridGeral_PC_ALIQ_ICMS As Integer = 29
    Const cnt_GridGeral_PC_ALIQ_ICMS_NEG As Integer = 30
    Const cnt_GridGeral_VL_PRECO_FRETE As Integer = 31
    Const cnt_GridGeral_VL_PRECO_FRETE_NEG As Integer = 32
    Const cnt_GridGeral_VL_LIMITE_CREDITO As Integer = 33
    Const cnt_GridGeral_QT_UMIDADE_PADRAO As Integer = 34
    Const cnt_GridGeral_QT_UMIDADE_PADRAO_NEG As Integer = 35
    Const cnt_GridGeral_PC_SUJIDADE_PADRAO As Integer = 36
    Const cnt_GridGeral_PC_SUJIDADE_PADRAO_NEG As Integer = 37
    Const cnt_GridGeral_NO_FILIAL_ENTREGA As Integer = 38
    Const cnt_GridGeral_CD_FILIAL_ENTREGA As Integer = 39
    Const cnt_GridGeral_CD_FILIAL_ENTREGA_NEG As Integer = 40
    Const cnt_GridGeral_NO_TIPO_CACAU As Integer = 41
    Const cnt_GridGeral_CD_TIPO_CACAU As Integer = 42
    Const cnt_GridGeral_CD_TIPO_CACAU_NEG As Integer = 43
    Const cnt_GridGeral_QT_DIA_CARENCIA_JUROS As Integer = 44
    Const cnt_GridGeral_QT_DIA_CARENCIA_JUROS_NEG As Integer = 45
    Const cnt_GridGeral_IC_CALCULA_JUROS As Integer = 46
    Const cnt_GridGeral_IC_CALCULA_JUROS_NEG As Integer = 47
    Const cnt_GridGeral_IC_JUROS_APOS_CARENCIA As Integer = 48
    Const cnt_GridGeral_IC_JUROS_APOS_CARENCIA_NEG As Integer = 49
    Const cnt_GridGeral_DS_MOTIVO_DT_VENC As Integer = 50
    Const cnt_GridGeral_DS_MOTIVO_RENEGOCIACAO As Integer = 51
    Const cnt_GridGeral_SQ_SOLICITACAO As Integer = 52

    Dim oDS As New Infragistics.Win.UltraWinDataSource.UltraDataSource

    Private Sub frmCadastroReNegociacao_Aprovacao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimparTela()

        objGrid_Inicializar(grdGeral, , oDS)
        objGrid_Coluna_Add(grdGeral, "Filial", 100)
        objGrid_Coluna_Add(grdGeral, "Usuario", 100)
        objGrid_Coluna_Add(grdGeral, "Data", 100)
        objGrid_Coluna_Add(grdGeral, "Contrato PAF", 100)
        objGrid_Coluna_Add(grdGeral, "Neg", 100)
        objGrid_Coluna_Add(grdGeral, "Fornecedor", 200)
        objGrid_Coluna_Add(grdGeral, "Repassador", 200)
        objGrid_Coluna_Add(grdGeral, "QT_KGS", 0)
        objGrid_Coluna_Add(grdGeral, "NO_TIPO_UNIDADE", 0)
        objGrid_Coluna_Add(grdGeral, "CD_TIPO_UNIDADE_NEG", 0)
        objGrid_Coluna_Add(grdGeral, "NO_TIPO_UNIDADE_NEG", 0)
        objGrid_Coluna_Add(grdGeral, "DT_VENCIMENTO", 0)
        objGrid_Coluna_Add(grdGeral, "DT_VENCIMENTO_NEG", 0)
        objGrid_Coluna_Add(grdGeral, "DT_PAGAMENTO", 0)
        objGrid_Coluna_Add(grdGeral, "DT_PAGAMENTO_NEG", 0)
        objGrid_Coluna_Add(grdGeral, "NO_LOCAL_ENTREGA", 0)
        objGrid_Coluna_Add(grdGeral, "CD_LOCAL_ENTREGA_NEG", 0)
        objGrid_Coluna_Add(grdGeral, "CD_LOCAL_ENTREGA_NEG", 0)
        objGrid_Coluna_Add(grdGeral, "PC_TAXA_JUROS", 0)
        objGrid_Coluna_Add(grdGeral, "PC_TAXA_JUROS_NEG", 0)
        objGrid_Coluna_Add(grdGeral, "NO_TIPO_NEGOCIACAO", 0)
        objGrid_Coluna_Add(grdGeral, "CD_TIPO_NEGOCIACAO", 0)
        objGrid_Coluna_Add(grdGeral, "CD_TIPO_NEGOCIACAO_NEG", 0)
        objGrid_Coluna_Add(grdGeral, "DT_PRAZO_FIXACAO", 0)
        objGrid_Coluna_Add(grdGeral, "DT_PRAZO_FIXACAO_NEG", 0)
        objGrid_Coluna_Add(grdGeral, "CD_PAPEL_COMPETENCIA", 0)
        objGrid_Coluna_Add(grdGeral, "CD_PAPEL_COMPETENCIA_NEG", 0)
        objGrid_Coluna_Add(grdGeral, "VL_NEGOCIACAO", 0)
        objGrid_Coluna_Add(grdGeral, "VL_NEGOCIACAO_NEG", 0)
        objGrid_Coluna_Add(grdGeral, "PC_ALIQ_ICMS", 0)
        objGrid_Coluna_Add(grdGeral, "PC_ALIQ_ICMS_NEG", 0)
        objGrid_Coluna_Add(grdGeral, "VL_PRECO_FRETE", 0)
        objGrid_Coluna_Add(grdGeral, "VL_PRECO_FRETE_NEG", 0)
        objGrid_Coluna_Add(grdGeral, "VL_LIMITE_CREDITO", 0)
        objGrid_Coluna_Add(grdGeral, "QT_UMIDADE_PADRAO", 0)
        objGrid_Coluna_Add(grdGeral, "QT_UMIDADE_PADRAO_NEG", 0)
        objGrid_Coluna_Add(grdGeral, "PC_SUJIDADE_PADRAO", 0)
        objGrid_Coluna_Add(grdGeral, "PC_SUJIDADE_PADRAO_NEG", 0)
        objGrid_Coluna_Add(grdGeral, "NO_FILIAL_ENTREGA", 0)
        objGrid_Coluna_Add(grdGeral, "CD_FILIAL_ENTREGA", 0)
        objGrid_Coluna_Add(grdGeral, "CD_FILIAL_ENTREGA_NEG", 0)
        objGrid_Coluna_Add(grdGeral, "NO_TIPO_CACAU", 0)
        objGrid_Coluna_Add(grdGeral, "CD_TIPO_CACAU", 0)
        objGrid_Coluna_Add(grdGeral, "CD_TIPO_CACAU_NEG", 0)
        objGrid_Coluna_Add(grdGeral, "QT_DIA_CARENCIA_JUROS", 0)
        objGrid_Coluna_Add(grdGeral, "QT_DIA_CARENCIA_JUROS_NEG", 0)
        objGrid_Coluna_Add(grdGeral, "IC_CALCULA_JUROS", 0)
        objGrid_Coluna_Add(grdGeral, "IC_CALCULA_JUROS_NEG", 0)
        objGrid_Coluna_Add(grdGeral, "IC_JUROS_APOS_CARENCIA", 0)
        objGrid_Coluna_Add(grdGeral, "IC_JUROS_APOS_CARENCIA_NEG", 0)
        objGrid_Coluna_Add(grdGeral, "DS_MOTIVO_DT_VENC", 0)
        objGrid_Coluna_Add(grdGeral, "DS_MOTIVO_RENEGOCIACAO", 0)
        objGrid_Coluna_Add(grdGeral, "SQ_SOLICITACAO", 0)

        Pesquisar()
    End Sub

    Private Sub LimparTela()
        lblAliqICMS.Visible = "0"
        lblBolsa.Text = ""
        lblCobraJuros.Text = ""
        lblDataPagamento.Text = ""
        lblDataVencimento.Text = ""
        lblFilialEntrega.Text = ""
        lblFreteFabrica.Text = ""
        lblJurosAposCarencia.Text = "0"
        lblLocalEntrega.Text = "0"
        lblPrazoFixacao.Text = ""
        lblQtdeDiasCarenciaJuros.Text = "0"
        lblQuantidade.Text = "0"
        lblMotivoDataVencimentoAvancada.Text = ""
        lblRazoesRenegociacao.Text = ""
        lblSaldoCredito.Visible = "0"
        lblSujidadePadrao.Visible = "0"
        lblTaxaJuros.Visible = "0"
        lblTipoCacau.Text = ""
        lblTipoNegociacao.Text = ""
        lblUmidadePadrao.Text = "0"
        lblUnidade.Text = ""
        lblValorUnitario.Text = "0"
    End Sub

    Private Sub Pesquisar()
        Dim SqlText As String

        SqlText = "SELECT FIL.NO_FILIAL," & _
                         "NVL(U.NO_USUARIO, SR.NO_USER_CRIACAO) NO_USUARIO," & _
                         "SR.DT_SOLICITACAO," & _
                         "SR.CD_CONTRATO_PAF," & _
                         "SR.SQ_NEGOCIACAO," & _
                         "F.NO_RAZAO_SOCIAL NO_FORNECEDOR," & _
                         "REP.NO_RAZAO_SOCIAL NO_REPASSADOR," & _
                         "SR.QT_KGS," & _
                         "TU.NO_TIPO_UNIDADE," & _
                         "SR.CD_TIPO_UNIDADE," & _
                         "N.CD_TIPO_UNIDADE CD_TIPO_UNIDADE_NEG," & _
                         "SR.DT_VENCIMENTO," & _
                         "N.DT_VENCIMENTO DT_VENCIMENTO_NEG," & _
                         "SR.DT_PAGAMENTO," & _
                         "N.DT_PAGAMENTO DT_PAGAMENTO_NEG," & _
                         "LE.NO_LOCAL_ENTREGA," & _
                         "SR.CD_LOCAL_ENTREGA," & _
                         "N.CD_LOCAL_ENTREGA CD_LOCAL_ENTREGA_NEG," & _
                         "SR.PC_TAXA_JUROS," & _
                         "NVL(N.PC_TAXA_JUROS,0) PC_TAXA_JUROS_NEG," & _
                         "TN.NO_TIPO_NEGOCIACAO," & _
                         "SR.CD_TIPO_NEGOCIACAO," & _
                         "N.CD_TIPO_NEGOCIACAO CD_TIPO_NEGOCIACAO_NEG," & _
                         "SR.DT_PRAZO_FIXACAO," & _
                         "N.DT_PRAZO_FIXACAO DT_PRAZO_FIXACAO_NEG," & _
                         "SR.CD_PAPEL_COMPETENCIA," & _
                         "N.CD_PAPEL_COMPETENCIA CD_PAPEL_COMPETENCIA_NEG," & _
                         "SR.VL_NEGOCIACAO," & _
                         "N.VL_NEGOCIACAO VL_NEGOCIACAO_NEG," & _
                         "SR.PC_ALIQ_ICMS," & _
                         "N.PC_ALIQ_ICMS PC_ALIQ_ICMS_NEG," & _
                         "SR.VL_PRECO_FRETE," & _
                         "N.VL_PRECO_FRETE VL_PRECO_FRETE_NEG," & _
                         "SR.VL_LIMITE_CREDITO," & _
                         "SR.QT_UMIDADE_PADRAO," & _
                         "N.QT_UMIDADE_PADRAO QT_UMIDADE_PADRAO_NEG," & _
                         "SR.PC_SUJIDADE_PADRAO," & _
                         "N.PC_SUJIDADE_PADRAO PC_SUJIDADE_PADRAO_NEG," & _
                         "FE.NO_FILIAL NO_FILIAL_ENTREGA," & _
                         "SR.CD_FILIAL_ENTREGA," & _
                         "N.CD_FILIAL_ENTREGA CD_FILIAL_ENTREGA_NEG," & _
                         "TC.NO_TIPO_CACAU," & _
                         "SR.CD_TIPO_CACAU," & _
                         "N.CD_TIPO_CACAU CD_TIPO_CACAU_NEG," & _
                         "NVL(SR.QT_DIA_CARENCIA_JUROS, 0) AS QT_DIA_CARENCIA_JUROS," & _
                         "NVL(N.QT_DIA_CARENCIA_JUROS, 0) QT_DIA_CARENCIA_JUROS_NEG," & _
                         "SR.IC_CALCULA_JUROS," & _
                         "N.IC_CALCULA_JUROS IC_CALCULA_JUROS_NEG," & _
                         "SR.IC_JUROS_APOS_CARENCIA," & _
                         "N.IC_JUROS_APOS_CARENCIA IC_JUROS_APOS_CARENCIA_NEG," & _
                         "SR.DS_MOTIVO_DT_VENC," & _
                         "SR.DS_MOTIVO_RENEGOCIACAO," & _
                         "SR.SQ_SOLICITACAO" & _
                  " FROM SOF.SOLICITACAO_RENEGOCIACAO SR," & _
                        "SOF.NEGOCIACAO N," & _
                        "SOF.CONTRATO_PAF CP," & _
                        "SOF.FORNECEDOR F," & _
                        "SOF.FORNECEDOR REP," & _
                        "SOF.FILIAL FIL," & _
                        "SOF.USUARIO U," & _
                        "SOF.TIPO_UNIDADE TU," & _
                        "SOF.LOCAL_ENTREGA LE," & _
                        "SOF.TIPO_NEGOCIACAO TN," & _
                        "SOF.FILIAL FE," & _
                        "SOF.TIPO_CACAU TC" & _
                  " WHERE N.CD_CONTRATO_PAF = SR.CD_CONTRATO_PAF" & _
                    " AND N.SQ_NEGOCIACAO = SR.SQ_NEGOCIACAO" & _
                    " AND CP.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF" & _
                    " AND CP.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                    " AND CP.CD_REPASSADOR = REP.CD_FORNECEDOR" & _
                    " AND F.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                    " AND U.CD_USER (+) = SR.NO_USER_CRIACAO" & _
                    " AND SR.CD_TIPO_UNIDADE = TU.CD_TIPO_UNIDADE" & _
                    " AND SR.CD_LOCAL_ENTREGA = LE.CD_LOCAL_ENTREGA" & _
                    " AND SR.CD_TIPO_NEGOCIACAO = TN.CD_TIPO_NEGOCIACAO" & _
                    " AND FE.CD_FILIAL (+)= SR.CD_FILIAL_ENTREGA" & _
                    " AND TC.CD_TIPO_CACAU (+) = SR.CD_TIPO_CACAU" & _
                    " AND SR.IC_STATUS_APROVACAO = 'W'"
        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_Filial, _
                                                           cnt_GridGeral_Usuario, _
                                                           cnt_GridGeral_Data, _
                                                           cnt_GridGeral_ContratoPAF, _
                                                           cnt_GridGeral_Neg, _
                                                           cnt_GridGeral_Fornecedor, _
                                                           cnt_GridGeral_Repassador, _
                                                           cnt_GridGeral_QT_KGS, _
                                                           cnt_GridGeral_NO_TIPO_UNIDADE, _
                                                           cnt_GridGeral_CD_TIPO_UNIDADE, _
                                                           cnt_GridGeral_CD_TIPO_UNIDADE_NEG, _
                                                           cnt_GridGeral_DT_VENCIMENTO, _
                                                           cnt_GridGeral_DT_VENCIMENTO_NEG, _
                                                           cnt_GridGeral_DT_PAGAMENTO, _
                                                           cnt_GridGeral_DT_PAGAMENTO_NEG, _
                                                           cnt_GridGeral_NO_LOCAL_ENTREGA, _
                                                           cnt_GridGeral_CD_LOCAL_ENTREGA, _
                                                           cnt_GridGeral_CD_LOCAL_ENTREGA_NEG, _
                                                           cnt_GridGeral_PC_TAXA_JUROS, _
                                                           cnt_GridGeral_PC_TAXA_JUROS_NEG, _
                                                           cnt_GridGeral_NO_TIPO_NEGOCIACAO, _
                                                           cnt_GridGeral_CD_TIPO_NEGOCIACAO, _
                                                           cnt_GridGeral_CD_TIPO_NEGOCIACAO_NEG, _
                                                           cnt_GridGeral_DT_PRAZO_FIXACAO, _
                                                           cnt_GridGeral_DT_PRAZO_FIXACAO_NEG, _
                                                           cnt_GridGeral_CD_PAPEL_COMPETENCIA, _
                                                           cnt_GridGeral_CD_PAPEL_COMPETENCIA_NEG, _
                                                           cnt_GridGeral_VL_NEGOCIACAO, _
                                                           cnt_GridGeral_VL_NEGOCIACAO_NEG, _
                                                           cnt_GridGeral_PC_ALIQ_ICMS, _
                                                           cnt_GridGeral_PC_ALIQ_ICMS_NEG, _
                                                           cnt_GridGeral_VL_PRECO_FRETE, _
                                                           cnt_GridGeral_VL_PRECO_FRETE_NEG, _
                                                           cnt_GridGeral_VL_LIMITE_CREDITO, _
                                                           cnt_GridGeral_QT_UMIDADE_PADRAO, _
                                                           cnt_GridGeral_QT_UMIDADE_PADRAO_NEG, _
                                                           cnt_GridGeral_PC_SUJIDADE_PADRAO, _
                                                           cnt_GridGeral_PC_SUJIDADE_PADRAO_NEG, _
                                                           cnt_GridGeral_NO_FILIAL_ENTREGA, _
                                                           cnt_GridGeral_CD_FILIAL_ENTREGA, _
                                                           cnt_GridGeral_CD_FILIAL_ENTREGA_NEG, _
                                                           cnt_GridGeral_NO_TIPO_CACAU, _
                                                           cnt_GridGeral_CD_TIPO_CACAU, _
                                                           cnt_GridGeral_CD_TIPO_CACAU_NEG, _
                                                           cnt_GridGeral_QT_DIA_CARENCIA_JUROS, _
                                                           cnt_GridGeral_QT_DIA_CARENCIA_JUROS_NEG, _
                                                           cnt_GridGeral_IC_CALCULA_JUROS, _
                                                           cnt_GridGeral_IC_CALCULA_JUROS_NEG, _
                                                           cnt_GridGeral_IC_JUROS_APOS_CARENCIA, _
                                                           cnt_GridGeral_IC_JUROS_APOS_CARENCIA_NEG, _
                                                           cnt_GridGeral_DS_MOTIVO_DT_VENC, _
                                                           cnt_GridGeral_DS_MOTIVO_RENEGOCIACAO, _
                                                           cnt_GridGeral_SQ_SOLICITACAO})
    End Sub

    Private Sub cmdAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAtualizar.Click
        Pesquisar()
    End Sub

    Private Sub grdGeral_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdGeral.AfterRowActivate
        lblQuantidade.Text = ""
        lblQuantidade.Font = New Font(lblQuantidade.Font, Nothing)

        lblUnidade.Text = ""
        lblUnidade.ForeColor = Black

        lblDataVencimento.Text = ""
        lblDataVencimento.ForeColor = Black

        lblDataPagamento.Text = ""
        lblDataPagamento.ForeColor = Black

        lblLocalEntrega.Text = ""
        lblLocalEntrega.ForeColor = Black

        lblTaxaJuros.Text = ""
        lblTaxaJuros.ForeColor = Black

        lblTipoNegociacao.Text = ""
        lblTipoNegociacao.ForeColor = Black

        lblPrazoFixacao.Text = ""
        lblPrazoFixacao.ForeColor = Black

        lblBolsa.Text = ""
        lblBolsa.ForeColor = Black

        lblValorUnitario.Text = ""
        lblValorUnitario.ForeColor = Black

        lblAliqICMS.Text = ""
        lblAliqICMS.ForeColor = Black

        lblFreteFabrica.Text = ""
        lblFreteFabrica.ForeColor = Black

        lblSaldoCredito.Text = ""
        lblSaldoCredito.ForeColor = Black

        lblMotivoDataVencimentoAvancada.Text = ""
        lblRazoesRenegociacao.Text = ""

        lblUmidadePadrao.Text = ""
        lblUmidadePadrao.ForeColor = Black

        lblSujidadePadrao.Text = ""
        lblSujidadePadrao.ForeColor = Black

        lblFilialEntrega.Text = ""
        lblFilialEntrega.ForeColor = Black

        lblTipoCacau.Text = ""
        lblTipoCacau.ForeColor = Black

        lblCobraJuros.Text = ""
        lblCobraJuros.ForeColor = Black

        lblJurosAposCarencia.Text = ""
        lblJurosAposCarencia.ForeColor = Black

        lblQtdeDiasCarenciaJuros.Text = ""
        lblQtdeDiasCarenciaJuros.ForeColor = Black

        If objGrid_LinhaSelecionada(grdGeral) = -1 Then Exit Sub

        lblQuantidade.Text = objGrid_Valor(grdGeral, cnt_GridGeral_QT_KGS)
        lblQuantidade.Font = New Font(lblQuantidade.Font, FontStyle.Bold)

        lblUnidade.Text = objGrid_Valor(grdGeral, cnt_GridGeral_NO_TIPO_UNIDADE)
        If objGrid_Valor(grdGeral, cnt_GridGeral_CD_TIPO_UNIDADE) <> objGrid_Valor(grdGeral, cnt_GridGeral_CD_TIPO_UNIDADE_NEG) Then
            lblUnidade.ForeColor = Red
        End If

        lblDataVencimento.Text = objGrid_Valor(grdGeral, cnt_GridGeral_DT_VENCIMENTO)
        If objGrid_Valor(grdGeral, cnt_GridGeral_DT_VENCIMENTO) <> objGrid_Valor(grdGeral, cnt_GridGeral_DT_VENCIMENTO_NEG) Then
            lblDataVencimento.ForeColor = Red
        End If

        lblDataPagamento.Text = objGrid_Valor(grdGeral, cnt_GridGeral_DT_PAGAMENTO)
        If objGrid_Valor(grdGeral, cnt_GridGeral_DT_PAGAMENTO) <> objGrid_Valor(grdGeral, cnt_GridGeral_DT_PAGAMENTO_NEG) Then
            lblDataPagamento .ForeColor = Red
        End If

        lblLocalEntrega.Text = objGrid_Valor(grdGeral, cnt_GridGeral_NO_LOCAL_ENTREGA)
        If objGrid_Valor(grdGeral, cnt_GridGeral_CD_LOCAL_ENTREGA) <> objGrid_Valor(grdGeral, cnt_GridGeral_CD_LOCAL_ENTREGA_NEG) Then
            lblLocalEntrega.ForeColor = Red
        End If

        lblTaxaJuros.Text = objGrid_Valor(grdGeral, cnt_GridGeral_PC_TAXA_JUROS)
        If objGrid_Valor(grdGeral, cnt_GridGeral_PC_TAXA_JUROS) <> objGrid_Valor(grdGeral, cnt_GridGeral_PC_TAXA_JUROS_NEG) Then
            lblTaxaJuros.ForeColor = Red
        End If

        lblTipoNegociacao.Text = objGrid_Valor(grdGeral, cnt_GridGeral_NO_TIPO_NEGOCIACAO)
        If objGrid_Valor(grdGeral, cnt_GridGeral_CD_TIPO_NEGOCIACAO) <> objGrid_Valor(grdGeral, cnt_GridGeral_CD_TIPO_NEGOCIACAO_NEG) Then
            lblTipoNegociacao.ForeColor = Red
        End If

        lblPrazoFixacao.Text = objGrid_Valor(grdGeral, cnt_GridGeral_DT_PRAZO_FIXACAO)
        If objGrid_Valor(grdGeral, cnt_GridGeral_DT_PRAZO_FIXACAO, , New Date(1990, 1, 1)) <> _
           objGrid_Valor(grdGeral, cnt_GridGeral_DT_PRAZO_FIXACAO_NEG, , New Date(1990, 1, 1)) Then
            lblPrazoFixacao.ForeColor = Red
        End If

        lblBolsa.Text = objGrid_Valor(grdGeral, cnt_GridGeral_CD_PAPEL_COMPETENCIA)
        If objGrid_Valor(grdGeral, cnt_GridGeral_CD_PAPEL_COMPETENCIA) <> objGrid_Valor(grdGeral, cnt_GridGeral_CD_PAPEL_COMPETENCIA_NEG) Then
            lblBolsa.ForeColor = Red
        End If

        lblValorUnitario.Text = objGrid_Valor(grdGeral, cnt_GridGeral_VL_NEGOCIACAO)
        If objGrid_Valor(grdGeral, cnt_GridGeral_VL_NEGOCIACAO) <> objGrid_Valor(grdGeral, cnt_GridGeral_VL_NEGOCIACAO_NEG) Then
            lblValorUnitario.ForeColor = Red
        End If

        lblAliqICMS.Text = objGrid_Valor(grdGeral, cnt_GridGeral_PC_ALIQ_ICMS)
        If objGrid_Valor(grdGeral, cnt_GridGeral_PC_ALIQ_ICMS) <> objGrid_Valor(grdGeral, cnt_GridGeral_PC_ALIQ_ICMS_NEG) Then
            lblAliqICMS.ForeColor = Red
        End If

        lblFreteFabrica.Text = objGrid_Valor(grdGeral, cnt_GridGeral_VL_PRECO_FRETE)
        If objGrid_Valor(grdGeral, cnt_GridGeral_VL_PRECO_FRETE) <> objGrid_Valor(grdGeral, cnt_GridGeral_VL_PRECO_FRETE_NEG) Then
            lblFreteFabrica.ForeColor = Red
        End If

        lblSaldoCredito.Text = objGrid_Valor(grdGeral, cnt_GridGeral_VL_LIMITE_CREDITO, , 0)
        If objGrid_Valor(grdGeral, cnt_GridGeral_VL_LIMITE_CREDITO, , 0) < 0 Then
            lblSaldoCredito.ForeColor = Red
        End If

        lblUmidadePadrao.Text = objGrid_Valor(grdGeral, cnt_GridGeral_QT_UMIDADE_PADRAO, , 0)
        If objGrid_Valor(grdGeral, cnt_GridGeral_QT_UMIDADE_PADRAO, , 0) <> objGrid_Valor(grdGeral, cnt_GridGeral_QT_UMIDADE_PADRAO_NEG, , 8) Then
            lblUmidadePadrao.ForeColor = Red
        End If

        lblSujidadePadrao.Text = objGrid_Valor(grdGeral, cnt_GridGeral_PC_SUJIDADE_PADRAO, , 0)
        If objGrid_Valor(grdGeral, cnt_GridGeral_PC_SUJIDADE_PADRAO, , 0) <> objGrid_Valor(grdGeral, cnt_GridGeral_PC_SUJIDADE_PADRAO, , 0.5) Then
            lblSujidadePadrao.ForeColor = Red
        End If

        lblFilialEntrega.Text = objGrid_Valor(grdGeral, cnt_GridGeral_NO_FILIAL_ENTREGA)
        If objGrid_Valor(grdGeral, cnt_GridGeral_CD_FILIAL_ENTREGA) <> objGrid_Valor(grdGeral, cnt_GridGeral_CD_FILIAL_ENTREGA_NEG) Then
            lblFilialEntrega.ForeColor = Red
        End If

        lblTipoCacau.Text = objGrid_Valor(grdGeral, cnt_GridGeral_NO_TIPO_CACAU)
        If objGrid_Valor(grdGeral, cnt_GridGeral_CD_TIPO_CACAU) <> objGrid_Valor(grdGeral, cnt_GridGeral_CD_TIPO_CACAU_NEG) Then
            lblTipoCacau.ForeColor = Red
        End If

        lblQtdeDiasCarenciaJuros.Text = objGrid_Valor(grdGeral, cnt_GridGeral_QT_DIA_CARENCIA_JUROS)
        If objGrid_Valor(grdGeral, cnt_GridGeral_QT_DIA_CARENCIA_JUROS) <> objGrid_Valor(grdGeral, cnt_GridGeral_QT_DIA_CARENCIA_JUROS_NEG) Then
            lblQtdeDiasCarenciaJuros.ForeColor = Red
        End If

        lblCobraJuros.Text = IIf(objGrid_Valor(grdGeral, cnt_GridGeral_IC_CALCULA_JUROS) = "S", "Sim", "Não")
        If objGrid_Valor(grdGeral, cnt_GridGeral_IC_CALCULA_JUROS) <> objGrid_Valor(grdGeral, cnt_GridGeral_IC_CALCULA_JUROS_NEG) Then
            lblCobraJuros.ForeColor = Red
        End If

        lblJurosAposCarencia.Text = IIf(objGrid_Valor(grdGeral, cnt_GridGeral_IC_JUROS_APOS_CARENCIA, , "N") = "S", "Sim", "Não")
        If objGrid_Valor(grdGeral, cnt_GridGeral_IC_JUROS_APOS_CARENCIA, , "N") <> objGrid_Valor(grdGeral, cnt_GridGeral_IC_JUROS_APOS_CARENCIA_NEG, , "N") Then
            lblJurosAposCarencia.ForeColor = Red
        End If

        lblMotivoDataVencimentoAvancada.Text = objGrid_Valor(grdGeral, cnt_GridGeral_DS_MOTIVO_DT_VENC, , "")
        lblRazoesRenegociacao.Text = objGrid_Valor(grdGeral, cnt_GridGeral_DS_MOTIVO_RENEGOCIACAO, , "")
    End Sub

    Private Sub cmdAprovar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAprovacao.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        If Not Msg_Perguntar("Aprova esta solicitação?") Then Exit Sub

        Dim SqlText As String

        On Error GoTo Erro

        SqlText = "SELECT NVL(IC_STATUS_APROVACAO, 'X')" & _
                  " FROM SOF.SOLICITACAO_RENEGOCIACAO" & _
                  " WHERE CD_CONTRATO_PAF = " & objGrid_Valor(grdGeral, cnt_GridGeral_ContratoPAF) & _
                    " AND SQ_NEGOCIACAO = " & objGrid_Valor(grdGeral, cnt_GridGeral_Neg) & _
                    " AND SQ_SOLICITACAO = " & objGrid_Valor(grdGeral, cnt_GridGeral_SQ_SOLICITACAO)

        If DBQuery_ValorUnico(SqlText) <> "W" Then
            Msg_Mensagem("A solicitação de renegociação não está mais aguardando aprovação")
        Else
            SqlText = DBMontar_SP("SOF.SP_APROVA_RENEGOCIACAO", False, ":CDCONTRATOPAF", _
                                                                       ":SQNEGSOLCITACAO", _
                                                                       ":SQSOLICITACAO")
            If Not DBExecutar(SqlText, DBParametro_Montar("CDCONTRATOPAF", objGrid_Valor(grdGeral, cnt_GridGeral_ContratoPAF)), _
                                       DBParametro_Montar("SQNEGSOLCITACAO", objGrid_Valor(grdGeral, cnt_GridGeral_Neg)), _
                                       DBParametro_Montar("SQSOLICITACAO", objGrid_Valor(grdGeral, cnt_GridGeral_SQ_SOLICITACAO))) Then GoTo Erro

            Pesquisar()
        End If

        Exit Sub

Erro:
        TratarErro(, , "frmCadastroReNegociacao_Aprovacao.cmdAprovar_Click")
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub
End Class