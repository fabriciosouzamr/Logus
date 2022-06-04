Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmCadastroFornecedor
    Const cnt_GridProcuracao_SQ_PROCURACAO As Integer = 0
    Const cnt_GridProcuracao_IC_CONTROLE As Integer = 1
    Const cnt_GridProcuracao_CD_PROCURADOR As Integer = 2
    Const cnt_GridProcuracao_NO_PROCURADOR As Integer = 3
    Const cnt_GridProcuracao_DT_VALIDADE As Integer = 4
    Const cnt_GridProcuracao_IC_VALIDADO As Integer = 5

    Const cnt_GridControlador_SQ_FORN_CONTROLADOR As Integer = 0
    Const cnt_GridControlador_IC_CONTROLE As Integer = 1
    Const cnt_GridControlador_NO_CONTROLADOR As Integer = 2
    Const cnt_GridControlador_NU_CGC_CPF AS INTEGER = 3
    Const cnt_GridControlador_NU_IDENTIDADE As Integer = 4
    Const cnt_GridControlador_IC_VALIDADO As Integer = 5

    Const cnt_GridColigada_SQ_FORN_COLIGADAS As Integer = 0
    Const cnt_GridColigada_IC_CONTROLE As Integer = 1
    Const cnt_GridColigada_NomeEmpresa As Integer = 2
    Const cnt_GridColigada_RamoAtividade As Integer = 3
    Const cnt_GridColigada_CPF_CGC As Integer = 4
    Const cnt_GridColigada_IC_VALIDADO As Integer = 5

    Const cnt_GridReferenciaBancaria_SQ_FORN_REF_BANCO As Integer = 0
    Const cnt_GridReferenciaBancaria_IC_CONTROLE As Integer = 1
    Const cnt_GridReferenciaBancaria_NrBanco As Integer = 2
    Const cnt_GridReferenciaBancaria_NomeBanco As Integer = 3
    Const cnt_GridReferenciaBancaria_NrAgencia As Integer = 4
    Const cnt_GridReferenciaBancaria_NrContaCorrente As Integer = 5
    Const cnt_GridReferenciaBancaria_NomeGerente As Integer = 6
    Const cnt_GridReferenciaBancaria_NrTelefone As Integer = 7
    Const cnt_GridReferenciaBancaria_IC_VALIDADO As Integer = 8

    Const cnt_GridFazenda_SQ_FAZENDA As Integer = 0
    Const cnt_GridFazenda_CD_MUNICIPIO As Integer = 1
    Const cnt_GridFazenda_IC_CONTROLE As Integer = 2
    Const cnt_GridFazenda_NomeFazenda As Integer = 3
    Const cnt_GridFazenda_AreaCacau As Integer = 4
    Const cnt_GridFazenda_AreaClonada As Integer = 5
    Const cnt_GridFazenda_ProducaoCacau As Integer = 6
    Const cnt_GridFazenda_Municipio As Integer = 7
    Const cnt_GridFazenda_Endereco As Integer = 8
    Const cnt_GridFazenda_CEP As Integer = 9
    Const cnt_GridFazenda_DiversidadesCulturais As Integer = 10
    Const cnt_GridFazenda_IC_VALIDADO As Integer = 11

    Const cnt_GridBem_SQ_BENS As Integer = 0
    Const cnt_GridBem_CD_BENS_TIPO As Integer = 1
    Const cnt_GridBem_CD_MUNICIPIO As Integer = 2
    Const cnt_GridBem_IC_CONTROLE As Integer = 3
    Const cnt_GridBem_TipoBem As Integer = 4
    Const cnt_GridBem_IdentificacaoBem As Integer = 5
    Const cnt_GridBem_DescricaoBem As Integer = 6
    Const cnt_GridBem_ValorBem As Integer = 7
    Const cnt_GridBem_Endereco As Integer = 8
    Const cnt_GridBem_Municipio As Integer = 9
    Const cnt_GridBem_AreaTotal As Integer = 10
    Const cnt_GridBem_AreaCultivada As Integer = 11
    Const cnt_GridBem_Producao As Integer = 12
    Const cnt_GridBem_IC_VALIDADO As Integer = 13

    Const cnt_GridSocio_SQ_FORNECEDOR_PESSOA As Integer = 0
    Const cnt_GridSocio_CD_TIPO_FORNECEDOR_PESSOA As Integer = 1
    Const cnt_GridSocio_CD_MUNICIPIO As Integer = 2
    Const cnt_GridSocio_IC_CONTROLE As Integer = 3
    Const cnt_GridSocio_TipoPessoa As Integer = 4
    Const cnt_GridSocio_NomeSocio As Integer = 5
    Const cnt_GridSocio_Municipio As Integer = 6
    Const cnt_GridSocio_Endereco As Integer = 7
    Const cnt_GridSocio_EMail As Integer = 8
    Const cnt_GridSocio_Telefone As Integer = 9
    Const cnt_GridSocio_CPF As Integer = 10
    Const cnt_GridSocio_IC_VALIDADO As Integer = 11

    Dim oDS_Procuracao As New UltraWinDataSource.UltraDataSource
    Dim oDS_Controlador As New UltraWinDataSource.UltraDataSource
    Dim oDS_Coligada As New UltraWinDataSource.UltraDataSource
    Dim oDS_ReferenciaBancaria As New UltraWinDataSource.UltraDataSource
    Dim oDS_Fazenda As New UltraWinDataSource.UltraDataSource
    Dim oDS_Bem As New UltraWinDataSource.UltraDataSource
    Dim oDS_Socio As New UltraWinDataSource.UltraDataSource

    Public CD_FORNECEDOR As Long
    Dim CPF_CNPJ_Seq As Long

    Private Sub optTipoPessoa_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTipoPessoa.ValueChanged
        TipoPessoa_Validar()
    End Sub

    Private Sub TipoPessoa_Validar()
        grpFisica.Visible = (optTipoPessoa.Value = "F")
        grpJuridica.Visible = (optTipoPessoa.Value = "J")

        MaskEditor(txtCPF_CNPJ, IIf(optTipoPessoa.Value = "F", cnt_Formato_CPF, cnt_Formato_CNPJ))

        If tabGeral.Tabs.Count > 0 Then
            tabGeral.Tabs(tabControlColig.Tab.Index).Visible = grpJuridica.Visible
            tabGeral.Tabs(tabSocio.Tab.Index).Visible = grpJuridica.Visible
        End If
    End Sub

    Private Sub frmCadastroFornecedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlText As String

        grpJuridica.Top = grpFisica.Top
        grpJuridica.Left = grpFisica.Left
        grpJuridica.Visible = False

        cboBem_Descricao.Left = txtBem_Descricao.Left
        cboBem_Descricao.Top = txtBem_Descricao.Top

        ComboBox_Carregar_Filial(cboFilial, True)
        ComboBox_Carregar_Estado_Civil(cboEstadoCivil, True)
        ComboBox_Carregar_Funrural(cboFunrural, True)
        ComboBox_Carregar_Tipo_Capital(cboTipoCapital, True)
        ComboBox_Carregar_Tipo_Pessoa_Tributacao(cboTipoPessoaTributacao, True)
        ComboBox_Carregar_Tipo_Pessoa(cboTipoPessoa, True)
        ComboBox_Carregar_Tipo_Bem(cboBem_Tipo, True)
        ComboBox_Carregar_Tipo_Fornecedor_Pessoa(cboSocio_TipoPessoa)

        Pesq_Repassador.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        Pesq_Procurador.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        txtNacionalidade.Text = DBQuery_ValorUnico("SELECT DS_NACIONALIDADE_PADRAO FROM SOF.PARAMETRO", "")

        SqlText = "(SELECT CD_MUNICIPIO," & _
                           "TRIM(MC.NO_CIDADE) || ' - ' || TRIM(UF.NO_UF) NO_CIDADE" & _
                   " FROM SOF.MUNICIPIO MC," & _
                         "SOF.UF UF" & _
                   " WHERE UF.CD_UF = MC.CD_UF)"

        With Pesq_Municipio_EndPrincipal
            .Codigo = 0
            .Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Municipio
        End With
        With Pesq_Municipio_EndSecundario
            .Codigo = 0
            .Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Municipio
        End With
        With Pesq_Municipio_Fazenda
            .Codigo = 0
            .Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Municipio
        End With
        With Pesq_Municipio_Bem
            .Codigo = 0
            .Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Municipio
        End With
        With Pesq_Municipio_Socio
            .Codigo = 0
            .Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Municipio
        End With

        objGrid_Inicializar(grdProcuracao, , oDS_Procuracao, CellClickAction.RowSelect)
        objGrid_Coluna_Add(grdProcuracao, "SQ_PROCURACAO", 0)
        objGrid_Coluna_Add(grdProcuracao, "IC_CONTROLE", 0)
        objGrid_Coluna_Add(grdProcuracao, "CD_PROCURADOR", 0)
        objGrid_Coluna_Add(grdProcuracao, "Nome do Procurador", 400)
        objGrid_Coluna_Add(grdProcuracao, "Validade da Procuração", 170, , True, , , cnt_Formato_Data, , True)
        objGrid_Coluna_Add(grdProcuracao, "IC_VALIDADO", 0)

        objGrid_Inicializar(grdControlador, AllowAddNew.FixedAddRowOnTop, oDS_Controlador, CellClickAction.EditAndSelectText)
        objGrid_Coluna_Add(grdControlador, "SQ_FORN_CONTROLADOR", 0)
        objGrid_Coluna_Add(grdControlador, "IC_CONTROLE", 0)
        objGrid_Coluna_Add(grdControlador, "Nome do Controlador/Acionista", 300)
        objGrid_Coluna_Add(grdControlador, "C.P.F./C.N.P.J.", 200)
        objGrid_Coluna_Add(grdControlador, "Número do R.G.", 130)
        objGrid_Coluna_Add(grdControlador, "IC_VALIDADO", 0)

        objGrid_Inicializar(grdColigada, AllowAddNew.FixedAddRowOnTop, oDS_Coligada, CellClickAction.EditAndSelectText)
        objGrid_Coluna_Add(grdColigada, "SQ_FORN_COLIGADAS", 0)
        objGrid_Coluna_Add(grdColigada, "IC_CONTROLE", 0)
        objGrid_Coluna_Add(grdColigada, "Nome da Empresa", 300)
        objGrid_Coluna_Add(grdColigada, "Ramo de Atividade", 200, , True)
        objGrid_Coluna_Add(grdColigada, "C.N.P.J.", 150, , True)
        objGrid_Coluna_Add(grdColigada, "IC_VALIDADO", 0)

        objGrid_Inicializar(grdReferenciaBancaria, AllowAddNew.FixedAddRowOnTop, oDS_ReferenciaBancaria, CellClickAction.EditAndSelectText)
        objGrid_Coluna_Add(grdReferenciaBancaria, "SQ_FORN_REF_BANCO", 0)
        objGrid_Coluna_Add(grdReferenciaBancaria, "IC_CONTROLE", 0)
        objGrid_Coluna_Add(grdReferenciaBancaria, "Nº do Banco", 100)
        objGrid_Coluna_Add(grdReferenciaBancaria, "Nome do Banco", 300)
        objGrid_Coluna_Add(grdReferenciaBancaria, "Nº da Agência", 120)
        objGrid_Coluna_Add(grdReferenciaBancaria, "Nº da Conta Corrente", 150)
        objGrid_Coluna_Add(grdReferenciaBancaria, "Nome do Gerente", 200)
        objGrid_Coluna_Add(grdReferenciaBancaria, "Nº do Telefone", 120)
        objGrid_Coluna_Add(grdReferenciaBancaria, "IC_VALIDADO", 0)

        objGrid_Inicializar(grdFazenda, , oDS_Fazenda, CellClickAction.EditAndSelectText)
        objGrid_Coluna_Add(grdFazenda, "SQ_FAZENDA", 0)
        objGrid_Coluna_Add(grdFazenda, "CD_MUNICIPIO", 0)
        objGrid_Coluna_Add(grdFazenda, "IC_CONTROLE", 0)
        objGrid_Coluna_Add(grdFazenda, "Nome da Fazenda", 250)
        objGrid_Coluna_Add(grdFazenda, "Área de Cacau", 120)
        objGrid_Coluna_Add(grdFazenda, "Área Clonada", 120)
        objGrid_Coluna_Add(grdFazenda, "Produção de Cacau", 150)
        objGrid_Coluna_Add(grdFazenda, "Município", 100)
        objGrid_Coluna_Add(grdFazenda, "Endereço", 150)
        objGrid_Coluna_Add(grdFazenda, "C.E.P.", 60)
        objGrid_Coluna_Add(grdFazenda, "Diversidades Culturais", 300)
        objGrid_Coluna_Add(grdFazenda, "IC_VALIDADO", 0)

        objGrid_Inicializar(grdBem, , oDS_Bem, CellClickAction.EditAndSelectText)
        objGrid_Coluna_Add(grdBem, "SQ_BENS", 0)
        objGrid_Coluna_Add(grdBem, "CD_BENS_TIPO", 0)
        objGrid_Coluna_Add(grdBem, "SQ_MUNICIPIO", 0)
        objGrid_Coluna_Add(grdBem, "IC_CONTROLE", 0)
        objGrid_Coluna_Add(grdBem, "Tipo do Bem", 100)
        objGrid_Coluna_Add(grdBem, "Identificação do Bem", 200)
        objGrid_Coluna_Add(grdBem, "Descrição do Bem", 200)
        objGrid_Coluna_Add(grdBem, "Valor do Bem", 150, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdBem, "Endereço", 250)
        objGrid_Coluna_Add(grdBem, "Município", 200)
        objGrid_Coluna_Add(grdBem, "Área Total", 100)
        objGrid_Coluna_Add(grdBem, "Área Cultivada", 100)
        objGrid_Coluna_Add(grdBem, "Produção", 100)
        objGrid_Coluna_Add(grdBem, "IC_VALIDADO", 0)

        objGrid_Inicializar(grdSocio, , oDS_Socio, CellClickAction.EditAndSelectText)
        objGrid_Coluna_Add(grdSocio, "SQ_FORNECEDOR_PESSOA", 0)
        objGrid_Coluna_Add(grdSocio, "CD_TIPO_FORNECEDOR_PESSOA", 0)
        objGrid_Coluna_Add(grdSocio, "CD_MUNICIPIO", 0)
        objGrid_Coluna_Add(grdSocio, "IC_CONTROLE", 0)
        objGrid_Coluna_Add(grdSocio, "Tipo de Pessoa", 150)
        objGrid_Coluna_Add(grdSocio, "Nome do Sócio", 200)
        objGrid_Coluna_Add(grdSocio, "Município", 120)
        objGrid_Coluna_Add(grdSocio, "Endereço", 200)
        objGrid_Coluna_Add(grdSocio, "E-Mail", 200)
        objGrid_Coluna_Add(grdSocio, "Telefone", 100)
        objGrid_Coluna_Add(grdSocio, "C.P.F.", 100)
        objGrid_Coluna_Add(grdSocio, "IC_VALIDADO", 0)

        PrepararTelaDadosBem()

        If CD_FORNECEDOR > 0 Then
            CarregaDados(CD_FORNECEDOR)
            Historico_Fornecedor(Tipo_Historico_Fornecedor.HFConsulta, CD_FORNECEDOR, txtRazaoSocial.Text)
        End If

        TipoPessoa_Validar()
        chkListaNegra.Visible = SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_IncluirEliminarFornecedorListaNegra)
    End Sub

    Private Sub CarregaDados(ByVal CdFornecedor As Integer)
        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "SELECT * " & _
                  " FROM SOF.FORNECEDOR F," & _
                        "SOF.FORNECEDOR_OBS O" & _
                  " WHERE F.CD_FORNECEDOR = " & CdFornecedor & _
                    " AND O.CD_FORNECEDOR (+) = F.CD_FORNECEDOR"
        oData = DBQuery(SqlText)

        If oData.Rows.Count = 0 Then
            Msg_Mensagem("Algum usuário do sistema eliminou o cadastro referente a esse fornecedor")
            Close()
        End If

        '>> Cabeçalho
        ComboBox_Possicionar(cboFilial, oData.Rows(0).Item("CD_FILIAL_ORIGEM"))
        txtRazaoSocial.Text = oData.Rows(0).Item("NO_RAZAO_SOCIAL")
        txtNomeFantasia.Text = objDataTable_LerCampo(oData.Rows(0).Item("NO_FANTASIA"), "")
        txtAddressNumber.Value = oData.Rows(0).Item("CD_ADDRESS_NUMBER")

        '>> Dados
        optTipoPessoa.Value = oData.Rows(0).Item("IC_FISICA_JURIDICA")
        TipoPessoa_Validar()
        txtCPF_CNPJ.Value = oData.Rows(0).Item("NU_CGC_CPF")
        txtCPF_CNPJ.Tag = oData.Rows(0).Item("NU_CGC_CPF")
        CPF_CNPJ_Seq = oData.Rows(0).Item("NU_CGC_CPF_SEQ")
        ComboBox_Possicionar(cboFunrural, oData.Rows(0).Item("CD_FUNRURAL"))

        If objDataTable_CampoVazio(oData.Rows(0).Item("CD_REPASSADOR")) Then
            chkRepassador.Checked = False
            chkRepassador_CheckedChanged(Nothing, Nothing)
        Else
            chkRepassador.Checked = True
            chkRepassador_CheckedChanged(Nothing, Nothing)
            Pesq_Repassador.Codigo = oData.Rows(0).Item("CD_REPASSADOR")
        End If

        txtEmail.Text = objDataTable_LerCampo(oData.Rows(0).Item("DS_EMAIL"), "")
        txtEstabelecidoDesde.Value = objDataTable_LerCampo(oData.Rows(0).Item("QT_TEMPO_ESTABELECIDO"), 0)
        ComboBox_Possicionar(cboTipoPessoaTributacao, oData.Rows(0).Item("CD_TIPO_PESSOA_TRIBUTACAO"))
        txtTelefone.Text = objDataTable_LerCampo(oData.Rows(0).Item("NU_TEL"), "")
        txtFax.Text = objDataTable_LerCampo(oData.Rows(0).Item("NU_FAX"), "")
        txtCelular.Text = objDataTable_LerCampo(oData.Rows(0).Item("NU_CELULAR"), "")
        txtContato.Text = objDataTable_LerCampo(oData.Rows(0).Item("NO_CONTATO"), "")
        txtCargoContato.Text = objDataTable_LerCampo(oData.Rows(0).Item("DS_CARGO_CONTATO"), "")
        txtEmailContato.Text = objDataTable_LerCampo(oData.Rows(0).Item("DS_EMAIL_CONTATO"), "")
        txtDataNascimentoContato.Text = objDataTable_LerCampo(oData.Rows(0).Item("DT_NASCIMENTO_CONTATO"), "")
        txtTelefoneContato.Text = objDataTable_LerCampo(oData.Rows(0).Item("NU_TELEFONE_CONTATO"), "")

        '>> Dados - Pessoa Física
        optTipoIdentidade.Value = objDataTable_LerCampo(oData.Rows(0).Item("IC_TIPO_RG"), "")
        txtNumeroIdentidade.Text = objDataTable_LerCampo(oData.Rows(0).Item("NU_RG"), "")
        txtLocalEmissaoIdentidade.Text = objDataTable_LerCampo(oData.Rows(0).Item("DS_ORGAO_EMISSOR_RG"), "")
        txtDataEmissaoIdentidade.Text = objDataTable_LerCampo(oData.Rows(0).Item("DT_EMISSAO_RG"), "")
        ComboBox_Possicionar(cboTipoPessoa, oData.Rows(0).Item("CD_TIPO_PESSOA"))
        txtDataNascimento.Text = objDataTable_LerCampo(oData.Rows(0).Item("DT_NASCIMENTO"), "")
        optSexo.Value = oData.Rows(0).Item("IC_SEXO")
        txtNaturalidade.Text = objDataTable_LerCampo(oData.Rows(0).Item("DS_NATURALIDADE"), "")
        txtNacionalidade.Text = objDataTable_LerCampo(oData.Rows(0).Item("DS_NACIONALIDADE"), "")
        txtProfissao.Text = objDataTable_LerCampo(oData.Rows(0).Item("NO_PROFISSAO"), "")
        ComboBox_Possicionar(cboEstadoCivil, objDataTable_LerCampo(oData.Rows(0).Item("CD_ESTADO_CIVIL"), 0))
        txtConjuge.Text = objDataTable_LerCampo(oData.Rows(0).Item("NO_CONJUGE"), "")
        txtDataNascimentoConjuge.Text = objDataTable_LerCampo(oData.Rows(0).Item("DT_NASCIMENTO_CONJUGE"), "")
        txtNomeMae.Text = objDataTable_LerCampo(oData.Rows(0).Item("NO_MAE"), "")
        txtNomePai.Text = objDataTable_LerCampo(oData.Rows(0).Item("NO_PAI"), "")
        txtDependentes.Value = objDataTable_LerCampo(oData.Rows(0).Item("QT_DEPENDENTES"), 0)

        '>> Dados - Pessoa Jurídica
        txtInscricaoEstadual.Text = "" & oData.Rows(0).Item("NU_INSC_ESTADUAL")
        txtInscricaoMunicipal.Text = "" & oData.Rows(0).Item("NU_INSCRICAO_MUNICIPAL")
        txtRegistroJunta.Text = "" & oData.Rows(0).Item("NU_REGISTRO_JUNTA_COMERCIAL")
        txtDataRegistroJunta.Text = objDataTable_LerCampo(oData.Rows(0).Item("DT_CONSTITUICAO_JUNTA"), "")
        ComboBox_Possicionar(cboTipoCapital, objDataTable_LerCampo(oData.Rows(0).Item("CD_TIPO_CAPITAL"), 0))
        txtCapitalNacional.Value = objDataTable_LerCampo(oData.Rows(0).Item("PC_CAPITAL_NACIONAL"), 0)
        txtCapitalEstrangeiro.Value = objDataTable_LerCampo(oData.Rows(0).Item("PC_CAPITAL_ESTRANGEIRO"), 0)
        txtPaisOrigemCapital.Text = objDataTable_LerCampo(oData.Rows(0).Item("DS_PAIS_CAPITAL"), "")
        txtFaturamentoAnual.Value = objDataTable_LerCampo(oData.Rows(0).Item("VL_FATURAMENTO_ANUAL"), )
        txtPatrimonioLiquido.Value = objDataTable_LerCampo(oData.Rows(0).Item("VL_PATRIMONIO_LIQUIDO"), 0)

        '>> Endereço - Principal
        txtEndereco1.Text = objDataTable_LerCampo(oData.Rows(0).Item("DS_ENDERECO"), "")
        txtComplemento1.Text = objDataTable_LerCampo(oData.Rows(0).Item("DS_ENDERECO_COMPLEMENTO"), "")
        txtBairro1.Text = objDataTable_LerCampo(oData.Rows(0).Item("NO_BAIRRO"), "")
        txtCEP1.Value = Formatar(SoNumero(objDataTable_LerCampo(oData.Rows(0).Item("NU_CEP"), "")), "@@@@@-@@@")
        Pesq_Municipio_EndPrincipal.Codigo = oData.Rows(0).Item("CD_MUNICIPIO")
        txtCaixaPostal1.Text = objDataTable_LerCampo(oData.Rows(0).Item("NU_CAIXA_POSTAL"), "")

        '>> Endereço - Secundário
        txtEndereco2.Text = objDataTable_LerCampo(oData.Rows(0).Item("DS_ENDERECO2"), "")
        txtComplemento2.Text = objDataTable_LerCampo(oData.Rows(0).Item("DS_ENDERECO_COMPLEMENTO2"), "")
        txtBairro2.Text = objDataTable_LerCampo(oData.Rows(0).Item("NO_BAIRRO2"), "")
        txtCEP2.Value = Formatar(SoNumero(objDataTable_LerCampo(oData.Rows(0).Item("NU_CEP2"), "")), "@@@@@-@@@")
        Pesq_Municipio_EndSecundario.Codigo = NVL(oData.Rows(0).Item("CD_MUNICIPIO2"), 0)
        txtCaixaPostal2.Text = objDataTable_LerCampo(oData.Rows(0).Item("NU_CAIXA_POSTAL2"), "")
        txtDescricaoEndereco2.Text = objDataTable_LerCampo(oData.Rows(0).Item("DS_DESCRICAO_ENDERECO2"), "")

        '>> Mais Informação
        chkAplicacaoAutamatica.Checked = IIf(oData.Rows(0).Item("IC_APLICA_AUTOMATICO") = "N", False, True)
        chkAtivo.Checked = IIf(oData.Rows(0).Item("IC_ATIVO") = "N", False, True)
        chkListaNegra.Checked = IIf(oData.Rows(0).Item("IC_LISTA_NEGRA") = "N", False, True)

        '>> Referências Bancárias
        txtReferencia_Favorecido.Text = objDataTable_LerCampo(oData.Rows(0).Item("NO_FAVORECIDO_CHEQUE"), "")
        txtReferencia_ContaCorrente.Text = objDataTable_LerCampo(oData.Rows(0).Item("NU_CONTA_CORRENTE"), "")
        txtReferencia_Agencia.Text = objDataTable_LerCampo(oData.Rows(0).Item("NU_AGENCIA"), "")
        txtReferencia_Banco.Text = objDataTable_LerCampo(oData.Rows(0).Item("NO_BANCO"), "")

        '>> Outras Infomações
        txtComercializacao.Text = objDataTable_LerCampo(oData.Rows(0).Item("DS_COMERCIALIZACAO"), "")
        txtOutraAtividade.Text = objDataTable_LerCampo(oData.Rows(0).Item("DS_OUTRA_ATIVIDADE"), "")
        txtNivelLiquidez.Text = objDataTable_LerCampo(oData.Rows(0).Item("DS_NIVEL_LIQUIDEZ"), "")
        txtObservacaoImpressaoFicha.Text = objDataTable_LerCampo(oData.Rows(0).Item("DS_OBS_FICHA"), "")

        '>> Observação
        txtObservacao.Text = Trim(objDataTable_LerCampo(oData.Rows(0).Item("DS_OBS"), ""))
        txtObservacao.Tag = 0

        '>> Grid - Procurações
        SqlText = "SELECT FP.SQ_PROCURACAO, 'N'," & _
                         "FP.CD_FORNECEDOR_PROCURADOR," & _
                         "FN.NO_RAZAO_SOCIAL," & _
                         "FP.DT_VALIDADE" & _
                  " FROM SOF.FORNECEDOR_PROCURACAO FP," & _
                        "SOF.FORNECEDOR FN" & _
                  " WHERE FP.CD_FORNECEDOR = " & CD_FORNECEDOR & _
                    " AND FN.CD_FORNECEDOR = FP.CD_FORNECEDOR_PROCURADOR" & _
                  " ORDER BY FN.NO_RAZAO_SOCIAL"
        objGrid_Carregar(grdProcuracao, SqlText, New Integer() {cnt_GridProcuracao_SQ_PROCURACAO, _
                                                                cnt_GridProcuracao_IC_CONTROLE, _
                                                                cnt_GridProcuracao_CD_PROCURADOR, _
                                                                cnt_GridProcuracao_NO_PROCURADOR, _
                                                                cnt_GridProcuracao_DT_VALIDADE})

        '>> Grid - Controlador
        SqlText = "SELECT FC.SQ_FORN_CONTROLADOR," & _
                         "'N', FC.NO_CONTROLADOR," & _
                         "FC.NU_CGC_CPF, FC.NU_RG" & _
                  " FROM SOF.FORNECEDOR_CONTROLADOR FC" & _
                  " WHERE FC.CD_FORNECEDOR = " & CD_FORNECEDOR
        objGrid_Carregar(grdControlador, SqlText, New Integer() {cnt_GridControlador_SQ_FORN_CONTROLADOR, _
                                                                 cnt_GridControlador_IC_CONTROLE, _
                                                                 cnt_GridControlador_NO_CONTROLADOR, _
                                                                 cnt_GridControlador_NU_CGC_CPF, _
                                                                 cnt_GridControlador_NU_IDENTIDADE})

        '>> Grid - Coligadas
        SqlText = "SELECT FC.SQ_FORN_COLIGADAS," & _
                         "'N', FC.NO_EMPRESA, FC.DS_RAMO_ATIVIDADE," & _
                         "FC.NU_CGC" & _
                  " FROM SOF.FORNECEDOR_COLIGADAS FC" & _
                  " WHERE FC.CD_FORNECEDOR = " & CD_FORNECEDOR
        objGrid_Carregar(grdColigada, SqlText, New Integer() {cnt_GridColigada_SQ_FORN_COLIGADAS, _
                                                              cnt_GridColigada_IC_CONTROLE, _
                                                              cnt_GridColigada_NomeEmpresa, _
                                                              cnt_GridColigada_RamoAtividade, _
                                                              cnt_GridColigada_CPF_CGC})

        '>> Grid - Referências Bancárias
        SqlText = "SELECT FR.SQ_FORN_REF_BANCO," & _
                         "'N', FR.NU_BANCO," & _
                         "FR.NO_BANCO," & _
                         "FR.CD_AGENCIA," & _
                         "FR.NU_CONTA_CORRENTE," & _
                         "FR.NO_GERENTE," & _
                         "FR.NU_TELEFONE" & _
                  " FROM SOF.FORNECEDOR_REFERENCIA_BANCO FR" & _
                  " WHERE FR.CD_FORNECEDOR = " & CD_FORNECEDOR
        objGrid_Carregar(grdReferenciaBancaria, SqlText, New Integer() {cnt_GridReferenciaBancaria_SQ_FORN_REF_BANCO, _
                                                                        cnt_GridReferenciaBancaria_IC_CONTROLE, _
                                                                        cnt_GridReferenciaBancaria_NrBanco, _
                                                                        cnt_GridReferenciaBancaria_NomeBanco, _
                                                                        cnt_GridReferenciaBancaria_NrAgencia, _
                                                                        cnt_GridReferenciaBancaria_NrContaCorrente, _
                                                                        cnt_GridReferenciaBancaria_NomeGerente, _
                                                                        cnt_GridReferenciaBancaria_NrTelefone})

        '>> Grid - Fazenda
        SqlText = "SELECT FZ.SQ_FAZENDA, FZ.CD_MUNICIPIO, 'N', FZ.NO_FAZENDA, FZ.QT_AREA_CACAU," & _
                         "FZ.QT_AREA_CLONADA, FZ.QT_PRODUCAO," & _
                         "Trim(MC.NO_CIDADE) ||  ' - ' || Trim(UF.NO_UF)," & _
                         "FZ.DS_ENDERECO, FZ.NU_CEP, FZ.DS_DIVERSIDADE_CULTURA" & _
                  " FROM SOF.FAZENDA FZ, SOF.MUNICIPIO MC, SOF.UF UF" & _
                  " WHERE FZ.CD_FORNECEDOR = " & CD_FORNECEDOR & _
                    " AND MC.CD_MUNICIPIO = FZ.CD_MUNICIPIO" & _
                    " AND UF.CD_UF = MC.CD_UF"
        objGrid_Carregar(grdFazenda, SqlText, New Integer() {cnt_GridFazenda_SQ_FAZENDA, _
                                                             cnt_GridFazenda_CD_MUNICIPIO, _
                                                             cnt_GridFazenda_IC_CONTROLE, _
                                                             cnt_GridFazenda_NomeFazenda, _
                                                             cnt_GridFazenda_AreaCacau, _
                                                             cnt_GridFazenda_AreaClonada, _
                                                             cnt_GridFazenda_ProducaoCacau, _
                                                             cnt_GridFazenda_Municipio, _
                                                             cnt_GridFazenda_Endereco, _
                                                             cnt_GridFazenda_CEP, _
                                                             cnt_GridFazenda_DiversidadesCulturais})

        '>> Grid - Bens
        SqlText = "SELECT BN.SQ_BENS, BN.CD_BENS_TIPO, BN.CD_MUNICIPIO_LOCALIZACAO, 'N', " & _
                         "BT.NO_BENS_TIPO, BN.DS_IDENTIFICACAO, BN.DS_BEM, BN.VL_BEM, BN.DS_ENDERECO," & _
                         "Trim(MC.NO_CIDADE) || ' - ' || Trim(UF.NO_UF), BN.QT_AREA_TOTAL," & _
                         "BN.QT_AREA_CULTIVADA, BN.QT_PRODUCAO" & _
                  " FROM SOF.FORNECEDOR_BENS FB," & _
                        "SOF.BENS BN," & _
                        "SOF.BENS_TIPO BT," & _
                        "SOF.MUNICIPIO MC," & _
                        "SOF.UF UF" & _
                  " WHERE FB.CD_FORNECEDOR = " & CD_FORNECEDOR & _
                    " AND BN.SQ_BENS = FB.SQ_BENS" & _
                    " AND BT.CD_BENS_TIPO = BN.CD_BENS_TIPO" & _
                    " AND MC.CD_MUNICIPIO (+) = BN.CD_MUNICIPIO_LOCALIZACAO" & _
                    " AND UF.CD_UF (+) = BN.CD_UF_LOCALIZACAO"
        objGrid_Carregar(grdBem, SqlText, New Integer() {cnt_GridBem_SQ_BENS, _
                                                         cnt_GridBem_CD_BENS_TIPO, _
                                                         cnt_GridBem_CD_MUNICIPIO, _
                                                         cnt_GridBem_IC_CONTROLE, _
                                                         cnt_GridBem_TipoBem, _
                                                         cnt_GridBem_IdentificacaoBem, _
                                                         cnt_GridBem_DescricaoBem, _
                                                         cnt_GridBem_ValorBem, _
                                                         cnt_GridBem_Endereco, _
                                                         cnt_GridBem_Municipio, _
                                                         cnt_GridBem_AreaTotal, _
                                                         cnt_GridBem_AreaCultivada, _
                                                         cnt_GridBem_Producao})

        '>> Grid - Sócio
        SqlText = "SELECT FP.SQ_FORNECEDOR_PESSOA, FP.CD_TIPO_FORNECEDOR_PESSOA," & _
                         "FP.CD_MUNICIPIO, 'N', TF.NO_TIPO_FORNECEDOR_PESSOA, FP.NO_FORNECEDOR_PESSOA," & _
                         "Trim(MC.NO_CIDADE) || ' - ' || Trim(UF.NO_UF), FP.DS_ENDERECO," & _
                         "FP.DS_EMAIL, FP.NU_TELEFONE, FP.NU_CGC_CPF" & _
                  " FROM SOF.FORNECEDOR_PESSOA FP," & _
                        "SOF.TIPO_FORNECEDOR_PESSOA TF," & _
                        "SOF.UF UF," & _
                        "SOF.MUNICIPIO MC" & _
                  " WHERE FP.CD_FORNECEDOR = " & CD_FORNECEDOR & _
                    " AND TF.CD_TIPO_FORNECEDOR_PESSOA = FP.CD_TIPO_FORNECEDOR_PESSOA" & _
                    " AND UF.CD_UF = FP.CD_UF" & _
                    " AND MC.CD_MUNICIPIO = FP.CD_MUNICIPIO"
        objGrid_Carregar(grdSocio, SqlText, New Integer() {cnt_GridSocio_SQ_FORNECEDOR_PESSOA, _
                                                           cnt_GridSocio_CD_TIPO_FORNECEDOR_PESSOA, _
                                                           cnt_GridSocio_CD_MUNICIPIO, _
                                                           cnt_GridSocio_IC_CONTROLE, _
                                                           cnt_GridSocio_TipoPessoa, _
                                                           cnt_GridSocio_NomeSocio, _
                                                           cnt_GridSocio_Municipio, _
                                                           cnt_GridSocio_Endereco, _
                                                           cnt_GridSocio_EMail, _
                                                           cnt_GridSocio_Telefone, _
                                                           cnt_GridSocio_CPF})

        If Not SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_PodeAlterarTodoCampoCadFornecedor) Then
            lblFilial.Enabled = False
            cboFilial.Enabled = False
            chkRepassador.Enabled = False
            chkAplicacaoAutamatica.Enabled = False
            fraRepassador.Enabled = False
            lblCPF_CNPJ.Enabled = False
            txtCPF_CNPJ.Enabled = False
            lblInscricaoEstadual.Enabled = False
            txtInscricaoEstadual.Enabled = False
            txtAddressNumber.Enabled = False
            lblAddressNumber.Enabled = False
        End If

        If InStr(ListarIDFiliaisLiberadaUsuario(), cboFilial.SelectedValue) = 0 Then
            Msg_Mensagem("Esse fornecedor é de uma filial que o seu usuário não tem acesso," & _
                         " por esse motivo você não poderá fazer atualizações das informações cadastrais do mesmo")
            cmdGravar.Enabled = False
        End If
    End Sub

    Private Sub chkRepassador_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRepassador.CheckedChanged
        If chkRepassador.Checked Then
            Pesq_Repassador.Enabled = True
        Else
            Pesq_Repassador.Codigo = 0
            Pesq_Repassador.Enabled = False
        End If
    End Sub

    Private Sub cmdProcuracao_Adicionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProcuracao_Adicionar.Click
        Dim iCont As Integer
        Dim bAchou As Boolean = False

        If Pesq_Procurador.Codigo < 1 Then
            Msg_Mensagem("Informe o procurador para dessa procuração")
            Exit Sub
        End If
        If Not IsDate(txtProcuracao_Validade.Value) Then
            Msg_Mensagem("Informe a validade dessa procuração")
            Exit Sub
        End If

        For iCont = 0 To grdProcuracao.Rows.Count - 1
            If objGrid_Valor(grdProcuracao, cnt_GridProcuracao_CD_PROCURADOR, iCont) = _
               Pesq_Procurador.Codigo And _
               CDate(objGrid_Valor(grdProcuracao, cnt_GridProcuracao_DT_VALIDADE, iCont)) = _
               CDate(txtProcuracao_Validade.Value) Then
                bAchou = True
                Exit For
            End If
        Next

        If bAchou Then
            If Not Msg_Perguntar("Já foi adicionada uma procuração com esses dados. Adiciona essa também?") Then Exit Sub
        End If

        oDS_Procuracao.Rows.Add()

        With oDS_Procuracao.Rows(oDS_Procuracao.Rows.Count - 1)
            .Item(cnt_GridProcuracao_IC_CONTROLE) = "S"
            .Item(cnt_GridProcuracao_CD_PROCURADOR) = Pesq_Procurador.Codigo
            .Item(cnt_GridProcuracao_NO_PROCURADOR) = Pesq_Procurador.Descricao
            .Item(cnt_GridProcuracao_DT_VALIDADE) = txtProcuracao_Validade.Value
        End With

        Procuracao_Limpar()
    End Sub

    Private Sub grdProcuracao_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdProcuracao.AfterCellUpdate
        e.Cell.Row.Cells(cnt_GridProcuracao_IC_CONTROLE).Value = "S"
    End Sub

    Private Sub cmdProcuracao_Novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProcuracao_Novo.Click
        Procuracao_Limpar()
    End Sub

    Private Sub Procuracao_Limpar()
        Pesq_Procurador.Codigo = 0
        txtProcuracao_Validade.Value = ""
    End Sub

    Private Sub grdProcuracao_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdProcuracao.BeforeRowsDeleted
        e.DisplayPromptMsg = False
        If Msg_Perguntar("Você deseja excluir essa procuração?") Then
            If NVL(e.Rows(0).Cells(cnt_GridProcuracao_SQ_PROCURACAO).Value, 0) > 0 Then
                Dim SqlText As String

                SqlText = "DELETE FROM SOF.FORNECEDOR_PROCURACAO" & _
                          " WHERE CD_FORNECEDOR = " & CD_FORNECEDOR & _
                            " AND SQ_PROCURACAO = " & e.Rows(0).Cells(cnt_GridProcuracao_SQ_PROCURACAO).Value
                If Not DBExecutar(SqlText) Then GoTo Erro
            End If
        Else
            e.Cancel = True
        End If

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub grdControlador_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdControlador.AfterCellUpdate
        grdControlador.ActiveCell.Row.Cells(cnt_GridControlador_IC_CONTROLE).Value = "S"
    End Sub

    Private Sub grdControlador_BeforeEnterEditMode(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grdControlador.BeforeEnterEditMode
        If Not grdControlador.ActiveCell.Row.IsAddRow Then
            Select Case grdControlador.ActiveCell.Column.Index
                Case cnt_GridControlador_NO_CONTROLADOR
                    e.Cancel = True
            End Select
        End If
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Fechar()
    End Sub

    Private Sub Fechar()
        Close()
    End Sub

    Private Sub grdControlador_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdControlador.BeforeRowsDeleted
        e.DisplayPromptMsg = False

        If Msg_Perguntar("Você deseja excluir esse Controlador/Acionista?") Then
            If NVL(e.Rows(0).Cells(cnt_GridControlador_SQ_FORN_CONTROLADOR).Value, 0) > 0 Then
                Dim SqlText As String

                SqlText = "DELETE FROM SOF.FORNECEDOR_CONTROLADOR" & _
                          " WHERE CD_FORNECEDOR = " & CD_FORNECEDOR & _
                            " AND SQ_FORN_CONTROLADOR = " & e.Rows(0).Cells(cnt_GridControlador_SQ_FORN_CONTROLADOR).Value
                If Not DBExecutar(SqlText) Then GoTo Erro
            End If
        Else
            e.Cancel = True
        End If

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub grdControlador_BeforeRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableRowEventArgs) Handles grdControlador.BeforeRowUpdate
        'If CampoNulo(e.Row.Cells(cnt_GridControlador_NO_CONTROLADOR).Value) Then
        '    Msg_Mensagem("Informe o nome do Controlador/Acionista")
        '    e.Cancel = True
        'ElseIf CampoNulo(e.Row.Cells(cnt_GridControlador_NU_CGC_CPF).Value) Then
        '    Msg_Mensagem("Informe o número do C.P.F./C.N.P.J. do Controlador/Acionista")
        '    e.Cancel = True
        'ElseIf CampoNulo(e.Row.Cells(cnt_GridControlador_NU_IDENTIDADE).Value) Then
        '    Msg_Mensagem("Informe o número do R.G. do Controlador/Acionista")
        '    e.Cancel = True
        'End If
    End Sub

    Private Sub grdColigada_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdColigada.AfterCellUpdate
        grdColigada.ActiveCell.Row.Cells(cnt_GridColigada_IC_CONTROLE).Value = "S"
    End Sub

    Private Sub grdColigada_BeforeEnterEditMode(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grdColigada.BeforeEnterEditMode
        If Not grdColigada.ActiveCell.Row.IsAddRow Then
            Select Case grdColigada.ActiveCell.Column.Index
                Case cnt_GridColigada_NomeEmpresa
                    e.Cancel = True
            End Select
        End If
    End Sub

    Private Sub grdColigada_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdColigada.BeforeRowsDeleted
        e.DisplayPromptMsg = False

        If Msg_Perguntar("Você deseja excluir essa Empresa Coligada?") Then
            If NVL(e.Rows(0).Cells(cnt_GridColigada_SQ_FORN_COLIGADAS).Value, 0) > 0 Then
                Dim SqlText As String

                SqlText = "DELETE FROM SOF.FORNECEDOR_COLIGADAS" & _
                          " WHERE CD_FORNECEDOR = " & CD_FORNECEDOR & _
                            " AND SQ_FORN_COLIGADAS = " & e.Rows(0).Cells(cnt_GridColigada_SQ_FORN_COLIGADAS).Value
                If Not DBExecutar(SqlText) Then GoTo Erro
            End If
        Else
            e.Cancel = True
        End If

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub grdColigada_BeforeRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableRowEventArgs) Handles grdColigada.BeforeRowUpdate
        'If CampoNulo(e.Row.Cells(cnt_GridColigada_NomeEmpresa).Value) Then
        '    Msg_Mensagem("Informe o nome da Empresa Coligada")
        '    e.Cancel = True
        'ElseIf CampoNulo(e.Row.Cells(cnt_GridColigada_RamoAtividade).Value) Then
        '    Msg_Mensagem("Informe o ramo de atividade da Empresa Coligada")
        '    e.Cancel = True
        'ElseIf CampoNulo(e.Row.Cells(cnt_GridColigada_CGC).Value) Then
        '    Msg_Mensagem("Informe o número do C.N.P.J. da Empresa Coligada")
        '    e.Cancel = True
        'End If
    End Sub

    Private Sub grdReferenciaBancaria_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdReferenciaBancaria.AfterCellUpdate
        grdReferenciaBancaria.ActiveCell.Row.Cells(cnt_GridReferenciaBancaria_IC_CONTROLE).Value = "S"
    End Sub

    Private Sub grdReferenciaBancaria_BeforeEnterEditMode(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grdReferenciaBancaria.BeforeEnterEditMode
        If Not grdReferenciaBancaria.ActiveCell.Row.IsAddRow Then
            Select Case grdReferenciaBancaria.ActiveCell.Column.Index
                Case cnt_GridReferenciaBancaria_NomeBanco
                    e.Cancel = True
            End Select
        End If
    End Sub

    Private Sub grdReferenciaBancaria_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdReferenciaBancaria.BeforeRowsDeleted
        e.DisplayPromptMsg = False

        If Msg_Perguntar("Você deseja excluir essa Referência Bancária?") Then
            If NVL(e.Rows(0).Cells(cnt_GridReferenciaBancaria_SQ_FORN_REF_BANCO).Value, 0) > 0 Then
                Dim SqlText As String

                SqlText = "DELETE FROM SOF.FORNECEDOR_REFERENCIA_BANCO" & _
                          " WHERE CD_FORNECEDOR = " & CD_FORNECEDOR & _
                            " AND SQ_FORN_REF_BANCO = " & e.Rows(0).Cells(cnt_GridReferenciaBancaria_SQ_FORN_REF_BANCO).Value
                If Not DBExecutar(SqlText) Then GoTo Erro
            End If
        Else
            e.Cancel = True
        End If

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub grdReferenciaBancaria_BeforeRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableRowEventArgs) Handles grdReferenciaBancaria.BeforeRowUpdate
        'If CampoNulo(e.Row.Cells(cnt_GridReferenciaBancaria_Nr_Banco).Value) Then
        '    Msg_Mensagem("Informe o número do Banco para referência bancária")
        '    e.Cancel = True
        'ElseIf CampoNulo(e.Row.Cells(cnt_GridReferenciaBancaria_NomeBanco).Value) Then
        '    Msg_Mensagem("Informe o nome do Banco para referência bancária")
        '    e.Cancel = True
        'ElseIf CampoNulo(e.Row.Cells(cnt_GridReferenciaBancaria_NrAgencia).Value) Then
        '    Msg_Mensagem("Informe o número da Agência para referência bancária")
        '    e.Cancel = True
        'ElseIf CampoNulo(e.Row.Cells(cnt_GridReferenciaBancaria_NrContaCorrente).Value) Then
        '    Msg_Mensagem("Informe o número da Conta Corrente para referência bancária")
        '    e.Cancel = True
        'End If
    End Sub

    Private Sub cmdFazenda_Adicionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFazenda_Adicionar.Click
        If Trim(txtFazenda_Nome.Text) = "" Then
            Msg_Mensagem("Informe o nome da fazenda a ser cadastrada")
            Exit Sub
        End If

        Dim iCont As Integer
        Dim bAchou As Boolean = False

        For iCont = 0 To grdFazenda.Rows.Count - 1
            If UCase(objGrid_Valor(grdFazenda, cnt_GridFazenda_NomeFazenda, iCont)) = _
               UCase(Trim(txtFazenda_Nome.Text)) Then
                bAchou = True
                Exit For
            End If
        Next

        If bAchou Then
            Msg_Mensagem("Já foi adicionada uma fazenda com esse nome para esse fornecedor")
            Exit Sub
        End If

        oDS_Fazenda.Rows.Add()

        With oDS_Fazenda.Rows(oDS_Fazenda.Rows.Count - 1)
            .Item(cnt_GridFazenda_CD_MUNICIPIO) = Pesq_Municipio_Fazenda.Codigo
            .Item(cnt_GridFazenda_NomeFazenda) = Trim(txtFazenda_Nome.Text)
            .Item(cnt_GridFazenda_AreaCacau) = txtFazenda_AreaCacau.Value
            .Item(cnt_GridFazenda_AreaClonada) = txtFazenda_AreaClonada.Value
            .Item(cnt_GridFazenda_ProducaoCacau) = txtFazenda_ProducaoCacau.Value
            .Item(cnt_GridFazenda_Municipio) = Pesq_Municipio_Fazenda.Descricao
            .Item(cnt_GridFazenda_Endereco) = Trim(txtFazenda_Endereco.Text)
            .Item(cnt_GridFazenda_CEP) = Trim(txtFazenda_CEP.Text)
            .Item(cnt_GridFazenda_DiversidadesCulturais) = txtFazenda_DiversidadesCulturais.Text
        End With

        Fazenda_Limpar()
    End Sub

    Private Sub Fazenda_Limpar()
        Pesq_Municipio_Fazenda.Codigo = 0
        txtFazenda_Nome.Text = ""
        txtFazenda_AreaCacau.Value = 0
        txtFazenda_AreaClonada.Value = 0
        txtFazenda_ProducaoCacau.Value = 0
        txtFazenda_Endereco.Text = ""
        txtFazenda_CEP.Text = ""
        txtFazenda_DiversidadesCulturais.Text = ""
    End Sub

    Private Sub cboBem_Descricao_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBem_Descricao.SelectedIndexChanged
        If Not ComboBox_LinhaSelecionada(cboBem_Descricao) Then Exit Sub

        Dim oData As New DataTable
        Dim SqlText As String
        Dim sMsg As String

        SqlText = "SELECT BEN.QT_AREA_TOTAL," & _
                         "BEN.QT_AREA_CULTIVADA," & _
                         "BEN.QT_PRODUCAO," & _
                         "BEN.DS_ENDERECO," & _
                         "BEN.VL_BEM," & _
                         "FNB.CD_FORNECEDOR," & _
                         "FRN.NO_RAZAO_SOCIAL NO_FORNECEDOR" & _
                  " FROM SOF.BENS BEN," & _
                        "SOF.FORNECEDOR_BENS FNB," & _
                        "SOF.FORNECEDOR FRN" & _
                  " WHERE BEN.SQ_BENS = " & cboBem_Descricao.SelectedValue & _
                    " AND FNB.SQ_BENS (+) = BEN.SQ_BENS" & _
                    " AND FRN.CD_FORNECEDOR (+) = FNB.CD_FORNECEDOR"
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            If oData.Rows(0).Item("CD_FORNECEDOR") <> CD_FORNECEDOR Then
                sMsg = "Essa fazenda está cadastrada para o fornecedor " & Trim(oData.Rows(0).Item("NO_FORNECEDOR")) & ". " & _
                       "Deseja cadastrá-la para esse fornecedor também?"

                If Not Msg_Perguntar(sMsg) Then
                    cboBem_Descricao.SelectedIndex = -1
                    GoTo Sair
                End If
            End If

            txtBem_AreaTotal.Value = objDataTable_LerCampo(oData.Rows(0).Item("QT_AREA_TOTAL"), 0)
            txtBem_AreaCultivada.Value = objDataTable_LerCampo(oData.Rows(0).Item("QT_AREA_CULTIVADA"), 0)
            txtBem_Producao.Value = objDataTable_LerCampo(oData.Rows(0).Item("QT_PRODUCAO"), 0)
            txtBem_Endereco.Text = objDataTable_LerCampo(oData.Rows(0).Item("DS_ENDERECO"), "")
            txtBem_Valor.Value = objDataTable_LerCampo(oData.Rows(0).Item("VL_BEM"), 0)
        End If

