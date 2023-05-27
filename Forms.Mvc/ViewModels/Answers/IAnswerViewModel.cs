using DomraSinForms.Domain.Models.Questions;

namespace Forms.Mvc.ViewModels.Answers;

public interface IAnswerViewModel
{
    public string QuestionId { get; set; }
    public string FormId { get; set; }
    public int Index { get; set; }
    public bool IsRequired { get; set; }
    public string Value { get; set; }
    public QuestionBase? Question { get; set; }
}
