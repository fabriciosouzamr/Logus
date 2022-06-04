Imports Infragistics.Win.UltraWinDataSource

Public Class frmAbreDia
    Dim QtErros As Integer
    Dim QtAlertas As Integer
    Dim DiaInicializado As Boolean
    Dim Dta As Date
    Dim IcBranche As Boolean
    Dim DataAnt As Date
    Dim DataNova As Date
    Dim IcSafra As String
    Dim NuSafra As Integer

    Dim oDSContabilizacao As New UltraDataSource

    Enum Status
        Ok = 1
        Erro = 2
        Alerta = 3
    End Enum

    Enum Processos
        Auditoria = 3
        InterfacePagamento = 4
        InterfaceMovimentacao = 5
        Branche = 6
        InativaLimite = 7
        RevisaLimite = 8
        EstoqueSilo = 9
        AtualizaData = 10
        InterfaceLivro = 11
        ExcluiAcessos = 12
        GeraBonus = 13
    End Enum

    Const cnt_RealizarAjustes_Fase01 As Integer = 1
    Const cnt_RealizarAjustes_Fase02 As Integer = 2

    Const cnt_GridContabilizacao_IC_AJUSTE_REALIZADO As Integer = 0
    Const cnt_GridContabilizacao_NR_FAZER As Integer = 1
    Const cnt_GridContabilizacao_CD_TIPO_AJUSTE As Integer = 2
    Const cnt_GridContabilizacao_CD_TIPO_ESTORNO As Integer = 3
    Const cnt_GridContabilizacao_CD_FILIAL As Integer = 4
    Const cnt_GridContabilizacao_CD_FILIAL_AJUSTE As Integer = 5
    Const cnt_GridContabilizacao_MovimentacaoAjuste As Integer = 6
    Const cnt_GridContabilizacao_ValorAjuste As Integer = 7
    Const cnt_GridContabilizacao_FilialContabilizada As Integer = 8
    Const cnt_GridContabilizacao_FilialAjuste As Integer = 9
    Const cnt_GridContabilizacao_MovimentacaoEstorno As Integer = 10

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        If DiaInicializado = True Then
            If QtErros <> 0 Then
                Msg_Mensagem("Ainda existe erros a serem reparados.")
                Exit Sub
            End If
            If QtAlertas <> 0 Then
                If Msg_Perguntar("Ainda existe alguns alertas. Deseja sair assim mesmo ?") = False Then Exit Sub
            End If
            Finaliza()
        End If
        Me.Close()
    End Sub

    Private Sub frmAbreDia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim NovaData As Date
        Dim SqlText As String

        imInterfaceLivro.Enabled = False
        TabContabilizacao.Tab.Visible = False
        DiaInicializado = False
        QtErros = 0
        QtAlertas = 0
        lblStatusContabilizacao.Text = ""

        NovaData = DataSistema()
        Do While True
            NovaData = DateAdd(DateInterval.Day, 1, NovaData)
            If Weekday(NovaData) <> 1 And Weekday(NovaData) <> 7 Then
                Exit Do
            End If
        Loop

        txtData.Value = NovaData
        txtSafra.Value = 0
        chkSafra_CheckedChanged(Nothing, Nothing)
        Dta = NovaData

        SqlText = "SELECT CD_FILIAL_MAE FROM SOF.PARAMETRO"
        If DBQuery_ValorUnico(SqlText) <> FilialLogada Then
            Msg_Mensagem("É necessario esta logado na filial mãe para realizar esta operação.")
            Close()
        End If

        SqlText = "SELECT NVL(IC_HABILITA_BRANCHE, 'N') AS IC_HABILITA_BRANCHE" & _
                  " FROM SOF.PARAMETRO"
        If DBQuery_ValorUnico(SqlText) = "S" Then
            IcBranche = True
        Else
            IcBranche = False
        End If

        objGrid_Inicializar(grdContabilizacao, , oDSContabilizacao)
        objGrid_Coluna_Add(grdContabilizacao, "IC_AJUSTE_REALIZADO", 0)
        objGrid_Coluna_Add(grdContabilizacao, "NR_FAZER", 0)
        objGrid_Coluna_Add(grdContabilizacao, "CD_TIPO_AJUSTE", 0)
        objGrid_Coluna_Add(grdContabilizacao, "CD_TIPO_ESTORNO", 0)
        objGrid_Coluna_Add(grdContabilizacao, "CD_FILIAL", 0)
        objGrid_Coluna_Add(grdContabilizacao, "CD_FILIAL_AJUSTE", 0)
        objGrid_Coluna_Add(grdContabilizacao, "Movimentação de Ajuste", 200)
        objGrid_Coluna_Add(grdContabilizacao, "Valor Ajuste", 200, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdContabilizacao, "Filial Contabilizada", 200)
        objGrid_Coluna_Add(grdContabilizacao, "Filial Ajuste", 200)
        objGrid_Coluna_Add(grdContabilizacao, "Movimentação de Estorno", 200)

        VerificarFechamento()
    End Sub

    Private Sub chkSafra_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSafra.CheckedChanged
        If chkSafra.Checked = True Then
            txtSafra.Enabled = True
        Else
            txtSafra.Enabled = False
        End If
    End Sub

    Private Sub Finaliza()
        Msg_Mensagem("A inicialização do dia foi realizado com sucesso." & vbCrLf & _
                     "O sistema sera finalizado. Na proxima vez que voce se logar sera com a nova data.")
        End
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        If cmdFazerAjuste.Visible And TabContabilizacao.Tab.Visible Then
            Msg_Mensagem("Verificar valores de ajustes e lançá-los no RD")
            Exit Sub
        End If

        QtErros = 0
        QtAlertas = 0

        imVerificaDados.Enabled = False
        imEstoqueSilo.Enabled = False
        imAuditoria.Enabled = False
        imAtualizaData.Enabled = False
        imBranche.Enabled = False
        imExcluiAcessos.Enabled = False
        imInativaLimite.Enabled = False
        imRevisaLimite.Enabled = False
        imInicializandoDia.Enabled = False
        imInterfaceLivro.Enabled = False
        imInterfaceMovimentacao.Enabled = False
        imInterfacePagamento.Enabled = False
        imGeraBonus.Enabled = False

        imVerificaDados.Image = imTarefa.Image
        If Verifica_Dados() = False Then
            imVerificaDados.Image = imErro.Image
            QtErros = QtErros + 1
            Exit Sub
        Else
            imVerificaDados.Image = imOK.Image
        End If

        If Msg_Perguntar("Dados corretos ?") = False Then
            Exit Sub
        End If

        DataAnt = DataSistema()
        DataNova = CDate(txtData.Value)

        If chkSafra.Checked = True Then
            IcSafra = "S"
            NuSafra = txtSafra.Value
        Else
            IcSafra = "N"
            NuSafra = -1
        End If

        imInicializandoDia.Image = imTarefa.Image
        If Inicializa_Dia() = False Then
            imInicializandoDia.Image = imErro.Image
            QtErros = QtErros + 1
            Exit Sub
        Else
            imInicializandoDia.Image = imOK.Image
        End If

        cmdGravar.Enabled = False
        DiaInicializado = True

        imAuditoria.Image = imTarefa.Image
        If Roda_Auditoria() = False Then
            imAuditoria.Image = imErro.Image
            QtErros = QtErros + 1
            imAuditoria.Enabled = True
            imAuditoria.BorderStyle = Infragistics.Win.UIElementBorderStyle.Raised
        Else
            imAuditoria.Image = imOK.Image
        End If

        imInterfacePagamento.Image = imTarefa.Image
        If Interface_JDE_Pag() = False Then
            imInterfacePagamento.Image = imErro.Image
            QtAlertas = QtAlertas + 1
            imInterfacePagamento.Enabled = True
            imInterfacePagamento.BorderStyle = Infragistics.Win.UIElementBorderStyle.Raised
        Else
            imInterfacePagamento.Image = imOK.Image
        End If

        imInterfaceMovimentacao.Image = imTarefa.Image
        If Interface_JDE_Rec() = False Then
            imInterfaceMovimentacao.Image = imErro.Image
            QtAlertas = QtAlertas + 1
            imInterfaceMovimentacao.Enabled = True
            imInterfaceMovimentacao.BorderStyle = Infragistics.Win.UIElementBorderStyle.Raised
        Else
            imInterfaceMovimentacao.Image = imOK.Image
        End If

        imBranche.Image = imTarefa.Image
        If IcBranche = True Then
            If Branche() = False Then
                imBranche.Image = imErro.Image
                QtErros = QtErros + 1
                imBranche.Enabled = True
                imBranche.BorderStyle = Infragistics.Win.UIElementBorderStyle.Raised
            Else
                imBranche.Image = imOK.Image
            End If
        Else
            imBranche.Image = imOK.Image
        End If

        imInativaLimite.Image = imTarefa.Image
        If Inativa_Limite_Credito() = False Then
            imInativaLimite.Image = imErro.Image
            QtErros = QtErros + 1
            imInativaLimite.Enabled = True
            imInativaLimite.BorderStyle = Infragistics.Win.UIElementBorderStyle.Raised
        Else
            imInativaLimite.Image = imOK.Image
        End If

        imRevisaLimite.Image = imTarefa.Image
        If Revisao_Limite_Credito() = False Then
            imRevisaLimite.Image = imErro.Image
            QtErros = QtErros + 1
            imRevisaLimite.Enabled = True
            imRevisaLimite.BorderStyle = Infragistics.Win.UIElementBorderStyle.Raised
        Else
            imRevisaLimite.Image = imOK.Image
        End If

        imEstoqueSilo.Image = imTarefa.Image
        If Utiliza_Silo() = False Then
            imEstoqueSilo.Image = imErro.Image
            QtErros = QtErros + 1
            imEstoqueSilo.Enabled = True
            imEstoqueSilo.BorderStyle = Infragistics.Win.UIElementBorderStyle.Raised
        Else
            imEstoqueSilo.Image = imOK.Image
        End If

        imAtualizaData.Image = imTarefa.Image
        If Atualiza_Data_Bolsa() = False Then
            imAtualizaData.Image = imErro.Image
            QtErros = QtErros + 1
            imAtualizaData.Enabled = True
            imAtualizaData.BorderStyle = Infragistics.Win.UIElementBorderStyle.Raised
        Else
            imAtualizaData.Image = imOK.Image
        End If

        'Desativado em 27/01/2011 por solicitando do setor fiscal
        'imInterfaceLivro.Image = imTarefa.Image
        'If Interface_LivroFiscal = False Then
        '    imInterfaceLivro.Image = imErro.Image
        '    QtAlertas = QtAlertas + 1
        '    imInterfaceLivro.Enabled = True
        '    imInterfaceLivro.BorderStyle = Infragistics.Win.UIElementBorderStyle.Raised
        'Else
        '    imInterfaceLivro.Image = imOK.Image
        'End If

        imExcluiAcessos.Image = imTarefa.Image
        If Exclui_Vencidos() = False Then
            imExcluiAcessos.Image = imErro.Image
            QtAlertas = QtAlertas + 1
            imExcluiAcessos.Enabled = True
            imExcluiAcessos.BorderStyle = Infragistics.Win.UIElementBorderStyle.Raised
        Else
            imExcluiAcessos.Image = imOK.Image
        End If

        imGeraBonus.Image = imTarefa.Image
        If GeraBonus() = False Then
            imGeraBonus.Image = imErro.Image
            QtAlertas = QtAlertas + 1
            lbl1.Enabled = True
            imGeraBonus.BorderStyle = Infragistics.Win.UIElementBorderStyle.Raised
        Else
            imGeraBonus.Image = imOK.Image
        End If

        If QtErros = 0 Then
            If QtAlertas <> 0 Then
                Msg_Mensagem("Alguns procedimentos apresentaram alertas. Favor rever.")
            Else
                If TabContabilizacao.Tab.Visible Then
                    RealizarEstorno()
                End If

                Finaliza()
                cmdGravar.Enabled = False
            End If
        Else
            Msg_Mensagem("Alguns procedimentos apresentaram erros. Favor rever.")
        End If

        Exit Sub

