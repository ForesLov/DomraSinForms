using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.ChartsWrapper.ApexCharts.Charts.LineChart;
public class LineChartOptionsBuilder : ChartOptionsBuilder, ILineChartOptionsBuilder
{
    public LineChartOptionsBuilder(IChartOptionsBuilder builder, Dictionary<object, object> data, LineChartDataType type = LineChartDataType.Line)
    {
        _options = builder.IntermediateInstance;
        _options.Chart.Type = "line";
        InitChart(data, type);
    }

    public ILineChartOptionsBuilder UseLineStyle(LineStroke lineStroke)
    {
        _options.Stroke.Curve = lineStroke switch
        {
            LineStroke.StepLine => "stepline",
            LineStroke.Straight => "straight",
            LineStroke.Smooth => "smooth",
            _ => "smooth"
        };
        return this;
    }
    public ILineChartOptionsBuilder AddData(Dictionary<object, object> data, LineChartDataType type)
    {
        var series = new Series
        {
            Type = type switch
            {
                LineChartDataType.Line => "line",
                LineChartDataType.Column => "column",
                LineChartDataType.Area => "area",
                LineChartDataType.Scatter => "scatter",
                _ => "line"
            },
            Name = ""
        };
        var seriesData = new List<Point>();
        foreach (var item in data)
        {
            seriesData.Add(new(item.Key, item.Value));
        }
        series.Data = seriesData;
        _options.Series.Add(series);

        return this;
    }
    private void InitChart(Dictionary<object, object> data, LineChartDataType type)
    {
        AddData(data, type);
    }
}
