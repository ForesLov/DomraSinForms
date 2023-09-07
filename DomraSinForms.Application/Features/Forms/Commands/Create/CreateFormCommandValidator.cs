using FluentValidation;

namespace DomraSinForms.Application.Forms.Commands.Create;
public class CreateFormCommandValidator : AbstractValidator<CreateFormCommand>
{
    public CreateFormCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.CreatorId).NotEmpty();
    }
}
