using DomraSinForms.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DomraSinForms.Application.Features.Answers.Commands.Complete;
using DomraSinForms.Application.Features.Answers.Commands.Update;
using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Application;

namespace DomraSinForms.Server.Controllers;

public class AnswersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly UserManager<User> _userManager;
    private readonly ILogger<AnswersController> _logger;

    public AnswersController(
        IMediator mediator,
        UserManager<User> userManager,
        ILogger<AnswersController> logger)
    {
        _mediator = mediator;
        _userManager = userManager;
        _logger = logger;
    }

    [HttpPost, Authorize]
    public async Task<IActionResult> UpdateFormAnswers([FromRoute] string formId, [FromBody] Answer viewModel)
    {
        var userId = _userManager.GetUserId(User);

        var result = await _mediator.Send(new UpdateFormAnswersCommand(
            new()
            {
                QuestionId = viewModel.QuestionId,
                Value = viewModel.Value,
            }, formId, userId));

        return result
            .AsOption()
            .Map<IActionResult>(Ok)
            .Reduce(BadRequest());
    }

    [HttpPost, Authorize]
    public async Task<IActionResult> CompleteForm([FromRoute] string formId)
    {
        var userId = _userManager.GetUserId(User);

        var result = await _mediator.Send(new CompleteFormAnswersCommand { FormId = formId, UserId = userId });

        return result.AsOption().Map<IActionResult>(Ok).Reduce(BadRequest());
    }
}
