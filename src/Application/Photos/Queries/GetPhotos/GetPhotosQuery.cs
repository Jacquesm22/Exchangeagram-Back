using ExchangeAGram.Application.Common.Interfaces;
using ExchangeAGram.Application.Photos.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExchangeAGram.Application.Photos.Queries.GetPhotos
{
    public class GetPhotosQuery : IRequest<IList<GetPhotosDto>>
    {
        public bool CurrentUser { get; set; }
    }

    class GetPhotosQueryHandler : IRequestHandler<GetPhotosQuery, IList<GetPhotosDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public GetPhotosQueryHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<IList<GetPhotosDto>> Handle(GetPhotosQuery request, CancellationToken cancellationToken)
        {
            var photos = new List<GetPhotosDto>();

            if (request.CurrentUser)
            {
                photos = await _context.Photos.Where(w => w.UserId.ToString() == _currentUserService.UserId).OrderByDescending(o => o.Created).Select(s => new GetPhotosDto
                {
                    Id = s.Id,
                    Date = s.Created,
                    User = s.User.Username,
                    Name = s.Name
                }).ToListAsync(cancellationToken);
            }
            else 
            {
                photos = await _context.Photos.OrderByDescending(o => o.Created).Select(s => new GetPhotosDto
                {
                    Id = s.Id,
                    Date = s.Created,
                    User = s.User.Username,
                    Name = s.Name
                }).ToListAsync(cancellationToken);
            }

            return photos;
        }
    }
}
