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
    public AnswersController(IMediator mediator, UserManager<User> userManager)
    {
        _mediator = mediator;
        _userManager = userManager;
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

    /// <summary>
    /// Returns form object with all questions and its data (is it required, options, etc). 
    /// If user authorized and has answer some questions already, returns filled answers.
    /// </summary>
    /// <param name="formId"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> GetToFill([FromRoute] string formId)
    {
        return NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> GetScore([FromRoute] string formAnswersId)
    {
        return NotFound();
    }
}
