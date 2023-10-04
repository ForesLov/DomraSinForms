using MediatR;

namespace DomraSinForms.Application.Features.Users.Queries.GetUserActionsSummary;

public class GetUserActionsSummaryQuery : IRequest<UsersActionsSummary?>
{
    public string UserId { get; set; }
}