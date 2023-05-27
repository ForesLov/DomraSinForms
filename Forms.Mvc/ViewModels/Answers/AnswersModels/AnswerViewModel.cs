using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Domain.Models.Questions;

namespace Forms.Mvc.ViewModels.Answers.AnswersModels;

public abstract class AnswerViewModel : IAnswerViewModel
{
    public AnswerViewModel(QuestionBase question, Answer answer)
    {
        Index = question.Index;
        IsRequired = question.IsRequired;
        QuestionId = question.Id;
        FormId = question.FormId;
        Question = question;
        Value = answer.Value;
    }
    public AnswerViewModel() { }

    public string FormId { get; set; } = "";
    public string QuestionId { get; set; } = "";
    public int Index { get; set; } = int.MaxValue;
    public bool IsRequired { get; set; } = false;
    public abstract string Value { get; set; }
    public QuestionBase? Question { get; set; }
}
