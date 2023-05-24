using DomraSinForms.Domain.Identity;
using DomraSinForms.Domain.Models.Versions;

namespace DomraSinForms.Domain.Models.Answers;

public class FormAnswers : DbEntity
{
    public string FormId { get; set; } = string.Empty;
    public Form Form { get; set; }
    public List<Answer> Answers { get; set; } = new();
    public bool IsCompleted { get; set; } = false;
    public DateTime CreationDate { get; set; }
    public string UserId { get; set; } = string.Empty;
    public User User { get; set; }
    public string? FormVersionId { get; set; }
    public FormVersion? FormVersion { get; set; }
}
