using System.Security.Cryptography.Xml;
using DomraSinForms.Application;
using DomraSinForms.Application.Answers.Commands.Create;
using DomraSinForms.Application.Answers.Commands.Update;
using DomraSinForms.Application.Answers.Queries.GetEmptyForm;
using DomraSinForms.Application.Answers.Queries.GetList;
using DomraSinForms.Domain.Models;
using DomraSinForms.Application.Forms.Queries.Get;
using DomraSinForms.Application.Forms.Queries.GetList;
using DomraSinForms.Application.Forms.Queries.GetMin;
using DomraSinForms.Domain.Identity;
using Forms.Mvc.Helpers;
using Forms.Mvc.ViewModels.Answers;
using Forms.Mvc.ViewModels.Answers.AnswersModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Mvc.Controllers;

public class AnswersController : Controller
{
    private readonly IMediator _mediator;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ILogger<AnswersController> _logger;

    public AnswersController(
        IMediator mediator, 
        UserManager<User> userManager, 
        SignInManager<User> signInManager,
        ILogger<AnswersController> logger)
    {
        _mediator = mediator;
        _userManager = userManager;
        _signInManager = signInManager;
        _logger = logger;
    }
    [Authorize]
    public async Task<IActionResult> Index(int page = 0, int count = 10, string searchText = "", FormOrderApproach order = FormOrderApproach.LastUpdateDescending)
    {
        var userId = _signInManager.UserManager.GetUserId(User);
        if (userId is null)
            return NotFound();

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
    /// <summary>
    /// Returns view with questions to answer.
    /// </summary>
    /// <param name="id"><see cref="Form"/> id.</param>
    /// <returns></returns>
    [Authorize]
    public async Task<IActionResult> Fill(string id)
    {
        var form = await _mediator.Send(new GetMinFormQuery { Id = id });
        var userId = _userManager.GetRequiredUserId(User);

        //if (form is null || userId is null || form.IsInArchive)
          //  return RedirectToAction(controllerName: "Home", actionName: "Index");

          return Option<FormAnswersDto>
              .Some(await _mediator.Send(new GetEmptyFormQuery { FormId = id, UserId = userId }))
              .Map<IActionResult>(any => View(new FillFormViewModel(any, form.Reduce(null))))
              .Reduce(RedirectToAction(controllerName: "Home", actionName: "Index"));
    }
    public async Task<IActionResult> UpdateStringAnswer([Bind] StringAnswer answer)
    {
        return await UpdateForm(answer);
    }
    public async Task<IActionResult> UpdateDecimalAnswer([Bind] DecimalAnswer answer)
    {
        return await UpdateForm(answer);
    }
    public async Task<IActionResult> UpdateDateAnswer([Bind] DateAnswer answer)
    {
        return await UpdateForm(answer);
    }
    public async Task<IActionResult> UpdateTimeAnswer([Bind] TimeAnswer answer)
    {
        return await UpdateForm(answer);
    }
    public async Task<IActionResult> UpdateDateTimeAnswer([Bind] DateTimeAnswer answer)
    {
        return await UpdateForm(answer);
    }
    public async Task<IActionResult> UpdatePhoneNumberAnswer([Bind] PhoneNumberAnswer answer)
    {
        return await UpdateForm(answer);
    }
    public async Task<IActionResult> UpdateCheckAnswer([Bind] CheckAnswer answer)
    {
        return await UpdateForm(answer);
    }
    public async Task<IActionResult> UpdateRadioAnswer([Bind] RadioAnswer answer)
    {
        return await UpdateForm(answer);
    }
    protected async Task<IActionResult> UpdateForm(IAnswerViewModel viewModel)
    {
        var userId = _userManager.GetUserId(User);
        if (userId is null)
            return RedirectToAction(nameof(Fill), routeValues: new { formId = viewModel.FormId });

        var result = await _mediator.Send(new UpdateFormAnswersCommand
        {
            FormId = viewModel.FormId,
            UserId = userId,
            Answer = new()
            {
                QuestionId = viewModel.QuestionId,
                Value = viewModel.Value,
            }
        });
        if (result is not null)
            return RedirectToAction(nameof(Fill), routeValues: new { id = result.FormId });

        return RedirectToAction("Index", "Home");
    }
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CompleteForm(string formId)
    {
        var userId = _userManager.GetUserId(User);
        if (userId is null)
            return RedirectToAction(nameof(Fill), routeValues: new { id = formId });

        var result = await _mediator.Send(new CreateFormAnswersCommand { FormId = formId, UserId = userId });
        if (result is null)
            return RedirectToAction(nameof(Fill), routeValues: new { id = formId });

        return RedirectToAction(nameof(AnsweredForm));
    }
    public IActionResult AnsweredForm()
    {
        return View();
    }

}
