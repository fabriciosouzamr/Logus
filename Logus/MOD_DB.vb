Imports System.Data.OracleClient
Imports System.Configuration

Public Class DBParamentro
    Public Nome As String
    Public Valor As Object
    Public Tipo As OracleType
    Public Direcao As ParameterDirection
    Public Tamanho As Integer
End Class

Public Enum TipoCampoFixo
    Todos = -1
    Nenhum = 0
    DadoCriacao = 1
    DadoAlteracao = 2
    DadoExclusao = 3
End Enum

Public Enum BancoConeccao
    Sistema = 1
    Ilheus = 2
    SPO60P = 3
    Luminis = 4
    BancoGeral = 5
End Enum

Public Class DBWhere
    Public Query As String
    Public NomeCampo As String
    Public ValorCampo As String
End Class

Module MOD_DB
    Public oDB_01 As OracleConnection
    Public oDB_02 As OracleConnection
    Public oDB_03 As OracleConnection

    Public oTipoComando As System.Data.CommandType = CommandType.Text
    Public bUsarTransacao As Boolean

    Dim oTrans As OracleTransaction
    Dim oRetorno As Microsoft.VisualBasic.Collection
    Dim MsgErr As String
    Dim bErro As Boolean
    Dim bExibirErro As Boolean = True
    Dim oBancoConeccao_Uso As BancoConeccao = BancoConeccao.Sistema

    Public Sub DBBanco_Uso(ByVal oBancoConeccao As BancoConeccao)
        oBancoConeccao_Uso = oBancoConeccao
    End Sub

    Public Function DBBanco_Atual() As BancoConeccao
        Return oBancoConeccao_Uso
    End Function

    Public Function DBConectar(Optional ByVal oBancoConeccao As BancoConeccao = BancoConeccao.Sistema, _
                               Optional ByVal BancoDados_Coneccao As String = "", _
                               Optional ByVal BancoDados_Usuario As String = "", _
                               Optional ByVal BancoDados_Senha As String = "") As Boolean
        Dim oDBControlX As New DBControlX.DBControlX

        On Error GoTo Erro

        Dim Senha As String = ""
        Dim sUsuarioDB As String = "AGCSEC"

        If Trim(BancoDados_Coneccao) = "" Then
            If oBancoConeccao = BancoConeccao.Luminis Then
                sBancoDados_BancoDadosLogado = "PSPSHR02"
            ElseIf oBancoConeccao = BancoConeccao.Ilheus Then
                sBancoDados_BancoDadosLogado = "ILH01P"
            Else
                sBancoDados_BancoDadosLogado = System.Web.Configuration.WebConfigurationManager.AppSettings("SERVER").ToString.ToUpper()
            End If
        Else
            sBancoDados_BancoDadosLogado = BancoDados_Coneccao
        End If

        Select Case oBancoConeccao
            Case BancoConeccao.SPO60P
                sUsuarioDB = "VPSOUZA"
            Case BancoConeccao.BancoGeral
                sUsuarioDB = BancoDados_Usuario
            Case sBancoDados_BancoDadosLogado = "ILH01P", oBancoConeccao = BancoConeccao.Ilheus
                sUsuarioDB = cnt_DBControl_Usuario_ILH01P
            Case sBancoDados_BancoDadosLogado = "SPO10D"
                sUsuarioDB = cnt_DBControl_Usuario_SPO10D
            Case Else
                sUsuarioDB = cnt_DBControl_Usuario
        End Select

        Select Case oBancoConeccao
            Case BancoConeccao.SPO60P
                Senha = "cacau008"
            Case BancoConeccao.BancoGeral
                Senha = BancoDados_Senha
            Case Else
                Senha = oDBControlX.GS_SenharUsuarioBanco(sBancoDados_BancoDadosLogado, sUsuarioDB, _
                                                          cnt_DBControl_Chave, cnt_DBControl_Bit)
        End Select

        oDBControlX = Nothing

        If Trim(Senha) <> "" Then
            Select Case oBancoConeccao
                Case BancoConeccao.Sistema
                    oDB_01 = New OracleConnection
                    oDB_01.ConnectionString = "user id=" & sUsuarioDB & _
                                              ";data source=" & sBancoDados_BancoDadosLogado & _
                                              ";password=" & Senha
                    oDB_01.Open()
                Case BancoConeccao.Ilheus, BancoConeccao.Luminis
                    oDB_02 = New OracleConnection
                    oDB_02.ConnectionString = "user id=" & sUsuarioDB & _
                                              ";data source=" & sBancoDados_BancoDadosLogado & _
                                              ";password=" & Senha
                    oDB_02.Open()
                Case BancoConeccao.SPO60P, BancoConeccao.BancoGeral
                    oDB_03 = New OracleConnection
                    oDB_03.ConnectionString = "user id=" & sUsuarioDB & _
                                              ";data source=SPO60P" & _
                                              ";password=" & Senha
                    oDB_03.Open()
            End Select
        Else
            If bExibirErro Then
                Err.Raise(60000, "", "Não foi possível acessar o DBControlX")
            Else
                MsgError_Setar("Não foi possível acessar o DBControlX")
            End If
        End If

        Return True

