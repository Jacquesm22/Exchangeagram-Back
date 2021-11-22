using FluentValidation;

namespace ExchangeAGram.Application.Photos.Commands.UploadPhoto
{
    public class UploadPhotoCommandValidator : AbstractValidator<UploadPhotoCommand>
    {
        public UploadPhotoCommandValidator()
        {
            RuleFor(f => f.FileName).NotEmpty();
            RuleFor(f => f.FileBytes).NotNull();
            RuleFor(f => f.FileBytes).NotEmpty().When(w => w.FileBytes != null);
        }
    }
}
