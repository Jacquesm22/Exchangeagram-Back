using MediatR;
using Microsoft.EntityFrameworkCore;
using ExchangeAGram.Application.Photos.Dtos;
using ExchangeAGram.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExchangeAGram.Application.Photos.Queries.GetPhotos
{
    public class GetClientsQuery : IRequest<IList<GetPhotoDto>>
    {
    }

    class GetPhotoQueryHandler : IRequestHandler<GetPhotosQuery, IList<GetPhotoDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetPhotoQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<GetPhotoDto>> Handle(GetPhotosQuery request, CancellationToken cancellationToken)
        {
            var photos = await _context.Photos.AsNoTracking().Select(s => new GetPhotoDto
            {
                Id = s.Id,
                Name = s.Name,
                Size = s.Size,
                Path = s.Path,
                Extension = s.Extension,
                CreatedDate = s.CreatedDate,
                UpdatedDate = s.UpdatedDate,
            })
            .ToListAsync(cancellationToken);

            return photos;
        }
    }
}