Erro:
        Call Erro_Tratar("MOD_DB.DBConectar")
    End Function

    Public Sub DBDesconectar(Optional ByVal oBancoConeccao As BancoConeccao = BancoConeccao.Sistema)
        Dim oBancoDados As OracleConnection

        oBancoDados = DBBancoDados(oBancoConeccao)

        If Not oBancoDados Is Nothing Then
            If oBancoDados.State = ConnectionState.Open Then
                oBancoDados.Close()
            End If

            oBancoDados.Dispose()
        End If

        oBancoDados = Nothing

        Select Case oBancoConeccao
            Case BancoConeccao.Sistema
                oDB_01 = Nothing
            Case BancoConeccao.Ilheus, BancoConeccao.Luminis
                oDB_02 = Nothing
            Case BancoConeccao.SPO60P, BancoConeccao.BancoGeral
                oDB_03 = Nothing
        End Select
    End Sub

    Public Function DBExecutar(ByVal SqlText As String, _
                               ByVal ParamArray Parametro() As DBParamentro) As Boolean
        Dim iLinhaAfetada As Integer

        Return DBExecutar_LinhaAfetadas(SqlText, iLinhaAfetada, Parametro)
    End Function

    Public Function DBExecutar_LinhaAfetadas(ByVal SqlText As String, _
                                             ByRef iLinhaAfetada As Integer, _
                                             ByVal ParamArray Parametro() As DBParamentro) As Boolean
        Dim oAux As DBParamentro
        Dim oCommand As New OracleCommand
        Dim oParametro As OracleParameter
        Dim bOutPutParametro As Boolean
        Dim bRetornoParametro As Boolean

        sAcesso_UsuarioLogado = UCase(sAcesso_UsuarioLogado)

        'If cnt_Sistema_ControleAcesso = 2 Then
        '    If UCase(Trim(System.Web.Configuration.WebConfigurationManager.AppSettings("SERVER").ToString.ToUpper())) = "ILH01P" _
        '       And (sAcesso_UsuarioLogado = "FAMOREIR" Or sAcesso_UsuarioLogado = "VPSOUZA" Or sAcesso_UsuarioLogado = "TASANTOS") Then
        '        Msg_Mensagem("Esse usuário não tem permissão para fazer alterações na base de produção")
        '        Return True
        '        Exit Function
        '    End If
        'End If

        Call LimparErro()

        Try
            oCommand = DBBancoDados(oBancoConeccao_Uso).CreateCommand

            If bUsarTransacao Then oCommand.Transaction = oTrans

            oCommand.CommandType = oTipoComando
            oTipoComando = CommandType.Text

            If Parametro Is Nothing Then
                oCommand.CommandText = SqlText
                oCommand.ExecuteNonQuery()
            Else
                oCommand.CommandText = SqlText
                oCommand.Prepare()

                For Each oAux In Parametro
                    Select Case oAux.Direcao
                        Case ParameterDirection.InputOutput, ParameterDirection.Output
                            bOutPutParametro = True
                        Case ParameterDirection.ReturnValue
                            bRetornoParametro = True
                    End Select

                    oParametro = New OracleParameter
                    oParametro = oCommand.CreateParameter

                    With oParametro
                        .ParameterName = oAux.Nome

                        .Direction = oAux.Direcao

                        If oAux.Valor Is Nothing Then
                            .Value = System.DBNull.Value
                        Else
                            .Value = oAux.Valor
                        End If

                        If oAux.Tamanho > 0 Then
                            .Size = oAux.Tamanho
                        End If
                    End With

                    oCommand.Parameters.Add(oParametro)
                Next

                If bOutPutParametro Or bRetornoParametro Then
                    Dim iCont As Integer

                    iLinhaAfetada = oCommand.ExecuteReader().RecordsAffected

                    oRetorno = New Microsoft.VisualBasic.Collection

                    For iCont = 0 To oCommand.Parameters.Count - 1
                        If oCommand.Parameters(iCont).Direction = ParameterDirection.Output Or _
                           oCommand.Parameters(iCont).Direction = ParameterDirection.InputOutput Or _
                           oCommand.Parameters(iCont).Direction = ParameterDirection.ReturnValue Then
                            oRetorno.Add(oCommand.Parameters(iCont).Value)
                        End If
                    Next
                ElseIf bRetornoParametro Then
                    oRetorno = New Microsoft.VisualBasic.Collection

                    oRetorno.Add(oCommand.ExecuteScalar)
                Else
                    iLinhaAfetada = oCommand.ExecuteNonQuery()
                End If
            End If

            oTipoComando = CommandType.Text

            Return True

            Exit Function
        Catch eDB As OracleException
            MsgErr = eDB.Message
            Call Erro_Tratar("MOD_DB.DBExecutar_LinhaAfetadas (OracleException)", SqlText & _
                             vbCrLf & vbCrLf & DBOracle_Parametro_ListarValores(oCommand.Parameters))
            Return False
        Catch ex As Exception
            Call Erro_Tratar("MOD_DB.DBExecutar_LinhaAfetadas (Exception)", SqlText & _
                             vbCrLf & vbCrLf & DBOracle_Parametro_ListarValores(oCommand.Parameters))
            Return False
        End Try
    End Function

    Private Function DBOracle_Parametro_ListarValores(ByVal oParamentros As System.Data.OracleClient.OracleParameterCollection) As String
        Dim sAux As String = ""
        Dim iCont As Integer

        Try
            If Not oParamentros Is Nothing Then
                For iCont = 0 To oParamentros.Count - 1
                    With oParamentros(iCont)
                        If CampoNulo(.Value) Then
                            Str_Adicionar(sAux, Trim(.ParameterName) & " = NULL", vbCrLf)
                        Else
                            Str_Adicionar(sAux, Trim(.ParameterName) & " = " & .Value.ToString, vbCrLf)
                        End If
                    End With
                Next

                sAux = "Valores usados na query" & vbCrLf & _
                       sAux
            End If
        Catch ex As Exception
            sAux = ""
        End Try

        Return sAux
    End Function

    Public Function DBExecutarTransacao(Optional ByVal bCommit As Boolean = True) As Boolean
        If Not bUsarTransacao Then
            Return True
            Exit Function
        End If

        On Error GoTo Erro

        Call LimparErro()

        If bCommit Then
            If cnt_Sistema_ControleAcesso <> 4 And cnt_Sistema_ControleAcesso <> 5 Then
                DBExecutar("DELETE FROM " & sBancoDados_OwnerPadrao & ".TMP_PROCESSO")
            End If

            oTrans.Commit()
        Else
            oTrans.Rollback()
        End If

        oTrans.Dispose()

        bUsarTransacao = False

        Return True

        Exit Function

