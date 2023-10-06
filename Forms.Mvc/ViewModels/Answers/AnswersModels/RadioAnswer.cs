using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Domain.Models.Forms.Questions.Types;

namespace Forms.Mvc.ViewModels.Answers.AnswersModels;

public class RadioAnswer : AnswerViewModel
{
    public RadioAnswer() : base() { }
    public RadioAnswer(OptionsQuestion question, Answer answer) : base(question, answer)
    {
        if (question.AllowMultipleChoice)
            return;
        foreach (var option in question.Options)
        {
            Options.Add(option.Text);
        }
        Value = answer.Value;
    }
    public List<string> Options { get; set; } = new();
    public string SelectedValue { get; set; } = "";
    public override string Value
    {
        get => SelectedValue;
        set
        {
            if (Options is null | Options?.Count == 0)
                return;
            var val = Options?.FirstOrDefault(o => o == value);

            if (val is not null)
                SelectedValue = val;
        }
    }
}
