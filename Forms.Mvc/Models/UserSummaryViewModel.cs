using DomraSinForms.Application.Users.Queries;
using DomraSinForms.Domain.Models;
using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Domain.Models.Versions;

namespace Forms.Mvc.Models;

public class UserSummaryViewModel
{
    public UserSummaryViewModel() {}
    public UserSummaryViewModel(UsersActionsSummary summary)
    {
        FormVersions = summary.FormVersions;
        Forms = summary.Forms;
        FormAnswers = summary.FormAnswers;
    }

    public IEnumerable<FormVersion> FormVersions { get; set; }
    public IEnumerable<Form> Forms { get; set; }
    public IEnumerable<FormAnswers> FormAnswers { get; set; }
    public Dictionary<object, object> FormsActions
    {
        get
        {
            var dictionary = new Dictionary<string, int>();

            foreach (var form in Forms)
            {
                if (!dictionary.TryAdd(form.CreationDate.ToShortDateString(), 1))
                    dictionary[form.CreationDate.ToShortDateString()] += 1;
            }
            foreach (var version in FormVersions)
            {
                if (!dictionary.TryAdd(version.CreationDate.ToShortDateString(), 1))
                    dictionary[version.CreationDate.ToShortDateString()] += 1;
            }

            var resultDictionary = new Dictionary<object, object>();
            foreach (var item in dictionary.OrderBy(d => d.Key))
            {
                resultDictionary.Add(item.Key, item.Value);
            };

            return resultDictionary;
        }
    }
    public Dictionary<object, object> AnswersActions
    {
        get
        {
            var dictionary = new Dictionary<string, int>();

            foreach (var answers in FormAnswers)
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
}
