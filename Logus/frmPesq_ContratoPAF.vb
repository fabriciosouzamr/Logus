Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmPesq_ContratoPAF
    Const cnt_GridGeral_IC_STATUS As Integer = 0
    Const cnt_GridGeral_CD_CONTRATO_PAF As Integer = 1
    Const cnt_GridGeral_DT_CONTRATO_PAF As Integer = 2
    Const cnt_GridGeral_DT_PRAZO_ENTREGA As Integer = 3
    Const cnt_GridGeral_DT_PRAZO_FIXACAO As Integer = 4
    Const cnt_GridGeral_NO_RAZAO_SOCIAL As Integer = 5
    Const cnt_GridGeral_QT_KGS As Integer = 6
    Const cnt_GridGeral_QT_KG_FIXO As Integer = 7
    Const cnt_GridGeral_QT_CANCELADO As Integer = 8
    Const cnt_GridGeral_QT_SALDO As Integer = 9
    Const cnt_GridGeral_QT_A_NEGOCIAR As Integer = 10
    Const cnt_GridGeral_VL_NF_FIXO As Integer = 11
    Const cnt_GridGeral_VL_PAG_FIXO As Integer = 12
    Const cnt_GridGeral_NO_FILIAL As Integer = 13
    Const cnt_GridGeral_NO_REPASSADOR As Integer = 14
    Const cnt_GridGeral_NO_TIPO_PESSOA As Integer = 15
    Const cnt_GridGeral_NO_TIPO_CONTRATO_PAF As Integer = 16
    Const cnt_GridGeral_VL_ADIANTAMENTO As Integer = 17
    Const cnt_GridGeral_DS_SAFRA As Integer = 18
    Const cnt_GridGeral_DS_SAFRA_COMPETENCIA As Integer = 19
    Const cnt_GridGeral_NO_TIPO_ACONDICIONAMENTO As Integer = 20
    Const cnt_GridGeral_NO_TIPO_MODALIDADE_ENTREGA As Integer = 21
    Const cnt_GridGeral_NO_LOCAL_CONFERENCIA_PESO As Integer = 22
    Const cnt_GridGeral_NO_LOCAL_CONFERENCIA_QUALIDADE As Integer = 23
    Const cnt_GridGeral_NO_TIPO_DESPESA_CARREGAMENTO As Integer = 24
    Const cnt_GridGeral_IC_CALCULA_JUROS As Integer = 25
    Const cnt_GridGeral_QT_DIA_CARENCIA_JUROS As Integer = 26
    Const cnt_GridGeral_IC_JUROS_APOS_CARENCIA As Integer = 27
    Const cnt_GridGeral_PC_TAXA_JUROS As Integer = 28
    Const cnt_GridGeral_NO_UF As Integer = 29
    Const cnt_GridGeral_NO_TIPO_QUALIDADE As Integer = 30
    Const cnt_GridGeral_NO_FILIAL_NF As Integer = 31
    Const cnt_GridGeral_NO_FILIAL_ENTREGA As Integer = 32
    Const cnt_GridGeral_NO_TIPO_CONDICAO_PAGAMENTO As Integer = 33
    Const cnt_GridGeral_CD_CONTRATO_PAF_ORIGEM As Integer = 34
    Const cnt_GridGeral_CD_FORNECEDOR As Integer = 35
    Const cnt_GridGeral_CD_REPASSADOR As Integer = 36
    Const cnt_GridGeral_CD_TIPO_CONTRATO_PAF As Integer = 37
    Const cnt_GridGeral_DT_VENCIMENTO As Integer = 38
    Const cnt_GridGeral_CD_FILIAL_ORIGEM As Integer = 39
    Const cnt_GridGeral_CD_SAFRA As Integer = 40
    Const cnt_GridGeral_DT_CRIACAO As Integer = 41
    Const cnt_GridGeral_NO_USER_CRIACAO As Integer = 42
    Const cnt_GridGeral_DT_ALTERACAO As Integer = 43
    Const cnt_GridGeral_NO_USER_ALTERACAO As Integer = 44
    Const cnt_GridGeral_VL_NF_INSS_FIXO As Integer = 45
    Const cnt_GridGeral_VL_NF_ICMS_FIXO As Integer = 46
    Const cnt_GridGeral_CD_SAFRA_COMPETENCIA As Integer = 47
    Const cnt_GridGeral_CD_TIPO_ACONDICIONAMENTO As Integer = 48
    Const cnt_GridGeral_CD_TIPO_MODALIDADE_ENTREGA As Integer = 49
    Const cnt_GridGeral_CD_TIPO_DESPESA_CARREGAMENTO As Integer = 50
    Const cnt_GridGeral_CD_LOCAL_CONFERENCIA_PESO As Integer = 51
    Const cnt_GridGeral_CD_LOCAL_CONFERENCIA_QUALIDADE As Integer = 52
    Const cnt_GridGeral_CD_TIPO_PESSOA As Integer = 53
    Const cnt_GridGeral_IC_ADIANTAMENTO As Integer = 54

    Dim oPesq_CodigoNome As Pesq_CodigoNome
    Dim oDS As New UltraWinDataSource.UltraDataSource
    Dim oFiltro As Collection

    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Close()
    End Sub

    Property Form_Pesq_Filtro() As Collection
        Get
            Return oFiltro
        End Get
        Set(ByVal Valor As Collection)
            oFiltro = Valor
        End Set
    End Property

    Property Form_Pesq_CodigoNome() As Pesq_CodigoNome
        Get
            Return oPesq_CodigoNome
        End Get
        Set(ByVal Valor As Pesq_CodigoNome)
            oPesq_CodigoNome = Valor
        End Set
    End Property

    Property Form_Pesq_Fornecedor() As Integer
        Get
            Return Pesq_Fornecedor.Codigo
        End Get
        Set(ByVal Valor As Integer)
            Pesq_Fornecedor.Codigo = Valor
            Pesq_Fornecedor.Enabled = (Valor = 0)
        End Set
    End Property

    Private Sub frmPesq_ContratoPAF_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Pesq_Fornecedor.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        objGrid_Inicializar(grdGeral, , oDS, Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect, , , True)
        objGrid_Coluna_Add(grdGeral, "Sit", 100)
        objGrid_Coluna_Add(grdGeral, "Número", 100)
        objGrid_Coluna_Add(grdGeral, "Data", 100, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdGeral, "Prazo de Entrega", 100)
        objGrid_Coluna_Add(grdGeral, "Prazo de Fixação", 100)
        objGrid_Coluna_Add(grdGeral, "Fornecedor", 100)
        objGrid_Coluna_Add(grdGeral, "Kgs", 100)
        objGrid_Coluna_Add(grdGeral, "Kgs Aplicado", 100)
        objGrid_Coluna_Add(grdGeral, "Kgs Cancelado", 100)
        objGrid_Coluna_Add(grdGeral, "Saldo", 100)
        objGrid_Coluna_Add(grdGeral, "Kgs a Negociar", 100)
        objGrid_Coluna_Add(grdGeral, "Valor NF Aplicado", 100)
        objGrid_Coluna_Add(grdGeral, "Valor Aplicado", 100)
        objGrid_Coluna_Add(grdGeral, "Filial de Origem", 100)
        objGrid_Coluna_Add(grdGeral, "Repassador", 100)
        objGrid_Coluna_Add(grdGeral, "Tipo de Pessoa", 100)
        objGrid_Coluna_Add(grdGeral, "Tipo de Contrato PAF", 100)
        objGrid_Coluna_Add(grdGeral, "Vl Adiantamento", 100)
        objGrid_Coluna_Add(grdGeral, "Safra", 100)
        objGrid_Coluna_Add(grdGeral, "Safra Competência", 100)
        objGrid_Coluna_Add(grdGeral, "Tipo de Acondicionamento", 100)
        objGrid_Coluna_Add(grdGeral, "Tipo de Modalidade de Entrega", 100)
        objGrid_Coluna_Add(grdGeral, "Local de Conferência de Peso", 100)
        objGrid_Coluna_Add(grdGeral, "Local de Conferência de Qualidade", 100)
        objGrid_Coluna_Add(grdGeral, "Despesa de Carregamento", 100)
        objGrid_Coluna_Add(grdGeral, "Calcula Juros?", 100)
        objGrid_Coluna_Add(grdGeral, "Qtde. Dias de Carência de Juros", 100)
        objGrid_Coluna_Add(grdGeral, "Juros após Carência ?", 100)
        objGrid_Coluna_Add(grdGeral, "Taxa de Juros", 100)
        objGrid_Coluna_Add(grdGeral, "Origem", 100)
        objGrid_Coluna_Add(grdGeral, "Tipo de Qualidade", 100)
        objGrid_Coluna_Add(grdGeral, "Filial da NF", 100)
        objGrid_Coluna_Add(grdGeral, "Filial de Entrega", 100)
        objGrid_Coluna_Add(grdGeral, "Tipo de Condição de Pagto.", 100)
        objGrid_Coluna_Add(grdGeral, "Contrato PAF de Origem", 100)
        objGrid_Coluna_Add(grdGeral, "CD_TIPO_CONTRATO_PAF", 0)
        objGrid_Coluna_Add(grdGeral, "CD_FORNECEDOR", 0)
        objGrid_Coluna_Add(grdGeral, "CD_REPASSADOR", 0)
        objGrid_Coluna_Add(grdGeral, "DT_VENCIMENTO", 0)
        objGrid_Coluna_Add(grdGeral, "CD_FILIAL_ORIGEM", 0)
        objGrid_Coluna_Add(grdGeral, "CD_SAFRA", 0)
        objGrid_Coluna_Add(grdGeral, "DT_CRIACAO", 0)
        objGrid_Coluna_Add(grdGeral, "NO_USER_CRIACAO", 0)
        objGrid_Coluna_Add(grdGeral, "DT_ALTERACAO", 0)
        objGrid_Coluna_Add(grdGeral, "NO_USER_ALTERACAO", 0)
        objGrid_Coluna_Add(grdGeral, "VL_NF_INSS_FIXO", 0)
        objGrid_Coluna_Add(grdGeral, "VL_NF_ICMS_FIXO", 0)
        objGrid_Coluna_Add(grdGeral, "CD_SAFRA_COMPETENCIA", 0)
        objGrid_Coluna_Add(grdGeral, "CD_TIPO_ACONDICIONAMENTO", 0)
        objGrid_Coluna_Add(grdGeral, "CD_TIPO_MODALIDADE_ENTREGA", 0)
        objGrid_Coluna_Add(grdGeral, "CD_TIPO_DESPESA_CARREGAMENTO", 0)
        objGrid_Coluna_Add(grdGeral, "CD_LOCAL_CONFERENCIA_PESO", 0)
        objGrid_Coluna_Add(grdGeral, "CD_LOCAL_CONFERENCIA_QUALIDADE", 0)
        objGrid_Coluna_Add(grdGeral, "CD_TIPO_PESSOA", 0)
        objGrid_Coluna_Add(grdGeral, "IC_ADIANTAMENTO", 0)
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String

        SqlText = "SELECT DECODE(CP.IC_STATUS, 'A', 'Aberto', 'E', 'Eliminado', 'F', 'Fechado') IC_STATUS," & _
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
                         "TCP.IC_ADIANTAMENTO" & _
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
                         "SOF.TIPO_CONDICAO_PAGAMENTO TCPAG" & _
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
                     " AND F.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"

        If Pesq_Fornecedor.Codigo > 0 Then
            SqlText = SqlText & " AND CP.CD_FORNECEDOR = " & Pesq_Fornecedor.Codigo
        End If
        If txtNumeroContratoPAF.Value <> 0 And IsNumeric(txtNumeroContratoPAF.Value) Then
            SqlText = SqlText & " AND CP.CD_CONTRATO_PAF = " & txtNumeroContratoPAF.Value
        End If
        If IsDate(txtDataInicial.Value) Then
            SqlText = SqlText & " AND CP.DT_CONTRATO_PAF >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Value))
        End If
        If IsDate(txtDataFinal.Value) Then
            SqlText = SqlText & " AND CP.DT_CONTRATO_PAF <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Value))
        End If

        If Not oFiltro Is Nothing Then
            If oFiltro.Count > 0 Then
                SqlText = SqlText & Montar_Filtro(oFiltro)
            End If
        End If

        SqlText = SqlText & _
                   " ORDER BY CP.CD_CONTRATO_PAF"

        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_IC_STATUS, cnt_GridGeral_CD_CONTRATO_PAF, _
                                                           cnt_GridGeral_DT_CONTRATO_PAF, cnt_GridGeral_DT_PRAZO_ENTREGA, _
                                                           cnt_GridGeral_DT_PRAZO_FIXACAO, cnt_GridGeral_NO_RAZAO_SOCIAL, _
                                                           cnt_GridGeral_QT_KGS, cnt_GridGeral_QT_KG_FIXO, _
                                                           cnt_GridGeral_QT_CANCELADO, cnt_GridGeral_QT_SALDO, _
                                                           cnt_GridGeral_QT_A_NEGOCIAR, cnt_GridGeral_VL_NF_FIXO, _
                                                           cnt_GridGeral_VL_PAG_FIXO, cnt_GridGeral_NO_FILIAL, _
                                                           cnt_GridGeral_NO_REPASSADOR, cnt_GridGeral_NO_TIPO_PESSOA, _
                                                           cnt_GridGeral_NO_TIPO_CONTRATO_PAF, cnt_GridGeral_VL_ADIANTAMENTO, _
                                                           cnt_GridGeral_DS_SAFRA, cnt_GridGeral_DS_SAFRA_COMPETENCIA, _
                                                           cnt_GridGeral_NO_TIPO_ACONDICIONAMENTO, cnt_GridGeral_NO_TIPO_MODALIDADE_ENTREGA, _
                                                           cnt_GridGeral_NO_LOCAL_CONFERENCIA_PESO, cnt_GridGeral_NO_LOCAL_CONFERENCIA_QUALIDADE, _
                                                           cnt_GridGeral_NO_TIPO_DESPESA_CARREGAMENTO, cnt_GridGeral_IC_CALCULA_JUROS, _
                                                           cnt_GridGeral_QT_DIA_CARENCIA_JUROS, cnt_GridGeral_IC_JUROS_APOS_CARENCIA, _
                                                           cnt_GridGeral_PC_TAXA_JUROS, cnt_GridGeral_NO_UF, cnt_GridGeral_NO_TIPO_QUALIDADE, _
                                                           cnt_GridGeral_NO_FILIAL_NF, cnt_GridGeral_NO_FILIAL_ENTREGA, _
                                                           cnt_GridGeral_NO_TIPO_CONDICAO_PAGAMENTO, cnt_GridGeral_CD_CONTRATO_PAF_ORIGEM, _
                                                           cnt_GridGeral_CD_FORNECEDOR, cnt_GridGeral_CD_REPASSADOR, _
                                                           cnt_GridGeral_CD_TIPO_CONTRATO_PAF, cnt_GridGeral_DT_VENCIMENTO, _
                                                           cnt_GridGeral_CD_FILIAL_ORIGEM, cnt_GridGeral_CD_SAFRA, cnt_GridGeral_DT_CRIACAO, _
                                                           cnt_GridGeral_NO_USER_CRIACAO, cnt_GridGeral_DT_ALTERACAO, cnt_GridGeral_NO_USER_ALTERACAO, _
                                                           cnt_GridGeral_VL_NF_INSS_FIXO, cnt_GridGeral_VL_NF_ICMS_FIXO, cnt_GridGeral_CD_SAFRA_COMPETENCIA, _
                                                           cnt_GridGeral_CD_TIPO_ACONDICIONAMENTO, cnt_GridGeral_CD_TIPO_MODALIDADE_ENTREGA, _
                                                           cnt_GridGeral_CD_TIPO_DESPESA_CARREGAMENTO, cnt_GridGeral_CD_LOCAL_CONFERENCIA_PESO, _
                                                           cnt_GridGeral_CD_LOCAL_CONFERENCIA_QUALIDADE, cnt_GridGeral_CD_TIPO_PESSOA, _
                                                           cnt_GridGeral_IC_ADIANTAMENTO})
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsulta()
    End Sub

    Private Sub cmdSelecionar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSelecionar.Click
        RegistroSelecionado()
    End Sub

    Private Sub RegistroSelecionado()
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        With oPesq_CodigoNome
            .TelaFiltro = True
            .Codigo = objGrid_Valor(grdGeral, cnt_GridGeral_CD_CONTRATO_PAF)
            .TelaFiltro = False
        End With

        Close()
    End Sub

    Private Sub grdGeral_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles grdGeral.DoubleClickRow
        RegistroSelecionado()
    End Sub
End Class