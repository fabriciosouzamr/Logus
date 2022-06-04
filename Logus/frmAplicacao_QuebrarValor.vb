Public Class frmAplicacao_QuebrarValor
    Public Enum enTipo_Aplicacao_Contrato
        tacPAG = 1
        tacREC = 2
    End Enum

    Dim oTipo_Aplicacao_Contrato As enTipo_Aplicacao_Contrato

    Public Cancelado As Boolean = True

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Cancelado = True
        Close()
    End Sub

    Private Sub frmAprovacaoPagamento_QuebrarValor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If oTipo_Aplicacao_Contrato = enTipo_Aplicacao_Contrato.tacPAG Then
            lblQuantidadeMaxima.Visible = False
            txtQuantidadeMaxima.Visible = False
            lblQuantidadeSolicitada.Visible = False
            txtQuantidadeSolicitada.Visible = False
        End If
    End Sub

    Public Property ValorMaximo() As Double
        Get
            Return txtValorMaximo.Value
        End Get
        Set(ByVal Valor As Double)
            txtValorMaximo.Value = Valor
        End Set
    End Property

    Public Property QuantidadeMaxima() As Double
        Get
            Return txtQuantidadeMaxima.Value
        End Get
        Set(ByVal Valor As Double)
            txtQuantidadeMaxima.Value = Valor
        End Set
    End Property

    Public ReadOnly Property ValorSolicitado() As Double
        Get
            Return txtValorSolicitado.Value
        End Get
    End Property

    Public ReadOnly Property QuantidadeSolicitada() As Double
        Get
            Return txtQuantidadeSolicitada.Value
        End Get
    End Property

    Public Property Tipo_Aplicacao_Contrato() As enTipo_Aplicacao_Contrato
        Get
            Return oTipo_Aplicacao_Contrato
        End Get
        Set(ByVal Valor As enTipo_Aplicacao_Contrato)
            oTipo_Aplicacao_Contrato = Valor
        End Set
    End Property

    Private Sub cmdGravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        If txtValorSolicitado.Value > txtValorMaximo.Value Then
            Msg_Mensagem("Valor solicitado maior que o valor maximo.")
            txtValorMaximo.Focus()
            Exit Sub
        End If
        If oTipo_Aplicacao_Contrato = enTipo_Aplicacao_Contrato.tacREC Then
            If txtQuantidadeSolicitada.Value > txtQuantidadeMaxima.Value Then
                Msg_Mensagem("Quantidade solicitada maior do que a quantidade maxima.")
                txtQuantidadeMaxima.Focus()
                Exit Sub
            End If
        End If

        Cancelado = False

        Close()
    End Sub

    Private Sub txtQuantidadeSolicitada_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuantidadeSolicitada.ValueChanged
        If Me.txtQuantidadeMaxima.Value = 0 Then
            txtValorSolicitado.Value = 0
        Else
            txtValorSolicitado.Value = (txtQuantidadeSolicitada.Value / txtQuantidadeMaxima.Value) * txtValorMaximo.Value
        End If
    End Sub
End Class