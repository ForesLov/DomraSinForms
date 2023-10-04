using DomraSinForms.Domain.Identity;
using MediatR;

namespace DomraSinForms.Application.Features.Users.Commands.Update;

public class UpdateUserCommand : IRequest<Option<User>>
{
    /// <summary>
    /// User Id.
    /// </summary>
    public string Id { get; set; }

    public string Email { get; set; }
    public string Username { get; set; }
    public string? NickName { get; set; } = "";
}