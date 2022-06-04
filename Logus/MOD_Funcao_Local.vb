Imports Infragistics.Win
Imports Microsoft.Win32

Module MOD_Funcao_Local
    Public oMDI As New frmMDI
    Dim FiliaisLiberadas As String

    Public Sub Main()
        'para não abri uma nova instancia do sistema
        'Dim processos() As System.Diagnostics.Process

        'processos = System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName)

        'If processos.Length > 1 Then
        '    Msg_Mensagem("O sistema ja esta aberto.")
        '    End
        'End If
        CorWindows()
        TraducaoInfragistics()
        'On Error GoTo Erro

        bBancoDados_CtrlAcesso_MultiSistema = True
        sBancoDados_OwnerPadrao = "SOF"
        sBancoDados_OwnerCtrlAcesso = "AGC"
        sBancoDados_OwnerSistemaEMail = "AGC"

        'Verifica Configuração regional
        AtualizaConfiguracao()

        If DBConectar() Then
            If Not SEC_ValidarUsuario() Then End

            'já tiver usuario é porque é desbloqueio
            If sAcesso_NomeUsuarioLogado Is Nothing Then
                Dim oData As DataTable
                Dim SqlText As String

                'Carrega Informações do usuário
                SqlText = "SELECT USR.NO_USUARIO," & _
                                 "USR.DS_EMAIL," & _
                                 "NVL(UST.DT_ULTIMO_ACESSO, TRUNC(SYSDATE)) DT_ULTIMO_ACESSO," & _
                                 "NVL(UST.IC_ATIVO, 'N') IC_ATIVO" & _
                          " FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO USR," & _
                                     sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO_SISTEMA UST" & _
                          " WHERE USR.CD_USUARIO = " & QuotedStr(sAcesso_UsuarioLogado) & _
                            " AND UST.CD_USUARIO (+) = USR.CD_USUARIO" & _
                            " AND UST.CD_SISTEMA = " & cnt_Sistema_ControleAcesso
                oData = DBQuery(SqlText)

                If objDataTable_Vazio(oData) Then
                    GoTo UsuarioSemAcesso
                Else
                    If oData.Rows(0).Item("IC_ATIVO") = "N" Then
                        GoTo UsuarioSemAcesso
                    Else
                        If DateDiff(DateInterval.Day, oData.Rows(0).Item("DT_ULTIMO_ACESSO"), Now.Date) > iAcesso_DiaSemUsoBloqueio Then
                            Msg_Mensagem("Este usuário tem mais que 30 dias que acessou este sistema, por isso o acesso do mesmo está bloqueado." & _
                                         "Favor procurar o administrador do sistema para normalizar o acesso.")
                            objData_Finalizar(oData)
                            Application.Exit()
                            Exit Sub
                        End If

                        sAcesso_NomeUsuarioLogado = oData.Rows(0).Item("NO_USUARIO")
                        sUsuario_EMail = objDataTable_LerCampo(oData.Rows(0).Item("DS_EMAIL"), "")
                    End If
                End If

                'Carrega informações de parâmetro
                oData = DBQuery("SELECT CD_FILIAL_MAE, CD_SAFRA FROM SOF.PARAMETRO")

                FilialMae = objDataTable_LerCampo(oData.Rows(0).Item("CD_FILIAL_MAE"))
                Safra = objDataTable_LerCampo(oData.Rows(0).Item("CD_SAFRA"))

                objData_Finalizar(oData)

                Sis_NomeSistema = "Logus - Sistema de Originação"
                Sis_CampoRegistro = "Logus"

                'Cria o contole de usuário ativo no banco
                DBExecutar("DELETE FROM SOF.TMP_CONECCAO")
                DBExecutar("INSERT INTO SOF.TMP_CONECCAO VALUES  (" & QuotedStr(sAcesso_UsuarioLogado) & ")")

                SqlText = DBMontar_Update(sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO_SISTEMA", GerarArray("DT_ULTIMO_ACESSO", "SYSDATE", _
                                                                                                           "DT_ENVIO_EMAIL_BLOQUEIO", ":DT_ENVIO_EMAIL_BLOQUEIO", _
                                                                                                           "DT_VERSAO_APLICACAO", ":DT_VERSAO_APLICACAO"), _
                                                                                                GerarArray("CD_USUARIO", ":CD_USUARIO", "AND", _
                                                                                                           "CD_SISTEMA", ":CD_SISTEMA"), False)
                If Not DBExecutar(SqlText, DBParametro_Montar("DT_ENVIO_EMAIL_BLOQUEIO", Nothing), _
                                           DBParametro_Montar("DT_VERSAO_APLICACAO", Date_TratarBancoDados(FileDateTime(Application.ExecutablePath)), OracleClient.OracleType.DateTime), _
                                           DBParametro_Montar("CD_USUARIO", sAcesso_UsuarioLogado), _
                                           DBParametro_Montar("CD_SISTEMA", cnt_Sistema_ControleAcesso)) Then GoTo Erro

                EMail_SuporteTecnico_Carregar()

                Dim oFormSplash As New frmConcordo
                Form_Show(Nothing, oFormSplash, True)
                Form_Close(oFormSplash)

                Dim oForm As New frmTelaInicial
                Form_Show(Nothing, oForm, True)
                Form_Close(oForm)

                oMDI.Inicializar()
                oMDI.ShowDialog()
                oMDI = Nothing

                DBDesconectar()
            End If
        End If

        Exit Sub

UsuarioSemAcesso:
        Msg_Mensagem("Usuário sem acesso ao sistema")
        Application.Exit()

        Exit Sub

