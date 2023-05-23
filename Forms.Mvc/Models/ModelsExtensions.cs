using DomraSinForms.Application.Forms.Queries.GetList;
using DomraSinForms.Domain.Models;

namespace Forms.Mvc.Models;

public static class ModelsExtensions
{
    public static string? FormatLastUpdate(this Form? form, string todayStringFormat = "{0}", string notEditedStringFormat = "-")
    {
        if (form is null)
            return string.Empty;
        if (form.LastUpdateDate == DateTime.MinValue)
        {
            return string.Format(notEditedStringFormat, todayStringFormat);
        }
        else if (form.LastUpdateDate?.Date == DateTime.Today.Date)
        {
            return string.Format(todayStringFormat, form.LastUpdateDate?.ToLocalTime().ToShortTimeString());
        }
        else
        {
            return form.LastUpdateDate?.ToLocalTime().ToShortDateString();
        }
    }
    public static string? FormatLastUpdate(this FormDto? form, string todayStringFormat = "{0}", string notEditedStringFormat = "-")
    {
        if (form is null)
            return string.Empty;
        if (form.LastUpdateDate == DateTime.MinValue)
        {
            return string.Format(notEditedStringFormat, todayStringFormat);
        }
        else if (form.LastUpdateDate.Date == DateTime.Today.Date)
        {
            return string.Format(todayStringFormat, form.LastUpdateDate.ToLocalTime().ToShortTimeString());
        }
        else
        {
            return form.LastUpdateDate.ToLocalTime().ToShortDateString();
        }
    }
}
