Module MOD_Chart_Local
    Public Sub Chart_CarregarTelaChart(ByVal oFormMDI As Windows.Forms.Form, _
                                       ByVal iTipoTela As frmChart_Propriedade.eGrafico)
        Select Case iTipoTela
            Case frmChart_Propriedade.eGrafico.Logus_Contato
                Form_Show_MDI(oFormMDI, New frmGRF_Contato)
            Case frmChart_Propriedade.eGrafico.Logus_Bolsa
                Form_Show_MDI(oFormMDI, New frmGRF_Bolsa)
        End Select
    End Sub
End Module
