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
    [JsonProperty("toolbar")]
    public ToolBarOptions? ToolBar { get; set; }
}

public class ToolBarOptions
{
    public bool Show { get; set; } = true;
    public int OffsetX { get; set; } = 0;
    public int OffsetY { get; set; } = 0;
    public Tools Tools { get; set; } = new();
}

public enum ToolBarTool
{
    Download, Selection, Zoom, ZoomIn, ZoomOut, Pan, ResetZoom
}

public class Tools
{
    public object? Download { get; set; } = false;
    public object? Selection { get; set; } = false;
    public object? Zoom { get; set; } = false;
    [JsonProperty("zoomin")]
    public object? ZoomIn { get; set; } = false;
    [JsonProperty("zoomout")]
    public object? ZoomOut { get; set; } = false;
    public object? Pan { get; set; } = false;
    public object? Reset { get; set; } = false;
    public List<CustomIcon> CustomIcons { get; set; } = new();
}
public class CustomIcon
{
    public string Icon { get; set; }
    public int Index { get; set; }
    public string Title { get; set; }
    public string Class { get; set; }
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