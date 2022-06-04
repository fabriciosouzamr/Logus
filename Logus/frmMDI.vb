Imports System.Windows.Forms
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinToolbars

Public Class frmMDI
    Const cnt_GridBolsa_TipoPessoa As Integer = 0
    Const cnt_GridBolsa_PostoFabrica_Kilos As Integer = 1
    Const cnt_GridBolsa_PostoFilial_Kilos As Integer = 2
    Const cnt_GridBolsa_PostoFazenda_Kilos As Integer = 3
    Const cnt_GridBolsa_PostoFabrica_Arroba As Integer = 4
    Const cnt_GridBolsa_PostoFilial_Arroba As Integer = 5
    Const cnt_GridBolsa_PostoFazenda_Arroba As Integer = 6
    Const cnt_GridBolsa_PostoFabrica_Sacos As Integer = 7
    Const cnt_GridBolsa_PostoFilial_Sacos As Integer = 8
    Const cnt_GridBolsa_PostoFazenda_Sacos As Integer = 9
    Const cnt_GridBolsa_TipoPessoaPercentual As Integer = 10

    Const cnt_DockPanel_Atalho As Integer = 0
    Const cnt_DockPanel_ValorCotacaoBolsa As Integer = 1
    Const cnt_DockPanel_Recente As Integer = 2
    Const cnt_DockPanel_CalculoDiferencial As Integer = 3

    Dim oDS As New UltraWinDataSource.UltraDataSource
    Dim oDSCalculo As New UltraWinDataSource.UltraDataSource
    Dim GridMontado As Boolean = False
    Dim WithEvents oFormGrafico As frmChart_Propriedade
    Dim bProcInterno As Boolean = False
    Dim TxICMS As Double
    Dim TxICMS_Fabrica As Double
    Dim VlDolar_Bolsa As Double

    Private Sub mnuSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSair.Click
        Close()
    End Sub

    Public Sub Inicializar()
        tmrBolsa.Enabled = True
    End Sub

    Private Sub frmMDI_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        Try
            SetWorkingMemory(System.IntPtr.op_Explicit(CInt(750000)), System.IntPtr.op_Explicit(CInt(300000)))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmMDI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        UDM.ControlPanes(cnt_DockPanel_Atalho).Close()
        UDM.ControlPanes(cnt_DockPanel_Recente).Close()
        mnuVisualizar_Atalho.Visible = False
        mnuVisualizar_Recente.Visible = False

        Rodape_Inicializar()
        Libera_Filial()
        ' Cria_Icones() 'Ainda não Implementado
        Menu_ValidarAcesso()

        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)
        objGrid_Coluna_Add(grdGeral, "Tipo Pessoa", 85)
        objGrid_Coluna_Add(grdGeral, "Posto Fabrica", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Posto Filial", 90, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Posto Fazenda", 110, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Posto Fabrica", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Posto Filial", 90, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Posto Fazenda", 110, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Posto Fabrica", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Posto Filial", 90, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Posto Fazenda", 110, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Percentual", 0)

        objGrid_Inicializar(grdCalculo, , oDSCalculo, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)
        objGrid_Coluna_Add(grdCalculo, "Tipo Pessoa", 85)
        objGrid_Coluna_Add(grdCalculo, "Posto Fabrica", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCalculo, "Posto Filial", 90, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCalculo, "Posto Fazenda", 110, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCalculo, "Posto Fabrica", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCalculo, "Posto Filial", 90, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCalculo, "Posto Fazenda", 110, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCalculo, "Posto Fabrica", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCalculo, "Posto Filial", 90, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCalculo, "Posto Fazenda", 110, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCalculo, "Percentual", 0)

        oImagemList = imgIcone
        Infragistics.Win.AppStyling.StyleManager.Load(Application.StartupPath & "\LucidDream.isl")

        CarregaGridBolsa()
        GridMontado = True
        optUnidadeMedida_ValueChanged(Nothing, Nothing)
        ComboBox_Carregar_Filial(cboFilialEntrega, False)
        ComboBox_Carregar_Filial(cboFilialEntregaCalculo, False)
        ComboBox_Carregar_Bolsa(cboBolsa)
        cboFilialLogada.ComboBox.DropDownStyle = ComboBoxStyle.DropDownList

        bProcInterno = True
        ComboBox_Carregar_Filial(cboFilialLogada.ComboBox, False, False, , True)
        bProcInterno = False

        ComboBox_Possicionar(cboFilialLogada.ComboBox, FilialLogada)
        ComboBox_Possicionar(cboFilialEntrega, FilialLogada)
        ComboBox_Possicionar(cboFilialEntregaCalculo, FilialLogada)

        Rodape_Formatar()
    End Sub

    Sub Cria_Icones()
        Dim BarIcones As UltraToolbar = Me.tlbIcones.Toolbars(0)

        Dim bt1 As ButtonTool = New ButtonTool("Fornecedor")
        bt1.SharedProps.Caption = "Fornecedor"
        bt1.SharedProps.AppearancesSmall.Appearance.Image = cnt_ImagemIcone_Fornecedor
        bt1.SharedProps.AppearancesLarge.Appearance.Image = cnt_ImagemIcone_Fornecedor
        Me.tlbIcones.Tools.Add(bt1)

        Dim bt2 As ButtonTool = New ButtonTool("Bolsa")
        bt2.SharedProps.Caption = "Bolsa"
        bt2.SharedProps.AppearancesSmall.Appearance.Image = cnt_ImagemIcone_Bolsa
        bt2.SharedProps.AppearancesLarge.Appearance.Image = cnt_ImagemIcone_Bolsa
        Me.tlbIcones.Tools.Add(bt2)

        Dim bt3 As ButtonTool = New ButtonTool("Conciliacao")
        bt3.SharedProps.Caption = "Conciliação"
        bt3.SharedProps.AppearancesSmall.Appearance.Image = cnt_ImagemIcone_Conciliacao
        bt3.SharedProps.AppearancesLarge.Appearance.Image = cnt_ImagemIcone_Conciliacao
        Me.tlbIcones.Tools.Add(bt3)

        Dim bt4 As ButtonTool = New ButtonTool("Contatos")
        bt4.SharedProps.Caption = "Contatos"
        bt4.SharedProps.AppearancesSmall.Appearance.Image = cnt_ImagemIcone_Contatos
        bt4.SharedProps.AppearancesLarge.Appearance.Image = cnt_ImagemIcone_Contatos
        Me.tlbIcones.Tools.Add(bt4)

        Dim bt5 As ButtonTool = New ButtonTool("Contratos")
        bt5.SharedProps.Caption = "Contratos"
        bt5.SharedProps.AppearancesSmall.Appearance.Image = cnt_ImagemIcone_Contrato
        bt5.SharedProps.AppearancesLarge.Appearance.Image = cnt_ImagemIcone_Contrato
        Me.tlbIcones.Tools.Add(bt5)

        Dim bt6 As ButtonTool = New ButtonTool("Frete")
        bt6.SharedProps.Caption = "Frete"
        bt6.SharedProps.AppearancesSmall.Appearance.Image = cnt_ImagemIcone_Frete
        bt6.SharedProps.AppearancesLarge.Appearance.Image = cnt_ImagemIcone_Frete
        Me.tlbIcones.Tools.Add(bt6)

        Dim bt7 As ButtonTool = New ButtonTool("Garantia")
        bt7.SharedProps.Caption = "Garantia"
        bt7.SharedProps.AppearancesSmall.Appearance.Image = cnt_ImagemIcone_Garantia
        bt7.SharedProps.AppearancesLarge.Appearance.Image = cnt_ImagemIcone_Garantia
        Me.tlbIcones.Tools.Add(bt7)

        Dim bt8 As ButtonTool = New ButtonTool("Inovacao")
        bt8.SharedProps.Caption = "Inovação"
        bt8.SharedProps.AppearancesSmall.Appearance.Image = cnt_ImagemIcone_Inovacao
        bt8.SharedProps.AppearancesLarge.Appearance.Image = cnt_ImagemIcone_Inovacao
        Me.tlbIcones.Tools.Add(bt8)

        Dim bt9 As ButtonTool = New ButtonTool("Jornal")
        bt9.SharedProps.Caption = "Jornal"
        bt9.SharedProps.AppearancesSmall.Appearance.Image = cnt_ImagemIcone_Jornal
        bt9.SharedProps.AppearancesLarge.Appearance.Image = cnt_ImagemIcone_Jornal
        Me.tlbIcones.Tools.Add(bt9)

        Dim bt10 As ButtonTool = New ButtonTool("Movimentação Bancaria")
        bt10.SharedProps.Caption = "Movimentação Bancaria"
        bt10.SharedProps.AppearancesSmall.Appearance.Image = cnt_ImagemIcone_MovimentacaoBancaria
        bt10.SharedProps.AppearancesLarge.Appearance.Image = cnt_ImagemIcone_MovimentacaoBancaria
        Me.tlbIcones.Tools.Add(bt10)

        Dim bt11 As ButtonTool = New ButtonTool("Movimentação Cacau")
        bt11.SharedProps.Caption = "Movimentação Cacau"
        bt11.SharedProps.AppearancesSmall.Appearance.Image = cnt_ImagemIcone_MovimentacaoCacau
        bt11.SharedProps.AppearancesLarge.Appearance.Image = cnt_ImagemIcone_MovimentacaoCacau
        Me.tlbIcones.Tools.Add(bt11)

        Dim bt12 As ButtonTool = New ButtonTool("Pagamento")
        bt12.SharedProps.Caption = "Pagamento"
        bt12.SharedProps.AppearancesSmall.Appearance.Image = cnt_ImagemIcone_Pagamento
        bt12.SharedProps.AppearancesLarge.Appearance.Image = cnt_ImagemIcone_Pagamento
        Me.tlbIcones.Tools.Add(bt12)

        Dim bt13 As ButtonTool = New ButtonTool("Recuperação Crédito")
        bt13.SharedProps.Caption = "Recuperação Crédito"
        bt13.SharedProps.AppearancesSmall.Appearance.Image = cnt_ImagemIcone_RecuperacaoCredito
        bt13.SharedProps.AppearancesLarge.Appearance.Image = cnt_ImagemIcone_RecuperacaoCredito
        Me.tlbIcones.Tools.Add(bt13)

        Dim bt14 As ButtonTool = New ButtonTool("RD")
        bt14.SharedProps.Caption = "RD"
        bt14.SharedProps.AppearancesSmall.Appearance.Image = cnt_ImagemIcone_RD
        bt14.SharedProps.AppearancesLarge.Appearance.Image = cnt_ImagemIcone_RD
        Me.tlbIcones.Tools.Add(bt14)

        Dim bt15 As ButtonTool = New ButtonTool("Sacaria")
        bt15.SharedProps.Caption = "Sacaria"
        bt15.SharedProps.AppearancesSmall.Appearance.Image = cnt_ImagemIcone_Sacaria
        bt15.SharedProps.AppearancesLarge.Appearance.Image = cnt_ImagemIcone_Sacaria
        Me.tlbIcones.Tools.Add(bt15)

        Dim bt16 As ButtonTool = New ButtonTool("Solicitação Crédito")
        bt16.SharedProps.Caption = "Solicitação Crédito"
        bt16.SharedProps.AppearancesSmall.Appearance.Image = cnt_ImagemIcone_SolicitacaoCredito
        bt16.SharedProps.AppearancesLarge.Appearance.Image = cnt_ImagemIcone_SolicitacaoCredito
        Me.tlbIcones.Tools.Add(bt16)

        BarIcones.Tools.Add(bt1)
        BarIcones.Tools.Add(bt2)
        BarIcones.Tools.Add(bt3)
        BarIcones.Tools.Add(bt4)
        BarIcones.Tools.Add(bt5)
        BarIcones.Tools.Add(bt6)
        BarIcones.Tools.Add(bt7)
        BarIcones.Tools.Add(bt8)
        BarIcones.Tools.Add(bt9)
        BarIcones.Tools.Add(bt10)
        BarIcones.Tools.Add(bt11)
        BarIcones.Tools.Add(bt12)
        BarIcones.Tools.Add(bt13)
        BarIcones.Tools.Add(bt14)
        BarIcones.Tools.Add(bt15)
        BarIcones.Tools.Add(bt16)
    End Sub

    Private Sub AtualizaPrecoBolsa()
        Dim SqlText As String
        Dim oData As DataTable
        Dim VlCotacao As Double
        Dim VlICMS As Double
        Dim EstadoFilMae As String
        Dim EstadoFilLog As String

        'Pego Valor do ICMS
        SqlText = "SELECT UF.PC_ALIQ_ICMS/100 " & _
                  " FROM SOF.FILIAL F," & _
                        "SOF.MUNICIPIO M," & _
                        "SOF.UF" & _
                  " WHERE F.CD_MUNICIPIO = M.CD_MUNICIPIO" & _
                   " AND M.CD_UF =UF.CD_UF AND F.CD_FILIAL = " & FilialLogada
        TxICMS = DBQuery_ValorUnico(SqlText, 0)

        'Pego o estado filial mãe
        SqlText = "SELECT UF.CD_UF " & _
                  " FROM SOF.FILIAL F," & _
                        "SOF.MUNICIPIO M," & _
                        "SOF.UF, sof.parametro p " & _
                  " WHERE F.CD_MUNICIPIO = M.CD_MUNICIPIO" & _
                   " AND M.CD_UF =UF.CD_UF AND F.CD_FILIAL = p.CD_FILIAL_MAE "
        EstadoFilMae = DBQuery_ValorUnico(SqlText, 0)

        'Pego o estado filial logada
        SqlText = "SELECT UF.CD_UF " & _
                  " FROM SOF.FILIAL F," & _
                        "SOF.MUNICIPIO M," & _
                        "SOF.UF, sof.parametro p " & _
                  " WHERE F.CD_MUNICIPIO = M.CD_MUNICIPIO" & _
                   " AND M.CD_UF =UF.CD_UF AND F.CD_FILIAL =  " & FilialLogada
        EstadoFilLog = DBQuery_ValorUnico(SqlText, 0)

        'Pega cotação do dolar
        SqlText = "SELECT B.VL_COTACAO," & _
                         "B.IC_BOLSA_SEM_SINAL," & _
                         "B.IC_ALTERNATIVO," & _
                         "B.VL_COTACAO_ALTERNATIVO," & _
                         "NVL(A.VL_JUROS_DIA,0) VL_JUROS_DIA" & _
                  " FROM SOF.BOLSA_PARAMETRO A," & _
                        "SOF.BOLSA_PERIODO B " & _
                  " WHERE A.CD_PAPEL_DOLAR = B.CD_PAPEL"
        oData = DBQuery(SqlText)

        If oData.Rows(0).Item("IC_BOLSA_SEM_SINAL") = "S" Or oData.Rows(0).Item("IC_ALTERNATIVO") = "S" Then
            If CampoNulo(oData.Rows(0).Item("VL_COTACAO_ALTERNATIVO")) Then
                VlDolar_Bolsa = 0
            Else
                VlDolar_Bolsa = oData.Rows(0).Item("VL_COTACAO_ALTERNATIVO")
            End If
        Else
            If CampoNulo(oData.Rows(0).Item("VL_COTACAO")) Then
                VlDolar_Bolsa = 0
            Else
                VlDolar_Bolsa = oData.Rows(0).Item("VL_COTACAO")
            End If
        End If

        If CampoNulo(oData.Rows(0).Item("VL_COTACAO")) Then
            txtDolar.Value = 0
            txtDolarCalculo.Value = 0
        Else
            txtDolar.Value = oData.Rows(0).Item("VL_COTACAO")
            txtDolarCalculo.Value = oData.Rows(0).Item("VL_COTACAO")
        End If

        'Pego nome e o papel atual
        SqlText = "SELECT CD_PAPEL, NO_PAPEL" & _
                  " FROM SOF.BOLSA_PERIODO B" & _
                  " WHERE IC_MOEDA = 'N' AND IC_EXIBE = 'S'" & _
                    " AND B.CD_PAPEL = " & QuotedStr(cboBolsa.SelectedValue) & _
                  " ORDER BY NU_SEQUENCIA ASC "
        oData = DBQuery(SqlText)

        If objDataTable_Vazio(oData) Then Exit Sub

        UDM.DockAreas(1).Panes(0).DockAreaPane.Text = "Valores de Cotação da Bolsa - " & oData.Rows(0).Item("CD_PAPEL")

        'UDM.DockAreas(1).DockAreaPane.
        SqlText = "SELECT DECODE(IC_BOLSA_SEM_SINAL, 'S', VL_COTACAO_ALTERNATIVO," & _
                                                    "DECODE(IC_ALTERNATIVO, 'S', VL_COTACAO_ALTERNATIVO, VL_COTACAO)) VL_COTACAO," & _
                         "IC_BOLSA_SEM_SINAL," & _
                         "IC_ALTERNATIVO," & _
                         "VL_COTACAO_ALTERNATIVO," & _
                         "VL_DIFERENCIAL, VL_DIFERENCA" & _
                  " FROM SOF.BOLSA_PERIODO " & _
                  " WHERE IC_MOEDA ='N'" & _
                    " AND CD_PAPEL = " & QuotedStr(oData.Rows(0).Item("CD_PAPEL"))
        oData = DBQuery(SqlText)

        If oData.Rows(0).Item("IC_BOLSA_SEM_SINAL") = "S" Or oData.Rows(0).Item("IC_ALTERNATIVO") = "S" Then
            If CampoNulo(oData.Rows(0).Item("VL_COTACAO_ALTERNATIVO")) Then
                VlCotacao = 0
            Else
                VlCotacao = oData.Rows(0).Item("VL_COTACAO_ALTERNATIVO") + NVL(oData.Rows(0).Item("VL_DIFERENCIAL"), 0)
            End If
        Else
            If CampoNulo(oData.Rows(0).Item("VL_COTACAO")) Then
                VlCotacao = 0
            Else
                VlCotacao = oData.Rows(0).Item("VL_COTACAO") + NVL(oData.Rows(0).Item("VL_DIFERENCIAL"), 0)
            End If
        End If

        If CampoNulo(oData.Rows(0).Item("VL_COTACAO")) Then
            txtCotacao.Value = 0
            txtCotacaoCalculo.Value = 0
        Else
            txtCotacao.Value = oData.Rows(0).Item("VL_COTACAO")
            txtCotacaoCalculo.Value = oData.Rows(0).Item("VL_COTACAO")
        End If

        txtDiferenca.Text = CStr(NVL(oData.Rows(0).Item("VL_DIFERENCA"), ""))
        txtDiferencaCalculo.Text = CStr(NVL(oData.Rows(0).Item("VL_DIFERENCA"), ""))

        If Mid(txtDiferenca.Text, 1, 1) = "-" Then
            txtDiferenca.ForeColor = Color.Red
            txtDiferencaCalculo.ForeColor = Color.Red
        Else
            txtDiferenca.ForeColor = Color.Green
            txtDiferencaCalculo.ForeColor = Color.Green
        End If

        Dim iCont As Integer
        Dim iCont2 As Integer

        For iCont = 0 To grdGeral.Rows.Count - 1
            If VlCotacao = 0 Or VlDolar_Bolsa = 0 Then
                With grdGeral.Rows(iCont)
                    .Cells(cnt_GridBolsa_PostoFabrica_Kilos).Value = 0
                    .Cells(cnt_GridBolsa_PostoFabrica_Arroba).Value = 0
                    .Cells(cnt_GridBolsa_PostoFabrica_Sacos).Value = 0

                    .Cells(cnt_GridBolsa_PostoFilial_Kilos).Value = 0
                    .Cells(cnt_GridBolsa_PostoFilial_Arroba).Value = 0
                    .Cells(cnt_GridBolsa_PostoFilial_Sacos).Value = 0

                    .Cells(cnt_GridBolsa_PostoFazenda_Kilos).Value = 0
                    .Cells(cnt_GridBolsa_PostoFazenda_Arroba).Value = 0
                    .Cells(cnt_GridBolsa_PostoFazenda_Sacos).Value = 0
                End With
            Else
                With grdGeral.Rows(iCont)
                    .Cells(cnt_GridBolsa_PostoFabrica_Kilos).Value = (((VlCotacao * VlDolar_Bolsa) / 1000) - (txtFreteFabrica.Value / 60))
                    .Cells(cnt_GridBolsa_PostoFabrica_Arroba).Value = ((((VlCotacao * VlDolar_Bolsa) / 1000) * 15) - (txtFreteFabrica.Value / 4))
                    .Cells(cnt_GridBolsa_PostoFabrica_Sacos).Value = ((((VlCotacao * VlDolar_Bolsa) / 1000) * 60) - (txtFreteFabrica.Value))

                    .Cells(cnt_GridBolsa_PostoFilial_Kilos).Value = (((VlCotacao * VlDolar_Bolsa) / 1000) - (txtFreteFilial.Value / 60))
                    .Cells(cnt_GridBolsa_PostoFilial_Arroba).Value = ((((VlCotacao * VlDolar_Bolsa) / 1000) * 15) - (txtFreteFilial.Value / 4))
                    .Cells(cnt_GridBolsa_PostoFilial_Sacos).Value = ((((VlCotacao * VlDolar_Bolsa) / 1000) * 60) - (txtFreteFilial.Value))

                    .Cells(cnt_GridBolsa_PostoFazenda_Kilos).Value = (((VlCotacao * VlDolar_Bolsa) / 1000) - ((txtFreteFazenda.Value + txtFreteFilial.Value) / 60))
                    .Cells(cnt_GridBolsa_PostoFazenda_Arroba).Value = ((((VlCotacao * VlDolar_Bolsa) / 1000) * 15) - ((txtFreteFazenda.Value + txtFreteFilial.Value) / 4))
                    .Cells(cnt_GridBolsa_PostoFazenda_Sacos).Value = ((((VlCotacao * VlDolar_Bolsa) / 1000) * 60) - ((txtFreteFazenda.Value + txtFreteFilial.Value)))

                    'Isso é preciso para calcular o valor do funrural sobre o icms, pois nesse
                    'pais o imposto é em cima de imposto e timanhos diferença no relatorio do diferencial
                    For iCont2 = 1 To 9
                        Select Case iCont2
                            Case cnt_GridBolsa_PostoFabrica_Kilos, cnt_GridBolsa_PostoFabrica_Arroba, cnt_GridBolsa_PostoFabrica_Sacos
                                If EstadoFilLog = EstadoFilMae Then
                                    VlICMS = 0
                                Else
                                    VlICMS = .Cells(iCont2).Value * TxICMS
                                End If

                                VlICMS = .Cells(iCont2).Value * TxICMS
                                .Cells(iCont2).Value = ((.Cells(iCont2).Value + VlICMS) * (.Cells(cnt_GridBolsa_TipoPessoaPercentual).Value / 100)) - VlICMS
                            Case Else
                                If EstadoFilLog = EstadoFilMae Then
                                    VlICMS = 0
                                Else
                                    VlICMS = .Cells(iCont2).Value * TxICMS
                                End If

                                .Cells(iCont2).Value = ((.Cells(iCont2).Value + VlICMS) * (.Cells(cnt_GridBolsa_TipoPessoaPercentual).Value / 100)) - VlICMS
                        End Select

                    Next
                End With
            End If
            grdGeral.Rows(iCont).Update()
        Next

        grdGeral.DisplayLayout.Bands(0).Columns(2).Format = cnt_Formato_Valor
    End Sub

    Private Sub AtualizacaoCalculoDiferencial()
        Dim VlCotacao As Double
        Dim VlICMS As Double
        Dim Vlfunrural As Double
        Dim TxFunrural As Double

        If VlDolar_Bolsa = 0 Then Exit Sub
        If txtCotacaoCalculo.Value = 0 Then Exit Sub

        Dim iCont As Integer
        Dim iCont2 As Integer

        If txtValorAroba.Value = 0 Then
            With grdCalculo.DisplayLayout.Bands(0)
                .Columns(cnt_GridBolsa_PostoFabrica_Kilos).Format = cnt_Formato_Valor
                .Columns(cnt_GridBolsa_PostoFabrica_Arroba).Format = cnt_Formato_Valor
                .Columns(cnt_GridBolsa_PostoFabrica_Sacos).Format = cnt_Formato_Valor
                .Columns(cnt_GridBolsa_PostoFilial_Kilos).Format = cnt_Formato_Valor
                .Columns(cnt_GridBolsa_PostoFilial_Arroba).Format = cnt_Formato_Valor
                .Columns(cnt_GridBolsa_PostoFilial_Sacos).Format = cnt_Formato_Valor
                .Columns(cnt_GridBolsa_PostoFazenda_Kilos).Format = cnt_Formato_Valor
                .Columns(cnt_GridBolsa_PostoFazenda_Arroba).Format = cnt_Formato_Valor
                .Columns(cnt_GridBolsa_PostoFazenda_Sacos).Format = cnt_Formato_Valor
            End With
        Else
            With grdCalculo.DisplayLayout.Bands(0)
                .Columns(cnt_GridBolsa_PostoFabrica_Kilos).Format = cnt_Formato_Valor_US
                .Columns(cnt_GridBolsa_PostoFabrica_Arroba).Format = cnt_Formato_Valor_US
                .Columns(cnt_GridBolsa_PostoFabrica_Sacos).Format = cnt_Formato_Valor_US
                .Columns(cnt_GridBolsa_PostoFilial_Kilos).Format = cnt_Formato_Valor_US
                .Columns(cnt_GridBolsa_PostoFilial_Arroba).Format = cnt_Formato_Valor_US
                .Columns(cnt_GridBolsa_PostoFilial_Sacos).Format = cnt_Formato_Valor_US
                .Columns(cnt_GridBolsa_PostoFazenda_Kilos).Format = cnt_Formato_Valor_US
                .Columns(cnt_GridBolsa_PostoFazenda_Arroba).Format = cnt_Formato_Valor_US
                .Columns(cnt_GridBolsa_PostoFazenda_Sacos).Format = cnt_Formato_Valor_US
            End With
        End If

        For iCont = 0 To grdCalculo.Rows.Count - 1
            If (txtCotacaoCalculo.Value = 0 Or VlDolar_Bolsa = 0) And (txtDiferencial.Value = 0 And txtValorAroba.Value = 0) Then
                With grdCalculo.Rows(iCont)
                    .Cells(cnt_GridBolsa_PostoFabrica_Kilos).Value = 0
                    .Cells(cnt_GridBolsa_PostoFabrica_Arroba).Value = 0
                    .Cells(cnt_GridBolsa_PostoFabrica_Sacos).Value = 0

                    .Cells(cnt_GridBolsa_PostoFilial_Kilos).Value = 0
                    .Cells(cnt_GridBolsa_PostoFilial_Arroba).Value = 0
                    .Cells(cnt_GridBolsa_PostoFilial_Sacos).Value = 0

                    .Cells(cnt_GridBolsa_PostoFazenda_Kilos).Value = 0
                    .Cells(cnt_GridBolsa_PostoFazenda_Arroba).Value = 0
                    .Cells(cnt_GridBolsa_PostoFazenda_Sacos).Value = 0
                End With
            Else
                If txtValorAroba.Value = 0 Then
                    With grdCalculo.Rows(iCont)
                        .Cells(cnt_GridBolsa_PostoFabrica_Kilos).Value = ((((txtCotacaoCalculo.Value + txtDiferencial.Value) * VlDolar_Bolsa) / 1000) - (txtFreteFabrica.Value / 60))
                        .Cells(cnt_GridBolsa_PostoFabrica_Arroba).Value = (((((txtCotacaoCalculo.Value + txtDiferencial.Value) * VlDolar_Bolsa) / 1000) * 15) - (txtFreteFabrica.Value / 4))
                        .Cells(cnt_GridBolsa_PostoFabrica_Sacos).Value = (((((txtCotacaoCalculo.Value + txtDiferencial.Value) * VlDolar_Bolsa) / 1000) * 60) - (txtFreteFabrica.Value))

                        .Cells(cnt_GridBolsa_PostoFilial_Kilos).Value = ((((txtCotacaoCalculo.Value + txtDiferencial.Value) * VlDolar_Bolsa) / 1000) - (txtFreteFilial.Value / 60))
                        .Cells(cnt_GridBolsa_PostoFilial_Arroba).Value = (((((txtCotacaoCalculo.Value + txtDiferencial.Value) * VlDolar_Bolsa) / 1000) * 15) - (txtFreteFilial.Value / 4))
                        .Cells(cnt_GridBolsa_PostoFilial_Sacos).Value = (((((txtCotacaoCalculo.Value + txtDiferencial.Value) * VlDolar_Bolsa) / 1000) * 60) - (txtFreteFilial.Value))

                        .Cells(cnt_GridBolsa_PostoFazenda_Kilos).Value = ((((txtCotacaoCalculo.Value + txtDiferencial.Value) * VlDolar_Bolsa) / 1000) - ((txtFreteFazenda.Value + txtFreteFilial.Value) / 60))
                        .Cells(cnt_GridBolsa_PostoFazenda_Arroba).Value = (((((txtCotacaoCalculo.Value + txtDiferencial.Value) * VlDolar_Bolsa) / 1000) * 15) - ((txtFreteFazenda.Value + txtFreteFilial.Value) / 4))
                        .Cells(cnt_GridBolsa_PostoFazenda_Sacos).Value = (((((txtCotacaoCalculo.Value + txtDiferencial.Value) * VlDolar_Bolsa) / 1000) * 60) - ((txtFreteFazenda.Value + txtFreteFilial.Value)))

                        'Isso é preciso para calcular o valor do funrural sobre o icms, pois nesse
                        'pais o imposto é em cima de imposto e timanhos diferença no relatorio do diferencial
                        For iCont2 = 1 To 6
                            VlICMS = .Cells(iCont2).Value * TxICMS
                            .Cells(iCont2).Value = ((.Cells(iCont2).Value + VlICMS) * (.Cells(cnt_GridBolsa_TipoPessoaPercentual).Value / 100)) - VlICMS
                        Next
                    End With
                Else
                    With grdCalculo.Rows(iCont)
                        If FilialLogada = cboFilialEntrega.SelectedValue Then
                            TxICMS = 0
                        End If
                        TxFunrural = (100 - .Cells(cnt_GridBolsa_TipoPessoaPercentual).Value)
                        VlCotacao = txtValorAroba.Value
                        Vlfunrural = ((((VlCotacao - (txtFreteFabrica.Value / 60)) / ((100 - ((TxICMS * 100) + TxFunrural)) / 100)) * (TxFunrural / 100)))

                        .Cells(cnt_GridBolsa_PostoFabrica_Kilos).Value = (((((VlCotacao + Vlfunrural) + (txtFreteFabrica.Value / 4)) / 15) * 1000) / VlDolar_Bolsa) - txtCotacaoCalculo.Value
                        .Cells(cnt_GridBolsa_PostoFabrica_Arroba).Value = (((((VlCotacao + Vlfunrural) + (txtFreteFabrica.Value / 4)) / 15) * 1000) / VlDolar_Bolsa) - txtCotacaoCalculo.Value
                        .Cells(cnt_GridBolsa_PostoFabrica_Sacos).Value = (((((VlCotacao + Vlfunrural) + (txtFreteFabrica.Value / 4)) / 15) * 1000) / VlDolar_Bolsa) - txtCotacaoCalculo.Value

                        Vlfunrural = ((((VlCotacao - (txtFreteFilial.Value / 60)) / ((100 - ((TxICMS * 100) + TxFunrural)) / 100)) * (TxFunrural / 100)))

                        .Cells(cnt_GridBolsa_PostoFilial_Kilos).Value = (((((VlCotacao + Vlfunrural) + (txtFreteFilial.Value / 4)) / 15) * 1000) / VlDolar_Bolsa) - txtCotacaoCalculo.Value
                        .Cells(cnt_GridBolsa_PostoFilial_Arroba).Value = (((((VlCotacao + Vlfunrural) + (txtFreteFilial.Value / 4)) / 15) * 1000) / VlDolar_Bolsa) - txtCotacaoCalculo.Value
                        .Cells(cnt_GridBolsa_PostoFilial_Sacos).Value = (((((VlCotacao + Vlfunrural) + (txtFreteFilial.Value / 4)) / 15) * 1000) / VlDolar_Bolsa) - txtCotacaoCalculo.Value

                        Vlfunrural = ((((VlCotacao - (txtFreteFazenda.Value / 60)) / ((100 - ((TxICMS * 100) + TxFunrural)) / 100)) * (TxFunrural / 100)))

                        .Cells(cnt_GridBolsa_PostoFazenda_Kilos).Value = (((((VlCotacao + Vlfunrural) + ((txtFreteFazenda.Value + txtFreteFilial.Value) / 4)) / 15) * 1000) / VlDolar_Bolsa) - txtCotacaoCalculo.Value
                        .Cells(cnt_GridBolsa_PostoFazenda_Arroba).Value = (((((VlCotacao + Vlfunrural) + ((txtFreteFazenda.Value + txtFreteFilial.Value) / 4)) / 15) * 1000) / VlDolar_Bolsa) - txtCotacaoCalculo.Value
                        .Cells(cnt_GridBolsa_PostoFazenda_Sacos).Value = (((((VlCotacao + Vlfunrural) + ((txtFreteFazenda.Value + txtFreteFilial.Value) / 4)) / 15) * 1000) / VlDolar_Bolsa) - txtCotacaoCalculo.Value
                    End With
                End If
            End If
            grdCalculo.Rows(iCont).Update()
        Next

        grdGeral.DisplayLayout.Bands(0).Columns(2).Format = cnt_Formato_Valor
    End Sub

    Private Sub cmdAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAtualizar.Click
        AtualizaPrecoBolsa()
    End Sub

    Private Sub cboFilialEntrega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFilialEntrega.SelectedIndexChanged
        If bProcInterno Then Exit Sub

        Dim SqlText As String
        Dim oData As DataTable

        If Not ComboBox_LinhaSelecionada(cboFilialEntrega) Then
            Exit Sub
        End If

        bProcInterno = True

        SqlText = "SELECT VL_FRETE_FILIAL_FAZENDA," & _
                         "VL_FRETE_FILIAL_FABRICA," & _
                         "VL_FRETE_FABRICA" & _
                  " FROM SOF.FILIAL F" & _
                  " WHERE F.CD_FILIAL = " & cboFilialEntrega.SelectedValue
        oData = DBQuery(SqlText)

        txtFreteFabrica.Value = oData.Rows(0).Item("VL_FRETE_FABRICA")
        txtFreteFilial.Value = oData.Rows(0).Item("VL_FRETE_FILIAL_FABRICA")
        txtFreteFazenda.Value = oData.Rows(0).Item("VL_FRETE_FILIAL_FAZENDA")
        ComboBox_Possicionar(cboFilialEntregaCalculo, cboFilialEntrega.SelectedValue)
        AtualizaPrecoBolsa()
        bProcInterno = False
    End Sub

    Private Sub optUnidadeMedida_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optUnidadeMedida.ValueChanged
        If GridMontado = True Then
            grdGeral.DisplayLayout.Bands(0).Columns(cnt_GridBolsa_PostoFabrica_Kilos).Hidden = (Not optUnidadeMedida.Value = "Q")
            grdGeral.DisplayLayout.Bands(0).Columns(cnt_GridBolsa_PostoFilial_Kilos).Hidden = (Not optUnidadeMedida.Value = "Q")
            grdGeral.DisplayLayout.Bands(0).Columns(cnt_GridBolsa_PostoFazenda_Kilos).Hidden = (Not optUnidadeMedida.Value = "Q")
            grdGeral.DisplayLayout.Bands(0).Columns(cnt_GridBolsa_PostoFabrica_Arroba).Hidden = (Not optUnidadeMedida.Value = "A")
            grdGeral.DisplayLayout.Bands(0).Columns(cnt_GridBolsa_PostoFilial_Arroba).Hidden = (Not optUnidadeMedida.Value = "A")
            grdGeral.DisplayLayout.Bands(0).Columns(cnt_GridBolsa_PostoFazenda_Arroba).Hidden = (Not optUnidadeMedida.Value = "A")
            grdGeral.DisplayLayout.Bands(0).Columns(cnt_GridBolsa_PostoFabrica_Sacos).Hidden = (Not optUnidadeMedida.Value = "S")
            grdGeral.DisplayLayout.Bands(0).Columns(cnt_GridBolsa_PostoFilial_Sacos).Hidden = (Not optUnidadeMedida.Value = "S")
            grdGeral.DisplayLayout.Bands(0).Columns(cnt_GridBolsa_PostoFazenda_Sacos).Hidden = (Not optUnidadeMedida.Value = "S")

            grdCalculo.DisplayLayout.Bands(0).Columns(cnt_GridBolsa_PostoFabrica_Kilos).Hidden = (Not optUnidadeMedida.Value = "Q")
            grdCalculo.DisplayLayout.Bands(0).Columns(cnt_GridBolsa_PostoFilial_Kilos).Hidden = (Not optUnidadeMedida.Value = "Q")
            grdCalculo.DisplayLayout.Bands(0).Columns(cnt_GridBolsa_PostoFazenda_Kilos).Hidden = (Not optUnidadeMedida.Value = "Q")
            grdCalculo.DisplayLayout.Bands(0).Columns(cnt_GridBolsa_PostoFabrica_Arroba).Hidden = (Not optUnidadeMedida.Value = "A")
            grdCalculo.DisplayLayout.Bands(0).Columns(cnt_GridBolsa_PostoFilial_Arroba).Hidden = (Not optUnidadeMedida.Value = "A")
            grdCalculo.DisplayLayout.Bands(0).Columns(cnt_GridBolsa_PostoFazenda_Arroba).Hidden = (Not optUnidadeMedida.Value = "A")
            grdCalculo.DisplayLayout.Bands(0).Columns(cnt_GridBolsa_PostoFabrica_Sacos).Hidden = (Not optUnidadeMedida.Value = "S")
            grdCalculo.DisplayLayout.Bands(0).Columns(cnt_GridBolsa_PostoFilial_Sacos).Hidden = (Not optUnidadeMedida.Value = "S")
            grdCalculo.DisplayLayout.Bands(0).Columns(cnt_GridBolsa_PostoFazenda_Sacos).Hidden = (Not optUnidadeMedida.Value = "S")
        End If
    End Sub

    Private Sub CarregaGridBolsa()
        Dim SqlText As String

        SqlText = "SELECT NO_TIPO_PESSOA, NULL, NULL, NULL, NULL, NULL, NULL,NULL, NULL, NULL, VL_PERCENTUAL_PRECO_BOLSA" & _
                  " FROM SOF.TIPO_PESSOA " & _
                  " WHERE IC_MOSTRA_PRECO_BOLSA = 'S'"

        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridBolsa_TipoPessoa, _
                                                           cnt_GridBolsa_PostoFabrica_Kilos, _
                                                           cnt_GridBolsa_PostoFilial_Kilos, _
                                                           cnt_GridBolsa_PostoFazenda_Kilos, _
                                                           cnt_GridBolsa_PostoFabrica_Arroba, _
                                                           cnt_GridBolsa_PostoFilial_Arroba, _
                                                           cnt_GridBolsa_PostoFazenda_Arroba, _
                                                           cnt_GridBolsa_PostoFabrica_Sacos, _
                                                           cnt_GridBolsa_PostoFilial_Sacos, _
                                                           cnt_GridBolsa_PostoFazenda_Sacos, _
                                                           cnt_GridBolsa_TipoPessoaPercentual}, False)

        objGrid_Carregar(grdCalculo, SqlText, New Integer() {cnt_GridBolsa_TipoPessoa, _
                                                             cnt_GridBolsa_PostoFabrica_Kilos, _
                                                             cnt_GridBolsa_PostoFilial_Kilos, _
                                                             cnt_GridBolsa_PostoFazenda_Kilos, _
                                                             cnt_GridBolsa_PostoFabrica_Arroba, _
                                                             cnt_GridBolsa_PostoFilial_Arroba, _
                                                             cnt_GridBolsa_PostoFazenda_Arroba, _
                                                             cnt_GridBolsa_PostoFabrica_Sacos, _
                                                             cnt_GridBolsa_PostoFilial_Sacos, _
                                                             cnt_GridBolsa_PostoFazenda_Sacos, _
                                                             cnt_GridBolsa_TipoPessoaPercentual}, False)
    End Sub

    Private Sub txtFreteFabrica_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFreteFabrica.LostFocus
        AtualizaPrecoBolsa()
    End Sub

    Private Sub txtFreteFilial_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFreteFilial.LostFocus
        AtualizaPrecoBolsa()
    End Sub

    Private Sub txtFreteFazenda_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFreteFazenda.LostFocus
        AtualizaPrecoBolsa()
    End Sub

    Private Sub UDM_BeforeShowFlyout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinDock.CancelableControlPaneEventArgs) Handles UDM.BeforeShowFlyout
        e.Pane.DockAreaPane.Closed = True
    End Sub

    Private Sub Menu_ValidarAcesso()
        Dim oData As DataTable
        Dim Transacao_Bolsa_Historico As Boolean

        If NVL(MenuPrincipal.Tag, 0) = 1 Then Exit Sub

        oData = DBQuery(SEC_SqlText_Acesso(sAcesso_UsuarioLogado, SEC_Tipo_AreaAcesso.SEC_TipoAreaAcesso_Menu))

        Menu_Habilitar(mnuAdministracao_AbreDia, AcessoMenu(oData, "Administracao_AbreFechaDia"))
        Menu_Habilitar(mnuAdministracao_FechaDia, AcessoMenu(oData, "Administracao_AbreFechaDia"))
        Menu_Habilitar(mnuAdministracao_AcertoRD_Movimentacao, AcessoMenu(oData, "Administracao_AcertoRD_Movimentacao"))
        Menu_Habilitar(mnuAdministracao_AcertoRD_Valor, AcessoMenu(oData, "Administracao_AcertoRD_Valor"))
        Menu_Habilitar(mnuAdministracao_ControleAcesso_CadGrupoAcesso, AcessoMenu(oData, "SEC_CadastroGrupoAcesso"))
        Menu_Habilitar(mnuAdministracao_ControleAcesso_CadUsuario, AcessoMenu(oData, "SEC_CadastroUsuario"))
        Menu_Habilitar(mnuAdministracao_ParametroGeral, AcessoMenu(oData, "Administracao_ParametrosGerais"))
        Menu_Habilitar(mnuAdministracao_StatusFilial, AcessoMenu(oData, "Administracao_StatusFilial"))
        Menu_Habilitar(mnuCadAdministrativo_BonusPadrao, AcessoMenu(oData, "Cadastro_Administrativo_BonusPadrao"))
        Menu_Habilitar(mnuCadAdministrativo_EstadoCivil, AcessoMenu(oData, "Cadastro_Administrativo_EstadoCivil"))
        Menu_Habilitar(mnuCadAdministrativo_Filial, AcessoMenu(oData, "Cadastro_Administrativo_Filial"))
        Menu_Habilitar(mnuCadAdministrativo_LocalEntrega, AcessoMenu(oData, "Cadastro_Administrativo_LocalEntrega"))
        Menu_Habilitar(mnuCadAdministrativo_Municipio, AcessoMenu(oData, "Cadastro_Administrativo_Município"))
        Menu_Habilitar(mnuCadAdministrativo_Safra, AcessoMenu(oData, "Cadastro_Administrativo_Safra"))
        Menu_Habilitar(mnuCadAdministrativo_TipoAcondicionamento, AcessoMenu(oData, "Cadastro_Administrativo_TipoAcondicionamento"))
        Menu_Habilitar(mnuCadAdministrativo_TipoAdendo, AcessoMenu(oData, "Cadastro_Administrativo_TipoAdendo"))
        Menu_Habilitar(mnuCadAdministrativo_TipoAprovacao, AcessoMenu(oData, "Cadastro_Administrativo_TipoAprovacao"))
        Menu_Habilitar(mnuCadAdministrativo_TipoCacau, AcessoMenu(oData, "Cadastro_Administrativo_TipoCacau"))
        Menu_Habilitar(mnuCadAdministrativo_TipoCapital, AcessoMenu(oData, "Cadastro_Administrativo_TipoCapital"))
        Menu_Habilitar(mnuCadAdministrativo_TipoContato, AcessoMenu(oData, "Cadastro_Administrativo_TipoContrato"))
        Menu_Habilitar(mnuCadAdministrativo_TipoContratoPAF, AcessoMenu(oData, "Cadastro_Administrativo_TipoContratoPAF"))
        Menu_Habilitar(mnuCadAdministrativo_TipoDescontoQualidade, AcessoMenu(oData, "Cadastro_Administrativo_TipoDescontoQualidade"))
        Menu_Habilitar(mnuCadAdministrativo_TipoFrete, AcessoMenu(oData, "Cadastro_Administrativo_TipoFrete"))
        Menu_Habilitar(mnuCadAdministrativo_TipoFretista, AcessoMenu(oData, "Cadastro_Administrativo_TipoFretista"))
        Menu_Habilitar(mnuCadAdministrativo_TipoFretistaTributacao, AcessoMenu(oData, "Cadastro_Administrativo_TipoFretistaTributacao"))
        Menu_Habilitar(mnuCadAdministrativo_TipoGarantia, AcessoMenu(oData, "Cadastro_Administrativo_TipoGarantia"))
        Menu_Habilitar(mnuCadAdministrativo_TipoInovacao, AcessoMenu(oData, "Cadastro_Administrativo_TipoInovacao"))
        Menu_Habilitar(mnuCadAdministrativo_TipoMovimentacao, AcessoMenu(oData, "Cadastro_Administrativo_TipoMovimentacao"))
        Menu_Habilitar(mnuCadAdministrativo_TipoMovimentacaoSacaria, AcessoMenu(oData, "Cadastro_Administrativo_TipoMovimentacaoSacaria"))
        Menu_Habilitar(mnuCadAdministrativo_TipoNegociacao, AcessoMenu(oData, "Cadastro_Administrativo_TipoNegociacao"))
        Menu_Habilitar(mnuCadAdministrativo_TipoNF, AcessoMenu(oData, "Cadastro_Administrativo_TipoNF"))
        Menu_Habilitar(mnuCadAdministrativo_TipoPagamento, AcessoMenu(oData, "Cadastro_Administrativo_TipoPagamento"))
        Menu_Habilitar(mnuCadAdministrativo_TipoPessoa, AcessoMenu(oData, "Cadastro_Administrativo_TipoPessoa"))
        Menu_Habilitar(mnuCadAdministrativo_TipoPessoaTributacao, AcessoMenu(oData, "Cadastro_Administrativo_TipoPessoaTributacao"))
        Menu_Habilitar(mnuCadAdministrativo_TipoRD, AcessoMenu(oData, "Cadastro_Administrativo_TipoRD"))
        Menu_Habilitar(mnuCadAdministrativo_TipoSacaria, AcessoMenu(oData, "Cadastro_Administrativo_TipoSacaria"))
        Menu_Habilitar(mnuCadAdministrativo_UF, AcessoMenu(oData, "Cadastro_Administrativo_UF"))
        Menu_Habilitar(mnuCadAdministrativo_UtilizacaoSistema, AcessoMenu(oData, "Cadastro_Administrativo_UtilizacaoSistema"))
        Menu_Habilitar(mnuCadContabil_ContaCorrente, AcessoMenu(oData, "Cadastro_Contabil_ContaCorrente"))
        Menu_Habilitar(mnuCadContabil_FormaPagamento, AcessoMenu(oData, "Cadastro_Contabil_FormaPagamento"))
        Menu_Habilitar(mnuCadContabil_Funrural, AcessoMenu(oData, "Cadastro_Contabil_Funrural"))
        Menu_Habilitar(mnuCadContabil_ItensBranch, AcessoMenu(oData, "Cadastro_Contabil_ItensBranch"))
        Menu_Habilitar(mnuCadContabil_ModalidadeConciliacao, AcessoMenu(oData, "Cadastro_Contabil_ModalidadeConciliacao"))
        Menu_Habilitar(mnuCadContabil_ModalidadeRecuperacaoCredito, AcessoMenu(oData, "Cadastro_Contabil_ModalidadeRecuperacaoCredito"))
        Menu_Habilitar(mnuCadContabil_OperacaoBancaria, AcessoMenu(oData, "Cadastro_Contabil_OperacaoBancaria"))
        Menu_Habilitar(mnuCadContabil_OperacaoBancariaTipoMovimentacao, AcessoMenu(oData, "Cadastro_Contabil_OperacaoBancariaTipoMovimentacao"))
        Menu_Habilitar(mnuCadContabil_Provisao, AcessoMenu(oData, "Cadastro_Contabil_Provisao"))
        Menu_Habilitar(mnuCadFornecedor, AcessoMenu(oData, "Cadastro_Fornecedor"))
        Menu_Habilitar(mnuCadFornecedor_Consulta, AcessoMenu(oData, "Cadastro_Fornecedor"))
        Menu_Habilitar(mnuCadFornecedor_Inclusao, AcessoMenu(oData, "Cadastro_Fornecedor", SEC_Validador.SEC_V_Inclusao))
        Menu_Habilitar(mnuCadFornecedor_Aniversariante, AcessoMenu(oData, "Cadastro_Fornecedor_Aniversariantes"))
        Menu_Habilitar(mnuCadFornecedor_Fotografia, AcessoMenu(oData, "Cadastro_Fornecedor_Fotografia"))
        Menu_Habilitar(mnuCadFornecedor_Historico, AcessoMenu(oData, "Cadastro_Fornecedor_Historico"))
        Menu_Habilitar(mnuCadFretista_Consulta, AcessoMenu(oData, "Cadastro_Fretista"))
        Menu_Habilitar(mnuCadFretista_Inclusao, AcessoMenu(oData, "Cadastro_Fretista", SEC_Validador.SEC_V_Inclusao))
        Menu_Habilitar(mnuCadMovCacau_Analise, AcessoMenu(oData, "Cadastro_Movimentacao_Analise"))
        Menu_Habilitar(mnuCadMovCacau_Armazem, AcessoMenu(oData, "Cadastro_Movimentacao_Armazem"))
        Menu_Habilitar(mnuCadMovCacau_GrupoTipoMovimentacao, AcessoMenu(oData, "Cadastro_Movimentacao_GrupoTipoMovimentacao"))
        Menu_Habilitar(mnuCadMovCacau_Origem, AcessoMenu(oData, "Cadastro_Movimentacao_Origem"))
        Menu_Habilitar(mnuCadMovCacau_Procedencia, AcessoMenu(oData, "Cadastro_Movimentacao_Procedencia"))
        Menu_Habilitar(mnuInterface_JDE, AcessoMenu(oData, "Interface_JDE"))
        Menu_Habilitar(mnuInterface_LivroFiscal_Interface, False) '// Desativado em 27/01/2011 por solicitando do setor fiscal - Menu_Habilitar(mnuInterface_LivroFiscal_Interface, AcessoMenu(oData, "Interface_LivroFiscal"))
        Menu_Habilitar(mnuInterface_LivroFiscal_Relatorio, AcessoMenu(oData, "Interface_LivroFiscal_Rel_InterfaceLivroFiscal"))
        Menu_Habilitar(mnuInterface_Pagamento, AcessoMenu(oData, "Interface_Pagamento"))
        Menu_Habilitar(mnuRelConciliacao, AcessoMenu(oData, "Relatorio_Conciliacao"))
        Menu_Habilitar(mnuRelContabilidade_AdiantamentoExposure, AcessoMenu(oData, "Relatorio_Contabilidade_AdiantamentoExposure"))
        Menu_Habilitar(mnuRelContabilidade_AjusteRD_Estoque, AcessoMenu(oData, "Relatorio_Contabilidade_AjusteRDEstoque"))
        Menu_Habilitar(mnuRelContabilidade_Branches, AcessoMenu(oData, "Relatorio_Contabilidade_Branches"))
        Menu_Habilitar(mnuRelContabilidade_CashTrade, AcessoMenu(oData, "Relatorio_Contabilidade_CashTrade"))
        Menu_Habilitar(mnuRelContabilidade_ComposicaoSaldoContaFornecedor, AcessoMenu(oData, "Relatorio_Contabilidade_ComposicaoSldCtaFornecedor"))
        Menu_Habilitar(mnuRelContabilidade_FluxoCaixa, AcessoMenu(oData, "Relatorio_Contabilidade_FluxoCaixa"))
        Menu_Habilitar(mnuRelContabilidade_Apuracao_Funrural_ICMS_PISCofins, AcessoMenu(oData, "Relatorio_Contabilidade_ApuracaoFunruralICMSPISCofins"))
        Menu_Habilitar(mnuRelContabilidade_NotaFiscalComplementarContabil, AcessoMenu(oData, "Relatorio_Contabilidade_NFComplementarContabil"))
        Menu_Habilitar(mnuRelContabilidade_PrecoMedioContabil, AcessoMenu(oData, "Relatorio_Contabilidade_PrecoMedioContabil"))
        Menu_Habilitar(mnuRelContabilidade_ResumoDiarioEstoque, AcessoMenu(oData, "Relatorio_Contabilidade_ResumoDiarioEstoque"))
        Menu_Habilitar(mnuRelContabilidade_ResumoOperacao, AcessoMenu(oData, "Relatorio_Contabilidade_ResumoOperacoes"))
        Menu_Habilitar(mnuRelcontabilidade_RevalorizacaoCacau, AcessoMenu(oData, "Relatorio_Contabilidade_RevalorizacaoCacauAOrdem"))
        Menu_Habilitar(mnuRelContrato_AmarracaoICMS, AcessoMenu(oData, "Relatorio_Contratos_AmarracaoICMS"))
        Menu_Habilitar(mnuRelContrato_CalculoDiferencial, AcessoMenu(oData, "Relatorio_Contratos_CálculoDiferencial"))
        Menu_Habilitar(mnuRelContrato_ContaCorrenteContratoFixo, AcessoMenu(oData, "Relatorio_Contratos_Conta CorrenteContratoFixo"))
        Menu_Habilitar(mnuRelContrato_ContratosEmAberto, AcessoMenu(oData, "Relatorio_Contratos_ContratosEmAberto"))
        Menu_Habilitar(mnuRelContrato_ContratosFixosCancelados, AcessoMenu(oData, "Relatorio_Contratos_ContratosFixosCancelados"))
        Menu_Habilitar(mnuRelContrato_InformeCompras, AcessoMenu(oData, "Relatorio_Contratos_InformeCompras"))
        Menu_Habilitar(mnuRelContrato_ListagemContratos, AcessoMenu(oData, "Relatorio_Contratos_ListagemContratos"))
        Menu_Habilitar(mnuRelContrato_NetSaldos, AcessoMenu(oData, "Relatorio_Contratos_NetSaldo"))
        Menu_Habilitar(mnuRelContrato_NotaFiscalComplementar, AcessoMenu(oData, "Relatorio_Contratos_NotaFiscalComplementar"))
        Menu_Habilitar(mnuRelContrato_PosicaoContratos, AcessoMenu(oData, "Relatorio_Contratos_PosicaoContratos"))
        Menu_Habilitar(mnuRelContrato_PosicaoEstoqueCacauSaldoFinanceiro, AcessoMenu(oData, "Relatorio_Contratos_PosicaoEstCacauSaldoFinanceiro"))
        Menu_Habilitar(mnuRelContrato_PosicaoFornecedor, AcessoMenu(oData, "Relatorio_Contratos_PosicaoFornecedor"))
        Menu_Habilitar(mnuRelContrato_PrecoMedioGeral, AcessoMenu(oData, "Relatorio_Contratos_PrecoMedio_Geral"))
        Menu_Habilitar(mnuRelContrato_AplicacoesEmContrato, AcessoMenu(oData, "Relatorio_Contrato_AplicacoesContratos"))
        Menu_Habilitar(mnuRelContrato_PrevisaoBonusQualidade, AcessoMenu(oData, "Relatorio_Contratos_PrevisaoBonusQualidade"))
        Menu_Habilitar(mnuRelContrato_ContaCorrenteFornecedor, AcessoMenu(oData, "Relatorio_Contratos_ContaCorrenteFornecedor"))
        Menu_Habilitar(mnuRelContrato_NegociacaoAbertoFixacao, AcessoMenu(oData, "Relatorio_Contratos_NegociacaoAbertoFixacao"))
        Menu_Habilitar(mnuRelCtrlAcesso_AcessoGrupoAcesso, AcessoMenu(oData, "Relatorio_ControleAcesso_AcessoGrupoAcesso"))
        Menu_Habilitar(mnuRelCtrlAcesso_AcessoUsuario, AcessoMenu(oData, "Relatorio_ControleAcesso_AcessoUsuario"))
        Menu_Habilitar(mnuRelCtrlAcesso_AreaAcesso, AcessoMenu(oData, "Relatorio_ControleAcesso_AreaAcesso"))
        Menu_Habilitar(mnuRelCtrlAcesso_CadastroUsuario, AcessoMenu(oData, "Relatorio_ControleAcesso_CadastroUsuario"))
        Menu_Habilitar(mnuRelCtrlAcesso_GrupoAcessoUsuario, AcessoMenu(oData, "Relatorio_ControleAcesso_GrupoAcessoUsuario"))
        Menu_Habilitar(mnuRelFornecedor, AcessoMenu(oData, "Relatorio_Fornecedor"))
        Menu_Habilitar(mnuRelFrete_DivergenciaValorFrete, AcessoMenu(oData, "Relatorio_Frete_DivergenciaValorFrete"))
        Menu_Habilitar(mnuRelMovBancaria_ExtratoBancario, AcessoMenu(oData, "Relatorio_MovimentacaoBancaria_ExtratoBancario"))
        Menu_Habilitar(mnuRelMovBancaria_PorOperacao, AcessoMenu(oData, "Relatorio_MovimentacaoBancaria_PorOperacao"))
        Menu_Habilitar(mnuRelMovBancaria_ProvisaoImpostos, AcessoMenu(oData, "Relatorio_MovimentacaoBancaria_ProvisaoImposto"))
        Menu_Habilitar(mnuRelMovCacau_AplicCtrFixo, AcessoMenu(oData, "Relatorio_Contratos_AplicacaoContratoFixoData"))
        Menu_Habilitar(mnuRelMovCacau_ApuracaoQuebraSobra, AcessoMenu(oData, "Relatorio_MovimentacaoCacau_ApuracaoQuebraSobra"))
        Menu_Habilitar(mnuRelMovCacau_CacauOrdem, AcessoMenu(oData, "Relatorio_MovimentacaoCacau_CacauOrdem"))
        Menu_Habilitar(mnuRelMovCacau_EstoqueArmazem, AcessoMenu(oData, "Relatorio_MovimentacaoCacau_EstoqueArmazem"))
        Menu_Habilitar(mnuRelMovCacau_EstoqueCacau, AcessoMenu(oData, "Relatorio_MovimentacaoCacau_EstoqueCacau"))
        Menu_Habilitar(mnuRelMovCacau_ListagemFreteRecepcaoCacau, AcessoMenu(oData, "Relatorio_MovimentacaoCacau_ListFreteRecepcaoCacau"))
        Menu_Habilitar(mnuRelMovCacau_MovimentacaoCacau, AcessoMenu(oData, "Relatorio_MovimentacaoCacau_MovimentacaoCacau"))
        Menu_Habilitar(mnuRelMovCacau_MovimentacaoCacau_DataCacau, AcessoMenu(oData, "Relatorio_MovimentacaoCacau_MovimCacau_DataCacau"))
        Menu_Habilitar(mnuRelMovCacau_NotaRemessa, AcessoMenu(oData, "Relatorio_MovimentacaoCacau_NotaRemessa"))
        Menu_Habilitar(mnuRelMovCacau_ResumoEstoque, AcessoMenu(oData, "Relatorio_MovimentacaoCacau_ResumoEstoque"))
        Menu_Habilitar(mnuRelMovCacau_TransferenciaData, AcessoMenu(oData, "Relatorio_MovimentacaoCacau_TransferenciaData"))
        Menu_Habilitar(mnuRelMovCacau_ControleQuebraTransferencias, AcessoMenu(oData, "Relatorio_MovimentacaoCacau_ControleQuebraPesagem"))
        Menu_Habilitar(mnuRelMovCacau_AbertoNegociacao, AcessoMenu(oData, "Relatorio_MovimentacaoCacau_MovAbertoNegociacao"))
        Menu_Habilitar(mnuRelMovCacau_ValorizacaoIndustrializacao, AcessoMenu(oData, "Relatorio_MovimentacaoCacau_ValorIndustrializacao"))
        Menu_Habilitar(mnuRelMovCacau_PorFilial, AcessoMenu(oData, "Relatorio_MovimentacaoCacau_MovimentacaoPorFilial"))
        Menu_Habilitar(mnuRelMovCacau_ProvisaoNFComplementar, AcessoMenu(oData, "Relatorio_MovimentacaoCacau_MovimentacaoPorFilial"))
        Menu_Habilitar(mnuRelMovCacau_UmidadeMedia, AcessoMenu(oData, "Relatorio_MovimentacaoCacau_UmidadeMedia"))
        Menu_Habilitar(mnuRelPagamento_AdiantamentoEmAberto, AcessoMenu(oData, "Relatorio_Pagamento_AdiantamentoAberto"))
        Menu_Habilitar(mnuRelPagamento_ListagemPagamentos, AcessoMenu(oData, "Relatorio_Pagamento_ListagemPagamentos"))
        Menu_Habilitar(mnuRelPagamento_PagamentosAberto, AcessoMenu(oData, "Relatorio_Pagamento_PagamentosAberto"))
        Menu_Habilitar(mnuRelRecuperacaoCredito, AcessoMenu(oData, "Relatorio_RecuperacaoCredito"))
        Menu_Habilitar(mnuRelSacaria_MovimentacaoSacaria, AcessoMenu(oData, "Relatorio_Sacaria_MovimentacaoSacaria"))
        Menu_Habilitar(mnuRelSacaria_SaldoFilial, AcessoMenu(oData, "Relatorio_Sacaria_SaldoFilial"))
        Menu_Habilitar(mnuRelSacaria_SaldoFornecedor, AcessoMenu(oData, "Relatorio_Sacaria_SaldoFornecedor"))
        Menu_Habilitar(mnuRelSacaria_SaldoRepassador, AcessoMenu(oData, "Relatorio_Sacaria_SaldRepassador"))
        Menu_Habilitar(mnuTransBolsa_DadosBolsa, AcessoMenu(oData, "Transacao_Bolsa_Dados_Bolsa"))
        Menu_Habilitar(mnuTransBolsa_Grafico, AcessoMenu(oData, "Transacao_Bolsa_Grafico"))
        Transacao_Bolsa_Historico = AcessoMenu(oData, "Transacao_Bolsa_Historico")
        Menu_Habilitar(mnuTransBolsa_Historico, Transacao_Bolsa_Historico)
        Menu_Habilitar(mnuTransBolsa_Parametro, AcessoMenu(oData, "Transacao_Bolsa_Parametro"))
        Menu_Habilitar(mnuTransConciliacao_Consulta, AcessoMenu(oData, "Transacao_Conciliacao"))
        Menu_Habilitar(mnuTransConciliacao_Inclusao, AcessoMenu(oData, "Transacao_Conciliacao", SEC_Validador.SEC_V_Inclusao))
        Menu_Habilitar(mnuTransContato_Consulta, AcessoMenu(oData, "Transacao_Contato"))
        Menu_Habilitar(mnuTransContato_Inclusao, AcessoMenu(oData, "Transacao_Contato", SEC_Validador.SEC_V_Inclusao))
        Menu_Habilitar(mnuTransContato_Grafico, AcessoMenu(oData, "Transacao_Contato_Grafico"))
        Menu_Habilitar(mnuTransContrato_AmarracaoManualICMS, AcessoMenu(oData, "Transacao_Contratos_AmarracaoManualICMS"))
        Menu_Habilitar(mnuTransContrato_AplicacaoMovimentacao, AcessoMenu(oData, "Transacao_Contratos_AplicacaoMovimentacao"))
        Menu_Habilitar(mnuTransContrato_AplicacaoPagamento, AcessoMenu(oData, "Transacao_Contratos_AplicacaoPagamento"))
        Menu_Habilitar(mnuTransContrato_ConsultaContratos, AcessoMenu(oData, "Transacao_Contratos_ContratosFixo") Or _
                                                           AcessoMenu(oData, "Transacao_Contratos_ContratosPAF") Or _
                                                           AcessoMenu(oData, "Transacao_Contratos_Negociacao"))
        Menu_Habilitar(mnuTransContrato_ConsultaCompraAcumulada, AcessoMenu(oData, "Transacao_Contratos_ConsultaComprasAcumuladas"))
        Menu_Habilitar(mnuTransContrato_InclusaoContratoFixo, AcessoMenu(oData, "Transacao_Contratos_ContratosFixo", SEC_Validador.SEC_V_Inclusao))
        Menu_Habilitar(mnuTransContrato_InclusaoContratoPAF, AcessoMenu(oData, "Transacao_Contratos_ContratosPAF", SEC_Validador.SEC_V_Inclusao))
        Menu_Habilitar(mnuTransContrato_Rec_GerarPremioQualidade, AcessoMenu(oData, "Transacao_Contratos_GerarPremioQualidade"))
        Menu_Habilitar(mnuTransContrato_InclusaoNegociacao, AcessoMenu(oData, "Transacao_Contratos_Negociacao", SEC_Validador.SEC_V_Inclusao))
        Menu_Habilitar(mnuTransContrato_Rec_PremioQualidadeInativo, AcessoMenu(oData, "Transacao_Contratos_PremioQualidadeInativo"))
        Menu_Habilitar(mnuTransContrato_ConsultaPreNegociacao, AcessoMenu(oData, "Transacao_Contratos_PreNegociacao"))
        Menu_Habilitar(mnuTransContrato_InclusaoPreNegociao, AcessoMenu(oData, "Transacao_Contratos_PreNegociacao", SEC_Validador.SEC_V_Inclusao))
        Menu_Habilitar(mnuTransContrato_Rec_ArmarracaoAutomatica, AcessoMenu(oData, "Transacao_Contratos_Recursos_AmarracaoAutomatica"))
        Menu_Habilitar(mnuTransContrato_Rec_AplicacaoAutomatica, AcessoMenu(oData, "Transacao_Contratos_Recursos_AplicacaoAutomatica"))
        Menu_Habilitar(mnuTransContrato_Rec_RevisaoContrato, AcessoMenu(oData, "Transacao_Contratos_RevisaoContratos"))
        Menu_Habilitar(mnuTransContrato_EstornoDeDesagio, AcessoMenu(oData, "Transacao_Contratos_SolicitaEstornoDesagio"))
        Menu_Habilitar(mnuTransContrato_AprovacaoEstornoDesagio, AcessoMenu(oData, "Transacao_Contratos_AprovacaoEstornoDesagio"))
        Menu_Habilitar(mnuTransContrato_AprovacaoRenegociacao, AcessoMenu(oData, "Transacao_Contratos_AprovacaoRenegociacao"))
        Menu_Habilitar(mnuTransFrete_Inclusao, AcessoMenu(oData, "Transacao_Frete", SEC_Validador.SEC_V_Inclusao))
        Menu_Habilitar(mnuTransFrete_ConsultaPagamento, AcessoMenu(oData, "Transacao_Frete_GerarPagamento"))
        Menu_Habilitar(mnuTransFrete_GerarPagamento, AcessoMenu(oData, "Transacao_Frete_GerarPagamento"))
        Menu_Habilitar(mnuTransGarantia_Consulta, AcessoMenu(oData, "Transacao_Garantia"))
        Menu_Habilitar(mnuTransGarantia_Inclusao, AcessoMenu(oData, "Transacao_Garantia", SEC_Validador.SEC_V_Inclusao))
        Menu_Habilitar(mnuTransInovacao_Consulta, AcessoMenu(oData, "Transacao_Inovacao"))
        Menu_Habilitar(mnuTransInovacao_Inclusao, AcessoMenu(oData, "Transacao_Inovacao", SEC_Validador.SEC_V_Inclusao))
        Menu_Habilitar(mnuTransJornal_Consulta, AcessoMenu(oData, "Transacao_Jornal"))
        Menu_Habilitar(mnuTransJornal_Inclusao, AcessoMenu(oData, "Transacao_Jornal", SEC_Validador.SEC_V_Inclusao))
        Menu_Habilitar(mnuTransMovCacau_CessaoDireito, AcessoMenu(oData, "Transacao_MovCacau_CessaoDireito"))
        Menu_Habilitar(mnuTransMovCacau_ConsultaArmazem, AcessoMenu(oData, "Transacao_MovCacau_ConsultaArmazem"))
        Menu_Habilitar(mnuTransMovCacau_ConsultaMovCacau, AcessoMenu(oData, "Transacao_MovCacau_ConsultaMovimentacaoCacau"))
        Menu_Habilitar(mnuTransMovCacau_ConsultaMovPorEstado, AcessoMenu(oData, "Transacao_MovCacau_ConsultaMovimentacaoEstado"))
        Menu_Habilitar(mnuTransMovCacau_ConsultaNotaRemessa, AcessoMenu(oData, "Transacao_MovCacau_NotaRemessa"))
        Menu_Habilitar(mnuTransMovCacau_RecepcaoSummus, AcessoMenu(oData, "Transacao_MovCacau_ConsultaRecepcaoSummus"))
        Menu_Habilitar(mnuTransMovCacau_ConsultaTransferencia, AcessoMenu(oData, "Transacao_MovCacau_ConsultaTransferencia"))
        Menu_Habilitar(mnuTransMovCacau_DevolucaoCacauFornecedor, AcessoMenu(oData, "Transacao_MovCacau_DevolucaoCacauFornecedor"))
        Menu_Habilitar(mnuTransMovCacau_EstoqueSilo, AcessoMenu(oData, "Transacao_MovCacau_EstoqueSilo"))
        Menu_Habilitar(mnuTransMovCacau_InclusaoNotaFiscalComplementar, AcessoMenu(oData, "Transacao_MovCacau_InclusaoNFComplementar", SEC_Validador.SEC_V_Inclusao))
        Menu_Habilitar(mnuTransMovCacau_InclusaoNFRemessa, AcessoMenu(oData, "Transacao_MovCacau_NotaRemessa", SEC_Validador.SEC_V_Inclusao))
        Menu_Habilitar(mnuTransMovCacau_MovimentarDentroArmazem, AcessoMenu(oData, "Transacao_MovCacau_MovimentarDentroArmazem"))
        Menu_Habilitar(mnuTransMovBancaria_Consulta, AcessoMenu(oData, "Transacao_MovimentacaoBancaria"))
        Menu_Habilitar(mnuTransMovBancaria_Inclusao, AcessoMenu(oData, "Transacao_MovimentacaoBancaria", SEC_Validador.SEC_V_Inclusao))
        Menu_Habilitar(mnuTransMovBancaria_EmissaoCheque, AcessoMenu(oData, "Transacao_MovimentacaoBancaria_EmissaoCheque"))
        Menu_Habilitar(mnuTransPagamento_Consulta, AcessoMenu(oData, "Transacao_Pagamento"))
        Menu_Habilitar(mnuTransPagamento_Inclusao, AcessoMenu(oData, "Transacao_Pagamento", SEC_Validador.SEC_V_Inclusao))
        Menu_Habilitar(mnuTransPagamento_Aprovacao, AcessoMenu(oData, "Transacao_Pagamento_Aprovacao"))
        Menu_Habilitar(mnuTransPDD, AcessoMenu(oData, "Transacao_PPD"))
        Menu_Habilitar(mnuTransRecuperacaoCredito_Consulta, AcessoMenu(oData, "Transacao_RecuperacaoCredito"))
        Menu_Habilitar(mnuTransRecuperacaoCredito_Inclusao, AcessoMenu(oData, "Transacao_RecuperacaoCredito", SEC_Validador.SEC_V_Inclusao))
        Menu_Habilitar(mnuTransResumoDiarioEstoque_Consulta, AcessoMenu(oData, "Transacao_ResumoDiarioEstoque_Consulta"))
        Menu_Habilitar(mnuTransResumoDiarioEstoque_LancamentoAjuste, AcessoMenu(oData, "Transacao_ResumoDiarioEstoque_LancamentoAjuste"))
        Menu_Habilitar(mnuTransSacaria_ConsultaMovimentacao, AcessoMenu(oData, "Transacao_Sacaria_ConsultaMovimentacao"))
        Menu_Habilitar(mnuTransSacaria_ConsultaSaldo, AcessoMenu(oData, "Transacao_Sacaria_ConsultaSaldo"))
        Menu_Habilitar(mnuTransSacaria_ConsultaTransferenciaAberto, AcessoMenu(oData, "Transacao_Sacaria_ConsultaTransferenciaTransito"))
        Menu_Habilitar(mnuTransSacaria_InclusaoRequisicaoSacaria, AcessoMenu(oData, "Transacao_Sacaria_RequisicaoSacaria", SEC_Validador.SEC_V_Inclusao))
        Menu_Habilitar(mnuTransSacaria_InclusaoSacariaPosicaoFilial, AcessoMenu(oData, "Transacao_Sacaria_InclusaoSacariaPosicaoFilial", SEC_Validador.SEC_V_Inclusao))
        Menu_Habilitar(mnuTransSacaria_InclusaoSacariaPosicaoFornecedor, AcessoMenu(oData, "Transacao_Sacaria_InclusaoSacariaPosicaoFornecedor", SEC_Validador.SEC_V_Inclusao))
        Menu_Habilitar(mnuTransSacaria_ConsultaRequisicaoSacaria, AcessoMenu(oData, "Transacao_Sacaria_RequisicaoSacaria"))
        Menu_Habilitar(mnuTransSolicitacaoCredito_Consulta, AcessoMenu(oData, "Transacao_SolicitacaoCredito"))
        Menu_Habilitar(mnuTransSolicitacaoCredito_Inclusao, AcessoMenu(oData, "Transacao_SolicitacaoCredito", SEC_Validador.SEC_V_Inclusao))
        Menu_Habilitar(mnuTransSolicitacaoCredito_Aprovacao, AcessoMenu(oData, "Transacao_SolicitacaoCredito_Aprovacao"))
        Menu_Habilitar(mnuTransSolicitacaoCredito_Historico, AcessoMenu(oData, "Transacao_SolicitacaoCredito_Historico"))

        mnuTransContrato_Linha_EstornoDesagio.Visible = (mnuTransContrato_AprovacaoEstornoDesagio.Visible Or mnuTransContrato_EstornoDeDesagio.Visible)
        mnuTransContrato_Linha_Renegociacao.Visible = (mnuTransContrato_AprovacaoRenegociacao.Visible)

        If Not Transacao_Bolsa_Historico Then
            UDM.ControlPanes(cnt_DockPanel_ValorCotacaoBolsa).Close()
            Menu_Habilitar(mnuVisualizar_ValorCotacaoBolsa, False)
            UDM.ControlPanes(cnt_DockPanel_CalculoDiferencial).Close()
            Menu_Habilitar(mnuVisualizar_CalculoDiferencial, False)
        End If

        '>> Cadastro
        Menu_Habilitar(mnuCadAdministrativo_Tipo, (mnuCadAdministrativo_TipoAcondicionamento.Tag = 1 Or _
                                                   mnuCadAdministrativo_TipoAdendo.Tag = 1 Or _
                                                   mnuCadAdministrativo_TipoAprovacao.Tag = 1 Or _
                                                   mnuCadAdministrativo_TipoCacau.Tag = 1 Or _
                                                   mnuCadAdministrativo_TipoCapital.Tag = 1 Or _
                                                   mnuCadAdministrativo_TipoContato.Tag = 1 Or _
                                                   mnuCadAdministrativo_TipoContratoPAF.Tag = 1 Or _
                                                   mnuCadAdministrativo_TipoDescontoQualidade.Tag = 1 Or _
                                                   mnuCadAdministrativo_TipoFrete.Tag = 1 Or _
                                                   mnuCadAdministrativo_TipoFretista.Tag = 1 Or _
                                                   mnuCadAdministrativo_TipoFretistaTributacao.Tag = 1 Or _
                                                   mnuCadAdministrativo_TipoGarantia.Tag = 1 Or _
                                                   mnuCadAdministrativo_TipoInovacao.Tag = 1 Or _
                                                   mnuCadAdministrativo_TipoMovimentacao.Tag = 1 Or _
                                                   mnuCadAdministrativo_TipoMovimentacaoSacaria.Tag = 1 Or _
                                                   mnuCadAdministrativo_TipoNF.Tag = 1 Or _
                                                   mnuCadAdministrativo_TipoNegociacao.Tag = 1 Or _
                                                   mnuCadAdministrativo_TipoPagamento.Tag = 1 Or _
                                                   mnuCadAdministrativo_TipoPessoa.Tag = 1 Or _
                                                   mnuCadAdministrativo_TipoPessoaTributacao.Tag = 1 Or _
                                                   mnuCadAdministrativo_TipoRD.Tag = 1 Or _
                                                   mnuCadAdministrativo_TipoSacaria.Tag = 1 Or _
                                                   mnuCadAdministrativo_UF.Tag = 1 Or _
                                                   mnuCadAdministrativo_UtilizacaoSistema.Tag = 1))
        Menu_Habilitar(mnuCadAdministrativo, (mnuCadAdministrativo_BonusPadrao.Tag = 1 Or _
                                             mnuCadAdministrativo_EstadoCivil.Tag = 1 Or _
                                             mnuCadAdministrativo_Filial.Tag = 1 Or _
                                             mnuCadAdministrativo_LocalEntrega.Tag = 1 Or _
                                             mnuCadAdministrativo_Municipio.Tag = 1 Or _
                                             mnuCadAdministrativo_Safra.Tag = 1 Or _
                                             mnuCadAdministrativo_Tipo.Tag = 1))
        Menu_Habilitar(mnuCadContabil, (mnuCadContabil_ContaCorrente.Tag = 1 Or _
                                        mnuCadContabil_FormaPagamento.Tag = 1 Or _
                                        mnuCadContabil_Funrural.Tag = 1 Or _
                                        mnuCadContabil_ItensBranch.Tag = 1 Or _
                                        mnuCadContabil_ModalidadeConciliacao.Tag = 1 Or _
                                        mnuCadContabil_ModalidadeRecuperacaoCredito.Tag = 1 Or _
                                        mnuCadContabil_OperacaoBancaria.Tag = 1 Or _
                                        mnuCadContabil_OperacaoBancariaTipoMovimentacao.Tag = 1 Or _
                                        mnuCadContabil_Provisao.Tag = 1))
        Menu_Habilitar(mnuCadFornecedor, (mnuCadFornecedor_Aniversariante.Tag = 1 Or _
                                          mnuCadFornecedor_Consulta.Tag = 1 Or _
                                          mnuCadFornecedor_Fotografia.Tag = 1 Or _
                                          mnuCadFornecedor_Historico.Tag = 1 Or _
                                          mnuCadFornecedor_Inclusao.Tag = 1))
        Menu_Habilitar(mnuCadFretista, (mnuCadFretista_Consulta.Tag = 1 Or _
                                        mnuCadFretista_Inclusao.Tag = 1))
        Menu_Habilitar(mnuCadMovCacau, (mnuCadMovCacau_Analise.Tag = 1 Or _
                                        mnuCadMovCacau_Armazem.Tag = 1 Or _
                                        mnuCadMovCacau_GrupoTipoMovimentacao.Tag = 1 Or _
                                        mnuCadMovCacau_Origem.Tag = 1 Or _
                                        mnuCadMovCacau_Procedencia.Tag = 1))
        Menu_Habilitar(mnuCadastro, (mnuCadAdministrativo.Tag = 1 Or _
                                     mnuCadContabil.Tag = 1 Or _
                                     mnuCadFornecedor.Tag = 1 Or _
                                     mnuCadFretista.Tag = 1 Or _
                                     mnuCadMovCacau.Tag = 1))
        '>> Transação
        Menu_Habilitar(mnuTransBolsa, (mnuTransBolsa_DadosBolsa.Tag = 1 Or _
                                       mnuTransBolsa_Grafico.Tag = 1 Or _
                                       mnuTransBolsa_Historico.Tag = 1 Or _
                                       mnuTransBolsa_Parametro.Tag = 1))
        Menu_Habilitar(mnuTransConciliacao, (mnuTransConciliacao_Consulta.Tag = 1 Or _
                                             mnuTransConciliacao_Inclusao.Tag = 1))
        Menu_Habilitar(mnuTransContato, (mnuTransContato_Consulta.Tag = 1 Or _
                                         mnuTransContato_Grafico.Tag = 1 Or _
                                         mnuTransContato_Inclusao.Tag = 1))
        Menu_Habilitar(mnuTransContrato_Recurso, (mnuTransContrato_Rec_AplicacaoAutomatica.Tag = 1 Or _
                                                  mnuTransContrato_Rec_ArmarracaoAutomatica.Tag = 1 Or _
                                                  mnuTransContrato_Rec_GerarPremioQualidade.Tag = 1 Or _
                                                  mnuTransContrato_Rec_PremioQualidadeInativo.Tag = 1 Or _
                                                  mnuTransContrato_Rec_RevisaoContrato.Tag = 1))
        Menu_Habilitar(mnuTransContrato, (mnuTransContrato_AmarracaoManualICMS.Tag = 1 Or _
                                          mnuTransContrato_AplicacaoMovimentacao.Tag = 1 Or _
                                          mnuTransContrato_AplicacaoPagamento.Tag = 1 Or _
                                          mnuTransContrato_ConsultaCompraAcumulada.Tag = 1 Or _
                                          mnuTransContrato_ConsultaContratos.Tag = 1 Or _
                                          mnuTransContrato_ConsultaPreNegociacao.Tag = 1 Or _
                                          mnuTransContrato_InclusaoContratoFixo.Tag = 1 Or _
                                          mnuTransContrato_InclusaoContratoPAF.Tag = 1 Or _
                                          mnuTransContrato_InclusaoNegociacao.Tag = 1 Or _
                                          mnuTransContrato_InclusaoPreNegociao.Tag = 1 Or _
                                          mnuTransContrato_Recurso.Tag = 1))
        Menu_Habilitar(mnuTransFrete, (mnuTransFrete_Consulta.Tag = 1 Or _
                                       mnuTransFrete_ConsultaPagamento.Tag = 1 Or _
                                       mnuTransFrete_GerarPagamento.Tag = 1 Or _
                                       mnuTransFrete_Inclusao.Tag = 1))
        Menu_Habilitar(mnuTransGarantia, (mnuTransGarantia_Consulta.Tag = 1 Or _
                                          mnuTransGarantia_Inclusao.Tag = 1))
        Menu_Habilitar(mnuTransInovacao, (mnuTransInovacao_Consulta.Tag = 1 Or _
                                          mnuTransInovacao_Inclusao.Tag = 1))
        Menu_Habilitar(mnuTransJornal, (mnuTransJornal_Consulta.Tag = 1 Or _
                                        mnuTransJornal_Inclusao.Tag = 1))
        Menu_Habilitar(mnuTransMovBancaria, (mnuTransMovBancaria_Consulta.Tag = 1 Or _
                                             mnuTransMovBancaria_Inclusao.Tag = 1 Or _
                                             mnuTransMovBancaria_EmissaoCheque.Tag = 1))
        Menu_Habilitar(mnuTransMovCacau, (mnuTransMovCacau_CessaoDireito.Tag = 1 Or _
                                          mnuTransMovCacau_ConsultaArmazem.Tag = 1 Or _
                                          mnuTransMovCacau_ConsultaMovCacau.Tag = 1 Or _
                                          mnuTransMovCacau_ConsultaMovPorEstado.Tag = 1 Or _
                                          mnuTransMovCacau_ConsultaNotaRemessa.Tag = 1 Or _
                                          mnuTransMovCacau_ConsultaTransferencia.Tag = 1 Or _
                                          mnuTransMovCacau_DevolucaoCacauFornecedor.Tag = 1 Or _
                                          mnuTransMovCacau_EstoqueSilo.Tag = 1 Or _
                                          mnuTransMovCacau_InclusaoNFRemessa.Tag = 1 Or _
                                          mnuTransMovCacau_InclusaoNotaFiscalComplementar.Tag = 1 Or _
                                          mnuTransMovCacau_RecepcaoSummus.Tag = 1))
        Menu_Habilitar(mnuTransPagamento, (mnuTransPagamento_Aprovacao.Tag = 1 Or _
                                           mnuTransPagamento_Consulta.Tag = 1 Or _
                                           mnuTransPagamento_Inclusao.Tag = 1))
        Menu_Habilitar(mnuTransRecuperacaoCredito, (mnuTransRecuperacaoCredito_Consulta.Tag = 1 Or _
                                                    mnuTransRecuperacaoCredito_Inclusao.Tag = 1))
        Menu_Habilitar(mnuTransResumoDiarioEstoque, (mnuTransResumoDiarioEstoque_Consulta.Tag = 1 Or _
                                                     mnuTransResumoDiarioEstoque_LancamentoAjuste.Tag = 1))
        Menu_Habilitar(mnuTransSacaria, (mnuTransSacaria_ConsultaMovimentacao.Tag = 1 Or _
                                         mnuTransSacaria_ConsultaRequisicaoSacaria.Tag = 1 Or _
                                         mnuTransSacaria_ConsultaSaldo.Tag = 1 Or _
                                         mnuTransSacaria_ConsultaTransferenciaAberto.Tag = 1 Or _
                                         mnuTransSacaria_InclusaoRequisicaoSacaria.Tag = 1 Or _
                                         mnuTransSacaria_InclusaoSacariaPosicaoFilial.Tag = 1 Or _
                                         mnuTransSacaria_InclusaoSacariaPosicaoFornecedor.Tag = 1))
        Menu_Habilitar(mnuTransSolicitacaoCredito, (mnuTransSolicitacaoCredito_Aprovacao.Tag = 1 Or _
                                                    mnuTransSolicitacaoCredito_Consulta.Tag = 1 Or _
                                                    mnuTransSolicitacaoCredito_Historico.Tag = 1 Or _
                                                    mnuTransSolicitacaoCredito_Inclusao.Tag = 1))
        Menu_Habilitar(mnuTransacao, (mnuTransBolsa.Tag = 1 Or _
                                      mnuTransConciliacao.Tag = 1 Or _
                                      mnuTransContato.Tag = 1 Or _
                                      mnuTransContrato.Tag = 1 Or _
                                      mnuTransFrete.Tag = 1 Or _
                                      mnuTransGarantia.Tag = 1 Or _
                                      mnuTransInovacao.Tag = 1 Or _
                                      mnuTransJornal.Tag = 1 Or _
                                      mnuTransMovBancaria.Tag = 1 Or _
                                      mnuTransMovCacau.Tag = 1 Or _
                                      mnuTransPagamento.Tag = 1 Or _
                                      mnuTransResumoDiarioEstoque.Tag = 1 Or _
                                      mnuTransSacaria.Tag = 1 Or _
                                      mnuTransSolicitacaoCredito.Tag = 1))
        '>> Relatório
        Menu_Habilitar(mnuRelContabilidade, (mnuRelContabilidade_AdiantamentoExposure.Tag = 1 Or _
                                             mnuRelContabilidade_Branches.Tag = 1 Or _
                                             mnuRelContabilidade_CashTrade.Tag = 1 Or _
                                             mnuRelContabilidade_ComposicaoSaldoContaFornecedor.Tag = 1 Or _
                                             mnuRelContabilidade_Apuracao_Funrural_ICMS_PISCofins.Tag = 1 Or _
                                             mnuRelContabilidade_NotaFiscalComplementarContabil.Tag = 1 Or _
                                             mnuRelContabilidade_PrecoMedioContabil.Tag = 1 Or _
                                             mnuRelContabilidade_ResumoDiarioEstoque.Tag = 1 Or _
                                             mnuRelContabilidade_ResumoOperacao.Tag = 1))
        Menu_Habilitar(mnuRelContrato, (mnuRelContrato_AmarracaoICMS.Tag = 1 Or _
                                        mnuRelContrato_CalculoDiferencial.Tag = 1 Or _
                                        mnuRelContrato_ContaCorrenteContratoFixo.Tag = 1 Or _
                                        mnuRelContrato_ContratosEmAberto.Tag = 1 Or _
                                        mnuRelContrato_ContratosFixosCancelados.Tag = 1 Or _
                                        mnuRelContrato_InformeCompras.Tag = 1 Or _
                                        mnuRelContrato_ListagemContratos.Tag = 1 Or _
                                        mnuRelContrato_NetSaldos.Tag = 1 Or _
                                        mnuRelContrato_NotaFiscalComplementar.Tag = 1 Or _
                                        mnuRelContrato_PosicaoContratos.Tag = 1 Or _
                                        mnuRelContrato_PosicaoFornecedor.Tag = 1 Or _
                                        mnuRelContrato_PrecoMedioGeral.Tag = 1 Or _
                                        mnuRelContrato_PrevisaoBonusQualidade.Tag = 1 Or _
                                        mnuRelContrato_ContaCorrenteFornecedor.Tag = 1 Or _
                                        mnuRelContrato_NegociacaoAbertoFixacao.Tag = 1))
        Menu_Habilitar(mnuRelCtrlAcesso, (mnuRelCtrlAcesso_AcessoGrupoAcesso.Tag = 1 Or _
                                          mnuRelCtrlAcesso_AcessoUsuario.Tag = 1 Or _
                                          mnuRelCtrlAcesso_AreaAcesso.Tag = 1 Or _
                                          mnuRelCtrlAcesso_CadastroUsuario.Tag = 1 Or _
                                          mnuRelCtrlAcesso_GrupoAcessoUsuario.Tag = 1))
        Menu_Habilitar(mnuRelFrete, (mnuRelFrete_DivergenciaValorFrete.Tag = 1))
        Menu_Habilitar(mnuRelMovBancaria, (mnuRelMovBancaria_ExtratoBancario.Tag = 1 Or _
                                           mnuRelMovBancaria_PorOperacao.Tag = 1 Or _
                                           mnuRelMovBancaria_ProvisaoImpostos.Tag = 1))
        Menu_Habilitar(mnuRelMovCacau, (mnuRelMovCacau_AplicCtrFixo.Tag = 1 Or _
                                        mnuRelMovCacau_ApuracaoQuebraSobra.Tag = 1 Or _
                                        mnuRelMovCacau_CacauOrdem.Tag = 1 Or _
                                        mnuRelMovCacau_EstoqueArmazem.Tag = 1 Or _
                                        mnuRelMovCacau_EstoqueCacau.Tag = 1 Or _
                                        mnuRelMovCacau_MovimentacaoCacau.Tag = 1 Or _
                                        mnuRelMovCacau_MovimentacaoCacau_DataCacau.Tag = 1 Or _
                                        mnuRelMovCacau_PorFilial.Tag = 1 Or _
                                        mnuRelMovCacau_AbertoNegociacao.Tag = 1 Or _
                                        mnuRelMovCacau_NotaRemessa.Tag = 1 Or _
                                        mnuRelMovCacau_ResumoEstoque.Tag = 1 Or _
                                        mnuRelMovCacau_TransferenciaData.Tag = 1 Or _
                                        mnuRelMovCacau_ControleQuebraTransferencias.Tag = 1))
        Menu_Habilitar(mnuRelPagamento, (mnuRelPagamento_AdiantamentoEmAberto.Tag = 1 Or _
                                         mnuRelPagamento_ListagemPagamentos.Tag = 1 Or _
                                         mnuRelPagamento_PagamentosAberto.Tag = 1))
        Menu_Habilitar(mnuRelSacaria, (mnuRelSacaria_MovimentacaoSacaria.Tag = 1 Or _
                                       mnuRelSacaria_SaldoFilial.Tag = 1 Or _
                                       mnuRelSacaria_SaldoFornecedor.Tag = 1 Or _
                                       mnuRelSacaria_SaldoRepassador.Tag = 1))
        Menu_Habilitar(mnuRelatorio, (mnuRelConciliacao.Tag = 1 Or _
                                      mnuRelContabilidade.Tag = 1 Or _
                                      mnuRelContrato.Tag = 1 Or _
                                      mnuRelCtrlAcesso.Tag = 1 Or _
                                      mnuRelFornecedor.Tag = 1 Or _
                                      mnuRelFrete.Tag = 1 Or _
                                      mnuRelMovBancaria.Tag = 1 Or _
                                      mnuRelMovCacau.Tag = 1 Or _
                                      mnuRelPagamento.Tag = 1 Or _
                                      mnuRelRecuperacaoCredito.Tag = 1 Or _
                                      mnuRelSacaria.Tag = 1))
        '>> Interface
        Menu_Habilitar(mnuInterface_LivroFiscal, (mnuInterface_LivroFiscal_Interface.Tag = 1 Or _
                                                  mnuInterface_LivroFiscal_Relatorio.Tag = 1))
        Menu_Habilitar(mnuInterface, (mnuInterface_LivroFiscal.Tag = 1 Or _
                                      mnuInterface_JDE.Tag = 1 Or _
                                      mnuInterface_Pagamento.Tag = 1))
        '>> Administração
        Menu_Habilitar(mnuAdministracao_AcertoRD, (mnuAdministracao_AcertoRD_Movimentacao.Tag = 1 Or _
                                                   mnuAdministracao_AcertoRD_Valor.Tag = 1))
        Menu_Habilitar(mnuAdministracao_ControleAcesso, (mnuAdministracao_ControleAcesso_CadGrupoAcesso.Tag = 1 Or _
                                                         mnuAdministracao_ControleAcesso_CadUsuario.Tag = 1))
        Menu_Habilitar(mnuAdministracao, (mnuAdministracao_AbreDia.Tag = 1 Or _
                                          mnuAdministracao_FechaDia.Tag = 1 Or _
                                          mnuAdministracao_AcertoRD.Tag = 1 Or _
                                          mnuAdministracao_ControleAcesso.Tag = 1 Or _
                                          mnuAdministracao_ParametroGeral.Tag = 1 Or _
                                          mnuAdministracao_StatusFilial.Tag = 1))

        'Eliminado em 13/01/2011 por solicitação da controladoria
        mnuTransGarantia.Visible = False
        mnuTransInovacao.Visible = False

        MenuPrincipal.Tag = 1
    End Sub

    Private Sub Menu_Habilitar(ByVal oMenu As Windows.Forms.ToolStripMenuItem, ByVal Habilitar As Boolean)
        oMenu.Visible = Habilitar
        oMenu.Tag = IIf(Habilitar, 1, 0)
    End Sub

    Private Function AcessoMenu(ByVal oData As DataTable, ByVal sNomeMenu As String, _
                                Optional ByVal TipoAcesso As SEC_Validador = 0) As Boolean
        Dim iCont As Integer

        If FilialLogada_Fechada Then
            TipoAcesso = SEC_Validador.SEC_V_Consulta
        End If

        For iCont = 0 To oData.Rows.Count - 1
            If UCase(oData.Rows(iCont).Item("NO_AREAACESSO_INTERNO")) = UCase(sNomeMenu) And _
               (TipoAcesso = 0 Or oData.Rows(iCont).Item("CD_TIPOACESSO") = TipoAcesso) Then
                Return True
                Exit For
            End If
        Next
    End Function

    Private Sub mnuCadastroSolicitacaoCredito_Aprovacao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTransSolicitacaoCredito_Aprovacao.Click
        Form_Show(Me, frmAprovacaoCreditoConsulta)
    End Sub

    Private Sub mnuCadastroFunrural_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCadContabil_Funrural.Click
        Form_Carregar_Cadastro_Listagem_Geral(Me, frmCadastroListagemGeral.eCadastroListagemGeral.Funrural)
    End Sub

    Private Sub mnuCadastroSacaria_ConsultaMovimentacao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTransSacaria_ConsultaMovimentacao.Click
        Form_Show(Me, frmConsultaSacaria)
    End Sub

    Private Sub mnuCadastroContato_Grafico_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTransContato_Grafico.Click
        oFormGrafico = New frmChart_Propriedade
        oFormGrafico.FormatarTela(frmChart_Propriedade.eGrafico.Logus_Contato)

        Form_Show_MDI(Nothing, oFormGrafico)
    End Sub

    Private Sub mnuCadastroFormaPagamento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCadContabil_FormaPagamento.Click
        Form_Carregar_Cadastro_Listagem_Geral(Me, frmCadastroListagemGeral.eCadastroListagemGeral.Forma_Pagamento)
    End Sub

    Private Sub mnuCadastroEstadoCivil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCadAdministrativo_EstadoCivil.Click
        Form_Carregar_Cadastro_Listagem_Geral(Me, frmCadastroListagemGeral.eCadastroListagemGeral.Estado_Civil)
    End Sub

    Private Sub mnuCadastroMunicipio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCadAdministrativo_Municipio.Click
        Form_Carregar_Cadastro_Listagem_Geral(Me, frmCadastroListagemGeral.eCadastroListagemGeral.Municipios)
    End Sub

    Private Sub mnuCadastroTipoCapital_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCadAdministrativo_TipoCapital.Click
        Form_Carregar_Cadastro_Listagem_Geral(Me, frmCadastroListagemGeral.eCadastroListagemGeral.Tipo_Capital)
    End Sub

    Private Sub mnuCadastroTipoDePessoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCadAdministrativo_TipoPessoa.Click
        Form_Carregar_Cadastro_Listagem_Geral(Me, frmCadastroListagemGeral.eCadastroListagemGeral.Tipo_Pessoa)
    End Sub

    Private Sub mnuCadastroTipoPessoaTributacao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCadAdministrativo_TipoPessoaTributacao.Click
        Form_Carregar_Cadastro_Listagem_Geral(Me, frmCadastroListagemGeral.eCadastroListagemGeral.Tipo_Pessoa_Tributacao)
    End Sub

    Private Sub mnuCadastroUF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCadAdministrativo_UF.Click
        Form_Carregar_Cadastro_Listagem_Geral(Me, frmCadastroListagemGeral.eCadastroListagemGeral.UF)
    End Sub

    Private Sub mnuCadastroFornecedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadFornecedor_Inclusao.Click
        Form_Show(Me, frmCadastroFornecedor)
    End Sub

    Private Sub mnuCadastroFornecedor_Historico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadFornecedor_Historico.Click
        Form_Show(Me, frmConsultaFornecedorHistorico)
    End Sub

    Private Sub mnuCadastroContato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransContato_Consulta.Click
        Form_Show(Me, frmConsultaContato)
    End Sub

    Private Sub mnuCadastroFrete_LancamentoFrete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransFrete_Consulta.Click
        Form_Show(Me, frmConsultaFrete)
    End Sub

    Private Sub mnuCadastroFrete_GerarPagamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransFrete_GerarPagamento.Click
        Form_Show(Me, frmGeraFretePagamento)
    End Sub

    Private Sub mnuCadastroFrete_PagamentoFrete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransFrete_ConsultaPagamento.Click
        Form_Show(Me, frmConsultaFretePagamento)
    End Sub

    Private Sub mnuCadastroRecuperacaoCredito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransRecuperacaoCredito_Consulta.Click
        Form_Show(Me, frmConsultaRecuperacaoCredito)
    End Sub

    Private Sub mnuCadastroSacaria_ConsultaSaldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransSacaria_ConsultaSaldo.Click
        Form_Show(Me, frmConsultaSaldoSacaria)
    End Sub

    Private Sub mnuCadastroSolicitacaoCredito_Historico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransSolicitacaoCredito_Historico.Click
        Form_Show(Me, frmHistoricoSolicitacaoCredito)
    End Sub

    Private Sub mnuPagamento_Aprovacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransPagamento_Aprovacao.Click
        Form_Show(Me, frmAprovacaoPagamento)
    End Sub

    Private Sub mnuInterface_Pagamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuInterface_Pagamento.Click
        Form_Show(Me, frmConsultaInterfacePagamento)
    End Sub

    Private Sub mnuInterface_JDE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuInterface_JDE.Click
        Form_Show(Me, frmGeraInterfaceJDE)
    End Sub

    Private Sub mnuMovimentacaoBancaria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransMovBancaria_Consulta.Click
        Form_Show(Me, frmConsultaMovimentacaoBancaria)
    End Sub

    Private Sub mnuSECCadastroUsuario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuAdministracao_ControleAcesso_CadUsuario.Click
        Form_Show(Me, frmCadastroUsuario)
    End Sub

    Private Sub mnuSECCadastroGrupoAcesso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuAdministracao_ControleAcesso_CadGrupoAcesso.Click
        Form_Show(Me, frmCadastroGrupoAcesso)
    End Sub

    Private Sub cboFilialLogada_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFilialLogada.DropDown
        If bProcInterno Then Exit Sub

        cboFilialLogada.Tag = cboFilialLogada.SelectedIndex
    End Sub

    Private Sub cboFilialLogada_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFilialLogada.SelectedIndexChanged
        If bProcInterno Then Exit Sub

        FilialLogada = 0

        If Me.MdiChildren.Length > 0 And _
           cboFilialLogada.SelectedIndex <> cboFilialLogada.Tag Then
            bProcInterno = True
            cboFilialLogada.SelectedIndex = cboFilialLogada.Tag
            Msg_Mensagem("Feche todas as janelas antes de alterar a filial logada")
            bProcInterno = False

            Exit Sub
        End If

        If cboFilialLogada.SelectedIndex > -1 Then
            FilialLogada = cboFilialLogada.SelectedItem(0)
        End If

        Libera_Filial()

        ComboBox_Possicionar(cboFilialEntrega, cboFilialLogada.SelectedItem(0))
        ComboBox_Possicionar(cboFilialEntregaCalculo, cboFilialLogada.SelectedItem(0))
    End Sub

    Private Sub mnuSECRelatorioAreaAcesso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelCtrlAcesso_AreaAcesso.Click
        Form_Show(Me, frmREL_SEC_AreaAcesso)
    End Sub

    Private Sub mnuSECRelatorioAcessoGrupoAcesso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelCtrlAcesso_AcessoGrupoAcesso.Click
        Form_Show(Me, frmREL_SEC_GrupoAcesso_Acesso)
    End Sub

    Private Sub mnuSECRelatorioAcessoUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelCtrlAcesso_AcessoUsuario.Click
        Form_Show(Me, frmREL_SEC_Usuario_Acesso)
    End Sub

    Private Sub mnuSECRelatorioCadastroUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelCtrlAcesso_CadastroUsuario.Click
        Form_Show(Me, frmREL_SEC_Usuario)
    End Sub

    Private Sub mnuSECRelatorioGrupoAcessoUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelCtrlAcesso_GrupoAcessoUsuario.Click
        Form_Show(Me, frmREL_SEC_Grupo_Usuario)
    End Sub

    Private Sub FilialNovoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadAdministrativo_Filial.Click
        Form_Carregar_Consulta_Geral(Me, frmConsultaGeral.eConsultaGeral.Filial)
    End Sub

    Private Sub FornecedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelFornecedor.Click
        Form_Show(Me, frmREL_Fornecedor)
    End Sub

    Private Sub mnuREL_MovBancaria_PorOperacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelMovBancaria_PorOperacao.Click
        Form_Show(Nothing, frmREL_MovBancaria_PorOperacao)
    End Sub

    Private Sub mnuREL_MovBancaria_ProvisaoImpostos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelMovBancaria_ProvisaoImpostos.Click
        Dim oForm As New frmRelatorioGeral_FilialPeriodo

        oForm.oTipoRelatorio = frmRelatorioGeral_FilialPeriodo.RGFP_TipoRelatorio.ProvisaoImpostos

        Form_Show(Nothing, oForm)
    End Sub

    Private Sub ListagemPagamentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelPagamento_ListagemPagamentos.Click
        Form_Show(Nothing, frmREL_Pagamento)
    End Sub

    Private Sub mnuRelConciliacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelConciliacao.Click
        Dim oRelatorio As New CrystalReportDocument

        Dim oForm As New frmRelatorioGeral_FilialPeriodo

        oForm.oTipoRelatorio = frmRelatorioGeral_FilialPeriodo.RGFP_TipoRelatorio.Conciliacao

        Form_Show(Nothing, oForm)
    End Sub

    Private Sub DivergênciaValorFreteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelFrete_DivergenciaValorFrete.Click
        Dim oForm As New frmRelatorioGeral_FilialPeriodo

        oForm.oTipoRelatorio = frmRelatorioGeral_FilialPeriodo.RGFP_TipoRelatorio.DivergenciaFrete

        Form_Show(Nothing, oForm)
    End Sub

    Private Sub mnuREL_MovBancaria_Extrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelMovBancaria_ExtratoBancario.Click
        Form_Show(Nothing, frmREL_MovBancaria_ExtratoBancario)
    End Sub

    Private Sub RecuperaçãoDeCréditoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelRecuperacaoCredito.Click
        Form_Show(Nothing, frmREL_RecuperacaoCredito)
    End Sub

    Private Sub PagamentosEmAbertoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelPagamento_PagamentosAberto.Click
        Form_Show(Nothing, frmREL_PagamentoAberto)
    End Sub

    Private Sub EstoqueSiloToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransMovCacau_EstoqueSilo.Click
        Form_Show(Me, frmConsultaEstoqueSilo)
    End Sub

    Private Sub InterfaceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuInterface_LivroFiscal_Interface.Click
        Form_Show(Me, frmGeraInterfaceLivroFiscal)
    End Sub

    Private Sub RelatórioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuInterface_LivroFiscal_Relatorio.Click
        Dim oForm As New frmRelatorioGeral_FilialPeriodo

        oForm.oTipoRelatorio = frmRelatorioGeral_FilialPeriodo.RGFP_TipoRelatorio.InterfaceLivroFiscal

        Form_Show(Nothing, oForm)
    End Sub

    Private Sub NotaDeRemessaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransMovCacau_ConsultaNotaRemessa.Click
        Form_Show(Me, frmConsultaNotaRemessa)
    End Sub

    Private Sub NotaRemessaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelMovCacau_NotaRemessa.Click
        Form_Show(Nothing, frmREL_NotaRemessa)
    End Sub

    Private Sub InclusãoMovimentaçãoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransMovCacau_InclusaoNotaFiscalComplementar.Click
        Form_Show(Me, frmCadastroMovimentacao)
    End Sub

    Private Sub mnuConsultaMovimentacaoCacau_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransMovCacau_ConsultaMovCacau.Click
        Form_Show(Me, frmConsultaMovimentacaoCacau)
    End Sub

    Private Sub ResumoDeEstoqueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelMovCacau_ResumoEstoque.Click
        Dim oForm As New frmREL_Resumo_Estoque

        oForm.oTipoRelatorio = frmREL_Resumo_Estoque.RGFP_TipoRelatorio.ResumoEstoque

        Form_Show(Nothing, oForm)
    End Sub

    Private Sub EstoqueArmazemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelMovCacau_EstoqueArmazem.Click
        Dim oForm As New frmREL_Resumo_Estoque

        oForm.oTipoRelatorio = frmREL_Resumo_Estoque.RGFP_TipoRelatorio.EstoqueArmazem

        Form_Show(Nothing, oForm)
    End Sub

    Private Sub ApuraçãoQuebraESobraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelMovCacau_ApuracaoQuebraSobra.Click
        Dim oForm As New frmRelatorioGeral_FilialPeriodo

        oForm.oTipoRelatorio = frmRelatorioGeral_FilialPeriodo.RGFP_TipoRelatorio.QuebraSobra

        Form_Show(Nothing, oForm)
    End Sub

    Private Sub CessãoDeDireitoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransMovCacau_CessaoDireito.Click
        Form_Show(Me, frmConsultaCessaoDireito)
    End Sub

    Private Sub ConsultaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransMovCacau_ConsultaMovPorEstado.Click
        Form_Show(Me, frmConsultaMovimentacaoPorEstado)
    End Sub

    Private Sub ConsultaSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransMovCacau_RecepcaoSummus.Click
        Form_Show(Me, frmConsultaSummus)
    End Sub

    Private Sub mnuRelMovCacau_MovimentacaoCacau_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelMovCacau_MovimentacaoCacau.Click
        Dim oForm As New frmREL_Movimentacao

        oForm.oTipoRelatorio = frmREL_Movimentacao.RGFP_TipoRelatorio.Fornecedor

        Form_Show(Nothing, oForm)
    End Sub

    Private Sub AplicaçãoPagamentoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransContrato_AplicacaoPagamento.Click
        Form_Show(Me, frmAplicacaoPagamento)
    End Sub

    Private Sub ContratoPAFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransContrato_InclusaoContratoPAF.Click
        Form_Show(Me, frmCadastroContratoPAF)
    End Sub

    Private Sub ContratoFixoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransContrato_InclusaoContratoFixo.Click
        Form_Show(Me, frmCadastroContratoFixo, , , , True)
    End Sub

    Private Sub ConsultaContratosNegociaõesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransContrato_ConsultaContratos.Click
        Form_Show(Me, frmConsultaContrato)
    End Sub

    Private Sub NegociaçãoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransContrato_InclusaoNegociacao.Click
        ControleEdicaoTela = eControleEdicaoTela.INCLUIR
        Filtro = Nothing
        Form_Show(Me, frmCadastroNegociacao, , , , True)
    End Sub

    Private Sub PréNegociaçãoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransContrato_InclusaoPreNegociao.Click
        Form_Show(Me, New frmCadastroPreNegociacao, , , , True)
    End Sub

    Private Sub ConsultaPréNegociaçãoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransContrato_ConsultaPreNegociacao.Click
        Form_Show(Me, frmConsultaPreNegociacao)
    End Sub

    Private Sub AmarraçãoICMSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelContrato_AmarracaoICMS.Click
        Dim oForm As New frmRelatorioGeral_FilialPeriodoFornecedor

        oForm.oTipoRelatorio = frmRelatorioGeral_FilialPeriodoFornecedor.RGFP_TipoRelatorio.AmarracaoICMS

        Form_Show(Nothing, oForm)
    End Sub

    Private Sub ContaCorrenteContratoFixoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelContrato_ContaCorrenteContratoFixo.Click
        Form_Show(Me, frmREL_ContaCorrenteContratoFixo)
    End Sub

    Private Sub ContratosFixosCanceladosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelContrato_ContratosFixosCancelados.Click
        Dim oForm As New frmRelatorioGeral_FilialPeriodo

        oForm.oTipoRelatorio = frmRelatorioGeral_FilialPeriodo.RGFP_TipoRelatorio.ContratosFixosCancelados

        Form_Show(Nothing, oForm)
    End Sub

    Private Sub NotaFiscalComplementarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelContrato_NotaFiscalComplementar.Click
        Dim oForm As New frmRelatorioGeral_FilialPeriodo

        oForm.oTipoRelatorio = frmRelatorioGeral_FilialPeriodo.RGFP_TipoRelatorio.NotaFiscalComplementar

        Form_Show(Nothing, oForm)
    End Sub

    Private Sub InformeDeComprasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelContrato_InformeCompras.Click
        Form_Show(Me, frmREL_InformeCompras)
    End Sub

    Private Sub SaldoFornecedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelSacaria_SaldoFornecedor.Click
        Dim oForm As New frmRelatorioGeral_FilialPeriodo

        oForm.oTipoRelatorio = frmRelatorioGeral_FilialPeriodo.RGFP_TipoRelatorio.SaldoSacariaFornecedor

        Form_Show(Nothing, oForm)
    End Sub

    Private Sub SaldoFilialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelSacaria_SaldoFilial.Click
        Dim oForm As New frmRelatorioGeral
        oForm.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eSaldoSacariaFilial
        Form_Show(Me, oForm)
    End Sub

    Private Sub SaldoRepassadorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelSacaria_SaldoRepassador.Click
        Dim oForm As New frmRelatorioGeral_FilialPeriodo

        oForm.oTipoRelatorio = frmRelatorioGeral_FilialPeriodo.RGFP_TipoRelatorio.SaldoSacariaRepassador

        Form_Show(Nothing, oForm)
    End Sub

    Private Sub PrevisãoBonusQualidadeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelContrato_PrevisaoBonusQualidade.Click
        Form_Show(Me, frmREL_ProvisaoBonus)
    End Sub

    Private Sub DiferêncialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelContrato_CalculoDiferencial.Click
        Form_Show(Me, frmREL_Diferencial)
    End Sub

    Private Sub EstoqueCacauToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelMovCacau_EstoqueCacau.Click
        Dim oForm As New frmREL_Resumo_Estoque

        oForm.oTipoRelatorio = frmREL_Resumo_Estoque.RGFP_TipoRelatorio.EstoqueCacau

        Form_Show(Nothing, oForm)
    End Sub

    Private Sub mnuRelContabilidade_Apuracao_Funrural_ICMS_PISCofins_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelContabilidade_Apuracao_Funrural_ICMS_PISCofins.Click
        Form_Show(Me, frmREL_Funrural_ICMS)
    End Sub

    Private Sub CacauAOrdemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelMovCacau_CacauOrdem.Click
        Form_Show(Me, frmREL_Cacau_Aordem)
    End Sub

    Private Sub ConsultaArmazemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransMovCacau_ConsultaArmazem.Click
        Form_Show(Me, frmConsultaArmazem)
    End Sub

    Private Sub mnuRelSacaria_MovimentacaoSacaria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelSacaria_MovimentacaoSacaria.Click
        Form_Show(Me, frmREL_Movimentacao_Sacaria)
    End Sub

    Private Sub RDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelContabilidade_ResumoDiarioEstoque.Click
        Form_Show(Me, frmREL_RD)
    End Sub

    Private Sub mnuCadastroSolicitacaoCredito_Inclusao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransSolicitacaoCredito_Inclusao.Click
        Form_Show(Me, New frmCadastroSolicitacaoCredito)
    End Sub

    Private Sub mnuMovBancaria_EmissaoCheque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransMovBancaria_EmissaoCheque.Click
        Form_Show(Me, frmImprimeCheque)
    End Sub

    Private Sub PosiçãoDeContratosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelContrato_PosicaoContratos.Click
        Form_Show(Me, frmREL_Posicao_Contrato)
    End Sub

    Private Sub TipoNFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadAdministrativo_TipoNF.Click
        Form_Carregar_Cadastro_Listagem_Geral(Me, frmCadastroListagemGeral.eCadastroListagemGeral.Tipo_NF)
    End Sub

    Private Sub AnaliseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadMovCacau_Analise.Click
        Form_Carregar_Cadastro_Listagem_Geral(Me, frmCadastroListagemGeral.eCadastroListagemGeral.Analise)
    End Sub

    Private Sub LocalEntregaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadAdministrativo_LocalEntrega.Click
        Form_Carregar_Cadastro_Listagem_Geral(Me, frmCadastroListagemGeral.eCadastroListagemGeral.LocalEntrega)
    End Sub

    Private Sub OrigemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadMovCacau_Origem.Click
        Form_Carregar_Cadastro_Listagem_Geral(Me, frmCadastroListagemGeral.eCadastroListagemGeral.Origem)
    End Sub

    Private Sub TipoFreteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadAdministrativo_TipoFrete.Click
        Form_Carregar_Cadastro_Listagem_Geral(Me, frmCadastroListagemGeral.eCadastroListagemGeral.Tipo_Frete)
    End Sub

    Private Sub TipoFretistaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadAdministrativo_TipoFretista.Click
        Form_Carregar_Cadastro_Listagem_Geral(Me, frmCadastroListagemGeral.eCadastroListagemGeral.Tipo_Frestista)
    End Sub

    Private Sub TipoAdendoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadAdministrativo_TipoAdendo.Click
        Form_Carregar_Cadastro_Listagem_Geral(Me, frmCadastroListagemGeral.eCadastroListagemGeral.Tipo_Adendo)
    End Sub

    Private Sub TipoCacauToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadAdministrativo_TipoCacau.Click
        Form_Carregar_Cadastro_Listagem_Geral(Me, frmCadastroListagemGeral.eCadastroListagemGeral.Tipo_Cacau)
    End Sub

    Private Sub TipoContratoPAFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadAdministrativo_TipoContratoPAF.Click
        Form_Carregar_Cadastro_Listagem_Geral(Me, frmCadastroListagemGeral.eCadastroListagemGeral.Tipo_ContratoPAF)
    End Sub

    Private Sub TipoContatoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadAdministrativo_TipoContato.Click
        Form_Carregar_Cadastro_Listagem_Geral(Me, frmCadastroListagemGeral.eCadastroListagemGeral.Tipo_Contato)
    End Sub

    Private Sub mnuConsultaFornecedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadFornecedor_Consulta.Click
        Form_Show(Me, frmConsultaFornecedor)
    End Sub


    Private Sub InclusãoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransContato_Inclusao.Click
        ControleEdicaoTela = eControleEdicaoTela.INCLUIR
        Filtro = Nothing
        Form_Show(Me, frmCadastroContato, , True)
    End Sub

    Private Sub InclusãoToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransInovacao_Inclusao.Click
        ControleEdicaoTela = eControleEdicaoTela.INCLUIR
        Filtro = Nothing
        Form_Show(Me, frmCadastroInovacao)
    End Sub

    Private Sub ConsultaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransInovacao_Consulta.Click
        Form_Show(Me, frmConsultaInovacao)
    End Sub

    Private Sub ConsultaToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransJornal_Consulta.Click
        Filtro = 1
        Form_Show(Me, frmConsultaJornal)
    End Sub

    Private Sub InclusãoToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransJornal_Inclusao.Click
        Dim oForm As New frmCadastroJornal

        oForm.Carregar(frmCadastroJornal.enTipoUtilizacaoTela.eCriacaoJornal, Nothing, 1)
        Form_Show(Me, oForm, , True)
    End Sub

    Private Sub GráficoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransBolsa_Grafico.Click
        oFormGrafico = New frmChart_Propriedade
        oFormGrafico.FormatarTela(frmChart_Propriedade.eGrafico.Logus_Bolsa)
        Form_Show_MDI(Nothing, oFormGrafico, False)
    End Sub

    Private Sub mnuCadastroSolicitacaoCredito_Consulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransSolicitacaoCredito_Consulta.Click
        Form_Show(Me, frmConsultaSolicitacaoCredito)
    End Sub

    Private Sub mnuPagamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransPagamento_Consulta.Click
        Form_Show(Me, frmConsultaPagamento)
    End Sub

    Private Sub mnuTransConciliacao_Inclusao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransConciliacao_Inclusao.Click
        ControleEdicaoTela = eControleEdicaoTela.INCLUIR
        Form_Show(Me, frmCadastroConciliacao)
    End Sub

    Private Sub mnuTransConciliacao_Consulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransConciliacao_Consulta.Click
        Form_Show(Me, frmConsultaConciliacao)
    End Sub

    Private Sub mnuTransFrete_Inclusao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransFrete_Inclusao.Click
        Form_Show(Me, frmCadastroFrete)
    End Sub

    Private Sub mnuTransGarantia_Consulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransGarantia_Consulta.Click
        Form_Show(Me, frmConsultaGarantia)
    End Sub

    Private Sub mnuTransGarantia_Inclusao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransGarantia_Inclusao.Click
        Form_Show(Me, frmCadastroGarantia)
    End Sub

    Private Sub mnuTransMovBancaria_Inclusao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransMovBancaria_Inclusao.Click
        Form_Show(Me, New frmCadastroMovimentacaoBancaria)
    End Sub

    Private Sub mnuTransMovCacau_InclusaoNFRemessa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransMovCacau_InclusaoNFRemessa.Click
        ControleEdicaoTela = eControleEdicaoTela.INCLUIR
        Form_Show(Me, frmCadastroNotaRemessa)
    End Sub

    Private Sub mnuTransPagamento_Inclusao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransPagamento_Inclusao.Click
        Form_Show(Me, New frmCadastroPagamento, , True)
    End Sub

    Private Sub mnuTransRecuperacaoCredito_Inclusao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransRecuperacaoCredito_Inclusao.Click
        Form_Show(Me, frmCadastroRecuperacaoCredito)
    End Sub

    Private Sub mnuCadFornecedor_Aniversariante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadFornecedor_Aniversariante.Click
        Form_Carregar_Consulta_Geral(Me, frmConsultaGeral.eConsultaGeral.Aniversariantes)
    End Sub

    Private Sub mnuTransBolsa_Historico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransBolsa_Historico.Click
        Form_Show(Me, frmConsultaHistoricoBolsa)
    End Sub

    Private Sub mnuAdministracao_StatusFilial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAdministracao_StatusFilial.Click
        Form_Show(Me, frmStatusFilial)
    End Sub

    Private Sub mnuCadAdministrativo_TipoAprovacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadAdministrativo_TipoAprovacao.Click
        Form_Carregar_Cadastro_Listagem_Geral(Me, frmCadastroListagemGeral.eCadastroListagemGeral.Tipo_Aprovacao)
    End Sub

    Private Sub mnuCadAdministrativo_TipoAcondicionamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadAdministrativo_TipoAcondicionamento.Click
        Form_Carregar_Cadastro_Listagem_Geral(Me, frmCadastroListagemGeral.eCadastroListagemGeral.Tipo_Acondicionamento)
    End Sub

    Private Sub mnuCadAdministrativo_TipoSacaria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadAdministrativo_TipoSacaria.Click
        Form_Carregar_Cadastro_Listagem_Geral(Me, frmCadastroListagemGeral.eCadastroListagemGeral.Tipo_Sacaria)
    End Sub

    Private Sub mnuCadAdministrativo_TipoInovacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadAdministrativo_TipoInovacao.Click
        Form_Carregar_Cadastro_Listagem_Geral(Me, frmCadastroListagemGeral.eCadastroListagemGeral.Tipo_Inovacao)
    End Sub

    Private Sub mnuCadAdministrativo_Safra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadAdministrativo_Safra.Click
        Form_Carregar_Cadastro_Listagem_Geral(Me, frmCadastroListagemGeral.eCadastroListagemGeral.Safra)
    End Sub

    Private Sub mnuCadMovCacau_Armazem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadMovCacau_Armazem.Click
        Form_Carregar_Cadastro_Listagem_Geral(Me, frmCadastroListagemGeral.eCadastroListagemGeral.Armazem)
    End Sub

    Private Sub ProcedênciaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadMovCacau_Procedencia.Click
        Form_Carregar_Cadastro_Listagem_Geral(Me, frmCadastroListagemGeral.eCadastroListagemGeral.Procedencia)
    End Sub

    Private Sub ProviToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadContabil_Provisao.Click
        Form_Carregar_Cadastro_Listagem_Geral(Me, frmCadastroListagemGeral.eCadastroListagemGeral.Provisoes)
    End Sub

    Private Sub ResumoDasOperaçõesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelContabilidade_ResumoOperacao.Click
        Form_Show(Me, frmREL_ResumoOperacoes)
    End Sub

    Private Sub TipoDeMovimentaçãoDeSacariaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadAdministrativo_TipoMovimentacaoSacaria.Click
        Form_Carregar_Cadastro_Listagem_Geral(Me, frmCadastroListagemGeral.eCadastroListagemGeral.Tipo_Movimentacao_Sacaria)
    End Sub

    Private Sub InclusãoDeConsultaDeRequisiçãoDeSacariaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransSacaria_InclusaoRequisicaoSacaria.Click
        Dim oForm As New frmRequisicaoSacaria

        oForm.Carregar(frmRequisicaoSacaria.TipoAcao.TA_Requisicao, 0)

        Form_Show(Me, oForm)
    End Sub

    Private Sub ConsultaDeRequisiçãoDeSacariaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransSacaria_ConsultaRequisicaoSacaria.Click
        Form_Show(Me, frmConsultaRequisicaoSacaria)
    End Sub

    Private Sub ConsultaDeTransferênciaEmAbertoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransSacaria_ConsultaTransferenciaAberto.Click
        Form_Show(Me, frmConusltaTransferenciaSacariaAberto)
    End Sub

    Private Sub InclusçãoDeSacariaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransSacaria_InclusaoSacariaPosicaoFilial.Click
        Form_Show(Me, frmSacaria_InclusaoFilial)
    End Sub

    Private Sub InclusãoDeSacariaNaPosiçãoDoFornecedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransSacaria_InclusaoSacariaPosicaoFornecedor.Click
        Form_Show(Me, frmSacaria_InclusaoFornecedor)
    End Sub

    Private Sub ConsultaComprasAcumuladasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransContrato_ConsultaCompraAcumulada.Click
        Form_Show(Me, frmConsultaComprasAcumuladas)
    End Sub

    Private Sub ParametrosGeraisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAdministracao_ParametroGeral.Click
        Form_Show(Me, frmParametroGeral)
    End Sub

    Private Sub ConsultaToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadFretista_Consulta.Click
        Form_Carregar_Consulta_Geral(Me, frmConsultaGeral.eConsultaGeral.Fretista)
    End Sub

    Private Sub InclusãoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadFretista_Inclusao.Click
        ControleEdicaoTela = Declaracao.eControleEdicaoTela.INCLUIR
        Form_Show(Me, frmCadastroFretista)
    End Sub

    Private Sub ConsultaDeTransferênciaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransMovCacau_ConsultaTransferencia.Click
        Form_Show(Me, frmConsultaTransferencia)
    End Sub

    Private Sub AplicaçãoDeMovimentaçãoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransContrato_AplicacaoMovimentacao.Click
        Form_Show(Me, frmAplicacaoMovimentacao)
    End Sub

    Private Sub mnuTransContrato_Rec_RevisaoContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransContrato_Rec_RevisaoContrato.Click
        Revisao_de_Contratos(True)
    End Sub

    Private Sub DevoluçãoDeCacauAoFornecedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransMovCacau_DevolucaoCacauFornecedor.Click
        Form_Show(Me, frmMovimentacaoCacau_Devolucao)
    End Sub

    Private Sub TipoRDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadAdministrativo_TipoRD.Click
        Form_Carregar_Consulta_Geral(Me, frmConsultaGeral.eConsultaGeral.Tipo_Rd)
    End Sub

    Private Sub mnuTransContrato_Rec_ArmarracaoAutomatica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransContrato_Rec_ArmarracaoAutomatica.Click
        Amarracao_Automatica(True)
    End Sub

    Private Sub AmarraçãoICMSManualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransContrato_AmarracaoManualICMS.Click
        Form_Show(Me, frmAmarracaoICMS)
    End Sub

    Private Sub UtilizaçãoSistemaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadAdministrativo_UtilizacaoSistema.Click
        Form_Carregar_Consulta_Geral(Me, frmConsultaGeral.eConsultaGeral.UtilizacaoSistema)
    End Sub

    Private Sub ModalidadeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadContabil_ModalidadeRecuperacaoCredito.Click
        Form_Carregar_Cadastro_Listagem_Geral(Me, frmCadastroListagemGeral.eCadastroListagemGeral.Modalidade_Recuperacao_Credito)
    End Sub

    Private Sub mnuTransContrato_Rec_GerarPremioQualidade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransContrato_Rec_GerarPremioQualidade.Click
        Form_Show(Me, frmGeraPremioQualidade)
    End Sub

    Private Sub PosiçãoFornecedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelContrato_PosicaoFornecedor.Click
        Form_Show(Me, frmREL_Posicao_Fornecedor)
    End Sub

    Private Sub NetDeSaldosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelContrato_NetSaldos.Click
        Form_Show(Me, frmREL_Net_Saldo)
    End Sub

    Private Sub mnuRelMovCacau_TransferenciaData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelMovCacau_TransferenciaData.Click
        Form_Show(Me, frmREL_Transferencia)
    End Sub

    Private Sub tmrBolsa_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrBolsa.Tick
        AtualizaPrecoBolsa()
        AtualizacaoCalculoDiferencial()
    End Sub

    Private Sub FotografiaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadFornecedor_Fotografia.Click
        Form_Show(Me, frmFotografiaFornecedor)
    End Sub

    Private Sub GrupoTipoMovimentaçãoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadMovCacau_GrupoTipoMovimentacao.Click
        Dim oForm As New frmConsultaGeral

        oForm.FiltroLocal_01 = 22 'Processo
        oForm.FiltroLocal_02 = 1 'Status
        oForm.FormatarTela(frmConsultaGeral.eConsultaGeral.GrupoTipoMovimentacao)

        Form_Show(Me, oForm, , , True)
    End Sub

    Private Sub OperaçãoBancariaXTipoMovimentaçãoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadContabil_OperacaoBancariaTipoMovimentacao.Click
        Form_Carregar_Consulta_Geral(Me, frmConsultaGeral.eConsultaGeral.OperacaoBancariaTipoMovimentacao)
    End Sub

    Private Sub ParametroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransBolsa_Parametro.Click
        Form_Show(Me, frmParametroBolsa)
    End Sub

    Private Sub mnuTransContrato_Rec_PremioQualidadeInativo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransContrato_Rec_PremioQualidadeInativo.Click
        Form_Carregar_Consulta_Geral(Me, frmConsultaGeral.eConsultaGeral.PremioQualidadeInativo)
    End Sub

    Private Sub ContaCorrenteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadContabil_ContaCorrente.Click
        Form_Carregar_Cadastro_Listagem_Geral(Me, frmCadastroListagemGeral.eCadastroListagemGeral.ContaCorrente)
    End Sub

    Private Sub TipoPagamentoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadAdministrativo_TipoPagamento.Click
        Form_Carregar_Consulta_Geral(Me, frmConsultaGeral.eConsultaGeral.TipoPagamento)
    End Sub

    Private Sub TipoRDToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadAdministrativo_TipoRD.Click
        Form_Carregar_Consulta_Geral(Me, frmConsultaGeral.eConsultaGeral.Tipo_Rd)
    End Sub

    Private Sub AberturaDiaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAdministracao_AbreDia.Click
        Form_Show(Me, frmAbreDia)
    End Sub

    Private Sub OperaçãoBancariaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadContabil_OperacaoBancaria.Click
        Form_Carregar_Consulta_Geral(Me, frmConsultaGeral.eConsultaGeral.OperaracaoBancaria)
    End Sub

    Private Sub ItensBranchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadContabil_ItensBranch.Click
        Form_Carregar_Consulta_Geral(Me, frmConsultaGeral.eConsultaGeral.ItensBranch)
    End Sub

    Private Sub TipoNegociaçãoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadAdministrativo_TipoNegociacao.Click
        Form_Carregar_Cadastro_Listagem_Geral(Me, frmCadastroListagemGeral.eCadastroListagemGeral.Tipo_Negociacao)
    End Sub

    Private Sub mnuAdministracao_AcertoRD_Movimentacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAdministracao_AcertoRD_Movimentacao.Click
        Form_Show(Me, frmAcertoRD_Movimentacao)
    End Sub

    Private Sub ValorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAdministracao_AcertoRD_Valor.Click
        Form_Show(Me, frmAcertoRD_Valor)
    End Sub

    Private Sub mnuTransContrato_Rec_AplicacaoAutomatica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransContrato_Rec_AplicacaoAutomatica.Click
        Form_Show(Me, frmAplicacaoAutomatica)
    End Sub

    Private Sub TipoDeGarantiaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadAdministrativo_TipoGarantia.Click
        Form_Carregar_Cadastro_Listagem_Geral(Me, frmCadastroListagemGeral.eCadastroListagemGeral.Tipo_Garantia)
    End Sub

    Private Sub TipoDescontoQualidadeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadAdministrativo_TipoDescontoQualidade.Click
        Form_Carregar_Cadastro_Listagem_Geral(Me, frmCadastroListagemGeral.eCadastroListagemGeral.Tipo_Desconto_Qualidade)
    End Sub

    Private Sub TipoFretistaTributaçãoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadAdministrativo_TipoFretistaTributacao.Click
        Form_Carregar_Consulta_Geral(Me, frmConsultaGeral.eConsultaGeral.TipoFretistaTributacao)
    End Sub

    Private Sub TipoDeMovimentaçãoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadAdministrativo_TipoMovimentacao.Click
        Form_Carregar_Consulta_Geral(Me, frmConsultaGeral.eConsultaGeral.TipoMovimentacao)
    End Sub

    Private Sub BônusPadrãoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadAdministrativo_BonusPadrao.Click
        Form_Carregar_Consulta_Geral(Me, frmConsultaGeral.eConsultaGeral.BonusPadrao)
    End Sub

    Private Sub ModalidadeConciliaçãoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadContabil_ModalidadeConciliacao.Click
        Form_Carregar_Consulta_Geral(Me, frmConsultaGeral.eConsultaGeral.ModalidadeConciliacao)
    End Sub

    Private Sub AdiantamentosEmAbertoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelPagamento_AdiantamentoEmAberto.Click
        Form_Show(Me, frmREL_Adiantamento_Em_Aberto)
    End Sub

    Private Sub mnuRelContabilidade_ComposicaoSaldoContaFornecedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelContabilidade_ComposicaoSaldoContaFornecedor.Click
        Form_Show(Me, frmREL_Saldo_Fornecedor)
    End Sub

    Private Sub PreçoMédioGeralToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelContrato_PrecoMedioGeral.Click
        Form_Show(Me, frmREL_Preco_Medio)
    End Sub

    Private Sub ContratosEmAbertoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelContrato_ContratosEmAberto.Click
        Form_Show(Me, frmREL_Contratos_Em_Aberto)
    End Sub

    Private Sub ListagemDeContratosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelContrato_ListagemContratos.Click
        Form_Show(Me, frmREL_Contratos_Listagem)
    End Sub

    Private Sub DadosDaBolsaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransBolsa_DadosBolsa.Click
        Form_Show(Me, frmConsultaDadosBolsa)
    End Sub

    Private Sub BranchesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelContabilidade_Branches.Click
        Form_Show(Me, frmREL_Branches)
    End Sub

    Private Sub mnuRelContabilidade_AdiantamentoExposure_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelContabilidade_AdiantamentoExposure.Click
        Form_Show(Me, frmREL_AdiantamentoExposure)
    End Sub

    Private Sub mnuRelContabilidade_NotaFiscalComplementarContabil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelContabilidade_NotaFiscalComplementarContabil.Click
        Dim oForm As New frmREL_PrecoMedioNFComplementa

        oForm.oTipoRelatorio = frmREL_PrecoMedioNFComplementa.RGFP_TipoRelatorio.NFComplementar

        Form_Show(Nothing, oForm)
    End Sub

    Private Sub mnuRelContabilidade_PrecoMedioContabil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelContabilidade_PrecoMedioContabil.Click
        Dim oForm As New frmREL_PrecoMedioNFComplementa

        oForm.oTipoRelatorio = frmREL_PrecoMedioNFComplementa.RGFP_TipoRelatorio.PrecoMedio

        Form_Show(Nothing, oForm)
    End Sub

    Private Sub mnuRelContrato_NegociacaoAbertoFixacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelContrato_NegociacaoAbertoFixacao.Click
        Form_Show(Me, frmREL_NegociacoesAbertoComFixacoes)
    End Sub

    Private Sub ContaCorrenteFornecedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelContrato_ContaCorrenteFornecedor.Click
        Form_Show(Me, frmREL_ContaCorrenteFornecedor)
    End Sub

    Private Sub Rodape_Inicializar()
        With Rodape
            Rodape_Data.Text = ""
            Rodape_Usuario.Text = ""
            Rodape_Safra.Text = ""
            Rodape_Banco.Text = ""
            Rodape_StatusFilial.Text = ""
            Rodape_StatusFilial.BackColor = System.Drawing.SystemColors.Control
        End With
    End Sub

    Private Sub Rodape_Formatar()
        Dim oData As DataTable

        oData = DBQuery("SELECT PRM.DT_SISTEMA, PRM.CD_SAFRA, SFR.DS_SAFRA" & _
                        " FROM SOF.PARAMETRO PRM," & _
                              "SOF.SAFRA SFR" & _
                        " WHERE SFR.CD_SAFRA = PRM.CD_SAFRA")

        With Rodape
            Rodape_Data_Atualizar(objDataTable_LerCampo(oData.Rows(0).Item("DT_SISTEMA"), ""))
            Rodape_Usuario.Text = sAcesso_NomeUsuarioLogado
            Rodape_Safra.Text = Trim(objDataTable_LerCampo(oData.Rows(0).Item("DS_SAFRA"), "")) & ": " & _
                                objDataTable_LerCampo(oData.Rows(0).Item("CD_SAFRA"), "")
            Rodape_Banco.Text = sBancoDados_BancoDadosLogado
        End With

        objData_Finalizar(oData)
    End Sub

    Public Sub Rodape_Data_Atualizar(ByVal Data As String)
        Rodape_Data.Text = Data
    End Sub

    Private Sub Rodape_StatusFiilal(ByVal Aberta As Boolean)
        Rodape_StatusFilial.Text = IIf(Aberta, "  Filial Aberta  ", "  Filial Fechada  ")
        Rodape_StatusFilial.ForeColor = Color.White
        Rodape_StatusFilial.BackColor = IIf(Aberta, Color.Green, Color.Red)
    End Sub

    Public Sub Libera_Filial()
        Dim SqlText As String

        SqlText = "SELECT IC_FECHADA FROM SOF.FILIAL WHERE CD_FILIAL = " & FilialLogada
        FilialLogada_Fechada = (DBQuery_ValorUnico(SqlText, "S") = "S")

        SEC_SomenteConsulta = FilialLogada_Fechada
        Rodape_StatusFiilal(Not FilialLogada_Fechada)
        SqlText = "SELECT PRM.DT_SISTEMA FROM SOF.PARAMETRO PRM"
        Rodape_Data_Atualizar(DBQuery_ValorUnico(SqlText, ""))
        Menu_ValidarAcesso()
    End Sub

    Private Sub Rodape_StatusFilial_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rodape_StatusFilial.DoubleClick
        Libera_Filial()
    End Sub

    Private Sub mnuVisualizar_ValorCotacaoBolsa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVisualizar_ValorCotacaoBolsa.Click
        UDM.ControlPanes(cnt_DockPanel_ValorCotacaoBolsa).Show()
        UDM.ControlPanes(cnt_DockPanel_ValorCotacaoBolsa).Pinned = Not UDM.ControlPanes(cnt_DockPanel_ValorCotacaoBolsa).Pinned
    End Sub

    Private Sub mnuVisualizar_Atalho_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuVisualizar_Atalho.Click
        UDM.ControlPanes(cnt_DockPanel_Atalho).Show()
    End Sub

    Private Sub mnuVisualizar_Recente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuVisualizar_Recente.Click
        UDM.ControlPanes(cnt_DockPanel_Recente).Show()
    End Sub

    Private Sub mnuAdministracao_FechaDia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAdministracao_FechaDia.Click
        Fecha_Dia()
    End Sub

    Private Sub Rodape_Banco_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rodape_Banco.DoubleClick
        If Trim(Rodape_Banco.Text) <> "ILH01P" Then
            DBDesconectar()
            System.Web.Configuration.WebConfigurationManager.AppSettings("SERVER") = "ILH01P"
            DBConectar()
            'Cria o contole de usuário ativo no banco
            DBExecutar("DELETE FROM SOF.TMP_CONECCAO")
            DBExecutar("INSERT INTO SOF.TMP_CONECCAO VALUES  (" & QuotedStr(sAcesso_UsuarioLogado) & ")")
            Rodape_Banco.Text = "ILH01P"
            ComboBox_Carregar_Bolsa(cboBolsa)
        End If
    End Sub

    Private Sub cboFilialEntregaCalculo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFilialEntregaCalculo.SelectedIndexChanged
        If bProcInterno = True Then Exit Sub

        ComboBox_Possicionar(cboFilialEntrega, cboFilialEntregaCalculo.SelectedValue)
        AtualizacaoCalculoDiferencial()
    End Sub

    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton1.Click
        AtualizaPrecoBolsa()
        AtualizacaoCalculoDiferencial()
    End Sub

    Private Sub txtDiferencial_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiferencial.ValueChanged
        AtualizacaoCalculoDiferencial()
    End Sub

    Private Sub txtValorAroba_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValorAroba.ValueChanged
        AtualizacaoCalculoDiferencial()
    End Sub

    Private Sub mnuVisualizar_CalculoDiferencial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVisualizar_CalculoDiferencial.Click
        UDM.ControlPanes(cnt_DockPanel_CalculoDiferencial).Show()
        UDM.ControlPanes(cnt_DockPanel_CalculoDiferencial).Pinned = Not UDM.ControlPanes(cnt_DockPanel_CalculoDiferencial).Pinned
    End Sub

    Private Sub tlbIcones_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles tlbIcones.ToolClick
        'Dim Menu As New MenuStrip
        'Select Case e.Tool.Key
        '    Case "Fornecedor"

        '        Menu.Items.Add("Fornecedor")
        '        Menu.Show(e.Tool, Nothing)


        '        mnuCadFornecedor.ShowDropDown()
        '    Case "Bolsa"
        '        mnuTransBolsa.ShowDropDown()
        'End Select
    End Sub

    Private Sub mnuRelMovCacau_AplicCtrFixo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelMovCacau_AplicCtrFixo.Click
        Dim oForm As New frmRelatorioGeral_FilialPeriodoFornecedor

        oForm.oTipoRelatorio = frmRelatorioGeral_FilialPeriodoFornecedor.RGFP_TipoRelatorio.AplicacaoContratoFixo

        Form_Show(Nothing, oForm)
    End Sub

    Private Sub mnuRelMovCacau_PorFilial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelMovCacau_PorFilial.Click
        Dim oForm As New frmREL_Movimentacao

        oForm.oTipoRelatorio = frmREL_Movimentacao.RGFP_TipoRelatorio.Filial

        Form_Show(Nothing, oForm)
    End Sub

    Private Sub mnuRelContabilidade_FluxoCaixa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelContabilidade_FluxoCaixa.Click
        Form_Show(Me, frmREL_Fluxo_Caixa)
    End Sub

    Private Sub mnuRelMovCacau_AbertoNegociacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelMovCacau_AbertoNegociacao.Click
        Dim oForm As New frmRelatorioGeral_FilialPeriodo

        oForm.oTipoRelatorio = frmRelatorioGeral_FilialPeriodo.RGFP_TipoRelatorio.MovimentacaoEmNegociacao

        Form_Show(Nothing, oForm)
    End Sub

    Private Sub mnuRelContrato_AplicacoesEmContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelContrato_AplicacoesEmContrato.Click
        Form_Show(Me, frmREL_Aplicacoes)
    End Sub

    Private Sub MovimentaçãoPorMunicipioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MovimentaçãoPorMunicipioToolStripMenuItem.Click
        Dim oForm As New frmRelatorioGeral_FilialPeriodo

        oForm.oTipoRelatorio = frmRelatorioGeral_FilialPeriodo.RGFP_TipoRelatorio.MovimentacaoPorMunicipio

        Form_Show(Nothing, oForm)
    End Sub

    Private Sub ContratosComSaldoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContratosComSaldoToolStripMenuItem.Click
        Form_Show(Me, frmREL_ContratosComSaldo)
    End Sub

    Private Sub cboBolsa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBolsa.SelectedIndexChanged
        AtualizaPrecoBolsa()
        AtualizacaoCalculoDiferencial()
    End Sub

    Private Sub ConferênciaContabilToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConferênciaContabilToolStripMenuItem.Click
        Form_Show(Me, frmREL_ConferenciaContabil)
    End Sub

    Private Sub cmdCopiarValores_CalculoDiferencial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopiarValores_CalculoDiferencial.Click
        Dim sTexto As String

        sTexto = "Cálculo de Diferencial" & vbCrLf & _
                 "- Cotação: " & txtCotacaoCalculo.Value & vbCrLf & _
                 "- Diferencial: " & txtDiferencaCalculo.Text & vbCrLf & _
                 "- Taxa do Dólar: " & Replace(txtDolarCalculo.Text, "_", "")

        Clipboard.Clear()
        Clipboard.SetText(sTexto)
    End Sub

    Private Sub cmdCopiarValores_Cotacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopiarValores_Cotacao.Click
        Dim sTexto As String

        sTexto = "Cotação da Bolsa" & vbCrLf & _
                 "- Cotação: " & txtCotacao.Value & vbCrLf & _
                 "- Diferencial: " & txtDiferenca.Text & vbCrLf & _
                 "- Taxa do Dólar: " & Replace(txtDolar.Text, "_", "")

        Clipboard.Clear()
        Clipboard.SetText(sTexto)
    End Sub

    Private Sub mnuTransContrato_EstornoDeDesagio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransContrato_EstornoDeDesagio.Click
        Form_Show(Me, frmEstornoDesagio)
    End Sub

    Private Sub mnuTransContrato_AprovacaoEstornoDesagio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransContrato_AprovacaoEstornoDesagio.Click
        Form_Show(Me, frmAprovacaoEstornoDesagio)
    End Sub

    Private Sub mnuRelMovCacau_MovimentacaoCacau_DataCacau_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelMovCacau_MovimentacaoCacau_DataCacau.Click
        Form_Show(Me, frmREL_Movimentacao_DataCacau)
    End Sub

    Private Sub mnuRelContrato_PosicaoEstoqueCacauSaldoFinanceiro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelContrato_PosicaoEstoqueCacauSaldoFinanceiro.Click
        Form_Show(Me, frmREL_PosEstoqueCacau_SaldoFinanceiro)
    End Sub

    Private Sub mnuCadAdministrativo_Armazem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadAdministrativo_Armazem.Click
        Form_Carregar_Consulta_Geral(Me, frmConsultaGeral.eConsultaGeral.Armazem)
    End Sub

    Private Sub mnuTransMovCacau_MovimentarDentroArmazem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransMovCacau_MovimentarDentroArmazem.Click
        Form_Show(Me, frmMovimentacaoCacau_MovimentarLote)
    End Sub

    Private Sub mnuTransContrato_AprovacaoRenegociacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransContrato_AprovacaoRenegociacao.Click
        Form_Show(Me, frmCadastroReNegociacao_Aprovacao, , , True)
    End Sub

    Private Sub mnuRelcontabilidade_RevalorizacaoCacau_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelcontabilidade_RevalorizacaoCacau.Click
        Form_Show(Me, frmREL_Cacau_Aordem_Valorizacao, , , True)
    End Sub

    Private Sub mnuRelMovCacau_ValorizacaoIndustrializacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelMovCacau_ValorizacaoIndustrializacao.Click
        Form_Show(Me, frmREL_Industrializacao, , , True)
    End Sub

    Private Sub mnuRelMovCacau_ListagemFreteRecepcaoCacau_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelMovCacau_ListagemFreteRecepcaoCacau.Click
        Form_Show(Me, frmREL_ListagemFrete_Recepcao, , , True)
    End Sub

    Private Sub frmRelMovCacau_ProvisaoNFComplementar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelMovCacau_ProvisaoNFComplementar.Click
        Form_Show(Me, frmREL_ProvisaoNFComplementar, , , True)
    End Sub

    Private Sub mnuRelMovCacau_ControleQuebraTransferencias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelMovCacau_ControleQuebraTransferencias.Click
        Dim oForm As New frmREL_Transferencia

        oForm.oTipoRelatorio = frmREL_Transferencia.RGFP_TipoRelatorio.Transferencia_ControleQuebraTransferencias

        Form_Show(Nothing, oForm)
    End Sub

    Private Sub mnuCadMovCacau_GrupoRD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadMovCacau_GrupoRD.Click
        Dim oForm As New frmConsultaGeral

        oForm.FiltroLocal_01 = 22 'processo
        oForm.FiltroLocal_02 = 2 'status
        oForm.FormatarTela(frmConsultaGeral.eConsultaGeral.GrupoTipoMovimentacao)

        Form_Show(Me, oForm, , , True)
    End Sub

    Private Sub mnuRelContabilidade_CashTrade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelContabilidade_CashTrade.Click
        Dim oForm As New frmREL_PrecoMedioNFComplementa

        oForm.oTipoRelatorio = frmREL_PrecoMedioNFComplementa.RGFP_TipoRelatorio.CashTrade

        Form_Show(Nothing, oForm)
    End Sub

    Private Sub mnuTransResumoDiarioEstoque_Consulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransResumoDiarioEstoque_Consulta.Click
        Form_Show(Me, frmConsultaRD)
    End Sub

    Private Sub mnuTransResumoDiarioEstoque_LancamentoAjuste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransResumoDiarioEstoque_LancamentoAjuste.Click
        Form_Show(Me, frmConsultaAjuste_RDE)
    End Sub

    Private Sub mnuTransMinhasPendencias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransMinhasPendencias.Click
        Form_Show(Me, frmControle_AprovacaoPendente)
    End Sub

    Private Sub mnuRelContabilidade_AjusteRD_Estoque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelContabilidade_AjusteRD_Estoque.Click
        Form_Show(Me, frmREL_Ajuste_RDE, , , True)
    End Sub

    Private Sub mnuRelMovCacau_UmidadeMedia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelMovCacau_UmidadeMedia.Click
        Form_Show(Me, frmREL_UmidadeMedia, , , True)
    End Sub

    Private Sub mnuRelContabilidade_SldFornecedorCtrFixo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelContabilidade_SldFornecedorCtrFixo.Click
        Dim oForm As New frmREL_PrecoMedioNFComplementa

        oForm.oTipoRelatorio = frmREL_PrecoMedioNFComplementa.RGFP_TipoRelatorio.SaldoFinanceiro_CtrFixo

        Form_Show(Nothing, oForm)
    End Sub

    Private Sub mnuRelGeracaoAutomatica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelGeracaoAutomatica.Click
        Form_Show(Me, frmRelatorioGeracaoAutomatica, , , True)
    End Sub

    Private Sub mnuTransPDD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransPDD.Click
        Form_Show(Me, frmConsultaPDD, , , True)
    End Sub

    Private Sub mnuRelContabilidade_PDD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelContabilidade_PDD.Click
        Form_Show(Me, frmREL_PDD)
    End Sub

    Private Sub mnuRelContabilidade_PISCofins_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelContabilidade_PISCofins.Click
        Form_Show(Me, frmREL_PISCofins)
    End Sub
End Class