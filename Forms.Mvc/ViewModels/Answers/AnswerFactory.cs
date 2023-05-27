using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Domain.Models.Questions;
using Forms.Mvc.ViewModels.Answers.AnswersModels;

namespace Forms.Mvc.ViewModels.Answers;

public class AnswerFactory : IAnswerViewModelFactory
{
    public IEnumerable<IAnswerViewModel> GetAnswers(IEnumerable<Answer>? answers)
    {
        if (answers is null)
            yield break;
        foreach (var answer in answers)
        {
            switch (answer.Question)
            {
                case OptionsQuestion oq:
                    if (oq.AllowMultipleChoice)
                    {
                        yield return new CheckAnswer(oq, answer);
                    }
                    else
                    {
                        yield return new RadioAnswer(oq, answer);
                    }
                    break;
                case TextQuestion tq:
                    switch (tq.Type)
                    {
                        case TextQuestionType.Text:
                            yield return new StringAnswer(tq, answer);
                            break;
                        case TextQuestionType.Number:
                            yield return new DecimalAnswer(tq, answer);
                            break;
                        case TextQuestionType.Date:
                            yield return new DateAnswer(tq, answer);
                            break;
                        case TextQuestionType.Time:
                            yield return new TimeAnswer(tq, answer);
                            break;
                        case TextQuestionType.DateTime:
                            yield return new DateTimeAnswer(tq, answer);
                            break;
                        case TextQuestionType.PhoneNumber:
                            yield return new PhoneNumberAnswer(tq, answer);
                            break;
                    }
                    break;
                default:
                    yield break;
            }
        }
    }
}
