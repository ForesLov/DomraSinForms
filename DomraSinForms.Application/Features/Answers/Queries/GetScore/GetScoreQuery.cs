using System.Security.Claims;
using MediatR;

namespace DomraSinForms.Application.Features.Answers.Queries.GetScore;
public record GetScoreQuery(string FormAnswersId, ClaimsPrincipal User) : IRequest<Option<ScoreDto>>;
