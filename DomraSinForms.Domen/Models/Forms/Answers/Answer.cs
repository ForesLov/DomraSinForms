using DomraSinForms.Domain.Models.Questions;

namespace DomraSinForms.Domain.Models.Answers;

#nullable disable

public class Answer : DbEntity
{
    public string QuestionId { get; set; }
    public QuestionBase Question { get; set; }
    public string Value { get; set; }
}
