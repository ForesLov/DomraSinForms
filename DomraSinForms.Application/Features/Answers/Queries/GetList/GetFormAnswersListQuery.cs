using MediatR;

namespace DomraSinForms.Application.Features.Answers.Queries.GetList;
public class GetFormAnswersListQuery : IRequest<IEnumerable<FormAnswersDto>>
{
    public int Page { get => 0; set { } }
    public int Count { get => int.MaxValue; set { } }
    public string SearchText { get; set; } = "";
    public string FormId { get; set; } = "";
}
