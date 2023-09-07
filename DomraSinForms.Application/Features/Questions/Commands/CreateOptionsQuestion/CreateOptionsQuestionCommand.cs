using DomraSinForms.Domain.Models.Questions;

namespace DomraSinForms.Application.Questions.Commands.CreateOptionsQuestion;
public class CreateOptionsQuestionCommand : CreateQuestionBaseCommand<OptionsQuestion>
{
    public List<QuestionOption> Options { get; set; } = new();
    public bool AllowMultipleChoice { get; set; }
}
