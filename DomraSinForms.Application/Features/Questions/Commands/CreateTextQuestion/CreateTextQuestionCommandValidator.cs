using FluentValidation;

namespace DomraSinForms.Application.Questions.Commands.CreateTextQuestion;
public class CreateTextQuestionCommandValidator : AbstractValidator<CreateTextQuestionCommand>
{
    public CreateTextQuestionCommandValidator()
    {
        RuleFor(tq => tq.QuestionText).NotEmpty();
        RuleFor(tq => tq.FormId).NotEmpty();
    }
}
