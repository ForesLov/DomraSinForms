using FluentValidation;

namespace DomraSinForms.Application.Features.Answers.Commands.Create;

public class CreateFormAnswersCommandValidator : AbstractValidator<CreateFormAnswersCommand>
{
    public CreateFormAnswersCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.FormId).NotEmpty();
    }
}