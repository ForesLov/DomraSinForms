using System.ComponentModel.DataAnnotations;
using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Domain.Models.Questions;

namespace DomraSinForms.Domain.Models;

#nullable disable

public class Form : DbEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string CreatorId { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? LastUpdateDate { get; set; }
    public List<QuestionBase> Questions { get; set; } = new();
    public List<FormAnswers> FormAnswers { get; set; } = new();
    public bool AllowAnonymous { get; set; } = false;
    public int Version { get; set; }
}