Erro:
        TratarErro(, , "frmAbreDia.cmdGravar_Click")
    End Sub

    Private Function Verifica_Dados() As Boolean
        Dim SqlText As String

        Verifica_Dados = False

        SqlText = "SELECT COUNT(SQ_NEGOCIACAO_PRE) AS QUANT" & _
                  " FROM SOF.NEGOCIACAO_PRE " & _
                  " WHERE QT_SALDO <> 0" & _
                    " AND TRUNC(DT_CRIACAO) <> TRUNC(SYSDATE)"

        If DBQuery_ValorUnico(SqlText) <> 0 Then
            Msg_Mensagem("Ainda existe pre-negociação em aberto.")
            Exit Function
        End If
        If Not IsDate(txtData.Value) Then
            Msg_Mensagem("Data invalida.")
            txtData.Focus()
            Exit Function
        End If
        If CDate(txtData.Value) <= DataSistema() Then
            Msg_Mensagem("Data tem que ser maior do que " & DataSistema())
            txtData.Focus()
            Exit Function
        End If
        If CDate(txtData.Value) > Dta Then
            MsgBox("Voce adiantou a data." & vbCrLf & _
                   "Favor verificar se a nova data esta correta.", vbCritical, "ATENÇÃO")
        End If

        Verifica_Dados = True
    End Function

    Private Function Inicializa_Dia() As Boolean
        Dim SqlText As String

        Inicializa_Dia = False

        SqlText = DBMontar_SP("SOF.INICIALIZA_DIA", False, ":DATA", ":MUDASAFRA", ":SAFRA")
        If Not DBExecutar(SqlText, DBParametro_Montar("DATA", Date_to_Oracle(DataNova), OracleClient.OracleType.DateTime), _
                                   DBParametro_Montar("MUDASAFRA", IcSafra), _
                                   DBParametro_Montar("SAFRA", IIf(NuSafra <> -1, NuSafra, Nothing))) Then GoTo Erro

        Inicializa_Dia = True

        Exit Function

Erro:
        TratarErro(, , "frmAbreDia.Inicializa_Dia")
    End Function

    Private Function Roda_Auditoria() As Boolean
        Dim SqlText As String

        Roda_Auditoria = False

        SqlText = DBMontar_SP("SOF.SP_ATUALIZA_AUDITORIA", False, ":DATA")
        If Not DBExecutar(SqlText, DBParametro_Montar("DATA", Date_to_Oracle(DataAnt), OracleClient.OracleType.DateTime)) Then GoTo Erro

        Roda_Auditoria = True

        Exit Function

