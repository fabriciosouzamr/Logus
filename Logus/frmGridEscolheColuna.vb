Imports Infragistics.Shared
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinDataSource

Public Class frmGridEscolheColuna
    Private _Grid As UltraGridBase = Nothing

    Private Sub InitializeBandsCombo(ByVal Grid As UltraGridBase)
        cboEscolheBand.SetDataBinding(Nothing, Nothing)

        If Nothing Is Grid Then Return

        Dim BandsUDS As UltraDataSource = New UltraDataSource()
        Dim Band As UltraGridBand

        BandsUDS.Band.Columns.Add("Band", GetType(UltraGridBand))
        BandsUDS.Band.Columns.Add("DisplayText", GetType(String))

        For Each Band In Grid.DisplayLayout.Bands
            If Not IsBandExcluded(Band) Then
                BandsUDS.Rows.Add(New Object() {Band, Band.Header.Caption})
            End If
        Next

        With cboEscolheBand
            .DisplayMember = "DisplayText"
            .ValueMember = "Band"
            .SetDataBinding(BandsUDS, Nothing)
            .DropDownWidth = 0

            With .DisplayLayout
                .Bands(0).Columns("Band").Hidden = True
                .Bands(0).ColHeadersVisible = False
                .Override.HotTrackRowAppearance.BackColor = Color.LightYellow
                .AutoFitStyle = AutoFitStyle.ResizeAllColumns
                .BorderStyle = UIElementBorderStyle.Solid
                .Appearance.BorderColor = SystemColors.Highlight
            End With
        End With
    End Sub

    Private Function IsBandExcluded(ByVal Band As UltraGridBand) As Boolean
        While Not Nothing Is Band
            If ExcludeFromColumnChooser.True = Band.ExcludeFromColumnChooser Then Return True
            Band = Band.ParentBand
        End While

        Return False
    End Function

    Public Property Grid() As UltraGridBase
        Get
            Return _Grid
        End Get
        Set(ByVal Value As UltraGridBase)

            If Not Value Is _Grid Then
                _Grid = Value

                grdEscolheColuna.SourceGrid = _Grid
                InitializeBandsCombo(_Grid)

                If cboEscolheBand.Rows.Count > 0 Then
                    cboEscolheBand.SelectedRow = cboEscolheBand.Rows(0)
                End If
            End If
        End Set
    End Property

    Public Property BandAtual() As UltraGridBand
        Get
            Return EscolheColunaControl.CurrentBand
        End Get
        Set(ByVal Value As UltraGridBand)
            If Not Nothing Is Value AndAlso (Nothing Is Grid OrElse Not Grid Is Value.Layout.Grid) Then
                Throw New ArgumentException()
            End If

            cboEscolheBand.Value = Value
        End Set
    End Property

    Public ReadOnly Property EscolheColunaControl() As UltraGridColumnChooser
        Get
            Return grdEscolheColuna
        End Get
    End Property

    Private Sub cboEscolheBand_RowSelected(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowSelectedEventArgs) Handles cboEscolheBand.RowSelected
        If Nothing Is Grid OrElse Grid.IsDisposed Then
            Return
        End If

        Dim SelectedBand As UltraGridBand = Nothing

        If Not TypeOf cboEscolheBand.Value Is UltraGridBand Then
            System.Diagnostics.Debug.Assert(False)
            SelectedBand = Grid.DisplayLayout.Bands(0)
            cboEscolheBand.Value = SelectedBand
        End If

        SelectedBand = DirectCast(cboEscolheBand.Value, UltraGridBand)

        grdEscolheColuna.CurrentBand = SelectedBand
    End Sub

    Private Sub frmGridEscolheColuna_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboEscolheBand.Visible = False
    End Sub
End Class