Sair:
        oData.Dispose()
        oData = Nothing
    End Sub

    Private Sub Pesq_Municipio_Bem_AlterouRegistro() Handles Pesq_Municipio_Bem.AlterouRegistro
        Dim SqlText As String

        SqlText = "SELECT SQ_BENS, DS_BEM FROM SOF.BENS" & _
                  " WHERE CD_MUNICIPIO_LOCALIZACAO = " & Pesq_Municipio_Bem.Codigo & _
                  " ORDER BY DS_BEM"

        DBCarregarComboBox(cboBem_Descricao, SqlText, True)
    End Sub

    Private Sub cboBem_Tipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBem_Tipo.SelectedIndexChanged
        PrepararTelaDadosBem()
        OrganizarControle_PorTipo()
    End Sub

    Private Sub OrganizarControle_PorTipo()
        If ComboBox_LinhaSelecionada(cboBem_Tipo) Then
            lblBem_Valor.Enabled = True
            txtBem_Valor.Enabled = True

            lblBem_Municipio.Enabled = True
            Pesq_Municipio_Bem.Enabled = True
            lblBem_Endereco.Enabled = True
            txtBem_Endereco.Enabled = True
            lblBem_Descricao.Enabled = True
            txtBem_Descricao.Enabled = True
            txtBem_Descricao.Visible = True

            Select Case cboBem_Tipo.SelectedValue
                Case cnt_TipoBem_CasaApartamento
                    lblBem_Descricao.Text = "Descrição do Bem"
                Case cnt_TipoBem_Fazenda
                    lblBem_Descricao.Text = "Nome da Fazenda"
                    lblBem_Descricao.Enabled = True
                    cboBem_Descricao.Visible = True
                    txtBem_Descricao.Visible = False
                    lblBem_AreaTotal.Enabled = True
                    txtBem_AreaTotal.Enabled = True
                    lblBem_AreaCultivada.Enabled = True
                    txtBem_AreaCultivada.Enabled = True
                    lblBem_Producao.Enabled = True
                    txtBem_Producao.Enabled = True
                Case cnt_TipoBem_Veiculo
                    lblBem_Municipio.Enabled = False
                    Pesq_Municipio_Bem.Enabled = False
                    lblBem_Endereco.Enabled = False
                    txtBem_Endereco.Enabled = False

                    lblBem_Identificacao.Text = "Placa do Veículo"
                    lblBem_Identificacao.Visible = True
                    txtBem_Identificacao.Visible = True
                    txtBem_Identificacao.Width = 90
                    txtBem_Identificacao.CharacterCasing = CharacterCasing.Upper
                    txtBem_Identificacao.MaxLength = 8
                    lblBem_Descricao.Text = "Modelo/Ano"
                Case cnt_TipoBem_Outros
                    lblBem_Descricao.Text = "Descrição do Bem"
            End Select
        End If
    End Sub

    Private Sub PrepararTelaDadosBem()
        lblBem_Identificacao.Visible = False
        txtBem_Identificacao.Visible = False
        txtBem_Identificacao.Text = ""
        txtBem_Identificacao.Width = 471
        lblBem_Municipio.Enabled = False
        Pesq_Municipio_Bem.Enabled = False
        Pesq_Municipio_Bem.Codigo = 0
        lblBem_Endereco.Enabled = False
        txtBem_Endereco.Enabled = False
        txtBem_Endereco.Text = ""
        lblBem_Valor.Enabled = False
        txtBem_Valor.Enabled = False
        txtBem_Valor.Value = 0
        lblBem_Descricao.Enabled = False
        txtBem_Descricao.Enabled = False
        txtBem_Descricao.Text = ""
        cboBem_Descricao.Visible = False
        cboBem_Descricao.SelectedIndex = -1
        lblBem_AreaTotal.Enabled = False
        txtBem_AreaTotal.Enabled = False
        txtBem_AreaTotal.Value = 0
        lblBem_AreaCultivada.Enabled = False
        txtBem_AreaCultivada.Enabled = False
        txtBem_AreaCultivada.Value = 0
        lblBem_Producao.Enabled = False
        txtBem_Producao.Enabled = False
        txtBem_Producao.Value = 0
    End Sub

    Private Sub grdBem_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdBem.AfterCellUpdate
        grdBem.ActiveCell.Row.Cells(cnt_GridBem_IC_CONTROLE).Value = "S"
    End Sub

    Private Sub txtBem_Identificacao_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBem_Identificacao.LostFocus
        Select Case cboBem_Tipo.SelectedValue
            Case cnt_TipoBem_Veiculo
                Dim oData As New DataTable
                Dim SqlText As String
                Dim sMsg As String

                SqlText = "SELECT BEN.*," & _
                                 "FNB.CD_FORNECEDOR," & _
                                 "FNC.NO_RAZAO_SOCIAL NO_FORNECEDOR" & _
                          " FROM SOF.BENS BEN," & _
                                "SOF.FORNECEDOR_BENS FNB," & _
                                "SOF.FORNECEDOR FNC" & _
                          " WHERE UPPER(TRIM(BEN.DS_IDENTIFICACAO)) = " & QuotedStr(UCase(Trim(txtBem_Identificacao.Text))) & _
                            " AND FNB.SQ_BENS (+) = BEN.SQ_BENS" & _
                            " AND FNC.CD_FORNECEDOR (+) = FNB.CD_FORNECEDOR"
                oData = DBQuery(SqlText)

                If Not objDataTable_Vazio(oData) Then
                    If Not CampoNulo(oData.Rows(0).Item("CD_FORNECEDOR") = CD_FORNECEDOR) Then
                        If oData.Rows(0).Item("CD_FORNECEDOR") = CD_FORNECEDOR Then
                            Msg_Mensagem("Já existe um veículo cadastrado para esse fornecedor com essa placa.")

                            txtBem_Identificacao.Text = ""
                            GoTo Sair
                        Else
                            sMsg = "Existe um veículo cadastrado com essa placa para o Fornecedor " & Trim(oData.Rows(0).Item("NO_FORNECEDOR")) & ". " & _
                                   "Por isso não é possível cadastrar essa placa de veículo para esse fornecedor!"
                            Msg_Mensagem(sMsg)

                            txtBem_Identificacao.Text = ""
                            GoTo Sair
                        End If
                    End If
                End If

                Exit Sub

