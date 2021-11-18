using FluentValidation;

namespace ExchangeAGram.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(f => f.Email).NotEmpty();
            RuleFor(f => f.Password).NotEmpty();
            RuleFor(f => f.Username).NotEmpty();
        }
    }
}
