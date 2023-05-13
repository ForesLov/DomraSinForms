using DomraSinForms.Application.Answers.Queries.Get;
using DomraSinForms.Application.Answers.Queries.GetEmptyForm;
using DomraSinForms.Application.Answers.Queries.GetList;
using DomraSinForms.Application.Forms.Queries.Get;
using Forms.Mvc.Models.Answers;
using Forms.Mvc.Models.Statistics;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Mvc.Controllers
{
    public class ShowAnswersController : Controller
    {
        private readonly IMediator _mediator;

        public ShowAnswersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Answers(string formId)
        {
            var model = new FormAnswersListViewModel
            {
                AnswersDto = await _mediator.Send(new GetFormAnswersListQuery { FormId = formId }),
                Form = await _mediator.Send(new GetFormQuery { Id = formId })                        
            };
            
            return View(model);
        }
        public async Task<IActionResult> FormAnswers(string formId)
        {
            var command = await _mediator.Send(new GetFormAnswersQuery { Id = formId});

            var cvm = new FillFormViewModel(command);
            return View(cvm);
        }
    }
}

