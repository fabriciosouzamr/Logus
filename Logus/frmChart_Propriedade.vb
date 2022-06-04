Imports Infragistics.UltraChart.Shared.Styles
Imports Infragistics.Win.UltraWinChart

Public Class frmChart_Propriedade
    Public Enum eGrafico
        Logus_Contato = 1
        SRP_Analise = 2
        SRP_Producao = 3
        Logus_Bolsa = 4
        Luminis_Pedidos = 5
        ContatoVisita = 6
    End Enum

    Dim oChart_Ctrl As UltraChart
    Dim iTipoTela As eGrafico

    Private Sub frmChart_Propriedade_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim modelStyle As String() = System.Enum.GetNames(GetType(ColorModels))
        Dim sAux As String

        Me.Left = Screen.PrimaryScreen.WorkingArea.Width - Me.Width - 100
        Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2

        For Each sAux In modelStyle
            cboModeloEstiloCor.Items.Add(sAux)
        Next sAux

        Me.Height = 694

        Chart_CarregarTelaChart(Me, iTipoTela)

        Me.tickmarkStyleEditor.Text = oChart_Ctrl.Axis.Y.TickmarkStyle.ToString()
        Me.tickIntervalEditor.Value = oChart_Ctrl.Axis.Y.TickmarkInterval
        Me.tickPercentageEditor.Value = oChart_Ctrl.Axis.Y.TickmarkPercentage

        SetTicksStyle()
    End Sub

    Public Sub FormatarTela(ByVal TipoTela As frmChart_Propriedade.eGrafico)
        iTipoTela = TipoTela
    End Sub

    Public Sub Carregar(ByVal oChart As UltraChart)
        oChart_Ctrl = oChart

        'Modelo de Estilo de Cor
        'cboModeloEstiloCor.SelectedItem = cboModeloEstiloCor.Items(cboModeloEstiloCor.FindString(System.Enum.GetName(GetType(ColorModels), _
        'oChart.ColorModel.ModelStyle), 0))

        'Linha de Grade
        chkLinhaHorizontalMaior.Checked = oChart.Axis.Y.MajorGridLines.Visible
        chkLinhaHorizontalMenor.Checked = oChart.Axis.Y.MinorGridLines.Visible
        chkLinhaVerticalMaior.Checked = oChart.Axis.X.MajorGridLines.Visible
        chkLinhaVerticalMenor.Checked = oChart.Axis.X.MinorGridLines.Visible

        'Extensão do Chart
        trbExtensao_Horizontal.Value = oChart.Axis.Y.Extent
        trbExtensao_Vertical.Value = oChart.Axis.X.Extent

        'Rotação
        trbRotacaoVertical.Value = Fix(oChart.Transform3D.XRotation)
        trbRotacaoHorizontal.Value = Fix(oChart.Transform3D.YRotation)
        trbRotacaoGiratoria.Value = Fix(oChart.Transform3D.ZRotation)

        'Escala
        trbEscala_Escala.Value = Fix(oChart.Transform3D.Scale)
        trbEscala_Perspectiva.Value = Fix(oChart.Transform3D.Perspective)

        trbRolagemHorizontal.Value = oChart_Ctrl.Axis.X.ScrollScale.Scale * 100
        trbRolagemVertical.Value = oChart_Ctrl.Axis.Y.ScrollScale.Scale * 100

        'Select Case oChart_Ctrl.ChartType
        '    Case ChartType.AreaChart3D, ChartType.BarChart3D, ChartType.BubbleChart3D, _
        '        ChartType.ColumnChart3D, ChartType.ConeChart3D, ChartType.CylinderBarChart3D, _
        '        ChartType.CylinderColumnChart3D, ChartType.CylinderStackBarChart3D, _
        '        ChartType.CylinderStackColumnChart3D, ChartType.DoughnutChart3D, ChartType.FunnelChart3D, _
        '        ChartType.HeatMapChart3D, ChartType.LineChart3D, _
        '        ChartType.PieChart3D, ChartType.PointChart3D, ChartType.PyramidChart3D, ChartType.SplineAreaChart3D, _
        '        ChartType.SplineChart3D, ChartType.Stack3DBarChart, ChartType.Stack3DColumnChart

        '        grpRolagem.Visible = False
        '        grpRotacao.Visible = True
        '    Case Else
        '        grpRolagem.Visible = True
        '        grpRotacao.Visible = False
        '        grpRolagem.Top = grpRotacao.Top
        'End Select

    End Sub

    Private Sub cboModeloEstiloCor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboModeloEstiloCor.SelectedIndexChanged
        oChart_Ctrl.ColorModel.ModelStyle = CType(System.Enum.Parse(GetType(ColorModels), _
                                                  cboModeloEstiloCor.SelectedItem.ToString()), _
                                                  ColorModels)
    End Sub

    Private Sub chkLinhaHorizontalMaior_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLinhaHorizontalMaior.CheckedChanged
        oChart_Ctrl.Axis.Y.MajorGridLines.Visible = chkLinhaHorizontalMaior.Checked
    End Sub

    Private Sub chkLinhaHorizontalMenor_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLinhaHorizontalMenor.CheckedChanged
        oChart_Ctrl.Axis.Y.MinorGridLines.Visible = chkLinhaHorizontalMenor.Checked
    End Sub

    Private Sub chkLinhaVerticalMaior_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLinhaVerticalMaior.CheckedChanged
        oChart_Ctrl.Axis.X.MajorGridLines.Visible = chkLinhaVerticalMaior.Checked
    End Sub

    Private Sub chkLinhaVerticalMenor_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLinhaVerticalMenor.CheckedChanged
        oChart_Ctrl.Axis.Y.MinorGridLines.Visible = chkLinhaHorizontalMenor.Checked
    End Sub

    Private Sub trbExtensao_Horizontal_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles trbExtensao_Horizontal.Scroll
        oChart_Ctrl.Axis.Y.Extent = trbExtensao_Horizontal.Value

        ToolTip.SetToolTip(trbExtensao_Horizontal, String_Porcentagem(trbExtensao_Horizontal.Value))
    End Sub

    Private Sub trbExtensao_Vertical_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles trbExtensao_Vertical.Scroll
        oChart_Ctrl.Axis.X.Extent = trbExtensao_Vertical.Value

        ToolTip.SetToolTip(trbExtensao_Vertical, String_Porcentagem(trbExtensao_Vertical.Value))
    End Sub

    Private Sub trbRotacaoGiratoria_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles trbRotacaoGiratoria.Scroll
        oChart_Ctrl.Transform3D.ZRotation = trbRotacaoGiratoria.Value

        ToolTip.SetToolTip(trbRotacaoGiratoria, String_Porcentagem(trbRotacaoGiratoria.Value))
    End Sub

    Private Sub trbRotacaoHorizontal_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles trbRotacaoHorizontal.Scroll
        oChart_Ctrl.Transform3D.YRotation = trbRotacaoHorizontal.Value

        ToolTip.SetToolTip(trbRotacaoHorizontal, String_Porcentagem(trbRotacaoHorizontal.Value))
    End Sub

    Private Sub trbRotacaoVertical_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles trbRotacaoVertical.Scroll
        oChart_Ctrl.Transform3D.XRotation = trbRotacaoVertical.Value

        ToolTip.SetToolTip(trbRotacaoVertical, String_Porcentagem(trbRotacaoVertical.Value))
    End Sub

    Private Sub trbEscala_Escala_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles trbEscala_Escala.Scroll
        oChart_Ctrl.Transform3D.Scale = trbEscala_Escala.Value

        ToolTip.SetToolTip(trbEscala_Escala, String_Porcentagem(trbEscala_Escala.Value))
    End Sub

    Private Sub trbEscala_Perspectiva_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles trbEscala_Perspectiva.Scroll
        oChart_Ctrl.Transform3D.Perspective = trbEscala_Perspectiva.Value

        ToolTip.SetToolTip(trbEscala_Perspectiva, String_Porcentagem(trbEscala_Perspectiva.Value))
    End Sub

    Public Sub Form_Carregar(ByVal oChart As UltraChart)
        oChart_Ctrl = oChart
        Carregar(oChart_Ctrl)
    End Sub

    Private Sub chkRolagem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRolagem.CheckedChanged
        oChart_Ctrl.Axis.X.ScrollScale.Visible = Me.chkRolagem.Checked
        oChart_Ctrl.Axis.Y.ScrollScale.Visible = Me.chkRolagem.Checked

        If Me.chkRolagem.Checked Then
            oChart_Ctrl.Axis.X.ScrollScale.Scale = 1
            oChart_Ctrl.Axis.Y.ScrollScale.Scale = 1
            trbRolagemHorizontal.Value = oChart_Ctrl.Axis.X.ScrollScale.Scale * 100
            trbRolagemVertical.Value = oChart_Ctrl.Axis.Y.ScrollScale.Scale * 100
        End If
    End Sub

    Private Sub trbRolagemHorizontal_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trbRolagemHorizontal.Scroll
        Me.oChart_Ctrl.Axis.X.ScrollScale.Scale = Me.trbRolagemHorizontal.Value / 100.0
        ToolTip.SetToolTip(trbRolagemHorizontal, String_Porcentagem(trbRolagemHorizontal.Value))
    End Sub

    Private Sub trbRolagemVertical_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trbRolagemVertical.Scroll
        Me.oChart_Ctrl.Axis.Y.ScrollScale.Scale = Me.trbRolagemVertical.Value / 100.0
        ToolTip.SetToolTip(trbRolagemVertical, String_Porcentagem(trbRolagemVertical.Value))
    End Sub

    Private Sub tickmarkStyleEditor_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tickmarkStyleEditor.ValueChanged
        SetTicksStyle()
    End Sub

    Private Sub SetTicksStyle()
        Select Case Trim(Me.tickmarkStyleEditor.SelectedItem.DataValue)
            Case "Percentage"
                oChart_Ctrl.Axis.X.TickmarkStyle = AxisTickStyle.Percentage
                Me.tickIntervalTypeEditor.Enabled = False
                Me.tickIntervalEditor.Enabled = False
                Me.tickPercentageEditor.Enabled = True
            Case "DataInterval"
                oChart_Ctrl.Axis.X.TickmarkStyle = AxisTickStyle.DataInterval
                Me.tickIntervalTypeEditor.Enabled = True
                Me.tickIntervalEditor.Enabled = True
                Me.tickPercentageEditor.Enabled = False
            Case "Smart"
                oChart_Ctrl.Axis.X.TickmarkStyle = AxisTickStyle.Smart
                Me.tickIntervalTypeEditor.Enabled = False
                Me.tickIntervalEditor.Enabled = False
                Me.tickPercentageEditor.Enabled = False
        End Select
    End Sub

    Private Sub tickIntervalEditor_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tickPercentageEditor.ValueChanged, tickIntervalTypeEditor.ValueChanged, tickIntervalEditor.ValueChanged
        oChart_Ctrl.Axis.X.TickmarkInterval = Convert.ToDouble(Me.tickIntervalEditor.Value)
        oChart_Ctrl.Axis.X.TickmarkPercentage = Convert.ToDouble(Me.tickPercentageEditor.Value)

        If Not Me.tickIntervalTypeEditor.SelectedItem Is Nothing Then
            Select Case Trim(Me.tickIntervalTypeEditor.SelectedItem.DataValue)
                Case "Ticks"
                    oChart_Ctrl.Axis.X.TickmarkIntervalType = AxisIntervalType.Ticks
                Case "Milliseconds"
                    oChart_Ctrl.Axis.X.TickmarkIntervalType = AxisIntervalType.Milliseconds
                Case "Seconds"
                    oChart_Ctrl.Axis.X.TickmarkIntervalType = AxisIntervalType.Seconds
                Case "Minutes"
                    oChart_Ctrl.Axis.X.TickmarkIntervalType = AxisIntervalType.Minutes
                Case "Hours"
                    oChart_Ctrl.Axis.X.TickmarkIntervalType = AxisIntervalType.Hours
                Case "Days"
                    oChart_Ctrl.Axis.X.TickmarkIntervalType = AxisIntervalType.Days
                Case "Weeks"
                    oChart_Ctrl.Axis.X.TickmarkIntervalType = AxisIntervalType.Weeks
                Case "Months"
                    oChart_Ctrl.Axis.X.TickmarkIntervalType = AxisIntervalType.Months
                Case "Years"
                    oChart_Ctrl.Axis.X.TickmarkIntervalType = AxisIntervalType.Years
                Case "NotSet"
                    oChart_Ctrl.Axis.X.TickmarkIntervalType = AxisIntervalType.NotSet
            End Select
        End If
    End Sub
End Class