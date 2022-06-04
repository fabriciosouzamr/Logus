Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmPesq_Fornecedor
    Const cnt_GridGeral_RazaoSocial As Integer = 0
    Const cnt_GridGeral_TipoPessoa As Integer = 1
    Const cnt_GridGeral_NomeFantasia As Integer = 2
    Const cnt_GridGeral_Repassador As Integer = 3
    Const cnt_GridGeral_Endereco As Integer = 4
    Const cnt_GridGeral_Bairro As Integer = 5
    Const cnt_GridGeral_Cidade As Integer = 6
    Const cnt_GridGeral_CEP As Integer = 7
    Const cnt_GridGeral_Contato As Integer = 8
    Const cnt_GridGeral_Telefone As Integer = 9
    Const cnt_GridGeral_Fax As Integer = 10
    Const cnt_GridGeral_Celular As Integer = 11
    Const cnt_GridGeral_Pessoa As Integer = 12
    Const cnt_GridGeral_ListaNegra As Integer = 13
    Const cnt_GridGeral_SacariaAcordo As Integer = 14
    Const cnt_GridGeral_CNPJ_CPF As Integer = 15
    Const cnt_GridGeral_InscricaoEstadual As Integer = 16
    Const cnt_GridGeral_Funrural As Integer = 17
    Const cnt_GridGeral_Favorecido As Integer = 18
    Const cnt_GridGeral_ContaCorrente As Integer = 19
    Const cnt_GridGeral_Agencia As Integer = 20
    Const cnt_GridGeral_Banco As Integer = 21
    Const cnt_GridGeral_FilialOrigem As Integer = 22
    Const cnt_GridGeral_Codigo As Integer = 23
    Const cnt_GridGeral_AddressNumber As Integer = 24
    Const cnt_GridGeral_Profissao As Integer = 25
    Const cnt_GridGeral_Conjuge As Integer = 26
    Const cnt_GridGeral_Email As Integer = 27
    Const cnt_GridGeral_DataNascimento As Integer = 28
    Const cnt_GridGeral_CaixaPostal As Integer = 29
    Const cnt_GridGeral_EstabelecidoDesde As Integer = 30
    Const cnt_GridGeral_OutrasAtividades As Integer = 31
    Const cnt_GridGeral_NivelLiquidez As Integer = 32
    Const cnt_GridGeral_TipoPessoaTributacao As Integer = 33
    Const cnt_GridGeral_Ativo As Integer = 34

    Dim oPesq_CodigoNome As Pesq_CodigoNome
    Dim oDS As New UltraWinDataSource.UltraDataSource
    Dim oFiltro As Collection

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

    Private Sub frmPesq_Fornecedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SelecaoFilial.BancoDados_Tabela = SQL_Filial_FilialLiberaUsuario()
        SelecaoFilial.BancoDados_Campo_Codigo = "CD_FILIAL"
        SelecaoFilial.BancoDados_Campo_Descricao = "NO_FILIAL"
        SelecaoFilial.BancoDados_Carregar()

        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.CellSelect, False, False, True)

        objGrid_Coluna_Add(grdGeral, "Razao Social", 180)
        objGrid_Coluna_Add(grdGeral, "Tipo Pessoa", 120)
        objGrid_Coluna_Add(grdGeral, "Nome Fantasia", 150)
        objGrid_Coluna_Add(grdGeral, "Repassador", 180)
        objGrid_Coluna_Add(grdGeral, "Endereço", 180)
        objGrid_Coluna_Add(grdGeral, "Bairro", 100)
        objGrid_Coluna_Add(grdGeral, "Cidade", 100)
        objGrid_Coluna_Add(grdGeral, "CEP", 80)
        objGrid_Coluna_Add(grdGeral, "Contato", 150)
        objGrid_Coluna_Add(grdGeral, "Telefone", 100)
        objGrid_Coluna_Add(grdGeral, "Fax", 100)
        objGrid_Coluna_Add(grdGeral, "Celular", 100)
        objGrid_Coluna_Add(grdGeral, "Pessoa", 100)
        objGrid_Coluna_Add(grdGeral, "Lista Negra", 100)
        objGrid_Coluna_Add(grdGeral, "Sacaria Acordo", 100)
        objGrid_Coluna_Add(grdGeral, "CNPJ\CPF", 100)
        objGrid_Coluna_Add(grdGeral, "Inscrição Estadual", 100)
        objGrid_Coluna_Add(grdGeral, "Funrural", 100)
        objGrid_Coluna_Add(grdGeral, "Favorecido", 150)
        objGrid_Coluna_Add(grdGeral, "Conta Corrente", 100)
        objGrid_Coluna_Add(grdGeral, "Agência", 100)
        objGrid_Coluna_Add(grdGeral, "Banco", 100)
        objGrid_Coluna_Add(grdGeral, "Filial Origem", 100)
        objGrid_Coluna_Add(grdGeral, "Código", 80)
        objGrid_Coluna_Add(grdGeral, "Address Number", 100)
        objGrid_Coluna_Add(grdGeral, "Profissão", 100)
        objGrid_Coluna_Add(grdGeral, "Cônjuge", 140)
        objGrid_Coluna_Add(grdGeral, "E-mail", 120)
        objGrid_Coluna_Add(grdGeral, "Data Nascimento", 100)
        objGrid_Coluna_Add(grdGeral, "Caixa Postal", 100)
        objGrid_Coluna_Add(grdGeral, "Estabelecido Desde", 100)
        objGrid_Coluna_Add(grdGeral, "Outras Atividades", 120)
        objGrid_Coluna_Add(grdGeral, "Nível Liquidez", 100)
        objGrid_Coluna_Add(grdGeral, "Tipo Pessoa Tributacao", 100)
        objGrid_Coluna_Add(grdGeral, "Ativo", 80)
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String
        Dim sCPNJ_CPF As String = ""

        If Trim(txtNomeFornecedor.Text) = "" And _
           Trim(txtCPF_CNPJ.Text) = "" And _
           Trim(txtMunicipio.Text) = "" Then
            Msg_Mensagem("Informe alguma informação de filtro para essa consulta")
            Exit Sub
        End If
        If Trim(txtCPF_CNPJ.Text) <> "" Then
            If Not Valida_CPF(SoNumero(txtCPF_CNPJ.Text)) And _
               Not Valida_CNPJ(SoNumero(txtCPF_CNPJ.Text)) Then
                Msg_Mensagem("C.P.F./C.N.P.J. informado é inválido")
                Exit Sub
            End If
        End If

        SqlText = "SELECT F.NO_RAZAO_SOCIAL," & _
                         "TP.NO_TIPO_PESSOA," & _
                         "F.NO_FANTASIA," & _
                         "REP.NO_RAZAO_SOCIAL NO_REPASSADOR," & _
                         "F.DS_ENDERECO," & _
                         "F.NO_BAIRRO," & _
                         "TRIM(M.NO_CIDADE) || ' - ' || M.CD_UF AS CIDADE," & _
                         "F.NU_CEP," & _
                         "F.NO_CONTATO," & _
                         "F.NU_TEL," & _
                         "F.NU_FAX," & _
                         "F.NU_CELULAR," & _
                         "DECODE(F.IC_FISICA_JURIDICA, 'F', 'Física', 'J', 'Jurídica') IC_FISICA_JURIDICA," & _
                         "DECODE(F.IC_LISTA_NEGRA, 'S', 'Sim', 'Não') IC_LISTA_NEGRA," & _
                         "DECODE(F.IC_SACARIA_ACORDADA, 'S', 'Sim', 'Não') IC_SACARIA_ACORDADA," & _
                         "F.NU_CGC_CPF," & _
                         "F.NU_INSC_ESTADUAL," & _
                         "FUN.NO_FUNRURAL," & _
                         "F.NO_FAVORECIDO_CHEQUE," & _
                         "F.NU_CONTA_CORRENTE," & _
                         "F.NU_AGENCIA," & _
                         "F.NO_BANCO," & _
                         "FIL.NO_FILIAL," & _
                         "F.CD_FORNECEDOR," & _
                         "F.CD_ADDRESS_NUMBER," & _
                         "F.NO_PROFISSAO," & _
                         "F.NO_CONJUGE," & _
                         "F.DS_EMAIL," & _
                         "F.DT_NASCIMENTO," & _
                         "F.NU_CAIXA_POSTAL," & _
                         "F.QT_TEMPO_ESTABELECIDO," & _
                         "F.DS_OUTRA_ATIVIDADE," & _
                         "F.DS_NIVEL_LIQUIDEZ," & _
                         "TPT.NO_TIPO_PESSOA_TRIBUTACAO," & _
                         "DECODE(F.IC_ATIVO, 'S', 'Sim', 'N', 'Não') IC_SACARIA_ACORDADA" & _
                  " FROM SOF.FORNECEDOR F," & _
                        "SOF.TIPO_PESSOA TP," & _
                        "SOF.MUNICIPIO M," & _
                        "SOF.UF U," & _
                        "SOF.FUNRURAL FUN," & _
                        "SOF.FILIAL FIL," & _
                        "SOF.FORNECEDOR REP," & _
                        "SOF.TIPO_PESSOA_TRIBUTACAO TPT" & _
                  " WHERE F.CD_TIPO_PESSOA = TP.CD_TIPO_PESSOA" & _
                    " AND F.CD_MUNICIPIO = M.CD_MUNICIPIO" & _
                    " AND U.CD_UF = M.CD_UF" & _
                    " AND F.CD_REPASSADOR = REP.CD_FORNECEDOR(+)" & _
                    " AND F.CD_FUNRURAL = FUN.CD_FUNRURAL" & _
                    " AND F.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                    " AND F.CD_TIPO_PESSOA_TRIBUTACAO = TPT.CD_TIPO_PESSOA_TRIBUTACAO (+) "

        If Trim(txtNomeFornecedor.Text) <> "" Then
            SqlText = SqlText & " AND UPPER(F.NO_RAZAO_SOCIAL) LIKE " & SQL_FormatarLike(txtNomeFornecedor.Text)
        End If
        If Trim(txtCPF_CNPJ.Text) <> "" Then
            If Len(SoNumero(txtCPF_CNPJ.Text)) = 11 Then
                sCPNJ_CPF = Formatar(SoNumero(txtCPF_CNPJ.Text), "@@@.@@@.@@@-@@")
            ElseIf Len(SoNumero(txtCPF_CNPJ.Text)) = 14 Then
                sCPNJ_CPF = Formatar(SoNumero(txtCPF_CNPJ.Text), "@@.@@@.@@@/@@@@-@@")
            End If

            SqlText = SqlText & " AND F.NU_CGC_CPF IN (" & QuotedStr(sCPNJ_CPF) & ", " & QuotedStr(SoNumero(txtCPF_CNPJ.Text)) & ")"
        End If
        If Trim(txtMunicipio.Text) <> "" Then
            SqlText = SqlText & " AND M.NO_CIDADE LIKE " & SQL_FormatarLike(txtMunicipio.Text)
        End If
        If SelecaoFilial.Lista_Quantidade > 0 Then
            SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & SelecaoFilial.Lista_ID & ")"
        Else
            SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If

        If Not oFiltro Is Nothing Then
            If oFiltro.Count > 0 Then
                SqlText = SqlText & Montar_Filtro(oFiltro)
            End If
        End If

        SqlText = SqlText & " ORDER BY F.NO_RAZAO_SOCIAL"

        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_RazaoSocial, _
                                                           cnt_GridGeral_TipoPessoa, _
                                                           cnt_GridGeral_NomeFantasia, _
                                                           cnt_GridGeral_Repassador, _
                                                           cnt_GridGeral_Endereco, _
                                                           cnt_GridGeral_Bairro, _
                                                           cnt_GridGeral_Cidade, _
                                                           cnt_GridGeral_CEP, _
                                                           cnt_GridGeral_Contato, _
                                                           cnt_GridGeral_Telefone, _
                                                           cnt_GridGeral_Fax, _
                                                           cnt_GridGeral_Celular, _
                                                           cnt_GridGeral_Pessoa, _
                                                           cnt_GridGeral_ListaNegra, _
                                                           cnt_GridGeral_SacariaAcordo, _
                                                           cnt_GridGeral_CNPJ_CPF, _
                                                           cnt_GridGeral_InscricaoEstadual, _
                                                           cnt_GridGeral_Funrural, _
                                                           cnt_GridGeral_Favorecido, _
                                                           cnt_GridGeral_ContaCorrente, _
                                                           cnt_GridGeral_Agencia, _
                                                           cnt_GridGeral_Banco, _
                                                           cnt_GridGeral_FilialOrigem, _
                                                           cnt_GridGeral_Codigo, _
                                                           cnt_GridGeral_AddressNumber, _
                                                           cnt_GridGeral_Profissao, _
                                                           cnt_GridGeral_Conjuge, _
                                                           cnt_GridGeral_Email, _
                                                           cnt_GridGeral_DataNascimento, _
                                                           cnt_GridGeral_CaixaPostal, _
                                                           cnt_GridGeral_EstabelecidoDesde, _
                                                           cnt_GridGeral_OutrasAtividades, _
                                                           cnt_GridGeral_NivelLiquidez, _
                                                           cnt_GridGeral_TipoPessoaTributacao, _
                                                           cnt_GridGeral_Ativo})

        Fornecedor_GridIdentificar(grdGeral, cnt_GridGeral_Ativo, cnt_GridGeral_ListaNegra)
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
            .Codigo = objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)
            .TelaFiltro = False
        End With

        Close()
    End Sub

    Private Sub grdGeral_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles grdGeral.DoubleClickRow
        RegistroSelecionado()
    End Sub
End Class