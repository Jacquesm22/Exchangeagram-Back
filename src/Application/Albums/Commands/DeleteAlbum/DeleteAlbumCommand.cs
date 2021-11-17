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

namespace ExchangeAGram.Application.Albums.Commands.DeleteAlbum
{
    [CustomAuthorize(Roles = Roles.Admin)]
    public class DeleteAlbumCommand : IRequest<CommandResult>
    {
        public Guid? Id { get; set; }
    }

    class DeleteAlbumCommandHandler : IRequestHandler<DeleteAlbumCommand, CommandResult>
    {
        private readonly IApplicationDbContext _context;

        public DeleteAlbumCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CommandResult> Handle(DeleteAlbumCommand request, CancellationToken cancellationToken)
        {
            var album = await _context.Albums.FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);
            if (album == null)
            {
                throw new NotFoundException(nameof(Album), request.Id);
            }

            _context.Albums.Remove(album);
            await _context.SaveChangesAsync(cancellationToken);

            return new CommandResult
            {
                Success = true
            };
        }
    }
}
