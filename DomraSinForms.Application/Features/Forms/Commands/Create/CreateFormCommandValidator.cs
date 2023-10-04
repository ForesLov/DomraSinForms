using FluentValidation;

namespace DomraSinForms.Application.Features.Forms.Commands.Create;

public class CreateFormCommandValidator : AbstractValidator<CreateFormCommand>
{
    public CreateFormCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.CreatorId).NotEmpty();
    }
}