Sair:
                oData.Dispose()
                oData = Nothing
        End Select
    End Sub

    Private Sub cmdFazenda_Novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFazenda_Novo.Click
        Fazenda_Limpar()
    End Sub

    Private Sub cmdBem_Novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBem_Novo.Click
        PrepararTelaDadosBem()
    End Sub

    Private Sub cmdBem_Adicionar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBem_Adicionar.Click
        If Not ComboBox_LinhaSelecionada(cboBem_Tipo) Then
            Msg_Mensagem("Selecione o tipo do bem do fornecedor")
            Exit Sub
        End If
        If cboBem_Descricao.Visible Then
            If Trim(cboBem_Descricao.Text) = "" Then
                Msg_Mensagem("Informe o " & lblBem_Descricao.Text & " do fornecedor")
            End If
        Else
            If Trim(txtBem_Descricao.Text) = "" Then
                Select Case cboBem_Tipo.SelectedValue
                    Case cnt_TipoBem_CasaApartamento, cnt_TipoBem_Outros
                        Msg_Mensagem("Informe a " & lblBem_Descricao.Text & " do fornecedor")
                    Case cnt_TipoBem_Veiculo
                        Msg_Mensagem("Informe o " & lblBem_Descricao.Text & " do fornecedor")
                End Select

                Exit Sub
            End If
        End If
        If txtBem_Valor.Value = 0 Then
            Msg_Mensagem("Informe o valor do bem do fornecedor")
            Exit Sub
        End If
        Select Case cboBem_Tipo.SelectedValue
            Case cnt_TipoBem_CasaApartamento, cnt_TipoBem_Fazenda
                If Pesq_Municipio_Bem.Codigo = 0 Then
                    Msg_Mensagem("Informe o município de localização do bem")
                    Exit Sub
                End If
                If Trim(txtBem_Endereco.Text) = "" Then
                    Msg_Mensagem("Informe o endereço de localização do bem")
                    Exit Sub
                End If
            Case cnt_TipoBem_Veiculo
                If Trim(txtBem_Identificacao.Text) = "" Then
                    Msg_Mensagem("Informe o número da placa do veículo")
                    Exit Sub
                End If
        End Select

        Dim iCont As Integer
        Dim bAchou As Boolean = False

        For iCont = 0 To grdBem.Rows.Count - 1
            If objGrid_Valor(grdBem, cnt_GridBem_CD_BENS_TIPO, iCont) = _
               cboBem_Tipo.SelectedValue And _
               UCase(Trim(objGrid_Valor(grdBem, cnt_GridBem_IdentificacaoBem, iCont, ""))) = _
               UCase(Trim(txtBem_Identificacao.Text)) And _
               UCase(Trim(objGrid_Valor(grdBem, cnt_GridBem_DescricaoBem, iCont, ""))) = _
               UCase(Trim(txtBem_Descricao.Text)) And _
               objGrid_Valor(grdBem, cnt_GridBem_ValorBem, iCont) = _
               txtBem_Valor.Value Then
                bAchou = True
                Exit For
            End If
        Next

        If bAchou Then
            Msg_Mensagem("Já foi adicionado um bem com essas informações para esse fornecedor")
            Exit Sub
        End If

        oDS_Bem.Rows.Add()

        With oDS_Bem.Rows(oDS_Bem.Rows.Count - 1)
            If cboBem_Descricao.Visible Then
                .Item(cnt_GridBem_SQ_BENS) = cboBem_Tipo.SelectedValue
            End If

            .Item(cnt_GridBem_IC_CONTROLE) = "S"
            .Item(cnt_GridBem_CD_BENS_TIPO) = cboBem_Tipo.SelectedValue
            .Item(cnt_GridBem_CD_MUNICIPIO) = Pesq_Municipio_Bem.Codigo
            .Item(cnt_GridBem_TipoBem) = cboBem_Tipo.Text
            .Item(cnt_GridBem_IdentificacaoBem) = Trim(txtBem_Identificacao.Text)

            If cboBem_Descricao.Visible Then
                .Item(cnt_GridBem_DescricaoBem) = Trim(cboBem_Descricao.Text)
            Else
                .Item(cnt_GridBem_DescricaoBem) = Trim(txtBem_Descricao.Text)
            End If

            .Item(cnt_GridBem_ValorBem) = txtBem_Valor.Value
            .Item(cnt_GridBem_Endereco) = txtBem_Endereco.Text
            .Item(cnt_GridBem_Municipio) = Pesq_Municipio_Bem.Descricao
            .Item(cnt_GridBem_AreaTotal) = txtBem_AreaTotal.Value
            .Item(cnt_GridBem_AreaCultivada) = txtBem_AreaCultivada.Value
            .Item(cnt_GridBem_Producao) = txtBem_Producao.Value
        End With

        PrepararTelaDadosBem()
    End Sub

    Private Sub grdBem_BeforeEnterEditMode(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grdBem.BeforeEnterEditMode
        If Not grdBem.ActiveCell.Row.IsAddRow Then
            Select Case grdBem.ActiveCell.Column.Index
                Case cnt_GridBem_TipoBem
                    e.Cancel = True
            End Select
        End If
    End Sub

    Private Sub grdBem_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdBem.BeforeRowsDeleted
        e.DisplayPromptMsg = False

        If Msg_Perguntar("Você deseja excluir essa Bem do fornecedor?") Then
            Dim SqlText As String

            If NVL(e.Rows(0).Cells(cnt_GridBem_SQ_BENS).Value, 0) > 0 Then
                SqlText = "DELETE FROM SOF.FORNECEDOR_BENS" & _
                          " WHERE SQ_BENS = " & e.Rows(0).Cells(cnt_GridBem_SQ_BENS).Value & _
                            " AND CD_FORNECEDOR = " & CD_FORNECEDOR
                DBExecutar(SqlText)

                SqlText = "SELECT COUNT(*) FROM SOF.FORNECEDOR_BENS" & _
                          " WHERE SQ_BENS = " & e.Rows(0).Cells(cnt_GridBem_SQ_BENS).Value
                If DBQuery_ValorUnico(SqlText) = 0 Then
                    SqlText = "DELETE FROM SOF.BENS" & _
                              " WHERE SQ_BENS = " & e.Rows(0).Cells(cnt_GridBem_SQ_BENS).Value
                    DBExecutar(SqlText)
                End If
            End If
        Else
            e.Cancel = True
        End If

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub cmdSocio_Adicionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSocio_Adicionar.Click
        If Not ComboBox_LinhaSelecionada(cboSocio_TipoPessoa) Then
            Msg_Mensagem("Selecione o tipo da pessoa")
            Exit Sub
        End If
        If Trim(txtSocio_Nome.Text) = "" Then
            Msg_Mensagem("Informe o nome do sócio")
            Exit Sub
        End If
        If Not Valida_CPF(SoNumero(txtSocio_CPF.Text)) Then
            Msg_Mensagem("Informe um número de C.P.F. válido para o sócio")
            Exit Sub
        End If

        Dim iCont As Integer
        Dim bAchou As Boolean = False

        For iCont = 0 To grdBem.Rows.Count - 1
            If objGrid_Valor(grdBem, cnt_GridSocio_CPF, iCont) = _
               Trim(txtSocio_CPF.Text) Then
                bAchou = True
                Exit For
            End If
        Next

        If bAchou Then
            Msg_Mensagem("Já foi adicionado esse sócio para esse fornecedor")
            Exit Sub
        End If

        oDS_Socio.Rows.Add()

        With oDS_Socio.Rows(oDS_Socio.Rows.Count - 1)
            .Item(cnt_GridSocio_CD_TIPO_FORNECEDOR_PESSOA) = cboSocio_TipoPessoa.SelectedValue
            .Item(cnt_GridSocio_CD_MUNICIPIO) = Pesq_Municipio_Socio.Codigo
            .Item(cnt_GridSocio_IC_CONTROLE) = "S"
            .Item(cnt_GridSocio_TipoPessoa) = cboSocio_TipoPessoa.Text
            .Item(cnt_GridSocio_NomeSocio) = Trim(txtSocio_Nome.Text)
            .Item(cnt_GridSocio_Municipio) = Pesq_Municipio_Socio.Descricao
            .Item(cnt_GridSocio_Endereco) = Trim(txtSocio_Endereco.Text)
            .Item(cnt_GridSocio_EMail) = Trim(txtSocio_EMail.Text)
            .Item(cnt_GridSocio_Telefone) = Trim(txtSocio_Telefone.Text)
            .Item(cnt_GridSocio_CPF) = Trim(txtSocio_CPF.Text)
        End With

        Socio_Limpar()
    End Sub

    Private Sub Socio_Limpar()
        cboSocio_TipoPessoa.SelectedIndex = -1
        Pesq_Municipio_Socio.Codigo = 0
        cboSocio_TipoPessoa.Text = ""
        txtSocio_Nome.Text = ""
        txtSocio_Endereco.Text = ""
        txtSocio_EMail.Text = ""
        txtSocio_Telefone.Text = ""
        txtSocio_CPF.Text = ""
    End Sub

    Private Sub grdSocio_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdSocio.AfterCellUpdate
        grdSocio.ActiveCell.Row.Cells(cnt_GridSocio_IC_CONTROLE).Value = "S"
    End Sub

    Private Sub grdSocio_BeforeEnterEditMode(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grdSocio.BeforeEnterEditMode
        If Not grdSocio.ActiveCell.Row.IsAddRow Then
            Select Case grdSocio.ActiveCell.Column.Index
                Case cnt_GridSocio_TipoPessoa
                    e.Cancel = True
            End Select
        End If
    End Sub

    Private Sub grdSocio_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdSocio.BeforeRowsDeleted
        e.DisplayPromptMsg = False

        If Msg_Perguntar("Você deseja excluir esse Sócio do fornecedor?") Then
            Dim SqlText As String

            If NVL(e.Rows(0).Cells(cnt_GridSocio_SQ_FORNECEDOR_PESSOA).Value, 0) > 0 Then
                SqlText = "DELETE FROM SOF.FORNECEDOR_PESSOA" & _
                          " WHERE SQ_FORNECEDOR_PESSOA = " & e.Rows(0).Cells(cnt_GridSocio_SQ_FORNECEDOR_PESSOA).Value & _
                            " AND CD_FORNECEDOR = " & CD_FORNECEDOR
                DBExecutar(SqlText)
            End If
        Else
            e.Cancel = True
        End If

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub cmdSocio_Novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSocio_Novo.Click
        Socio_Limpar()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        If Not Gravar_Validar_DadosFornecedor() Then Exit Sub
        If Not Gravar_Validar_Procuracao() Then Exit Sub
        If Not Gravar_Validar_Controlador() Then Exit Sub
        If Not Gravar_Validar_Coligado() Then Exit Sub
        If Not Gravar_Validar_ReferenciaBancaria() Then Exit Sub
        If Not Gravar_Validar_Fazenda() Then Exit Sub
        If Not Gravar_Validar_Bem() Then Exit Sub
        If Not Gravar_Validar_Socio() Then Exit Sub

        On Error GoTo Erro

        Dim SqlText As String
        Dim oParametro(71) As DBParamentro
        Dim bPessoaFisica As Boolean
        Dim iCont As Integer

        Dim SQ_PROCURACAO As Long
        Dim SQ_FORN_CONTROLADOR As Long
        Dim SQ_FORN_COLIGADAS As Long
        Dim SQ_FORN_REF_BANCO As Long
        Dim SQ_BENS As Long
        Dim SQ_FORNECEDOR_PESSOA As Long
        Dim SEQ_AUX As Long

        Dim UF As String

        DBUsarTransacao = True

        '>> Dados Gerais
        If CD_FORNECEDOR = 0 Then
            CD_FORNECEDOR = DBNumeroMaisUm("SOF.FORNECEDOR", "CD_FORNECEDOR")

            SqlText = DBMontar_Insert("SOF.FORNECEDOR", TipoCampoFixo.DadoCriacao, "CD_ADDRESS_NUMBER", ":CD_ADDRESS_NUMBER", _
                                                                                   "CD_ESTADO_CIVIL", ":CD_ESTADO_CIVIL", _
                                                                                   "CD_FILIAL_ORIGEM", ":CD_FILIAL_ORIGEM", _
                                                                                   "CD_FUNRURAL", ":CD_FUNRURAL", _
                                                                                   "CD_MUNICIPIO", ":CD_MUNICIPIO", _
                                                                                   "CD_MUNICIPIO2", ":CD_MUNICIPIO2", _
                                                                                   "CD_REPASSADOR", ":CD_REPASSADOR", _
                                                                                   "CD_TIPO_CAPITAL", ":CD_TIPO_CAPITAL", _
                                                                                   "CD_TIPO_PESSOA", ":CD_TIPO_PESSOA", _
                                                                                   "CD_TIPO_PESSOA_TRIBUTACAO", ":CD_TIPO_PESSOA_TRIBUTACAO", _
                                                                                   "DS_CARGO_CONTATO", ":DS_CARGO_CONTATO", _
                                                                                   "DS_COMERCIALIZACAO", ":DS_COMERCIALIZACAO", _
                                                                                   "DS_DESCRICAO_ENDERECO2", ":DS_DESCRICAO_ENDERECO2", _
                                                                                   "DS_EMAIL", ":DS_EMAIL", _
                                                                                   "DS_EMAIL_CONTATO", ":DS_EMAIL_CONTATO", _
                                                                                   "DS_ENDERECO", ":DS_ENDERECO", _
                                                                                   "DS_ENDERECO_COMPLEMENTO", ":DS_ENDERECO_COMPLEMENTO", _
                                                                                   "DS_ENDERECO_COMPLEMENTO2", ":DS_ENDERECO_COMPLEMENTO2", _
                                                                                   "DS_ENDERECO2", ":DS_ENDERECO2", _
                                                                                   "DS_NACIONALIDADE", ":DS_NACIONALIDADE", _
                                                                                   "DS_NATURALIDADE", ":DS_NATURALIDADE", _
                                                                                   "DS_NIVEL_LIQUIDEZ", ":DS_NIVEL_LIQUIDEZ", _
                                                                                   "DS_OBS_FICHA", ":DS_OBS_FICHA", _
                                                                                   "DS_ORGAO_EMISSOR_RG", ":DS_ORGAO_EMISSOR_RG", _
                                                                                   "DS_OUTRA_ATIVIDADE", ":DS_OUTRA_ATIVIDADE", _
                                                                                   "DS_PAIS_CAPITAL", ":DS_PAIS_CAPITAL", _
                                                                                   "DT_CONSTITUICAO_JUNTA", ":DT_CONSTITUICAO_JUNTA", _
                                                                                   "DT_EMISSAO_RG", ":DT_EMISSAO_RG", _
                                                                                   "DT_NASCIMENTO", ":DT_NASCIMENTO", _
                                                                                   "DT_NASCIMENTO_CONJUGE", ":DT_NASCIMENTO_CONJUGE", _
                                                                                   "DT_NASCIMENTO_CONTATO", ":DT_NASCIMENTO_CONTATO", _
                                                                                   "IC_APLICA_AUTOMATICO", ":IC_APLICA_AUTOMATICO", _
                                                                                   "IC_ATIVO", ":IC_ATIVO", _
                                                                                   "IC_FISICA_JURIDICA", ":IC_FISICA_JURIDICA", _
                                                                                   "IC_LISTA_NEGRA", ":IC_LISTA_NEGRA", _
                                                                                   "IC_SEXO", ":IC_SEXO", _
                                                                                   "IC_TIPO_RG", ":IC_TIPO_RG", _
                                                                                   "NO_BAIRRO", ":NO_BAIRRO", _
                                                                                   "NO_BAIRRO2", ":NO_BAIRRO2", _
                                                                                   "NO_BANCO", ":NO_BANCO", _
                                                                                   "NO_CONJUGE", ":NO_CONJUGE", _
                                                                                   "NO_CONTATO", ":NO_CONTATO", _
                                                                                   "NO_FANTASIA", ":NO_FANTASIA", _
                                                                                   "NO_FAVORECIDO_CHEQUE", ":NO_FAVORECIDO_CHEQUE", _
                                                                                   "NO_MAE", ":NO_MAE", _
                                                                                   "NO_PAI", ":NO_PAI", _
                                                                                   "NO_PROFISSAO", ":NO_PROFISSAO", _
                                                                                   "NO_RAZAO_SOCIAL", ":NO_RAZAO_SOCIAL", _
                                                                                   "NU_AGENCIA", ":NU_AGENCIA", _
                                                                                   "NU_CAIXA_POSTAL", ":NU_CAIXA_POSTAL", _
                                                                                   "NU_CAIXA_POSTAL2", ":NU_CAIXA_POSTAL2", _
                                                                                   "NU_CELULAR", ":NU_CELULAR", _
                                                                                   "NU_CEP", ":NU_CEP", _
                                                                                   "NU_CEP2", ":NU_CEP2", _
                                                                                   "NU_CGC_CPF", ":NU_CGC_CPF", _
                                                                                   "NU_CGC_CPF_SEQ", ":NU_CGC_CPF_SEQ", _
                                                                                   "NU_CONTA_CORRENTE", ":NU_CONTA_CORRENTE", _
                                                                                   "NU_FAX", ":NU_FAX", _
                                                                                   "NU_INSC_ESTADUAL", ":NU_INSC_ESTADUAL", _
                                                                                   "NU_INSCRICAO_MUNICIPAL", ":NU_INSCRICAO_MUNICIPAL", _
                                                                                   "NU_REGISTRO_JUNTA_COMERCIAL", ":NU_REGISTRO_JUNTA_COMERCIAL", _
                                                                                   "NU_RG", ":NU_RG", _
                                                                                   "NU_TEL", ":NU_TEL", _
                                                                                   "NU_TELEFONE_CONTATO", ":NU_TELEFONE_CONTATO", _
                                                                                   "PC_CAPITAL_ESTRANGEIRO", ":PC_CAPITAL_ESTRANGEIRO", _
                                                                                   "PC_CAPITAL_NACIONAL", ":PC_CAPITAL_NACIONAL", _
                                                                                   "QT_DEPENDENTES", ":QT_DEPENDENTES", _
                                                                                   "QT_TEMPO_ESTABELECIDO", ":QT_TEMPO_ESTABELECIDO", _
                                                                                   "VL_FATURAMENTO_ANUAL", ":VL_FATURAMENTO_ANUAL", _
                                                                                   "VL_PATRIMONIO_LIQUIDO", ":VL_PATRIMONIO_LIQUIDO", _
                                                                                   "IC_LIBERACAO_CREDITO", ":IC_LIBERACAO_CREDITO", _
                                                                                   "CD_FORNECEDOR", ":CD_FORNECEDOR")
        Else
            SqlText = DBMontar_Update("SOF.FORNECEDOR", GerarArray("CD_ADDRESS_NUMBER", ":CD_ADDRESS_NUMBER", _
                                                                   "CD_ESTADO_CIVIL", ":CD_ESTADO_CIVIL", _
                                                                   "CD_FILIAL_ORIGEM", ":CD_FILIAL_ORIGEM", _
                                                                   "CD_FUNRURAL", ":CD_FUNRURAL", _
                                                                   "CD_MUNICIPIO", ":CD_MUNICIPIO", _
                                                                   "CD_MUNICIPIO2", ":CD_MUNICIPIO2", _
                                                                   "CD_REPASSADOR", ":CD_REPASSADOR", _
                                                                   "CD_TIPO_CAPITAL", ":CD_TIPO_CAPITAL", _
                                                                   "CD_TIPO_PESSOA", ":CD_TIPO_PESSOA", _
                                                                   "CD_TIPO_PESSOA_TRIBUTACAO", ":CD_TIPO_PESSOA_TRIBUTACAO", _
                                                                   "DS_CARGO_CONTATO", ":DS_CARGO_CONTATO", _
                                                                   "DS_COMERCIALIZACAO", ":DS_COMERCIALIZACAO", _
                                                                   "DS_DESCRICAO_ENDERECO2", ":DS_DESCRICAO_ENDERECO2", _
                                                                   "DS_EMAIL", ":DS_EMAIL", _
                                                                   "DS_EMAIL_CONTATO", ":DS_EMAIL_CONTATO", _
                                                                   "DS_ENDERECO", ":DS_ENDERECO", _
                                                                   "DS_ENDERECO_COMPLEMENTO", ":DS_ENDERECO_COMPLEMENTO", _
                                                                   "DS_ENDERECO_COMPLEMENTO2", ":DS_ENDERECO_COMPLEMENTO2", _
                                                                   "DS_ENDERECO2", ":DS_ENDERECO2", _
                                                                   "DS_NACIONALIDADE", ":DS_NACIONALIDADE", _
                                                                   "DS_NATURALIDADE", ":DS_NATURALIDADE", _
                                                                   "DS_NIVEL_LIQUIDEZ", ":DS_NIVEL_LIQUIDEZ", _
                                                                   "DS_OBS_FICHA", ":DS_OBS_FICHA", _
                                                                   "DS_ORGAO_EMISSOR_RG", ":DS_ORGAO_EMISSOR_RG", _
                                                                   "DS_OUTRA_ATIVIDADE", ":DS_OUTRA_ATIVIDADE", _
                                                                   "DS_PAIS_CAPITAL", ":DS_PAIS_CAPITAL", _
                                                                   "DT_CONSTITUICAO_JUNTA", ":DT_CONSTITUICAO_JUNTA", _
                                                                   "DT_EMISSAO_RG", ":DT_EMISSAO_RG", _
                                                                   "DT_NASCIMENTO", ":DT_NASCIMENTO", _
                                                                   "DT_NASCIMENTO_CONJUGE", ":DT_NASCIMENTO_CONJUGE", _
                                                                   "DT_NASCIMENTO_CONTATO", ":DT_NASCIMENTO_CONTATO", _
                                                                   "IC_APLICA_AUTOMATICO", ":IC_APLICA_AUTOMATICO", _
                                                                   "IC_ATIVO", ":IC_ATIVO", _
                                                                   "IC_FISICA_JURIDICA", ":IC_FISICA_JURIDICA", _
                                                                   "IC_LISTA_NEGRA", ":IC_LISTA_NEGRA", _
                                                                   "IC_SEXO", ":IC_SEXO", _
                                                                   "IC_TIPO_RG", ":IC_TIPO_RG", _
                                                                   "NO_BAIRRO", ":NO_BAIRRO", _
                                                                   "NO_BAIRRO2", ":NO_BAIRRO2", _
                                                                   "NO_BANCO", ":NO_BANCO", _
                                                                   "NO_CONJUGE", ":NO_CONJUGE", _
                                                                   "NO_CONTATO", ":NO_CONTATO", _
                                                                   "NO_FANTASIA", ":NO_FANTASIA", _
                                                                   "NO_FAVORECIDO_CHEQUE", ":NO_FAVORECIDO_CHEQUE", _
                                                                   "NO_MAE", ":NO_MAE", _
                                                                   "NO_PAI", ":NO_PAI", _
                                                                   "NO_PROFISSAO", ":NO_PROFISSAO", _
                                                                   "NO_RAZAO_SOCIAL", ":NO_RAZAO_SOCIAL", _
                                                                   "NU_AGENCIA", ":NU_AGENCIA", _
                                                                   "NU_CAIXA_POSTAL", ":NU_CAIXA_POSTAL", _
                                                                   "NU_CAIXA_POSTAL2", ":NU_CAIXA_POSTAL2", _
                                                                   "NU_CELULAR", ":NU_CELULAR", _
                                                                   "NU_CEP", ":NU_CEP", _
                                                                   "NU_CEP2", ":NU_CEP2", _
                                                                   "NU_CGC_CPF", ":NU_CGC_CPF", _
                                                                   "NU_CGC_CPF_SEQ", ":NU_CGC_CPF_SEQ", _
                                                                   "NU_CONTA_CORRENTE", ":NU_CONTA_CORRENTE", _
                                                                   "NU_FAX", ":NU_FAX", _
                                                                   "NU_INSC_ESTADUAL", ":NU_INSC_ESTADUAL", _
                                                                   "NU_INSCRICAO_MUNICIPAL", ":NU_INSCRICAO_MUNICIPAL", _
                                                                   "NU_REGISTRO_JUNTA_COMERCIAL", ":NU_REGISTRO_JUNTA_COMERCIAL", _
                                                                   "NU_RG", ":NU_RG", _
                                                                   "NU_TEL", ":NU_TEL", _
                                                                   "NU_TELEFONE_CONTATO", ":NU_TELEFONE_CONTATO", _
                                                                   "PC_CAPITAL_ESTRANGEIRO", ":PC_CAPITAL_ESTRANGEIRO", _
                                                                   "PC_CAPITAL_NACIONAL", ":PC_CAPITAL_NACIONAL", _
                                                                   "QT_DEPENDENTES", ":QT_DEPENDENTES", _
                                                                   "QT_TEMPO_ESTABELECIDO", ":QT_TEMPO_ESTABELECIDO", _
                                                                   "VL_FATURAMENTO_ANUAL", ":VL_FATURAMENTO_ANUAL", _
                                                                   "VL_PATRIMONIO_LIQUIDO", ":VL_PATRIMONIO_LIQUIDO", _
                                                                   "IC_LIBERACAO_CREDITO", ":IC_LIBERACAO_CREDITO"), _
                                                        GerarArray("CD_FORNECEDOR", ":CD_FORNECEDOR"))
        End If

        bPessoaFisica = (optTipoPessoa.Value = "F")
        oParametro(0) = DBParametro_Montar("CD_ADDRESS_NUMBER", txtAddressNumber.Value)
        oParametro(1) = DBParametro_Montar("CD_ESTADO_CIVIL", IIf(bPessoaFisica, NULLIf(cboEstadoCivil.SelectedValue, -1), Nothing))
        oParametro(2) = DBParametro_Montar("CD_FILIAL_ORIGEM", cboFilial.SelectedValue)
        oParametro(3) = DBParametro_Montar("CD_FUNRURAL", cboFunrural.SelectedValue)
        oParametro(4) = DBParametro_Montar("CD_MUNICIPIO", Pesq_Municipio_EndPrincipal.Codigo)
        oParametro(5) = DBParametro_Montar("CD_MUNICIPIO2", NULLIf(Pesq_Municipio_EndSecundario.Codigo, 0))
        oParametro(6) = DBParametro_Montar("CD_REPASSADOR", IIf(chkRepassador.Checked, Pesq_Repassador.Codigo, Nothing))
        oParametro(7) = DBParametro_Montar("CD_TIPO_CAPITAL", IIf(bPessoaFisica, Nothing, NULLIf(cboTipoCapital.SelectedValue, -1)))
        oParametro(8) = DBParametro_Montar("CD_TIPO_PESSOA", cboTipoPessoa.SelectedValue)
        oParametro(9) = DBParametro_Montar("CD_TIPO_PESSOA_TRIBUTACAO", NULLIf(cboTipoPessoaTributacao.SelectedValue, -1))
        oParametro(10) = DBParametro_Montar("DS_CARGO_CONTATO", NULLIf(Trim(txtCargoContato.Text), ""))
        oParametro(11) = DBParametro_Montar("DS_COMERCIALIZACAO", NULLIf(Trim(txtComercializacao.Text), ""), , , 300)
        oParametro(12) = DBParametro_Montar("DS_DESCRICAO_ENDERECO2", NULLIf(Trim(txtDescricaoEndereco2.Text), ""))
        oParametro(13) = DBParametro_Montar("DS_EMAIL", NULLIf(Trim(txtEmail.Text), ""))
        oParametro(14) = DBParametro_Montar("DS_EMAIL_CONTATO", NULLIf(Trim(txtEmailContato.Text), ""))
        oParametro(15) = DBParametro_Montar("DS_ENDERECO", NULLIf(Trim(txtEndereco1.Text), ""))
        oParametro(16) = DBParametro_Montar("DS_ENDERECO2", NULLIf(Trim(txtEndereco2.Text), ""))
        oParametro(17) = DBParametro_Montar("DS_ENDERECO_COMPLEMENTO", NULLIf(Trim(txtComplemento1.Text), ""))
        oParametro(18) = DBParametro_Montar("DS_ENDERECO_COMPLEMENTO2", NULLIf(Trim(txtComplemento2.Text), ""))
        oParametro(19) = DBParametro_Montar("DS_NACIONALIDADE", NULLIf(Trim(txtNacionalidade.Text), ""))
        oParametro(20) = DBParametro_Montar("DS_NATURALIDADE", NULLIf(Trim(txtNaturalidade.Text), ""))
        oParametro(21) = DBParametro_Montar("DS_NIVEL_LIQUIDEZ", NULLIf(Trim(txtNivelLiquidez.Text), ""))
        oParametro(22) = DBParametro_Montar("DS_OBS_FICHA", NULLIf(Trim(txtObservacaoImpressaoFicha.Text), ""), , , 3000)
        oParametro(23) = DBParametro_Montar("DS_ORGAO_EMISSOR_RG", NULLIf(Trim(txtLocalEmissaoIdentidade.Text), ""))
        oParametro(24) = DBParametro_Montar("DS_OUTRA_ATIVIDADE", NULLIf(Trim(txtOutraAtividade.Text), ""), , , 300)
        oParametro(25) = DBParametro_Montar("DS_PAIS_CAPITAL", NULLIf(Trim(txtPaisOrigemCapital.Text), ""))
        oParametro(26) = DBParametro_Montar("DT_CONSTITUICAO_JUNTA", Date_to_Oracle_Nulo(txtDataRegistroJunta.Value))
        oParametro(27) = DBParametro_Montar("DT_EMISSAO_RG", Date_to_Oracle_Nulo(txtDataEmissaoIdentidade.Value))
        oParametro(28) = DBParametro_Montar("DT_NASCIMENTO", Date_to_Oracle_Nulo(txtDataNascimento.Value))
        oParametro(29) = DBParametro_Montar("DT_NASCIMENTO_CONJUGE", Date_to_Oracle_Nulo(txtDataNascimentoConjuge.Value))
        oParametro(30) = DBParametro_Montar("DT_NASCIMENTO_CONTATO", Date_to_Oracle_Nulo(txtDataNascimentoContato.Value))
        oParametro(31) = DBParametro_Montar("IC_APLICA_AUTOMATICO", IIf(chkAplicacaoAutamatica.Checked, "S", "N"))
        oParametro(32) = DBParametro_Montar("IC_ATIVO", IIf(chkAtivo.Checked, "S", "N"))
        oParametro(33) = DBParametro_Montar("IC_FISICA_JURIDICA", optTipoPessoa.Value)
        oParametro(34) = DBParametro_Montar("IC_LISTA_NEGRA", IIf(chkListaNegra.Checked, "S", "N"))
        oParametro(35) = DBParametro_Montar("IC_SEXO", optSexo.Value)
        oParametro(36) = DBParametro_Montar("IC_TIPO_RG", optTipoIdentidade.Value)
        oParametro(37) = DBParametro_Montar("NO_BAIRRO", NULLIf(Trim(txtBairro1.Text), ""))
        oParametro(38) = DBParametro_Montar("NO_BAIRRO2", NULLIf(Trim(txtBairro2.Text), ""))
        oParametro(39) = DBParametro_Montar("NO_BANCO", NULLIf(Trim(txtReferencia_Banco.Text), ""))
        oParametro(40) = DBParametro_Montar("NO_CONJUGE", NULLIf(Trim(txtConjuge.Text), ""))
        oParametro(41) = DBParametro_Montar("NO_CONTATO", NULLIf(Trim(txtContato.Text), ""))
        oParametro(42) = DBParametro_Montar("NO_FANTASIA", NULLIf(Trim(txtNomeFantasia.Text), ""))
        oParametro(43) = DBParametro_Montar("NO_FAVORECIDO_CHEQUE", NULLIf(Trim(txtReferencia_Favorecido.Text), ""))
        oParametro(44) = DBParametro_Montar("NO_MAE", NULLIf(Trim(txtNomeMae.Text), ""))
        oParametro(45) = DBParametro_Montar("NO_PAI", NULLIf(Trim(txtNomePai.Text), ""))
        oParametro(46) = DBParametro_Montar("NO_PROFISSAO", NULLIf(Trim(txtProfissao.Text), ""))
        oParametro(47) = DBParametro_Montar("NO_RAZAO_SOCIAL", NULLIf(Trim(txtRazaoSocial.Text), ""))
        oParametro(48) = DBParametro_Montar("NU_AGENCIA", NULLIf(Trim(txtReferencia_Agencia.Text), ""))
        oParametro(49) = DBParametro_Montar("NU_CAIXA_POSTAL", NULLIf(Trim(txtCaixaPostal1.Text), ""))
        oParametro(50) = DBParametro_Montar("NU_CAIXA_POSTAL2", NULLIf(Trim(txtCaixaPostal2.Text), ""))
        oParametro(51) = DBParametro_Montar("NU_CELULAR", NULLIf(Trim(txtCelular.Text), ""))
        oParametro(52) = DBParametro_Montar("NU_CEP", NULLIf(Trim(txtCEP1.Text), ""))
        oParametro(53) = DBParametro_Montar("NU_CEP2", NULLIf(Trim(txtCEP2.Text), ""))
        oParametro(54) = DBParametro_Montar("NU_CGC_CPF", NULLIf(Trim(txtCPF_CNPJ.Text), ""))
        oParametro(55) = DBParametro_Montar("NU_CGC_CPF_SEQ", CPF_CNPJ_Seq)
        oParametro(56) = DBParametro_Montar("NU_CONTA_CORRENTE", NULLIf(Trim(txtReferencia_ContaCorrente.Text), ""))
        oParametro(57) = DBParametro_Montar("NU_FAX", NULLIf(Trim(txtFax.Text), ""))
        oParametro(58) = DBParametro_Montar("NU_INSC_ESTADUAL", NULLIf(Trim(txtInscricaoEstadual.Text), ""))
        oParametro(59) = DBParametro_Montar("NU_INSCRICAO_MUNICIPAL", NULLIf(Trim(txtInscricaoMunicipal.Text), ""))
        oParametro(60) = DBParametro_Montar("NU_REGISTRO_JUNTA_COMERCIAL", NULLIf(Trim(txtRegistroJunta.Text), ""))
        oParametro(61) = DBParametro_Montar("NU_RG", NULLIf(Trim(txtNumeroIdentidade.Text), ""))
        oParametro(62) = DBParametro_Montar("NU_TEL", NULLIf(Trim(txtTelefone.Text), ""))
        oParametro(63) = DBParametro_Montar("NU_TELEFONE_CONTATO", NULLIf(Trim(txtTelefoneContato.Text), ""))
        oParametro(64) = DBParametro_Montar("PC_CAPITAL_ESTRANGEIRO", NULLIf(txtCapitalEstrangeiro.Value, 0))
        oParametro(65) = DBParametro_Montar("PC_CAPITAL_NACIONAL", NULLIf(txtCapitalNacional.Value, 0))
        oParametro(66) = DBParametro_Montar("QT_DEPENDENTES", NULLIf(txtDependentes.Value, 0))
        oParametro(67) = DBParametro_Montar("QT_TEMPO_ESTABELECIDO", NULLIf(txtEstabelecidoDesde.Value, 0))
        oParametro(68) = DBParametro_Montar("VL_FATURAMENTO_ANUAL", NULLIf(txtFaturamentoAnual.Value, 0))
        oParametro(69) = DBParametro_Montar("VL_PATRIMONIO_LIQUIDO", NULLIf(txtPatrimonioLiquido.Value, 0))
        oParametro(70) = DBParametro_Montar("IC_LIBERACAO_CREDITO", "N")
        oParametro(71) = DBParametro_Montar("CD_FORNECEDOR", CD_FORNECEDOR)

        If Not DBExecutar(SqlText, oParametro) Then GoTo Erro

        '>> Procuração
        SqlText = "SELECT NVL(MAX(SQ_PROCURACAO), 0)" & _
                  " FROM SOF.FORNECEDOR_PROCURACAO" & _
                  " WHERE CD_FORNECEDOR = " & CD_FORNECEDOR
        SEQ_AUX = DBQuery_ValorUnico(SqlText)

        For iCont = 0 To grdProcuracao.Rows.Count - 1
            If objGrid_Valor(grdProcuracao, cnt_GridProcuracao_IC_CONTROLE, iCont) = "S" Then
                If NVL(objGrid_Valor(grdProcuracao, cnt_GridProcuracao_SQ_PROCURACAO, iCont), 0) > 0 Then
                    SQ_PROCURACAO = objGrid_Valor(grdProcuracao, cnt_GridProcuracao_SQ_PROCURACAO, iCont)

                    SqlText = DBMontar_Update("SOF.FORNECEDOR_PROCURACAO", GerarArray("CD_FORNECEDOR_PROCURADOR", ":CD_FORNECEDOR_PROCURADOR", _
                                                                                      "DT_VALIDADE", ":DT_VALIDADE"), _
                                                                           GerarArray("SQ_PROCURACAO", ":SQ_PROCURACAO", "AND", _
                                                                                      "CD_FORNECEDOR", ":CD_FORNECEDOR"))
                Else
                    SEQ_AUX = SEQ_AUX + 1
                    SQ_PROCURACAO = SEQ_AUX

                    SqlText = DBMontar_Insert("SOF.FORNECEDOR_PROCURACAO", TipoCampoFixo.DadoCriacao, _
                                                                           "CD_FORNECEDOR_PROCURADOR", ":CD_FORNECEDOR_PROCURADOR", _
                                                                           "DT_VALIDADE", ":DT_VALIDADE", _
                                                                           "SQ_PROCURACAO", ":SQ_PROCURACAO", _
                                                                           "CD_FORNECEDOR", ":CD_FORNECEDOR")
                End If

                If Not DBExecutar(SqlText, _
                                  DBParametro_Montar("CD_FORNECEDOR_PROCURADOR", objGrid_Valor(grdProcuracao, cnt_GridProcuracao_CD_PROCURADOR, iCont)), _
                                  DBParametro_Montar("DT_VALIDADE", Date_to_Oracle(objGrid_Valor(grdProcuracao, cnt_GridProcuracao_DT_VALIDADE, iCont))), _
                                  DBParametro_Montar("SQ_PROCURACAO", SQ_PROCURACAO), _
                                  DBParametro_Montar("CD_FORNECEDOR", CD_FORNECEDOR)) Then GoTo Erro
            End If
        Next

        If tabGeral.Tabs(tabControlColig.Tab.Index).Visible Then
            '>> Controlador
            SqlText = "SELECT NVL(MAX(SQ_FORN_CONTROLADOR), 0)" & _
                      " FROM SOF.FORNECEDOR_CONTROLADOR" & _
                      " WHERE CD_FORNECEDOR = " & CD_FORNECEDOR
            SEQ_AUX = DBQuery_ValorUnico(SqlText)

            For iCont = 0 To grdControlador.Rows.Count - 1
                If objGrid_Valor(grdControlador, cnt_GridControlador_IC_CONTROLE, iCont) = "S" Then
                    If NVL(objGrid_Valor(grdControlador, cnt_GridControlador_SQ_FORN_CONTROLADOR, iCont), 0) > 0 Then
                        SQ_FORN_CONTROLADOR = objGrid_Valor(grdControlador, cnt_GridControlador_SQ_FORN_CONTROLADOR, iCont)

                        SqlText = DBMontar_Update("SOF.FORNECEDOR_CONTROLADOR", GerarArray("NO_CONTROLADOR", ":NO_CONTROLADOR", _
                                                                                           "NU_CGC_CPF", ":NU_CGC_CPF", _
                                                                                           "NU_RG", ":NU_RG"), _
                                                                                GerarArray("SQ_FORN_CONTROLADOR", ":SQ_FORN_CONTROLADOR", "AND", _
                                                                                           "CD_FORNECEDOR", ":CD_FORNECEDOR"))
                    Else
                        SEQ_AUX = SEQ_AUX + 1
                        SQ_FORN_CONTROLADOR = SEQ_AUX

                        SqlText = DBMontar_Insert("SOF.FORNECEDOR_CONTROLADOR", TipoCampoFixo.DadoCriacao, _
                                                                                "NO_CONTROLADOR", ":NO_CONTROLADOR", _
                                                                                "NU_CGC_CPF", ":NU_CGC_CPF", _
                                                                                "NU_RG", ":NU_RG", _
                                                                                "SQ_FORN_CONTROLADOR", ":SQ_FORN_CONTROLADOR", _
                                                                                "CD_FORNECEDOR", ":CD_FORNECEDOR")
                    End If

                    If Not DBExecutar(SqlText, _
                                      DBParametro_Montar("NO_CONTROLADOR", Trim(objGrid_Valor(grdControlador, cnt_GridControlador_NO_CONTROLADOR, iCont))), _
                                      DBParametro_Montar("NU_CGC_CPF", Trim(objGrid_Valor(grdControlador, cnt_GridControlador_NU_CGC_CPF, iCont))), _
                                      DBParametro_Montar("NU_RG", Trim(objGrid_Valor(grdControlador, cnt_GridControlador_NU_IDENTIDADE, iCont))), _
                                      DBParametro_Montar("SQ_FORN_CONTROLADOR", SQ_FORN_CONTROLADOR), _
                                      DBParametro_Montar("CD_FORNECEDOR", CD_FORNECEDOR)) Then GoTo Erro
                End If
            Next

            '>> Coligada
            SqlText = "SELECT NVL(MAX(SQ_FORN_COLIGADAS), 0)" & _
                      " FROM SOF.FORNECEDOR_COLIGADAS" & _
                      " WHERE CD_FORNECEDOR = " & CD_FORNECEDOR
            SEQ_AUX = DBQuery_ValorUnico(SqlText)

            For iCont = 0 To grdColigada.Rows.Count - 1
                If objGrid_Valor(grdColigada, cnt_GridColigada_IC_CONTROLE, iCont) = "S" Then
                    If NVL(objGrid_Valor(grdColigada, cnt_GridColigada_SQ_FORN_COLIGADAS, iCont), 0) > 0 Then
                        SQ_FORN_COLIGADAS = objGrid_Valor(grdColigada, cnt_GridColigada_SQ_FORN_COLIGADAS, iCont)

                        SqlText = DBMontar_Update("SOF.FORNECEDOR_COLIGADAS", GerarArray("NO_EMPRESA", ":NO_EMPRESA", _
                                                                                         "DS_RAMO_ATIVIDADE", ":DS_RAMO_ATIVIDADE", _
                                                                                         "NU_CGC", ":NU_CGC"), _
                                                                              GerarArray("SQ_FORN_COLIGADAS", ":SQ_FORN_COLIGADAS", "AND", _
                                                                                         "CD_FORNECEDOR", ":CD_FORNECEDOR"))
                    Else
                        SEQ_AUX = SEQ_AUX + 1
                        SQ_FORN_COLIGADAS = SEQ_AUX

                        SqlText = DBMontar_Insert("SOF.FORNECEDOR_COLIGADAS", TipoCampoFixo.DadoCriacao, _
                                                                              "NO_EMPRESA", ":NO_EMPRESA", _
                                                                              "DS_RAMO_ATIVIDADE", ":DS_RAMO_ATIVIDADE", _
                                                                              "NU_CGC", ":NU_CGC", _
                                                                              "SQ_FORN_COLIGADAS", ":SQ_FORN_COLIGADAS", _
                                                                              "CD_FORNECEDOR", ":CD_FORNECEDOR")
                    End If

                    If Not DBExecutar(SqlText, _
                                      DBParametro_Montar("NO_EMPRESA", Trim(objGrid_Valor(grdColigada, cnt_GridColigada_NomeEmpresa, iCont))), _
                                      DBParametro_Montar("DS_RAMO_ATIVIDADE", Trim("" & objGrid_Valor(grdColigada, cnt_GridColigada_NomeEmpresa, iCont))), _
                                      DBParametro_Montar("NU_CGC", objGrid_Valor(grdColigada, cnt_GridColigada_CPF_CGC, iCont)), _
                                      DBParametro_Montar("SQ_FORN_COLIGADAS", SQ_FORN_COLIGADAS), _
                                      DBParametro_Montar("CD_FORNECEDOR", CD_FORNECEDOR)) Then GoTo Erro
                End If
            Next
        Else
            SqlText = "DELETE FROM SOF.FORNECEDOR_CONTROLADOR WHERE CD_FORNECEDOR = " & CD_FORNECEDOR
            If Not DBExecutar(SqlText) Then GoTo Erro
            SqlText = "DELETE FROM SOF.FORNECEDOR_COLIGADAS WHERE CD_FORNECEDOR = " & CD_FORNECEDOR
            If Not DBExecutar(SqlText) Then GoTo Erro
        End If

        '>> Referência Bancária
        SqlText = "SELECT NVL(MAX(SQ_FORN_REF_BANCO), 0)" & _
                  " FROM SOF.FORNECEDOR_REFERENCIA_BANCO" & _
                  " WHERE CD_FORNECEDOR = " & CD_FORNECEDOR
        SEQ_AUX = DBQuery_ValorUnico(SqlText)

        For iCont = 0 To grdReferenciaBancaria.Rows.Count - 1
            If objGrid_Valor(grdReferenciaBancaria, cnt_GridReferenciaBancaria_IC_CONTROLE, iCont) = "S" Then
                If NVL(objGrid_Valor(grdReferenciaBancaria, cnt_GridReferenciaBancaria_SQ_FORN_REF_BANCO, iCont), 0) > 0 Then
                    SQ_FORN_REF_BANCO = objGrid_Valor(grdReferenciaBancaria, cnt_GridReferenciaBancaria_SQ_FORN_REF_BANCO, iCont)

                    SqlText = DBMontar_Update("SOF.FORNECEDOR_REFERENCIA_BANCO", GerarArray("NU_BANCO", ":NU_BANCO", _
                                                                                            "NO_BANCO", ":NO_BANCO", _
                                                                                            "CD_AGENCIA", ":CD_AGENCIA", _
                                                                                            "NU_CONTA_CORRENTE", ":NU_CONTA_CORRENTE", _
                                                                                            "NO_GERENTE", ":NO_GERENTE", _
                                                                                            "NU_TELEFONE", ":NU_TELEFONE"), _
                                                                                 GerarArray("SQ_FORN_REF_BANCO", ":SQ_FORN_REF_BANCO", "AND", _
                                                                                            "CD_FORNECEDOR", ":CD_FORNECEDOR"))
                Else
                    SEQ_AUX = SEQ_AUX + 1
                    SQ_FORN_REF_BANCO = SEQ_AUX

                    SqlText = DBMontar_Insert("SOF.FORNECEDOR_REFERENCIA_BANCO", TipoCampoFixo.DadoCriacao, _
                                                                                 "NU_BANCO", ":NU_BANCO", _
                                                                                 "NO_BANCO", ":NO_BANCO", _
                                                                                 "CD_AGENCIA", ":CD_AGENCIA", _
                                                                                 "NU_CONTA_CORRENTE", ":NU_CONTA_CORRENTE", _
                                                                                 "NO_GERENTE", ":NO_GERENTE", _
                                                                                 "NU_TELEFONE", ":NU_TELEFONE", _
                                                                                 "SQ_FORN_REF_BANCO", ":SQ_FORN_REF_BANCO", _
                                                                                 "CD_FORNECEDOR", ":CD_FORNECEDOR")
                End If

                If Not DBExecutar(SqlText, _
                                  DBParametro_Montar("NU_BANCO", NULLIf(objGrid_Valor(grdReferenciaBancaria, cnt_GridReferenciaBancaria_NrBanco, iCont, ""), "")), _
                                  DBParametro_Montar("NO_BANCO", NULLIf(objGrid_Valor(grdReferenciaBancaria, cnt_GridReferenciaBancaria_NomeBanco, iCont), "")), _
                                  DBParametro_Montar("CD_AGENCIA", NULLIf(objGrid_Valor(grdReferenciaBancaria, cnt_GridReferenciaBancaria_NrAgencia, iCont, ""), "")), _
                                  DBParametro_Montar("NU_CONTA_CORRENTE", NULLIf(objGrid_Valor(grdReferenciaBancaria, cnt_GridReferenciaBancaria_NrContaCorrente, iCont, ""), "")), _
                                  DBParametro_Montar("NO_GERENTE", NULLIf(objGrid_Valor(grdReferenciaBancaria, cnt_GridReferenciaBancaria_NomeGerente, iCont, ""), "")), _
                                  DBParametro_Montar("NU_TELEFONE", NULLIf(objGrid_Valor(grdReferenciaBancaria, cnt_GridReferenciaBancaria_NrTelefone, iCont, ""), "")), _
                                  DBParametro_Montar("SQ_FORN_REF_BANCO", SQ_FORN_REF_BANCO), _
                                  DBParametro_Montar("CD_FORNECEDOR", CD_FORNECEDOR)) Then GoTo Erro
            End If
        Next

        '>> Fazenda
        For iCont = 0 To grdFazenda.Rows.Count - 1
            SqlText = DBMontar_SP("SOF.INCLUI_FAZENDA", False, ":CDFORN", ":SEQ", ":NOFAZ", ":DSEND", ":CDMUNIC", _
                                                               ":NUCEP", ":QTAREACACAU", ":QTAREACLONADA", ":QTPROD", _
                                                               ":DSDIVERSIDADE", ":MANUT")

            If Not DBExecutar(SqlText, _
                              DBParametro_Montar("CDFORN", CD_FORNECEDOR), _
                              DBParametro_Montar("SEQ", NVL(objGrid_Valor(grdFazenda, cnt_GridFazenda_SQ_FAZENDA, iCont), 0)), _
                              DBParametro_Montar("NOFAZ", objGrid_Valor(grdFazenda, cnt_GridFazenda_NomeFazenda, iCont)), _
                              DBParametro_Montar("DSEND", objGrid_Valor(grdFazenda, cnt_GridFazenda_Endereco, iCont)), _
                              DBParametro_Montar("CDMUNIC", objGrid_Valor(grdFazenda, cnt_GridFazenda_CD_MUNICIPIO, iCont)), _
                              DBParametro_Montar("NUCEP", NULLIf(Trim("" & objGrid_Valor(grdFazenda, cnt_GridFazenda_CEP, iCont)), "")), _
                              DBParametro_Montar("QTAREACACAU", objGrid_Valor(grdFazenda, cnt_GridFazenda_AreaCacau, iCont)), _
                              DBParametro_Montar("QTAREACLONADA", objGrid_Valor(grdFazenda, cnt_GridFazenda_AreaClonada, iCont)), _
                              DBParametro_Montar("QTPROD", objGrid_Valor(grdFazenda, cnt_GridFazenda_ProducaoCacau, iCont)), _
                              DBParametro_Montar("DSDIVERSIDADE", NULLIf(Trim("" & objGrid_Valor(grdFazenda, cnt_GridFazenda_DiversidadesCulturais, iCont)), ""), , , 300), _
                              DBParametro_Montar("MANUT", IIf(CampoNulo(objGrid_Valor(grdFazenda, cnt_GridFazenda_SQ_FAZENDA, iCont)), "I", "A"))) Then GoTo Erro

            If CampoNulo(objGrid_Valor(grdFazenda, cnt_GridFazenda_SQ_FAZENDA, iCont)) Then
                Historico_Fornecedor(Tipo_Historico_Fornecedor.HFInclusaoFazenda, CD_FORNECEDOR, txtRazaoSocial.Text)
            Else
                Historico_Fornecedor(Tipo_Historico_Fornecedor.HFAlteracaoFazenda, CD_FORNECEDOR, txtRazaoSocial.Text)
            End If
        Next

        '>> Bem
        For iCont = 0 To grdBem.Rows.Count - 1
            If objGrid_Valor(grdBem, cnt_GridBem_IC_CONTROLE, iCont) = "S" Then
                If NVL(objGrid_Valor(grdBem, cnt_GridBem_CD_MUNICIPIO, iCont), 0) > 0 Then
                    UF = DBQuery_ValorUnico("SELECT CD_UF FROM SOF.MUNICIPIO" & _
                                            " WHERE CD_MUNICIPIO = " & objGrid_Valor(grdBem, cnt_GridBem_CD_MUNICIPIO, iCont))
                Else
                    UF = ""
                End If

                If NVL(objGrid_Valor(grdBem, cnt_GridBem_SQ_BENS, iCont), 0) > 0 Then
                    SQ_BENS = objGrid_Valor(grdBem, cnt_GridBem_SQ_BENS, iCont)

                    SqlText = DBMontar_Update("SOF.BENS", GerarArray("CD_BENS_TIPO", ":CD_BENS_TIPO", _
                                                                     "VL_BEM", ":VL_BEM", _
                                                                     "DS_BEM", ":DS_BEM", _
                                                                     "DS_IDENTIFICACAO", ":DS_IDENTIFICACAO", _
                                                                     "CD_UF_LOCALIZACAO", ":CD_UF_LOCALIZACAO", _
                                                                     "CD_MUNICIPIO_LOCALIZACAO", ":CD_MUNICIPIO_LOCALIZACAO", _
                                                                     "QT_AREA_TOTAL", ":QT_AREA_TOTAL", _
                                                                     "QT_AREA_CULTIVADA", ":QT_AREA_CULTIVADA", _
                                                                     "QT_PRODUCAO", ":QT_PRODUCAO", _
                                                                     "DS_ENDERECO", ":DS_ENDERECO"), _
                                                          GerarArray("SQ_BENS", ":SQ_BENS"))
                Else
                    SQ_BENS = DBNovaSequence("SOF.SQ_BENS")

                    SqlText = DBMontar_Insert("SOF.BENS", TipoCampoFixo.DadoCriacao, _
                                                          "CD_BENS_TIPO", ":CD_BENS_TIPO", _
                                                          "VL_BEM", ":VL_BEM", _
                                                          "DS_BEM", ":DS_BEM", _
                                                          "DS_IDENTIFICACAO", ":DS_IDENTIFICACAO", _
                                                          "CD_UF_LOCALIZACAO", ":CD_UF_LOCALIZACAO", _
                                                          "CD_MUNICIPIO_LOCALIZACAO", ":CD_MUNICIPIO_LOCALIZACAO", _
                                                          "QT_AREA_TOTAL", ":QT_AREA_TOTAL", _
                                                          "QT_AREA_CULTIVADA", ":QT_AREA_CULTIVADA", _
                                                          "QT_PRODUCAO", ":QT_PRODUCAO", _
                                                          "DS_ENDERECO", ":DS_ENDERECO", _
                                                          "SQ_BENS", ":SQ_BENS")
                End If

                If Not DBExecutar(SqlText, _
                                  DBParametro_Montar("CD_BENS_TIPO", Trim(objGrid_Valor(grdBem, cnt_GridBem_CD_BENS_TIPO, iCont))), _
                                  DBParametro_Montar("VL_BEM", Trim(objGrid_Valor(grdBem, cnt_GridBem_ValorBem, iCont))), _
                                  DBParametro_Montar("DS_BEM", Trim(objGrid_Valor(grdBem, cnt_GridBem_DescricaoBem, iCont))), _
                                  DBParametro_Montar("DS_IDENTIFICACAO", Trim(objGrid_Valor(grdBem, cnt_GridBem_IdentificacaoBem, iCont, ""))), _
                                  DBParametro_Montar("CD_UF_LOCALIZACAO", NULLIf(UF, "")), _
                                  DBParametro_Montar("CD_MUNICIPIO_LOCALIZACAO", NULLIf(NVL(objGrid_Valor(grdBem, cnt_GridBem_CD_MUNICIPIO, iCont), 0), 0)), _
                                  DBParametro_Montar("QT_AREA_TOTAL", txtBem_AreaTotal.Value), _
                                  DBParametro_Montar("QT_AREA_CULTIVADA", txtBem_AreaCultivada.Value), _
                                  DBParametro_Montar("QT_PRODUCAO", txtBem_AreaCultivada.Value), _
                                  DBParametro_Montar("DS_ENDERECO", NULLIf(objGrid_Valor(grdBem, cnt_GridBem_Endereco, iCont, ""), "")), _
                                  DBParametro_Montar("SQ_BENS", SQ_BENS)) Then GoTo Erro

                '> Associa ao fornecedor
                SqlText = "SELECT COUNT(*) FROM SOF.FORNECEDOR_BENS" & _
                          " WHERE CD_FORNECEDOR = " & CD_FORNECEDOR & _
                            " AND SQ_BENS = " & SQ_BENS

                If DBQuery_ValorUnico(SqlText) = 0 Then
                    SqlText = DBMontar_Insert("SOF.FORNECEDOR_BENS", TipoCampoFixo.DadoCriacao, _
                                                                     "CD_FORNECEDOR", ":CD_FORNECEDOR", _
                                                                     "SQ_BENS", ":SQ_BENS")

                    If Not DBExecutar(SqlText, DBParametro_Montar("CD_FORNECEDOR", CD_FORNECEDOR), _
                                               DBParametro_Montar("SQ_BENS", SQ_BENS)) Then GoTo Erro
                End If
            End If
        Next

        If tabGeral.Tabs(tabSocio.Tab.Index).Visible Then
            '>> Sócio
            For iCont = 0 To grdSocio.Rows.Count - 1
                If objGrid_Valor(grdSocio, cnt_GridSocio_IC_CONTROLE, iCont) = "S" Then
                    If NVL(objGrid_Valor(grdSocio, cnt_GridSocio_CD_MUNICIPIO, iCont), 0) > 0 Then
                        UF = DBQuery_ValorUnico("SELECT CD_UF FROM SOF.MUNICIPIO" & _
                                                " WHERE CD_MUNICIPIO = " & objGrid_Valor(grdSocio, cnt_GridSocio_CD_MUNICIPIO, iCont))
                    Else
                        UF = ""
                    End If

                    If NVL(objGrid_Valor(grdSocio, cnt_GridSocio_SQ_FORNECEDOR_PESSOA, iCont), 0) > 0 Then
                        SQ_FORNECEDOR_PESSOA = objGrid_Valor(grdSocio, cnt_GridSocio_SQ_FORNECEDOR_PESSOA, iCont)

                        SqlText = DBMontar_Update("SOF.FORNECEDOR_PESSOA", GerarArray("NO_FORNECEDOR_PESSOA", ":NO_FORNECEDOR_PESSOA", _
                                                                                      "NU_CGC_CPF", ":NU_CGC_CPF", _
                                                                                      "IC_FORNECEDOR", ":IC_FORNECEDOR", _
                                                                                      "CD_TIPO_FORNECEDOR_PESSOA", ":CD_TIPO_FORNECEDOR_PESSOA", _
                                                                                      "DS_EMAIL", ":DS_EMAIL", _
                                                                                      "NU_TELEFONE", ":NU_TELEFONE", _
                                                                                      "CD_UF", ":CD_UF", _
                                                                                      "CD_MUNICIPIO", ":CD_MUNICIPIO", _
                                                                                      "DS_ENDERECO", ":DS_ENDERECO"), _
                                                                           GerarArray("SQ_FORNECEDOR_PESSOA", ":SQ_FORNECEDOR_PESSOA", "AND", _
                                                                                      "CD_FORNECEDOR", ":CD_FORNECEDOR"))
                    Else
                        SQ_FORNECEDOR_PESSOA = DBNovaSequence("SOF.SQ_SOCIO_FORNECEDOR")

                        SqlText = DBMontar_Insert("SOF.FORNECEDOR_PESSOA", TipoCampoFixo.DadoCriacao, _
                                                                           "NO_FORNECEDOR_PESSOA", ":NO_FORNECEDOR_PESSOA", _
                                                                           "NU_CGC_CPF", ":NU_CGC_CPF", _
                                                                           "IC_FORNECEDOR", ":IC_FORNECEDOR", _
                                                                           "CD_TIPO_FORNECEDOR_PESSOA", ":CD_TIPO_FORNECEDOR_PESSOA", _
                                                                           "DS_EMAIL", ":DS_EMAIL", _
                                                                           "NU_TELEFONE", ":NU_TELEFONE", _
                                                                           "CD_UF", ":CD_UF", _
                                                                           "CD_MUNICIPIO", ":CD_MUNICIPIO", _
                                                                           "DS_ENDERECO", ":DS_ENDERECO", _
                                                                           "SQ_FORNECEDOR_PESSOA", ":SQ_FORNECEDOR_PESSOA", _
                                                                           "CD_FORNECEDOR", ":CD_FORNECEDOR")
                    End If

                    If Not DBExecutar(SqlText, _
                                      DBParametro_Montar("NO_FORNECEDOR_PESSOA", Trim(objGrid_Valor(grdSocio, cnt_GridSocio_NomeSocio, iCont))), _
                                      DBParametro_Montar("NU_CGC_CPF", Trim(objGrid_Valor(grdSocio, cnt_GridSocio_CPF, iCont))), _
                                      DBParametro_Montar("IC_FORNECEDOR", "N"), _
                                      DBParametro_Montar("CD_TIPO_FORNECEDOR_PESSOA", objGrid_Valor(grdSocio, cnt_GridSocio_CD_TIPO_FORNECEDOR_PESSOA, iCont)), _
                                      DBParametro_Montar("DS_EMAIL", NULLIf(Trim(objGrid_Valor(grdSocio, cnt_GridSocio_EMail, iCont, "")), "")), _
                                      DBParametro_Montar("NU_TELEFONE", NULLIf(objGrid_Valor(grdSocio, cnt_GridSocio_Telefone, iCont, ""), "")), _
                                      DBParametro_Montar("CD_UF", NULLIf(Trim(UF), "")), _
                                      DBParametro_Montar("CD_MUNICIPIO", NULLIf(NVL(objGrid_Valor(grdSocio, cnt_GridSocio_CD_MUNICIPIO, iCont), 0), 0)), _
                                      DBParametro_Montar("DS_ENDERECO", NULLIf(NVL(objGrid_Valor(grdSocio, cnt_GridSocio_Endereco, iCont, ""), 0), "")), _
                                      DBParametro_Montar("SQ_FORNECEDOR_PESSOA", SQ_FORNECEDOR_PESSOA), _
                                      DBParametro_Montar("CD_FORNECEDOR", CD_FORNECEDOR)) Then GoTo Erro
                End If
            Next
        Else
            SqlText = "DELETE FROM SOF.FORNECEDOR_PESSOA WHERE CD_FORNECEDOR = " & CD_FORNECEDOR
            If Not DBExecutar(SqlText) Then GoTo Erro
        End If

        '>> Observação
        If txtObservacao.Tag = 1 Then
            If Trim(txtObservacao.Text) = "" Then
                SqlText = "DELETE FROM SOF.FORNECEDOR_OBS" & _
                          " WHERE CD_FORNECEDOR = " & CD_FORNECEDOR
                If Not DBExecutar(SqlText) Then GoTo Erro
            Else
                SqlText = "SELECT COUNT(*) FROM SOF.FORNECEDOR_OBS" & _
                          " WHERE CD_FORNECEDOR = " & CD_FORNECEDOR

                If DBQuery_ValorUnico(SqlText) = 0 Then
                    SqlText = DBMontar_Insert("SOF.FORNECEDOR_OBS", TipoCampoFixo.DadoCriacao, _
                                                                    "DS_OBS", ":DS_OBS", _
                                                                    "CD_FORNECEDOR", ":CD_FORNECEDOR")
                Else
                    SqlText = DBMontar_Update("SOF.FORNECEDOR_OBS", GerarArray("DS_OBS", ":DS_OBS"), _
                                                                    GerarArray("CD_FORNECEDOR", ":CD_FORNECEDOR"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("DS_OBS", Trim(txtObservacao.Text), , , 250), _
                                           DBParametro_Montar("CD_FORNECEDOR", CD_FORNECEDOR)) Then GoTo Erro
            End If
        End If

        If Not DBExecutarTransacao() Then GoTo Erro

        Msg_Mensagem("Gravação Efetuada")

        Fechar()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Function Gravar_Validar_DadosFornecedor() As Boolean
        Dim UF As String

        If optTipoPessoa.Value = "F" Then
            If Not ComboBox_LinhaSelecionada(cboTipoPessoa) Then
                Msg_Mensagem("Informe o tipo de pessoa desse fornecedor")
                GoTo Sair
            End If
        End If
        If Trim(txtRazaoSocial.Text) = "" Then
            Msg_Mensagem("Informe a razão social desse fornecedor")
            GoTo Sair
        End If
        If Not ComboBox_LinhaSelecionada(cboTipoPessoa) Then
            Msg_Mensagem("Selecione um tipo de pessoa")
            GoTo Sair
        End If
        If Trim(txtEndereco1.Text) = "" Then
            Msg_Mensagem("Informe o endereço para o endereço principal desse fornecedor")
            GoTo Sair
        End If
        If Trim(txtBairro1.Text) = "" Then
            Msg_Mensagem("Informe o bairro para o endereço principal desse fornecedor")
            GoTo Sair
        End If
        If Pesq_Municipio_EndPrincipal.Codigo = 0 Then
            Msg_Mensagem("Informe o município para o endereço principal desse fornecedor")
            GoTo Sair
        End If
        If Trim(txtCEP1.Text) = "" Then
            Msg_Mensagem("Informe o C.E.P. para o endereço principal desse fornecedor")
            GoTo Sair
        End If

        UF = DBQuery_ValorUnico("SELECT CD_UF FROM SOF.MUNICIPIO " & _
                                " WHERE CD_MUNICIPIO = " & Pesq_Municipio_EndPrincipal.Codigo)

        If optTipoPessoa.Value = "J" Then
            If Not Valida_CNPJ(SoNumero(txtCPF_CNPJ.Value)) Then
                Msg_Mensagem("O número do C.N.P.J. informado para o fornecedor está inválido.")
                GoTo Sair
            End If
            If Trim(txtInscricaoEstadual.Text) <> "" Then
                If Not Valida_InscricaoEstadual(UF, txtInscricaoEstadual.Text) Then
                    Msg_Mensagem("O número da Inscrição Estadual informada para o fornecedor está inválida.")
                    GoTo Sair
                End If
            End If
        Else
            If Not Valida_CPF(SoNumero(NVL(txtCPF_CNPJ.Value, ""))) Then
                Msg_Mensagem("O número do C.P.F. informado para o fornecedor está inválido.")
                GoTo Sair
            End If
        End If
        If Not ComboBox_LinhaSelecionada(cboFunrural) Then
            Msg_Mensagem("Informe o tipo de Funrural desse fornecedor")
            GoTo Sair
        End If
        If Not ComboBox_LinhaSelecionada(cboFilial) Then
            Msg_Mensagem("Favor selecionar a filial de origem desse fornecedor.")
            GoTo Sair
        End If
        If NVL(txtAddressNumber.Value, 0) = 0 Then
            Msg_Mensagem("Favor informar o Address Number desse Fornecedor.")
            GoTo Sair
        End If
        If cboTipoPessoa.SelectedValue <> cnt_TipoPessoa_IMPORTADO And Not Ambiente_Desenvolvimento() Then
            Dim SqlText As String

            SqlText = "SELECT COUNT(*) FROM ILH_OW.F0101 AB" & _
                      " WHERE AB.ABAN8 = " & txtAddressNumber.Value & _
                        " AND AB.ABTAX = " & QuotedStr(SoNumero(txtCPF_CNPJ.Value))

            If DBQuery_ValorUnico(SqlText) = 0 Then
                Msg_Mensagem("O Address Number informado para esse Fornecedor está inválido.")

                If Not SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_PodeAlterarTodoCampoCadFornecedor) Then
                    txtAddressNumber.Focus()
                    GoTo Sair
                End If
            End If
        End If
        If chkRepassador.Checked Then
            If Pesq_Repassador.Codigo = 0 Then
                Msg_Mensagem("Favor informar um repassador válido.")
                GoTo Sair
            End If
        End If
        If Address_Number_Cadastrado() Then
            Msg_Mensagem("Address Number já cadastrado para outro fornecedor.")
            GoTo Sair
        End If
        If CGC_CPF_Cadastrado(CPF_CNPJ_Seq) Then
            Msg_Mensagem("CPF/CGC já cadastrado.")
            GoTo Sair
        End If
        If Not ComboBox_LinhaSelecionada(cboTipoPessoaTributacao) Then
            Msg_Mensagem("Favor selecionar um tipo de Tributação para a Pessoa.")
            GoTo Sair
        End If

        Return True

Sair:
        Return False
    End Function

    Private Function Gravar_Validar_Procuracao() As Boolean
        Dim iCont_01 As Integer
        Dim iCont_02 As Integer

        'Valida a duplicidade de informações
        For iCont_01 = 0 To grdProcuracao.Rows.Count - 1
            For iCont_02 = 0 To grdProcuracao.Rows.Count - 1
                If objGrid_Valor(grdProcuracao, cnt_GridProcuracao_CD_PROCURADOR, iCont_01, 0) = _
                   objGrid_Valor(grdProcuracao, cnt_GridProcuracao_CD_PROCURADOR, iCont_02, 0) And _
                   objGrid_Valor(grdProcuracao, cnt_GridProcuracao_DT_VALIDADE, iCont_01, Now.Date) = _
                   objGrid_Valor(grdProcuracao, cnt_GridProcuracao_DT_VALIDADE, iCont_02, Now.Date) And _
                   objGrid_Valor(grdProcuracao, cnt_GridProcuracao_IC_VALIDADO, iCont_01, "N") <> "S" And _
                   objGrid_Valor(grdProcuracao, cnt_GridProcuracao_IC_VALIDADO, iCont_02, "N") <> "S" And _
                   iCont_01 <> iCont_02 Then
                    If Msg_Perguntar("A procuração de " & _
                                     objGrid_Valor(grdProcuracao, cnt_GridProcuracao_NO_PROCURADOR, iCont_01) & _
                                     ", com a data de validade para " & _
                                     objGrid_Valor(grdProcuracao, cnt_GridProcuracao_DT_VALIDADE, iCont_01) & _
                                     "está informada mais de uma vez." & _
                                     " Continuar com a gravação das informações do fornecedor?") Then
                        grdProcuracao.Rows(iCont_01).Cells(cnt_GridProcuracao_IC_VALIDADO).Value = "S"
                        grdProcuracao.Rows(iCont_02).Cells(cnt_GridProcuracao_IC_VALIDADO).Value = "S"
                    Else
                        GoTo Sair
                    End If
                End If
            Next
        Next

        'Valida o formato e as informações obrigatórias
        For iCont_01 = 0 To grdProcuracao.Rows.Count - 1
            If Trim(objGrid_Valor(grdProcuracao, cnt_GridProcuracao_NO_PROCURADOR, iCont_01)) = "" Then
                Msg_Mensagem("É preciso informar o nome de todos os procuradores")
                GoTo Sair
            End If
            If Not IsDate(objGrid_Valor(grdProcuracao, cnt_GridProcuracao_DT_VALIDADE, iCont_01)) Then
                Msg_Mensagem("É preciso informar a data de validade para todas as procurações")
                GoTo Sair
            End If
        Next

        Return True

Sair:
        Return False
    End Function

    Private Function Gravar_Validar_Controlador() As Boolean
        Dim iCont_01 As Integer
        Dim iCont_02 As Integer

        'Valida a duplicidade deinformações
        For iCont_01 = 0 To grdControlador.Rows.Count - 1
            For iCont_02 = 0 To grdControlador.Rows.Count - 1
                If objGrid_Valor(grdControlador, cnt_GridControlador_NU_CGC_CPF, iCont_01, "") = _
                   objGrid_Valor(grdControlador, cnt_GridControlador_NU_CGC_CPF, iCont_02, "") And _
                   NVL(objGrid_Valor(grdControlador, cnt_GridControlador_IC_VALIDADO, iCont_01), "N") <> "S" And _
                   NVL(objGrid_Valor(grdControlador, cnt_GridControlador_IC_VALIDADO, iCont_02), "N") <> "S" And _
                   iCont_01 <> iCont_02 Then
                    If Msg_Perguntar("O controlador/acionista " & _
                                     objGrid_Valor(grdControlador, cnt_GridControlador_NO_CONTROLADOR, iCont_01) & _
                                     "está informado mais de uma vez." & _
                                     " Continuar com a gravação das informações do fornecedor?") Then
                        grdControlador.Rows(iCont_01).Cells(cnt_GridControlador_IC_VALIDADO).Value = "S"
                        grdControlador.Rows(iCont_02).Cells(cnt_GridControlador_IC_VALIDADO).Value = "S"
                    Else
                        GoTo Sair
                    End If
                End If
            Next
        Next

        'Valida o formato e as informações obrigatórias
        For iCont_01 = 0 To grdControlador.Rows.Count - 1
            If Trim(objGrid_Valor(grdControlador, cnt_GridControlador_NO_CONTROLADOR, iCont_01)) = "" Then
                Msg_Mensagem("Informe o nome todos os controladores/acionistas")
                GoTo Sair
            End If
            If Trim(objGrid_Valor(grdControlador, cnt_GridControlador_NU_CGC_CPF, iCont_01)) = "" Then
                Msg_Mensagem("Informe um número de C.P.F./C.N.P.J. válido para todas os controladores/acionistas")
                GoTo Sair
            Else
                If Not Valida_CNPJ(SoNumero(objGrid_Valor(grdControlador, cnt_GridControlador_NU_CGC_CPF, iCont_01))) And _
                   Not Valida_CPF(SoNumero(objGrid_Valor(grdControlador, cnt_GridControlador_NU_CGC_CPF, iCont_01))) Then
                    Msg_Mensagem("Informe um número de C.P.F./C.N.P.J. válido para todas os controladores/acionistas")
                    GoTo Sair
                End If
            End If
        Next

        Return True

Sair:
        Return False
    End Function

    Private Function Gravar_Validar_Coligado() As Boolean
        Dim iCont_01 As Integer
        Dim iCont_02 As Integer

        'Valida a duplicidade de informações
        For iCont_01 = 0 To grdColigada.Rows.Count - 1
            For iCont_02 = 0 To grdColigada.Rows.Count - 1
                If objGrid_Valor(grdColigada, cnt_GridColigada_CPF_CGC, iCont_01, "") = _
                   objGrid_Valor(grdColigada, cnt_GridColigada_CPF_CGC, iCont_02, "") And _
                   objGrid_Valor(grdColigada, cnt_GridColigada_IC_VALIDADO, iCont_01, "N") <> "S" And _
                   objGrid_Valor(grdColigada, cnt_GridColigada_IC_VALIDADO, iCont_02, "N") <> "S" And _
                   iCont_01 <> iCont_02 Then
                    If Msg_Perguntar("A coligada/controlada " & _
                                     objGrid_Valor(grdColigada, cnt_GridColigada_NomeEmpresa, iCont_01) & _
                                     "está informada mais de uma vez." & _
                                     " Continuar com a gravação das informações do fornecedor?") Then
                        grdColigada.Rows(iCont_01).Cells(cnt_GridColigada_IC_VALIDADO).Value = "S"
                        grdColigada.Rows(iCont_02).Cells(cnt_GridColigada_IC_VALIDADO).Value = "S"
                    Else
                        GoTo Sair
                    End If
                End If
            Next
        Next

        'Valida o formato e as informações obrigatórias
        For iCont_01 = 0 To grdColigada.Rows.Count - 1
            If Trim(objGrid_Valor(grdColigada, cnt_GridColigada_NomeEmpresa, iCont_01)) = "" Then
                Msg_Mensagem("Informe o nome todas as empresas coligadas/controladas")
                GoTo Sair
            End If
            If Trim(objGrid_Valor(grdColigada, cnt_GridColigada_CPF_CGC, iCont_01)) = "" Then
                Msg_Mensagem("Informe um número de C.N.P.J. válido para todas as coligadas/controladas")
                GoTo Sair
            Else
                If Not Valida_CNPJ(SoNumero(objGrid_Valor(grdColigada, cnt_GridColigada_CPF_CGC, iCont_01))) And _
                   Not Valida_CPF(SoNumero(objGrid_Valor(grdColigada, cnt_GridColigada_CPF_CGC, iCont_01))) Then
                    Msg_Mensagem("Informe um número de C.N.P.J. válido para todas as coligadas/controladas")
                    GoTo Sair
                End If
            End If
        Next

        Return True

Sair:
        Return False
    End Function

    Private Function Gravar_Validar_ReferenciaBancaria() As Boolean
        Dim iCont_01 As Integer
        Dim iCont_02 As Integer

        'Valida a duplicidade de informações
        For iCont_01 = 0 To grdReferenciaBancaria.Rows.Count - 1
            For iCont_02 = 0 To grdReferenciaBancaria.Rows.Count - 1
                If objGrid_Valor(grdReferenciaBancaria, cnt_GridReferenciaBancaria_NrBanco, iCont_01, 0) = _
                   objGrid_Valor(grdReferenciaBancaria, cnt_GridReferenciaBancaria_NrBanco, iCont_02, 0) And _
                   objGrid_Valor(grdReferenciaBancaria, cnt_GridReferenciaBancaria_NrAgencia, iCont_01, 0) = _
                   objGrid_Valor(grdReferenciaBancaria, cnt_GridReferenciaBancaria_NrAgencia, iCont_02, 0) And _
                   objGrid_Valor(grdReferenciaBancaria, cnt_GridReferenciaBancaria_NrContaCorrente, iCont_01, 0) = _
                   objGrid_Valor(grdReferenciaBancaria, cnt_GridReferenciaBancaria_NrContaCorrente, iCont_02, 0) And _
                   objGrid_Valor(grdReferenciaBancaria, cnt_GridReferenciaBancaria_IC_VALIDADO, iCont_01, "N") <> "S" And _
                   objGrid_Valor(grdReferenciaBancaria, cnt_GridReferenciaBancaria_IC_VALIDADO, iCont_02, "N") <> "S" And _
                   iCont_01 <> iCont_02 Then
                    If Msg_Perguntar("A referência bancária, " & _
                                     "banco " & objGrid_Valor(grdReferenciaBancaria, cnt_GridReferenciaBancaria_NomeBanco, iCont_01) & _
                                     " na agência " & objGrid_Valor(grdReferenciaBancaria, cnt_GridReferenciaBancaria_NrAgencia, iCont_01) & _
                                     " para a conta corrente " & objGrid_Valor(grdReferenciaBancaria, cnt_GridReferenciaBancaria_NrContaCorrente, iCont_01) & _
                                     ", está informada mais de uma vez." & _
                                     " Continuar com a gravação das informações do fornecedor?") Then
                        grdReferenciaBancaria.Rows(iCont_01).Cells(cnt_GridReferenciaBancaria_IC_VALIDADO).Value = "S"
                        grdReferenciaBancaria.Rows(iCont_02).Cells(cnt_GridReferenciaBancaria_IC_VALIDADO).Value = "S"
                    Else
                        GoTo Sair
                    End If
                End If
            Next
        Next

        'Valida o formato e as informações obrigatórias
        For iCont_01 = 0 To grdReferenciaBancaria.Rows.Count - 1
            If Trim(objGrid_Valor(grdReferenciaBancaria, cnt_GridReferenciaBancaria_NomeBanco, iCont_01)) = "" Then
                Msg_Mensagem("Informe o nome do banco para todas as referências bancárias")
                GoTo Sair
            End If
        Next

        Return True

Sair:
        Return False
    End Function

    Private Function Gravar_Validar_Fazenda() As Boolean
        Dim iCont_01 As Integer
        Dim iCont_02 As Integer

        'Valida a duplicidade de informações
        For iCont_01 = 0 To grdFazenda.Rows.Count - 1
            For iCont_02 = 0 To grdFazenda.Rows.Count - 1
                If objGrid_Valor(grdFazenda, cnt_GridFazenda_CD_MUNICIPIO, iCont_01, 0) = _
                   objGrid_Valor(grdFazenda, cnt_GridFazenda_CD_MUNICIPIO, iCont_02, 0) And _
                   Trim(objGrid_Valor(grdFazenda, cnt_GridFazenda_NomeFazenda, iCont_01, "")) = _
                   Trim(objGrid_Valor(grdFazenda, cnt_GridFazenda_NomeFazenda, iCont_02, "")) And _
                   objGrid_Valor(grdFazenda, cnt_GridFazenda_IC_VALIDADO, iCont_01, "N") <> "S" And _
                   objGrid_Valor(grdFazenda, cnt_GridFazenda_IC_VALIDADO, iCont_02, "N") <> "S" And _
                   iCont_01 <> iCont_02 Then
                    If Msg_Perguntar("A fazenda " & objGrid_Valor(grdFazenda, cnt_GridFazenda_NomeFazenda, iCont_01) & _
                                     " no município de " & objGrid_Valor(grdFazenda, cnt_GridFazenda_Municipio, iCont_01) & _
                                     ", está informada mais de uma vez." & _
                                     " Continuar com a gravação das informações do fornecedor?") Then
                        grdFazenda.Rows(iCont_01).Cells(cnt_GridFazenda_IC_VALIDADO).Value = "S"
                        grdFazenda.Rows(iCont_02).Cells(cnt_GridFazenda_IC_VALIDADO).Value = "S"
                    Else
                        GoTo Sair
                    End If
                End If
            Next
        Next

        'Valida o formato e as informações obrigatórias
        For iCont_01 = 0 To grdFazenda.Rows.Count - 1
            If Trim(objGrid_Valor(grdFazenda, cnt_GridFazenda_NomeFazenda, iCont_01)) = "" Then
                Msg_Mensagem("Informe o nome para todas as fazendas")
                GoTo Sair
            End If
        Next

        Return True

Sair:
        Return False
    End Function

    Private Function Gravar_Validar_Bem() As Boolean
        Dim iCont_01 As Integer
        Dim iCont_02 As Integer

        'Valida a duplicidade de informações
        For iCont_01 = 0 To grdBem.Rows.Count - 1
            For iCont_02 = 0 To grdBem.Rows.Count - 1
                If objGrid_Valor(grdBem, cnt_GridBem_CD_BENS_TIPO, iCont_01, 0) = _
                   objGrid_Valor(grdBem, cnt_GridBem_CD_BENS_TIPO, iCont_02, 0) And _
                   Trim(objGrid_Valor(grdBem, cnt_GridBem_IdentificacaoBem, iCont_01, "")) = _
                   Trim(objGrid_Valor(grdBem, cnt_GridBem_IdentificacaoBem, iCont_02, "")) And _
                   Trim(objGrid_Valor(grdBem, cnt_GridBem_DescricaoBem, iCont_01, "")) = _
                   Trim(objGrid_Valor(grdBem, cnt_GridBem_DescricaoBem, iCont_02, "")) And _
                   Trim(objGrid_Valor(grdBem, cnt_GridBem_ValorBem, iCont_01, 0)) = _
                   Trim(objGrid_Valor(grdBem, cnt_GridBem_ValorBem, iCont_02, 0)) And _
                   NVL(objGrid_Valor(grdBem, cnt_GridBem_IC_VALIDADO, iCont_01), "N") <> "S" And _
                   NVL(objGrid_Valor(grdBem, cnt_GridBem_IC_VALIDADO, iCont_02), "N") <> "S" And _
                   iCont_01 <> iCont_02 Then
                    If Msg_Perguntar("O bem " & objGrid_Valor(grdBem, cnt_GridBem_TipoBem, iCont_01) & _
                                     " - " & objGrid_Valor(grdBem, cnt_GridBem_DescricaoBem, iCont_01) & _
                                     ", está informado mais de uma vez." & _
                                     " Continuar com a gravação das informações do fornecedor?") Then
                        grdBem.Rows(iCont_01).Cells(cnt_GridBem_IC_VALIDADO).Value = "S"
                        grdBem.Rows(iCont_02).Cells(cnt_GridBem_IC_VALIDADO).Value = "S"
                    Else
                        GoTo Sair
                    End If
                End If
            Next
        Next

        'Valida o formato e as informações obrigatórias
        For iCont_01 = 0 To grdBem.Rows.Count - 1
            If NVL(objGrid_Valor(grdBem, cnt_GridBem_CD_BENS_TIPO, iCont_01), 0) = 0 Then
                Msg_Mensagem("Informe o tipo para todos os bens do fornecedor")
                GoTo Sair
            End If
            If Trim(objGrid_Valor(grdBem, cnt_GridBem_DescricaoBem, iCont_01)) = "" Then
                Msg_Mensagem("Informe a descrição para todos os bens do fornecedor")
                GoTo Sair
            End If
            If NVL(objGrid_Valor(grdBem, cnt_GridBem_ValorBem, iCont_01), 0) = 0 Then
                Msg_Mensagem("Informe o valor para todos os bens do fornecedor")
                GoTo Sair
            End If
        Next

        Return True

Sair:
        Return False
    End Function

    Private Function Gravar_Validar_Socio() As Boolean
        Dim iCont_01 As Integer
        Dim iCont_02 As Integer

        'Valida a duplicidade de informações
        For iCont_01 = 0 To grdSocio.Rows.Count - 1
            For iCont_02 = 0 To grdSocio.Rows.Count - 1
                If Trim(objGrid_Valor(grdSocio, cnt_GridSocio_CPF, iCont_01, "")) = _
                   Trim(objGrid_Valor(grdSocio, cnt_GridSocio_CPF, iCont_02, "")) And _
                   objGrid_Valor(grdSocio, cnt_GridSocio_IC_VALIDADO, iCont_01, "N") <> "S" And _
                   objGrid_Valor(grdSocio, cnt_GridSocio_IC_VALIDADO, iCont_02, "N") <> "S" And _
                   iCont_01 <> iCont_02 Then
                    If Msg_Perguntar("O sócio " & objGrid_Valor(grdSocio, cnt_GridSocio_NomeSocio, iCont_01) & _
                                     ", está informado mais de uma vez." & _
                                     " Continuar com a gravação das informações do fornecedor?") Then
                        grdSocio.Rows(iCont_01).Cells(cnt_GridSocio_IC_VALIDADO).Value = "S"
                        grdSocio.Rows(iCont_02).Cells(cnt_GridSocio_IC_VALIDADO).Value = "S"
                    Else
                        GoTo Sair
                    End If
                End If
            Next
        Next

        'Valida o formato e as informações obrigatórias
        For iCont_01 = 0 To grdSocio.Rows.Count - 1
            If NVL(objGrid_Valor(grdSocio, cnt_GridSocio_CD_TIPO_FORNECEDOR_PESSOA, iCont_01), 0) = 0 Then
                Msg_Mensagem("Informe o tipo para todos os sócios do fornecedor")
                GoTo Sair
            End If
            If Trim(objGrid_Valor(grdSocio, cnt_GridSocio_NomeSocio, iCont_01)) = "" Then
                Msg_Mensagem("Informe o nome para todos os sócios do fornecedor")
                GoTo Sair
            End If
            If Trim(objGrid_Valor(grdSocio, cnt_GridSocio_CPF, iCont_01)) = "" Then
                Msg_Mensagem("Informe um número de C.P.F. válido para todos os sócios")
                GoTo Sair
            Else
                If Not Valida_CPF(SoNumero(objGrid_Valor(grdSocio, cnt_GridSocio_CPF, iCont_01))) Then
                    Msg_Mensagem("Informe um número de C.P.F. válido para todos os sócios")
                    GoTo Sair
                End If
            End If
        Next

        Return True

Sair:
        Return False
    End Function

    Private Function Address_Number_Cadastrado() As Boolean
        Dim SqlText As String
        Dim bOk As Boolean

        bOk = False

        SqlText = DBMontar_SP("SOF.PROCURA_ADDRESS_NUMBER", False, ":CDFORN", ":CDAN", ":NOVO", ":OK")

        If Not DBExecutar(SqlText, DBParametro_Montar("CDFORN", IIf(CD_FORNECEDOR = 0, Nothing, CD_FORNECEDOR)), _
                                   DBParametro_Montar("CDAN", txtAddressNumber.Value), _
                                   DBParametro_Montar("NOVO", IIf(CD_FORNECEDOR = 0, "S", "N")), _
                                   DBParametro_Montar("OK", Nothing, , ParameterDirection.InputOutput)) Then GoTo Erro

        If DBTeveRetorno() Then
            If DBRetorno(1) = "N" Then
                bOk = True
            End If
        End If

        Return bOk

        Exit Function

Erro:
        TratarErro()
        Return False
    End Function

    Private Function CGC_CPF_Cadastrado(ByRef Seq As Long) As Boolean
        Dim bOk As Boolean
        Dim SqlText As String

        bOk = True

        If txtCPF_CNPJ.Value <> NVL(txtCPF_CNPJ.Tag, txtCPF_CNPJ.Value) Or CD_FORNECEDOR = 0 Then
            SqlText = DBMontar_SP("SOF.SP_PROCURA_CGC_CPF", False, ":CDFORN", ":CGCCPF", ":NOVO", ":SEQ")

            If Not DBExecutar(SqlText, _
                              DBParametro_Montar("CDFORN", CD_FORNECEDOR), _
                              DBParametro_Montar("CGCCPF", txtCPF_CNPJ.Text), _
                              DBParametro_Montar("NOVO", IIf(CD_FORNECEDOR = 0, "S", "N")), _
                              DBParametro_Montar("SEQ", Nothing, , ParameterDirection.InputOutput)) Then GoTo Erro

            If DBTeveRetorno() Then
                Seq = Val(DBRetorno(1))
            End If

            If Seq = 0 Then
                bOk = False
            Else
                bOk = True

                If SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_PodeAlterarTodoCampoCadFornecedor) Then
                    If Msg_Perguntar("O CPF/CGC ja foi cadastrado. Deseja cadastrar novamente ?") = True Then
                        bOk = False
                    End If
                End If
            End If
        Else
            bOk = False
        End If

        Return bOk

        Exit Function

Erro:
        TratarErro()
    End Function

    Private Sub grdFazenda_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdFazenda.AfterCellUpdate
        grdFazenda.ActiveCell.Row.Cells(cnt_GridFazenda_IC_CONTROLE).Value = "S"
    End Sub

    Private Sub grdFazenda_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdFazenda.BeforeRowsDeleted
        e.DisplayPromptMsg = False

        If Msg_Perguntar("Você deseja excluir essa fazenda do fornecedor?") Then
            Dim SqlText As String

            If NVL(e.Rows(0).Cells(cnt_GridBem_SQ_BENS).Value, 0) > 0 Then
                SqlText = "DELETE FROM SOF.FAZENDA" & _
                          " WHERE SQ_FAZENDA = " & e.Rows(0).Cells(cnt_GridFazenda_SQ_FAZENDA).Value & _
                            " AND CD_FORNECEDOR = " & CD_FORNECEDOR
                DBExecutar(SqlText)

                Historico_Fornecedor(Tipo_Historico_Fornecedor.HFExclusaoFazenda, CD_FORNECEDOR, txtRazaoSocial.Text)
            End If
        Else
            e.Cancel = True
        End If

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub txtObservacao_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtObservacao.TextChanged
        txtObservacao.Tag = 1
    End Sub

    Private Sub tabGeral_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles tabGeral.SelectedTabChanged
        Select Case e.Tab.Index
            Case tabFazenda.Tab.Index
                Historico_Fornecedor(Tipo_Historico_Fornecedor.HFConsultaFazenda, CD_FORNECEDOR, txtRazaoSocial.Text)
            Case tabObservacao.Tab.Index
                Historico_Fornecedor(Tipo_Historico_Fornecedor.HFConsultaOBS, CD_FORNECEDOR, txtRazaoSocial.Text)
        End Select
    End Sub
End Class