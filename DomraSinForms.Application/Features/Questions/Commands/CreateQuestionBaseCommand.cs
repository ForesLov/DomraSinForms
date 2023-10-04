using DomraSinForms.Domain.Models.Questions;
using MediatR;

namespace DomraSinForms.Application.Features.Questions.Commands;
public class CreateQuestionBaseCommand
{
    public string FormId { get; set; } = string.Empty;
    public string QuestionText { get; set; } = string.Empty;
    public bool IsRequired { get; set; } = false;
}
public class CreateQuestionBaseCommand<TQuestion> : CreateQuestionBaseCommand, IRequest<TQuestion> where TQuestion : QuestionBase
{

}
