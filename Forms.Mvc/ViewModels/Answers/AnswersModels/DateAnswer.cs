using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Domain.Models.Forms.Questions.Types;

namespace Forms.Mvc.ViewModels.Answers.AnswersModels;

public class DateAnswer : DateTimeAnswer
{
    public DateAnswer() : base()
    {
    }

    public DateAnswer(TextQuestion question, Answer answer) : base(question, answer)
    {
    }
    public override string Value
    {
        get => DateTimeValue.HasValue ? DateTimeValue.Value.ToShortDateString() : "";
        set
        {
            if (DateTime.TryParse(value, out _))
                DateTimeValue = DateTime.Parse(value);
        }
    }
}
