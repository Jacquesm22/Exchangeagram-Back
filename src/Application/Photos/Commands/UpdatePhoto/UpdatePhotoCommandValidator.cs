using FluentValidation;
using System;

namespace ExchangeAGram.Application.Photos.Commands.UpdatePhoto
{
    public class UpdatePhotoCommandValidator : AbstractValidator<UpdatePhotoCommand>
    {
        public UpdatePhotoCommandValidator()
        {
            RuleFor(f => f.Id).NotNull().WithMessage("Must contain an id");
            RuleFor(f => f.Id).NotEqual(Guid.Empty).WithMessage("Can't be empty");
            RuleFor(f => f.Dto).NotNull().WithMessage("Can't be empty");
            RuleFor(f => f.Dto.Name).NotEmpty().WithMessage("Name is required");
        }
    }
}
