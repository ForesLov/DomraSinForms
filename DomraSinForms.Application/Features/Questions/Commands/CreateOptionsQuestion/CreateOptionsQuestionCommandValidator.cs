using FluentValidation;

namespace DomraSinForms.Application.Questions.Commands.CreateOptionsQuestion;
public class CreateOptionsQuestionCommandValidator : AbstractValidator<CreateOptionsQuestionCommand>
{
    public CreateOptionsQuestionCommandValidator()
    {
        RuleFor(qo => qo.QuestionText).NotEmpty();
        RuleFor(qo => qo.FormId).NotEmpty();
    }
}
