using DomraSinForms.Domain.Models.Forms.Questions.Types;

namespace DomraSinForms.Application.Features.Questions.Commands.CreateTextQuestion;

public class CreateTextQuestionCommand : CreateQuestionBaseCommand<TextQuestion>
{
    public TextQuestionType Type { get; set; }
}