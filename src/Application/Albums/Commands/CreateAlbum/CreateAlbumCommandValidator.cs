using FluentValidation;

namespace ExchangeAGram.Application.Albums.Commands.AddAlbum
{
    public class AddAlbumCommandValidator : AbstractValidator<AddAlbumCommand>
    {
        public AddAlbumCommandValidator()
        {
            RuleFor(f => f.Name).NotEmpty().WithMessage("name is required.");
        }
    }
}
