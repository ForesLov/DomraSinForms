using DomraSinForms.Application.Users.Queries;
using DomraSinForms.Domain.Models;
using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Domain.Models.Versions;
using Forms.Mvc.Helpers;

namespace Forms.Mvc.ViewModels;

public class UserSummaryViewModel
{
    public UserSummaryViewModel() : this(new()) {}
    public UserSummaryViewModel(UsersActionsSummary summary)
    {
        FormVersions = summary.FormVersions;
        Forms = summary.Forms;
        FormAnswers = summary.FormAnswers;
    }
    public IEnumerable<FormVersion> FormVersions { get; set; }
    public IEnumerable<Form> Forms { get; set; }
    public IEnumerable<FormAnswers> FormAnswers { get; set; }

    public Dictionary<object, object> FormsActions => ChartHelper.FormsActions(Forms, FormVersions);
    public Dictionary<object, object> AnswersActions => ChartHelper.AnswersActions(FormAnswers);
}
