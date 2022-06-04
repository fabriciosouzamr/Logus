Module Declaracao
    '*---------------------------------------------------------------------------------------------------*
    '*                            V A R I A V E I S   E N U M E R A D A S                                *
    '*---------------------------------------------------------------------------------------------------*
    '*---------------------------------------------------------------------------------------------------*
    '*                            V A R I A V E I S   E   C O N S T A N T E S                            *
    '*---------------------------------------------------------------------------------------------------*

    '>>> Ref. ao sistema
    Public Sis_NomeSistema As String
    Public Sis_CampoRegistro As String

    '>>> Acesso - Informações
    Public sAcesso_UsuarioLogado As String
    Public sAcesso_UsuarioLogado_DS As String
    Public sAcesso_NomeUsuarioLogado As String
    Public iAcesso_DiaSemUsoBloqueio As Integer = 30

    '>>> Informações do Usuário
    Public sUsuario_EMail As String
    Public Usuario_Tipo As Integer

    Public cnt_Usuario_Status_Ativo = "S"
    Public cnt_Usuario_Status_Inativo = "N"
    Public cnt_Usuario_Status_EliminadoSO = "E"

    Public cnt_Usuario_StatusDescricao_Ativo = "Ativo"
    Public cnt_Usuario_StatusDescricao_Inativo = "Inativo"
    Public cnt_Usuario_StatusDescricao_EliminadoSO = "Eliminado SO"

    '>>> Banco de Dados
    Public bBancoDados_CtrlAcesso_MultiSistema As Boolean = False
    Public sBancoDados_OwnerCtrlAcesso As String
    Public sBancoDados_OwnerPadrao As String
    Public sBancoDados_OwnerSistemaEMail As String
    Public sBancoDados_BancoDadosLogado As String

    '>>> Ref. ao controles do sistema
    Public oImagemList As ImageList

    '>>> Variável de acesso ao dbcontrol
    Public Const cnt_DBControl_Usuario_ILH01P As String = "AGCSEC"
    Public Const cnt_DBControl_Usuario_SPO10D As String = "AGCSEC"
    Public Const cnt_DBControl_Usuario As String = "AGCSEC"
    Public Const cnt_DBControl_Chave As Integer = 123456
    Public Const cnt_DBControl_Bit As Byte = 7
    Public Const cnt_DBControl_Sistema As String = "DS"

    '>>> Formatação de valores
    Public Const cnt_Formato_Data As String = "dd/MM/yyyy"
    Public Const cnt_Formato_DataHoraCurta As String = "dd/MM/yyyy HH:mm"
    Public Const cnt_Formato_DataHora As String = "dd/MM/yyyy HH:mm:ss"
    Public Const cnt_Formato_Hora As String = "HH:mm:ss"
    Public Const cnt_Formato_Valor As String = "R$ ###,###,##0.00"
    Public Const cnt_Formato_Valor_4casas As String = "R$ ###,###,##0.0000"
    Public Const cnt_Formato_Valor_US As String = "US$ ###,###,##0.00"
    Public Const cnt_Formato_Valor_EU As String = "€ ###,###,##0.00"
    Public Const cnt_Formato_Valor_US_4casas As String = "US$ ###,###,##0.0000"
    Public Const cnt_Formato_Kilos As String = "###,###,##0"
    Public Const cnt_Formato_NumeroInteiro As String = "########0"
    Public Const cnt_Formato_Porcentagem As String = "###,###,##0.00 %"
    Public Const cnt_Formato_Procentagem_4casas As String = "###,###,##0.0000"
    Public Const cnt_Formato_Fracao_Simples As String = "##0.00"
    Public Const cnt_Formato_Fracao As String = "###,###,##0.00"
    Public Const cnt_Formato_Fracao_4casas As String = "###,###,##0.0000"
    Public Const cnt_Formato_Fracao_8casas As String = "###,###,##0.00000000"
    Public Const cnt_Formato_CNPJ As String = "##.###.###/####-##"
    Public Const cnt_Formato_CPF As String = "###.###.###-##"
    Public Const cnt_Formato_CEP As String = "#####-###"
    Public Const cnt_Formato_Imagem As String = "@"
    Public Const cnt_Formato_Telefone As String = "(##) ####-####"

    '>>> Utilizado na tela de E-Mail
    Public Const cnt_EMail_Recebido As Integer = 1
    Public Const cnt_EMail_Enviado As Integer = 2

    '>>> Utilizado no Envio de E-Mail - Início
    Public cnt_EMail_From_Proc As String = "SEE - Sistema de Envio de E-Mail <donotreply@cargill.com>"

    Public Const cnt_EMail_Prioridade_Baixa As String = "B"
    Public Const cnt_EMail_Prioridade_Media As String = "M"
    Public Const cnt_EMail_Prioridade_Alta As String = "A"

    Public Const cnt_TipoHorario_HoraEspecifica As String = "E"
    Public Const cnt_TipoHorario_IntervaloMinuto As String = "M"
    Public Const cnt_TipoHorario_IntervaloHora As String = "H"
    Public Const cnt_TipoHorario_IntervaloDia As String = "D"

    Public Const cnt_EMail_NrDiaExclusaoAposEnvio As Integer = 7
    Public Const cnt_EMail_NrHoraIntervaloSolicitacaoCadastroEMail As Integer = 3

    Public Const cnt_HoraTrabalho_Ini As String = "07:00"
    Public Const cnt_HoraTrabalho_Fim As String = "20:00"
    '>>> Utilizado no Envio de E-Mail - Fim

    Public sEMail_Usuario_Cadastro As String
    Public sNome_Usuario_Cadastro As String
    Public sEMail_Usuario_Tecnico As String
    Public sNome_Usuario_Tecnico As String

    Public Enum eDbType
        _Inteiro = 1
        _Numero = 2
        _Data = 3
        _Texto = 4
        _Decimal = 5
    End Enum

    Public Class cEmail_HTML_Linha
        Public Coluna_01_Texto As String
        Public Coluna_01_Negrito As Boolean
        Public Coluna_02_Texto As String
        Public Coluna_02_Memo As Boolean
        Public Coluna_02_Negrito As Boolean
        Public Coluna_02_Link As Boolean
        Public Coluna_02_Link_Texto As String
    End Class

    '>>> Formatação
    Public Const cnt_FormatoValor_Produto As Integer = -1
    Public Const cnt_FormatoValor_Batch As Integer = -2
    Public Const cnt_FormatoValor_Manobra As Integer = -3
    Public Const cnt_FormatoValor_Linha As Integer = -4
    Public Const cnt_FormatoValor_SimNao As Integer = 1
    Public Const cnt_FormatoValor_Quantidade As Integer = 2
    Public Const cnt_FormatoValor_Valor As Integer = 3
    Public Const cnt_FormatoValor_Porcentagem As Integer = 4
    Public Const cnt_FormatoValor_Inteiro As Integer = 5
    Public Const cnt_FormatoValor_Calculado As Integer = 6
    Public Const cnt_FormatoValor_MateriaPrima As Integer = 7

    '>>> Controle de Acesso
    Public Const cnt_SEC_TipoAcesso_Inclusao As Integer = 1
    Public Const cnt_SEC_TipoAcesso_Exclusao As Integer = 2
    Public Const cnt_SEC_TipoAcesso_Alteracao As Integer = 3
    Public Const cnt_SEC_TipoAcesso_Consulta As Integer = 4
    Public Const cnt_SEC_TipoAcesso_Ativo As Integer = 5

    '>>> Status de Ordem de Serviço
    Public Const cnt_Status_EmAnalise As Integer = 1
    Public Const cnt_Status_Cancelada As Integer = 2
    Public Const cnt_Status_AguardandoExecucao As Integer = 3
    Public Const cnt_Status_Executada As Integer = 4

    '>>> Biometria - Finger
    Public Const cnt_TipoAcesso_DS_DirectoryService As Integer = 1
    Public Const cnt_TipoAcesso_SenhaSistema As Integer = 2

    '>>> Tipo da Pessoa
    Public Const cnt_TipoPessoa_PRODUTOR As Integer = 1
    Public Const cnt_TipoPessoa_EAGRICOLA As Integer = 2
    Public Const cnt_TipoPessoa_AGREGADO As Integer = 3
    Public Const cnt_TipoPessoa_INTERFIRMA As Integer = 4
    Public Const cnt_TipoPessoa_REPASSADOR As Integer = 5
    Public Const cnt_TipoPessoa_IMPORTADO As Integer = 6
    Public Const cnt_TipoPessoa_COOPERATIVA As Integer = 7
    Public Const cnt_TipoPessoa_ASSOCIACAO As Integer = 8
    Public Const cnt_TipoPessoa_PROCURADOR As Integer = 9

    Public sGerenciadorArquivo_Mapeamento As String = "\\10.117.2.48\Data1"
    Public sGerenciadorArquivo_Diretorio As String
    Public sGerenciadorArquivo_Usuario As String = "la\SECCRM"
    'Public sGerenciadorArquivo_Senha As String = "Cacau#002"
    Public sGerenciadorArquivo_DriveMap As String = ""
    Public sGerenciadorArquivo_DriveUnMap As String = ""

    Public Enum Moeda
        Real = 6
        Dolar = 7
        Euro = 183
    End Enum

    Public Enum eControleEdicaoTela
        SemDefinicao = 0
        INCLUIR = 1
        ALTERAR = 2
        FINALIZAR_PARADA = 3
        ALTERAR_SENHA = 4
        PRE_NEGOCIACAO = 5
    End Enum

    Public Enum TipoValidacaoUsuario
        _Acesso = 1
        _Desbloqueio = 2
        _UsuarioLogado = 3
        _UsuarioEspecifico = 4
    End Enum

    Public Class DataTable_Column
        Public Nome As String
        Public Tipo As eDbType = eDbType._Texto
    End Class

    Public ControleEdicaoTela As eControleEdicaoTela
    Public Filtro As Integer
    Public Filtro1 As Integer
    Public FiltroStr As String
End Module