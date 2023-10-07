using DomraSinForms.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DomraSinForms.Application.Features.Answers.Commands.Create;
using DomraSinForms.Application.Features.Answers.Commands.Update;
using DomraSinForms.Domain.Models.Answers;

namespace Forms.Mvc.Controllers;

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

        var result = await _mediator.Send(new UpdateFormAnswersCommand
        {
            FormId = formId,
            UserId = userId,
            Answer = new()
            {
                QuestionId = viewModel.QuestionId,
                Value = viewModel.Value,
            }
        });

        if (result is not null)
            return Ok();
        else
            return BadRequest();
    }
    [HttpPost, Authorize]
    public async Task<IActionResult> CompleteForm(string formId)
    {
        var userId = _userManager.GetUserId(User);

        var result = await _mediator.Send(new CreateFormAnswersCommand { FormId = formId, UserId = userId });
        if (result is not null)
            return Ok();

        return BadRequest();
    }
}
