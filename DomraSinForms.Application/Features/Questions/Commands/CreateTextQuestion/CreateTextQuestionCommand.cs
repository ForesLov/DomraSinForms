using DomraSinForms.Domain.Models.Questions;

namespace DomraSinForms.Application.Features.Questions.Commands.CreateTextQuestion;

public class CreateTextQuestionCommand : CreateQuestionBaseCommand<TextQuestion>
{
    public TextQuestionType Type { get; set; }
}