using DomraSinForms.Domain.Models.Answers;
using MediatR;

namespace DomraSinForms.Application.Answers.Commands.Update;

public class UpdateFormAnswersCommand : IRequest<FormAnswers?>
{
    public string FormId { get; set; } = "";
    public string UserId { get; set; } = "";
    public Answer? Answer { get; set; }
}
