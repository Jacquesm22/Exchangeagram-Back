using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ExchangeAGram.Application.Common.Interfaces;
using ExchangeAGram.Application.Common.Models;
using ExchangeAGram.Domain.Entities;
using System.Threading;
using ExchangeAGram.Application.Common.Exceptions;
using ExchangeAGram.Application.Photos.Dtos;
using ExchangeAGram.Application.Common.Constants;
using ExchangeAGram.Application.Common.Attributes;

namespace ExchangeAGram.Application.Photos.Commands.UpdatePhoto
{
    [CustomAuthorize(Roles = Roles.Admin)]
    public class UpdatePhotoCommand : IRequest<CommandResult>
    {
        public Guid? Id { get; set; }
        public UpdatePhotoDto Dto { get; set; }
    }

    class UpdatePhotoCommandHandler : IRequestHandler<UpdatePhotoCommand, CommandResult>
    {
        private readonly IApplicationDbContext _context;

        public UpdatePhotoCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CommandResult> Handle(UpdatePhotoCommand request, CancellationToken cancellationToken)
        {
            bool duplicatePhoto = await _context.Photos.AnyAsync(a => a.Name.ToLower() == request.Dto.Name.ToLower()
                                                                     && a.Id != request.Id, cancellationToken);

            if (duplicatePhoto)
            {
                return new CommandResult
                {
                    Message = "Photo already exists",
                    Success = false
                };
            }
            var entity = await _context.Photos.FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Photo), request.Id);
            }

            entity.Name = request.Dto.Name;
            await _context.SaveChangesAsync(cancellationToken);

            return new CommandResult
            {
                Message = "Photo updated",
                Success = true
            };
        }
    }
}
