using DomraSinForms.Domain.Models.Questions;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Forms.Mvc.Helpers;

public class QuestionsHelper
{
    public static IEnumerable<SelectListItem> TextQuestionTypesSelect(IViewLocalizer localizer) => new[]
    {
        new SelectListItem(localizer["Text question"]?.Value, ((int) TextQuestionType.Text).ToString()),
        new SelectListItem(localizer["Number question"]?.Value, ((int) TextQuestionType.Number).ToString()),
        new SelectListItem(localizer["Date question"]?.Value, ((int) TextQuestionType.Date).ToString()),
        new SelectListItem(localizer["DateTime question"]?.Value, ((int) TextQuestionType.DateTime).ToString()),
        new SelectListItem(localizer["Time question"]?.Value, ((int) TextQuestionType.Time).ToString()),
        new SelectListItem(localizer["Phone number"]?.Value, ((int) TextQuestionType.PhoneNumber).ToString()),

    };
}