Erro:
        TratarErro(, , "FUNC -> Main")
    End Sub

    Public Sub ComboBox_Carregar_Usuario(ByRef oCombo As System.Windows.Forms.ComboBox, _
                                         Optional ByVal UsuariosAtivos As Boolean = False, _
                                         Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT USR.CD_USUARIO, UPPER(USR.NO_USUARIO) NO_USUARIO" & _
                  " FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO USR," _
                           & sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO_SISTEMA UST"

        If UsuariosAtivos = True Then
            SqlText = SqlText & " WHERE USR.IC_ATIVO = 'S'" & _
                                  " AND UST.CD_USUARIO = USR.CD_USUARIO" & _
                                  " AND UST.CD_SISTEMA = " & cnt_Sistema_ControleAcesso
        End If

        SqlText = SqlText & " ORDER BY USR.NO_USUARIO"

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Function Valida_CNPJ(ByVal CGC As String) As Boolean
        On Error GoTo Err_CGC

        Dim i As Integer 'utilizada nos FOR... NEXT
        Dim strCGC As String 'armazena a parte do CGC entre /0001- ou seja 0001
        Dim strcampo As String 'armazena do CPF que será utilizada para o cálculo
        Dim strCaracter As String 'armazena os digitos do CPF da direita para a esquerda
        Dim intNumero As Integer 'armazena o digito separado para cálculo (uma a um)
        Dim intMais As Integer 'armazena o digito específico multiplicado pela sua base
        Dim intSoma As Long 'armazena a soma dos digitos multiplicados pela sua base(intmais)
        Dim intSoma1 As Long 'armazena a soma dos 8 primeiros digitos multiplicados pela sua base(intmais)
        Dim intSoma2 As Long ''armazena a soma dos 4 ultimos digitos multiplicados pela sua base(intmais)
        Dim dblDivisao As Double 'armazena a divisão dos digitos*base por 11
        Dim intInteiro As Long 'armazena inteiro da divisão
        Dim intResto As Integer 'armazena o resto
        Dim intDig1 As Integer 'armazena o 1º digito verificador
        Dim intDig2 As Integer 'armazena o 2º digito verificador
        Dim strConf As String 'armazena o digito verificador

        intSoma = 0
        intSoma1 = 0
        intSoma2 = 0
        intNumero = 0
        intMais = 0
        'Inicia cálculos do 1º dígito
        'Separa os dígitos do CGC que serão multiplicados de 2 a 9.
        'Retira a "/" da máscara de entrada.
        strCGC = Right(CGC, 6)
        strCGC = Left(strCGC, 4)
        strcampo = Left(CGC, 8)
        strcampo = Right(strcampo, 4) & strCGC
        For i = 2 To 9
            strCaracter = Right(strcampo, i - 1)
            intNumero = Left(strCaracter, 1)
            intMais = intNumero * i
            intSoma1 = intSoma1 + intMais
        Next i
        'Separa os 4 primeiros dígitos do CGC
        strcampo = Left(CGC, 4)
        For i = 2 To 5
            strCaracter = Right(strcampo, i - 1)
            intNumero = Left(strCaracter, 1)
            intMais = intNumero * i
            intSoma2 = intSoma2 + intMais
        Next i
        intSoma = intSoma1 + intSoma2
        dblDivisao = intSoma / 11
        intInteiro = Int(dblDivisao) * 11
        intResto = intSoma - intInteiro
        If intResto = 0 Or intResto = 1 Then
            intDig1 = 0
        Else
            intDig1 = 11 - intResto
        End If
        intSoma = 0
        intSoma1 = 0
        intSoma2 = 0
        intNumero = 0
        intMais = 0
        'Inicia cálculos do 2º dígito
        strCGC = Right(CGC, 6)
        strCGC = Left(strCGC, 4)
        strcampo = Left(CGC, 8)
        strcampo = Right(strcampo, 3) & strCGC & intDig1
        For i = 2 To 9
            strCaracter = Right(strcampo, i - 1)
            intNumero = Left(strCaracter, 1)
            intMais = intNumero * i
            intSoma1 = intSoma1 + intMais
        Next i
        strcampo = Left(CGC, 5)
        For i = 2 To 6
            strCaracter = Right(strcampo, i - 1)
            intNumero = Left(strCaracter, 1)
            intMais = intNumero * i
            intSoma2 = intSoma2 + intMais
        Next i
        intSoma = intSoma1 + intSoma2
        dblDivisao = intSoma / 11
        intInteiro = Int(dblDivisao) * 11
        intResto = intSoma - intInteiro
        If intResto = 0 Or intResto = 1 Then
            intDig2 = 0
        Else
            intDig2 = 11 - intResto
        End If
        strConf = intDig1 & intDig2
        'Caso o CGC esteja errado dispara a mensagem

        If strConf <> Right(CGC, 2) Then
            Return False
        Else
            Return True
        End If

        Exit Function

Exit_CGC:
        Exit Function

Err_CGC:
        Resume Exit_CGC
    End Function

    Function Valida_CPF(ByVal CPF As String) As Boolean
        On Error GoTo Err_CPF
        Dim i As Integer 'utilizada nos FOR... NEXT
        Dim strcampo As String 'armazena do CPF que será utilizada para o cálculo
        Dim strCaracter As String 'armazena os digitos do CPF da direita para a esquerda
        Dim intNumero As Integer 'armazena o digito separado para cálculo (uma a um)
        Dim intMais As Integer 'armazena o digito específico multiplicado pela sua base
        Dim lngSoma As Long 'armazena a soma dos digitos multiplicados pela sua base(intmais)
        Dim dblDivisao As Double 'armazena a divisão dos digitos*base por 11
        Dim lngInteiro As Long 'armazena inteiro da divisão
        Dim intResto As Integer 'armazena o resto
        Dim intDig1 As Integer 'armazena o 1º digito verificador
        Dim intDig2 As Integer 'armazena o 2º digito verificador
        Dim strConf As String 'armazena o digito verificador

        lngSoma = 0
        intNumero = 0
        intMais = 0
        strcampo = Left(CPF, 9)

        'Inicia cálculos do 1º dígito
        For i = 2 To 10
            strCaracter = Right(strcampo, i - 1)
            intNumero = Left(strCaracter, 1)
            intMais = intNumero * i
            lngSoma = lngSoma + intMais
        Next i
        dblDivisao = lngSoma / 11

        lngInteiro = Int(dblDivisao) * 11
        intResto = lngSoma - lngInteiro
        If intResto = 0 Or intResto = 1 Then
            intDig1 = 0
        Else
            intDig1 = 11 - intResto
        End If

        strcampo = strcampo & intDig1 'concatena o CPF com o primeiro digito verificador
        lngSoma = 0
        intNumero = 0
        intMais = 0
        'Inicia cálculos do 2º dígito
        For i = 2 To 11
            strCaracter = Right(strcampo, i - 1)
            intNumero = Left(strCaracter, 1)
            intMais = intNumero * i
            lngSoma = lngSoma + intMais
        Next i
        dblDivisao = lngSoma / 11
        lngInteiro = Int(dblDivisao) * 11
        intResto = lngSoma - lngInteiro
        If intResto = 0 Or intResto = 1 Then
            intDig2 = 0
        Else
            intDig2 = 11 - intResto
        End If
        strConf = intDig1 & intDig2
        'Caso o CPF esteja errado dispara a mensagem
        If strConf <> Right(CPF, 2) Then
            Return False
        Else
            Return True
        End If

        Exit Function

Exit_CPF:
        Exit Function

Err_CPF:
        Resume Exit_CPF
    End Function

    Public Sub ListBox_Carregar_Tipo_Acao(ByRef oList As System.Windows.Forms.CheckedListBox, _
                                          Optional ByVal SelecionarTodas As Boolean = False)
        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "SELECT CD_TIPO_ACAO, NO_TIPO_ACAO FROM SOF.TIPO_ACAO ORDER BY NO_TIPO_ACAO"
        oData = DBQuery(SqlText)

        oList.DataSource = oData
        oList.DisplayMember = "NO_TIPO_ACAO"
        oList.ValueMember = "CD_TIPO_ACAO"

        If SelecionarTodas Then
            objCheckList_SelecionarItens(oList, True)
        End If
    End Sub

    Public Sub Form_Carregar_Consulta_Geral(ByVal oFormMDI As Form, _
                                            ByVal TipoTela As frmConsultaGeral.eConsultaGeral)
        Dim oForm As New frmConsultaGeral

        oForm.FormatarTela(TipoTela)

        Form_Show(oFormMDI, oForm, , , True)
    End Sub

    Public Sub Form_Carregar_Cadastro_Listagem_Geral(ByVal oFormMDI As Form, _
                                                     ByVal TipoTela As frmCadastroListagemGeral.eCadastroListagemGeral)
        Dim oForm As New frmCadastroListagemGeral

        oForm.FormatarTela(TipoTela)

        Form_Show(oFormMDI, oForm, , , True)
    End Sub

    Public Sub ComboBox_Carregar_Filial(ByRef oCombo As System.Windows.Forms.ComboBox, _
                                        Optional ByVal LinhaBranco As Boolean = False, _
                                        Optional ByVal SemArmazem As Boolean = True, _
                                        Optional ByVal FilialEntrega As Boolean = False, _
                                        Optional ByVal LiberadaUsuario As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT CD_FILIAL, NO_FILIAL" & _
                  " FROM SOF.FILIAL " & _
                  " WHERE IC_ATIVA = 'S'"

        If SemArmazem Then
            SqlText = SqlText & " AND IC_ARMAZEM = 'N'"
        End If
        If FilialEntrega Then
            SqlText = SqlText & " AND IC_FILIAL_COM_ARMAZEM = 'S'"
        End If
        If LiberadaUsuario Then
            SqlText = SqlText & " AND CD_FILIAL IN (SELECT CD_FILIAL" & _
                                                   " FROM SOF.FILIAL_LIBERADA" & _
                                                   " WHERE CD_USER = " & QuotedStr(sAcesso_UsuarioLogado) & ")"
        End If

        SqlText = SqlText & " ORDER BY NO_FILIAL "

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Filial_Entrega(ByRef oCombo As System.Windows.Forms.ComboBox, _
                                                Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT CD_FILIAL," & _
                         "NO_FILIAL," & _
                         "VL_FRETE_FILIAL_FAZENDA," & _
                         "VL_FRETE_FILIAL_FABRICA," & _
                         "VL_FRETE_FABRICA" & _
                  " FROM SOF.FILIAL " & _
                  " WHERE IC_ATIVA= 'S'" & _
                    " AND IC_FILIAL_COM_ARMAZEM = 'S'" & _
                  " ORDER BY NO_FILIAL"

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Tipo_Pagamento(ByRef oCombo As System.Windows.Forms.ComboBox, _
                                                Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "select  cd_tipo_pagamento ,no_tipo_pagamento from sof.tipo_pagamento  where IC_ATIVO='S' order by no_tipo_pagamento "

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Procedencia(ByRef oCombo As System.Windows.Forms.ComboBox, _
                Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "select  cd_procedencia ,no_procedencia from sof.procedencia order by no_procedencia "

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Tipo_RD(ByRef oCombo As System.Windows.Forms.ComboBox, _
                Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "select  cd_tipo_rd ,no_tipo_rd from sof.tipo_rd order by no_tipo_rd "

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub


    Public Sub ComboBox_Carregar_Local_Conferencia(ByRef oCombo As System.Windows.Forms.ComboBox, _
            Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "select  cd_local_conferencia ,no_local_conferencia from sof.local_conferencia order by no_local_conferencia "

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub


    Public Sub ComboBox_Carregar_Local_Entrega(ByRef oCombo As System.Windows.Forms.ComboBox, _
                  Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "select  cd_local_entrega ,no_local_entrega from sof.local_entrega where ic_ativo='S' order by no_local_entrega "

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Tipo_Documento(ByRef oCombo As System.Windows.Forms.ComboBox, _
            Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT   t.cd_tipo_nf, t.cd_tipo_nf || ' - ' || t.no_tipo_nf AS no_tipo_nf " & _
                    " FROM sof.tipo_nf t ORDER BY t.cd_tipo_nf"

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Pilha(ByRef oCombo As System.Windows.Forms.ComboBox, _
                                       ByVal CD_ARMAZEM As Integer, _
                                       Optional ByVal LinhaBranco As Boolean = False, _
                                       Optional ByVal SomentePilhaComEstoque As Boolean = False)
        Dim SqlText As String

        If SomentePilhaComEstoque Then
            SqlText = "SELECT DISTINCT CD_PILHA_ARMAZEM," & _
                                      "CAST(CD_PILHA_ARMAZEM AS VARCHAR2(10)) PILHA_ARMAZEM" & _
                      " FROM SOF.MOVIMENTACAO_PILHA_ARMAZEM " & _
                      " WHERE CD_ARMAZEM = " & CD_ARMAZEM & _
                      " ORDER BY CD_PILHA_ARMAZEM"
        Else
            SqlText = "SELECT CD_PILHA_ARMAZEM," & _
                             "CAST(CD_PILHA_ARMAZEM AS VARCHAR2(10)) PILHA_ARMAZEM" & _
                      " FROM SOF.PILHA_ARMAZEM " & _
                      " WHERE CD_ARMAZEM = " & CD_ARMAZEM & _
                      " ORDER BY CD_PILHA_ARMAZEM"
        End If

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Tipo_Cacau(ByRef oCombo As System.Windows.Forms.ComboBox, _
            Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT CD_TIPO_CACAU, NO_TIPO_CACAU FROM SOF.TIPO_CACAU ORDER BY NO_TIPO_CACAU"

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Tipo_Negociacao(ByRef oCombo As System.Windows.Forms.ComboBox, _
            Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT TN.CD_TIPO_NEGOCIACAO," & _
                         "TN.NO_TIPO_NEGOCIACAO," & _
                         "TN.IC_BOLSA," & _
                         "TN.IC_DOLAR," & _
                         "TN.IC_TIPO_PRECO_FIXO," & _
                         "TN.IC_BOLSA_OPERACAO," & _
                         "TN.CD_TIPO_PRECO, " & _
                         "TN.QT_DIA_VENC_PADRAO," & _
                         "DECODE(NVL(TN.IC_TIPO_PRECO_FIXO, 'N'), 'S'," & cnt_TIPO_NEGOCIACAO_FixoEmReal & "," & _
                                "DECODE(NVL(TN.IC_DOLAR, 'N'), 'S', " & cnt_TIPO_NEGOCIACAO_FixoEmDolar & "," & _
                                       "DECODE(NVL(TN.IC_BOLSA, 'N'), 'S', " & cnt_TIPO_NEGOCIACAO_DiferencialBolsa & ", 0))) CD_TIPO" & _
                  " FROM SOF.TIPO_NEGOCIACAO TN " & _
                  " ORDER BY TN.NO_TIPO_NEGOCIACAO ASC"
        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Tipo_Unidade(ByRef oCombo As System.Windows.Forms.ComboBox, _
        Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT TU.CD_TIPO_UNIDADE," & _
                         "TU.NO_TIPO_UNIDADE," & _
                         "TU.QT_FATOR" & _
                  " FROM SOF.TIPO_UNIDADE TU " & _
                  " ORDER BY TU.NO_TIPO_UNIDADE ASC"
        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Tipo_Contato(ByRef oCombo As System.Windows.Forms.ComboBox, _
                      Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT CD_TIPO_ATENDIMENTO, NO_TIPO_ATENDIMENTO FROM SOF.TIPO_ATENDIMENTO ORDER BY NO_TIPO_ATENDIMENTO"

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Tipo_Endereco_Armazem(ByRef oCombo As System.Windows.Forms.ComboBox, _
                      Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT CD_TIPO_ATENDIMENTO, NO_TIPO_ATENDIMENTO FROM SOF.TIPO_ATENDIMENTO ORDER BY NO_TIPO_ATENDIMENTO"

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Tipo_Fornecedor_Pessoa(ByRef oCombo As System.Windows.Forms.ComboBox, _
                                                        Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT CD_TIPO_FORNECEDOR_PESSOA, NO_TIPO_FORNECEDOR_PESSOA FROM SOF.TIPO_FORNECEDOR_PESSOA" & _
                  " ORDER BY NO_TIPO_FORNECEDOR_PESSOA"

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Tipo_Adendo(ByRef oCombo As System.Windows.Forms.ComboBox, _
                                             Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT CD_TIPO_ADENDO, DS_TIPO_ADENDO FROM SOF.TIPO_ADENDO WHERE IC_ATIVO='S' " & _
                  " ORDER BY DS_TIPO_ADENDO"

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Tipo_Bonus(ByRef oCombo As System.Windows.Forms.ComboBox, _
                                          Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT CD_BONUS_PADRAO, NO_BONUS_PADRAO FROM SOF.BONUS_PADRAO WHERE IC_ATIVO='S' " & _
                  " ORDER BY NO_BONUS_PADRAO"

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Tipo_Movimentacao_Sacaria(ByRef oCombo As System.Windows.Forms.ComboBox, _
                                                           Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT CD_TIPO_MOVIMENTACAO," & _
                         "NO_TIPO_MOVIMENTACAO" & _
                  " FROM SOF.SACARIA_TIPO_MOVIMENTACAO" & _
                  " ORDER BY NO_TIPO_MOVIMENTACAO"

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Tipo_Movimentacao(ByRef oCombo As System.Windows.Forms.ComboBox, _
                                                   Optional ByVal LinhaBranco As Boolean = False, _
                                                   Optional ByVal bAplicacao As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT CD_TIPO_MOVIMENTACAO," & _
                         "NO_TIPO_MOVIMENTACAO" & _
                  " FROM SOF.TIPO_MOVIMENTACAO"

        If bAplicacao Then
            SqlText = SqlText & _
                  " WHERE NVL(IC_APLICACAO, 'N') = 'S'"
        End If

        SqlText = SqlText & _
                  " ORDER BY NO_TIPO_MOVIMENTACAO"

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Tipo_Bem(ByRef oCombo As System.Windows.Forms.ComboBox, _
                                      Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT CD_BENS_TIPO, NO_BENS_TIPO FROM SOF.BENS_TIPO" & _
                  " ORDER BY NO_BENS_TIPO "

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Tipo_Sacaria(ByRef oCombo As System.Windows.Forms.ComboBox, _
                                              Optional ByVal LinhaBranco As Boolean = False, _
                                              Optional ByVal Contabiliza_Fornecedor As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT CD_TIPO_SACARIA," & _
                         "NO_TIPO_SACARIA" & _
                  " FROM SOF.TIPO_SACARIA" & _
                  " WHERE IC_ATIVO='S'"

        If Contabiliza_Fornecedor Then
            SqlText = SqlText & _
                 " AND IC_CONTABILIZA_FORNECEDOR = 'S'"
        End If

        SqlText = SqlText & _
                  " ORDER BY NO_TIPO_SACARIA "

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Processo_Tipo(ByRef oCombo As System.Windows.Forms.ComboBox, _
                                               Optional ByVal TipoProcesso As Integer = 0, _
                                               Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT CD_STATUS, NO_STATUS" & _
                  " FROM SOF.PROCESSO_STATUS" & _
                  " WHERE CD_PROCESSO = " & TipoProcesso & _
                  " ORDER BY NO_STATUS"
        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Tipo_Garantia(ByRef oCombo As System.Windows.Forms.ComboBox, _
                      Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "select  cd_tipo_garantia ,no_tipo_garantia from sof.tipo_garantia where ic_garantido='S' order by no_tipo_garantia "

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Tipo_Fretista(ByRef oCombo As System.Windows.Forms.ComboBox, _
                  Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "select  cd_tipo_fretista ,no_tipo_fretista from sof.tipo_fretista order by no_tipo_fretista "

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Tipo_Cobranca_Frete(ByRef oCombo As System.Windows.Forms.ComboBox, _
              Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT CD_ITEM_LISTA, NO_ITEM_LISTA " & _
                     " FROM SOF.PROCESSO_LISTA" & _
                     " WHERE CD_PROCESSO = " & enProcesso_Status.TipoPagamentoFrete & _
                     " ORDER BY NO_ITEM_LISTA"

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Status_Garantia(ByRef oCombo As System.Windows.Forms.ComboBox, _
                  Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "select  CD_TIPO_STATUS ,NO_TIPO_STATUS from sof.LIMITE_CREDITO_TIPO_STATUS where CD_TIPO_STATUS in ('A','C','E','I') order by NO_TIPO_STATUS "

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Status_Credito(ByRef oCombo As System.Windows.Forms.ComboBox, _
              Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "select  CD_TIPO_STATUS ,NO_TIPO_STATUS from sof.LIMITE_CREDITO_TIPO_STATUS order by NO_TIPO_STATUS "

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_UF(ByRef oCombo As System.Windows.Forms.ComboBox, _
                                    Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT CD_UF, NO_UF FROM SOF.UF ORDER BY NO_UF"

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ListBox_Carregar_Tipo_Fretista(ByRef oList As System.Windows.Forms.CheckedListBox)
        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "SELECT CD_TIPO_FRETISTA, NO_TIPO_FRETISTA FROM SOF.TIPO_FRETISTA ORDER BY NO_TIPO_FRETISTA"
        oData = DBQuery(SqlText)

        oList.DataSource = oData
        oList.DisplayMember = "NO_TIPO_FRETISTA"
        oList.ValueMember = "CD_TIPO_FRETISTA"
    End Sub

    Public Sub ListBox_Carregar_Filial(ByRef oList As System.Windows.Forms.ListBox, _
                                       Optional ByVal SemArmazem As Boolean = True, _
                                       Optional ByVal FilialEntrega As Boolean = False, _
                                       Optional ByVal LiberadaUsuario As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT CD_FILIAL, NO_FILIAL" & _
                  " FROM SOF.FILIAL " & _
                  " WHERE IC_ATIVA = 'S'"

        If SemArmazem Then
            SqlText = SqlText & " AND IC_ARMAZEM = 'N'"
        End If
        If FilialEntrega Then
            SqlText = SqlText & " AND IC_FILIAL_COM_ARMAZEM = 'S'"
        End If
        If LiberadaUsuario Then
            SqlText = SqlText & " AND CD_FILIAL IN (SELECT CD_FILIAL" & _
                                                   " FROM SOF.FILIAL_LIBERADA" & _
                                                   " WHERE CD_USER = " & QuotedStr(sAcesso_UsuarioLogado) & ")"
        End If

        SqlText = SqlText & " ORDER BY NO_FILIAL "

        oList.DataSource = DBQuery(SqlText)
        oList.DisplayMember = "NO_FILIAL"
        oList.ValueMember = "CD_FILIAL"
    End Sub

    Public Sub ListBox_Carregar_Filial2(ByRef oList As System.Windows.Forms.CheckedListBox, _
                                        Optional ByVal SemArmazem As Boolean = True, _
                                        Optional ByVal FilialEntrega As Boolean = False, _
                                        Optional ByVal LiberadaUsuario As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT CD_FILIAL, NO_FILIAL" & _
                  " FROM SOF.FILIAL " & _
                  " WHERE IC_ATIVA = 'S'"

        If SemArmazem Then
            SqlText = SqlText & " AND IC_ARMAZEM = 'N'"
        End If
        If FilialEntrega Then
            SqlText = SqlText & " AND IC_FILIAL_COM_ARMAZEM = 'S'"
        End If
        If LiberadaUsuario Then
            SqlText = SqlText & " AND CD_FILIAL IN (SELECT CD_FILIAL" & _
                                                   " FROM SOF.FILIAL_LIBERADA" & _
                                                   " WHERE CD_USER = " & QuotedStr(sAcesso_UsuarioLogado) & ")"
        End If

        SqlText = SqlText & " ORDER BY NO_FILIAL "

        oList.DataSource = DBQuery(SqlText)
        oList.DisplayMember = "NO_FILIAL"
        oList.ValueMember = "CD_FILIAL"
    End Sub

    Public Sub ListBox_Carregar_Origem(ByRef oList As System.Windows.Forms.CheckedListBox)
        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "SELECT CD_UF, CD_UF || ' - ' || NO_UF NOUF FROM SOF.UF ORDER BY CD_UF"
        oData = DBQuery(SqlText)

        oList.DataSource = oData
        oList.DisplayMember = "NOUF"
        oList.ValueMember = "CD_UF"
    End Sub
    Public Sub ComboBox_Carregar_Moeda_Credito(ByRef oCombo As System.Windows.Forms.ComboBox, _
                                Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT cd_status, no_status FROM SOF.processo_status where cd_processo=" & enProcesso_Status.Moeda & " ORDER BY no_status"

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Moeda(ByRef oCombo As System.Windows.Forms.ComboBox)
        Dim oRow As DataRow
        Dim oDataCombo As New DataTable
        oDataCombo.Columns.Add(0)
        oDataCombo.Columns.Add(1)

        oRow = oDataCombo.NewRow
        oRow(0) = 1
        oRow(1) = "R$"
        oDataCombo.Rows.Add(oRow)

        oRow = oDataCombo.NewRow
        oRow(0) = 2
        oRow(1) = "US$"
        oDataCombo.Rows.Add(oRow)

        oRow = oDataCombo.NewRow
        oRow(0) = 3
        oRow(1) = "Qt @"
        oDataCombo.Rows.Add(oRow)

        If Not oDataCombo Is Nothing Then
            oCombo.ValueMember = oDataCombo.Columns(0).ColumnName
            oCombo.DisplayMember = oDataCombo.Columns(1).ColumnName
            oCombo.DataSource = oDataCombo
            oCombo.Refresh()
        End If
    End Sub

    Public Sub ComboBox_Carregar_Tipo_Interface_JDE(ByRef oCombo As System.Windows.Forms.ComboBox, _
                   Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "select  cd_tipo_interface_jde ,no_tipo_interface_jde from sof.tipo_interface_jde order by no_tipo_interface_jde "

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Tipo_Pessoa_Tributacao(ByRef oCombo As System.Windows.Forms.ComboBox, _
                Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "select  cd_tipo_pessoa_tributacao ,no_tipo_pessoa_tributacao from sof.tipo_pessoa_tributacao order by no_tipo_pessoa_tributacao "

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Tipo_Capital(ByRef oCombo As System.Windows.Forms.ComboBox, _
                Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "select  cd_tipo_capital ,no_tipo_capital from sof.fornecedor_tipo_capital order by no_tipo_capital "

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Bolsa(ByRef oCombo As System.Windows.Forms.ComboBox, _
             Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT BP.CD_PAPEL, BP.CD_PAPEL as NO_PAPEL " & _
                          "FROM SOF.BOLSA_PERIODO BP " & _
                          "WHERE BP.ic_moeda = 'N' and BP.ic_exibe='S' " & _
                          "ORDER BY BP.SQ_BOLSA_PERIODO_MATRIZ ASC, NU_SEQUENCIA"


        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

   

    Public Sub ComboBox_Carregar_Estado_Civil(ByRef oCombo As System.Windows.Forms.ComboBox, _
                    Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "select  cd_estado_civil ,no_estado_civil from sof.estado_civil order by no_estado_civil "

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Funrural(ByRef oCombo As System.Windows.Forms.ComboBox, _
                    Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "select  cd_funrural ,no_funrural from sof.funrural order by no_funrural "

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Tipo_Pessoa(ByRef oCombo As System.Windows.Forms.ComboBox, _
                                             Optional ByVal LinhaBranco As Boolean = False, _
                                             Optional ByVal TipoPessoaBolsa As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT CD_TIPO_PESSOA," & _
                         "NO_TIPO_PESSOA" & _
                  " FROM SOF.TIPO_PESSOA"

        If TipoPessoaBolsa Then
            SqlText = SqlText & _
                  " WHERE IC_MOSTRA_PRECO_BOLSA = 'S'"
        End If

        SqlText = SqlText & _
                  " ORDER BY NO_TIPO_PESSOA"
        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Tipo_Aprovacao(ByRef oCombo As System.Windows.Forms.ComboBox, _
             Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "select  cd_tipo_aprovacao,no_tipo_aprovacao " & _
                  "from sof.tipo_aprovacao " & _
                  "order by no_tipo_aprovacao"

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Tipo_ContratoPAF(ByRef oCombo As System.Windows.Forms.ComboBox, _
                Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT CD_TIPO_CONTRATO_PAF," & _
                         "NO_TIPO_CONTRATO_PAF," & _
                         "IC_ADIANTAMENTO" & _
                  " FROM SOF.TIPO_CONTRATO_PAF" & _
                  " ORDER BY NO_TIPO_CONTRATO_PAF"

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Tipo_Inovacao(ByRef oCombo As System.Windows.Forms.ComboBox, _
                Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "select  cd_tipo_inovacao ,no_tipo_inovacao from sof.tipo_inovacao order by no_tipo_inovacao "

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Conta_Bancaria(ByRef oCombo As System.Windows.Forms.ComboBox, _
                                                Optional ByVal LinhaBranco As Boolean = False, _
                                                Optional ByVal ApenasFiliaisUsuario As Boolean = False)
        Dim SqlText As String

        If ApenasFiliaisUsuario Then
            SqlText = "SELECT CD_BANCO, NO_BANCO" & _
                         " FROM SOF.BANCO " & _
                         " WHERE NVL(IC_ATIVO, 'N') = 'S'" & _
                           " AND CD_FILIAL_ORIGEM in (" & FiliaisLiberadas & ")" & _
                         " ORDER BY NO_BANCO"
        Else
            If SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_AcessoBancosTodasFiliais) Then
                SqlText = "SELECT CD_BANCO, NO_BANCO" & _
                          " FROM SOF.BANCO" & _
                          " WHERE NVL(IC_ATIVO, 'N') = 'S'" & _
                          " ORDER BY NO_BANCO"
            Else
                SqlText = "SELECT CD_BANCO, NO_BANCO" & _
                          " FROM SOF.BANCO " & _
                          " WHERE NVL(IC_ATIVO, 'N') = 'S'" & _
                            " AND CD_FILIAL_ORIGEM = " & FilialLogada & _
                          " ORDER BY NO_BANCO"
            End If
        End If

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Forma_Pagamento(ByRef oCombo As System.Windows.Forms.ComboBox, _
                                                 Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT CD_FORMA_PAGAMENTO, NO_FORMA_PAGAMENTO" & _
                  " FROM SOF.FORMA_PAGAMENTO" & _
                  " WHERE NVL(IC_ATIVO, 'N') = 'S'" & _
                  " ORDER BY NO_FORMA_PAGAMENTO"

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Qualidade(ByRef oCombo As System.Windows.Forms.ComboBox, _
                Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "select  cd_tipo_qualidade ,no_tipo_qualidade from sof.tipo_qualidade order by no_tipo_qualidade "

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Modalidade_Recuperacao(ByRef oCombo As System.Windows.Forms.ComboBox, _
                Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String


        SqlText = "select  CD_CONFISSAO_DIVIDA_MODALIDADE ,NO_CONFISSAO_DIVIDA_MODALIDADE from sof.CONFISSAO_DIVIDA_MODALIDADE order by NO_CONFISSAO_DIVIDA_MODALIDADE "

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Modalidade_Conciliacao(ByRef oCombo As System.Windows.Forms.ComboBox, _
                    Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT CD_CONCILIACAO_MODALIDADE, NO_CONCILIACAO_MODALIDADE " & _
        "FROM SOF.CONCILIACAO_MODALIDADE WHERE IC_ATIVO='S' ORDER BY NO_CONCILIACAO_MODALIDADE"

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Bolsa_Papel_Moeda(ByRef oCombo As System.Windows.Forms.ComboBox, _
                Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT b.cd_papel, b.cd_papel no_papael FROM sof.bolsa_periodo b WHERE b.ic_moeda = 'S'"

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub
    Public Sub ComboBox_Carregar_Provisao(ByRef oCombo As System.Windows.Forms.ComboBox, _
                                          Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT CD_PROVISAO, NO_PROVISAO FROM SOF.PROVISAO ORDER BY NO_PROVISAO"

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub
    Public Sub ComboBox_Carregar_PeriodoBolsa(ByRef oCombo As System.Windows.Forms.ComboBox, _
                                              Optional ByVal LinhaBranco As Boolean = False, _
                                              Optional ByVal IC_MOEDA As Boolean = Nothing)
        Dim SqlText As String

        SqlText = "SELECT BP.CD_PAPEL," & _
                         "BP.NO_PAPEL " & _
                  " FROM SOF.BOLSA_PERIODO BP" & _
                  " WHERE BP.IC_MOEDA = " & IIf(IC_MOEDA, "'S'", "'N'") & _
                  " ORDER BY BP.SQ_BOLSA_PERIODO_MATRIZ ASC"

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub
    Public Sub ComboBox_Carregar_Tipo_Fretista_Tributacao(ByRef oCombo As System.Windows.Forms.ComboBox, _
            Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT cd_tipo_fretista_tributacao, no_tipo_fretista_tributacao FROM SOF.tipo_fretista_tributacao ORDER BY no_tipo_fretista_tributacao"

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub ComboBox_Carregar_Transferencia_Modalidade_Silo(ByRef oCombo As System.Windows.Forms.ComboBox, _
                                                               Optional ByVal LinhaBranco As Boolean = False, _
                                                               Optional ByVal TipoModalidade As String = "U")
        Dim SqlText As String

        SqlText = "SELECT TM.CD_TRANSFERENCIA_MODALIDADE," & _
                         "TM.NO_TRANSFERENCIA_MODALIDADE" & _
                  " FROM SOF.TRANSFERENCIA_MODALIDADE TM" & _
                  " WHERE NVL(TM.IC_MOVIMENTACAO_SILO, 'N') = 'S'" & _
                    " AND NVL(TM.IC_TIPO_UTILIZACAO, 'U') = " & QuotedStr(TipoModalidade) & _
                  " ORDER BY TM.NO_TRANSFERENCIA_MODALIDADE ASC"
        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub
        
    Public Sub ComboBox_Carregar_Favorecido(ByRef oCombo As System.Windows.Forms.ComboBox, _
                                            ByVal CdFornecedor As Integer)
        Dim SqlText As String

        SqlText = "SELECT CD_FORNECEDOR, NO_RAZAO_SOCIAL"
        SqlText = SqlText & " FROM SOF.FORNECEDOR A "
        SqlText = SqlText & "WHERE CD_FORNECEDOR = " & CdFornecedor
        SqlText = SqlText & " UNION ALL "
        SqlText = SqlText & "SELECT A.CD_FORNECEDOR_PROCURADOR, F.NO_RAZAO_SOCIAL "
        SqlText = SqlText & "FROM SOF.FORNECEDOR_PROCURACAO A, "
        SqlText = SqlText & "     SOF.FORNECEDOR F "
        SqlText = SqlText & "WHERE A.CD_FORNECEDOR_PROCURADOR = F.CD_FORNECEDOR AND "
        SqlText = SqlText & "      A.CD_FORNECEDOR = " & CdFornecedor & " AND "
        SqlText = SqlText & "      A.DT_VALIDADE >= '" & Date_to_Oracle(DataSistema()) & "' "

        DBCarregarComboBox(oCombo, SqlText, False)
    End Sub

    Public Sub Fornecedor_GridIdentificar(ByVal oGrid As UltraWinGrid.UltraGrid, _
                                          Optional ByVal iColAtivo As Integer = -1, _
                                          Optional ByVal iColListaNegra As Integer = -1)
        Dim iCont As Integer

        For iCont = 0 To oGrid.Rows.Count - 1
            If objGrid_Valor_SN(oGrid, iColListaNegra, iCont) Then
                With oGrid.Rows(iCont).Appearance
                    .ForeColor = Color.Black
                    .FontData.Bold = DefaultableBoolean.True
                End With
            Else
                If Not objGrid_Valor_SN(oGrid, iColAtivo, iCont) Then
                    With oGrid.Rows(iCont).Appearance
                        .ForeColor = Color.Red
                        .FontData.Bold = DefaultableBoolean.True
                    End With
                End If
            End If
        Next
    End Sub

    Public Function DataSistema() As String
        Dim oData As DataTable

        oData = DBQuery("SELECT DT_SISTEMA FROM SOF.PARAMETRO")

        If Not objDataTable_Vazio(oData) Then
            oMDI.Rodape_Data_Atualizar(oData.Rows(0).Item("DT_SISTEMA"))
            Return oData.Rows(0).Item("DT_SISTEMA")
        End If

        Return Nothing
    End Function

    Public Function Data_Safra_Inicio(ByVal Data As Date) As Date
        If Data.Month < 6 Then
            Return New Date(Data.Year - 1, 6, 1)
        Else
            Return New Date(Data.Year, 6, 1)
        End If
    End Function

    Public Function Data_Safra_Fim(ByVal Data As Date) As Date
        If Data.Month < 6 Then
            Return Data_UltimoDiaMes(5, Data.Year)
        Else
            Return Data_UltimoDiaMes(5, Data.Year + 1)
        End If
    End Function

    Public Function SafraAtual() As Integer
        Dim oData As DataTable

        oData = DBQuery("SELECT CD_SAFRA FROM SOF.PARAMETRO")

        If Not objDataTable_Vazio(oData) Then
            Return oData.Rows(0).Item("CD_SAFRA")
        End If

        Return Nothing
    End Function

    Public Function FilialFechada(ByVal CdFilial As Integer) As Boolean
        If DBQuery_ValorUnico("SELECT IC_FECHADA FROM SOF.FILIAL WHERE CD_FILIAL=" & CdFilial) = "S" Then
            Return True

            If Not FilialLogada_Fechada Then
                oMDI.Libera_Filial()
            End If
        Else
            Return False
        End If

        Return Nothing
    End Function



    Public Sub ComboBox_Carregar_CreditoDebito(ByRef oCombo As System.Windows.Forms.ComboBox, _
                                               Optional ByVal LinhaBranco As Boolean = False)
        Dim oData As New DataTable

        oData.Columns.Add()
        oData.Columns.Add()

        If LinhaBranco Then
            oData.Rows.Add(New Object() {-1, ""})
        End If

        oData.Rows.Add(New Object() {"C", "Crédito"})
        oData.Rows.Add(New Object() {"D", "Débito"})

        oCombo.DisplayMember = oData.Columns(1).ColumnName
        oCombo.ValueMember = oData.Columns(0).ColumnName
        oCombo.DataSource = oData
    End Sub

    Public Sub ComboBox_Carregar_EntradaSaida(ByRef oCombo As System.Windows.Forms.ComboBox, _
                                              Optional ByVal LinhaBranco As Boolean = False)
        Dim oData As New DataTable

        oData.Columns.Add()
        oData.Columns.Add()

        If LinhaBranco Then
            oData.Rows.Add(New Object() {-1, ""})
        End If

        oData.Rows.Add(New Object() {"E", "Entrada"})
        oData.Rows.Add(New Object() {"S", "Saida"})

        oCombo.DisplayMember = oData.Columns(1).ColumnName
        oCombo.ValueMember = oData.Columns(0).ColumnName
        oCombo.DataSource = oData
    End Sub

    Public Sub Cheque_Imprimir(ByVal SQ_MOV_BANCARIO As Integer)
        Dim oData As DataTable
        Dim SqlText As String

        Dim VL_CHEQUE As Double
        Dim NO_FAVORECIDO As String
        Dim NO_CIDADE As String
        Dim CD_UF As String
        Dim DT_MOVIMENTACAO As Date
        Dim VALOR_POR_EXTENSO As String

        Dim oImpressora As New PrintDialog
        Dim sNomeImpressora As String = ""
        Dim oImpressao As LinePrinter
        Dim sTexto As String

        SqlText = "SELECT DT_MOVIMENTACAO," & _
                         "NO_FAVORECIDO," & _
                         "VL_BRUTO " & _
                  " FROM SOF.MOV_BANCARIO " & _
                  " WHERE SQ_MOV_BANCARIO=" & SQ_MOV_BANCARIO
        oData = DBQuery(SqlText)

        If objDataTable_Vazio(oData) Then
            Msg_Mensagem("Cheque não encontrado.")
            Exit Sub
        End If

        DT_MOVIMENTACAO = oData.Rows(0).Item("DT_MOVIMENTACAO")
        VL_CHEQUE = oData.Rows(0).Item("VL_BRUTO")
        NO_FAVORECIDO = objDataTable_LerCampo(oData.Rows(0).Item("NO_FAVORECIDO"), "")

        SqlText = "SELECT MC.NO_CIDADE," & _
                         "MC.CD_UF" & _
                  " FROM SOF.FILIAL FI," & _
                        "SOF.MUNICIPIO MC" & _
                  " WHERE FI.CD_FILIAL = " & FilialLogada & _
                    " AND FI.CD_MUNICIPIO = MC.CD_MUNICIPIO"
        oData = DBQuery(SqlText)

        If objDataTable_Vazio(oData) Then
            Msg_Mensagem("Houve algum problema com sua filial." & vbCrLf & _
                         "Favor contactar o administrador do sistema.")
            Exit Sub
        End If

        CD_UF = oData.Rows(0).Item("CD_UF")
        NO_CIDADE = oData.Rows(0).Item("NO_CIDADE")
        VALOR_POR_EXTENSO = Extenso(VL_CHEQUE)

        sNomeImpressora = Registro_Read_String("IMPRESSORA_CHEQUE")

        Do While sNomeImpressora = ""
            If sNomeImpressora = "" Then
                If oImpressora.ShowDialog = DialogResult.OK Then
                    sNomeImpressora = oImpressora.PrinterSettings.PrinterName
                    Registro_Write_String("IMPRESSORA_CHEQUE", oImpressora.PrinterSettings.PrinterName)
                    Exit Do
                End If
            End If

            If sNomeImpressora = "" Then
                oImpressora.Dispose()
                Msg_Mensagem("Impressão cancelada.")
                Exit Sub
            End If
        Loop

        oImpressora.Dispose()
        oImpressao = New LinePrinter(sNomeImpressora, "SOF - Impressão de cheques")

        sTexto = Chr(27) & Chr(77) & Chr(15) & Chr(27) & Chr(27) & Chr(15) & _
                       StrReplicate(104, " ") & "# " & Format(VL_CHEQUE, "#,##0.00") & " #" & vbCrLf
        sTexto = sTexto & " " & vbCrLf
        sTexto = sTexto & StrReplicate(22, " ") & PadR(Mid(VALOR_POR_EXTENSO, 1, 109) & _
                       " ", 109, "*") & vbCrLf
        sTexto = sTexto & " " & vbCrLf
        sTexto = sTexto & StrReplicate(6, " ") & PadR(Mid(VALOR_POR_EXTENSO, 110, 230) & _
                       " ", 120, "*") & vbCrLf
        sTexto = sTexto & StrReplicate(10, " ") & NO_FAVORECIDO & vbCrLf
        sTexto = sTexto & StrReplicate(64, " ") & PadR(NO_CIDADE & " - " & CD_UF, 26, " ") & _
                       PadR(DT_MOVIMENTACAO.Day, 9, " ") & PadR(VerMes(DT_MOVIMENTACAO), 30, " ") & DT_MOVIMENTACAO.Year & vbCrLf
        sTexto = sTexto & " " & vbCrLf
        sTexto = sTexto & " " & vbCrLf
        sTexto = sTexto & " " & vbCrLf
        sTexto = sTexto & " " & vbCrLf
        sTexto = sTexto & " " & vbCrLf
        sTexto = sTexto & " " & vbCrLf
        sTexto = sTexto & " " & vbCrLf
        sTexto = sTexto & " " & vbCrLf
        sTexto = sTexto & " " & vbCrLf
        sTexto = sTexto & " " & vbCrLf
        sTexto = sTexto & Chr(18) & vbCrLf

        oImpressao.WriteLine(sTexto)
        oImpressao.EndJob(False)

        'Atualizo o usuario da alteração que será quem imprime o cheque
        SqlText = "UPDATE SOF.MOV_BANCARIO" & _
                  " SET DT_ALTERACAO = SYSDATE," & _
                       "NO_USER_ALTERACAO = " & QuotedStr(sAcesso_UsuarioLogado) & _
                  " WHERE SQ_MOV_BANCARIO = " & SQ_MOV_BANCARIO
        DBExecutar(SqlText)
    End Sub

    Public Sub Historico_Fornecedor(ByVal TpAcao As Tipo_Historico_Fornecedor, ByVal CdForn As Long, ByVal NoForn As String)
        Dim SqlText As String

        If CdForn = 0 Or Trim(NoForn) = "" Then Exit Sub

        SqlText = DBMontar_SP("SOF.SP_ACAO_CADASTRO_FORNECEDOR", False, ":TIPOACAO", ":CDFORN", ":NOFORN")

        If Not DBExecutar(SqlText, DBParametro_Montar("TIPOACAO", TpAcao.GetHashCode), _
                                   DBParametro_Montar("CDFORN", CdForn), _
                                   DBParametro_Montar("NOFORN", NoForn)) Then GoTo Erro

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Public Sub ComboBox_Carregar_Tipo_Frete(ByRef oCombo As System.Windows.Forms.ComboBox, _
                                               Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT CD_TIPO_FRETE, NO_TIPO_FRETE FROM SOF.TIPO_FRETE ORDER BY NO_TIPO_FRETE"

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub objEditorValor_Formatar(ByVal oEditor As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor, _
                                       Optional ByVal ValorMinimo As Decimal = -1, _
                                       Optional ByVal ValorMaximo As Decimal = -1, _
                                       Optional ByVal QuantidadeDigitoParteInteira As Integer = 0)
        With oEditor
            .FormatProvider = New System.Globalization.CultureInfo("pt-BR")

            If ValorMinimo <> -1 Then .MinValue = ValorMinimo
            If ValorMaximo <> -1 Then .MaxValue = ValorMaximo

            If QuantidadeDigitoParteInteira > 0 Then
                .MaskInput = "{LOC}$ " & StrReplicate(QuantidadeDigitoParteInteira, "n") & ".nn"
            End If
        End With
    End Sub

    Public Sub objEditorNumero_Formatar(ByVal oEditor As Infragistics.Win.UltraWinEditors.UltraNumericEditor, _
                                        Optional ByVal ValorMinimo As Decimal = -1, _
                                        Optional ByVal ValorMaximo As Decimal = -1, _
                                        Optional ByVal QuantidadeDigitoParteInteira As Integer = 0, _
                                        Optional ByVal QuantidadeDigitoParteDecimal As Integer = 0)
        With oEditor
            .FormatProvider = New System.Globalization.CultureInfo("pt-BR")

            If ValorMinimo <> -1 Then .MinValue = ValorMinimo
            If ValorMaximo <> -1 Then .MaxValue = ValorMaximo

            If QuantidadeDigitoParteInteira > 0 Then
                .MaskInput = StrReplicate(QuantidadeDigitoParteInteira, "n")
                .NumericType = UltraWinEditors.NumericType.Integer

                If QuantidadeDigitoParteDecimal > 0 Then
                    .NumericType = UltraWinEditors.NumericType.Double
                    .MaskInput = .MaskInput & "." & StrReplicate(QuantidadeDigitoParteDecimal, "n")
                End If
            End If
        End With
    End Sub

    Public Function ListarIDFiliaisLiberadaUsuario() As String
        Return FiliaisLiberadas
    End Function

    Public Sub PovoaFiliaisLiberadaUsuario()
        Dim sAux As String = ""
        Dim iCont As Integer
        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "SELECT FILIAL_LIBERADA.CD_FILIAL, " & _
          "FILIAL.NO_FILIAL " & _
          "From SOF.FILIAL_LIBERADA, SOF.FILIAL " & _
          "Where FILIAL_LIBERADA.CD_FILIAL = FILIAL.CD_FILIAL and " & _
          "FILIAL_LIBERADA.CD_user='" & sAcesso_UsuarioLogado & "' AND " & _
          "FILIAL.IC_ATIVA='S'"

        oData = DBQuery(SqlText)

        For iCont = 0 To oData.Rows.Count - 1
            Str_Adicionar(sAux, oData.Rows(iCont).Item("CD_FILIAL"), ",")
        Next
        FiliaisLiberadas = sAux
    End Sub

    Public Function SEC_ValidarAcessoPermisao(ByVal Permisao As SEC_Permissao) As Boolean
        Dim sPermissao As String
        Dim SqlText As String
        Dim bPermite As Boolean

        If SEC_SomenteConsulta Then
            Return False
        Else
            Select Case Permisao
                Case SEC_Permissao.SEC_P_Acesso_RenegociarRecuperacaoCredito
                    sPermissao = "RenegociarRecuperacaoCredito"
                Case SEC_Permissao.SEC_P_Acesso_QuebrarRecuperacaoCredito
                    sPermissao = "QuebrarRecuperacaoCredito"
                Case SEC_Permissao.SEC_P_Acesso_PagarRecuperacaoCredito
                    sPermissao = "PagarRecuperacaoCredito"
                Case SEC_Permissao.SEC_P_Acesso_ImprimirVoucherPagamento
                    sPermissao = "ImprimirVoucherPagamento"
                Case SEC_Permissao.SEC_P_Acesso_ImprimirCheque
                    sPermissao = "ImprimirCheque"
                Case SEC_Permissao.SEC_P_Acesso_CancelarGarantia
                    sPermissao = "CancelarGarantia"
                Case SEC_Permissao.SEC_P_Acesso_ApagarPagamentoParcialmente
                    sPermissao = "ApagarPagamentoParcialmente"
                Case SEC_Permissao.SEC_P_Acesso_AlterarExcluirJornalDataAnteriorAtual
                    sPermissao = "AlterarExcluirJornalDataAnteriorAtual"
                Case SEC_Permissao.SEC_P_Acesso_AcessoBancosTodasFiliais
                    sPermissao = "AcessoBancosTodasFiliais"
                Case SEC_Permissao.SEC_P_Acesso_PodeAlterarTodoCampoCadFornecedor
                    sPermissao = "PodeAlterarTodoCampoCadFornecedor"
                Case SEC_Permissao.SEC_P_Acesso_IncluirSolicitacaoCreditoFornecedorOutraFilial
                    sPermissao = "IncluirSolicCreditoFornecedorOutraFilial"
                Case SEC_Permissao.SEC_P_Acesso_ExcluirFreteLancadoDataAnteriorAtual
                    sPermissao = "ExcluirFreteLancadoDataAnteriorAtual"
                Case SEC_Permissao.SEC_P_Acesso_ExcluirMovimentacaoBancariaDataAnterior
                    sPermissao = "ExcluirMovimentacaoBancariaDataAnterior"
                Case SEC_Permissao.SEC_P_Acesso_IncluirInovacoesDataAnteriorAtual
                    sPermissao = "IncluirInovacoesDataAnteriorAtual"
                Case SEC_Permissao.SEC_P_Acesso_AlterarExcluirContatosDataAnteriorAtual
                    sPermissao = "AlterarExcluirContatosDataAnteriorAtual"
                Case SEC_Permissao.SEC_P_Acesso_TodosAlmoxarifados
                    sPermissao = "Acesso_TodosAlmoxarifados"
                Case SEC_Permissao.SEC_P_Acesso_AcessoMovimentarCacauEntrePilha
                    sPermissao = "AcessoMovimentarCacauEntrePilha"
                Case SEC_Permissao.SEC_P_Acesso_LancarNotaFiscalReferenciaMovimentacao
                    sPermissao = "LancarNotaFiscalReferenciaMovimentacao"
                Case SEC_Permissao.SEC_P_Acesso_CancelarContratoPAF
                    sPermissao = "CancelarContratoPAF"
                Case SEC_Permissao.SEC_P_Acesso_LancarJurosContratoPAF
                    sPermissao = "LancarJurosContratoPAF"
                Case SEC_Permissao.SEC_P_Acesso_Abrir_FecharContratoPAF
                    sPermissao = "Abrir_FecharContratoPAF"
                Case SEC_Permissao.SEC_P_Acesso_CancelarNegociacaoContrato
                    sPermissao = "CancelarNegociacaoContrato"
                Case SEC_Permissao.SEC_P_Acesso_EstornoNegociacaoContrato
                    sPermissao = "EstornoNegociacaoContrato"
                Case SEC_Permissao.SEC_P_Acesso_LancarJurosNegociacaoContrato
                    sPermissao = "LancarJurosNegociacaoContrato"
                Case SEC_Permissao.SEC_P_Acesso_LiberacaoSaldoPreNegociacao
                    sPermissao = "LiberacaoSaldoPreNegociacao"
                Case SEC_Permissao.SEC_P_Acesso_Abrir_FecharNegociacao
                    sPermissao = "Abrir_FecharNegociacao"
                Case SEC_Permissao.SEC_P_Acesso_IncluirAdendoContratoFixo
                    sPermissao = "IncluirAdendoContratoFixo"
                Case SEC_Permissao.SEC_P_Acesso_FixarDolarContratoFixo
                    sPermissao = "FixarDolarContratoFixo"
                Case SEC_Permissao.SEC_P_Acesso_CancelarContratoFixo
                    sPermissao = "CancelarContratoFixo"
                Case SEC_Permissao.SEC_P_Acesso_EliminarAdendoContratoFixo
                    sPermissao = "EliminarAdendoContratoFixo"
                Case SEC_Permissao.SEC_P_Acesso_AlterarInovacaoDataAnteriorAtual
                    sPermissao = "AlterarInovacaoDataAnteriorAtual"
                Case SEC_Permissao.SEC_P_Acesso_AjustarSaldoEstoqueSacariaMovimentacoes
                    sPermissao = "AjustarSaldoEstoqueSacariaMovimentacoes"
                Case SEC_Permissao.SEC_P_Acesso_VisualizarRequisicaoSacariaOutraFilial
                    sPermissao = "VisualizarRequisicaoSacariaOutraFilial"
                Case SEC_Permissao.SEC_P_Acesso_RecepcionarDevolucaoSacariaFornecedor
                    sPermissao = "RecepcionarDevolucaoSacariaFornecedor"
                Case SEC_Permissao.SEC_P_Acesso_EntregarSacariaRequisitadaFornecedor
                    sPermissao = "EntregarSacariaRequisitadaFornecedor"
                Case SEC_Permissao.SEC_P_Acesso_CancelarRequisicaoSacariaStatusEntregue
                    sPermissao = "CancelarRequisicaoSacariaStatusEntregue"
                Case SEC_Permissao.SEC_P_Acesso_QuebrarAplicacaoAdiantamentDataAnteriorContratoPAF
                    sPermissao = "QuebrarAplicacaoAdiantamentDataAnteriorContratoPAF"
                Case SEC_Permissao.SEC_P_Acesso_ExcluirQuebrarAplicacaoNegociacaoFechada
                    sPermissao = "ExcluirQuebrarAplicacaoNegociacaoFechada"
                Case SEC_Permissao.SEC_P_Acesso_AcordarDesagioAplicacaoRecebimentos
                    sPermissao = "AcordarDesagioAplicacaoRecebimentos"
                Case SEC_Permissao.SEC_P_Acesso_ExcluirQuebrarAplicacaoContratoFixoFechado
                    sPermissao = "ExcluirQuebrarAplicacaoContratoFixoFechado"
                Case SEC_Permissao.SEC_P_Acesso_VisualizarBolsaInvisiveisConsulta
                    sPermissao = "VisualizarBolsaInvisiveisConsulta"
                Case SEC_Permissao.SEC_P_Acesso_ExcluirTodaMovimentacaoPilhaManualmente
                    sPermissao = "ExcluirTodaMovimentacaoPilhaManualmente"
                Case SEC_Permissao.SEC_P_Acesso_AlterarDisponibilizacaoPagamentoAmarracao
                    sPermissao = "AlterarDisponibilizacaoPagamentoAmarracao"
                Case SEC_Permissao.SEC_P_Acesso_AlterarIndicadorInterfaceEnviadaJDE_OW
                    sPermissao = "AlterarIndicadorInterfaceEnviadaJDE_OW"
                Case SEC_Permissao.SEC_P_Acesso_AlterarFornecCtrRecuperacaoCredito
                    sPermissao = "AlterarFornecCtrRecuperacaoCredito"
                Case SEC_Permissao.SEC_P_Acesso_IncluirRecuperacaoCreditoDataRetroativa
                    sPermissao = "IncluirRecuperacaoCreditoDataRetroativa"
                Case SEC_Permissao.SEC_P_Acesso_CancelarRecuperacaoCredito
                    sPermissao = "CancelarRecuperacaoCredito"
                Case SEC_Permissao.SEC_P_Acesso_RecepcionarTransferenciaSacariaAberto
                    sPermissao = "RecepcionarTransferenciaSacariaAberto"
                Case SEC_Permissao.SEC_P_Acesso_Abrir_FecharContratoFixo
                    sPermissao = "Abrir_FecharContratoFixo"
                Case SEC_Permissao.SEC_P_Acesso_IncluirEliminarFornecedorListaNegra
                    sPermissao = "IncluirEliminarFornecedorListaNegra"
                Case SEC_Permissao.SEC_P_Acesso_ListarMovimentacoesTodasFiliais
                    sPermissao = "ListarMovimentacoesTodasFiliais"
                Case SEC_Permissao.SEC_P_Acesso_ImprimirRequisicaoSacariaEntregue
                    sPermissao = "ImprimirRequisicaoSacariaEntregue"
                Case SEC_Permissao.SEC_P_Acesso_VisualizarCadastroFornecedorOutraFilial
                    sPermissao = "VisualizarCadastroFornecedorOutraFilial"
                Case SEC_Permissao.SEC_P_Acesso_RealizarCessaoDireitoValor_NF
                    sPermissao = "RealizarCessaoDireitoValor_NF"
                Case SEC_Permissao.SEC_P_Acesso_RealizarCessaoDireitoQuantidadeValor_NF
                    sPermissao = "RealizarCessaoDireitoQuantidadeValor_NF"
                Case SEC_Permissao.SEC_P_Acesso_AlterarProcedenciaPilha
                    sPermissao = "AlterarProcedenciaPilha"
                Case SEC_Permissao.SEC_P_Acesso_EmitirRelatorioContratoComSaldoINSS
                    sPermissao = "EmitirRelatorioContratoComSaldoINSS"
                Case SEC_Permissao.SEC_P_Acesso_CadastroRenegociacao_Consultar
                    sPermissao = "CadastroRenegociacao_Consultar"
                Case SEC_Permissao.SEC_P_Acesso_CadastroRenegociacao_Solicitar
                    sPermissao = "CadastroRenegociacao_Solicitar"
                Case SEC_Permissao.SEC_P_Acesso_Usuario_Desbloquear
                    sPermissao = "Usuario_Desbloquear"
                Case SEC_Permissao.SEC_P_Acesso_AprovarAjusteRDE
                    sPermissao = "AprovarAjusteRDE"
                Case SEC_Permissao.SEC_P_Acesso_ApricaCacauSemProporcionalidade
                    sPermissao = "Acesso_AplicarCacauSemProporcionalidade"
                Case SEC_Permissao.SEC_P_Acesso_LimitarInclusaoCtrSomentoImportacao
                    sPermissao = "Acesso_LimitarInclusaoCtrSomentoImportacao"
                Case Else
                    sPermissao = ""
            End Select

            SqlText = "SELECT COUNT(*)" & _
                      " FROM (" & SEC_SqlText_Acesso(sAcesso_UsuarioLogado, SEC_Tipo_AreaAcesso.SEC_TipoAreaAcesso_Permissao) & " )" & _
                      " WHERE UPPER(NO_AREAACESSO_INTERNO) = " & QuotedStr(UCase(sPermissao))

            bPermite = (DBQuery_ValorUnico(SqlText) > 0)

            Return bPermite
        End If
    End Function

    Public Sub ComboBox_Carregar_Armazem(ByRef oCombo As System.Windows.Forms.ComboBox, _
                                         Optional ByVal SqlText As String = "", _
                                         Optional ByVal LinhaBranco As Boolean = False, _
                                         Optional ByVal bIncluiFilialArmazem As Boolean = False, _
                                         Optional ByVal Filial As Integer = 0, _
                                         Optional ByVal AcessoTodasFiliais As Boolean = True, _
                                         Optional ByVal bArmazemFilialAcesso As Boolean = False, _
                                         Optional ByVal TodosArmazemAtivo As Boolean = False)
        Dim sUsuario As String

        sUsuario = sAcesso_UsuarioLogado

        If SqlText = "" Then
            If (SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_TodosAlmoxarifados) And AcessoTodasFiliais) Or TodosArmazemAtivo Then
                SqlText = "SELECT CD_ARMAZEM, NO_ARMAZEM FROM SOF.ARMAZEM WHERE IC_ATIVO = 'S' ORDER BY NO_ARMAZEM"
            Else
                If Filial = 0 Then
                    Filial = FilialLogada
                End If

                If bArmazemFilialAcesso Then
                    SqlText = "SELECT CD_ARMAZEM, NO_ARMAZEM" & _
                              " FROM SOF.ARMAZEM " & _
                              " WHERE CD_FILIAL_ORIGEM IN (SELECT CD_FILIAL" & _
                                                          " FROM SOF.FILIAL_LIBERADA" & _
                                                          " WHERE CD_USER = " & QuotedStr(sUsuario) & ")" & _
                                " AND IC_ATIVO = 'S'"
                End If

                If bIncluiFilialArmazem Then
                    If Trim(SqlText) <> "" Then
                        SqlText = SqlText & " UNION "
                    End If

                    SqlText = SqlText & _
                              "SELECT CD_ARMAZEM, NO_ARMAZEM" & _
                              " FROM SOF.ARMAZEM " & _
                              " WHERE CD_FILIAL_ORIGEM IN (SELECT CD_FILIAL" & _
                                                          " FROM SOF.FILIAL" & _
                                                          " WHERE CD_FILIAL_RESPONSAVEL = " & Trim(Filial) & _
                                                             " OR CD_FILIAL = " & Trim(Filial) & ")" & _
                                " AND IC_ATIVO = 'S'"
                End If

                If Trim(SqlText) = "" Then
                    SqlText = "SELECT CD_ARMAZEM, NO_ARMAZEM" & _
                              " FROM SOF.ARMAZEM" & _
                              " WHERE CD_FILIAL_ORIGEM = " & Trim(Filial) & _
                                " AND IC_ATIVO = 'S'"
                End If

                SqlText = SqlText & " ORDER BY NO_ARMAZEM"
            End If
        End If

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Function PadR(ByVal Texto As String, ByVal Tamanho As Integer, ByVal Caracter As String) As String
        Return Texto & StrReplicate(Tamanho - Len(Texto), Caracter)
    End Function

    Public Function PadL(ByVal Texto As String, ByVal Tamanho As Integer, ByVal Caracter As String) As String
        Return StrReplicate(Tamanho - Len(Texto), Caracter) & Texto
    End Function

    Public Function PadC(ByVal Texto As String, ByVal Tamanho As Integer, ByVal Caracter As String) As String
        Dim T1 As Integer
        Dim T2 As Integer

        If Len(Texto) >= Tamanho Then
            PadC = Mid(Texto, 1, Tamanho)
        Else
            T1 = Int((Tamanho - Len(Texto)) / 2)
            T2 = Tamanho - Len(Texto) - T1
            PadC = StrReplicate(T1, Caracter) & Texto & StrReplicate(T2, Caracter)
        End If
    End Function

    Public Function Ambiente_Desenvolvimento() As Boolean
        Return (sBancoDados_BancoDadosLogado = "SPO10D")
    End Function

    Public Sub ComboBox_Carregar_Tipo_Devolucao(ByRef oCombo As System.Windows.Forms.ComboBox, _
                                                Optional ByVal LinhaBranco As Boolean = False)
        Dim SqlText As String

        SqlText = "SELECT CD_TRANSFERENCIA_MODALIDADE," & _
                         "NO_TRANSFERENCIA_MODALIDADE" & _
                  " FROM SOF.TRANSFERENCIA_MODALIDADE" & _
                  " WHERE IC_DEVOLUCAO = 'S'" & _
                  " ORDER BY NO_TRANSFERENCIA_MODALIDADE"

        DBCarregarComboBox(oCombo, SqlText, LinhaBranco)
    End Sub

    Public Sub Pesq_CodigNome_FormPesquisa(ByVal oPesq_CodigoNome As Pesq_CodigoNome, _
                                           ByVal oTPPesquisa As Pesq_CodigoNome.TPPesquisa, _
                                           ByVal oBancoDados_Filtro As Collection, _
                                           ByVal sBancoDados_Campo_Codigo2 As String)
        Dim oForm As Object = Nothing

        Select Case oTPPesquisa
            Case Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
                oForm = New frmPesq_Fornecedor

                oForm.Form_Pesq_CodigoNome = oPesq_CodigoNome
                oForm.Form_Pesq_Filtro = oBancoDados_Filtro
                Form_Show(Nothing, oForm, True)
            Case Pesq_CodigoNome.TPPesquisa.Pq_Logus_Movimentacao
                oForm = New frmPesq_Movimentacao

                oForm.Form_Pesq_CodigoNome = oPesq_CodigoNome
                Form_Show(Nothing, oForm, True)
            Case Pesq_CodigoNome.TPPesquisa.Pq_Logus_OperacaoBancaria
                oForm = New frmPesq_OperacaoBancaria

                oForm.Form_Pesq_CodigoNome = oPesq_CodigoNome
                oForm.Form_Pesq_Filtro = oBancoDados_Filtro
                Form_Show(Nothing, oForm, True)
            Case Pesq_CodigoNome.TPPesquisa.Pq_Logus_TipoMovimentacao
                oForm = New frmPesq_Listagem

                oForm.Form_Pesq_CodigoNome = oPesq_CodigoNome
                oForm.Form_Pesq_Filtro = oBancoDados_Filtro
                oForm.Carregar(frmPesq_Listagem.PesqLista_TipoTela.TipoMovimentacao)
                Form_Show(Nothing, oForm, True)
            Case Pesq_CodigoNome.TPPesquisa.Pq_Logus_TipoMovimentacao_Aplicacao
                oForm = New frmPesq_Listagem

                oForm.Form_Pesq_CodigoNome = oPesq_CodigoNome
                oForm.Form_Pesq_Filtro = oBancoDados_Filtro
                oForm.Carregar(frmPesq_Listagem.PesqLista_TipoTela.TipoMovimentacao_Aplicacao)
                Form_Show(Nothing, oForm, True)
            Case Pesq_CodigoNome.TPPesquisa.Pq_Logus_Freista
                oForm = New frmPesq_Listagem

                oForm.Form_Pesq_CodigoNome = oPesq_CodigoNome
                oForm.Form_Pesq_Filtro = oBancoDados_Filtro
                oForm.Carregar(frmPesq_Listagem.PesqLista_TipoTela.Fretista)
                Form_Show(Nothing, oForm, True)
            Case Pesq_CodigoNome.TPPesquisa.Pq_Logus_ContratoPAF
                oForm = New frmPesq_ContratoPAF

                oForm.Form_Pesq_CodigoNome = oPesq_CodigoNome
                oForm.Form_Pesq_Filtro = oBancoDados_Filtro
                Form_Show(Nothing, oForm, True)
            Case Pesq_CodigoNome.TPPesquisa.Pq_Logus_ContratoPAF_Fornecedor
                oForm = New frmPesq_ContratoPAF

                oForm.Form_Pesq_CodigoNome = oPesq_CodigoNome
                oForm.Form_Pesq_Filtro = oBancoDados_Filtro
                If Trim(sBancoDados_Campo_Codigo2) <> "" Then
                    oForm.Form_Pesq_Fornecedor = Val(sBancoDados_Campo_Codigo2)
                End If
                Form_Show(Nothing, oForm, True)
            Case Pesq_CodigoNome.TPPesquisa.Pq_Logus_Municipio
                oForm = New frmPesq_Municipio

                oForm.Form_Pesq_CodigoNome = oPesq_CodigoNome
                oForm.Form_Pesq_Filtro = oBancoDados_Filtro
                Form_Show(Nothing, oForm, True)
        End Select

        oForm.Dispose()
        oForm = Nothing
    End Sub

    Public Function SQL_Filial_FilialLiberaUsuario() As String
        Return "(SELECT FI.CD_FILIAL, FI.NO_FILIAL" & _
                " FROM SOF.FILIAL_LIBERADA FL," & _
                      "SOF.FILIAL FI" & _
                " WHERE FL.CD_USER = " & QuotedStr(sAcesso_UsuarioLogado) & _
                  " AND FI.CD_FILIAL = FL.CD_FILIAL" & _
                  " AND FI.IC_ATIVA = 'S'" & _
                " ORDER BY FI.NO_FILIAL)"
    End Function

    Public Function View_ARMAZEM_PILHA_LASTRO() As String
        Dim SqlText As String

        SqlText = "SELECT APL.CD_ARMAZEM," & _
                         "APL.CD_PILHA_MAE," & _
                         "APL.NR_PILHA_FILHA," & _
                         "NVL2(APL.CD_PILHA_MAE, APL.CD_PILHA_MAE, APL.CD_PILHA) CD_PILHA," & _
                         "APL.CD_PILHA CD_SUB_PILHA," & _
                         "NVL2(APL.CD_PILHA_MAE, APL.CD_PILHA_MAE + (APL.NR_PILHA_FILHA / 10), APL.CD_PILHA) CD_PILHA_FILHA," & _
                         "APL.QT_LASTRO," & _
                         "APL.NO_PILHA," & _
                         "APL.QT_SACOS," & _
                         "APL.QT_OCUPADA," & _
                         "APL.SQ_TIPO_ENDERECO_ARMAZEM," & _
                         "APL.SQ_PROCEDENCIA_LOTE," & _
                         "APL.CD_STATUS_PILHA," & _
                         "PL13.DATA_LIBERACAO," & _
                         "NVL(PL15.IC_BLOQUEADA, 'N') IC_BLOQUEADA," & _
                         "DECODE(NVL(APM.IC_ATIVO, 'N'), 'S', APL.IC_ATIVO, 'N') IC_ATIVO," & _
                         "APL.DT_CRIACAO," & _
                         "APL.NO_USER_CRIACAO," & _
                         "APL.DT_ALTERACAO," & _
                         "APL.NO_USER_ALTERACAO" & _
                  " FROM SOF.ARMAZEM_PILHA_LASTRO APL," & _
                        "SOF.ARMAZEM_PILHA_LASTRO APM," & _
                        "(SELECT DISTINCT APC.CD_ARMAZEM," & _
                                         "APC.CD_PILHA," & _
                                         "APC.DT_ITEM_CONFIGURACAO DATA_LIBERACAO" & _
                         " FROM SOF.ARMAZEM_PILHA_CONFIGURACAO APC" & _
                         " WHERE APC.CD_ITEM_CONFIGURACAO = 13) PL13," & _
                        "(SELECT DISTINCT APC.CD_ARMAZEM," & _
                                         "APC.CD_PILHA," & _
                                         "'S' IC_BLOQUEADA" & _
                         " FROM SOF.ARMAZEM_PILHA_CONFIGURACAO APC" & _
                         " WHERE APC.CD_ITEM_CONFIGURACAO = 15" & _
                           " AND APC.IC_ITEM_CONFIGURACAO = 'S') PL15" & _
                  " WHERE APM.CD_ARMAZEM (+) = APL.CD_ARMAZEM" & _
                    " AND APM.CD_PILHA (+) = APL.CD_PILHA" & _
                    " AND PL13.CD_ARMAZEM (+) = APL.CD_ARMAZEM" & _
                    " AND PL13.CD_PILHA (+) = APL.CD_PILHA" & _
                    " AND PL15.CD_ARMAZEM (+) = APL.CD_ARMAZEM" & _
                    " AND PL15.CD_PILHA (+) = APL.CD_PILHA"

        Return "(" & SqlText & ")"
    End Function

    Public Sub GeraPremioQualidade(ByVal IcStatusContratoPaf As String, _
                                   ByVal IcStatusNegociacao As String, _
                                   ByVal IcStatus As String, _
                                   ByVal ContratoPaf As Integer, _
                                   ByVal Negociacao As Integer, _
                                   ByVal ContratoFixo As Integer, _
                                   ByVal CdTipAdendo As Integer, _
                                   ByVal ValorBonus As Double)
        Dim SqlText As String

        If IcStatusContratoPaf = "F" Then
            MUDA_SITUACAO_CONTRATO_PAF(ContratoPaf, "A")
        End If
        If IcStatusNegociacao = "F" Then
            MUDA_SITUACAO_NEGOCIACAO(ContratoPaf, Negociacao, "A")
        End If
        If IcStatus = "F" Then
            MUDA_SITUACAO_CONTRATO_FIXO(ContratoPaf, Negociacao, ContratoFixo, "A")
        End If

        SqlText = DBMontar_SP("SOF.SP_INCLUI_ADENDO_CTR_FIXO", False, ":CDCTRPAF", ":NUNEG", ":NUCTRFIXO", _
                                                                      ":CDTIPOADENDO", ":VLADENDO")
        If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", ContratoPaf), _
                                   DBParametro_Montar("NUNEG", Negociacao), _
                                   DBParametro_Montar("NUCTRFIXO", ContratoFixo), _
                                   DBParametro_Montar("CDTIPOADENDO", CdTipAdendo), _
                                   DBParametro_Montar("VLADENDO", ValorBonus)) Then GoTo Erro

        SqlText = "UPDATE sof.bonus_contrato_fixo "
        SqlText = SqlText & "   SET ic_pago = 'S', "
        SqlText = SqlText & "       dt_alteracao = '" & Date_to_Oracle(DataSistema) & "', "
        SqlText = SqlText & "       no_user_alteracao = '" & sAcesso_UsuarioLogado & "'"
        SqlText = SqlText & " WHERE (sq_movimentacao, "
        SqlText = SqlText & "        cd_contrato_paf, "
        SqlText = SqlText & "        sq_ctr_paf_movimentacao, "
        SqlText = SqlText & "        sq_negociacao, "
        SqlText = SqlText & "        sq_ctr_paf_neg_movimentacao, "
        SqlText = SqlText & "        sq_contrato_fixo, "
        SqlText = SqlText & "        sq_ctr_paf_neg_ctr_fix_mov, "
        SqlText = SqlText & "        sq_movimentacao_cessao_direito "
        SqlText = SqlText & "       ) IN ( "
        SqlText = SqlText & "          SELECT bcf.sq_movimentacao, bcf.cd_contrato_paf, "
        SqlText = SqlText & "                 bcf.sq_ctr_paf_movimentacao, bcf.sq_negociacao, "
        SqlText = SqlText & "                 bcf.sq_ctr_paf_neg_movimentacao, bcf.sq_contrato_fixo, "
        SqlText = SqlText & "                 bcf.sq_ctr_paf_neg_ctr_fix_mov, "
        SqlText = SqlText & "                 bcf.sq_movimentacao_cessao_direito "
        SqlText = SqlText & "            FROM sof.bonus_contrato_fixo bcf, "
        SqlText = SqlText & "                 sof.bonus_padrao bp, "
        SqlText = SqlText & "                 sof.ctr_paf_neg_ctr_fix_mov cm, "
        SqlText = SqlText & "                 sof.contrato_paf cp, "
        SqlText = SqlText & "                 sof.contrato_fixo cf, "
        SqlText = SqlText & "                 sof.negociacao n "
        SqlText = SqlText & "           WHERE cm.sq_movimentacao = bcf.sq_movimentacao "
        SqlText = SqlText & "             AND cm.sq_movimentacao_cessao_direito = bcf.sq_movimentacao_cessao_direito "
        SqlText = SqlText & "             AND cm.cd_contrato_paf = bcf.cd_contrato_paf "
        SqlText = SqlText & "             AND cm.sq_ctr_paf_movimentacao = bcf.sq_ctr_paf_movimentacao "
        SqlText = SqlText & "             AND cm.sq_negociacao = bcf.sq_negociacao "
        SqlText = SqlText & "             AND cm.sq_ctr_paf_neg_movimentacao = bcf.sq_ctr_paf_neg_movimentacao "
        SqlText = SqlText & "             AND cm.sq_contrato_fixo = bcf.sq_contrato_fixo "
        SqlText = SqlText & "             AND cm.sq_ctr_paf_neg_ctr_fix_mov = bcf.sq_ctr_paf_neg_ctr_fix_mov "
        SqlText = SqlText & "             AND cp.cd_contrato_paf = cm.cd_contrato_paf "
        SqlText = SqlText & "             AND n.cd_contrato_paf = cm.cd_contrato_paf "
        SqlText = SqlText & "             AND n.sq_negociacao = cm.sq_negociacao "
        SqlText = SqlText & "             AND bcf.cd_contrato_paf = cf.cd_contrato_paf "
        SqlText = SqlText & "             AND bcf.sq_negociacao = cf.sq_negociacao "
        SqlText = SqlText & "             AND bcf.sq_contrato_fixo = cf.sq_contrato_fixo "
        SqlText = SqlText & "             AND bcf.ic_pago = 'N' "
        SqlText = SqlText & "             AND cf.cd_contrato_paf= " & ContratoPaf
        SqlText = SqlText & "             AND cf.sq_negociacao= " & Negociacao
        SqlText = SqlText & "             AND cf.sq_contrato_fixo= " & ContratoFixo
        SqlText = SqlText & "             AND bp.cd_bonus_padrao = bcf.cd_bonus_padrao "
        SqlText = SqlText & "             and bp.CD_TIPO_ADENDO=" & CdTipAdendo & ")"

        If Not DBExecutar(SqlText) Then GoTo Erro

        Exit Sub

Erro:
        TratarErro("GeraPremioQualidade")
    End Sub

    Public Function Documento_Relatorio_Versao_Arquivo(ByVal Documento As enDocumento_Relatorio, _
                                                       ByVal Data As Date) As String
        Return Documento_Versao_Arquivo(enDocumento_Tipo.eRelatorio, Documento, Data)
    End Function

    Public Function Documento_Relatorio_Versao_Documento(ByVal Documento As enDocumento_Relatorio, _
                                                         ByVal Data As Date) As enDocumento_Relatorio
        Return Documento_Versao_Documento(enDocumento_Tipo.eRelatorio, Documento, Data)
    End Function

    Private Function Documento_Versao_Arquivo(ByVal Tipo As enDocumento_Tipo, _
                                              ByVal Documento As enDocumento_Relatorio, _
                                              ByVal Data As Date) As String
        Dim sArquivo As String = ""

        Select Case Tipo
            Case enDocumento_Tipo.eRelatorio
                Select Case Documento
                    Case enDocumento_Relatorio.eDeclaracaoFixacao_DiferencialBolsa
                        If Data >= New Date(2011, 10, 18) Then
                            sArquivo = "RPT_DeclaracaoFixacaoPreco_DiferencialBolsa.rpt"
                        Else
                            sArquivo = "RPT_DeclaracaoFixacaoPreco.rpt"
                        End If
                    Case enDocumento_Relatorio.eDeclaracaoFixacao_DolarFlutuante
                        If Data >= New Date(2011, 10, 18) Then
                            sArquivo = "RPT_DeclaracaoFixacaoPreco_DolarFlutuante.rpt"
                        Else
                            sArquivo = "RPT_DeclaracaoFixacaoPreco.rpt"
                        End If
                End Select
        End Select

        Return sArquivo
    End Function

    Private Function Documento_Versao_Documento(ByVal Tipo As enDocumento_Tipo, _
                                                ByVal Documento As enDocumento_Relatorio, _
                                                ByVal Data As Date) As enDocumento_Relatorio
        Dim DocumentoRetorno As enDocumento_Relatorio

        DocumentoRetorno = Documento

        Select Case Tipo
            Case enDocumento_Tipo.eRelatorio
                Select Case Documento
                    Case enDocumento_Relatorio.eDeclaracaoFixacao_DiferencialBolsa, enDocumento_Relatorio.eDeclaracaoFixacao_DolarFlutuante
                        If Data < New Date(2011, 2, 21) Then
                            DocumentoRetorno = enDocumento_Relatorio.eDeclaracaoFixacao
                        End If
                    Case enDocumento_Relatorio.eNegociacao_ContratoPAF_Master, enDocumento_Relatorio.eContratoPAF_PAFComADTO_2010
                        If Data < New Date(2011, 2, 21) Then
                            DocumentoRetorno = enDocumento_Relatorio.eNegociacao
                        End If
                    Case enDocumento_Relatorio.eContratoPAF_Master
                        If Data < New Date(2010, 12, 7) Then
                            DocumentoRetorno = enDocumento_Relatorio.eContratoPAF
                        Else
                            DocumentoRetorno = enDocumento_Relatorio.eContratoPAF_Master
                        End If
                    Case enDocumento_Relatorio.eContratoPAF
                        If Data < New Date(2010, 12, 7) Then
                            DocumentoRetorno = enDocumento_Relatorio.eContratoPAF
                            'ElseIf Data < New Date(2011, 2, 21) Then
                        Else
                            DocumentoRetorno = enDocumento_Relatorio.eContratoPAF_2011
                        End If
                    Case enDocumento_Relatorio.eContratoPAF_PrecoFixo
                        If Data < New Date(2011, 2, 21) Then
                            DocumentoRetorno = enDocumento_Relatorio.eContratoPAF
                        Else
                            DocumentoRetorno = enDocumento_Relatorio.eSemImpressao
                        End If
                    Case enDocumento_Relatorio.eNegociacao
                        If Data >= New Date(2011, 2, 21) Then
                            DocumentoRetorno = enDocumento_Relatorio.eSemImpressao
                        End If
                    Case enDocumento_Relatorio.eNegociacao_Aditamento
                        'If Data < New Date(2011, 2, 21) Then
                        DocumentoRetorno = enDocumento_Relatorio.eNegociacao_Aditamento
                        'End If
                End Select
        End Select

        Return DocumentoRetorno
    End Function

    Public Function Bolsa_Extenso(ByVal CD_PERIODO_BOLSA As String, _
                                  ByVal DataBase As Date) As String
        Dim sAux As String = ""

        Select Case Mid(CD_PERIODO_BOLSA, 3, 1)
            Case "H"
                sAux = "Março"
            Case "K"
                sAux = "Maio"
            Case "N"
                sAux = "Julho"
            Case "U"
                sAux = "Setembro"
            Case "Z"
                sAux = "Dezembro"
        End Select

        If Int(Mid(DataBase.Year, 1, 3) & Mid(CD_PERIODO_BOLSA, 4, 1)) > DataBase.Year Then
            sAux = sAux & " de " & Int(Mid(DataBase.Year, 1, 3) & Mid(CD_PERIODO_BOLSA, 4, 1)) - 10
        Else
            sAux = sAux & " de " & Int(Mid(DataBase.Year, 1, 3) & Mid(CD_PERIODO_BOLSA, 4, 1))
        End If

        sAux = sAux & " (" & Trim(CD_PERIODO_BOLSA) & ")"

        Return sAux
    End Function

    Public Function PrecoMedioRD(ByVal DataBase As String) As Double
        Dim oData As DataTable
        Dim SqlText As String

        Dim VL_TOTAL As Double
        Dim QT_TOTAL As Double

        Dim DT_RD As Date

        SqlText = "SELECT MAX(DT_MOVIMENTO)" & _
                  " FROM SOF.RESUMO_DIARIO_ESTOQUE" & _
                  " WHERE DT_MOVIMENTO <= " & QuotedStr(Date_to_Oracle(DataBase))
        DT_RD = DBQuery_ValorUnico(SqlText, DataBase)

        'Pega o saldo final de todas as filiais   
        SqlText = "SELECT SUM(VL_MENSAL) VL_MENSAL," & _
                         "SUM(QT_KG_MENSAL) QT_KG_MENSAL" & _
                  " FROM SOF.RESUMO_DIARIO_ESTOQUE RD," & _
                        "(SELECT CD_TP_MOV_SALDO_FINAL" & _
                         " FROM SOF.TIPO_RD" & _
                         " WHERE CD_TIPO_RD IN (SELECT CD_TIPO_RD" & _
                                               " FROM SOF.TRANSFERENCIA_MODALIDADE MD," & _
                                                     "SOF.TIPO_MOVIMENTACAO TM" & _
                                               " WHERE MD.IC_MOVIMENTACAO_SILO = 'S'" & _
                                                 " AND TM.CD_TIPO_MOVIMENTACAO = MD.CD_TIPO_MOVIMENTACAO_SAIDA)) TR" & _
                  " WHERE CD_TIPO_MOVIMENTACAO = TR.CD_TP_MOV_SALDO_FINAL" & _
                    " AND DT_MOVIMENTO = " & QuotedStr(Date_to_Oracle(DT_RD))
        oData = DBQuery(SqlText)

        VL_TOTAL = VL_TOTAL + NVL(oData.Rows(0).Item("VL_MENSAL"), 0)
        QT_TOTAL = QT_TOTAL + NVL(oData.Rows(0).Item("QT_KG_MENSAL"), 0)

        'Diminuo as saidas da filial fabrica, menos aquelas de uma lista pre-definida
        SqlText = "SELECT SUM(VL_MENSAL) VL_MENSAL," & _
                         "SUM(QT_KG_MENSAL) QT_KG_MENSAL" & _
                  " FROM SOF.PARAMETRO PR," & _
                        "SOF.RESUMO_DIARIO_ESTOQUE" & _
                  " WHERE CD_FILIAL_ORIGEM = PR.CD_FILIAL_MAE" & _
                    " AND IC_ENTRADA_SAIDA = 'S'" & _
                    " AND CD_TIPO_MOVIMENTACAO NOT IN (SELECT T.CD_TIPO_MOVIMENTACAO " & _
                                                      " FROM SOF.PARAMETRO_MODALIDADE_TIPO_MOV T " & _
                                                      " WHERE T.CD_PARAMETRO_MODALIDADE = 13)" & _
                    " AND DT_MOVIMENTO = " & QuotedStr(Date_to_Oracle(DT_RD))
        oData = DBQuery(SqlText)

        VL_TOTAL = VL_TOTAL + NVL(oData.Rows(0).Item("VL_MENSAL"), 0)
        QT_TOTAL = QT_TOTAL + NVL(oData.Rows(0).Item("QT_KG_MENSAL"), 0)

        'Inclui transito
        SqlText = "SELECT SUM(M.VL_NF) VL_TRANSITO," & _
                         "SUM(M.QT_KG_LIQUIDO_NF) QT_TRANSITO" & _
                  " FROM SOF.TRANSFERENCIA T," & _
                        "SOF.MOVIMENTACAO M," & _
                        "SOF.TRANSFERENCIA_MODALIDADE TM" & _
                 " WHERE T.SQ_MOVIMENTACAO_SAIDA = M.SQ_MOVIMENTACAO" & _
                   " AND T.CD_TRANSFERENCIA_MODALIDADE = TM.CD_TRANSFERENCIA_MODALIDADE" & _
                   " AND TM.IC_POSSUI_TRANSITO = 'S'" & _
                   " AND TM.IC_TIPO_UTILIZACAO NOT IN ('T')" & _
                   " AND TM.CD_TIPO_MOVIMENTACAO_SAIDA = M.CD_TIPO_MOVIMENTACAO" & _
                   " AND ((" & QuotedStr(Date_to_Oracle(DT_RD)) & " BETWEEN T.DT_TRANSFERENCIA AND NVL(T.DT_CHEGADA, " & QuotedStr(Date_to_Oracle(DT_RD.AddDays(1))) & ")) AND" & _
                        " NVL(T.DT_CHEGADA," & QuotedStr(Date_to_Oracle(DT_RD.AddDays(1))) & ") <> " & QuotedStr(Date_to_Oracle(DT_RD)) & ")"
        oData = DBQuery(SqlText)

        VL_TOTAL = VL_TOTAL + NVL(oData.Rows(0).Item("VL_TRANSITO"), 0)
        QT_TOTAL = QT_TOTAL + NVL(oData.Rows(0).Item("QT_TRANSITO"), 0)

        If NVL(QT_TOTAL, 0) = 0 Then
            QT_TOTAL = 1
        End If

        Return Math.Round((VL_TOTAL / QT_TOTAL), 4)
    End Function

    Public Function GerenciadorArquivo_Senha() As String
        Return ""
    End Function
End Module