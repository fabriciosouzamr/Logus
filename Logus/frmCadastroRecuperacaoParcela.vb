Public Class frmCadastroRecuperacaoParcela
    Enum eTipoRecuperacaoParcela
        CadastroNovaParcela = 1
        Renegociar = 2
        QuebrarParcela = 3
    End Enum

    Public SqConfissaoDivida As Integer
    Public NuParcelaAnterior As Integer
    Public oTipoRecuperacaoParcela As eTipoRecuperacaoParcela

    Private Sub optForma_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optForma.ValueChanged
        Select Case optForma.Value
            Case "D"
                Me.txtDescricaoOutros.Text = ""
                Me.txtDescricaoOutros.Enabled = False
                Me.txtQuantidadeParcela.Value = 1
                Me.txtQuantidadeParcela.Enabled = False
            Case "C"
                Me.txtDescricaoOutros.Text = ""
                Me.txtDescricaoOutros.Enabled = False
                Me.txtQuantidadeParcela.Value = 0
                Me.txtQuantidadeParcela.Enabled = True
            Case "O"
                Me.txtDescricaoOutros.Enabled = True
                Me.txtQuantidadeParcela.Value = 0
                Me.txtQuantidadeParcela.Enabled = True
            Case Else
                Me.txtDescricaoOutros.Text = ""
                Me.txtDescricaoOutros.Enabled = False
                Me.txtQuantidadeParcela.Value = 0
                Me.txtQuantidadeParcela.Enabled = True
        End Select
    End Sub

    Private Sub frmCadastroRecuperacaoParcela_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Select Case oTipoRecuperacaoParcela
            Case eTipoRecuperacaoParcela.QuebrarParcela
                Dim oData As DataTable
                Dim SqlText As String

                SqlText = "SELECT DECODE(IC_CACAU,'S',1,DECODE(IC_MOEDA,'S',2,DECODE(IC_OUTROS,'S',3,4))) CD_FORMA" & _
                          " FROM SOF.CONFISSAO_DIVIDA_PARCELA " & _
                          " WHERE SQ_CONFISSAO_DIVIDA=" & SqConfissaoDivida & _
                            " AND NU_PARCELA=" & NuParcelaAnterior
                oData = DBQuery(SqlText)

                Select Case oData.Rows(0).Item("cd_forma")
                    Case 1
                        optForma.Value = "C"
                    Case 2
                        optForma.Value = "D"
                    Case 3
                        optForma.Value = "O"
                        txtDescricaoOutros.Text = "" & oData.Rows(0).Item("ds_outros")
                End Select

                optForma.Enabled = False
                txtDescricaoOutros.Enabled = False
                Me.Text = "Quebra Parcela"
            Case eTipoRecuperacaoParcela.CadastroNovaParcela
                Me.Text = "Nova Parcela"
            Case eTipoRecuperacaoParcela.Renegociar
                Me.Text = "Renegocia Parcela"
        End Select


        optForma_ValueChanged(Nothing, Nothing)
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String
        Dim VlParcelaAnterior As Double
        Dim QtParcelaAnterior As Double

        If txtValorParcela.Value <= 0 Then
            Msg_Mensagem("Valor invalido.")
            txtValorParcela.Focus()
            Exit Sub
        End If

        Select Case optForma.Value
            Case "C"
                If txtQuantidadeParcela.Value <= 0 Then
                    Msg_Mensagem("Quantidade invalida.")
                    txtQuantidadeParcela.Focus()
                    Exit Sub
                End If
            Case "O"
                If txtQuantidadeParcela.Value <= 0 Then
                    Msg_Mensagem("Quantidade invalida.")
                    txtQuantidadeParcela.Focus()
                    Exit Sub
                End If
                If Me.txtDescricaoOutros.Text = "" Then
                    Msg_Mensagem("Favor informar uma descrição.")
                    txtDescricaoOutros.Focus()
                    Exit Sub
                End If
            Case "D"
            Case Else
                Msg_Mensagem("Favor selecionar uma forma.")
                Exit Sub
        End Select

        If Not txtDataVencimentoParcela Is Nothing Then
            If Not IsDate(txtDataVencimentoParcela.Text) Then
                Msg_Mensagem("Data de vencimento invalida.")
                txtDataVencimentoParcela.Focus()
                Exit Sub
            End If

            If Not SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_IncluirRecuperacaoCreditoDataRetroativa) Then
                If txtDataVencimentoParcela.DateTime.Date <= CDate(DataSistema()) Then
                    Msg_Mensagem("A data de vencimento não pode ser inferior a data atual.")
                    txtDataVencimentoParcela.Focus()
                    Exit Sub
                End If
            End If
        End If

        SqlText = "SELECT VL_PARCELA" & _
                  " FROM SOF.CONFISSAO_DIVIDA_PARCELA" & _
                  " WHERE SQ_CONFISSAO_DIVIDA = " & SqConfissaoDivida & _
                    " AND NU_PARCELA = " & NuParcelaAnterior
        VlParcelaAnterior = DBQuery_ValorUnico(SqlText)

        If oTipoRecuperacaoParcela = eTipoRecuperacaoParcela.QuebrarParcela Then
            SqlText = "SELECT QT_ITEM_PARCELA" & _
                      " FROM SOF.CONFISSAO_DIVIDA_PARCELA" & _
                      " WHERE SQ_CONFISSAO_DIVIDA = " & SqConfissaoDivida & _
                        " AND NU_PARCELA = " & NuParcelaAnterior
            QtParcelaAnterior = DBQuery_ValorUnico(SqlText)

            If VlParcelaAnterior <= txtValorParcela.Value Then
                Msg_Mensagem("Favor informar um valor menor do que " & Format(VlParcelaAnterior, "#,##0.00"))
                Exit Sub
            End If
            If optForma.Value <> "D" Then
                If QtParcelaAnterior <= txtQuantidadeParcela.Value Then
                    Msg_Mensagem("Favor informar uma quantidade menor do que " & Format(QtParcelaAnterior, "#,##0.000"))
                    Exit Sub
                End If
            End If
        End If

        SqlText = DBMontar_SP("SOF.SP_INCLUI_CONF_DIV_PARCELA", False, ":SQCONFISSAODIVIDA", _
                                                                       ":ICSITUACAO", _
                                                                       ":ICCACAU", _
                                                                       ":ICMOEDA", _
                                                                       ":ICOUTROS", _
                                                                       ":DSOUTROS", _
                                                                       ":DTVENCIMENTO", _
                                                                       ":VLPARCELA", _
                                                                       ":QTITEMPARCELA", _
                                                                       ":NUPARCELAANTERIOR", _
                                                                       ":NUPARCELA")

        If Not DBExecutar(SqlText, DBParametro_Montar("SQCONFISSAODIVIDA", SqConfissaoDivida), _
                                   DBParametro_Montar("ICSITUACAO", "A"), _
                                   DBParametro_Montar("ICCACAU", IIf(optForma.Value = "C", "S", "N")), _
                                   DBParametro_Montar("ICMOEDA", IIf(optForma.Value = "D", "S", "N")), _
                                   DBParametro_Montar("ICOUTROS", IIf(optForma.Value = "O", "S", "N")), _
                                   DBParametro_Montar("DSOUTROS", IIf(optForma.Value = "O", txtDescricaoOutros.Text, Nothing)), _
                                   DBParametro_Montar("DTVENCIMENTO", Date_to_Oracle(txtDataVencimentoParcela.Text), OracleClient.OracleType.DateTime), _
                                   DBParametro_Montar("VLPARCELA", txtValorParcela.Value), _
                                   DBParametro_Montar("QTITEMPARCELA", txtQuantidadeParcela.Value), _
                                   DBParametro_Montar("NUPARCELAANTERIOR", NuParcelaAnterior), _
                                   DBParametro_Montar("NUPARCELA", Nothing, , ParameterDirection.Output)) Then GoTo Erro

        Select Case oTipoRecuperacaoParcela
            Case eTipoRecuperacaoParcela.Renegociar
                SqlText = "UPDATE SOF.CONFISSAO_DIVIDA_PARCELA" & _
                          " SET IC_SITUACAO = 'C' " & _
                          " WHERE SQ_CONFISSAO_DIVIDA = " & SqConfissaoDivida & _
                            " AND NU_PARCELA = " & NuParcelaAnterior
                If Not DBExecutar(SqlText) Then GoTo Erro

                SqlText = "UPDATE SOF.CONFISSAO_DIVIDA" & _
                          " SET VL_NEGOCIADO = VL_NEGOCIADO - " & VlParcelaAnterior & " + " & txtValorParcela.Value & _
                          " WHERE SQ_CONFISSAO_DIVIDA = " & SqConfissaoDivida
                If Not DBExecutar(SqlText) Then GoTo Erro
            Case eTipoRecuperacaoParcela.QuebrarParcela
                Select Case optForma.Value
                    Case "C", "O"
                        SqlText = "UPDATE SOF.CONFISSAO_DIVIDA_PARCELA" & _
                                  " SET VL_PARCELA = VL_PARCELA - " & txtValorParcela.Value & _
                                      ",QT_ITEM_PARCELA = QT_ITEM_PARCELA - " & txtQuantidadeParcela.Value & _
                                  " WHERE SQ_CONFISSAO_DIVIDA = " & SqConfissaoDivida & _
                                    " AND NU_PARCELA = " & NuParcelaAnterior
                        If Not DBExecutar(SqlText) Then GoTo Erro
                    Case "D"
                        SqlText = "UPDATE SOF.CONFISSAO_DIVIDA_PARCELA" & _
                                  " SET VL_PARCELA = VL_PARCELA - " & txtValorParcela.Value & _
                                  " WHERE SQ_CONFISSAO_DIVIDA = " & SqConfissaoDivida & _
                                    " AND NU_PARCELA = " & NuParcelaAnterior
                        If Not DBExecutar(SqlText) Then GoTo Erro
                End Select
        End Select

        Me.Close()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub
End Class