Erro:
        TratarErro(, , "frmAbreDia.Roda_Auditoria")
    End Function

    Private Function Interface_JDE_Pag() As Boolean
        Dim SqlText As String

        Interface_JDE_Pag = False

        SqlText = DBMontar_SP("SOF.INTERFACE_JDE_PAG", False, ":DATA")
        If Not DBExecutar(SqlText, DBParametro_Montar("DATA", Date_to_Oracle(DataAnt), OracleClient.OracleType.DateTime)) Then GoTo Erro

        Interface_JDE_Pag = True

        Exit Function

Erro:
        TratarErro(, , "frmAbreDia.Interface_JDE_Pag")
    End Function

    Private Function Interface_JDE_Rec() As Boolean
        Dim SqlText As String

        Interface_JDE_Rec = False

        SqlText = DBMontar_SP("SOF.INTERFACE_JDE_REC", False, ":DATA")
        If Not DBExecutar(SqlText, DBParametro_Montar("DATA", Date_to_Oracle(DataAnt), OracleClient.OracleType.DateTime)) Then GoTo Erro

        Interface_JDE_Rec = True

        Exit Function

Erro:
        TratarErro(, , "frmAbreDia.Interface_JDE_Rec")
    End Function

    Private Function Interface_LivroFiscal() As Boolean
        Dim SqlText As String

        Interface_LivroFiscal = False

        SqlText = DBMontar_SP("SOF.SP_GERA_INTERFACE_LIVROFISCAL", False, ":DATA")
        If Not DBExecutar(SqlText, DBParametro_Montar("DATA", Date_to_Oracle(DataAnt), OracleClient.OracleType.DateTime)) Then GoTo Erro

        SqlText = DBMontar_SP("SOF.SP_CLASS_INTERFACE_LIVROFISCAL", False, ":DATA")
        If Not DBExecutar(SqlText, DBParametro_Montar("DATA", Date_to_Oracle(DataAnt), OracleClient.OracleType.DateTime)) Then GoTo Erro

        Interface_LivroFiscal = True

        Exit Function

Erro:
        TratarErro(, , "frmAbreDia.Interface_LivroFiscal")
    End Function

    Private Function Branche() As Boolean
        Dim SqlText As String
        Dim oData As DataTable
        Dim iCont As Integer

        Branche = False


        SqlText = DBMontar_SP("SOF.ATUALIZA_BRANCHE", False, ":DATA")
        If Not DBExecutar(SqlText, DBParametro_Montar("DATA", Date_to_Oracle(DataAnt), OracleClient.OracleType.DateTime)) Then GoTo Erro

        SqlText = "SELECT COUNT(*) AS QT FROM SOF.BRANCHE " & _
                  "WHERE DT_BRANCHE = " & QuotedStr(Date_to_Oracle(DataAnt)) & _
                   " AND CD_BRANCHE_ITEM = 24"

        If DBQuery_ValorUnico(SqlText) = 0 Then
            SqlText = "SELECT NVL(SUM(CF.qt_cancelado),0) AS QT_TOTAL, CP.CD_FILIAL_ORIGEM " & _
                      "FROM SOF.CONTRATO_FIXO_cancelado CF, SOF.NEGOCIACAO N, SOF.CONTRATO_PAF CP, " & _
                      "SOF.TIPO_NEGOCIACAO TN " & _
                      "WHERE N.CD_CONTRATO_PAF = CP.CD_CONTRATO_PAF AND " & _
                      "N.CD_CONTRATO_PAF = CF.CD_CONTRATO_PAF AND " & _
                      "N.SQ_NEGOCIACAO = CF.SQ_NEGOCIACAO AND " & _
                      "N.CD_TIPO_NEGOCIACAO = TN.CD_TIPO_NEGOCIACAO AND " & _
                      "CF.dt_cancelamento = '" & Date_to_Oracle(DataAnt) & "' AND " & _
                      "(TN.IC_BOLSA = 'S' OR TN.IC_DOLAR = 'S') " & _
                      "GROUP BY CP.CD_FILIAL_ORIGEM"
            oData = DBQuery(SqlText)

            For iCont = 0 To oData.Rows.Count - 1D
                SqlText = "INSERT INTO SOF.BRANCHE " & _
                          "(SQ_BRANCHE, DT_BRANCHE, CD_BRANCHE_ITEM, CD_FILIAL, CD_SAFRA, QT_SALDO, " & _
                          "VL_SALDO, DT_CRIACAO, NO_USER_CRIACAO) Values " & _
                          "(SOF.SEQUENCIA_BRANCHE.NEXTVAL, '" & Date_to_Oracle(DataAnt) & "', 24, " & _
                          oData.Rows(iCont).Item("cd_filial_origem") & ", NULL, " & oData.Rows(iCont).Item("qt_total") & ", NULL, " & _
                          "SYSDATE, '" & sAcesso_UsuarioLogado & "')"
                If Not DBExecutar(SqlText) Then GoTo Erro
            Next
        End If

        Branche = True

        Exit Function

Erro:
        TratarErro(, , "frmAbreDia.Branche")
    End Function

    Private Function Inativa_Limite_Credito() As Boolean
        Dim SqlText As String

        Inativa_Limite_Credito = False

        SqlText = DBMontar_SP("SOF.SP_INATIVA_LIMITE_CREDITO", False, ":DATA")
        If Not DBExecutar(SqlText, DBParametro_Montar("DATA", Date_to_Oracle(DataNova), OracleClient.OracleType.DateTime)) Then GoTo Erro

        Inativa_Limite_Credito = True

        Exit Function

Erro:
        TratarErro(, , "frmAbreDia.Inativa_Limite_Credito")
    End Function
    Private Function Revisao_Limite_Credito() As Boolean
        Dim SqlText As String

        Revisao_Limite_Credito = False

        SqlText = DBMontar_SP("SOF.SP_PEDE_REVISAO_LIMITE_CREDITO", False, ":DATA")
        If Not DBExecutar(SqlText, DBParametro_Montar("DATA", Date_to_Oracle(DataNova), OracleClient.OracleType.DateTime)) Then GoTo Erro

        Revisao_Limite_Credito = True

        Exit Function

Erro:
        TratarErro(, , "frmAbreDia.Revisao_Limite_Credito")
    End Function
    Private Function Utiliza_Silo() As Boolean
        Dim SqlText As String

        Utiliza_Silo = False

        SqlText = DBMontar_SP("SOF.SP_UTILIZA_ESTOQUE_SILO", False)
        If Not DBExecutar(SqlText) Then GoTo Erro

        Utiliza_Silo = True

        Exit Function

Erro:
        TratarErro(, , "frmAbreDia.Utiliza_Silo")
    End Function

    Private Function Atualiza_Data_Bolsa() As Boolean
        Dim SqlText As String

        Atualiza_Data_Bolsa = False

        SqlText = "UPDATE SOF.BOLSA_PERIODO" & _
                  " SET DT_LIMITE_ENTREGA = TO_DATE(" & QuotedStr(Date_to_Oracle(DataNova)) & ") + QT_DIA_ENTREGA" & _
                  " WHERE NVL(QT_DIA_ENTREGA, 0) <> 0"
        If Not DBExecutar(SqlText) Then GoTo erro

        Atualiza_Data_Bolsa = True

        Exit Function

