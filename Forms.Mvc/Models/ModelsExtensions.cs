using DomraSinForms.Application.Forms.Queries.GetList;
using DomraSinForms.Domain.Models;
using DomraSinForms.Domain.Models.Answers;

namespace Forms.Mvc.Models;

public static class ModelsExtensions
{
    public static string? FormatLastUpdate(this Form? form, string todayStringFormat = "{0}", string notEditedStringFormat = "-")
    {
        if (form is null)
            return string.Empty;
        return FormatLastActionDate(form.LastUpdateDate.Value, todayStringFormat, notEditedStringFormat);
    }
    public static string? FormatLastUpdate(this FormDto? form, string todayStringFormat = "{0}", string notEditedStringFormat = "-")
    {
        if (form is null)
            return string.Empty;
        return FormatLastActionDate(form.LastUpdateDate, todayStringFormat, notEditedStringFormat);
    }
    public static string? FormatCreationDate(this FormAnswers? answers, string todayStringFormat = "{0}", string notEditedStringFormat = "-")
    {
        if (answers is null)
            return null;
        return FormatLastActionDate(answers.CreationDate, todayStringFormat, notEditedStringFormat);
    }

    public static string FormatLastActionDate(DateTime date, string todayStringFormat, string notEditedStringFormat)
    {
        if (date == DateTime.MinValue)
        {
            return string.Format(notEditedStringFormat, todayStringFormat);
        }
        else if (date.Date == DateTime.Today.Date)
        {
            return string.Format(todayStringFormat, date.ToLocalTime().ToShortTimeString());
        }
        else
        {
            return date.ToLocalTime().ToShortDateString();
        }
    }
}
