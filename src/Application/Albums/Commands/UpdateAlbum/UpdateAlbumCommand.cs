using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ExchangeAGram.Application.Common.Interfaces;
using ExchangeAGram.Application.Common.Models;
using ExchangeAGram.Domain.Entities;
using System.Threading;
using ExchangeAGram.Application.Common.Exceptions;
using ExchangeAGram.Application.Albums.Dtos;
using ExchangeAGram.Application.Common.Constants;
using ExchangeAGram.Application.Common.Attributes;

namespace ExchangeAGram.Application.Albums.Commands.UpdateAlbum
{
    [CustomAuthorize(Roles = Roles.Admin)]
    public class UpdateAlbumCommand : IRequest<CommandResult>
    {
        public Guid? Id { get; set; }
        public UpdateAlbumDto Dto { get; set; }
    }

    class UpdateAlbumCommandHandler : IRequestHandler<UpdateAlbumCommand, CommandResult>
    {
        private readonly IApplicationDbContext _context;

        public UpdateAlbumCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CommandResult> Handle(UpdateAlbumCommand request, CancellationToken cancellationToken)
        {
            bool duplicateAlbum = await _context.Albums.AnyAsync(a => a.Name.ToLower() == request.Dto.Name.ToLower()
                                                                     && a.Id != request.Id, cancellationToken);

            if (duplicateAlbum)
            {
                return new CommandResult
                {
                    Message = "Album already exists",
                    Success = false
                };
            }
            var entity = await _context.Albums.FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Album), request.Id);
            }

            entity.Name = request.Dto.Name;
            await _context.SaveChangesAsync(cancellationToken);

            return new CommandResult
            {
                Message = "Album updated",
                Success = true
            };
        }
    }
}