Erro:
        TratarErro(, , "frmAbreDia.Atualiza_Data_Bolsa")
    End Function

    Private Function GeraBonus() As Boolean
        Dim SqlText As String
        Dim iCont As Integer
        Dim odata As DataTable

        GeraBonus = False

        SqlText = "SELECT bcf.cd_contrato_paf, bcf.sq_negociacao, "
        SqlText = SqlText & "   bcf.sq_contrato_fixo,f.no_razao_social,SUM (cm.qt_kg_fixo) AS qt_kg_fixo, "
        SqlText = SqlText & "   sum(ROUND ((ABS (bcf.vl_unitario_bonus / bcf.qt_fator_bonus)* cm.qt_kg_fixo),2)) AS vl_bonus, "
        SqlText = SqlText & "   cf.ic_status, n.ic_status ic_status_negociacao,cp.ic_status ic_status_contrato_paf, "
        SqlText = SqlText & "   ta.cd_tipo_adendo, ta.DS_TIPO_ADENDO "
        SqlText = SqlText & "FROM sof.bonus_contrato_fixo bcf, sof.bonus_padrao bp, "
        SqlText = SqlText & "     sof.ctr_paf_neg_ctr_fix_mov cm, "
        SqlText = SqlText & "     sof.contrato_paf cp, "
        SqlText = SqlText & "     sof.filial fil, "
        SqlText = SqlText & "     sof.fornecedor f, "
        SqlText = SqlText & "     sof.municipio munic, "
        SqlText = SqlText & "     sof.contrato_fixo cf, "
        SqlText = SqlText & "     sof.negociacao n, sof.tipo_adendo ta "
        SqlText = SqlText & "WHERE cm.sq_movimentacao = bcf.sq_movimentacao AND "
        SqlText = SqlText & "      cm.sq_movimentacao_cessao_direito = bcf.sq_movimentacao_cessao_direito AND "
        SqlText = SqlText & "      cm.cd_contrato_paf = bcf.cd_contrato_paf AND "
        SqlText = SqlText & "      cm.sq_ctr_paf_movimentacao = bcf.sq_ctr_paf_movimentacao AND "
        SqlText = SqlText & "      cm.sq_negociacao = bcf.sq_negociacao AND "
        SqlText = SqlText & "      cm.sq_ctr_paf_neg_movimentacao = bcf.sq_ctr_paf_neg_movimentacao AND "
        SqlText = SqlText & "      cm.sq_contrato_fixo = bcf.sq_contrato_fixo AND "
        SqlText = SqlText & "      cm.sq_ctr_paf_neg_ctr_fix_mov = bcf.sq_ctr_paf_neg_ctr_fix_mov AND "
        SqlText = SqlText & "      cp.cd_contrato_paf = cm.cd_contrato_paf AND "
        SqlText = SqlText & "      n.cd_contrato_paf = cm.cd_contrato_paf AND "
        SqlText = SqlText & "      n.sq_negociacao = cm.sq_negociacao AND "
        SqlText = SqlText & "      f.cd_fornecedor = cp.cd_fornecedor AND "
        SqlText = SqlText & "      fil.cd_filial = f.cd_filial_origem AND "
        SqlText = SqlText & "      f.cd_municipio = munic.cd_municipio AND "
        SqlText = SqlText & "      bcf.cd_bonus_padrao = bp.cd_bonus_padrao  AND "
        SqlText = SqlText & "      bp.cd_tipo_adendo = ta.cd_tipo_adendo (+) AND "
        SqlText = SqlText & "      bcf.cd_contrato_paf = cf.cd_contrato_paf AND "
        SqlText = SqlText & "      bcf.sq_negociacao = cf.sq_negociacao AND "
        SqlText = SqlText & "      bcf.sq_contrato_fixo = cf.sq_contrato_fixo AND "
        SqlText = SqlText & "      munic.cd_uf <> 'EX' AND "
        SqlText = SqlText & "      bcf.ic_pago = 'N' and nvl(bp.IC_GERACAO_AUTOMATICA,'N')='S' "

        If IsDate(txtData.Text) Then
            SqlText = SqlText & " AND TRUNC(bcf.dt_concessao ) >= " & QuotedStr(Date_to_Oracle(txtData.Text))
        End If

        SqlText = SqlText & " and (cf.qt_kgs - cf.qt_cancelado - cf.qt_kg_fixo)=0"


        SqlText = SqlText & " group by fil.no_filial, f.no_razao_social, bcf.cd_contrato_paf,bcf.sq_negociacao, "
        SqlText = SqlText & " bcf.sq_contrato_fixo, cf.ic_status, n.ic_status, cp.ic_status,ta.cd_tipo_adendo, ta.DS_TIPO_ADENDO "

        SqlText = "select * from (" & SqlText & ") order by cd_contrato_paf,sq_negociacao,sq_contrato_fixo"

        odata = DBQuery(SqlText)

        If Not objDataTable_Vazio(odata) Then
            For iCont = 0 To odata.Rows.Count - 1
                With odata.Rows(iCont)
                    GeraPremioQualidade(.Item("IC_STATUS_CONTRATO_PAF"), _
                                        .Item("IC_STATUS_NEGOCIACAO"), _
                                        .Item("IC_STATUS"), _
                                        .Item("CD_CONTRATO_PAF"), _
                                        .Item("SQ_NEGOCIACAO"), _
                                        .Item("SQ_CONTRATO_FIXO"), _
                                        .Item("CD_TIPO_ADENDO"), _
                                        .Item("VL_BONUS"))
                End With
            Next
        End If

        GeraBonus = True
        Exit Function

Erro:
        TratarErro(, , "frmAbreDia.GeraBonus")
    End Function

    Private Function Exclui_Vencidos() As Boolean
        Dim SqlText As String
        Dim oData As DataTable
        Dim iCont As Integer

        Exclui_Vencidos = False

        'EXCLUI DIREITO DE APROVAÇÃO VENCIDO
        SqlText = "delete from sof.usuario_tipo_aprovacao a "
        SqlText = SqlText & "where a.dt_validade <sysdate "
        If Not DBExecutar(SqlText) Then GoTo Erro

        'EXCLUI ACESSO A GRUPOS VENCIDO
        SqlText = "DELETE FROM sof.grupo_acesso_usuario g "
        SqlText = SqlText & "      WHERE g.dt_validade < SYSDATE "
        If Not DBExecutar(SqlText) Then GoTo Erro

        SqlText = "SELECT   c.sq_confissao_divida, SUM (DECODE (cp.ic_situacao, NULL, 0, 1)) "
        SqlText = SqlText & "    FROM sof.confissao_divida c, "
        SqlText = SqlText & "         sof.confissao_divida_parcela cp, "
        SqlText = SqlText & "         sof.confissao_divida_modalidade cm "
        SqlText = SqlText & "   WHERE cp.ic_situacao(+) = 'A' "
        SqlText = SqlText & "     AND c.sq_confissao_divida = cp.sq_confissao_divida(+) "
        SqlText = SqlText & "     AND c.ic_status = 'A' "
        SqlText = SqlText & "     AND c.cd_confissao_divida_modalidade = cm.cd_confissao_divida_modalidade "
        SqlText = SqlText & "     AND cm.ic_provissoria = 'N' "
        SqlText = SqlText & "GROUP BY c.sq_confissao_divida "
        SqlText = SqlText & "  HAVING SUM (DECODE (cp.ic_situacao, NULL, 0, 1)) = 0 "
        oData = DBQuery(SqlText)

        For iCont = 0 To oData.Rows.Count - 1
            SqlText = " UPDATE SOF.CONFISSAO_DIVIDA "
            SqlText = SqlText & "        SET DT_FECHAMENTO = '" & Date_to_Oracle(txtData.Value) & "', "
            SqlText = SqlText & "            IC_STATUS = 'F' "
            SqlText = SqlText & "        WHERE SQ_CONFISSAO_DIVIDA = " & oData.Rows(iCont).Item("sq_confissao_divida")
            If Not DBExecutar(SqlText) Then GoTo Erro
        Next

        Exclui_Vencidos = True

        Exit Function

