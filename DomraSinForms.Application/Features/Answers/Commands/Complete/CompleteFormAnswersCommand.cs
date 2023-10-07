using DomraSinForms.Domain.Models.Answers;
using MediatR;

namespace DomraSinForms.Application.Features.Answers.Commands.Complete;

public class CompleteFormAnswersCommand : IRequest<FormAnswers?>
{
    public string UserId { get; set; } = "";
    public string FormId { get; set; } = "";
}