Erro:
        Call Erro_Tratar("MOD_DB.DBExecutarTransacao")
    End Function

    Public Function DBExecutar_Insert(ByVal Tabela As String, _
                                  ByVal CampoFixo As Boolean, _
                                  ByVal ParamArray CampoValor() As Object) As Boolean
        Dim SqlText As String

        If DBContemErro() Then
            Return False
        End If

        SqlText = DBMontar_Insert(Tabela, CampoFixo, CampoValor)

        Return DBExecutar(SqlText)
    End Function

    Public Function DBExecutar_Update(ByVal Tabela As String, _
                                      ByVal CampoValor As Object, _
                                      ByVal Where As Object, _
                                      Optional ByVal CampoFixo As Boolean = True) As Boolean
        Dim SqlText As String

        If DBContemErro() Then
            Return False
        End If

        SqlText = DBMontar_Update(Tabela, CampoValor, Where, CampoFixo)

        Return DBExecutar(SqlText)
    End Function

    Public Function DBExecutar_Delete(ByVal Tabela As String, _
                                      ByVal ParamArray Where() As Object) As Boolean
        Dim SqlText As String
        Dim sWhere As String = String.Empty
        Dim Aux As String
        Dim bCampo As Boolean
        Dim bOperador As Boolean

        If DBContemErro() Then
            Return False
        End If

        Tabela = DBObjeto_TratarNome(Tabela)

        bCampo = True

        For Each Aux In Where
            If bCampo Then
                sWhere = sWhere + Aux
                bCampo = False
            ElseIf bOperador Then
                sWhere = sWhere + " " + Aux + " "
                bCampo = True
                bOperador = False
            Else
                If UCase(Aux) = "IS NULL" Then
                    sWhere = sWhere & " is null "
                Else
                    sWhere = sWhere & " = " & Aux
                End If

                bOperador = True
            End If
        Next

        SqlText = "Delete from " & Tabela & " where " & sWhere

        Return DBExecutar(SqlText)
    End Function

    Public Function DBMontar_Insert(ByVal Tabela As String, _
                                    ByVal CampoFixo As TipoCampoFixo, _
                                    ByVal ParamArray CampoValor() As Object) As String
        Dim SqlText As String
        Dim Campo As String = String.Empty
        Dim Valor As String = String.Empty
        Dim Aux As String
        Dim bCampo As Boolean

        Tabela = DBObjeto_TratarNome(Tabela)

        bCampo = True

        For Each Aux In CampoValor
            If Trim(Aux) <> "" Then
                If bCampo Then
                    If Trim(Campo) <> "" Then Campo = Campo & ","
                    Campo = Campo + Aux
                Else
                    If Trim(Valor) <> "" Then Valor = Valor & ","

                    If IsNumeric(Aux) Then
                        Valor = Valor + ConvValorFormatoAmericano(Aux)
                    Else
                        Valor = Valor + NuloString(Aux)
                    End If
                End If

                bCampo = (Not bCampo)
            End If
        Next

        If CampoFixo = TipoCampoFixo.Todos Or CampoFixo = TipoCampoFixo.DadoCriacao Then
            If Trim(Campo) <> "" Then Campo = Campo & ","
            If Trim(Valor) <> "" Then Valor = Valor & ","

            Campo = Campo & "dt_Criacao, no_User_Criacao"
            Valor = Valor & "sysdate, " & UCase(QuotedStr(sAcesso_UsuarioLogado))
        End If

        If CampoFixo = TipoCampoFixo.Todos Or CampoFixo = TipoCampoFixo.DadoAlteracao Then
            If Trim(Campo) <> "" Then Campo = Campo & ","
            If Trim(Valor) <> "" Then Valor = Valor & ","

            Campo = Campo & "dt_Alteracao, no_User_Alteracao"
            Valor = Valor & "sysdate, " & UCase(QuotedStr(sAcesso_UsuarioLogado))
        End If

        SqlText = "Insert into " & Tabela & " (" & Campo & ") values (" & Valor & ")"

        Return SqlText
    End Function

    Public Function DBMontar_Update(ByVal Tabela As String, _
                                    ByVal CampoValor As Object, _
                                    ByVal Where As Object, _
                                    Optional ByVal CampoFixo As Boolean = True, _
                                    Optional ByVal CampoExclusao As Boolean = False) As String
        Dim SqlText As String
        Dim sCampo As String = String.Empty
        Dim sWhere As String = String.Empty
        Dim Aux As String
        Dim bCampo As Boolean
        Dim bOperador As Boolean

        Tabela = DBObjeto_TratarNome(Tabela)

        bCampo = True

        If Not CampoValor Is Nothing Then
            For Each Aux In CampoValor
                If bCampo Then
                    If Trim(sCampo) <> "" Then sCampo = sCampo & ","
                    sCampo = sCampo + NuloString(Aux)
                Else
                    If IsNumeric(Aux) Then
                        sCampo = sCampo & " = " & ConvValorFormatoAmericano(Aux)
                    Else
                        sCampo = sCampo & " = " & NuloString(Aux)
                    End If
                End If

                bCampo = (Not bCampo)
            Next
        End If

        bCampo = True

        If Not Where Is Nothing Then
            For Each Aux In Where
                If bCampo Then
                    sWhere = sWhere + Aux
                    bCampo = False
                ElseIf bOperador Then
                    sWhere = sWhere + " " + Aux + " "
                    bCampo = True
                    bOperador = False
                Else
                    If UCase(Aux) = "IS NULL" Then
                        sWhere = sWhere & " is null "
                    Else
                        sWhere = sWhere & " = " & Aux
                    End If

                    bOperador = True
                End If
            Next
        End If

        If CampoFixo Then
            If Trim(sCampo) <> "" Then sCampo = sCampo + ", "
            sCampo = sCampo & "dt_Alteracao = sysdate, no_User_Alteracao = " & UCase(QuotedStr(sAcesso_UsuarioLogado))
        End If
        If CampoExclusao Then
            If Trim(sCampo) <> "" Then sCampo = sCampo + ", "
            sCampo = sCampo & "dt_Exclusao = sysdate, no_User_Exclusao = " & UCase(QuotedStr(sAcesso_UsuarioLogado))
        End If

        SqlText = "Update " & Tabela & " set " & sCampo

        If Trim(sWhere) <> "" Then
            SqlText = SqlText & " where " & sWhere
        End If

        Return SqlText
    End Function

    Public Function DBMontar_Where(ByVal Query As String, _
                                   ByVal Campo As String, _
                                   ByVal Valor As String) As DBWhere
        Dim oWhere As New DBWhere

        With oWhere
            .Query = Query
            .NomeCampo = Campo
            .ValorCampo = Valor
        End With

        Return oWhere
    End Function

    Public Function DBMontar_SP(ByVal SP As String, _
                                ByVal CampoErro As Boolean, _
                                ByVal ParamArray Campo() As Object) As String
        Dim SqlText As String
        Dim Parametro As String = String.Empty
        Dim Aux As String

        For Each Aux In Campo
            If Trim(Parametro) <> "" Then Parametro = Parametro & ","

            If IsNumeric(Aux) Then
                Aux = ConvValorFormatoAmericano(Aux)
            End If

            Parametro = Parametro + Aux
        Next

        If CampoErro Then
            Parametro = Parametro & ", :P_Erro"
        End If

        SqlText = "CALL " & SP & " (" & Parametro & ")"

        Return SqlText
    End Function

    Public Function DBMontar_Function(ByVal sFunction As String, _
                                      ByVal ParamArray Campo() As Object) As String
        Dim SqlText As String
        Dim Parametro As String = String.Empty
        Dim Aux As String

        For Each Aux In Campo
            If Trim(Parametro) <> "" Then Parametro = Parametro & ","

            If IsNumeric(Aux) Then
                Aux = ConvValorFormatoAmericano(Aux)
            End If

            Parametro = Parametro + Aux
        Next

        SqlText = sFunction & " (" & Parametro & ")"

        Return "BEGIN :RET:= " & SqlText & "; END;"
    End Function

    Public Function DBParametro_Montar(ByVal Nome As String, _
                                       ByVal Valor As Object, _
                                       Optional ByVal Tipo As OracleType = OracleType.VarChar, _
                                       Optional ByVal Direcao As ParameterDirection = _
                                                                 ParameterDirection.Input, _
                                       Optional ByVal Tamanho As Integer = 0) As DBParamentro
        Dim oPar As New DBParamentro

        With oPar
            .Nome = Nome
            .Valor = Valor
            .Tipo = Tipo
            .Direcao = Direcao

            If Tamanho > -1 Then
                If Tipo = OracleType.VarChar And Tamanho = 0 Then
                    .Tamanho = 100
                Else
                    .Tamanho = Tamanho
                End If
            End If
        End With

        Return oPar
    End Function

    Public Function DBNumeroMaisUm(ByVal Tabela As String, ByVal NomeCampo As String) As Integer
        Dim oData As DataTable
        Dim Numero As Long

        Numero = -1

        Tabela = DBObjeto_TratarNome(Tabela)

        oData = DBQuery("select nvl(max(" & Trim(NomeCampo) & "), 0) from " & Tabela)

        If oData Is Nothing Then
            If DBContemErro() Then
                If bExibirErro Then
                    Err.Raise(60000, "", DBMsgError)
                End If
            Else
                If bExibirErro Then
                    Err.Raise(60000, "", "Não foi possível verificar o valor do campo!")
                Else
                    MsgError_Setar("Não foi possível verificar o valor do campo!")
                End If
            End If
        Else
            Numero = oData.Rows(0).Item(0) + 1
        End If

        Return Numero
    End Function

    Public Function DBQuery(ByVal SqlText As String, _
                            Optional ByVal NomeQuery As String = "", _
                            Optional ByVal oDataBase As DataTable = Nothing) As DataTable
        On Error GoTo Erro

        Return DBQuery(SqlText, NomeQuery, oDataBase, Nothing)

        Exit Function

