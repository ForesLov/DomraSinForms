﻿namespace DomraSinForms.Domain.Models.Questions;
public class RadioQuestion : QuestionBase
{
    public IEnumerable<QuestionOption> Options { get; set; }
}