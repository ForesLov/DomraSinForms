﻿using DomraSinForms.Application.Answers.Queries.GetList;
using Forms.Mvc.Models.Statistics;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Mvc.Controllers
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
        public async Task<IActionResult> Summary(string formId)
        {
            var vm = new SummaryViewModel
            {
                FormId = formId,
                AnswersDto = await _mediator.Send(new GetFormAnswersListQuery { FormId = formId }),
            };
            return View(vm);
        }
        /// <summary>
        /// Выводит все ответы одного пользователя.
        /// </summary>
        /// <param name="formId"></param>
        /// <returns></returns>
        public async Task<IActionResult> FormAnswersList(string formId)
        {
            var vm = new FormAnswersViewModel
            {
                FormId = formId,
                FormAnswersList = await _mediator.Send(new GetFormAnswersListQuery { FormId = formId })
            };
            return View(vm);
        }
        /// <summary>
        /// Выводит все ответы на вопрос.
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IActionResult> Question(string questionId)
        {
            return View();
        }
    }
}


/*public async Task<IActionResult> Answers(string formId)
{
    var model = new FormAnswersListViewModel
    {
        AnswersDto = await _mediator.Send(new GetFormAnswersListQuery { FormId = formId }),
        Form = await _mediator.Send(new GetFormQuery { Id = formId })                        
    };

    return View(model);
}*/