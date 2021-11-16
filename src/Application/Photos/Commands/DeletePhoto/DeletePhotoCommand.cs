using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ExchangeAGram.Application.Common.Interfaces;
using ExchangeAGram.Application.Common.Models;
using ExchangeAGram.Domain.Entities;
using System.Threading;
using ExchangeAGram.Application.Common.Exceptions;
using ExchangeAGram.Application.Common.Constants;
using ExchangeAGram.Application.Common.Attributes;

namespace ExchangeAGram.Application.Photos.Commands.DeletePhoto
{
    [CustomAuthorize(Roles = Roles.Admin)]
    public class DeletePhotoCommand : IRequest<CommandResult>
    {
        public Guid? Id { get; set; }
    }

    class DeletePhotoCommandHandler : IRequestHandler<DeletePhotoCommand, CommandResult>
    {
        private readonly IApplicationDbContext _context;

        public DeletePhotoCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CommandResult> Handle(DeletePhotoCommand request, CancellationToken cancellationToken)
        {
            var photo = await _context.Photos.FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);
            if (photo == null)
            {
                throw new NotFoundException(nameof(Photo), request.Id);
            }

            _context.Photos.Remove(photo);
            await _context.SaveChangesAsync(cancellationToken);

            return new CommandResult
            {
                Success = true
            };
        }
    }
}
