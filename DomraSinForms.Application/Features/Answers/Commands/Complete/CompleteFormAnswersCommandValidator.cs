using FluentValidation;

namespace DomraSinForms.Application.Features.Answers.Commands.Complete;

public class CompleteFormAnswersCommandValidator : AbstractValidator<CompleteFormAnswersCommand>
{
    public CompleteFormAnswersCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.FormId).NotEmpty();
    }
}