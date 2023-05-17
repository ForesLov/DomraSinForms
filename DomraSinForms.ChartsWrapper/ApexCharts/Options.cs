﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DomraSinForms.ChartsWrapper.ApexCharts;
public class Options
{
    public Chart Chart { get; set; } = new();
    public List<object> Series { get; set; } = new();
    [JsonProperty("xaxis")]
    public Axis XAxis { get; set; } = new();
    public Theme Theme { get; set; } = new();
    public IEnumerable<object> Labels { get; set; }
}

public class Theme
{
    public string Mode { get; set; }
    public string Palette { get; set; }
}

public class Chart
{
    public string Type { get; set; }
}
public class Axis
{
    public IEnumerable<object> Categories { get; set; }
}
public class Series
{
    public string Name { get; set; }
    public IEnumerable<object> Data { get; set; }
}