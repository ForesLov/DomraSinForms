using DomraSinForms.Domain.Identity;

namespace DomraSinForms.Domain.Models.Answers;

#nullable disable

public class FormAnswers : DbEntity
{
    public string FormId { get; set; }
    public List<Answer> Answers { get; set; } = new();
    public bool IsCompleted { get; set; } = false;
    public string UserId { get; set; }
    public DateTime CreationDate { get; set; }
    public User User { get; set; }
}
