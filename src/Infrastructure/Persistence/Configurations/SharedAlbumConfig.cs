using ExchangeAGram.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExchangeAGram.Infrastructure.Persistence.Configurations
{
    public class SharedAlbumConfig : IEntityTypeConfiguration<SharedAlbum>
    {
        public void Configure(EntityTypeBuilder<SharedAlbum> builder)
        {
            builder.HasOne(o => o.User).WithMany(m => m.SharedAlbums).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
