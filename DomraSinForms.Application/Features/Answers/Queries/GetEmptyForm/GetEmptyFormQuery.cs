using DomraSinForms.Application.Answers.Queries.GetList;
using MediatR;

namespace DomraSinForms.Application.Answers.Queries.GetEmptyForm;
public class GetEmptyFormQuery : IRequest<FormAnswersDto?>
{
    public string FormId { get; set; } = "";
    public string UserId { get; set; } = "";
}