Erro:
        Erro_Tratar("MOD_DB.DBQuery", SqlText)
    End Function

    Private Function DBQuery(ByVal SqlText As String, _
                             ByVal NomeQuery As String, _
                             ByVal oDataBase As DataTable, _
                             ByVal ParamArray Parametro() As DBParamentro) As DataTable
        Dim oData As New DataTable
        Dim oAdapter As New OracleDataAdapter
        Dim oCommand As OracleCommand
        Dim oAux As DBParamentro
        Dim oParametro As OracleParameter

        oCommand = DBBancoDados(oBancoConeccao_Uso).CreateCommand

        If bUsarTransacao Then oCommand.Transaction = oTrans

        oCommand.CommandText = SqlText

        If Not Parametro Is Nothing Then
            oCommand.CommandText = SqlText
            oCommand.Prepare()

            For Each oAux In Parametro
                If oAux.Direcao <> ParameterDirection.ReturnValue Then
                    oParametro = New OracleParameter

                    With oParametro
                        .ParameterName = oAux.Nome
                        .DbType = oAux.Tipo
                        .Direction = oAux.Direcao

                        If oAux.Valor Is Nothing Then
                            .Value = System.DBNull.Value
                        Else
                            .Value = oAux.Valor
                        End If

                        .Size = oAux.Tamanho
                    End With

                    oCommand.Parameters.Add(oParametro)
                End If
            Next
        End If

        oAdapter.SelectCommand = oCommand
        oAdapter.Fill(oData)
        oAdapter.Update(oData)

        If Trim(NomeQuery) <> "" Then
            oData.TableName = NomeQuery
        End If
        If Not oDataBase Is Nothing Then
            DBData_CopiarEstrutura(oDataBase, oData)
            oDataBase = oData
        End If

        oCommand.Dispose()
        oCommand = Nothing
        oAdapter.Dispose()
        oAdapter = Nothing

        Return oData
    End Function

    Public Function DBQuery_Append(ByVal oData As DataTable, _
                                   ByVal SqlText As String, _
                                   Optional ByVal bLimparTabela As Boolean = False, _
                                   Optional ByVal oDataAux As DataTable = Nothing) As DataTable
        Dim oRow As DataRow
        Dim iCont_01 As Integer
        Dim iCont_02 As Integer

        If oDataAux Is Nothing Then
            oDataAux = New DataTable
            oDataAux = DBQuery(SqlText)
        End If

        If bLimparTabela Then
            oData.Rows.Clear()
        End If

        For iCont_01 = 0 To oDataAux.Rows.Count - 1
            oRow = oData.Rows.Add

            For iCont_02 = 0 To oDataAux.Columns.Count - 1
                oRow.Item(iCont_02) = oDataAux.Rows(iCont_01).Item(iCont_02)
            Next
        Next

        Return oData
    End Function

    Public Function DBQuery_ValorUnico(ByVal SqlText As String, _
                                       Optional ByVal ValorPadrao As Object = Nothing) As Object
        Return DBQuery_ValorUnico(SqlText, ValorPadrao, Nothing)
    End Function

    Public Function DBQuery_ValorUnico_Lista(ByVal SqlText As String, _
                                             Optional ByVal Separador As String = ",", _
                                             Optional ByVal bNumber As Boolean = True) As String
        Dim oData As DataTable
        Dim iCont As Integer
        Dim sAux As String = ""

        oData = DBQuery(SqlText)

        If objDataTable_CampoVazio(oData) Then
            Return ""
        Else
            For iCont = 0 To oData.Rows.Count - 1
                If bNumber Then
                    Str_Adicionar(sAux, oData.Rows(iCont).Item(0), Separador)
                Else
                    Str_Adicionar(sAux, QuotedStr(oData.Rows(iCont).Item(0)), Separador)
                End If
            Next

            Return sAux
        End If
    End Function

    Public Function DBQuery_ValorUnico(ByVal SqlText As String, _
                                       ByVal ValorPadrao As Object, _
                                       ByVal ParamArray Parametro() As DBParamentro) As Object
        Dim oData As DataTable
        Dim Aux As Object

        Aux = Nothing
        oData = DBQuery(SqlText, "", Nothing, Parametro)

        If Not oData Is Nothing Then
            If oData.Rows.Count > 0 Then
                Aux = oData.Rows(0).Item(0)
            End If
        End If

        oData = Nothing

        If CampoNulo(Aux) And Not ValorPadrao Is Nothing Then
            Aux = ValorPadrao
        End If

        Return Aux
    End Function

    Public Function DBNovaSequence(ByVal Nome As String) As Long
        Dim oData As DataTable
        Dim SQ As Long

        SQ = -1

        Nome = DBObjeto_TratarNome(Nome)

        oData = DBQuery("select " & Trim(Nome) & ".nextval from dual")

        If oData Is Nothing Then
            If DBContemErro() Then
                Err.Raise(60000, "", DBMsgError)
            Else
                Err.Raise(60000, "", "Não foi possível gerar um novo 'SEQUENCE'")
            End If
        Else
            SQ = oData.Rows(0).Item(0)
        End If

        Return SQ
    End Function

    Private Sub LimparErro()
        bErro = False
        MsgErr = ""
    End Sub

    Public Function DBContemErro() As Boolean
        Return bErro
    End Function

    Public Function DBObjeto_TratarNome(ByVal sObjeto As String) As String
        If InStr(sObjeto, ".") = 0 And Trim(sBancoDados_OwnerPadrao) <> "" And InStr(sObjeto, "FROM DUAL") = 0 Then
            sObjeto = Trim(sBancoDados_OwnerPadrao) & "." & sObjeto
        End If

        Return sObjeto
    End Function

    Public Function DBMsgError() As String
        Dim sAux As String

        sAux = MsgErr
        LimparErro()

        Return sAux
    End Function

    Public Function objDataTable_Vazio(ByVal oData As DataTable) As Boolean
        Dim bVazio As Boolean

        bVazio = True

        If Not oData Is Nothing Then
            If oData.Rows.Count > 0 Then
                bVazio = False
            End If
        End If

        Return bVazio
    End Function

    Public Sub objData_Finalizar(ByRef oData As DataTable)
        If Not oData Is Nothing Then
            oData.Dispose()
            oData = Nothing
        End If
    End Sub

    Public Sub objData_Coluna_Copiar(ByRef oDataDestino As DataTable, _
                                     ByVal oColuna As DataColumn)
        With oDataDestino.Columns.Add(oColuna.ColumnName, oColuna.DataType)
            .AllowDBNull = oColuna.AllowDBNull
            .AutoIncrement = oColuna.AutoIncrement
            .AutoIncrementSeed = oColuna.AutoIncrementSeed
            .AutoIncrementStep = oColuna.AutoIncrementStep
            .Caption = oColuna.Caption
            .ColumnMapping = oColuna.ColumnMapping
            .DateTimeMode = oColuna.DateTimeMode
            .DefaultValue = oColuna.DefaultValue
            .MaxLength = oColuna.MaxLength
            .ReadOnly = oColuna.ReadOnly
            .Site = oColuna.Site
            .Unique = oColuna.Unique
        End With
    End Sub

    Public Function objData_RetornarDistinto(ByVal oData As DataTable, _
                                             ByVal IDColunaComparacao() As Integer, _
                                             Optional ByVal ColunaMaxima As Integer = 0) As DataTable
        Dim oDataRet As New DataTable
        Dim oRow As DataRow
        Dim iLinha_01 As Integer
        Dim iLinha_02 As Integer
        Dim iColuna As Integer
        Dim bAchou As Boolean
        Dim iUltimaColuna As Integer

        iUltimaColuna = IIf(ColunaMaxima = 0, oData.Columns.Count - 1, ColunaMaxima)

        'Copiar colunas
        For iColuna = 0 To iUltimaColuna
            objData_Coluna_Copiar(oDataRet, oData.Columns(IDColunaComparacao(iColuna)))
        Next

        'Copiar Dados
        For iLinha_01 = 0 To oData.Rows.Count - 1
            'Verifica se a linha já foi inserida
            bAchou = False

            For iLinha_02 = 0 To oDataRet.Rows.Count - 1
                bAchou = True

                For iColuna = 0 To iUltimaColuna
                    If oData.Rows(iLinha_01).Item(IDColunaComparacao(iColuna)) <> oDataRet.Rows(iLinha_02).Item(iColuna) Then
                        bAchou = False
                        Exit For
                    End If
                Next

                If bAchou Then Exit For
            Next

            'Se não achou é criada uma nova linha
            If Not bAchou Then
                oRow = oDataRet.NewRow

                For iColuna = 0 To iUltimaColuna
                    oRow.Item(iColuna) = oData.Rows(iLinha_01).Item(IDColunaComparacao(iColuna))
                Next

                oDataRet.Rows.Add(oRow)
            End If
        Next

        Return oDataRet
    End Function

    Public Sub objData_Formatar(ByRef oData As DataTable, _
                                ByVal oColuna() As DataTable_Column)
        Dim iCont As Integer

        oData = New DataTable

        If Not oColuna Is Nothing Then
            For iCont = LBound(oColuna) To UBound(oColuna)
                oData.Columns.Add(oColuna(iCont).Nome, _
                                  DBDataType(oColuna(iCont).Tipo))
            Next
        End If
    End Sub

    Public Function objData_Formatar_Coluna(ByVal Nome As String, Optional ByVal Tipo As eDbType = eDbType._Texto) As DataTable_Column
        Dim oDataTable_Column As New DataTable_Column

        oDataTable_Column.Nome = Nome
        oDataTable_Column.Tipo = Tipo

        Return oDataTable_Column
    End Function

    Public Function objDataTable_SelectDistinct(ByVal SourceTable As DataTable, ByVal ParamArray Columns() As String) As DataTable

        Dim Result As DataTable = New DataTable()

        If SourceTable IsNot Nothing Then
            Dim DView As DataView = SourceTable.DefaultView

            Try
                Result = DView.ToTable(True, Columns)
            Catch ex As Exception
            End Try
        End If

        Return Result
    End Function

    Public Function objDataTable_CampoVazio(ByVal oCampo As Object) As Boolean
        Return oCampo Is System.DBNull.Value
    End Function

    Public Function objDataTable_LerCampo(ByVal oCampo As Object, _
                                          Optional ByVal ValorPadrao As Object = Nothing) As Object
        If oCampo Is System.DBNull.Value Then
            Return ValorPadrao
        Else
            Return oCampo
        End If
    End Function

    Public Function objDataTable_Pesquisa(ByRef oData As DataTable, _
                                          ByVal Campo As String, _
                                          ByVal Valor As Object, _
                                          Optional ByVal NovaLinhaSeNaoEncontrar As Boolean = False) As DataRow
        Dim oRow As DataRow = Nothing
        Dim iCont As Integer

        For iCont = 0 To oData.Rows.Count - 1
            With oData.Rows(iCont)
                If .Item(Campo) = Valor Then
                    oRow = oData.Rows(iCont)
                    Exit For
                End If
            End With
        Next

        If oRow Is Nothing And _
           NovaLinhaSeNaoEncontrar Then
            oRow = oData.NewRow
            oData.Rows.Add(oRow)
        End If

        Return oRow
    End Function

    Public Sub DBCarregarComboBox(ByVal oCombo As System.Windows.Forms.ComboBox, _
                                  ByVal SqlText As String, _
                                  Optional ByVal LinhaBranco As Boolean = False, _
                                  Optional ByVal SelecionaAutomatico As Boolean = True, _
                                  Optional ByVal ManterSelecao As Boolean = False)
        Dim oData As DataTable
        Dim oDataCombo As New DataTable
        Dim iCont_01 As Integer
        Dim oAux As Object

        If ManterSelecao Then
            oAux = oCombo.SelectedValue
        End If

        oData = DBQuery(SqlText)
        oDataCombo = oData.Copy

        'Se for ter linha em branco
        If LinhaBranco And oDataCombo.Rows.Count > 0 Then
            Dim oRow As DataRow
            Dim iCont As Integer

            'LInha em branco
            oDataCombo.Rows.Clear()
            oRow = oDataCombo.NewRow
            oDataCombo.Rows.Add(oRow)
            oRow(0) = -1
            oRow(1) = " "

            For iCont = 0 To oData.Rows.Count - 1
                oRow = oDataCombo.NewRow

                For iCont_01 = 0 To oData.Columns.Count - 1
                    oRow(iCont_01) = oData.Rows(iCont)(iCont_01)
                Next

                oDataCombo.Rows.Add(oRow)
            Next
        End If

        If Not oData Is Nothing Then
            oCombo.DataSource = Nothing
            oCombo.ValueMember = oDataCombo.Columns(0).ColumnName
            oCombo.DisplayMember = oDataCombo.Columns(1).ColumnName
            oCombo.DataSource = oDataCombo
            oCombo.Refresh()

            Dim quant As Integer

            If LinhaBranco = True Then
                quant = 2
            Else
                quant = 1
            End If

            If SelecionaAutomatico = True Then
                If oCombo.Items.Count = quant Then
                    oCombo.SelectedIndex = quant - 1
                End If
            End If
        End If

        If ManterSelecao Then
            ComboBox_Possicionar(oCombo, oAux)
        End If
    End Sub

    Public Sub DBCarregarListBox(ByVal oListBox As System.Windows.Forms.ListBox, ByVal SqlText As String)
        Dim oData As DataTable

        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            If oData.Columns.Count = 1 Then
                oListBox.DisplayMember = oData.Columns(0).ColumnName
            Else
                oListBox.ValueMember = oData.Columns(0).ColumnName
                oListBox.DisplayMember = oData.Columns(1).ColumnName
            End If

            oListBox.DataSource = oData
        End If
    End Sub

    Public Property DBUsarTransacao() As Boolean
        Get
            Return bUsarTransacao
        End Get
        Set(ByVal Valor As Boolean)
            If Valor Then
                If bUsarTransacao Then oTrans.Commit()

                bUsarTransacao = Valor

                oTrans = DBBancoDados(oBancoConeccao_Uso).BeginTransaction
            Else
                If bUsarTransacao Then
                    oTrans.Rollback()
                    bUsarTransacao = False
                End If
            End If
        End Set
    End Property

    Public Property DBErro_ExibirMensagem() As Boolean
        Get
            Return bExibirErro
        End Get
        Set(ByVal Value As Boolean)
            bExibirErro = Value
        End Set
    End Property

    Private Sub MsgError_Setar(ByVal sErro As String)
        MsgErr = sErro
        bErro = True
    End Sub

    Private Sub Erro_Tratar(ByVal LocalErro As String, _
                            Optional ByVal ErroComplemento As String = "")
        Dim sErro As String

        sErro = MsgErr

        MsgError_Setar(TratarErro(sErro, bExibirErro, LocalErro, ErroComplemento))
        LimparErro()
    End Sub

    Public Function DBTeveRetorno() As Boolean
        If oRetorno Is Nothing Then
            Return False
        Else
            Return oRetorno.Count > 0
        End If
    End Function

    Public Function DBRetorno(ByVal Indice As Integer) As String
        If DBTeveRetorno() Then
            If Indice > oRetorno.Count Then
                Msg_Mensagem("Parâmetro inexistente")
                Return Nothing
            Else
                If oRetorno(Indice) Is DBNull.Value Then
                    Return ""
                Else
                    Return oRetorno(Indice)
                End If
            End If
        Else
            Return ""
        End If
    End Function

    Public Function DBDataServidor_PT() As String
        Dim oData As DataTable

        oData = DBQuery("SELECT TO_CHAR(SYSDATE, 'DD/MM/YYYY') DATA FROM DUAL")

        If Not objDataTable_Vazio(oData) Then
            Return oData.Rows(0).Item("DATA")
        End If

        Return Nothing
    End Function

    Public Sub DBData_CopiarEstrutura(ByVal oDataOrigem As DataTable, ByVal oDataDestino As DataTable)
        Dim iCont As Integer

        oDataOrigem.TableName = oDataDestino.TableName

        For iCont = 0 To oDataOrigem.Columns.Count - 1
            If iCont < oDataDestino.Columns.Count Then
                oDataDestino.Columns(iCont).Caption = oDataOrigem.Columns(iCont).Caption
            End If
        Next
    End Sub

    Public Function DBData_Criar(ByVal oDS As DataSet, _
                                 ByVal TabelaNome As String, _
                                 ByVal Coluna() As String, _
                                 Optional ByVal ColunaTipo() As eDbType = Nothing) As DataTable
        Dim oData As New DataTable
        Dim iCont As Integer

        oData.TableName = TabelaNome

        For iCont = LBound(Coluna) To UBound(Coluna)
            oData.Columns.Add(Coluna(iCont))

            If Not ColunaTipo Is Nothing Then
                oData.Columns(Coluna(iCont)).DataType = DBDataType(ColunaTipo(iCont))
            End If
        Next

        If Not oDS Is Nothing Then
            oDS.Tables.Add(oData)
        End If

        Return oData
    End Function

    Public Sub DBData_Relationamento_Criar(ByVal oDS As DataSet, ByVal Nome As String, _
                                           ByVal oTB01 As DataTable, ByVal Colunas01() As String, _
                                           ByVal oTB02 As DataTable, ByVal Colunas02() As String)

        Dim iCont As Integer

        If Not oTB01 Is Nothing And Not oTB02 Is Nothing Then
            Dim oDR As DataRelation
            Dim oColunas01(UBound(Colunas01)) As DataColumn
            Dim oColunas02(UBound(Colunas02)) As DataColumn

            For iCont = LBound(Colunas01) To UBound(Colunas01)
                oColunas01(iCont) = oTB01.Columns(Colunas01(iCont))
                oColunas02(iCont) = oTB02.Columns(Colunas02(iCont))
            Next

            oDR = New DataRelation(Nome & "_", oColunas01, oColunas02, False)
            oDS.Relations.Add(oDR)

            oDR = Nothing
        End If
    End Sub

    Public Function DBDataType(ByVal oTipo As eDbType) As System.Type
        Select Case oTipo
            Case eDbType._Inteiro
                Return System.Type.GetType("System.Int16")
            Case eDbType._Numero
                Return System.Type.GetType("System.Double")
            Case eDbType._Data
                Return System.Type.GetType("System.DateTime")
            Case eDbType._Texto
                Return System.Type.GetType("System.String")
            Case eDbType._Decimal
                Return System.Type.GetType("System.Decimal")
            Case Else
                Return System.Type.GetType("System.String")
        End Select
    End Function

    Public Function DBCarregarUsuario() As Boolean

        On Error GoTo Erro

        DBExecutar("DELETE FROM " & sBancoDados_OwnerPadrao & ".TMP_CONECCAO")
        DBExecutar("INSERT INTO " & sBancoDados_OwnerPadrao & ".TMP_CONECCAO VALUES ('" & sAcesso_UsuarioLogado & "')")

        Return True

Erro:
        Return False
    End Function

    Public Function DBBancoDados(Optional ByVal oBancoConeccao As BancoConeccao = BancoConeccao.Sistema) As OracleConnection
        Select Case oBancoConeccao
            Case BancoConeccao.Sistema
                Return oDB_01
            Case BancoConeccao.Ilheus, BancoConeccao.Luminis
                Return oDB_02
            Case BancoConeccao.SPO60P, BancoConeccao.BancoGeral
                Return oDB_03
            Case Else
                Return Nothing
        End Select
    End Function
End Module