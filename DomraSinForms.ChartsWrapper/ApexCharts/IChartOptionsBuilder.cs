using DomraSinForms.ChartsWrapper.ApexCharts.ToolBar;

namespace DomraSinForms.ChartsWrapper.ApexCharts;
public interface IChartOptionsBuilder
{
    internal ChartOptions IntermediateInstance { get; }
    IChartOptionsBuilder SetupToolBar(Action<IToolBarOptionsBuilder> toolBarSetupAction);
    ChartOptions Build();
}
