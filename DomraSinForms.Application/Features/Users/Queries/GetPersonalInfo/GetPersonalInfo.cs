using MediatR;

namespace DomraSinForms.Application.Users.Queries.GetPersonalInfo;

public record GetPersonalInfo(string UserId) : IRequest<Option<PersonalInfo>>;