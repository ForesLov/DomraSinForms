﻿using DomraSinForms.Application.Questions.Commands.CreateOptionsQuestion;
using DomraSinForms.Application.Questions.Commands.CreateTextQuestion;
using DomraSinForms.Application.Questions.Commands.Delete;
using DomraSinForms.Application.Questions.Commands.Update;
using DomraSinForms.Application.Questions.Queries.Get;
using DomraSinForms.Application.Questions.Queries.GetList;
using DomraSinForms.Domain.Models.Questions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Api.Controllers;

public class QuestionsController : CRUDController<QuestionBase, CreateTextQuestionCommand, GetQuestionQuery, GetQuestionListQuery, UpdateQuestionCommand, DeleteQuestionCommand>
{
    public QuestionsController(IMediator mediator) : base(mediator)
    {
    }
    [NonAction]
    public override Task<QuestionBase> Create([FromBody] CreateTextQuestionCommand command)
    {
        throw new NotImplementedException();
    }
    [NonAction]
    public override Task<QuestionBase> Update([FromBody] UpdateQuestionCommand command)
    {
        throw new NotImplementedException();
    }
    [HttpPost]
    public async Task<OptionsQuestion> CreateOptionsQuestion([FromBody] CreateOptionsQuestionCommand command)
    {
        return await _mediator.Send(command);
    }
    [HttpPost]
    public async Task<TextQuestion> CreateTextQuestion([FromBody] CreateTextQuestionCommand command)
    {
        return await _mediator.Send(command);
    }
}
