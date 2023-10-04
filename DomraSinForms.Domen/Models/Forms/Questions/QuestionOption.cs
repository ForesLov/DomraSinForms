namespace DomraSinForms.Domain.Models.Questions;

#nullable disable

public class QuestionOption : DbEntity
{
    public string Text { get; set; }
    public OptionsQuestion Question { get; set; }
    public string QuestionId { get; set; }
}