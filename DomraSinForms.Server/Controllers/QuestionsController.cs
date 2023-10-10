using DomraSinForms.Application.Features.Questions.Commands.CreateOptionsQuestion;
using DomraSinForms.Application.Features.Questions.Commands.CreateTextQuestion;
using DomraSinForms.Application.Features.Questions.Commands.Delete;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DomraSinForms.Server.Controllers;

public class QuestionsController : Controller
{
    private readonly IMediator _mediator;

    public QuestionsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost, Authorize]
    public async Task<IActionResult> CreateTextQuestion([FromBody] CreateTextQuestionCommand command)
    {

        var result = await _mediator.Send(command);

        return Ok(result);
    }
    [HttpPost, Authorize]
    public async Task<IActionResult> CreateOptionsQuestion([FromBody] CreateOptionsQuestionCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }
    /*[HttpPost]
    public async Task<IActionResult> UpdateTextQuestion([FromBody] UpdateTextQuestionViewModel viewModel)
    {
        QuestionBase? q = null;
        try
        {
            q = await _mediator.Send(viewModel.Command);
        }
        catch { }

        return RedirectToAction(
            controllerName: "Forms",
            actionName: nameof(FormsController.Edit),
            routeValues: new { id = q?.FormId });
    }
    [HttpPost]
    public async Task<IActionResult> UpdateOptionsQuestion([FromBody] UpdateOptionsQuestionCommand command)
    {

        var q = await _mediator.Send(command);

        return RedirectToAction(
            controllerName: "Forms",
            actionName: nameof(FormsController.Edit),
            routeValues: new { id = q.FormId });
    }*/
    [HttpPost, Authorize]
    public async Task<IActionResult> Delete(string id, string formId)
    {
        var result = await _mediator.Send(new DeleteQuestionCommand { Id = id });

        return Ok(result);
    }
}
