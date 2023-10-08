namespace DomraSinForms.Application.Features.Answers.Models;
public class AnonymousFormAnswersDto
{
    public string FormId { get; set; }
    public string Nickname { get; set; }
    public IEnumerable<AnswerDto> Answers { get; set; }
}
