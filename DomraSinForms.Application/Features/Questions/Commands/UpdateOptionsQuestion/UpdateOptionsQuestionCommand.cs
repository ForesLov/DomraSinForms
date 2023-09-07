using DomraSinForms.Domain.Models.Questions;

namespace DomraSinForms.Application.Questions.Commands.UpdateOptionsQuestion;

#nullable disable

public class UpdateOptionsQuestionCommand : UpdateQuestionBaseCommand<OptionsQuestion>
{
    public ICollection<QuestionOption> Options { get; set; }
    public bool AllowMultipleChoice { get; set; }
}
