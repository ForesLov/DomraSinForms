﻿using DomraSinForms.Domain.Models.Answers;

namespace DomraSinForms.Domain.Models.Questions;

public abstract class QuestionBase : DbEntity
{
    public string QuestionText { get; set; } = string.Empty;
    public int Index { get; set; }
    public string FormId { get; set; } = string.Empty;
    public bool IsRequired { get; set; }
    public ICollection<Answer> Answers { get; set; }
    //public ICollection<RightAnswer>? RightAnswers { get; set; }
}