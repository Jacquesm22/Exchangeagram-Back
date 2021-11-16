using FluentValidation;

namespace ExchangeAGram.Application.Photos.Commands.AddPhoto
{
    public class AddPhotoCommandValidator : AbstractValidator<AddPhotoCommand>
    {
        public AddPhotoCommandValidator()
        {
            RuleFor(f => f.Name).NotEmpty().WithMessage("name is required.");
        }
    }
}
