using Microsoft.EntityFrameworkCore;
using ExchangeAGram.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace ExchangeAGram.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Photo> Photos { get; set; }
        DbSet<Meta> Metas { get; set; }
        DbSet<SharedPhoto> SharedPhotos { get; set; }
        DbSet<AlbumPhoto> AlbumPhotos { get; set; }
        DbSet<Album> Albums { get; set; }
        DbSet<SharedAlbum> SharedAlbums { get; set; }
        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
