using DomraSinForms.Domain.Models.Answers;
using MediatR;

namespace DomraSinForms.Application.Answers.Queries.GetQuestionAnswers;
public class GetQuestionAnswersQuery : IRequest<IEnumerable<Answer>>
{
    /// <summary>
    /// Question Id.
    /// </summary>
    public string QuestionId { get; set; } = "";
}
