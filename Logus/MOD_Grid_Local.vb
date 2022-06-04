Imports Infragistics.Win.UltraWinGrid

Module MOD_Grid_Local
    Const cnt_PopUp_Menu_EscolheColuna As String = "Escolhe de Coluna"
    Const cnt_PopUp_Menu_Copiar As String = "Copiar"

    Private oFormGridEscolheColuna As frmGridEscolheColuna = Nothing
    Private WithEvents oMenu As System.Windows.Forms.ContextMenuStrip

    Public Sub objGrid_Formatar(ByVal oGrid As UltraGrid)
        '>> Criação do itens do popupmenu
        oMenu = New System.Windows.Forms.ContextMenuStrip

        oMenu.Tag = oGrid
        oMenu.Items.Add("Escolhe de Coluna", Nothing, New EventHandler(AddressOf PopUp_EscolheColuna_Click))
        oMenu.Items.Add("Copiar", Nothing, New EventHandler(AddressOf Copiar_Click))

        'oMenu.Items.Add(cnt_PopUp_Menu_EscolheColuna)

        oGrid.ContextMenuStrip = oMenu
    End Sub

    'Private Sub PopUp_EscolheColuna()
    Private Sub PopUp_EscolheColuna_Click(ByVal Sender As System.Object, ByVal e As System.EventArgs)
        Dim oMenu As System.Windows.Forms.ToolStripMenuItem
        Dim a As String = ""

        oMenu = Sender

        If Nothing Is oFormGridEscolheColuna OrElse oFormGridEscolheColuna.IsDisposed Then
            oFormGridEscolheColuna = New frmGridEscolheColuna()
            oFormGridEscolheColuna.Owner = oMenu.Owner.Tag.Parent
            oFormGridEscolheColuna.Grid = oMenu.Owner.Tag
        End If

        Form_Show(oMenu.Owner.Tag.Parent, oFormGridEscolheColuna, True)
    End Sub

    Private Sub Copiar_Click(ByVal Sender As System.Object, ByVal e As System.EventArgs)
        Dim oGrid As UltraGrid
        Dim texto As String
        Clipboard.Clear()
        oGrid = oMenu.Tag
        oGrid.DisplayLayout.Override.AllowMultiCellOperations = AllowMultiCellOperation.All
        oGrid.DisplayLayout.Override.CellClickAction = CellClickAction.CellSelect
        oGrid.PerformAction(UltraGridAction.Copy)

        texto = Clipboard.GetText()
        texto = Mid(texto, InStr(texto, vbCr) + 2)
        If texto <> "" Then
            Clipboard.SetText(texto)
        End If
    End Sub

    Private Sub oMenu_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles oMenu.ItemClicked
        Select Case e.ClickedItem.Name
            Case cnt_PopUp_Menu_EscolheColuna
                'PopUp_EscolheColuna()
            Case cnt_PopUp_Menu_Copiar

        End Select
    End Sub
End Module