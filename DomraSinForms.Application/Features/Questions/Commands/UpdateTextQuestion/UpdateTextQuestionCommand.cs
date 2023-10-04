using DomraSinForms.Application.Features.Questions.Commands;
using DomraSinForms.Application.Mapper;
using DomraSinForms.Domain.Models.Questions;

namespace DomraSinForms.Application.Features.Questions.Commands.UpdateTextQuestion;
public class UpdateTextQuestionCommand : UpdateQuestionBaseCommand<TextQuestion>, IMapWith<QuestionBase>
{
    public TextQuestionType Type { get; set; }
}
