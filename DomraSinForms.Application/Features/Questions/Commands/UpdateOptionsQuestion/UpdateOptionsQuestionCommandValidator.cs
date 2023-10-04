using FluentValidation;

namespace DomraSinForms.Application.Features.Questions.Commands.UpdateOptionsQuestion;

public class UpdateOptionsQuestionCommandValidator : AbstractValidator<UpdateOptionsQuestionCommand>
{
    public UpdateOptionsQuestionCommandValidator()
    {
        RuleFor(c => c.Options)
            .NotEmpty();
    }
}