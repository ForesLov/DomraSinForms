using DomraSinForms.Domain.Models.Questions;
using MediatR;

namespace DomraSinForms.Application.Questions.Queries.GetList;
public class GetQuestionListQuery : IRequest<IEnumerable<QuestionBase>>
{
    public int Page { get => 0; set { } }
    public int Count { get => int.MaxValue; set { } }
    public string SearchText { get => ""; set { } }
    public string FormId { get; set; } = string.Empty;
}
