using MediatR;
using Microsoft.EntityFrameworkCore;
using ExchangeAGram.Application.Albums.Dtos;
using ExchangeAGram.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExchangeAGram.Application.Albums.Queries.GetAlbums
{
    //public class GetClientsQuery : IRequest<IList<GetAlbumDto>>
    //{
    //}

    //class GetAlbumQueryHandler : IRequestHandler<GetAlbumsQuery, IList<GetAlbumDto>>
    //{
    //    private readonly IApplicationDbContext _context;

    //    public GetAlbumQueryHandler(IApplicationDbContext context)
    //    {
    //        _context = context;
    //    }

    //    public async Task<IList<GetAlbumDto>> Handle(GetAlbumsQuery request, CancellationToken cancellationToken)
    //    {
    //        var albums = await _context.Albums.AsNoTracking().Select(s => new GetAlbumDto
    //        {
    //            Id = s.Id,
    //            Name = s.Name,
    //            CreatedDate = s.CreatedDate,
    //            UpdatedDate = s.UpdatedDate,
    //        })
    //        .ToListAsync(cancellationToken);

    //        return albums;
    //    }
    //}
}
