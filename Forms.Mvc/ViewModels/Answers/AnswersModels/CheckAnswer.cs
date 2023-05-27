using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Domain.Models.Questions;

namespace Forms.Mvc.ViewModels.Answers.AnswersModels;

public class CheckAnswer : AnswerViewModel
{
    public CheckAnswer() : base() { }
    public CheckAnswer(OptionsQuestion question, Answer answer) : base(question, answer)
    {
        if (!question.AllowMultipleChoice)
            return;

        var options = new List<CheckOption>();
        foreach (var option in question.Options)
        {
            options.Add(new(false, option.Text));
        }
        Options = options;
        Value = answer.Value;
    }
    public List<CheckOption> Options { get; set; } = new();

    public override string Value
    {
        get
        {
            if (Options is null)
                return "";
            var checks = new List<string>();
            foreach (var option in Options)
            {
                if (option.Check)
                    checks.Add(option.Value);
            }
            return string.Join("; ", checks.ToArray());
        }
        set
        {
            if (value is null)
                return;
            if (Options is null)
                return;
            var options = value.Split("; ");
            foreach (var val in options)
            {
                var option = Options.FirstOrDefault(o => o.Value == val);
                if (option is not null)
                    option.Check = true;
            }
        }
    }
}
public class CheckOption
{
    public CheckOption() : this(false, "") { }
    public CheckOption(bool check, string value) => (Check, Value) = (check, value);
    public bool Check { get; set; }
    public string Value { get; set; }
}