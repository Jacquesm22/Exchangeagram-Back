using ExchangeAGram.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExchangeAGram.Infrastructure.Persistence.Configurations
{
    public class AlbumPhotoConfig : IEntityTypeConfiguration<AlbumPhoto>
    {
        public void Configure(EntityTypeBuilder<AlbumPhoto> builder)
        {
            builder.HasOne(o => o.Photo).WithMany(m => m.AlbumPhotos).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
