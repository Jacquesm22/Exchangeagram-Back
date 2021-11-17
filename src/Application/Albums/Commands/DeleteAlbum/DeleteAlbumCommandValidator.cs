using FluentValidation;
using System;

namespace ExchangeAGram.Application.Album.Commands.DeleteAlbum
{
    public class DeleteAlbumCommandValidator : AbstractValidator<DeleteAlbumCommand>
    {
        public DeleteAlbumCommandValidator()
        {
            RuleFor(f => f.Id).NotNull().WithMessage("Must contain an id");
            RuleFor(f => f.Id).NotEqual(Guid.Empty).WithMessage("Can't be empty");
        }
    }
}
