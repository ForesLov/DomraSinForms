using DomraSinForms.Domain.Models.Answers;

namespace Forms.Mvc.ViewModels.Answers;

public interface IAnswerViewModelFactory
{
    IEnumerable<IAnswerViewModel> GetAnswers(IEnumerable<Answer> answers);
}