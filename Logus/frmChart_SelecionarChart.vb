Imports Infragistics.Win.UltraWinChart

Public Class frmChart_SelecionarChart
    Dim oChart_Ctrl As UltraChart
    Dim oPicture_TypeChart(48) As Picture_TypeChart

    Private Sub frmChart_SelecionarChart_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sCaminho As String = System.Web.Configuration.WebConfigurationManager.AppSettings("PATH_GRAFICO_IMAGEM").ToString.ToUpper()
        Dim iCont_01 As Integer
        Dim iCont_02 As Integer
        Dim sNome As String
        Dim oPicture As System.Windows.Forms.PictureBox

        For iCont_01 = 0 To tabChart.TabCount - 1
            For iCont_02 = 0 To tabChart.TabPages(iCont_01).Controls.Count - 1
                If TypeName(tabChart.TabPages(iCont_01).Controls(iCont_02)) = "PictureBox" Then
                    oPicture = tabChart.TabPages(iCont_01).Controls(iCont_02)

                    sNome = Mid(oPicture.Name, 4)

                    oPicture.Image = Image.FromFile(Application.StartupPath & "\" & sCaminho & "\" & _
                                                    tabChart.TabPages(iCont_01).Tag & "\" & sNome & ".png")
                    ToolTip1.SetToolTip(oPicture, sNome)

                    AddHandler oPicture.DoubleClick, AddressOf Picture_DoubleClick
                End If
            Next
        Next

        Picture_TypeChart_Setar(0, "BubbleChart", Infragistics.UltraChart.Shared.Styles.ChartType.BubbleChart)
        Picture_TypeChart_Setar(1, "BubbleChart3D", Infragistics.UltraChart.Shared.Styles.ChartType.BubbleChart3D)
        Picture_TypeChart_Setar(2, "CandleChart", Infragistics.UltraChart.Shared.Styles.ChartType.CandleChart)
        Picture_TypeChart_Setar(3, "DoughnutChart3D", Infragistics.UltraChart.Shared.Styles.ChartType.DoughnutChart3D)
        Picture_TypeChart_Setar(4, "GanttChart", Infragistics.UltraChart.Shared.Styles.ChartType.GanttChart)
        Picture_TypeChart_Setar(5, "HeatMapChart", Infragistics.UltraChart.Shared.Styles.ChartType.HeatMapChart)
        Picture_TypeChart_Setar(6, "HeatMapChart3D", Infragistics.UltraChart.Shared.Styles.ChartType.HeatMapChart3D)
        Picture_TypeChart_Setar(7, "PieChart", Infragistics.UltraChart.Shared.Styles.ChartType.PieChart)
        Picture_TypeChart_Setar(8, "PieChart3D", Infragistics.UltraChart.Shared.Styles.ChartType.PieChart3D)
        Picture_TypeChart_Setar(9, "PointChart3D", Infragistics.UltraChart.Shared.Styles.ChartType.PointChart3D)
        Picture_TypeChart_Setar(10, "PolarChart", Infragistics.UltraChart.Shared.Styles.ChartType.PolarChart)
        Picture_TypeChart_Setar(11, "ProbabilityChart", Infragistics.UltraChart.Shared.Styles.ChartType.ProbabilityChart)
        Picture_TypeChart_Setar(12, "ScatterChart", Infragistics.UltraChart.Shared.Styles.ChartType.ScatterChart)
        Picture_TypeChart_Setar(13, "LineChart", Infragistics.UltraChart.Shared.Styles.ChartType.LineChart)
        Picture_TypeChart_Setar(14, "LineChart3D", Infragistics.UltraChart.Shared.Styles.ChartType.LineChart3D)
        Picture_TypeChart_Setar(15, "RadarChart", Infragistics.UltraChart.Shared.Styles.ChartType.RadarChart)
        Picture_TypeChart_Setar(16, "ScatterLineChart", Infragistics.UltraChart.Shared.Styles.ChartType.ScatterLineChart)
        Picture_TypeChart_Setar(17, "SplineChart", Infragistics.UltraChart.Shared.Styles.ChartType.SplineChart)
        Picture_TypeChart_Setar(18, "StackLineChart", Infragistics.UltraChart.Shared.Styles.ChartType.ScatterLineChart)
        Picture_TypeChart_Setar(19, "StackSplineChart", Infragistics.UltraChart.Shared.Styles.ChartType.ScatterLineChart)
        Picture_TypeChart_Setar(20, "ConeChart3D", Infragistics.UltraChart.Shared.Styles.ChartType.ConeChart3D)
        Picture_TypeChart_Setar(21, "FunnelChart", Infragistics.UltraChart.Shared.Styles.ChartType.FunnelChart)
        Picture_TypeChart_Setar(22, "FunnelChart3D", Infragistics.UltraChart.Shared.Styles.ChartType.FunnelChart3D)
        Picture_TypeChart_Setar(23, "PyramidChart", Infragistics.UltraChart.Shared.Styles.ChartType.PyramidChart)
        Picture_TypeChart_Setar(24, "PyramidChart3D", Infragistics.UltraChart.Shared.Styles.ChartType.PyramidChart3D)
        Picture_TypeChart_Setar(25, "BarChart", Infragistics.UltraChart.Shared.Styles.ChartType.BarChart)
        Picture_TypeChart_Setar(26, "BarChart3D", Infragistics.UltraChart.Shared.Styles.ChartType.BarChart3D)
        Picture_TypeChart_Setar(27, "ColumnChart", Infragistics.UltraChart.Shared.Styles.ChartType.ColumnChart)
        Picture_TypeChart_Setar(28, "ColumnChart3D", Infragistics.UltraChart.Shared.Styles.ChartType.ColumnChart3D)
        Picture_TypeChart_Setar(29, "ColumnLineChart", Infragistics.UltraChart.Shared.Styles.ChartType.ColumnLineChart)
        Picture_TypeChart_Setar(30, "CylinderBarChart3D", Infragistics.UltraChart.Shared.Styles.ChartType.CylinderBarChart3D)
        Picture_TypeChart_Setar(31, "CylinderColumnChart3D", Infragistics.UltraChart.Shared.Styles.ChartType.CylinderColumnChart3D)
        Picture_TypeChart_Setar(32, "CylinderStackBarChart3D", Infragistics.UltraChart.Shared.Styles.ChartType.CylinderStackBarChart3D)
        Picture_TypeChart_Setar(33, "CylinderStackColumnChart3D", Infragistics.UltraChart.Shared.Styles.ChartType.CylinderStackColumnChart3D)
        Picture_TypeChart_Setar(34, "ParetoChart", Infragistics.UltraChart.Shared.Styles.ChartType.ParetoChart)
        Picture_TypeChart_Setar(35, "Stack3DBarChart", Infragistics.UltraChart.Shared.Styles.ChartType.Stack3DBarChart)
        Picture_TypeChart_Setar(36, "Stack3DColumnChart", Infragistics.UltraChart.Shared.Styles.ChartType.Stack3DColumnChart)
        Picture_TypeChart_Setar(37, "StackBarChart", Infragistics.UltraChart.Shared.Styles.ChartType.StackBarChart)
        Picture_TypeChart_Setar(38, "StackColumnChart", Infragistics.UltraChart.Shared.Styles.ChartType.StackColumnChart)
        Picture_TypeChart_Setar(39, "AreaChart", Infragistics.UltraChart.Shared.Styles.ChartType.AreaChart)
        Picture_TypeChart_Setar(40, "AreaChart3D", Infragistics.UltraChart.Shared.Styles.ChartType.AreaChart3D)
        Picture_TypeChart_Setar(41, "SplineAreaChart", Infragistics.UltraChart.Shared.Styles.ChartType.SplineAreaChart)
        Picture_TypeChart_Setar(42, "SplineAreaChart3D", Infragistics.UltraChart.Shared.Styles.ChartType.SplineAreaChart3D)
        Picture_TypeChart_Setar(43, "SplineChart3D", Infragistics.UltraChart.Shared.Styles.ChartType.SplineChart3D)
        Picture_TypeChart_Setar(44, "StackAreaChart", Infragistics.UltraChart.Shared.Styles.ChartType.StackAreaChart)
        Picture_TypeChart_Setar(45, "StackSplineAreaChart", Infragistics.UltraChart.Shared.Styles.ChartType.StackSplineAreaChart)
        Picture_TypeChart_Setar(46, "StepAreaChart", Infragistics.UltraChart.Shared.Styles.ChartType.StepAreaChart)
        Picture_TypeChart_Setar(47, "StepLineChart", Infragistics.UltraChart.Shared.Styles.ChartType.StepLineChart)
        Picture_TypeChart_Setar(48, "DoughnutChart", Infragistics.UltraChart.Shared.Styles.ChartType.DoughnutChart)
    End Sub

    Public Sub Form_Carregar(ByVal oChart As UltraChart)
        oChart_Ctrl = oChart
    End Sub

    Private Sub Picture_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sNome As String
        Dim iCont As Integer

        sNome = Mid(sender.Name, 4)

        For iCont = 0 To UBound(oPicture_TypeChart) - 1
            If oPicture_TypeChart(iCont).Picture = sNome Then
                oChart_Ctrl.ChartType = oPicture_TypeChart(iCont).TipoChart
                oChart_Ctrl.Refresh()
            End If
        Next

        Close()
    End Sub

    Private Sub Picture_TypeChart_Setar(ByVal Indice As Integer, _
                                        ByVal Nome As String, _
                                        ByVal oTipo As Infragistics.UltraChart.Shared.Styles.ChartType)
        oPicture_TypeChart(Indice) = New Picture_TypeChart
        oPicture_TypeChart(Indice).Picture = Nome
        oPicture_TypeChart(Indice).TipoChart = oTipo
    End Sub

    
End Class

Public Class Picture_TypeChart
    Public Picture As String
    Public TipoChart As Infragistics.UltraChart.Shared.Styles.ChartType
End Class