using DomraSinForms.Application.Interfaces;

namespace DomraSinForms.Application.Features.Questions.Commands.Delete;
public class DeleteQuestionCommand : IDeleteRequest
{
    public string Id { get; set; } = string.Empty;
}
