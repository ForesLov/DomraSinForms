using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Domain.Models.Questions;

namespace Forms.Mvc.ViewModels.Answers.AnswersModels;

public class StringAnswer : AnswerViewModel
{
    public StringAnswer(TextQuestion question, Answer answer) : base(question, answer) { }
    public StringAnswer() : base() { }
    public string AnswerValue { get; set; } = "";
    public override string Value
    {
        get => AnswerValue;
        set => AnswerValue = value;
    }
}
