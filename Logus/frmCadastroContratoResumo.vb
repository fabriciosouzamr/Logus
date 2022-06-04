Public Class frmCadastroContratoResumo
    Const cnt_GridResumo_TipoPessoa As Integer = 0
    Const cnt_GridResumo_ValorR As Integer = 1
    Const cnt_GridResumo_ValorUS As Integer = 2
    Const cnt_GridResumo_Quantidade As Integer = 3

    Public Par_SubTotal_01 As Double
    Public Par_SubTotal_02 As Double
    Public Par_SubTotal_03 As Double
    Public Par_Cancelados_01 As Double
    Public Par_Cancelados_02 As Double
    Public Par_Cancelados_03 As Double
    Public Par_Total_01 As Double
    Public Par_Total_02 As Double
    Public Par_Total_03 As Double

    Enum TipoTela
        ContratoFixo = 1
        ContratoNegociacao = 2
        ContratoPAF = 3
    End Enum

    Dim oDS As New Infragistics.Win.UltraWinDataSource.UltraDataSource

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Public Sub Carregar(ByVal oTipoTela As TipoTela, ByVal oData As DataTable)
        objGrid_Inicializar(grdResumo, , oDS, Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect)
        objGrid_Coluna_Add(grdResumo, "Tipo de Pessoa", 200)
        objGrid_Coluna_Add(grdResumo, "Valor R$", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdResumo, "Valor US$", 100, , , , , cnt_Formato_Valor_US)
        objGrid_Coluna_Add(grdResumo, "Quantidade", 100, , , , , cnt_Formato_NumeroInteiro, , True)

        Select Case oTipoTela
            Case TipoTela.ContratoFixo
                grdResumo.DisplayLayout.Bands(0).Columns(cnt_GridResumo_ValorUS).Hidden = True

                txtSubTotal_02.Visible = False
                txtCancelados_02.Visible = False
                txtTotal_02.Visible = False
            Case TipoTela.ContratoNegociacao
                grdResumo.DisplayLayout.Bands(0).Columns(cnt_GridResumo_ValorR).Hidden = True

                txtSubTotal_01.Visible = False
                txtCancelados_01.Visible = False
                txtTotal_01.Visible = False
                txtSubTotal_02.Visible = False
                txtCancelados_02.Visible = False
                txtTotal_02.Visible = False
            Case TipoTela.ContratoPAF
                grdResumo.DisplayLayout.Bands(0).Columns(cnt_GridResumo_ValorR).Hidden = True
                grdResumo.DisplayLayout.Bands(0).Columns(cnt_GridResumo_ValorUS).Hidden = True

                txtSubTotal_01.Visible = False
                txtCancelados_01.Visible = False
                txtTotal_01.Visible = False
                txtSubTotal_02.Visible = False
                txtCancelados_02.Visible = False
                txtTotal_02.Visible = False
        End Select

        txtSubTotal_01.Value = Par_SubTotal_01
        txtSubTotal_02.Value = Par_SubTotal_02
        txtSubTotal_03.Value = Par_SubTotal_03
        txtCancelados_01.Value = Par_Cancelados_01
        txtCancelados_02.Value = Par_Cancelados_02
        txtCancelados_03.Value = Par_Cancelados_03
        txtTotal_01.Value = Par_Total_01
        txtTotal_02.Value = Par_Total_02
        txtTotal_03.Value = Par_Total_03

        Dim iCont As Integer

        For iCont = 0 To oData.Rows.Count - 1
            oDS.Rows.Add()

            With oDS.Rows(oDS.Rows.Count - 1)
                .Item(cnt_GridResumo_TipoPessoa) = oData.Rows(iCont).Item("NO_TIPO_PESSOA")
                .Item(cnt_GridResumo_ValorR) = oData.Rows(iCont).Item("VALOR")
                .Item(cnt_GridResumo_ValorUS) = oData.Rows(iCont).Item("VALOR_US")
                .Item(cnt_GridResumo_Quantidade) = oData.Rows(iCont).Item("QUANTIDADE")
            End With
        Next
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdResumo, Me.Text, cmdExcell)
    End Sub
End Class