Erro:
        TratarErro()
    End Function

    Private Sub Revisao(ByVal CdProceso As Processos)
        If DiaInicializado = False Then Exit Sub

        If Msg_Perguntar("Executa rotina?") = False Then Exit Sub

        Select Case CdProceso
            Case Processos.Auditoria
                imAuditoria.Image = imTarefa.Image
                If Roda_Auditoria() = False Then
                    imAuditoria.Image = imErro.Image
                Else
                    imAuditoria.Image = imOK.Image
                    QtErros = QtErros - 1
                    imAuditoria.Enabled = False
                    imAuditoria.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
                End If
                Me.Refresh()
            Case Processos.InterfacePagamento
                imInterfacePagamento.Image = imTarefa.Image
                If Interface_JDE_Pag() = False Then
                    imInterfacePagamento.Image = imErro.Image
                Else
                    imInterfacePagamento.Image = imOK.Image
                    QtAlertas = QtAlertas - 1
                    imInterfacePagamento.Enabled = False
                    imInterfacePagamento.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
                End If
                Me.Refresh()
            Case Processos.InterfaceMovimentacao
                imInterfaceMovimentacao.Image = imTarefa.Image
                If Interface_JDE_Rec() = False Then
                    imInterfaceMovimentacao.Image = imErro.Image
                Else
                    imInterfaceMovimentacao.Image = imOK.Image
                    QtAlertas = QtAlertas - 1
                    imInterfaceMovimentacao.Enabled = False
                    imInterfaceMovimentacao.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
                End If
                Me.Refresh()
            Case Processos.Branche
                imBranche.Image = imTarefa.Image
                If IcBranche = True Then
                    If Branche() = False Then
                        imBranche.Image = imErro.Image
                    Else
                        imBranche.Image = imOK.Image
                        QtErros = QtErros - 1
                        imBranche.Enabled = False
                        imBranche.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
                    End If
                Else
                    imBranche.Image = imOK.Image
                End If
                Me.Refresh()
            Case Processos.InativaLimite
                imInativaLimite.Image = imTarefa.Image
                If Inativa_Limite_Credito() = False Then
                    imInativaLimite.Image = imErro.Image
                Else
                    imInativaLimite.Image = imOK.Image
                    QtErros = QtErros - 1
                    imInativaLimite.Enabled = False
                    imInativaLimite.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
                End If
                Me.Refresh()
            Case Processos.RevisaLimite
                imRevisaLimite.Image = imTarefa.Image
                If Revisao_Limite_Credito() = False Then
                    imRevisaLimite.Image = imErro.Image
                Else
                    imRevisaLimite.Image = imOK.Image
                    QtErros = QtErros - 1
                    imRevisaLimite.Enabled = False
                    imErro.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
                End If
                Me.Refresh()
            Case Processos.EstoqueSilo
                imEstoqueSilo.Image = imTarefa.Image
                If Utiliza_Silo() = False Then
                    imEstoqueSilo.Image = imErro.Image
                Else
                    imEstoqueSilo.Image = imOK.Image
                    QtErros = QtErros - 1
                    imEstoqueSilo.Enabled = False
                    imEstoqueSilo.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
                End If
            Case Processos.AtualizaData
                imAtualizaData.Image = imTarefa.Image
                If Atualiza_Data_Bolsa() = False Then
                    imAtualizaData.Image = imErro.Image
                Else
                    imAtualizaData.Image = imOK.Image
                    QtErros = QtErros - 1
                    imAtualizaData.Enabled = False
                    imAtualizaData.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
                End If
            Case Processos.InterfaceLivro
                'Desativado em 27/01/2011 por solicitando do setor fiscal
                'imInterfaceLivro.Image = imTarefa.Image
                'If Interface_LivroFiscal() = False Then
                '    imInterfaceLivro.Image = imErro.Image
                'Else
                '    imInterfaceLivro.Image = imOK.Image
                '    QtAlertas = QtAlertas - 1
                '    imInterfaceLivro.Enabled = False
                '    imInterfaceLivro.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
                'End If
            Case Processos.ExcluiAcessos
                imExcluiAcessos.Image = imTarefa.Image
                If Exclui_Vencidos() = False Then
                    imExcluiAcessos.Image = imErro.Image
                Else
                    imExcluiAcessos.Image = imOK.Image
                    QtAlertas = QtAlertas - 1
                    imExcluiAcessos.Enabled = False
                    imExcluiAcessos.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
                End If
            Case Processos.GeraBonus
                imGeraBonus.Image = imTarefa.Image
                If GeraBonus() = False Then
                    imGeraBonus.Image = imErro.Image
                Else
                    imGeraBonus.Image = imOK.Image
                    QtAlertas = QtAlertas - 1
                    imGeraBonus.Enabled = False
                    imGeraBonus.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
                End If
        End Select
    End Sub

    Private Sub imAuditoria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imAuditoria.Click
        Revisao(Processos.Auditoria)
    End Sub

    Private Sub imInterfacePagamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imInterfacePagamento.Click
        Revisao(Processos.InterfacePagamento)
    End Sub

    Private Sub imInterfaceMovimentacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imInterfaceMovimentacao.Click
        Revisao(Processos.InterfaceMovimentacao)
    End Sub

    Private Sub imBranche_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imBranche.Click
        Revisao(Processos.Branche)
    End Sub

    Private Sub imInativaLimite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imInativaLimite.Click
        Revisao(Processos.InativaLimite)
    End Sub

    Private Sub imRevisaLimite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imRevisaLimite.Click
        Revisao(Processos.RevisaLimite)
    End Sub

    Private Sub imEstoqueSilo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imEstoqueSilo.Click
        Revisao(Processos.EstoqueSilo)
    End Sub

    Private Sub imAtualizaData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imAtualizaData.Click
        Revisao(Processos.AtualizaData)
    End Sub

    Private Sub imInterfaceLivro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imInterfaceLivro.Click
        Revisao(Processos.InterfaceLivro)
    End Sub

    Private Sub imExcluiAcessos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imExcluiAcessos.Click
        Revisao(Processos.ExcluiAcessos)
    End Sub

    Private Sub imGeraBonus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imGeraBonus.Click
        Revisao(Processos.GeraBonus)
    End Sub

    Private Sub CarregarContabilizacao(ByVal Nivel As Integer)
        Dim oData_Filial As DataTable
        Dim oData_Aux As DataTable
        Dim oRowFilial As DataRow

        Dim SqlText As String
        Dim SqlText_Filial As String

        Dim iCont As Integer
        Dim iCont_Filial As Integer
        Dim dAux As Double
        Dim vAux As Double
        Dim sFilialMae As String

        Dim DataInicioMes As Date
        Dim Data_Sistema As Date

        Dim Bolsa As Double
        Dim ValorArroba As Double
        Dim Dolar As Double
        Dim ValorDiff As Double

        Dim CD_TP_MOV_AJST_INDUSTRIAL_RDE As Integer
        Dim CD_TP_MOV_AJST_REV_EST_FXO_RDE As Integer
        Dim CD_TP_MOV_AJST_REV_EST_BLS_RDE As Integer
        Dim CD_TP_MOV_AJST_PROV_NF_CPL_RDE As Integer
        Dim CD_TP_MOV_ESAJ_REV_EST_FXO_RDE As Integer
        Dim CD_TP_MOV_ESAJ_REV_EST_BLS_RDE As Integer
        Dim CD_TP_MOV_ESAJ_PROV_NF_CPL_RDE As Integer

        Dim NO_TP_MOV_AJST_INDUSTRIAL_RDE As String
        Dim NO_TP_MOV_AJST_REV_EST_FXO_RDE As String
        Dim NO_TP_MOV_AJST_REV_EST_BLS_RDE As String
        Dim NO_TP_MOV_AJST_PROV_NF_CPL_RDE As String
        Dim NO_TP_MOV_ESAJ_REV_EST_FXO_RDE As String
        Dim NO_TP_MOV_ESAJ_REV_EST_BLS_RDE As String
        Dim NO_TP_MOV_ESAJ_PROV_NF_CPL_RDE As String

        SqlText_Filial = "SELECT FI.CD_FILIAL," & _
                                "FI.NO_FILIAL," & _
                                "NVL(FI.CD_FILIAL_AJUSTE_RDE, FI.CD_FILIAL) CD_FILIAL_AJUSTE_RDE," & _
                                "NVL(FA.NO_FILIAL, FI.NO_FILIAL) NO_FILIAL_AJUSTE_RDE" & _
                         " FROM SOF.FILIAL FI," & _
                               "SOF.FILIAL FA" & _
                         " WHERE FA.CD_FILIAL (+) = FI.CD_FILIAL_AJUSTE_RDE"

        SqlText = "SELECT PRT.CD_TP_MOV_AJST_INDUSTRIAL_RDE," & _
                         "PRT.CD_TP_MOV_AJST_REV_EST_FXO_RDE," & _
                         "PRT.CD_TP_MOV_AJST_REV_EST_BLS_RDE," & _
                         "PRT.CD_TP_MOV_AJST_PROV_NF_CPL_RDE," & _
                         "PRT.CD_TP_MOV_ESAJ_REV_EST_FXO_RDE," & _
                         "PRT.CD_TP_MOV_ESAJ_REV_EST_BLS_RDE," & _
                         "PRT.CD_TP_MOV_ESAJ_PROV_NF_CPL_RDE," & _
                         "AID.NO_TIPO_MOVIMENTACAO NO_TP_MOV_AJST_INDUSTRIAL_RDE," & _
                         "AEF.NO_TIPO_MOVIMENTACAO NO_TP_MOV_AJST_REV_EST_FXO_RDE," & _
                         "AEB.NO_TIPO_MOVIMENTACAO NO_TP_MOV_AJST_REV_EST_BLS_RDE," & _
                         "APN.NO_TIPO_MOVIMENTACAO NO_TP_MOV_AJST_PROV_NF_CPL_RDE," & _
                         "EEF.NO_TIPO_MOVIMENTACAO NO_TP_MOV_ESAJ_REV_EST_FXO_RDE," & _
                         "EEB.NO_TIPO_MOVIMENTACAO NO_TP_MOV_ESAJ_REV_EST_BLS_RDE," & _
                         "EPV.NO_TIPO_MOVIMENTACAO NO_TP_MOV_ESAJ_PROV_NF_CPL_RDE" & _
                  " FROM SOF.PARAMETRO PRT," & _
                        "SOF.TIPO_MOVIMENTACAO AID," & _
                        "SOF.TIPO_MOVIMENTACAO AEF," & _
                        "SOF.TIPO_MOVIMENTACAO AEB," & _
                        "SOF.TIPO_MOVIMENTACAO APN," & _
                        "SOF.TIPO_MOVIMENTACAO EEF," & _
                        "SOF.TIPO_MOVIMENTACAO EEB," & _
                        "SOF.TIPO_MOVIMENTACAO EPV" & _
                  " WHERE AID.CD_TIPO_MOVIMENTACAO (+) = PRT.CD_TP_MOV_AJST_INDUSTRIAL_RDE" & _
                    " AND AEF.CD_TIPO_MOVIMENTACAO (+) = PRT.CD_TP_MOV_AJST_REV_EST_FXO_RDE" & _
                    " AND AEB.CD_TIPO_MOVIMENTACAO (+) = PRT.CD_TP_MOV_AJST_REV_EST_BLS_RDE" & _
                    " AND APN.CD_TIPO_MOVIMENTACAO (+) = PRT.CD_TP_MOV_AJST_PROV_NF_CPL_RDE" & _
                    " AND EEF.CD_TIPO_MOVIMENTACAO (+) = PRT.CD_TP_MOV_ESAJ_REV_EST_FXO_RDE" & _
                    " AND EEB.CD_TIPO_MOVIMENTACAO (+) = PRT.CD_TP_MOV_ESAJ_REV_EST_BLS_RDE" & _
                    " AND EPV.CD_TIPO_MOVIMENTACAO (+) = PRT.CD_TP_MOV_ESAJ_PROV_NF_CPL_RDE"
        oData_Filial = DBQuery(SqlText)

        With oData_Filial.Rows(0)
            CD_TP_MOV_AJST_INDUSTRIAL_RDE = NVL(.Item("CD_TP_MOV_AJST_INDUSTRIAL_RDE"), 0)
            CD_TP_MOV_AJST_REV_EST_FXO_RDE = NVL(.Item("CD_TP_MOV_AJST_REV_EST_FXO_RDE"), 0)
            CD_TP_MOV_AJST_REV_EST_BLS_RDE = NVL(.Item("CD_TP_MOV_AJST_REV_EST_BLS_RDE"), 0)
            CD_TP_MOV_AJST_PROV_NF_CPL_RDE = NVL(.Item("CD_TP_MOV_AJST_PROV_NF_CPL_RDE"), 0)
            CD_TP_MOV_ESAJ_REV_EST_FXO_RDE = NVL(.Item("CD_TP_MOV_ESAJ_REV_EST_FXO_RDE"), 0)
            CD_TP_MOV_ESAJ_REV_EST_BLS_RDE = NVL(.Item("CD_TP_MOV_ESAJ_REV_EST_BLS_RDE"), 0)
            CD_TP_MOV_ESAJ_PROV_NF_CPL_RDE = NVL(.Item("CD_TP_MOV_ESAJ_PROV_NF_CPL_RDE"), 0)

            NO_TP_MOV_AJST_INDUSTRIAL_RDE = NVL(.Item("NO_TP_MOV_AJST_INDUSTRIAL_RDE"), "")
            NO_TP_MOV_AJST_REV_EST_FXO_RDE = NVL(.Item("NO_TP_MOV_AJST_REV_EST_FXO_RDE"), "")
            NO_TP_MOV_AJST_REV_EST_BLS_RDE = NVL(.Item("NO_TP_MOV_AJST_REV_EST_BLS_RDE"), "")
            NO_TP_MOV_AJST_PROV_NF_CPL_RDE = NVL(.Item("NO_TP_MOV_AJST_PROV_NF_CPL_RDE"), "")
            NO_TP_MOV_ESAJ_REV_EST_FXO_RDE = NVL(.Item("NO_TP_MOV_ESAJ_REV_EST_FXO_RDE"), "")
            NO_TP_MOV_ESAJ_REV_EST_BLS_RDE = NVL(.Item("NO_TP_MOV_ESAJ_REV_EST_BLS_RDE"), "")
            NO_TP_MOV_ESAJ_PROV_NF_CPL_RDE = NVL(.Item("NO_TP_MOV_ESAJ_PROV_NF_CPL_RDE"), "")
        End With

        SqlText = "SELECT TRIM(NO_FILIAL) FROM SOF.FILIAL WHERE CD_FILIAL = " & FilialMae
        sFilialMae = DBQuery_ValorUnico(SqlText)

        '>> Ajuste
        'AJUSTE INDUSTRIALIZAÇÃO 	                         170	 766132.56
        'PROVISÃO NF COMPLEMENTAR 	                         164	  54063.16
        'REVALOR DE ESTOQ DIFERENC FIXO 	                 168	-396689.69
        'REVALOR DE ESTOQ PREÇO A FIXAR 	                 166	2444345.19
        '>> Estorno
        'ESTORNO PROVISÃO NF COMPL.     	                 165	 -54063.16
        'ESTORNO REVALOR ESTOQ DIF FIXO 	                 169	 396689.69
        'ESTORNO REVALOR ESTOQ A FIXAR  	                 167   -2444345.19

        oData_Filial = DBQuery(SqlText_Filial)

        Select Case Nivel
            Case 1
                Relatorio_PegaValor(Data_Sistema, Dolar, Bolsa, ValorArroba)
                SqlText = "SELECT *" & _
                          " FROM (SELECT BP.VL_DIFERENCIAL FROM SOF.BOLSA_PERIODO BP" & _
                                 " WHERE BP.IC_MOEDA = 'N'" & _
                                 " AND BP.IC_EXIBE = 'S' " & _
                                 " ORDER BY BP.SQ_BOLSA_PERIODO_MATRIZ ASC, NU_SEQUENCIA)" & _
                          " WHERE ROWNUM = 1"
                ValorDiff = DBQuery_ValorUnico(SqlText, 0)

                Data_Sistema = DataSistema()
                DataInicioMes = Data_1DiaMes(Data_Sistema)

                For iCont_Filial = 0 To oData_Filial.Rows.Count - 1
                    '>> Carregar ajuste de PROVISÃO NF COMPLEMENTAR - Início
                    oRowFilial = oData_Filial.Rows(iCont_Filial)

                    oData_Aux = Gera_Data_ProvisaoNFComplementar(0, oRowFilial.Item("CD_FILIAL"))

                    If oData_Aux.Rows.Count > 0 Then
                        With oDSContabilizacao.Rows.Add()
                            .Item(cnt_GridContabilizacao_NR_FAZER) = Nivel
                            .Item(cnt_GridContabilizacao_CD_TIPO_AJUSTE) = CD_TP_MOV_AJST_PROV_NF_CPL_RDE
                            .Item(cnt_GridContabilizacao_CD_TIPO_ESTORNO) = CD_TP_MOV_ESAJ_PROV_NF_CPL_RDE
                            .Item(cnt_GridContabilizacao_MovimentacaoAjuste) = NO_TP_MOV_AJST_PROV_NF_CPL_RDE
                            .Item(cnt_GridContabilizacao_MovimentacaoEstorno) = NO_TP_MOV_ESAJ_PROV_NF_CPL_RDE
                            .Item(cnt_GridContabilizacao_CD_FILIAL) = oRowFilial.Item("CD_FILIAL")
                            .Item(cnt_GridContabilizacao_CD_FILIAL_AJUSTE) = oRowFilial.Item("CD_FILIAL_AJUSTE_RDE")
                            .Item(cnt_GridContabilizacao_FilialContabilizada) = oRowFilial.Item("NO_FILIAL")
                            .Item(cnt_GridContabilizacao_FilialAjuste) = oRowFilial.Item("NO_FILIAL_AJUSTE_RDE")

                            For iCont = 0 To oData_Aux.Rows.Count - 1
                                .Item(cnt_GridContabilizacao_ValorAjuste) = NVL(.Item(cnt_GridContabilizacao_ValorAjuste), 0) + _
                                                                            (NVL(oData_Aux.Rows(iCont).Item("VL_CONTRATO"), 0) - _
                                                                             NVL(oData_Aux.Rows(iCont).Item("VL_NF"), 0))
                            Next
                        End With
                    End If
                    '>> Carregar ajuste de PROVISÃO NF COMPLEMENTAR - Fim

                    '>> Carregar ajuste de REVALOR DE ESTOQ DIFERENC FIXO - Início
                    vAux = 0
                    oData_Aux = Gera_RS_Neg_A_Ordem(oRowFilial.Item("CD_FILIAL"))

                    For iCont = 0 To oData_Aux.Rows.Count - 1
                        With oData_Aux.Rows(iCont)
                            If NVL(.Item("QT_KG_A_FIXAR"), 0) <> 0 Then
                                vAux = vAux + ((((Math.Round((((Bolsa + NVL(.Item("VL_DIFERENCIAL"), 0)) * Dolar) / 1000), 4)) * NVL(.Item("QT_KG_A_FIXAR"), 0))) - .Item("VL_A_FIXAR"))
                            End If
                        End With
                    Next

                    If vAux <> 0 Then
                        With oDSContabilizacao.Rows.Add()
                            .Item(cnt_GridContabilizacao_NR_FAZER) = Nivel
                            .Item(cnt_GridContabilizacao_CD_TIPO_AJUSTE) = CD_TP_MOV_AJST_REV_EST_BLS_RDE
                            .Item(cnt_GridContabilizacao_CD_TIPO_ESTORNO) = CD_TP_MOV_ESAJ_REV_EST_BLS_RDE
                            .Item(cnt_GridContabilizacao_MovimentacaoAjuste) = NO_TP_MOV_AJST_REV_EST_BLS_RDE
                            .Item(cnt_GridContabilizacao_MovimentacaoEstorno) = NO_TP_MOV_ESAJ_REV_EST_BLS_RDE
                            .Item(cnt_GridContabilizacao_CD_FILIAL) = oRowFilial.Item("CD_FILIAL")
                            .Item(cnt_GridContabilizacao_CD_FILIAL_AJUSTE) = oRowFilial.Item("CD_FILIAL_AJUSTE_RDE")
                            .Item(cnt_GridContabilizacao_FilialContabilizada) = oRowFilial.Item("NO_FILIAL")
                            .Item(cnt_GridContabilizacao_FilialAjuste) = oRowFilial.Item("NO_FILIAL_AJUSTE_RDE")
                            .Item(cnt_GridContabilizacao_ValorAjuste) = vAux
                        End With
                    End If
                    '>> Carregar ajuste de REVALOR DE ESTOQ DIFERENC FIXO - Fim

                    '>> Carregar ajuste de REVALOR DE ESTOQ PREÇO A FIXAR - Início
                    vAux = 0
                    oData_Aux = Gera_Rs_Cacau_A_Ordem(oRowFilial.Item("CD_FILIAL"), False, False, Now.Date, False, False, False, False, , True)

                    For iCont = 0 To oData_Aux.Rows.Count - 1
                        With oData_Aux.Rows(iCont)
                            If NVL(.Item("QT_KG_A_FIXAR"), 0) <> 0 Then
                                vAux = vAux + Math.Round((Math.Round((((Bolsa + ValorDiff) * Dolar) / 1000), 4) * NVL(.Item("QT_KG_A_FIXAR"), 0)) - .Item("VL_A_FIXAR"), 2)
                            End If
                        End With
                    Next

                    If vAux <> 0 Then
                        With oDSContabilizacao.Rows.Add()
                            .Item(cnt_GridContabilizacao_NR_FAZER) = Nivel
                            .Item(cnt_GridContabilizacao_CD_TIPO_AJUSTE) = CD_TP_MOV_AJST_REV_EST_FXO_RDE
                            .Item(cnt_GridContabilizacao_CD_TIPO_ESTORNO) = CD_TP_MOV_ESAJ_REV_EST_FXO_RDE
                            .Item(cnt_GridContabilizacao_MovimentacaoAjuste) = NO_TP_MOV_AJST_REV_EST_FXO_RDE
                            .Item(cnt_GridContabilizacao_MovimentacaoEstorno) = NO_TP_MOV_ESAJ_REV_EST_FXO_RDE
                            .Item(cnt_GridContabilizacao_CD_FILIAL) = oRowFilial.Item("CD_FILIAL")
                            .Item(cnt_GridContabilizacao_CD_FILIAL_AJUSTE) = oRowFilial.Item("CD_FILIAL_AJUSTE_RDE")
                            .Item(cnt_GridContabilizacao_FilialContabilizada) = oRowFilial.Item("NO_FILIAL")
                            .Item(cnt_GridContabilizacao_FilialAjuste) = oRowFilial.Item("NO_FILIAL_AJUSTE_RDE")
                            .Item(cnt_GridContabilizacao_ValorAjuste) = vAux
                        End With
                    End If
                    '>> Carregar ajuste de REVALOR DE ESTOQ PREÇO A FIXAR - Fim
                Next
            Case 2
                '>> Carregar ajuste de Industrialização - Início
                Data_Sistema = DataSistema()
                DataInicioMes = Data_1DiaMes(Data_Sistema)

                dAux = 0
                vAux = 0
                oData_Aux = Gera_Data_IndustrializacaoValorializacao(DataInicioMes, Data_Sistema)

                For iCont = 0 To oData_Aux.Rows.Count - 1
                    With oData_Aux.Rows(iCont)
                        dAux = dAux + (NVL(.Item("QT_LINHA_A"), 0) + NVL(.Item("QT_LINHA_B"), 0))
                        vAux = vAux + (NVL(.Item("VL_LINHA_A"), 0) + NVL(.Item("VL_LINHA_B"), 0))
                    End With
                Next

                With oDSContabilizacao.Rows.Add()
                    .Item(cnt_GridContabilizacao_NR_FAZER) = Nivel
                    .Item(cnt_GridContabilizacao_CD_TIPO_AJUSTE) = CD_TP_MOV_AJST_INDUSTRIAL_RDE
                    .Item(cnt_GridContabilizacao_MovimentacaoAjuste) = NO_TP_MOV_AJST_INDUSTRIAL_RDE
                    .Item(cnt_GridContabilizacao_CD_FILIAL) = FilialMae
                    .Item(cnt_GridContabilizacao_CD_FILIAL_AJUSTE) = FilialMae
                    .Item(cnt_GridContabilizacao_FilialContabilizada) = sFilialMae
                    .Item(cnt_GridContabilizacao_FilialAjuste) = sFilialMae
                    .Item(cnt_GridContabilizacao_ValorAjuste) = ((dAux * PrecoMedioRD(DataSistema)) - vAux)
                End With
                '>> Carregar ajuste de Industrialização - Fim
        End Select

        cmdFazerAjuste.Tag = Nivel
        objData_Finalizar(oData_Aux)
        objData_Finalizar(oData_Filial)
    End Sub

    Private Sub cmdFazerAjuste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFazerAjuste.Click
        Dim SqlText As String
        Dim iCont As Integer
        Dim DataAjuste As Date

        DataAjuste = DataSistema()

        For iCont = 0 To grdContabilizacao.Rows.Count - 1
            SqlText = DBMontar_SP("SOF.INCLUI_RD", False, ":TPMOV", ":DATA", ":FILIAL", ":VALOR", ":QUANT")

            With grdContabilizacao.Rows(iCont)
                If .Cells(cnt_GridContabilizacao_NR_FAZER).Value = cmdFazerAjuste.Tag And _
                   NVL(.Cells(cnt_GridContabilizacao_IC_AJUSTE_REALIZADO).Value, "N") = "N" Then
                    If Not DBExecutar(SqlText, DBParametro_Montar("TPMOV", .Cells(cnt_GridContabilizacao_CD_TIPO_AJUSTE).Value), _
                                               DBParametro_Montar("DATA", DataAjuste, OracleClient.OracleType.DateTime), _
                                               DBParametro_Montar("FILIAL", .Cells(cnt_GridContabilizacao_CD_FILIAL_AJUSTE).Value), _
                                               DBParametro_Montar("VALOR", .Cells(cnt_GridContabilizacao_ValorAjuste).Value), _
                                               DBParametro_Montar("QUANT", 0)) Then GoTo Erro

                    .Cells(cnt_GridContabilizacao_IC_AJUSTE_REALIZADO).Value = "S"
                End If
            End With
        Next

        grdContabilizacao.Refresh()

        Select Case cmdFazerAjuste.Tag
            Case cnt_RealizarAjustes_Fase01
                CarregarContabilizacao(cnt_RealizarAjustes_Fase02)
                lblStatusContabilizacao.Text = "Ajustes Fase 01 realizados. Realize os ajuste Fase 02."
            Case cnt_RealizarAjustes_Fase02
                cmdFazerAjuste.Visible = False
                lblStatusContabilizacao.Text = "Ajustes Fase 02 realizados. Pode proceder com a abertura de dia."
                GoTo Sair
        End Select

        cmdFazerAjuste.Text = "Realizar Ajustes (Fase " & Format(cmdFazerAjuste.Tag, "00") & ")"

