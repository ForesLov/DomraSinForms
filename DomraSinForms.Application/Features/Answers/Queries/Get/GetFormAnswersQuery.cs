using DomraSinForms.Application.Interfaces;
using DomraSinForms.Domain.Models.Answers;

namespace DomraSinForms.Application.Features.Answers.Queries.Get;

public class GetFormAnswersQuery : IGetSingleRequest<FormAnswers?>
{
    /// <summary>
    /// Form answers Id.
    /// </summary>
    public string Id { get; set; } = "";
}