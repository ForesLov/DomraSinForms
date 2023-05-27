using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Domain.Models.Questions;

namespace Forms.Mvc.ViewModels.Answers.AnswersModels;

public class DecimalAnswer : AnswerViewModel
{
    public DecimalAnswer() : base() { }

    public DecimalAnswer(TextQuestion question, Answer answer) : base(question, answer) { }
    public decimal Number { get; set; }
    public override string Value { get => Number.ToString(); set { } }
}
