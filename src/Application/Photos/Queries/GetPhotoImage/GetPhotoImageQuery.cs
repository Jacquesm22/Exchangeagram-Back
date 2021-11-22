using ExchangeAGram.Application.Common.Exceptions;
using ExchangeAGram.Application.Common.Interfaces;
using ExchangeAGram.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ExchangeAGram.Application.Photos.Queries.GetPhotoImage
{
    public class GetPhotoImageQuery : IRequest<byte[]>
    {
        public Guid PhotoId { get; set; }
    }

    class GetPhotoImageQueryHandler : IRequestHandler<GetPhotoImageQuery, byte[]>
    {
        private readonly IApplicationDbContext _context;
        private readonly ISystemFileService _systemFileService;

        public GetPhotoImageQueryHandler(IApplicationDbContext context, ISystemFileService systemFileService)
        {
            _context = context;
            _systemFileService = systemFileService;
        }

        public async Task<byte[]> Handle(GetPhotoImageQuery request, CancellationToken cancellationToken)
        {
            var photo = await _context.Photos.FirstOrDefaultAsync(f => f.Id == request.PhotoId, cancellationToken);
            if (photo == null) 
            {
                throw new NotFoundException(nameof(Photo), request.PhotoId);
            }

            var image = _systemFileService.GetSystemFile(photo.Path);
            return image;
        }
    }
}
