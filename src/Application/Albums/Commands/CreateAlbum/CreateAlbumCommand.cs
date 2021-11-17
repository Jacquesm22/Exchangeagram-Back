using MediatR;
using Microsoft.EntityFrameworkCore;
using ExchangeAGram.Application.Common.Attributes;
using ExchangeAGram.Application.Common.Constants;
using ExchangeAGram.Application.Common.Interfaces;
using ExchangeAGram.Application.Common.Models;
using ExchangeAGram.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace ExchangeAGram.Application.Albums.Commands.AddAlbum
{
    [CustomAuthorize(Roles = Roles.Admin)]
    public class AddAlbumCommand : IRequest<CommandResult>
    {
        public string Name { get; set; }
    }

    class AddAlbumCommandHandler : IRequestHandler<AddAlbumCommand, CommandResult>
    {
        private readonly IApplicationDbContext _context;

        public AddAlbumCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CommandResult> Handle(AddAlbumCommand request, CancellationToken cancellationToken)
        {
            bool duplicateAlbum = await _context.Albums.AnyAsync(a => a.Name.ToLower() == request.Name.ToLower(), cancellationToken);

            if (duplicateAlbum)
            {
                return new CommandResult
                {
                    Message = "Album already exists",
                    Success = false
                };
            }

            var newAlbum = new Album
            {
                Name = request.Name
            };

            await _context.Albums.AddAsync(newAlbum, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new CommandResult
            {
                Data = newAlbum.Id,
                Message = "Album created",
                Success = true
            };
        }
    }
}
