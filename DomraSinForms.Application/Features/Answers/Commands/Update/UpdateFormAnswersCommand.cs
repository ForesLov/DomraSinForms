using DomraSinForms.Domain.Models.Answers;
using MediatR;

namespace DomraSinForms.Application.Features.Answers.Commands.Update;

public record UpdateFormAnswersCommand(Answer? Answer, string FormId, string UserId) : IRequest<FormAnswers?>;