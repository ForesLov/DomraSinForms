namespace DomraSinForms.ChartsWrapper.ApexCharts;
public class ChartOptionsBuilder : IChartOptionsBuilder
{
    protected ChartOptions _options = new();
    public ChartOptions IntermediateInstance => _options;
    /// <summary>
    /// Enables one of 11 palettes (from 0 to 10). <br/><br/>
    /// For more information see <a href="https://apexcharts.com/docs/themes/">docs</a>.
    /// </summary>
    /// <param name="paletteNumber">Palette number, must be in range from 0 to 10.</param>
    /// <returns>Instance of <see cref="ChartOptionsBuilder"/>.</returns>
    public ChartOptionsBuilder UsePalette(int paletteNumber)
    {
        if (paletteNumber >= 0 && paletteNumber <= 10)
        {
            _options.Theme.Palette = $"palette{paletteNumber}";
        }
        return this;
    }
    public ChartOptions Build()
    {
        return _options;
    }
}