Sair:
        Exit Sub

Erro:
        TratarErro(, , "frmAbreDia.cmdFazerAjuste_Click")
    End Sub

    Private Function VerificarFechamento() As Boolean
        Exit Function
        If Month(DataSistema()) <> Month(txtData.DateTime.Date) Then
            TabContabilizacao.Tab.Visible = True
            tbcGeral.ActiveTab = TabContabilizacao.Tab

            CarregarContabilizacao(cnt_RealizarAjustes_Fase01)
        End If
    End Function

    Private Sub RealizarEstorno()
        Dim SqlText As String
        Dim iCont As Integer
        Dim dAux As Double
        Exit Sub
        For iCont = 0 To grdContabilizacao.Rows.Count - 1
            With grdContabilizacao.Rows(iCont)
                If Not CampoNulo(.Cells(cnt_GridContabilizacao_CD_TIPO_ESTORNO).Value) Then
                    dAux = .Cells(cnt_GridContabilizacao_ValorAjuste).Value

                    SqlText = DBMontar_SP("SOF.INCLUI_RD", False, ":TPMOV", ":DATA", ":FILIAL", ":VALOR", ":QUANT")
                    If Not DBExecutar(SqlText, DBParametro_Montar("TPMOV", .Cells(cnt_GridContabilizacao_CD_TIPO_ESTORNO).Value), _
                                               DBParametro_Montar("DATA", DataNova, OracleClient.OracleType.DateTime), _
                                               DBParametro_Montar("FILIAL", .Cells(cnt_GridContabilizacao_CD_FILIAL_AJUSTE).Value), _
                                               DBParametro_Montar("VALOR", (dAux * -1)), _
                                               DBParametro_Montar("QUANT", 0)) Then GoTo Erro
                End If
            End With
        Next

        Exit Sub

Erro:
        TratarErro(, , "frmAbreDia.RealizarEstorno")
    End Sub
End Class