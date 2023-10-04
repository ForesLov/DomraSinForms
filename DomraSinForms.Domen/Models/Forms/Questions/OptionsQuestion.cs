namespace DomraSinForms.Domain.Models.Questions;
public class OptionsQuestion : QuestionBase
{
    public ICollection<QuestionOption> Options { get; set; } = new List<QuestionOption>();

    public bool AllowMultipleChoice { get; set; }
}
