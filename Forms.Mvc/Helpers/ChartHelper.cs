using DomraSinForms.Application.Answers.Queries.GetList;
using DomraSinForms.Application.Forms.Queries.GetList;
using DomraSinForms.ChartsWrapper.ApexCharts;
using DomraSinForms.Domain.Models;
using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Domain.Models.Versions;
using Forms.Mvc.ViewModels.Statistics;

namespace Forms.Mvc.Helpers;

public static class ChartHelper
{
    public static Dictionary<object, object> FormsActions(IEnumerable<Form> forms, IEnumerable<FormVersion> formVersions)
    {
        var dictionary = new Dictionary<string, int>();

        foreach (var form in forms)
        {
            if (!dictionary.TryAdd(form.CreationDate.ToShortDateString(), 1))
                dictionary[form.CreationDate.ToShortDateString()] += 1;
        }
        foreach (var version in formVersions)
        {
            if (!dictionary.TryAdd(version.CreationDate.ToShortDateString(), 1))
                dictionary[version.CreationDate.ToShortDateString()] += 1;
        }

        var resultDictionary = new Dictionary<object, object>();
        foreach (var item in dictionary.OrderBy(d => d.Key))
        {
            resultDictionary.Add(item.Key, item.Value);
        }

        return resultDictionary;

    }
    public static Dictionary<object, object> AnswersActions(IEnumerable<FormAnswers> formAnswers)
    {
        var dictionary = new Dictionary<string, int>();

        foreach (var answers in formAnswers)
        {
            if (!dictionary.TryAdd(answers.CreationDate.ToShortDateString(), 1))
                dictionary[answers.CreationDate.ToShortDateString()] += 1;
        }

        var resultDictionary = new Dictionary<object, object>();
        foreach (var item in dictionary.OrderBy(d => d.Key))
        {
            resultDictionary.Add(item.Key, item.Value);
        };
        return resultDictionary;

    }
    public static IChartOptionsBuilder GetChartOptionsBuilder()
    {
        return new ChartOptionsBuilder()
            .UsePalette(1)
            .SetupToolBar(options => options.Show()
                .EnableTool(ToolBarTool.ZoomIn, @"<i class=\""bi-zoom-in fs-3\"" ></i>")
                .EnableTool(ToolBarTool.ZoomOut, @"<i class=\""bi-zoom-out fs-3\"" width=\""20\""></i>")
                .EnableTool(ToolBarTool.ResetZoom, @"<i class=\""bi-x-circle fs-5\"" width=\""20px\""></i>")
                .EnableTool(ToolBarTool.Download, @"<i class=\""bi-download fs-5\""></i>")
                );
    }
    public static Dictionary<object, object> GetCountData(QuestionSummary summary)
    {
        var result = new Dictionary<object, object>();

        var allAnswers = summary.Answers.SelectMany(a => a.Split("; ")).ToArray();
        foreach (var answer in allAnswers.Distinct())
        {
            result.Add(answer, allAnswers.Count(a => a == answer));
        }
        return result;
    }
    public static Dictionary<object, object> GetPercentageData(QuestionSummary summary)
    {
        var result = new Dictionary<object, object>();

        var allAnswers = summary.Answers.SelectMany(a => a.Split("; ")).ToArray();
        foreach (var answer in allAnswers.Distinct())
        {
            result.Add(answer, (double)allAnswers.Count(a => a == answer) / (double)allAnswers.Length * 100d);
        }
        return result;
    }
    public static Dictionary<object, object> AnswersActions(IEnumerable<FormAnswersDto> formAnswers)
    {
        var dictionary = new Dictionary<string, int>();

        foreach (var answers in formAnswers)
        {
            if (!dictionary.TryAdd(answers.CreationDate.ToShortDateString(), 1))
                dictionary[answers.CreationDate.ToShortDateString()] += 1;
        }

        var resultDictionary = new Dictionary<object, object>();
        foreach (var item in dictionary.OrderBy(d => d.Key))
        {
            resultDictionary.Add(item.Key, item.Value);
        };
        return resultDictionary;
    }
}
