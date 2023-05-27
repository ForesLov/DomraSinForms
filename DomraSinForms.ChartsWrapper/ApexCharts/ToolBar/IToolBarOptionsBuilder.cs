using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.ChartsWrapper.ApexCharts.ToolBar;
public interface IToolBarOptionsBuilder
{
    IToolBarOptionsBuilder EnableTool(ToolBarTool tool, string? customClass = null);
    IToolBarOptionsBuilder Show(bool show = true);
    ToolBarOptions Build();
}
