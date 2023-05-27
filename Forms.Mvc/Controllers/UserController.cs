using DomraSinForms.Application.Users.Update;
using DomraSinForms.Domain.Identity;
using Forms.Mvc.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Mvc.Controllers;

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
    public async Task<IActionResult> Profile()
    {
        var user = await _userManager.GetUserAsync(User);
        return View(user);
    }
    [HttpPost]
    public async Task<IActionResult> Edit([Bind] UpdateUserCommand command)
    {
        return 
            (await _mediator.Send(command))
            .Map(user => RedirectToAction(nameof(Profile)))
            .Reduce(RedirectToAction(controllerName: "Home", actionName: "Index"));
    }
}
