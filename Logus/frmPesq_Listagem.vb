Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmPesq_Listagem
    Public Enum PesqLista_TipoTela
        TipoMovimentacao = 1
        Fretista = 2
        TipoMovimentacao_Aplicacao = 3
    End Enum

    Const cnt_GridTipoMovimentacao_Codigo As Integer = 0
    Const cnt_GridTipoMovimentacao_Descricao As Integer = 1
    Const cnt_GridTipoMovimentacao_EntraRD As Integer = 2
    Const cnt_GridTipoMovimentacao_TipoRD As Integer = 3
    Const cnt_GridTipoMovimentacao_EntradaSaida As Integer = 4
    Const cnt_GridTipoMovimentacao_Contabiliza As Integer = 5
    Const cnt_GridTipoMovimentacao_NrContaContabil As Integer = 6
    Const cnt_GridTipoMovimentacao_MudaContaContabil As Integer = 7
    Const cnt_GridTipoMovimentacao_NrContaContabil_CP As Integer = 8
    Const cnt_GridTipoMovimentacao_MudaContaContabil_CP As Integer = 9
    Const cnt_GridTipoMovimentacao_SubLedger As Integer = 10
    Const cnt_GridTipoMovimentacao_TipoSubLedger As Integer = 11
    Const cnt_GridTipoMovimentacao_SubLedger_CP As Integer = 12
    Const cnt_GridTipoMovimentacao_TipoSubLedger_CP As Integer = 13
    Const cnt_GridTipoMovimentacao_Valida_KG As Integer = 14
    Const cnt_GridTipoMovimentacao_ValidaQualidade As Integer = 15
    Const cnt_GridTipoMovimentacao_ValidaValor As Integer = 16
    Const cnt_GridTipoMovimentacao_Importacao As Integer = 17
    Const cnt_GridTipoMovimentacao_Fiscal As Integer = 18
    Const cnt_GridTipoMovimentacao_RDAtivo As Integer = 19
    Const cnt_GridTipoMovimentacao_PostoFixo As Integer = 20
    Const cnt_GridTipoMovimentacao_LocalEntrega As Integer = 21

    Const cnt_GridTipoFretista_Nome As Integer = 0
    Const cnt_GridTipoFretista_TipoFretista As Integer = 1
    Const cnt_GridTipoFretista_Pessoa As Integer = 2
    Const cnt_GridTipoFretista_CNPJ_CPF As Integer = 3
    Const cnt_GridTipoFretista_Inscricao_INSS As Integer = 4
    Const cnt_GridTipoFretista_PIS_PASEP As Integer = 5
    Const cnt_GridTipoFretista_AddressNumber As Integer = 6
    Const cnt_GridTipoFretista_Favorecido As Integer = 7
    Const cnt_GridTipoFretista_Qt_Dependentes As Integer = 8
    Const cnt_GridTipoFretista_Codigo As Integer = 9

    Dim oPesq_CodigoNome As Pesq_CodigoNome
    Dim oDS As New UltraWinDataSource.UltraDataSource
    Dim oFiltro As Collection
    Dim oTipoTela As PesqLista_TipoTela

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
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

    Public Sub Carregar(ByVal oTipo As PesqLista_TipoTela)
        oTipoTela = oTipo

        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False, True)

        Select Case oTipoTela
            Case PesqLista_TipoTela.TipoMovimentacao, PesqLista_TipoTela.TipoMovimentacao_Aplicacao
                lblListagem.Text = "Listagem de Tipo de Movimentação"

                objGrid_Coluna_Add(grdGeral, "Código", 53)
                objGrid_Coluna_Add(grdGeral, "Descrição", 248)
                objGrid_Coluna_Add(grdGeral, "Entra no RD?", 50)
                objGrid_Coluna_Add(grdGeral, "Tipo do RD", 86)
                objGrid_Coluna_Add(grdGeral, "Entrada/Saída", 103)
                objGrid_Coluna_Add(grdGeral, "Contabiliza?", 93)
                objGrid_Coluna_Add(grdGeral, "Nº da Conta Contábil", 147)
                objGrid_Coluna_Add(grdGeral, "Muda Conta Contábil?", 157)
                objGrid_Coluna_Add(grdGeral, "Nº da Conta Contábil C/P", 174)
                objGrid_Coluna_Add(grdGeral, "Muda Conta Contábil C/P", 175)
                objGrid_Coluna_Add(grdGeral, "Sub Ledger", 86)
                objGrid_Coluna_Add(grdGeral, "Tipo Sub Ledger", 119)
                objGrid_Coluna_Add(grdGeral, "Sub Ledger C/P", 113)
                objGrid_Coluna_Add(grdGeral, "Tipo Sub Ledger C/P", 146)
                objGrid_Coluna_Add(grdGeral, "Valida K.G.?", 102)
                objGrid_Coluna_Add(grdGeral, "Valida Qualidade?", 129)
                objGrid_Coluna_Add(grdGeral, "Valida Valor?", 98)
                objGrid_Coluna_Add(grdGeral, "Importação?", 93)
                objGrid_Coluna_Add(grdGeral, "Fiscal?", 58)
                objGrid_Coluna_Add(grdGeral, "RD Ativo?", 77)
                objGrid_Coluna_Add(grdGeral, "Posto Fixo?", 90)
                objGrid_Coluna_Add(grdGeral, "Local de Entrega", 123)

                Pesquisar()
            Case PesqLista_TipoTela.Fretista
                objGrid_Coluna_Add(grdGeral, "Nome", 150)
                objGrid_Coluna_Add(grdGeral, "Tipo Fretista", 100)
                objGrid_Coluna_Add(grdGeral, "Pessoa", 100)
                objGrid_Coluna_Add(grdGeral, "CNPJ/CPF", 100)
                objGrid_Coluna_Add(grdGeral, "Inscrição INSS", 100)
                objGrid_Coluna_Add(grdGeral, "PIS/PASEP", 100)
                objGrid_Coluna_Add(grdGeral, "Address Number", 100)
                objGrid_Coluna_Add(grdGeral, "Favorecido", 150)
                objGrid_Coluna_Add(grdGeral, "Qt Dependentes", 100)
                objGrid_Coluna_Add(grdGeral, "Codigo", 50)

                Pesquisar()
        End Select
    End Sub

    Private Sub Pesquisar()
        Dim SqlText As String

        Select Case oTipoTela
            Case PesqLista_TipoTela.TipoMovimentacao, PesqLista_TipoTela.TipoMovimentacao_Aplicacao
                SqlText = "SELECT M.CD_TIPO_MOVIMENTACAO," & _
                                 "M.NO_TIPO_MOVIMENTACAO," & _
                                 "DECODE(NVL(M.IC_ENTRA_NO_RD, 'N'), 'S', 'Sim', 'Não') IC_ENTRA_NO_RD," & _
                                 "RD.NO_TIPO_RD," & _
                                 "DECODE(NVL(M.IC_ENTRADA_SAIDA, 'N'), 'E', 'Entrada', 'S', 'Saída', '') IC_ENTRADA_SAIDA," & _
                                 "DECODE(NVL(M.IC_CONTABILIZA, 'N'), 'S', 'Sim', 'Não') IC_CONTABILIZA," & _
                                 "M.NU_CONTA_CONTABIL," & _
                                 "DECODE(NVL(M.IC_MUDA_CONTA_CONTABIL, 'N'), 'S', 'Sim', 'Não') IC_MUDA_CONTA_CONTABIL," & _
                                 "M.NU_CONTA_CONTABIL_CP," & _
                                 "DECODE(NVL(M.IC_MUDA_CONTA_CONTABIL_CP, 'N'), 'S', 'Sim', 'Não') IC_MUDA_CONTA_CONTABIL_CP," & _
                                 "M.CD_SUB_LEDGER," & _
                                 "M.CD_TIPO_SUB_LEDGER," & _
                                 "M.CD_SUB_LEDGER_CP," & _
                                 "M.CD_TIPO_SUB_LEDGER_CP," & _
                                 "DECODE(NVL(M.IC_VALIDA_KG, 'N'), 'S', 'Sim', 'Não') IC_VALIDA_KG," & _
                                 "DECODE(NVL(M.IC_VALIDA_QUALIDADE, 'N'), 'S', 'Sim', 'Não') IC_VALIDA_QUALIDADE," & _
                                 "DECODE(NVL(M.IC_VALIDA_VALOR, 'N'), 'S', 'Sim', 'Não') IC_VALIDA_VALOR," & _
                                 "DECODE(NVL(M.IC_IMPORTACAO, 'N'), 'S', 'Sim', 'Não') IC_IMPORTACAO," & _
                                 "DECODE(NVL(M.IC_FISCAL, 'N'), 'S', 'Sim', 'Não') IC_FISCAL," & _
                                 "DECODE(NVL(M.IC_ATIVO, 'N'), 'S', 'Sim', 'Não') IC_ATIVO," & _
                                 "DECODE(NVL(M.IC_POSTO_FIXO, 'N'), 'S', 'Sim', 'Não') IC_POSTO_FIXO," & _
                                 "L.NO_LOCAL_ENTREGA " & _
                          " FROM (SELECT NO_TIPO_RD,CD_TIPO_RD, IC_ATIVO AS IC_ATIVO_RD FROM SOF.TIPO_RD) RD," & _
                                "(SELECT CD_LOCAL_ENTREGA , NO_LOCAL_ENTREGA, IC_ATIVO AS IC_ATIVO_LE FROM SOF.LOCAL_ENTREGA) L," & _
                                "SOF.TIPO_MOVIMENTACAO M" & _
                          " WHERE RD.CD_TIPO_RD (+) = M.CD_TIPO_RD" & _
                            " AND L.CD_LOCAL_ENTREGA (+) = M.CD_LOCAL_ENTREGA"

                If oTipoTela = PesqLista_TipoTela.TipoMovimentacao_Aplicacao Then
                    SqlText = SqlText & " AND NVL(M.IC_APLICACAO, 'N') = 'S'"
                End If

                SqlText = SqlText & Montar_Filtro(oFiltro)

                SqlText = SqlText & _
                          " ORDER BY M.NO_TIPO_MOVIMENTACAO"

                objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridTipoMovimentacao_Codigo, _
                                                                   cnt_GridTipoMovimentacao_Descricao, _
                                                                   cnt_GridTipoMovimentacao_EntraRD, _
                                                                   cnt_GridTipoMovimentacao_TipoRD, _
                                                                   cnt_GridTipoMovimentacao_EntradaSaida, _
                                                                   cnt_GridTipoMovimentacao_Contabiliza, _
                                                                   cnt_GridTipoMovimentacao_NrContaContabil, _
                                                                   cnt_GridTipoMovimentacao_MudaContaContabil, _
                                                                   cnt_GridTipoMovimentacao_NrContaContabil_CP, _
                                                                   cnt_GridTipoMovimentacao_MudaContaContabil_CP, _
                                                                   cnt_GridTipoMovimentacao_SubLedger, _
                                                                   cnt_GridTipoMovimentacao_TipoSubLedger, _
                                                                   cnt_GridTipoMovimentacao_SubLedger_CP, _
                                                                   cnt_GridTipoMovimentacao_TipoSubLedger_CP, _
                                                                   cnt_GridTipoMovimentacao_Valida_KG, _
                                                                   cnt_GridTipoMovimentacao_ValidaQualidade, _
                                                                   cnt_GridTipoMovimentacao_ValidaValor, _
                                                                   cnt_GridTipoMovimentacao_Importacao, _
                                                                   cnt_GridTipoMovimentacao_Fiscal, _
                                                                   cnt_GridTipoMovimentacao_RDAtivo, _
                                                                   cnt_GridTipoMovimentacao_PostoFixo, _
                                                                   cnt_GridTipoMovimentacao_LocalEntrega})
            Case PesqLista_TipoTela.Fretista
                SqlText = "SELECT F.NO_FRETISTA," & _
                                 "TF.NO_TIPO_FRETISTA," & _
                                 "DECODE(F.IC_FISICA_JURIDICA, 'J', 'Jurídica', 'Física') IC_FISICA_JURIDICA," & _
                                 "F.NU_CGC_CPF," & _
                                 "F.NU_INSCRICAO_INSS," & _
                                 "F.NU_PIS_PASEP," & _
                                 "F.CD_ADDRESS_NUMBER," & _
                                 "F.NO_FAVORECIDO," & _
                                 "F.QT_DEPENDETES," & _
                                 "F.CD_FRETISTA" & _
                          " FROM SOF.FRETISTA F," & _
                                "SOF.TIPO_FRETISTA TF " & _
                          " WHERE F.CD_TIPO_FRETISTA = TF.CD_TIPO_FRETISTA" & _
                          " ORDER BY F.NO_FRETISTA"

                SqlText = SqlText & Montar_Filtro(oFiltro)

                objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridTipoFretista_Nome, cnt_GridTipoFretista_TipoFretista, _
                                                                    cnt_GridTipoFretista_Pessoa, cnt_GridTipoFretista_CNPJ_CPF, _
                                                                    cnt_GridTipoFretista_Inscricao_INSS, cnt_GridTipoFretista_PIS_PASEP, _
                                                                    cnt_GridTipoFretista_AddressNumber, cnt_GridTipoFretista_Favorecido, _
                                                                    cnt_GridTipoFretista_Qt_Dependentes, cnt_GridTipoFretista_Codigo})
        End Select
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

            Select Case oTipoTela
                Case PesqLista_TipoTela.TipoMovimentacao
                    .Codigo = objGrid_Valor(grdGeral, cnt_GridTipoMovimentacao_Codigo)
                Case PesqLista_TipoTela.Fretista
                    .Codigo = objGrid_Valor(grdGeral, cnt_GridTipoFretista_Codigo)
            End Select

            .TelaFiltro = False
        End With

        Close()
    End Sub

    Private Sub grdGeral_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles grdGeral.DoubleClickRow
        RegistroSelecionado()
    End Sub

    Private Sub cmdAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAtualizar.Click
        Pesquisar()
    End Sub
End Class