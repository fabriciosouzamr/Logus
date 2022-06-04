Public Class frmCadastroSolicitacaoCredito_Cancelamento
    Public CdSolicitacaoCredito As Integer

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmCadastroSolicitacaoCredito_Cancelamento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CarregarAprovacao()
    End Sub

    Private Sub CarregarAprovacao()
        Dim SqlText As String
        Dim oData As DataTable
        Dim iCont As Integer
        Dim Quant As Double

        SqlText = "SELECT DISTINCT UTA.cd_tipo_aprovacao, TA.NO_TIPO_APROVACAO,UTA.VL_MINIMO_APROVACAO, UTA.VL_MAXIMO_APROVACAO, " & _
              "TA.IC_POSSUI_LIMITE,  decode(uta.dt_validade,null,sysdate,uta.dt_validade) as dt_validade " & _
              "FROM SOF.USUARIO_TIPO_APROVACAO UTA, SOF.TIPO_APROVACAO TA " & _
              "WHERE UTA.CD_TIPO_APROVACAO = TA.CD_TIPO_APROVACAO AND " & _
              "UTA.CD_USER = '" & sAcesso_UsuarioLogado & "'"
        oData = DBQuery(SqlText)

        If oData.Rows.Count = 0 Then
            Msg_Mensagem("Você não tem acesso a Cancelamento de Solicitações de Crédito.")
            Exit Sub
        End If

        Quant = DBQuery_ValorUnico("select l.vl_credito  FROM sof.limite_credito l where l.sq_limite_credito =" & CdSolicitacaoCredito)

        For iCont = 0 To oData.Rows.Count - 1
            If oData.Rows(iCont).Item("ic_possui_limite") = "S" Then
                If Not (oData.Rows(iCont).Item("vl_minimo_aprovacao") <= Quant And _
                   oData.Rows(iCont).Item("vl_maximo_aprovacao") >= Quant And _
                   oData.Rows(iCont).Item("dt_validade") >= Now) Then
                    oData.Rows(iCont).Delete()
                End If
            End If
        Next

        lstAprovacao.DataSource = oData
        lstAprovacao.DisplayMember = "NO_TIPO_APROVACAO"
        lstAprovacao.ValueMember = "cd_tipo_aprovacao"
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim iCont As Integer
        Dim Sqltext As String
        Dim Parametro(3) As DBParamentro

        If lstAprovacao.CheckedItems.Count = 0 Then
            Msg_Mensagem("Favor selecionar ao menos um tipo de aprovação.")
            lstAprovacao.Focus()
            Exit Sub
        End If
        If rctDescricao.Text = "" Then
            Msg_Mensagem("Favor informar o motivo.")
            rctDescricao.Focus()
            Exit Sub
        End If


        For iCont = 0 To lstAprovacao.CheckedItems.Count - 1
            SqlText = DBMontar_SP("SOF.SP_INCLUI_APROVACAO_CREDITO", False, ":SQLIMITE", ":TPAPROV", ":STAPROV", ":DSOBS")

            Parametro(0) = DBParametro_Montar("SQLIMITE", CdSolicitacaoCredito)
            Parametro(1) = DBParametro_Montar("TPAPROV", lstAprovacao.CheckedItems(iCont)(0))
            Parametro(2) = DBParametro_Montar("STAPROV", "C")

            If rctDescricao.Text = "" Then
                Parametro(3) = DBParametro_Montar("DSOBS", Nothing, OracleClient.OracleType.VarChar, , 4000)
            Else
                Parametro(3) = DBParametro_Montar("DSOBS", rctDescricao.Text, OracleClient.OracleType.VarChar, , 4000)
            End If

            If Not DBExecutar(SqlText, Parametro) Then GoTo Erro
        Next

        Msg_Mensagem("Cancelamento Realizado")
        Close()
        Exit Sub
Erro:
        TratarErro()
    End Sub
End Class