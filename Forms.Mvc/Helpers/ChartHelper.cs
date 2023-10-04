using DomraSinForms.Application.Features.Answers.Queries.GetList;
using DomraSinForms.ChartsWrapper.ApexCharts;
using DomraSinForms.Domain.Models;
using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Domain.Models.Versions;
using Forms.Mvc.ViewModels.Statistics;

namespace Forms.Mvc.Helpers;

public static class ChartHelper
{
    private const int DaysForStatistics = 30;
    public static Dictionary<object, object> FormsActions(IEnumerable<Form> forms, IEnumerable<FormVersion> formVersions)
    {
        var dictionary = new Dictionary<DateTime, int>();

        foreach (var form in forms
                     .Where(form => form.CreationDate >= DateTime.Now - TimeSpan.FromDays(DaysForStatistics)))
        {
            if (!dictionary.TryAdd(form.CreationDate.Date, 1))
                dictionary[form.CreationDate.Date] += 1;
        }
        foreach (var version in formVersions
                     .Where(version => version.CreationDate >= DateTime.Now - TimeSpan.FromDays(DaysForStatistics)))
        {
            if (!dictionary.TryAdd(version.CreationDate.Date, 1))
                dictionary[version.CreationDate.Date] += 1;
        }

        var resultDictionary = new Dictionary<object, object>();
        foreach (var item in dictionary.AddMissingDates().OrderBy(d => d.Key))
        {
            resultDictionary.Add(item.Key.ToShortDateString(), item.Value);
        }
        return resultDictionary;

    }
    public static Dictionary<object, object> AnswersActions(IEnumerable<FormAnswers> formAnswers)
    {
        var dictionary = new Dictionary<DateTime, int>();

        foreach (var answers in formAnswers
                     .Where(version => version.CreationDate >= DateTime.Now - TimeSpan.FromDays(DaysForStatistics)))
        {
            if (!dictionary.TryAdd(answers.CreationDate.Date, 1))
                dictionary[answers.CreationDate.Date] += 1;
        }
        var resultDictionary = new Dictionary<object, object>();
        foreach (var item in dictionary.AddMissingDates().OrderBy(d => d.Key))
        {
            resultDictionary.Add(item.Key.ToShortDateString(), item.Value);
        };
        return resultDictionary;

    }
    public static IChartOptionsBuilder GetChartOptionsBuilder()
    {
        return new ChartOptionsBuilder()
            .UsePalette(1)
            .SetupToolBar(options => options.Show()
                .EnableTool(ToolBarTool.Pan, @"<i class=\""bi-hand-index fs-3\""></i>")
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
        var dictionary = new Dictionary<DateTime, int>();

        foreach (var answers in formAnswers)
        {
            if (!dictionary.TryAdd(answers.CreationDate.Date, 1))
                dictionary[answers.CreationDate.Date] += 1;
        }
        var resultDictionary = new Dictionary<object, object>();
        foreach (var item in dictionary.AddMissingDates().OrderBy(d => d.Key))
        {
            resultDictionary.Add(item.Key.ToShortDateString(), item.Value);
        };
        return resultDictionary;
    }
    public static Dictionary<DateTime, int> AddMissingDates(this Dictionary<DateTime, int> dictionary)
    {
        var resultDictionary = new Dictionary<DateTime, int>(dictionary);
        var start = resultDictionary.Count == 0 ? DateTime.UtcNow.Date : resultDictionary.Min(d => d.Key);
        var end = DateTime.UtcNow;

        foreach (var date in Enumerable.Range(0, 1 + end.Subtract(start).Days)
          .Select(offset => start.AddDays(offset)))
        {
            if (!resultDictionary.ContainsKey(date))
                resultDictionary.Add(date, 0);
        }
        return resultDictionary;
    }
}
