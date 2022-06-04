Imports Infragistics.Win

Public Class frmPesq_Municipio
    Const cnt_GridGeral_CD_MUNICIPIO As Integer = 0
    Const cnt_GridGeral_NO_CIDADE As Integer = 1
    Const cnt_GridGeral_CD_UF As Integer = 2
    Const cnt_GridGeral_NO_UF As Integer = 3

    Dim oPesq_CodigoNome As Pesq_CodigoNome
    Dim oDS As New UltraWinDataSource.UltraDataSource
    Dim oFiltro As Collection

    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Close()
    End Sub

    Property Form_Pesq_Filtro() As Collection
        Get
            Return oFiltro
        End Get
        Set(ByVal Valor As Collection)
            oFiltro = Valor
        End Set
    End Property

    Property Form_Pesq_CodigoNome() As Pesq_CodigoNome
        Get
            Return oPesq_CodigoNome
        End Get
        Set(ByVal Valor As Pesq_CodigoNome)
            oPesq_CodigoNome = Valor
        End Set
    End Property

    Private Sub frmPesq_ContratoPAF_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        objGrid_Inicializar(grdGeral, , oDS, Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect, , , True)
        objGrid_Coluna_Add(grdGeral, "CD_MUNICIPIO", 0)
        objGrid_Coluna_Add(grdGeral, "Município", 250)
        objGrid_Coluna_Add(grdGeral, "Código da U.F.", 100)
        objGrid_Coluna_Add(grdGeral, "Nome da U.F.", 250)

        ComboBox_Carregar_UF(cboUnidadeFederativa, True)
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String

        If Trim(txtNomeMunicipio.Text) = "" And Not ComboBox_LinhaSelecionada(cboUnidadeFederativa) Then
            Msg_Mensagem("Informe pelo uma informação para o filtro")
            Exit Sub
        End If

        SqlText = "SELECT MC.CD_MUNICIPIO," & _
                         "MC.NO_CIDADE," & _
                         "UF.CD_UF," & _
                         "UF.NO_UF" & _
                  " FROM SOF.MUNICIPIO MC," & _
                        "SOF.UF UF" & _
                  " WHERE UF.CD_UF = MC.CD_UF"

        If Trim(txtNomeMunicipio.Text) <> "" Then
            SqlText = SqlText & " AND MC.NO_CIDADE LIKE " & SQL_FormatarLike(Trim(txtNomeMunicipio.Text))
        End If
        If ComboBox_LinhaSelecionada(cboUnidadeFederativa) Then
            SqlText = SqlText & " AND UF.CD_UF = " & QuotedStr(cboUnidadeFederativa.SelectedValue)
        End If

        If Not oFiltro Is Nothing Then
            If oFiltro.Count > 0 Then
                SqlText = SqlText & Montar_Filtro(oFiltro)
            End If
        End If

        SqlText = SqlText & _
                   " ORDER BY MC.NO_CIDADE"

        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_CD_MUNICIPIO, cnt_GridGeral_NO_CIDADE, _
                                                           cnt_GridGeral_CD_UF, cnt_GridGeral_NO_UF})
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsulta()
    End Sub

    Private Sub cmdSelecionar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSelecionar.Click
        RegistroSelecionado()
    End Sub

    Private Sub RegistroSelecionado()
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        With oPesq_CodigoNome
            .TelaFiltro = True
            .Codigo = objGrid_Valor(grdGeral, cnt_GridGeral_CD_MUNICIPIO)
            .TelaFiltro = False
        End With

        Close()
    End Sub

    Private Sub grdGeral_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles grdGeral.DoubleClickRow
        RegistroSelecionado()
    End Sub
End Class