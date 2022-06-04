Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_Diferencial
    Dim oRelatorio As New CrystalReportDocument

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmREL_Diferencial_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_Diferencial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDataInicial.Value = DataSistema()
        txtDataFinal.Value = DataSistema()

        Pesq_Fornecedor.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        With SelecaoFilial
            .BancoDados_Tabela = "SOF.FILIAL"
            .BancoDados_Campo_Codigo = "CD_FILIAL"
            .BancoDados_Campo_Descricao = "NO_FILIAL"
            .BancoDados_Carregar()
        End With
        With SelecaoTipoCacau
            .BancoDados_Tabela = "SOF.TIPO_CACAU"
            .BancoDados_Campo_Codigo = "CD_TIPO_CACAU"
            .BancoDados_Campo_Descricao = "NO_TIPO_CACAU"
            .BancoDados_Carregar()
        End With
        With SelecaoTipoPessoa
            .BancoDados_Tabela = "SOF.TIPO_PESSOA"
            .BancoDados_Campo_Codigo = "CD_TIPO_PESSOA"
            .BancoDados_Campo_Descricao = "NO_TIPO_PESSOA"
            .BancoDados_Carregar()
        End With
        With SelecaoUF
            .BancoDados_Tabela = "SOF.UF"
            .BancoDados_Campo_Codigo = "CD_UF"
            .BancoDados_Campo_Descricao = "NO_UF"
            .BancoDados_Carregar()
        End With

        Configura_Relatorio()

        Me.WindowState = 2
    End Sub

    Private Sub Configura_Relatorio()
        Dim SqlText As String = ""

        Select Case optRelatorio.Value
            Case "D"
                SqlText = "SELECT 'TODOS', 'Todos' " & _
                        "  FROM DUAL UNION " & _
                        "SELECT 'SEM_IMPORT', 'Sem Importado' " & _
                        "  FROM DUAL UNION " & _
                        "SELECT 'SOMENTE_IMPORT', 'Somente Importado' " & _
                        "  FROM DUAL UNION " & _
                        "SELECT 'NEG_SEM_IMPORT', 'Negociaçoes s\ Importado' " & _
                        "  FROM DUAL UNION " & _
                        "SELECT 'NEG_SOMENTE_IMPORT', 'Negociações Somente Importado' " & _
                        "  FROM DUAL "

                optTipo.Enabled = True
                optTipo.CheckedIndex = 1
                chkAgrupaFornecedor.Enabled = True
                Pesq_Fornecedor.Enabled = True
            Case "P"
                SqlText = "SELECT 'TODOS', 'Todos' " & _
                        "  FROM DUAL UNION " & _
                        "SELECT 'SEM_IMPORT', 'Sem Importado' " & _
                        "  FROM DUAL UNION " & _
                        "SELECT 'SOMENTE_IMPORT', 'Somente Importado' " & _
                        "  FROM DUAL "

                optTipo.Enabled = False
                optTipo.CheckedIndex = 1
                chkAgrupaFornecedor.Enabled = False
                chkAgrupaFornecedor.Checked = False
                Pesq_Fornecedor.Codigo = 0
                Pesq_Fornecedor.Enabled = False
        End Select

        DBCarregarComboBox(cboOpcoes, SqlText, False)

        ComboBox_Possicionar(cboOpcoes, "TODOS")
    End Sub

    Private Sub Imprimir()
        Dim oData As DataTable
        Dim SqlText As String = ""
        Dim sFiltro As String = ""
        Dim Opcao As enCalcDiferencial_Opcao

        If Not Data_ValidarPeriodo("", txtDataInicial.Value, txtDataFinal.Value, True) Then Exit Sub

        AVI_Carregar(Me)

        Select Case optRelatorio.Value
            Case "D"
                If ComboBox_LinhaSelecionada(cboOpcoes) Then
                    Select Case cboOpcoes.SelectedValue
                        Case "SEM_IMPORT"
                            Opcao = enCalcDiferencial_Opcao.SEM_IMPORT
                        Case "NEG_SEM_IMPORT"
                            Opcao = enCalcDiferencial_Opcao.NEG_SEM_IMPORT
                        Case "SOMENTE_IMPORT"
                            Opcao = enCalcDiferencial_Opcao.SOMENTE_IMPORT
                        Case "NEG_SOMENTE_IMPORT"
                            Opcao = enCalcDiferencial_Opcao.NEG_SOMENTE_IMPORT
                        Case "TODOS"
                            Opcao = enCalcDiferencial_Opcao.TODOS
                        Case Else
                            Opcao = enCalcDiferencial_Opcao.NAO_INFORMADO
                    End Select
                End If

                oData = Gera_Rs_CalculoDiferencial(txtDataInicial.DateTime.Date, _
                                                    txtDataFinal.DateTime.Date, _
                                                    SelecaoFilial.Lista_ID, _
                                                    SelecaoTipoCacau.Lista_ID, _
                                                    SelecaoTipoPessoa.Lista_ID, _
                                                    SelecaoUF.Lista_ID, _
                                                    chkFilialEntregaCtr.Checked, _
                                                    Pesq_Fornecedor.Codigo, _
                                                    chkExcluiCancelado.Checked, _
                                                    Opcao)

                oRelatorio.Load(Application.StartupPath & "\RPT_Diferencial.rpt")
                oRelatorio.SetDataSource(oData)

                oRelatorio.SetParameterValue("Periodo", "Período: De " & txtDataInicial.Text & " até " & txtDataFinal.Text)
                oRelatorio.SetParameterValue("AgrupaFornecedor", IIf(chkAgrupaFornecedor.Checked, "S", "N"))
                oRelatorio.SetParameterValue("Tipo", optTipo.Value)
                oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

                crvMain.ReportSource = oRelatorio
            Case "P"
                'CONSULTA DE NEGOCIAÇÃO
                SqlText = "SELECT N.CD_CONTRATO_PAF CD_CONTRATO," & _
                                 "F.NO_RAZAO_SOCIAL," & _
                                 "TP.NO_TIPO_PESSOA," & _
                                 "N.QT_KGS," & _
                                 "N.CD_TIPO_UNIDADE," & _
                                 "N.VL_NEGOCIACAO VL_UNITARIO," & _
                                 "N.VL_PRECO_FRETE," & _
                                 "N.QT_KG_FIXO," & _
                                 "FIL.CD_FILIAL," & _
                                 "FIL.NO_FILIAL," & _
                                 "FUN.VL_TAXA," & _
                                 "N.PC_ALIQ_ICMS," & _
                                 "NVL(N.VL_TAXA_DOLAR, 0) VL_TAXA_DOLAR," & _
                                 "NVL(N.VL_TAXA_DOLAR_ALTERNATIVO, 0) VL_TAXA_DOLAR_ALTERNATIVO," & _
                                 "NVL(N.VL_BOLSA, 0) VL_BOLSA, " & _
                                 "NVL(N.VL_BOLSA_ALTERNATIVO, 0) VL_BOLSA_ALTERNATIVO," & _
                                 "DECODE(TN.IC_BOLSA, 'S', N.CD_PAPEL_COMPETENCIA, N.CD_PAPEL) CD_PAPEL," & _
                                 "N.VL_DIFERENCIAL," & _
                                 "N.DT_CRIACAO," & _
                                 "N.DT_NEGOCIACAO DT_CONTRATO," & _
                                 "N.SQ_NEGOCIACAO," & _
                                 "TU.QT_FATOR," & _
                                 "TN.CD_TIPO_NEGOCIACAO," & _
                                 "TN.NO_TIPO_NEGOCIACAO," & _
                                 "TN.IC_BOLSA," & _
                                 "TN.IC_BOLSA_OPERACAO," & _
                                 "TN.IC_TIPO_PRECO_FIXO," & _
                                 "TN.IC_DOLAR," & _
                                 "0 SQ_CONTRATO_FIXO," & _
                                 "'N' TP_CTR," & _
                                 "0 VL_NEGOCIACAO_BOLSA," & _
                                 "N.VL_PREMIO_UNITARIO VL_PREMIO_UNITARIO_KG," & _
                                 "F.IC_FISICA_JURIDICA," & _
                                 "TC.CD_TIPO_CACAU," & _
                                 "TC.NO_TIPO_CACAU" & _
                          " FROM SOF.FORNECEDOR F," & _
                                "SOF.FILIAL FIL," & _
                                "SOF.TIPO_PESSOA TP," & _
                                "SOF.CONTRATO_PAF CP," & _
                                "SOF.NEGOCIACAO N," & _
                                "SOF.FUNRURAL FUN," & _
                                "SOF.TIPO_NEGOCIACAO TN," & _
                                "SOF.TIPO_UNIDADE TU," & _
                                "SOF.MUNICIPIO MUNIC," & _
                                "SOF.TIPO_CACAU TC" & _
                          " WHERE CP.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                            " AND F.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                            " AND F.CD_TIPO_PESSOA = TP.CD_TIPO_PESSOA" & _
                            " AND CP.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF" & _
                            " AND F.CD_FUNRURAL = FUN.CD_FUNRURAL" & _
                            " AND N.CD_TIPO_NEGOCIACAO = TN.CD_TIPO_NEGOCIACAO" & _
                            " AND N.CD_TIPO_UNIDADE=TU.CD_TIPO_UNIDADE" & _
                            " AND F.CD_MUNICIPIO = MUNIC.CD_MUNICIPIO" & _
                            " AND TC.CD_TIPO_CACAU (+) = N.CD_TIPO_CACAU" & _
                            " AND N.DT_NEGOCIACAO  BETWEEN " & QuotedStr(Date_to_Oracle(txtDataInicial.Text)) & _
                                                     " AND " & QuotedStr(Date_to_Oracle(txtDataFinal.Text)) & _
                            " AND N.IC_STATUS <> 'E'"

                'FILTRA FILIAL
                If SelecaoFilial.Lista_Quantidade > 0 Then
                    If chkFilialEntregaCtr.Checked Then
                        SqlText = SqlText & " AND CP.CD_FILIAL_ENTREGA IN (" & SelecaoFilial.Lista_ID & ")"
                    Else
                        SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & SelecaoFilial.Lista_ID & ")"
                    End If
                Else
                    SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
                End If
                If SelecaoTipoCacau.Lista_Quantidade > 0 Then
                    SqlText = SqlText & " AND TC.CD_TIPO_CACAU IN (" & SelecaoTipoCacau.Lista_ID & ")"
                End If
                If SelecaoTipoPessoa.Lista_Quantidade > 0 Then
                    SqlText = SqlText & " AND TP.CD_TIPO_PESSOA IN (" & SelecaoTipoPessoa.Lista_ID & ")"
                End If
                If SelecaoUF.Lista_Quantidade > 0 Then
                    SqlText = SqlText & " AND MUNIC.CD_UF IN (" & SelecaoUF.Lista_ID & ")"
                End If

                Select Case cboOpcoes.SelectedValue
                    Case "SEM_IMPORT"
                        SqlText = SqlText & " AND MUNIC.CD_UF <> 'EX'"
                    Case "SOMENTE_IMPORT"
                        SqlText = SqlText & " AND MUNIC.CD_UF = 'EX'"
                End Select

                If chkExcluiCancelado.Checked = False Then
                    'CONSULTA DE NEGOCIAÇÕES CANCELAMENTOS
                    SqlText = SqlText & _
                              " UNION ALL " & _
                              "SELECT N.CD_CONTRATO_PAF," & _
                                     "F.NO_RAZAO_SOCIAL," & _
                                     "TP.NO_TIPO_PESSOA," & _
                                     "(0 - NC.QT_CANCELADO) QT_KGS," & _
                                     "N.CD_TIPO_UNIDADE," & _
                                     "NC.VL_UNITARIO," & _
                                     "0 VL_PRECO_FRETE," & _
                                     "N.QT_KG_FIXO," & _
                                     "FIL.CD_FILIAL," & _
                                     "FIL.NO_FILIAL," & _
                                     "0 VL_TAXA," & _
                                     "0 PC_ALIQ_ICMS," & _
                                     "0 VL_TAXA_DOLAR," & _
                                     "NC.VL_TAXA_DOLAR VL_TAXA_DOLAR_ALTERNATIVO," & _
                                     "0 VL_BOLSA," & _
                                     "NC.VL_BOLSA VL_BOLSA_ALTERNATIVO," & _
                                     "NC.CD_PAPEL," & _
                                     "0 VL_DIFERENCIAL," & _
                                     "NC.DT_CRIACAO," & _
                                     "NC.DT_CANCELAMENTO," & _
                                     "N.SQ_NEGOCIACAO," & _
                                     "TU.QT_FATOR," & _
                                     "TN.CD_TIPO_NEGOCIACAO," & _
                                     "TN.NO_TIPO_NEGOCIACAO," & _
                                     "'N' IC_BOLSA," & _
                                     "NULL," & _
                                     "'S' IC_TIPO_PRECO_FIXO," & _
                                     "'N' IC_DOLAR," & _
                                     "0 SQ_CONTRATO_FIXO," & _
                                     "'N' TP_CTR," & _
                                     "0 VL_NEGOCIACAO_BOLSA," & _
                                     "N.VL_PREMIO_UNITARIO," & _
                                     "F.IC_FISICA_JURIDICA," & _
                                     "TC.CD_TIPO_CACAU," & _
                                     "TC.NO_TIPO_CACAU" & _
                              " FROM SOF.FORNECEDOR F," & _
                                    "SOF.FILIAL FIL," & _
                                    "SOF.TIPO_PESSOA TP," & _
                                    "SOF.CONTRATO_PAF CP," & _
                                    "SOF.NEGOCIACAO N," & _
                                    "SOF.NEGOCIACAO_CANCELADO NC," & _
                                    "SOF.TIPO_NEGOCIACAO TN," & _
                                    "SOF.TIPO_UNIDADE TU," & _
                                    "SOF.MUNICIPIO MUNIC," & _
                                    "SOF.TIPO_CACAU TC" & _
                              " WHERE CP.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                                " AND F.CD_FILIAL_ORIGEM = FIL.CD_FILIAL " & _
                                " AND F.CD_TIPO_PESSOA = TP.CD_TIPO_PESSOA " & _
                                " AND CP.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF " & _
                                " AND N.CD_TIPO_NEGOCIACAO = TN.CD_TIPO_NEGOCIACAO  " & _
                                " AND N.CD_TIPO_UNIDADE = TU.CD_TIPO_UNIDADE " & _
                                " AND N.CD_CONTRATO_PAF = NC.CD_CONTRATO_PAF " & _
                                " AND N.SQ_NEGOCIACAO = NC.SQ_NEGOCIACAO " & _
                                " AND F.CD_MUNICIPIO = MUNIC.CD_MUNICIPIO " & _
                                " AND TC.CD_TIPO_CACAU (+) = N.CD_TIPO_CACAU" & _
                                " AND NC.DT_CANCELAMENTO BETWEEN " & QuotedStr(Date_to_Oracle(txtDataInicial.Text)) & _
                                                           " AND " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))

                    'FILTRA FILIAL
                    If SelecaoFilial.Lista_Quantidade > 0 Then
                        If chkFilialEntregaCtr.Checked Then
                            SqlText = SqlText & " AND CP.CD_FILIAL_ENTREGA IN (" & SelecaoFilial.Lista_ID & ")"
                        Else
                            SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & SelecaoFilial.Lista_ID & ")"
                        End If
                    Else
                        SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
                    End If
                    If SelecaoTipoCacau.Lista_Quantidade > 0 Then
                        SqlText = SqlText & " AND TC.CD_TIPO_CACAU IN (" & SelecaoTipoCacau.Lista_ID & ")"
                    End If
                    If SelecaoTipoPessoa.Lista_Quantidade > 0 Then
                        SqlText = SqlText & " AND TP.CD_TIPO_PESSOA IN (" & SelecaoTipoPessoa.Lista_ID & ")"
                    End If
                    If SelecaoUF.Lista_Quantidade > 0 Then
                        SqlText = SqlText & " AND MUNIC.CD_UF IN (" & SelecaoUF.Lista_ID & ")"
                    End If

                    Select Case cboOpcoes.SelectedValue
                        Case "SEM_IMPORT"
                            SqlText = SqlText & " AND MUNIC.CD_UF <> 'EX'"
                        Case "SOMENTE_IMPORT"
                            SqlText = SqlText & " AND MUNIC.CD_UF = 'EX'"
                    End Select
                End If

                oData = DBQuery(SqlText)

                oRelatorio.Load(Application.StartupPath & "\RPT_Diferencial_Preco_Base.rpt")
                oRelatorio.SetDataSource(oData)

                oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
                crvMain.ReportSource = oRelatorio
        End Select

        AVI_Fechar(Me)
    End Sub

    Private Sub optRelatorio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optRelatorio.ValueChanged
        Configura_Relatorio()
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Imprimir()
        crvMain.Focus()
    End Sub

    Private Sub frmREL_Diferencial_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub
End Class