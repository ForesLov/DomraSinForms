using DomraSinForms.Application.Answers.Queries.GetList;
using DomraSinForms.Domain.Models;

namespace Forms.Mvc.ViewModels.Statistics;

#nullable disable

public class SummaryViewModel
{
    private IEnumerable<FormAnswersDto> _answersDto = Array.Empty<FormAnswersDto>();

    public string FormId { get; set; }
    public Form Form { get; set; }
    public IEnumerable<FormAnswersDto> AnswersDto
    {
        get => _answersDto; set
        {
            _answersDto = value;
            Questions = GetQuestions(value);
        }
    }
    public IEnumerable<QuestionSummary> Questions { get; set; } = Array.Empty<QuestionSummary>();

    private IEnumerable<QuestionSummary> GetQuestions(IEnumerable<FormAnswersDto> formAnswers)
    {
        var answers = formAnswers.SelectMany(a => a.Answers);
        foreach (var question in answers.Select(a => a.Question).DistinctBy(q => q.Id))
        {
            yield return new QuestionSummary
            {
                Question = question,
                Answers = answers.Where(a => a.QuestionId == question.Id).Select(a => a.Value).ToArray()
            };
        }
    }
}
