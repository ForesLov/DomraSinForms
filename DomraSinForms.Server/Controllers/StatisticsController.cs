/*using DomraSinForms.Application.Features.Answers.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DomraSinForms.Server.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Выводит все вопросы и диаграммы для их ответов.
        /// </summary>
        /// <param name="formId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [Authorize]
        public async Task<IActionResult> Summary(string formId)
        {
            var vm = new SummaryViewModel
            {
                FormId = formId,
                AnswersDto = await _mediator.Send(new GetFormAnswersListQuery { FormId = formId }),
            };
            if (vm.AnswersDto is null)
                return NotFound();
            return View(vm);
        }
        /// <summary>
        /// Выводит все ответы одного пользователя.
        /// </summary>
        /// <param name="formId"></param>
        /// <returns></returns>
        [Authorize]
        public async Task<IActionResult> FormAnswersList(string formId)
        {
            var vm = new FormAnswersViewModel
            {
                FormId = formId,
                FormAnswersList = await _mediator.Send(new GetFormAnswersListQuery { FormId = formId })
            };
            if (vm.FormAnswersList is null)
                return NotFound();
            return View(vm);
        }
    }
}*/