using DomraSinForms.Application.Features.Forms.Queries.GetList;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Forms.Mvc.Helpers;

public static class FormSortHelper
{
    public static IEnumerable<SelectListItem> OrderApproaches(IViewLocalizer localizer) => new[]
    {
        new SelectListItem(localizer["By title"]?.Value, ((int)FormOrderApproach.Title).ToString()),
        new SelectListItem(localizer["By title descending"]?.Value, ((int)FormOrderApproach.TitleDescending).ToString()),
        new SelectListItem(localizer["By creation date"]?.Value, ((int)FormOrderApproach.Creation).ToString()),
        new SelectListItem(localizer["By creation date descending"]?.Value, ((int)FormOrderApproach.CreationDescending).ToString()),
        new SelectListItem(localizer["By last edit date"]?.Value, ((int)FormOrderApproach.LastUpdate).ToString()),
        new SelectListItem(localizer["By last edit date descending"]?.Value, ((int)FormOrderApproach.LastUpdateDescending).ToString()),
    };
}
