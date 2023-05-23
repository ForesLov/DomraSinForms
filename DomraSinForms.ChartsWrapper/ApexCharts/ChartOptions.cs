using Newtonsoft.Json;

namespace DomraSinForms.ChartsWrapper.ApexCharts;
public class ChartOptions
{
    public Chart Chart { get; set; } = new();
    public List<object> Series { get; set; } = new();
    [JsonProperty("xaxis")]
    public Axis XAxis { get; set; } = new();
    public Theme Theme { get; set; } = new();
    public IEnumerable<object>? Labels { get; set; }
    public Stroke Stroke { get; set; } = new();
}

public class Stroke
{
    public string Curve { get; set; }
}

public class Theme
{
    public string? Mode { get; set; }
    public string? Palette { get; set; }
}

public class Chart
{
    public string? Type { get; set; }
}
public class Axis
{
    public IEnumerable<object>? Categories { get; set; }
}
public class Series
{
    public string? Name { get; set; }
    public IEnumerable<object>? Data { get; set; }
    public string? Type { get; set; }
}