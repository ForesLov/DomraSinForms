using DomraSinForms.Application.Features.Forms.Commands.Create;
using DomraSinForms.Application.Features.Forms.Commands.Delete;
using DomraSinForms.Application.Features.Forms.Commands.Update;
using DomraSinForms.Application.Features.Forms.Queries.Get;
using DomraSinForms.Application.Features.Forms.Queries.GetList;
using DomraSinForms.Domain.Identity;
using Forms.Mvc.Helpers;
using Forms.Mvc.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Mvc.Controllers;

public class FormsController : Controller
{
    private readonly IMediator _mediator;
    private readonly SignInManager<User> _signInManager;

    public FormsController(IMediator mediator, SignInManager<User> signInManager)
    {
        _mediator = mediator;
        _signInManager = signInManager;
    }
    [Authorize]
    public async Task<IActionResult> Index(int page = 0, int count = 10, string searchText = "", FormOrderApproach order = FormOrderApproach.LastUpdateDescending)
    {
        var userId = _signInManager.UserManager.GetRequiredUserId(User);

        var forms = await _mediator.Send(
            new GetFormListQuery
            {
                Count = count,
                Page = page,
                SearchText = searchText,
                UserId = userId,
                OrderBy = order,
            });

        return View(forms);
    }

    [Authorize]
    public IActionResult Create()
    {
        var userId = _signInManager.UserManager.GetRequiredUserId<User>(User);

        var command = new CreateFormCommand { CreatorId = userId };

        return View(command);
    }
    [HttpPost, Authorize]
    public async Task<IActionResult> Create([Bind] CreateFormCommand command)
    {
        if (!ModelState.IsValid)
            return View(command);

        var result = await _mediator.Send(command);
        if (result is not null)
            return RedirectToAction(nameof(Edit), new { id = result.Id });
        return RedirectToIndex();
    }
    [Authorize]
    public async Task<IActionResult> Edit(string id)
    {
        var userId = _signInManager.UserManager.GetRequiredUserId(User);

        var form = await _mediator.Send(new GetFormQuery(id, userId));
        
        return form
            .Map<IActionResult>(any => View(new EditFormViewModel { Form = any }))
            .Reduce(RedirectToIndex());
    }
    [HttpPost, Authorize]
    public async Task<IActionResult> Edit([Bind] UpdateFormCommand command)
    {
        if (ModelState.IsValid)
            await _mediator.Send(command);

        return RedirectToAction(nameof(Edit), routeValues: new { Id = command.Id });
    }
    [HttpPost, Authorize]
    public async Task<IActionResult> Delete(string id)
    {
        var userId = _signInManager.UserManager.GetRequiredUserId(User);

        var command = new DeleteFormCommand { Id = id, UserId = userId };
        await _mediator.Send(command);

        return RedirectToIndex();
    }

    private IActionResult RedirectToIndex()
    {
        return RedirectToAction(nameof(Index));
    }
}
