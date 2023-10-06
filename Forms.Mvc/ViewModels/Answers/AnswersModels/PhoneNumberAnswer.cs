using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Text.RegularExpressions;
using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Domain.Models.Forms.Questions.Types;

namespace Forms.Mvc.ViewModels.Answers.AnswersModels;

public class PhoneNumberAnswer : AnswerViewModel
{
    public PhoneNumberAnswer() : base()
    {
    }

    public PhoneNumberAnswer(TextQuestion question, Answer answer) : base(question, answer)
    {
    }
    private string? _value;
    [RegexStringValidator("[\\+\\(\\)\\-\\d]+")]
    [Required(AllowEmptyStrings = false)]
    public override string Value
    {
        get => _value;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                return;
            if (Regex.IsMatch(value, @"[\+\(\)\-\d]+"))
                _value = value;
        }
    }
}
