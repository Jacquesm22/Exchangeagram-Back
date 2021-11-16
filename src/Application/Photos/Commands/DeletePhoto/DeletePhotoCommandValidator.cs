using FluentValidation;
using System;

namespace ExchangeAGram.Application.Photo.Commands.DeletePhoto
{
    public class DeletePhotoCommandValidator : AbstractValidator<DeletePhotoCommand>
    {
        public DeletePhotoCommandValidator()
        {
            RuleFor(f => f.Id).NotNull().WithMessage("Must contain an id");
            RuleFor(f => f.Id).NotEqual(Guid.Empty).WithMessage("Can't be empty");
        }
    }
}
