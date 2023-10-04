using MediatR;

namespace DomraSinForms.Application.Features.Users.Queries.GetPersonalInfo;

public record GetPersonalInfo(string UserId) : IRequest<Option<PersonalInfo>>;