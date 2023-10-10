using DomraSinForms.Application.Features.Users.Commands.Update;
using DomraSinForms.Application.Features.Users.Queries.GetPersonalInfo;
using DomraSinForms.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DomraSinForms.Server.Controllers;

[Authorize]
public class UserController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly IMediator _mediator;

    public UserController(UserManager<User> userManager, IMediator mediator)
    {
        _userManager = userManager;
        _mediator = mediator;
    }
    [Authorize]
    public async Task<IActionResult> GetPersonalInfo()
    {
        var userId = _userManager.GetUserId(User);

        return (await _mediator.Send(new GetPersonalInfo(userId)))
            .Map<IActionResult>(Ok)
            .Reduce(BadRequest());
    }
    [HttpPost, Authorize]
    public async Task<IActionResult> Edit([Bind] UpdateUserCommand command)
    {
        return 
            (await _mediator.Send(command))
            .Map<IActionResult>(user => Ok())
            .Reduce(BadRequest());
    }
}
