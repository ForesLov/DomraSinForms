using System.ComponentModel.DataAnnotations;
using DomraSinForms.Domain.Identity;
using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Domain.Models.Questions;
using DomraSinForms.Domain.Models.Versions;

namespace DomraSinForms.Domain.Models;

public class Form : DbEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string CreatorId { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
    public DateTime? LastUpdateDate { get; set; }
    public List<QuestionBase> Questions { get; set; } = new();
    public List<FormAnswers> FormAnswers { get; set; } = new();
    public FormVersion? Version { get; set; }
    public bool IsInArchive { get; set; }
    public ICollection<User> AllowedUsers { get; set; }
}
