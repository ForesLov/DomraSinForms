using DomraSinForms.Application.Interfaces;
using DomraSinForms.Domain.Models.Questions;

namespace DomraSinForms.Application.Questions.Queries.Get;
public class GetQuestionQuery : IGetSingleRequest<QuestionBase?>
{
    public string Id { get; set; } = string.Empty;
}
