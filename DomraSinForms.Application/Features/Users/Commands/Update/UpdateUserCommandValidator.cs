using FluentValidation;

namespace DomraSinForms.Application.Features.Users.Commands.Update;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(command => command.Email).NotEmpty().EmailAddress();
        RuleFor(command => command.Username).NotEmpty().Matches(@"[A-Za-z\d]+");
    }
}