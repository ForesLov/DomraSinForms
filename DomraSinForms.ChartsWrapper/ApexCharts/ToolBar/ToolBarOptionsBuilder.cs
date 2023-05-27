using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.ChartsWrapper.ApexCharts.ToolBar;
public class ToolBarOptionsBuilder : IToolBarOptionsBuilder
{
    private ToolBarOptions _options = new();
    public ToolBarOptions Build()
    {
        return _options;
    }

    public IToolBarOptionsBuilder EnableTool(ToolBarTool tool, string? customClass = null)
    {
        switch (tool)
        {
            case ToolBarTool.Download:
                _options.Tools.Download = (object)customClass ?? true;
                break;
            case ToolBarTool.Selection:
                _options.Tools.Selection = (object)customClass ?? true;
                break;
            case ToolBarTool.Zoom:
                _options.Tools.Zoom = (object)customClass ?? true;
                break;
            case ToolBarTool.ZoomIn:
                _options.Tools.ZoomIn = (object)customClass ?? true;
                break;
            case ToolBarTool.ZoomOut:
                _options.Tools.ZoomOut = (object)customClass ?? true;
                break;
            case ToolBarTool.Pan:
                _options.Tools.Pan = (object)customClass ?? true;
                break;
            case ToolBarTool.ResetZoom:
                _options.Tools.Reset = (object)customClass ?? true;
                break;
            default:
                break;
        }
        return this;
    }

    public IToolBarOptionsBuilder Show(bool show = true)
    {
        _options.Show = show;
        return this;
    }
}
