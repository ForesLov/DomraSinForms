using System.Security.Claims;
using MediatR;

namespace DomraSinForms.Application.Features.Answers.Queries.GetFormScore;
public record GetFormScoreQuery(string FormAnswersId, ClaimsPrincipal User) : IRequest<Option<ScoreDto>>;
