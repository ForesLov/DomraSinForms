using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.ChartsWrapper.ApexCharts.Charts.LineChart;
public interface ILineChartOptionsBuilder : IChartOptionsBuilder
{
    ILineChartOptionsBuilder UseLineStyle(LineStroke lineStroke);
    ILineChartOptionsBuilder AddData(Dictionary<object, object> data, LineChartDataType type);
}
