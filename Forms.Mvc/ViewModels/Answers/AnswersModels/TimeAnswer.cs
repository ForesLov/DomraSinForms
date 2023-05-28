using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Domain.Models.Questions;

namespace Forms.Mvc.ViewModels.Answers.AnswersModels;

public class TimeAnswer : DateTimeAnswer
{
    public TimeAnswer() : base()
    {
    }

    public TimeAnswer(TextQuestion question, Answer answer) : base(question, answer)
    {
    }
    public override string Value
    {
        get => DateTimeValue.HasValue ? DateTimeValue.Value.ToShortTimeString() : "";
        set
        {
            if (DateTime.TryParse(value, out _))
                DateTimeValue = DateTime.Parse(value);
        }
    }
}
