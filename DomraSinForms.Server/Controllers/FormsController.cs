using DomraSinForms.Application;
using DomraSinForms.Application.Features.Forms.Commands.Create;
using DomraSinForms.Application.Features.Forms.Commands.Delete;
using DomraSinForms.Application.Features.Forms.Commands.Update;
using DomraSinForms.Application.Features.Forms.Queries.Get;
using DomraSinForms.Application.Features.Forms.Queries.GetList;
using DomraSinForms.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FormsDomraSinForms.Server.Controllers;

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
    public async Task<IActionResult> GetList(int page = 0, int count = 10, string searchText = "", FormOrderApproach order = FormOrderApproach.LastUpdateDescending)
    {
        var userId = _signInManager.UserManager.GetUserId(User);

        var forms = await _mediator.Send(
            new GetFormListQuery
            {
                Count = count,
                Page = page,
                SearchText = searchText,
                UserId = userId,
                OrderBy = order,
            });

        return Ok(forms);
    }

    [Authorize]
    public IActionResult Create()
    {
        var userId = _signInManager.UserManager.GetUserId(User);

        var command = new CreateFormCommand { CreatorId = userId };

        return View(command);
    }
    [HttpPost, Authorize]
    public async Task<IActionResult> Create([FromBody] CreateFormCommand command)
    {
        var result = await _mediator.Send(command);

        return result.AsOption()
            .Map<IActionResult>(Ok)
            .Reduce(BadRequest());
    }

    [HttpPost, Authorize]
    public async Task<IActionResult> Edit([FromBody] UpdateFormCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }
    [HttpPost, Authorize]
    public async Task<IActionResult> Delete(string id)
    {
        var userId = _signInManager.UserManager.GetUserId(User);

        var command = new DeleteFormCommand { Id = id, UserId = userId };
        var result = await _mediator.Send(command);

        return Ok(result);
    }
}
