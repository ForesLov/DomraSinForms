using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Features.Users.Commands.Update;
public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Option<User>>
{
    private readonly UserManager<User> _userManager;

    public UpdateUserCommandHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }
    public async Task<Option<User>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(user => user.Id == request.Id, cancellationToken);
        if (user is null)
            return Option<User>.None();

        user.Email = request.Email;
        user.UserName = request.Username;
        if (!string.IsNullOrWhiteSpace(request.NickName))
            user.NickName = request.NickName;

        await _userManager.UpdateAsync(user);

        return Option<User>.Some(user);
    }
}
