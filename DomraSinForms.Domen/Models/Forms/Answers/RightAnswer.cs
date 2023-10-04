using System.ComponentModel.DataAnnotations;

namespace DomraSinForms.Domain.Models.Answers;

public class RightAnswer : DbEntity
{
    public string QuestionId { get; set; }
    public string Answer { get; set; }
    [Range(1, int.MaxValue)]
    public int Points { get; set; }
}