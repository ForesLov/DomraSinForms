using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Domain.Models.Questions;

namespace Forms.Mvc.ViewModels.Answers.AnswersModels;

public class DateTimeAnswer : AnswerViewModel
{
    public DateTimeAnswer(TextQuestion question, Answer answer) : base(question, answer)
    {
    }
    public DateTimeAnswer() : base()
    {

    }
    public DateTime DateTimeValue { get; set; }
    public override string Value
    {
        get => DateTimeValue.ToString();
        set
        {
            if (DateTime.TryParse(value, out _))
                DateTimeValue = DateTime.Parse(value);
        }
    }
}
