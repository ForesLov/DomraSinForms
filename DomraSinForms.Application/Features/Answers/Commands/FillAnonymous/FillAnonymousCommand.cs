using DomraSinForms.Application.Features.Answers.Models;
using MediatR;

namespace DomraSinForms.Application.Features.Answers.Commands.FillAnonymous;
public record FillAnonymousCommand(AnonymousFormAnswersDto FormAnswers) : IRequest<bool>;
