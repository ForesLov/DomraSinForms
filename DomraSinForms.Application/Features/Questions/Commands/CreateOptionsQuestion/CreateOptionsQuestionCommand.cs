﻿using DomraSinForms.Application.Features.Questions.Commands;
using DomraSinForms.Domain.Models.Questions;

namespace DomraSinForms.Application.Features.Questions.Commands.CreateOptionsQuestion;
public class CreateOptionsQuestionCommand : CreateQuestionBaseCommand<OptionsQuestion>
{
    public List<QuestionOption> Options { get; set; } = new();
    public bool AllowMultipleChoice { get; set; }
}
