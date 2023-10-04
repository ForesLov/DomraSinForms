using DomraSinForms.Application.Features.Questions.Commands.CreateOptionsQuestion;
using DomraSinForms.Application.Features.Questions.Commands.CreateTextQuestion;
using DomraSinForms.Application.Features.Questions.Commands.UpdateOptionsQuestion;
using DomraSinForms.Application.Questions.Commands.Delete;
using DomraSinForms.Domain.Models.Questions;
using Forms.Mvc.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Mvc.Controllers;

public class QuestionsController : Controller
{
    private readonly IMediator _mediator;

    public QuestionsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> CreateTextQuestion([Bind] CreateTextQuestionCommand command)
    {
        //if (!string.IsNullOrWhiteSpace(viewModel.CreateTextQuestionCommand.QuestionText))
        try
        {
            _ = await _mediator.Send(command);
        }
        catch { }
        return RedirectToAction(
            controllerName: "Forms",
            actionName: nameof(FormsController.Edit),
            routeValues: new { id = command.FormId });
    }
    [HttpPost]
    public async Task<IActionResult> CreateOptionsQuestion([Bind] CreateOptionsQuestionCommand command)
    {
        try
        {
            _ = await _mediator.Send(command);
        }
        catch { }
        return RedirectToAction(
            controllerName: "Forms",
            actionName: nameof(FormsController.Edit),
            routeValues: new { id = command.FormId });
    }
    [HttpPost]
    public async Task<IActionResult> UpdateTextQuestion([Bind] UpdateTextQuestionViewModel viewModel)
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
    public async Task<IActionResult> UpdateOptionsQuestion([Bind] UpdateOptionsQuestionCommand command)
    {

        var q = await _mediator.Send(command);

        return RedirectToAction(
            controllerName: "Forms",
            actionName: nameof(FormsController.Edit),
            routeValues: new { id = q.FormId });
    }
    [HttpPost]
    public async Task<IActionResult> Delete(string id, string formId)
    {
        var q = await _mediator.Send(new DeleteQuestionCommand { Id = id });

        return RedirectToAction(
            controllerName: "Forms",
            actionName: nameof(FormsController.Edit),
            routeValues: new { id = formId });
    }
    [HttpPost]
    public IActionResult AddNewOption()
    {
        return PartialView("/Views/Questions/_OptionPartial.cshtml", new QuestionOption());
    }
}
