using DomraSinForms.Domain.Models.Questions;

namespace DomraSinForms.Domain.Models.Forms.Questions.Types;
public class OptionsQuestion : QuestionBase
{
    public ICollection<QuestionOption> Options { get; set; } = new List<QuestionOption>();

    public bool AllowMultipleChoice { get; set; }
}
