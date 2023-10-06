using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Domain.Models.Forms.Questions.Types;

namespace Forms.Mvc.ViewModels.Answers.AnswersModels;

public class DecimalAnswer : AnswerViewModel
{
    public DecimalAnswer() : base() { }

    public DecimalAnswer(TextQuestion question, Answer answer) : base(question, answer) { }
    private decimal? _number;
    public override string Value
    {
        get
        {
            if (_number.HasValue)
                return _number.Value.ToString();
            else
                return string.Empty;
        } 
        set
        {
            if (decimal.TryParse(value, out decimal number))
            {
                _number = number;
            }
        }
    }
}
