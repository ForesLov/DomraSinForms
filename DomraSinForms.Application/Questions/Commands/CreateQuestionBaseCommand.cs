﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.Domain.Models.Questions;
using MediatR;

namespace DomraSinForms.Application.Questions.Commands;
public class CreateQuestionBaseCommand
{
    public string FormId { get; set; }
    public string QuestionText { get; set; }
}
public class CreateQuestionBaseCommand<TQuestion> : CreateQuestionBaseCommand, IRequest<TQuestion> where TQuestion : QuestionBase
{

}